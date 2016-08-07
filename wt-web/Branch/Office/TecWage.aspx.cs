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

public partial class Branch_Office_TecWage : Page, IRequiresSessionState
{
	
	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dtest = 0m;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r27"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM");
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfOrder.Value != "ID")
		{
			this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
		}
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		string str = FunLibrary.ChkInput(this.tbDateE.Text);
		DateTime startDate = DateTime.Parse(str + "-01");
		DateTime endDate = DateTime.Parse(startDate.AddMonths(1).AddDays(-1.0).ToString("yyyy-MM-dd") + " 23:59:59");
		int iDept = 0;
		int.TryParse(this.ddlBranch.SelectedValue, out iDept);
		DataSet stDayData = DALCommon.GetStDayData("tec_xz", iDept, startDate, endDate);
		stDayData.Tables[0].Columns.Add("sTotal");
		stDayData.Tables[0].Columns["sTotal"].Expression = "pd+Total";
		this.gvdata.DataSource = stDayData;
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
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
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[4].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[5].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[6].Text = this.dr3.ToString("#0.00");
			e.Row.Cells[7].Text = this.dr4.ToString("#0.00");
			e.Row.Cells[8].Text = this.dr5.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbDateE.Text);
		DateTime startDate = DateTime.Parse(str + "-01");
		DateTime endDate = DateTime.Parse(startDate.AddMonths(1).AddDays(-1.0).ToString("yyyy-MM-dd") + " 23:59:59");
		int iDept = 0;
		int.TryParse(this.ddlBranch.SelectedValue, out iDept);
		DataTable dataTable = DALCommon.GetStDayData("tec_xz", iDept, startDate, endDate).Tables[0];
		dataTable.Columns.Add("sTotal");
		dataTable.Columns["sTotal"].Expression = "pd+Total";
		string[] array = this.hfTbField.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < array.Length; i++)
		{
			dataTable.Columns[array[i]].SetOrdinal(i);
		}
		DataTable dataTable2 = dataTable.DefaultView.ToTable();
		string[] array2 = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		while (dataTable2.Columns.Count > array2.Length)
		{
			dataTable2.Columns.Remove(dataTable2.Columns[array2.Length]);
		}
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dataTable2, array2, Guid.NewGuid().ToString() + ".xls", "员工月度薪资", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
