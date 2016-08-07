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

public partial class Headquarters_Office_TimeSetAdd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			this.tbStartDate.Text = "09:00:00";
			this.tbEndDate.Text = "17:00:00";
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		AttendanceTimeInfo attendanceTimeInfo = new AttendanceTimeInfo();
		attendanceTimeInfo.Week = this.ddlWeek.SelectedValue;
		attendanceTimeInfo.DeptID = 1;
		attendanceTimeInfo.WorkTime = this.tbStartDate.Text;
		attendanceTimeInfo.AfterWorkTime = this.tbEndDate.Text;
		attendanceTimeInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALAttendanceTime dALAttendanceTime = new DALAttendanceTime();
		string str;
		int num2;
		int num = dALAttendanceTime.Add(attendanceTimeInfo, out str, out num2);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"btnRef1\").click();");
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
