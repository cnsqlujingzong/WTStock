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
using Wuqi.Webdiyer;

public partial class Headquarters_Stat_MaterialDeByGoods : Page, IRequiresSessionState
{
	private int pageSize = 25;

	private string dateStart;

	private string dateEnd;

	private string branchID;

	private string value;

	private decimal getcount = 0m;

	private decimal backcount = 0m;

	private decimal wastecount = 0m;

	private decimal balancecount = 0m;

	private decimal totalgetcount = 0m;

	private decimal totalbackcount = 0m;

	private decimal totalwastecount = 0m;

	private decimal totalbalancecount = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.FillData("");
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		string sWhere = " and " + this.hfSql.Value;
		this.FillData(sWhere);
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = "";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DeptID = " + this.ddlBranch.SelectedValue;
		}
		if (this.tbCon.Text.Trim() != "")
		{
			if (this.ddlKey.SelectedValue == "_Name")
			{
				text = text + " and _Name like '%" + this.tbCon.Text.Trim() + "%'";
			}
			else if (this.ddlKey.SelectedValue == "GoodsNO")
			{
				text = text + " and GoodsNO like '%" + this.tbCon.Text.Trim() + "%'";
			}
			else if (this.ddlKey.SelectedValue == "StockName")
			{
				text = text + " and StockName = '" + this.tbCon.Text.Trim() + "'";
			}
			else
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and _Name like '%",
					this.tbCon.Text.Trim(),
					"%' and GoodsNO like '%",
					this.tbCon.Text.Trim(),
					"%' "
				});
			}
		}
		this.FillData(text);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
	}

	protected void FillData(string sWhere)
	{
		DALBroughtBack dALBroughtBack = new DALBroughtBack();
		string text = sWhere;
		sWhere = string.Concat(new string[]
		{
			text,
			" and ChkDate between '",
			this.tbDateB.Text,
			"' and '",
			this.tbDateE.Text,
			" 23:59:59 '"
		});
		string sWhere2 = " 1 = 1 " + sWhere;
		this.hfSql.Value = sWhere2;
		DataTable dataTable = dALBroughtBack.SchStockCount(sWhere2).Tables[0];
		this.gvdata.DataSource = dataTable;
		this.gvdata.DataBind();
		this.lbCount.Text = dataTable.Rows.Count.ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
			this.lbCountText.Text = "无商品信息";
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
			this.lbCountText.Visible = true;
		}
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		this.dateStart = this.tbDateB.Text;
		this.dateEnd = this.tbDateE.Text;
		this.branchID = this.ddlBranch.SelectedValue;
		this.value = string.Concat(new string[]
		{
			this.dateStart,
			",",
			this.dateEnd,
			",",
			this.branchID
		});
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text + "," + e.Row.Cells[2].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				",",
				e.Row.Cells[2].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ChkMod(870, 525,'Stat/BroughBackSellDe.aspx?v=" + this.value + "','详细信息');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[6].Text, out this.getcount);
			this.totalgetcount += this.getcount;
			decimal.TryParse(e.Row.Cells[8].Text, out this.backcount);
			this.totalbackcount += this.backcount;
			decimal.TryParse(e.Row.Cells[10].Text, out this.wastecount);
			this.totalwastecount += this.wastecount;
			decimal.TryParse(e.Row.Cells[12].Text, out this.balancecount);
			this.totalbalancecount += this.balancecount;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[6].Text = this.totalgetcount.ToString("#0.00");
			e.Row.Cells[8].Text = this.totalbackcount.ToString("#0.00");
			e.Row.Cells[10].Text = this.totalwastecount.ToString("#0.00");
			e.Row.Cells[12].Text = this.totalbalancecount.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DALBroughtBack dALBroughtBack = new DALBroughtBack();
		string sWhere = this.hfSql.Value;
		DataTable dt = dALBroughtBack.ExecStockCount(sWhere).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "备件明细汇总", out flag, out empty);
		if (!flag)
		{
			this.FillData("");
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
