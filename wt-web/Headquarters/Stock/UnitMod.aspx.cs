using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.OtherLibrary;

public partial class Headquarters_Stock_UnitMod : Page, IRequiresSessionState
{
	private string strc;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.strc = base.Request["str"];
		if (this.strc == null)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			OtherFunction.BindUnit(this.ddlUnit);
			string[] array = this.strc.Split(new char[]
			{
				','
			});
			this.ddlUnit.Items.FindByValue(array[0].ToString()).Selected = true;
			this.tbRel.Text = array[2].ToString();
			this.tbBarCode.Text = array[3].ToString();
			this.tbPriceDetail.Text = array[4].ToString();
			this.tbPriceCost.Text = array[5].ToString();
			this.tbPriceInner.Text = array[6].ToString();
			this.tbPriceWho1.Text = array[7].ToString();
			this.tbPriceWho2.Text = array[8].ToString();
			this.tbPriceWho3.Text = array[9].ToString();
			DALRight dALRight = new DALRight();
			if (!dALRight.GetRight(int.Parse((string)this.Session["Session_wtPurID"]), "jc_r26"))
			{
				this.tbPriceCost.Visible = false;
			}
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
