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
using wt.OtherLibrary;

public partial class Branch_Basic_SupplierMod : Page, IRequiresSessionState
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
			int num2 = 0;
			this.slSupClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "SupplierClass", "", 0, 0, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slSupClass);
			DALSupplierList dALSupplierList = new DALSupplierList();
			SupplierListInfo model = dALSupplierList.GetModel(this.id);
			if (model != null)
			{
				if (model.DeptID.ToString() == this.Session["Session_wtBranchID"].ToString())
				{
					this.btnAdd.Visible = true;
				}
				else
				{
					this.btnAdd.Visible = false;
				}
				this.tbName.Text = model._Name;
				this.hfTemp.Value = (this.tbSupNO.Text = model.SupNO);
				this.tbSupClass.Value = model.Class;
				for (int i = 0; i < this.slSupClass.Items.Count; i++)
				{
					if (this.slSupClass.Items[i].Value == model.ClassID.ToString())
					{
						this.slSupClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbLinkMan.Text = model.LinkMan;
				this.tbTel.Text = model.Tel;
				this.tbTel2.Text = model.Tel2;
				this.tbFax.Text = model.Fax;
				this.tbZip.Text = model.Zip;
				this.tbEmail.Text = model.Email;
				this.tbAccount.Text = model.Account;
				this.tbAdr.Text = model.Adr;
				this.tbRemark.Text = model.Remark;
				this.cbChargeCorp.Checked = model.bChargeCorp;
				this.cbSupplier.Checked = model.bSupplier;
				this.cbTransmitCorp.Checked = model.bTransmitCorp;
				this.cbStop.Checked = model.bStop;
				this.hfsuplierclass.Value = model.Class;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		SupplierListInfo supplierListInfo = new SupplierListInfo();
		supplierListInfo.ID = this.id;
		supplierListInfo.ClassID = new int?(int.Parse(this.slSupClass.Items[this.slSupClass.SelectedIndex].Value));
		supplierListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		supplierListInfo.SupNO = FunLibrary.ChkInput(this.tbSupNO.Text);
		supplierListInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		supplierListInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		supplierListInfo.Tel2 = FunLibrary.ChkInput(this.tbTel2.Text);
		supplierListInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
		supplierListInfo.Zip = FunLibrary.ChkInput(this.tbZip.Text);
		supplierListInfo.Fax = FunLibrary.ChkInput(this.tbFax.Text);
		supplierListInfo.Email = FunLibrary.ChkInput(this.tbEmail.Text);
		supplierListInfo.Account = FunLibrary.ChkInput(this.tbAccount.Text);
		supplierListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
		supplierListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		supplierListInfo.bSupplier = this.cbSupplier.Checked;
		supplierListInfo.bChargeCorp = this.cbChargeCorp.Checked;
		supplierListInfo.bTransmitCorp = this.cbTransmitCorp.Checked;
		supplierListInfo.bStop = this.cbStop.Checked;
		string chkfld = string.Empty;
		if (supplierListInfo.SupNO != this.hfTemp.Value)
		{
			if (this.cbsys.Checked)
			{
				supplierListInfo.SupNO = DALCommon.CreateID(4, 1);
			}
			chkfld = supplierListInfo.SupNO;
		}
		DALSupplierList dALSupplierList = new DALSupplierList();
		string str;
		int num = dALSupplierList.Update(supplierListInfo, chkfld, out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + str + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
