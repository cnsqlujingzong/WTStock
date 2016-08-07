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

public partial class Headquarters_System_UserPwd : Page, IRequiresSessionState
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
		DALUserManage dALUserManage = new DALUserManage();
		int staffID = 0;
		int.TryParse(this.Session["Session_wtUserID"].ToString(), out staffID);
		UserManageInfo model = dALUserManage.GetModel(staffID, 1);
		if (model != null)
		{
			string a = FunLibrary.StrDecode(model.Pwd);
			if (a != this.tbPswOld.Text)
			{
				this.SysInfo("window.alert('�����벻��ȷ.');$('tbPswOld').select();");
			}
			else if (this.tbPsw.Text.Trim().Length > 20 || this.tbPsw.Text.Trim().Length < 7)
			{
				this.SysInfo("window.alert('����ʧ�ܣ����볤�ȱ�����7-20λ֮��');$('tbPsw').select();");
			}
			else
			{
				dALUserManage.UpdatePs(staffID, FunLibrary.StrEncode(this.tbPsw.Text));
				this.SysInfo("window.alert('�����ɹ��������޸�����Ч');parent.CloseDialog();");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
