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

public partial class Headquarters_Services_ServicesOp : Page, IRequiresSessionState
{
 
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
        row[6] = "";
        row[7] = gridViewSource.Rows.Count;
        row[8] = 0;
        row[9] = 0;
        gridViewSource.Rows.Add(row);
        this.GridViewSource = gridViewSource;
        this.BindData();
    }

    private void AddEmptyI()
    {
        DataTable gridViewSourceI = this.GridViewSourceI;
        DataRow row = gridViewSourceI.NewRow();
        row[0] = "";
        row[1] = "";
        row[2] = 0;
        row[3] = 0;
        row[4] = "";
        row[5] = "";
        row[6] = 0;
        row[7] = "";
        row[8] = 0;
        row[9] = 0;
        row[10] = 0;
        gridViewSourceI.Rows.Add(row);
        this.GridViewSourceI = gridViewSourceI;
        this.BindDataI();
    }

    private void AddEmptyM()
    {
        DataTable gridViewSourceM = this.GridViewSourceM;
        DataRow row = gridViewSourceM.NewRow();
        row[0] = "";
        row[1] = "";
        row[2] = "";
        row[3] = "";
        row[4] = "";
        row[5] = 0;
        row[6] = 0;
        row[7] = 0;
        row[8] = "";
        row[9] = "";
        row[10] = "";
        row[11] = "";
        row[12] = "";
        row[13] = 0;
        row[14] = 0;
        row[15] = 0;
        row[0x10] = 0;
        row[0x11] = false;
        row[0x12] = 0;
        row[0x13] = 0;
        row[20] = 0;
        gridViewSourceM.Rows.Add(row);
        this.GridViewSourceM = gridViewSourceM;
        this.BindDataM();
    }

    private void BindData()
    {
        this.GridView1.DataSource = this.GridViewSource;
        this.GridView1.DataBind();
    }

    private void BindDataI()
    {
        this.GridView3.DataSource = this.GridViewSourceI;
        this.GridView3.DataBind();
    }

    private void BindDataM()
    {
        this.GridView2.DataSource = this.GridViewSourceM;
        this.GridView2.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int num8;
        string[] strArray;
        string str4;
        int result = 0;
        int.TryParse(this.hfDevID.Value, out result);
        DALServices services = new DALServices();
        ServicesInfo model = new ServicesInfo();
        string reason = FunLibrary.ChkInput(this.tbReason.Value);
        string takeSteps = FunLibrary.ChkInput(this.tbTakeSteps.Text);
        int num2 = 0;
        decimal num3 = 0M;
        int.TryParse(this.tbDay.Text, out num2);
        decimal.TryParse(this.tbHour.Text, out num3);
        DateTime minValue = DateTime.MinValue;
        if (!this.tbDoorDate.Text.Trim().Equals(""))
        {
            DateTime.TryParse(this.tbDoorDate.Text, out minValue);
        }
        int num4 = 0;
        int.TryParse(this.hfProcID.Value, out num4);
        services.UpdateProcess(num4, reason, takeSteps, DateTime.Parse(this.tbArrDate.Text), num2, num3, minValue, this.tbCourse.Text.Trim());
        services.UpdateProcessSteps(num4, this.hfTakeSteps.Value);
        string ids = this.hfTSAttachs.Value.Trim().Trim(new char[] { ',' });
        services.UpdateAttachs(num4, 2, ids);
        ids = this.hfReasonAttachs.Value.Trim().Trim(new char[] { ',' });
        services.UpdateAttachs(num4, 3, ids);
        model.ID = this.id;
        model.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
        model.Tel = FunLibrary.ChkInput(this.tbTel.Text);
        model.UsePerson = FunLibrary.ChkInput(this.tbUsePerson.Text);
        model.UsePersonDept = FunLibrary.ChkInput(this.tbDept.Value);
        model.UsePersonTel = FunLibrary.ChkInput(this.tbUsePersonTel.Text);
        model.Accessory = FunLibrary.ChkInput(this.tbAcc.Text);
        model.ProductBrandID = int.Parse(this.ddlBrand.SelectedValue);
        model.ProductClassID = int.Parse(this.ddlClass.SelectedValue);
        model.ProductModelID = int.Parse(this.ddlModel.SelectedValue);
        model.ProductSN1 = FunLibrary.ChkInput(this.tbSN1.Text);
        model.ProductSN2 = FunLibrary.ChkInput(this.tbSN2.Text);
        model.WarrantyID = int.Parse(this.ddlRepStatus.SelectedValue);
        model.BuyInvoice = FunLibrary.ChkInput(this.tbBuyInvoice.Text);
        model.SaveID = FunLibrary.ChkInput(this.tbSaveID.Text);
        model.SubscribeTime = FunLibrary.ChkInput(this.tbSubTime.Text);
        model.SubscribeConnectTime = FunLibrary.ChkInput(this.tbSubContTime.Text);
        decimal num5 = 0M;
        decimal.TryParse(this.tbRepCost.Text, out num5);
        model.RepairCost = num5;
        decimal.TryParse(this.tbCostExtra.Text, out num5);
        model.ExtraCost = num5;
        decimal.TryParse(this.tbCost3.Text, out num5);
        model.Fee_Add = num5;
        model.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
        decimal num6 = 0M;
        decimal num7 = 0M;
        this.CollectDataM();
        DataTable gridViewSourceM = this.GridViewSourceM;
        if (gridViewSourceM.Rows.Count > 0)
        {
            List<ServicesMaterialInfo> list = new List<ServicesMaterialInfo>();
            ServicesMaterialInfo item = null;
            for (num8 = 0; num8 < gridViewSourceM.Rows.Count; num8++)
            {
                if (int.Parse(gridViewSourceM.Rows[num8]["GoodsID"].ToString()) > 0)
                {
                    item = new ServicesMaterialInfo
                    {
                        ID = int.Parse(gridViewSourceM.Rows[num8]["RecID"].ToString()),
                        GoodsID = int.Parse(gridViewSourceM.Rows[num8]["GoodsID"].ToString()),
                        UnitID = int.Parse(gridViewSourceM.Rows[num8]["UnitID"].ToString()),
                        Qty = decimal.Parse(gridViewSourceM.Rows[num8]["Qty"].ToString()),
                        Price = decimal.Parse(gridViewSourceM.Rows[num8]["Price"].ToString()),
                        MaintenancePeriod = gridViewSourceM.Rows[num8]["MaintenancePeriod"].ToString(),
                        PeriodEndDate = gridViewSourceM.Rows[num8]["PeriodEndDate"].ToString(),
                        ChargeStyle = gridViewSourceM.Rows[num8]["ChargeStyle"].ToString(),
                        Remark = gridViewSourceM.Rows[num8]["Remark"].ToString(),
                        SN = gridViewSourceM.Rows[num8]["SN"].ToString(),
                        OutSourcing = bool.Parse(gridViewSourceM.Rows[num8]["OutSourcing"].ToString()),
                        CostPrice = decimal.Parse(gridViewSourceM.Rows[num8]["OutCostPrice"].ToString()),
                        TaxRate = decimal.Parse(gridViewSourceM.Rows[num8]["TaxRate"].ToString())
                    };
                    num6 += item.Qty * item.Price;
                    list.Add(item);
                }
            }
            model.ServicesMaterialInfos = list;
        }
        model.Fee_Materail = num6;
        List<string[]> strdellist = new List<string[]>();
        if (this.hfdellist1.Value != string.Empty)
        {
            strArray = new string[] { "ServicesMaterial", this.hfdellist1.Value };
            strdellist.Add(strArray);
        }
        this.CollectDataI();
        gridViewSourceM = this.GridViewSourceI;
        if (gridViewSourceM.Rows.Count > 0)
        {
            List<ServicesItemInfo> list3 = new List<ServicesItemInfo>();
            ServicesItemInfo info3 = null;
            for (num8 = 0; num8 < gridViewSourceM.Rows.Count; num8++)
            {
                if (int.Parse(gridViewSourceM.Rows[num8]["ItemID"].ToString()) > 0)
                {
                    info3 = new ServicesItemInfo
                    {
                        ID = int.Parse(gridViewSourceM.Rows[num8]["RecID"].ToString()),
                        ItemID = int.Parse(gridViewSourceM.Rows[num8]["ItemID"].ToString()),
                        TecDeduct = decimal.Parse(gridViewSourceM.Rows[num8]["TecDeduct"].ToString()),
                        Price = decimal.Parse(gridViewSourceM.Rows[num8]["Price"].ToString()),
                        dPoint = decimal.Parse(gridViewSourceM.Rows[num8]["dPoint"].ToString()),
                        Tec = gridViewSourceM.Rows[num8]["Tec"].ToString(),
                        ChargeStyle = gridViewSourceM.Rows[num8]["ChargeStyle"].ToString(),
                        Remark = gridViewSourceM.Rows[num8]["Remark"].ToString()
                    };
                    num7 += info3.Price;
                    list3.Add(info3);
                }
            }
            model.ServicesItemInfos = list3;
        }
        model.Fee_Labor = num7;
        if (this.hfdellist2.Value != string.Empty)
        {
            strArray = new string[] { "ServicesItem", this.hfdellist2.Value };
            strdellist.Add(strArray);
        }
        this.CollectData();
        gridViewSourceM = this.GridViewSource;
        if (gridViewSourceM.Rows.Count > 0)
        {
            List<ServicesDeviceConfInfo> list4 = new List<ServicesDeviceConfInfo>();
            ServicesDeviceConfInfo info4 = null;
            for (num8 = 0; num8 < gridViewSourceM.Rows.Count; num8++)
            {
                if (int.Parse(gridViewSourceM.Rows[num8]["ID"].ToString()) > 0)
                {
                    info4 = new ServicesDeviceConfInfo
                    {
                        ID = int.Parse(gridViewSourceM.Rows[num8]["RecID"].ToString()),
                        _Name = gridViewSourceM.Rows[num8]["_Name"].ToString(),
                        Parameter = gridViewSourceM.Rows[num8]["Parameter"].ToString(),
                        SN = gridViewSourceM.Rows[num8]["SN"].ToString(),
                        MaintenancePeriod = gridViewSourceM.Rows[num8]["MaintenancePeriod"].ToString(),
                        MaintenanceEnd = gridViewSourceM.Rows[num8]["MaintenanceEnd"].ToString(),
                        BuyDate = gridViewSourceM.Rows[num8]["BuyDate"].ToString(),
                        Remark = gridViewSourceM.Rows[num8]["Remark"].ToString()
                    };
                    list4.Add(info4);
                }
            }
            model.ServicesDeviceConfInfos = list4;
        }
        if (this.hfdellist.Value != string.Empty)
        {
            strArray = new string[] { "ServicesDeviceConf", this.hfdellist.Value };
            strdellist.Add(strArray);
        }
        if (services.UpdateDo(model, strdellist, out str4) == 0)
        {
            this.SysInfo("window.alert('操作成功！服务单已保存');parent.CloseDialog('1');");
        }
        else
        {
            this.SysInfo("window.alert(\"" + str4 + "\");");
        }
    }

    protected void btnAddEmpty_Click(object sender, EventArgs e)
    {
        this.CollectData();
        this.AddEmpty();
    }

    protected void btnId_Click(object sender, EventArgs e)
    {
        this.CollectData();
        string str = string.Empty;
        if (this.hfRecID.Value.EndsWith(","))
        {
            str = this.hfRecID.Value.Remove(this.hfRecID.Value.LastIndexOf(','));
        }
        else
        {
            str = this.hfRecID.Value;
        }
        DataTable gridViewSource = this.GridViewSource;
        if (str != string.Empty)
        {
            DataTable table2 = DALCommon.GetDataList("jc_deviceconfitem", "", " [ID] in(" + str + ") ").Tables[0];
            if (table2.Rows.Count > 0)
            {
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    DataRow row = gridViewSource.NewRow();
                    row[0] = table2.Rows[i]["_Name"].ToString();
                    row[1] = table2.Rows[i]["Parameter"].ToString();
                    row[2] = "";
                    row[3] = table2.Rows[i]["MaintenancePeriod"].ToString();
                    row[4] = "";
                    row[5] = "";
                    row[6] = table2.Rows[i]["Remark"].ToString();
                    row[7] = gridViewSource.Rows.Count;
                    row[8] = 0;
                    row[9] = 0;
                    gridViewSource.Rows.Add(row);
                }
            }
        }
        this.BindData();
    }

    protected void btnId1_Click(object sender, EventArgs e)
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
        DataTable gridViewSourceM = this.GridViewSourceM;
        if (str != string.Empty)
        {
            DataTable table3 = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + str + ") ").Tables[0];
            if (table3.Rows.Count > 0)
            {
                this.CollectDataM();
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
                    for (int j = 1; j < gridViewSourceM.Rows.Count; j++)
                    {
                        if (gridViewSourceM.Rows[j]["GoodsID"].ToString() == table3.Rows[i]["ID"].ToString())
                        {
                            string str4 = gridViewSourceM.Rows[i]["Qty"].ToString();
                            decimal Qty = decimal.Parse(gridViewSourceM.Rows[j]["Qty"].ToString());
                            ++Qty;
                            gridViewSourceM.Rows[j]["Qty"] = Qty;
                            gridViewSourceM.Rows[j]["Total"] = decimal.Parse(gridViewSourceM.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSourceM.Rows[j]["Price"].ToString());
                            flag2 = false;
                        }
                    }
                    if (flag2)
                    {
                        DataRow row = gridViewSourceM.NewRow();
                        row[0] = table3.Rows[i]["GoodsNO"].ToString();
                        row[1] = table3.Rows[i]["_Name"].ToString();
                        row[2] = table3.Rows[i]["Spec"].ToString();
                        row[3] = table3.Rows[i]["ProductBrand"].ToString();
                        row[4] = table3.Rows[i]["Unit"].ToString();
                        row[5] = 1;
                        row[6] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                        row[7] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                        row[8] = "";
                        row[9] = table3.Rows[i]["MainTenancePeriod"].ToString();
                        row[10] = "";
                        row[11] = "客付";
                        row[12] = "";
                        row[13] = int.Parse(table3.Rows[i]["ID"].ToString());
                        row[14] = int.Parse(table3.Rows[i]["GoodsUnitID"].ToString());
                        row[15] = 0;
                        row[0x10] = 0;
                        row[0x11] = false;
                        row[0x12] = 0;
                        row[0x13] = 0;
                        row[20] = 0;
                        gridViewSourceM.Rows.Add(row);
                    }
                }
                this.BindDataM();
            }
        }
        this.SysInfo1("$('tbConInfo').focus();");
    }

    protected void btnId2_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        if (this.hfreclist2.Value.EndsWith(","))
        {
            str = this.hfreclist2.Value.Remove(this.hfreclist2.Value.LastIndexOf(','));
        }
        else
        {
            str = this.hfreclist2.Value;
        }
        DataTable gridViewSourceI = this.GridViewSourceI;
        if (str != string.Empty)
        {
            DataTable table2 = DALCommon.GetDataList("ServicesItemList", "", " [ID] in(" + str + ") ").Tables[0];
            if (table2.Rows.Count > 0)
            {
                this.CollectDataI();
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    bool flag2 = true;
                    for (int j = 1; j < gridViewSourceI.Rows.Count; j++)
                    {
                        if (gridViewSourceI.Rows[j]["ItemID"].ToString() == table2.Rows[i]["ID"].ToString())
                        {
                            flag2 = false;
                        }
                    }
                    if (flag2)
                    {
                        DataRow row = gridViewSourceI.NewRow();
                        row[0] = table2.Rows[i]["ItemNO"].ToString();
                        row[1] = table2.Rows[i]["_Name"].ToString();
                        row[2] = decimal.Parse(table2.Rows[i]["Price"].ToString());
                        row[3] = 0;
                        row[4] = "";
                        row[5] = "客付";
                        row[6] = decimal.Parse(table2.Rows[i]["TecDeduct"].ToString());
                        row[7] = "";
                        row[8] = int.Parse(table2.Rows[i]["ID"].ToString());
                        row[9] = 0;
                        row[10] = 0;
                        gridViewSourceI.Rows.Add(row);
                    }
                }
                this.BindDataI();
            }
        }
        this.SysInfo2("$('tbConInfo2').focus();");
    }

    protected void btnRefBrand_Click(object sender, EventArgs e)
    {
        OtherFunction.BindProductBrand(this.ddlBrand);
        if (this.hfBrand.Value != string.Empty)
        {
            this.ddlBrand.ClearSelection();
            this.ddlBrand.Items.FindByText(this.hfBrand.Value).Selected = true;
            this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
        }
    }

    protected void btnRefClass_Click(object sender, EventArgs e)
    {
        OtherFunction.BindProductClass(this.ddlClass);
        if (this.hfClass.Value != string.Empty)
        {
            this.ddlClass.ClearSelection();
            this.ddlClass.Items.FindByText(this.hfClass.Value).Selected = true;
            this.tbClass.Text = this.ddlClass.SelectedItem.Text;
        }
    }

    protected void btnRefModel_Click(object sender, EventArgs e)
    {
        if (this.hfModelID.Value != "")
        {
            OtherFunction.BindProductModel(this.ddlModel, "");
            DataTable table = DALCommon.GetDataList("jc_productmodel", "", "ID=" + this.hfModelID.Value).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.ddlBrand.ClearSelection();
                this.ddlBrand.Items.FindByText(table.Rows[0]["Brand"].ToString()).Selected = true;
                this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
                this.ddlClass.ClearSelection();
                this.ddlClass.Items.FindByText(table.Rows[0]["Class"].ToString()).Selected = true;
                this.tbClass.Text = this.ddlClass.SelectedItem.Text;
                this.ddlModel.ClearSelection();
                this.ddlModel.Items.FindByText(table.Rows[0]["_Name"].ToString()).Selected = true;
                this.tbModel.Text = this.ddlModel.SelectedItem.Text;
            }
        }
    }

    protected void btnRefWarranty_Click(object sender, EventArgs e)
    {
        OtherFunction.BindWarranty(this.ddlRepStatus);
        if (this.hfWarranty.Value != string.Empty)
        {
            this.ddlRepStatus.ClearSelection();
            this.ddlRepStatus.Items.FindByText(this.hfWarranty.Value).Selected = true;
        }
    }

    protected void btnSltUnit_Click(object sender, EventArgs e)
    {
        this.CollectDataM();
        DataTable gridViewSourceM = this.GridViewSourceM;
        for (int i = 0; i < gridViewSourceM.Rows.Count; i++)
        {
            if (gridViewSourceM.Rows[i]["GoodsID"].ToString() == this.hfRecID.Value.Replace("u", ""))
            {
                gridViewSourceM.Rows[i][4] = this.hfName.Value;
                gridViewSourceM.Rows[i][14] = int.Parse(this.hfRecIDs.Value);
            }
        }
        this.BindDataM();
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
        DataTable gridViewSource = this.GridViewSource;
        DataTable table2 = DALCommon.GetDataList("jc_deviceconfitem", "", " ProductClass like '%" + str + "%' ").Tables[0];
        if (table2.Rows.Count > 0)
        {
            this.CollectData();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                DataRow row = gridViewSource.NewRow();
                row[0] = table2.Rows[i]["_Name"].ToString();
                row[1] = table2.Rows[i]["Parameter"].ToString();
                row[2] = "";
                row[3] = table2.Rows[i]["MaintenancePeriod"].ToString();
                row[4] = "";
                row[5] = "";
                row[6] = table2.Rows[i]["Remark"].ToString();
                row[7] = gridViewSource.Rows.Count;
                row[8] = 0;
                row[9] = 0;
                gridViewSource.Rows.Add(row);
            }
            this.BindData();
        }
        else
        {
            this.SysInfo3("window.alert('操作失败！没有该类别的配置项');$('" + this.tbCon.ClientID + "').select();");
        }
    }

    protected void btnSure1_Click(object sender, EventArgs e)
    {
        string str = FunLibrary.ChkInput(this.tbConInfo.Text.Trim());
        DataTable gridViewSourceM = this.GridViewSourceM;
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
        string str3 = "$('" + this.tbConInfo.ClientID + "').select();";
        if (table2.Rows.Count > 0)
        {
            this.CollectDataM();
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
                for (int j = 0; j < gridViewSourceM.Rows.Count; j++)
                {
                    if (gridViewSourceM.Rows[j]["GoodsID"].ToString() == table2.Rows[i]["ID"].ToString())
                    {
                        
                        decimal Qty = decimal.Parse(gridViewSourceM.Rows[j]["Qty"].ToString()); ++Qty; gridViewSourceM.Rows[j]["Qty"] = Qty;
                        gridViewSourceM.Rows[j]["Total"] = decimal.Parse(gridViewSourceM.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSourceM.Rows[j]["Price"].ToString());
                        flag2 = false;
                    }
                }
                if (flag2)
                {
                    DataRow row = gridViewSourceM.NewRow();
                    row[0] = table2.Rows[i]["GoodsNO"].ToString();
                    row[1] = table2.Rows[i]["_Name"].ToString();
                    row[2] = table2.Rows[i]["Spec"].ToString();
                    row[3] = table2.Rows[i]["ProductBrand"].ToString();
                    row[4] = table2.Rows[i]["Unit"].ToString();
                    row[5] = 1;
                    row[6] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                    row[7] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                    row[8] = "";
                    row[9] = table2.Rows[i]["MainTenancePeriod"].ToString();
                    row[10] = "";
                    row[11] = "客付";
                    row[12] = "";
                    row[13] = int.Parse(table2.Rows[i]["ID"].ToString());
                    row[14] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
                    row[15] = 0;
                    row[0x10] = 0;
                    row[0x11] = false;
                    row[0x12] = 0;
                    row[0x13] = 0;
                    row[20] = 0;
                    gridViewSourceM.Rows.Add(row);
                }
            }
            this.BindDataM();
        }
        else
        {
            str3 = str3 + "window.alert('操作失败！没有该产品信息');";
        }
        this.SysInfo1(str3);
    }

    protected void btnSure2_Click(object sender, EventArgs e)
    {
        string str = FunLibrary.ChkInput(this.tbConInfo2.Text.Trim());
        DataTable gridViewSourceI = this.GridViewSourceI;
        DataTable table2 = DALCommon.GetDataList("ServicesItemList", "", this.ddlSchFld2.SelectedValue + "='" + str + "'").Tables[0];
        string str2 = "$('" + this.tbConInfo2.ClientID + "').select();";
        if (table2.Rows.Count > 0)
        {
            this.CollectDataI();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                bool flag2 = true;
                for (int j = 0; j < gridViewSourceI.Rows.Count; j++)
                {
                    if (gridViewSourceI.Rows[j]["ItemID"].ToString() == table2.Rows[i]["ID"].ToString())
                    {
                        flag2 = false;
                    }
                }
                if (flag2)
                {
                    DataRow row = gridViewSourceI.NewRow();
                    row[0] = table2.Rows[i]["ItemNO"].ToString();
                    row[1] = table2.Rows[i]["_Name"].ToString();
                    row[2] = decimal.Parse(table2.Rows[i]["Price"].ToString());
                    row[3] = 0;
                    row[4] = "";
                    row[5] = "客付";
                    row[6] = decimal.Parse(table2.Rows[i]["TecDeduct"].ToString());
                    row[7] = "";
                    row[8] = int.Parse(table2.Rows[i]["ID"].ToString());
                    row[9] = 0;
                    row[10] = 0;
                    gridViewSourceI.Rows.Add(row);
                }
            }
            this.BindDataI();
        }
        else
        {
            str2 = str2 + "window.alert('操作失败！没有该服务项目');";
        }
        this.SysInfo2(str2);
    }

    protected void CollectData()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            TextBox box = this.GridView1.Rows[i].FindControl("tbName") as TextBox;
            TextBox box2 = this.GridView1.Rows[i].FindControl("tbParameter") as TextBox;
            TextBox box3 = this.GridView1.Rows[i].FindControl("tbSN") as TextBox;
            TextBox box4 = this.GridView1.Rows[i].FindControl("tbPeriod") as TextBox;
            TextBox box5 = this.GridView1.Rows[i].FindControl("tbBuyDate") as TextBox;
            TextBox box6 = this.GridView1.Rows[i].FindControl("tbMaintenanceEnd") as TextBox;
            TextBox box7 = this.GridView1.Rows[i].FindControl("tbRemark") as TextBox;
            DataTable gridViewSource = this.GridViewSource;
            gridViewSource.Rows[i][0] = FunLibrary.ChkInput(box.Text);
            gridViewSource.Rows[i][1] = FunLibrary.ChkInput(box2.Text);
            gridViewSource.Rows[i][2] = FunLibrary.ChkInput(box3.Text);
            gridViewSource.Rows[i][3] = FunLibrary.ChkInput(box4.Text);
            gridViewSource.Rows[i][4] = FunLibrary.ChkInput(box5.Text);
            gridViewSource.Rows[i][5] = FunLibrary.ChkInput(box6.Text);
            gridViewSource.Rows[i][6] = FunLibrary.ChkInput(box7.Text);
        }
    }

    protected void CollectDataI()
    {
        for (int i = 0; i < this.GridView3.Rows.Count; i++)
        {
            TextBox box = this.GridView3.Rows[i].FindControl("tbPrice") as TextBox;
            TextBox box2 = this.GridView3.Rows[i].FindControl("tbRemark") as TextBox;
            TextBox box3 = this.GridView3.Rows[i].FindControl("tbdPoint") as TextBox;
            TextBox box4 = this.GridView3.Rows[i].FindControl("tbTecDeduct") as TextBox;
            TextBox box5 = this.GridView3.Rows[i].FindControl("tbTec") as TextBox;
            DropDownList list = this.GridView3.Rows[i].FindControl("ddlChargeStyle") as DropDownList;
            DataTable gridViewSourceI = this.GridViewSourceI;
            gridViewSourceI.Rows[i]["Price"] = box.Text;
            gridViewSourceI.Rows[i]["dPoint"] = box3.Text;
            gridViewSourceI.Rows[i]["Remark"] = FunLibrary.ChkInput(box2.Text);
            gridViewSourceI.Rows[i]["TecDeduct"] = box4.Text;
            gridViewSourceI.Rows[i]["Tec"] = FunLibrary.ChkInput(box5.Text);
            gridViewSourceI.Rows[i]["ChargeStyle"] = list.SelectedItem.Text;
        }
    }

    protected void CollectDataM()
    {
        for (int i = 0; i < this.GridView2.Rows.Count; i++)
        {
            TextBox box = this.GridView2.Rows[i].FindControl("tbQty") as TextBox;
            TextBox box2 = this.GridView2.Rows[i].FindControl("tbSN") as TextBox;
            TextBox box3 = this.GridView2.Rows[i].FindControl("tbPrice") as TextBox;
            TextBox box4 = this.GridView2.Rows[i].FindControl("tbRemark") as TextBox;
            TextBox box5 = this.GridView2.Rows[i].FindControl("tbPeriod") as TextBox;
            TextBox box6 = this.GridView2.Rows[i].FindControl("tbPeriodEndDate") as TextBox;
            DropDownList list = this.GridView2.Rows[i].FindControl("ddlChargeStyle") as DropDownList;
            CheckBox box7 = this.GridView2.Rows[i].FindControl("cbOutSourcing") as CheckBox;
            TextBox box8 = this.GridView2.Rows[i].FindControl("tbOutPrice") as TextBox;
            TextBox box9 = this.GridView2.Rows[i].FindControl("tbTaxRate") as TextBox;
            DataTable gridViewSourceM = this.GridViewSourceM;
            gridViewSourceM.Rows[i]["Qty"] = box.Text;
            gridViewSourceM.Rows[i]["SN"] = box2.Text;
            gridViewSourceM.Rows[i]["Price"] = box3.Text;
            decimal num2 = decimal.Parse(box.Text) * decimal.Parse(box3.Text);
            decimal num3 = num2 * decimal.Parse(box9.Text);
            decimal num4 = num2 + num3;
            gridViewSourceM.Rows[i]["Total"] = num4;
            gridViewSourceM.Rows[i]["Remark"] = FunLibrary.ChkInput(box4.Text);
            gridViewSourceM.Rows[i]["MaintenancePeriod"] = FunLibrary.ChkInput(box5.Text);
            gridViewSourceM.Rows[i]["PeriodEndDate"] = FunLibrary.ChkInput(box6.Text);
            gridViewSourceM.Rows[i]["ChargeStyle"] = list.SelectedItem.Text;
            gridViewSourceM.Rows[i]["OutSourcing"] = box7.Checked;
            gridViewSourceM.Rows[i]["OutCostPrice"] = box8.Text;
            gridViewSourceM.Rows[i]["TaxRate"] = box9.Text;
            gridViewSourceM.Rows[i]["TaxAmount"] = num3;
        }
    }

    protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetProductModel();
    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetProductModel();
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlModel.SelectedValue != "-1")
        {
            DataTable table = DALCommon.GetDataList("jc_productmodel", "", "ID=" + this.ddlModel.SelectedValue).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.ddlBrand.ClearSelection();
                this.ddlBrand.Items.FindByText(table.Rows[0]["Brand"].ToString()).Selected = true;
                this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
                this.ddlClass.ClearSelection();
                this.ddlClass.Items.FindByText(table.Rows[0]["Class"].ToString()).Selected = true;
                this.tbClass.Text = this.ddlClass.SelectedItem.Text;
            }
        }
    }

    protected void GetProductModel()
    {
        string strWhere = string.Empty;
        if ((this.ddlBrand.SelectedValue != "0") && (this.ddlBrand.SelectedValue != "-1"))
        {
            strWhere = strWhere + " BrandID=" + this.ddlBrand.SelectedValue;
        }
        if ((this.ddlClass.SelectedValue != "0") && (this.ddlClass.SelectedValue != "-1"))
        {
            if (strWhere == string.Empty)
            {
                strWhere = strWhere + " ClassID=" + this.ddlClass.SelectedValue;
            }
            else
            {
                strWhere = strWhere + " and ClassID=" + this.ddlClass.SelectedValue;
            }
        }
        this.tbModel.Text = "";
        OtherFunction.BindProductModel(this.ddlModel, strWhere);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[0].Text == "0")
        {
            e.Row.Visible = false;
        }
        e.Row.Cells[0].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
            e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
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

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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
            Label label = e.Row.FindControl("lbAmount") as Label;
            TextBox box3 = e.Row.FindControl("tbChargeStyle") as TextBox;
            TextBox box4 = e.Row.FindControl("tbSN") as TextBox;
            TextBox box5 = e.Row.FindControl("tbTaxRate") as TextBox;
            Label label2 = e.Row.FindControl("lbTaxAmount") as Label;
            box.Attributes.Add("oldNum", box.Text);
            box2.Attributes.Add("oldNum", box2.Text);
            label.Attributes.Add("oldNum", label.Text);
            box.Attributes.Add("onblur", "ValidateNumsm(this,'" + box2.ClientID + "','" + box5.ClientID + "','" + label2.ClientID + "','" + label.ClientID + "');");
            box2.Attributes.Add("onblur", "ValidateMoneysm(this,'" + box.ClientID + "','" + box5.ClientID + "','" + label2.ClientID + "','" + label.ClientID + "');");
            box5.Attributes.Add("onblur", "ValidateTaxsm(this,'" + box.ClientID + "','" + box2.ClientID + "','" + label2.ClientID + "','" + label.ClientID + "');");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex);
            e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;");
            e.Row.Cells[7].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
            e.Row.Cells[7].Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
            e.Row.Cells[7].Attributes.Add("ondblclick", "SltUnit1();");
            e.Row.Cells[8].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
            e.Row.Cells[8].Attributes.Add("onclick", "ChkIDs('q" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "');");
            e.Row.Cells[8].Attributes.Add("ondblclick", "SltUnitQty1('" + box.ClientID + "');");
            HtmlInputButton button = e.Row.FindControl("btnsch") as HtmlInputButton;
            e.Row.Cells[10].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
            button.Attributes.Add("onclick", "ChkIDs('p" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "');SltPrice1('2','" + box2.ClientID + "');");
            e.Row.Cells[9].Text = "<a href=\"#\" onclick=\"EditSN('" + e.Row.Cells[0].Text + "','" + e.Row.Cells[1].Text + "','" + box4.ClientID + "','" + box.ClientID + "');\">编辑序列号</a>";
            DropDownList list = e.Row.FindControl("ddlChargeStyle") as DropDownList;
            list.Items.Add(new ListItem("客付", "客付"));
            list.Items.Add(new ListItem("厂付", "厂付"));
            list.Items.Add(new ListItem("免费", "免费"));
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Text == box3.Text)
                {
                    list.Items[i].Selected = true;
                    break;
                }
            }
        }
    }

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.CollectDataM();
        DataTable gridViewSourceM = this.GridViewSourceM;
        for (int i = 0; i < gridViewSourceM.Rows.Count; i++)
        {
            if ((i == e.RowIndex) && (int.Parse(gridViewSourceM.Rows[i]["iFlag"].ToString()) == 1))
            {
                if (this.hfdellist1.Value == string.Empty)
                {
                    this.hfdellist1.Value = gridViewSourceM.Rows[i]["RecID"].ToString();
                }
                else
                {
                    this.hfdellist1.Value = this.hfdellist1.Value + "," + gridViewSourceM.Rows[i]["RecID"].ToString();
                }
            }
        }
        this.GridViewSourceM.Rows[e.RowIndex].Delete();
        this.BindDataM();
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[0].Text == "0")
        {
            e.Row.Visible = false;
        }
        e.Row.Cells[0].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox box = e.Row.FindControl("tbChargeStyle") as TextBox;
            TextBox box2 = e.Row.FindControl("tbTec") as TextBox;
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
            e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
            HtmlInputButton button = e.Row.FindControl("btnsch") as HtmlInputButton;
            button.Attributes.Add("onclick", "SltTec('" + box2.ClientID + "');");
            DropDownList list = e.Row.FindControl("ddlChargeStyle") as DropDownList;
            list.Items.Add(new ListItem("客付", "客付"));
            list.Items.Add(new ListItem("厂付", "厂付"));
            list.Items.Add(new ListItem("免费", "免费"));
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Text == box.Text)
                {
                    list.Items[i].Selected = true;
                    break;
                }
            }
        }
    }

    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.CollectDataI();
        DataTable gridViewSourceI = this.GridViewSourceI;
        for (int i = 0; i < gridViewSourceI.Rows.Count; i++)
        {
            if ((i == e.RowIndex) && (int.Parse(gridViewSourceI.Rows[i]["iFlag"].ToString()) == 1))
            {
                if (this.hfdellist2.Value == string.Empty)
                {
                    this.hfdellist2.Value = gridViewSourceI.Rows[i]["RecID"].ToString();
                }
                else
                {
                    this.hfdellist2.Value = this.hfdellist2.Value + "," + gridViewSourceI.Rows[i]["RecID"].ToString();
                }
            }
        }
        this.GridViewSourceI.Rows[e.RowIndex].Delete();
        this.BindDataI();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkHead();
        int.TryParse(base.Request["id"], out this.id);
        if (this.id == 0)
        {
            base.Response.End();
        }
        if (!base.IsPostBack)
        {
            int num2;
            DataRow row2;
            int rightID = int.Parse((string)this.Session["Session_wtPurID"]);
            if (rightID > 0)
            {
                DALRight right = new DALRight();
                if (!right.GetRight(rightID, "gd_r9"))
                {
                    this.btnAdd.Enabled = false;
                }
            }
            OtherFunction.BindProductBrand(this.ddlBrand);
            OtherFunction.BindProductClass(this.ddlClass);
            OtherFunction.BindProductModel(this.ddlModel, "");
            OtherFunction.BindWarranty(this.ddlRepStatus);
            OtherFunction.BindTrobleReason(this.ddlTroubleReason);
            DataTable table = DALCommon.GetDataList("fw_services", "", " [ID]=" + this.id.ToString()).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.hfCusID.Value = table.Rows[0]["CustomerID"].ToString();
                this.tbLinkMan.Text = table.Rows[0]["LinkMan"].ToString();
                this.tbTel.Text = table.Rows[0]["Tel"].ToString();
                this.tbUsePerson.Text = table.Rows[0]["UsePerson"].ToString();
                this.tbUsePersonTel.Text = table.Rows[0]["UsePersonTel"].ToString();
                this.tbDept.Value = table.Rows[0]["UsePersonDept"].ToString();
                for (num2 = 0; num2 < this.ddlBrand.Items.Count; num2++)
                {
                    if (this.ddlBrand.Items[num2].Text == table.Rows[0]["ProductBrand"].ToString())
                    {
                        this.ddlBrand.Items[num2].Selected = true;
                        this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
                        break;
                    }
                }
                for (num2 = 0; num2 < this.ddlClass.Items.Count; num2++)
                {
                    if (this.ddlClass.Items[num2].Text == table.Rows[0]["ProductClass"].ToString())
                    {
                        this.ddlClass.Items[num2].Selected = true;
                        this.tbClass.Text = this.ddlClass.SelectedItem.Text;
                        break;
                    }
                }
                num2 = 0;
                while (num2 < this.ddlModel.Items.Count)
                {
                    if (this.ddlModel.Items[num2].Text == table.Rows[0]["ProductModel"].ToString())
                    {
                        this.ddlModel.Items[num2].Selected = true;
                        this.tbModel.Text = this.ddlModel.SelectedItem.Text;
                        break;
                    }
                    num2++;
                }
                this.tbSN1.Text = table.Rows[0]["ProductSN1"].ToString();
                this.tbSN2.Text = table.Rows[0]["ProductSN2"].ToString();
                this.tbAcc.Text = table.Rows[0]["Accessory"].ToString();
                this.tbFault.Text = table.Rows[0]["Fault"].ToString();
                for (num2 = 0; num2 < this.ddlRepStatus.Items.Count; num2++)
                {
                    if (this.ddlRepStatus.Items[num2].Text == table.Rows[0]["Warranty"].ToString())
                    {
                        this.ddlRepStatus.Items[num2].Selected = true;
                        break;
                    }
                }
                this.tbBuyInvoice.Text = table.Rows[0]["BuyInvoice"].ToString();
                this.tbSaveID.Text = table.Rows[0]["SaveID"].ToString();
                this.tbDisposal.Text = table.Rows[0]["DisposalOper"].ToString();
                this.tbSubTime.Text = table.Rows[0]["SubscribeTime"].ToString();
                this.tbSubContTime.Text = table.Rows[0]["SubscribeConnectTime"].ToString();
                this.tbRepCost.Text = table.Rows[0]["RepairCost"].ToString();
                this.tbCostExtra.Text = table.Rows[0]["ExtraCost"].ToString();
                this.tbCost1.Text = table.Rows[0]["Fee_Materail"].ToString();
                this.tbCost2.Text = table.Rows[0]["Fee_Labor"].ToString();
                this.tbCost3.Text = table.Rows[0]["Fee_Add"].ToString();
                this.tbRemark.Text = table.Rows[0]["Remark"].ToString();
                DataTable table2 = DALCommon.GetDataList("ServicesProcess", "top 1 *", "BillID=" + this.id.ToString() + " and DoStyle='委外送修' order by ID desc").Tables[0];
                if (table2.Rows.Count > 0)
                {
                    this.tbArrDate.Text = table2.Rows[0]["ArrivedTime"].ToString();
                    if (!table2.Rows[0]["visitdate"].ToString().Trim().Equals(""))
                    {
                        this.tbDoorDate.Text = DateTime.Parse(table2.Rows[0]["visitdate"].ToString()).ToString("yyyy-MM-dd");
                    }
                    this.tbTakeSteps.Text = table2.Rows[0]["TakeSteps"].ToString();
                    this.tbReason.Value = table2.Rows[0]["Reason"].ToString();
                    this.tbDay.Text = table2.Rows[0]["iDays"].ToString();
                    this.tbHour.Text = table2.Rows[0]["iHours"].ToString();
                    this.tbCourse.Text = table2.Rows[0]["Course"].ToString();
                    this.hfProcID.Value = table2.Rows[0]["ID"].ToString();
                    string str = table2.Rows[0]["ID"].ToString().Trim();
                    DataTable table3 = DALCommon.GetList("SerAttach", "ID", "BillID=" + str + " and iType=2").Tables[0];
                    string str2 = string.Empty;
                    foreach (DataRow row in table3.Rows)
                    {
                        str2 = str2 + row["ID"].ToString().Trim() + ",";
                    }
                    this.hfTSAttachs.Value = str2.Trim(new char[] { ',' });
                    DataTable table4 = DALCommon.GetList("SerAttach", "ID", "BillID=" + str + " and iType=3").Tables[0];
                    str2 = string.Empty;
                    foreach (DataRow row in table4.Rows)
                    {
                        str2 = str2 + row["ID"].ToString().Trim() + ",";
                    }
                    this.hfReasonAttachs.Value = str2.Trim(new char[] { ',' });
                    DataTable table5 = DALCommon.GetList("SerAttach", "ID", "BillID=" + this.id + " and iType=1").Tables[0];
                    str2 = string.Empty;
                    foreach (DataRow row in table5.Rows)
                    {
                        str2 = str2 + row["ID"].ToString().Trim() + ",";
                    }
                    this.hfAttachs.Value = str2.Trim(new char[] { ',' });
                }
            }
            DALSysParm parm = new DALSysParm();
            if (parm.GetModel(1).bTakeStepsNoInput)
            {
                this.tbTakeSteps.Attributes["onfocus"] = "blur();";
            }
            this.AddEmptyM();
            this.AddEmptyI();
            this.AddEmpty();
            DataTable table6 = DALCommon.GetDataList("ServicesDeviceConf", "", " [BillID]=" + this.id.ToString()).Tables[0];
            if (table6.Rows.Count > 0)
            {
                DataTable gridViewSource = this.GridViewSource;
                for (num2 = 0; num2 < table6.Rows.Count; num2++)
                {
                    row2 = gridViewSource.NewRow();
                    row2[0] = table6.Rows[num2]["_Name"].ToString();
                    row2[1] = table6.Rows[num2]["Parameter"].ToString();
                    row2[2] = table6.Rows[num2]["SN"].ToString();
                    row2[3] = table6.Rows[num2]["MaintenancePeriod"].ToString();
                    row2[4] = table6.Rows[num2]["BuyDate"].ToString();
                    row2[5] = table6.Rows[num2]["MaintenanceEnd"].ToString();
                    row2[6] = table6.Rows[num2]["Remark"].ToString();
                    row2[7] = gridViewSource.Rows.Count;
                    row2[8] = int.Parse(table6.Rows[num2]["ID"].ToString());
                    row2[9] = 1;
                    gridViewSource.Rows.Add(row2);
                }
                this.GridViewSource = gridViewSource;
                this.BindData();
            }
            DataTable table8 = DALCommon.GetDataList("fw_servicesmaterial", "", " [BillID]=" + this.id.ToString()).Tables[0];
            if (table8.Rows.Count > 0)
            {
                DataTable gridViewSourceM = this.GridViewSourceM;
                for (num2 = 0; num2 < table8.Rows.Count; num2++)
                {
                    row2 = gridViewSourceM.NewRow();
                    row2[0] = table8.Rows[num2]["GoodsNO"].ToString();
                    row2[1] = table8.Rows[num2]["_Name"].ToString();
                    row2[2] = table8.Rows[num2]["Spec"].ToString();
                    row2[3] = table8.Rows[num2]["ProductBrand"].ToString();
                    row2[4] = table8.Rows[num2]["Unit"].ToString();
                    row2[5] = decimal.Parse(table8.Rows[num2]["Qty"].ToString());
                    row2[6] = decimal.Parse(table8.Rows[num2]["Price"].ToString());
                    row2[7] = decimal.Parse(table8.Rows[num2]["Total"].ToString());
                    row2[8] = table8.Rows[num2]["SN"].ToString();
                    row2[9] = table8.Rows[num2]["MainTenancePeriod"].ToString();
                    row2[10] = table8.Rows[num2]["PeriodEndDate"].ToString();
                    row2[11] = table8.Rows[num2]["ChargeStyle"].ToString();
                    row2[12] = table8.Rows[num2]["Remark"].ToString();
                    row2[13] = int.Parse(table8.Rows[num2]["GoodsID"].ToString());
                    row2[14] = int.Parse(table8.Rows[num2]["UnitID"].ToString());
                    row2[15] = int.Parse(table8.Rows[num2]["ID"].ToString());
                    row2[0x10] = 1;
                    row2[0x11] = table8.Rows[num2]["OutSourcing"].ToString() != "";
                    row2[0x12] = decimal.Parse(table8.Rows[num2]["OutCostPrice"].ToString());
                    row2[0x13] = table8.Rows[num2]["TaxRate"].ToString().TrimEnd(new char[] { '0' }).TrimEnd(new char[] { '.' });
                    row2[20] = table8.Rows[num2]["TaxAmount"].ToString().TrimEnd(new char[] { '0' }).TrimEnd(new char[] { '.' });
                    gridViewSourceM.Rows.Add(row2);
                }
                this.GridViewSourceM = gridViewSourceM;
                this.BindDataM();
            }
            DataTable table10 = DALCommon.GetDataList("fw_servicesitem", "", " [BillID]=" + this.id.ToString()).Tables[0];
            if (table10.Rows.Count > 0)
            {
                DataTable gridViewSourceI = this.GridViewSourceI;
                for (num2 = 0; num2 < table10.Rows.Count; num2++)
                {
                    row2 = gridViewSourceI.NewRow();
                    row2[0] = table10.Rows[num2]["ItemNO"].ToString();
                    row2[1] = table10.Rows[num2]["_Name"].ToString();
                    row2[2] = decimal.Parse(table10.Rows[num2]["Price"].ToString());
                    row2[3] = decimal.Parse(table10.Rows[num2]["dPoint"].ToString());
                    row2[4] = table10.Rows[num2]["Tec"].ToString();
                    row2[5] = table10.Rows[num2]["ChargeStyle"].ToString();
                    row2[6] = decimal.Parse(table10.Rows[num2]["TecDeduct"].ToString());
                    row2[7] = table10.Rows[num2]["Remark"].ToString();
                    row2[8] = int.Parse(table10.Rows[num2]["ItemID"].ToString());
                    row2[9] = int.Parse(table10.Rows[num2]["ID"].ToString());
                    row2[10] = 1;
                    gridViewSourceI.Rows.Add(row2);
                }
                this.GridViewSourceI = gridViewSourceI;
                this.BindDataI();
            }
        }
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
    }

    protected void SysInfo1(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", str, true);
    }

    protected void SysInfo2(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.UpdatePanel4.GetType(), "sysinfo", str, true);
    }

    protected void SysInfo3(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.UpdatePanel3.GetType(), "sysinfo", str, true);
    }

    private DataTable GridViewSource
    {
        get
        {
            if (this.ViewState["List"] == null)
            {
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("_Name", typeof(string)));
                table.Columns.Add(new DataColumn("Parameter", typeof(string)));
                table.Columns.Add(new DataColumn("SN", typeof(string)));
                table.Columns.Add(new DataColumn("MaintenancePeriod", typeof(string)));
                table.Columns.Add(new DataColumn("BuyDate", typeof(string)));
                table.Columns.Add(new DataColumn("MaintenanceEnd", typeof(string)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("ID", typeof(int)));
                table.Columns.Add(new DataColumn("RecID", typeof(int)));
                table.Columns.Add(new DataColumn("iFlag", typeof(int)));
                this.ViewState["List"] = table;
            }
            return (DataTable)this.ViewState["List"];
        }
        set
        {
            this.ViewState["List"] = value;
        }
    }

    private DataTable GridViewSourceI
    {
        get
        {
            if (this.ViewState["ListI"] == null)
            {
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("ItemNO", typeof(string)));
                table.Columns.Add(new DataColumn("_Name", typeof(string)));
                table.Columns.Add(new DataColumn("Price", typeof(decimal)));
                table.Columns.Add(new DataColumn("dPoint", typeof(decimal)));
                table.Columns.Add(new DataColumn("Tec", typeof(string)));
                table.Columns.Add(new DataColumn("ChargeStyle", typeof(string)));
                table.Columns.Add(new DataColumn("TecDeduct", typeof(decimal)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("ItemID", typeof(int)));
                table.Columns.Add(new DataColumn("RecID", typeof(int)));
                table.Columns.Add(new DataColumn("iFlag", typeof(int)));
                this.ViewState["ListI"] = table;
            }
            return (DataTable)this.ViewState["ListI"];
        }
        set
        {
            this.ViewState["ListI"] = value;
        }
    }

    private DataTable GridViewSourceM
    {
        get
        {
            if (this.ViewState["ListM"] == null)
            {
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
                table.Columns.Add(new DataColumn("_Name", typeof(string)));
                table.Columns.Add(new DataColumn("Spec", typeof(string)));
                table.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
                table.Columns.Add(new DataColumn("Unit", typeof(string)));
                table.Columns.Add(new DataColumn("Qty", typeof(decimal)));
                table.Columns.Add(new DataColumn("Price", typeof(decimal)));
                table.Columns.Add(new DataColumn("Total", typeof(decimal)));
                table.Columns.Add(new DataColumn("SN", typeof(string)));
                table.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
                table.Columns.Add(new DataColumn("PeriodEndDate", typeof(string)));
                table.Columns.Add(new DataColumn("ChargeStyle", typeof(string)));
                table.Columns.Add(new DataColumn("Remark", typeof(string)));
                table.Columns.Add(new DataColumn("GoodsID", typeof(int)));
                table.Columns.Add(new DataColumn("UnitID", typeof(int)));
                table.Columns.Add(new DataColumn("RecID", typeof(int)));
                table.Columns.Add(new DataColumn("iFlag", typeof(int)));
                table.Columns.Add(new DataColumn("OutSourcing", typeof(bool)));
                table.Columns.Add(new DataColumn("OutCostPrice", typeof(decimal)));
                table.Columns.Add(new DataColumn("TaxRate", typeof(decimal)));
                table.Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));
                this.ViewState["ListM"] = table;
            }
            return (DataTable)this.ViewState["ListM"];
        }
        set
        {
            this.ViewState["ListM"] = value;
        }
    }


}

