using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Model;

public partial class Web_Forget : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (base.IsPostBack)
		{
			this.rsp4.InnerHtml = string.Empty;
			this.rsp1.InnerHtml = string.Empty;
		}
		else
		{
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo sysParm = dALSysParm.GetSysParm();
			if (sysParm != null)
			{
				this.lbcorp.Text = sysParm.CorpName;
			}
		}
	}

	protected void btnsure_Click(object sender, EventArgs e)
	{
		string a = this.tbvalidate.Text.Trim();
		string text = this.tbemail.Text.Trim();
		if (a != (string)this.Session["ValidateCode"])
		{
			this.rsp4.InnerHtml = "验证码错误.";
			this.rsp4.Attributes.Add("class", "rsp1_w");
		}
		else
		{
			this.Session.Remove("ValidateCode");
			if (!(text == string.Empty))
			{
				DALAssociator dALAssociator = new DALAssociator();
				AssociatorInfo modelEmail = dALAssociator.GetModelEmail(text);
				if (modelEmail == null)
				{
					this.rsp1.InnerHtml = "该email帐号不存在.";
					this.rsp1.Attributes.Add("class", "rsp1_w");
				}
				else
				{
					string password = modelEmail.Password;
					string title = "您的“报修平台”密码";
					string text2 = string.Empty;
					text2 += "<div style=\"font-size:14px;font-family:Verdana; line-height:150%;\">";
					text2 = text2 + "<p>" + modelEmail._Name + ",您好！</p>";
					text2 = text2 + "<p style=\"text-indent:2em;\">您在“报修平台”的密码是" + password + "，请妥善保管。</p>";
					text2 += "</div>";
					string a2 = this.MailSend(text, title, text2);
					if (a2 == string.Empty)
					{
						this.rsp1.InnerHtml = "密码已经成功发送到您的Email邮箱，请注意查收.";
						this.tbvalidate.Text = string.Empty;
						this.rsp1.Attributes.Add("style", "color:#fff; background:#008000; padding:0 7px;");
						this.btnsure.Enabled = false;
					}
					else
					{
						this.rsp1.InnerHtml = "密码发送失败，请稍后重试..";
						this.rsp1.Attributes.Add("style", "color:#fff; background:#ff0000; padding:0 7px;");
					}
				}
			}
		}
	}

	public string MailSend(string toEmail, string title, string body)
	{
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		string result;
		if (sysParm != null)
		{
			string emailServer = sysParm.EmailServer;
			string emailLogName = sysParm.EmailLogName;
			string emailPwd = sysParm.EmailPwd;
			string s = "25";
			string emailAdr = sysParm.EmailAdr;
			int port;
			int.TryParse(s, out port);
			try
			{
				new SmtpClient(emailServer, port)
				{
					UseDefaultCredentials = true,
					Credentials = new NetworkCredential(emailLogName, emailPwd)
				}.Send(new MailMessage
				{
					From = new MailAddress(emailAdr, "报修平台"),
					To = 
					{
						new MailAddress(toEmail, "报修平台会员")
					},
					Subject = title,
					Body = body,
					IsBodyHtml = true
				});
				result = string.Empty;
				return result;
			}
			catch (Exception ex)
			{
				result = ex.Message.ToString();
				return result;
			}
		}
		result = "系统错误！请联系我们";
		return result;
	}
}
