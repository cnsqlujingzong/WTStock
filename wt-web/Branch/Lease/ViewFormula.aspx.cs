using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Lease_ViewFormula : Page, IRequiresSessionState
{
	private string fid;

	private string f;

	private int id;



	public string Str_Fid
	{
		get
		{
			return this.fid;
		}
	}

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		this.fid = base.Request["fid"];
		if (this.fid == null || this.fid == string.Empty)
		{
			this.fid = "iframeDialog";
			this.f = "3";
		}
		else
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			this.gvdata.DataSource = DALCommon.GetDataList("LeaseFormula", "", " BillID=" + this.id);
			this.gvdata.DataBind();
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[0].Attributes.Add("style", "background:#ECE9D8;");
		}
	}
}
