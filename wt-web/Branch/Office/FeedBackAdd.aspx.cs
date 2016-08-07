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

public partial class Branch_Office_FeedBackAdd : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
			}
			string text = (string)this.Session["Session_wtUserB"];
			this.tbCreateName.Text = text;
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		FeedBackInfo feedBackInfo = new FeedBackInfo();
		DALFeedBack dALFeedBack = new DALFeedBack();
		feedBackInfo.CreateDate = this.tbDate.Text;
		feedBackInfo.CreateOperator = FunLibrary.ChkInput(this.tbCreateName.Text);
		feedBackInfo.Context = FunLibrary.ChkInput(this.tbContext.Text);
		feedBackInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		feedBackInfo.curStatus = 0;
		feedBackInfo.DeptID = int.Parse(this.Session["Session_wtBranchID"].ToString());
		feedBackInfo.DeptName = this.Session["Session_wtBranch"].ToString();
		int num = dALFeedBack.InsertData(feedBackInfo);
		if (num > 0)
		{
			this.SysInfo("window.alert('操作成功！该反馈已建立');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！该反馈建立失败！');parent.CloseDialog('1');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
