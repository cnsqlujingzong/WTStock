using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Branch_Financial_PaymentAdd : Page, IRequiresSessionState
{
	private decimal drec1;

	private decimal drec2;

	private decimal drec3;

	private decimal dtest;


	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Date", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Operator", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("HaveAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("NotChargeAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ChargeAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r4"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zk_r9"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zk_r13"))
				{
					this.btnPrint.Visible = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(24, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
			OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
			OtherFunction.BindChargeItem(this.ddlItem, " Type=1 and DeptID=" + (string)this.Session["Session_wtBranchID"]);
			this.AddEmpty();
			this.tbBalance.Text = (this.tbRecMoney.Text = (this.tbPreMoney.Text = (this.tbRealMoney.Text = "0.00")));
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = 0;
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		dataRow[9] = "";
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbChargeMoney") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["ChargeAmount"] = (textBox.Text.Trim().Equals("") ? "0" : textBox.Text);
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;");
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.drec1 += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.drec2 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.drec3 += this.dtest;
			if (e.Row.Cells[2].Text == "销售退货")
			{
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href=\"#\" onclick=\"Sell('",
					e.Row.Cells[3].Text,
					"');\">",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[2].Text == "采购入库")
			{
				e.Row.Cells[3].Text = string.Concat(new string[]
				{
					"<a href=\"#\" onclick=\"Purchase('",
					e.Row.Cells[3].Text,
					"');\">",
					e.Row.Cells[3].Text,
					"</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[2].Text = "合计:";
			e.Row.Cells[6].Text = this.drec1.ToString("#0");
			e.Row.Cells[7].Text = this.drec2.ToString("#0");
			e.Row.Cells[8].Text = this.drec3.ToString("#0");
			e.Row.Attributes.Add("style", "color:#ff0000;text-align:right;");
		}
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		this.tbBalance.Text = "0.00";
		if (this.hfCusID.Value != "")
		{
			this.GridViewSource.Clear();
			this.AddEmpty();
			string text = this.hfCusID.Value.Replace("c", "").Replace("b", "").Replace("s", "").Replace("l", "");
			DataTable dataTable = DALCommon.GetDataList("zk_arrearage", "Balance", string.Concat(new string[]
			{
				"DeptID=",
				(string)this.Session["Session_wtBranchID"],
				" and CusType=",
				this.hfType.Value,
				" and CustomerID=",
				text
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbBalance.Text = dataTable.Rows[0]["Balance"].ToString();
			}
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable2 = DALCommon.GetDataList("zk_cusarrearage", "", string.Concat(new string[]
			{
				" DeptID=",
				(string)this.Session["Session_wtBranchID"],
				" and Status=1 and NotChargeAmount>0 and Type='应付款' and CustomerID=",
				text,
				" and CusType=",
				this.hfType.Value
			})).Tables[0];
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = int.Parse(dataTable2.Rows[i]["ID"].ToString());
				dataRow[1] = dataTable2.Rows[i]["RecType"].ToString();
				dataRow[2] = dataTable2.Rows[i]["OperationID"].ToString();
				dataRow[3] = dataTable2.Rows[i]["_Date"].ToString();
				dataRow[4] = dataTable2.Rows[i]["_Name"].ToString();
				dataRow[5] = decimal.Parse(dataTable2.Rows[i]["Amount"].ToString());
				dataRow[6] = decimal.Parse(dataTable2.Rows[i]["HaveAmount"].ToString());
				dataRow[7] = decimal.Parse(dataTable2.Rows[i]["NotChargeAmount"].ToString());
				dataRow[8] = 0;
				dataRow[9] = dataTable2.Rows[i]["Remark"].ToString();
				gridViewSource.Rows.Add(dataRow);
			}
			this.GridViewSource = gridViewSource;
			this.BindData();
		}
	}

	protected void btnSltID_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfreclist.Value.EndsWith(","))
		{
			text = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfreclist.Value;
		}
		if (text != string.Empty)
		{
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable = DALCommon.GetDataList("zk_cusarrearage", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["ID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[1] = dataTable.Rows[i]["RecType"].ToString();
						dataRow[2] = dataTable.Rows[i]["OperationID"].ToString();
						dataRow[3] = dataTable.Rows[i]["_Date"].ToString();
						dataRow[4] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[5] = decimal.Parse(dataTable.Rows[i]["Amount"].ToString());
						dataRow[6] = decimal.Parse(dataTable.Rows[i]["HaveAmount"].ToString());
						dataRow[7] = decimal.Parse(dataTable.Rows[i]["NotChargeAmount"].ToString());
						dataRow[8] = 0;
						dataRow[9] = dataTable.Rows[i]["Remark"].ToString();
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
	}

	protected void btnAuto_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！无应收明细，请添加！');");
		}
		else
		{
			decimal num = 0m;
			decimal.TryParse(this.tbRecMoney.Text, out num);
			decimal d = 0m;
			decimal num2 = 0m;
			decimal num3 = 0m;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				decimal.TryParse(gridViewSource.Rows[i]["NotChargeAmount"].ToString(), out d);
				num2 += d;
				decimal.TryParse(gridViewSource.Rows[i]["ChargeAmount"].ToString(), out d);
				num3 += d;
			}
			decimal num4;
			if (num == 0m)
			{
				if (num3 > num2)
				{
					num4 = num2;
				}
				else
				{
					num4 = num3;
				}
			}
			else if (num3 == 0m)
			{
				if (num > num2)
				{
					num4 = num2;
				}
				else
				{
					num4 = num;
				}
			}
			else if (num3 > num2)
			{
				if (num2 > num)
				{
					num4 = num2;
				}
				else
				{
					num4 = num;
				}
			}
			else if (num3 > num)
			{
				num4 = num3;
			}
			else
			{
				num4 = num;
			}
			this.tbRecMoney.Text = num4.ToString("#0.00");
			decimal d2 = 0m;
			decimal.TryParse(this.tbPreMoney.Text, out d2);
			this.tbRealMoney.Text = Convert.ToDouble(num4 - d2).ToString("#0.00");
			decimal num5 = 0m;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				decimal.TryParse(gridViewSource.Rows[i]["NotChargeAmount"].ToString(), out num5);
				if (num4 > 0m)
				{
					if (num4 > num5)
					{
						gridViewSource.Rows[i]["ChargeAmount"] = num5;
					}
					else
					{
						gridViewSource.Rows[i]["ChargeAmount"] = num4;
					}
				}
				else
				{
					gridViewSource.Rows[i]["ChargeAmount"] = 0;
				}
				num4 -= num5;
			}
			this.BindData();
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！无应付明细，请添加！');");
		}
		else
		{
			decimal num = 0m;
			decimal num2 = 0m;
			decimal.TryParse(this.tbRecMoney.Text, out num2);
			decimal d = 0m;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				decimal.TryParse(gridViewSource.Rows[i]["ChargeAmount"].ToString(), out d);
				num += d;
			}
			if (num != num2)
			{
				this.SysInfo("window.alert('操作失败！本次应付款与单据明细不符，请修改！');");
			}
			else if (num2 > num)
			{
				this.SysInfo("window.alert('操作失败!应付款不能大于本次结算总金额，请修改！');");
			}
			else
			{
				string empty = string.Empty;
				int iTbid;
				int num3 = this.BillAdd(out iTbid, out empty);
				if (num3 == 0)
				{
					DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
					int iOperator = 0;
					int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
					num3 = dALIncomeExpenses.IncomExpChk(iTbid, iOperator, out empty);
					if (num3 == 0)
					{
						this.SysInfo("window.alert('" + empty + "');");
					}
					else
					{
						this.SysInfo("window.alert('" + empty + "');");
					}
					this.ClearText();
					this.hfPrintID.Value = iTbid.ToString();
				}
				else
				{
					this.SysInfo("window.alert('操作失败！" + empty + "');");
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！无应付明细，请添加！');");
		}
		else
		{
			decimal num = 0m;
			decimal num2 = 0m;
			decimal.TryParse(this.tbRecMoney.Text, out num2);
			decimal d = 0m;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				decimal.TryParse(gridViewSource.Rows[i]["ChargeAmount"].ToString(), out d);
				num += d;
			}
			if (num != num2)
			{
				this.SysInfo("window.alert('操作失败！本次应付款与单据明细不符，请修改！');");
			}
			else if (num2 > num)
			{
				this.SysInfo("window.alert('操作失败!应付款不能大于本次结算总金额，请修改！');");
			}
			else
			{
				string empty = string.Empty;
				int num3;
				if (this.BillAdd(out num3, out empty) == 0)
				{
					this.SysInfo("window.alert('操作成功！应付款已保存！');");
					this.ClearText();
					this.hfPrintID.Value = num3.ToString();
				}
				else
				{
					this.SysInfo("window.alert('" + empty + "');");
				}
			}
		}
	}

	protected int BillAdd(out int iTbid, out string strMsg)
	{
		IncomeExpensesInfo incomeExpensesInfo = new IncomeExpensesInfo();
		incomeExpensesInfo.DeptID = new int?(int.Parse((string)this.Session["Session_wtBranchID"]));
		incomeExpensesInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		incomeExpensesInfo.PersonID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		incomeExpensesInfo.RecType = "应付款";
		incomeExpensesInfo.CusType = new int?(int.Parse(this.hfType.Value));
		incomeExpensesInfo.CustomerID = new int?(int.Parse(this.hfCusID.Value.Replace("c", "").Replace("b", "").Replace("s", "").Replace("l", "")));
		incomeExpensesInfo.DueMoney = decimal.Parse(this.tbRecMoney.Text);
		incomeExpensesInfo.PreMoney = decimal.Parse(this.tbPreMoney.Text);
		incomeExpensesInfo.RealDueMoney = decimal.Parse(this.tbRealMoney.Text);
		incomeExpensesInfo.ChargeModeID = new int?(int.Parse(this.ddlChargeStyle.SelectedValue));
		incomeExpensesInfo.AccountID = new int?(int.Parse(this.ddlChargeAccount.SelectedValue));
		incomeExpensesInfo.ItemID = new int?(int.Parse(this.ddlItem.SelectedValue));
		incomeExpensesInfo.InvoiceClassID = new int?(int.Parse(this.ddlInvoiceClass.SelectedValue));
		incomeExpensesInfo.InvoiceNO = FunLibrary.ChkInput(this.tbInvoiceNO.Text);
		incomeExpensesInfo.CheckNO = FunLibrary.ChkInput(this.tbCheckNO.Text);
		incomeExpensesInfo.VoucherNO = FunLibrary.ChkInput(this.tbVoucherNO.Text);
		incomeExpensesInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		incomeExpensesInfo.InvoiceDate = FunLibrary.ChkInput(this.tbInvoiceDate.Text);
		decimal invoiceAmount = 0m;
		decimal.TryParse(this.tbInvoiceAmount.Text, out invoiceAmount);
		incomeExpensesInfo.InvoiceAmount = invoiceAmount;
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<CiteAccountInfo> list = new List<CiteAccountInfo>();
			decimal num = 0m;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				decimal.TryParse(gridViewSource.Rows[i]["ChargeAmount"].ToString(), out num);
				if (num > 0m)
				{
					list.Add(new CiteAccountInfo
					{
						ArrearageID = new int?(int.Parse(gridViewSource.Rows[i]["ID"].ToString())),
						Money = new decimal?(num)
					});
				}
			}
			incomeExpensesInfo.CiteAccountInfos = list;
		}
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		int result = dALIncomeExpenses.Add(incomeExpensesInfo, 2, out iTbid, out strMsg);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(24, 0);
		this.tbCusName.Text = string.Empty;
		this.tbCusName.Visible = true;
		this.hfCusID.Value = string.Empty;
		this.ddlChargeAccount.ClearSelection();
		this.ddlChargeAccount.Items.FindByText("").Selected = true;
		this.ddlInvoiceClass.ClearSelection();
		this.ddlInvoiceClass.Items.FindByText("").Selected = true;
		this.ddlItem.ClearSelection();
		this.ddlItem.Items.FindByText("").Selected = true;
		this.tbCheckNO.Text = (this.tbInvoiceNO.Text = (this.tbVoucherNO.Text = string.Empty));
		this.tbRemark.Text = string.Empty;
		this.tbInvoiceAmount.Text = "0.00";
		this.tbInvoiceDate.Text = "";
		this.tbBalance.Text = (this.tbRecMoney.Text = (this.tbRealMoney.Text = (this.tbPreMoney.Text = "0.00")));
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
