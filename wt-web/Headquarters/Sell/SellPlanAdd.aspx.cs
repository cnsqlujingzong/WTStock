using EF;
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

public partial class Headquarters_Sell_SellPlanAdd : Page, IRequiresSessionState
{

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("StockName", typeof(string)));//1
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));//2
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));//3
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));//4
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));//5
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));//6
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));//7
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));//8
				dataTable.Columns.Add(new DataColumn("Dis", typeof(decimal)));//9
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));//10
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));//11
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));//12
				dataTable.Columns.Add(new DataColumn("StockID", typeof(int)));//13
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));//14
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));//15
				dataTable.Columns.Add(new DataColumn("TaxRate", typeof(decimal)));//16
				dataTable.Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));//17
				dataTable.Columns.Add(new DataColumn("GoodsAmount", typeof(decimal)));//18
                dataTable.Columns.Add(new DataColumn("Huoqi", typeof(string)));//19
                dataTable.Columns.Add(new DataColumn("chengse", typeof(string)));//20
                dataTable.Columns.Add(new DataColumn("baozhuang", typeof(string)));//21
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
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "xs_r10"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r13"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r17"))
				{
					this.btnPrint.Visible = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(21, 0);
            this.tbDate.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now); 
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0 and bSeller=1");
			OtherFunction.BindStaff(this.ddlSndOperator, "DeptID=1 and Status=0");
            ddlOperator.SelectedValue = Session["Session_wtUserID"].ToString();
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			for (int i = 0; i < this.ddlSndOperator.Items.Count; i++)
			{
				if (this.ddlSndOperator.Items[i].Text == b)
				{
					this.ddlSndOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbAQty.Text = "0.00";
			this.tbAmount.Text = "0.00";
			this.tbGoodsAmount.Text = "0.00";
			this.AddEmpty();
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
		dataRow[12] = 0;
		dataRow[13] = 0;
		dataRow[14] = 0;
		dataRow[15] = 0;
		dataRow[16] = 0;
		dataRow[17] = 0;
        dataRow[18] = "";
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
			TextBox textBox4 = e.Row.FindControl("tbTaxRate") as TextBox;
			Label label2 = e.Row.FindControl("lbTaxAmount") as Label;
			Label label3 = e.Row.FindControl("lbGoodsAmount") as Label;
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox2.Attributes.Add("oldNum", textBox2.Text);
			label.Attributes.Add("oldNum", label.Text);
			textBox4.Attributes.Add("oldNum", textBox4.Text);
			label2.Attributes.Add("oldNum", label2.Text);
			label3.Attributes.Add("oldNum", label3.Text);
            /***为每个产品增加税率 by Coding**/
           // if (!string.IsNullOrEmpty(this.tbTaxrate.Text))
          //  {
          //      textBox4.Text = tbTaxrate.Text;
         //   }



			linkButton.Attributes.Add("num", e.Row.RowIndex.ToString());
			linkButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkAmountselp(this,'",
				label.ClientID,
				"','",
				textBox.ClientID,
				"','",
				textBox4.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');"
			}));
			textBox2.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateMoneyselp(this,'",
				textBox.ClientID,
				"','",
				textBox3.ClientID,
				"','",
				label.ClientID,
				"','",
				textBox4.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');"
			}));   
			textBox.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateNumselp(this,'",
				textBox2.ClientID,
				"','",
				textBox3.ClientID,
				"','",
				label.ClientID,
				"','",
				textBox4.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');"
			}));
			textBox3.Attributes.Add("onchange", string.Concat(new string[]
			{
				"ValidateMoneyselp(this,'",
				textBox.ClientID,
				"','",
				textBox2.ClientID,
				"','",
				label.ClientID,
				"','",
				textBox4.ClientID,
				"','",
				label2.ClientID,
				"','",
				label3.ClientID,
				"');"
			}));
			textBox4.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateRateselp(this,'",
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
			e.Row.Cells[3].Attributes.Add("ondblclick", "SltStock();");
			e.Row.Cells[8].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
			e.Row.Cells[8].Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[8].Attributes.Add("ondblclick", "SltUnit();");
			e.Row.Cells[9].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[9].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[9].Attributes.Add("ondblclick", "SltUnitQty('" + textBox.ClientID + "');");
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			e.Row.Cells[10].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			htmlInputButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('p",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');SltPrice('2','",
				textBox2.ClientID,
				"');"
			}));
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
        string str3 = "$('" + this.tbCon.ClientID + "').select();";
        if (table2.Rows.Count > 0)
        {
            this.CollectData();
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
                bool flag2 = true;
                for (int j = 0; j < gridViewSource.Rows.Count; j++)
                {
                    if (gridViewSource.Rows[j]["GoodsID"].ToString() == table2.Rows[i]["ID"].ToString())
                    {
                        decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
                        gridViewSource.Rows[j]["Total"] = Convert.ToDouble((decimal) (decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                        gridViewSource.Rows[j]["GoodsAmount"] = (decimal.Parse(gridViewSource.Rows[j]["GoodsAmount"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())) + ((decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString()));
                        this.tbGoodsAmount.Text = Convert.ToDouble((decimal) ((decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())) + ((decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())))).ToString("#0.00");
                        decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                        this.tbAmount.Text = Convert.ToDouble((decimal) (decimal.Parse(this.tbAmount.Text) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                        flag2 = false;
                    }
                }
                if (flag2)
                {
                    DataRow row = gridViewSource.NewRow();
                    row[0] = table2.Rows[i]["StockName"].ToString();
                    row[1] = table2.Rows[i]["GoodsNO"].ToString();
                    row[2] = table2.Rows[i]["_Name"].ToString();
                    row[3] = table2.Rows[i]["Spec"].ToString();
                    row[4] = table2.Rows[i]["ProductBrand"].ToString();
                    row[5] = table2.Rows[i]["Unit"].ToString();
                    row[6] = 1;
                    row[7] = num;
                    row[8] = result;
                    row[9] = Convert.ToDouble((decimal) (num * result)).ToString("#0.00");
                    row[10] = table2.Rows[i]["MainTenancePeriod"].ToString();
                    row[11] = "";
                    int num7 = -1;
                    int.TryParse(table2.Rows[i]["StockID"].ToString(), out num7);
                    row[12] = num7;
                    row[13] = int.Parse(table2.Rows[i]["ID"].ToString());
                    row[14] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
                    row[15] = 0;
                    row[0x10] = 0;
                    row[0x11] = num;
                    decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                    this.tbAmount.Text = Convert.ToDouble((decimal) (decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                    this.tbGoodsAmount.Text = Convert.ToDouble((decimal) (decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                    gridViewSource.Rows.Add(row);
                }
            }
            this.BindData();
        }
        else
        {
            str3 = str3 + "window.alert('操作失败！没有该产品信息');";
        }
        this.tbCon.Text = string.Empty;
        this.SysInfo(str3);
        this.SysInfo2("$('tbCon').focus();");
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
                       bool flag2 = true;
                       for (int j = 1; j < gridViewSource.Rows.Count; j++)
                       {
                           if (gridViewSource.Rows[j]["GoodsID"].ToString() == table3.Rows[i]["ID"].ToString())
                           {
                               decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
                               gridViewSource.Rows[j]["Total"] = Convert.ToDouble((decimal)(decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                               gridViewSource.Rows[j]["GoodsAmount"] = (decimal.Parse(gridViewSource.Rows[j]["GoodsAmount"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())) + ((decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString()));
                               this.tbGoodsAmount.Text = Convert.ToDouble((decimal)((decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())) + ((decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())))).ToString("#0.00");
                               decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                               this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                               flag2 = false;
                           }
                       }
                       if (flag2)
                       {
                           DataRow row = gridViewSource.NewRow();
                           row[0] = table3.Rows[i]["StockName"].ToString();
                           row[1] = table3.Rows[i]["GoodsNO"].ToString();
                           row[2] = table3.Rows[i]["_Name"].ToString();
                           row[3] = table3.Rows[i]["Spec"].ToString();
                           row[4] = table3.Rows[i]["ProductBrand"].ToString();
                           row[5] = table3.Rows[i]["Unit"].ToString();
                           row[6] = 1;
                           row[7] = num;
                           row[8] = result;
                           row[9] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                           row[10] = table3.Rows[i]["MainTenancePeriod"].ToString();
                           row[11] = "";
                           int num7 = -1;
                           int.TryParse(table3.Rows[i]["StockID"].ToString(), out num7);
                           row[12] = num7;
                           row[13] = int.Parse(table3.Rows[i]["ID"].ToString());
                           row[14] = int.Parse(table3.Rows[i]["GoodsUnitID"].ToString());
                           row[15] = 0;
                           row[0x10] = 0;
                           row[0x11] = num;
                           decimal AQty=decimal.Parse(this.tbAQty.Text);  
                           ++AQty; 
                           this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                           this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                           this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                           gridViewSource.Rows.Add(row);
                       }
                   }
                   this.BindData();
               }
           }
           this.SysInfo("$('tbCon').focus();");
           GoodTotal();//重新合计
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
				gridViewSource.Rows[i][12] = int.Parse(this.hfRecIDs.Value);
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
				gridViewSource.Rows[i][14] = int.Parse(this.hfRecIDs.Value);
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
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbDis") as TextBox;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			TextBox textBox5 = this.gvdata.Rows[i].FindControl("tbTaxRate") as TextBox;
            TextBox textBox6 = this.gvdata.Rows[i].FindControl("tbhuoqi") as TextBox;
            DropDownList textBox7 = this.gvdata.Rows[i].FindControl("ddl_chengse") as DropDownList;
            DropDownList textBox8 = this.gvdata.Rows[i].FindControl("ddl_baozhuang") as DropDownList;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["Price"] = textBox2.Text;
			gridViewSource.Rows[i]["Dis"] = textBox3.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox2.Text) * decimal.Parse(textBox3.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox4.Text);
            //if (string.IsNullOrEmpty(FunLibrary.ChkInput(textBox6.Text)))//	this.SysInfo("window.alert(\"" + empty + "\");");
            //{
            //    this.SysInfo("window.alert(\"货期不能为空\");");
            //    return;
            //}
            gridViewSource.Rows[i]["Huoqi"] = FunLibrary.ChkInput(textBox6.Text);
            gridViewSource.Rows[i]["chengse"] = FunLibrary.ChkInput(textBox7.SelectedValue);
            gridViewSource.Rows[i]["baozhuang"] = FunLibrary.ChkInput(textBox8.SelectedValue);
			gridViewSource.Rows[i]["TaxRate"] = textBox5.Text;
			gridViewSource.Rows[i]["TaxAmount"] = Convert.ToDouble(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) * decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString())).ToString("#0.00");
			gridViewSource.Rows[i]["GoodsAmount"] = Convert.ToDouble(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString())).ToString("#0.00");
			d += decimal.Parse(textBox.Text);
			d2 += decimal.Parse(textBox.Text) * decimal.Parse(textBox2.Text);
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
		this.tbGoodsAmount.Text = "0.00";
		this.AddEmpty();
	}

	protected void btnCusInfo_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
            DataTable dataTable = DALCommon.GetDataList("CustomerList", "_Name,LinkMan,Tel,Tel2,Adr", " [ID]=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();				
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();

                DataTable dataTable2 = DALCommon.GetDataList("CustomerLinkMan", " CustomerID,_Name,tel_Office,tel_Mobile ", " [CustomerID]=" + this.hfCusID.Value).Tables[0];

                ddl_LinkMan.Items.Clear();
                this.tbTel.Text = "";
                ListItem li0 = new ListItem("请选择联系人", "-1");
                ListItem li1 = new ListItem(dataTable.Rows[0]["LinkMan"].ToString(), string.IsNullOrEmpty(dataTable.Rows[0]["Tel"].ToString()) ? dataTable.Rows[0]["Tel2"].ToString() : dataTable.Rows[0]["Tel"].ToString());
                ddl_LinkMan.Items.Add(li0);
                ddl_LinkMan.Items.Add(li1);
                if (dataTable2.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTable2.Rows)
                    {
                        string tel = string.IsNullOrEmpty(item["tel_Office"].ToString()) ? item["tel_Mobile"].ToString() : item["tel_Office"].ToString();
                        ddl_LinkMan.Items.Add(new ListItem(item["_Name"].ToString(), tel));
                    }
                }

               // this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
               // this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
  
			}
		}
	}
    protected void ddl_LinkMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.tbLinkMan.Text= ddl_LinkMan.SelectedItem.Text;
        this.tbTel.Text = ddl_LinkMan.SelectedValue == "-1" ? "" : ddl_LinkMan.SelectedValue;
    }
    /// <summary>
    /// 查询网点
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnWangdian_Click(object sender, EventArgs e)
	{
		if (this.hfwangdianID.Value != "")
        {
            //技术服务+增值税销项+增值税进项+普通发票
            DataTable dataTable = DALCommon.GetDataList("BranchList", "_Name, CAST(TR_jsfw as varchar(10))+'-'+CAST(TR_zzsxx as varchar(10))+'-'+CAST(TR_zzsjx as varchar(10))+'-'+CAST(TR_ptfp as varchar(10)) as TR ", " [ID]=" + this.hfwangdianID.Value).Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                tbwangdian.Text = dataTable.Rows[0]["_Name"].ToString();
                //tbwdTaxrate.Text = dataTable.Rows[0]["TaxRate"].ToString();
                ddl_branchFax.Items.Clear();
                string[] taxs = dataTable.Rows[0]["TR"].ToString().Split('-');
                ListItem li0 = new ListItem("不含税", "no-0");
                ListItem li1 = new ListItem("技术服务费：" + Math.Round(decimal.Parse(taxs[0]) * 100, 2) + "%", "jsfw-" + taxs[0]);
                ListItem li2 = new ListItem("增值税销项：" + Math.Round(decimal.Parse(taxs[1]) * 100, 2) + "%", "zzsxx-" + taxs[1]);
                ListItem li3 = new ListItem("增值税进项：" + Math.Round(decimal.Parse(taxs[2]) * 100, 2) + "%", "zzsjx-" + taxs[2]);
                ListItem li4 = new ListItem("普通发票：" + Math.Round(decimal.Parse(taxs[3]) * 100, 2) + "%", "ptfp-" + taxs[3]);
                ddl_branchFax.Items.Add(li0);
                ddl_branchFax.Items.Add(li1);
                ddl_branchFax.Items.Add(li2);
                ddl_branchFax.Items.Add(li3);
                ddl_branchFax.Items.Add(li4);
            }
		}
        tbGoodsAmount.Text = tbAmount.Text;
    
        UpdatePanel2.Update();
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
                WTLog.WriteLog("销售订单", iTbid.ToString(), "新建订单", "保存成功!");
				DALSellPlan dALSellPlan = new DALSellPlan();
				string empty = string.Empty;
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
				dALSellPlan.ChkSellPlan(1, iTbid, iOperator, out empty);
                WTLog.WriteLog("销售订单", iTbid.ToString(), "审核订单", empty);
				this.SysInfo("window.alert(\"" + empty + "\");");
				this.ClearText();
            
			}
			else
			{
				this.SysInfo("window.alert('操作失败！请查看错误日志');");
			}
		}
	}
    /// <summary>
    /// 保存销售计划单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
				this.SysInfo("window.alert('操作成功！该销售订单已保存');");
				this.ClearText();
                WTLog.WriteLog("销售订单", num.ToString(), "新建订单");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！请查看错误日志');");
			}
		}
	}

	protected int BillAdd(out int iTbid)
	{
		SellPlanInfo sellPlanInfo = new SellPlanInfo();
		sellPlanInfo.DeptID = 1;
		sellPlanInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		sellPlanInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		sellPlanInfo.CustomerID = int.Parse(this.hfCusID.Value);
		sellPlanInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		sellPlanInfo.ContractNO = FunLibrary.ChkInput(this.tbContractNO.Text);
		sellPlanInfo.bEnd = 1;
		sellPlanInfo.SndOperatorID = int.Parse(this.ddlSndOperator.SelectedValue);
		sellPlanInfo.LinkMan = FunLibrary.ChkInput(this.ddl_LinkMan.SelectedItem.Text);
		sellPlanInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		sellPlanInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
     
        string[] ps = this.ddl_branchFax.SelectedValue.Split('-');
        sellPlanInfo.BrandName = FunLibrary.ChkInput(tbwangdian.Text);
        sellPlanInfo.BrandTaxRate = decimal.Parse(FunLibrary.ChkInput(ps[1]));
        sellPlanInfo.BrandTaxRateType = FunLibrary.ChkInput(ps[0]);

		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<SellPlanDetailInfo> list = new List<SellPlanDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new SellPlanDetailInfo
					{
						StockID = int.Parse(gridViewSource.Rows[i]["StockID"].ToString()),
						GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()),
						UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString()),
						Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()),
						Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString()),
						Dis = decimal.Parse(gridViewSource.Rows[i]["Dis"].ToString()),
						Remark = gridViewSource.Rows[i]["Remark"].ToString(),
						TaxRate = decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString()),
						TaxAmount = decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString()),
						GoodsAmount = decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString()),
                        Huoqi = gridViewSource.Rows[i]["Huoqi"].ToString(),
                        chengse = gridViewSource.Rows[i]["chengse"].ToString(),
                        baozhuang = gridViewSource.Rows[i]["baozhuang"].ToString()


					});
				}
			}
			sellPlanInfo.SellPlanDetailInfos = list;
		}
		DALSellPlan dALSellPlan = new DALSellPlan();
		int result = dALSellPlan.Add(sellPlanInfo, out iTbid);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(21, 0);
		this.tbDate.Text =string.Format("{0:yyyy-MM-dd HH:mm:ss}",DateTime.Now);
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
		this.hfCusID.Value = "";
		this.tbCusName.Text = "";
		this.tbRemark.Text = "";
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.tbAdr.Text = "";
		this.tbTel.Text = "";
		this.tbLinkMan.Text = "";
		this.tbContractNO.Text = "";
		this.tbGoodsAmount.Text = "0.00";
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void SysInfo2(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo2", str, true);
	}
    /**
    protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] ps = this.ddl_branch.SelectedValue.Split('-');    
        if (ps.Length < 2)
        {
            tbTaxrate.Text = "";
        }
        else
        {
            tbTaxrate.Text = ps[1];
        } 
    }**/
    //税率改变
    protected void ddl_branchFax_SelectedIndexChanged(object sender, EventArgs e)
    {
        GoodTotal();
      //  UpdatePanel2.Update();
    }

    private void GoodTotal()
    {
        int allcount = 0;
        decimal totle = 0;

        //btnId_Click(null, null);
        if (gvdata.Rows.Count > 0)
        {
            for (int i = 0; i < gvdata.Rows.Count; i++)
            {
                TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
                TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
                TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbDis") as TextBox;
                allcount += int.Parse(textBox.Text);
                totle += int.Parse(textBox.Text) * decimal.Parse(textBox2.Text) * decimal.Parse(textBox3.Text);
            }
        }
        decimal lv = 1;
        if (!string.IsNullOrEmpty(ddl_branchFax.SelectedValue))
        {
            lv = decimal.Parse(ddl_branchFax.SelectedValue.Split('-')[1]) + 1; 
        }
        tbAQty.Text = allcount.ToString();
        tbAmount.Text = totle.ToString("#0.00");
        tbGoodsAmount.Text = totle.ToString("#0.00"); //Math.Round(totle * lv, 2).ToString("#0.00");
    }
 
}
