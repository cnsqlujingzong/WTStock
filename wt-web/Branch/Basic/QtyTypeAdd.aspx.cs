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

public partial class Branch_Basic_QtyTypeAdd : Page, IRequiresSessionState
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
		FunLibrary.ChkBran();
		this.f = base.Request["f"];
		if (this.f == null)
		{
			this.f = "1";
		}
		this.fid = base.Request["fid"];
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r1"))
				{
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		BaseInfo baseInfo = new BaseInfo();
		baseInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		baseInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
		DALBaseInfo dALBaseInfo = new DALBaseInfo();
		string str;
		int num2;
		int num = dALBaseInfo.Add("QtyType", baseInfo, "计数器类型", false, out str, out num2);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"btnClr\").click();");
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
