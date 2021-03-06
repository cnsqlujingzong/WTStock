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

public partial class Headquarters_Stat_StStockDeCd : Page, IRequiresSessionState
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
			this.type = "入";
		}
		else
		{
			this.type = "出";
		}
		if (!base.IsPostBack)
		{
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
			OtherFunction.BindStocks(this.ddlStock, " bStop=0 ");
			DataTable dataSource = DALCommon.GetDataList("StaffList", "[ID],[_Name]", " Status=0 ").Tables[0];
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
			if (this.f == 0)
			{
				OtherFunction.BindINReason(this.ddlReason, "");
				this.cusname.Visible = false;
			}
			else
			{
				OtherFunction.BindOutReason(this.ddlReason, "");
			}
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " Status='已审核' ";
		string selectedValue = this.ddlBranch.SelectedValue;
		string selectedValue2 = this.ddlStock.SelectedValue;
		string selectedValue3 = this.ddlPerson.SelectedValue;
		string selectedValue4 = this.ddlOperator.SelectedValue;
		string text2 = FunLibrary.ChkInput(this.tbDateB.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbDateE.Text).Replace("\"", "");
		string selectedValue5 = this.ddlReason.SelectedValue;
		string selectedValue6 = this.ddlChkOperator.SelectedValue;
		string text4 = FunLibrary.ChkInput(this.tbChkDateB.Text).Replace("\"", "");
		string text5 = FunLibrary.ChkInput(this.tbChkDateE.Text).Replace("\"", "");
		string text6 = FunLibrary.ChkInput(this.tbGoodsNO.Text).Replace("\"", "");
		string text7 = FunLibrary.ChkInput(this.tbName.Text).Replace("\"", "");
		string text8 = FunLibrary.ChkInput(this.tbSpec.Text).Replace("\"", "");
		string text9 = FunLibrary.ChkInput(this.tbBrand.Text).Replace("\"", "");
		decimal d = 0m;
		decimal.TryParse(this.tbTotalB.Text, out d);
		decimal d2 = 0m;
		decimal.TryParse(this.tbTotalE.Text, out d2);
		string text10 = this.tbBillRemark.Text.Trim();
		string text11 = this.tbRemark.Text.Trim();
		string text12 = FunLibrary.ChkInput(this.tbUserName.Text);
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
		if (text4 != "")
		{
			text = text + " and ChkDate>='" + text4 + "'";
		}
		if (text5 != "")
		{
			text = text + " and ChkDate<='" + text5 + " 23:59:59'";
		}
		if (selectedValue5 != "-1")
		{
			text = text + " and ReasonID='" + selectedValue5 + "'";
		}
		if (selectedValue6 != "-1")
		{
			text = text + " and ChkOperatorID='" + selectedValue6 + "'";
		}
		if (text6 != "")
		{
			text = text + " and GoodsNO='" + text6 + "'";
		}
		if (text7 != "")
		{
			text = text + " and _Name='" + text7 + "'";
		}
		if (text8 != "")
		{
			text = text + " and Spec='" + text8 + "'";
		}
		if (text9 != "")
		{
			text = text + " and ProductBrand='" + text9 + "'";
		}
		if (d > 0m)
		{
			text = text + " and Total>=" + d.ToString();
		}
		if (d2 > 0m)
		{
			text = text + " and Total<=" + d2.ToString();
		}
		if (text10 != "")
		{
			text = text + " and BillRemark like '%" + text10 + "%' ";
		}
		if (text11 != "")
		{
			text = text + " and Remark like '%" + text11 + "%' ";
		}
		if (text12 != "")
		{
			text = text + " and CustomerName like'%" + text12 + "%'";
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}

	protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlBranch.SelectedValue != "-1")
		{
			OtherFunction.BindStocks(this.ddlStock, " bStop=0 and DeptID=" + this.ddlBranch.SelectedValue);
		}
		else
		{
			OtherFunction.BindStocks(this.ddlStock, " bStop=0 ");
		}
	}
}
