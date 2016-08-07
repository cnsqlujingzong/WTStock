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

public partial class Headquarters_Tool_SmsTimingMod : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].ToString().Replace("s", ""), out this.id);
		if (!base.IsPostBack)
		{
			this.ddlSmsTmp.DataSource = DALCommon.GetDataList("SmsTmp", "", "").Tables[0];
			this.ddlSmsTmp.DataTextField = "Title";
			this.ddlSmsTmp.DataValueField = "RecID";
			this.ddlSmsTmp.DataBind();
			this.ddlSmsTmp.Items.Insert(0, new ListItem("", ""));
			DALSmsStrategy dALSmsStrategy = new DALSmsStrategy();
			SmsStrategyInfo model = dALSmsStrategy.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlTiming.Items.Count; i++)
				{
					if (this.ddlTiming.Items[i].Text == model.SndTiming)
					{
						this.ddlTiming.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlSmsTmp.Items.Count; i++)
				{
					if (this.ddlSmsTmp.Items[i].Text == model.SmsTmp)
					{
						this.ddlSmsTmp.Items[i].Selected = true;
						break;
					}
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALSmsStrategy dALSmsStrategy = new DALSmsStrategy();
		dALSmsStrategy.Update(new SmsStrategyInfo
		{
			RecID = this.id,
			SndTiming = this.ddlTiming.SelectedItem.Text,
			SmsTmp = this.ddlSmsTmp.SelectedItem.Text
		});
		this.SysInfo("window.alert(\"操作成功！短信策略已更新\");parent.iframeDialog.$(\"btnRefTiming\").click();parent.CloseDialog1();");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
