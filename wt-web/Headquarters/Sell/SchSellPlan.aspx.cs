using EF;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using Wuqi.Webdiyer;

public partial class Headquarters_Sell_SchSellPlan : Page, IRequiresSessionState
{

	private int pageSize = 15;

	private decimal dqty = 0m;

	private decimal tqty = 0m;

	private decimal dprice = 0m;

	private decimal dtotal = 0m;

	private decimal dsqty = 0m;

	private decimal dre1 = 0m;

	private decimal dre2 = 0m;

	private decimal dtaxamount = 0m;

	private decimal dgoodsamount = 0m;
    private DataTable sell;
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "xs_r11"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "xs_r13"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r14"))
				{
					this.btnChkU.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r15"))
				{
					this.btnDel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r16"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r17"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(num, "xs_r18"))
				{
					this.btnEnd.Enabled = false;
				}
				if (dALRight.GetRight(num, "xs_r19"))
				{
					this.hfPurDept.Value = "1";
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
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (OperatorID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or OperatorID is null)";
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "xs_sellplan", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_2ED = this.hfTbTitle;
						expr_2ED.Value = expr_2ED.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_33D = this.hfTbField;
						expr_33D.Value = expr_33D.Value + "," + dataField;
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
		string text = " DeptID=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int num = 0;
				int.TryParse(this.ddlKey.SelectedValue, out num);
				if (text2 != "")
				{
					DALSellPlan dALSellPlan = new DALSellPlan();
					text += dALSellPlan.GetSchWhere(num, text2);
					if (num == 11)
					{
						text = text + " and ID in ( select BillID from xs_sellplandetail where GoodsNO ='" + text2 + "')";
					}
					if (num == 12)
					{
						text = text + " and ID in ( select BillID from xs_sellplandetail where _Name like '%" + text2 + "%')";
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
			if (e.Row.Cells[1].Text == "待审核")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
			else if (e.Row.Cells[1].Text == "已审核")
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
			if (e.Row.Cells[11].Text == "已执行")
			{
				e.Row.Attributes.Add("style", "color:black");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALSellPlan dALSellPlan = new DALSellPlan();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALSellPlan.ChkSellPlan(1, iTbid, iOperator, out empty);
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
            WTLog.WriteLog("销售订单", this.hfRecID.Value, "审核", "失败", empty);
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
            WTLog.WriteLog("销售订单", this.hfRecID.Value, "审核", "成功");
		}
		this.SysInfo(text);
	}

	protected void btnChkU_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALSellPlan dALSellPlan = new DALSellPlan();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALSellPlan.ChkSellPlanU(1, iTbid, iOperator, out empty);
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
            WTLog.WriteLog("销售订单", this.hfRecID.Value, "反审核", "失败",empty);
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
            WTLog.WriteLog("销售订单", this.hfRecID.Value, "反审核", "成功");
		}
		this.SysInfo(text);
	}

	protected void btnEnd_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALSellPlan dALSellPlan = new DALSellPlan();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALSellPlan.ChkEnd(1, iTbid, iOperator, out empty);
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
            WTLog.WriteLog("销售订单", this.hfRecID.Value, "终止", "失败",empty);
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
            WTLog.WriteLog("销售订单", this.hfRecID.Value, "终止", "成功");
		}
		this.SysInfo(text);
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALSellPlan dALSellPlan = new DALSellPlan();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALSellPlan.Delete(1, iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
            WTLog.WriteLog("销售订单", this.hfRecID.Value, "删除", "成功");
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
    WTLog.WriteLog("销售订单", this.hfRecID.Value, "删除", "失败",empty);
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
		DataTable dt = DALCommon.GetDataList("xs_sellplan", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "销售订单", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void btnExcelDe_Click(object sender, EventArgs e)
	{
		DataTable dt = DALCommon.GetDataList("xs_sellplandetail", this.hfTbFieldDe.Value, " BillID=" + this.hfRecID.Value).Tables[0];
		string[] tbTitle = this.hfTbTitleDe.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "销售订单明细", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.ShowDetail();
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding-right:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			decimal.TryParse(e.Row.Cells[8].Text, out this.tqty);
			decimal.TryParse(e.Row.Cells[10].Text, out this.dprice);
			this.dqty += this.tqty;
			this.dtotal += this.tqty * this.dprice;
			decimal.TryParse(e.Row.Cells[14].Text, out this.dre1);
			this.dtaxamount += this.dre1;
			decimal.TryParse(e.Row.Cells[15].Text, out this.dre2);
			this.dgoodsamount += this.dre2;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[8].Text = this.dqty.ToString("#0.00");
			e.Row.Cells[12].Text = this.dtotal.ToString("#0.00");

            string tax = this.dtaxamount.ToString("#0.00");
            string totle = this.dgoodsamount.ToString("#0.00");
            if (sell != null && sell.Rows.Count > 0)
            {
                tax = (this.dgoodsamount * Convert.ToDecimal(sell.Rows[0]["BrandTaxRate"])).ToString("#0.00");
                totle = (this.dgoodsamount * (1 + Convert.ToDecimal(sell.Rows[0]["BrandTaxRate"]))).ToString("#0.00");
            }
            //e.Row.Cells[13].Text = Convert.ToDecimal(sell.Rows[0]["BrandTaxRate"]).ToString("#0.00");
            e.Row.Cells[14].Text = this.dtotal.ToString();//(this.dtotal * (1 + Convert.ToDecimal(sell.Rows[0]["BrandTaxRate"]))).ToString("#0.00"); ; //tax;
           // e.Row.Cells[15].Text = totle;
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
		this.GridView2.DataSource = DALCommon.GetDataList("xs_sellplandetail", "", " BillID=" + this.hfRecID.Value);
        sell = DALCommon.GetDataList("SellPlan", " top 1 BrandName,BrandTaxRate,BrandTaxRateType", " ID=" + this.hfRecID.Value + "").Tables[0];
		this.GridView2.DataBind();
     
		this.hfTbFieldDe.Value = (this.hfTbTitleDe.Value = string.Empty);
		if (this.GridView2.Rows.Count > 0)
		{
			for (int i = 0; i < this.GridView2.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView2.Columns[i]).DataField;
				string text = this.GridView2.HeaderRow.Cells[i].Text;
				if (dataField != "" && dataField != "ID")
				{
					if (this.hfTbTitleDe.Value == string.Empty)
					{
						this.hfTbTitleDe.Value = text;
					}
					else
					{
						HiddenField expr_120 = this.hfTbTitleDe;
						expr_120.Value = expr_120.Value + "," + text;
					}
					if (this.hfTbFieldDe.Value == string.Empty)
					{
						this.hfTbFieldDe.Value = dataField;
					}
					else
					{
						HiddenField expr_16F = this.hfTbFieldDe;
						expr_16F.Value = expr_16F.Value + "," + dataField;
					}
				}
			}
		}
	}

}
