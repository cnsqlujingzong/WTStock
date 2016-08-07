using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using Wuqi.Webdiyer;

public partial class Interface_Customer : Page, IRequiresSessionState
{
	
	private int pageSize = 15;

	private string tel;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		this.tel = base.Server.UrlDecode(base.Request.QueryString["tel"]);
		if (!(this.tel == string.Empty) && this.tel != null)
		{
			this.tel = FunLibrary.ChkInput(this.tel);
			if (!base.IsPostBack)
			{
				this.FillData();
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkValue('",
				e.Row.Cells[0].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ChkPass();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Attributes.Add("style", "height:17px;padding-left:5px;vertical-align:text-bottom");
			this.lbPage.Text = "当前页:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void FillData()
	{
		int recordCount = 0;
		string strCondition = string.Concat(new string[]
		{
			" Tel like '%",
			this.tel,
			"%' or Tel2 like '%",
			this.tel,
			"%' or [ID] in(select CustomerID from CustomerLinkMan where tel_Office='",
			this.tel,
			"' or tel_Home='",
			this.tel,
			"' or tel_Mobile='",
			this.tel,
			"')"
		});
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "ks_customer", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, " ID desc ", out recordCount);
		this.GridView1.DataBind();
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
		this.lbCount.Text = "总记录:" + recordCount.ToString();
		if (this.lbCount.Text == "总记录:0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
