using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Branch_Basic_LinkManAdd : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "kh_r33"))
				{
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.tbName.Text.Trim() != string.Empty)
		{
			SupplierListInfo supplierListInfo = new SupplierListInfo();
			List<SupplierLinkManInfo> list = new List<SupplierLinkManInfo>();
			SupplierLinkManInfo supplierLinkManInfo = new SupplierLinkManInfo();
			supplierLinkManInfo.ID = 0;
			supplierListInfo.ID = this.id;
			supplierLinkManInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			supplierLinkManInfo.Sex = FunLibrary.ChkInput(this.tbSex.Value);
			supplierLinkManInfo.Posit = FunLibrary.ChkInput(this.tbPosition.Value);
			supplierLinkManInfo.tel_Office = FunLibrary.ChkInput(this.tbTel1.Text);
			supplierLinkManInfo.tel_Home = FunLibrary.ChkInput(this.tbTel2.Text);
			supplierLinkManInfo.tel_Mobile = FunLibrary.ChkInput(this.tbTel3.Text);
			supplierLinkManInfo.Fax = FunLibrary.ChkInput(this.tbFax.Text);
			supplierLinkManInfo.Birthday = FunLibrary.ChkInput(this.tbBirthDay.Text);
			supplierLinkManInfo.Email = FunLibrary.ChkInput(this.tbEmail.Text);
			supplierLinkManInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			supplierLinkManInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
			list.Add(supplierLinkManInfo);
			supplierListInfo.SupplierLinkManInfos = list;
			DALSupplierList dALSupplierList = new DALSupplierList();
			string str;
			int num = dALSupplierList.UpdateLinkMan(supplierListInfo, out str);
			if (num == 0)
			{
				if (!this.cbClose.Checked)
				{
					this.ClearText();
					this.SysInfo("$(\"tbName\").fosup();");
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
		this.tbBirthDay.Text = (this.tbEmail.Text = (this.tbFax.Text = (this.tbName.Text = (this.tbPosition.Value = (this.tbRemark.Text = (this.tbSex.Value = (this.tbTel1.Text = (this.tbTel2.Text = (this.tbTel3.Text = string.Empty)))))))));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
