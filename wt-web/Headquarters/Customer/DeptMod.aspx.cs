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
using wt.Model;

public partial class Headquarters_Customer_DeptMod : Page, IRequiresSessionState
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
			DataTable dataTable = DALCommon.GetDataList("CustomerDept", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.hfTmp.Value = (this.tbName.Text = dataTable.Rows[0]["_Name"].ToString());
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALCustomerDept dALCustomerDept = new DALCustomerDept();
		CustomerDeptInfo customerDeptInfo = new CustomerDeptInfo();
		customerDeptInfo.CustomerID = int.Parse(this.hfCusID.Value);
		customerDeptInfo.ID = this.id;
		customerDeptInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		customerDeptInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		customerDeptInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		customerDeptInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		string chkfld = string.Empty;
		if (customerDeptInfo._Name != this.hfTmp.Value)
		{
			chkfld = string.Concat(new string[]
			{
				" CustomerID=",
				this.hfCusID.Value,
				" and _Name='",
				customerDeptInfo._Name,
				"'"
			});
		}
		string str;
		int num = dALCustomerDept.Update(customerDeptInfo, chkfld, out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('" + str + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
