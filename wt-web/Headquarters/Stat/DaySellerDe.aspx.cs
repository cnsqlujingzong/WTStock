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

public partial class Headquarters_Stat_DaySellerDe : Page, IRequiresSessionState
{
	private string billdate;

	private int deptid;

	private int iflag;

	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dtest = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.billdate = base.Request["billdate"];
		int.TryParse(base.Request["deptid"], out this.deptid);
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (this.billdate == null || this.billdate == string.Empty || this.deptid == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			string text = "";
			string text2 = "";
			if (this.iflag == 0)
			{
				if (this.billdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)='" + this.billdate + "'";
					text2 = text2 + " and convert(char(10),Time_Close,120)='" + this.billdate + "'";
				}
			}
			else if (this.iflag == 2)
			{
				if (this.billdate != "")
				{
					string text3 = DateTime.Parse(this.billdate + "-01").AddMonths(1).AddDays(-1.0).ToString("yyyy-MM-dd") + " 23:59:59";
					string text4 = text;
					text = string.Concat(new string[]
					{
						text4,
						" and chkdate>'",
						this.billdate,
						"-01' and chkdate<'",
						text3,
						"'"
					});
					text4 = text2;
					text2 = string.Concat(new string[]
					{
						text4,
						" and Time_Close>'",
						this.billdate,
						"-01' and Time_Close<'",
						text3,
						"'"
					});
				}
			}
			if (this.deptid > 0)
			{
				text = text + " and DeptID=" + this.deptid;
				text2 = text2 + " and DisposalID=" + this.deptid;
			}
			this.gvdata.DataSource = DALCommon.GetStZhDetail("tj_zh_mx", 1, text, text2);
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
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[1].Text,
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
			if (e.Row.Cells[0].Text == "退货")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[8].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[9].Text = this.dr2.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = "";
		string text2 = "";
		if (this.iflag == 0)
		{
			if (this.billdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)='" + this.billdate + "'";
				text2 = text2 + " and convert(char(10),Time_Close,120)='" + this.billdate + "'";
			}
		}
		else if (this.iflag == 2)
		{
			if (this.billdate != "")
			{
				string text3 = DateTime.Parse(this.billdate + "-01").AddMonths(1).AddDays(-1.0).ToString("yyyy-MM-dd") + " 23:59:59";
				string text4 = text;
				text = string.Concat(new string[]
				{
					text4,
					" and chkdate>'",
					this.billdate,
					"-01' and chkdate<'",
					text3,
					"'"
				});
				text4 = text2;
				text2 = string.Concat(new string[]
				{
					text4,
					" and Time_Close>'",
					this.billdate,
					"-01' and Time_Close<'",
					text3,
					"'"
				});
			}
		}
		if (this.deptid > 0)
		{
			text = text + " and DeptID=" + this.deptid;
			text2 = text2 + " and DisposalID=" + this.deptid;
		}
		DataTable dt = DALCommon.GetStZhDetail("tj_zh_mx", 1, text, text2).Tables[0];
		string[] tbTitle = new string[]
		{
			"单据类别",
			"单据编号",
			"所属",
			"日期",
			"制单人",
			"业务员",
			"技术员",
			"客户名称",
			"金额",
			"毛利",
			"审核日期",
			"审核人"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "detail", out flag, out empty);
	}
}
