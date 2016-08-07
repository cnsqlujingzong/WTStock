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

public partial class Headquarters_Lease_LeaseCd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			OtherFunction.BindStocks(this.ddlStock, " bStop=0 and DeptID=1 ");
			DataTable dataSource = DALCommon.GetDataList("StaffList", "[ID],[_Name]", " Status=0 and DeptID=1 ").Tables[0];
			this.ddlOperator.DataSource = dataSource;
			this.ddlOperator.DataTextField = "_Name";
			this.ddlOperator.DataValueField = "ID";
			this.ddlOperator.DataBind();
			this.ddlOperator.Items.Insert(0, new ListItem("", "-1"));
			this.ddlPerson.DataSource = dataSource;
			this.ddlPerson.DataTextField = "_Name";
			this.ddlPerson.DataValueField = "ID";
			this.ddlPerson.DataBind();
			this.ddlPerson.Items.Insert(0, new ListItem("", "-1"));
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " 1=1 ";
		string selectedValue = this.ddlType.SelectedValue;
		string selectedValue2 = this.ddlStock.SelectedValue;
		string selectedValue3 = this.ddlPerson.SelectedValue;
		string selectedValue4 = this.ddlOperator.SelectedValue;
		string text2 = FunLibrary.ChkInput(this.tbDateB.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbDateE.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbDateDB.Text).Replace("\"", "");
		string text5 = FunLibrary.ChkInput(this.tbDateDE.Text).Replace("\"", "");
		string text6 = FunLibrary.ChkInput(this.tbCusName.Text).Replace("\"", "");
		string text7 = FunLibrary.ChkInput(this.tbGoodsNO.Text).Replace("\"", "");
		string text8 = FunLibrary.ChkInput(this.tbBrand.Text).Replace("\"", "");
		string text9 = FunLibrary.ChkInput(this.tbClass.Text).Replace("\"", "");
		string text10 = FunLibrary.ChkInput(this.tbModel.Text).Replace("\"", "");
		string text11 = FunLibrary.ChkInput(this.tbSN.Text).Replace("\"", "");
		if (selectedValue != "")
		{
			text = text + " and Type='" + selectedValue + "'";
		}
		if (selectedValue2 != "-1")
		{
			text = text + " and ID in(select BillID from zl_leasedevice where StockID=" + selectedValue2 + ") ";
		}
		if (selectedValue3 != "-1")
		{
			text = text + " and OperatorID='" + selectedValue3 + "'";
		}
		if (selectedValue4 != "-1")
		{
			text = text + " and SellerID='" + selectedValue4 + "'";
		}
		if (text2 != "")
		{
			text = text + " and StartDate>='" + text2 + "'";
		}
		if (text3 != "")
		{
			text = text + " and StartDate<='" + text3 + " 23:59:59'";
		}
		if (text4 != "")
		{
			text = text + " and EndDate>='" + text4 + "'";
		}
		if (text5 != "")
		{
			text = text + " and EndDate<='" + text5 + " 23:59:59'";
		}
		if (text6 != "")
		{
			text = text + " and CustomerName like '%" + text6 + "%'";
		}
		if (text7 != "")
		{
			text = text + " and ID in(select BillID from zl_leasedevice where GoodsNO like '%" + text7 + "%') ";
		}
		if (text8 != "")
		{
			text = text + " and ID in(select BillID from zl_leasedevice where Brand like '%" + text8 + "%') ";
		}
		if (text9 != "")
		{
			text = text + " and ID in(select BillID from zl_leasedevice where Class like '%" + text9 + "%') ";
		}
		if (text10 != "")
		{
			text = text + " and ID in(select BillID from zl_leasedevice where Model like '%" + text10 + "%') ";
		}
		if (text11 != "")
		{
			string text12 = text;
			text = string.Concat(new string[]
			{
				text12,
				" and (ID in(select BillID from zl_leasedevice where ProductSN1 like '%",
				text11,
				"%') or ID in(select BillID from zl_leasedevice where ProductSN2 like '%",
				text11,
				"%')) "
			});
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
