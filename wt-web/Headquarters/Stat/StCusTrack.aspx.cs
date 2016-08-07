// Decompiled with JetBrains decompiler
// Type: Headquarters_Stat_StCusTrack
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
using wt.OtherLibrary;

public partial class Headquarters_Stat_StCusTrack : Page, IRequiresSessionState
{
    private Decimal dr4 = new Decimal(0);
    private Decimal dr5 = new Decimal(0);
    private Decimal dr6 = new Decimal(0);
    private Decimal dr7 = new Decimal(0);
    private Decimal dr8 = new Decimal(0);
    private Decimal dr9 = new Decimal(0);
    private Decimal dr10 = new Decimal(0);
    private Decimal dtest = new Decimal(0);
    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkHead();
        if (this.IsPostBack)
            return;
        int RightID = int.Parse((string)this.Session["Session_wtPurID"]);
        if (RightID > 0 && new DALRight().GetRight(RightID, "kh_r18"))
        {
            DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserID"]).Tables[0];
            if (dataTable.Rows.Count > 0)
                this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
        }
        OtherFunction.BindBranch(this.ddlBranch);
        this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
        this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-01");
        this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        if (this.hfOrder.Value != "ID")
            this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
    }

    protected void btnSch_Click(object sender, EventArgs e)
    {
        this.hfSch.Value = "0";
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void FillData(string sortExpression, string direction)
    {
        string str1 = FunLibrary.ChkInput(this.tbDateB.Text);
        string str2 = FunLibrary.ChkInput(this.tbDateE.Text);
        string strCondition = " 1=1 ";
        string fldSort = sortExpression + " " + direction;
        if (fldSort.Trim().Equals(""))
            fldSort = "_Date";
        int count = 0;
        if (this.ddlBranch.SelectedValue != "-1")
            strCondition = strCondition + " and OperatorDept=" + this.ddlBranch.SelectedValue;
        if (str1 != "")
            strCondition = strCondition + " and convert(char(10),_Date,120)>='" + str1 + "'";
        if (str2 != "")
            strCondition = strCondition + " and convert(char(10),_Date,120)<='" + str2 + " 23:59:59'";
        if (!this.tbOperator.Text.Trim().Equals(""))
            strCondition += string.Format(" and Operator like '%{0}%'", (object)this.tbOperator.Text.Trim());
        if (this.hfPurArea.Value != "")
            strCondition = strCondition + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
        this.gvdata.DataSource = (object)DALCommon.GetList_HL(0, "ks_customertrack", "", 0, 0, strCondition, fldSort, out count);
        this.gvdata.DataBind();
        this.hfTbTitle.Value = this.hfTbField.Value = string.Empty;
        if (this.gvdata.Rows.Count <= 0)
            return;
        for (int index = 0; index < this.gvdata.HeaderRow.Cells.Count; ++index)
        {
            if (index > 0)
            {
                string dataField = ((BoundField)this.gvdata.Columns[index]).DataField;
                string text = this.gvdata.HeaderRow.Cells[index].Text;
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("id", dataField);
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("onclick", "HeaderOrder('" + dataField + "','" + text + "');");
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("onmouseover", "this.style.cursor='default';");
                if (dataField != "ID")
                {
                    if (this.hfTbTitle.Value == string.Empty)
                    {
                        this.hfTbTitle.Value = text;
                    }
                    else
                    {
                        HiddenField hiddenField = this.hfTbTitle;
                        string str3 = hiddenField.Value + "," + text;
                        hiddenField.Value = str3;
                    }
                    if (this.hfTbField.Value == string.Empty)
                    {
                        this.hfTbField.Value = dataField;
                    }
                    else
                    {
                        HiddenField hiddenField = this.hfTbField;
                        string str3 = hiddenField.Value + "," + dataField;
                        hiddenField.Value = str3;
                    }
                }
            }
        }
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
        }
        if (e.Row.RowType != DataControlRowType.Footer)
        { }
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string str1 = FunLibrary.ChkInput(this.tbDateB.Text);
        string str2 = FunLibrary.ChkInput(this.tbDateE.Text);
        string strCondition = " 1=1 ";
        int count = 0;
        if (this.ddlBranch.SelectedValue != "-1")
            strCondition = strCondition + " and OperatorDept=" + this.ddlBranch.SelectedValue;
        if (str1 != "")
            strCondition = strCondition + " and convert(char(10),_Date,120)>='" + str1 + "'";
        if (str2 != "")
            strCondition = strCondition + " and convert(char(10),_Date,120)<='" + str2 + " 23:59:59'";
        if (!this.tbOperator.Text.Trim().Equals(""))
            strCondition += string.Format(" and Operator like '%{0}%'", (object)this.tbOperator.Text.Trim());
        string fldSort = this.hfOrderName.Value + " " + this.hfOrder.Value;
        DataTable dt = DALCommon.GetList_HL(0, "ks_customertrack", this.hfTbField.Value, 0, 0, strCondition, fldSort, out count).Tables[0];
        string[] TbTitle = this.hfTbTitle.Value.Split(',');
        string result = string.Empty;
        bool iFlag = false;
        DataToExcel.DataTableToExcel(dt, TbTitle, Guid.NewGuid().ToString() + ".xls", "客户跟踪汇总", out iFlag, out result);
        if (iFlag)
            return;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        this.SysInfo("window.alert(\"" + result + "\");");
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }
}
