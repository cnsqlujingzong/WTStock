using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Financial_ModRemindDateAdd : Page, IRequiresSessionState
{
	private int id;

	private string type = string.Empty;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].ToString(), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		this.type = base.Request["x"];
		if (this.type == null)
		{
			base.Response.End();
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
		int personid = int.Parse(this.Session["Session_wtUserID"].ToString());
		int iflag;
		if (this.type == "s")
		{
			iflag = 0;
		}
		else
		{
			iflag = 1;
		}
		dALArrearage.insertArrearageDetail(personid, this.id, this.tbName.Text, this.tbRemark.Text, this.tbInvoice.Text, this.tbAmount.Text, this.tbInvDate.Text, amount, haveAmount, notChargeAmount, iflag);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
