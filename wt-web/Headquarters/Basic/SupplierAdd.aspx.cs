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

public partial class Headquarters_Basic_SupplierAdd : Page, IRequiresSessionState
{
	private string f;

	private string fid;

	private int classid;

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	public string Str_Fid
	{
		get
		{
			return this.fid;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["classid"], out this.classid);
		this.f = base.Request["f"];
		if (this.f == null)
		{
			this.f = string.Empty;
		}
		else
		{
			this.cbSupplier.Checked = true;
		}
		this.fid = base.Request["fid"];
		if (this.fid == null)
		{
			this.fid = "iframeDialog";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r33"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			int num2 = 0;
			this.slSupClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "SupplierClass", "", 0, 0, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slSupClass);
			for (int i = 0; i < this.slSupClass.Items.Count; i++)
			{
				if (this.slSupClass.Items[i].Value == this.classid.ToString())
				{
					this.slSupClass.Items[i].Selected = true;
					this.tbSupClass.Value = this.slSupClass.Items[i].Text.Replace("├", "").Replace("│", "").Replace(HttpUtility.HtmlDecode("&nbsp;&nbsp;"), "");
					break;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		SupplierListInfo supplierListInfo = new SupplierListInfo();
		supplierListInfo.DeptID = 1;
		supplierListInfo.ClassID = new int?(int.Parse(this.slSupClass.Items[this.slSupClass.SelectedIndex].Value));
		supplierListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		if (this.cbsys1.Checked)
		{
			supplierListInfo.SupNO = DALCommon.CreateID(4, 1);
		}
		else
		{
			supplierListInfo.SupNO = FunLibrary.ChkInput(this.tbSupNO.Text);
		}
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
		DALSupplierList dALSupplierList = new DALSupplierList();
		string str;
		int num2;
		int num = dALSupplierList.Add(supplierListInfo, out str, out num2);
		if (num == 0)
		{
			if (this.f == "")
			{
				if (this.cbClose.Checked)
				{
					this.SysInfo("parent.CloseDialog('1');");
				}
				else
				{
					this.SysInfo("$('tbName').select();");
					this.ClearText();
					if (this.cbsys1.Checked)
					{
						this.tbSupNO.Enabled = false;
					}
					else
					{
						this.tbSupNO.Enabled = true;
					}
				}
			}
			else
			{
				if (this.cbStop.Checked || !this.cbSupplier.Checked)
				{
					supplierListInfo._Name = "";
				}
				if (this.fid == string.Empty)
				{
					if (this.f == "1")
					{
						this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"hfSupplier\").value='" + supplierListInfo._Name + "';parent.iframeDialog.$(\"btnRefSupplier\").click();");
					}
					else
					{
						this.SysInfo("parent.CloseDialog2();parent.iframeDialog1.$(\"hfSupplier\").value='" + supplierListInfo._Name + "';parent.iframeDialog1.$(\"btnRefSupplier\").click();");
					}
				}
				else
				{
					this.SysInfo("RetuenAdd('" + supplierListInfo._Name + "');");
				}
			}
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

	protected void ClearText()
	{
		this.tbAccount.Text = (this.tbAdr.Text = (this.tbEmail.Text = (this.tbFax.Text = (this.tbLinkMan.Text = (this.tbName.Text = (this.tbRemark.Text = (this.tbSupNO.Text = (this.tbTel.Text = (this.tbTel2.Text = (this.tbZip.Text = string.Empty))))))))));
		this.cbChargeCorp.Checked = (this.cbSupplier.Checked = (this.cbSupplier.Checked = (this.cbStop.Checked = false)));
		this.tbSupClass.Value = string.Empty;
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
