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

public partial class Branch_Financial_ArrearageAdm : Page, IRequiresSessionState
{
	private int pageSize = 15;

	private decimal damount = 0m;

	private decimal dbamount = 0m;

	private decimal dtamount = 0m;

	private decimal dtest = 0m;

	private decimal damount2 = 0m;

	private decimal dbamount2 = 0m;

	private decimal dtamount2 = 0m;

	private decimal dtest2 = 0m;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r14"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "zk_r16"))
				{
					this.btnExcel.Enabled = false;
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
		DataTable dataTable = DALCommon.GetDataList("zk_arrearage", "sum(isnull(Rec,0)) as Qty,sum(isnull(Due,0)) as Amount", text).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.lbARec.Text = dataTable.Rows[0]["Qty"].ToString();
			this.lbADue.Text = dataTable.Rows[0]["Amount"].ToString();
		}
		else
		{
			this.lbARec.Text = "0.00";
			this.lbADue.Text = "0.00";
		}
		this.gvbranch.DataSource = DALCommon.GetList_HL(1, "zk_arrearage", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvbranch.DataBind();
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
		if (this.gvbranch.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvbranch.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvbranch.Columns[i]).DataField;
				string text2 = this.gvbranch.HeaderRow.Cells[i].Text;
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("id", dataField);
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					dataField,
					"','",
					text2,
					"');"
				}));
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
				if (dataField != "ID" && dataField != "")
				{
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_35D = this.hfTbTitle;
						expr_35D.Value = expr_35D.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_3AF = this.hfTbField;
						expr_3AF.Value = expr_3AF.Value + "," + dataField;
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
		string text = " DeptID=" + (string)this.Session["Session_wtBranchID"] + " ";
		if (!this.cbAll.Checked)
		{
			text += " and (Rec>0 or Due>0) ";
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (text2 != "")
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						"and ",
						this.ddlKey.SelectedValue,
						" like '%",
						text2,
						"%'"
					});
				}
			}
		}
		return text;
	}

	protected void gvbranch_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvbranch.Rows.Count.ToString();
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
		DataTable dt = DALCommon.GetDataList("zk_arrearage", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "应收应付", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnRecExcel_Click(object sender, EventArgs e)
	{
		string text = "";
		if (!this.cbAll.Checked)
		{
			text = " NotChargeAmount>0 and ";
		}
		text = text + " Status=1 and Type='应收款' and BillID=" + this.hfRecID.Value;
		DataTable dt = DALCommon.GetDataList("zk_arrearagedetail", "RecType,OperationID,_Date,_Name,Amount,HaveAmount,NotChargeAmount,RemindDate,InvoiceNO,InvoiceMoney,InvoiceDate,AccountName,Remark", text).Tables[0];
		string[] tbTitle = new string[]
		{
			"单据类别",
			"单据编号",
			"日期",
			"经办人",
			"总金额",
			"已结算金额",
			"未结算金额",
			"提醒日期",
			"发票号码",
			"发票金额",
			"开票日期",
			"收款账户",
			"备注"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "应收明细", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnDueExcel_Click(object sender, EventArgs e)
	{
		string text = "";
		if (!this.cbAll.Checked)
		{
			text = " NotChargeAmount>0 and ";
		}
		text = text + " Status=1 and Type='应付款' and BillID=" + this.hfRecID.Value;
		DataTable dt = DALCommon.GetDataList("zk_arrearagedetail", "RecType,OperationID,_Date,_Name,Amount,HaveAmount,NotChargeAmount,RemindDate,InvoiceNO,InvoiceMoney,InvoiceDate,AccountName,Remark", text).Tables[0];
		string[] tbTitle = new string[]
		{
			"单据类别",
			"单据编号",
			"日期",
			"经办人",
			"总金额",
			"已结算金额",
			"未结算金额",
			"提醒日期",
			"发票号码",
			"发票金额",
			"开票日期",
			"收款账户",
			"备注"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "应付明细", out flag, out empty);
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

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		string text = "";
		if (!this.cbAll.Checked)
		{
			text = " NotChargeAmount>0 and ";
		}
		if (this.ddlRecType.SelectedValue != "0")
		{
			text = text + " RecType='" + this.ddlRecType.SelectedValue.Trim() + "' and ";
		}
		text = text + " Status=1 and Type='应收款' and BillID=" + this.hfRecID.Value;
		this.GridView1.DataSource = DALCommon.GetDataList("zk_arrearagedetail", "", text);
		this.GridView1.DataBind();
		string text2 = "";
		if (!this.cbAll.Checked)
		{
			text2 = " NotChargeAmount>0 and ";
		}
		if (this.ddlDueType.SelectedValue != "0")
		{
			text2 = text2 + " RecType='" + this.ddlDueType.SelectedValue.Trim() + "' and ";
		}
		text2 = text2 + " Status=1 and Type='应付款' and BillID=" + this.hfRecID.Value;
		this.GridView2.DataSource = DALCommon.GetDataList("zk_arrearagedetail", "", text2);
		this.GridView2.DataBind();
	}

	protected void ddlRecType_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ddlDueType_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "ChkModR();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding-right:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[2].Text.Trim().Contains("采购"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkCG(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("服务合同"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkHT(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("完工结算"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkGD(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("网点调拨"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkDB(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("销售"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkXS(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("租金结算"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkJS(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("收货结算"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkGD(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("预收款") || e.Row.Cells[2].Text.Trim().Contains("预付款"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkSFK(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.damount += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dbamount += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dtamount += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[6].Text = this.damount.ToString("#0.00");
			e.Row.Cells[7].Text = this.dbamount.ToString("#0.00");
			e.Row.Cells[8].Text = this.dtamount.ToString("#0.00");
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
			e.Row.Attributes.Add("ondblclick", "ChkModR();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding-right:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[2].Text.Trim().Contains("采购"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkCG(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("服务合同"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkHT(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("完工结算"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkGD(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("网点调拨"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkDB(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("销售"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkXS(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("收货结算"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkGD(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text.Trim().Contains("预收款") || e.Row.Cells[2].Text.Trim().Contains("预付款"))
			{
				e.Row.Cells[3].Style["background"] = "white";
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkSFK(\"",
					e.Row.Cells[3].Text.Trim(),
					"\")'>",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest2);
			this.damount2 += this.dtest2;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest2);
			this.dbamount2 += this.dtest2;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest2);
			this.dtamount2 += this.dtest2;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[6].Text = this.damount2.ToString("#0.00");
			e.Row.Cells[7].Text = this.dbamount2.ToString("#0.00");
			e.Row.Cells[8].Text = this.dtamount2.ToString("#0.00");
		}
	}

	protected void cbAll_CheckedChanged(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}
}
