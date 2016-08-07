using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Lease_ShowCharge : Page, IRequiresSessionState
{

	private int id;

	private string ids;

	private string f;

	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dr6 = 0m;

	private decimal dr7 = 0m;

	private decimal dtest = 0m;

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
		if (base.Request["id"] != null)
		{
			int.TryParse(base.Request["id"].Replace("j", ""), out this.id);
		}
		this.ids = base.Request["ids"];
		if (this.id == 0 && this.ids == null)
		{
			base.Response.End();
		}
		this.f = base.Request["f"];
		if (this.f == null || this.f == "")
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r4"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			string strCondition;
			if (this.id == 0)
			{
				strCondition = " OperationID='" + this.ids + "'";
			}
			else
			{
				strCondition = " [ID]=" + this.id;
			}
			DataTable dataTable = DALCommon.GetDataList("zl_leasecharge", "", strCondition).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.id = int.Parse(dataTable.Rows[0]["ID"].ToString());
				decimal d = 0m;
				decimal.TryParse(dataTable.Rows[0]["Cycle"].ToString(), out d);
				if (d == 0m)
				{
					d = 1m;
				}
				this.tbCycle.Text = d.ToString();
				this.tbStartDate.Text = dataTable.Rows[0]["StartDate"].ToString();
				this.tbEndDate.Text = dataTable.Rows[0]["EndDate"].ToString();
				decimal d2 = 0m;
				decimal.TryParse(dataTable.Rows[0]["Rent"].ToString(), out d2);
				this.tbRent.Text = dataTable.Rows[0]["Rent"].ToString();
				this.tbAARent.Text = (this.tbARent.Text = Convert.ToDouble(d * d2).ToString());
				this.tbCycled.Text = dataTable.Rows[0]["Cycle"].ToString();
				this.tbRec.Text = dataTable.Rows[0]["dRec"].ToString();
				this.tbAASuperZhangFee.Text = dataTable.Rows[0]["SuperZhangFee"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.gvdata.DataSource = DALCommon.GetDataList("zl_leasechargedetail", "", " [BillID]=" + this.id);
				this.gvdata.DataBind();
			}
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			decimal.TryParse(e.Row.Cells[4].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dr3 += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dr4 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dr5 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dr6 = this.dtest;
			decimal.TryParse(e.Row.Cells[10].Text, out this.dtest);
			this.dr7 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[4].Text = this.dr1.ToString("#0");
			e.Row.Cells[5].Text = this.dr2.ToString("#0");
			e.Row.Cells[6].Text = this.dr3.ToString("#0");
			e.Row.Cells[7].Text = this.dr4.ToString("#0");
			e.Row.Cells[8].Text = this.dr5.ToString("#0");
			e.Row.Cells[10].Text = this.dr7.ToString("#0.00");
			e.Row.Attributes.Add("style", "color:#ff0000;text-align:right;");
		}
	}
}
