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

public partial class Branch_Stat_StStock : Page, IRequiresSessionState
{
	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dr6 = 0m;

	private decimal dr7 = 0m;

	private decimal dr8 = 0m;

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
				if (!dALRight.GetRight(num, "tj_r4"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStocks(this.ddlStock, "DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]));
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
		string s = FunLibrary.ChkInput(this.tbDateB.Text);
		string s2 = FunLibrary.ChkInput(this.tbDateE.Text);
		DateTime now = DateTime.Now;
		DateTime now2 = DateTime.Now;
		DateTime.TryParse(s, out now);
		DateTime.TryParse(s2, out now2);
		this.gvdata.DataSource = DALCommon.GetStDayData("tj_ck_hz", int.Parse(this.ddlBranch.SelectedValue), now, now2, int.Parse(this.ddlStock.SelectedValue));
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
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dr3 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dr4 += this.dtest;
			decimal.TryParse(e.Row.Cells[10].Text, out this.dtest);
			this.dr5 += this.dtest;
			decimal.TryParse(e.Row.Cells[11].Text, out this.dtest);
			this.dr6 += this.dtest;
			decimal.TryParse(e.Row.Cells[12].Text, out this.dtest);
			this.dr7 += this.dtest;
			decimal.TryParse(e.Row.Cells[13].Text, out this.dtest);
			this.dr8 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "序";
			cells.Add(new TableHeaderCell());
			cells[1].ColumnSpan = 5;
			cells[1].Text = "产品";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 2;
			cells[2].Text = "期初";
			cells.Add(new TableHeaderCell());
			cells[3].ColumnSpan = 2;
			cells[3].Text = "本期入库";
			cells.Add(new TableHeaderCell());
			cells[4].ColumnSpan = 2;
			cells[4].Text = "本期出库";
			cells.Add(new TableHeaderCell());
			cells[5].ColumnSpan = 2;
			cells[5].Text = "期末</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[6].Text = "编号";
			cells.Add(new TableHeaderCell());
			cells[7].Text = "名称";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "规格";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "属性";
			cells.Add(new TableHeaderCell());
			cells[10].Text = "单位";
			cells.Add(new TableHeaderCell());
			cells[11].Text = "数量";
			cells.Add(new TableHeaderCell());
			cells[12].Text = "金额";
			cells.Add(new TableHeaderCell());
			cells[13].Text = "数量";
			cells.Add(new TableHeaderCell());
			cells[14].Text = "金额";
			cells.Add(new TableHeaderCell());
			cells[15].Text = "数量";
			cells.Add(new TableHeaderCell());
			cells[16].Text = "金额";
			cells.Add(new TableHeaderCell());
			cells[17].Text = "数量";
			cells.Add(new TableHeaderCell());
			cells[18].Text = "金额</th></tr><tr>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[6].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[7].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[8].Text = this.dr3.ToString("#0.00");
			e.Row.Cells[9].Text = this.dr4.ToString("#0.00");
			e.Row.Cells[10].Text = this.dr5.ToString("#0.00");
			e.Row.Cells[11].Text = this.dr6.ToString("#0.00");
			e.Row.Cells[12].Text = this.dr7.ToString("#0.00");
			e.Row.Cells[13].Text = this.dr8.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string s = FunLibrary.ChkInput(this.tbDateB.Text);
		string s2 = FunLibrary.ChkInput(this.tbDateE.Text);
		DateTime now = DateTime.Now;
		DateTime now2 = DateTime.Now;
		DateTime.TryParse(s, out now);
		DateTime.TryParse(s2, out now2);
		DataTable dt = DALCommon.GetStDayData("tj_ck_hz", int.Parse(this.ddlBranch.SelectedValue), now, now2, int.Parse(this.ddlStock.SelectedValue)).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "仓库汇总表", out flag, out empty);
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
