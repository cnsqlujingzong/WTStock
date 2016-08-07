using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Financial_CancelArrDetail : Page, IRequiresSessionState
{

	private int id;

	private string flag;

	private string str_did;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		this.flag = base.Request["f"];
		if (this.flag == null)
		{
			base.Response.End();
		}
		this.str_did = base.Request["detailid"];
		if (this.str_did != null)
		{
			this.str_did = this.str_did.TrimStart(new char[]
			{
				'd'
			});
		}
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
				if (!dALRight.GetRight(num, "zk_r15"))
				{
					this.btnSave.Enabled = false;
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALArrearage dALArrearage = new DALArrearage();
		int num = dALArrearage.CancelArrDetail(this.id, int.Parse(this.str_did), this.Session["Session_wtUser"].ToString(), 1, int.Parse(this.flag));
		if (num == 0)
		{
			this.SysInfo("window.alert('注销成功');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('注销失败，请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
