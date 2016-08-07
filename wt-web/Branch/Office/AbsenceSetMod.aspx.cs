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

public partial class Branch_Office_AbsenceSetMod : Page, IRequiresSessionState
{
	private int id;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"].Replace("q", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALAbsenceSet dALAbsenceSet = new DALAbsenceSet();
			AbsenceSetInfo model = dALAbsenceSet.GetModel(this.id);
			if (model != null)
			{
				this.tbType.Text = model.Type;
				this.tbMoney.Text = model.dMoney.ToString();
				this.tbRemark.Text = model.Remark;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		AbsenceSetInfo absenceSetInfo = new AbsenceSetInfo();
		absenceSetInfo.ID = this.id;
		absenceSetInfo.Type = FunLibrary.ChkInput(this.tbType.Text);
		decimal dMoney = 0m;
		decimal.TryParse(this.tbMoney.Text, out dMoney);
		absenceSetInfo.dMoney = dMoney;
		absenceSetInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALAbsenceSet dALAbsenceSet = new DALAbsenceSet();
		string str;
		int num = dALAbsenceSet.Update(absenceSetInfo, "", out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"btnRef3\").click();");
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + str + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
