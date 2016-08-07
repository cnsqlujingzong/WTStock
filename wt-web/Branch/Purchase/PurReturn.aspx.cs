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

public partial class Branch_Purchase_PurReturn : Page, IRequiresSessionState
{
	
	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("TaxRate", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("GoodsAmount", typeof(decimal)));
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
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			DALRight dALRight = new DALRight();
			if (!dALRight.ChkBranchPurchase(int.Parse(this.Session["Session_wtBranchID"].ToString())))
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
				base.Response.End();
			}
			else
			{
				if (num > 0)
				{
					if (!dALRight.GetRight(num, "cg_r1"))
					{
						this.btnAdd.Enabled = false;
					}
					if (!dALRight.GetRight(num, "cg_r5"))
					{
						this.btnChk.Enabled = false;
					}
					if (!dALRight.GetRight(num, "cg_r9"))
					{
						this.btnPrint.Visible = false;
					}
					if (dALRight.GetRight(num, "jc_r27"))
					{
						this.hfBuyPrice.Value = "1";
						this.tdmoney1.Attributes["style"] = "display:none;";
						this.tdmoney2.Attributes["style"] = "display:none;";
						this.tdmoney3.Attributes["style"] = "display:none;";
						this.tdmoney4.Attributes["style"] = "display:none;";
						this.tdmoney5.Attributes["style"] = "display:none;";
						this.tdmoney6.Attributes["style"] = "display:none;";
					}
					if (dALRight.GetRight(num, "ck_r84"))
					{
						this.hfvalue.Value = "1";
					}
				}
				this.tbBillID.Text = DALCommon.CreateID(17, 0);
				this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + this.Session["Session_wtBranchID"].ToString() + " and Status=0 and bSeller=1");
				OtherFunction.BindStocks(this.ddlStock, " DeptID=" + this.Session["Session_wtBranchID"].ToString() + " and bStop=0 and bReject=0 ");
				string b = (string)this.Session["Session_wtUserB"];
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
				this.tbInCash.Text = "0.00";
				this.tbGoodsAmount.Text = "0.00";
				this.AddEmpty();
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
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = "";
		dataRow[9] = "";
		dataRow[10] = "";
		dataRow[11] = 0;
		dataRow[12] = 0;
		dataRow[13] = 0;
		dataRow[14] = 0;
		dataRow[15] = 0;
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
		if (this.hfBuyPrice.Value.Trim().Equals("1"))
		{
			e.Row.Cells[10].Style["display"] = "none";
			e.Row.Cells[11].Style["display"] = "none";
			e.Row.Cells[12].Style["display"] = "none";
			e.Row.Cells[13].Style["display"] = "none";
			e.Row.Cells[14].Style["display"] = "none";
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbPrice") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			LinkButton linkButton = e.Row.FindControl("lbDel") as LinkButton;
			TextBox textBox3 = e.Row.FindControl("tbSN") as TextBox;
			TextBox textBox4 = e.Row.FindControl("tbTaxRate") as TextBox;
			Label label2 = e.Row.FindControl("lbTaxAmount") as Label;
			Label label3 = e.Row.FindControl("lbGoodsAmount") as Label;
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox2.Attributes.Add("oldNum", textBox2.Text);
			label.Attributes.Add("oldNum", label.Text);
			textBox4.Attributes.Add("oldNum", textBox4.Text);
			label2.Attributes.Add("oldNum", label2.Text);
			label3.Attributes.Add("oldNum", label3.Text);
			linkButton.Attributes.Add("num", e.Row.RowIndex.ToString());
			linkButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkAmount(this,'",
				label.ClientID,
				"','",
				textBox.ClientID,
				"',1,'",
				label3.ClientID,
				"');"
			}));
			textBox.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateNum(this,'",
				textBox2.ClientID,
				"','",
				label.ClientID,
				"',1,'",
				textBox4.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');"
			}));
			textBox2.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateMoney(this,'",
				textBox.ClientID,
				"','",
				label.ClientID,
				"',1,'",
				textBox4.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');"
			}));
			textBox4.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateRate(this,'",
				textBox.ClientID,
				"','",
				label.ClientID,
				"',1,'",
				textBox2.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[7].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
			e.Row.Cells[7].Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[7].Attributes.Add("ondblclick", "SltUnit();");
			e.Row.Cells[8].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[8].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[8].Attributes.Add("ondblclick", "SltUnitQty('" + textBox.ClientID + "');");
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			e.Row.Cells[10].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			htmlInputButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('p",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');SltPrice('1','",
				textBox2.ClientID,
				"');"
			}));
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
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ck_goods", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
		string text = "$('" + this.tbCon.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < gridViewSource.Rows.Count; j++)
				{
					if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
					{
						decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
						gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
						gridViewSource.Rows[j]["GoodsAmount"] = decimal.Parse(gridViewSource.Rows[j]["GoodsAmount"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString());
						this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())).ToString("#0.00"));
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
						flag = false;
					}
				}
				if (flag)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[5] = 1;
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
					dataRow[8] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[9] = "";
					dataRow[10] = "";
					dataRow[11] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[12] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
					dataRow[13] = 0;
					dataRow[14] = 0;
					dataRow[15] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
					decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00");
					this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00"));
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
		else
		{
			text += "window.alert('操作失败！没有该产品信息');";
		}
		this.SysInfo(text);
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
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
							gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
							gridViewSource.Rows[j]["GoodsAmount"] = decimal.Parse(gridViewSource.Rows[j]["GoodsAmount"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString());
							this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())).ToString("#0.00"));
							decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[5] = 1;
						dataRow[6] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
						dataRow[7] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
						dataRow[8] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[9] = "";
						dataRow[10] = "";
						dataRow[11] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[12] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
						dataRow[13] = 0;
						dataRow[14] = 0;
						dataRow[15] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
						this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00"));
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00");
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.SysInfo("$('tbCon').focus();");
	}

	protected void btnSltBill_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfSltID.Value, out num);
		DataTable gridViewSource = this.GridViewSource;
		if (num != 0)
		{
			DALPurchase dALPurchase = new DALPurchase();
			PurchaseInfo model = dALPurchase.GetModel(num);
			if (model == null)
			{
				return;
			}
			this.ddlStock.ClearSelection();
			for (int i = 0; i < this.ddlStock.Items.Count; i++)
			{
				if (this.ddlStock.Items[i].Value == model.StockID.ToString())
				{
					this.ddlStock.Items[i].Selected = true;
					break;
				}
			}
			this.hfSupID.Value = model.ProvID.ToString();
			this.tbSupName.Text = model.SupName;
			this.hfOperationID.Value = model.BillID;
			this.tbInCash.Text = model.InCash.ToString("#0.00");
			DataTable dataTable = DALCommon.GetDataList("cg_purchasedetail", "", " BillID=" + num.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["GoodsID"].ToString())
						{
							gridViewSource.Rows[j]["Qty"] = Convert.ToDouble(decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString()) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
							gridViewSource.Rows[j]["Total"] = Convert.ToDouble(decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
							gridViewSource.Rows[j]["GoodsAmount"] = decimal.Parse(gridViewSource.Rows[j]["GoodsAmount"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString());
							this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())).ToString("#0.00"));
							this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[5] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString()).ToString("#0.00");
						dataRow[6] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()).ToString("#0.00");
						dataRow[7] = decimal.Parse(dataTable.Rows[i]["Total"].ToString()).ToString("#0.00");
						dataRow[8] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[9] = dataTable.Rows[i]["SN"].ToString();
						dataRow[10] = "";
						dataRow[11] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
						dataRow[12] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
						dataRow[13] = decimal.Parse(dataTable.Rows[i]["TaxRate"].ToString()).ToString("#0.00");
						dataRow[14] = decimal.Parse(dataTable.Rows[i]["TaxAmount"].ToString()).ToString("#0.00");
						dataRow[15] = decimal.Parse(dataTable.Rows[i]["GoodsAmount"].ToString()).ToString("#0.00");
						this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable.Rows[i]["GoodsAmount"].ToString())).ToString("#0.00");
						this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString()) * decimal.Parse(dataTable.Rows[i]["Price"].ToString())).ToString("#0.00");
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.SysInfo("$('tbCon').focus();");
	}

	protected void btnSltUnit_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["GoodsID"].ToString() == this.hfRecID.Value.Replace("u", ""))
			{
				gridViewSource.Rows[i][4] = this.hfName.Value;
				gridViewSource.Rows[i][12] = int.Parse(this.hfRecIDs.Value);
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
		decimal d3 = 0m;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			TextBox textBox5 = this.gvdata.Rows[i].FindControl("tbTaxRate") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["SN"] = textBox2.Text;
			gridViewSource.Rows[i]["Price"] = textBox3.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox4.Text);
			gridViewSource.Rows[i]["TaxRate"] = textBox5.Text;
			gridViewSource.Rows[i]["TaxAmount"] = Convert.ToDouble(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) * decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString())).ToString("#0.00");
			gridViewSource.Rows[i]["GoodsAmount"] = Convert.ToDouble(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString())).ToString("#0.00");
			d += decimal.Parse(textBox.Text);
			d2 += decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text);
			d3 += decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString());
		}
		this.tbAQty.Text = d.ToString("#0.00");
		this.tbAmount.Text = d2.ToString("#0.00");
		this.tbGoodsAmount.Text = d3.ToString("#0.00");
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
		this.tbInCash.Text = "0.00";
		this.tbGoodsAmount.Text = "0.00";
		this.AddEmpty();
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		DataTable dataTable = DALCommon.GetDataList("SupplierList", "[ID]", " _Name='" + FunLibrary.ChkInput(this.tbSupName.Text) + "' ").Tables[0];
		if (dataTable.Rows.Count == 1)
		{
			this.hfSupID.Value = dataTable.Rows[0]["ID"].ToString();
			this.CollectData();
			if (this.GridViewSource.Rows.Count == 1)
			{
				ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
			}
			else
			{
				int iTbid;
				int num = this.BillAdd(out iTbid);
				if (num == 0)
				{
					DALPurchase dALPurchase = new DALPurchase();
					string empty = string.Empty;
					int iOperator = 0;
					int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
					if (this.hfvalue.Value == "1")
					{
						dALPurchase.ChkPurchase(1, iTbid, iOperator, out empty);
					}
					else
					{
						dALPurchase.ChkPurchase(0, iTbid, iOperator, out empty);
					}
					this.SysInfo("window.alert(\"" + empty + "\");");
					this.ClearText();
				}
				else
				{
					this.SysInfo("window.alert('操作失败！请查看错误日志');");
				}
			}
		}
		else
		{
			this.hfSupID.Value = "";
			this.SysInfo("window.alert('操作失败！厂商不存在，请添加');$(\"tbSupName\").focus()");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DataTable dataTable = DALCommon.GetDataList("SupplierList", "[ID]", " _Name='" + FunLibrary.ChkInput(this.tbSupName.Text) + "' ").Tables[0];
		if (dataTable.Rows.Count == 1)
		{
			this.hfSupID.Value = dataTable.Rows[0]["ID"].ToString();
			this.CollectData();
			if (this.GridViewSource.Rows.Count == 1)
			{
				ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
			}
			else
			{
				int num2;
				int num = this.BillAdd(out num2);
				if (num == 0)
				{
					this.SysInfo("window.alert('操作成功！该采购退货单已保存');");
					this.ClearText();
				}
				else
				{
					this.SysInfo("window.alert('操作失败！请查看错误日志');");
				}
			}
		}
		else
		{
			this.hfSupID.Value = "";
			this.SysInfo("window.alert('操作失败！厂商不存在，请添加');$(\"tbSupName\").focus()");
		}
	}

	protected int BillAdd(out int iTbid)
	{
		PurchaseInfo purchaseInfo = new PurchaseInfo();
		purchaseInfo.DeptID = new int?(int.Parse(this.Session["Session_wtBranchID"].ToString()));
		purchaseInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		purchaseInfo.OperatorID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		purchaseInfo.StockID = new int?(int.Parse(this.ddlStock.SelectedValue));
		purchaseInfo.ProvID = new int?(int.Parse(this.hfSupID.Value));
		purchaseInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		purchaseInfo.OperationID = this.hfOperationID.Value;
		decimal inCash = 0m;
		decimal.TryParse(this.tbInCash.Text, out inCash);
		purchaseInfo.InCash = inCash;
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<PurchaseDetailInfo> list = new List<PurchaseDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new PurchaseDetailInfo
					{
						GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()),
						UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString()),
						Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()),
						Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString()),
						Remark = gridViewSource.Rows[i]["Remark"].ToString(),
						SN = gridViewSource.Rows[i]["SN"].ToString(),
						TaxRate = decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString()),
						TaxAmount = decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString()),
						GoodsAmount = decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString())
					});
				}
			}
			purchaseInfo.PurchaseDetailInfos = list;
		}
		DALPurchase dALPurchase = new DALPurchase();
		int result = dALPurchase.Add(purchaseInfo, 2, out iTbid);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(17, 0);
		this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		this.ddlOperator.ClearSelection();
		string b = (string)this.Session["Session_wtUserB"];
		for (int i = 0; i < this.ddlOperator.Items.Count; i++)
		{
			if (this.ddlOperator.Items[i].Text == b)
			{
				this.ddlOperator.Items[i].Selected = true;
				break;
			}
		}
		this.ddlStock.ClearSelection();
		this.ddlStock.Items.FindByText("").Selected = true;
		this.tbSupName.Text = "";
		this.hfSupID.Value = "";
		this.tbRemark.Text = "";
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.tbInCash.Text = "0.00";
		this.tbGoodsAmount.Text = "0.00";
		this.hfOperationID.Value = (this.hfSltID.Value = "");
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
