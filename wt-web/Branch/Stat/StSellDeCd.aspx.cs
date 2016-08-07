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

public partial class Branch_Stat_StSellDeCd : Page, IRequiresSessionState
{
	private int f;

	private string type;

	

	public string Str_Type
	{
		get
		{
			return this.type;
		}
	}


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["f"], out this.f);
		if (this.f == 0)
		{
			this.type = "销售";
		}
		else
		{
			this.type = "退货";
		}
		if (!base.IsPostBack)
		{
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
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
			this.ddlChkOperator.DataSource = dataSource;
			this.ddlChkOperator.DataTextField = "_Name";
			this.ddlChkOperator.DataValueField = "ID";
			this.ddlChkOperator.DataBind();
			this.ddlChkOperator.Items.Insert(0, new ListItem("", "-1"));
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " Status='已审核' ";
		if (this.f == 0)
		{
			text += " and Type='销售' ";
		}
		else
		{
			text += " and Type='退货' ";
		}
		string selectedValue = this.ddlBranch.SelectedValue;
		string selectedValue2 = this.ddlStock.SelectedValue;
		string selectedValue3 = this.ddlPerson.SelectedValue;
		string selectedValue4 = this.ddlOperator.SelectedValue;
		string text2 = FunLibrary.ChkInput(this.tbDateB.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbDateE.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbCusName.Text).Replace("\"", "");
		string selectedValue5 = this.ddlChkOperator.SelectedValue;
		string text5 = FunLibrary.ChkInput(this.tbChkDateB.Text).Replace("\"", "");
		string text6 = FunLibrary.ChkInput(this.tbChkDateE.Text).Replace("\"", "");
		string text7 = FunLibrary.ChkInput(this.tbGoodsNO.Text).Replace("\"", "");
		string text8 = FunLibrary.ChkInput(this.tbName.Text).Replace("\"", "");
		string text9 = FunLibrary.ChkInput(this.tbSpec.Text).Replace("\"", "");
		string text10 = FunLibrary.ChkInput(this.tbBrand.Text).Replace("\"", "");
		decimal d = 0m;
		decimal.TryParse(this.tbTotalB.Text, out d);
		decimal d2 = 0m;
		decimal.TryParse(this.tbTotalE.Text, out d2);
		string text11 = FunLibrary.ChkInput(this.tbArea.Text).Replace("\"", "");
		string text12 = FunLibrary.ChkInput(this.tbCusclass.Text).Replace("\"", "");
		if (selectedValue != "-1")
		{
			text = text + " and DeptID='" + selectedValue + "'";
		}
		if (selectedValue2 != "-1")
		{
			text = text + " and StockID='" + selectedValue2 + "'";
		}
		if (selectedValue3 != "-1")
		{
			text = text + " and PersonID='" + selectedValue3 + "'";
		}
		if (selectedValue4 != "-1")
		{
			text = text + " and OperatorID='" + selectedValue4 + "'";
		}
		if (text2 != "")
		{
			text = text + " and _Date>='" + text2 + "'";
		}
		if (text3 != "")
		{
			text = text + " and _Date<='" + text3 + " 23:59:59'";
		}
		if (text5 != "")
		{
			text = text + " and ChkDate>='" + text5 + "'";
		}
		if (text6 != "")
		{
			text = text + " and ChkDate<='" + text6 + " 23:59:59'";
		}
		if (text4 != "")
		{
			text = text + " and Customer like '%" + text4 + "%'";
		}
		if (selectedValue5 != "-1")
		{
			text = text + " and ChkOperatorID='" + selectedValue5 + "'";
		}
		if (text7 != "")
		{
			text = text + " and GoodsNO='" + text7 + "'";
		}
		if (text8 != "")
		{
			text = text + " and _Name='" + text8 + "'";
		}
		if (text9 != "")
		{
			text = text + " and Spec='" + text9 + "'";
		}
		if (text10 != "")
		{
			text = text + " and ProductBrand='" + text10 + "'";
		}
		if (d > 0m)
		{
			text = text + " and Total>=" + d.ToString();
		}
		if (d2 > 0m)
		{
			text = text + " and Total<=" + d2.ToString();
		}
		if (text11 != "")
		{
			text = text + " and Area like '%" + text11 + "%'";
		}
		if (text12 != "")
		{
			text = text + " and CusClass like '%" + text12 + "%'";
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
