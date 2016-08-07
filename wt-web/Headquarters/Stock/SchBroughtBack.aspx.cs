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
using Wuqi.Webdiyer;

public partial class Headquarters_Stock_SchBroughtBack : Page, IRequiresSessionState
{
	private int pageSize = 15;

	private static bool isLowPricePower = true;

	private static bool bSeeBasePrice = true;

	private decimal dqty = 0m;

	private decimal tqty = 0m;

	private decimal dprice = 0m;

	private decimal dtotal = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r28"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "ck_r29"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r30"))
				{
					this.btnChkU.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r32"))
				{
					this.btnDel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r33"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r34"))
				{
					this.btnPrint.Visible = false;
				}
				if (dALRight.GetRight(num, "jc_r37"))
				{
					Headquarters_Stock_SchBroughtBack.isLowPricePower = false;
				}
				if (dALRight.GetRight(num, "ck_r85"))
				{
					Headquarters_Stock_SchBroughtBack.bSeeBasePrice = false;
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
			this.ShowDetail();
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
			this.ShowDetail();
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ck_broughtback", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (dataField != "" && dataField != "ID")
				{
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
				}
			}
		}
		this.hfTbField.Value = "Status,Type,BillID,_Date,Person,AppOperator,Dept,ChkDate,ChkOperator,StockName,GoodsNO,_Name,Spec,ProductBrand,Unit,Qty,Price,Total,SN,MaintenancePeriod,OperationID,Remark";
		this.hfTbTitle.Value = "单据状态,单据类型,单据编号,日期,制单人,领料人,所属,审核日期,审核人,仓库,产品编号,名称,规格,品牌,单位,数量,单价,金额,序列号,保修期,服务单号,备注";
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " 1=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int num = 0;
				int.TryParse(this.ddlKey.SelectedValue, out num);
				if (text2 != "")
				{
					DALBroughtBack dALBroughtBack = new DALBroughtBack();
					text += dALBroughtBack.GetSchWhere(num, text2);
					if (num == 10)
					{
						text = text + " and AppOperator like '%" + text2 + "%' ";
					}
					if (num == 25)
					{
						text = text + " and ID in (select BillID from BroughtBackDetail where GoodsID in(select ID from Goods where goodsNO like '%" + text2 + "%'))";
					}
					if (num == 26)
					{
						text = text + " and ID in (select BillID from BroughtBackDetail where GoodsID in(select ID from Goods where _Name like '%" + text2 + "%'))";
					}
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
			e.Row.Attributes.Add("ondblclick", "ModBill();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[2].Text == "待审核")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
				e.Row.Cells[1].Attributes.Add("class", "tred");
			}
			else if (e.Row.Cells[2].Text == "已审核")
			{
				e.Row.Attributes.Add("style", "color:#008000");
				e.Row.Cells[1].Attributes.Add("class", "tgreen");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfRecID.Value, out num);
		DALBroughtBack dALBroughtBack = new DALBroughtBack();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		bool flag = dALBroughtBack.comparePrice(num);
		if (!Headquarters_Stock_SchBroughtBack.isLowPricePower)
		{
			if (!flag)
			{
				this.SysInfo("window.alert('审核失败！没有“允许低于最低销售价出库”的权限');");
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				return;
			}
		}
		int num2 = dALBroughtBack.ChkBroughtBack(1, num, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num2 != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
		}
		this.SysInfo(text);
	}

	protected void btnChkU_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALBroughtBack dALBroughtBack = new DALBroughtBack();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALBroughtBack.ChkBroughtBackU(1, iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
		}
		this.SysInfo(text);
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALBroughtBack dALBroughtBack = new DALBroughtBack();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALBroughtBack.Delete(1, iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			}));
			this.ShowDetail();
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
		DataTable dt = DALCommon.GetDataList("v_excel_broughtbackdetail", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "领退单", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (!Headquarters_Stock_SchBroughtBack.bSeeBasePrice)
		{
			e.Row.Cells[10].Visible = false;
			e.Row.Cells[11].Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding-right:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			decimal.TryParse(e.Row.Cells[9].Text, out this.tqty);
			decimal.TryParse(e.Row.Cells[10].Text, out this.dprice);
			this.dqty += this.tqty;
			this.dtotal += this.tqty * this.dprice;
			string[] array = e.Row.Cells[12].Text.Split(new char[]
			{
				','
			});
			if (array.Length > 1)
			{
				e.Row.Cells[12].Text = "<a href=\"#\" onclick=\"ViewSN('" + e.Row.Cells[12].Text + "');\">查看序列号</a>";
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[9].Text = this.dqty.ToString("#0.00");
			e.Row.Cells[11].Text = this.dtotal.ToString("#0.00");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		this.GridView2.DataSource = DALCommon.GetDataList("ck_broughtbackdetail", "", " BillID=" + this.hfRecID.Value);
		this.GridView2.DataBind();
	}

	protected void btnEx_Click(object sender, EventArgs e)
	{
		DataTable dt = DALCommon.GetDataList("ck_broughtbackdetail", "StockName,GoodsNO,_Name,Spec,ProductBrand,Unit,Qty,Price,Total,SN,MainTenancePeriod,PeriodEndDate,OperationID,Remark", " BillID=" + this.hfRecID.Value).Tables[0];
		string[] tbTitle = new string[]
		{
			"仓库",
			"产品编号",
			"名称",
			"规格",
			"品牌",
			"单位",
			"数量",
			"单价",
			"金额",
			"序列号",
			"保修期",
			"截止日期",
			"服务单号",
			"备注"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "领退单", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}
}
