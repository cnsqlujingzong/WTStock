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

public partial class Headquarters_Services_ModI : Page, IRequiresSessionState
{

	private int id;

	private int purid = 0;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].Replace("i", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALRight dALRight = new DALRight();
			this.purid = int.Parse((string)this.Session["Session_wtPurID"]);
			if (this.purid > 0)
			{
				if (!dALRight.GetRight(this.purid, "gd_r9"))
				{
					this.btnAdd.Enabled = false;
				}
				if (dALRight.GetRight(this.purid, "gd_r26"))
				{
					this.tbDed.Attributes["onfocus"] = "blur();";
				}
			}
			DataTable dataTable = DALCommon.GetDataList("fw_servicesitem", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbItemNO.Text = dataTable.Rows[0]["ItemNO"].ToString();
				this.tbName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbPrice.Text = dataTable.Rows[0]["Price"].ToString();
				if (this.purid > 0)
				{
					if (dALRight.GetRight(this.purid, "gd_r31"))
					{
						this.tbPrice.Text = "";
					}
				}
				this.tbdPoint.Text = dataTable.Rows[0]["dPoint"].ToString();
				this.tbDed.Text = dataTable.Rows[0]["TecDeduct"].ToString();
				this.tbDisposal.Text = dataTable.Rows[0]["Tec"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				for (int i = 0; i < this.ddlChargeStyle.Items.Count; i++)
				{
					if (this.ddlChargeStyle.Items[i].Text == dataTable.Rows[0]["ChargeStyle"].ToString())
					{
						this.ddlChargeStyle.Items[i].Selected = true;
						break;
					}
				}
				if (dataTable.Rows[0]["bComplete"].ToString() != "")
				{
					this.cbbComplete.Checked = true;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALRight dALRight = new DALRight();
		this.purid = int.Parse((string)this.Session["Session_wtPurID"]);
		if (this.purid > 0)
		{
			if (dALRight.GetRight(this.purid, "gd_r31"))
			{
				this.SysInfo("window.alert('保存失败，权限不足，请取消《禁止查看项目金额》之后再操作');");
				return;
			}
		}
		DALServicesItem dALServicesItem = new DALServicesItem();
		ServicesItemInfo servicesItemInfo = new ServicesItemInfo();
		servicesItemInfo.ID = this.id;
		decimal num = 0m;
		decimal.TryParse(this.tbPrice.Text, out num);
		servicesItemInfo.Price = num;
		decimal.TryParse(this.tbdPoint.Text, out num);
		servicesItemInfo.dPoint = num;
		decimal.TryParse(this.tbDed.Text, out num);
		servicesItemInfo.TecDeduct = num;
		servicesItemInfo.Tec = this.tbDisposal.Text;
		servicesItemInfo.ChargeStyle = this.ddlChargeStyle.SelectedItem.Text;
		servicesItemInfo.Remark = this.tbRemark.Text;
		servicesItemInfo.bComplete = this.cbbComplete.Checked;
		dALServicesItem.Update(servicesItemInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
