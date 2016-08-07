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
using Wuqi.Webdiyer;

public partial class Headquarters_Stat_StSerBroughtBack : Page, IRequiresSessionState
{

	private int pageSize = 25;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r65"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
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
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : this.hfParm.Value;
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "fw_ltmx", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvdata.DataBind();
		this.lbCount.Text = recordCount.ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
			this.lbCountText.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
			this.lbCountText.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " 1=1  ";
		if (this.hfSch.Value == "0")
		{
			if (this.ddlBranch.SelectedValue != "-1")
			{
				text = text + " and DeptID=" + this.ddlBranch.SelectedValue + "";
			}
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (this.ddlKey.SelectedValue == "StockName")
				{
					if (this.tbCon.Text.Trim() != "")
					{
						text += string.Format(" and (fInStock like '%{0}%' or fOutStock like '%{0}%' or wInStock like '%{0}%')", this.tbCon.Text.Trim());
					}
				}
				else if (this.ddlKey.SelectedValue == "SN")
				{
					if (this.tbCon.Text.Trim() != "")
					{
						text += string.Format(" and (fInSN like '%{0}%' or fOutSN like '%{0}%' or wInSN like '%{0}%')", this.tbCon.Text.Trim());
					}
				}
				else if (this.tbCon.Text.Trim() != "")
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"and ",
						this.ddlKey.SelectedValue,
						" like '%",
						FunLibrary.ChkInput(this.tbCon.Text),
						"%'"
					});
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			int count = cells.Count;
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "服务单号";
			cells.Add(new TableHeaderCell());
			cells[1].RowSpan = 2;
			cells[1].Text = "完成时间";
			cells.Add(new TableHeaderCell());
			cells[2].RowSpan = 2;
			cells[2].Text = "服务类别";
			cells.Add(new TableHeaderCell());
			cells[3].RowSpan = 2;
			cells[3].Text = "客户名称";
			cells.Add(new TableHeaderCell());
			cells[4].RowSpan = 2;
			cells[4].Text = "技术员";
			cells.Add(new TableHeaderCell());
			cells[5].ColumnSpan = 2;
			cells[5].Text = "产品";
			cells.Add(new TableHeaderCell());
			cells[6].ColumnSpan = 6;
			cells[6].Text = "良品仓库明细";
			cells.Add(new TableHeaderCell());
			cells[7].ColumnSpan = 3;
			cells[7].Text = "废品库明细</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[8].Text = "产品编号";
			cells.Add(new TableHeaderCell());
			cells[9].Text = "产品名称";
			cells.Add(new TableHeaderCell());
			cells[10].Text = "出库仓库";
			cells.Add(new TableHeaderCell());
			cells[11].Text = "出库数量";
			cells.Add(new TableHeaderCell());
			cells[12].Text = "出库序列号";
			cells.Add(new TableHeaderCell());
			cells[13].Text = "良品入库仓库";
			cells.Add(new TableHeaderCell());
			cells[14].Text = "良品入库数量";
			cells.Add(new TableHeaderCell());
			cells[15].Text = "良品入库序列号";
			cells.Add(new TableHeaderCell());
			cells[16].Text = "废品入库仓库";
			cells.Add(new TableHeaderCell());
			cells[17].Text = "废品入库数量";
			cells.Add(new TableHeaderCell());
			cells[18].Text = "废品入库序列号";
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
		DataTable dt = DALCommon.GetDataList("fw_ltmx", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "服务备件领退", out flag, out empty);
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
