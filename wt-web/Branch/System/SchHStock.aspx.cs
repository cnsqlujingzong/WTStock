using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Branch_System_SchHStock : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " 1=1 ";
		string text2 = FunLibrary.ChkInput(this.tbGoodsNO.Text);
		string text3 = FunLibrary.ChkInput(this.tbGoodsName.Text);
		string text4 = FunLibrary.ChkInput(this.tbSpec.Text);
		string text5 = FunLibrary.ChkInput(this.tbAttr.Text);
		string text6 = FunLibrary.ChkInput(this.tbBrand.Text);
		string text7 = FunLibrary.ChkInput(this.tbBaoXiu.Text);
		string text8 = FunLibrary.ChkInput(this.tbRemark.Text);
		string text9 = FunLibrary.ChkInput(this.tbSupplier.Text);
		if (text2 != "")
		{
			text = text + " and GoodsNO like '%" + text2 + "%'";
		}
		if (text3 != "")
		{
			text = text + " and _Name like '%" + text3 + "%'";
		}
		if (text4 != "")
		{
			text = text + " and Spec='" + text4 + "'";
		}
		if (text5 != "")
		{
			text = text + " and Attr='" + text5 + "'";
		}
		if (text6 != "")
		{
			text = text + " and ProductBrand='" + text6 + "'";
		}
		if (text7 != "")
		{
			text = text + " and MaintenancePeriod like '%" + text7 + "%'";
		}
		if (text8 != "")
		{
			text = text + " and Remark like '%" + text8 + "%'";
		}
		if (text9 != "")
		{
			text = text + " and Provider like '%" + text9 + "%'";
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.iframeDialog.document.getElementById(\"hfSchH\").value=\"" + text + "\";parent.iframeDialog.document.getElementById(\"btnSchH\").click();parent.CloseDialog1();", true);
	}
}
