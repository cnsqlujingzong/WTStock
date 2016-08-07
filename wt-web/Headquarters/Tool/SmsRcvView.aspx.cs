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

public partial class Headquarters_Tool_SmsRcvView : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].ToString().Replace("rcv", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALSmsRcv dALSmsRcv = new DALSmsRcv();
			SmsRcvInfo model = dALSmsRcv.GetModel(this.id);
			if (model != null)
			{
				this.tbTitle.Text = model.SndFrom;
				this.tbContent.Text = model.Content;
			}
		}
	}
}
