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

public partial class Headquarters_Customer_DeviceCd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = 0;
			this.slCusClass.Items.Add(new ListItem("", "-1"));
			DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
			OtherFunction.BindDrpLevelClass("-1", dt, "├", "-1", this.slCusClass);
			OtherFunction.BindWarranty(this.ddlRepStatus);
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindProductModel(this.ddlModel, "");
			OtherFunction.BindProductAspect(this.ddlAspect);
			OtherFunction.BindArea(this.ddlArea);
			this.ddlArea.Items.Remove(new ListItem("新建...", "0"));
			this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
			this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
			this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
			this.ddlRepStatus.Items.Remove(new ListItem("新建...", "0"));
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " 1=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCusNO.Text);
		string text3 = FunLibrary.ChkInput(this.tbCusName.Text);
		string text4 = FunLibrary.ChkInput(this.tbLinkMan.Text);
		string text5 = FunLibrary.ChkInput(this.tbDept.Text);
		string text6 = FunLibrary.ChkInput(this.tbTel.Text);
		string text7 = FunLibrary.ChkInput(this.tbAdr.Text);
		string text8 = FunLibrary.ChkInput(this.tbBrand.Text);
		string text9 = FunLibrary.ChkInput(this.tbClass.Text);
		string text10 = FunLibrary.ChkInput(this.tbModel.Text);
		string text11 = FunLibrary.ChkInput(this.tbSN.Text);
		string text12 = FunLibrary.ChkInput(this.tbProt.Value);
		string selectedValue = this.ddlRepStatus.SelectedValue;
		string text13 = FunLibrary.ChkInput(this.tbAspect.Value);
		string text14 = FunLibrary.ChkInput(this.tbBuyFrom.Text);
		string text15 = FunLibrary.ChkInput(this.tbWStart.Text);
		string text16 = FunLibrary.ChkInput(this.tbWEnd.Text);
		string text17 = FunLibrary.ChkInput(this.tbLastDate.Text);
		string text18 = FunLibrary.ChkInput(this.tbFinD.Text);
		string text19 = FunLibrary.ChkInput(this.tbPStart.Text);
		string text20 = FunLibrary.ChkInput(this.tbPEnd.Text);
		string text21 = FunLibrary.ChkInput(this.tbContractNO.Text);
		string text22 = FunLibrary.ChkInput(this.tbRemark.Text);
		string value = this.slCusClass.Items[this.slCusClass.SelectedIndex].Value;
		string text23 = FunLibrary.ChkInput(this.tbArea.Text);
		int num = int.Parse(this.ddlMPlan.SelectedValue);
		int num2 = 0;
		int num3 = 0;
		int.TryParse(this.tbDays.Text, out num2);
		int.TryParse(this.tbCounts.Text, out num3);
		if (text2 != "")
		{
			text = text + " and DeviceNO like '%" + text2 + "%'";
		}
		if (text3 != "")
		{
			text = text + " and _Name like '%" + text3 + "%'";
		}
		if (text4 != "")
		{
			text = text + " and LinkMan like '%" + text4 + "%'";
		}
		if (text5 != "")
		{
			text = text + " and CusDept like '%" + text5 + "%'";
		}
		if (text6 != "")
		{
			text = text + " and Tel like '%" + text6 + "%'";
		}
		if (text7 != "")
		{
			text = text + " and Adr like '%" + text7 + "%'";
		}
		if (text8 != "")
		{
			text = text + " and ProductBrand like '%" + text8 + "%'";
		}
		if (text9 != "")
		{
			text = text + " and ProductClass like '%" + text9 + "%'";
		}
		if (text10 != "")
		{
			text = text + " and ProductModel like '%" + text10 + "%'";
		}
		if (text11 != "")
		{
			string text24 = text;
			text = string.Concat(new string[]
			{
				text24,
				" and (ProductSN1 like '%",
				text11,
				"%' or ProductSN2 like '%",
				text11,
				"%')"
			});
		}
		if (text12 != "")
		{
			text = text + " and MaintenancePeriod like '%" + text12 + "%'";
		}
		if (selectedValue != "-1")
		{
			text = text + " and WarrantyID=" + selectedValue;
		}
		if (text13 != "")
		{
			text = text + " and ProductAspect like '%" + text13 + "%'";
		}
		if (text14 != "")
		{
			text = text + " and BuyFrom like '%" + text14 + "%'";
		}
		if (text15 != "")
		{
			text = text + " and WarrantyStart>='" + text15 + "'";
		}
		if (text16 != "")
		{
			text = text + " and WarrantyEnd<='" + text16 + " 23:59:59'";
		}
		if (text19 != "")
		{
			text = text + " and ContractWarrantyStart>='" + text19 + "'";
		}
		if (text20 != "")
		{
			text = text + " and ContractWarrantyEnd<='" + text20 + " 23:59:59'";
		}
		if (text17 != "")
		{
			text = text + " and Repairlately like '%" + text17 + "%'";
		}
		if (text18 != "")
		{
			text = text + " and RepairWarrantyEnd like '%" + text18 + "%'";
		}
		if (text21 != "")
		{
			text = text + " and ContractNO like '%" + text21 + "%'";
		}
		if (text22 != "")
		{
			text = text + " and Remark like '%" + text22 + "%'";
		}
		if (value != "-1")
		{
			text = text + " and _Level like '" + value + "%'";
		}
		if (text23 != "")
		{
			text += string.Format(" and Area like '%{0}%' ", text23);
		}
		if (num == 3)
		{
			text += " and [ID] in (select DevID from ks_maintenanceplan where Status='正常')";
		}
		else if (num == 2)
		{
			text += " and not exists(select ID from MaintenancePlan where DevID=ks_device.ID)";
		}
		else if (num == 4)
		{
			text += " and [ID] in (select DevID from ks_maintenanceplan where Status='终止')";
		}
		else if (num == 5)
		{
			text += " and [ID] in (select DevID from ks_maintenanceplan where Status='已过期')";
		}
		if (num2 > 0 && num3 > 0)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and exists(select count(1) from ServicesList where Time_Make>='",
				DateTime.Today.AddDays((double)(-(double)num2 - 1)).ToString("yyyy-MM-dd"),
				"' and ((isnull(DeviceNO,'')<>'' and DeviceNO=ks_device.DeviceNO) or (isnull(ProductSN1,'')<>'' and ProductSN1=ks_device.ProductSN1)) having count(1)>=",
				num3,
				")"
			});
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}

	protected void btnCusInfo_Click(object sender, EventArgs e)
	{
		this.ddlDept.DataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
		this.ddlDept.DataTextField = "_Name";
		this.ddlDept.DataValueField = "ID";
		this.ddlDept.DataBind();
		this.ddlDept.Items.Insert(0, new ListItem("", ""));
		this.ddlLinkMan.DataSource = DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
		this.ddlLinkMan.DataTextField = "_Name";
		this.ddlLinkMan.DataValueField = "ID";
		this.ddlLinkMan.DataBind();
		this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
	}
}
