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
using wt.OtherLibrary;

public partial class Headquarters_Customer_Mtnsconcd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			DataTable dataSource = DALCommon.GetDataList("ContractType", "[ID],[_Name]", "").Tables[0];
			this.ddlConType.DataSource = dataSource;
			this.ddlConType.DataTextField = "_Name";
			this.ddlConType.DataValueField = "ID";
			this.ddlConType.DataBind();
			this.ddlConType.Items.Insert(0, new ListItem("", "-1"));
			OtherFunction.BindStaff(this.ddlSeller, "DeptID=1 and Status=0");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " 1=1 ";
		string text2 = FunLibrary.ChkInput(this.tbContractNO.Text);
		string selectedValue = this.ddlConType.SelectedValue;
		string text3 = FunLibrary.ChkInput(this.tbTakeB.Text);
		string text4 = FunLibrary.ChkInput(this.tbTakeE.Text);
		string text5 = this.ddlStatus.SelectedItem.Text;
		string text6 = FunLibrary.ChkInput(this.tbCusName.Text);
		string text7 = FunLibrary.ChkInput(this.tbLinkman.Text);
		string text8 = FunLibrary.ChkInput(this.tbLinkTel.Text);
		string text9 = FunLibrary.ChkInput(this.tbStartB.Text);
		string text10 = FunLibrary.ChkInput(this.tbStartE.Text);
		string text11 = FunLibrary.ChkInput(this.tbEndB.Text);
		string text12 = FunLibrary.ChkInput(this.tbEndE.Text);
		string text13 = FunLibrary.ChkInput(this.tbAdr.Text);
		string text14 = FunLibrary.ChkInput(this.tbRemark.Text);
		string selectedValue2 = this.ddlSeller.SelectedValue;
		string selectedValue3 = this.ddlOperator.SelectedValue;
		if (!text2.Equals(""))
		{
			text += string.Format(" and ContractNO like '%{0}%' ", text2);
		}
		if (!selectedValue.Equals("-1"))
		{
			text += string.Format(" and ContractTypeID={0} ", selectedValue);
		}
		if (!text3.Equals(""))
		{
			text += string.Format(" and _Date>='{0}' ", text3);
		}
		if (!text4.Equals(""))
		{
			text += string.Format(" and _Date<='{0}' ", text4);
		}
		if (!text5.Equals(""))
		{
			text += string.Format(" and Status='{0}' ", text5);
		}
		if (!text6.Equals(""))
		{
			text += string.Format(" and CustomerName like '%{0}%' ", text6);
		}
		if (!text7.Equals(""))
		{
			text += string.Format(" and LinkMan like '%{0}%' ", text7);
		}
		if (!text8.Equals(""))
		{
			text += string.Format(" and Tel like '%{0}%' ", text8);
		}
		if (!text9.Equals(""))
		{
			text += string.Format(" and StartDate>='{0}' ", text9);
		}
		if (!text10.Equals(""))
		{
			text += string.Format(" and StartDate<='{0}' ", text10);
		}
		if (!text11.Equals(""))
		{
			text += string.Format(" and EndDate>='{0}' ", text11);
		}
		if (!text12.Equals(""))
		{
			text += string.Format(" and EndDate<='{0}' ", text12);
		}
		if (!text13.Equals(""))
		{
			text += string.Format(" and Adr like '%{0}%' ", text13);
		}
		if (!text14.Equals(""))
		{
			text += string.Format(" and Remark like '%{0}%' ", text14);
		}
		if (!selectedValue2.Equals("-1"))
		{
			text += string.Format(" and SellerID={0} ", selectedValue2);
		}
		if (!selectedValue3.Equals("-1"))
		{
			text += string.Format(" and OperatorID={0} ", selectedValue3);
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
