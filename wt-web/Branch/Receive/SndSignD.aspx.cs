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

public partial class Branch_Receive_SndSignD : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "fh_r3"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALRcvSnd dALRcvSnd = new DALRcvSnd();
		if (dALRcvSnd.isFirm(this.id))
		{
			this.SysInfo("window.alert('该收货类型只能由总部签收！');");
		}
		else
		{
			int num = dALRcvSnd.ConfRcv(this.id, int.Parse(this.ddlOperator.SelectedValue), this.tbDate.Text, out empty);
			if (num == 0)
			{
				this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！该发货单已签收');");
			}
			else
			{
				this.SysInfo("window.alert('" + empty + "');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
