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

public partial class Headquarters_Basic_TroubleAdd : Page, IRequiresSessionState
{

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
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
			DataTable dt = DALCommon.GetList_HL(0, "TroubleClass", "", 1, 1, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slTroubClass);
			this.tbScore.Text = "0";
			this.AddDetail();
		}
	}

	protected void AddDetail()
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
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
				if (gridViewSource.Rows[i]["_Name"].ToString() != string.Empty)
				{
					takeStepsInfo.Summary = gridViewSource.Rows[i]["_Name"].ToString();
					list.Add(takeStepsInfo);
				}
			}
			troubleListInfo.TakeStepsInfos = list;
		}
		DALTroubleList dALTroubleList = new DALTroubleList();
		string str;
		int num2;
		int num = dALTroubleList.Add(troubleListInfo, this.cbsys.Checked, out str, out num2);
		if (num == 0)
		{
			if (this.cbClose.Checked)
			{
				this.SysInfo("parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("$('tbName').select();");
				this.ClearText();
			}
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

	private void ClearText()
	{
		this.tbName.Text = string.Empty;
		this.GridViewSource.Clear();
		this.BindData();
		this.AddDetail();
		this.BindData();
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
