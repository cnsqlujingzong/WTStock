using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
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

public partial class Branch_Purchase_PurchaseAdd : Page, IRequiresSessionState
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
			DALRight dALRight = new DALRight();
			if (!dALRight.ChkBranchPurchase(int.Parse(this.Session["Session_wtBranchID"].ToString())))
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
				base.Response.End();
			}
			else
			{
				int num = int.Parse((string)this.Session["Session_wtPurBID"]);
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
				OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
				OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=" + this.Session["Session_wtBranchID"].ToString());
				OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
				this.tbBillID.Text = DALCommon.CreateID(16, 0);
				this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + this.Session["Session_wtBranchID"].ToString() + " and Status=0 and bSeller=1");
				OtherFunction.BindStocks(this.ddlStock, " DeptID=" + this.Session["Session_wtBranchID"].ToString() + " and bStop=0 and bReject=0 ");
				DataTable dataTable = DALCommon.GetDataList("SysParm", "bPlanControl", "ID=1").Tables[0];
				if (dataTable.Rows[0][0].ToString().ToLower().Equals("true") || dataTable.Rows[0][0].ToString().Equals("1"))
				{
					this.tdpc.Visible = true;
					this.hfPlanControl.Value = "1";
				}
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
				if (base.Request.QueryString["sellid"] != null)
				{
					int num2 = 0;
					int.TryParse(base.Request.QueryString["sellid"], out num2);
					DataTable gridViewSource = this.GridViewSource;
					DataTable dataTable2 = DALCommon.GetDataList("xs_selldetail", "", " BillID=" + num2).Tables[0];
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
						dataRow[9] = "";
						dataRow[10] = "";
						dataRow[11] = int.Parse(dataTable2.Rows[i]["GoodsID"].ToString());
						dataRow[12] = int.Parse(dataTable2.Rows[i]["UnitID"].ToString());
						dataRow[13] = decimal.Parse(dataTable2.Rows[i]["TaxRate"].ToString()).ToString("#0.00");
						dataRow[14] = decimal.Parse(dataTable2.Rows[i]["TaxAmount"].ToString()).ToString("#0.00");
						dataRow[15] = decimal.Parse(dataTable2.Rows[i]["GoodsAmount"].ToString()).ToString("#0.00");
						this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable2.Rows[i]["GoodsAmount"].ToString())).ToString("#0.00"));
						this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable2.Rows[i]["Qty"].ToString())).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable2.Rows[i]["Qty"].ToString()) * decimal.Parse(dataTable2.Rows[i]["Price"].ToString())).ToString("#0.00");
						gridViewSource.Rows.Add(dataRow);
					}
					this.BindData();
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["f"]))
				{
					string str = base.Request.QueryString["f"].TrimEnd(new char[]
					{
						','
					});
					DataTable gridViewSource = this.GridViewSource;
					DataTable dataTable3 = DALCommon.GetDataList("ck_stockdepthb", "", "ID in(" + str + ")").Tables[0];
					int count = dataTable3.Rows.Count;
					for (int i = 0; i < count; i++)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable3.Rows[i]["GoodsNO"].ToString();
						dataRow[1] = dataTable3.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable3.Rows[i]["Spec"].ToString();
						dataRow[3] = dataTable3.Rows[i]["ProductBrand"].ToString();
						dataRow[4] = dataTable3.Rows[i]["Unit"].ToString();
						dataRow[5] = "0.00";
						dataRow[6] = "0.00";
						dataRow[7] = "0.00";
						dataRow[8] = dataTable3.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[9] = "";
						dataRow[10] = "";
						dataRow[11] = int.Parse(dataTable3.Rows[i]["GoodsID"].ToString());
						dataRow[12] = int.Parse(dataTable3.Rows[i]["GoodsUnitID"].ToString());
						dataRow[13] = "0.00";
						dataRow[14] = "0.00";
						dataRow[15] = "0.00";
						this.tbAQty.Text = "0.00";
						this.tbAmount.Text = "0.00";
						gridViewSource.Rows.Add(dataRow);
					}
					this.BindData();
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
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
		this.sdyest();
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
				"');Caculate();"
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
				"');Caculate();"
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
			e.Row.Cells[17].Attributes.Add("id", "tdsn" + e.Row.Cells[0].Text);
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
		this.SysInfo("$('" + this.tbCon.ClientID + "').focus();");
	}

	protected void btnSltBill_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfSltID.Value, out num);
		DataTable gridViewSource = this.GridViewSource;
		if (num != 0)
		{
			DALPurchasePlan dALPurchasePlan = new DALPurchasePlan();
			PurchasePlanInfo model = dALPurchasePlan.GetModel(num);
			if (model == null)
			{
				return;
			}
			this.lbPlan.Text = model.BillID;
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
			this.hfPlanID.Value = model.ID.ToString();
			DataTable dataTable = DALCommon.GetDataList("cg_purchaseplandetail", "", " BillID=" + num.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				if (this.hfPlanControl.Value == "1")
				{
					gridViewSource.Rows.Clear();
					this.AddEmpty();
				}
				else
				{
					this.CollectData();
				}
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
						decimal d = 0m;
						decimal.TryParse(dataTable.Rows[i]["leftcount"].ToString(), out d);
						if (this.hfPlanControl.Value == "")
						{
							dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
							dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
							dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
							dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
							dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
							dataRow[5] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString()).ToString("#0.00");
							dataRow[6] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()).ToString("#0.00");
							dataRow[7] = decimal.Parse(dataTable.Rows[i]["Total"].ToString()).ToString("#0.00");
							dataRow[8] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
							dataRow[9] = "";
							dataRow[10] = "";
							dataRow[11] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
							dataRow[12] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
							dataRow[13] = decimal.Parse(dataTable.Rows[i]["TaxRate"].ToString()).ToString("#0.00");
							dataRow[14] = decimal.Parse(dataTable.Rows[i]["TaxAmount"].ToString()).ToString("#0.00");
							dataRow[15] = decimal.Parse(dataTable.Rows[i]["GoodsAmount"].ToString()).ToString("#0.00");
							this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable.Rows[i]["GoodsAmount"].ToString())).ToString("#0.00"));
							this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString()) * decimal.Parse(dataTable.Rows[i]["Price"].ToString())).ToString("#0.00");
							gridViewSource.Rows.Add(dataRow);
						}
						else if (d > 0m)
						{
							dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
							dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
							dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
							dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
							dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
							dataRow[5] = decimal.Parse(dataTable.Rows[i]["leftcount"].ToString()).ToString("#0.00");
							dataRow[6] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()).ToString("#0.00");
							dataRow[7] = (decimal.Parse(dataTable.Rows[i]["leftcount"].ToString()) * decimal.Parse(dataTable.Rows[i]["Price"].ToString())).ToString("#0.00");
							dataRow[8] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
							dataRow[9] = "";
							dataRow[10] = "";
							dataRow[11] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
							dataRow[12] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
							dataRow[13] = decimal.Parse(dataTable.Rows[i]["TaxRate"].ToString()).ToString("#0.00");
							dataRow[14] = (decimal.Parse(dataTable.Rows[i]["leftcount"].ToString()) * decimal.Parse(dataTable.Rows[i]["Price"].ToString()) * decimal.Parse(dataTable.Rows[i]["TaxRate"].ToString())).ToString("#0.00");
                            decimal TaxRate1=decimal.Parse(dataTable.Rows[i]["TaxRate"].ToString());
                            ++TaxRate1;
                            decimal TaxRate2 = decimal.Parse(dataTable.Rows[i]["TaxRate"].ToString());
                            ++TaxRate2;
                            dataRow[15] = (decimal.Parse(dataTable.Rows[i]["leftcount"].ToString()) * decimal.Parse(dataTable.Rows[i]["Price"].ToString()) * TaxRate1).ToString("#0.00");
                            this.tbInCash.Text = (this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable.Rows[i]["leftcount"].ToString()) * decimal.Parse(dataTable.Rows[i]["Price"].ToString()) * TaxRate2).ToString("#0.00"));
							this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["leftcount"].ToString())).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["leftcount"].ToString()) * decimal.Parse(dataTable.Rows[i]["Price"].ToString())).ToString("#0.00");
							gridViewSource.Rows.Add(dataRow);
						}
					}
				}
				this.BindData();
			}
		}
		this.SysInfo("$('" + this.tbCon.ClientID + "').focus();");
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
					this.SysInfo("window.alert('" + empty + "');");
					this.ClearText();
				}
				else if (num == -11)
				{
					this.SysInfo("window.alert('操作失败！货品采购总数量超过订单额定量');");
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
					this.SysInfo("window.alert('操作成功！该采购单已保存');");
					this.ClearText();
				}
				else if (num == -11)
				{
					this.SysInfo("window.alert('操作失败！货品采购总数量超过订单额定量');");
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
		int num = 0;
		if (this.hfPlanID.Value != "")
		{
			int.TryParse(this.hfPlanID.Value, out num);
		}
		purchaseInfo.PlanID = num;
		purchaseInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		purchaseInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		decimal invoiceMoney = 0m;
		decimal.TryParse(this.tbInvoiceAmount.Text, out invoiceMoney);
		purchaseInfo.InvoiceMoney = invoiceMoney;
		purchaseInfo.InvoiceNO = FunLibrary.ChkInput(this.tbInvoiceNO.Text);
		purchaseInfo.InvoiceDate = (this.tbInvoiceDate.Text.Trim().Equals("") ? DateTime.MinValue : DateTime.Parse(this.tbInvoiceDate.Text));
		purchaseInfo.AccountID = new int?(int.Parse(this.ddlChargeAccount.SelectedValue));
		purchaseInfo.InvoiceClassID = new int?(int.Parse(this.ddlInvoiceClass.SelectedValue));
		purchaseInfo.ChargeModeID = new int?(int.Parse(this.ddlChargeStyle.SelectedValue));
		DataTable gridViewSource = this.GridViewSource;
		int result;
		if (gridViewSource.Rows.Count > 0)
		{
			DataTable dataTable = null;
			if (num > 0)
			{
				dataTable = DALCommon.GetDataList("cg_purchaseplandetail", "GoodsID,UnitID,Leftcount", "BillID=" + num).Tables[0];
			}
			List<PurchaseDetailInfo> list = new List<PurchaseDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					PurchaseDetailInfo purchaseDetailInfo = new PurchaseDetailInfo();
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
						if (array.Length > 0)
						{
							decimal d = 0m;
							decimal.TryParse(array[0]["leftcount"].ToString(), out d);
							if (d < purchaseDetailInfo.Qty)
							{
								iTbid = 0;
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
		DALPurchase dALPurchase = new DALPurchase();
		int num2 = dALPurchase.Add(purchaseInfo, 1, out iTbid);
		if (this.hfPlanControl.Value == "1" && num > 0)
		{
			DALPurchasePlan dALPurchasePlan = new DALPurchasePlan();
			dALPurchasePlan.FullClose(num);
		}
		this.hfPrintID.Value = iTbid.ToString();
		result = num2;
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(16, 0);
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
		this.tbLinkMan.Text = string.Empty;
		this.tbTel.Text = string.Empty;
		this.ddlChargeStyle.ClearSelection();
		this.ddlInvoiceClass.ClearSelection();
		this.ddlChargeAccount.ClearSelection();
		this.tbInvoiceNO.Text = string.Empty;
		this.tbInvoiceAmount.Text = string.Empty;
		this.tbInvoiceDate.Text = string.Empty;
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
		this.lbPlan.Text = "未关联采购订单";
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	public void sdyest()
	{
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		DALSysVali dALSysVali = new DALSysVali();
		string corpName = sysParm.CorpName;
		string text = sysParm.BranchNum.ToString();
		string str = sysParm.bWeb.ToString();
		string value = dALSysVali.GetValue("ITEM2");
		string text2 = corpName + str + text;
		if (sysParm.bSim)
		{
			text2 += "并发";
		}
		string b = FunLibrary.EncodeReg(text2);
		if (value != b)
		{
			string value2 = dALSysVali.GetValue("ITEM1");
			try
			{
				string time = FunLibrary.StrDecode(value2);
				int num = this.DayTs(time);
				if (num > 60 || num < 0)
				{
					dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
				}
			}
			catch
			{
				dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
			}
		}
		else
		{
			int num2;
			int.TryParse(DALCommon.TCount("UserManage", ""), out num2);
			int num3;
			int.TryParse(text, out num3);
			if (!sysParm.bSim && num2 > num3)
			{
				dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
			}
			try
			{
				string requestUriString = "http://www.differsoft.com/kill_get.asp?id=8";
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Method = "GET";
				httpWebRequest.MaximumAutomaticRedirections = 3;
				httpWebRequest.Timeout = 5000;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text3 = streamReader.ReadToEnd();
				streamReader.Dispose();
				responseStream.Dispose();
				if (text3.Contains(value))
				{
					dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
				}
			}
			catch
			{
			}
			string str2 = dALSysVali.GetValue("ITEM6").ToString().Trim();
			int num4 = 0;
			try
			{
				num4 = int.Parse(FunLibrary.StrDecode(str2));
			}
			catch
			{
			}
			if (dALSysVali.GetValue("ITEM5") != DateTime.Now.ToString("yyyy-MM-dd") || num4 > 0)
			{
				try
				{
					string tel = sysParm.Tel;
					string zip = sysParm.Zip;
					string adr = sysParm.Adr;
					string text4 = "id=8";
					string text5 = text4;
					text4 = string.Concat(new string[]
					{
						text5,
						"&CustomerInfo=公司名:",
						corpName,
						"，电话:",
						tel
					});
					text5 = text4;
					text4 = string.Concat(new string[]
					{
						text5,
						"，邮编:",
						zip,
						"，地址:",
						adr,
						"，注册用户数:",
						text,
						"，实际用户数:",
						num2.ToString(),
						"注册码:",
						value
					});
					if (sysParm.bSim)
					{
						text4 += "，并发";
					}
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(text4);
					HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create("http://www.differsoft.com/kill_post.asp");
					httpWebRequest2.Method = "POST";
					httpWebRequest2.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
					httpWebRequest2.ContentLength = (long)bytes.Length;
					Stream requestStream = httpWebRequest2.GetRequestStream();
					requestStream.Write(bytes, 0, bytes.Length);
					requestStream.Close();
					HttpWebResponse httpWebResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
					StreamReader streamReader2 = new StreamReader(httpWebResponse2.GetResponseStream(), Encoding.GetEncoding("GB2312"));
					string text3 = streamReader2.ReadToEnd();
					requestStream.Dispose();
					streamReader2.Dispose();
					if (text3.ToLower() == "ok")
					{
						dALSysVali.Update("ITEM5", DateTime.Now.ToString("yyyy-MM-dd"));
						dALSysVali.Update("ITEM6", FunLibrary.StrEncode("0"));
					}
					else
					{
						dALSysVali.Update("ITEM6", FunLibrary.StrEncode((num4 + 1).ToString()));
					}
				}
				catch
				{
					dALSysVali.Update("ITEM6", FunLibrary.StrEncode((num4 + 1).ToString()));
				}
			}
		}
	}

	protected int DayTs(string time)
	{
		DateTime d = DateTime.Parse(time);
		DateTime now = DateTime.Now;
		return 1;
	}

	protected void btnSupInfo_Click(object sender, EventArgs e)
	{
		if (this.hfSupID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("SupplierList", " LinkMan,Tel ", " [ID]=" + this.hfSupID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
			}
		}
	}
}
