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

public partial class Headquarters_Basic_SerItemAdd : Page, IRequiresSessionState
{
	private string f;

	private string fid;

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
		this.f = base.Request["f"];
		if (this.f == null)
		{
			this.f = string.Empty;
		}
		this.fid = base.Request["fid"];
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r30"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.tbItemID.Enabled = false;
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		ServicesItemListInfo servicesItemListInfo = new ServicesItemListInfo();
		DALServicesItemList dALServicesItemList = new DALServicesItemList();
		servicesItemListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		servicesItemListInfo.ItemNO = FunLibrary.ChkInput(this.tbItemID.Text);
		decimal value = 0m;
		decimal value2 = 0m;
		decimal value3 = 0m;
		decimal.TryParse(this.tbPrice.Text, out value);
		decimal.TryParse(this.tbPricew.Text, out value2);
		decimal.TryParse(this.tbDeduct.Text, out value3);
		servicesItemListInfo.Price = new decimal?(value);
		servicesItemListInfo.WarrantyPrice = new decimal?(value2);
		servicesItemListInfo.TecDeduct = new decimal?(value3);
		servicesItemListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
		if (this.cbsys.Checked)
		{
			servicesItemListInfo.ItemNO = DALCommon.CreateID(2, 1);
		}
		string str;
		int num2;
		int num = dALServicesItemList.Add(servicesItemListInfo, out str, out num2);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog2();parent.iframeDialog1.$(\"btnClr\").click();");
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

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
