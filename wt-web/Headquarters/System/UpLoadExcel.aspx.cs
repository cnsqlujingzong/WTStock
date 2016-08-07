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

public partial class Headquarters_System_UpLoadExcel : Page, IRequiresSessionState
{
	private string str;

	private string f;

	private string f2;

	public string StrF1
	{
		get
		{
			return this.f;
		}
	}

	public string StrF2
	{
		get
		{
			return this.f2;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.str = base.Request["f"];
		if (this.str == null || this.str == "")
		{
			this.f = "1";
			this.f2 = "";
		}
		else
		{
			this.f = "2";
			this.f2 = "1";
		}
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnUpfile_Click(object sender, EventArgs e)
	{
		bool flag = false;
		string str = string.Empty;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		this.Label1.Text = string.Empty;
		try
		{
			if (this.FileUpload1.HasFile)
			{
				text = Path.GetExtension(this.FileUpload1.FileName).ToLower();
				string text5 = ".asp,.aspx,.js,.asa,.jsp,.inc,.exe";
				if (text5.Contains(text))
				{
					this.Label1.Text = "危险文件类型！";
				}
				else
				{
					string[] array = new string[]
					{
						".xlsx",
						".xls"
					};
					for (int i = 0; i < array.Length; i++)
					{
						if (text == array[i])
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						text3 = DateTime.Now.ToString("yyyy-MM");
						str = base.Server.MapPath("../Document/InputExcel");
						text4 = str + "\\" + text3;
						if (!Directory.Exists(text4))
						{
							Directory.CreateDirectory(text4);
						}
						text2 = DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "");
						this.FileUpload1.PostedFile.SaveAs(text4 + "\\" + text2 + text);
						if (!FunLibrary.IsAllowedExtension(text4 + "\\" + text2 + text))
						{
							this.Label1.Text = "该文件怀疑为木马，已经删除，详细信息已记录到日志中！";
						}
						else
						{
							this.hfPath.Value = string.Concat(new string[]
							{
								"../../Headquarters/Document/InputExcel/",
								text3,
								"/",
								text2,
								text
							});
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.Append("parent.CloseDialog" + this.f + "();");
							stringBuilder.Append(string.Concat(new string[]
							{
								"parent.iframeDialog",
								this.f2,
								".document.getElementById(\"hfPath\").value=\"",
								this.hfPath.Value,
								"\";"
							}));
							stringBuilder.Append("parent.iframeDialog" + this.f2 + ".document.getElementById(\"btnUp\").click();");
							base.ClientScript.RegisterStartupScript(base.GetType(), "Info", stringBuilder.ToString(), true);
						}
					}
					else
					{
						this.Label1.Text = "<br/>不允许上传该文件类型！(支持的文件类型：.xls .xlsx)";
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
