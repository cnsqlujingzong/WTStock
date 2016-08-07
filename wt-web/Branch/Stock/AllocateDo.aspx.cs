using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Stock_AllocateDo : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "ck_r38"))
				{
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALAllocate dALAllocate = new DALAllocate();
		int iType = 1;
		if (this.r2.Checked)
		{
			iType = 2;
		}
		else if (this.r3.Checked)
		{
			iType = 3;
		}
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
		int num = dALAllocate.ChkErrorDo(int.Parse((string)this.Session["Session_wtBranchID"]), iType, this.id, iOperator, out empty);
		if (num == 0)
		{
			this.SysInfo("window.alert('" + empty + "');parent.CloseDialog('2');");
		}
		else
		{
			this.SysInfo("window.alert('" + empty + "');parent.CloseDialog('1');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
