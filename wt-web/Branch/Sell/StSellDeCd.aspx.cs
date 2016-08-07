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

public partial class Branch_Sell_StSellDeCd : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			this.ddlBranch.Items.Clear();
			this.ddlBranch.Items.Add(new ListItem(this.Session["Session_wtBranch"].ToString(), this.Session["Session_wtBranchID"].ToString()));
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
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " DeptID=" + (string)this.Session["Session_wtBranchID"];
		string selectedValue = this.ddlDept.SelectedValue;
		string selectedValue2 = this.ddlBranch.SelectedValue;
		string selectedValue3 = this.ddlStock.SelectedValue;
		string selectedValue4 = this.ddlPerson.SelectedValue;
		string selectedValue5 = this.ddlOperator.SelectedValue;
		string text2 = FunLibrary.ChkInput(this.tbDateB.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbDateE.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbCusName.Text).Replace("\"", "");
		string selectedValue6 = this.ddlChkOperator.SelectedValue;
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
		string text11 = FunLibrary.ChkInput(this.tbSndOper.Text).Replace("\"", "");
		string selectedValue7 = this.ddlStatus.SelectedValue;
		if (selectedValue2 != "-1")
		{
			text = text + " and DeptID='" + selectedValue2 + "'";
		}
		if (selectedValue3 != "-1")
		{
			text = text + " and ID in(select BillID from SellDetail where StockID=" + selectedValue3 + ")";
		}
		if (selectedValue4 != "-1")
		{
			text = text + " and PersonID='" + selectedValue4 + "'";
		}
		if (selectedValue5 != "-1")
		{
			text = text + " and OperatorID='" + selectedValue5 + "'";
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
			text = text + " and _Name like '%" + text4 + "%'";
		}
		if (selectedValue6 != "-1")
		{
			text = text + " and ChkOperatorID='" + selectedValue6 + "'";
		}
		if (text7 != "")
		{
			text = text + " and ID in(select BillID from xs_selldetail where GoodsNO like '%" + text7 + "%')";
		}
		if (text8 != "")
		{
			text = text + " and ID in(select BillID from xs_selldetail where _Name like '%" + text8 + "%')";
		}
		if (text9 != "")
		{
			text = text + " and ID in(select BillID from xs_selldetail where Spec like '%" + text9 + "%')";
		}
		if (text10 != "")
		{
			text = text + " and ID in(select BillID from xs_selldetail where ProductBrand='" + text10 + "')";
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
			text = text + " and SndOperator like '%" + text11 + "%'";
		}
		if (selectedValue7 != "0")
		{
			text = text + " and Status='" + selectedValue7 + "'";
		}
		if (selectedValue != "")
		{
			text = text + " and StaffDeptID ='" + selectedValue + "'";
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}

	protected void ddlOperator_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ddlDept.Items.Clear();
		string selectedValue = this.ddlOperator.SelectedValue;
		if (selectedValue != "")
		{
			DataTable dataTable = DALCommon.GetDataList("StaffList", " StaffDeptID ", " [ID]= " + selectedValue).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				string text = dataTable.Rows[0][0].ToString();
				if (text != "")
				{
					DataTable dataSource = DALCommon.GetDataList("StaffDept", " [ID] ,[_Name] ", " [ID]= " + text).Tables[0];
					this.ddlDept.DataSource = dataSource;
					this.ddlDept.DataTextField = "_Name";
					this.ddlDept.DataValueField = "ID";
					this.ddlDept.DataBind();
					this.ddlDept.Items.Insert(0, new ListItem("", ""));
				}
			}
		}
	}

	protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ddlDept.Items.Clear();
		string selectedValue = this.ddlBranch.SelectedValue;
		if (selectedValue == "-1")
		{
			DataTable dataSource = DALCommon.GetDataList("StaffDept", " [ID],[_Name] ", " ").Tables[0];
			this.ddlDept.DataSource = dataSource;
			this.ddlDept.DataTextField = "_Name";
			this.ddlDept.DataValueField = "ID";
			this.ddlDept.DataBind();
			this.ddlDept.Items.Insert(0, new ListItem("", ""));
		}
		else
		{
			DataTable dataSource = DALCommon.GetDataList("StaffDept", " [ID],[_Name] ", " [DeptID]= " + selectedValue).Tables[0];
			this.ddlDept.DataSource = dataSource;
			this.ddlDept.DataTextField = "_Name";
			this.ddlDept.DataValueField = "ID";
			this.ddlDept.DataBind();
			this.ddlDept.Items.Insert(0, new ListItem("", ""));
		}
	}
}
