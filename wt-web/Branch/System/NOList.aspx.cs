using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;

public partial class Branch_System_NOList : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPurB"] != "系统管理员")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=NOSet");
				base.Response.End();
			}
			this.DataFill();
		}
	}

	public void DataFill()
	{
		this.GridView1.DataSource = DALCommon.GetDataList("NOPlan", "", string.Format("ID like '__{0}%'", this.Session["Session_wtBranchID"].ToString().Trim())).Tables[0];
		this.GridView1.DataBind();
	}

	protected void btnRef_Click(object sender, EventArgs e)
	{
		this.DataFill();
		if (this.hfRecID.Value != "-1")
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "ChkID('" + this.hfRecID.Value + "');", true);
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "EidtNO();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}
}
