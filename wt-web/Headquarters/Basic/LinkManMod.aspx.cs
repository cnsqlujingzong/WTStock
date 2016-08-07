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

public partial class Headquarters_Basic_LinkManMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "jc_r34"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DataTable dataTable = DALCommon.GetDataList("SupplierLinkMan", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbName.Text = dataTable.Rows[0]["_Name"].ToString();
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
				this.hfCusID.Value = dataTable.Rows[0]["SupplierID"].ToString();
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
			supplierListInfo.ID = int.Parse(this.hfCusID.Value);
			supplierLinkManInfo.ID = this.id;
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
