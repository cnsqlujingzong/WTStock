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
using wt.OtherLibrary;

public partial class Headquarters_Customer_TrackAllot : Page, IRequiresSessionState
{
	private int id;

	private string str;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		this.str = base.Request["str"];
		if (this.str == null)
		{
			this.str = "";
		}
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
				if (!dALRight.GetRight(num, "kh_r11"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindServiceLevel(this.ddlPRI);
			this.tbRemark.Text = this.str;
			DataTable dataTable = DALCommon.GetDataList("ks_consumablestrack", "", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["Type"].ToString() != "租赁")
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "销售业务产生的耗材跟踪不能做派工处理！";
					this.lbMod.Attributes.Add("class", "si1");
				}
			}
			else
			{
				this.btnAdd.Enabled = false;
				this.lbMod.Text = "当前记录不存在！";
				this.lbMod.Attributes.Add("class", "si2");
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALConsumablesTrack dALConsumablesTrack = new DALConsumablesTrack();
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		string disOperator = FunLibrary.ChkInput(this.tbDisposal.Text);
		int pRI = int.Parse(this.ddlPRI.SelectedItem.Value);
		string remark = FunLibrary.ChkInput(this.tbRemark.Text);
		string str = "";
		int num = dALConsumablesTrack.ChkTrackAllot(this.id, iOperator, disOperator, pRI, remark, out str);
		if (num == 0)
		{
			this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
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
