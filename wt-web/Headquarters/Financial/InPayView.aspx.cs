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

public partial class Headquarters_Financial_InPayView : Page, IRequiresSessionState
{

	private int id;

	private string ids;

	private string flag;

	public string str_flag
	{
		get
		{
			return this.flag;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0 && base.Request["ids"] != null)
		{
			this.ids = base.Request["ids"];
			if (this.ids != null)
			{
				this.id = dALIncomeExpenses.GetIDs(this.ids);
			}
		}
		if (this.id == 0)
		{
			base.Response.End();
		}
		string text = base.Request["n"];
		if (text != null && text == "1")
		{
			this.btnSave.Visible = false;
		}
		this.flag = base.Request["iflag"];
		if (this.flag == "" || this.flag == null)
		{
			this.flag = "";
		}
		if (!base.IsPostBack)
		{
			DALRight dALRight = new DALRight();
			int num = 0;
			int num2 = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num2 > 0)
			{
				if (!dALRight.GetRight(num2, "zk_r7"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num2, "zk_r8"))
				{
					num = 1;
					this.btnSave.Enabled = false;
				}
			}
			IncomeExpensesInfo model = dALIncomeExpenses.GetModel(this.id);
			if (model != null)
			{
				OtherFunction.BindStaff(this.ddlOperator, " [ID]=" + model.PersonID.ToString());
				OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
				OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=1");
				OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.lbType.Text = model.Type;
				if (model.Type == "收款单")
				{
					OtherFunction.BindChargeItem(this.ddlItem, " Type=0 and DeptID=1");
				}
				else
				{
					OtherFunction.BindChargeItem(this.ddlItem, " Type=1 and DeptID=1");
				}
				this.tbDate.Text = model._Date;
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.PersonID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbRecType.Text = model.RecType;
				this.tbCusName.Text = model.CustomerName;
				if (model.Type == "收款单")
				{
	this.lbsy1.Text = (this.lbsy2.Text = "收");
					this.tbAmount.Text = model.RecMoney.ToString("#0.00");
					this.tbRealAmount.Text = model.RealRecMoney.ToString("#0.00");
				}
				else
				{
		this.lbsy1.Text = (this.lbsy2.Text = "付");
					this.tbAmount.Text = model.DueMoney.ToString("#0.00");
					this.tbRealAmount.Text = model.RealDueMoney.ToString("#0.00");
				}
				this.tbYAmount.Text = model.PreMoney.ToString("#0.00");
				this.tbInvoiceAmount.Text = model.InvoiceAmount.ToString("#0.00");
				this.tbInvoiceDate.Text = ((model.InvoiceDate == "1900-01-01") ? "" : model.InvoiceDate);
				for (int i = 0; i < this.ddlChargeStyle.Items.Count; i++)
				{
					if (this.ddlChargeStyle.Items[i].Value == model.ChargeModeID.ToString())
					{
						this.ddlChargeStyle.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlChargeAccount.Items.Count; i++)
				{
					if (this.ddlChargeAccount.Items[i].Value == model.AccountID.ToString())
					{
						this.ddlChargeAccount.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlInvoiceClass.Items.Count; i++)
				{
					if (this.ddlInvoiceClass.Items[i].Value == model.InvoiceClassID.ToString())
					{
						this.ddlInvoiceClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbInvoiceNO.Text = model.InvoiceNO;
				this.tbVoucherNO.Text = model.VoucherNO;
				this.tbCheckNO.Text = model.CheckNO;
				for (int i = 0; i < this.ddlItem.Items.Count; i++)
				{
					if (this.ddlItem.Items[i].Value == model.ItemID.ToString())
					{
						this.ddlItem.Items[i].Selected = true;
						break;
					}
				}
				this.tbRemark.Text = model.Remark;
				if (model.DeptID > 1)
				{
					this.lbMod.Text = "总部只能修改自己的收付款单.";
					this.lbMod.Attributes.Add("class", "si2");
					this.btnSave.Enabled = false;
				}
				if (num2 > 0)
				{
					if (num == 0)
					{
						if (model.Status == 2)
						{
							this.ddlChargeStyle.Enabled = false;
							this.ddlChargeAccount.Enabled = false;
							this.ddlItem.Enabled = false;
						}
					}
					else
					{
						if (model.Status == 2)
						{
							this.lbMod.Text = "该单据已经审核，修改无法保存";
							this.lbMod.Attributes.Add("class", "si2");
							this.btnSave.Enabled = false;
						}
						if (model.Status == 3)
						{
							this.lbMod.Text = "该单据已经作废，修改无法保存";
							this.lbMod.Attributes.Add("class", "si2");
							this.btnSave.Enabled = false;
						}
					}
				}
				else if (model.Status == 2)
				{
					this.ddlChargeStyle.Enabled = false;
					this.ddlChargeAccount.Enabled = false;
					this.ddlItem.Enabled = false;
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		IncomeExpensesInfo incomeExpensesInfo = new IncomeExpensesInfo();
		incomeExpensesInfo.ID = this.id;
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
		string str;
		int num = dALIncomeExpenses.Update(incomeExpensesInfo, out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + str + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
