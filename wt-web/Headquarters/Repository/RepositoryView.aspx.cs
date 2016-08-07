using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_Repository_RepositoryView : Page, IRequiresSessionState
{
	private int i;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request.QueryString["id"], out this.i);
		if (this.i == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALRepository dALRepository = new DALRepository();
			RepositoryInfo model = dALRepository.GetModel(this.i);
			if (model != null)
			{
				if (model.AccessLevel == 4)
				{
					if (model.AuthorID != int.Parse((string)this.Session["Session_wtUserID"]))
					{
						base.Response.Write("无查看权限！");
						return;
					}
				}
				this.Repeater1.DataSource = DALCommon.GetDataList("zs_repository", "", "[ID]=" + this.i.ToString());
				this.Repeater1.DataBind();
				dALRepository.UpdateHit(this.i);
			}
		}
	}
}
