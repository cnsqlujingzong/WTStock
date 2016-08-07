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

public partial class Headquarters_Stat_StSellg : Page, IRequiresSessionState
{
	private decimal dqty = 0m;

	private decimal dtotal = 0m;

	private decimal dtest = 0m;

	private decimal dcost = 0m;

	private decimal dtotals = 0m;

	private decimal dprofit = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r22"))
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
		string text = " 1=1 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and x.DeptID=" + this.ddlBranch.SelectedValue + "";
		}
		if (this.tbDateB.Text.Trim() != string.Empty)
		{
			text = text + " and x.ChkDate>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
		}
		if (this.tbDateE.Text.Trim() != string.Empty)
		{
			text = text + " and x.ChkDate<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'";
		}
		if (this.tbSch.Text != "")
		{
			string selectedValue = this.ddrSchType.SelectedValue;
			if (selectedValue != null)
			{
				if (!(selectedValue == "1"))
				{
					if (!(selectedValue == "2"))
					{
						if (selectedValue == "3")
						{
							text = text + " and a.spec='" + this.tbSch.Text + "'";
						}
					}
					else
					{
						text = text + " and a.GoodsNO like '%" + this.tbSch.Text + "%'";
					}
				}
				else
				{
					text = text + " and a._Name like '%" + this.tbSch.Text + "%'";
				}
			}
		}
		string strOrderFld = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetStData("tj_xs_ck", 0, text, strOrderFld);
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtest);
			this.dqty += this.dtest;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dtotal += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dtotals += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dcost += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dprofit += this.dtest;
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
			cells[1].Text = "产品";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 5;
			cells[2].Text = "销售</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[3].Text = "编号";
			cells.Add(new TableHeaderCell());
			cells[4].Text = "名称";
			cells.Add(new TableHeaderCell());
			cells[5].Text = "规格";
			cells.Add(new TableHeaderCell());
			cells[6].Text = "单位";
			cells.Add(new TableHeaderCell());
			cells[7].Text = "数量";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "金额";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "价税合计";
			cells.Add(new TableHeaderCell());
			cells[10].Text = "成本";
			cells.Add(new TableHeaderCell());
			cells[11].Text = "毛利</th></tr><tr>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计:";
			e.Row.Cells[5].Text = this.dqty.ToString("#0.00");
			e.Row.Cells[6].Text = this.dtotal.ToString("#0.00");
			e.Row.Cells[7].Text = this.dtotals.ToString("#0.00");
			e.Row.Cells[8].Text = this.dcost.ToString("#0.00");
			e.Row.Cells[9].Text = this.dprofit.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DataTable dt = DALCommon.GetStData("tj_xs_ck", 0, this.hfSql.Value, this.hfOrderName.Value + " " + this.hfOrder.Value).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "销售汇总表", out flag, out empty);
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
