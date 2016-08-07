using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Model;

public partial class Web_Nav : Page, IRequiresSessionState
{
	private string nstr1;

	private string nstr2;


	protected string Nstr1
	{
		get
		{
			return this.nstr1;
		}
	}

	protected string Nstr2
	{
		get
		{
			return this.nstr2;
		}
	}

	

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.nstr1 = "0";
			this.nstr2 = "0";
			DALAssociator dALAssociator = new DALAssociator();
			AssociatorInfo model = dALAssociator.GetModel((string)this.Session["Session_Web_Name"]);
			if (model != null)
			{
				int customerID = model.CustomerID;
				if (customerID > 0)
				{
					DALServices dALServices = new DALServices();
					this.nstr1 = dALServices.TCount(" CustomerID='" + customerID + "'");
					DALDeviceList dALDeviceList = new DALDeviceList();
					this.nstr2 = dALDeviceList.TCount(" CustomerID='" + customerID + "'");
				}
			}
		}
	}

	public void ChkWebUser()
	{
		if (this.Session["Session_Web_Name"] == null || this.Session["Session_Web_ID"] == null)
		{
			base.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
			base.Response.End();
		}
	}
}
