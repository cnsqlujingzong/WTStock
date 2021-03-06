using EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
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

public partial class Headquarters_Sell_SellMod : Page, IRequiresSessionState
{

    private string f;

    private int id;
    private string ids;
    private static bool isLowPricePower = false;
    private static bool isOutPutCheck = false;

    private void AddEmpty()
    {
        DataTable gridViewSource = this.GridViewSource;
        DataRow row = gridViewSource.NewRow();
        row[0] = "";
        row[1] = "";
        row[2] = "";
        row[3] = "";
        row[4] = "";
        row[5] = "";
        row[6] = 0;
        row[7] = 0;
        row[8] = 0;
        row[9] = 0;
        row[10] = "";
        row[11] = "";
        row[12] = "";
        row[13] = "";
        row[14] = 0;
        row[15] = 0;
        row[0x10] = 0;
        row[0x11] = 0;
        row[0x12] = 0;
        row[0x13] = 0;
        row[20] = 0;
        row[0x15] = 0;
        row[0x16] = "";
        gridViewSource.Rows.Add(row);
        this.GridViewSource = gridViewSource;
        this.BindData();
    }

    protected int BillUpdate(out string strMsg, out bool isLowPrice)
    {
        SellInfo model = new SellInfo();
        isLowPrice = true;
        model.ID = this.id;
        model._Date = FunLibrary.ChkInput(this.tbDate.Text);
        model.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
        model.CustomerID = int.Parse(this.hfCusID.Value);
        model.AutoNO = FunLibrary.ChkInput(this.tbAutoNO.Text);
        model.PersonID = int.Parse(this.Session["Session_wtUserID"].ToString());
        model.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
        decimal result = 0M;
        decimal.TryParse(this.tbInCash.Text, out result);
        model.InCash = result;
        model.OperationID = this.hfOperationID.Value;
        model.SndOperatorID = int.Parse(this.ddlSndOperator.SelectedValue);
        model.LinkMan = FunLibrary.ChkInput(this.ddl_LinkMan.SelectedItem.Text);
        model.Tel = FunLibrary.ChkInput(this.tbTel.Text);
        model.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
        model.ChargeModeID = int.Parse(this.ddlChargeStyle.SelectedValue);
        model.AccountID = int.Parse(this.ddlChargeAccount.SelectedValue);

        string[] ps = this.ddl_branchFax.SelectedValue.Split('-');
        model.BrandName = FunLibrary.ChkInput(tbwangdian.Text);
        model.BrandTaxRate = decimal.Parse(FunLibrary.ChkInput(ps[1]));
        model.BrandTaxRateType = FunLibrary.ChkInput(ps[0]);

        model.isDai = int.Parse(ddl_isdai.SelectedValue);
        if (model.isDai == 1)
        {
            model.CustomerID2 = int.Parse(this.hfCusID2.Value);
            model.LinkMan2 = FunLibrary.ChkInput(this.ddl_LinkMan2.SelectedItem.Text);
            model.Tel2 = FunLibrary.ChkInput(this.tbTel2.Text);
            model.Adr2 = FunLibrary.ChkInput(this.tbAdr2.Text);
        }

        decimal num2 = 0M;
        if (!this.tbInvoiceAmount.Text.Trim().Equals(""))
        {
            decimal.TryParse(this.tbInvoiceAmount.Text, out num2);
        }
        model.InvoiceMoney = num2;
        model.InvoiceNO = this.tbInvoiceNO.Text.Trim();
        model.InvoiceDate = this.tbInvoiceDate.Text.Trim().Equals("") ? Convert.ToDateTime(DateTime.MinValue) : Convert.ToDateTime(this.tbInvoiceDate.Text);
        model.InvoiceClassID = int.Parse(this.ddlInvoiceClass.SelectedValue);
        DataTable gridViewSource = this.GridViewSource;
        if (gridViewSource.Rows.Count > 0)
        {
            List<SellDetailInfo> list = new List<SellDetailInfo>();
            SellDetailInfo item = null;
            for (int i = 0; i < gridViewSource.Rows.Count; i++)
            {
                if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
                {
                    item = new SellDetailInfo
                    {
                        ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString()),
                        StockID = int.Parse(gridViewSource.Rows[i]["StockID"].ToString()),
                        GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()),
                        UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString()),
                        Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()),
                        Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString()),
                        Dis = decimal.Parse(gridViewSource.Rows[i]["Dis"].ToString()),
                        Remark = gridViewSource.Rows[i]["Remark"].ToString(),
                        SN = gridViewSource.Rows[i]["SN"].ToString(),
                        MaintenancePeriod = gridViewSource.Rows[i]["MaintenancePeriod"].ToString(),
                        PeriodEndDate = gridViewSource.Rows[i]["PeriodEnd"].ToString(),
                        TaxRate = decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString()),
                        TaxAmount = decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString()),
                        GoodsAmount = decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString()),
                        Huoqi = gridViewSource.Rows[i]["Huoqi"].ToString(),
                        chengse = gridViewSource.Rows[i]["chengse"].ToString(),
                        baozhuang = gridViewSource.Rows[i]["baozhuang"].ToString()
                    };
                    list.Add(item);
                    if (new DALGoods().getLowPrice(item.GoodsID) > item.Price)
                    {
                        isLowPrice = false;
                    }
                }
            }
            model.SellDetailInfos = list;
        }
        List<string[]> strdellist = new List<string[]>();
        if (this.hfdellist.Value != string.Empty)
        {
            string[] strArray = new string[] { "SellDetail", this.hfdellist.Value };
            strdellist.Add(strArray);
        }
        DALSell sell = new DALSell();
        return sell.Update(model, strdellist, out strMsg);
    }

    private void BindData()
    {
        this.gvdata.DataSource = this.GridViewSource;
        this.gvdata.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.hfCusID.Value == "")
        {
            DataTable table = DALCommon.GetDataList("CustomerList", "[ID]", " _Name='" + FunLibrary.ChkInput(this.tbCusName.Text) + "' ").Tables[0];
            if (table.Rows.Count == 1)
            {
                this.hfCusID.Value = table.Rows[0]["ID"].ToString();
            }
            else
            {
                this.hfCusID.Value = "";
                this.SysInfo("window.alert('操作失败！客户不存在，请添加');$(\"tbCusName\").focus()");
                return;
            }
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
            bool flag2;
            if (this.BillUpdate(out str, out flag2) == 0)
            {
                this.SysInfo("window.alert('操作成功！该" + this.lbType.Text + "单已保存');parent.CloseDialog('1');");
                WTLog.WriteLog("销售单", this.id.ToString(), "编辑销售单", "销售单保存成功!", str);
            }
            else
            {
                this.SysInfo("window.alert(\"" + str + "\");");
                WTLog.WriteLog("销售单", this.id.ToString(), "编辑销售单", "失败!", str);
            }
        }
    }

    protected void btnChk_Click(object sender, EventArgs e)
    {
        if (this.hfCusID.Value == "")
        {
            DataTable table = DALCommon.GetDataList("CustomerList", "[ID]", " _Name='" + FunLibrary.ChkInput(this.tbCusName.Text) + "' ").Tables[0];
            if (table.Rows.Count == 1)
            {
                this.hfCusID.Value = table.Rows[0]["ID"].ToString();
            }
            else
            {
                this.hfCusID.Value = "";
                this.SysInfo("window.alert('操作失败！客户不存在，请添加');$(\"tbCusName\").focus()");
                return;
            }
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
            bool flag2;
            if (this.BillUpdate(out str, out flag2) == 0)
            {
                if (isLowPricePower && !flag2)
                {
                    this.SysInfo("window.alert('销售单保存成功!审核失败！没有“允许低于最低销售价出库”的权限');");
                    WTLog.WriteLog("销售单", this.id.ToString(), "编辑销售单->审核", "销售单保存成功!审核失败！",str);
                }
                else
                {
                    DALSell sell = new DALSell();
                    int result = 0;
                    int.TryParse((string)this.Session["Session_wtUserID"], out result);
                    if (isOutPutCheck)
                    {
                        sell.ChkSell1(1, this.id, result, out str);
                    }
                    else
                    {
                        sell.ChkSell(1, this.id, result, out str);
                    }
                    this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
                    WTLog.WriteLog("销售单", this.id.ToString(), "编辑销售单->审核", "销售单保存成功!审核成功！", str);
                }
            }
            else
            {
                this.SysInfo("window.alert(\"" + str + "\");");
            }
        }
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
            DataTable table = DALCommon.GetDataList("CustomerList", "_Name,LinkMan,Tel,Adr", " [ID]=" + this.hfCusID.Value).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.tbCusName.Text = table.Rows[0]["_Name"].ToString();
               // this.tbLinkMan.Text = table.Rows[0]["LinkMan"].ToString();
                //this.tbTel.Text = table.Rows[0]["Tel"].ToString();
                this.tbAdr.Text = table.Rows[0]["Adr"].ToString();
                DataTable dataTable2 = DALCommon.GetDataList("CustomerLinkMan", " CustomerID,_Name,tel_Office,tel_Mobile ", " [CustomerID]=" + this.hfCusID.Value).Tables[0];

                ddl_LinkMan.Items.Clear();
                this.tbTel.Text = "";
                ListItem li0 = new ListItem("请选择联系人", "-1");
                ListItem li1 = new ListItem(table.Rows[0]["LinkMan"].ToString(), table.Rows[0]["Tel"].ToString());
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
            }
        }
    }
    protected void btnCusInfo2_Click(object sender, EventArgs e)
    {
        if (this.hfCusID2.Value != "")
        {
            DataTable table = DALCommon.GetDataList("CustomerList", "_Name,LinkMan,Tel,Adr", " [ID]=" + this.hfCusID2.Value).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.tbCusName2.Text = table.Rows[0]["_Name"].ToString();
                // this.tbLinkMan.Text = table.Rows[0]["LinkMan"].ToString();
                //this.tbTel.Text = table.Rows[0]["Tel"].ToString();
                this.tbAdr2.Text = table.Rows[0]["Adr"].ToString();
                DataTable dataTable2 = DALCommon.GetDataList("CustomerLinkMan", " CustomerID,_Name,tel_Office,tel_Mobile ", " [CustomerID]=" + this.hfCusID2.Value).Tables[0];

                ddl_LinkMan2.Items.Clear();
                this.tbTel2.Text = "";
                ListItem li0 = new ListItem("请选择联系人", "-1");
                ListItem li1 = new ListItem(table.Rows[0]["LinkMan"].ToString(), table.Rows[0]["Tel"].ToString());
                ddl_LinkMan2.Items.Add(li0);
                ddl_LinkMan2.Items.Add(li1);
                if (dataTable2.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTable2.Rows)
                    {
                        string tel = string.IsNullOrEmpty(item["tel_Office"].ToString()) ? item["tel_Mobile"].ToString() : item["tel_Office"].ToString();
                        ddl_LinkMan2.Items.Add(new ListItem(item["_Name"].ToString(), tel));
                    }
                }
            }
        }
    }
    protected void ddl_LinkMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.tbLinkMan.Text = ddl_LinkMan.SelectedItem.Text;
        this.tbTel.Text = ddl_LinkMan.SelectedValue == "-1" ? "" : ddl_LinkMan.SelectedValue;
    }
    protected void ddl_LinkMan2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.tbLinkMan2.Text = ddl_LinkMan2.SelectedItem.Text;
        this.tbTel2.Text = ddl_LinkMan2.SelectedValue == "-1" ? "" : ddl_LinkMan2.SelectedValue;
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
                    row[10] = "";
                    row[11] = table3.Rows[i]["MainTenancePeriod"].ToString();
                    row[12] = "";
                    row[13] = "";
                    row[14] = int.Parse(table3.Rows[i]["StockID"].ToString());
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
                gridViewSource.Rows[i][0x10] = int.Parse(this.hfRecIDs.Value);
            }
        }
        this.BindData();
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
                row[0] = table2.Rows[i]["StockName"].ToString();
                row[1] = table2.Rows[i]["GoodsNO"].ToString();
                row[2] = table2.Rows[i]["_Name"].ToString();
                row[3] = table2.Rows[i]["Spec"].ToString();
                row[4] = table2.Rows[i]["ProductBrand"].ToString();
                row[5] = table2.Rows[i]["Unit"].ToString();
                row[6] = 1;
                row[7] = num;
                row[8] = result;
                row[9] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                row[10] = "";
                row[11] = table2.Rows[i]["MainTenancePeriod"].ToString();
                row[12] = "";
                row[13] = "";
                row[14] = int.Parse(table2.Rows[i]["StockID"].ToString());
                row[15] = int.Parse(table2.Rows[i]["ID"].ToString());
                row[0x10] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
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
        else
        {
            str3 = str3 + "window.alert('操作失败！没有该产品信息');";
        }
        this.SysInfo(str3);
    }

    protected void CollectData()
    {
        decimal num = 0M;
        decimal num2 = 0M;
        decimal num3 = 0M;
        for (int i = 0; i < this.gvdata.Rows.Count; i++)
        {
            TextBox box = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
            TextBox box2 = this.gvdata.Rows[i].FindControl("tbSN") as TextBox;
            TextBox box3 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
            TextBox box4 = this.gvdata.Rows[i].FindControl("tbDis") as TextBox;
            TextBox box5 = this.gvdata.Rows[i].FindControl("tbPeriod") as TextBox;
            TextBox box6 = this.gvdata.Rows[i].FindControl("tbPeriodEnd") as TextBox;
            TextBox box7 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
            TextBox box8 = this.gvdata.Rows[i].FindControl("tbTaxRate") as TextBox;
            TextBox box9 = this.gvdata.Rows[i].FindControl("tbHuoqi") as TextBox;
            DropDownList textBox7 = this.gvdata.Rows[i].FindControl("ddl_chengse") as DropDownList;
            DropDownList textBox8 = this.gvdata.Rows[i].FindControl("ddl_baozhuang") as DropDownList;
            DataTable gridViewSource = this.GridViewSource;
            gridViewSource.Rows[i]["Qty"] = box.Text;
            gridViewSource.Rows[i]["SN"] = box2.Text;
            gridViewSource.Rows[i]["Price"] = box3.Text;
            gridViewSource.Rows[i]["Dis"] = box4.Text;
            gridViewSource.Rows[i]["Total"] = Convert.ToDouble((decimal)((decimal.Parse(box.Text) * decimal.Parse(box3.Text)) * decimal.Parse(box4.Text))).ToString("#0.00");
            gridViewSource.Rows[i]["MainTenancePeriod"] = FunLibrary.ChkInput(box5.Text);
            gridViewSource.Rows[i]["PeriodEnd"] = FunLibrary.ChkInput(box6.Text);
            gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(box7.Text);
            gridViewSource.Rows[i]["TaxRate"] = box8.Text;
            gridViewSource.Rows[i]["Huoqi"] = box9.Text;
            gridViewSource.Rows[i]["chengse"] = textBox7.SelectedValue;
            gridViewSource.Rows[i]["baozhuang"] = textBox8.SelectedValue;


            gridViewSource.Rows[i]["TaxAmount"] = Convert.ToDouble((decimal)(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) * decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString()))).ToString("#0.00");
            gridViewSource.Rows[i]["GoodsAmount"] = Convert.ToDouble((decimal)(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString()))).ToString("#0.00");
            num += decimal.Parse(box.Text);
            num2 += (decimal.Parse(box.Text) * decimal.Parse(box3.Text)) * decimal.Parse(box4.Text);
            num3 += decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString());
        }
        this.tbAQty.Text = num.ToString("#0.00");
        this.tbAmount.Text = num2.ToString("#0.00");
        this.tbGoodsAmount.Text = num3.ToString("#0.00");
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[0].Text == "0")
        {
            e.Row.Visible = false;
        }
        e.Row.Cells[0].Visible = e.Row.Cells[1].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox box = e.Row.FindControl("tbQty") as TextBox;
            TextBox box2 = e.Row.FindControl("tbPrice") as TextBox;
            TextBox box3 = e.Row.FindControl("tbDis") as TextBox;
            Label label = e.Row.FindControl("lbAmount") as Label;
            LinkButton button = e.Row.FindControl("lbDel") as LinkButton;
            TextBox box4 = e.Row.FindControl("tbSN") as TextBox;
            TextBox box5 = e.Row.FindControl("tbTaxRate") as TextBox;
            Label label2 = e.Row.FindControl("lbTaxAmount") as Label;
            Label label3 = e.Row.FindControl("lbGoodsAmount") as Label;
            box5.Attributes.Add("oldNum", box5.Text);
            label2.Attributes.Add("oldNum", label2.Text);
            label3.Attributes.Add("oldNum", label3.Text);
            box.Attributes.Add("oldNum", box.Text);
            box2.Attributes.Add("oldNum", box2.Text);
            label.Attributes.Add("oldNum", label.Text);
            button.Attributes.Add("num", e.Row.RowIndex.ToString());
            button.Attributes.Add("onclick", "ChkAmountsel(this,'" + label.ClientID + "','" + box.ClientID + "','" + box5.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');");
            box2.Attributes.Add("onblur", "ValidateMoneysel(this,'" + box.ClientID + "','" + box3.ClientID + "','" + label.ClientID + "','" + box5.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');Caculate();");
            box.Attributes.Add("onblur", "ValidateNumsel(this,'" + box2.ClientID + "','" + box3.ClientID + "','" + label.ClientID + "','" + box5.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');Caculate();");
            box3.Attributes.Add("onchange", "ValidateMoneysel(this,'" + box.ClientID + "','" + box2.ClientID + "','" + label.ClientID + "','" + box5.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');Caculate();");
            box5.Attributes.Add("onblur", "ValidateRatesel(this,'" + box.ClientID + "','" + box3.ClientID + "','" + label.ClientID + "','" + box2.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');");
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
            e.Row.Cells[9].Attributes.Add("onclick", "ChkIDs('q" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "');");
            e.Row.Cells[9].Attributes.Add("ondblclick", "SltUnitQty1('" + box.ClientID + "');");
            HtmlInputButton button2 = e.Row.FindControl("btnsch") as HtmlInputButton;
            e.Row.Cells[11].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
            int result = 1;
            if (base.Request["f"] != null)
            {
                int.TryParse(base.Request["f"], out result);
                result++;
            }
            button2.Attributes.Add("onclick", string.Concat(new object[] { "ChkIDs('p", e.Row.Cells[0].Text, "','", e.Row.Cells[1].Text, "');SltPrice", result, "('2','", box2.ClientID, "');" }));
            e.Row.Cells[10].Text = "<a href=\"#\" onclick=\"EditSN('" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "','" + box4.ClientID + "','" + box.ClientID + "');\">编辑序列号</a>";
        }
    }

    protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.CollectData();
        DataTable gridViewSource = this.GridViewSource;
        for (int i = 0; i < gridViewSource.Rows.Count; i++)
        {
            if ((i == e.RowIndex) && (int.Parse(gridViewSource.Rows[i]["iFlag"].ToString()) == 1))
            {
                if (this.hfdellist.Value == string.Empty)
                {
                    this.hfdellist.Value = gridViewSource.Rows[i]["RecID"].ToString();
                }
                else
                {
                    this.hfdellist.Value = this.hfdellist.Value + "," + gridViewSource.Rows[i]["RecID"].ToString();
                }
            }
        }
        this.GridViewSource.Rows[e.RowIndex].Delete();
        this.BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkHead();
        int.TryParse(base.Request["id"], out this.id);
        this.ids = base.Request["ids"];
        if ((this.id == 0) && (this.ids == null))
        {
            base.Response.End();
        }
        this.f = base.Request["f"];
        if ((this.f == null) || (this.f == ""))
        {
            this.f = "";
        }
        string str = base.Request["n"];
        if ((str == "1") && (str != null))
        {
            this.btnAdd.Visible = false;
        }
        if (!base.IsPostBack)
        {
            int rightID = int.Parse((string)this.Session["Session_wtPurID"]);
            if (rightID > 0)
            {
                DALRight right = new DALRight();
                if (!right.GetRight(rightID, "xs_r4"))
                {
                    this.btnAdd.Enabled = false;
                }
                if (!right.GetRight(rightID, "xs_r5"))
                {
                    this.btnChk.Enabled = false;
                }
                if (!right.GetRight(rightID, "xs_r9"))
                {
                    this.btnPrint.Visible = false;
                }
                if (right.GetRight(rightID, "ck_r84"))
                {
                    isOutPutCheck = true;
                }
                if (right.GetRight(rightID, "jc_r37"))
                {
                    isLowPricePower = true;
                }
            }
            OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
            OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
            OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=1");
            OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
         //   ddlOperator.SelectedValue = Session["Session_wtUserID"].ToString();
            OtherFunction.BindStaff(this.ddlSndOperator, "DeptID=1 and Status=0");
            DALSell sell = new DALSell();
            if (this.id == 0)
            {
                this.id = sell.GetID(this.ids);
            }
            SellInfo model = sell.GetModel(this.id);
            if (model != null)
            {
                int num2;
                this.hfPrintID.Value = this.id.ToString();
                this.tbBillID.Text = model.BillID;
                this.tbDate.Text = model._Date;
                for (num2 = 0; num2 < this.ddlOperator.Items.Count; num2++)
                {
                    if (this.ddlOperator.Items[num2].Value == model.OperatorID.ToString())
                    {
                        this.ddlOperator.Items[num2].Selected = true;
                        break;
                    }
                }
                num2 = 0;
                while (num2 < this.ddlSndOperator.Items.Count)
                {
                    if (this.ddlSndOperator.Items[num2].Value == model.SndOperatorID.ToString())
                    {
                        this.ddlSndOperator.Items[num2].Selected = true;
                        break;
                    }
                    num2++;
                }
                this.hfOperationID.Value = model.OperationID;
              
                this.tbAutoNO.Text = model.AutoNO;
                this.hfCusID.Value = model.CustomerID.ToString();
                this.tbRemark.Text = model.Remark;
              //  this.tbLinkMan.Text = model.LinkMan;

                this.tbCusName.Text = model.CusName;
                ddl_LinkMan.Items.Clear();
                this.tbTel.Text = "";
                ListItem li0 = new ListItem("请选择联系人", "-1");
                ListItem li1 = new ListItem(model.LinkMan, model.Tel);
                ddl_LinkMan.Items.Add(li0);
                ddl_LinkMan.Items.Add(li1);
                DataTable dataTable2 = DALCommon.GetDataList("CustomerLinkMan", " CustomerID,_Name,tel_Office,tel_Mobile ", " [CustomerID]=" + this.hfCusID.Value).Tables[0];

                if (dataTable2.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTable2.Rows)
                    {
                        string tel = string.IsNullOrEmpty(item["tel_Office"].ToString()) ? item["tel_Mobile"].ToString() : item["tel_Office"].ToString();
                        ddl_LinkMan.Items.Add(new ListItem(item["_Name"].ToString(), tel));
                    }
                }

                ddl_LinkMan.SelectedValue = model.Tel;
                this.tbTel.Text = model.Tel;
                this.tbAdr.Text = model.Adr;


                ddl_isdai.SelectedValue = string.IsNullOrEmpty(model.isDai.ToString()) ? "0" : model.isDai.ToString();
                if(model.isDai==1){
                this.tbCusName2.Text = model.CusName2;
                ddl_LinkMan2.Items.Clear();
                this.tbTel2.Text = "";
                ListItem li02 = new ListItem("请选择联系人", "-1");
                ListItem li12 = new ListItem(model.LinkMan2, model.Tel2);
                ddl_LinkMan2.Items.Add(li02);
                ddl_LinkMan2.Items.Add(li12);
                DataTable dataTable22 = DALCommon.GetDataList("CustomerLinkMan", " CustomerID,_Name,tel_Office,tel_Mobile ", " [CustomerID]=" + this.hfCusID2.Value).Tables[0];

                if (dataTable22.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTable22.Rows)
                    {
                        string tel = string.IsNullOrEmpty(item["tel_Office"].ToString()) ? item["tel_Mobile"].ToString() : item["tel_Office"].ToString();
                        ddl_LinkMan2.Items.Add(new ListItem(item["_Name"].ToString(), tel));
                    }
                }

                ddl_LinkMan2.SelectedValue = model.Tel2;
                this.tbTel2.Text = model.Tel2;
                this.tbAdr2.Text = model.Adr2;
            }



                this.ddlChargeAccount.SelectedValue = model.AccountID.ToString();
                this.tbInvoiceNO.Text = model.InvoiceNO.Trim();
                this.tbInvoiceDate.Text = model.InvoiceDate.Equals(DateTime.MinValue) ? "" : model.InvoiceDate.ToString("yyyy-MM-dd");
                this.tbInvoiceAmount.Text = model.InvoiceMoney.ToString("f2");

                this.tbwangdian.Text = model.BrandName;
                DataTable tb = DALCommon.GetDataList("BranchList", "_Name, CAST(TR_jsfw as varchar(10))+'-'+CAST(TR_zzsxx as varchar(10))+'-'+CAST(TR_zzsjx as varchar(10))+'-'+CAST(TR_ptfp as varchar(10)) as TR ", " [_Name]='" + model.BrandName+"'").Tables[0];
               CreatDropList(tb);
                if(tb.Rows.Count>0)
                {
                    ddl_branchFax.SelectedValue = model.BrandTaxRateType + "-" + (model.BrandTaxRate == 0 ? 0 : Math.Round(model.BrandTaxRate, 2));
                }

                this.ddlChargeStyle.SelectedValue = model.ChargeModeID.ToString();
                this.ddlInvoiceClass.SelectedValue = model.InvoiceClassID.ToString();
                this.tbAQty.Text = "0.00";
                this.tbAmount.Text = "0.00";
                this.tbGoodsAmount.Text = "0.00";
                this.tbInCash.Text = model.InCash.ToString("#0.00");
                this.AddEmpty();
                DataTable gridViewSource = this.GridViewSource;
                DataTable table2 = DALCommon.GetDataList("xs_selldetail", "", " BillID=" + this.id.ToString()).Tables[0];
                for (num2 = 0; num2 < table2.Rows.Count; num2++)
                {
                    DataRow row = gridViewSource.NewRow();
                    row[0] = table2.Rows[num2]["StockName"].ToString();
                    row[1] = table2.Rows[num2]["GoodsNO"].ToString();
                    row[2] = table2.Rows[num2]["_Name"].ToString();
                    row[3] = table2.Rows[num2]["Spec"].ToString();
                    row[4] = table2.Rows[num2]["ProductBrand"].ToString();
                    row[5] = table2.Rows[num2]["Unit"].ToString();
                    row[6] = decimal.Parse(table2.Rows[num2]["Qty"].ToString()).ToString("#0.00");
                    row[7] = decimal.Parse(table2.Rows[num2]["Price"].ToString()).ToString("#0.00");
                    row[8] = decimal.Parse(table2.Rows[num2]["Dis"].ToString()).ToString("#0.00");
                    row[9] = decimal.Parse(table2.Rows[num2]["Total"].ToString()).ToString("#0.00");
                    row[10] = table2.Rows[num2]["SN"].ToString();
                    row[11] = table2.Rows[num2]["MainTenancePeriod"].ToString();
                    row[12] = table2.Rows[num2]["PeriodEndDate"].ToString();
                    row[13] = table2.Rows[num2]["Remark"].ToString();
                    row[14] = int.Parse(table2.Rows[num2]["StockID"].ToString());
                    row[15] = int.Parse(table2.Rows[num2]["GoodsID"].ToString());
                    row[0x10] = int.Parse(table2.Rows[num2]["UnitID"].ToString());
                    row[0x11] = int.Parse(table2.Rows[num2]["ID"].ToString());
                    row[0x12] = 1;
                    row[0x13] = decimal.Parse(table2.Rows[num2]["TaxRate"].ToString()).ToString("#0.00");
                    row[20] = decimal.Parse(table2.Rows[num2]["TaxAmount"].ToString()).ToString("#0.00");
                    row[0x15] = decimal.Parse(table2.Rows[num2]["GoodsAmount"].ToString()).ToString("#0.00");
                    row[0x16] = table2.Rows[num2]["Huoqi"].ToString();
                    row[0x17] = table2.Rows[num2]["chengse"].ToString();
                    row[0x18] = table2.Rows[num2]["baozhuang"].ToString();
                    this.tbAQty.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAQty.Text) + decimal.Parse(table2.Rows[num2]["Qty"].ToString()))).ToString("#0.00");
                    this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + decimal.Parse(table2.Rows[num2]["Total"].ToString()))).ToString("#0.00");
                   // this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(table2.Rows[num2]["GoodsAmount"].ToString()))).ToString("#0.00");

                  
                    gridViewSource.Rows.Add(row);
                }
                this.GridViewSource = gridViewSource;
                this.tbGoodsAmount.Text = this.tbAmount.Text;// ((1 + model.BrandTaxRate) * decimal.Parse(this.tbAmount.Text)).ToString("#0.00");

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
                    this.btnClean.Enabled = false;
                    this.btnAdd.Enabled = false;
                    this.btnChk.Enabled = false;
                    this.lbMod.Text = "总部只能修改自己的销售单.";
                    this.lbMod.Attributes.Add("class", "si2");
                }
                if (model.Type == 2)
                {
                    this.lbType.Text = "退货";
                }
            }
        }
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
    }


    private DataTable GridViewSource
    {
        get
        {
            if (this.ViewState["List"] == null)
            {
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("StockName", typeof(string)));
                table.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
                table.Columns.Add(new DataColumn("_Name", typeof(string)));
                table.Columns.Add(new DataColumn("Spec", typeof(string)));
                table.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
                table.Columns.Add(new DataColumn("Unit", typeof(string)));
                table.Columns.Add(new DataColumn("Qty", typeof(decimal)));
                table.Columns.Add(new DataColumn("Price", typeof(decimal)));
                table.Columns.Add(new DataColumn("Dis", typeof(decimal)));
                table.Columns.Add(new DataColumn("Total", typeof(decimal)));
                table.Columns.Add(new DataColumn("SN", typeof(string)));
                table.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
                table.Columns.Add(new DataColumn("PeriodEnd", typeof(string)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("StockID", typeof(int)));
                table.Columns.Add(new DataColumn("GoodsID", typeof(int)));
                table.Columns.Add(new DataColumn("UnitID", typeof(int)));
                table.Columns.Add(new DataColumn("RecID", typeof(int)));
                table.Columns.Add(new DataColumn("iFlag", typeof(int)));
                table.Columns.Add(new DataColumn("TaxRate", typeof(decimal)));
                table.Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));
                table.Columns.Add(new DataColumn("GoodsAmount", typeof(decimal)));
                table.Columns.Add(new DataColumn("Huoqi", typeof(string)));
                table.Columns.Add(new DataColumn("chengse", typeof(string)));
                table.Columns.Add(new DataColumn("baozhuang", typeof(string)));
                this.ViewState["List"] = table;
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
    protected void ddl_branchFax_SelectedIndexChanged(object sender, EventArgs e)
    {
        GoodTotal();
    }
    private void GoodTotal()
    {      
        decimal lv = 1;
        if (!string.IsNullOrEmpty(ddl_branchFax.SelectedValue))
        {
            lv = decimal.Parse(ddl_branchFax.SelectedValue.Split('-')[1]) + 1;
        }       
        string jshj = Math.Round(decimal.Parse(tbAmount.Text) * lv, 2).ToString("#0.00");
        tbGoodsAmount.Text = tbAmount.Text;// jshj;
        tbInCash.Text = tbAmount.Text;// jshj;
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
            CreatDropList(dataTable);
        }
    }

    private void CreatDropList(DataTable dataTable)
    {
        if (dataTable.Rows.Count > 0)
        {
            tbwangdian.Text = dataTable.Rows[0]["_Name"].ToString();
            //tbwdTaxrate.Text = dataTable.Rows[0]["TaxRate"].ToString();
            ddl_branchFax.Items.Clear();
            string[] taxs = dataTable.Rows[0]["TR"].ToString().Split('-');
            ListItem li0 = new ListItem("不含税", "no-0");
            ListItem li1 = new ListItem("技术服务费：" + Math.Round(decimal.Parse(taxs[0]) * 100, 2) + "%", "jsfw-" + Math.Round(decimal.Parse(taxs[0]), 2));
            ListItem li2 = new ListItem("增值税销项：" + Math.Round(decimal.Parse(taxs[1]) * 100, 2) + "%", "zzsxx-" + Math.Round(decimal.Parse(taxs[1]), 2));
            ListItem li3 = new ListItem("增值税进项：" + Math.Round(decimal.Parse(taxs[2]) * 100, 2) + "%", "zzsjx-" + Math.Round(decimal.Parse(taxs[2]), 2));
            ListItem li4 = new ListItem("普通发票：" + Math.Round(decimal.Parse(taxs[3]) * 100, 2) + "%", "ptfp-" + Math.Round(decimal.Parse(taxs[3]), 2));
            ddl_branchFax.Items.Add(li0);
            ddl_branchFax.Items.Add(li1);
            ddl_branchFax.Items.Add(li2);
            ddl_branchFax.Items.Add(li3);
            ddl_branchFax.Items.Add(li4);
        }
        tbGoodsAmount.Text = tbAmount.Text;
        tbInCash.Text = tbAmount.Text;
        UpdatePanel2.Update();
    }
}

