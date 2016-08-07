using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Branch_Services_PrintBill : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		string text = base.Request.QueryString["id"];
		if (text == "" || text == null)
		{
			text = "-1";
		}
		this.hfRecID.Value = text;
	}
}
