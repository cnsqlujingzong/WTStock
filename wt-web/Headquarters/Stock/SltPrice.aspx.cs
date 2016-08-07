// Decompiled with JetBrains decompiler
// Type: Headquarters_Stock_SltPrice
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

public partial class Headquarters_Stock_SltPrice : Page, IRequiresSessionState
{
    private string strfid;
    private string f;
    private string id;
    private string uid;
    private string tbprice;
    private int flag;
    private int icusid;
    private string stockid;

    private DataTable GridViewSource
    {
        get
        {
            if (this.ViewState["List"] == null)
                this.ViewState["List"] = (object)new DataTable()
                {
                    Columns = {
            new DataColumn("_Name", typeof (string)),
            new DataColumn("Price", typeof (string))
          }
                };
            return (DataTable)this.ViewState["List"];
        }
        set
        {
            this.ViewState["List"] = (object)value;
        }
    }

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

    public string Str_Price
    {
        get
        {
            return this.tbprice;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkHead();
        this.id = this.Request["id"];
        this.uid = this.Request["uid"];
        this.tbprice = this.Request["tbprice"];
        this.stockid = this.Request["stockid"];
        if (this.stockid == null || this.stockid == "")
            this.stockid = "-1";
        int.TryParse(this.Request["flag"], out this.flag);
        int.TryParse(this.Request["cusid"], out this.icusid);
        if (this.id == null || this.id == string.Empty || (this.uid == null || this.uid == string.Empty) || this.tbprice == null || this.flag == 0)
            this.Response.End();
        this.strfid = this.Request["fid"];
        if (this.strfid == null || this.strfid == string.Empty)
        {
            this.strfid = "iframeDialog";
            this.f = "1";
        }
        else
            this.f = "";
        if (this.Request["f"] != null)
            this.f = this.Request["f"].Trim();
        if (this.IsPostBack)
            return;
        this.FillData();
    }

    protected void FillData()
    {
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        bool flag5 = false;
        bool flag6 = false;
        bool flag7 = false;
        bool flag8 = false;
        int RightID = int.Parse((string)this.Session["Session_wtPurID"]);
        if (RightID > 0)
        {
            DALRight dalRight = new DALRight();
            if (dalRight.GetRight(RightID, "jc_r26"))
                flag1 = true;
            if (dalRight.GetRight(RightID, "jc_r36"))
                flag8 = true;
        }
        int result = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result);
        DataTable dataTable1 = new DALSys().GetLayoutDetail(1, 1, 1, 0, result).Tables[0];
        if (dataTable1.Rows.Count > 0)
        {
            for (int index = 0; index < dataTable1.Rows.Count; ++index)
            {
                string str = dataTable1.Rows[index]["FieldName"].ToString();
                if (str == "PriceCost")
                    flag2 = true;
                if (str == "PriceInner")
                    flag3 = true;
                if (str == "PriceDetail")
                    flag4 = true;
                if (str == "PriceWholesale1")
                    flag5 = true;
                if (str == "PriceWholesale2")
                    flag6 = true;
                if (str == "PriceWholesale3")
                    flag7 = true;
            }
        }
        else
        {
            flag2 = true;
            flag3 = true;
            flag4 = true;
            flag5 = true;
            flag6 = true;
            flag7 = true;
        }
        DataTable dataTable2 = !(this.stockid == "-1") ? DALCommon.GetGoodsPriceList(this.flag, 1, int.Parse(this.id.Replace("p", "")), int.Parse(this.uid), this.icusid, int.Parse(this.stockid)).Tables[0] : DALCommon.GetGoodsPriceList(this.flag, 1, int.Parse(this.id.Replace("p", "")), int.Parse(this.uid), this.icusid, -1).Tables[0];
        DataTable gridViewSource = this.GridViewSource;
        for (int index = 0; index < dataTable2.Rows.Count; ++index)
        {
            DataRow row = gridViewSource.NewRow();
            row[0] = (object)dataTable2.Rows[index]["_Name"].ToString();
            row[1] = (object)dataTable2.Rows[index]["Price"].ToString();
            if ((!flag1 || !(dataTable2.Rows[index]["_Name"].ToString() == "进货价")) && (!flag8 || !(dataTable2.Rows[index]["_Name"].ToString() == "库存均价")) && ((flag2 || !(dataTable2.Rows[index]["_Name"].ToString() == "进货价")) && (flag4 || !(dataTable2.Rows[index]["_Name"].ToString() == "零售价"))) && ((flag3 || !(dataTable2.Rows[index]["_Name"].ToString() == "内部价")) && (flag5 || !(dataTable2.Rows[index]["_Name"].ToString() == "旧货价")) && ((flag6 || !(dataTable2.Rows[index]["_Name"].ToString() == "替代价")) && (flag7 || !(dataTable2.Rows[index]["_Name"].ToString() == "列表价")))))
                gridViewSource.Rows.Add(row);
        }
        this.GridViewSource = gridViewSource;
        this.BindData();
    }

    private void BindData()
    {
        this.gvdata.DataSource = (object)this.GridViewSource;
        this.gvdata.DataBind();
    }

    protected void CollectData()
    {
        for (int index = 0; index < this.gvdata.Rows.Count; ++index)
        {
            TextBox textBox = this.gvdata.Rows[index].FindControl("tbQty") as TextBox;
            this.GridViewSource.Rows[index][2] = (object)textBox.Text;
        }
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;
        e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
        e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "','" + e.Row.Cells[2].Text + "');");
        e.Row.Attributes.Add("ondblclick", "ChkSltList();");
        e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
        e.Row.Cells[0].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
        e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }
}
