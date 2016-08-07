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

public partial class Headquarters_Customer_SchHCus : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = 0;
			this.slCusClass.Items.Add(new ListItem("", "-1"));
			DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
			OtherFunction.BindDrpLevelClass("-1", dt, "©À", "-1", this.slCusClass);
			OtherFunction.BindArea(this.ddlArea);
			OtherFunction.BindFrom(this.ddlFrom);
			OtherFunction.BindStaff(this.ddlSeller, "bSeller=1 and DeptID=1 ");
			OtherFunction.BindMember(this.ddlMember);
			OtherFunction.BindCustomerStatus(this.ddlStatus);
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " 1=1 ";
		string value = this.slCusClass.Items[this.slCusClass.SelectedIndex].Value;
		string text2 = FunLibrary.ChkInput(this.tbArea.Text);
		string selectedValue = this.ddlFrom.SelectedValue;
		string selectedValue2 = this.ddlSeller.SelectedValue;
		string selectedValue3 = this.ddlMember.SelectedValue;
		string selectedValue4 = this.ddlStatus.SelectedValue;
		string text3 = FunLibrary.ChkInput(this.tbCusID.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbLinkMan.Text).Replace("\"", "");
		string text5 = FunLibrary.ChkInput(this.tbTel.Text).Replace("\"", "");
		string text6 = FunLibrary.ChkInput(this.tbQQ.Text).Replace("\"", "");
		string text7 = FunLibrary.ChkInput(this.tbAdr.Text).Replace("\"", "");
		string text8 = FunLibrary.ChkInput(this.tbDate_Begin.Text).Replace("\"", "");
		string text9 = FunLibrary.ChkInput(this.tbDate_End.Text).Replace("\"", "");
		int num = 0;
		int num2 = 0;
		int.TryParse(this.tbDays.Text, out num);
		int.TryParse(this.tbCounts.Text, out num2);
		int num3 = int.Parse(this.ddlMPlan.SelectedValue);
		int num4 = 0;
		int num5 = 0;
		if (this.chkBaack.Checked)
		{
			num4 = 1;
		}
		if (this.chkTrace.Checked)
		{
			num5 = 1;
		}
		int num6 = 0;
		int.TryParse(this.tbDateOver.Text, out num6);
		if (num6 > 0)
		{
			text += string.Format(" and ID not in(select CustomerID from ServicesList where Time_Payee>='{0}' union all select CustomerID from Sell where _Date>='{0}' union all select CustomerID from MeterReading mr left join Lease l on mr.BillID=l.ID where mr._Date>='{0}' union all select CustomerID from CustomerTrack where _Date>='{0}')", DateTime.Now.AddDays((double)(-(double)num6)).ToString("yyyy-MM-dd"));
		}
		if (value != "-1")
		{
			text = text + " and _Level like '" + value + "%'";
		}
		if (selectedValue != "-1")
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and FromID=",
				Convert.ToInt32(selectedValue),
				""
			});
		}
		if (selectedValue2 != "-1")
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and SellerID=",
				Convert.ToInt32(selectedValue2),
				""
			});
		}
		if (selectedValue3 != "-1")
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and MemberID=",
				Convert.ToInt32(selectedValue3),
				""
			});
		}
		if (selectedValue4 != "-1" && selectedValue4 != "0")
		{
			text = text + " and Status='" + this.ddlStatus.SelectedItem.Text + "'";
		}
		if (text2 != "")
		{
			text = text + " and Area='" + text2 + "'";
		}
		if (text3 != "")
		{
			text = text + " and CustomerNO like'%" + text3 + "%'";
		}
		if (text4 != "")
		{
			text = text + " and LinkMan='" + text4 + "'";
		}
		if (text5 != "")
		{
			text = text + " and Tel='" + text5 + "'";
		}
		if (text6 != "")
		{
			text = text + " and QQ='" + text6 + "'";
		}
		if (text7 != "")
		{
			text = text + " and Adr like'%" + text7 + "%'";
		}
		if (num4 == 1)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and bCall=",
				num4,
				""
			});
		}
		if (num5 == 1)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and bTrack=",
				num5,
				""
			});
		}
		if (text8 != "")
		{
			text = text + " and _Date>='" + text8 + "'";
		}
		if (text9 != "")
		{
			text = text + " and _Date<='" + text9 + " 23:59:59'";
		}
		if (num3 == 1)
		{
			text += " and exists(select mp.ID from MaintenancePlan mp left join DeviceList dl on mp.DevID=dl.ID where dl.CustomerID=ks_customer.ID and EndDate>getdate())";
		}
		else if (num3 == 2)
		{
			text += " and not exists(select mp.ID from MaintenancePlan mp left join DeviceList dl on mp.DevID=dl.ID where dl.CustomerID=ks_customer.ID and EndDate>getdate())";
		}
		if (num > 0 && num2 > 0)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and exists(select count(1) from ServicesList where Time_Make>='",
				DateTime.Today.AddDays((double)(-(double)num - 1)).ToString("yyyy-MM-dd"),
				"' and CustomerID=ks_customer.ID having count(1)>=",
				num2,
				")"
			});
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
