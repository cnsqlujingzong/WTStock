using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Office_DownLoad : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request.QueryString["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			if (base.Request.UrlReferrer != null)
			{
				if (base.Request.UrlReferrer.ToString().Contains("DocAdm.aspx"))
				{
					DALOA_Doc dALOA_Doc = new DALOA_Doc();
					string filePath = dALOA_Doc.GetFilePath(this.id);
					dALOA_Doc.UpdateHit(this.id);
					base.Response.Redirect("../Document/" + filePath);
				}
			}
		}
	}
}
