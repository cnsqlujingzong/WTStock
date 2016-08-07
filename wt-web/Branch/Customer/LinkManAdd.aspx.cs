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

public partial class Branch_Customer_LinkManAdd : Page, IRequiresSessionState
{
	private int id;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r3"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DataTable dataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.id.ToString()).Tables[0];
			this.ddlDept.DataSource = dataSource;
			this.ddlDept.DataTextField = "_Name";
			this.ddlDept.DataValueField = "ID";
			this.ddlDept.DataBind();
			this.ddlDept.Items.Insert(0, new ListItem("", ""));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.tbName.Text.Trim() != string.Empty)
		{
			CustomerListInfo customerListInfo = new CustomerListInfo();
			List<CustomerLinkManInfo> list = new List<CustomerLinkManInfo>();
			CustomerLinkManInfo customerLinkManInfo = new CustomerLinkManInfo();
			customerLinkManInfo.ID = 0;
			customerListInfo.ID = this.id;
			customerLinkManInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			customerLinkManInfo.LinkManDept = FunLibrary.ChkInput(this.tbDept.Text);
			string str;
			int num;
			if (customerLinkManInfo.LinkManDept != "")
			{
				DALCustomerDept dALCustomerDept = new DALCustomerDept();
				int num2;
				num = dALCustomerDept.Add(new CustomerDeptInfo
				{
					CustomerID = this.id,
					_Name = customerLinkManInfo.LinkManDept
				}, out str, out num2);
			}
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
			num = dALCustomerList.UpdateLinkMan(customerListInfo, out str);
			if (num == 0)
			{
				if (!this.cbClose.Checked)
				{
					this.ClearText();
					this.SysInfo("$(\"tbName\").focus();");
				}
				else
				{
					this.SysInfo("parent.CloseDialog('1');");
				}
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
	}

	protected void ClearText()
	{
		this.tbBirthDay.Text = (this.tbDept.Text = (this.tbEmail.Text = (this.tbFax.Text = (this.tbName.Text = (this.tbPosition.Value = (this.tbRemark.Text = (this.tbSex.Value = (this.tbTel1.Text = (this.tbTel2.Text = (this.tbTel3.Text = string.Empty))))))))));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
