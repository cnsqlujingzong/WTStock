// Decompiled with JetBrains decompiler
// Type: Branch_Financial_SchFullExpense
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

public partial class Branch_Financial_SchFullExpense : Page, IRequiresSessionState
{
    private int pageSize = 20;
    private bool blayout = false;
    private int itake = 23;
    private int iflag;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkBran();
        if (this.IsPostBack)
            return;
        int RightID = int.Parse((string)this.Session["Session_wtPurBID"]);
        if (RightID > 0 && !new DALRight().GetRight(RightID, "zk_r24"))
        {
            this.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
            this.Response.End();
        }
        this.FillData();
        TextBox textBox1 = this.tbDateB;
        DateTime now = DateTime.Now;
        string str1 = now.ToString("yyyy-MM") + "-01";
        textBox1.Text = str1;
        TextBox textBox2 = this.tbDateE;
        now = DateTime.Now;
        string str2 = now.ToString("yyyy-MM-dd");
        textBox2.Text = str2;
    }

    protected void btnClr_Click(object sender, EventArgs e)
    {
        this.FillData();
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
    }

    protected void btnSch_Click(object sender, EventArgs e)
    {
        this.FillData();
    }

    protected void btnSchH_Click(object sender, EventArgs e)
    {
    }

    protected void btnFsh_Click(object sender, EventArgs e)
    {
        this.FillData();
    }

    protected void LoadField(DataSet ds)
    {
        DataTable dataTable = ds.Tables[0];
        if (dataTable.Rows.Count <= 0)
            return;
        this.gvdata.Columns.Clear();
        BoundField boundField1 = new BoundField();
        boundField1.DataField = "姓名";
        boundField1.HeaderText = "姓名";
        this.gvdata.Columns.Add((DataControlField)boundField1);
        BoundField boundField2 = new BoundField();
        boundField2.DataField = "所属网点";
        boundField2.HeaderText = "所属网点";
        this.gvdata.Columns.Add((DataControlField)boundField2);
        BoundField boundField3 = new BoundField();
        boundField3.DataField = "日期";
        boundField3.HeaderText = "日期";
        this.gvdata.Columns.Add((DataControlField)boundField3);
        BoundField boundField4 = new BoundField();
        boundField4.DataField = "关联业务";
        boundField4.HeaderText = "关联业务";
        this.gvdata.Columns.Add((DataControlField)boundField4);
        for (int index = 4; index < dataTable.Columns.Count; ++index)
        {
            BoundField boundField5 = new BoundField();
            if (index == dataTable.Columns.Count - 1)
            {
                boundField5.HeaderText = dataTable.Columns[index].Caption.ToString();
                boundField5.DataField = dataTable.Columns[index].Caption.ToString();
            }
            else
            {
                boundField5.HeaderText = dataTable.Columns[index].Caption.ToString().TrimStart('c');
                boundField5.DataField = dataTable.Columns[index].Caption.ToString();
            }
            this.gvdata.Columns.Add((DataControlField)boundField5);
        }
        this.blayout = true;
    }

    protected void FillData()
    {
        DataSet listBx = DALCommon.GetListBX(this.tbDateB.Text, this.tbDateE.Text, this.ddlStatus.SelectedValue, 3, this.tbCon.Text, this.Session["Session_wtBranch"].ToString());
        this.LoadField(listBx);
        this.gvdata.DataSource = (object)listBx.Tables[0];
        this.gvdata.DataBind();
        this.lbCount.Text = (listBx.Tables[0].Rows.Count - 1).ToString();
        if (this.lbCount.Text == "-1")
        {
            this.lbCount.Text = "无信息记录";
            this.lbPage.Visible = false;
            this.lbCountText.Visible = false;
        }
        else
        {
            this.lbCount.Visible = true;
            this.lbPage.Visible = true;
            this.lbCountText.Visible = true;
        }
    }

    protected void jsPager_PageChanged(object sender, EventArgs e)
    {
    }

    protected string strParm()
    {
        return "  ";
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[4].Visible = false;
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }

    protected void btnExcelDe_Click(object sender, EventArgs e)
    {
        DataToExcel.CreateExcel(DALCommon.GetListBX(this.tbDateB.Text, this.tbDateE.Text, this.ddlStatus.SelectedValue, 3, this.tbCon.Text, this.Session["Session_wtBranch"].ToString()));
    }
}
