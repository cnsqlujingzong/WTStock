using System;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Headquarters_Print_upfile : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		string str = base.Request["name"];
		string[] allKeys = base.Request.Files.AllKeys;
		for (int i = 0; i < allKeys.Length; i++)
		{
			string name = allKeys[i];
			HttpPostedFile httpPostedFile = base.Request.Files[name];
			if (httpPostedFile.ContentLength > 10)
			{
				string text = base.Server.MapPath("templete_upfile");
				DirectoryInfo directoryInfo = new DirectoryInfo(text);
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
				httpPostedFile.SaveAs(text + "\\" + str + ".frf.rar");
			}
		}
	}
}
