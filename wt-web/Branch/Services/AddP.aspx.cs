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

public partial class Branch_Services_AddP : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "gd_r7"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString();
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
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServicesPush dALServicesPush = new DALServicesPush();
		ServicesPushInfo servicesPushInfo = new ServicesPushInfo();
		servicesPushInfo.BillID = this.id;
		servicesPushInfo._Date = this.tbDate.Text;
		servicesPushInfo.iOperator = int.Parse(this.ddlOperator.SelectedValue);
		servicesPushInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		servicesPushInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		servicesPushInfo.Result = FunLibrary.ChkInput(this.tbRemark.Text);
		string str = "";
		int num = 0;
		int num2 = dALServicesPush.Add(servicesPushInfo, out str, out num);
		if (num2 == 0)
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
