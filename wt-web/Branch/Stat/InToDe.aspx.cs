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

public partial class Branch_Stat_InToDe : Page, IRequiresSessionState
{
	

	private string billdate;

	private string startdate;

	private string enddate;

	private int deptid;

	private int iflag;

	private int f;

	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dtest = 0m;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.billdate = base.Request["billdate"];
		this.startdate = base.Request["startdate"];
		this.enddate = base.Request["enddate"];
		int.TryParse(base.Request["deptid"], out this.deptid);
		int.TryParse(base.Request["iflag"], out this.iflag);
		int.TryParse(base.Request["f"], out this.f);
		if (this.billdate == null || this.billdate == string.Empty || this.deptid == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			string text = " Status='已审核' ";
			if (this.iflag == 0)
			{
				if (this.billdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)='" + this.billdate + "'";
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
						" and chkdate>'",
						this.billdate,
						"-01' and chkdate<'",
						text2,
						"'"
					});
				}
			}
			else if (this.iflag == 2)
			{
				if (this.billdate.Contains("c"))
				{
					text = text + " and CusType=1 and CustomerID=" + this.billdate.Replace("c", "");
				}
				if (this.billdate.Contains("b"))
				{
					text = text + " and CusType=3 and CustomerID=" + this.billdate.Replace("b", "");
				}
				if (this.billdate.Contains("s"))
				{
					text = text + " and CusType=2 and CustomerID=" + this.billdate.Replace("s", "");
				}
				if (this.billdate.Contains("l"))
				{
					text = text + " and CusType=4 and CustomerID=" + this.billdate.Replace("l", "");
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
			else if (this.iflag == 3)
			{
				if (this.billdate != "0")
				{
					text = text + " and ChargeModeID=" + this.billdate;
				}
				else
				{
					text += " and (ChargeModeID='' or ChargeModeID is null)";
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
				if (this.billdate != "0")
				{
					text = text + " and AccountID=" + this.billdate;
				}
				else
				{
					text += " and (AccountID='' or AccountID is null)";
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
			if (this.f == 1)
			{
				text += " and Type='收款单'";
			}
			else if (this.f == 2)
			{
				text += " and Type='付款单'";
			}
			if (this.deptid > 0)
			{
				text = text + " and DeptID=" + this.deptid;
			}
			text += " and iFlag=0";
			int num = 0;
			this.gvdata.DataSource = DALCommon.GetList_HL(0, "zk_incomeexpenses", "", 0, 0, text, " ID desc ", out num);
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
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dr3 += this.dtest;
			decimal.TryParse(e.Row.Cells[10].Text, out this.dtest);
			this.dr4 += this.dtest;
			decimal.TryParse(e.Row.Cells[11].Text, out this.dtest);
			this.dr5 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计:";
			e.Row.Cells[7].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[8].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[9].Text = this.dr3.ToString("#0.00");
			e.Row.Cells[10].Text = this.dr4.ToString("#0.00");
			e.Row.Cells[11].Text = this.dr5.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = " Status='已审核' ";
		if (this.iflag == 0)
		{
			if (this.billdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)='" + this.billdate + "'";
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
					" and chkdate>'",
					this.billdate,
					"-01' and chkdate<'",
					text2,
					"'"
				});
			}
		}
		else if (this.iflag == 2)
		{
			if (this.billdate.Contains("c"))
			{
				text = text + " and CusType=1 and CustomerID=" + this.billdate.Replace("c", "");
			}
			if (this.billdate.Contains("b"))
			{
				text = text + " and CusType=3 and CustomerID=" + this.billdate.Replace("b", "");
			}
			if (this.billdate.Contains("s"))
			{
				text = text + " and CusType=2 and CustomerID=" + this.billdate.Replace("s", "");
			}
			if (this.billdate.Contains("l"))
			{
				text = text + " and CusType=4 and CustomerID=" + this.billdate.Replace("l", "");
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
		else if (this.iflag == 3)
		{
			if (this.billdate != "0")
			{
				text = text + " and ChargeModeID=" + this.billdate;
			}
			else
			{
				text += " and (ChargeModeID='' or ChargeModeID is null)";
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
			if (this.billdate != "0")
			{
				text = text + " and AccountID=" + this.billdate;
			}
			else
			{
				text += " and (AccountID='' or AccountID is null)";
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
		if (this.f == 1)
		{
			text += " and Type='收款单'";
		}
		else if (this.f == 2)
		{
			text += " and Type='付款单'";
		}
		if (this.deptid > 0)
		{
			text = text + " and DeptID=" + this.deptid;
		}
		text += " and iFlag=0";
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "zk_incomeexpenses", "type,billid,dept,_Date,operator,customername,RecMoney,DueMoney,PreMoney,RealRecMoney,RealDueMoney,ChargeStyle,Account,InvoiceClass,InvoiceNO,VoucherNO,ChargeItem,chkdate,chkoperator,Remark", 0, 0, text, " ID desc ", out num).Tables[0];
		string[] tbTitle = new string[]
		{
			"单据类别",
			"单据编号",
			"所属",
			"日期",
			"经办人",
			"往来单位",
			"应收款",
			"应付款",
			"优惠金额",
			"实收款",
			"实付款",
			"结算方式",
			"结算帐户",
			"发票类别",
			"发票号码",
			"凭证号码",
			"结算项目",
			"审核日期",
			"审核人",
			"备注"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "detail", out flag, out empty);
	}
}
