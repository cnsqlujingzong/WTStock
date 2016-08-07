using System;
using System.IO;
using System.Web;

namespace wt.Library
{
	public sealed class OtherClass
	{
		public OtherClass()
		{
		}

		public static void AppendErrorLog(string error)
		{
			DateTime now;
			if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/ErrorLog")))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/ErrorLog"));
			}
			if (!File.Exists(HttpContext.Current.Server.MapPath(string.Concat("~/ErrorLog/", DateTime.Now.ToString("yyyy-MM-dd"), ".txt"))))
			{
				HttpServerUtility server = HttpContext.Current.Server;
				now = DateTime.Now;
				StreamWriter streamWriter = File.CreateText(server.MapPath(string.Concat("~/ErrorLog/", now.ToString("yyyy-MM-dd"), ".txt")));
				streamWriter.Close();
			}
			HttpServerUtility httpServerUtility = HttpContext.Current.Server;
			now = DateTime.Now;
			string str = httpServerUtility.MapPath(string.Concat("~/ErrorLog/", now.ToString("yyyy-MM-dd"), ".txt"));
			FileStream fileStream = new FileStream(str, FileMode.Append, FileAccess.Write);
			StreamWriter streamWriter1 = new StreamWriter(fileStream);
			streamWriter1.WriteLine(error);
			streamWriter1.WriteLine("\n");
			streamWriter1.Close();
			fileStream.Close();
		}
	}
}