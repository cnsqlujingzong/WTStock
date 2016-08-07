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

public partial class Headquarters_Customer_CloseTrack : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "kh_r4"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindCustomerStatus(this.ddlCustomerStatus);
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALCustomerList dALCustomerList = new DALCustomerList();
		int num = dALCustomerList.CloseTrack(this.id.TrimEnd(new char[]
		{
			','
		}), int.Parse(this.ddlCustomerStatus.SelectedValue));
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！客户跟踪已关闭');");
		}
		else
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作失败！请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
