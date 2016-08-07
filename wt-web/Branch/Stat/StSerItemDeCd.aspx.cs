using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Branch_Stat_StSerItemDeCd : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = " 1=1 ";
		string selectedValue = this.ddlBranch.SelectedValue;
		string selectedValue2 = this.ddlChargeStyle.SelectedValue;
		string text2 = FunLibrary.ChkInput(this.tbDateB.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbDateE.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbTec.Text);
		string text5 = FunLibrary.ChkInput(this.tbBillID.Text);
		string text6 = FunLibrary.ChkInput(this.tbCusName.Text).Replace("\"", "");
		string text7 = FunLibrary.ChkInput(this.tbLinkMan.Text);
		decimal d = 0m;
		decimal d2 = 0m;
		decimal.TryParse(this.tbPoint.Text, out d);
		decimal.TryParse(this.tbTecDeduct.Text, out d2);
		string text8 = FunLibrary.ChkInput(this.tbItemNO.Text).Replace("\"", "");
		string text9 = FunLibrary.ChkInput(this.tbName.Text).Replace("\"", "");
		decimal d3 = 0m;
		decimal.TryParse(this.tbTotalB.Text, out d3);
		decimal d4 = 0m;
		decimal.TryParse(this.tbTotalE.Text, out d4);
		if (selectedValue != "-1")
		{
			text = text + " and b.DisposalID='" + selectedValue + "'";
		}
		if (selectedValue2 != "")
		{
			text = text + " and a.ChargeStyle='" + selectedValue2 + "'";
		}
		if (text2 != "")
		{
			text = text + " and b.Time_TakeOver>='" + text2 + "'";
		}
		if (text3 != "")
		{
			text = text + " and b.Time_TakeOver<='" + text3 + " 23:59:59'";
		}
		if (text6 != "")
		{
			text = text + " and b.CustomerName like '%" + text6 + "%'";
		}
		if (text7 != "")
		{
			text = text + " and b.LinkMan like '%" + text7 + "%'";
		}
		if (text8 != "")
		{
			text = text + " and c.ItemNO like '%" + text8 + "%'";
		}
		if (text9 != "")
		{
			text = text + " and c._Name like '%" + text9 + "%'";
		}
		if (text5 != "")
		{
			text = text + " and b.BillID like '%" + text5 + "%'";
		}
		if (d2 > 0m)
		{
			text = text + " and a.TecDeduct=" + d2.ToString();
		}
		if (d > 0m)
		{
			text = text + " and a.dPoint=" + d.ToString();
		}
		if (text4 != "")
		{
			text = text + " and a.Tec like '%" + text4 + "%'";
		}
		if (d3 > 0m)
		{
			text = text + " and a.Price>=" + d3.ToString();
		}
		if (d4 > 0m)
		{
			text = text + " and a.Price<=" + d4.ToString();
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text + "\");parent.CloseDialog();", true);
	}
}
