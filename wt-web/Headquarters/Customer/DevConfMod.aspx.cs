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

public partial class Headquarters_Customer_DevConfMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "kh_r8"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DALDeviceConfig dALDeviceConfig = new DALDeviceConfig();
			DeviceConfigInfo model = dALDeviceConfig.GetModel(this.id);
			if (model != null)
			{
				this.tbName.Text = model._Name;
				this.tbParameter.Text = model.Parameter;
				this.tbSN.Text = model.SN;
				this.tbProt.Value = model.MaintenancePeriod;
				this.tbBuyDate.Text = model.BuyDate;
				this.tbMaintenanceEnd.Text = model.MaintenanceEnd;
				this.tbRemark.Text = model.Remark;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALDeviceConfig dALDeviceConfig = new DALDeviceConfig();
		dALDeviceConfig.Update(new DeviceConfigInfo
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
