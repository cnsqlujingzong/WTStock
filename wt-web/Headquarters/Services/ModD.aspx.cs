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

public partial class Headquarters_Services_ModD : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].Replace("d", ""), out this.id);
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
			DataTable dataTable = DALCommon.GetDataList("ServicesDeviceConf", "", " [ID]=" + this.id.ToString()).Tables[0];
			this.tbName.Text = dataTable.Rows[0]["_Name"].ToString();
			this.tbParameter.Text = dataTable.Rows[0]["Parameter"].ToString();
			this.tbSN.Text = dataTable.Rows[0]["SN"].ToString();
			this.tbProt.Value = dataTable.Rows[0]["MaintenancePeriod"].ToString();
			this.tbBuyDate.Text = dataTable.Rows[0]["BuyDate"].ToString();
			this.tbMaintenanceEnd.Text = dataTable.Rows[0]["MaintenanceEnd"].ToString();
			this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServicesDeviceConf dALServicesDeviceConf = new DALServicesDeviceConf();
		dALServicesDeviceConf.Update(new ServicesDeviceConfInfo
		{
			ID = this.id,
			_Name = this.tbName.Text,
			SN = this.tbSN.Text,
			Parameter = this.tbParameter.Text,
			MaintenancePeriod = this.tbProt.Value,
			BuyDate = this.tbBuyDate.Text,
			MaintenanceEnd = this.tbMaintenanceEnd.Text,
			Remark = this.tbRemark.Text
		});
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
