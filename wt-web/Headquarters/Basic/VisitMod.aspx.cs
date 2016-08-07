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

public partial class Headquarters_Basic_VisitMod : Page, IRequiresSessionState
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
				dataTable.Columns.Add(new DataColumn("dMoney", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
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
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r20"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DALVisitContent dALVisitContent = new DALVisitContent();
			VisitContentInfo model = dALVisitContent.GetModel(this.id);
			if (model != null)
			{
				this.tbName.Text = model.Content;
				this.tbRemark.Text = model.Remark;
				this.cbbStop.Checked = model.bStop;
				DataTable dataTable = DALCommon.GetList("VisitResult", "*", "ContentID=" + this.id.ToString()).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					DataTable gridViewSource = this.GridViewSource;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["Result"];
						dataRow[1] = decimal.Parse(dataTable.Rows[i]["Rewards"].ToString());
						dataRow[2] = dataTable.Rows[i]["Remark"];
						dataRow[3] = dataTable.Rows[i]["ID"];
						dataRow[4] = 1;
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
		dataRow[2] = "";
		dataRow[3] = 0;
		dataRow[4] = 0;
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
		VisitContentInfo visitContentInfo = new VisitContentInfo();
		visitContentInfo.ID = this.id;
		visitContentInfo.Content = FunLibrary.ChkInput(this.tbName.Text);
		visitContentInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<VisitResultInfo> list = new List<VisitResultInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				VisitResultInfo visitResultInfo = new VisitResultInfo();
				if (gridViewSource.Rows[i]["_Name"].ToString() != string.Empty)
				{
					visitResultInfo.ID = int.Parse(gridViewSource.Rows[i]["ID"].ToString());
					visitResultInfo.Result = gridViewSource.Rows[i]["_Name"].ToString();
					visitResultInfo.Rewards = decimal.Parse(gridViewSource.Rows[i]["dMoney"].ToString());
					visitResultInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					list.Add(visitResultInfo);
				}
			}
			visitContentInfo.VisitResultInfos = list;
		}
		List<string> list2 = new List<string>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(this.hfdellist.Value);
		}
		if (this.cbbStop.Checked)
		{
			visitContentInfo.bStop = true;
		}
		else
		{
			visitContentInfo.bStop = false;
		}
		DALVisitContent dALVisitContent = new DALVisitContent();
		string str;
		int num = dALVisitContent.Update(visitContentInfo, list2, out str);
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
		decimal num = 0m;
		for (int i = 0; i < this.GridView1.Rows.Count; i++)
		{
			TextBox textBox = this.GridView1.Rows[i].FindControl("txtName") as TextBox;
			TextBox textBox2 = this.GridView1.Rows[i].FindControl("txtMoney") as TextBox;
			TextBox textBox3 = this.GridView1.Rows[i].FindControl("txtRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i][0] = FunLibrary.ChkInput(textBox.Text);
			decimal.TryParse(textBox2.Text, out num);
			gridViewSource.Rows[i][1] = num;
			gridViewSource.Rows[i][2] = FunLibrary.ChkInput(textBox3.Text);
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
			e.Row.Cells[4].Attributes.Add("style", "width:30px;padding-right:0px;vertical-align:middle;");
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

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
