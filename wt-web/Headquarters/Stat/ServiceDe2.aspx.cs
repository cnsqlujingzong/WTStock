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

public partial class Headquarters_Stat_ServiceDe2 : Page, IRequiresSessionState
{
	private string strid;

	private string startdate;

	private string enddate;

	private string brandid;

	private string classid;

	private int deptid;

	private int iflag;

	private decimal drec1 = 0m;

	private decimal drec2 = 0m;

	private decimal drec3 = 0m;

	private decimal drec4 = 0m;

	private decimal drec5 = 0m;

	private decimal drec6 = 0m;

	private decimal drec7 = 0m;

	private decimal drec8 = 0m;

	private decimal drec9 = 0m;

	private decimal drec10 = 0m;

	private decimal drec11 = 0m;

	private decimal dtest = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.strid = base.Request["strid"];
		this.startdate = base.Request["startdate"];
		this.enddate = base.Request["enddate"];
		this.brandid = base.Request["brandid"];
		this.classid = base.Request["classid"];
		int.TryParse(base.Request["deptid"], out this.deptid);
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (this.strid == null || this.strid == string.Empty || this.deptid == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = 0;
			string strCondition = this.strParm();
			string fldSort = " ID desc ";
			this.gvdata.DataSource = DALCommon.GetList_HL(0, "fw_services", "", 0, 0, strCondition, fldSort, out num);
			this.gvdata.DataBind();
			if (this.gvdata.Rows.Count > 0)
			{
				this.lbTitle.Visible = true;
				this.lbCount.Text = this.gvdata.Rows.Count.ToString() + " ��";
			}
			else
			{
				this.lbTitle.Visible = false;
			}
			this.hfCount.Value = this.gvdata.Rows.Count.ToString();
		}
	}

	protected string strParm()
	{
		string text = " curStatus='�ѽ���' ";
		if (this.iflag == 1)
		{
			text = text + " and ProductBrandID=" + this.strid;
		}
		else if (this.iflag == 2)
		{
			text = text + " and ProductClassID=" + this.strid;
		}
		else
		{
			if (this.strid != "����")
			{
				text = text + " and Fault='" + this.strid + "'";
			}
			else
			{
				text += " and (Fault='' or Fault is null)";
			}
			if (this.brandid != "-1")
			{
				text = text + " and ProductBrandID=" + this.brandid;
			}
			if (this.classid != "-1")
			{
				text = text + " and ProductClassID=" + this.classid;
			}
		}
		if (this.deptid != -1)
		{
			text = text + " and DisposalID=" + this.deptid;
		}
		if (this.startdate != "")
		{
			text = text + " and convert(char(10),Time_TakeOver,120)>='" + this.startdate + "'";
		}
		if (this.enddate != "")
		{
			text = text + " and convert(char(10),Time_TakeOver,120)<='" + this.enddate + " 23:59:59'";
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ShowDetail();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[42].Text, out this.dtest);
			this.drec1 += this.dtest;
			decimal.TryParse(e.Row.Cells[43].Text, out this.dtest);
			this.drec2 += this.dtest;
			decimal.TryParse(e.Row.Cells[44].Text, out this.dtest);
			this.drec3 += this.dtest;
			decimal.TryParse(e.Row.Cells[45].Text, out this.dtest);
			this.drec4 += this.dtest;
			decimal.TryParse(e.Row.Cells[46].Text, out this.dtest);
			this.drec5 += this.dtest;
			decimal.TryParse(e.Row.Cells[47].Text, out this.dtest);
			this.drec6 += this.dtest;
			decimal.TryParse(e.Row.Cells[48].Text, out this.dtest);
			this.drec7 += this.dtest;
			decimal.TryParse(e.Row.Cells[49].Text, out this.dtest);
			this.drec8 += this.dtest;
			decimal.TryParse(e.Row.Cells[50].Text, out this.dtest);
			this.drec9 += this.dtest;
			decimal.TryParse(e.Row.Cells[51].Text, out this.dtest);
			this.drec10 += this.dtest;
			decimal.TryParse(e.Row.Cells[52].Text, out this.dtest);
			this.drec11 += this.dtest;
			if (e.Row.Cells[26].Text.Length > 16)
			{
				e.Row.Cells[26].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[26].Text,
					"\" onclick=\"ShowTA('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[26].Text.Substring(0, 16),
					"...</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "�ϼ�:";
			e.Row.Cells[42].Text = this.drec1.ToString("#0.00");
			e.Row.Cells[43].Text = this.drec2.ToString("#0.00");
			e.Row.Cells[44].Text = this.drec3.ToString("#0.00");
			e.Row.Cells[45].Text = this.drec4.ToString("#0.00");
			e.Row.Cells[46].Text = this.drec5.ToString("#0.00");
			e.Row.Cells[47].Text = this.drec6.ToString("#0.00");
			e.Row.Cells[48].Text = this.drec7.ToString("#0.00");
			e.Row.Cells[49].Text = this.drec8.ToString("#0.00");
			e.Row.Cells[50].Text = this.drec9.ToString("#0.00");
			e.Row.Cells[51].Text = this.drec10.ToString("#0.00");
			e.Row.Cells[52].Text = this.drec11.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strCondition = this.strParm();
		DataTable dt = DALCommon.GetDataList("fw_services", "ServicesType,TakeStyle,BillID,TakeDept,DisposalDept,Time_TakeOver,Operator,Speding,CustomerName,LinkMan,Tel,Adr,Area,DeviceNO,ProductBrand,ProductClass,ProductModel,ProductSN1,ProductSN2,Aspect,Accessory,_PRI,Warranty,Fault,DisposalOper,TakeSteps,QtyType,BuyDate,BuyFrom,BuyInvoice,dPoint,bRepair,SaveID,SubscribeTime,SubscribeConnectTime,RepairCorp,Time_Over,Time_Payee,PayeeOper,Time_Close,ChkOperator,Fee_Materail,MaterailCost,Fee_Labor,Fee_Add,RepairCost,ExtraCost,Fee_Total,PreMoney,RealMoney,HaveAmount,NotChargeAmount,Remark", strCondition).Tables[0];
		string text = "�������,����ʽ,���ݱ��,��������,��������,����ʱ��,������,����ʱ��,�ͻ�����,��ϵ��,��ϵ�绰,��ַ,�ͻ�����,�������,����Ʒ��,���,�ͺ�,���к�1,���к�2,���,�������,���񼶱�,�������,���ƹ���,����Ա,�����ʩ/���,������,����ʱ��,������,����Ʊ,����,�Ƿ���,�浵����,ԤԼʱ��,ԤԼȡ��,���޳���,�깤ʱ��,����ʱ��,������,���ʱ��,�����,���Ϸ�,���ϳɱ�,�˹���,���ӷ�,���޳ɱ�,����ɱ�,�ϼ�Ӧ��,�Żݽ��,ʵ���տ�,���տ�,δ�տ�,��ע";
		string[] tbTitle = text.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "Services", out flag, out empty);
	}
}
