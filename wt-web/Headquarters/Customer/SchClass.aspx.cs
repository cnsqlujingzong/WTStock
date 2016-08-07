using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Customer_SchClass : Page, IRequiresSessionState
{
	private string f;

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		string text = base.Request.Form["keydata"];
		if (text == null)
		{
			base.Response.End();
		}
		this.f = base.Request.Form["f"];
		if (!base.IsPostBack)
		{
			DALRight dALRight = new DALRight();
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
			}
			text = FunLibrary.ChkInput(text);
			string str = " 1=1 ";
			if (text != string.Empty)
			{
				str = str + " and _Name like '%" + text + "%' ";
			}
			if (num > 0)
			{
			}
			string str2 = " order by [ID] Desc ";
			this.gvice.DataSource = DALCommon.GetList("ProductClass", " [ID],[_Name] ", str + str2);
			this.gvice.DataBind();
		}
	}

	protected void gvice_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "clickItem1(this.sectionRowIndex);");
			e.Row.Attributes.Add("ondblclick", "MoveDivTable();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}
}
