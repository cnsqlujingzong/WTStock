using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Stat_AnIncomeType : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r50"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			for (int i = 2000; i <= 2050; i++)
			{
				ListItem listItem = new ListItem();
				listItem.Text = i.ToString();
				listItem.Value = i.ToString();
				if (i.ToString() == DateTime.Now.ToString("yyyy"))
				{
					listItem.Attributes.Add("selected", "selected");
				}
				this.ddlYear.Items.Add(listItem);
			}
		}
	}
}
