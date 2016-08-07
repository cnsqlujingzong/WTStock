using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_Services_SerAttachsAdd : Page, IRequiresSessionState
{
	private string fid;

	private string f;

	private int billid;

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		this.fid = base.Request["fid"];
		if (base.Request["bid"] != null)
		{
			int.TryParse(base.Request.QueryString["bid"], out this.billid);
		}
		if (this.fid == null || this.fid == "")
		{
			this.fid = "iframeDialog";
			this.f = "1";
		}
		else
		{
			this.f = base.Request.QueryString["f"];
		}
	}

	protected void btnUpfile_Click(object sender, EventArgs e)
	{
		bool flag = false;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		string text5 = string.Empty;
		this.Label1.Text = string.Empty;
		string text6 = string.Empty;
		try
		{
			if (this.FileUpload1.HasFile)
			{
				text6 = this.FileUpload1.FileName;
				text2 = Path.GetExtension(text6).ToLower();
				string text7 = ".asp,.aspx,.js,.asa,.jsp,.inc,.exe";
				if (text7.Contains(text2))
				{
					this.Label1.Text = "危险文件类型！";
				}
				else
				{
					string[] array = new string[]
					{
						".docx",
						".doc",
						".rar",
						".zip",
						".jpg",
						".jpeg",
						".gif",
						".bmp",
						".tiff",
						".pdf",
						".xls",
						".xlsx"
					};
					for (int i = 0; i < array.Length; i++)
					{
						if (text2 == array[i])
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						text4 = DateTime.Now.ToString("yyyy-MM");
						text = base.Server.MapPath("../../SerAttach");
						text3 = DateTime.Now.ToString("ddHHmmss");
						text5 = string.Concat(new string[]
						{
							text,
							"\\",
							text4,
							"\\",
							text3
						});
						if (!Directory.Exists(text5))
						{
							Directory.CreateDirectory(text5);
						}
						this.FileUpload1.PostedFile.SaveAs(text5 + "\\" + text6);
						if (!FunLibrary.IsAllowedExtension(text5 + "\\" + text6))
						{
							this.Label1.Text = "该文件怀疑为木马，已经删除，详细信息已记录到日志中！";
						}
						else
						{
							this.hfPath.Value = string.Concat(new string[]
							{
								"../../SerAttach",
								text4,
								"/",
								text3,
								"/",
								text6
							});
							DalSerAttach dalSerAttach = new DalSerAttach();
							SerAttachInfo serAttachInfo = new SerAttachInfo();
							serAttachInfo.FileName = text6;
							serAttachInfo.FilePath = string.Concat(new string[]
							{
								"../../SerAttach/",
								text4,
								"/",
								text3,
								"/"
							});
							serAttachInfo.BillID = this.billid;
							int num = 0;
							int.TryParse(base.Request.QueryString["t"], out num);
							serAttachInfo.iType = int.Parse(base.Request.QueryString["t"]);
							int num2 = dalSerAttach.Add(serAttachInfo);
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.Append("parent.CloseDialog" + this.f + "();");
							stringBuilder.Append(string.Concat(new object[]
							{
								"parent.",
								this.fid,
								".UploadedAttach('",
								num2,
								"');parent.",
								this.fid,
								".Rf();"
							}));
							base.ClientScript.RegisterStartupScript(base.GetType(), "Info", stringBuilder.ToString(), true);
						}
					}
					else
					{
						this.Label1.Text = "不允许上传该文件类型！(支持的文件类型：.docx .doc .rar .zip .jpg .jpeg .gif .tiff .pdf .xls .xlsx)";
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
