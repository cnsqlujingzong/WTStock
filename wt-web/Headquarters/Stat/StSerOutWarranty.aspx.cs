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

public partial class Headquarters_Stat_StSerOutWarranty : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r69"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.FillData();
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.FillData();
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
		this.FillData();
	}

	protected void FillData()
	{
		DALServices dALServices = new DALServices();
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		if (text != string.Empty)
		{
			text = DateTime.Parse(text).AddDays(-1.0).ToString("yyyy-MM-dd");
		}
		if (text2 != string.Empty)
		{
			text2 = DateTime.Parse(text2).AddDays(1.0).ToString("yyyy-MM-dd");
		}
		string text3 = string.Empty;
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and sl.DisposalID=" + this.ddlBranch.SelectedValue;
		}
		DataSet dataSet = dALServices.StSerCosts(3, text3, text, text2);
		this.gvdata.Columns.Clear();
		BoundField boundField = new BoundField();
		boundField.HeaderText = "ID";
		boundField.DataField = "ClassID";
		this.gvdata.Columns.Add(boundField);
		BoundField boundField2 = new BoundField();
		boundField2.HeaderText = "序";
		this.gvdata.Columns.Add(boundField2);
		BoundField boundField3 = new BoundField();
		boundField3.HeaderText = "机器类别";
		boundField3.DataField = "ClassName";
		this.gvdata.Columns.Add(boundField3);
		BoundField boundField4 = new BoundField();
		boundField4.HeaderText = "维修台数";
		boundField4.DataField = "fwcount";
		this.gvdata.Columns.Add(boundField4);
		BoundField boundField5 = new BoundField();
		boundField5.HeaderText = "备件成本";
		boundField5.DataField = "MaterialCost";
		boundField5.DataFormatString = "{0:f2}";
		this.gvdata.Columns.Add(boundField5);
		string text4 = "机器类别,维修台数,备件成本";
		string text5 = "ClassName,fwcount,MaterialCost";
		for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
		{
			string text6 = dataSet.Tables[0].Columns[i].Caption.Trim();
			if (!(text6 != "MaterialCost"))
			{
				break;
			}
			BoundField boundField6 = new BoundField();
			boundField6.HeaderText = text6.Substring(1);
			boundField6.DataField = text6;
			boundField6.DataFormatString = "{0:f2}";
			this.gvdata.Columns.Add(boundField6);
			text4 = text4 + "," + text6.Substring(1);
			text5 = text5 + "," + text6;
		}
		this.hfTbField.Value = text5;
		this.hfTbTitle.Value = text4;
		this.gvdata.DataSource = dataSet;
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[1].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView('" + e.Row.Cells[0].Text + "');");
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			int count = e.Row.Cells.Count;
			string text = "";
			for (int i = 4; i < count; i++)
			{
				text = text + cells[i].Text.Trim() + ",";
			}
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "序";
			cells.Add(new TableHeaderCell());
			cells[1].RowSpan = 2;
			cells[1].Text = "机器类别";
			cells.Add(new TableHeaderCell());
			cells[2].RowSpan = 2;
			cells[2].Text = "维修台数";
			cells.Add(new TableHeaderCell());
			cells[3].ColumnSpan = count - 2;
			cells[3].Text = "费用支出</th></tr><tr class=\"tdHead8\">";
			string[] array = text.Split(new char[]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				cells.Add(new TableHeaderCell());
				cells[i + 4].Text = array[i];
			}
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DALServices dALServices = new DALServices();
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		if (text != string.Empty)
		{
			text = DateTime.Parse(text).AddDays(-1.0).ToString("yyyy-MM-dd");
		}
		if (text2 != string.Empty)
		{
			text2 = DateTime.Parse(text2).AddDays(1.0).ToString("yyyy-MM-dd");
		}
		string text3 = string.Empty;
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and sl.DisposalID=" + this.ddlBranch.SelectedValue;
		}
		DataTable dataTable = dALServices.StSerCosts(3, text3, text, text2).Tables[0];
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
		DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "维保期内机器维修成本", out flag, out empty);
		if (!flag)
		{
			this.FillData();
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
