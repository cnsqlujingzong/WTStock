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

public partial class Headquarters_Customer_CusHistory : Page, IRequiresSessionState
{

	private int icus;

	private int pageSized = 18;

	protected void Page_Load(object sender, EventArgs e)
	{
		bool btel = false;
		if (base.Request.QueryString["itel"] != null)
		{
			btel = true;
		}
		FunLibrary.ChkHead(btel);
		int.TryParse(base.Request["cusid"], out this.icus);
		if (this.icus == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int rightID = int.Parse((string)this.Session["Session_wtPurID"]);
			DALRight dALRight = new DALRight();
			if (dALRight.GetRight(rightID, "kh_r7"))
			{
				this.FillDatad();
			}
			if (dALRight.GetRight(rightID, "gd_r1"))
			{
				this.FillDatab();
			}
			if (dALRight.GetRight(rightID, "xs_r3"))
			{
				this.FillDatas();
			}
			if (dALRight.GetRight(rightID, "zl_r12"))
			{
				this.FillDatale();
			}
		}
	}

	protected void FillDatad()
	{
		int recordCount = 0;
		string strCondition = " CustomerID=" + this.icus.ToString();
		string fldSort = " ID desc";
		this.gvtrouble.DataSource = DALCommon.GetList_HL(1, "ks_device", "", this.pageSized, this.jsPagerd.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.gvtrouble.DataBind();
		this.lbCountd.Text = recordCount.ToString();
		if (this.lbCountd.Text == "0")
		{
			this.lbCountd.Visible = false;
			this.lbPaged.Visible = false;
			this.lbCountTextd.Visible = false;
		}
		else
		{
			this.lbCountd.Visible = true;
			this.lbPaged.Visible = true;
			this.lbCountTextd.Visible = true;
		}
		this.jsPagerd.PageSize = this.pageSized;
		this.jsPagerd.RecordCount = recordCount;
	}

	protected void jsPagerd_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatad();
	}

	protected void gvtrouble_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModD();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPaged.Text = "当前页:" + this.gvtrouble.Rows.Count.ToString();
		}
	}

	protected void FillDatab()
	{
		int recordCount = 0;
		string strCondition = " CustomerID=" + this.icus.ToString();
		string fldSort = " ID desc";
		this.GridView3.DataSource = DALCommon.GetList_HL(1, "fw_services", "", this.pageSized, this.jsPagerb.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView3.DataBind();
		this.lbCountb.Text = recordCount.ToString();
		if (this.lbCountb.Text == "0")
		{
			this.lbCountb.Visible = false;
			this.lbPageb.Visible = false;
			this.lbCountTextb.Visible = false;
		}
		else
		{
			this.lbCountb.Visible = true;
			this.lbPageb.Visible = true;
			this.lbCountTextb.Visible = true;
		}
		this.jsPagerb.PageSize = this.pageSized;
		this.jsPagerb.RecordCount = recordCount;
	}

	protected void jsPagerb_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatab();
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "b" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('b" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "SerV();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[20].Text.Length > 16)
			{
				e.Row.Cells[20].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[20].Text,
					"\" onclick=\"ShowTA('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[20].Text.Substring(0, 16),
					"...</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPageb.Text = "当前页:" + this.GridView3.Rows.Count.ToString();
		}
	}

	protected void FillDatas()
	{
		int recordCount = 0;
		string strCondition = " CustomerID=" + this.icus.ToString();
		string fldSort = " ID desc";
		this.GridView4.DataSource = DALCommon.GetList_HL(1, "xs_sell", "", this.pageSized, this.jsPagers.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView4.DataBind();
		this.lbCounts.Text = recordCount.ToString();
		if (this.lbCounts.Text == "0")
		{
			this.lbCounts.Visible = false;
			this.lbPages.Visible = false;
			this.lbCountTexts.Visible = false;
		}
		else
		{
			this.lbCounts.Visible = true;
			this.lbPages.Visible = true;
			this.lbCountTexts.Visible = true;
		}
		this.jsPagers.PageSize = this.pageSized;
		this.jsPagers.RecordCount = recordCount;
	}

	protected void jsPagers_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatas();
	}

	protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('s" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "SellV();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPages.Text = "当前页:" + this.GridView4.Rows.Count.ToString();
		}
	}

	protected void FillDatale()
	{
		int recordCount = 0;
		string strCondition = " CustomerID=" + this.icus.ToString();
		string fldSort = " ID desc";
		this.GridView5.DataSource = DALCommon.GetList_HL(1, "zl_lease", "", this.pageSized, this.jsPagerle.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView5.DataBind();
		this.lbCountle.Text = recordCount.ToString();
		if (this.lbCountle.Text == "0")
		{
			this.lbCountle.Visible = false;
			this.lbPagele.Visible = false;
			this.lbCountTextle.Visible = false;
		}
		else
		{
			this.lbCountle.Visible = true;
			this.lbPagele.Visible = true;
			this.lbCountTextle.Visible = true;
		}
		this.jsPagerle.PageSize = this.pageSized;
		this.jsPagerle.RecordCount = recordCount;
	}

	protected void jsPagerle_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatale();
	}

	protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "le" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('le" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "LeaseV();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPagele.Text = "当前页:" + this.GridView5.Rows.Count.ToString();
		}
	}
}
