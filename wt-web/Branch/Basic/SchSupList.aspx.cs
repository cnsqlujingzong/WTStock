using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Basic_SchSupList : Page, IRequiresSessionState
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
		FunLibrary.ChkBran();
		string text = base.Request.Form["keydata"];
		if (text == null)
		{
			base.Response.End();
		}
		this.f = base.Request.Form["f"];
		if (!base.IsPostBack)
		{
			DALRight dALRight = new DALRight();
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
			}
			text = FunLibrary.ChkInput(text);
			string text2 = " bStop=0 ";
			if (text != string.Empty)
			{
				string text3 = text2;
				text2 = string.Concat(new string[]
				{
					text3,
					" and (SupNO like '%",
					text,
					"%' or _Name like '%",
					text,
					"%' or pyCode like '%",
					text,
					"%' or LinkMan like '%",
					text,
					"%' or Tel like '%",
					text,
					"%')"
				});
			}
			string str = " order by [ID] Desc ";
			this.gvice.DataSource = DALCommon.GetList("SupplierList", " top 10 [ID],SupNO,_Name,LinkMan,Tel", text2 + str);
			this.gvice.DataBind();
		}
	}

	protected void gvice_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "clickItem(this.sectionRowIndex);");
			e.Row.Attributes.Add("ondblclick", "MoveDivTable();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}
}
