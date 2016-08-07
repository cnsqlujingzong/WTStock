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

public partial class Headquarters_Basic_VisitAdd : Page, IRequiresSessionState
{

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
				if (!dALRight.GetRight(num, "jc_r20"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.AddDetail();
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
					visitResultInfo.Result = gridViewSource.Rows[i]["_Name"].ToString();
					visitResultInfo.Rewards = decimal.Parse(gridViewSource.Rows[i]["dMoney"].ToString());
					visitResultInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					list.Add(visitResultInfo);
				}
			}
			visitContentInfo.VisitResultInfos = list;
		}
		DALVisitContent dALVisitContent = new DALVisitContent();
		string str;
		int num2;
		int num = dALVisitContent.Add(visitContentInfo, out str, out num2);
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
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
