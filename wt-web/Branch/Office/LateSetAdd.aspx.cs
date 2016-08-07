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

public partial class Branch_Office_LateSetAdd : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		LateSetInfo lateSetInfo = new LateSetInfo();
		lateSetInfo.Type = this.ddlType.SelectedValue;
		lateSetInfo.DeptID = int.Parse((string)this.Session["Session_wtBranchID"]);
		decimal dMoney = 0m;
		decimal.TryParse(this.tbMoney.Text, out dMoney);
		int startMin = 0;
		int endMin = 0;
		int.TryParse(this.tbStart.Text, out startMin);
		int.TryParse(this.tbEnd.Text, out endMin);
		lateSetInfo.StartMin = startMin;
		lateSetInfo.EndMin = endMin;
		lateSetInfo.dMoney = dMoney;
		lateSetInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALLateSet dALLateSet = new DALLateSet();
		string str;
		int num2;
		int num = dALLateSet.Add(lateSetInfo, out str, out num2);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"btnRef2\").click();");
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
