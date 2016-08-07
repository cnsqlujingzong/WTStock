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
using wt.OtherLibrary;

public partial class Headquarters_Stat_StServiceDay : Page, IRequiresSessionState
{
	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

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
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r28"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
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
		string strStart = FunLibrary.ChkInput(this.tbDateB.Text);
		string strEnd = FunLibrary.ChkInput(this.tbDateE.Text);
		string text = "";
		string strCondition = "";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		this.gvdata.DataSource = DALCommon.GetStMKBB("tj_fw_report", 0, strStart, strEnd, text, strCondition);
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
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			decimal.TryParse(e.Row.Cells[2].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[3].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[4].Text, out this.dtest);
			this.dr3 += this.dtest;
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
			cells[1].RowSpan = 2;
			cells[1].Text = "业务日期";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 5;
			cells[2].Text = "客付费用";
			cells.Add(new TableHeaderCell());
			cells[3].ColumnSpan = 3;
			cells[3].Text = "成本";
			cells.Add(new TableHeaderCell());
			cells[4].RowSpan = 2;
			cells[4].Text = "营业额";
			cells.Add(new TableHeaderCell());
			cells[5].RowSpan = 2;
			cells[5].Text = "毛利</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[6].Text = "材料费";
			cells.Add(new TableHeaderCell());
			cells[7].Text = "人工费";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "附加费";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "优惠金额";
			cells.Add(new TableHeaderCell());
			cells[10].Text = "合计";
			cells.Add(new TableHeaderCell());
			cells[11].Text = "材料成本";
			cells.Add(new TableHeaderCell());
			cells[12].Text = "额外成本";
			cells.Add(new TableHeaderCell());
			cells[13].Text = "送修成本</th></tr><tr>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[2].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[3].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[4].Text = this.dr3.ToString("#0.00");
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
		string strStart = FunLibrary.ChkInput(this.tbDateB.Text);
		string strEnd = FunLibrary.ChkInput(this.tbDateE.Text);
		string text = "";
		string strCondition = "";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		DataTable dt = DALCommon.GetStMKBB("tj_fw_report", 0, strStart, strEnd, text, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "服务日报表", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
