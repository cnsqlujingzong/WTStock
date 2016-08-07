using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Public_Editor_UploadPic : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnadd_Click(object sender, EventArgs e)
	{
		bool flag = false;
		string text = base.Server.MapPath("~/Headquarters/RepImages/");
		string text2 = string.Empty;
		string text3 = string.Empty;
		if (this.FileUpload1.HasFile)
		{
			text2 = Path.GetExtension(this.FileUpload1.FileName).ToLower();
			string[] array = new string[]
			{
				".gif",
				".jpeg",
				".jpg"
			};
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
				int contentLength = this.FileUpload1.PostedFile.ContentLength;
				if (contentLength > 1048576)
				{
					this.Message("上传失败，图片大小不能超过1024KB.");
				}
				else
				{
					string text4 = DateTime.Now.ToString("yyyy-MM");
					text = text + text4 + "\\";
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					Random random = new Random();
					string text5 = random.Next(9999).ToString();
					while (text5.Length < 4)
					{
						text5 = "0" + text5;
					}
					text3 = DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "") + text5;
					string text6 = text + text3 + text2;
					this.FileUpload1.PostedFile.SaveAs(text6);
					if (!FunLibrary.IsAllowedExtension(text6))
					{
						File.Delete(text6);
						this.Message("该文件怀疑为木马，已经删除.");
					}
					else
					{
						System.Drawing.Image image = System.Drawing.Image.FromFile(text6);
						image.Dispose();
						string text7 = base.Request.Url.ToString();
						text7 = text7.Remove(text7.LastIndexOf("Public"));
						string str = string.Concat(new string[]
						{
							text7,
							"Headquarters/RepImages/",
							text4,
							"/",
							text3,
							text2
						});
						base.ClientScript.RegisterStartupScript(base.GetType(), "notice", "parent.iframeDialog.Editor.createImgupload('" + str + "');parent.CloseDialog1();", true);
					}
				}
			}
			catch (Exception ex)
			{
				this.lbNotice.Text = "出错:" + ex.ToString();
			}
		}
		else
		{
			this.Message("未知图片类型.");
		}
	}

	protected void Message(string str)
	{
		base.ClientScript.RegisterStartupScript(base.GetType(), "notice", "alert(\"" + str + ".\");", true);
	}
}
