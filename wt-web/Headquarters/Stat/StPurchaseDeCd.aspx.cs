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

public partial class Headquarters_Stat_StPurchaseDeCd : Page, IRequiresSessionState
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
		FunLibrary.ChkHead();
		int.TryParse(base.Request["f"], out this.f);
		if (this.f == 0)
		{
			this.type = "采购";
		}
		else
		{
			this.type = "退货";
		}
		if (!base.IsPostBack)
		{
			OtherFunction.BindStocks(this.ddlStock, " bStop=0 ");
			DataTable dataSource = DALCommon.GetDataList("StaffList", "[ID],[_Name]", " Status=0 ").Tables[0];
			this.ddlOperator.DataSource = dataSource;
			this.ddlOperator.DataTextField = "_Name";
			this.ddlOperator.DataValueField = "ID";
			this.ddlOperator.DataBind();
			this.ddlOperator.Items.Insert(0, new ListItem("", "-1"));
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
			text += " and Type='采购' ";
		}
		else
		{
			text += " and Type='退货' ";
		}
		string text2 = FunLibrary.ChkInput(this.tbProvider.Text);
		string selectedValue = this.ddlStock.SelectedValue;
		string selectedValue2 = this.ddlOperator.SelectedValue;
		string text3 = FunLibrary.ChkInput(this.tbDateB.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbDateE.Text).Replace("\"", "");
		string selectedValue3 = this.ddlChkOperator.SelectedValue;
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
		if (text2 != "")
		{
			text = text + " and Provider='" + text2 + "'";
		}
		if (selectedValue != "-1")
		{
			text = text + " and StockID='" + selectedValue + "'";
		}
		if (selectedValue2 != "-1")
		{
			text = text + " and OperatorID='" + selectedValue2 + "'";
		}
		if (text3 != "")
		{
			text = text + " and _Date>='" + text3 + "'";
		}
		if (text4 != "")
		{
			text = text + " and _Date<='" + text4 + " 23:59:59'";
		}
		if (text5 != "")
		{
			text = text + " and ChkDate>='" + text5 + "'";
		}
		if (text6 != "")
		{
			text = text + " and ChkDate<='" + text6 + " 23:59:59'";
		}
		if (selectedValue3 != "-1")
		{
			text = text + " and ChkOperatorID='" + selectedValue3 + "'";
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
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
