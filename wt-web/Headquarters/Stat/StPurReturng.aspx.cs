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

public partial class Headquarters_Stat_StPurReturng : Page, IRequiresSessionState
{
	private decimal dqty = 0m;

	private decimal dtotal = 0m;

	private decimal dtotals = 0m;

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
				if (!dALRight.GetRight(num, "tj_r17"))
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
		string text = " 1=1 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and x.DeptID=" + this.ddlBranch.SelectedValue + "";
		}
		if (this.tbDateB.Text.Trim() != string.Empty)
		{
			text = text + " and x.ChkDate>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
		}
		if (this.tbDateE.Text.Trim() != string.Empty)
		{
			text = text + " and x.ChkDate<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'";
		}
		string strOrderFld = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetStData("tj_cg_th", 0, text, strOrderFld);
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtest);
			this.dqty += this.dtest;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dtotal += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dtotals += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "��";
			cells.Add(new TableHeaderCell());
			cells[1].ColumnSpan = 4;
			cells[1].Text = "��Ʒ";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 3;
			cells[2].Text = "�˻�</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[3].Text = "���";
			cells.Add(new TableHeaderCell());
			cells[4].Text = "����";
			cells.Add(new TableHeaderCell());
			cells[5].Text = "���";
			cells.Add(new TableHeaderCell());
			cells[6].Text = "��λ";
			cells.Add(new TableHeaderCell());
			cells[7].Text = "����";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "���";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "��˰�ϼ�</th></tr><tr>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "�ϼ�:";
			e.Row.Cells[5].Text = this.dqty.ToString("#0.00");
			e.Row.Cells[6].Text = this.dtotal.ToString("#0.00");
			e.Row.Cells[7].Text = this.dtotals.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DataTable dt = DALCommon.GetStData("tj_cg_th", 0, this.hfSql.Value, this.hfOrderName.Value + " " + this.hfOrder.Value).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "�˻����ܱ�", out flag, out empty);
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
