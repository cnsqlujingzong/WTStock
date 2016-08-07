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

public partial class Branch_Office_FeedBackMod : Page, IRequiresSessionState
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
			FeedBackInfo feedBackInfo = new FeedBackInfo();
			DALFeedBack dALFeedBack = new DALFeedBack();
			feedBackInfo = dALFeedBack.GetList(this.id);
			if (feedBackInfo != null)
			{
				if (feedBackInfo.curStatus == 1)
				{
					this.btnAdd.Enabled = false;
				}
				if ((feedBackInfo.DeptID != int.Parse(this.Session["Session_wtBranchID"].ToString()) || !(feedBackInfo.CreateOperator == this.Session["Session_wtUserB"].ToString())) && num != 0)
				{
					this.btnAdd.Enabled = false;
				}
				this.tbDate.Text = feedBackInfo.CreateDate;
				this.tbCreateName.Text = feedBackInfo.CreateOperator;
				this.tbContext.Text = feedBackInfo.Context;
				this.tbRemark.Text = feedBackInfo.Remark;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		FeedBackInfo feedBackInfo = new FeedBackInfo();
		DALFeedBack dALFeedBack = new DALFeedBack();
		feedBackInfo.ID = this.id;
		feedBackInfo.Context = FunLibrary.ChkInput(this.tbContext.Text);
		feedBackInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		int num = dALFeedBack.Update(feedBackInfo);
		if (num > 0)
		{
			this.SysInfo("window.alert('操作成功！该任务已保存');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！');parent.CloseDialog('1');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
