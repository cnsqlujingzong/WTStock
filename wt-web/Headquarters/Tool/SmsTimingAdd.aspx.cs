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

public partial class Headquarters_Tool_SmsTimingAdd : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			this.ddlSmsTmp.DataSource = DALCommon.GetDataList("SmsTmp", "", "").Tables[0];
			this.ddlSmsTmp.DataTextField = "Title";
			this.ddlSmsTmp.DataValueField = "RecID";
			this.ddlSmsTmp.DataBind();
			this.ddlSmsTmp.Items.Insert(0, new ListItem("", ""));
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALSmsStrategy dALSmsStrategy = new DALSmsStrategy();
		dALSmsStrategy.Add(new SmsStrategyInfo
		{
			SndTiming = this.ddlTiming.SelectedItem.Text,
			SmsTmp = this.ddlSmsTmp.SelectedItem.Text
		});
		this.SysInfo("window.alert(\"操作成功！短信策略已建立\");parent.iframeDialog.$(\"btnRefTiming\").click();parent.CloseDialog1();");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
