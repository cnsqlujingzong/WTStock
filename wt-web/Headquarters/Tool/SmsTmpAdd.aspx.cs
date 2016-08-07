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

public partial class Headquarters_Tool_SmsTmpAdd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALSmsTmp dALSmsTmp = new DALSmsTmp();
		dALSmsTmp.Add(new SmsTmpInfo
		{
			Title = this.tbTitle.Text,
			Content = this.tbContent.Text
		});
		this.SysInfo("window.alert(\"操作成功！短信模版已建立\");parent.iframeDialog.$(\"btnRefTmp\").click();parent.CloseDialog1();");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
