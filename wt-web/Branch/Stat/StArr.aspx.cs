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

public partial class Branch_Stat_StArr : Page, IRequiresSessionState
{
	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dr6 = 0m;

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
				if (!dALRight.GetRight(num, "tj_r40"))
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
			text3 = text3 + " and DeptID=" + this.ddlBranch.SelectedValue;
			text4 = text4 + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and convert(char(10),_Date,120)>='" + text + "'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and convert(char(10),_Date,120)<='" + text2 + " 23:59:59'";
		}
		string text5 = FunLibrary.ChkInput(this.tbCon.Text);
		if (text5 != "")
		{
			text3 = text3 + " and CustomerName like '%" + text5 + "%'";
			text4 = text4 + " and _Name like '%" + text5 + "%'";
		}
		this.gvdata.DataSource = DALCommon.GetStMKBB("tj_zk_report", 5, text, text2, text3, text4);
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			decimal.TryParse(e.Row.Cells[3].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[4].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtest);
			this.dr3 += this.dtest;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dr4 += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dr5 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dr6 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "序";
			cells.Add(new TableHeaderCell());
			cells[1].ColumnSpan = 2;
			cells[1].Text = "单位信息";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 3;
			cells[2].Text = "应收";
			cells.Add(new TableHeaderCell());
			cells[3].ColumnSpan = 3;
			cells[3].Text = "应付</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[4].Text = "单位名称";
			cells.Add(new TableHeaderCell());
			cells[5].Text = "所属";
			cells.Add(new TableHeaderCell());
			cells[6].Text = "总金额";
			cells.Add(new TableHeaderCell());
			cells[7].Text = "已结算金额";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "未结算金额";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "总金额";
			cells.Add(new TableHeaderCell());
			cells[10].Text = "已结算金额";
			cells.Add(new TableHeaderCell());
			cells[11].Text = "未结算金额</th></tr><tr>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[3].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[4].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[5].Text = this.dr3.ToString("#0.00");
			e.Row.Cells[6].Text = this.dr4.ToString("#0.00");
			e.Row.Cells[7].Text = this.dr5.ToString("#0.00");
			e.Row.Cells[8].Text = this.dr6.ToString("#0.00");
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
			text3 = text3 + " and DeptID=" + this.ddlBranch.SelectedValue;
			text4 = text4 + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and convert(char(10),_Date,120)>='" + text + "'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and convert(char(10),_Date,120)<='" + text2 + " 23:59:59'";
		}
		string text5 = FunLibrary.ChkInput(this.tbCon.Text);
		if (text5 != "")
		{
			text3 = text3 + " and CustomerName like '%" + text5 + "%'";
			text4 = text4 + " and _Name like '%" + text5 + "%'";
		}
		DataTable dt = DALCommon.GetStMKBB("tj_zk_report", 5, text, text2, text3, text4).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "arr", out flag, out empty);
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
