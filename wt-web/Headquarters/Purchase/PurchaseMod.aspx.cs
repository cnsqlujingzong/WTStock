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

public partial class Headquarters_Purchase_PurchaseMod : Page, IRequiresSessionState
{

	private int id;

	private string ids;

	private string f;

	private static bool bCheck = false;

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
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
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

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		DALPurchase dALPurchase = new DALPurchase();
		FunLibrary.ChkHead();
		string text = base.Request["n"];
		if (text == "1" && text != null)
		{
			this.btnAdd.Visible = false;
		}
		int.TryParse(base.Request["id"], out this.id);
		this.ids = base.Request["ids"];
		if (this.id == 0 && this.ids == null)
		{
			base.Response.End();
		}
		if (this.id == 0)
		{
			this.id = dALPurchase.GetID(this.ids);
		}
		this.f = base.Request["f"];
		if (this.f == null || this.f == "")
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "cg_r4"))
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
				if (dALRight.GetRight(num, "ck_r86"))
				{
					Headquarters_Purchase_PurchaseMod.bCheck = true;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			OtherFunction.BindStocks(this.ddlStock, " DeptID=1 and bStop=0 and bReject=0 ");
			PurchaseInfo model = dALPurchase.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbSupName.Text = model.SupName;
				if (model.Type == 2)
				{
					this.lbType.Text = "退货";
				}
				this.tbDate.Text = model._Date;
				this.hfPlanID.Value = model.PlanID.ToString();
				this.hfSupID.Value = model.ProvID.ToString();
				DataTable dataTable = DALCommon.GetDataList("SysParm", "bPlanControl", "ID=1").Tables[0];
				if (dataTable.Rows[0][0].ToString().ToLower().Equals("true") || dataTable.Rows[0][0].ToString().Equals("1"))
				{
					this.hfPlanControl.Value = "1";
				}
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.OperatorID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlStock.Items.Count; i++)
				{
					if (this.ddlStock.Items[i].Value == model.StockID.ToString())
					{
						this.ddlStock.Items[i].Selected = true;
						break;
					}
				}
				this.tbRemark.Text = model.Remark;
				this.tbAQty.Text = "0.00";
				this.tbAmount.Text = "0.00";
				this.tbGoodsAmount.Text = "0.00";
				this.tbInCash.Text = model.InCash.ToString("#0.00");
				this.AddEmpty();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable2 = DALCommon.GetDataList("cg_purchasedetail", "", " BillID=" + this.id.ToString()).Tables[0];
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable2.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable2.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable2.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable2.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = dataTable2.Rows[i]["Unit"].ToString();
					dataRow[5] = decimal.Parse(dataTable2.Rows[i]["Qty"].ToString()).ToString("#0.00");
					dataRow[6] = decimal.Parse(dataTable2.Rows[i]["Price"].ToString()).ToString("#0.00");
					dataRow[7] = decimal.Parse(dataTable2.Rows[i]["Total"].ToString()).ToString("#0.00");
					dataRow[8] = dataTable2.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[9] = dataTable2.Rows[i]["SN"].ToString();
					dataRow[10] = dataTable2.Rows[i]["Remark"].ToString();
					dataRow[11] = int.Parse(dataTable2.Rows[i]["GoodsID"].ToString());
					dataRow[12] = int.Parse(dataTable2.Rows[i]["UnitID"].ToString());
					dataRow[13] = int.Parse(dataTable2.Rows[i]["ID"].ToString());
					dataRow[14] = 1;
					dataRow[15] = decimal.Parse(dataTable2.Rows[i]["TaxRate"].ToString()).ToString("#0.00");
					dataRow[16] = decimal.Parse(dataTable2.Rows[i]["TaxAmount"].ToString()).ToString("#0.00");
					dataRow[17] = decimal.Parse(dataTable2.Rows[i]["GoodsAmount"].ToString()).ToString("#0.00");
					this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable2.Rows[i]["Qty"].ToString())).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable2.Rows[i]["Total"].ToString())).ToString("#0.00");
					this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable2.Rows[i]["GoodsAmount"].ToString())).ToString("#0.00");
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
					this.lbMod.Text = "若手工输入编号或条码，输入完成后回车";
					this.lbMod.Attributes.Add("class", "si1");
				}
				if (model.DeptID != 1)
				{
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.btnClean.Enabled = false;
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
		dataRow[16] = 0;
		dataRow[17] = 0;
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
		if (this.hfBuyPrice.Value.Trim().Equals("1"))
		{
			e.Row.Cells[10].Style["display"] = "none";
			e.Row.Cells[11].Style["display"] = "none";
			e.Row.Cells[12].Style["display"] = "none";
			e.Row.Cells[13].Style["display"] = "none";
			e.Row.Cells[14].Style["display"] = "none";
		}
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
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
			e.Row.Cells[7].Attributes.Add("ondblclick", "SltUnit1();");
			e.Row.Cells[8].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[8].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[8].Attributes.Add("ondblclick", "SltUnitQty1('" + textBox.ClientID + "');");
			e.Row.Cells[17].Attributes.Add("id", "tdsn" + e.Row.Cells[0].Text);
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			e.Row.Cells[10].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			htmlInputButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('p",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');SltPrice1('1','",
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
				"','tdsn",
				e.Row.Cells[0].Text,
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
					dataRow[15] = 0;
					dataRow[16] = 0;
					dataRow[17] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
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
						dataRow[15] = 0;
						dataRow[16] = 0;
						dataRow[17] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00");
						this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00"));
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
		this.tbInCash.Text = "0.00";
		this.tbGoodsAmount.Text = "0.00";
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
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				DALPurchase dALPurchase = new DALPurchase();
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
				if (Headquarters_Purchase_PurchaseMod.bCheck)
				{
					dALPurchase.ChkPurchase(1, this.id, iOperator, out str);
				}
				else
				{
					dALPurchase.ChkPurchase(0, this.id, iOperator, out str);
				}
				this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
			}
			else if (num == -11)
			{
				this.SysInfo("window.alert('操作失败！货品采购总数量超过订单额定量');");
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
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该采购单已保存');parent.CloseDialog('1');");
			}
			else if (num == -11)
			{
				this.SysInfo("window.alert('操作失败！货品采购总数量超过订单额定量');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected int BillUpdate(out string strMsg)
	{
		PurchaseInfo purchaseInfo = new PurchaseInfo();
		purchaseInfo.ID = this.id;
		purchaseInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		purchaseInfo.OperatorID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		purchaseInfo.StockID = new int?(int.Parse(this.ddlStock.SelectedValue));
		purchaseInfo.ProvID = new int?(int.Parse(this.hfSupID.Value));
		purchaseInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		decimal inCash = 0m;
		decimal.TryParse(this.tbInCash.Text, out inCash);
		purchaseInfo.InCash = inCash;
		int num = 0;
		if (this.hfPlanID.Value != "")
		{
			int.TryParse(this.hfPlanID.Value, out num);
		}
		DataTable gridViewSource = this.GridViewSource;
		int result;
		if (gridViewSource.Rows.Count > 0)
		{
			DataTable dataTable = null;
			DataTable dataTable2 = null;
			if (num > 0)
			{
				dataTable = DALCommon.GetDataList("cg_purchaseplandetail", "GoodsID,UnitID,Qty", "BillID=" + num).Tables[0];
				dataTable2 = DALCommon.GetDataList("cg_purchasedetail", "GoodsID,UnitID,Qty", string.Concat(new object[]
				{
					"BillID in(select ID from Purchase where PlanID=",
					num,
					") and BillID<>",
					this.id
				})).Tables[0];
			}
			List<PurchaseDetailInfo> list = new List<PurchaseDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					PurchaseDetailInfo purchaseDetailInfo = new PurchaseDetailInfo();
					purchaseDetailInfo.ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString());
					purchaseDetailInfo.GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString());
					purchaseDetailInfo.UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString());
					purchaseDetailInfo.Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString());
					if (this.hfPlanControl.Value == "1" && num > 0)
					{
						DataRow[] array = dataTable.Select(string.Concat(new object[]
						{
							"GoodsID=",
							purchaseDetailInfo.GoodsID,
							" and UnitID=",
							purchaseDetailInfo.UnitID
						}));
						DataRow[] array2 = dataTable2.Select(string.Concat(new object[]
						{
							"GoodsID=",
							purchaseDetailInfo.GoodsID,
							" and UnitID=",
							purchaseDetailInfo.UnitID
						}));
						decimal num2 = 0m;
						for (int j = 0; j < array2.Length; j++)
						{
							decimal d = 0m;
							decimal.TryParse(array2[j]["Qty"].ToString(), out d);
							num2 += d;
						}
						num2 += purchaseDetailInfo.Qty;
						if (array.Length > 0)
						{
							decimal d2 = 0m;
							decimal.TryParse(array[0]["Qty"].ToString(), out d2);
							if (d2 < num2)
							{
								strMsg = "";
								result = -11;
								return result;
							}
						}
					}
					purchaseDetailInfo.Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString());
					purchaseDetailInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					purchaseDetailInfo.SN = gridViewSource.Rows[i]["SN"].ToString();
					purchaseDetailInfo.TaxRate = decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString());
					purchaseDetailInfo.TaxAmount = decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString());
					purchaseDetailInfo.GoodsAmount = decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString());
					list.Add(purchaseDetailInfo);
				}
			}
			purchaseInfo.PurchaseDetailInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"PurchaseDetail",
				this.hfdellist.Value
			});
		}
		DALPurchase dALPurchase = new DALPurchase();
		int num3 = dALPurchase.Update(purchaseInfo, list2, out strMsg);
		if (this.hfPlanControl.Value == "1" && num > 0)
		{
			DALPurchasePlan dALPurchasePlan = new DALPurchasePlan();
			dALPurchasePlan.FullClose(num);
		}
		result = num3;
		return result;
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
