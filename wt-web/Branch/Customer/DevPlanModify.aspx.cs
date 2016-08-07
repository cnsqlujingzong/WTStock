using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Branch_Customer_DevPlanModify : Page, IRequiresSessionState
{


	private int id;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"].Trim(new char[]
		{
			'p'
		}), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r7"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DALMaintenancePlan dALMaintenancePlan = new DALMaintenancePlan();
			DataSet dataList = DALCommon.GetDataList("MaintenancePlan", "", "ID=" + this.id);
			this.tbName.Text = dataList.Tables[0].Rows[0]["_Name"].ToString();
			string text = dataList.Tables[0].Rows[0]["StartDate"].ToString();
			string text2 = dataList.Tables[0].Rows[0]["EndDate"].ToString();
			this.tbStartDate.Text = ((text != string.Empty) ? text.Split(new char[]
			{
				' '
			})[0] : "");
			this.tbEndDate.Text = ((text2 != string.Empty) ? text2.Split(new char[]
			{
				' '
			})[0] : "");
			this.ddlTimingStyle.SelectedValue = dataList.Tables[0].Rows[0]["TimingStyle"].ToString();
			this.tbMaintenanceCycle.Text = dataList.Tables[0].Rows[0]["MaintenanceCycle"].ToString();
			this.tbRemindDay.Text = dataList.Tables[0].Rows[0]["RemindDay"].ToString();
			this.tbRemark.Text = dataList.Tables[0].Rows[0]["Remark"].ToString();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALMaintenancePlan dALMaintenancePlan = new DALMaintenancePlan();
		MaintenancePlanInfo maintenancePlanInfo = new MaintenancePlanInfo();
		maintenancePlanInfo.ID = this.id;
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
		string empty = string.Empty;
		int num = dALMaintenancePlan.Update(maintenancePlanInfo, out empty);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('ÏµÍ³´íÎó£¡" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
