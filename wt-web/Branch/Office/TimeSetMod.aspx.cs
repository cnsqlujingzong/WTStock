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

public partial class Branch_Office_TimeSetMod : Page, IRequiresSessionState
{
	

	private int id;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"].ToString().Replace("t", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALAttendanceTime dALAttendanceTime = new DALAttendanceTime();
			AttendanceTimeInfo model = dALAttendanceTime.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlWeek.Items.Count; i++)
				{
					if (this.ddlWeek.Items[i].Text == model.Week)
					{
						this.ddlWeek.Items[i].Selected = true;
						break;
					}
				}
				this.hfTemp.Value = model.Week;
				this.tbStartDate.Text = model.WorkTime;
				this.tbEndDate.Text = model.AfterWorkTime;
				this.tbRemark.Text = model.Remark;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		AttendanceTimeInfo attendanceTimeInfo = new AttendanceTimeInfo();
		attendanceTimeInfo.ID = this.id;
		attendanceTimeInfo.Week = this.ddlWeek.SelectedValue;
		attendanceTimeInfo.DeptID = int.Parse((string)this.Session["Session_wtBranchID"]);
		attendanceTimeInfo.WorkTime = this.tbStartDate.Text;
		attendanceTimeInfo.AfterWorkTime = this.tbEndDate.Text;
		attendanceTimeInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		string chkfld = string.Empty;
		if (attendanceTimeInfo.Week != this.hfTemp.Value)
		{
			chkfld = "_Name='" + attendanceTimeInfo.Week + "' and DeptID=" + (string)this.Session["Session_wtBranchID"];
		}
		DALAttendanceTime dALAttendanceTime = new DALAttendanceTime();
		string str;
		int num = dALAttendanceTime.Update(attendanceTimeInfo, chkfld, out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"btnRef1\").click();");
		}
		else
		{
			this.SysInfo("window.alert('" + str + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
