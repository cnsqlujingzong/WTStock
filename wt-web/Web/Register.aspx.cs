using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Web_Register : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		if (base.IsPostBack)
		{
			this.rsp4.InnerHtml = string.Empty;
			this.rsp5.InnerHtml = string.Empty;
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

	protected void btnreg_Click(object sender, EventArgs e)
	{
		string a = this.tbvalidate.Text.Trim();
		if (a != (string)this.Session["ValidateCode"])
		{
			this.rsp4.InnerHtml = "验证码错误.";
			this.rsp4.Attributes.Add("class", "rsp1_w");
		}
		else
		{
			this.Session.Remove("ValidateCode");
			string text = this.tbName.Text.Trim();
			string password = FunLibrary.ChkInput(this.tbpwd.Text);
			string company = FunLibrary.ChkInput(this.tbcorp.Text);
			string linkMan = FunLibrary.ChkInput(this.tbman.Text);
			string tel = FunLibrary.ChkInput(this.tbtel.Text);
			string adr = FunLibrary.ChkInput(this.tbadr.Text);
			AssociatorInfo associatorInfo = new AssociatorInfo();
			associatorInfo._Name = text;
			associatorInfo.Password = password;
			associatorInfo.LinkMan = linkMan;
			associatorInfo.Company = company;
			associatorInfo.Adr = adr;
			associatorInfo.Tel = tel;
			associatorInfo.Email = this.tbemail.Text;
			associatorInfo.iFlag = true;
			associatorInfo.CustomerID = 0;
			DALAssociator dALAssociator = new DALAssociator();
			string text2;
			int num2;
			int num = dALAssociator.Add(associatorInfo, out text2, out num2);
			if (num == 0)
			{
				this.Session["Session_Web_Name"] = text;
				this.Session["Session_Web_ID"] = num2.ToString();
				base.Response.Redirect("Main.aspx");
			}
			else
			{
				this.rsp5.InnerHtml = "该会员名已经被使用了.";
				this.rsp5.Attributes.Add("class", "rsp1_w");
			}
		}
	}
}
