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
using wt.OtherLibrary;

public partial class Headquarters_Office_AbsencePwd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r18"))
				{
					this.ddlOperator.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALStaffList dALStaffList = new DALStaffList();
		int num = 0;
		int.TryParse(this.ddlOperator.SelectedValue, out num);
		StaffListInfo model = dALStaffList.GetModel(num);
		if (model != null)
		{
			string attendancePwd = model.AttendancePwd;
			if (attendancePwd != "")
			{
				if (attendancePwd != this.tbPwd.Text)
				{
					this.SysInfo("window.alert('旧密码不正确.');$('tbPwd').select();");
					return;
				}
			}
			dALStaffList.UpdatePwd(num, this.tbPwd1.Text);
			this.SysInfo("window.alert('操作成功！考勤密码已修改');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void btnEmptyPwd_Click(object sender, EventArgs e)
	{
		DALStaffList dALStaffList = new DALStaffList();
		int iTbid = 0;
		int.TryParse(this.ddlOperator.SelectedValue, out iTbid);
		dALStaffList.UpdatePwd(iTbid, "");
		this.SysInfo("window.alert('操作成功！考勤密码已清空');");
	}
}
