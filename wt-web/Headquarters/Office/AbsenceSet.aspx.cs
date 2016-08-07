using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Office_AbsenceSet : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r17"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=d");
					base.Response.End();
				}
			}
			this.GridView1.DataSource = DALCommon.GetDataList("AttendanceTime", "ID,DeptID,Week,CONVERT(varchar(100),WorkTime,8) as WorkTime,CONVERT(varchar(100),AfterWorkTime,8) as AfterWorkTime,Remark", " DeptID=1 ");
			this.GridView1.DataBind();
			this.GridView2.DataSource = DALCommon.GetDataList("LateSet", "", " DeptID=1 ");
			this.GridView2.DataBind();
			this.GridView3.DataSource = DALCommon.GetDataList("AbsenceSet", "", " DeptID=1 ");
			this.GridView3.DataBind();
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('t" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tt" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "Mod1();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnRef1_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.GridView1.DataSource = DALCommon.GetDataList("AttendanceTime", "ID,DeptID,Week,CONVERT(varchar(100),WorkTime,8) as WorkTime,CONVERT(varchar(100),AfterWorkTime,8) as AfterWorkTime,Remark", " DeptID=1 ");
		this.GridView1.DataBind();
	}

	protected void btnDel1_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("AttendanceTime", "[ID]=" + this.hfRecID.Value.Replace("t", ""), out empty);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo1("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo1("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView1.DataSource = DALCommon.GetDataList("AttendanceTime", "ID,DeptID,Week,CONVERT(varchar(100),WorkTime,8) as WorkTime,CONVERT(varchar(100),AfterWorkTime,8) as AfterWorkTime,Remark", " DeptID=1 ");
		this.GridView1.DataBind();
		this.hfRecID.Value = "-1";
	}

	protected void SysInfo1(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "l" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('l" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tl" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "Mod2();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnRef2_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.GridView2.DataSource = DALCommon.GetDataList("LateSet", "", " DeptID=1 ");
		this.GridView2.DataBind();
	}

	protected void btnDel2_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("LateSet", "[ID]=" + this.hfRecID.Value.Replace("l", ""), out empty);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo2("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo2("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView2.DataSource = DALCommon.GetDataList("LateSet", "", " DeptID=1 ");
		this.GridView2.DataBind();
		this.hfRecID.Value = "-1";
	}

	protected void SysInfo2(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('q" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tq" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "Mod3();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnRef3_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.GridView3.DataSource = DALCommon.GetDataList("AbsenceSet", "", " DeptID=1 ");
		this.GridView3.DataBind();
	}

	protected void btnDel3_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("AbsenceSet", "[ID]=" + this.hfRecID.Value.Replace("q", ""), out empty);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo3("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo3("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView3.DataSource = DALCommon.GetDataList("AbsenceSet", "", " DeptID=1 ");
		this.GridView3.DataBind();
		this.hfRecID.Value = "-1";
	}

	protected void SysInfo3(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.UpdatePanel3.GetType(), "SysInfo", str, true);
	}
}
