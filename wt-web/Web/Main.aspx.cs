using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.DB;
using wt.Model;

public partial class Web_Main : Page, IRequiresSessionState
{
	private string user;


	protected string Str_user
	{
		get
		{
			return this.user;
		}
	}
	
	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		if (!base.IsPostBack)
		{
			this.user = (string)this.Session["Session_Web_Name"];
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo sysParm = dALSysParm.GetSysParm();
			if (sysParm != null)
			{
				this.lbcorp.Text = sysParm.CorpName;
			}
		}
	}

	protected void btnExit_Click(object sender, EventArgs e)
	{
		string s = this.Session["Session_Web_ID"].ToString();
		DALUserManage dALUserManage = new DALUserManage();
		DbHelperSQL.InsertErrorLogs(1, 0, 0, "退出WEB自助平台", int.Parse(s));
		this.Session.Remove("Session_Web_Name");
		base.Response.Redirect("Default.aspx");
	}

	public void ChkWebUser()
	{
		if (this.Session["Session_Web_Name"] == null || this.Session["Session_Web_ID"] == null)
		{
			base.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
			base.Response.End();
		}
	}
}
