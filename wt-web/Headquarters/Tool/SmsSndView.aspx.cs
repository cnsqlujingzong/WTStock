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

public partial class Headquarters_Tool_SmsSndView : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].ToString().Replace("snd", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALSmsSnd dALSmsSnd = new DALSmsSnd();
			SmsSndInfo model = dALSmsSnd.GetModel(this.id);
			if (model != null)
			{
				this.tbTitle.Text = model.SndTo;
				this.tbContent.Text = model.Content;
			}
		}
	}
}
