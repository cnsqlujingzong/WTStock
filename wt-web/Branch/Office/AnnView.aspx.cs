using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Office_AnnView : Page, IRequiresSessionState
{
	private int i;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request.QueryString["id"], out this.i);
		if (this.i == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALOA_Annunciate dALOA_Annunciate = new DALOA_Annunciate();
			this.Repeater1.DataSource = DALCommon.GetDataList("oa_ann", "", "[ID]=" + this.i.ToString());
			this.Repeater1.DataBind();
			dALOA_Annunciate.UpdateHit(this.i);
		}
	}
}
