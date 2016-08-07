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

public partial class Headquarters_Office_TecDayWorkDe : Page, IRequiresSessionState
{
	private int id;

	private string startdate;

	private string enddate;

	private int deptid;

	private int iflag;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		this.startdate = base.Request["startdate"];
		this.enddate = base.Request["enddate"];
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DataSet stDayDataDe = DALCommon.GetStDayDataDe("tec_dayworkde", this.id, this.startdate, this.enddate);
			this.gvdata.DataSource = stDayDataDe.Tables[8];
			this.gvdata.DataBind();
			if (this.gvdata.Rows.Count > 0)
			{
				this.lbTitle.Visible = true;
				this.lbCount.Text = this.gvdata.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.lbTitle.Visible = false;
			}
			this.hfCount.Value = this.gvdata.Rows.Count.ToString();
			this.GridView1.DataSource = stDayDataDe.Tables[7];
			this.GridView1.DataBind();
			if (this.GridView1.Rows.Count > 0)
			{
				this.lbTitle2.Visible = true;
				this.lbCount2.Text = this.GridView1.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.lbTitle2.Visible = false;
			}
			this.GridView2.DataSource = stDayDataDe.Tables[6];
			this.GridView2.DataBind();
			if (this.GridView2.Rows.Count > 0)
			{
				this.Label1.Visible = true;
				this.Label2.Text = this.GridView2.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label1.Visible = false;
			}
			this.GridView3.DataSource = stDayDataDe.Tables[1];
			this.GridView3.DataBind();
			if (this.GridView3.Rows.Count > 0)
			{
				this.Label3.Visible = true;
				this.Label4.Text = this.GridView3.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label3.Visible = false;
			}
			this.GridView4.DataSource = stDayDataDe.Tables[0];
			this.GridView4.DataBind();
			if (this.GridView4.Rows.Count > 0)
			{
				this.Label5.Visible = true;
				this.Label6.Text = this.GridView4.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label5.Visible = false;
			}
			this.GridView5.DataSource = stDayDataDe.Tables[2];
			this.GridView5.DataBind();
			if (this.GridView5.Rows.Count > 0)
			{
				this.Label7.Visible = true;
				this.Label8.Text = this.GridView5.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label7.Visible = false;
			}
			this.GridView6.DataSource = stDayDataDe.Tables[3];
			this.GridView6.DataBind();
			if (this.GridView6.Rows.Count > 0)
			{
				this.Label9.Visible = true;
				this.Label10.Text = this.GridView6.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label9.Visible = false;
			}
			this.GridView7.DataSource = stDayDataDe.Tables[5];
			this.GridView7.DataBind();
			if (this.GridView7.Rows.Count > 0)
			{
				this.Label11.Visible = true;
				this.Label12.Text = this.GridView7.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label11.Visible = false;
			}
			this.GridView8.DataSource = stDayDataDe.Tables[4];
			this.GridView8.DataBind();
			if (this.GridView8.Rows.Count > 0)
			{
				this.Label13.Visible = true;
				this.Label14.Text = this.GridView8.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label13.Visible = false;
			}
			this.GridView9.DataSource = stDayDataDe.Tables[9];
			this.GridView9.DataBind();
			if (this.GridView8.Rows.Count > 0)
			{
				this.Label15.Visible = true;
				this.Label16.Text = this.GridView9.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label15.Visible = false;
			}
			this.GridView10.DataSource = stDayDataDe.Tables[10];
			this.GridView10.DataBind();
			if (this.GridView10.Rows.Count > 0)
			{
				this.Label17.Visible = true;
				this.Label18.Text = this.GridView10.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label17.Visible = false;
			}
			this.GridView11.DataSource = stDayDataDe.Tables[11];
			this.GridView11.DataBind();
			if (this.GridView11.Rows.Count > 0)
			{
				this.Label19.Visible = true;
				this.Label20.Text = this.GridView11.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label19.Visible = false;
			}
			this.GridView12.DataSource = stDayDataDe.Tables[12];
			this.GridView12.DataBind();
			if (this.GridView12.Rows.Count > 0)
			{
				this.Label21.Visible = true;
				this.Label22.Text = this.GridView12.Rows.Count.ToString() + " 条";
			}
			else
			{
				this.Label21.Visible = false;
			}
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "srv" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('srv",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(1);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.gvdata.Rows.Count > 0 && this.HiddenField1.Value == "")
		{
			for (int i = 2; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
				string text = this.gvdata.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField1;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "sell" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('sell",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(2);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView1.Rows.Count > 0 && this.HiddenField2.Value == "")
		{
			for (int i = 2; i < this.GridView1.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView1.Columns[i]).DataField;
				string text = this.GridView1.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField2;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "splan" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('splan",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(3);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView2.Rows.Count > 0 && this.HiddenField3.Value == "")
		{
			for (int i = 2; i < this.GridView2.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView2.Columns[i]).DataField;
				string text = this.GridView2.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField3;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "ck" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('ck",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(4);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView3.Rows.Count > 0 && this.HiddenField4.Value == "")
		{
			for (int i = 2; i < this.GridView3.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView3.Columns[i]).DataField;
				string text = this.GridView3.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField4;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "rk" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('rk",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(5);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView4.Rows.Count > 0 && this.HiddenField5.Value == "")
		{
			for (int i = 2; i < this.GridView4.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView4.Columns[i]).DataField;
				string text = this.GridView4.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField5;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "lt" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('lt",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(6);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView5.Rows.Count > 0 && this.HiddenField6.Value == "")
		{
			for (int i = 2; i < this.GridView5.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView5.Columns[i]).DataField;
				string text = this.GridView5.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField6;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "db" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('db",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(7);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView6.Rows.Count > 0 && this.HiddenField7.Value == "")
		{
			for (int i = 2; i < this.GridView6.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView6.Columns[i]).DataField;
				string text = this.GridView6.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField7;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "p" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('p",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(8);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView7.Rows.Count > 0 && this.HiddenField8.Value == "")
		{
			for (int i = 2; i < this.GridView7.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView7.Columns[i]).DataField;
				string text = this.GridView7.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField8;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView8_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "pp" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('pp",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(9);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView8.Rows.Count > 0 && this.HiddenField9.Value == "")
		{
			for (int i = 2; i < this.GridView8.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView8.Columns[i]).DataField;
				string text = this.GridView8.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField9;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView9_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "kh" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('kh",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(10);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView9.Rows.Count > 0 && this.HiddenField10.Value == "")
		{
			for (int i = 2; i < this.GridView9.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView9.Columns[i]).DataField;
				string text = this.GridView9.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField10;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView10_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "ht" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('ht",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(11);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView10.Rows.Count > 0 && this.HiddenField11.Value == "")
		{
			for (int i = 2; i < this.GridView10.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView10.Columns[i]).DataField;
				string text = this.GridView10.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField11;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView11_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "khgz" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('khgz",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ShowDetail(12);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView11.Rows.Count > 0 && this.HiddenField12.Value == "")
		{
			for (int i = 2; i < this.GridView11.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView11.Columns[i]).DataField;
				string text = this.GridView11.HeaderRow.Cells[i].Text;
				HiddenField expr_1C0 = this.HiddenField12;
				string value = expr_1C0.Value;
				expr_1C0.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void GridView12_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "hc" + e.Row.RowIndex.ToString());
			e.Row.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkID('hc",
				e.Row.RowIndex,
				"','",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (this.GridView12.Rows.Count > 0 && this.HiddenField13.Value == "")
		{
			for (int i = 2; i < this.GridView12.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView12.Columns[i]).DataField;
				string text = this.GridView12.HeaderRow.Cells[i].Text;
				HiddenField expr_1A5 = this.HiddenField13;
				string value = expr_1A5.Value;
				expr_1A5.Value = string.Concat(new string[]
				{
					value,
					text,
					"<",
					dataField,
					">|"
				});
			}
		}
	}

	protected void btnExout_Click(object sender, EventArgs e)
	{
		DataSet stDayDataDe = DALCommon.GetStDayDataDe("tec_dayworkde", this.id, this.startdate, this.enddate);
		string[] titles = new string[]
		{
			this.HiddenField1.Value,
			this.HiddenField2.Value,
			this.HiddenField3.Value,
			this.HiddenField4.Value,
			this.HiddenField5.Value,
			this.HiddenField6.Value,
			this.HiddenField7.Value,
			this.HiddenField8.Value,
			this.HiddenField9.Value,
			this.HiddenField10.Value,
			this.HiddenField11.Value,
			this.HiddenField12.Value,
			this.HiddenField13.Value
		};
		string empty = string.Empty;
		bool flag = false;
		string[] sheetNames = new string[]
		{
			"服务单|8",
			"销售单|7",
			"销售订单|6",
			"出库单|1",
			"入库单|0",
			"领退单|2",
			"调拨单|3",
			"采购单|5",
			"采购订单|4",
			"新建客户|9",
			"服务合同|10",
			"客户跟踪|11",
			"耗材跟踪|12"
		};
		DataToExcel.DataSetToExcel(stDayDataDe, titles, Guid.NewGuid().ToString() + ".xls", "Detail", sheetNames, out flag, out empty);
	}
}
