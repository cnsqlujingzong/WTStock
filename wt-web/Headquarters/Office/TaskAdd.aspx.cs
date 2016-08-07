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

public partial class Headquarters_Office_TaskAdd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r20"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, " DeptID=1 ");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbDoDate.Text = (this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd"));
			OtherFunction.BindStaff(this.ddlDoOperator, " DeptID=1 ");
			for (int i = 0; i < this.ddlDoOperator.Items.Count; i++)
			{
				if (this.ddlDoOperator.Items[i].Text == b)
				{
					this.ddlDoOperator.Items[i].Selected = true;
					break;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		TaskListInfo taskListInfo = new TaskListInfo();
		DALTaskList dALTaskList = new DALTaskList();
		taskListInfo.DeptID = 1;
		taskListInfo._Date = DateTime.Parse(this.tbDate.Text);
		taskListInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		taskListInfo.ExeDate = DateTime.Parse(this.tbDoDate.Text);
		taskListInfo.ExerID = int.Parse(this.ddlDoOperator.SelectedValue);
		taskListInfo.Summary = FunLibrary.ChkInput(this.tbSummary.Text);
		taskListInfo.TaskRemark = FunLibrary.ChkInput(this.tbTaskRemark.Text);
		taskListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		taskListInfo.Status = "待执行";
		dALTaskList.Add(taskListInfo);
		this.SysInfo("window.alert('操作成功！该任务已建立');parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
