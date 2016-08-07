using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Headquarters_Basic_TroubleMod : Page, IRequiresSessionState
{

	private int id;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r17"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindRepairClass(this.ddlRepair);
			this.slTroubClass.Items.Add(new ListItem("", ""));
			int num2 = 0;
			DataTable dt = DALCommon.GetList_HL(0, "TroubleClass", "", 1, 1, "", " ID Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slTroubClass);
			DALTroubleList dALTroubleList = new DALTroubleList();
			TroubleListInfo model = dALTroubleList.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Value == model.ProductClassID.ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlRepair.Items.Count; i++)
				{
					if (this.ddlRepair.Items[i].Value == model.RepairClassID.ToString())
					{
						this.ddlRepair.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.slTroubClass.Items.Count; i++)
				{
					if (this.slTroubClass.Items[i].Value == model.TroubleClassID.ToString())
					{
						this.slTroubClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbTroubClass.Value = model.TroubleClass;
				this.hfTemp.Value = (this.tbTroubleNO.Text = model.TroubleNO);
				this.tbName.Text = model.Summary;
				this.tbScore.Text = model.Score.ToString();
				DataTable dataTable = DALCommon.GetList("TakeSteps", "*", "TroubleID=" + this.id.ToString()).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					DataTable gridViewSource = this.GridViewSource;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["Summary"];
						dataRow[1] = dataTable.Rows[i]["ID"];
						dataRow[2] = 1;
						gridViewSource.Rows.Add(dataRow);
					}
					this.GridViewSource = gridViewSource;
					this.BindData();
				}
				else
				{
					this.AddDetail();
				}
			}
		}
	}

	protected void AddDetail()
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		dataRow[1] = 0;
		dataRow[2] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void btnAddTake_Click(object sender, EventArgs e)
	{
		this.AddDetail();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		TroubleListInfo troubleListInfo = new TroubleListInfo();
		troubleListInfo.ID = this.id;
		troubleListInfo.ProductClassID = new int?(int.Parse(this.ddlClass.SelectedValue));
		troubleListInfo.RepairClassID = new int?(int.Parse(this.ddlRepair.SelectedValue));
		troubleListInfo.TroubleClassID = new int?(int.Parse(this.slTroubClass.Items[this.slTroubClass.SelectedIndex].Value));
		troubleListInfo.TroubleNO = FunLibrary.ChkInput(this.tbTroubleNO.Text);
		troubleListInfo.Summary = FunLibrary.ChkInput(this.tbName.Text);
		decimal score = 0m;
		decimal.TryParse(this.tbScore.Text, out score);
		troubleListInfo.Score = score;
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<TakeStepsInfo> list = new List<TakeStepsInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				TakeStepsInfo takeStepsInfo = new TakeStepsInfo();
				if (gridViewSource.Rows[i]["_Name"].ToString() != string.Empty || int.Parse(gridViewSource.Rows[i]["iFlag"].ToString()) == 1)
				{
					takeStepsInfo.ID = int.Parse(gridViewSource.Rows[i]["ID"].ToString());
					takeStepsInfo.Summary = gridViewSource.Rows[i]["_Name"].ToString();
					list.Add(takeStepsInfo);
				}
			}
			troubleListInfo.TakeStepsInfos = list;
		}
		bool bsys = false;
		string chkfld = string.Empty;
		if (troubleListInfo.TroubleNO != this.hfTemp.Value)
		{
			if (this.cbsys.Checked)
			{
				bsys = true;
			}
			else
			{
				chkfld = " TroubleNO='" + troubleListInfo.TroubleNO + "'";
			}
		}
		List<string> list2 = new List<string>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(this.hfdellist.Value);
		}
		DALTroubleList dALTroubleList = new DALTroubleList();
		string str;
		int num = dALTroubleList.Update(troubleListInfo, bsys, chkfld, list2, out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + str + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	private void BindData()
	{
		this.GridView1.DataSource = this.GridViewSource;
		this.GridView1.DataBind();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.GridView1.Rows.Count; i++)
		{
			TextBox textBox = this.GridView1.Rows[i].FindControl("txtName") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i][0] = FunLibrary.ChkInput(textBox.Text);
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;vertical-align:middle;");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[1].Attributes.Add("style", "padding-right:5px;");
			e.Row.Cells[2].Attributes.Add("style", "width:30px;padding-right:0px;vertical-align:middle;");
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		DataRow dataRow = this.GridViewSource.Rows[e.RowIndex];
		if (dataRow != null)
		{
			if (int.Parse(dataRow["iFlag"].ToString()) == 1)
			{
				if (this.hfdellist.Value == string.Empty)
				{
					this.hfdellist.Value = dataRow["ID"].ToString();
				}
				else
				{
					HiddenField expr_94 = this.hfdellist;
					expr_94.Value = expr_94.Value + "," + dataRow["ID"].ToString();
				}
			}
		}
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void btnRefClass_Click(object sender, EventArgs e)
	{
		OtherFunction.BindProductClass(this.ddlClass);
		if (this.hfClass.Value != string.Empty)
		{
			this.ddlClass.ClearSelection();
			this.ddlClass.Items.FindByText(this.hfClass.Value).Selected = true;
		}
	}

	protected void btnRefRepair_Click(object sender, EventArgs e)
	{
		OtherFunction.BindRepairClass(this.ddlRepair);
		if (this.hfRepair.Value != string.Empty)
		{
			this.ddlRepair.ClearSelection();
			this.ddlRepair.Items.FindByText(this.hfRepair.Value).Selected = true;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
