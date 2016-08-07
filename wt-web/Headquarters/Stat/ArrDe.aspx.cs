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

public partial class Headquarters_Stat_ArrDe : Page, IRequiresSessionState
{
	private int id;

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
		this.startdate = base.Request["startdate"];
		this.enddate = base.Request["enddate"];
		int.TryParse(base.Request["deptid"], out this.deptid);
		int.TryParse(base.Request["iflag"], out this.iflag);
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0 || this.deptid == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			string text = " Status=1 and BillID=" + this.id;
			if (this.startdate != "")
			{
				text = text + " and convert(char(10),_Date,120)>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and convert(char(10),_Date,120)<='" + this.enddate + " 23:59:59'";
			}
			if (this.deptid > 0)
			{
				text = text + " and DeptID=" + this.deptid;
			}
			int num = 0;
			this.gvdata.DataSource = DALCommon.GetList_HL(0, "zk_arrearagedetail2", "", 0, 0, text, " ID desc ", out num);
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
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "应付款")
			{
				e.Row.Cells[8].Text = "-" + e.Row.Cells[8].Text;
				e.Row.Cells[9].Text = "-" + e.Row.Cells[9].Text;
				e.Row.Cells[10].Text = "-" + e.Row.Cells[10].Text;
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[10].Text, out this.dtest);
			this.dr3 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计:";
			e.Row.Cells[8].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[9].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[10].Text = this.dr3.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = " Status=1 and BillID=" + this.id;
		if (this.startdate != "")
		{
			text = text + " and convert(char(10),_Date,120)>='" + this.startdate + "'";
		}
		if (this.enddate != "")
		{
			text = text + " and convert(char(10),_Date,120)<='" + this.enddate + " 23:59:59'";
		}
		if (this.deptid > 0)
		{
			text = text + " and DeptID=" + this.deptid;
		}
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "zk_arrearagedetail2", "Type,CustomerName,Dept,RecType,OperationID,_Name,_Date,Amount,HaveAmount,NotChargeAmount,RemindDate,Remark", 0, 0, text, " ID desc ", out num).Tables[0];
		string[] tbTitle = new string[]
		{
			"帐款类别",
			"单位名称",
			"所属",
			"单据类别",
			"单据编号",
			"经办人",
			"日期",
			"总金额",
			"已结算金额",
			"未结算金额",
			"提醒日期",
			"备注"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "detail", out flag, out empty);
	}
}
