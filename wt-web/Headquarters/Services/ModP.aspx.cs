using System;
using System.Data;
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

public partial class Headquarters_Services_ModP : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].ToString().Replace("p", ""), out this.id);
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
				if (!dALRight.GetRight(num, "gd_r9"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			DataTable dataTable = DALCommon.GetDataList("fw_servicespush", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				string b = dataTable.Rows[0]["Operator"].ToString();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == b)
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbDate.Text = dataTable.Rows[0]["_Date"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Result"].ToString();
				this.ddlOperator.Enabled = false;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServicesPush dALServicesPush = new DALServicesPush();
		dALServicesPush.Update(new ServicesPushInfo
		{
			ID = this.id,
			_Date = this.tbDate.Text,
			LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text),
			Tel = FunLibrary.ChkInput(this.tbTel.Text),
			Result = FunLibrary.ChkInput(this.tbRemark.Text)
		});
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
