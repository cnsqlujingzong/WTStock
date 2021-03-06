// Decompiled with JetBrains decompiler
// Type: Web_SltGoods
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
using Wuqi.Webdiyer;

public partial class Web_SltGoods : Page, IRequiresSessionState
{
    private int pageSize = 15;
    private bool ilayout = false;
    private string strfid;
    private string f;
    private string id;
    private string flag;
    private string ifd;
  

    public string Str_Fid
    {
        get
        {
            return this.strfid;
        }
    }

    public string Str_F
    {
        get
        {
            return this.f;
        }
    }

    public string Str_Flag
    {
        get
        {
            return this.flag;
        }
    }

    public string Str_Ifd
    {
        get
        {
            return this.ifd;
        }
    }

   

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ChkWebUser();
        this.strfid = this.Request["fid"];
        this.id = this.Request["id"];
        this.flag = this.Request["flag"];
        this.ifd = this.Request["f"];
        this.flag = this.flag != null && !(this.flag == "") ? "1" : "2";
        if (this.strfid == null || this.strfid == string.Empty)
        {
            this.strfid = "iframeDialog";
            this.f = "1";
        }
        else
            this.f = "";
        if (this.ifd == null || this.ifd == "")
            this.ifd = "1";
        if (this.IsPostBack)
            return;
        this.FillData();
    }

    protected void LoadField()
    {
        int result = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result);
        DataTable dataTable = new DALSys().GetLayoutDetail(1, 1, 1, 0, result).Tables[0];
        if (dataTable.Rows.Count <= 0)
            return;
        this.gvgds.Columns.Clear();
        BoundField boundField1 = new BoundField();
        boundField1.DataField = "ID";
        boundField1.HeaderText = "ID";
        this.gvgds.Columns.Add((DataControlField)boundField1);
        TemplateField templateField = new TemplateField();
        templateField.HeaderText = "<input id=\"cball\" type=\"checkbox\" class=\"cb1\" onclick=\"allcb();\" title=\"全选/取消全选\"/>";
        templateField.ItemTemplate = (ITemplate)new MyTemplategdsone("", DataControlRowType.DataRow);
        this.gvgds.Columns.Add((DataControlField)templateField);
        for (int index = 0; index < dataTable.Rows.Count; ++index)
        {
            BoundField boundField2 = new BoundField();
            boundField2.DataField = dataTable.Rows[index]["FieldName"].ToString();
            boundField2.HeaderText = dataTable.Rows[index]["TitleName"].ToString();
            if ((!(this.hfPurCost.Value == "1") || !(boundField2.DataField == "PriceCost")) && (!(this.hfPurProv.Value == "1") || !(boundField2.DataField == "Provider")))
            {
                this.ilayout = true;
                this.gvgds.Columns.Add((DataControlField)boundField2);
            }
        }
    }

    protected void btnClr_Click(object sender, EventArgs e)
    {
        this.FillData();
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
    }

    protected void btnSch_Click(object sender, EventArgs e)
    {
        this.hfRecID.Value = "-1";
        this.FillData();
    }

    protected void FillData()
    {
        int count = 0;
        string strCondition = this.strParm();
        if (this.id != null && this.id != string.Empty)
            strCondition = strCondition + " and ID<>" + this.id;
        string fldSort = "ID desc";
        this.gvgds.DataSource = (object)DALCommon.GetList_HL(1, "ck_goods", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, fldSort, out count);
        this.gvgds.DataBind();
        this.lbCount.Text = "总记录:" + count.ToString();
        if (this.lbCount.Text == "总记录:0")
        {
            this.lbCount.Visible = false;
            this.lbPage.Visible = false;
        }
        else
        {
            this.lbCount.Visible = true;
            this.lbPage.Visible = true;
        }
        this.jsPager.PageSize = this.pageSize;
        this.jsPager.RecordCount = count;
    }

    protected void jsPager_PageChanged(object sender, EventArgs e)
    {
        this.hfRecID.Value = "-1";
        this.FillData();
    }

    protected string strParm()
    {
        string str = " bStop='' ";
        string strcon = FunLibrary.ChkInput(this.tbCon.Text);
        if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
            str = !(this.hfClass.Value == "0") ? str + " and _Level like '" + this.hfClass.Value + "%'" : str + " and ClassID is null ";
        else if (this.hfClassID.Value == "-2")
            str += " and ClassID is null ";
        if (this.ddlKey.SelectedValue != "-1")
        {
            int result = 0;
            int.TryParse(this.ddlKey.SelectedValue, out result);
            if (strcon != "")
            {
                DALGoods dalGoods = new DALGoods();
                str += dalGoods.GetSchWhere(result, strcon);
            }
        }
        return str;
    }

    protected void gvgds_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        if (!this.ilayout)
        {
            if (this.hfPurCost.Value == "1")
                e.Row.Cells[9].Visible = false;
            if (this.hfPurProv.Value == "1")
                e.Row.Cells[16].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
            e.Row.Attributes.Add("ondblclick", "ChkSltList();");
            e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:5px;");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            e.Row.Cells[1].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" onclick=\"cbone(this);\"/>";
            if (e.Row.Cells[12].Text != "&nbsp;")
                e.Row.Cells[12].Text = "<a target='_blank' href='../Headquarters/Images/" + e.Row.Cells[12].Text + "'>查看图片</a>";
        }
        if (e.Row.RowType != DataControlRowType.Footer)
            return;
        this.lbPage.Text = "当前页:" + this.gvgds.Rows.Count.ToString();
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }

    protected void btnStockDept_Click(object sender, EventArgs e)
    {
        this.GetStockDept();
    }

    protected void GetStockDept()
    {
        string str = " and DeptID=1 ";
        if (this.hfStock.Value == "1")
            str = " and bReject<>1 ";
        if (this.hfStockR.Value == "1")
            str = " and bReject<>0 ";
        this.GridView1.DataSource = (object)DALCommon.GetDataList("ck_stockdept", "", " GoodsID=" + this.hfRecID.Value + str).Tables[0];
        this.GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;
        e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
        e.Row.Attributes.Add("onclick", "ChkID2('s" + e.Row.Cells[0].Text + "');");
        e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
        e.Row.Cells[3].Attributes.Add("style", "font-weight:bold;");
    }

    public void ChkWebUser()
    {
        if (this.Session["Session_Web_Name"] != null && this.Session["Session_Web_ID"] != null)
            return;
        this.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
        this.Response.End();
    }
}
