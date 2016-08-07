using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_System_BackupPlan : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "ϵͳ����Ա")
			{
				this.btnSave.Enabled = false;
				this.lbInfo.Text = "�޲���Ȩ��!";
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo sysParm = dALSysParm.GetSysParm();
			if (sysParm != null)
			{
				this.tbPath.Text = sysParm.BackUpAdr;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		string pattern = "^[a-zA-Z]:(\\\\[^\\\\/:<>\\|]+)+$";
		if (!Regex.IsMatch(this.tbPath.Text.Trim(), pattern))
		{
			this.SysInfo("window.alert('����·����ʽ����ȷ��');");
		}
		else
		{
			DALSys dALSys = new DALSys();
			dALSys.BackJob(FunLibrary.ChkInput(this.tbPath.Text));
			this.SysInfo("window.alert('���ݿⱸ�ݼƻ��ѳɹ�������');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
