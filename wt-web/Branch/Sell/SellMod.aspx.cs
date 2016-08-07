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

public partial class Branch_Sell_SellMod : Page, IRequiresSessionState
{
	private int id;

	private string f;

	private string ids;

	
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
				dataTable.Columns.Add(new DataColumn("Dis", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PeriodEnd", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StockID", typeof(int)));
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
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		this.ids = base.Request["ids"];
		if (this.id == 0 && this.ids == null)
		{
			base.Response.End();
		}
		string text = base.Request["n"];
		if (text != null & text == "1")
		{
			this.btnAdd.Visible = false;
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
				if (!dALRight.GetRight(num, "xs_r4"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r5"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r9"))
				{
					this.btnPrint.Visible = false;
				}
				if (dALRight.GetRight(num, "ck_r82"))
				{
					this.hfout.Value = "1";
				}
				if (dALRight.GetRight(num, "jc_r18"))
				{
					this.hflow.Value = "1";
				}
			}
			OtherFunction.BindStock(this.ddlStock, "DeptID=" + (string)this.Session["Session_wtBranchID"]);
			this.ddlStock.Items.Remove(new ListItem("新建...", "0"));
			OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
			OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
			OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			OtherFunction.BindStaff(this.ddlSndOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			DALSell dALSell = new DALSell();
			if (this.id == 0)
			{
				this.id = dALSell.GetID(this.ids);
			}
			SellInfo model = dALSell.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.OperatorID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlSndOperator.Items.Count; i++)
				{
					if (this.ddlSndOperator.Items[i].Value == model.SndOperatorID.ToString())
					{
						this.ddlSndOperator.Items[i].Selected = true;
						break;
					}
				}
				this.hfOperationID.Value = model.OperationID;
				this.tbCusName.Text = model.CusName;
				this.tbAutoNO.Text = model.AutoNO;
				this.hfCusID.Value = model.CustomerID.ToString();
				this.tbRemark.Text = model.Remark;
				this.tbLinkMan.Text = model.LinkMan;
				this.tbTel.Text = model.Tel;
				this.tbAdr.Text = model.Adr;
				this.ddlChargeAccount.SelectedValue = model.AccountID.ToString();
				this.tbInvoiceNO.Text = model.InvoiceNO.Trim();
				this.tbInvoiceDate.Text = (model.InvoiceDate.Equals(DateTime.MinValue) ? "" : model.InvoiceDate.ToString("yyyy-MM-dd"));
				this.tbInvoiceAmount.Text = model.InvoiceMoney.ToString("f2");
				this.ddlChargeStyle.SelectedValue = model.ChargeModeID.ToString();
				this.ddlInvoiceClass.SelectedValue = model.InvoiceClassID.ToString();
				this.tbAQty.Text = "0.00";
				this.tbAmount.Text = "0.00";
				this.tbGoodsAmount.Text = "0.00";
				this.tbInCash.Text = model.InCash.ToString("#0.00");
				this.AddEmpty();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("xs_selldetail", "", " BillID=" + this.id.ToString()).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString()).ToString("#0.00");
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()).ToString("#0.00");
					dataRow[8] = decimal.Parse(dataTable.Rows[i]["Dis"].ToString()).ToString("#0.00");
					dataRow[9] = decimal.Parse(dataTable.Rows[i]["Total"].ToString()).ToString("#0.00");
					dataRow[10] = dataTable.Rows[i]["SN"].ToString();
					dataRow[11] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[12] = dataTable.Rows[i]["PeriodEndDate"].ToString();
					dataRow[13] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[14] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					dataRow[15] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					dataRow[16] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
					dataRow[17] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[18] = 1;
					dataRow[19] = decimal.Parse(dataTable.Rows[i]["TaxRate"].ToString()).ToString("#0.00");
					dataRow[20] = decimal.Parse(dataTable.Rows[i]["TaxAmount"].ToString()).ToString("#0.00");
					dataRow[21] = decimal.Parse(dataTable.Rows[i]["GoodsAmount"].ToString()).ToString("#0.00");
					this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Total"].ToString())).ToString("#0.00");
					this.tbGoodsAmount.Text = Convert.ToDouble(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(dataTable.Rows[i]["GoodsAmount"].ToString())).ToString("#0.00");
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
				if (model.DeptID != int.Parse((string)this.Session["Session_wtBranchID"]))
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "只能修改本部门的销售单.";
					this.lbMod.Attributes.Add("class", "si2");
				}
				if (model.Type == 2)
				{
					this.lbType.Text = "退货";
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
		dataRow[9] = 0;
		dataRow[10] = "";
		dataRow[11] = "";
		dataRow[12] = "";
		dataRow[13] = "";
		dataRow[14] = 0;
		dataRow[15] = 0;
		dataRow[16] = 0;
		dataRow[17] = 0;
		dataRow[18] = 0;
		dataRow[19] = 0;
		dataRow[20] = 0;
		dataRow[21] = 0;
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
			TextBox textBox3 = e.Row.FindControl("tbDis") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			LinkButton linkButton = e.Row.FindControl("lbDel") as LinkButton;
			TextBox textBox4 = e.Row.FindControl("tbSN") as TextBox;
			TextBox textBox5 = e.Row.FindControl("tbTaxRate") as TextBox;
			Label label2 = e.Row.FindControl("lbTaxAmount") as Label;
			Label label3 = e.Row.FindControl("lbGoodsAmount") as Label;
			textBox5.Attributes.Add("oldNum", textBox5.Text);
			label2.Attributes.Add("oldNum", label2.Text);
			label3.Attributes.Add("oldNum", label3.Text);
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox2.Attributes.Add("oldNum", textBox2.Text);
			label.Attributes.Add("oldNum", label.Text);
			linkButton.Attributes.Add("num", e.Row.RowIndex.ToString());
			linkButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkAmountsel(this,'",
				label.ClientID,
				"','",
				textBox.ClientID,
				"','",
				textBox5.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');"
			}));
			textBox2.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateMoneysel(this,'",
				textBox.ClientID,
				"','",
				textBox3.ClientID,
				"','",
				label.ClientID,
				"','",
				textBox5.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');Caculate();"
			}));
			textBox.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateNumsel(this,'",
				textBox2.ClientID,
				"','",
				textBox3.ClientID,
				"','",
				label.ClientID,
				"','",
				textBox5.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');Caculate();"
			}));
			textBox3.Attributes.Add("onchange", string.Concat(new string[]
			{
				"ValidateMoneysel(this,'",
				textBox.ClientID,
				"','",
				textBox2.ClientID,
				"','",
				label.ClientID,
				"','",
				textBox5.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');Caculate();"
			}));
			textBox5.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateRatesel(this,'",
				textBox.ClientID,
				"','",
				textBox3.ClientID,
				"','",
				label.ClientID,
				"','",
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
			e.Row.Cells[3].Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Cells[3].Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[3].Attributes.Add("ondblclick", "SltStock1();");
			e.Row.Cells[8].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
			e.Row.Cells[8].Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[8].Attributes.Add("ondblclick", "SltUnit1();");
			e.Row.Cells[9].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[9].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[9].Attributes.Add("ondblclick", "SltUnitQty1('" + textBox.ClientID + "');");
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			e.Row.Cells[11].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			int num = 1;
			if (base.Request["f"] != null)
			{
				int.TryParse(base.Request["f"], out num);
				num++;
			}
			htmlInputButton.Attributes.Add("onclick", string.Concat(new object[]
			{
				"ChkIDs('p",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');SltPrice",
				num,
				"('2','",
				textBox2.ClientID,
				"');"
			}));
			e.Row.Cells[10].Text = string.Concat(new string[]
			{
				"<a href=\"#\" onclick=\"EditSN('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"','",
				textBox4.ClientID,
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
        DataTable table2 = DALCommon.GetDataList("ck_goods", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
        decimal num = 0M;
        decimal result = 1M;
        string str2 = "零售价";
        if (this.hfCusID.Value != "")
        {
            DataTable table3 = DALCommon.GetDataList("ks_customer", "Price,Dis", " [ID]=" + this.hfCusID.Value).Tables[0];
            if ((table3.Rows.Count > 0) && (table3.Rows[0]["Price"].ToString() != ""))
            {
                str2 = table3.Rows[0]["Price"].ToString();
                decimal.TryParse(table3.Rows[0]["Dis"].ToString(), out result);
                if (result == 0M)
                {
                    result = 1M;
                }
            }
        }
        string str3 = "$('" + this.tbCon.ClientID + "').select();Caculate();";
        if (table2.Rows.Count > 0)
        {
            this.CollectData();
            string text = "";
            int num3 = 0;
            if (this.ddlStock.Items.Count > 1)
            {
                text = this.ddlStock.Items[1].Text;
                num3 = int.Parse(this.ddlStock.Items[1].Value);
            }
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                switch (str2)
                {
                    case "零售价":
                        num = decimal.Parse(table2.Rows[i]["PriceDetail"].ToString());
                        break;

                    case "进货价":
                        num = decimal.Parse(table2.Rows[i]["PriceCost"].ToString());
                        break;

                    case "内部价":
                        num = decimal.Parse(table2.Rows[i]["PriceInner"].ToString());
                        break;

                    case "旧货价":
                        num = decimal.Parse(table2.Rows[i]["PriceWholesale1"].ToString());
                        break;

                    case "替代价":
                        num = decimal.Parse(table2.Rows[i]["PriceWholesale2"].ToString());
                        break;

                    case "列表价":
                        num = decimal.Parse(table2.Rows[i]["PriceWholesale3"].ToString());
                        break;

                    default:
                        num = decimal.Parse(table2.Rows[i]["PriceDetail"].ToString());
                        break;
                }
                DataRow row = gridViewSource.NewRow();
                row[0] = text;
                row[1] = table2.Rows[i]["GoodsNO"].ToString();
                row[2] = table2.Rows[i]["_Name"].ToString();
                row[3] = table2.Rows[i]["Spec"].ToString();
                row[4] = table2.Rows[i]["ProductBrand"].ToString();
                row[5] = table2.Rows[i]["Unit"].ToString();
                row[6] = 1;
                row[7] = num;
                row[8] = result;
                row[9] = Convert.ToDouble((decimal) (num * result)).ToString("#0.00");
                row[10] = "";
                row[11] = table2.Rows[i]["MainTenancePeriod"].ToString();
                row[12] = "";
                row[13] = "";
                row[14] = num3;
                row[15] = int.Parse(table2.Rows[i]["ID"].ToString());
                row[0x10] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
                row[0x11] = 0;
                row[0x12] = 0;
                row[0x13] = 0;
                row[20] = 0;
                row[0x15] = num;
                this.tbInCash.Text = this.tbGoodsAmount.Text = Convert.ToDouble((decimal) (decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                this.tbAmount.Text = Convert.ToDouble((decimal) (decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                gridViewSource.Rows.Add(row);
            }
            this.BindData();
        }
        else
        {
            str3 = str3 + "window.alert('操作失败！没有该产品信息');";
        }
        this.SysInfo(str3);
    }

       protected void btnId_Click(object sender, EventArgs e)
       {
           string str = string.Empty;
           if (this.hfreclist.Value.EndsWith(","))
           {
               str = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
           }
           else
           {
               str = this.hfreclist.Value;
           }
           decimal num = 0M;
           decimal result = 1M;
           string str2 = "零售价";
           if (this.hfCusID.Value != "")
           {
               DataTable table = DALCommon.GetDataList("ks_customer", "Price,Dis", " [ID]=" + this.hfCusID.Value).Tables[0];
               if ((table.Rows.Count > 0) && (table.Rows[0]["Price"].ToString() != ""))
               {
                   str2 = table.Rows[0]["Price"].ToString();
                   decimal.TryParse(table.Rows[0]["Dis"].ToString(), out result);
                   if (result == 0M)
                   {
                       result = 1M;
                   }
               }
           }
           DataTable gridViewSource = this.GridViewSource;
           if (str != string.Empty)
           {
               DataTable table3 = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + str + ") ").Tables[0];
               if (table3.Rows.Count > 0)
               {
                   this.CollectData();
                   string text = "";
                   int num3 = 0;
                   if (this.ddlStock.Items.Count > 1)
                   {
                       text = this.ddlStock.Items[1].Text;
                       num3 = int.Parse(this.ddlStock.Items[1].Value);
                   }
                   for (int i = 0; i < table3.Rows.Count; i++)
                   {
                       switch (str2)
                       {
                           case "零售价":
                               num = decimal.Parse(table3.Rows[i]["PriceDetail"].ToString());
                               break;

                           case "进货价":
                               num = decimal.Parse(table3.Rows[i]["PriceCost"].ToString());
                               break;

                           case "内部价":
                               num = decimal.Parse(table3.Rows[i]["PriceInner"].ToString());
                               break;

                           case "旧货价":
                               num = decimal.Parse(table3.Rows[i]["PriceWholesale1"].ToString());
                               break;

                           case "替代价":
                               num = decimal.Parse(table3.Rows[i]["PriceWholesale2"].ToString());
                               break;

                           case "列表价":
                               num = decimal.Parse(table3.Rows[i]["PriceWholesale3"].ToString());
                               break;

                           default:
                               num = decimal.Parse(table3.Rows[i]["PriceDetail"].ToString());
                               break;
                       }
                       DataRow row = gridViewSource.NewRow();
                       row[0] = text;
                       row[1] = table3.Rows[i]["GoodsNO"].ToString();
                       row[2] = table3.Rows[i]["_Name"].ToString();
                       row[3] = table3.Rows[i]["Spec"].ToString();
                       row[4] = table3.Rows[i]["ProductBrand"].ToString();
                       row[5] = table3.Rows[i]["Unit"].ToString();
                       row[6] = 1;
                       row[7] = num;
                       row[8] = result;
                       row[9] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                       row[10] = "";
                       row[11] = table3.Rows[i]["MainTenancePeriod"].ToString();
                       row[12] = "";
                       row[13] = "";
                       row[14] = num3;
                       row[15] = int.Parse(table3.Rows[i]["ID"].ToString());
                       row[0x10] = int.Parse(table3.Rows[i]["GoodsUnitID"].ToString());
                       row[0x11] = 0;
                       row[0x12] = 0;
                       row[0x13] = 0;
                       row[20] = 0;
                       row[0x15] = num;
                       this.tbInCash.Text = this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                       decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                       this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                       gridViewSource.Rows.Add(row);
                   }
                   this.BindData();
               }
           }
           this.SysInfo("$('tbCon').focus();Caculate();");
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
				gridViewSource.Rows[i][14] = int.Parse(this.hfRecIDs.Value);
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
				gridViewSource.Rows[i][16] = int.Parse(this.hfRecIDs.Value);
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
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbDis") as TextBox;
			TextBox textBox5 = this.gvdata.Rows[i].FindControl("tbPeriod") as TextBox;
			TextBox textBox6 = this.gvdata.Rows[i].FindControl("tbPeriodEnd") as TextBox;
			TextBox textBox7 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			TextBox textBox8 = this.gvdata.Rows[i].FindControl("tbTaxRate") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["SN"] = textBox2.Text;
			gridViewSource.Rows[i]["Price"] = textBox3.Text;
			gridViewSource.Rows[i]["Dis"] = textBox4.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text) * decimal.Parse(textBox4.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["MainTenancePeriod"] = FunLibrary.ChkInput(textBox5.Text);
			gridViewSource.Rows[i]["PeriodEnd"] = FunLibrary.ChkInput(textBox6.Text);
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox7.Text);
			gridViewSource.Rows[i]["TaxRate"] = textBox8.Text;
			gridViewSource.Rows[i]["TaxAmount"] = Convert.ToDouble(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) * decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString())).ToString("#0.00");
			gridViewSource.Rows[i]["GoodsAmount"] = Convert.ToDouble(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString())).ToString("#0.00");
			d += decimal.Parse(textBox.Text);
			d2 += decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text) * decimal.Parse(textBox4.Text);
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

	protected void btnCusInfo_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "_Name,LinkMan,Tel,Adr", " [ID]=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
			}
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value == "")
		{
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "[ID]", " _Name='" + FunLibrary.ChkInput(this.tbCusName.Text) + "' ").Tables[0];
			if (dataTable.Rows.Count != 1)
			{
				this.hfCusID.Value = "";
				this.SysInfo("window.alert('操作失败！客户不存在，请添加');$(\"tbCusName\").focus()");
				return;
			}
			this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
		}
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
				if (this.hflow.Value == "1")
				{
					if (!flag)
					{
						this.SysInfo("window.alert('销售单保存成功!审核失败！没有“允许低于最低销售价出库”的权限');");
						return;
					}
				}
				DALSell dALSell = new DALSell();
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
				if (this.hfout.Value == "1")
				{
					dALSell.ChkSell1(int.Parse((string)this.Session["Session_wtBranchID"]), this.id, iOperator, out str);
				}
				else
				{
					dALSell.ChkSell(int.Parse((string)this.Session["Session_wtBranchID"]), this.id, iOperator, out str);
				}
				this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value == "")
		{
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "[ID]", " _Name='" + FunLibrary.ChkInput(this.tbCusName.Text) + "' ").Tables[0];
			if (dataTable.Rows.Count != 1)
			{
				this.hfCusID.Value = "";
				this.SysInfo("window.alert('操作失败！客户不存在，请添加');$(\"tbCusName\").focus()");
				return;
			}
			this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
		}
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
				this.SysInfo("window.alert('操作成功！该" + this.lbType.Text + "单已保存');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
	}

	protected int BillUpdate(out string strMsg, out bool isLowPrice)
	{
		SellInfo sellInfo = new SellInfo();
		isLowPrice = true;
		sellInfo.ID = this.id;
		sellInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		sellInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		sellInfo.CustomerID = int.Parse(this.hfCusID.Value);
		sellInfo.AutoNO = FunLibrary.ChkInput(this.tbAutoNO.Text);
		sellInfo.PersonID = int.Parse(this.Session["Session_wtUserBID"].ToString());
		sellInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		decimal inCash = 0m;
		decimal.TryParse(this.tbInCash.Text, out inCash);
		sellInfo.InCash = inCash;
		sellInfo.OperationID = this.hfOperationID.Value;
		sellInfo.SndOperatorID = int.Parse(this.ddlSndOperator.SelectedValue);
		sellInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		sellInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		sellInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
		sellInfo.ChargeModeID = int.Parse(this.ddlChargeStyle.SelectedValue);
		sellInfo.AccountID = int.Parse(this.ddlChargeAccount.SelectedValue);
		decimal invoiceMoney = 0m;
		if (!this.tbInvoiceAmount.Text.Trim().Equals(""))
		{
			decimal.TryParse(this.tbInvoiceAmount.Text, out invoiceMoney);
		}
		sellInfo.InvoiceMoney = invoiceMoney;
		sellInfo.InvoiceNO = this.tbInvoiceNO.Text.Trim();
		sellInfo.InvoiceDate = (this.tbInvoiceDate.Text.Trim().Equals("") ? DateTime.MinValue : DateTime.Parse(this.tbInvoiceDate.Text));
		sellInfo.InvoiceClassID = int.Parse(this.ddlInvoiceClass.SelectedValue);
		DataTable gridViewSource = this.GridViewSource;
		int result;
		if (gridViewSource.Rows.Count > 0)
		{
			List<SellDetailInfo> list = new List<SellDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					SellDetailInfo sellDetailInfo = new SellDetailInfo();
					sellDetailInfo.ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString());
					int num = 0;
					int.TryParse(gridViewSource.Rows[i]["StockID"].ToString(), out num);
					if (num == 0)
					{
						strMsg = "请选择出库仓库！";
						result = -1;
						return result;
					}
					sellDetailInfo.StockID = num;
					sellDetailInfo.GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString());
					sellDetailInfo.UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString());
					sellDetailInfo.Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString());
					sellDetailInfo.Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString());
					sellDetailInfo.Dis = decimal.Parse(gridViewSource.Rows[i]["Dis"].ToString());
					sellDetailInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					sellDetailInfo.SN = gridViewSource.Rows[i]["SN"].ToString();
					sellDetailInfo.MaintenancePeriod = gridViewSource.Rows[i]["MaintenancePeriod"].ToString();
					sellDetailInfo.PeriodEndDate = gridViewSource.Rows[i]["PeriodEnd"].ToString();
					sellDetailInfo.TaxRate = decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString());
					sellDetailInfo.TaxAmount = decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString());
					sellDetailInfo.GoodsAmount = decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString());
					list.Add(sellDetailInfo);
					decimal lowPrice = new DALGoods().getLowPrice(sellDetailInfo.GoodsID);
					if (lowPrice > sellDetailInfo.Price)
					{
						isLowPrice = false;
					}
				}
			}
			sellInfo.SellDetailInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"SellDetail",
				this.hfdellist.Value
			});
		}
		DALSell dALSell = new DALSell();
		int num2 = dALSell.Update(sellInfo, list2, out strMsg);
		result = num2;
		return result;
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
