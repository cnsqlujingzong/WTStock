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

public partial class Headquarters_Lease_LeaseCancel : Page, IRequiresSessionState
{

	private string id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r19"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindCancelReason(this.ddlCancel);
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALLease dALLease = new DALLease();
		int num = 0;
		int num2 = 0;
		string[] array = this.id.Split(new char[]
		{
			','
		});
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			if (num3 != 0)
			{
				int num4 = dALLease.ChkLeaseCancel(num3, int.Parse((string)this.Session["Session_wtUserID"]), FunLibrary.ChkInput(this.tbCaReason.Value), out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！" + num2.ToString() + "条业务单已取消');");
		}
		else if (num2 == 0)
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作失败！" + num.ToString() + "条业务单状态已变化，请刷新后操作！');");
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"parent.CloseDialog('2');window.alert('",
				num2.ToString(),
				"条业务单已取消；",
				num.ToString(),
				"条业务单状态已变化，请刷新后操作！');"
			}));
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
