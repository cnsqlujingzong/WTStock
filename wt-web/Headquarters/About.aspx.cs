using System;
using System.Configuration;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Headquarters_About : Page, IRequiresSessionState
{

	private string version;

	protected string Version
	{
		get
		{
			return this.version;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.version = ConfigurationManager.AppSettings["version"];
			if (this.version == null || this.version == string.Empty)
			{
				this.version = "2.1.001.321";
			}
		}
	}
}
