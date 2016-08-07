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

public partial class Headquarters_Basic_StockLocAdd : Page, IRequiresSessionState
{

	private string f;

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
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		BaseInfo baseInfo = new BaseInfo();
		baseInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		baseInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
		baseInfo.DeptID = new int?(1);
		DALBaseInfo dALBaseInfo = new DALBaseInfo();
		string str;
		int num2;
		int num = dALBaseInfo.Add("StockLocation", baseInfo, "仓位名称", true, out str, out num2);
		if (num == 0)
		{
			if (this.f == "1")
			{
				this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"hfStockLoc\").value='" + baseInfo._Name + "';parent.iframeDialog.$(\"btnStockLoc\").click();");
			}
			else
			{
				this.SysInfo("parent.CloseDialog2();parent.iframeDialog1.$(\"hfStockLoc\").value='" + baseInfo._Name + "';parent.iframeDialog1.$(\"btnStockLoc\").click();");
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

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
