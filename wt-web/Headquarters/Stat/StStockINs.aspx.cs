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
using wt.OtherLibrary;

public partial class Headquarters_Stat_StStockINs : Page, IRequiresSessionState
{
	private decimal dqty = 0m;

	private decimal dtotal = 0m;

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
				if (!dALRight.GetRight(num, "tj_r6"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
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
		this.gvdata.DataSource = DALCommon.GetStData("tj_ck_rk", 1, text, strOrderFld);
		this.gvdata.DataBind();
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
				string text2 = this.gvdata.HeaderRow.Cells[i].Text;
				this.gvdata.HeaderRow.Cells[i].Attributes.Add("id", dataField);
				this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					dataField,
					"','",
					text2,
					"');"
				}));
				this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
				if (this.hfTbTitle.Value == string.Empty)
				{
					this.hfTbTitle.Value = text2;
				}
				else
				{
					HiddenField expr_278 = this.hfTbTitle;
					expr_278.Value = expr_278.Value + "," + text2;
				}
				if (this.hfTbField.Value == string.Empty)
				{
					this.hfTbField.Value = dataField;
				}
				else
				{
					HiddenField expr_2C8 = this.hfTbField;
					expr_2C8.Value = expr_2C8.Value + "," + dataField;
				}
			}
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[2].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[2].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[3].Text, out this.dtest);
			this.dqty += this.dtest;
			decimal.TryParse(e.Row.Cells[4].Text, out this.dtest);
			this.dtotal += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计:";
			e.Row.Cells[3].Text = this.dqty.ToString("#0.00");
			e.Row.Cells[4].Text = this.dtotal.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DataTable dt = DALCommon.GetStData("tj_ck_rk", 1, this.hfSql.Value, this.hfOrderName.Value + " " + this.hfOrder.Value).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "入库汇总表", out flag, out empty);
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
