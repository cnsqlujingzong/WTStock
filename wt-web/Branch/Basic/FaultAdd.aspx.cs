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

public partial class Branch_Basic_FaultAdd : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		bool btel = false;
		if (base.Request.QueryString["itel"] != null)
		{
			btel = true;
		}
		FunLibrary.ChkBran(btel);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r1"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindRepairClass(this.ddlRepair);
			this.slTroubClass.Items.Add(new ListItem("", ""));
			int num2 = 0;
			DataTable dt = DALCommon.GetList_HL(0, "TroubleClass", "", 1, 1, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", slTroubClass);
			this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
			this.ddlRepair.Items.Remove(new ListItem("新建...", "0"));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		TroubleListInfo troubleListInfo = new TroubleListInfo();
		troubleListInfo.ProductClassID = new int?(int.Parse(this.ddlClass.SelectedValue));
		troubleListInfo.RepairClassID = new int?(int.Parse(this.ddlRepair.SelectedValue));
		troubleListInfo.TroubleClassID = new int?(int.Parse(this.slTroubClass.Items[this.slTroubClass.SelectedIndex].Value));
		troubleListInfo.TroubleNO = FunLibrary.ChkInput(this.tbTroubleNO.Text);
		troubleListInfo.Summary = FunLibrary.ChkInput(this.tbName.Text);
		DALTroubleList dALTroubleList = new DALTroubleList();
		string str;
		int num2;
		int num = dALTroubleList.Add(troubleListInfo, this.cbsys.Checked, out str, out num2);
		if (num == 0)
		{
			if (this.cbClose.Checked)
			{
				this.SysInfo("parent.iframeDialog1.$(\"btnClr\").click();parent.CloseDialog2();");
			}
			else
			{
				this.SysInfo("parent.iframeDialog1.$(\"btnClr\").click();$('tbName').select();");
				this.tbName.Text = "";
			}
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + str + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
