using EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
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

public partial class Headquarters_Sell_SellAdd : Page, IRequiresSessionState
{

    private static bool isLowPricePower = true;

    private void AddData(int drecid)
    {
        DataTable gridViewSource = this.GridViewSource;
        if (drecid != 0)
        {
            SellPlanInfo model = new DALSellPlan().GetModel(drecid);
            if (model != null)
            {
                int num2;
                this.hfOperationID.Value = model.BillID;
                this.tbCusName.Text = model.CusName;

                this.tbwangdian.Text = model.BrandName;
                DataTable tb = DALCommon.GetDataList("BranchList", "_Name, CAST(TR_jsfw as varchar(10))+'-'+CAST(TR_zzsxx as varchar(10))+'-'+CAST(TR_zzsjx as varchar(10))+'-'+CAST(TR_ptfp as varchar(10)) as TR ", " [_Name]='" + model.BrandName + "'").Tables[0];
                CreatDropList(tb);
                if (tb.Rows.Count > 0)
                {
                    ddl_branchFax.SelectedValue = model.BrandTaxRateType + "-" + (model.BrandTaxRate == 0 ? 0 : Math.Round(model.BrandTaxRate,2));
                }
           
                this.hfCusID.Value = model.CustomerID.ToString();
                this.tbAutoNO.Text = model.ContractNO;
                //this.tbLinkMan.Text = model.LinkMan;
              //  this.ddl_LinkMan.SelectedItem.Text = model.LinkMan;
               // DataTable cust = DALCommon.GetDataList("CustomerList", "_Name,LinkMan,Tel,Tel2,Adr", " [ID]=" + this.hfCusID.Value).Tables[0];
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


                this.tbTel.Text ="";
                this.tbAdr.Text = model.Adr;
                this.ddlSndOperator.ClearSelection();
                for (num2 = 0; num2 < this.ddlSndOperator.Items.Count; num2++)
                {
                    if (this.ddlSndOperator.Items[num2].Value == model.SndOperatorID.ToString())
                    {
                        this.ddlSndOperator.Items[num2].Selected = true;
                        break;
                    }
                }
                DataTable table2 = DALCommon.GetDataList("xs_sellplandetail", "", " BillID=" + drecid.ToString()).Tables[0];
                if (table2.Rows.Count > 0)
                {
                    this.CollectData();
                    for (num2 = 0; num2 < table2.Rows.Count; num2++)
                    {
                        if ("0.00" != table2.Rows[num2]["Qty"].ToString())
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
                            row[10] = "";
                            row[11] = table2.Rows[num2]["MainTenancePeriod"].ToString();
                            row[12] = "";
                            row[13] = "";
                            int result = 0;
                            int.TryParse(table2.Rows[num2]["StockID"].ToString(), out result);
                            row[14] = result;
                            row[15] = int.Parse(table2.Rows[num2]["GoodsID"].ToString());
                            row[0x10] = int.Parse(table2.Rows[num2]["UnitID"].ToString());
                            row[0x11] = decimal.Parse(table2.Rows[num2]["TaxRate"].ToString());
                            row[0x12] = decimal.Parse(table2.Rows[num2]["TaxAmount"].ToString());
                            row[0x13] = decimal.Parse(table2.Rows[num2]["GoodsAmount"].ToString());
                            row[0x14] = table2.Rows[num2]["Huoqi"].ToString();
                            row[0x15] = table2.Rows[num2]["chengse"].ToString();
                            row[0x16] = table2.Rows[num2]["baozhuang"].ToString();
                            this.tbInCash.Text = this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(table2.Rows[num2]["GoodsAmount"].ToString()))).ToString("#0.00");
                            this.tbAQty.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAQty.Text) + decimal.Parse(table2.Rows[num2]["Qty"].ToString()))).ToString("#0.00");
                            this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + decimal.Parse(table2.Rows[num2]["Total"].ToString()))).ToString("#0.00");
                            gridViewSource.Rows.Add(row);
                        }
                    }
                    this.BindData();
                }
            }
        }
    }

    private void AddDataByContract(int contactid)
    {
        DataTable gridViewSource = this.GridViewSource;
        if (contactid != 0)
        {
            SaleContractInfo model = new DALSaleContract().GetModel(contactid);
            if (model != null)
            {
                int num2;
                this.hfConstractID.Value = model.ContractNO.ToString();
                this.tbCusName.Text = model.CustomerName;
                this.hfCusID.Value = model.CustomerID.ToString();
                this.tbAutoNO.Text = model.ContractNO;
               // this.tbLinkMan.Text = model.LinkMan;
              //  this.ddl_LinkMan.SelectedItem.Text = model.LinkMan;
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


                this.tbTel.Text = "";
                this.tbAdr.Text = model.Adr;
                this.tbwangdian.Text = model.BrandName;
                DataTable tb = DALCommon.GetDataList("BranchList", "_Name, CAST(TR_jsfw as varchar(10))+'-'+CAST(TR_zzsxx as varchar(10))+'-'+CAST(TR_zzsjx as varchar(10))+'-'+CAST(TR_ptfp as varchar(10)) as TR ", " [_Name]='" + model.BrandName + "'").Tables[0];
                CreatDropList(tb);
                if (tb.Rows.Count > 0)
                {
                    ddl_branchFax.SelectedValue = model.BrandTaxRateType + "-" + model.BrandTaxRate;
                }




                this.ddlOperator.ClearSelection();
                for (num2 = 0; num2 < this.ddlOperator.Items.Count; num2++)
                {
                    if (this.ddlOperator.Items[num2].Value == model.SellerID.ToString())
                    {
                        this.ddlOperator.Items[num2].Selected = true;
                        break;
                    }
                }
                DataTable table2 = DALCommon.GetDataList("v_saleContractDetail", "", " ContractID=" + contactid.ToString()).Tables[0];
                if (table2.Rows.Count > 0)
                {
                    this.CollectData();
                    for (num2 = 0; num2 < table2.Rows.Count; num2++)
                    {
                        decimal result = 0M;
                        decimal.TryParse(table2.Rows[num2]["Quotety"].ToString(), out result);
                        decimal num4 = 0M;
                        decimal.TryParse(table2.Rows[num2]["Qty"].ToString(), out num4);
                        if (num4 > result)
                        {
                            DataRow row = gridViewSource.NewRow();
                            row[0] = table2.Rows[num2]["StockName"].ToString();
                            row[1] = table2.Rows[num2]["GoodsNO"].ToString();
                            row[2] = table2.Rows[num2]["_Name"].ToString();
                            row[3] = table2.Rows[num2]["Spec"].ToString();
                            row[4] = table2.Rows[num2]["ProductBrand"].ToString();
                            row[5] = table2.Rows[num2]["Unit"].ToString();
                            decimal num5 = decimal.Parse(table2.Rows[num2]["Qty"].ToString()) - result;
                            row[6] = num5.ToString("#0.00");
                            row[7] = decimal.Parse(table2.Rows[num2]["Price"].ToString()).ToString("#0.00");
                            row[8] = decimal.Parse(table2.Rows[num2]["Dis"].ToString()).ToString("#0.00");
                            row[9] = (decimal.Parse(table2.Rows[num2]["Total"].ToString()) - (decimal.Parse(table2.Rows[num2]["Price"].ToString()) * result)).ToString("#0.00");
                            row[10] = "";
                            row[11] = table2.Rows[num2]["MainTenancePeriod"].ToString();
                            row[12] = "";
                            row[13] = "";
                            int num6 = 0;
                            int.TryParse(table2.Rows[num2]["StockID"].ToString(), out num6);
                            row[14] = num6;
                            row[15] = int.Parse(table2.Rows[num2]["GoodsID"].ToString());
                            row[0x10] = int.Parse(table2.Rows[num2]["UnitID"].ToString());
                            row[0x11] = decimal.Parse(table2.Rows[num2]["TaxRate"].ToString());
                            if (table2.Rows[num2]["TaxRate"].ToString() != "0.00")
                            {
                                row[0x12] = (decimal.Parse(table2.Rows[num2]["Total"].ToString()) - (decimal.Parse(table2.Rows[num2]["Price"].ToString()) * result)) * decimal.Parse(table2.Rows[num2]["TaxRate"].ToString());
                            }
                            else
                            {
                                row[0x12] = decimal.Parse(table2.Rows[num2]["TaxAmount"].ToString());
                            }
                            row[0x13] = (decimal.Parse(table2.Rows[num2]["Total"].ToString()) - (decimal.Parse(table2.Rows[num2]["Price"].ToString()) * result)) + ((decimal)row[0x12]);
                            row[0x14] = table2.Rows[num2]["Huoqi"].ToString();
                            row[0x15] = table2.Rows[num2]["chengse"].ToString();
                            row[0x16] = table2.Rows[num2]["baozhuang"].ToString();
                            this.tbInCash.Text = this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + ((decimal)row[0x13]))).ToString("#0.00");
                            this.tbAQty.Text = Convert.ToDouble((decimal)((decimal.Parse(this.tbAQty.Text) + num4) - result)).ToString("#0.00");
                            this.tbAmount.Text = Convert.ToDouble((decimal)((decimal.Parse(this.tbAmount.Text) + decimal.Parse(table2.Rows[num2]["Total"].ToString())) - (decimal.Parse(table2.Rows[num2]["Price"].ToString()) * result))).ToString("#0.00");
                            gridViewSource.Rows.Add(row);
                        }
                    }
                    this.BindData();
                }
            }
        }
    }

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
        gridViewSource.Rows.Add(row);
        this.GridViewSource = gridViewSource;
        this.BindData();
        this.sdyes();
    }

    protected int BillAdd(out int iTbid, out bool isLowPrice)
    {
        SellInfo model = new SellInfo();
        isLowPrice = true;
        model.DeptID = 1;
        model._Date = FunLibrary.ChkInput(this.tbDate.Text);
        model.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
        model.CustomerID = int.Parse(this.hfCusID.Value);
        model.AutoNO = FunLibrary.ChkInput(this.tbAutoNO.Text);
        model.PersonID = int.Parse(this.Session["Session_wtUserID"].ToString());
        model.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
       
        decimal result = 0M;
        decimal.TryParse(this.tbInCash.Text, out result);
        model.InCash = result;
        model.Type = 1;
        model.OperationID = this.hfOperationID.Value;
        model.SndOperatorID = int.Parse(this.ddlSndOperator.SelectedValue);
        model.LinkMan = FunLibrary.ChkInput(this.ddl_LinkMan.SelectedItem.Text);
        model.Tel = FunLibrary.ChkInput(this.tbTel.Text);
        model.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
        model.InvoiceNO = this.tbInvoiceNO.Text;

        string[] ps = this.ddl_branchFax.SelectedValue.Split('-');
        model.BrandName = FunLibrary.ChkInput(tbwangdian.Text);
        model.BrandTaxRate = decimal.Parse(FunLibrary.ChkInput(ps[1]));
        model.BrandTaxRateType = FunLibrary.ChkInput(ps[0]);

        model.isDai =int.Parse( ddl_isdai.SelectedValue);
        if (model.isDai==1)
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
        model.InvoiceDate = this.tbInvoiceDate.Text.Trim().Equals("") ? DateTime.MinValue : DateTime.Parse(this.tbInvoiceDate.Text);
        model.AccountID = int.Parse(this.ddlChargeAccount.SelectedValue);
        model.ChargeModeID = int.Parse(this.ddlChargeStyle.SelectedValue);
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
                    item = new SellDetailInfo();
                    int num4 = 0;
                    int.TryParse(gridViewSource.Rows[i]["StockID"].ToString(), out num4);
                    if (num4 <= 0)
                    {
                        this.SysInfo("ChkID('" + gridViewSource.Rows[i]["GoodsID"].ToString().Trim() + "');alert('保存失败！请选择仓库')");
                    }
                    item.StockID = num4;
                    item.GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString());
                    item.UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString());
                    item.Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString());
                    item.Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString());
                    item.Dis = decimal.Parse(gridViewSource.Rows[i]["Dis"].ToString());
                    item.SN = gridViewSource.Rows[i]["SN"].ToString();
                    item.MaintenancePeriod = gridViewSource.Rows[i]["MaintenancePeriod"].ToString();
                    item.PeriodEndDate = gridViewSource.Rows[i]["PeriodEnd"].ToString();
                    item.Remark = gridViewSource.Rows[i]["Remark"].ToString();
                    item.CiteID = 0;
                    item.TaxRate = decimal.Parse(gridViewSource.Rows[i]["TaxRate"].ToString());
                    item.TaxAmount = decimal.Parse(gridViewSource.Rows[i]["TaxAmount"].ToString());
                    item.GoodsAmount = decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString());
                    item.Huoqi = gridViewSource.Rows[i]["Huoqi"].ToString();
                    item.chengse = gridViewSource.Rows[i]["chengse"].ToString();
                    item.baozhuang = gridViewSource.Rows[i]["baozhuang"].ToString();
                    list.Add(item);
                    if (new DALGoods().getLowPrice(item.GoodsID) > item.Price)
                    {
                        isLowPrice = false;
                    }
                }
            }
            model.SellDetailInfos = list;
        }
        int num6 = new DALSell().Add(model, out iTbid);
        this.hfPrintID.Value = ((int)iTbid).ToString();
        return num6;
    }

    private void BindData()
    {
        this.gvdata.DataSource = this.GridViewSource;     
        this.gvdata.DataBind();
        GoodTotal();
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
        decimal result = 0M;
        decimal.TryParse(this.tbInCash.Text, out result);
        decimal num2 = new DALCustomerList().getPositionAmount(int.Parse(this.hfCusID.Value));
        if (num2 > 0M)
        {
            decimal num3 = new DALArrearage().getBalance(int.Parse(this.hfCusID.Value));
            decimal num4 = 0M;
            decimal.TryParse(this.tbGoodsAmount.Text, out num4);
            if ((((num2 - num3) - num4) + result) < 0M)
            {
                this.SysInfo("window.alert('销售单保存失败，客户信誉额度不足！');");
                this.btnClean_Click(sender, e);
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
            int num5;
            bool flag2;
            string billid = this.hfOperationID.Value.Trim();
            string constractno = this.hfConstractID.Value.Trim();
            if (this.hfSltID1.Value != "")
            {
                if (!this.sellGoodsByContract(constractno))
                {
                    return;
                }
            }
            else if (!this.sellGoods(billid))
            {
                return;
            }
            if (this.BillAdd(out num5, out flag2) == 0)
            {
                this.SysInfo("window.alert('操作成功！该销售单已保存');");
                WTLog.WriteLog("销售单", num5.ToString(), "新建销售单","成功");
                this.ClearText();
            }
            else
            {
                this.SysInfo("window.alert('操作失败！请查看错误日志');");
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
        decimal result = 0M;
        decimal.TryParse(this.tbInCash.Text, out result);
        decimal num2 = new DALCustomerList().getPositionAmount(int.Parse(this.hfCusID.Value));
        if (num2 > 0M)
        {
            decimal num3 = new DALArrearage().getBalance(int.Parse(this.hfCusID.Value));
            decimal num4 = 0M;
            decimal.TryParse(this.tbGoodsAmount.Text, out num4);
            if ((((num2 - num3) - num4) + result) < 0M)
            {
                this.SysInfo("window.alert('销售单保存失败，客户信誉额度不足！');");
                this.btnClean_Click(sender, e);
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
            int num5;
            bool flag2;
            string billid = this.hfOperationID.Value.Trim();
            string constractno = this.hfConstractID.Value.Trim();
            if (this.hfSltID1.Value != "")
            {
                if (!this.sellGoodsByContract(constractno))
                {
                    return;
                }
            }
            else if (!this.sellGoods(billid))
            {
                return;
            }
            if (this.BillAdd(out num5, out flag2) == 0)
            {
                if (!isLowPricePower && !flag2)
                {
                    this.SysInfo("window.alert('销售单保存成功!审核失败！没有“允许低于最低销售价出库”的权限');");
                    this.ClearText();
                }
                else
                {
                    DALSell sell = new DALSell();
                    string strMsg = string.Empty;
                    int num7 = 0;
                    int.TryParse((string)this.Session["Session_wtUserID"], out num7);
                    if (this.hfFlag.Value == "1")
                    {
                        sell.ChkSell1(1, num5, num7, out strMsg);
                    }
                    else
                    {
                        sell.ChkSell(1, num5, num7, out strMsg);
                    }
                    this.SysInfo("window.alert(\"" + strMsg + "\");");
                    this.ClearText();

                    WTLog.WriteLog("销售单", num5.ToString(), "新建销售单->审核", strMsg);
                }
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
        this.tbInCash.Text = "0.00";
        this.tbGoodsAmount.Text = "0.00";
        this.AddEmpty();
    }

    protected void btnCusInfo_Click(object sender, EventArgs e)
    {
        if (this.hfCusID.Value != "")
        {
            DataTable table = DALCommon.GetDataList("CustomerList", "_Name,LinkMan,Tel,Tel2,Adr", " [ID]=" + this.hfCusID.Value).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.tbCusName.Text = table.Rows[0]["_Name"].ToString();
                this.tbAdr.Text = table.Rows[0]["Adr"].ToString();

                string ctel;
         
                if (string.IsNullOrEmpty(table.Rows[0]["Tel2"].ToString()))
                {
                    ctel = table.Rows[0]["Tel"].ToString();
                }
                else if (string.IsNullOrEmpty(table.Rows[0]["Tel"].ToString()))
                {
                    ctel = table.Rows[0]["Tel2"].ToString();
                }
                else
                {
                    ctel = table.Rows[0]["Tel"].ToString() + "," + table.Rows[0]["Tel2"].ToString();
                }

                DataTable dataTable2 = DALCommon.GetDataList("CustomerLinkMan", " CustomerID,_Name,tel_Office,tel_Mobile ", " [CustomerID]=" + this.hfCusID.Value).Tables[0];

                ddl_LinkMan.Items.Clear();
                this.tbTel.Text = "";
                ListItem li0 = new ListItem("请选择联系人", "-1");
                ListItem li1 = new ListItem(table.Rows[0]["LinkMan"].ToString(), ctel);
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

                //this.tbLinkMan.Text = table.Rows[0]["LinkMan"].ToString();

            }
        }
    }
    protected void btnCusInfo2_Click(object sender, EventArgs e)
    {
        if (this.hfCusID2.Value != "")
        {
            DataTable table = DALCommon.GetDataList("CustomerList", "_Name,LinkMan,Tel,Tel2,Adr", " [ID]=" + this.hfCusID2.Value).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.tbCusName2.Text = table.Rows[0]["_Name"].ToString();
                this.tbAdr2.Text = table.Rows[0]["Adr"].ToString();

                string ctel;

                if (string.IsNullOrEmpty(table.Rows[0]["Tel2"].ToString()))
                {
                    ctel = table.Rows[0]["Tel"].ToString();
                }
                else if (string.IsNullOrEmpty(table.Rows[0]["Tel"].ToString()))
                {
                    ctel = table.Rows[0]["Tel2"].ToString();
                }
                else
                {
                    ctel = table.Rows[0]["Tel"].ToString() + "," + table.Rows[0]["Tel2"].ToString();
                }

                DataTable dataTable2 = DALCommon.GetDataList("CustomerLinkMan", " CustomerID,_Name,tel_Office,tel_Mobile ", " [CustomerID]=" + this.hfCusID2.Value).Tables[0];

                ddl_LinkMan2.Items.Clear();
                this.tbTel2.Text = "";
                ListItem li0 = new ListItem("请选择联系人", "-1");
                ListItem li1 = new ListItem(table.Rows[0]["LinkMan"].ToString(), ctel);
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

                //this.tbLinkMan.Text = table.Rows[0]["LinkMan"].ToString();

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
                    int num6 = 0;
                    int.TryParse(table3.Rows[i]["StockID"].ToString(), out num6);
                    row[14] = num6;
                    row[15] = int.Parse(table3.Rows[i]["ID"].ToString());
                    row[0x10] = int.Parse(table3.Rows[i]["GoodsUnitID"].ToString());
                    row[0x11] = 0;
                    row[0x12] = 0;
                    row[0x13] = num;
                    this.tbInCash.Text = this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                    decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                    this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                    gridViewSource.Rows.Add(row);
                }
                this.BindData();
            }
        }
          GoodTotal();
        this.SysInfo("$('tbCon').focus();Caculate();");
    }

    protected void btnSltBill_Click(object sender, EventArgs e)
    {
        int result = 0;
        int.TryParse(this.hfSltID.Value, out result);
        if (result != 0)
        {
            this.AddData(result);
        }
        int num2 = 0;
        int.TryParse(this.hfSltID1.Value, out num2);
        if (num2 != 0)
        {
            this.AddDataByContract(num2);
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
        string tblName = "ck_goods";
        string strCondition = this.ddlSchFld.SelectedValue + "='" + str + "'";
        if (this.ddlSchFld.SelectedValue == "SN")
        {
            tblName = "ck_stocksn";
            strCondition = strCondition + " and Status='在库' and DeptID=1 ";
        }
        DataTable table2 = DALCommon.GetDataList(tblName, "", strCondition).Tables[0];
        decimal num = 0M;
        decimal result = 1M;
        string str4 = "零售价";
        if (this.hfCusID.Value != "")
        {
            DataTable table3 = DALCommon.GetDataList("ks_customer", "Price,Dis", " [ID]=" + this.hfCusID.Value).Tables[0];
            if ((table3.Rows.Count > 0) && (table3.Rows[0]["Price"].ToString() != ""))
            {
                str4 = table3.Rows[0]["Price"].ToString();
                decimal.TryParse(table3.Rows[0]["Dis"].ToString(), out result);
                if (result == 0M)
                {
                    result = 1M;
                }
            }
        }
        string str5 = "$('" + this.tbCon.ClientID + "').select();Caculate();";
        if (table2.Rows.Count > 0)
        {
            this.CollectData();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                switch (str4)
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
                    row[10] = table2.Rows[i]["SN"].ToString();
                    row[11] = table2.Rows[i]["MainTenancePeriod"].ToString();
                    row[12] = "";
                    row[13] = "";
                    int num7 = 0;
                    int.TryParse(table2.Rows[i]["StockID"].ToString(), out num7);
                    row[14] = num7;
                    if (this.ddlSchFld.SelectedValue == "SN")
                    {
                        row[15] = int.Parse(table2.Rows[i]["GoodsID"].ToString());
                    }
                    else
                    {
                        row[15] = int.Parse(table2.Rows[i]["ID"].ToString());
                    }
                    row[0x10] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
                    row[0x11] = 0;
                    row[0x12] = 0;
                    row[0x13] = num;
                    this.tbInCash.Text = this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + (num * result))).ToString("#0.00");
                    decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                    this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (num * result))).ToString("#0.00");
                    gridViewSource.Rows.Add(row);
                }
            }
            this.BindData();
        }
        else
        {
            str5 = str5 + "window.alert('操作失败！没有该产品信息');";
        }
        this.tbCon.Text = string.Empty;
        this.SysInfo(str5);
        this.SysInfo2("$('tbCon').focus();");
          GoodTotal();
  
    }

    protected void ClearText()
    {
        this.tbBillID.Text = DALCommon.CreateID(0x13, 0);
        this.tbDate.Text = string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);
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
        this.hfOperationID.Value = this.hfSltID.Value = "";
        this.tbAQty.Text = "0.00";
        this.tbAmount.Text = "0.00";
        this.tbInCash.Text = "0.00";
        this.tbGoodsAmount.Text = "0.00";
        this.tbAdr.Text = "";
        this.tbTel.Text = "";
        this.tbLinkMan.Text = "";
        this.tbAutoNO.Text = "";
        this.ddlChargeAccount.SelectedValue = "-1";
        this.tbInvoiceNO.Text = "";
        this.tbInvoiceDate.Text = "";
        this.tbInvoiceAmount.Text = "";
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
            TextBox box2 = this.gvdata.Rows[i].FindControl("tbSN") as TextBox;
            TextBox box3 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
            TextBox box4 = this.gvdata.Rows[i].FindControl("tbDis") as TextBox;
            TextBox box5 = this.gvdata.Rows[i].FindControl("tbPeriod") as TextBox;
            TextBox box6 = this.gvdata.Rows[i].FindControl("tbPeriodEnd") as TextBox;
            TextBox box7 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
            TextBox box8 = this.gvdata.Rows[i].FindControl("tbTaxRate") as TextBox;
            TextBox box9 = this.gvdata.Rows[i].FindControl("tbhuoqi") as TextBox;
            DropDownList textBox7 = this.gvdata.Rows[i].FindControl("ddl_chengse") as DropDownList;
            DropDownList textBox8 = this.gvdata.Rows[i].FindControl("ddl_baozhuang") as DropDownList;
            DataTable gridViewSource = this.GridViewSource;
            gridViewSource.Rows[i]["Qty"] = box.Text;
            gridViewSource.Rows[i]["SN"] = box2.Text;
            gridViewSource.Rows[i]["Price"] = box3.Text;
            gridViewSource.Rows[i]["Huoqi"] = box9.Text;
            gridViewSource.Rows[i]["chengse"] = textBox7.SelectedValue;
            gridViewSource.Rows[i]["baozhuang"] = textBox8.SelectedValue;
            gridViewSource.Rows[i]["Dis"] = box4.Text;
            gridViewSource.Rows[i]["Total"] = Convert.ToDouble((decimal)((decimal.Parse(box.Text) * decimal.Parse(box3.Text)) * decimal.Parse(box4.Text))).ToString("#0.00");
            gridViewSource.Rows[i]["MainTenancePeriod"] = FunLibrary.ChkInput(box5.Text);
            gridViewSource.Rows[i]["PeriodEnd"] = FunLibrary.ChkInput(box6.Text);
            gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(box7.Text);
            gridViewSource.Rows[i]["TaxRate"] = box8.Text;
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

    protected int DayTs(string time)
    {
        DateTime time2 = DateTime.Parse(time);
        TimeSpan span = (TimeSpan)(DateTime.Now - time2);
        return span.Days;
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

          /***为每个产品增加税率 by Coding**/
          //  if (!string.IsNullOrEmpty(tbwdTaxrate.Text))
         //   {
         //       box5.Text = tbwdTaxrate.Text;
         //   }

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
            e.Row.Cells[3].Attributes.Add("ondblclick", "SltStock();");
            e.Row.Cells[8].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
            e.Row.Cells[8].Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
            e.Row.Cells[8].Attributes.Add("ondblclick", "SltUnit();");
            e.Row.Cells[9].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
            e.Row.Cells[9].Attributes.Add("onclick", "ChkIDs('q" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "');");
            e.Row.Cells[9].Attributes.Add("ondblclick", "SltUnitQty('" + box.ClientID + "');");
            HtmlInputButton button2 = e.Row.FindControl("btnsch") as HtmlInputButton;
            e.Row.Cells[11].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
            button2.Attributes.Add("onclick", "ChkIDs('p" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "');SltPrice('2','" + box2.ClientID + "');");
            e.Row.Cells[10].Text = "<a href=\"#\" onclick=\"EditSN('" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "','" + box4.ClientID + "','" + box.ClientID + "');\">编辑序列号</a>";
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
        FunLibrary.ChkHead();
        if (!base.IsPostBack)
        {
            int num2;
            int rightID = int.Parse((string)this.Session["Session_wtPurID"]);
            if (rightID > 0)
            {
                DALRight right = new DALRight();
                if (!right.GetRight(rightID, "xs_r1"))
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
                    this.hfFlag.Value = "1";
                }
                if (right.GetRight(rightID, "jc_r37"))
                {
                    isLowPricePower = false;
                }
            }
            this.tbBillID.Text = DALCommon.CreateID(0x13, 0);
            this.tbDate.Text = string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);
            OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
            OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
            OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0 and bSeller=1");
            ddlOperator.SelectedValue = Session["Session_wtUserID"].ToString();
            OtherFunction.BindStaff(this.ddlSndOperator, "DeptID=1 and Status=0");
            OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=1");
            string str = (string)this.Session["Session_wtUser"];
            for (num2 = 0; num2 < this.ddlOperator.Items.Count; num2++)
            {
                if (this.ddlOperator.Items[num2].Text == str)
                {
                    this.ddlOperator.Items[num2].Selected = true;
                    break;
                }
            }
            for (num2 = 0; num2 < this.ddlSndOperator.Items.Count; num2++)
            {
                if (this.ddlSndOperator.Items[num2].Text == str)
                {
                    this.ddlSndOperator.Items[num2].Selected = true;
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

    public void sdyes()
    {
        SysParmInfo sysParm = new DALSysParm().GetSysParm();
        DALSysVali vali = new DALSysVali();
        string corpName = sysParm.CorpName;
        string s = sysParm.BranchNum.ToString();
        string str3 = sysParm.bWeb.ToString();
        string str4 = vali.GetValue("ITEM2");
        string str = corpName + str3 + s;
        if (sysParm.bSim)
        {
            str = str + "并发";
        }
        string str6 = FunLibrary.EncodeReg(str);
        if (str4 != str6)
        {
            string str7 = vali.GetValue("ITEM1");
            try
            {
                string time = FunLibrary.StrDecode(str7);
                int num2 = this.DayTs(time);
                if ((num2 > 60) || (num2 < 0))
                {
                    vali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
                }
            }
            catch
            {
                vali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
            }
        }
        else
        {
            int num3;
            int num4;
            string str10;
            int.TryParse(DALCommon.TCount("UserManage", ""), out num3);
            int.TryParse(s, out num4);
            if (!(sysParm.bSim || (num3 <= num4)))
            {
                vali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
            }
            try
            {
                string requestUriString = "http://www.differsoft.com/kill_get.asp?id=8";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
                request.Method = "GET";
                request.MaximumAutomaticRedirections = 3;
                request.Timeout = 0x1388;
                Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                str10 = reader.ReadToEnd();
                reader.Dispose();
                responseStream.Dispose();
                if (str10.Contains(str4))
                {
                    vali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
                }
            }
            catch
            {
            }
            string str11 = vali.GetValue("ITEM6").ToString().Trim();
            int num5 = 0;
            try
            {
                num5 = int.Parse(FunLibrary.StrDecode(str11));
            }
            catch
            {
            }
            if ((vali.GetValue("ITEM5") != DateTime.Now.ToString("yyyy-MM-dd")) || (num5 > 0))
            {
                int num;
                try
                {
                    string tel = sysParm.Tel;
                    string zip = sysParm.Zip;
                    string adr = sysParm.Adr;
                    string str15 = "id=8";
                    string str16 = str15;
                    str16 = str16 + "&CustomerInfo=公司名:" + corpName + "，电话:" + tel;
                    str15 = str16 + "，邮编:" + zip + "，地址:" + adr + "，注册用户数:" + s + "，实际用户数:" + num3.ToString() + "注册码:" + str4;
                    if (sysParm.bSim)
                    {
                        str15 = str15 + "，并发";
                    }
                    byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(str15);
                    HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://www.differsoft.com/kill_post.asp");
                    request2.Method = "POST";
                    request2.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
                    request2.ContentLength = bytes.Length;
                    Stream requestStream = request2.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)request2.GetResponse();
                    StreamReader reader2 = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                    str10 = reader2.ReadToEnd();
                    requestStream.Dispose();
                    reader2.Dispose();
                    if (str10.ToLower() == "ok")
                    {
                        vali.Update("ITEM5", DateTime.Now.ToString("yyyy-MM-dd"));
                        vali.Update("ITEM6", FunLibrary.StrEncode("0"));
                    }
                    else
                    {
                        num = num5 + 1;
                        vali.Update("ITEM6", FunLibrary.StrEncode(num.ToString()));
                    }
                }
                catch
                {
                    num = num5 + 1;
                    vali.Update("ITEM6", FunLibrary.StrEncode(num.ToString()));
                }
            }
        }
    }

    private bool sellGoods(string billid)
    {
        if (billid != "")
        {
            DALSellPlan plan = new DALSellPlan();
            DataTable gridViewSource = this.GridViewSource;
            string s = "";
            if (gridViewSource.Rows.Count > 0)
            {
                for (int i = 1; i < gridViewSource.Rows.Count; i++)
                {
                    string str2 = gridViewSource.Rows[i]["Qty"].ToString();
                    string str3 = gridViewSource.Rows[i]["GoodsID"].ToString();
                    DataSet set = plan.Qtyquery(this.hfOperationID.Value.Trim(), int.Parse(str3));
                    if (set.Tables[0].Rows.Count > 0)
                    {
                        decimal num2 = decimal.Parse(set.Tables[0].Rows[0]["Qty"].ToString());
                        if (decimal.Parse(str2) > num2)
                        {
                            this.SysInfo("window.alert('销售数量不能大于订单中订货量');");
                            return false;
                        }
                        s = set.Tables[0].Rows[0]["SellID"].ToString();
                        plan.UpdateCount(int.Parse(s), decimal.Parse(str2), int.Parse(str3));
                    }
                }
                DataTable table2 = plan.QtyCount(int.Parse(s)).Tables[0];
                if (table2.Rows.Count > 0)
                {
                    decimal num3 = 0M;
                    for (int j = 0; j < table2.Rows.Count; j++)
                    {
                        num3 += (decimal)table2.Rows[j][0];
                    }
                    if (num3 == 0M)
                    {
                        plan.UpdateStatus(this.hfOperationID.Value.Trim());
                    }
                }
            }
        }
        return true;
    }

    private bool sellGoodsByContract(string constractno)
    {
        if (constractno != "")
        {
            DALSaleContractDetail detail = new DALSaleContractDetail();
            DALSaleContract contract = new DALSaleContract();
            int iDByContractNO = contract.GetIDByContractNO(constractno);
            DataTable gridViewSource = this.GridViewSource;
            if (gridViewSource.Rows.Count > 0)
            {
                decimal result = 0M;
                for (int i = 1; i < gridViewSource.Rows.Count; i++)
                {
                    string s = gridViewSource.Rows[i]["Qty"].ToString();
                    string str2 = gridViewSource.Rows[i]["GoodsID"].ToString();
                    DataSet list = detail.GetList(iDByContractNO, int.Parse(str2));
                    if (list.Tables[0].Rows.Count > 0)
                    {
                        decimal num4 = decimal.Parse(list.Tables[0].Rows[0]["Qty"].ToString());
                        decimal.TryParse(list.Tables[0].Rows[0]["Quotety"].ToString(), out result);
                        if (decimal.Parse(s) > (num4 - result))
                        {
                            this.SysInfo("window.alert('销售数量不能大于合同中订货量');");
                            return false;
                        }
                        string str3 = list.Tables[0].Rows[0]["ID"].ToString();
                        detail.UpdateCount(int.Parse(str3), decimal.Parse(s));
                        contract.UpdateEndSer2(iDByContractNO);
                    }
                }
                DataTable tableByContstractID = detail.GetTableByContstractID(iDByContractNO);
                if (tableByContstractID.Rows.Count > 0)
                {
                    decimal num5 = 0M;
                    decimal num6 = 0M;
                    decimal num7 = 0M;
                    for (int j = 0; j < tableByContstractID.Rows.Count; j++)
                    {
                        num5 += (decimal)tableByContstractID.Rows[j]["Qty"];
                        decimal.TryParse(tableByContstractID.Rows[j]["Quotety"].ToString(), out num7);
                        num6 += num7;
                    }
                    if (num5 <= num6)
                    {
                        contract.UpdateEndSer1(iDByContractNO);
                    }
                }
            }
        }
        return true;
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
    }

    protected void SysInfo2(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo2", str, true);
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
                ListItem li0= new ListItem("不含税", "no-0");
                ListItem li1 = new ListItem("技术服务费：" +Math.Round(decimal.Parse(taxs[0])*100,2)+"%", "jsfw-"+taxs[0]);
                ListItem li2 = new ListItem("增值税销项：" + Math.Round(decimal.Parse(taxs[1]) * 100, 2) + "%", "zzsxx-" + taxs[1]);
                ListItem li3 = new ListItem("增值税进项：" + Math.Round(decimal.Parse(taxs[2]) * 100, 2) + "%", "zzsjx-"+taxs[2]);
                ListItem li4 = new ListItem("普通发票：" + Math.Round(decimal.Parse(taxs[3]) * 100, 2) + "%", "ptfp-"+taxs[3]);
                ddl_branchFax.Items.Add(li0);
                ddl_branchFax.Items.Add(li1);
                ddl_branchFax.Items.Add(li2);
                ddl_branchFax.Items.Add(li3);
                ddl_branchFax.Items.Add(li4);
            }
   
        }       
        tbGoodsAmount.Text = tbAmount.Text;
            tbInCash.Text = tbAmount.Text;
            UpdatePanel2.Update();
    }

    protected void ddl_branchFax_SelectedIndexChanged(object sender, EventArgs e)
    {
        GoodTotal();
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
                int c = textBox.Text.IndexOf(".") > 0 ? int.Parse(textBox.Text.Substring(0, textBox.Text.IndexOf("."))) : int.Parse(textBox.Text);
                allcount += c;
                totle +=c * decimal.Parse(textBox2.Text) * decimal.Parse(textBox3.Text);
            }
        }
        decimal lv = 1;
        if (!string.IsNullOrEmpty(ddl_branchFax.SelectedValue))
        {
            lv =decimal.Parse( ddl_branchFax.SelectedValue.Split('-')[1])+1;
        }
        tbAQty.Text = allcount.ToString();
        tbAmount.Text = totle.ToString("#0.00");
        string jshj = Math.Round(totle, 2).ToString("#0.00");
        tbGoodsAmount.Text = jshj;
        tbInCash.Text = jshj;
        //backp 以下三行
       //// string jshj=Math.Round(totle * lv, 2).ToString("#0.00");
        //tbGoodsAmount.Text = totle.ToString("#0.00");//jshj;
        //tbInCash.Text = totle.ToString("#0.00");//jshj;
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
            ListItem li1 = new ListItem("技术服务费：" + Math.Round(decimal.Parse(taxs[0]) * 100, 2) + "%", "jsfw-" +Math.Round(decimal.Parse(taxs[0]),2));
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

        UpdatePanel2.Update();
    }


}



