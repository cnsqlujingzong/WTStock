using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Branch_Receive_SndSureD : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "fh_r2"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindSndStyle(this.ddlSndStyle, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			RcvSndInfo model = dALRcvSnd.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlSndStyle.Items.Count; i++)
				{
					if (this.ddlSndStyle.Items[i].Value == model.SndStyleID.ToString())
					{
						this.ddlSndStyle.Items[i].Selected = true;
						break;
					}
				}
				this.tbPostNO.Text = model.PostNO;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALRcvSnd dALRcvSnd = new DALRcvSnd();
		int num = dALRcvSnd.ConfSnd(this.id, int.Parse(this.ddlSndStyle.SelectedValue), FunLibrary.ChkInput(this.tbPostNO.Text), out empty);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！该发货单转入待收货确认');");
		}
		else
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
