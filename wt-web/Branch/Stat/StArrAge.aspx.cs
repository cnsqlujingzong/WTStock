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

public partial class Branch_Stat_StArrAge : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r42"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Clear();
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		int num = 0;
		if (this.ddlBranch.SelectedValue != "-1")
		{
			int.TryParse(this.ddlBranch.SelectedValue, out num);
		}
		string text2 = " 1=1 ";
		if (num > 0)
		{
			text2 = text2 + " and a.DeptID=" + num;
		}
		if (text == "")
		{
			text2 += string.Format(" and ad._Date<='{0}' ", DateTime.Today.ToString("yyyy-MM-dd"));
		}
		else
		{
			text2 += string.Format(" and ad._Date<='{0}' ", text);
		}
		string text3 = this.tbCusName.Text.Trim();
		if (!text3.Trim().Equals(""))
		{
			text2 += string.Format(" and ((cl._Name like '%{0}%' and a.Type=1) or (sl._Name like '%{0}%' and a.Type=2) or (bl._Name like '%{0}%' and a.Type=3) or (stfl._Name like '%{0}%' and a.Type=4))", text3);
		}
		DALArrearage dALArrearage = new DALArrearage();
		DataSet ageSum = dALArrearage.GetAgeSum(text2);
		this.Label1.Text = ageSum.Tables[0].Rows[0][1].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.Label2.Text = ageSum.Tables[0].Rows[0][0].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.gvdata.DataSource = dALArrearage.GetArrAge(num, text, this.tbCusName.Text.Trim());
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[1].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView(" + e.Row.Cells[1].Text + ");");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "序";
			cells.Add(new TableHeaderCell());
			cells[1].RowSpan = 2;
			cells[1].Text = "网点";
			cells.Add(new TableHeaderCell());
			cells[2].ColumnSpan = 3;
			cells[2].Text = "单位";
			cells.Add(new TableHeaderCell());
			cells[3].ColumnSpan = 2;
			cells[3].Text = "合计";
			cells.Add(new TableHeaderCell());
			cells[4].ColumnSpan = 2;
			cells[4].Text = "1至30天";
			cells.Add(new TableHeaderCell());
			cells[5].ColumnSpan = 2;
			cells[5].Text = "31至60天";
			cells.Add(new TableHeaderCell());
			cells[6].ColumnSpan = 2;
			cells[6].Text = "61至90天";
			cells.Add(new TableHeaderCell());
			cells[7].ColumnSpan = 2;
			cells[7].Text = "91至180天";
			cells.Add(new TableHeaderCell());
			cells[8].ColumnSpan = 2;
			cells[8].Text = "181至360天";
			cells.Add(new TableHeaderCell());
			cells[9].ColumnSpan = 2;
			cells[9].Text = "361至720天";
			cells.Add(new TableHeaderCell());
			cells[10].ColumnSpan = 2;
			cells[10].Text = "721至1095天";
			cells.Add(new TableHeaderCell());
			cells[11].ColumnSpan = 2;
			cells[11].Text = "1096天以上</th></tr><tr class=\"tdHead8\">";
			cells.Add(new TableHeaderCell());
			cells[12].Text = "客户类型";
			cells.Add(new TableHeaderCell());
			cells[13].Text = "客户编号";
			cells.Add(new TableHeaderCell());
			cells[14].Text = "客户名称";
			cells.Add(new TableHeaderCell());
			cells[15].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[16].Text = "应付款";
			cells.Add(new TableHeaderCell());
			cells[17].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[18].Text = "应付款";
			cells.Add(new TableHeaderCell());
			cells[19].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[20].Text = "应付款";
			cells.Add(new TableHeaderCell());
			cells[21].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[22].Text = "应付款";
			cells.Add(new TableHeaderCell());
			cells[23].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[24].Text = "应付款";
			cells.Add(new TableHeaderCell());
			cells[25].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[26].Text = "应付款";
			cells.Add(new TableHeaderCell());
			cells[27].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[28].Text = "应付款";
			cells.Add(new TableHeaderCell());
			cells[29].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[30].Text = "应付款";
			cells.Add(new TableHeaderCell());
			cells[31].Text = "应收款";
			cells.Add(new TableHeaderCell());
			cells[32].Text = "应付款";
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strStart = FunLibrary.ChkInput(this.tbDateB.Text);
		int deptID = 0;
		if (this.ddlBranch.SelectedValue != "-1")
		{
			int.TryParse(this.ddlBranch.SelectedValue, out deptID);
		}
		DALArrearage dALArrearage = new DALArrearage();
		DataTable dataTable = dALArrearage.GetArrAge(deptID, strStart, this.tbCusName.Text.Trim()).Tables[0];
		string[] array = this.hfTbField.Value.Split(new char[]
		{
			','
		});
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			dataTable.Columns[array[i]].SetOrdinal(i);
		}
		while (dataTable.Columns.Count != num)
		{
			dataTable.Columns.Remove(dataTable.Columns[num]);
		}
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "应收应付账龄", out flag, out empty);
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
