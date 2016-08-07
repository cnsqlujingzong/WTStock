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

public partial class Headquarters_Customer_DeptAdd : Page, IRequiresSessionState
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
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALCustomerDept dALCustomerDept = new DALCustomerDept();
		string str;
		int num2;
		int num = dALCustomerDept.Add(new CustomerDeptInfo
		{
			CustomerID = this.id,
			_Name = FunLibrary.ChkInput(this.tbName.Text),
			LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text),
			Tel = FunLibrary.ChkInput(this.tbTel.Text),
			Remark = FunLibrary.ChkInput(this.tbRemark.Text)
		}, out str, out num2);
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

	protected void ClearText()
	{
		this.tbName.Text = (this.tbRemark.Text = (this.tbLinkMan.Text = (this.tbTel.Text = "")));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
