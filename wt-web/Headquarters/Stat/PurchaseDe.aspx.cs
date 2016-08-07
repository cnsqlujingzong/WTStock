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

public partial class Headquarters_Stat_PurchaseDe : Page, IRequiresSessionState
{
	private string billdate;

	private string startdate;

	private string enddate;

	private int deptid;

	private int iflag;

	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dtest = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
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
			if (this.iflag == 1)
			{
				if (this.billdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)='" + this.billdate + "'";
				}
			}
			else if (this.iflag == 2)
			{
				if (this.billdate != "")
				{
					text = text + " and GoodsNO='" + this.billdate + "' and Type='采购'";
				}
				if (this.startdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
				}
			}
			if (this.iflag == 3)
			{
				if (this.billdate != "")
				{
					text = text + " and ProvID=" + this.billdate + " and Type='采购'";
				}
				if (this.startdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
				}
			}
			else if (this.iflag == 4)
			{
				if (this.billdate != "")
				{
					text = text + " and GoodsNO='" + this.billdate + "' and Type='退货'";
				}
				if (this.startdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
				}
			}
			if (this.iflag == 5)
			{
				if (this.billdate != "")
				{
					text = text + " and ProvID=" + this.billdate + " and Type='退货'";
				}
				if (this.startdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
				}
			}
			if (this.deptid > 0)
			{
				text = text + " and DeptID=" + this.deptid;
			}
			this.gvdata.DataSource = DALCommon.GetStZhDetail("tj_mx", 5, text, strCondition);
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
			decimal.TryParse(e.Row.Cells[13].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[14].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[15].Text, out this.dtest);
			this.dr3 += this.dtest;
			string[] array = e.Row.Cells[16].Text.Split(new char[]
			{
				','
			});
			if (array.Length > 1)
			{
				e.Row.Cells[16].Text = "<a href=\"#\" style=\"color:#0000ff;\" onclick=\"ViewSN('" + e.Row.Cells[16].Text + "');\">查看序列号</a>";
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[13].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[14].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[15].Text = this.dr3.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = "";
		string strCondition = "";
		if (this.iflag == 1)
		{
			if (this.billdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)='" + this.billdate + "'";
			}
		}
		else if (this.iflag == 2)
		{
			if (this.billdate != "")
			{
				text = text + " and GoodsNO='" + this.billdate + "' and Type='采购'";
			}
			if (this.startdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
			}
		}
		if (this.iflag == 3)
		{
			if (this.billdate != "")
			{
				text = text + " and ProvID=" + this.billdate + " and Type='采购'";
			}
			if (this.startdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
			}
		}
		else if (this.iflag == 4)
		{
			if (this.billdate != "")
			{
				text = text + " and GoodsNO='" + this.billdate + "' and Type='退货'";
			}
			if (this.startdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
			}
		}
		if (this.iflag == 5)
		{
			if (this.billdate != "")
			{
				text = text + " and ProvID=" + this.billdate + " and Type='退货'";
			}
			if (this.startdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
			}
		}
		if (this.deptid > 0)
		{
			text = text + " and DeptID=" + this.deptid;
		}
		if (this.deptid > 0)
		{
			text = text + " and DeptID=" + this.deptid;
		}
		DataTable dt = DALCommon.GetStZhDetail("tj_mx", 5, text, strCondition).Tables[0];
		string[] tbTitle = new string[]
		{
			"业务类型",
			"单据编号",
			"所属",
			"日期",
			"经办人",
			"审核日期",
			"审核人",
			"仓库",
			"编号",
			"名称",
			"规格",
			"品牌",
			"单位",
			"数量",
			"金额",
			"价税合计",
			"序列号"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "detail", out flag, out empty);
	}
}
