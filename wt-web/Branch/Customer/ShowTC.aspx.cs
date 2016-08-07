using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Customer_ShowTC : Page, IRequiresSessionState
{
	private int id;
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customertrack", "Content", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbContent.Text = dataTable.Rows[0]["Content"].ToString();
			}
		}
	}
}