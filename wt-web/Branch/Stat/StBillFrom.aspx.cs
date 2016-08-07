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

public partial class Branch_Stat_StBillFrom : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "tj_r28"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
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
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("序", typeof(int)));
		dataTable.Columns.Add(new DataColumn("工单总数", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待确认", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待处理", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待网点确认", typeof(string)));
		dataTable.Columns.Add(new DataColumn("处理中", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待结算", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待回访", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待审核", typeof(string)));
		dataTable.Columns.Add(new DataColumn("已结束", typeof(string)));
		dataTable.Columns.Add(new DataColumn("已取消", typeof(string)));
		dataTable.Columns.Add(new DataColumn("送修", typeof(string)));
		for (int i = 0; i <= 1; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["工单总数"] = 0;
			dataRow["待确认"] = 0;
			dataRow["待处理"] = 0;
			dataRow["待网点确认"] = 0;
			dataRow["处理中"] = 0;
			dataRow["待结算"] = 0;
			dataRow["待回访"] = 0;
			dataRow["待审核"] = 0;
			dataRow["已结束"] = 0;
			dataRow["已取消"] = 0;
			dataRow["送修"] = 0;
			dataRow["序"] = i + 1;
			dataTable.Rows.Add(dataRow);
		}
		string text = this.strParm();
		this.hfSql.Value = text;
		DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[Time_TakeOver],[Time_Over],[Time_Payee],[Time_BackSee],[Time_Close],[curStatus]", text).Tables[0];
		string columnName = string.Empty;
		if (dataTable2.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				dataTable.Rows[0]["工单总数"] = int.Parse(dataTable.Rows[0]["工单总数"].ToString()) + 1;
				columnName = dataTable2.Rows[i]["curStatus"].ToString();
				dataTable.Rows[0][columnName] = int.Parse(dataTable.Rows[0][columnName].ToString()) + 1;
			}
		}
		dataTable.Rows[1]["工单总数"] = "比例(%)";
		float num = float.Parse(dataTable.Rows[0]["工单总数"].ToString());
		if (num != 0f)
		{
			if (dataTable.Rows[0]["待确认"].ToString() != "0")
			{
				dataTable.Rows[1]["待确认"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待确认"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待处理"].ToString() != "0")
			{
				dataTable.Rows[1]["待处理"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待处理"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待网点确认"].ToString() != "0")
			{
				dataTable.Rows[1]["待网点确认"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待网点确认"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["处理中"].ToString() != "0")
			{
				dataTable.Rows[1]["处理中"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["处理中"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待结算"].ToString() != "0")
			{
				dataTable.Rows[1]["待结算"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待结算"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待回访"].ToString() != "0")
			{
				dataTable.Rows[1]["待回访"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待回访"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待审核"].ToString() != "0")
			{
				dataTable.Rows[1]["待审核"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待审核"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["已结束"].ToString() != "0")
			{
				dataTable.Rows[1]["已结束"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["已结束"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["已取消"].ToString() != "0")
			{
				dataTable.Rows[1]["已取消"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["已取消"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["送修"].ToString() != "0")
			{
				dataTable.Rows[1]["送修"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["送修"].ToString()) / num).ToString("#00%");
			}
		}
		this.gvdata.DataSource = dataTable;
		this.gvdata.DataBind();
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
				string text2 = this.gvdata.HeaderRow.Cells[i].Text;
				if (this.hfTbTitle.Value == string.Empty)
				{
					this.hfTbTitle.Value = text2;
				}
				else
				{
					HiddenField expr_998 = this.hfTbTitle;
					expr_998.Value = expr_998.Value + "," + text2;
				}
				if (this.hfTbField.Value == string.Empty)
				{
					this.hfTbField.Value = dataField;
				}
				else
				{
					HiddenField expr_9E8 = this.hfTbField;
					expr_9E8.Value = expr_9E8.Value + "," + dataField;
				}
			}
		}
	}

	protected string strParm()
	{
		string str = " ID>0 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			str = str + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		if (this.tbDateB.Text.Trim() != string.Empty && this.tbDateE.Text.Trim() != string.Empty)
		{
			str = str + " and Time_TakeOver>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_TakeOver<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'";
		}
		return str + " order by ID Asc ";
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string selectedValue = this.ddlBranch.SelectedValue;
		string text3 = string.Concat(new string[]
		{
			text,
			",",
			text2,
			",",
			selectedValue
		});
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", text3);
			e.Row.Attributes.Add("onclick", "ChkID('" + text3 + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("序", typeof(int)));
		dataTable.Columns.Add(new DataColumn("工单总数", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待确认", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待处理", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待网点确认", typeof(string)));
		dataTable.Columns.Add(new DataColumn("处理中", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待结算", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待回访", typeof(string)));
		dataTable.Columns.Add(new DataColumn("待审核", typeof(string)));
		dataTable.Columns.Add(new DataColumn("已结束", typeof(string)));
		dataTable.Columns.Add(new DataColumn("已取消", typeof(string)));
		dataTable.Columns.Add(new DataColumn("送修", typeof(string)));
		for (int i = 0; i <= 1; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["工单总数"] = 0;
			dataRow["待确认"] = 0;
			dataRow["待处理"] = 0;
			dataRow["待网点确认"] = 0;
			dataRow["处理中"] = 0;
			dataRow["待结算"] = 0;
			dataRow["待回访"] = 0;
			dataRow["待审核"] = 0;
			dataRow["已结束"] = 0;
			dataRow["已取消"] = 0;
			dataRow["送修"] = 0;
			dataRow["序"] = i + 1;
			dataTable.Rows.Add(dataRow);
		}
		string text = this.strParm();
		this.hfSql.Value = text;
		DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[Time_TakeOver],[Time_Over],[Time_Payee],[Time_BackSee],[Time_Close],[curStatus]", text).Tables[0];
		string columnName = string.Empty;
		if (dataTable2.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				dataTable.Rows[0]["工单总数"] = int.Parse(dataTable.Rows[0]["工单总数"].ToString()) + 1;
				columnName = dataTable2.Rows[i]["curStatus"].ToString();
				dataTable.Rows[0][columnName] = int.Parse(dataTable.Rows[0][columnName].ToString()) + 1;
			}
		}
		dataTable.Rows[1]["工单总数"] = "比例(%)";
		float num = float.Parse(dataTable.Rows[0]["工单总数"].ToString());
		if (num != 0f)
		{
			if (dataTable.Rows[0]["待确认"].ToString() != "0")
			{
				dataTable.Rows[1]["待确认"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待确认"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待处理"].ToString() != "0")
			{
				dataTable.Rows[1]["待处理"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待处理"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待网点确认"].ToString() != "0")
			{
				dataTable.Rows[1]["待网点确认"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待网点确认"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["处理中"].ToString() != "0")
			{
				dataTable.Rows[1]["处理中"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["处理中"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待结算"].ToString() != "0")
			{
				dataTable.Rows[1]["待结算"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待结算"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待回访"].ToString() != "0")
			{
				dataTable.Rows[1]["待回访"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待回访"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["待审核"].ToString() != "0")
			{
				dataTable.Rows[1]["待审核"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["待审核"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["已结束"].ToString() != "0")
			{
				dataTable.Rows[1]["已结束"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["已结束"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["已取消"].ToString() != "0")
			{
				dataTable.Rows[1]["已取消"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["已取消"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["送修"].ToString() != "0")
			{
				dataTable.Rows[1]["送修"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["送修"].ToString()) / num).ToString("#00%");
			}
		}
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "BillFrom", out flag, out empty);
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
