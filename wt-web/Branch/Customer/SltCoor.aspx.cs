using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Branch_Customer_SltCoor : Page, IRequiresSessionState
{
	private string str;

	private string strcite;

	private string strf;

	private string strfid;

	

	public string strcity
	{
		get
		{
			return this.strcite;
		}
	}

	public string strarea
	{
		get
		{
			return this.str;
		}
	}

	public string str_Fid
	{
		get
		{
			return this.strfid;
		}
	}

	public string str_F
	{
		get
		{
			return this.strf;
		}
	}

	
	protected void Page_Load(object sender, EventArgs e)
	{
		bool btel = false;
		if (base.Request.QueryString["itel"] != null)
		{
			btel = true;
		}
		FunLibrary.ChkBran(btel);
		this.strcite = base.Request["strcite"];
		this.str = base.Request["str"];
		if (this.str == null)
		{
			this.str = "";
		}
		if (this.strcite == null)
		{
			this.strcite = "";
		}
		this.strf = base.Request["f"];
		if (this.strf == null || this.strf == "")
		{
			this.strfid = "iframeDialog";
			this.strf = "1";
		}
		else if (this.strf == "2")
		{
			this.strfid = "iframeDialog2";
			this.strf = "3";
		}
		else if (this.strf == "1")
		{
			this.strfid = "iframeDialog1";
			this.strf = "2";
		}
		if (!base.IsPostBack)
		{
			this.tbCity.Text = this.strcite;
			this.tbCon.Text = this.str;
		}
	}
}
