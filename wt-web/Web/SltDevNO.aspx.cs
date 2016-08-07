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
using Wuqi.Webdiyer;

public partial class Web_SltDevNO : Page, IRequiresSessionState
{
	private int pageSize = 10;
	private string user;
	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		if (!base.IsPostBack)
		{
			this.hfcusid.Value = "-1";
			this.user = (string)this.Session["Session_Web_Name"];
			DALAssociator dALAssociator = new DALAssociator();
			AssociatorInfo model = dALAssociator.GetModel(this.user);
			if (model != null)
			{
				this.hfcusid.Value = model.CustomerID.ToString();
			}
			this.FillData();
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkValue('",
				e.Row.Cells[1].Text,
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
		int num = 0;
		string strCondition = this.strParm();
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "jc_trouble", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, "ID Desc", out num);
		this.GridView1.DataBind();
		if (num == 0)
		{
			this.d_empty.Visible = true;
			this.d_page.Visible = false;
		}
		else
		{
			this.d_empty.Visible = false;
			this.d_page.Visible = true;
		}
		this.lbCount.Text = "总记录:" + num.ToString();
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = num;
	}

	protected string strParm()
	{
		string text = " 1=1 ";
		if (this.ddlkey.SelectedValue != "-1")
		{
			if (this.tbcon.Text.Trim() != "")
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"and ",
					this.ddlkey.SelectedValue,
					" like '%",
					FunLibrary.ChkInput(this.tbcon.Text),
					"%'"
				});
			}
		}
		return text;
	}

	protected void btnsch_Click(object sender, EventArgs e)
	{
		this.FillData();
	}

	protected void ReturnStr(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "ReturnStr", "document.getElementById(\"span_info\").style.display=\"inline\";document.getElementById(\"span_info\").innerHTML=\"" + str + "\";", true);
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
