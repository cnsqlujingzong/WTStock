using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Lease_HistoryReading : Page, IRequiresSessionState
{

	private string id;

	protected void Page_Load(object sender, EventArgs e)
	{
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			this.ddlQtyType.DataSource = DALCommon.GetDataList("zl_leasedetail", "QtyTypeName,QtyType", " iBillID=" + this.id);
			this.ddlQtyType.DataTextField = "QtyTypeName";
			this.ddlQtyType.DataValueField = "QtyType";
			this.ddlQtyType.DataBind();
			this.ddlQtyType.Items.Insert(0, new ListItem("", ""));
			this.ShowDetail();
		}
	}

	protected void ShowDetail()
	{
		string text = " BillID=" + this.id;
		if (this.ddlQtyType.SelectedValue != "")
		{
			text = text + " and QtyType=" + this.ddlQtyType.SelectedValue;
		}
		if (this.tbDateB.Text != "")
		{
			text = text + " and _Date>='" + this.tbDateB.Text + "'";
		}
		if (this.tbDateD.Text != "")
		{
			text = text + " and _Date<='" + this.tbDateD.Text + " 23:59:59'";
		}
		text += " order by [_Date] desc";
		this.gvdata.DataSource = DALCommon.GetDataList("zl_meterreading", "", text);
		this.gvdata.DataBind();
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.ShowDetail();
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.ShowDetail();
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.ShowDetail();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}
}
