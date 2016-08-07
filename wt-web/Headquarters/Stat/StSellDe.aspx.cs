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

public partial class Headquarters_Stat_StSellDe : Page, IRequiresSessionState
{
	private int pageSize = 25;

	private decimal xianjieAmount = 0m;

	private decimal count = 0m;

	private decimal amount = 0m;

	private decimal totalAmount = 0m;

	private decimal costPrice = 0m;

	private decimal maoli = 0m;

	private decimal ticheng = 0m;

	private decimal xianjieAmount1 = 0m;

	private decimal count1 = 0m;

	private decimal amount1 = 0m;

	private decimal totalAmount1 = 0m;

	private decimal costPrice1 = 0m;

	private decimal maoli1 = 0m;

	private decimal ticheng1 = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r24"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
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
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : this.hfParm.Value;
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		DataSet dataList = DALCommon.GetDataList("st_selldetail", "isnull(sum(GoodsAmount),0),isnull(sum(CostPrice),0),isnull(sum(Profit),0)", text);
		this.Label1.Text = dataList.Tables[0].Rows[0][0].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.Label2.Text = dataList.Tables[0].Rows[0][1].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.Label3.Text = dataList.Tables[0].Rows[0][2].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "v_st_selldetaildeduct", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvdata.DataBind();
		this.lbCount.Text = recordCount.ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
			this.lbCountText.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
			this.lbCountText.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
				string text2 = this.gvdata.HeaderRow.Cells[i].Text;
				this.gvdata.HeaderRow.Cells[i].Attributes.Add("id", dataField);
				this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					dataField,
					"','",
					text2,
					"');"
				}));
				this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
				if (dataField != "ID" && dataField != "Deduct")
				{
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_3F1 = this.hfTbTitle;
						expr_3F1.Value = expr_3F1.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_443 = this.hfTbField;
						expr_443.Value = expr_443.Value + "," + dataField;
					}
				}
			}
		}
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " Status='已审核' and Type='销售' ";
		if (this.hfSch.Value == "0")
		{
			if (this.ddlBranch.SelectedValue != "-1")
			{
				text = text + " and DeptID=" + this.ddlBranch.SelectedValue + "";
			}
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (this.tbCon.Text.Trim() != "")
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"and ",
						this.ddlKey.SelectedValue,
						" like '%",
						FunLibrary.ChkInput(this.tbCon.Text),
						"%'"
					});
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			string[] array = e.Row.Cells[26].Text.Split(new char[]
			{
				','
			});
			if (array.Length > 1)
			{
				e.Row.Cells[26].Text = "<a href=\"#\" style=\"color:#0000ff;\" onclick=\"ViewSN('" + e.Row.Cells[26].Text + "');\">查看序列号</a>";
			}
			decimal.TryParse(e.Row.Cells[8].Text, out this.xianjieAmount);
			this.xianjieAmount1 += this.xianjieAmount;
			decimal.TryParse(e.Row.Cells[20].Text, out this.count);
			this.count1 += this.count;
			decimal.TryParse(e.Row.Cells[22].Text, out this.amount);
			this.amount1 += this.amount;
			decimal.TryParse(e.Row.Cells[23].Text, out this.totalAmount);
			this.totalAmount1 += this.totalAmount;
			decimal.TryParse(e.Row.Cells[24].Text, out this.costPrice);
			this.costPrice1 += this.costPrice;
			decimal.TryParse(e.Row.Cells[25].Text, out this.maoli);
			this.maoli1 += this.maoli;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[8].Text = this.xianjieAmount1.ToString("#0.00");
			e.Row.Cells[20].Text = this.count1.ToString("#0.00");
			e.Row.Cells[22].Text = this.amount1.ToString("#0.00");
			e.Row.Cells[23].Text = this.totalAmount1.ToString("#0.00");
			e.Row.Cells[24].Text = this.costPrice1.ToString("#0.00");
			e.Row.Cells[25].Text = this.maoli1.ToString("#0.00");
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strCondition = string.Concat(new string[]
		{
			this.hfSql.Value,
			" order by ",
			this.hfOrderName.Value,
			" ",
			this.hfOrder.Value
		});
		DataTable dt = DALCommon.GetDataList("v_st_selldetaildeduct", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "销售明细", out flag, out empty);
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
