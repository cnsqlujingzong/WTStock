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

public partial class Headquarters_Office_AbsenceSetAdd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		AbsenceSetInfo absenceSetInfo = new AbsenceSetInfo();
		absenceSetInfo.Type = FunLibrary.ChkInput(this.tbType.Text);
		absenceSetInfo.DeptID = 1;
		decimal dMoney = 0m;
		decimal.TryParse(this.tbMoney.Text, out dMoney);
		absenceSetInfo.dMoney = dMoney;
		absenceSetInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALAbsenceSet dALAbsenceSet = new DALAbsenceSet();
		string str;
		int num2;
		int num = dALAbsenceSet.Add(absenceSetInfo, out str, out num2);
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
