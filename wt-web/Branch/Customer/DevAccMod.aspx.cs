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

public partial class Branch_Customer_DevAccMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "bg_r3"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + this.Session["Session_wtBranchID"].ToString());
			DALDeviceAccessory dALDeviceAccessory = new DALDeviceAccessory();
			DeviceAccessoryInfo model = dALDeviceAccessory.GetModel(this.id);
			if (model != null)
			{
				this.tbName.Text = model._Name;
				this.tbRemark.Text = model.Remark;
				this.hfUpload.Value = model.Path;
				this.ddlOperator.SelectedValue = model.OperatorID.ToString();
				this.tbDate.Text = model._Date.ToString("yyyy-MM-dd HH:mm:ss");
				if (this.hfUpload.Value != string.Empty)
				{
					string text = this.hfUpload.Value.Substring(this.hfUpload.Value.LastIndexOf('/') + 1);
					this.dUpload.InnerHtml = string.Concat(new string[]
					{
						"<img src='../../Public/Images/dmony.gif' /> <a href=\"",
						model.Path,
						"\" target=_blank >",
						text,
						"</a>"
					});
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DeviceAccessoryInfo deviceAccessoryInfo = new DeviceAccessoryInfo();
		deviceAccessoryInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		deviceAccessoryInfo.ID = this.id;
		deviceAccessoryInfo.Path = this.hfUpload.Value;
		deviceAccessoryInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		deviceAccessoryInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		deviceAccessoryInfo._Date = DateTime.Parse(this.tbDate.Text);
		DALDeviceAccessory dALDeviceAccessory = new DALDeviceAccessory();
		dALDeviceAccessory.Update(deviceAccessoryInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
