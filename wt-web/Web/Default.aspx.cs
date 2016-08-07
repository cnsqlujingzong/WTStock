using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.DB;
using wt.Library;
using wt.Model;

public partial class Web_Default : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			string text = base.Request.QueryString["a"];
			if (text == null)
			{
				if (this.Session["Session_Web_Name"] != null && this.Session["Session_Web_ID"] != null)
				{
					this.sp_m.InnerHtml = "您已经登陆. <a title=\"点击进入管理面版.\" href=\"Main.aspx\" style=\"color:#fff;text-decoration:none;\">[点此进入]</a>";
					this.sp_m.Attributes.Add("class", "s1_o");
				}
			}
			else if (text == "1")
			{
				this.PutInfo("登陆超时，或没有登陆.");
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo sysParm = dALSysParm.GetSysParm();
			if (sysParm != null)
			{
				DALSysVali dALSysVali = new DALSysVali();
				string corpName = sysParm.CorpName;
				string str = sysParm.BranchNum.ToString();
				string str2 = sysParm.bWeb.ToString();
				string value = dALSysVali.GetValue("ITEM2");
				string text2 = corpName + str2 + str;
				if (sysParm.bSim)
				{
					text2 += "并发";
				}
				string b = FunLibrary.EncodeReg(text2);
				this.Page.Title = "在线报修平台-" + sysParm.CorpName;
				if (value != b)
				{
					string value2 = dALSysVali.GetValue("ITEM1");
					try
					{
						string time = FunLibrary.StrDecode(value2);
                        int num = 0; //this.DayTs(time);
						if (num > 60 || num < 0)
						{
							base.Response.Redirect("../Branch/Guide.html");
						}
						else
						{
							this.Page.Title = this.Page.Title + "(已试用了" + Convert.ToString(num) + "天)";
						}
					}
					catch
					{
						base.Response.Redirect("../Branch/Guide.html");
					}
				}
				if (sysParm.bWeb == 1)//(sysParm.bWeb == 0)
                {
					base.Response.Redirect("../Branch/Guide.html");
				}
				this.lbcorp.Text = sysParm.CorpName;
				this.lbtel.Text = sysParm.Tel;
				this.lbadr.Text = sysParm.Adr;
			}
		}
	}

	protected void btnlogin_Click(object sender, EventArgs e)
	{
		string text = this.tbuser.Text.Trim();
		string text2 = this.tbpwd.Text.Trim();
		string a = this.tbvalidate.Text.Trim();
		if (a != (string)this.Session["ValidateCode"])
		{
			this.PutInfo("验证码错误.");
		}
		else
		{
			this.Session.Remove("ValidateCode");
			if (!(text == string.Empty) && !(text2 == string.Empty))
			{
				DALAssociator dALAssociator = new DALAssociator();
				AssociatorInfo model = dALAssociator.GetModel(text);
				if (model == null)
				{
					this.PutInfo("帐号不存在.");
				}
				else if (model.Password != text2)
				{
					this.PutInfo("密码错误.");
				}
				else if (!model.iFlag)
				{
					this.PutInfo("帐号被冻结了.");
				}
				else
				{
					this.Session["Session_Web_Name"] = model._Name;
					this.Session["Session_Web_ID"] = model.ID.ToString();
					DALUserManage dALUserManage = new DALUserManage();
					DbHelperSQL.InsertErrorLogs(1, 0, 0, "登录WEB自助平台", model.ID);
					base.Response.Redirect("Main.aspx");
				}
			}
		}
	}

	protected void PutInfo(string info)
	{
		this.sp_m.InnerHtml = info;
		this.sp_m.Attributes.Add("class", "s1_i");
	}

	protected int DayTs(string time)
	{
		DateTime d = DateTime.Parse(time);
		DateTime now = DateTime.Now;
		return 1;
	}
}
