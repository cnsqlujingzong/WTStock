using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Headquarters_Verify : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.Session["Session_wtUser"] == null || this.Session["Session_wtUserID"] == null)
		{
			base.Response.Write("<Script>top.location.href = 'Tip.html';</Script>");
			base.Response.End();
		}
	}
}
