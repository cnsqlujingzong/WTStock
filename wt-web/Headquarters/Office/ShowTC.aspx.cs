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

public partial class Headquarters_Office_ShowTC : Page, IRequiresSessionState
{

	private int id;

	private int iflag;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DataTable dataTable = DALCommon.GetDataList("oa_tasklist", "TaskRemark,executeRemark,Score", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				if (this.iflag == 1)
				{
					this.tbContent.Text = dataTable.Rows[0]["TaskRemark"].ToString();
				}
				else if (this.iflag == 2)
				{
					this.tbContent.Text = dataTable.Rows[0]["executeRemark"].ToString();
				}
				else if (this.iflag == 3)
				{
					this.tbContent.Text = dataTable.Rows[0]["Score"].ToString();
				}
			}
		}
	}
}
