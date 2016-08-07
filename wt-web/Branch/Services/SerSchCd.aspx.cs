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

public partial class Branch_Services_SerSchCd : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			OtherFunction.BindBranch(this.ddlTake);
			this.ddlTake.Items.Insert(0, new ListItem("", "-1"));
			OtherFunction.BindBranch(this.ddlDisposal);
			this.ddlDisposal.Items.Insert(0, new ListItem("", "-1"));
			OtherFunction.BindTakeStyle(this.ddlTakeStyle);
			this.ddlTakeStyle.Items.Insert(0, new ListItem("", "-1"));
			DataTable dataSource = DALCommon.GetDataList("StaffList", "[ID],[_Name]", " Status=0 and deptid=1 ").Tables[0];
			this.ddlOperator.DataSource = dataSource;
			this.ddlOperator.DataTextField = "_Name";
			this.ddlOperator.DataValueField = "ID";
			this.ddlOperator.DataBind();
			this.ddlOperator.Items.Insert(0, new ListItem("", "-1"));
			this.ddlMakeOper.DataSource = dataSource;
			this.ddlMakeOper.DataTextField = "_Name";
			this.ddlMakeOper.DataValueField = "ID";
			this.ddlMakeOper.DataBind();
			this.ddlMakeOper.Items.Insert(0, new ListItem("", "-1"));
			OtherFunction.BindWarranty(this.ddlRepStatus);
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindProductModel(this.ddlModel, "");
			OtherFunction.BindServicesType(this.ddlSerType);
			this.ddlSerType.Items.Insert(0, new ListItem("", "-1"));
			this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
			this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
			this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
			this.ddlRepStatus.Items.Remove(new ListItem("新建...", "0"));
			OtherFunction.BindServiceLevel(this.ddlPRI);
			OtherFunction.BindArea(this.ddlArea);
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " 1=1 ";
		string selectedValue = this.ddlTake.SelectedValue;
		string selectedValue2 = this.ddlDisposal.SelectedValue;
		string text2 = FunLibrary.ChkInput(this.tbTakeB.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbTakeE.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbMakeB.Text).Replace("\"", "");
		string text5 = FunLibrary.ChkInput(this.tbMakeE.Text).Replace("\"", "");
		string text6 = FunLibrary.ChkInput(this.tbBillID.Text);
		string selectedValue3 = this.ddlTakeStyle.SelectedValue;
		string text7 = FunLibrary.ChkInput(this.tbSupplierNO.Text);
		string selectedValue4 = this.ddlMakeOper.SelectedValue;
		string text8 = FunLibrary.ChkInput(this.tbSaveNO.Text);
		string selectedValue5 = this.ddlOperator.SelectedValue;
		string text9 = FunLibrary.ChkInput(this.tbCusName.Text);
		string text10 = FunLibrary.ChkInput(this.tbLinkMan.Text);
		string text11 = FunLibrary.ChkInput(this.tbTel.Text);
		string text12 = FunLibrary.ChkInput(this.tbAdr.Text);
		string text13 = FunLibrary.ChkInput(this.tbBrand.Text);
		string text14 = FunLibrary.ChkInput(this.tbClass.Text);
		string text15 = FunLibrary.ChkInput(this.tbModel.Text);
		string text16 = FunLibrary.ChkInput(this.tbSN.Text);
		string selectedValue6 = this.ddlRepStatus.SelectedValue;
		string text17 = FunLibrary.ChkInput(this.tbDisposalOper.Text);
		string text18 = FunLibrary.ChkInput(this.tbFault.Text);
		string text19 = FunLibrary.ChkInput(this.tbRemark.Text);
		string text20 = this.ddlcurStatus.SelectedItem.Text;
		string text21 = FunLibrary.ChkInput(this.tbChkTimeStart.Text);
		string text22 = FunLibrary.ChkInput(this.tbChkTimeEnd.Text);
		string text23 = FunLibrary.ChkInput(this.tbOverTimeStart.Text);
		string text24 = FunLibrary.ChkInput(this.tbOverTimeEnd.Text);
		string text25 = FunLibrary.ChkInput(this.tbJSTimeStart.Text);
		string text26 = FunLibrary.ChkInput(this.tbJSTimeEnd.Text);
		string text27 = FunLibrary.ChkInput(this.tbArea.Text);
		string text28 = FunLibrary.ChkInput(this.tbSellContNO.Text);
		int num = int.Parse(this.ddlSerType.SelectedValue);
		string text29 = FunLibrary.ChkInput(this.tbBackViewStart.Text);
		string text30 = FunLibrary.ChkInput(this.tbBackViewEnd.Text);
		if (selectedValue != "-1")
		{
			text = text + " and TakeOverID=" + selectedValue;
		}
		if (selectedValue2 != "-1")
		{
			text = text + " and DisposalID=" + selectedValue2;
		}
		if (text2 != "")
		{
			text = text + " and Time_TakeOver>='" + text2 + "'";
		}
		if (text3 != "")
		{
			text = text + " and Time_TakeOver<='" + text3 + " 23:59:59'";
		}
		if (text4 != "")
		{
			text = text + " and Time_Make>='" + text4 + "'";
		}
		if (text5 != "")
		{
			text = text + " and Time_Make<='" + text5 + " 23:59:59'";
		}
		if (text6 != "")
		{
			text = text + " and BillID like '%" + text6 + "%'";
		}
		if (selectedValue3 != "-1")
		{
			text = text + " and TakeStyleID=" + selectedValue3;
		}
		if (text7 != "")
		{
			text = text + " and SupplierID like '%" + text7 + "%'";
		}
		if (selectedValue4 != "-1")
		{
			text = text + " and PersonID=" + selectedValue4;
		}
		if (text8 != "")
		{
			text = text + " and SaveID like '%" + text8 + "%'";
		}
		if (selectedValue5 != "-1")
		{
			text = text + " and OperatorID=" + selectedValue5;
		}
		if (text9 != "")
		{
			text = text + " and CustomerName like '%" + text9 + "%'";
		}
		if (text10 != "")
		{
			text = text + " and LinkMan like '%" + text10 + "%'";
		}
		if (text11 != "")
		{
			text = text + " and Tel like '%" + text11 + "%'";
		}
		if (text12 != "")
		{
			text = text + " and Adr like '%" + text12 + "%'";
		}
		if (text13 != "")
		{
			text = text + " and ProductBrand like '%" + text13 + "%'";
		}
		if (text14 != "")
		{
			text = text + " and ProductClass like '%" + text14 + "%'";
		}
		if (text15 != "")
		{
			text = text + " and ProductModel like '%" + text15 + "%'";
		}
		if (text16 != "")
		{
			string text31 = text;
			text = string.Concat(new string[]
			{
				text31,
				" and (ProductSN1 like '%",
				text16,
				"%' or ProductSN2 like '%",
				text16,
				"%')"
			});
		}
		if (selectedValue6 != "-1")
		{
			text = text + " and WarrantyID=" + selectedValue6;
		}
		if (text17 != "")
		{
			text = text + " and DisposalOper like '%" + text17 + "%'";
		}
		if (this.ddlPRI.SelectedItem.Text != "")
		{
			text = text + " and _PRI='" + this.ddlPRI.SelectedItem.Text + "'";
		}
		if (this.ddlbRepair.SelectedItem.Text != "")
		{
			text = text + " and bRepair='" + this.ddlbRepair.SelectedItem.Value + "'";
		}
		if (text20 != "")
		{
			text = text + " and curStatus='" + this.ddlcurStatus.SelectedItem.Text + "'";
		}
		if (text18 != "")
		{
			text = text + " and Fault like '%" + text18 + "%'";
		}
		if (text19 != "")
		{
			text = text + " and Remark like '%" + text19 + "%'";
		}
		if (text29 != "")
		{
			text = text + " and VisitDate>='" + text29 + "'";
		}
		if (text30 != "")
		{
			text = text + " and VisitDate<='" + text30 + " 23:59:59'";
		}
		if (text23 != "")
		{
			text = text + " and Time_Over>='" + text23 + "'";
		}
		if (text24 != "")
		{
			text = text + " and Time_Over<='" + text24 + " 23:59:59'";
		}
		if (text25 != "")
		{
			text = text + " and Time_Payee>='" + text25 + "'";
		}
		if (text26 != "")
		{
			text = text + " and Time_Payee<='" + text26 + " 23:59:59'";
		}
		if (text21 != "")
		{
			text = text + " and Time_Close>='" + text21 + "'";
		}
		if (text22 != "")
		{
			text = text + " and Time_Close<='" + text22 + " 23:59:59'";
		}
		if (text27 != "")
		{
			text = text + " and Area like '%" + text27 + "%'";
		}
		if (text28 != "")
		{
			text = text + " and ContractNO  like '%" + text28 + "%'";
		}
		if (this.cbSeeBack.Checked)
		{
			text += " and bCall ='☆'";
		}
		if (num > 0)
		{
			text = text + " and TypeID=" + num;
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
