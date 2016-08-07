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

public partial class Branch_Stat_StLeaseCd : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			OtherFunction.BindStocks(this.ddlStock, " bStop=0 and DeptID=" + (string)this.Session["Session_wtBranchID"]);
			DataTable dataSource = DALCommon.GetDataList("StaffList", "[ID],[_Name]", " Status=0 and DeptID=" + (string)this.Session["Session_wtBranchID"]).Tables[0];
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
		string text = " Status=2 ";
		string selectedValue = this.ddlType.SelectedValue;
		string selectedValue2 = this.ddlStock.SelectedValue;
		string selectedValue3 = this.ddlPerson.SelectedValue;
		string selectedValue4 = this.ddlOperator.SelectedValue;
		string text2 = FunLibrary.ChkInput(this.tbDateB.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbDateE.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbCusName.Text).Replace("\"", "");
		string text5 = FunLibrary.ChkInput(this.tbGoodsNO.Text).Replace("\"", "");
		string text6 = FunLibrary.ChkInput(this.tbBrand.Text).Replace("\"", "");
		string text7 = FunLibrary.ChkInput(this.tbClass.Text).Replace("\"", "");
		string text8 = FunLibrary.ChkInput(this.tbModel.Text).Replace("\"", "");
		string text9 = FunLibrary.ChkInput(this.tbSN.Text).Replace("\"", "");
		if (selectedValue != "")
		{
			text = text + " and Type='" + selectedValue + "'";
		}
		if (selectedValue2 != "-1")
		{
			text = text + " and StockID='" + selectedValue2 + "'";
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
			text = text + " and _Date>='" + text2 + "'";
		}
		if (text3 != "")
		{
			text = text + " and _Date<='" + text3 + " 23:59:59'";
		}
		if (text4 != "")
		{
			text = text + " and Customer='" + text4 + "'";
		}
		if (text5 != "")
		{
			text = text + " and GoodsNO='" + text5 + "'";
		}
		if (text6 != "")
		{
			text = text + " and Brand='" + text6 + "'";
		}
		if (text7 != "")
		{
			text = text + " and Class='" + text7 + "'";
		}
		if (text8 != "")
		{
			text = text + " and Model='" + text8 + "'";
		}
		if (text9 != "")
		{
			string text10 = text;
			text = string.Concat(new string[]
			{
				text10,
				" and (ProductSN1='",
				text9,
				"' or ProductSN1='",
				text9,
				"')"
			});
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
