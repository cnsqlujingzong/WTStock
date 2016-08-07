using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Branch_Stock_BroughtM : Page, IRequiresSessionState
{

	private int id;

	

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("StockName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("LQty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PeriodEndDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StockID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r23"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r25"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r30"))
				{
					this.btnPrint.Visible = false;
				}
				if (dALRight.GetRight(num, "jc_r18"))
				{
					this.hfvalue.Value = "1";
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(12, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bStop=0 and bReject=0 ");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbAQty.Text = "0.00";
			this.tbAmount.Text = "0.00";
			this.AddEmpty();
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable = DALCommon.GetDataList("ck_servicesmaterial", "", " OutSourcing=0 and OperationID=" + this.id.ToString()).Tables[0];
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
				dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
				dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
				dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
				dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
				dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
				dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString()) - decimal.Parse(dataTable.Rows[i]["LQty"].ToString());
				dataRow[7] = decimal.Parse(dataTable.Rows[i]["LQty"].ToString());
				dataRow[8] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
				dataRow[9] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()) * decimal.Parse(dataRow[6].ToString());
				dataRow[10] = dataTable.Rows[i]["SN"].ToString();
				dataRow[11] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
				dataRow[12] = dataTable.Rows[i]["PeriodEndDate"].ToString();
				dataRow[13] = dataTable.Rows[i]["BillID"].ToString();
				dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
				dataRow[15] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
				dataRow[16] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
				dataRow[17] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
				dataRow[18] = int.Parse(dataTable.Rows[i]["ID"].ToString());
				this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataRow[6].ToString())).ToString("#0.00");
				this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataRow[9].ToString())).ToString("#0.00");
				gridViewSource.Rows.Add(dataRow);
			}
			this.GridViewSource = gridViewSource;
			this.BindData();
			this.lbMod.Text = "若手工输入编号或单号，输入完成后回车";
			this.lbMod.Attributes.Add("class", "si1");
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = "";
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		dataRow[9] = 0;
		dataRow[10] = "";
		dataRow[11] = "";
		dataRow[12] = "";
		dataRow[13] = "";
		dataRow[14] = "";
		dataRow[15] = 0;
		dataRow[16] = 0;
		dataRow[17] = 0;
		dataRow[18] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbPrice") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			LinkButton linkButton = e.Row.FindControl("lbDel") as LinkButton;
			TextBox textBox3 = e.Row.FindControl("tbSN") as TextBox;
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox2.Attributes.Add("oldNum", textBox2.Text);
			label.Attributes.Add("oldNum", label.Text);
			linkButton.Attributes.Add("num", e.Row.RowIndex.ToString());
			linkButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkAmount(this,'",
				label.ClientID,
				"','",
				textBox.ClientID,
				"');"
			}));
			textBox.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateNum(this,'",
				textBox2.ClientID,
				"','",
				label.ClientID,
				"');"
			}));
			textBox2.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateMoney(this,'",
				textBox.ClientID,
				"','",
				label.ClientID,
				"');"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[9].Text = string.Concat(new string[]
			{
				"<a href=\"#\" onclick=\"EditSN('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"','",
				textBox3.ClientID,
				"','",
				textBox.ClientID,
				"');\">编辑序列号</a>"
			});
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		string text2 = "$('" + this.tbCon.ClientID + "').select();";
		DataSet dataList = DALCommon.GetDataList("ServicesList", "BillID", "ID=" + this.id);
		string value = "";
		if (dataList.Tables[0].Rows.Count > 0)
		{
			value = dataList.Tables[0].Rows[0][0].ToString().Trim();
		}
		if (this.hfType.Value == "2")
		{
			DataTable dataTable = DALCommon.GetDataList("ck_goods", "", " GoodsNO='" + text + "'").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							string text3 = gridViewSource.Rows[i]["Qty"].ToString();
							decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
							gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
							decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
						dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[6] = 1;
						dataRow[7] = 1;
						dataRow[8] = 0;
						dataRow[9] = 0;
						dataRow[10] = dataTable.Rows[i]["SN"].ToString();
						dataRow[11] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[12] = "";
						dataRow[13] = value;
						dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
						dataRow[15] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
						dataRow[16] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[17] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
						dataRow[18] = 0;
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text)).ToString("#0.00");
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		else
		{
			DataTable dataTable = DALCommon.GetDataList("ck_servicesmaterial", "", string.Concat(new string[]
			{
				" DisposalID=1 and (curStatus='待处理' or curStatus='处理中') and ",
				this.ddlSchFld.SelectedValue,
				"='",
				text,
				"'"
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 0; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["ID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
							gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
							decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
						dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString());
						dataRow[7] = decimal.Parse(dataTable.Rows[i]["LQty"].ToString());
						dataRow[8] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
						dataRow[9] = decimal.Parse(dataTable.Rows[i]["Total"].ToString());
						dataRow[10] = dataTable.Rows[i]["SN"].ToString();
						dataRow[11] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[12] = dataTable.Rows[i]["PeriodEndDate"].ToString();
						dataRow[13] = dataTable.Rows[i]["BillID"].ToString();
						dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
						dataRow[15] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
						dataRow[16] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
						dataRow[17] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
						dataRow[18] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Price"].ToString()) * decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
			else
			{
				text2 += "window.alert('操作失败！没有该产品信息');";
			}
		}
		this.SysInfo(text2);
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfreclist.Value.EndsWith(","))
		{
			text = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfreclist.Value;
		}
		DataSet dataList = DALCommon.GetDataList("ServicesList", "BillID", "ID=" + this.id);
		string value = "";
		if (dataList.Tables[0].Rows.Count > 0)
		{
			value = dataList.Tables[0].Rows[0][0].ToString().Trim();
		}
		DataTable gridViewSource = this.GridViewSource;
		this.CollectData();
		if (text != string.Empty)
		{
			if (this.hfType.Value == "2")
			{
				DataTable dataTable = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + text + ") ").Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						bool flag = true;
						for (int j = 1; j < gridViewSource.Rows.Count; j++)
						{
							if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
							{
								string text2 = gridViewSource.Rows[i]["Qty"].ToString();
								decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
								gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
								decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
								this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
								flag = false;
							}
						}
						if (flag)
						{
							DataRow dataRow = gridViewSource.NewRow();
							dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
							dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
							dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
							dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
							dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
							dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
							dataRow[6] = 1;
							dataRow[7] = 1;
							dataRow[8] = dataTable.Rows[i]["PriceCost"].ToString();
							dataRow[9] = dataTable.Rows[i]["PriceCost"].ToString();
							dataRow[10] = dataTable.Rows[i]["SN"].ToString();
							dataRow[11] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
							dataRow[12] = "";
							dataRow[13] = value;
							dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
							dataRow[15] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
							dataRow[16] = int.Parse(dataTable.Rows[i]["ID"].ToString());
							dataRow[17] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
							dataRow[18] = 0;
							decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text)).ToString("#0.00");
							gridViewSource.Rows.Add(dataRow);
						}
					}
					this.BindData();
				}
			}
			else
			{
				DataTable dataTable = DALCommon.GetDataList("ck_servicesmaterial", "", " [ID] in(" + text + ") ").Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.CollectData();
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						bool flag = true;
						for (int j = 1; j < gridViewSource.Rows.Count; j++)
						{
							if (gridViewSource.Rows[j]["ID"].ToString() == dataTable.Rows[i]["ID"].ToString())
							{
								string text2 = gridViewSource.Rows[i]["Qty"].ToString();
								decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
								gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
								decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
								this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
								flag = false;
							}
						}
						if (flag)
						{
							DataRow dataRow = gridViewSource.NewRow();
							dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
							dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
							dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
							dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
							dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
							dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
							dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString());
							dataRow[7] = decimal.Parse(dataTable.Rows[i]["LQty"].ToString());
							dataRow[8] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
							dataRow[9] = decimal.Parse(dataTable.Rows[i]["Total"].ToString());
							dataRow[10] = dataTable.Rows[i]["SN"].ToString();
							dataRow[11] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
							dataRow[12] = dataTable.Rows[i]["PeriodEndDate"].ToString();
							dataRow[13] = dataTable.Rows[i]["BillID"].ToString();
							dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
							dataRow[15] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
							dataRow[16] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
							dataRow[17] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
							dataRow[18] = int.Parse(dataTable.Rows[i]["ID"].ToString());
							this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Price"].ToString()) * decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
							gridViewSource.Rows.Add(dataRow);
						}
					}
					this.BindData();
				}
			}
			this.SysInfo("$('tbCon').focus();");
		}
	}

	protected void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlReason.SelectedValue == "3")
		{
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bStop=0 and bReject=1 ");
			this.lbOperator.Text = "退";
			this.lbStock.Text = "入库";
			this.tbSltGoods.Visible = false;
		}
		else if (this.ddlReason.SelectedValue == "2")
		{
			this.lbOperator.Text = "退";
			this.lbStock.Text = "入库";
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bStop=0 and bReject=0 ");
			this.tbSltGoods.Visible = false;
		}
		else
		{
			this.lbOperator.Text = "领";
			this.lbStock.Text = "出库";
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bStop=0 and bReject=0 ");
			this.tbSltGoods.Visible = true;
		}
	}

	protected void btnSltStock_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["GoodsID"].ToString() == this.hfRecID.Value)
			{
				gridViewSource.Rows[i][0] = this.hfName.Value;
				gridViewSource.Rows[i][15] = int.Parse(this.hfRecIDs.Value);
			}
		}
		this.BindData();
	}

	protected void btnSltUnit_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["GoodsID"].ToString() == this.hfRecID.Value.Replace("u", ""))
			{
				gridViewSource.Rows[i][5] = this.hfName.Value;
				gridViewSource.Rows[i][17] = int.Parse(this.hfRecIDs.Value);
			}
		}
		this.BindData();
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected bool CollectData()
	{
		decimal num = 0m;
		decimal d = 0m;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["SN"] = textBox2.Text;
			gridViewSource.Rows[i]["Price"] = textBox3.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox4.Text);
			num += decimal.Parse(textBox.Text);
			d += decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text);
		}
		decimal num2 = 0m;
		bool result;
		if (this.ddlReason.SelectedValue != "1")
		{
			DataTable dataTable = DALCommon.GetDataList("fw_servicesmaterial", "[LQty]", " [BillID] in(" + this.id + ") ").Tables[0];
			int count = dataTable.Rows.Count;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					num2 += (decimal.TryParse(dataTable.Rows[i][0].ToString(), out num2) ? num2 : 0m);
				}
			}
			if (num2 < num)
			{
				this.SysInfo("window.alert('退货数量不能大于已领数量,请重新选择单据');");
				result = false;
				return result;
			}
		}
		this.tbAQty.Text = num.ToString("#0.00");
		this.tbAmount.Text = d.ToString("#0.00");
		result = true;
		return result;
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.AddEmpty();
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		if (this.CollectData())
		{
			if (this.GridViewSource.Rows.Count == 1)
			{
				ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
			}
			else
			{
				int iTbid;
				bool flag;
				int num = this.BillAdd(out iTbid, out flag);
				if (num == 0)
				{
					if (this.hfvalue.Value == "1")
					{
						if (!flag)
						{
							this.SysInfo("window.alert('领退单已保存！但审核失败！没有“允许低于最低销售价出库”的权限');");
							this.ClearText();
							return;
						}
					}
					DALBroughtBack dALBroughtBack = new DALBroughtBack();
					string empty = string.Empty;
					int iOperator = 0;
					int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
					dALBroughtBack.ChkBroughtBack(int.Parse((string)this.Session["Session_wtBranchID"]), iTbid, iOperator, out empty);
					this.SysInfo("window.alert('" + empty + "');");
					this.ClearText();
				}
				else
				{
					this.SysInfo("window.alert('操作失败！请查看错误日志');");
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.CollectData())
		{
			if (this.GridViewSource.Rows.Count == 1)
			{
				ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
			}
			else
			{
				int num2;
				bool flag;
				int num = this.BillAdd(out num2, out flag);
				if (num == 0)
				{
					this.SysInfo("window.alert('操作成功！该领退单已保存');");
					this.ClearText();
				}
				else
				{
					this.SysInfo("window.alert('操作失败！请查看错误日志');");
				}
			}
		}
	}

	protected int BillAdd(out int iTbid, out bool isLowPrice)
	{
		BroughtBackInfo broughtBackInfo = new BroughtBackInfo();
		isLowPrice = true;
		broughtBackInfo.DeptID = new int?(int.Parse((string)this.Session["Session_wtBranchID"]));
		broughtBackInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		broughtBackInfo.AppID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		broughtBackInfo.Type = new int?(int.Parse(this.ddlReason.SelectedValue));
		broughtBackInfo.PersonID = new int?(int.Parse(this.Session["Session_wtUserBID"].ToString()));
		broughtBackInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		broughtBackInfo.Status = new int?(1);
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<BroughtBackDetailInfo> list = new List<BroughtBackDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					BroughtBackDetailInfo broughtBackDetailInfo = new BroughtBackDetailInfo();
					broughtBackDetailInfo.StockID = new int?(int.Parse(this.ddlStock.SelectedValue));
					broughtBackDetailInfo.GoodsID = new int?(int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()));
					broughtBackDetailInfo.UnitID = new int?(int.Parse(gridViewSource.Rows[i]["UnitID"].ToString()));
					broughtBackDetailInfo.Qty = new decimal?(decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()));
					broughtBackDetailInfo.Price = new decimal?(decimal.Parse(gridViewSource.Rows[i]["Price"].ToString()));
					broughtBackDetailInfo.CiteID = int.Parse(gridViewSource.Rows[i]["ID"].ToString());
					broughtBackDetailInfo.OperationID = gridViewSource.Rows[i]["BillID"].ToString();
					broughtBackDetailInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					broughtBackDetailInfo.SN = gridViewSource.Rows[i]["SN"].ToString();
					list.Add(broughtBackDetailInfo);
					if (this.ddlReason.SelectedValue == "1")
					{
						int goodsid;
						int.TryParse(broughtBackDetailInfo.GoodsID.ToString(), out goodsid);
						if (new DALGoods().getLowPrice(goodsid) > broughtBackDetailInfo.Price)
						{
							isLowPrice = false;
						}
					}
				}
			}
			broughtBackInfo.BroughtBackDetailInfos = list;
		}
		DALBroughtBack dALBroughtBack = new DALBroughtBack();
		int result = dALBroughtBack.Add(broughtBackInfo, out iTbid);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(12, 0);
		this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		this.ddlOperator.ClearSelection();
		string b = (string)this.Session["Session_wtUser"];
		for (int i = 0; i < this.ddlOperator.Items.Count; i++)
		{
			if (this.ddlOperator.Items[i].Text == b)
			{
				this.ddlOperator.Items[i].Selected = true;
				break;
			}
		}
		this.tbRemark.Text = "";
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
