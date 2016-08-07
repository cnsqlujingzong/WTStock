using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Financial_CancelArr : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "zk_r15"))
				{
					this.btnSave.Enabled = false;
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALArrearage dALArrearage = new DALArrearage();
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
		int num = dALArrearage.CancelArr(this.id, iOperator, FunLibrary.ChkInput(this.tbReason.Text), out empty);
		if (num == 0)
		{
			this.SysInfo("window.alert('" + empty + "');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
