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

public partial class Headquarters_Stat_StSerWarrantyDe : Page, IRequiresSessionState
{
	private string contractid;

	private string startdate;

	private string enddate;

	private int deptid;

	private string classid;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.classid = base.Request["cid"].Trim();
		this.startdate = base.Request["startdate"].Trim();
		this.enddate = base.Request["enddate"].Trim();
		int.TryParse(base.Request["deptid"], out this.deptid);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r68"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.FillData();
		}
	}

	protected void FillData()
	{
		DALServices dALServices = new DALServices();
		string strDateS = string.Empty;
		string strDateE = string.Empty;
		if (this.startdate != string.Empty)
		{
			strDateS = DateTime.Parse(this.startdate).AddDays(-1.0).ToString("yyyy-MM-dd");
		}
		if (this.enddate != string.Empty)
		{
			strDateE = DateTime.Parse(this.enddate).AddDays(1.0).ToString("yyyy-MM-dd");
		}
		string text = string.Empty;
		if (this.classid != null && !this.classid.Equals(""))
		{
			text = text + " and pc.ID=" + this.classid;
		}
		else
		{
			text += " and pc.ID is null";
		}
		if (this.deptid > 0)
		{
			text = text + " and sl.DisposalID=" + this.deptid;
		}
		DataSet dataSet = dALServices.StSerCosts(21, text, strDateS, strDateE);
		this.gvdata.Columns.Clear();
		BoundField boundField = new BoundField();
		boundField.HeaderText = "序";
		this.gvdata.Columns.Add(boundField);
		BoundField boundField2 = new BoundField();
		boundField2.HeaderText = "服务单号";
		boundField2.DataField = "BillID";
		this.gvdata.Columns.Add(boundField2);
		BoundField boundField3 = new BoundField();
		boundField3.HeaderText = "返修";
		boundField3.DataField = "bRepair";
		this.gvdata.Columns.Add(boundField3);
		BoundField boundField4 = new BoundField();
		boundField4.HeaderText = "设备编号";
		boundField4.DataField = "DeviceNO";
		this.gvdata.Columns.Add(boundField4);
		BoundField boundField5 = new BoundField();
		boundField5.HeaderText = "序列号";
		boundField5.DataField = "ProductSN1";
		this.gvdata.Columns.Add(boundField5);
		BoundField boundField6 = new BoundField();
		boundField6.HeaderText = "备件成本";
		boundField6.DataField = "MaterialCost";
		boundField6.DataFormatString = "{0:f2}";
		this.gvdata.Columns.Add(boundField6);
		string text2 = "服务单号,设备编号,序列号,备件成本";
		string text3 = "BillID,DeviceNO,ProductSN1,MaterialCost";
		for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
		{
			string text4 = dataSet.Tables[0].Columns[i].Caption.Trim();
			if (!(text4 != "RelatedBusiness"))
			{
				break;
			}
			BoundField boundField7 = new BoundField();
			boundField7.HeaderText = text4.Substring(1);
			boundField7.DataField = text4;
			boundField7.DataFormatString = "{0:f2}";
			this.gvdata.Columns.Add(boundField7);
			text2 = text2 + "," + text4.Substring(1);
			text3 = text3 + "," + text4;
		}
		BoundField boundField8 = new BoundField();
		boundField8.HeaderText = "备件明细";
		boundField8.DataField = "MaterialDetail";
		this.gvdata.Columns.Add(boundField8);
		text2 += ",备件明细";
		text3 += ",MaterialDetail";
		this.hfTbField.Value = text3;
		this.hfTbTitle.Value = text2;
		this.lbCount.Text = "总记录：" + dataSet.Tables[0].Rows.Count.ToString();
		this.gvdata.DataSource = dataSet;
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			int count = e.Row.Cells.Count;
			string text = "";
			for (int i = 5; i < count; i++)
			{
				text = text + cells[i].Text.Trim() + ",";
			}
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "序";
			cells.Add(new TableHeaderCell());
			cells[1].RowSpan = 2;
			cells[1].Text = "服务单号";
			cells.Add(new TableHeaderCell());
			cells[2].RowSpan = 2;
			cells[2].Text = "返修";
			cells.Add(new TableHeaderCell());
			cells[3].RowSpan = 2;
			cells[3].Text = "设备编号";
			cells.Add(new TableHeaderCell());
			cells[4].RowSpan = 2;
			cells[4].Text = "序列号";
			cells.Add(new TableHeaderCell());
			cells[5].ColumnSpan = count - 6;
			cells[5].Text = "费用支出";
			cells.Add(new TableHeaderCell());
			cells[6].RowSpan = 2;
			cells[6].Text = "备件明细</th></tr><tr class=\"tdHead3\">";
			string[] array = text.Split(new char[]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length - 1; i++)
			{
				cells.Add(new TableHeaderCell());
				cells[i + 7].Text = array[i];
			}
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DALServices dALServices = new DALServices();
		string text = this.startdate;
		string text2 = this.enddate;
		if (text != string.Empty)
		{
			text = DateTime.Parse(text).AddDays(-1.0).ToString("yyyy-MM-dd");
		}
		if (text2 != string.Empty)
		{
			text2 = DateTime.Parse(text2).AddDays(1.0).ToString("yyyy-MM-dd");
		}
		string text3 = string.Empty;
		if (this.classid != null && !this.classid.Equals(""))
		{
			text3 = text3 + " and pc.ID=" + this.classid;
		}
		else
		{
			text3 += " and pc.ID is null";
		}
		if (this.deptid > 0)
		{
			text3 = text3 + " and sl.DisposalID=" + this.deptid;
		}
		DataTable dataTable = dALServices.StSerCosts(21, text3, text, text2).Tables[0];
		string[] array = this.hfTbField.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < array.Length; i++)
		{
			dataTable.Columns[array[i]].SetOrdinal(i);
		}
		while (dataTable.Columns.Count > array.Length)
		{
			dataTable.Columns.Remove(dataTable.Columns[array.Length]);
		}
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "保内维修成本明细", out flag, out empty);
		if (!flag)
		{
			this.FillData();
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this, base.GetType(), "SysInfo", str, true);
	}
}
