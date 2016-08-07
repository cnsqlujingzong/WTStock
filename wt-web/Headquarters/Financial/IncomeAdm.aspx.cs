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

public partial class Headquarters_Financial_IncomeAdm : Page, IRequiresSessionState
{

	private int pageSize = 20;

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
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r7"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "zk_r9"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zk_r10"))
				{
					this.btnChkU.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zk_r11"))
				{
					this.btnCancel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zk_r12"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zk_r13"))
				{
					this.btnPrint.Visible = false;
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
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
		this.hfcbID.Value = "";
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

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : this.hfParm.Value;
		string fldSort = sortExpression + " " + direction;
		if (this.cbzerostk.Checked)
		{
			text += " and iFlag=0 ";
		}
		if (this.chkbox.Checked)
		{
			text += " and status != '已审核' ";
		}
		this.hfSql.Value = text;
		DataTable dataTable = DALCommon.GetDataList("zk_incomeexpenses", "sum(isnull(RealRecMoney,0)) as Qty,sum(isnull(RealDueMoney,0)) as Amount,sum(isnull(InvoiceAmount,0)) as InvoiceAmount", text).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.Label1.Text = dataTable.Rows[0]["Qty"].ToString();
			this.Label2.Text = dataTable.Rows[0]["Amount"].ToString();
			this.Label3.Text = dataTable.Rows[0]["InvoiceAmount"].ToString();
		}
		else
		{
			this.Label1.Text = "0.00";
			this.Label2.Text = "0.00";
			this.Label3.Text = "0.00";
		}
		this.gvbranch.DataSource = DALCommon.GetList_HL(1, "zk_incomeexpenses", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (i > 1)
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
							HiddenField expr_40E = this.hfTbTitle;
							expr_40E.Value = expr_40E.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_45E = this.hfTbField;
							expr_45E.Value = expr_45E.Value + "," + dataField;
						}
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

	protected void cbzerostk_CheckedChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void gvbranch_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[2].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:5px;");
			e.Row.Cells[1].Text = string.Concat(new string[]
			{
				"<input id=\"cb",
				e.Row.Cells[0].Text,
				"\" type=\"checkbox\" onclick=\"SltValue('",
				e.Row.Cells[0].Text,
				"',this);\"/>"
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToString() == e.Row.Cells[0].Text)
				{
					e.Row.Cells[1].Text = string.Concat(new string[]
					{
						"<input id=\"cb",
						e.Row.Cells[0].Text,
						"\" type=\"checkbox\" checked=\"checked\" onclick=\"SltValue('",
						e.Row.Cells[0].Text,
						"',this);\"/>"
					});
					break;
				}
			}
			if (e.Row.Cells[4].Text == "已审核")
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
			else if (e.Row.Cells[4].Text == "待审核")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
			else if (e.Row.Cells[4].Text == "已作废")
			{
				e.Row.Attributes.Add("style", "color:#848284");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvbranch.Rows.Count.ToString();
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		string value = this.hfcbID.Value;
		if (value == "")
		{
			value = this.hfRecID.Value;
		}
		int num = 0;
		int num2 = 0;
		string empty = string.Empty;
		string[] array = value.Split(new char[]
		{
			','
		});
		int num3 = 0;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			if (num3 != 0)
			{
				int num4 = dALIncomeExpenses.IncomExpChk(num3, iOperator, out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		if (num > 0)
		{
			if (num2 == 0)
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('操作失败！",
					num.ToString(),
					"条收付款单",
					empty,
					"');ChkID('",
					this.hfRecID.Value,
					"');"
				}));
			}
			else
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('",
					num2.ToString(),
					"条收付款单已审核；",
					num.ToString(),
					"条收付款单审核失败。",
					empty,
					"');ChkID('",
					this.hfRecID.Value,
					"');"
				}));
			}
		}
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnChkU_Click(object sender, EventArgs e)
	{
		string value = this.hfcbID.Value;
		if (value == "")
		{
			value = this.hfRecID.Value;
		}
		int num = 0;
		int num2 = 0;
		string empty = string.Empty;
		string[] array = value.Split(new char[]
		{
			','
		});
		int num3 = 0;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			if (num3 != 0)
			{
				int num4 = dALIncomeExpenses.IncomExpChkU(num3, iOperator, out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		if (num > 0)
		{
			if (num2 == 0)
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('操作失败！",
					num.ToString(),
					"条收付款单",
					empty,
					"');ChkID('",
					this.hfRecID.Value,
					"');"
				}));
			}
			else
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('",
					num2.ToString(),
					"条收付款单已反审核；",
					num.ToString(),
					"条收付款单反审核失败。",
					empty,
					"');ChkID('",
					this.hfRecID.Value,
					"');"
				}));
			}
		}
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		string value = this.hfcbID.Value;
		if (value == "")
		{
			value = this.hfRecID.Value;
		}
		int num = 0;
		int num2 = 0;
		string empty = string.Empty;
		string[] array = value.Split(new char[]
		{
			','
		});
		int num3 = 0;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			if (num3 != 0)
			{
				int num4 = dALIncomeExpenses.IncomExpCancel(num3, iOperator, out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		if (num > 0)
		{
			if (num2 == 0)
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('操作失败！",
					num.ToString(),
					"条收付款单",
					empty,
					"');ChkID('",
					this.hfRecID.Value,
					"');"
				}));
			}
			else
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('",
					num2.ToString(),
					"条收付款单已作废；",
					num.ToString(),
					"条收付款单作废失败。",
					empty,
					"');ChkID('",
					this.hfRecID.Value,
					"');"
				}));
			}
		}
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		DataTable dt = DALCommon.GetDataList("zk_incomeexpenses", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "收付款单", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		this.GridView1.DataSource = DALCommon.GetDataList("zk_arrearagedetail", "", " ID in (select ArrearageID from CiteAccount where IncomeExpensesID=" + this.hfRecID.Value + ")");
		this.GridView1.DataBind();
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
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding-right:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[3].Text.Trim().Contains("采购"))
			{
				e.Row.Cells[4].Style["background"] = "white";
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkCG(\"",
					e.Row.Cells[4].Text.Trim(),
					"\")'>",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("服务合同"))
			{
				e.Row.Cells[4].Style["background"] = "white";
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkHT(\"",
					e.Row.Cells[4].Text.Trim(),
					"\")'>",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("完工结算"))
			{
				e.Row.Cells[4].Style["background"] = "white";
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkGD(\"",
					e.Row.Cells[4].Text.Trim(),
					"\")'>",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("网点调拨"))
			{
				e.Row.Cells[4].Style["background"] = "white";
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkDB(\"",
					e.Row.Cells[4].Text.Trim(),
					"\")'>",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("销售"))
			{
				e.Row.Cells[4].Style["background"] = "white";
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkXS(\"",
					e.Row.Cells[4].Text.Trim(),
					"\")'>",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("租金结算"))
			{
				e.Row.Cells[4].Style["background"] = "white";
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkJS(\"",
					e.Row.Cells[4].Text.Trim(),
					"\")'>",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("收货结算"))
			{
				e.Row.Cells[4].Style["background"] = "white";
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkGD(\"",
					e.Row.Cells[4].Text.Trim(),
					"\")'>",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("预收款") || e.Row.Cells[2].Text.Trim().Contains("预付款"))
			{
				e.Row.Cells[4].Style["background"] = "white";
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href='javascript:ChkSFK(\"",
					e.Row.Cells[4].Text.Trim(),
					"\")'>",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.damount += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dbamount += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dtamount += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[7].Text = this.damount.ToString("#0.00");
			e.Row.Cells[8].Text = this.dbamount.ToString("#0.00");
			e.Row.Cells[9].Text = this.dtamount.ToString("#0.00");
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

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
