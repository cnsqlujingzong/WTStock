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

public partial class Branch_Stat_StBillView : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "tj_r27"))
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
		dataTable.Columns.Add(new DataColumn("日期", typeof(DateTime)));
		dataTable.Columns.Add(new DataColumn("受理", typeof(int)));
		dataTable.Columns.Add(new DataColumn("处理", typeof(int)));
		dataTable.Columns.Add(new DataColumn("结算", typeof(int)));
		dataTable.Columns.Add(new DataColumn("回访", typeof(int)));
		dataTable.Columns.Add(new DataColumn("审核", typeof(int)));
		dataTable.Columns.Add(new DataColumn("完工率", typeof(float)));
		DateTime dateTime = DateTime.Parse(this.tbDateB.Text);
		DateTime dateTime2 = DateTime.Parse(this.tbDateE.Text + " 23:59:59");
		int days = (dateTime2 - dateTime).Days;
		if (days >= 800)
		{
			this.SysInfo("alert('数据量太大，时间间隔不能超过800天');");
			this.lbCount.Visible = false;
		}
		else
		{
			for (int i = 0; i <= days; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["序"] = i + 1;
				dataRow["日期"] = dateTime.AddDays((double)i);
				dataRow["受理"] = 0;
				dataRow["处理"] = 0;
				dataRow["结算"] = 0;
				dataRow["回访"] = 0;
				dataRow["审核"] = 0;
				dataRow["完工率"] = 0;
				dataTable.Rows.Add(dataRow);
			}
			string text = this.strParm();
			this.hfSql.Value = text;
			DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[Time_TakeOver],[Time_Over],[Time_Payee],[Time_BackSee],[Time_Close],[curStatus]", text).Tables[0];
			string empty = string.Empty;
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					if (dataTable2.Rows[i]["Time_Close"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_Close"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["审核"] = int.Parse(dataTable.Rows[timeSpan.Days]["审核"].ToString()) + 1;
						}
					}
					if (dataTable2.Rows[i]["Time_BackSee"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_BackSee"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["回访"] = int.Parse(dataTable.Rows[timeSpan.Days]["回访"].ToString()) + 1;
						}
					}
					if (dataTable2.Rows[i]["Time_Payee"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_Payee"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["结算"] = int.Parse(dataTable.Rows[timeSpan.Days]["结算"].ToString()) + 1;
						}
					}
					if (dataTable2.Rows[i]["Time_Over"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_Over"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["处理"] = int.Parse(dataTable.Rows[timeSpan.Days]["处理"].ToString()) + 1;
						}
					}
					if (dataTable2.Rows[i]["Time_TakeOver"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_TakeOver"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["受理"] = int.Parse(dataTable.Rows[timeSpan.Days]["受理"].ToString()) + 1;
						}
					}
				}
			}
			this.gvdata.DataSource = dataTable;
			this.gvdata.DataBind();
			this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
			if (this.gvdata.Rows.Count > 0)
			{
				for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
				{
					if (i != 7)
					{
						string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
						string text2 = this.gvdata.HeaderRow.Cells[i].Text;
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_7E9 = this.hfTbTitle;
							expr_7E9.Value = expr_7E9.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_83B = this.hfTbField;
							expr_83B.Value = expr_83B.Value + "," + dataField;
						}
					}
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
			str = str + " and ((Time_TakeOver>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_TakeOver<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59') or";
			str = str + " (Time_Over>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_Over<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59') or";
			str = str + " (Time_Payee>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_Payee<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59') or";
			str = str + " (Time_BackSee>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_BackSee<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59') or";
			str = str + " (Time_Close>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_Close<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'))";
		}
		return str + " order by Time_TakeOver Asc ";
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			if (e.Row.Cells[6].Text != "0" && e.Row.Cells[2].Text != "0")
			{
				e.Row.Cells[7].Text = Convert.ToDouble(float.Parse(e.Row.Cells[6].Text) / float.Parse(e.Row.Cells[2].Text)).ToString("#00%");
			}
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("序", typeof(int)));
		dataTable.Columns.Add(new DataColumn("日期", typeof(DateTime)));
		dataTable.Columns.Add(new DataColumn("受理", typeof(int)));
		dataTable.Columns.Add(new DataColumn("处理", typeof(int)));
		dataTable.Columns.Add(new DataColumn("结算", typeof(int)));
		dataTable.Columns.Add(new DataColumn("回访", typeof(int)));
		dataTable.Columns.Add(new DataColumn("审核", typeof(int)));
		DateTime dateTime = DateTime.Parse(this.tbDateB.Text);
		DateTime dateTime2 = DateTime.Parse(this.tbDateE.Text + " 23:59:59");
		int days = (dateTime2 - dateTime).Days;
		if (days >= 800)
		{
			this.SysInfo("alert('数据量太大，时间间隔不能超过800天');");
			this.lbCount.Visible = false;
		}
		else
		{
			for (int i = 0; i <= days; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["序"] = i + 1;
				dataRow["日期"] = dateTime.AddDays((double)i);
				dataRow["受理"] = 0;
				dataRow["处理"] = 0;
				dataRow["结算"] = 0;
				dataRow["回访"] = 0;
				dataRow["审核"] = 0;
				dataTable.Rows.Add(dataRow);
			}
			string strCondition = this.strParm();
			DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[Time_TakeOver],[Time_Over],[Time_Payee],[Time_BackSee],[Time_Close],[curStatus]", strCondition).Tables[0];
			string empty = string.Empty;
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					if (dataTable2.Rows[i]["Time_Close"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_Close"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["审核"] = int.Parse(dataTable.Rows[timeSpan.Days]["审核"].ToString()) + 1;
						}
					}
					if (dataTable2.Rows[i]["Time_BackSee"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_BackSee"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["回访"] = int.Parse(dataTable.Rows[timeSpan.Days]["回访"].ToString()) + 1;
						}
					}
					if (dataTable2.Rows[i]["Time_Payee"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_Payee"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["结算"] = int.Parse(dataTable.Rows[timeSpan.Days]["结算"].ToString()) + 1;
						}
					}
					if (dataTable2.Rows[i]["Time_Over"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_Over"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["处理"] = int.Parse(dataTable.Rows[timeSpan.Days]["处理"].ToString()) + 1;
						}
					}
					if (dataTable2.Rows[i]["Time_TakeOver"].ToString() != "")
					{
						DateTime dateTime3 = DateTime.Parse(dataTable2.Rows[i]["Time_TakeOver"].ToString());
						if (dateTime3 >= dateTime && dateTime3 <= dateTime2)
						{
							TimeSpan timeSpan = dateTime3 - dateTime;
							dataTable.Rows[timeSpan.Days]["受理"] = int.Parse(dataTable.Rows[timeSpan.Days]["受理"].ToString()) + 1;
						}
					}
				}
			}
			string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
			{
				','
			});
			string empty2 = string.Empty;
			bool flag = false;
			DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "BillView", out flag, out empty2);
			if (!flag)
			{
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				this.SysInfo("window.alert('" + empty2 + "');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
