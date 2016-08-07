using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.OtherLibrary;

public partial class Branch_Lease_Transpond : Page, IRequiresSessionState
{


	private int id = 0;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id <= 0 && base.Request.QueryString["idlist"] == null)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r27"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("", "-1"));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALLease dALLease = new DALLease();
		if (this.id > 0)
		{
			int num = dALLease.Transpond(this.id, int.Parse(this.ddlBranch.SelectedValue), int.Parse(this.Session["Session_wtUserBID"].ToString()));
			if (num > 0)
			{
				this.SysInfo("parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("alert('派单失败！');");
			}
		}
		else
		{
			string[] array = base.Request.QueryString["idlist"].Trim().Trim(new char[]
			{
				','
			}).Split(new char[]
			{
				','
			});
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				int.TryParse(array[i], out num4);
				int num = dALLease.Transpond(num4, int.Parse(this.ddlBranch.SelectedValue), int.Parse(this.Session["Session_wtUserBID"].ToString()));
				if (num > 0)
				{
					num2++;
				}
				else
				{
					num3++;
				}
			}
			if (num2 > 0)
			{
				if (num3 > 0)
				{
					this.SysInfo(string.Format("alert('派单成功！{0}条租赁单派单成功，{1}条租赁单派单失败');parent.CloseDialog('1');", num2, num3));
				}
				else
				{
					this.SysInfo("parent.CloseDialog('1');");
				}
			}
			else
			{
				this.SysInfo("alert('派单失败！');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
