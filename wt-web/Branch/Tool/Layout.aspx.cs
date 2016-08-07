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

public partial class Branch_Tool_Layout : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPurB"] != "系统管理员")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=Right");
				base.Response.End();
			}
			this.LoadClass();
			this.FillData();
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "LayoutClass", "", 0, 0, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bSys=0 ", " ID Asc", out num).Tables[0];
		this.tv.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.tv.Nodes.Add(treeNode);
		this.InitFirst(dt, treeNode);
		this.tv.Nodes[0].Selected = true;
	}

	public void FillData()
	{
		string text = " DeptID=" + (string)this.Session["Session_wtBranchID"];
		int classID = 1;
		if (this.hfClass.Value != "-1" && this.hfClass.Value != "")
		{
			text = text + " and ClassID=" + this.hfClass.Value;
			classID = int.Parse(this.hfClass.Value);
		}
		this.gvuser.DataSource = DALCommon.GetDataList("xt_layoutuser", "", text);
		this.gvuser.DataBind();
		DALSys dALSys = new DALSys();
		if (this.ddlWinName.SelectedValue == "14")
		{
			DataTable dataTable = dALSys.GetLayoutDetail(0, int.Parse((string)this.Session["Session_wtBranchID"]), int.Parse(this.ddlWinName.SelectedValue), classID, 0).Tables[0];
			DataRow[] array = dataTable.Select("FieldName='CancelReason'");
			if (array.Length == 0)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = 0;
				dataRow[1] = 1;
				dataRow[2] = 1;
				dataRow[3] = 14;
				dataRow[4] = "取消原因";
				dataRow[5] = "CancelReason";
				dataRow[6] = 56;
				dataRow[7] = true;
				dataTable.Rows.Add(dataRow);
			}
			array = dataTable.Select("FieldName='bCall'");
			if (array.Length == 0)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = 0;
				dataRow[1] = 1;
				dataRow[2] = 1;
				dataRow[3] = 14;
				dataRow[4] = "回访";
				dataRow[5] = "bCall";
				dataRow[6] = 57;
				dataRow[7] = true;
				dataTable.Rows.Add(dataRow);
			}
			this.GridView1.DataSource = dataTable;
			this.GridView1.DataBind();
		}
		else
		{
			this.GridView1.DataSource = dALSys.GetLayoutDetail(0, int.Parse((string)this.Session["Session_wtBranchID"]), int.Parse(this.ddlWinName.SelectedValue), classID, 0).Tables[0];
			this.GridView1.DataBind();
		}
	}

	protected void InitFirst(DataTable dt, TreeNode menu)
	{
		if (!dt.Rows.Count.Equals(0))
		{
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Text = dt.Rows[i]["_Name"].ToString();
				treeNode.Value = dt.Rows[i]["ID"].ToString();
				menu.ChildNodes.Add(treeNode);
			}
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData();
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void tv_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.hfClass.Value = this.tv.SelectedNode.Value;
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void gvuser_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[0].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnBackDefault_Click(object sender, EventArgs e)
	{
		int num = 1;
		int.TryParse(this.hfClass.Value, out num);
		if (num <= 0)
		{
			this.SysInfo3("window.alert('恢复失败！请选择要恢复的布局分类');");
		}
		else
		{
			string empty = string.Empty;
			int num2 = DALCommon.DeteleData("LayoutDetail", string.Concat(new string[]
			{
				" DeptID=",
				(string)this.Session["Session_wtBranchID"],
				" and ClassID=",
				this.hfClass.Value,
				" and WinName=",
				this.ddlWinName.SelectedValue
			}), out empty);
			if (num2 == 0)
			{
				this.SysInfo3("window.alert('恢复成功！');");
			}
			else if (num2 == -1)
			{
				this.SysInfo3("window.alert('" + empty + "');");
			}
			else
			{
				this.SysInfo3("window.alert('系统错误！请查看错误日志');");
			}
			this.FillData();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("LayoutUser", "[ID]=" + this.hfRecID.Value, out empty);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.FillData();
	}

	protected void ddlWinName_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[3].Visible = (e.Row.Cells[4].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "padding-right:10px;");
			e.Row.Cells[1].Attributes.Add("style", "padding-right:10px;");
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		int num = 1;
		int.TryParse(this.hfClass.Value, out num);
		if (num <= 0)
		{
			this.SysInfo3("window.alert('操作失败！请选择布局分类');");
		}
		else
		{
			DALSys dALSys = new DALSys();
			DataTable dataTable = DALCommon.GetDataList("LayoutDetail", "ID", string.Concat(new string[]
			{
				" DeptID=",
				(string)this.Session["Session_wtBranchID"],
				" and ClassID=",
				num.ToString(),
				" and WinName=",
				this.ddlWinName.SelectedValue
			})).Tables[0];
			LayoutDetailInfo layoutDetailInfo = new LayoutDetailInfo();
			List<LayoutDetailInfos> list = new List<LayoutDetailInfos>();
			for (int i = 0; i < this.GridView1.Rows.Count; i++)
			{
				TextBox textBox = this.GridView1.Rows[i].FindControl("tbName") as TextBox;
				TextBox textBox2 = this.GridView1.Rows[i].FindControl("tbOrder") as TextBox;
				CheckBox checkBox = this.GridView1.Rows[i].FindControl("cbbShow") as CheckBox;
				int order;
				int.TryParse(textBox2.Text, out order);
				LayoutDetailInfos layoutDetailInfos = new LayoutDetailInfos();
				layoutDetailInfos.DeptID = int.Parse((string)this.Session["Session_wtBranchID"]);
				layoutDetailInfos.ClassID = num;
				layoutDetailInfos.WinName = int.Parse(this.ddlWinName.SelectedValue);
				layoutDetailInfos.TitleName = FunLibrary.ChkInput(textBox.Text);
				layoutDetailInfos.FieldName = this.GridView1.Rows[i].Cells[4].Text;
				layoutDetailInfos._Order = order;
				layoutDetailInfos.bShow = checkBox.Checked;
				int iD = 0;
				if (dataTable.Rows.Count > 0)
				{
					int.TryParse(this.GridView1.Rows[i].Cells[3].Text, out iD);
				}
				layoutDetailInfos.ID = iD;
				list.Add(layoutDetailInfos);
			}
			layoutDetailInfo.LayoutDetailInfoss = list;
			string str = "";
			int num2 = dALSys.AddLayout(layoutDetailInfo, out str);
			if (num2 == 0)
			{
				this.FillData();
				this.SysInfo3("window.alert('操作成功！表格布局已保存');");
			}
			else
			{
				this.SysInfo3("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected void SysInfo3(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.UpdatePanel3.GetType(), "SysInfo", str, true);
	}
}
