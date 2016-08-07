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

public partial class Branch_Stat_StCusValueList : Page, IRequiresSessionState
{
	

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dr6 = 0m;

	private decimal dr7 = 0m;

	private decimal dr8 = 0m;

	private decimal dr9 = 0m;

	private decimal dr10 = 0m;

	private decimal dtest = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r47"))
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
		string text5 = "";
		string text6 = "";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and a.DisposalID=" + this.ddlBranch.SelectedValue;
			text4 = text4 + " and a.DeptID=" + this.ddlBranch.SelectedValue;
			text5 = text5 + " and a.DeptID=" + this.ddlBranch.SelectedValue;
			text6 = text6 + " and a.DeptID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and convert(char(10),Time_Close,120)>='" + text + "'";
			text4 = text4 + " and convert(char(10),ChkDate,120)>='" + text + "'";
			text5 = text5 + " and convert(char(10),_Date,120)>='" + text + "'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and convert(char(10),Time_Close,120)<='" + text2 + " 23:59:59'";
			text4 = text4 + " and convert(char(10),ChkDate,120)<='" + text2 + " 23:59:59'";
			text5 = text5 + " and convert(char(10),_Date,120)<='" + text2 + " 23:59:59'";
		}
		this.gvdata.DataSource = DALCommon.GetStMKBB("tj_kh_report", 0, text, text2, text3, text4, text5, text6);
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtest);
			this.dr4 += this.dtest;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dr5 += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dr6 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dr7 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dr8 += this.dtest;
			decimal.TryParse(e.Row.Cells[10].Text, out this.dtest);
			this.dr9 += this.dtest;
			decimal.TryParse(e.Row.Cells[11].Text, out this.dtest);
			this.dr10 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "序";
			cells.Add(new TableHeaderCell());
			cells[1].ColumnSpan = 4;
			cells[1].Text = "客户";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 2;
			cells[2].Text = "服务";
			cells.Add(new TableHeaderCell());
			cells[3].ColumnSpan = 2;
			cells[3].Text = "销售";
			cells.Add(new TableHeaderCell());
			cells[4].RowSpan = 2;
			cells[4].Text = "租赁金额";
			cells.Add(new TableHeaderCell());
			cells[5].ColumnSpan = 2;
			cells[5].Text = "合计</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[6].Text = "名称";
			cells.Add(new TableHeaderCell());
			cells[7].Text = "联系人";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "联系电话";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "业务员";
			cells.Add(new TableHeaderCell());
			cells[10].Text = "金额";
			cells.Add(new TableHeaderCell());
			cells[11].Text = "毛利";
			cells.Add(new TableHeaderCell());
			cells[12].Text = "金额";
			cells.Add(new TableHeaderCell());
			cells[13].Text = "毛利";
			cells.Add(new TableHeaderCell());
			cells[14].Text = "金额";
			cells.Add(new TableHeaderCell());
			cells[15].Text = "毛利</th></tr><tr>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[5].Text = this.dr4.ToString("#0.00");
			e.Row.Cells[6].Text = this.dr5.ToString("#0.00");
			e.Row.Cells[7].Text = this.dr6.ToString("#0.00");
			e.Row.Cells[8].Text = this.dr7.ToString("#0.00");
			e.Row.Cells[9].Text = this.dr8.ToString("#0.00");
			e.Row.Cells[10].Text = this.dr9.ToString("#0.00");
			e.Row.Cells[11].Text = this.dr10.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and a.DisposalID=" + this.ddlBranch.SelectedValue;
			text4 = text4 + " and a.DeptID=" + this.ddlBranch.SelectedValue;
			text5 = text5 + " and a.DeptID=" + this.ddlBranch.SelectedValue;
			text6 = text6 + " and a.DeptID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and convert(char(10),Time_Close,120)>='" + text + "'";
			text4 = text4 + " and convert(char(10),ChkDate,120)>='" + text + "'";
			text5 = text5 + " and convert(char(10),_Date,120)>='" + text + "'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and convert(char(10),Time_Close,120)<='" + text2 + " 23:59:59'";
			text4 = text4 + " and convert(char(10),ChkDate,120)<='" + text2 + " 23:59:59'";
			text5 = text5 + " and convert(char(10),_Date,120)<='" + text2 + " 23:59:59'";
		}
		DataTable dt = DALCommon.GetStMKBB("tj_kh_report", 0, text, text2, text3, text4, text5, text6).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "客户价值排行", out flag, out empty);
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
