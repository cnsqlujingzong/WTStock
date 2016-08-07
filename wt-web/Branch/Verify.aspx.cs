using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Branch_Verify : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.Session["Session_wtUserB"] == null || this.Session["Session_wtUserBID"] == null)
		{
			base.Response.Write("<Script>top.location.href = '../Headquarters/Tip.html';</Script>");
			base.Response.End();
		}
	}
}
