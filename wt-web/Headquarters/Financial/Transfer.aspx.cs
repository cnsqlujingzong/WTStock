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

public partial class Headquarters_Financial_Transfer : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r17"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "zk_r9"))
				{
					this.btnChk.Enabled = false;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindChargeAccount(this.ddlFAccount, " DeptID=1");
			OtherFunction.BindChargeAccount(this.ddlSAccount, " DeptID=1");
			this.tbAmount.Text = "0.00";
		}
	}

	protected void ddlSAccount_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlSAccount.SelectedValue != "-1")
		{
			DALAccount dALAccount = new DALAccount();
			AccountInfo model = dALAccount.GetModel(int.Parse(this.ddlSAccount.SelectedValue));
			if (model != null)
			{
				this.tbSBalance.Text = decimal.Parse(model.Money.ToString()).ToString("#0.00");
			}
		}
	}

	protected void ddlFAccount_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlFAccount.SelectedValue != "-1")
		{
			DALAccount dALAccount = new DALAccount();
			AccountInfo model = dALAccount.GetModel(int.Parse(this.ddlFAccount.SelectedValue));
			if (model != null)
			{
				this.tbFBalance.Text = decimal.Parse(model.Money.ToString()).ToString("#0.00");
			}
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		int iTbid;
		int iTbid2;
		if (this.BillAdd(out iTbid, out iTbid2) == 0)
		{
			string empty = string.Empty;
			DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
			int iOperator = 0;
			int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
			int num = dALIncomeExpenses.IncomExpChk(iTbid, iOperator, out empty);
			if (num == 0)
			{
				num = dALIncomeExpenses.IncomExpChk(iTbid2, iOperator, out empty);
				if (num == 0)
				{
					this.SysInfo("window.alert('操作成功！转账单已【审核】！');");
				}
				else
				{
					this.SysInfo("window.alert('" + empty + "');");
				}
			}
			else
			{
				this.SysInfo("window.alert('" + empty + "');");
			}
			this.ClearText();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num;
		int num2;
		if (this.BillAdd(out num, out num2) == 0)
		{
			this.SysInfo("window.alert('操作成功！转账单已保存！');");
			this.ClearText();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected int BillAdd(out int iTbid, out int iTbid2)
	{
		IncomeExpensesInfo incomeExpensesInfo = new IncomeExpensesInfo();
		incomeExpensesInfo.DeptID = new int?(1);
		incomeExpensesInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		incomeExpensesInfo.PersonID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		incomeExpensesInfo.RecType = "帐户转帐";
		incomeExpensesInfo.CusType = new int?(3);
		incomeExpensesInfo.CustomerID = incomeExpensesInfo.DeptID;
		incomeExpensesInfo.RecMoney = decimal.Parse(this.tbAmount.Text);
		incomeExpensesInfo.RealRecMoney = incomeExpensesInfo.RecMoney;
		incomeExpensesInfo.AccountID = new int?(int.Parse(this.ddlSAccount.SelectedValue));
		incomeExpensesInfo.CheckNO = FunLibrary.ChkInput(this.tbCheckNO.Text);
		incomeExpensesInfo.VoucherNO = FunLibrary.ChkInput(this.tbVoucherNO.Text);
		incomeExpensesInfo.Remark = this.tbRemark.Text;
		string empty = string.Empty;
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		int num = dALIncomeExpenses.Add(incomeExpensesInfo, 1, out iTbid, out empty);
		IncomeExpensesInfo incomeExpensesInfo2 = new IncomeExpensesInfo();
		incomeExpensesInfo2.DeptID = new int?(1);
		incomeExpensesInfo2._Date = FunLibrary.ChkInput(this.tbDate.Text);
		incomeExpensesInfo2.PersonID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		incomeExpensesInfo2.RecType = "帐户转帐";
		incomeExpensesInfo2.CusType = new int?(3);
		incomeExpensesInfo2.CustomerID = incomeExpensesInfo2.DeptID;
		incomeExpensesInfo2.DueMoney = decimal.Parse(this.tbAmount.Text);
		incomeExpensesInfo2.RealDueMoney = incomeExpensesInfo2.DueMoney;
		incomeExpensesInfo2.AccountID = new int?(int.Parse(this.ddlFAccount.SelectedValue));
		incomeExpensesInfo2.CheckNO = FunLibrary.ChkInput(this.tbCheckNO.Text);
		incomeExpensesInfo2.VoucherNO = FunLibrary.ChkInput(this.tbVoucherNO.Text);
		incomeExpensesInfo2.Remark = this.tbRemark.Text;
		return dALIncomeExpenses.Add(incomeExpensesInfo2, 2, out iTbid2, out empty);
	}

	protected void ClearText()
	{
		this.tbAmount.Text = "0.00";
		this.tbCheckNO.Text = (this.tbVoucherNO.Text = string.Empty);
		this.tbRemark.Text = string.Empty;
		this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		string b = (string)this.Session["Session_wtUser"];
		this.ddlOperator.ClearSelection();
		for (int i = 0; i < this.ddlOperator.Items.Count; i++)
		{
			if (this.ddlOperator.Items[i].Text == b)
			{
				this.ddlOperator.Items[i].Selected = true;
				break;
			}
		}
		this.ddlSAccount.ClearSelection();
		this.ddlFAccount.ClearSelection();
		this.ddlFAccount.Items.FindByText("").Selected = true;
		this.ddlSAccount.Items.FindByText("").Selected = true;
		this.tbSBalance.Text = (this.tbFBalance.Text = "");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
