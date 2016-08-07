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

public partial class Headquarters_Stat_StTechnician : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "tj_r36"))
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
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("Technician", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Finish_Op", typeof(int)));
		dataTable.Columns.Add(new DataColumn("Cancel_Op", typeof(int)));
		dataTable.Columns.Add(new DataColumn("Tec_Score", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_CL", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_RG", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_FJ", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_CB", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_EW", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Charge_Cus", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Charge_Sup", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("ChargeValue", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Profit", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
		dataTable.Columns.Add(new DataColumn("DeptID", typeof(int)));
		string text = " bTechnician=1 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		DataTable dataTable2 = DALCommon.GetDataList("StaffList", "[DeptID],[_Name],JobNO", text).Tables[0];
		if (dataTable2.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["Technician"] = dataTable2.Rows[i]["_Name"].ToString();
				dataRow["Finish_Op"] = 0;
				dataRow["Cancel_Op"] = 0;
				dataRow["Tec_Score"] = 0;
				dataRow["Cost_CL"] = 0;
				dataRow["Cost_RG"] = 0;
				dataRow["Cost_FJ"] = 0;
				dataRow["Cost_CB"] = 0;
				dataRow["Cost_EW"] = 0;
				dataRow["Charge_Cus"] = 0;
				dataRow["Charge_Sup"] = 0;
				dataRow["ChargeValue"] = 0;
				dataRow["Profit"] = 0;
				dataRow["RecID"] = i + 1;
				dataRow["DeptID"] = int.Parse(dataTable2.Rows[i]["DeptID"].ToString());
				dataTable.Rows.Add(dataRow);
			}
		}
		string text2 = this.strParm();
		this.hfSql.Value = text2;
		DataTable dataTable3 = DALCommon.GetDataList("ServicesList", "[DisposalID],[DisposalOper],[curStatus],[Fee_Materail],[Fee_Labor],[Fee_Add],[MaterailCost],[ExtraCost],[ChargeValue],[WarrantyChargeValue],([ChargeValue]+[WarrantyChargeValue]) as ChargeTotal,[Profit],[dPoint]", text2).Tables[0];
		string empty = string.Empty;
		if (dataTable3.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable3.Rows.Count; i++)
			{
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					if (dataTable.Rows[j]["DeptID"].ToString().Trim().Equals(dataTable3.Rows[i]["DisposalID"].ToString().Trim()))
					{
						bool flag = false;
						string text3 = dataTable3.Rows[i]["DisposalOper"].ToString();
						string[] array = text3.Split(new char[]
						{
							','
						});
						for (int k = 0; k < array.Length; k++)
						{
							if (array[k].ToString() == dataTable.Rows[j]["Technician"].ToString())
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							if (dataTable3.Rows[i]["curStatus"].ToString() == "已结束")
							{
								dataTable.Rows[j]["Finish_Op"] = int.Parse(dataTable.Rows[j]["Finish_Op"].ToString()) + 1;
								dataTable.Rows[j]["Cost_CL"] = decimal.Parse(dataTable.Rows[j]["Cost_CL"].ToString()) + decimal.Parse(dataTable3.Rows[i]["Fee_Materail"].ToString());
								dataTable.Rows[j]["Cost_RG"] = decimal.Parse(dataTable.Rows[j]["Cost_RG"].ToString()) + decimal.Parse(dataTable3.Rows[i]["Fee_Labor"].ToString());
								dataTable.Rows[j]["Cost_FJ"] = decimal.Parse(dataTable.Rows[j]["Cost_FJ"].ToString()) + decimal.Parse(dataTable3.Rows[i]["Fee_Add"].ToString());
								dataTable.Rows[j]["Cost_CB"] = decimal.Parse(dataTable.Rows[j]["Cost_CB"].ToString()) + decimal.Parse(dataTable3.Rows[i]["MaterailCost"].ToString());
								dataTable.Rows[j]["Cost_EW"] = decimal.Parse(dataTable.Rows[j]["Cost_EW"].ToString()) + decimal.Parse(dataTable3.Rows[i]["ExtraCost"].ToString());
								dataTable.Rows[j]["Charge_Cus"] = decimal.Parse(dataTable.Rows[j]["Charge_Cus"].ToString()) + decimal.Parse(dataTable3.Rows[i]["ChargeValue"].ToString());
								dataTable.Rows[j]["Charge_Sup"] = decimal.Parse(dataTable.Rows[j]["Charge_Sup"].ToString()) + decimal.Parse(dataTable3.Rows[i]["WarrantyChargeValue"].ToString());
								dataTable.Rows[j]["ChargeValue"] = decimal.Parse(dataTable.Rows[j]["ChargeValue"].ToString()) + decimal.Parse(dataTable3.Rows[i]["ChargeTotal"].ToString());
								dataTable.Rows[j]["Profit"] = decimal.Parse(dataTable.Rows[j]["Profit"].ToString()) + decimal.Parse(dataTable3.Rows[i]["Profit"].ToString());
								if (dataTable3.Rows[i]["dPoint"].ToString() != "")
								{
									dataTable.Rows[j]["Tec_Score"] = decimal.Parse(dataTable.Rows[j]["Tec_Score"].ToString()) + decimal.Parse(dataTable3.Rows[i]["dPoint"].ToString());
								}
							}
							else
							{
								dataTable.Rows[j]["Cancel_Op"] = int.Parse(dataTable.Rows[j]["Cancel_Op"].ToString()) + 1;
							}
						}
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
				if (i > 0)
				{
					string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
					string text4 = this.gvdata.HeaderRow.Cells[i].Text;
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text4;
					}
					else
					{
						HiddenField expr_B4D = this.hfTbTitle;
						expr_B4D.Value = expr_B4D.Value + "," + text4;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_B9D = this.hfTbField;
						expr_B9D.Value = expr_B9D.Value + "," + dataField;
					}
				}
			}
		}
	}

	protected string strParm()
	{
		string str = " ID>0 and curStatus='已结束' ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			str = str + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		if (this.tbDateB.Text.Trim() != string.Empty && this.tbDateE.Text.Trim() != string.Empty)
		{
			str = str + " and Time_Payee>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_Payee<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'";
		}
		str += " or ( curStatus='已取消' ";
		if (this.tbDateB.Text.Trim() != string.Empty && this.tbDateE.Text.Trim() != string.Empty)
		{
			str = str + " and Time_Close>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_Close<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'";
		}
		str += " )";
		return str + " order by ID Asc ";
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("Technician", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Finish_Op", typeof(int)));
		dataTable.Columns.Add(new DataColumn("Cancel_Op", typeof(int)));
		dataTable.Columns.Add(new DataColumn("Tec_Score", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_CL", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_RG", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_FJ", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_CB", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Cost_EW", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Charge_Cus", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Charge_Sup", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("ChargeValue", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("Profit", typeof(decimal)));
		string text = " bTechnician=1 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		DataTable dataTable2 = DALCommon.GetDataList("StaffList", "[_Name],JobNO", text).Tables[0];
		if (dataTable2.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["Technician"] = dataTable2.Rows[i]["_Name"].ToString();
				dataRow["Finish_Op"] = 0;
				dataRow["Cancel_Op"] = 0;
				dataRow["Tec_Score"] = 0;
				dataRow["Cost_CL"] = 0;
				dataRow["Cost_RG"] = 0;
				dataRow["Cost_FJ"] = 0;
				dataRow["Cost_CB"] = 0;
				dataRow["Cost_EW"] = 0;
				dataRow["Charge_Cus"] = 0;
				dataRow["Charge_Sup"] = 0;
				dataRow["ChargeValue"] = 0;
				dataRow["Profit"] = 0;
				dataTable.Rows.Add(dataRow);
			}
		}
		string text2 = this.strParm();
		this.hfSql.Value = text2;
		DataTable dataTable3 = DALCommon.GetDataList("ServicesList", "[DisposalOper],[curStatus],[Fee_Materail],[Fee_Labor],[Fee_Add],[MaterailCost],[ExtraCost],[ChargeValue],[WarrantyChargeValue],([ChargeValue]+[WarrantyChargeValue]) as ChargeTotal,[Profit],[dPoint]", text2).Tables[0];
		string empty = string.Empty;
		if (dataTable3.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable3.Rows.Count; i++)
			{
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					bool flag = false;
					string text3 = dataTable3.Rows[i]["DisposalOper"].ToString();
					string[] array = text3.Split(new char[]
					{
						','
					});
					for (int k = 0; k < array.Length; k++)
					{
						if (array[k].ToString() == dataTable.Rows[j]["Technician"].ToString())
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						if (dataTable3.Rows[i]["curStatus"].ToString() == "已结束")
						{
							dataTable.Rows[j]["Finish_Op"] = int.Parse(dataTable.Rows[j]["Finish_Op"].ToString()) + 1;
							dataTable.Rows[j]["Cost_CL"] = decimal.Parse(dataTable.Rows[j]["Cost_CL"].ToString()) + decimal.Parse(dataTable3.Rows[i]["Fee_Materail"].ToString());
							dataTable.Rows[j]["Cost_RG"] = decimal.Parse(dataTable.Rows[j]["Cost_RG"].ToString()) + decimal.Parse(dataTable3.Rows[i]["Fee_Labor"].ToString());
							dataTable.Rows[j]["Cost_FJ"] = decimal.Parse(dataTable.Rows[j]["Cost_FJ"].ToString()) + decimal.Parse(dataTable3.Rows[i]["Fee_Add"].ToString());
							dataTable.Rows[j]["Cost_CB"] = decimal.Parse(dataTable.Rows[j]["Cost_CB"].ToString()) + decimal.Parse(dataTable3.Rows[i]["MaterailCost"].ToString());
							dataTable.Rows[j]["Cost_EW"] = decimal.Parse(dataTable.Rows[j]["Cost_EW"].ToString()) + decimal.Parse(dataTable3.Rows[i]["ExtraCost"].ToString());
							dataTable.Rows[j]["Charge_Cus"] = decimal.Parse(dataTable.Rows[j]["Charge_Cus"].ToString()) + decimal.Parse(dataTable3.Rows[i]["ChargeValue"].ToString());
							dataTable.Rows[j]["Charge_Sup"] = decimal.Parse(dataTable.Rows[j]["Charge_Sup"].ToString()) + decimal.Parse(dataTable3.Rows[i]["WarrantyChargeValue"].ToString());
							dataTable.Rows[j]["ChargeValue"] = decimal.Parse(dataTable.Rows[j]["ChargeValue"].ToString()) + decimal.Parse(dataTable3.Rows[i]["ChargeTotal"].ToString());
							dataTable.Rows[j]["Profit"] = decimal.Parse(dataTable.Rows[j]["Profit"].ToString()) + decimal.Parse(dataTable3.Rows[i]["Profit"].ToString());
							if (dataTable3.Rows[i]["dPoint"].ToString() != "")
							{
								dataTable.Rows[j]["Tec_Score"] = decimal.Parse(dataTable.Rows[j]["Tec_Score"].ToString()) + decimal.Parse(dataTable3.Rows[i]["dPoint"].ToString());
							}
						}
						else
						{
							dataTable.Rows[j]["Cancel_Op"] = int.Parse(dataTable.Rows[j]["Cancel_Op"].ToString()) + 1;
						}
					}
				}
			}
		}
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty2 = string.Empty;
		bool flag2 = false;
		DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "StTec", out flag2, out empty2);
		if (!flag2)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty2 + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
