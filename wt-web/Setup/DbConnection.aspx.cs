using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

public partial class Setup_DbConnection : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		string text = base.Request.Form["parm1"];
		string text2 = base.Request.Form["parm2"];
		string text3 = base.Request.Form["parm3"];
		string text4 = base.Request.Form["parm4"];
		string connectionString = string.Concat(new string[]
		{
			"Data Source=",
			text,
			";Initial Catalog=",
			text2,
			";User ID=",
			text3,
			";Password=",
			text4
		});
		bool flag = false;
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			try
			{
				sqlConnection.Open();
				Configuration configuration = WebConfigurationManager.OpenWebConfiguration(base.Request.ApplicationPath);
				ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
				connectionStringsSection.ConnectionStrings["connectionString"].ConnectionString = connectionString;
				configuration.Save();
				sqlConnection.Close();
				flag = true;
				base.Response.Write("1");
			}
			catch
			{
				sqlConnection.Close();
				base.Response.Write("0");
			}
			if (flag)
			{
				try
				{
					base.Response.Write("1");
				}
				catch
				{
					base.Response.Write("0");
				}
			}
		}
	}
}
