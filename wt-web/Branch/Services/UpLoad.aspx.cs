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

public partial class Branch_Services_UpLoad : Page, IRequiresSessionState
{
	private string fid;

	private string f;



	public string Str_F
	{
		get
		{
			return this.f;
		}
	}


	protected void Page_Load(object sender, EventArgs e)
	{
		bool btel = false;
		if (base.Request.QueryString["itel"] != null)
		{
			btel = true;
		}
		FunLibrary.ChkBran(btel);
		this.fid = base.Request["fid"];
		if (this.fid == null || this.fid == "")
		{
			this.fid = "iframeDialog";
			this.f = "1";
		}
		else
		{
			this.f = "";
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
					this.Label1.Text = "Σ���ļ����ͣ�";
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
						if (text == array[i])
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						text3 = DateTime.Now.ToString("yyyy-MM");
						str = base.Server.MapPath("../../Headquarters/Document/Accessory");
						text4 = str + "\\" + text3;
						if (!Directory.Exists(text4))
						{
							Directory.CreateDirectory(text4);
						}
						text2 = DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "");
						this.FileUpload1.PostedFile.SaveAs(text4 + "\\" + text2 + text);
						if (!FunLibrary.IsAllowedExtension(text4 + "\\" + text2 + text))
						{
							this.Label1.Text = "���ļ�����Ϊľ���Ѿ�ɾ������ϸ��Ϣ�Ѽ�¼����־�У�";
						}
						else
						{
							this.hfPath.Value = string.Concat(new string[]
							{
								"../../Headquarters/Document/Accessory/",
								text3,
								"/",
								text2,
								text
							});
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.Append("parent.CloseDialog" + this.f + "();");
							stringBuilder.Append(string.Concat(new string[]
							{
								"parent.",
								this.fid,
								".document.getElementById(\"hfPath\").value=\"",
								this.hfPath.Value,
								"\";"
							}));
							stringBuilder.Append(string.Concat(new string[]
							{
								"parent.",
								this.fid,
								".document.getElementById(\"dUpload\").innerHTML=\"<img src='../../Public/Images/dmony.gif' title='����1' /> <a href=",
								this.hfPath.Value,
								" target=_blank >����",
								text,
								"</a>\";"
							}));
							base.ClientScript.RegisterStartupScript(base.GetType(), "Info", stringBuilder.ToString(), true);
						}
					}
					else
					{
						this.Label1.Text = "<br/>�������ϴ����ļ����ͣ�(֧�ֵ��ļ����ͣ�.docx .doc .rar .zip .jpg .jpeg .gif .tiff .pdf .xls .xlsx)";
					}
				}
			}
		}
		catch (Exception ex)
		{
			this.Label1.Text = "<br/>�ļ��ϴ�ʧ�ܣ�" + ex.ToString();
		}
	}
}
