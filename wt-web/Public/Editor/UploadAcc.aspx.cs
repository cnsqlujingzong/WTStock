using System;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Public_Editor_UploadAcc : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnUpfile_Click(object sender, EventArgs e)
	{
		bool flag = false;
		string text = base.Server.MapPath("~/Headquarters/RepAcc/");
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = "";
		if (this.FileUpload1.HasFile)
		{
			text2 = Path.GetExtension(this.FileUpload1.FileName).ToLower();
			string text5 = ".asp,.aspx,.js,.asa,.jsp,.inc,.exe";
			if (text5.Contains(text2))
			{
				this.lbNotice.Text = "危险文件类型！";
				return;
			}
			text4 = DateTime.Now.ToString("yyyy-MM");
			text = text + text4 + "\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string[] array = FunLibrary.GetXmlNodeText(base.Server.MapPath("../../Public/Xml/config.xml"), "postfix").Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (text2 == array[i])
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			try
			{
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				Random random = new Random();
				string text6 = random.Next(9999).ToString();
				while (text6.Length < 4)
				{
					text6 = "0" + text6;
				}
				text3 = DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "") + text6;
				string text7 = text + text3 + text2;
				this.FileUpload1.PostedFile.SaveAs(text7);
				if (!FunLibrary.IsAllowedExtension(text7))
				{
					File.Delete(text7);
					this.Message("该文件怀疑为木马，已经删除.");
				}
				else
				{
					string text8 = base.Request.Url.ToString();
					text8 = text8.Remove(text8.LastIndexOf("Public"));
					string text9 = string.Concat(new string[]
					{
						text8,
						"Headquarters/RepAcc/",
						text4,
						"/",
						text3,
						text2
					});
					base.ClientScript.RegisterStartupScript(base.GetType(), "notice", string.Concat(new string[]
					{
						"parent.iframeDialog.Editor.InsertBody('<p><a target=\"blank\" style=\" color:#999;\" href=\"",
						text9,
						"\">",
						text3,
						"</a></p>');parent.CloseDialog1();"
					}), true);
				}
			}
			catch (Exception ex)
			{
				this.lbNotice.Text = "出错:" + ex.ToString();
			}
		}
		else
		{
			this.Message("未知文件类型.");
		}
	}

	protected void Message(string str)
	{
		base.ClientScript.RegisterStartupScript(base.GetType(), "notice", "alert(\"" + str + ".\");", true);
	}
}
