using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;
using wt.OtherLibrary;

public partial class Branch_Financial_IncomeCd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			this.ddlBranch.Items.Insert(0, new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			OtherFunction.BindStaff(this.ddlOperator, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindStaff(this.ddlChkOperator, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
			OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
			OtherFunction.BindChargeItem(this.ddlItem, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " DeptID=" + (string)this.Session["Session_wtBranchID"];
		string selectedValue = this.ddlBranch.SelectedValue;
		string text2 = FunLibrary.ChkInput(this.tbDateB.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbDateE.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbDateChkB.Text).Replace("\"", "");
		string text5 = FunLibrary.ChkInput(this.tbDateChkE.Text).Replace("\"", "");
		string selectedValue2 = this.ddlOperator.SelectedValue;
		string selectedValue3 = this.ddlChkOperator.SelectedValue;
		string text6 = FunLibrary.ChkInput(this.tbCusName.Text);
		string selectedValue4 = this.ddlType.SelectedValue;
		string selectedValue5 = this.ddlRecType.SelectedValue;
		string selectedValue6 = this.ddlChargeStyle.SelectedValue;
		string selectedValue7 = this.ddlChargeAccount.SelectedValue;
		string selectedValue8 = this.ddlInvoiceClass.SelectedValue;
		string selectedValue9 = this.ddlItem.SelectedValue;
		string selectedValue10 = this.ddlStatus.SelectedValue;
		string text7 = FunLibrary.ChkInput(this.tbRemark.Text);
		if (selectedValue != "-1")
		{
			text = text + " and DeptID=" + selectedValue;
		}
		if (text2 != "")
		{
			text = text + " and _Date>='" + text2 + "'";
		}
		if (text3 != "")
		{
			text = text + " and _Date<='" + text3 + " 23:59:59'";
		}
		if (text4 != "")
		{
			text = text + " and ChkDate>='" + text4 + "'";
		}
		if (text5 != "")
		{
			text = text + " and ChkDate<='" + text5 + " 23:59:59'";
		}
		if (selectedValue2 != "-1")
		{
			text = text + " and PersonID=" + selectedValue2;
		}
		if (selectedValue3 != "-1")
		{
			text = text + " and ChkOperatorID=" + selectedValue3;
		}
		if (text6 != "")
		{
			text = text + " and CustomerName like '%" + text6 + "%'";
		}
		if (selectedValue4 != "")
		{
			text = text + " and Type='" + selectedValue4 + "'";
		}
		if (selectedValue5 != "")
		{
			text = text + " and RecType='" + selectedValue5 + "'";
		}
		if (selectedValue6 != "-1")
		{
			text = text + " and ChargeModeID=" + selectedValue6;
		}
		if (selectedValue7 != "-1")
		{
			text = text + " and AccountID=" + selectedValue7;
		}
		if (selectedValue8 != "-1")
		{
			text = text + " and InvoiceClassID=" + selectedValue8;
		}
		if (selectedValue9 != "-1")
		{
			text = text + " and ItemID=" + selectedValue9;
		}
		if (selectedValue10 != "")
		{
			text = text + " and Status='" + selectedValue10 + "'";
		}
		if (text7 != "")
		{
			text = text + " and Remark like '%" + text7 + "%'";
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
