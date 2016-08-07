using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;
using wt.OtherLibrary;

public partial class Branch_Financial_SchExpenseCd : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			OtherFunction.BindChargeAccount(this.ddlAccount, " DeptID=" + this.Session["Session_wtBranchID"].ToString());
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " DeptID=" + this.Session["Session_wtBranchID"].ToString() + " ";
		string text2 = this.tbDateB.Text.Trim();
		string text3 = this.tbDateE.Text.Trim();
		string text4 = this.tbChkDateB.Text.Trim();
		string text5 = this.tbChkDateE.Text.Trim();
		string text6 = this.tbPaymentDateB.Text.Trim();
		string text7 = this.tbPaymentDateE.Text.Trim();
		string text8 = this.ddlStatus.SelectedItem.Text.Trim();
		string text9 = this.tbRelatedBusiness.Text.Trim();
		string text10 = this.tbOperator.Text.Trim();
		decimal num = 0m;
		if (!this.tbMoneyL.Text.Trim().Equals(""))
		{
			decimal.TryParse(this.tbMoneyL.Text.Trim(), out num);
		}
		decimal num2 = 0m;
		if (!this.tbMoneyH.Text.Trim().Equals(""))
		{
			decimal.TryParse(this.tbMoneyH.Text.Trim(), out num2);
		}
		string text11 = this.tbSummary.Text.Trim();
		string selectedValue = this.ddlAccount.SelectedValue;
		string text12 = this.tbChkOperator.Text.Trim();
		string text13 = this.tbPaymentOper.Text.Trim();
		string text14 = this.tbRemark.Text.Trim();
		if (!text2.Equals(""))
		{
			text += string.Format(" and convert(varchar(10),_Date,120)>='{0}' ", text2);
		}
		if (!text3.Equals(""))
		{
			text += string.Format(" and convert(varchar(10),_Date,120)<='{0}' ", text3);
		}
		if (!text4.Equals(""))
		{
			text += string.Format(" and convert(varchar(10),ChkDate,120)>='{0}' ", text4);
		}
		if (!text5.Equals(""))
		{
			text += string.Format(" and convert(varchar(10),ChkDate,120)<='{0}' ", text5);
		}
		if (!text6.Equals(""))
		{
			text += string.Format(" and convert(varchar(10),PaymentDate,120)>='{0}' ", text6);
		}
		if (!text7.Equals(""))
		{
			text += string.Format(" and convert(varchar(10),PaymentDate,120)<='{0}' ", text7);
		}
		if (!text8.Equals(""))
		{
			text += string.Format(" and status='{0}' ", text8);
		}
		if (!text9.Equals(""))
		{
			text += string.Format(" and RelatedBusiness like '%{0}%' ", text9);
		}
		if (!text10.Equals(""))
		{
			text += string.Format(" and Operator like '%{0}%' ", text10);
		}
		if (!text11.Equals(""))
		{
			text += string.Format(" and Summary like '%{0}%' ", text11);
		}
		if (num > 0m)
		{
			text = text + " and dMoney>=" + num;
		}
		if (num2 > 0m)
		{
			text = text + " and dMoney<=" + num2;
		}
		if (!selectedValue.Equals("-1"))
		{
			text = text + " and AccountID=" + selectedValue;
		}
		if (!text12.Equals(""))
		{
			text += string.Format(" and ChkOperator like '%{0}%' ", text12);
		}
		if (!text13.Equals(""))
		{
			text += string.Format(" and PaymentOper like '%{0}%' ", text13);
		}
		if (!text14.Equals(""))
		{
			text += string.Format(" and Remark like '%{0}%' ", text14);
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
