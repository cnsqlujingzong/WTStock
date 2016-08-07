// Decompiled with JetBrains decompiler
// Type: Branch_Stock_SltPrice
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

public partial class Branch_Stock_SltPrice : Page, IRequiresSessionState
{
 
    private string strfid;
    private string f;
    private string id;
    private string uid;
    private string tbprice;
    private int flag;
    private int icusid;
    

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
        FunLibrary.ChkBran();
        this.id = this.Request["id"];
        this.uid = this.Request["uid"];
        this.tbprice = this.Request["tbprice"];
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
        int RightID = int.Parse((string)this.Session["Session_wtPurBID"]);
        if (RightID > 0)
        {
            DALRight dalRight = new DALRight();
            if (dalRight.GetRight(RightID, "jc_r12"))
                flag1 = true;
            if (dalRight.GetRight(RightID, "jc_r14"))
                flag2 = true;
        }
        DataTable dataTable = DALCommon.GetGoodsPriceList(this.flag, int.Parse((string)this.Session["Session_wtBranchID"]), int.Parse(this.id.Replace("p", "")), int.Parse(this.uid), this.icusid, -1).Tables[0];
        DataTable gridViewSource = this.GridViewSource;
        for (int index = 0; index < dataTable.Rows.Count; ++index)
        {
            DataRow row = gridViewSource.NewRow();
            row[0] = (object)dataTable.Rows[index]["_Name"].ToString();
            row[1] = (object)dataTable.Rows[index]["Price"].ToString();
            if ((!flag1 || !(dataTable.Rows[index]["_Name"].ToString() == "进货价")) && (!flag2 || !(dataTable.Rows[index]["_Name"].ToString() == "库存均价")))
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
