using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Customer_DevPlanMod : Page, IRequiresSessionState
{
	private int id;


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"].ToString().Replace("p", ""), out this.id);
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
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALMaintenancePlan dALMaintenancePlan = new DALMaintenancePlan();
		string str = "";
		int num = dALMaintenancePlan.ChkEndPlan(this.id, FunLibrary.ChkInput(this.tbName.Text), out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('" + str + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
