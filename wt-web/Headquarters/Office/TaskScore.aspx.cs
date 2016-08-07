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

public partial class Headquarters_Office_TaskScore : Page, IRequiresSessionState
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
			DALRight dALRight = new DALRight();
			if (num > 0)
			{
				if (!dALRight.GetRight(num, "bg_r24"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DataTable dataTable = DALCommon.GetDataList("oa_tasklist", "", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < this.ddlCompleteRate.Items.Count; i++)
				{
					if (this.ddlCompleteRate.Items[i].Value == dataTable.Rows[0]["CompleteRate"].ToString())
					{
						this.ddlCompleteRate.Items[i].Selected = true;
						break;
					}
				}
				this.tbexecuteRemark.Text = dataTable.Rows[0]["executeRemark"].ToString();
				this.tbScore.Text = dataTable.Rows[0]["Score"].ToString();
				if (num > 0)
				{
					if (dALRight.GetRight(num, "bg_r26"))
					{
						if (dataTable.Rows[0]["Operator"].ToString() == (string)this.Session["Session_wtUser"])
						{
							this.lbMod.Text = "只有创建人才能评价该任务";
							this.lbMod.Attributes.Add("class", "si3");
							this.btnAdd.Enabled = false;
						}
					}
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		TaskListInfo taskListInfo = new TaskListInfo();
		DALTaskList dALTaskList = new DALTaskList();
		taskListInfo.ID = this.id;
		taskListInfo.CompleteRate = this.ddlCompleteRate.SelectedValue;
		taskListInfo.executeRemark = FunLibrary.ChkInput(this.tbexecuteRemark.Text);
		taskListInfo.Score = FunLibrary.ChkInput(this.tbScore.Text);
		taskListInfo.Status = "已评价";
		dALTaskList.UpdateScore(taskListInfo);
		this.SysInfo("window.alert('操作成功！该任务已评价');parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
