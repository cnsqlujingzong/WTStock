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

public partial class Headquarters_Stat_StServiceDe : Page, IRequiresSessionState
{
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

	private decimal drec12 = 0m;

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
				if (!dALRight.GetRight(num, "tj_r31"))
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
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		int num = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and curStatus='已结束'");
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(0, "fw_services", "", 0, 0, text, fldSort, out num);
		this.gvdata.DataBind();
		this.lbCount.Text = num.ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
		}
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				if (i > 0)
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
					if (dataField != "ID")
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_271 = this.hfTbTitle;
							expr_271.Value = expr_271.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_2C1 = this.hfTbField;
							expr_2C1.Value = expr_2C1.Value + "," + dataField;
						}
					}
				}
			}
		}
	}

	protected string strParm()
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string text3 = " curStatus='已结束' ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and convert(char(10),Time_TakeOver,120)>='" + text + "'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and convert(char(10),Time_TakeOver,120)<='" + text2 + " 23:59:59'";
		}
		string text4 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text4 != "")
				{
					DALServices dALServices = new DALServices();
					text3 += dALServices.GetSchWhere(schid, text4);
				}
			}
		}
		return text3;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[43].Text, out this.dtest);
			this.drec1 += this.dtest;
			decimal.TryParse(e.Row.Cells[44].Text, out this.dtest);
			this.drec2 += this.dtest;
			decimal.TryParse(e.Row.Cells[45].Text, out this.dtest);
			this.drec3 += this.dtest;
			decimal.TryParse(e.Row.Cells[46].Text, out this.dtest);
			this.drec4 += this.dtest;
			decimal.TryParse(e.Row.Cells[47].Text, out this.dtest);
			this.drec5 += this.dtest;
			decimal.TryParse(e.Row.Cells[48].Text, out this.dtest);
			this.drec6 += this.dtest;
			decimal.TryParse(e.Row.Cells[49].Text, out this.dtest);
			this.drec7 += this.dtest;
			decimal.TryParse(e.Row.Cells[50].Text, out this.dtest);
			this.drec8 += this.dtest;
			decimal.TryParse(e.Row.Cells[51].Text, out this.dtest);
			this.drec9 += this.dtest;
			decimal.TryParse(e.Row.Cells[52].Text, out this.dtest);
			this.drec10 += this.dtest;
			decimal.TryParse(e.Row.Cells[53].Text, out this.dtest);
			this.drec11 += this.dtest;
			decimal.TryParse(e.Row.Cells[54].Text, out this.dtest);
			this.drec12 += this.dtest;
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
			e.Row.Cells[0].Text = "合计:";
			e.Row.Cells[43].Text = this.drec1.ToString("#0.00");
			e.Row.Cells[44].Text = this.drec2.ToString("#0.00");
			e.Row.Cells[45].Text = this.drec3.ToString("#0.00");
			e.Row.Cells[46].Text = this.drec4.ToString("#0.00");
			e.Row.Cells[47].Text = this.drec5.ToString("#0.00");
			e.Row.Cells[48].Text = this.drec6.ToString("#0.00");
			e.Row.Cells[49].Text = this.drec7.ToString("#0.00");
			e.Row.Cells[50].Text = this.drec8.ToString("#0.00");
			e.Row.Cells[51].Text = this.drec9.ToString("#0.00");
			e.Row.Cells[52].Text = this.drec10.ToString("#0.00");
			e.Row.Cells[53].Text = this.drec11.ToString("#0.00");
			e.Row.Cells[54].Text = this.drec12.ToString("#0.00");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strCondition = string.Concat(new string[]
		{
			this.hfSql.Value,
			" order by ",
			this.hfOrderName.Value,
			" ",
			this.hfOrder.Value
		});
		DataTable dt = DALCommon.GetDataList("fw_services", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "Services", out flag, out empty);
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
