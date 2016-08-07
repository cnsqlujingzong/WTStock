using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Branch_Customer_CusAccAdd : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "bg_r3"))
				{
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		CustomerAccessoryInfo customerAccessoryInfo = new CustomerAccessoryInfo();
		customerAccessoryInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		customerAccessoryInfo.CustomerID = this.id;
		customerAccessoryInfo.OperatorID = int.Parse((string)this.Session["Session_wtUserBID"]);
		customerAccessoryInfo._Date = DateTime.Now;
		customerAccessoryInfo.Path = this.hfUpload.Value;
		customerAccessoryInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALCustomerAccessory dALCustomerAccessory = new DALCustomerAccessory();
		dALCustomerAccessory.Add(customerAccessoryInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
