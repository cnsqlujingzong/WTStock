using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_Customer_LinkManMod : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r4"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DataTable dataTable = DALCommon.GetDataList("CustomerLinkMan", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbDept.Text = dataTable.Rows[0]["LinkManDept"].ToString();
				this.tbSex.Value = dataTable.Rows[0]["Sex"].ToString();
				this.tbPosition.Value = dataTable.Rows[0]["Posit"].ToString();
				this.tbTel1.Text = dataTable.Rows[0]["Tel_office"].ToString();
				this.tbTel2.Text = dataTable.Rows[0]["Tel_home"].ToString();
				this.tbTel3.Text = dataTable.Rows[0]["Tel_Mobile"].ToString();
				this.tbFax.Text = dataTable.Rows[0]["Fax"].ToString();
				if (dataTable.Rows[0]["Birthday"].ToString() != "")
				{
					this.tbBirthDay.Text = DateTime.Parse(dataTable.Rows[0]["Birthday"].ToString()).ToString("yyyy-MM-dd");
				}
				this.tbEmail.Text = dataTable.Rows[0]["Email"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
				this.ddlDept.DataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
				this.ddlDept.DataTextField = "_Name";
				this.ddlDept.DataValueField = "ID";
				this.ddlDept.DataBind();
				this.ddlDept.Items.Insert(0, new ListItem("", ""));
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.tbName.Text.Trim() != string.Empty)
		{
			CustomerListInfo customerListInfo = new CustomerListInfo();
			List<CustomerLinkManInfo> list = new List<CustomerLinkManInfo>();
			CustomerLinkManInfo customerLinkManInfo = new CustomerLinkManInfo();
			customerListInfo.ID = int.Parse(this.hfCusID.Value);
			customerLinkManInfo.ID = this.id;
			customerLinkManInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			customerLinkManInfo.LinkManDept = FunLibrary.ChkInput(this.tbDept.Text);
			customerLinkManInfo.Sex = FunLibrary.ChkInput(this.tbSex.Value);
			customerLinkManInfo.Posit = FunLibrary.ChkInput(this.tbPosition.Value);
			customerLinkManInfo.tel_Office = FunLibrary.ChkInput(this.tbTel1.Text);
			customerLinkManInfo.tel_Home = FunLibrary.ChkInput(this.tbTel2.Text);
			customerLinkManInfo.tel_Mobile = FunLibrary.ChkInput(this.tbTel3.Text);
			customerLinkManInfo.Fax = FunLibrary.ChkInput(this.tbFax.Text);
			customerLinkManInfo.Birthday = FunLibrary.ChkInput(this.tbBirthDay.Text);
			customerLinkManInfo.Email = FunLibrary.ChkInput(this.tbEmail.Text);
			customerLinkManInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			customerLinkManInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
			list.Add(customerLinkManInfo);
			customerListInfo.CustomerLinkManInfos = list;
			DALCustomerList dALCustomerList = new DALCustomerList();
			string str;
			int num = dALCustomerList.UpdateLinkMan(customerListInfo, out str);
			if (num == 0)
			{
				this.SysInfo("parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
