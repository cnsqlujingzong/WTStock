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

public partial class Headquarters_System_NOMod : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "系统管理员")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=NOSet");
				base.Response.End();
			}
			DALNOPlan dALNOPlan = new DALNOPlan();
			NOPlanInfo model = dALNOPlan.GetModel(this.id);
			if (model != null)
			{
				this.tbType.Text = model.Type;
				this.tbCode.Text = model.Code;
				this.ddlTally.Text = model.Tally;
				this.ddlFrist.Text = model.BeginNO;
				this.ddlStyle.Text = model.Style;
				this.tbModel.Text = model.Model;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALNOPlan dALNOPlan = new DALNOPlan();
		dALNOPlan.Update(new NOPlanInfo
		{
			ID = this.id,
			Code = this.tbCode.Text,
			Style = this.ddlStyle.SelectedValue,
			Tally = this.ddlTally.SelectedValue,
			BeginNO = this.ddlFrist.SelectedValue,
			Model = this.tbModel.Text
		});
		this.SysInfo("window.alert('操作成功！编号信息已保存');parent.CloseDialog1();parent.iframeDialog.$(\"btnRef\").click();");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
