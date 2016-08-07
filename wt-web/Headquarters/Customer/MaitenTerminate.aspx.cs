using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Customer_MaitenTerminate : Page, IRequiresSessionState
{
	private int id = 0;

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
				if (!dALRight.GetRight(num, "kh_r24"))
				{
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALMaintenanceContract dALMaintenanceContract = new DALMaintenanceContract();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALMaintenanceContract.ContEnd(1, this.id, iOperator, this.tbCaReason.Value, out empty);
		if (num == 0)
		{
			if (base.Request["fp"] == null)
			{
				this.SysInfo("parent.CloseDialog('2');");
			}
			else
			{
				this.SysInfo("parent.CloseDialog('3');");
			}
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('ϵͳ������鿴������־');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
