using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_System_Update : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "系统管理员")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=Right");
				base.Response.End();
			}
			string text = ConfigurationManager.AppSettings["version"];
			if (text == null || text == string.Empty)
			{
				text = "未知";
			}
			this.lbVer.Text = text;
			string url = "http://www.differsoft.com/itcontrol/version.asp";
			string param = "ver=" + text;
			string text2 = string.Empty;
			text2 = this.GetServerInfo(url, param);
			if (text2 == "")
			{
				this.tbupdate.Value = "可升级版本:";
			}
			else if (text2 == "0")
			{
				this.tbupdate.Value = "可升级版本:无 (当前版本已经是最新软件版本)";
				this.btnUpdate.Enabled = false;
			}
			else
			{
				this.tbupdate.Value = "可升级版本:" + text2;
				this.hfver.Value = text2;
			}
		}
	}

	protected string GetServerInfo(string url, string param)
	{
		string result = string.Empty;
		try
		{
			byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(param);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
			httpWebRequest.ContentLength = (long)bytes.Length;
			Stream requestStream = httpWebRequest.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Close();
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("GB2312"));
			result = streamReader.ReadToEnd();
			requestStream.Dispose();
			streamReader.Dispose();
		}
		catch
		{
		}
		return result;
	}

	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		DALSysVali dALSysVali = new DALSysVali();
		try
		{
			string corpName = sysParm.CorpName;
			string text = sysParm.BranchNum.ToString();
			int num;
			int.TryParse(DALCommon.TCount("UserManage", ""), out num);
			string value = dALSysVali.GetValue("ITEM2");
			string tel = sysParm.Tel;
			string zip = sysParm.Zip;
			string adr = sysParm.Adr;
			string text2 = "id=8";
			string text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				"&CustomerInfo=公司名:",
				corpName,
				"，电话:",
				tel
			});
			text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				"，邮编:",
				zip,
				"，地址:",
				adr,
				"，注册用户数:",
				text,
				"，实际用户数:",
				num.ToString(),
				"注册码:",
				value
			});
			if (sysParm.bSim)
			{
				text2 += "，并发";
			}
			byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(text2);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.differsoft.com/kill_post.asp");
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
			httpWebRequest.ContentLength = (long)bytes.Length;
			Stream requestStream = httpWebRequest.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Close();
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("GB2312"));
			string text4 = streamReader.ReadToEnd();
			requestStream.Dispose();
			streamReader.Dispose();
		}
		catch
		{
		}
		if (this.hfver.Value != string.Empty)
		{
			string url = "http://www.differsoft.com/itcontrol/files.asp";
			string text2 = "ver=" + this.hfver.Value;
			string text4 = string.Empty;
			text4 = this.GetServerInfo(url, text2);
			int num2 = 0;
			if (text4 != string.Empty)
			{
				string text5 = string.Empty;
				string text6 = string.Empty;
				WebClient webClient = new WebClient();
				string[] array = text4.Split(new char[]
				{
					'|'
				});
				string[] array2 = new string[]
				{
					"",
					""
				};
				for (int i = 0; i < array.Length; i++)
				{
					try
					{
						string[] array3 = array[i].ToString().Split(new char[]
						{
							','
						});
						text5 = "http://www.differsoft.com/itcontrol/files/" + this.hfver.Value + "/" + array3[1].ToString();
						text6 = base.Server.MapPath(array3[0].ToString());
						string path = text6.Substring(0, text6.LastIndexOf('\\'));
						if (!Directory.Exists(path))
						{
							Directory.CreateDirectory(path);
						}
						webClient.DownloadFile(text5, text6);
					}
					catch (WebException ex)
					{
						num2++;
						OtherClass.AppendErrorLog(string.Concat(new string[]
						{
							ex.Message,
							";Uri:",
							text5,
							"File:",
							text6
						}));
					}
				}
				if (num2 <= 0)
				{
					this.hfu.Value = "1";
					Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
					AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
					appSettingsSection.Settings["version"].Value = this.hfver.Value;
					configuration.Save();
					this.Session.Remove("Session_wtUser");
					this.Session.Remove("Session_wtUserID");
					this.Session.Remove("Session_wtPur");
				}
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
