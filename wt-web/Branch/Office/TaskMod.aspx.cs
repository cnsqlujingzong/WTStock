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
using wt.OtherLibrary;

public partial class Branch_Office_TaskMod : Page, IRequiresSessionState
{
	private int id;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
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
				if (!dALRight.GetRight(num, "bg_r19"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, " DeptID = " + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindStaff(this.ddlDoOperator, " DeptID = " + (string)this.Session["Session_wtBranchID"]);
			DataTable dataTable = DALCommon.GetDataList("oa_tasklist", "", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbDate.Text = dataTable.Rows[0]["_Date"].ToString();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == dataTable.Rows[0]["Operator"].ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlDoOperator.Items.Count; i++)
				{
					if (this.ddlDoOperator.Items[i].Text == dataTable.Rows[0]["Exer"].ToString())
					{
						this.ddlDoOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbDoDate.Text = dataTable.Rows[0]["ExeDate"].ToString();
				this.tbSummary.Text = dataTable.Rows[0]["Summary"].ToString();
				this.tbTaskRemark.Text = dataTable.Rows[0]["TaskRemark"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				if (dataTable.Rows[0]["Status"].ToString() != "待执行")
				{
					this.lbMod.Text = "只有待执行的任务才能修改！";
					this.lbMod.Attributes.Add("class", "si3");
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		TaskListInfo taskListInfo = new TaskListInfo();
		DALTaskList dALTaskList = new DALTaskList();
		taskListInfo.ID = this.id;
		taskListInfo._Date = DateTime.Parse(this.tbDate.Text);
		taskListInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		taskListInfo.ExeDate = DateTime.Parse(this.tbDoDate.Text);
		taskListInfo.ExerID = int.Parse(this.ddlDoOperator.SelectedValue);
		taskListInfo.Summary = FunLibrary.ChkInput(this.tbSummary.Text);
		taskListInfo.TaskRemark = FunLibrary.ChkInput(this.tbTaskRemark.Text);
		taskListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		dALTaskList.Update(taskListInfo);
		this.SysInfo("window.alert('操作成功！该任务已保存');parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
