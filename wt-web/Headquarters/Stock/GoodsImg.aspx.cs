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

public partial class Headquarters_Stock_GoodsImg : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnUpfile_Click(object sender, EventArgs e)
	{
		bool flag = false;
		string str = base.Server.MapPath("~/Headquarters/Images/");
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		if (this.FileUpload1.HasFile)
		{
			text = Path.GetExtension(this.FileUpload1.FileName).ToLower();
			string[] array = new string[]
			{
				".gif",
				".png",
				".jpeg",
				".jpg"
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (text == array[i])
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			try
			{
				if (this.FileUpload1.PostedFile.ContentLength > 1048576)
				{
					this.Label1.Text = "上传图片大小不能超过1024KB";
				}
				else
				{
					text3 = DateTime.Now.ToString("yyyy-MM");
					text4 = str + text3 + "\\";
					if (!Directory.Exists(text4))
					{
						Directory.CreateDirectory(text4);
					}
					text2 = DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "");
					this.FileUpload1.PostedFile.SaveAs(text4 + text2 + text);
					this.hfPath.Value = text3 + "/" + text2 + text;
					if (!FunLibrary.IsAllowedExtension(text4 + text2 + text))
					{
						this.Label1.Text = "该文件怀疑为木马，已经删除，详细信息已记录到日志中！";
					}
					else
					{
						System.Drawing.Image image = System.Drawing.Image.FromFile(text4 + text2 + text);
						image.Dispose();
						this.Label1.Text = "File uploaded!";
						ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", string.Concat(new string[]
						{
							"parent.iframeDialog.document.getElementById('gdiv').innerHTML='<img src=../Images/",
							this.hfPath.Value,
							" style=margin-top:5px width=130 />';parent.CloseDialog1();parent.iframeDialog.document.getElementById('hfImgName').value='",
							this.hfPath.Value,
							"';"
						}), true);
					}
				}
			}
			catch (Exception ex)
			{
				this.Label1.Text = "File could not be uploaded.Info:" + ex.ToString();
			}
		}
		else
		{
			this.Label1.Text = "Cannot accept files of this type.";
		}
	}
}
