using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Stat_StockDe : Page, IRequiresSessionState
{
	private string billdate;

	private string startdate;

	private string enddate;

	private int deptid;

	private int iflag;

	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

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
					text = text + " and convert(char(10),chkdate,120)='" + this.billdate + "'";
				}
			}
			else if (this.iflag == 1)
			{
				if (this.billdate != "")
				{
					text = text + " and GoodsNO='" + this.billdate + "'";
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
			else if (this.iflag == 2)
			{
				if (this.billdate != "")
				{
					text = text + " and GoodsNO='" + this.billdate + "'";
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
				if (this.billdate != "")
				{
					text = text + " and StockName='" + this.billdate + "'";
				}
				if (this.startdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
				}
				this.iflag = 2;
			}
			else if (this.iflag == 4)
			{
				if (this.billdate != "")
				{
					text = text + " and GoodsNO='" + this.billdate + "'";
				}
				if (this.startdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
				}
				this.iflag = 3;
			}
			else if (this.iflag == 5)
			{
				if (this.billdate != "")
				{
					text = text + " and StockName='" + this.billdate + "'";
				}
				if (this.startdate != "")
				{
					text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
				}
				if (this.enddate != "")
				{
					text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
				}
				this.iflag = 3;
			}
			if (this.deptid > 0)
			{
				text = text + " and DeptID=" + this.deptid;
			}
			DataSet stZhDetail = DALCommon.GetStZhDetail("tj_mx", this.iflag, text, strCondition);
			if (stZhDetail.Tables[0].Rows.Count > 0)
			{
				if (stZhDetail.Tables[0].Columns.IndexOf("customername") < 0)
				{
					for (int i = 0; i < this.gvdata.Columns.Count; i++)
					{
						if (this.gvdata.Columns[i].HeaderText == "客户名称")
						{
							this.gvdata.Columns.RemoveAt(i);
						}
					}
				}
			}
			this.gvdata.DataSource = stZhDetail;
			this.gvdata.DataBind();
			if (this.gvdata.Rows.Count > 0)
			{
				this.lbTitle.Visible = true;
				this.lbCount.Text = this.gvdata.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.lbTitle.Visible = false;
				this.lbCount.Text = "该时间段无出入库记录";
				this.lbCount.ForeColor = Color.Red;
			}
			this.hfCount.Value = this.gvdata.Rows.Count.ToString();
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[2].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[2].Text,
				"','",
				e.Row.Cells[0].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[9].Text != "")
			{
				if (e.Row.Cells[1].Text == "采购入库")
				{
					e.Row.Cells[9].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Purchase('",
						e.Row.Cells[9].Text,
						"','采购单')\">",
						e.Row.Cells[9].Text,
						"</a>"
					});
				}
				else if (e.Row.Cells[1].Text == "员工退料")
				{
					e.Row.Cells[9].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"BroughtBack('",
						e.Row.Cells[9].Text,
						"','退料单')\">",
						e.Row.Cells[9].Text,
						"</a>"
					});
				}
				else if (e.Row.Cells[1].Text == "销售退货")
				{
					e.Row.Cells[9].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Sell('",
						e.Row.Cells[9].Text,
						"','销售退货单')\">",
						e.Row.Cells[9].Text,
						"</a>"
					});
				}
				else if (e.Row.Cells[1].Text == "租赁退还" || e.Row.Cells[1].Text == "设备更换" || e.Row.Cells[1].Text == "租赁退机")
				{
					e.Row.Cells[9].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Lease('",
						e.Row.Cells[9].Text,
						"')\">",
						e.Row.Cells[9].Text,
						"</a>"
					});
				}
				else if (e.Row.Cells[1].Text == "员工领料")
				{
					e.Row.Cells[9].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"BroughtBack('",
						e.Row.Cells[9].Text,
						"','领料单')\">",
						e.Row.Cells[9].Text,
						"</a>"
					});
				}
				else if (e.Row.Cells[1].Text == "销售出库")
				{
					e.Row.Cells[9].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Sell('",
						e.Row.Cells[9].Text,
						"','销售单')\">",
						e.Row.Cells[9].Text,
						"</a>"
					});
				}
				else if (e.Row.Cells[1].Text == "采购退货")
				{
					e.Row.Cells[9].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Purchase('",
						e.Row.Cells[9].Text,
						"','采购退货单')\">",
						e.Row.Cells[9].Text,
						"</a>"
					});
				}
				else if (e.Row.Cells[1].Text == "租赁" || e.Row.Cells[1].Text == "租赁增机")
				{
					e.Row.Cells[9].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Lease('",
						e.Row.Cells[9].Text,
						"')\">",
						e.Row.Cells[9].Text,
						"</a>"
					});
				}
			}
			decimal.TryParse(e.Row.Cells[16].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[17].Text, out this.dtest);
			this.dr2 += this.dtest;
			string[] array = e.Row.Cells[18].Text.Split(new char[]
			{
				','
			});
			if (array.Length > 1)
			{
				e.Row.Cells[18].Text = "<a href=\"#\" style=\"color:#0000ff;\" onclick=\"ViewSN('" + e.Row.Cells[18].Text + "');\">查看序列号</a>";
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[16].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[17].Text = this.dr2.ToString("#0.00");
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
				text = text + " and convert(char(10),chkdate,120)='" + this.billdate + "'";
			}
		}
		else if (this.iflag == 1)
		{
			if (this.billdate != "")
			{
				text = text + " and GoodsNO='" + this.billdate + "'";
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
		else if (this.iflag == 2)
		{
			if (this.billdate != "")
			{
				text = text + " and GoodsNO='" + this.billdate + "'";
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
			if (this.billdate != "")
			{
				text = text + " and StockName='" + this.billdate + "'";
			}
			if (this.startdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
			}
			this.iflag = 2;
		}
		else if (this.iflag == 4)
		{
			if (this.billdate != "")
			{
				text = text + " and GoodsNO='" + this.billdate + "'";
			}
			if (this.startdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
			}
			this.iflag = 3;
		}
		else if (this.iflag == 5)
		{
			if (this.billdate != "")
			{
				text = text + " and StockName='" + this.billdate + "'";
			}
			if (this.startdate != "")
			{
				text = text + " and convert(char(10),chkdate,120)>='" + this.startdate + "'";
			}
			if (this.enddate != "")
			{
				text = text + " and convert(char(10),chkdate,120)<='" + this.enddate + " 23:59:59'";
			}
			this.iflag = 3;
		}
		if (this.deptid > 0)
		{
			text = text + " and DeptID=" + this.deptid;
		}
		string text2 = "单据属性,业务类型,单据编号,所属,日期,制单人,业务员,审核日期,审核人,关联业务,仓库,编号,名称,规格,品牌,单位,数量,金额,序列号";
		DataTable dataTable = DALCommon.GetStZhDetail("tj_mx", this.iflag, text, strCondition).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			if (dataTable.Columns.IndexOf("customername") >= 0)
			{
				text2 = "单据属性,业务类型,单据编号,所属,日期,制单人,业务员,客户名称,审核日期,审核人,关联业务,仓库,编号,名称,规格,品牌,单位,数量,金额,序列号";
			}
		}
		string[] tbTitle = text2.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "detail", out flag, out empty);
	}
}
