using System;
using System.Web.SessionState;
using System.Web.UI;
using wt.DAL;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Headquarters_Basic_BranchMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "jc_r4"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DALBranchList dALBranchList = new DALBranchList();
			BranchListInfo model = dALBranchList.GetModel(this.id);
			if (model != null)
			{
				OtherFunction.BindArea(this.ddlArea);
				this.tbName.Text = model._Name;
				this.hfTemp.Value = (this.tbBranchNO.Text = model.BranchNO);
				this.tbCorp.Text = model.CorpName;
				this.tbMan.Text = model.LinkMan;
				this.tbTel.Text = model.Tel;
				this.tbAdr.Text = model.Adr;
				this.tbZip.Text = model.Zip;
				this.tbFax.Text = model.Fax;
				this.tbEmail.Text = model.Email;
				this.tbArea.Text = model.Area;
				this.tbAccount.Text = model.Account;
				this.tbRemark.Text = model.Remark;
				this.bStop.Checked = model.bStop;
				this.cbBranchPurchase.Checked = model.bBranchPurchase;
				this.cbGoodsAdd.Checked = model.bGoodsAdd;
				this.tbArray.Text = model.ArrayID.ToString();
                this.txt_js_TaxRate.Text = Math.Round( model.TR_jsfw,3).ToString();
                this.txt_ptfp_TaxRate.Text = Math.Round(model.TR_ptfp, 3).ToString();
                this.txt_zzsjx_TaxRate.Text = Math.Round(model.TR_zzsjx, 3).ToString();
                this.txt_zzsxx_TaxRate.Text = Math.Round(model.TR_zzsxx, 3).ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.tbName.Text.Trim() == "总部")
		{
			this.SysInfo("window.alert('保存失败！该网点名无法使用');$('tbName').select();");
		}
		else
		{
			int arrayID = 0;
			if (!int.TryParse(this.tbArray.Text, out arrayID))
			{
				this.SysInfo("window.alert('保存失败！排序字段必须为数字');$('tbArray').select();");
			}
			else
			{
				DALBranchList dALBranchList = new DALBranchList();
				BranchListInfo branchListInfo = new BranchListInfo();
				branchListInfo.ID = this.id;
				branchListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
				branchListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
				branchListInfo.BranchNO = FunLibrary.ChkInput(this.tbBranchNO.Text);
				branchListInfo.CorpName = FunLibrary.ChkInput(this.tbCorp.Text);
				branchListInfo.Account = FunLibrary.ChkInput(this.tbAccount.Text);
				branchListInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
				branchListInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
				branchListInfo.Email = FunLibrary.ChkInput(this.tbEmail.Text);
				branchListInfo.Fax = FunLibrary.ChkInput(this.tbFax.Text);
				branchListInfo.LinkMan = FunLibrary.ChkInput(this.tbMan.Text);
				branchListInfo.bStop = this.bStop.Checked;
				branchListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
				branchListInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
				branchListInfo.Zip = FunLibrary.ChkInput(this.tbZip.Text);
				branchListInfo.bBranchPurchase = this.cbBranchPurchase.Checked;
				branchListInfo.bGoodsAdd = this.cbGoodsAdd.Checked;
				branchListInfo.ArrayID = arrayID;
                branchListInfo.TR_jsfw = string.IsNullOrEmpty(txt_js_TaxRate.Text.Trim()) ? 0 : decimal.Parse(txt_js_TaxRate.Text.Trim());
                branchListInfo.TR_ptfp = string.IsNullOrEmpty(txt_ptfp_TaxRate.Text.Trim()) ? 0 : decimal.Parse(txt_ptfp_TaxRate.Text.Trim());
                branchListInfo.TR_zzsjx = string.IsNullOrEmpty(txt_zzsjx_TaxRate.Text.Trim()) ? 0 : decimal.Parse(txt_zzsjx_TaxRate.Text.Trim());
                branchListInfo.TR_zzsxx = string.IsNullOrEmpty(txt_zzsxx_TaxRate.Text.Trim()) ? 0 : decimal.Parse(txt_zzsxx_TaxRate.Text.Trim());
				string chkfld = string.Empty;
				if (branchListInfo.BranchNO != this.hfTemp.Value)
				{
					if (this.cbsys.Checked)
					{
						branchListInfo.BranchNO = DALCommon.CreateID(6, 1);
					}
					chkfld = " BranchNO='" + branchListInfo.BranchNO + "'";
				}
				if (branchListInfo.BranchNO == "")
				{
					branchListInfo.BranchNO = DALCommon.CreateID(6, 1);
					chkfld = " BranchNO='" + branchListInfo.BranchNO + "'";
				}
				string str;
				int num = dALBranchList.Update(branchListInfo, chkfld, out str);
				if (num == 0)
				{
					this.SysInfo("parent.CloseDialog('1');");
				}
				else if (num == -1)
				{
					this.SysInfo("window.alert('" + str + "');$('tbName').select();");
				}
				else
				{
					this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
				}
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnRef_Click(object sender, EventArgs e)
	{
		OtherFunction.BindArea(this.ddlArea);
		if (this.hfArea.Value != string.Empty)
		{
			this.ddlArea.ClearSelection();
			this.ddlArea.Items.FindByText(this.hfArea.Value).Selected = true;
			this.tbArea.Text = this.ddlArea.SelectedItem.Text;
		}
	}
}
