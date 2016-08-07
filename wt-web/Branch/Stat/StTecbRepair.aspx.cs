using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Stat_StTecbRepair : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r56"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfOrder.Value != "ID")
		{
			this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
		}
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string text3 = "";
		string text4 = "";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and DisposalID=" + this.ddlBranch.SelectedValue;
			text4 = text4 + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and convert(char(10),Time_Close,120)>='" + text + "'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and convert(char(10),Time_Close,120)<='" + text2 + " 23:59:59'";
		}
		this.gvdata.DataSource = DALCommon.GetStMKBB("tj_fw_report", 8, text, text2, text3, text4);
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			e.Row.Attributes.Add("id", e.Row.Cells[3].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[3].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string text3 = "";
		string text4 = "";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and DisposalID=" + this.ddlBranch.SelectedValue;
			text4 = text4 + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and convert(char(10),Time_Close,120)>='" + text + "'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and convert(char(10),Time_Close,120)<='" + text2 + " 23:59:59'";
		}
		DataTable dt = DALCommon.GetStMKBB("tj_fw_report", 8, text, text2, text3, text4).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "返修汇总表", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
