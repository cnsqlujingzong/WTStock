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

public partial class Branch_Customer_CusAllot : Page, IRequiresSessionState
{
	private string id;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r28"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bSeller=1 ");
			OtherFunction.BindAllotReason(this.ddlCancel);
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int iType = 1;
		if (this.r2.Checked)
		{
			iType = 2;
		}
		DALCustomerList dALCustomerList = new DALCustomerList();
		int num = dALCustomerList.CusAllot(this.id.TrimEnd(new char[]
		{
			','
		}), int.Parse((string)this.Session["Session_wtUserBID"]), int.Parse(this.ddlOperator.SelectedValue), FunLibrary.ChkInput(this.tbCaReason.Value), iType, int.Parse((string)this.Session["Session_wtBranchID"]));
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！客户已分派');");
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

	protected void r1_CheckedChanged(object sender, EventArgs e)
	{
		this.lbName.Text = "跟踪人";
		OtherFunction.BindStaff(this.ddlOperator, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bSeller=1 ");
		this.ddlOperator.Items.Remove(new ListItem((string)this.Session["Session_wtUserB"], (string)this.Session["Session_wtUserBID"]));
	}

	protected void r2_CheckedChanged(object sender, EventArgs e)
	{
		this.lbName.Text = "跟踪网点";
		OtherFunction.BindBranch(this.ddlOperator);
		this.ddlOperator.Items.Remove(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
		this.ddlOperator.Items.Insert(0, new ListItem("", "-1"));
	}
}
