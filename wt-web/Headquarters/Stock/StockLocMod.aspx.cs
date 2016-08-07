using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;
using wt.OtherLibrary;

public partial class Headquarters_Stock_StockLocMod : Page, IRequiresSessionState
{
	private string f;

	private string strc;

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.f = base.Request["f"];
		if (this.f == null)
		{
			this.f = string.Empty;
		}
		this.strc = base.Request["str"];
		if (this.strc == null)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			OtherFunction.BindStockLoc(this.ddlStockLoc, "DeptID=1");
			if (this.strc != string.Empty)
			{
				this.ddlStockLoc.Items.FindByText(this.strc).Selected = true;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		text = this.ddlStockLoc.SelectedItem.Value + ",";
		text = text + this.ddlStockLoc.SelectedItem.Text + ",";
		this.SysInfo("ChkAdds('" + text + "');");
	}

	protected void btnStockLoc_Click(object sender, EventArgs e)
	{
		if (this.hfStockLoc.Value != string.Empty)
		{
			OtherFunction.BindStockLoc(this.ddlStockLoc, "DeptID=1");
			this.ddlStockLoc.ClearSelection();
			this.ddlStockLoc.Items.FindByText(this.hfStockLoc.Value).Selected = true;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
