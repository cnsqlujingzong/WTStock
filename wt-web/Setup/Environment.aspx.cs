using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

public partial class Setup_Environment : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			try
			{
				this.Session["Session_a"] = "a";
				this.Session.Remove("Session_a");
				base.Response.Write("1^");
			}
			catch
			{
				base.Response.Write("0^");
			}
			if (this.SystemFolderCheck("~/ErrorLog"))
			{
				base.Response.Write("1^");
			}
			else
			{
				base.Response.Write("0^");
			}
			if (this.SystemFolderCheck("~/Public/Xml"))
			{
				base.Response.Write("1^");
			}
			else
			{
				base.Response.Write("0^");
			}
			if (this.SystemFolderCheck("~/Headquarters/Images"))
			{
				base.Response.Write("1^");
			}
			else
			{
				base.Response.Write("0^");
			}
			if (this.SystemFolderCheck("~/Headquarters/Document"))
			{
				base.Response.Write("1^");
			}
			else
			{
				base.Response.Write("0^");
			}
			if (this.SystemFolderCheck("~/Setup"))
			{
				base.Response.Write("1^");
			}
			else
			{
				base.Response.Write("0^");
			}
			try
			{
				Configuration configuration = WebConfigurationManager.OpenWebConfiguration(base.Request.ApplicationPath);
				ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
				string connectionString = connectionStringsSection.ConnectionStrings["connectionString"].ConnectionString;
				connectionStringsSection.ConnectionStrings["connectionString"].ConnectionString = connectionString;
				configuration.Save();
				base.Response.Write("1^");
			}
			catch
			{
				base.Response.Write("0^");
			}
			try
			{
				new ScriptManager
				{
					ID = "a"
				}.Dispose();
				base.Response.Write("1");
			}
			catch
			{
				base.Response.Write("0");
			}
		}
	}

	public bool SystemFolderCheck(string foldername)
	{
		string str = base.Server.MapPath(foldername);
		bool result;
		try
		{
			using (FileStream fileStream = new FileStream(str + "\\a.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				fileStream.Close();
			}
			if (File.Exists(str + "\\a.txt"))
			{
				File.Delete(str + "\\a.txt");
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}
}
