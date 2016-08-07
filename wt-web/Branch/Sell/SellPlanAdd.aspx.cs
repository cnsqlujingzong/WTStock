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

public partial class Branch_Sell_SellPlanAdd : Page, IRequiresSessionState
{
  

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
        row[12] = 0;
        row[13] = 0;
        row[14] = 0;
        row[15] = 0;
        row[0x10] = 0;
        row[0x11] = 0;
        gridViewSource.Rows.Add(row);
        this.GridViewSource = gridViewSource;
        this.BindData();
    }

    protected int BillAdd(out int iTbid)
    {
        SellPlanInfo model = new SellPlanInfo
        {
            DeptID = int.Parse((string)this.Session["Session_wtBranchID"]),
            _Date = FunLibrary.ChkInput(this.tbDate.Text),
            OperatorID = int.Parse(this.ddlOperator.SelectedValue),
            CustomerID = int.Parse(this.hfCusID.Value),
            Remark = FunLibrary.ChkInput(this.tbRemark.Text),
            ContractNO = FunLibrary.ChkInput(this.tbContractNO.Text),
            bEnd = 1,
            SndOperatorID = int.Parse(this.ddlSndOperator.SelectedValue),
            LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text),
            Tel = FunLibrary.ChkInput(this.tbTel.Text),
            Adr = FunLibrary.ChkInput(this.tbAdr.Text)
        };
        DataTable gridViewSource = this.GridViewSource;
        if (gridViewSource.Rows.Count > 0)
        {
            List<SellPlanDetailInfo> list = new List<SellPlanDetailInfo>();
            SellPlanDetailInfo item = null;
            for (int i = 0; i < gridViewSource.Rows.Count; i++)
            {
                if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
                {
                    item = new SellPlanDetailInfo
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
                        GoodsAmount = decimal.Parse(gridViewSource.Rows[i]["GoodsAmount"].ToString())
                    };
                    list.Add(item);
                }
            }
            model.SellPlanDetailInfos = list;
        }
        int num2 = new DALSellPlan().Add(model, out iTbid);
        this.hfPrintID.Value = ((int)iTbid).ToString();
        return num2;
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
                int.TryParse((string)this.Session["Session_wtUserBID"], out result);
                plan.ChkSellPlan(int.Parse((string)this.Session["Session_wtBranchID"]), num, result, out strMsg);
                this.SysInfo("window.alert('" + strMsg + "');");
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
                string text = "";
                int num3 = 0;
                if (this.ddlStock.Items.Count > 1)
                {
                    text = this.ddlStock.Items[1].Text;
                    num3 = int.Parse(this.ddlStock.Items[1].Value);
                }
                else
                {
                    this.SysInfo("window.alert('不存在仓库信息，请到仓库目录内添加！');");
                    return;
                }
                for (int i = 0; i < table3.Rows.Count; i++)
                {
                    bool flag2 = true;
                    for (int j = 1; j < gridViewSource.Rows.Count; j++)
                    {
                        if (gridViewSource.Rows[j]["GoodsID"].ToString() == table3.Rows[i]["ID"].ToString())
                        {
                            decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
                            gridViewSource.Rows[j]["Total"] = Convert.ToDouble((decimal)(decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                            decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                            this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                            flag2 = false;
                        }
                    }
                    if (flag2)
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
                        row[10] = table3.Rows[i]["MainTenancePeriod"].ToString();
                        row[11] = "";
                        row[12] = num3;
                        row[13] = int.Parse(table3.Rows[i]["ID"].ToString());
                        row[14] = int.Parse(table3.Rows[i]["GoodsUnitID"].ToString());
                        row[15] = 0;
                        row[0x10] = 0;
                        row[0x11] = num;
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
            string text = "";
            int num3 = 0;
            if (this.ddlStock.Items.Count > 1)
            {
                text = this.ddlStock.Items[1].Text;
                num3 = int.Parse(this.ddlStock.Items[1].Value);
            }
            else
            {
                this.SysInfo("window.alert('不存在仓库信息，请到仓库目录内添加！');");
                return;
            }
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                bool flag2 = true;
                for (int j = 0; j < gridViewSource.Rows.Count; j++)
                {
                    if (gridViewSource.Rows[j]["GoodsID"].ToString() == table2.Rows[i]["ID"].ToString())
                    {
                        decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
                        gridViewSource.Rows[j]["Total"] = Convert.ToDouble((decimal)(decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                        decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                        this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (decimal.Parse(gridViewSource.Rows[j]["Price"].ToString()) * decimal.Parse(gridViewSource.Rows[j]["Dis"].ToString())))).ToString("#0.00");
                        flag2 = false;
                    }
                }
                if (flag2)
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
                    row[9] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                    row[10] = table2.Rows[i]["MainTenancePeriod"].ToString();
                    row[11] = "";
                    row[12] = num3;
                    row[13] = int.Parse(table2.Rows[i]["ID"].ToString());
                    row[14] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
                    row[15] = 0;
                    row[0x10] = 0;
                    row[0x11] = num;
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

    protected void ClearText()
    {
        this.tbBillID.Text = DALCommon.CreateID(0x15, 0);
        this.tbDate.Text = DateTime.Now.ToString();
        this.ddlOperator.ClearSelection();
        string str = (string)this.Session["Session_wtUserB"];
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
        this.tbGoodsAmount.Text = "0.00";
        this.tbAdr.Text = "";
        this.tbTel.Text = "";
        this.tbLinkMan.Text = "";
        this.tbContractNO.Text = "";
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
            e.Row.Cells[10].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
            button2.Attributes.Add("onclick", "ChkIDs('p" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "');SltPrice('2','" + box2.ClientID + "');");
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
        FunLibrary.ChkBran();
        if (!base.IsPostBack)
        {
            int num2;
            int rightID = int.Parse((string)this.Session["Session_wtPurBID"]);
            if (rightID > 0)
            {
                DALRight right = new DALRight();
                if (!right.GetRight(rightID, "xs_r10"))
                {
                    this.btnAdd.Enabled = false;
                }
                if (!right.GetRight(rightID, "xs_r13"))
                {
                    this.btnChk.Enabled = false;
                }
                if (!right.GetRight(rightID, "xs_r17"))
                {
                    this.btnPrint.Visible = false;
                }
            }
            this.tbBillID.Text = DALCommon.CreateID(0x15, 0);
            this.tbDate.Text = DateTime.Now.ToString();
            OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + ((string)this.Session["Session_wtBranchID"]) + " and Status=0 and bSeller=1");
            OtherFunction.BindStocks(this.ddlStock, " DeptID=" + ((string)this.Session["Session_wtBranchID"]) + " and bStop=0 ");
            OtherFunction.BindStaff(this.ddlSndOperator, "DeptID=" + ((string)this.Session["Session_wtBranchID"]) + " and Status=0");
            string str = (string)this.Session["Session_wtUserB"];
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

