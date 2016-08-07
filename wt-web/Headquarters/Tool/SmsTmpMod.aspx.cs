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

public partial class Headquarters_Tool_SmsTmpMod : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALSmsTmp dALSmsTmp = new DALSmsTmp();
			SmsTmpInfo model = dALSmsTmp.GetModel(this.id);
			if (model != null)
			{
				this.tbTitle.Text = model.Title;
				this.tbContent.Text = model.Content;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALSmsTmp dALSmsTmp = new DALSmsTmp();
		dALSmsTmp.Update(new SmsTmpInfo
		{
			RecID = this.id,
			Title = this.tbTitle.Text,
			Content = this.tbContent.Text
		});
		this.SysInfo("window.alert(\"操作成功！短信模版已更新\");parent.iframeDialog.$(\"btnRefTmp\").click();parent.CloseDialog1();");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
