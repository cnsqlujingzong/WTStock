
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Branch_Office_MailUpload : Page, IRequiresSessionState
{
	private string p;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		this.p = base.Request.QueryString["p"];
		if (this.p == null || this.p == "")
		{
			base.Response.End();
		}
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnUpfile_Click(object sender, EventArgs e)
	{
		bool flag = false;
		string str = string.Empty;
		string text = string.Empty;
		string str2 = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		this.Label1.Text = string.Empty;
		try
		{
			if (this.FileUpload1.HasFile)
			{
				text = Path.GetExtension(this.FileUpload1.FileName).ToLower();
				string text4 = ".asp,.aspx,.js,.asa,.jsp,.inc,.exe";
				if (text4.Contains(text))
				{
					this.Label1.Text = "危险文件类型！";
				}
				else
				{
					string[] array = FunLibrary.GetXmlNodeText(base.Server.MapPath("../../Public/Xml/config.xml"), "postfix").Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (text == array[i])
						{
							flag = true;
						}
					}
					if (flag)
					{
						text2 = DateTime.Now.ToString("yyyy-MM");
						str = base.Server.MapPath("../../Headquarters/Document");
						text3 = str + "\\" + text2;
						if (!Directory.Exists(text3))
						{
							Directory.CreateDirectory(text3);
						}
						int contentLength = this.FileUpload1.PostedFile.ContentLength;
						str2 = DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "");
						this.FileUpload1.PostedFile.SaveAs(text3 + "\\" + str2 + text);
						if (!FunLibrary.IsAllowedExtension(text3 + "\\" + str2 + text))
						{
							this.Label1.Text = "该文件怀疑为木马，已经删除，详细信息已记录到日志中！";
						}
						else
						{
							this.hfPath.Value = text2 + "/" + str2 + text;
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.Append("parent.CloseDialog1();");
							stringBuilder.Append(string.Concat(new string[]
							{
								"parent.iframeDialog.document.getElementById(\"hfUpload",
								this.p,
								"\").value=\"",
								this.hfPath.Value,
								"\";"
							}));
							stringBuilder.Append(string.Concat(new string[]
							{
								"parent.iframeDialog.document.getElementById(\"dUpload\").innerHTML=parent.iframeDialog.document.getElementById(\"dUpload\").innerHTML+\"<img src='../../Public/Images/dmony.gif' title='附件1' /> <a href=../../Headquarters/Document/",
								this.hfPath.Value,
								" target=_blank >附件",
								this.p,
								"</a> (",
								Convert.ToString(contentLength / 1024),
								"kb)\";"
							}));
							base.ClientScript.RegisterStartupScript(base.GetType(), "Info", stringBuilder.ToString(), true);
						}
					}
					else
					{
						this.Label1.Text = "<br/>不允许上传该文件类型！(支持的文件类型：.rar .zip .pdf .doc .xls .txt .jpg .gif)";
					}
				}
			}
		}
		catch (Exception ex)
		{
			this.Label1.Text = "<br/>文件上传失败：" + ex.ToString();
		}
	}
}
