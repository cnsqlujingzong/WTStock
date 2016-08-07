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

public partial class Branch_Stat_StMonthSeller : Page, IRequiresSessionState
{
	
	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dr6 = 0m;

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
				if (!dALRight.GetRight(num, "tj_r2"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-") + "01";
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
		string strStart = FunLibrary.ChkInput(this.tbDateB.Text);
		string strEnd = FunLibrary.ChkInput(this.tbDateE.Text);
		int num = 0;
		int.TryParse(this.ddlBranch.SelectedValue, out num);
		string text = "";
		string text2 = "";
		if (num > 0)
		{
			text = text + " and DeptID=" + num;
			text2 = text2 + " and DisposalID=" + num;
		}
		this.gvdata.DataSource = DALCommon.GetStZhBB("tj_zh_myye", strStart, strEnd, text, text2);
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			decimal.TryParse(e.Row.Cells[2].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[3].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[4].Text, out this.dtest);
			this.dr3 += this.dtest;
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtest);
			this.dr4 += this.dtest;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dr5 += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dr6 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "��";
			cells.Add(new TableHeaderCell());
			cells[1].RowSpan = 2;
			cells[1].Text = "ҵ���¶�";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 2;
			cells[2].Text = "����";
			cells.Add(new TableHeaderCell());
			cells[3].ColumnSpan = 2;
			cells[3].Text = "����";
			cells.Add(new TableHeaderCell());
			cells[4].ColumnSpan = 2;
			cells[4].Text = "�ϼ�</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[5].Text = "���";
			cells.Add(new TableHeaderCell());
			cells[6].Text = "ë��";
			cells.Add(new TableHeaderCell());
			cells[7].Text = "���";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "ë��";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "���";
			cells.Add(new TableHeaderCell());
			cells[10].Text = "ë��</th></tr><tr>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "�ϼ�:";
			e.Row.Cells[2].Text = this.dr1.ToString("#0.00");
			e.Row.Cells[3].Text = this.dr2.ToString("#0.00");
			e.Row.Cells[4].Text = this.dr3.ToString("#0.00");
			e.Row.Cells[5].Text = this.dr4.ToString("#0.00");
			e.Row.Cells[6].Text = this.dr5.ToString("#0.00");
			e.Row.Cells[7].Text = this.dr6.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strStart = FunLibrary.ChkInput(this.tbDateB.Text);
		string strEnd = FunLibrary.ChkInput(this.tbDateE.Text);
		int num = 0;
		int.TryParse(this.ddlBranch.SelectedValue, out num);
		string text = "";
		string text2 = "";
		if (num > 0)
		{
			text = text + " and DeptID=" + num;
			text2 = text2 + " and DisposalID=" + num;
		}
		DataTable dt = DALCommon.GetStZhBB("tj_zh_myye", strStart, strEnd, text, text2).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "monseller", out flag, out empty);
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
