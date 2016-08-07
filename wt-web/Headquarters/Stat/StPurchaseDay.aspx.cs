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

public partial class Headquarters_Stat_StPurchaseDay : Page, IRequiresSessionState
{
	private decimal dinqty = 0m;

	private decimal dintotal = 0m;

	private decimal doutqty = 0m;

	private decimal douttotal = 0m;

	private decimal dre1 = 0m;

	private decimal dre2 = 0m;

	private decimal dtest = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r13"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Insert(0, new ListItem("�ܲ�", "1"));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
		string s = FunLibrary.ChkInput(this.tbDateB.Text);
		string s2 = FunLibrary.ChkInput(this.tbDateE.Text);
		DateTime now = DateTime.Now;
		DateTime now2 = DateTime.Now;
		DateTime.TryParse(s, out now);
		DateTime.TryParse(s2, out now2);
		this.gvdata.DataSource = DALCommon.GetStDayData("tj_cg_rbb", int.Parse(this.ddlBranch.SelectedValue), now, now2);
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
			this.dinqty += this.dtest;
			decimal.TryParse(e.Row.Cells[3].Text, out this.dtest);
			this.dintotal += this.dtest;
			decimal.TryParse(e.Row.Cells[4].Text, out this.dtest);
			this.doutqty += this.dtest;
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtest);
			this.douttotal += this.dtest;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dre1 += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dre2 += this.dtest;
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
			cells[1].Text = "����";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 3;
			cells[2].Text = "�ɹ�";
			cells.Add(new TableHeaderCell());
			cells[3].ColumnSpan = 3;
			cells[3].Text = "�˻�</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[4].Text = "����";
			cells.Add(new TableHeaderCell());
			cells[5].Text = "���";
			cells.Add(new TableHeaderCell());
			cells[6].Text = "��˰�ϼ�";
			cells.Add(new TableHeaderCell());
			cells[7].Text = "����";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "���";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "��˰�ϼ�</th></tr><tr>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "�ϼ�:";
			e.Row.Cells[2].Text = this.dinqty.ToString("#0.00");
			e.Row.Cells[3].Text = this.dintotal.ToString("#0.00");
			e.Row.Cells[4].Text = this.doutqty.ToString("#0.00");
			e.Row.Cells[5].Text = this.douttotal.ToString("#0.00");
			e.Row.Cells[6].Text = this.dre1.ToString("#0.00");
			e.Row.Cells[7].Text = this.dre2.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string s = FunLibrary.ChkInput(this.tbDateB.Text);
		string s2 = FunLibrary.ChkInput(this.tbDateE.Text);
		DateTime now = DateTime.Now;
		DateTime now2 = DateTime.Now;
		DateTime.TryParse(s, out now);
		DateTime.TryParse(s2, out now2);
		DataTable dt = DALCommon.GetStDayData("tj_cg_rbb", int.Parse(this.ddlBranch.SelectedValue), now, now2).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "�ɹ��ձ���", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}