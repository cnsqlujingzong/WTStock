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

public partial class Headquarters_Basic_ProductModelAdd : Page, IRequiresSessionState
{
	private string f;

	private string fid;

	private int igbid;

	private int igcid;

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["gbid"], out this.igbid);
		int.TryParse(base.Request["gcid"], out this.igcid);
		this.f = base.Request["f"];
		if (this.f == null)
		{
			this.f = string.Empty;
		}
		this.fid = base.Request["fid"];
		if (!base.IsPostBack)
		{
			OtherFunction.BindProductBrand(this.ddlBrand);
			this.ddlBrand.Items.Remove(new ListItem("�½�...", "0"));
			OtherFunction.BindProductClass(this.ddlClass);
			this.ddlClass.Items.Remove(new ListItem("�½�...", "0"));
			for (int i = 0; i < this.ddlBrand.Items.Count; i++)
			{
				if (this.ddlBrand.Items[i].Value == this.igbid.ToString())
				{
					this.ddlBrand.Items[i].Selected = true;
					break;
				}
			}
			for (int i = 0; i < this.ddlClass.Items.Count; i++)
			{
				if (this.ddlClass.Items[i].Value == this.igcid.ToString())
				{
					this.ddlClass.Items[i].Selected = true;
					break;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		ProductModelInfo productModelInfo = new ProductModelInfo();
		DALProductModel dALProductModel = new DALProductModel();
		productModelInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		productModelInfo.BrandID = new int?(int.Parse(this.ddlBrand.SelectedValue));
		productModelInfo.ClassID = new int?(int.Parse(this.ddlClass.SelectedValue));
		int value = 0;
		int.TryParse(this.tbPeriod.Text, out value);
		productModelInfo.Period = new int?(value);
		productModelInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
		string str;
		int num2;
		int num = dALProductModel.Add(productModelInfo, out str, out num2);
		if (num == 0)
		{
			if (this.fid != null && this.fid != "")
			{
				this.SysInfo(string.Concat(new string[]
				{
					"parent.CloseDialog1();parent.",
					this.fid,
					".$(\"hfModelID\").value='",
					num2.ToString(),
					"';parent.",
					this.fid,
					".$(\"btnRefModel\").click();"
				}));
			}
			else if (this.f == "1")
			{
				this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"hfModelID\").value='" + num2.ToString() + "';parent.iframeDialog.$(\"btnRefModel\").click();");
			}
			else
			{
				this.SysInfo("parent.CloseDialog2();parent.iframeDialog1.$(\"hfModelID\").value='" + num2.ToString() + "';parent.iframeDialog1.$(\"btnRefModel\").click();");
			}
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + str + "');$('tbName').select();");
		}
		else
		{
			this.SysInfo("window.alert('ϵͳ������鿴������־');$('tbName').select();");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
