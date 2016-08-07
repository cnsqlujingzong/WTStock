// Decompiled with JetBrains decompiler
// Type: Headquarters_Customer_DeviceMod
// Assembly: wt.web, Version=0.0.0.0, Culture=neutral
// MVID: D3272D05-C02C-47E6-9FBF-767A521D8A35
// Assembly location: C:\Users\Administrator\Desktop\wt_itfiles\wt_itfiles\wt_files\bin\wt.web.dll

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

public partial class Headquarters_Customer_DeviceMod : Page, IRequiresSessionState
{
    private int id;
    private string f;

    public string Str_F
    {
        get
        {
            return this.f;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bool btel = false;
        if (this.Request.QueryString["itel"] != null)
            btel = true;
        FunLibrary.ChkHead(btel);
        int.TryParse(this.Request["id"], out this.id);
        if (this.id == 0)
            this.Response.End();
        this.f = this.Request["f"];
        if (this.f == null || this.f == "")
            this.f = "";
        if (this.IsPostBack)
            return;
        OtherFunction.BindProductBrand(this.ddlBrand);
        OtherFunction.BindProductClass(this.ddlClass);
        OtherFunction.BindProductModel(this.ddlModel, "");
        OtherFunction.BindProductAspect(this.ddlAspect);
        OtherFunction.BindWarranty(this.ddlRepStatus);
        int result = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result);
        DataTable dataTable1 = new DALSys().GetLayoutDetail(1, 1, 16, 0, result).Tables[0];
        if (dataTable1.Rows.Count > 0)
        {
            for (int index = 0; index < dataTable1.Rows.Count; ++index)
            {
                switch (dataTable1.Rows[index]["FieldName"].ToString())
                {
                    case "userdef1":
                        this.lbuserdef1.Text = dataTable1.Rows[index]["TitleName"].ToString();
                        break;
                    case "userdef2":
                        this.lbuserdef2.Text = dataTable1.Rows[index]["TitleName"].ToString();
                        break;
                    case "userdef3":
                        this.lbuserdef3.Text = dataTable1.Rows[index]["TitleName"].ToString();
                        break;
                    case "userdef4":
                        this.lbuserdef4.Text = dataTable1.Rows[index]["TitleName"].ToString();
                        break;
                    case "userdef5":
                        this.lbuserdef5.Text = dataTable1.Rows[index]["TitleName"].ToString();
                        break;
                }
            }
        }
        else
        {
            this.lbuserdef1.Text = "自定义1";
            this.lbuserdef2.Text = "自定义2";
            this.lbuserdef3.Text = "自定义3";
            this.lbuserdef4.Text = "自定义4";
            this.lbuserdef5.Text = "自定义5";
        }
        int RightID = int.Parse((string)this.Session["Session_wtPurID"]);
        if (RightID > 0)
        {
            DALRight dalRight = new DALRight();
            string str1 = "";
            if (!dalRight.GetRight(RightID, "kh_r8"))
                this.btnAdd.Enabled = false;
            string str2;
            if (!dalRight.GetRight(RightID, "jc_r9"))
            {
                this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
                str2 = str1 + "0";
            }
            else
                str2 = str1 + "1";
            string str3;
            if (!dalRight.GetRight(RightID, "jc_r10"))
            {
                this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
                str3 = str2 + "0";
            }
            else
                str3 = str2 + "1";
            string str4;
            if (!dalRight.GetRight(RightID, "jc_r11"))
            {
                this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
                str4 = str3 + "0";
            }
            else
                str4 = str3 + "1";
            this.hfbAddBCM.Value = str4;
        }
        if (this.f != "")
        {
            this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
            this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
            this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
            this.ddlAspect.Items.Remove(new ListItem("新建...", "0"));
            this.ddlRepStatus.Items.Remove(new ListItem("新建...", "0"));
        }
        DataTable dataTable2 = DALCommon.GetDataList("ks_device", "", " [ID]=" + this.id.ToString()).Tables[0];
        if (dataTable2.Rows.Count > 0)
        {
            this.hfCusID.Value = dataTable2.Rows[0]["CustomerID"].ToString();
            this.tbCusName.Text = dataTable2.Rows[0]["_Name"].ToString();
            this.tbName.Text = dataTable2.Rows[0]["LinkMan"].ToString();
            this.tbDept.Text = dataTable2.Rows[0]["CusDept"].ToString();
            this.tbTel.Text = dataTable2.Rows[0]["Tel"].ToString();
            this.tbTel2.Text = dataTable2.Rows[0]["Tel2"].ToString();
            this.tbFax.Text = dataTable2.Rows[0]["Fax"].ToString();
            this.tbZip.Text = dataTable2.Rows[0]["Zip"].ToString();
            this.tbAdr.Text = dataTable2.Rows[0]["Adr"].ToString();
            for (int index = 0; index < this.ddlBrand.Items.Count; ++index)
            {
                if (this.ddlBrand.Items[index].Text == dataTable2.Rows[0]["ProductBrand"].ToString())
                {
                    this.ddlBrand.Items[index].Selected = true;
                    this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
                    break;
                }
            }
            for (int index = 0; index < this.ddlClass.Items.Count; ++index)
            {
                if (this.ddlClass.Items[index].Text == dataTable2.Rows[0]["ProductClass"].ToString())
                {
                    this.ddlClass.Items[index].Selected = true;
                    this.tbClass.Text = this.ddlClass.SelectedItem.Text;
                    break;
                }
            }
            for (int index = 0; index < this.ddlModel.Items.Count; ++index)
            {
                if (this.ddlModel.Items[index].Text == dataTable2.Rows[0]["ProductModel"].ToString())
                {
                    this.ddlModel.Items[index].Selected = true;
                    this.tbModel.Text = this.ddlModel.SelectedItem.Text;
                    break;
                }
            }
            for (int index = 0; index < this.ddlProperty.Items.Count; ++index)
            {
                if (this.ddlProperty.Items[index].Text == dataTable2.Rows[0]["Property"].ToString())
                {
                    this.ddlProperty.Items[index].Selected = true;
                    break;
                }
            }
            this.tbBuyPrice.Text = dataTable2.Rows[0]["BuyPrice"].ToString();
            this.hfSN.Value = this.tbSN1.Text = dataTable2.Rows[0]["ProductSN1"].ToString();
            this.tbSN2.Text = dataTable2.Rows[0]["ProductSN2"].ToString();
            this.tbAspect.Value = dataTable2.Rows[0]["ProductAspect"].ToString();
            this.tbBuyDate.Text = dataTable2.Rows[0]["BuyDate"].ToString();
            this.tbBuyFrom.Text = dataTable2.Rows[0]["BuyFrom"].ToString();
            this.tbInvoice.Text = dataTable2.Rows[0]["BuyInvoice"].ToString();
            this.tbProt.Value = dataTable2.Rows[0]["MaintenancePeriod"].ToString();
            if (this.ddlRepStatus.Items.FindByValue(dataTable2.Rows[0]["WarrantyID"].ToString()) != null)
                this.ddlRepStatus.Items.FindByValue(dataTable2.Rows[0]["WarrantyID"].ToString()).Selected = true;
            this.tbRepNum.Text = dataTable2.Rows[0]["RepairTimes"].ToString();
            this.tbWStart.Text = dataTable2.Rows[0]["WarrantyStart"].ToString();
            this.tbWEnd.Text = dataTable2.Rows[0]["WarrantyEnd"].ToString();
            this.tbLastDate.Text = dataTable2.Rows[0]["Repairlately"].ToString();
            this.tbPStart.Text = dataTable2.Rows[0]["ContractWarrantyStart"].ToString();
            this.tbPEnd.Text = dataTable2.Rows[0]["ContractWarrantyEnd"].ToString();
            this.tbFinD.Text = dataTable2.Rows[0]["RepairWarrantyEnd"].ToString();
            this.tbContractNO.Text = dataTable2.Rows[0]["ContractNO"].ToString();
            this.tbInStall.Text = dataTable2.Rows[0]["InstallDate"].ToString();
            this.tbRemark.Text = dataTable2.Rows[0]["Remark"].ToString();
            this.hfDeviceNO.Value = this.tbDeviceNO.Text = dataTable2.Rows[0]["DeviceNO"].ToString();
            this.tbuserdef1.Text = dataTable2.Rows[0]["userdef1"].ToString();
            this.tbuserdef2.Text = dataTable2.Rows[0]["userdef2"].ToString();
            this.tbuserdef3.Text = dataTable2.Rows[0]["userdef3"].ToString();
            this.tbuserdef4.Text = dataTable2.Rows[0]["userdef4"].ToString();
            this.tbuserdef5.Text = dataTable2.Rows[0]["userdef5"].ToString();
            this.tbDisposal.Text = dataTable2.Rows[0]["Technicians"].ToString();
            this.ddlDept.DataSource = (object)DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
            this.ddlDept.DataTextField = "_Name";
            this.ddlDept.DataValueField = "ID";
            this.ddlDept.DataBind();
            this.ddlDept.Items.Insert(0, new ListItem("", ""));
            this.ddlLinkMan.DataSource = (object)DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
            this.ddlLinkMan.DataTextField = "_Name";
            this.ddlLinkMan.DataValueField = "ID";
            this.ddlLinkMan.DataBind();
            this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.hfCusID.Value == "")
        {
            DataTable dataTable = DALCommon.GetDataList("CustomerList", "[ID]", " _Name='" + FunLibrary.ChkInput(this.tbCusName.Text) + "' ").Tables[0];
            if (dataTable.Rows.Count == 1)
            {
                this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
            }
            else
            {
                this.hfCusID.Value = "";
                this.SysInfo("window.alert('操作失败！客户不存在，请添加');$(\"tbCusName\").focus()");
                return;
            }
        }
        string str = FunLibrary.ChkInput(this.tbDeviceNO.Text);
        if (this.hfDeviceNO.Value != str && str != "" && DALCommon.GetDataList("ks_device", "[ID]", " DeviceNO='" + str + "'").Tables[0].Rows.Count > 0)
        {
            this.SysInfo("window.alert('操作失败！该机器编号已存在，请修改');$(\"tbDeviceNO\").focus()");
        }
        else
        {
            if (!(this.tbSN1.Text.Trim() != string.Empty))
                return;
            DeviceListInfo model = new DeviceListInfo();
            model.ID = this.id;
            model.CustomerID = new int?(int.Parse(this.hfCusID.Value));
            model.ProductSN1 = FunLibrary.ChkInput(this.tbSN1.Text);
            if (this.hfSN.Value != model.ProductSN1)
            {
                if (DALCommon.GetDataList("ks_device", "[ID]", " CustomerID!=" + this.hfCusID.Value + " and ProductSN1='" + model.ProductSN1 + "'").Tables[0].Rows.Count > 0)
                {
                    this.SysInfo("window.alert('操作失败！已存在该序列号的机器档案，请修改');$(\"tbSN1\").focus()");
                    return;
                }
            }
            model.LinkMan = FunLibrary.ChkInput(this.tbName.Text);
            model.CusDept = FunLibrary.ChkInput(this.tbDept.Text);
            model.Tel = FunLibrary.ChkInput(this.tbTel.Text);
            model.Tel2 = FunLibrary.ChkInput(this.tbTel2.Text);
            model.Fax = FunLibrary.ChkInput(this.tbFax.Text);
            model.Zip = FunLibrary.ChkInput(this.tbZip.Text);
            model.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
            model.ProductBrandID = new int?(int.Parse(this.ddlBrand.SelectedValue));
            model.ProductClassID = new int?(int.Parse(this.ddlClass.SelectedValue));
            model.ProductModelID = new int?(int.Parse(this.ddlModel.SelectedValue));
            model.ProductSN2 = FunLibrary.ChkInput(this.tbSN2.Text);
            model.ProductAspect = FunLibrary.ChkInput(this.tbAspect.Value);
            model.BuyDate = FunLibrary.ChkInput(this.tbBuyDate.Text);
            model.BuyFrom = FunLibrary.ChkInput(this.tbBuyFrom.Text);
            model.BuyInvoice = FunLibrary.ChkInput(this.tbInvoice.Text);
            model.MaintenancePeriod = FunLibrary.ChkInput(this.tbProt.Value);
            model.WarrantyID = new int?(int.Parse(this.ddlRepStatus.SelectedValue));
            int result1 = 0;
            int.TryParse(FunLibrary.ChkInput(this.tbRepNum.Text), out result1);
            model.RepairTimes = new int?(result1);
            model.WarrantyStart = FunLibrary.ChkInput(this.tbWStart.Text);
            model.WarrantyEnd = FunLibrary.ChkInput(this.tbWEnd.Text);
            model.Repairlately = FunLibrary.ChkInput(this.tbLastDate.Text);
            model.ContractWarrantyStart = FunLibrary.ChkInput(this.tbPStart.Text);
            model.ContractWarrantyEnd = FunLibrary.ChkInput(this.tbPEnd.Text);
            model.RepairWarrantyEnd = FunLibrary.ChkInput(this.tbFinD.Text);
            model.ContractNO = FunLibrary.ChkInput(this.tbContractNO.Text);
            model.InstallDate = FunLibrary.ChkInput(this.tbInStall.Text);
            model.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
            model.DeviceNO = str;
            model.Property = int.Parse(this.ddlProperty.SelectedValue);
            Decimal result2 = new Decimal(0);
            Decimal.TryParse(this.tbBuyPrice.Text, out result2);
            model.BuyPrice = result2;
            model.userdef1 = FunLibrary.ChkInput(this.tbuserdef1.Text);
            model.userdef2 = FunLibrary.ChkInput(this.tbuserdef2.Text);
            model.userdef3 = FunLibrary.ChkInput(this.tbuserdef3.Text);
            model.userdef4 = FunLibrary.ChkInput(this.tbuserdef4.Text);
            model.userdef5 = FunLibrary.ChkInput(this.tbuserdef5.Text);
            model.Technicians = FunLibrary.ChkInput(this.tbDisposal.Text);
            string strMsg;
            switch (new DALDeviceList().Update(model, out strMsg))
            {
                case 0:
                    this.SysInfo("parent.CloseDialog" + this.f + "('1');");
                    break;
                case -1:
                    this.SysInfo("window.alert('" + strMsg + "');$('tbName').select();");
                    break;
                default:
                    this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
                    break;
            }
        }
    }

    protected void btnCusInfo_Click(object sender, EventArgs e)
    {
        if (!(this.hfCusID.Value != ""))
            return;
        this.ddlDept.DataSource = (object)DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
        this.ddlDept.DataTextField = "_Name";
        this.ddlDept.DataValueField = "ID";
        this.ddlDept.DataBind();
        this.ddlDept.Items.Insert(0, new ListItem("", ""));
        this.ddlLinkMan.DataSource = (object)DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
        this.ddlLinkMan.DataTextField = "_Name";
        this.ddlLinkMan.DataValueField = "ID";
        this.ddlLinkMan.DataBind();
        this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
    }

    protected void btnRefBrand_Click(object sender, EventArgs e)
    {
        OtherFunction.BindProductBrand(this.ddlBrand);
        if (this.hfbAddBCM.Value.Length != 3 || (int)this.hfbAddBCM.Value[0] != 49)
            this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
        if (!(this.hfBrand.Value != string.Empty))
            return;
        this.ddlBrand.ClearSelection();
        this.ddlBrand.Items.FindByText(this.hfBrand.Value).Selected = true;
        this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
    }

    protected void btnRefClass_Click(object sender, EventArgs e)
    {
        OtherFunction.BindProductClass(this.ddlClass);
        if (this.hfbAddBCM.Value.Length != 3 || (int)this.hfbAddBCM.Value[1] != 49)
            this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
        if (!(this.hfClass.Value != string.Empty))
            return;
        this.ddlClass.ClearSelection();
        this.ddlClass.Items.FindByText(this.hfClass.Value).Selected = true;
        this.tbClass.Text = this.ddlClass.SelectedItem.Text;
    }

    protected void btnRefModel_Click(object sender, EventArgs e)
    {
        if (!(this.hfModelID.Value != ""))
            return;
        OtherFunction.BindProductModel(this.ddlModel, "");
        if (this.hfbAddBCM.Value.Length != 3 || (int)this.hfbAddBCM.Value[2] != 49)
            this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
        DataTable dataTable = DALCommon.GetDataList("jc_productmodel", "", "ID=" + this.hfModelID.Value).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            this.ddlBrand.ClearSelection();
            this.ddlBrand.Items.FindByText(dataTable.Rows[0]["Brand"].ToString()).Selected = true;
            this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
            this.ddlClass.ClearSelection();
            this.ddlClass.Items.FindByText(dataTable.Rows[0]["Class"].ToString()).Selected = true;
            this.tbClass.Text = this.ddlClass.SelectedItem.Text;
            this.ddlModel.ClearSelection();
            this.ddlModel.Items.FindByText(dataTable.Rows[0]["_Name"].ToString()).Selected = true;
            this.tbModel.Text = this.ddlModel.SelectedItem.Text;
        }
    }

    protected void btnRefWarranty_Click(object sender, EventArgs e)
    {
        OtherFunction.BindWarranty(this.ddlRepStatus);
        if (!(this.hfWarranty.Value != string.Empty))
            return;
        this.ddlRepStatus.ClearSelection();
        this.ddlRepStatus.Items.FindByText(this.hfWarranty.Value).Selected = true;
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
        if (!(this.ddlModel.SelectedValue != "-1"))
            return;
        DataTable dataTable = DALCommon.GetDataList("jc_productmodel", "", "ID=" + this.ddlModel.SelectedValue).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            this.ddlBrand.ClearSelection();
            this.ddlBrand.Items.FindByText(dataTable.Rows[0]["Brand"].ToString()).Selected = true;
            this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
            this.ddlClass.ClearSelection();
            this.ddlClass.Items.FindByText(dataTable.Rows[0]["Class"].ToString()).Selected = true;
            this.tbClass.Text = this.ddlClass.SelectedItem.Text;
        }
    }

    protected void GetProductModel()
    {
        string strWhere = string.Empty;
        if (this.ddlBrand.SelectedValue != "0" && this.ddlBrand.SelectedValue != "-1")
            strWhere = strWhere + " BrandID=" + this.ddlBrand.SelectedValue;
        if (this.ddlClass.SelectedValue != "0" && this.ddlClass.SelectedValue != "-1")
            strWhere = !(strWhere == string.Empty) ? strWhere + " and ClassID=" + this.ddlClass.SelectedValue : strWhere + " ClassID=" + this.ddlClass.SelectedValue;
        this.tbModel.Text = "";
        OtherFunction.BindProductModel(this.ddlModel, strWhere);
        if (this.hfbAddBCM.Value.Length == 3 && (int)this.hfbAddBCM.Value[2] == 49)
            return;
        this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }

    protected void ddlLinkMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(this.hfCusID.Value != ""))
            return;
        DataTable dataTable = DALCommon.GetList("CustomerLinkMan", "[ID],LinkManDept,tel_Office,tel_Mobile,Fax,Adr", " CustomerID=" + this.hfCusID.Value + " and _Name='" + FunLibrary.ChkInput(this.tbName.Text) + "'").Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            this.tbDept.Text = dataTable.Rows[0]["LinkManDept"].ToString();
            this.tbTel.Text = dataTable.Rows[0]["tel_Office"].ToString();
            this.tbTel2.Text = dataTable.Rows[0]["tel_Mobile"].ToString();
            this.tbFax.Text = dataTable.Rows[0]["Fax"].ToString();
            this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
        }
    }
}
