using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;
using wt.OtherLibrary;

public partial class Headquarters_Stock_UnitAdd : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			OtherFunction.BindUnit(this.ddlUnit);
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		text = this.ddlUnit.SelectedItem.Value + ",";
		text = text + this.ddlUnit.SelectedItem.Text + ",";
		text = text + FunLibrary.ChkInput(this.tbRel.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbBarCode.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbPriceDetail.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbPriceCost.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbPriceInner.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbPriceWho1.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbPriceWho2.Text) + ",";
		text += FunLibrary.ChkInput(this.tbPriceWho3.Text);
		this.SysInfo("ChkAdd('" + text + "');");
		if (!this.cbClose.Checked)
		{
			this.ClearText();
			this.SysInfo("$(\"tbName\").focus();");
		}
	}

	protected void ClearText()
	{
		this.ddlUnit.ClearSelection();
		this.ddlUnit.Items.FindByText("").Selected = true;
		this.tbBarCode.Text = (this.tbPriceCost.Text = (this.tbPriceDetail.Text = (this.tbPriceInner.Text = (this.tbPriceWho1.Text = (this.tbPriceWho2.Text = (this.tbPriceWho3.Text = (this.tbRel.Text = string.Empty)))))));
	}

	protected void btnRefUnit_Click(object sender, EventArgs e)
	{
		if (this.hfUnit.Value != string.Empty)
		{
			OtherFunction.BindUnit(this.ddlUnit);
			this.ddlUnit.ClearSelection();
			this.ddlUnit.Items.FindByText(this.hfUnit.Value).Selected = true;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
