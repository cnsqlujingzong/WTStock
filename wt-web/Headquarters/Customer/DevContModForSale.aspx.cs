using System;
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

public partial class Headquarters_Customer_DevContModForSale : Page, IRequiresSessionState
{

    private string conno;
    private string f;
    private int id;

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
        row[0x12] = 0;
        row[0x13] = 0;
        gridViewSource.Rows.Add(row);
        this.GridViewSource = gridViewSource;
        this.BindData();
    }

    private void BindData()
    {
        this.gvdata.DataSource = this.GridViewSource;
        this.gvdata.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.CollectData();
        int result = 0;
        int.TryParse(this.hfCusID.Value, out result);
        string strMsg = "";
        int num3 = 0;
        if (result > 0)
        {
            DataTable table = DALCommon.GetDataList("CustomerList", "[ID]", string.Concat(new object[] { " [ID]=", result, " and _Name='", FunLibrary.ChkInput(this.tbCusName.Text), "'" })).Tables[0];
            if (table.Rows.Count == 0)
            {
                num3 = 1;
            }
        }
        if ((result == 0) || (num3 == 1))
        {
            CustomerListInfo info = new CustomerListInfo
            {
                DeptID = 1,
                _Name = FunLibrary.ChkInput(this.tbCusName.Text),
                pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbCusName.Text)),
                LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text),
                Tel = FunLibrary.ChkInput(this.tbTel.Text),
                SellerID = new int?(int.Parse(this.ddlOperator.SelectedValue)),
                Adr = FunLibrary.ChkInput(this.tbAdr.Text)
            };
            DALCustomerList list = new DALCustomerList();
            if (list.Add(info, true, out strMsg, out result) != 0)
            {
                return;
            }
        }
        SaleContractInfo model = new SaleContractInfo();
        DALSaleContract contract = new DALSaleContract();
        model.ID = this.id;
        model.CustomerID = result;
        model.CustomerName = FunLibrary.ChkInput(this.tbCusName.Text);
        model.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
        model.Tel = FunLibrary.ChkInput(this.tbTel.Text);
        model.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
        model.ContractType = this.ddlType.SelectedValue;
        DateTime now = DateTime.Now;
        DateTime.TryParse(this.tbDate.Text, out now);
        model._Date = now;
        model.SellerID = int.Parse(this.ddlOperator.SelectedValue);
        model.ContractNO = FunLibrary.ChkInput(this.tbContract.Text);
        DateTime time2 = DateTime.Now;
        DateTime.TryParse(this.tbStartDate.Text, out time2);
        model.StartDate = time2;
        DateTime time3 = DateTime.Now;
        DateTime.TryParse(this.tbEndDate.Text, out time3);
        model.EndDate = time3;
        model.Summary = FunLibrary.ChkInput(this.tbSummary.Text);
        decimal num4 = 0M;
        decimal.TryParse(this.tbAmount1.Text, out num4);
        model.dAmount = num4;
        decimal num5 = 0M;
        decimal.TryParse(this.tbInCash.Text, out num5);
        model.dInCash = num5;
        model.Accessory = FunLibrary.ChkInput(this.hfUpload.Value);
        model.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
        if (contract.UpdateDatas(model) == 0)
        {
            this.SysInfo("window.alert('修改失败，请查看错误日志！');parent.CloseDialog('1');");
        }
        else
        {
            DALSaleContractDetail detail = new DALSaleContractDetail();
            if (detail.DeleteData(" ContractID in (" + this.id + ")") == 0)
            {
                this.SysInfo("window.alert('销售合同更改失败!请重试');parent.CloseDialog('1');");
            }
            else
            {
                DataTable gridViewSource = this.GridViewSource;
                if (gridViewSource.Rows.Count > 0)
                {
                    SaleContractDetailInfo info3 = null;
                    for (int i = 0; i < gridViewSource.Rows.Count; i++)
                    {
                        if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
                        {
                            info3 = new SaleContractDetailInfo
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
                                ContractID = this.id,
                                MainTenancePeriod = gridViewSource.Rows[i]["MainTenancePeriod"].ToString(),
                                Spec = gridViewSource.Rows[i]["Spec"].ToString(),
                                ProductBrand = gridViewSource.Rows[i]["ProductBrand"].ToString(),
                                Total = decimal.Parse(gridViewSource.Rows[i]["Total"].ToString())
                            };
                            if (detail.Add(info3) == 0)
                            {
                                this.SysInfo("window.alert('操作失败！请查看错误日志');parent.CloseDialog('1');");
                                return;
                            }
                        }
                    }
                }
                this.SysInfo("window.alert('操作成功！销售合同已更新');parent.CloseDialog('1');");
            }
        }
    }

    protected void btnClean_Click(object sender, EventArgs e)
    {
        this.GridViewSource.Clear();
        this.AddEmpty();
    }

    protected void btnCusInfo_Click(object sender, EventArgs e)
    {
        DataTable table;
        if (this.hfCusID.Value != "")
        {
            table = DALCommon.GetDataList("ks_customer", "LinkMan,Tel,Adr", " ID=" + this.hfCusID.Value).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.tbLinkMan.Text = table.Rows[0]["LinkMan"].ToString();
                this.tbTel.Text = table.Rows[0]["Tel"].ToString();
                this.tbAdr.Text = table.Rows[0]["Adr"].ToString();
                return;
            }
        }
        string str = FunLibrary.ChkInput(this.tbCusName.Text);
        if (str != "")
        {
            table = DALCommon.GetDataList("ks_customer", "[ID],LinkMan,Tel,Adr", " _Name='" + str + "'").Tables[0];
            if (table.Rows.Count > 1)
            {
                this.SysInfo("ConfCusInfo();");
            }
            else if (table.Rows.Count == 1)
            {
                this.tbLinkMan.Text = table.Rows[0]["LinkMan"].ToString();
                this.tbTel.Text = table.Rows[0]["Tel"].ToString();
                this.tbAdr.Text = table.Rows[0]["Adr"].ToString();
                this.hfCusID.Value = table.Rows[0]["ID"].ToString();
            }
            else
            {
                this.hfCusID.Value = "";
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
        DataTable gridViewSource = this.GridViewSource;
        decimal num = 0M;
        decimal num2 = 1M;
        string str2 = "零售价";
        if (str != string.Empty)
        {
            DataTable table2 = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + str + ") ").Tables[0];
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
                    for (int j = 1; j < gridViewSource.Rows.Count; j++)
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
                        row[8] = num2;
                        row[9] = Convert.ToDouble((decimal)(num * num2)).ToString("#0.00");
                        row[10] = table2.Rows[i]["MainTenancePeriod"].ToString();
                        row[11] = "";
                        row[12] = int.Parse(table2.Rows[i]["StockID"].ToString());
                        row[13] = int.Parse(table2.Rows[i]["ID"].ToString());
                        row[14] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
                        row[15] = 0;
                        row[0x10] = 0;
                        row[0x11] = 0;
                        row[0x12] = 0;
                        row[0x13] = num;
                        decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
                        this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + (num * num2))).ToString("#0.00");
                        this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + (num * num2))).ToString("#0.00");
                        gridViewSource.Rows.Add(row);
                    }
                }
                this.BindData();
            }
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
        if (this.id == 0)
        {
            this.conno = base.Request["conno"];
        }
        if (this.conno != null)
        {
            DataTable table = DALCommon.GetDataList("MaintenanceContract", "ID", "[ContractNO]='" + this.conno + "'").Tables[0];
            if (table.Rows.Count > 0)
            {
                this.id = int.Parse(table.Rows[0][0].ToString());
            }
        }
        if (this.id == 0)
        {
            base.Response.End();
        }
        this.f = base.Request["f"];
        if ((this.f == null) || (this.f == ""))
        {
            this.f = "";
        }
        string str = base.Request["n"];
        if ((str != null) && (str == "1"))
        {
            this.btnAdd.Visible = false;
        }
        if (!base.IsPostBack)
        {
            int rightID = int.Parse((string)this.Session["Session_wtPurID"]);
            if (rightID > 0)
            {
                DALRight right = new DALRight();
                if (!right.GetRight(rightID, "kh_r22"))
                {
                    this.btnAdd.Enabled = false;
                }
            }
            OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
            this.ddlType.Items.Add(new ListItem("销售"));
            this.AddEmpty();
            DataTable table2 = DALCommon.GetDataList("v_saleContract", "", "[ID]=" + this.id).Tables[0];
            if (table2.Rows.Count > 0)
            {
                int num2;
                string str2 = table2.Rows[0]["Seller"].ToString();
                for (num2 = 0; num2 < this.ddlOperator.Items.Count; num2++)
                {
                    if (this.ddlOperator.Items[num2].Text == str2)
                    {
                        this.ddlOperator.Items[num2].Selected = true;
                        break;
                    }
                }
                this.ddlType.SelectedItem.Text = table2.Rows[0]["ContractType"].ToString();
                this.tbDate.Text = table2.Rows[0]["_Date"].ToString();
                this.tbContract.Text = table2.Rows[0]["ContractNO"].ToString();
                this.tbAmount1.Text = Convert.ToDouble(table2.Rows[0]["dAmount"].ToString()).ToString("#0.00");
                this.tbInCash.Text = Convert.ToDouble(table2.Rows[0]["dInCash"].ToString()).ToString("#0.00");
                this.tbStartDate.Text = table2.Rows[0]["StartDate"].ToString();
                this.tbEndDate.Text = table2.Rows[0]["EndDate"].ToString();
                this.tbSummary.Text = table2.Rows[0]["Summary"].ToString();
                this.hfCusID.Value = table2.Rows[0]["CustomerID"].ToString();
                this.tbCusName.Text = table2.Rows[0]["CustomerName"].ToString();
                this.tbLinkMan.Text = table2.Rows[0]["LinkMan"].ToString();
                this.tbTel.Text = table2.Rows[0]["Tel"].ToString();
                this.tbAdr.Text = table2.Rows[0]["Adr"].ToString();
                this.tbRemark.Text = table2.Rows[0]["Remark"].ToString();
                this.hfUpload.Value = table2.Rows[0]["Accessory"].ToString();
                if (this.hfUpload.Value != string.Empty)
                {
                    string str3 = this.hfUpload.Value.Substring(this.hfUpload.Value.LastIndexOf('/') + 1);
                    this.dUpload.InnerHtml = "<img src='../../Public/Images/dmony.gif' /> <a href=\"" + table2.Rows[0]["Accessory"].ToString() + "\" target=_blank >" + str3 + "</a>";
                }
                if (table2.Rows[0]["Status"].ToString() == "4")
                {
                    this.btnAdd.Enabled = false;
                    this.btnClean.Enabled = false;
                    this.lbMod.Text = "该维修合同已终止，不能修改";
                    this.lbMod.Attributes.Add("class", "si2");
                }
                if (table2.Rows[0]["Status"].ToString() == "3")
                {
                    this.btnAdd.Enabled = false;
                    this.btnClean.Enabled = false;
                    this.lbMod.Text = "该维修合同已执行，不能修改";
                    this.lbMod.Attributes.Add("class", "si2");
                }
                this.tbAQty.Text = "0.00";
                this.tbAmount.Text = "0.00";
                this.tbGoodsAmount.Text = "0.00";
                DataTable gridViewSource = this.GridViewSource;
                DataTable table4 = DALCommon.GetDataList("v_saleContractDetail", "", " ContractID=" + this.id.ToString()).Tables[0];
                for (num2 = 0; num2 < table4.Rows.Count; num2++)
                {
                    decimal num8;
                    DataRow row = gridViewSource.NewRow();
                    row[0] = table4.Rows[num2]["StockName"].ToString();
                    row[1] = table4.Rows[num2]["GoodsNO"].ToString();
                    row[2] = table4.Rows[num2]["_Name"].ToString();
                    row[3] = table4.Rows[num2]["Spec"].ToString();
                    row[4] = table4.Rows[num2]["ProductBrand"].ToString();
                    row[5] = table4.Rows[num2]["Unit"].ToString();
                    row[6] = decimal.Parse(table4.Rows[num2]["Qty"].ToString()).ToString("#0.00");
                    row[7] = decimal.Parse(table4.Rows[num2]["Price"].ToString()).ToString("#0.00");
                    row[8] = decimal.Parse(table4.Rows[num2]["Dis"].ToString()).ToString("#0.00");
                    decimal.TryParse(table4.Rows[num2]["Total"].ToString(), out num8);
                    row[9] = num8.ToString("#0.00");
                    row[10] = table4.Rows[num2]["MainTenancePeriod"].ToString();
                    row[11] = table4.Rows[num2]["Remark"].ToString();
                    row[12] = int.Parse(table4.Rows[num2]["StockID"].ToString());
                    row[13] = int.Parse(table4.Rows[num2]["GoodsID"].ToString());
                    row[14] = int.Parse(table4.Rows[num2]["UnitID"].ToString());
                    row[15] = int.Parse(table4.Rows[num2]["ID"].ToString());
                    row[0x10] = 1;
                    row[0x11] = decimal.Parse(table4.Rows[num2]["TaxRate"].ToString()).ToString("#0.00");
                    row[0x12] = decimal.Parse(table4.Rows[num2]["TaxAmount"].ToString()).ToString("#0.00");
                    row[0x13] = decimal.Parse(table4.Rows[num2]["GoodsAmount"].ToString()).ToString("#0.00");
                    this.tbAQty.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAQty.Text) + decimal.Parse(table4.Rows[num2]["Qty"].ToString()))).ToString("#0.00");
                    this.tbAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbAmount.Text) + num8)).ToString("#0.00");
                    this.tbGoodsAmount.Text = Convert.ToDouble((decimal)(decimal.Parse(this.tbGoodsAmount.Text) + decimal.Parse(table4.Rows[num2]["GoodsAmount"].ToString()))).ToString("#0.00");
                    gridViewSource.Rows.Add(row);
                }
                this.GridViewSource = gridViewSource;
                this.BindData();
            }
        }
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }


    public string Str_F
    {
        get
        {
            return this.f;
        }
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
                table.Columns.Add(new DataColumn("RecID", typeof(int)));
                table.Columns.Add(new DataColumn("iFlag", typeof(int)));
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

