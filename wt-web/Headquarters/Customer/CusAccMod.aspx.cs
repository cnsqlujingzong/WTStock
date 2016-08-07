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

public partial class Headquarters_Customer_CusAccMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "bg_r3"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DALCustomerAccessory dALCustomerAccessory = new DALCustomerAccessory();
			CustomerAccessoryInfo model = dALCustomerAccessory.GetModel(this.id);
			if (model != null)
			{
				this.tbName.Text = model._Name;
				this.tbRemark.Text = model.Remark;
				this.hfUpload.Value = model.Path;
				if (this.hfUpload.Value != string.Empty)
				{
					string text = this.hfUpload.Value.Substring(this.hfUpload.Value.LastIndexOf('/') + 1);
					this.dUpload.InnerHtml = string.Concat(new string[]
					{
						"<img src='../../Public/Images/dmony.gif' /> <a href=\"",
						model.Path,
						"\" target=_blank >",
						text,
						"</a>"
					});
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		CustomerAccessoryInfo customerAccessoryInfo = new CustomerAccessoryInfo();
		customerAccessoryInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		customerAccessoryInfo.ID = this.id;
		customerAccessoryInfo.Path = this.hfUpload.Value;
		customerAccessoryInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALCustomerAccessory dALCustomerAccessory = new DALCustomerAccessory();
		dALCustomerAccessory.Update(customerAccessoryInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
