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

public partial class Branch_Stock_BroughtBackMod : Page, IRequiresSessionState
{
	
	private int id;

	private string ids;

	private string f;
    

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
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PeriodEndDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CiteID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StockID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		this.ids = base.Request["ids"];
		if (this.id == 0 && this.ids == null)
		{
			base.Response.End();
		}
		this.f = base.Request["f"];
		if (this.f == null || this.f == "")
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r27"))
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
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			DALBroughtBack dALBroughtBack = new DALBroughtBack();
			if (this.id == 0)
			{
				this.id = dALBroughtBack.GetID(this.ids);
			}
			BroughtBackInfo model = dALBroughtBack.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.AppID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlReason.Items.Count; i++)
				{
					if (this.ddlReason.Items[i].Value == model.Type.ToString())
					{
						this.ddlReason.Items[i].Selected = true;
						break;
					}
				}
				if (model.Type == 2)
				{
					this.lbOperator.Text = "退";
				}
				this.tbRemark.Text = model.Remark;
				this.tbAQty.Text = "0.00";
				this.tbAmount.Text = "0.00";
				this.AddEmpty();
				int num2 = 0;
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("ck_broughtbackdetail", "", " BillID=" + this.id.ToString()).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
					this.hfStockName.Value = dataTable.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString()).ToString("#0.00");
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()).ToString("#0.00");
					dataRow[8] = decimal.Parse(dataTable.Rows[i]["Total"].ToString()).ToString("#0.00");
					dataRow[9] = dataTable.Rows[i]["SN"].ToString();
					dataRow[10] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[11] = dataTable.Rows[i]["PeriodEndDate"].ToString();
					dataRow[12] = dataTable.Rows[i]["OperationID"].ToString();
					int.TryParse(dataTable.Rows[i]["CiteID"].ToString(), out num2);
					dataRow[13] = num2;
					dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[15] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					this.hfStockID.Value = dataTable.Rows[i]["StockID"].ToString();
					dataRow[16] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					dataRow[17] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
					dataRow[18] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[19] = 1;
					this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Total"].ToString())).ToString("#0.00");
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
				if (model.Status == 2)
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "该单据已经审核，修改无法保存";
					this.lbMod.Attributes.Add("class", "si2");
				}
				else
				{
					this.lbMod.Text = "若手工输入编号或单号，输入完成后回车";
					this.lbMod.Attributes.Add("class", "si1");
				}
				if (model.DeptID != int.Parse((string)this.Session["Session_wtBranchID"]))
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "只能修改本部门的领退单.";
					this.lbMod.Attributes.Add("class", "si2");
				}
			}
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
		dataRow[9] = "";
		dataRow[10] = "";
		dataRow[11] = "";
		dataRow[12] = "";
		dataRow[13] = 0;
		dataRow[14] = "";
		dataRow[15] = 0;
		dataRow[16] = 0;
		dataRow[17] = 0;
		dataRow[18] = 0;
		dataRow[19] = 0;
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
			e.Row.Cells[10].Text = string.Concat(new string[]
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
			e.Row.Cells[15].Text = string.Concat(new string[]
			{
				"<a href = \"#\" onclick=\"ChkGD('",
				e.Row.Cells[15].Text,
				"');\">",
				e.Row.Cells[15].Text,
				"</a>"
			});
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		string text2 = "$('" + this.tbCon.ClientID + "').select();";
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
						dataRow[0] = this.hfStockName.Value;
						dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[6] = 1;
						dataRow[7] = 0;
						dataRow[8] = 0;
						dataRow[9] = "";
						dataRow[10] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[11] = "";
						dataRow[12] = "";
						dataRow[13] = 0;
						dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
						dataRow[15] = int.Parse(this.hfStockID.Value);
						dataRow[16] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[17] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
						dataRow[18] = 0;
						dataRow[19] = 0;
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
						if (gridViewSource.Rows[j]["CiteID"].ToString() == dataTable.Rows[i]["ID"].ToString())
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
						dataRow[0] = this.hfStockName.Value;
						dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString());
						dataRow[7] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
						dataRow[8] = decimal.Parse(dataTable.Rows[i]["Total"].ToString());
						dataRow[9] = dataTable.Rows[i]["SN"].ToString();
						dataRow[10] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[11] = dataTable.Rows[i]["PeriodEndDate"].ToString();
						dataRow[12] = dataTable.Rows[i]["BillID"].ToString();
						dataRow[13] = 0;
						dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
						dataRow[15] = int.Parse(this.hfStockID.Value);
						dataRow[16] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
						dataRow[17] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
						dataRow[18] = 0;
						dataRow[19] = 0;
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
							dataRow[0] = this.hfStockName.Value;
							dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
							dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
							dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
							dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
							dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
							dataRow[6] = 1;
							dataRow[7] = 0;
							dataRow[8] = 0;
							dataRow[9] = "";
							dataRow[10] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
							dataRow[11] = "";
							dataRow[12] = "";
							dataRow[13] = 0;
							dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
							dataRow[15] = int.Parse(this.hfStockID.Value);
							dataRow[16] = int.Parse(dataTable.Rows[i]["ID"].ToString());
							dataRow[17] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
							dataRow[18] = 0;
							dataRow[19] = 0;
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
							if (gridViewSource.Rows[j]["CiteID"].ToString() == dataTable.Rows[i]["ID"].ToString())
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
							dataRow[0] = this.hfStockName.Value;
							dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
							dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
							dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
							dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
							dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
							dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString());
							dataRow[7] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
							dataRow[8] = decimal.Parse(dataTable.Rows[i]["Total"].ToString());
							dataRow[9] = dataTable.Rows[i]["SN"].ToString();
							dataRow[10] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
							dataRow[11] = dataTable.Rows[i]["PeriodEndDate"].ToString();
							dataRow[12] = dataTable.Rows[i]["BillID"].ToString();
							dataRow[13] = 0;
							dataRow[14] = dataTable.Rows[i]["Remark"].ToString();
							dataRow[15] = int.Parse(this.hfStockID.Value);
							dataRow[16] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
							dataRow[17] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
							dataRow[18] = 0;
							dataRow[19] = 0;
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

	protected void CollectData()
	{
		decimal d = 0m;
		decimal d2 = 0m;
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
			d += decimal.Parse(textBox.Text);
			d2 += decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text);
		}
		this.tbAQty.Text = d.ToString("#0.00");
		this.tbAmount.Text = d2.ToString("#0.00");
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (i == e.RowIndex)
			{
				if (int.Parse(gridViewSource.Rows[i]["iFlag"].ToString()) == 1)
				{
					if (this.hfdellist.Value == string.Empty)
					{
						this.hfdellist.Value = gridViewSource.Rows[i]["RecID"].ToString();
					}
					else
					{
						HiddenField expr_AA = this.hfdellist;
						expr_AA.Value = expr_AA.Value + "," + gridViewSource.Rows[i]["RecID"].ToString();
					}
				}
			}
		}
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
		this.CollectData();
		this.BindData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			string str;
			bool flag;
			int num = this.BillUpdate(out str, out flag);
			if (num == 0)
			{
				if (this.hfvalue.Value == "1")
				{
					if (!flag)
					{
						this.SysInfo("window.alert('领退单已保存！但审核失败！没有“允许低于最低销售价出库”的权限');");
						return;
					}
				}
				DALBroughtBack dALBroughtBack = new DALBroughtBack();
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
				dALBroughtBack.ChkBroughtBack(int.Parse((string)this.Session["Session_wtBranchID"]), this.id, iOperator, out str);
				this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		this.BindData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			string str;
			bool flag;
			int num = this.BillUpdate(out str, out flag);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该领退单已保存');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected int BillUpdate(out string strMsg, out bool isLowPrice)
	{
		BroughtBackInfo broughtBackInfo = new BroughtBackInfo();
		isLowPrice = true;
		broughtBackInfo.ID = this.id;
		broughtBackInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		broughtBackInfo.AppID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		broughtBackInfo.Type = new int?(int.Parse(this.ddlReason.SelectedValue));
		broughtBackInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<BroughtBackDetailInfo> list = new List<BroughtBackDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					BroughtBackDetailInfo broughtBackDetailInfo = new BroughtBackDetailInfo();
					broughtBackDetailInfo.ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString());
					broughtBackDetailInfo.StockID = new int?(int.Parse(gridViewSource.Rows[i]["StockID"].ToString()));
					broughtBackDetailInfo.GoodsID = new int?(int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()));
					broughtBackDetailInfo.UnitID = new int?(int.Parse(gridViewSource.Rows[i]["UnitID"].ToString()));
					broughtBackDetailInfo.Qty = new decimal?(decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()));
					broughtBackDetailInfo.Price = new decimal?(decimal.Parse(gridViewSource.Rows[i]["Price"].ToString()));
					broughtBackDetailInfo.CiteID = int.Parse(gridViewSource.Rows[i]["CiteID"].ToString());
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
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"BroughtBackDetail",
				this.hfdellist.Value
			});
		}
		DALBroughtBack dALBroughtBack = new DALBroughtBack();
		return dALBroughtBack.Update(broughtBackInfo, list2, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
