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
using wt.OtherLibrary;

public partial class Headquarters_Basic_BranchAdd : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r3"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindArea(this.ddlArea);
			this.tbArray.Text = "0";
			int num2 = int.Parse(DALCommon.GetDataList("SysParm", "count(1)", "bSim=1 or BranchNum>(select count(1) from UserManage)").Tables[0].Rows[0][0].ToString());
			this.hfOverFlag.Value = num2.ToString();
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
				BranchListInfo branchListInfo = new BranchListInfo();
				branchListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
				if (this.cbsys.Checked)
				{
					branchListInfo.BranchNO = DALCommon.CreateID(6, 1);
				}
				else
				{
					branchListInfo.BranchNO = FunLibrary.ChkInput(this.tbBranchNO.Text);
				}
				branchListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
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
				DALBranchList dALBranchList = new DALBranchList();
				string str;
				int num2;
				int num = dALBranchList.Add(branchListInfo, out str, out num2);
				if (num == 0)
				{
					if (this.cbClose.Checked)
					{
						this.SysInfo("parent.CloseDialog('1');");
					}
					else
					{
						this.SysInfo("$('tbName').select();");
						this.ClearText();
					}
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

	protected void ClearText()
	{
		this.tbAccount.Text = (this.tbAdr.Text = (this.tbName.Text = (this.tbCorp.Text = (this.tbEmail.Text = (this.tbFax.Text = (this.tbMan.Text = (this.tbRemark.Text = (this.tbTel.Text = (this.tbZip.Text = string.Empty)))))))));
		this.ddlArea.ClearSelection();
		this.ddlArea.Items.FindByValue("-1").Selected = true;
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
