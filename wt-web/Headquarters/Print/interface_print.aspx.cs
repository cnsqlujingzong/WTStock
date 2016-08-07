using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Headquarters_Print_interface_print : Page, IRequiresSessionState
{


	private string url;

	private string parm;

	private string action;

	

	protected string Url
	{
		get
		{
			return this.url;
		}
	}

	protected string Parm
	{
		get
		{
			return this.parm;
		}
	}

	protected string Action
	{
		get
		{
			return this.action;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			string text = base.Request.Url.ToString();
			if (base.Request.Url.ToString().Contains(string.Format("{0}:{1}", base.Request.Url.Host, base.Request.Url.Port)))
			{
				text = base.Request.Url.ToString().Replace(string.Format("{0}:{1}", base.Request.Url.Host, base.Request.Url.Port), base.Request.Headers["host"]);
			}
			else
			{
				text = base.Request.Url.ToString().Replace(base.Request.Url.Host, base.Request.Headers["host"]);
			}
			string text2 = base.Request.QueryString["type"];
			string text3 = base.Request.QueryString["obj"];
			if (text2.ToLower() == "print" || text2.ToLower() == "modify")
			{
				text = text.Replace("interface_print.aspx", "interface_data.aspx");
			}
			string[] array = text.Split(new char[]
			{
				'?'
			});
			this.url = "<param name=\"property1\" value=\"" + array[0].ToString() + "\" />";
			this.parm = "<param name=\"property2\" value=\"" + array[1].ToString() + "\" />";
			this.action = string.Concat(new string[]
			{
				"<param name=\"property3\" value=\"",
				text2,
				"|",
				text3,
				"\" />"
			});
		}
	}
}
