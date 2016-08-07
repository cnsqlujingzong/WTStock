using System;
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

public partial class Branch_Financial_AdvanceInAdd : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r2"))
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
			this.tbBillID.Text = DALCommon.CreateID(23, 0);
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
			OtherFunction.BindChargeItem(this.ddlItem, " Type=0 and DeptID=" + (string)this.Session["Session_wtBranchID"]);
			this.tbMoney.Text = "0.00";
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		int iTbid;
		int num = this.BillAdd(out iTbid);
		if (num == 0)
		{
			string empty = string.Empty;
			DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
			int iOperator = 0;
			int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
			num = dALIncomeExpenses.IncomExpChk(iTbid, iOperator, out empty);
			if (num == 0)
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
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num;
		if (this.BillAdd(out num) == 0)
		{
			this.SysInfo("window.alert('操作成功！预收款已保存！');");
			this.ClearText();
			this.hfPrintID.Value = num.ToString();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected int BillAdd(out int iTbid)
	{
		IncomeExpensesInfo incomeExpensesInfo = new IncomeExpensesInfo();
		incomeExpensesInfo.DeptID = new int?(int.Parse((string)this.Session["Session_wtBranchID"]));
		incomeExpensesInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		incomeExpensesInfo.PersonID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		incomeExpensesInfo.RecType = "预收款";
		incomeExpensesInfo.CusType = new int?(int.Parse(this.hfType.Value));
		incomeExpensesInfo.CustomerID = new int?(int.Parse(this.hfCusID.Value.Replace("c", "").Replace("b", "").Replace("s", "").Replace("l", "")));
		incomeExpensesInfo.RecMoney = decimal.Parse(this.tbMoney.Text);
		incomeExpensesInfo.RealRecMoney = incomeExpensesInfo.RecMoney;
		incomeExpensesInfo.ChargeModeID = new int?(int.Parse(this.ddlChargeStyle.SelectedValue));
		incomeExpensesInfo.AccountID = new int?(int.Parse(this.ddlChargeAccount.SelectedValue));
		incomeExpensesInfo.ItemID = new int?(int.Parse(this.ddlItem.SelectedValue));
		incomeExpensesInfo.InvoiceClassID = new int?(int.Parse(this.ddlInvoiceClass.SelectedValue));
		incomeExpensesInfo.InvoiceNO = FunLibrary.ChkInput(this.tbInvoiceNO.Text);
		incomeExpensesInfo.CheckNO = FunLibrary.ChkInput(this.tbCheckNO.Text);
		incomeExpensesInfo.VoucherNO = FunLibrary.ChkInput(this.tbVoucherNO.Text);
		incomeExpensesInfo.Remark = this.tbRemark.Text;
		incomeExpensesInfo.InvoiceDate = FunLibrary.ChkInput(this.tbInvoiceDate.Text);
		decimal invoiceAmount = 0m;
		decimal.TryParse(this.tbInvoiceAmount.Text, out invoiceAmount);
		incomeExpensesInfo.InvoiceAmount = invoiceAmount;
		string empty = string.Empty;
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		int result = dALIncomeExpenses.Add(incomeExpensesInfo, 1, out iTbid, out empty);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(23, 0);
		this.tbCusName.Text = string.Empty;
		this.hfCusID.Value = string.Empty;
		this.tbMoney.Text = "0.00";
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
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
