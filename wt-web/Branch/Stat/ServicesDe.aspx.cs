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

public partial class Branch_Stat_ServicesDe : Page, IRequiresSessionState
{
	private string billdate;

	private string startdate;

	private string enddate;

	private int deptid;

	private int iflag;

	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dr6 = 0m;

	private decimal dr7 = 0m;

	private decimal dr8 = 0m;

	private decimal dr9 = 0m;

	private decimal dr10 = 0m;

	private decimal dtest = 0m;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.billdate = base.Request["billdate"];
		this.startdate = base.Request["startdate"];
		this.enddate = base.Request["enddate"];
		int.TryParse(base.Request["deptid"], out this.deptid);
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (this.billdate == null || this.billdate == string.Empty || this.deptid == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			string text = "";
			string strCondition = "";
			if (this.iflag == 0)
			{
				if (this.billdate != "")
				{
					text = text + " and convert(char(10),a.Time_Close,120)='" + this.billdate + "'";
				}
			}
			else if (this.iflag == 1)
			{
				if (this.billdate != "")
				{
					string text2 = DateTime.Parse(this.billdate + "-01").AddMonths(1).AddDays(-1.0).ToString("yyyy-MM-dd") + " 23:59:59";
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						" and Time_Close>'",
						this.billdate,
						"-01' and Time_Close<'",
						text2,
						"'"
					});
				}
			}
			else if (this.iflag == 2)
			{
				if (this.billdate != "")
				{
					text = text + " and CustomerID=" + this.billdate;
				}
				if (this.startdate != "")
				{
					text = text + " and Time_Close>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and Time_Close<='" + this.enddate + " 23:59:59'";
				}
			}
			else if (this.iflag == 3)
			{
				if (this.billdate != "")
				{
					text = text + " and charindex('" + this.billdate + "',DisposalOper)>0";
				}
				if (this.startdate != "")
				{
					text = text + " and Time_Close>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and Time_Close<='" + this.enddate + " 23:59:59'";
				}
			}
			if (this.deptid > 0)
			{
				text = text + " and DisposalID=" + this.deptid;
			}
			this.gvdata.DataSource = DALCommon.GetStZhDetail("tj_mx", 7, text, strCondition);
			this.gvdata.DataBind();
			if (this.gvdata.Rows.Count > 0)
			{
				this.lbTitle.Visible = true;
				this.lbCount.Text = this.gvdata.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.lbTitle.Visible = false;
			}
			this.hfCount.Value = this.gvdata.Rows.Count.ToString();
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[0].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[10].Text, out this.dtest);
			this.dr3 += this.dtest;
			decimal.TryParse(e.Row.Cells[11].Text, out this.dtest);
			this.dr4 += this.dtest;
			decimal.TryParse(e.Row.Cells[12].Text, out this.dtest);
			this.dr5 += this.dtest;
			decimal.TryParse(e.Row.Cells[13].Text, out this.dtest);
			this.dr6 += this.dtest;
			decimal.TryParse(e.Row.Cells[14].Text, out this.dtest);
			this.dr7 += this.dtest;
			decimal.TryParse(e.Row.Cells[15].Text, out this.dtest);
			this.dr8 += this.dtest;
			decimal.TryParse(e.Row.Cells[16].Text, out this.dtest);
			this.dr9 += this.dtest;
			decimal.TryParse(e.Row.Cells[17].Text, out this.dtest);
			this.dr10 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[8].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[9].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[10].Text = this.dr3.ToString("#0.00");
			e.Row.Cells[11].Text = this.dr4.ToString("#0.00");
			e.Row.Cells[12].Text = this.dr5.ToString("#0.00");
			e.Row.Cells[13].Text = this.dr6.ToString("#0.00");
			e.Row.Cells[14].Text = this.dr7.ToString("#0.00");
			e.Row.Cells[15].Text = this.dr8.ToString("#0.00");
			e.Row.Cells[16].Text = this.dr9.ToString("#0.00");
			e.Row.Cells[17].Text = this.dr10.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = "";
		string strCondition = "";
		if (this.iflag == 0)
		{
			if (this.billdate != "")
			{
				text = text + " and convert(char(10),a.Time_Close,120)='" + this.billdate + "'";
			}
		}
		else if (this.iflag == 1)
		{
			if (this.billdate != "")
			{
				string text2 = DateTime.Parse(this.billdate + "-01").AddMonths(1).AddDays(-1.0).ToString("yyyy-MM-dd") + " 23:59:59";
				string text3 = text;
				text = string.Concat(new string[]
				{
					text3,
					" and Time_Close>'",
					this.billdate,
					"-01' and Time_Close<'",
					text2,
					"'"
				});
			}
		}
		else if (this.iflag == 2)
		{
			if (this.billdate != "")
			{
				text = text + " and CustomerID=" + this.billdate;
			}
			if (this.startdate != "")
			{
				text = text + " and Time_Close>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and Time_Close<='" + this.enddate + " 23:59:59'";
			}
		}
		else if (this.iflag == 3)
		{
			if (this.billdate != "")
			{
				text = text + " and charindex('" + this.billdate + "',DisposalOper)>0";
			}
			if (this.startdate != "")
			{
				text = text + " and Time_Close>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and Time_Close<='" + this.enddate + " 23:59:59'";
			}
		}
		if (this.deptid > 0)
		{
			text = text + " and DisposalID=" + this.deptid;
		}
		DataTable dt = DALCommon.GetStZhDetail("tj_mx", 7, text, strCondition).Tables[0];
		string[] tbTitle = new string[]
		{
			"单据编号",
			"所属",
			"日期",
			"制单人",
			"业务员",
			"客户名称",
			"审核日期",
			"审核人",
			"材料费",
			"人工费",
			"附加费",
			"优惠金额",
			"合计",
			"材料成本",
			"额外成本",
			"送修成本",
			"营业额",
			"毛利"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "detail", out flag, out empty);
	}
}
