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

public partial class Branch_Stat_MaterialDeByAppOperator : Page, IRequiresSessionState
{
	private int pageSize = 25;

	private string dateStart;

	private string dateEnd;

	private string branchID;

	private string value;

	private decimal usecount = 0m;

	private decimal getcount = 0m;

	private decimal backcount1 = 0m;

	private decimal backcount2 = 0m;

	private decimal useprice = 0m;

	private decimal totalusecount = 0m;

	private decimal totalgetcount = 0m;

	private decimal totalbackcount1 = 0m;

	private decimal totalbackcount2 = 0m;

	private decimal totaluseAmount = 0m;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			this.ddlBranch.Items.Clear();
			this.ddlBranch.Items.Add(new ListItem(this.Session["Session_wtBranch"].ToString(), this.Session["Session_wtBranchID"].ToString()));
			OtherFunction.BindStaff(this.ddlStaffName, "DeptID =" + this.Session["Session_wtBranchID"].ToString());
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
			else if (this.ddlKey.SelectedValue == "AppOperator")
			{
				text = text + " and AppOperator like '%" + this.tbCon.Text.Trim() + "%'";
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
		string sWhere2 = " DeptID = " + this.Session["Session_wtBranchID"].ToString() + sWhere;
		this.hfSql.Value = sWhere2;
		DataTable dataTable = dALBroughtBack.SchStockCountBy(sWhere2).Tables[0];
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
			decimal.TryParse(e.Row.Cells[6].Text, out this.getcount);
			decimal.TryParse(e.Row.Cells[8].Text, out this.backcount1);
			decimal.TryParse(e.Row.Cells[10].Text, out this.backcount2);
			decimal.TryParse(e.Row.Cells[13].Text, out this.useprice);
			this.usecount = this.getcount - this.backcount1 - this.backcount2;
			e.Row.Cells[12].Text = this.usecount.ToString("#0.00");
			e.Row.Cells[14].Text = (this.usecount * this.useprice).ToString("#0.00");
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text + "," + e.Row.Cells[2].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				",",
				e.Row.Cells[2].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ChkMod(870, 525,'Stat/BroughBackSellDetail.aspx?v=" + this.value + "','详细信息');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			this.totalusecount += this.usecount;
			this.totalgetcount += this.getcount;
			this.totalbackcount1 += this.backcount1;
			this.totalbackcount2 += this.backcount2;
			this.totaluseAmount += this.usecount * this.useprice;
			if (e.Row.Cells[12].Text == "0.00")
			{
				e.Row.Visible = false;
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[6].Text = this.totalgetcount.ToString("#0.00");
			e.Row.Cells[8].Text = this.totalbackcount1.ToString("#0.00");
			e.Row.Cells[10].Text = this.totalbackcount2.ToString("#0.00");
			e.Row.Cells[12].Text = this.totalusecount.ToString("#0.00");
			e.Row.Cells[14].Text = this.totaluseAmount.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DALBroughtBack dALBroughtBack = new DALBroughtBack();
		string sWhere = this.hfSql.Value;
		DataTable dt = dALBroughtBack.ExecStockCountBy(sWhere).Tables[0];
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

	protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlBranch.SelectedValue == "-1")
		{
			OtherFunction.BindStaff(this.ddlStaffName, "");
		}
		else
		{
			OtherFunction.BindStaff(this.ddlStaffName, " DeptID =" + this.ddlBranch.SelectedValue);
		}
	}
}
