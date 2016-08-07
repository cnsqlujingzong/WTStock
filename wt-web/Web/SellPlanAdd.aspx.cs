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

public partial class Web_SellPlanAdd : Page, IRequiresSessionState
{
  
    private string price1 = string.Empty;
  
    private void AddEmpty()
    {
        DataTable gridViewSource = this.GridViewSource;
        DataRow row = gridViewSource.NewRow();
        row[0] = "";
        row[1] = "";
        row[2] = "";
        row[3] = "";
        row[4] = "";
        row[5] = 0;
        row[6] = 0;
        row[7] = 0;
        row[8] = 0;
        row[9] = "";
        row[10] = "";
        row[11] = 0;
        row[12] = 0;
        row[13] = 0;
        row[14] = 0;
        row[15] = 0;
        row[0x10] = 0;
        gridViewSource.Rows.Add(row);
        this.GridViewSource = gridViewSource;
        this.BindData();
    }

    protected int BillAdd(out int iTbid)
    {
        SellPlanInfo model = new SellPlanInfo
        {
            DeptID = 1,
            _Date = FunLibrary.ChkInput(this.tbDate.Text),
            CustomerID = int.Parse(this.hfCusID.Value),
            Remark = FunLibrary.ChkInput(this.tbRemark.Text),
            ContractNO = FunLibrary.ChkInput(this.tbContractNO.Text),
            bEnd = 1,
            LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text),
            Tel = FunLibrary.ChkInput(this.tbTel.Text),
            Adr = FunLibrary.ChkInput(this.tbAdr.Text)
        };
        DataTable gridViewSource = this.GridViewSource;
        if (gridViewSource.Rows.Count > 0)
        {
            int stockID = new DALStockList().GetStockID();
            if (stockID == -1)
            {
                this.SysInfo("window.alert('操作失败！请联系管理员添加仓库!');");
                iTbid = -1;
                return -1;
            }
            List<SellPlanDetailInfo> list2 = new List<SellPlanDetailInfo>();
            SellPlanDetailInfo item = null;
            for (int i = 0; i < gridViewSource.Rows.Count; i++)
            {
                if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
                {
                    item = new SellPlanDetailInfo
                    {
                        StockID = stockID,
                        GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()),
                        UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString()),
                        Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()),
                        Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString()),
                        Dis = decimal.Parse(gridViewSource.Rows[i]["Dis"].ToString()),
                        Remark = gridViewSource.Rows[i]["Remark"].ToString(),
                        TaxRate = decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString()),
                        TaxAmount = decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString()),
                        GoodsAmount = decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString())
                    };
                    list2.Add(item);
                }
            }
            model.SellPlanDetailInfos = list2;
        }
        int num4 = new DALSellPlan().Add(model, out iTbid);
        this.hfPrintID.Value = ((int)iTbid).ToString();
        return num4;
    }

    private void BindData()
    {
        this.gvdata.DataSource = this.GridViewSource;
        this.gvdata.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AssociatorInfo model = new DALAssociator().GetModel(int.Parse(this.Session["Session_Web_ID"].ToString()));
        DataTable table = DALCommon.GetDataList("CustomerList", "[ID]", " CustomerNO='" + model.CustomerNO + "' ").Tables[0];
        if (table.Rows.Count == 1)
        {
            this.hfCusID.Value = table.Rows[0]["ID"].ToString();
        }
        else
        {
            this.hfCusID.Value = "";
            this.SysInfo("window.alert('操作失败！请联系管理员，在“保修会员管理”中设置“关联审核”');");
            return;
        }
        this.CollectData();
        if (this.GridViewSource.Rows.Count == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
        }
        else
        {
            int num;
            if (this.BillAdd(out num) == 0)
            {
                this.SysInfo("window.alert('操作成功！该销售订单已保存');");
                this.ClearText();
            }
            else
            {
                this.SysInfo("window.alert('操作失败！请查看错误日志');");
            }
        }
    }

    protected void btnAddGoods_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        if (this.hfGoodsNO.Value != "")
        {
            str = this.hfGoodsNO.Value;
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
                            decimal Qtyd = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());
                            ++Qtyd;
                            gridViewSource.Rows[j]["Qty"] = Qtyd;
                            gridViewSource.Rows[j]["Total"] = Convert.ToDouble((decimal)(decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                            gridViewSource.Rows[j]["GoodsAmount"] = (decimal.Parse(gridViewSource.Rows[j]["GoodsAmount"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())) + ((decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString()));
                            this.tbGoodsAmount.Text = Convert.ToDouble((decimal)((decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())) + ((decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())) * decimal.Parse(gridViewSource.Rows[j]["TaxRate"].ToString())))).ToString("#0.00");
                           decimal AQty=decimal.Parse(this.tbAQty.Text);
                            ++AQty;
                            this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                            this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                            flag2 = false;
                        }
                    }
                    if (flag2)
                    {
                        DataRow row = gridViewSource.NewRow();
                        row[0] = table3.Rows[i]["GoodsNO"].ToString();
                        row[1] = table3.Rows[i]["_Name"].ToString();
                        row[2] = table3.Rows[i]["Spec"].ToString();
                        row[3] = table3.Rows[i]["ProductBrand"].ToString();
                        row[4] = table3.Rows[i]["Unit"].ToString();
                        row[5] = 1;
                        row[6] = num;
                        row[7] = result;
                        row[8] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                        row[9] = table3.Rows[i]["MainTenancePeriod"].ToString();
                        row[10] = "";
                        int num7 = -1;
                        row[11] = int.TryParse(table3.Rows[i]["StockID"].ToString(), out num7);
                        row[12] = int.Parse(table3.Rows[i]["ID"].ToString());
                        row[13] = int.Parse(table3.Rows[i]["GoodsUnitID"].ToString());
                        row[14] = 0;
                        row[15] = 0;
                        row[0x10] = num * result;
                        decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                        this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                        this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                        gridViewSource.Rows.Add(row);
                    }
                }
                this.BindData();
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
        if (this.GridViewSource.Rows.Count == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
        }
        else
        {
            int num;
            if (this.BillAdd(out num) == 0)
            {
                DALSellPlan plan = new DALSellPlan();
                string strMsg = string.Empty;
                int result = 0;
                int.TryParse((string)this.Session["Session_wtUserID"], out result);
                plan.ChkSellPlan(1, num, result, out strMsg);
                this.SysInfo("window.alert(\"" + strMsg + "\");");
                this.ClearText();
            }
            else
            {
                this.SysInfo("window.alert('操作失败！请查看错误日志');");
            }
        }
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
            DataTable table = DALCommon.GetDataList("CustomerList", "_Name,LinkMan,Tel,Adr", " [ID]=" + this.hfCusID.Value).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.tbCusName.Text = table.Rows[0]["_Name"].ToString();
                this.tbLinkMan.Text = table.Rows[0]["LinkMan"].ToString();
                this.tbTel.Text = table.Rows[0]["Tel"].ToString();
                this.tbAdr.Text = table.Rows[0]["Adr"].ToString();
            }
        }
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
                        row[0] = table3.Rows[i]["GoodsNO"].ToString();
                        row[1] = table3.Rows[i]["_Name"].ToString();
                        row[2] = table3.Rows[i]["Spec"].ToString();
                        row[3] = table3.Rows[i]["ProductBrand"].ToString();
                        row[4] = table3.Rows[i]["Unit"].ToString();
                        row[5] = 1;
                        row[6] = num;
                        row[7] = result;
                        row[8] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                        row[9] = table3.Rows[i]["MainTenancePeriod"].ToString();
                        row[10] = "";
                        int num7 = -1;
                        int.TryParse(table3.Rows[i]["StockID"].ToString(), out num7);
                        row[11] = num7;
                        row[12] = int.Parse(table3.Rows[i]["ID"].ToString());
                        row[13] = int.Parse(table3.Rows[i]["GoodsUnitID"].ToString());
                        row[14] = 0;
                        row[15] = 0;
                        row[0x10] = num;
                        decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                        this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                        this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                        gridViewSource.Rows.Add(row);
                    }
                }
                this.BindData();
            }
        }
        this.SysInfo("$('tbCon').focus();");
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
                    row[0] = table2.Rows[i]["GoodsNO"].ToString();
                    row[1] = table2.Rows[i]["_Name"].ToString();
                    row[2] = table2.Rows[i]["Spec"].ToString();
                    row[3] = table2.Rows[i]["ProductBrand"].ToString();
                    row[4] = table2.Rows[i]["Unit"].ToString();
                    row[5] = 1;
                    row[6] = num;
                    row[7] = result;
                    row[8] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                    row[9] = table2.Rows[i]["MainTenancePeriod"].ToString();
                    row[10] = "";
                    row[11] = int.Parse(table2.Rows[i]["StockID"].ToString());
                    row[12] = int.Parse(table2.Rows[i]["ID"].ToString());
                    row[13] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
                    row[14] = 0;
                    row[15] = 0;
                    row[0x10] = num;
                    decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                    this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                    this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                    gridViewSource.Rows.Add(row);
                }
            }
            this.BindData();
        }
        else
        {
            str3 = str3 + "window.alert('操作失败！没有该产品信息');";
        }
        this.SysInfo(str3);
    }

    public void ChkWebUser()
    {
        if ((this.Session["Session_Web_Name"] == null) || (this.Session["Session_Web_ID"] == null))
        {
            base.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
            base.Response.End();
        }
    }

    protected void ClearText()
    {
        this.tbBillID.Text = DALCommon.CreateID(0x15, 0);
        this.tbDate.Text = DateTime.Now.ToString();
        this.ddlOperator.ClearSelection();
        string str = (string)this.Session["Session_wtUser"];
        for (int i = 0; i < this.ddlOperator.Items.Count; i++)
        {
            if (this.ddlOperator.Items[i].Text == str)
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

    protected void CollectData()
    {
        decimal num = 0M;
        decimal num2 = 0M;
        decimal num3 = 0M;
        for (int i = 0; i < this.gvdata.Rows.Count; i++)
        {
            TextBox box = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
            TextBox box2 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
            TextBox box3 = this.gvdata.Rows[i].FindControl("tbDis") as TextBox;
            TextBox box4 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
            TextBox box5 = this.gvdata.Rows[i].FindControl("tbTaxRate") as TextBox;
            DataTable gridViewSource = this.GridViewSource;
            gridViewSource.Rows[i]["Qty"] = box.Text;
            gridViewSource.Rows[i]["Price"] = box2.Text;
            gridViewSource.Rows[i]["Dis"] = box3.Text;
            gridViewSource.Rows[i]["Total"] = Convert.ToDouble((decimal)((decimal.Parse(box.Text) * decimal.Parse(box2.Text)) * decimal.Parse(box3.Text))).ToString("#0.00");
            gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(box4.Text);
            gridViewSource.Rows[i]["TaxRate"] = box5.Text;
            gridViewSource.Rows[i]["TaxAmount"] = Convert.ToDouble((decimal)(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) * decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString()))).ToString("#0.00");
            gridViewSource.Rows[i]["GoodsAmount"] = Convert.ToDouble((decimal)(decimal.Parse(gridViewSource.Rows[i]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString()))).ToString("#0.00");
            num += decimal.Parse(box.Text);
            num2 += decimal.Parse(box.Text) * decimal.Parse(box2.Text);
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
            TextBox box4 = e.Row.FindControl("tbTaxRate") as TextBox;
            Label label2 = e.Row.FindControl("lbTaxAmount") as Label;
            Label label3 = e.Row.FindControl("lbGoodsAmount") as Label;
            box.Attributes.Add("oldNum", box.Text);
            box2.Attributes.Add("oldNum", box2.Text);
            label.Attributes.Add("oldNum", label.Text);
            box4.Attributes.Add("oldNum", box4.Text);
            label2.Attributes.Add("oldNum", label2.Text);
            label3.Attributes.Add("oldNum", label3.Text);
            button.Attributes.Add("num", e.Row.RowIndex.ToString());
            button.Attributes.Add("onclick", "ChkAmountselp(this,'" + label.ClientID + "','" + box.ClientID + "','" + box4.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');");
            box2.Attributes.Add("onblur", "ValidateMoneyselp(this,'" + box.ClientID + "','" + box3.ClientID + "','" + label.ClientID + "','" + box4.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');");
            box.Attributes.Add("onblur", "ValidateNumselp(this,'" + box2.ClientID + "','" + box3.ClientID + "','" + label.ClientID + "','" + box4.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');");
            box3.Attributes.Add("onchange", "ValidateMoneyselp(this,'" + box.ClientID + "','" + box2.ClientID + "','" + label.ClientID + "','" + box4.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');");
            box4.Attributes.Add("onblur", "ValidateRateselp(this,'" + box.ClientID + "','" + box3.ClientID + "','" + label.ClientID + "','" + box2.ClientID + "','" + label2.ClientID + "','" + label3.ClientID + "');");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex);
            e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;");
            e.Row.Cells[4].Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Cells[4].Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
            e.Row.Cells[9].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
            e.Row.Cells[10].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
        }
    }

    protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.CollectData();
        this.GridViewSource.Rows[e.RowIndex].Delete();
        this.BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ChkWebUser();
        string s = this.Session["Session_Web_ID"].ToString();
        DALAssociator associator = new DALAssociator();
        this.hfCusID.Value = associator.getCusID(int.Parse(s)).ToString();
        if (!base.IsPostBack)
        {
            int num2;
            CustomerListInfo model = new DALCustomerList().GetModel(int.Parse(this.hfCusID.Value));
            if (model != null)
            {
                this.tbCusName.Text = model._Name;
            }
            this.tbBillID.Text = DALCommon.CreateID(0x15, 0);
            this.tbDate.Text = DateTime.Now.ToString();
            string str2 = (string)this.Session["Session_wtUser"];
            for (num2 = 0; num2 < this.ddlOperator.Items.Count; num2++)
            {
                if (this.ddlOperator.Items[num2].Text == str2)
                {
                    this.ddlOperator.Items[num2].Selected = true;
                    break;
                }
            }
            for (num2 = 0; num2 < this.ddlSndOperator.Items.Count; num2++)
            {
                if (this.ddlSndOperator.Items[num2].Text == str2)
                {
                    this.ddlSndOperator.Items[num2].Selected = true;
                    break;
                }
            }
            this.tbAQty.Text = "0.00";
            this.tbAmount.Text = "0.00";
            this.tbGoodsAmount.Text = "0.00";
            this.AddEmpty();
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
                table.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
                table.Columns.Add(new DataColumn("_Name", typeof(string)));
                table.Columns.Add(new DataColumn("Spec", typeof(string)));
                table.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
                table.Columns.Add(new DataColumn("Unit", typeof(string)));
                table.Columns.Add(new DataColumn("Qty", typeof(decimal)));
                table.Columns.Add(new DataColumn("Price", typeof(decimal)));
                table.Columns.Add(new DataColumn("Dis", typeof(decimal)));
                table.Columns.Add(new DataColumn("Total", typeof(decimal)));
                table.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("StockID", typeof(int)));
                table.Columns.Add(new DataColumn("GoodsID", typeof(int)));
                table.Columns.Add(new DataColumn("UnitID", typeof(int)));
                table.Columns.Add(new DataColumn("TaxRate", typeof(decimal)));
                table.Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));
                table.Columns.Add(new DataColumn("GoodsAmount", typeof(decimal)));
                this.ViewState["List"] = table;
            }
            return (DataTable)this.ViewState["List"];
        }
        set
        {
            this.ViewState["List"] = value;
        }
    }

}

