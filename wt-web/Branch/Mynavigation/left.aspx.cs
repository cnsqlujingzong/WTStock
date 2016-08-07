using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using wt.DAL;

public partial class Branch_Mynavigation_left : Page, IRequiresSessionState
{


	protected string[] moduln = new string[20];
    
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DataSet dataSet = DALCommon.aa_getright(num);
				DataTable dataTable = dataSet.Tables[0];
				int count = dataTable.Rows.Count;
				if (count > 0)
				{
					string a = string.Empty;
					for (int i = 1; i <= count; i++)
					{
						a = dataTable.Rows[i - 1]["pur"].ToString();
						if (a == "0")
						{
							this.moduln[i - 1] = "style=\"display:none;\"";
						}
					}
				}
			}
		}
	}
}
