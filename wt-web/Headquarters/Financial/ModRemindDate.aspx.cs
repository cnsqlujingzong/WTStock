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

public partial class Headquarters_Financial_ModRemindDate : Page, IRequiresSessionState
{

	private int id;

	private static bool b = false;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].ToString().Replace("d", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (base.Request["v"] != null && base.Request["v"].Equals("1"))
		{
			Headquarters_Financial_ModRemindDate.b = true;
		}
		if (!base.IsPostBack)
		{
			DataTable dataTable = DALCommon.GetDataList("zk_arrearagedetail", "Amount,HaveAmount,NotChargeAmount,RemindDate,Remark,InvoiceNO,InvoiceMoney,InvoiceDate", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbName.Text = dataTable.Rows[0]["RemindDate"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbAmount.Text = dataTable.Rows[0]["InvoiceMoney"].ToString();
				this.tbInvoice.Text = dataTable.Rows[0]["InvoiceNO"].ToString();
				this.tbInvDate.Text = dataTable.Rows[0]["InvoiceDate"].ToString();
				this.tbSumAmount.Text = dataTable.Rows[0]["Amount"].ToString();
				this.tbHaveAmount.Text = dataTable.Rows[0]["HaveAmount"].ToString();
				this.tbNotChargeAmount.Text = dataTable.Rows[0]["NotChargeAmount"].ToString();
			}
			else
			{
				this.btnAdd.Enabled = false;
			}
			if (Headquarters_Financial_ModRemindDate.b)
			{
				this.tbAmount.Enabled = false;
				this.tbInvoice.Enabled = false;
				this.tbInvDate.Enabled = false;
				this.tbSumAmount.Enabled = false;
				this.tbHaveAmount.Enabled = false;
				this.tbNotChargeAmount.Enabled = false;
			}
			else
			{
				this.tbAmount.Enabled = true;
				this.tbInvoice.Enabled = true;
				this.tbInvDate.Enabled = true;
				this.tbSumAmount.Enabled = true;
				this.tbHaveAmount.Enabled = true;
				this.tbNotChargeAmount.Enabled = true;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALArrearage dALArrearage = new DALArrearage();
		decimal amount;
		decimal.TryParse(this.tbSumAmount.Text, out amount);
		decimal haveAmount;
		decimal.TryParse(this.tbHaveAmount.Text, out haveAmount);
		decimal notChargeAmount;
		decimal.TryParse(this.tbNotChargeAmount.Text, out notChargeAmount);
		if (Headquarters_Financial_ModRemindDate.b)
		{
			dALArrearage.updateRemindDate(this.id, FunLibrary.ChkInput(this.tbName.Text), FunLibrary.ChkInput(this.tbRemark.Text));
		}
		else
		{
			dALArrearage.UpdateRemindDate(this.id, FunLibrary.ChkInput(this.tbName.Text), FunLibrary.ChkInput(this.tbRemark.Text), FunLibrary.ChkInput(this.tbInvoice.Text), FunLibrary.ChkInput(this.tbAmount.Text), FunLibrary.ChkInput(this.tbInvDate.Text), amount, haveAmount, notChargeAmount);
		}
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
