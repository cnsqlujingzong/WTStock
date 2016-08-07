// Decompiled with JetBrains decompiler
// Type: Headquarters_System_Reminder
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

public partial class Headquarters_System_Reminder : Page, IRequiresSessionState
{
    private int pageSize = 18;
    private string strfid;
    private string f;
    private string flag;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkHead();
        this.strfid = this.Request["fid"];
        this.flag = this.Request["f"];
        if (this.flag == null || this.flag == string.Empty)
            this.flag = "2";
        if (this.strfid == null || this.strfid == string.Empty)
        {
            this.strfid = "iframeDialog";
            this.f = "1";
        }
        else
            this.f = "";
        if (this.IsPostBack)
            return;
        if (int.Parse((string)this.Session["Session_wtPurID"]) <= 0)
        {}
        this.FillData();
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
        this.FillData();
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        this.FillData();
        if (this.hfOrder.Value != "ID")
            this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
    }

    protected void FillData()
    {
        DataTable dataTable = DALCommon.GetList("serviceslist", "*", this.strParm()).Tables[0];
        this.gvdata.DataSource = (object)dataTable;
        this.gvdata.DataBind();
        this.lbCount.Text = "总记录:" + dataTable.Rows.Count.ToString();
        if (this.lbCount.Text == "总记录:0")
            this.lbCount.Visible = false;
        else
            this.lbCount.Visible = true;
        if (this.gvdata.Rows.Count <= 0)
            return;
        for (int index = 0; index < this.gvdata.HeaderRow.Cells.Count; ++index)
        {
            if (index > 1)
            {
                string dataField = ((BoundField)this.gvdata.Columns[index]).DataField;
                string text = this.gvdata.HeaderRow.Cells[index].Text;
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("id", dataField);
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("onclick", "HeaderOrder('" + dataField + "','" + text + "');");
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("onmouseover", "this.style.cursor='default';");
            }
        }
    }

    protected void jsPager_PageChanged(object sender, EventArgs e)
    {
    }

    protected string strParm()
    {
        string str = " id in (select billid from fw_servicespush) and (curStatus ='待处理' or curStatus = '处理中') and disposalid = 1  ";
        string strcon = FunLibrary.ChkInput(this.tbCon.Text);
        if (this.ddlKey.SelectedValue != "-1")
        {
            int result = 0;
            int.TryParse(this.ddlKey.SelectedValue, out result);
            if (strcon != "")
            {
                DALServices dalServices = new DALServices();
                str += dalServices.GetSchWhere(result, strcon);
            }
        }
        return str;
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Attributes.Add("style", "padding:auto 5px;");
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;
        e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
        e.Row.Attributes.Add("ondblclick", "ChkView();");
        e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }
}
