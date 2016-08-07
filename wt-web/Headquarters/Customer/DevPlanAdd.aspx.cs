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

public partial class Headquarters_Customer_DevPlanAdd : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r8"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.tbRemindDay.Text = "3";
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALMaintenancePlan dALMaintenancePlan = new DALMaintenancePlan();
		MaintenancePlanInfo maintenancePlanInfo = new MaintenancePlanInfo();
		maintenancePlanInfo.DevID = this.id;
		maintenancePlanInfo.DeptID = 1;
		maintenancePlanInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		maintenancePlanInfo.StartDate = this.tbStartDate.Text;
		maintenancePlanInfo.EndDate = this.tbEndDate.Text;
		maintenancePlanInfo.TimingStyle = this.ddlTimingStyle.SelectedItem.Text;
		int maintenanceCycle = 0;
		int.TryParse(this.tbMaintenanceCycle.Text, out maintenanceCycle);
		maintenancePlanInfo.MaintenanceCycle = maintenanceCycle;
		int remindDay = 0;
		int.TryParse(this.tbRemindDay.Text, out remindDay);
		maintenancePlanInfo.RemindDay = remindDay;
		maintenancePlanInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		int num2;
		int num = dALMaintenancePlan.Add(maintenancePlanInfo, out num2);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
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
