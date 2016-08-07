// Decompiled with JetBrains decompiler
// Type: Headquarters_Stat_stSerTakeSteps
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

public partial class Headquarters_Stat_stSerTakeSteps : Page, IRequiresSessionState
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
        if (int.Parse((string)this.Session["Session_wtPurID"]) > 0)
        {
            DALRight dalRight = new DALRight();
        }
        OtherFunction.BindBranch(this.ddlBranch);
        this.ddlBranch.Items.Insert(0, new ListItem("È«²¿", "-1"));
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
        string strCondition = this.strParm();
        string fldSort = sortExpression + " " + direction;
        if (fldSort.Trim().Equals(""))
            fldSort = "_Date";
        int count = 0;
        this.gvdata.DataSource = (object)DALCommon.GetList_HL(0, "fw_takesteps", "", 0, 0, strCondition, fldSort, out count);
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
                        string str = hiddenField.Value + "," + text;
                        hiddenField.Value = str;
                    }
                    if (this.hfTbField.Value == string.Empty)
                    {
                        this.hfTbField.Value = dataField;
                    }
                    else
                    {
                        HiddenField hiddenField = this.hfTbField;
                        string str = hiddenField.Value + "," + dataField;
                        hiddenField.Value = str;
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
        string strCondition = this.strParm();
        int count = 0;
        string fldSort = this.hfOrderName.Value + " " + this.hfOrder.Value;
        DataTable dt = DALCommon.GetList_HL(0, "fw_takesteps", this.hfTbField.Value, 0, 0, strCondition, fldSort, out count).Tables[0];
        string[] TbTitle = this.hfTbTitle.Value.Split(',');
        string result = string.Empty;
        bool iFlag = false;
        DataToExcel.DataTableToExcel(dt, TbTitle, Guid.NewGuid().ToString() + ".xls", "¹ÊÕÏ»ã×Ü", out iFlag, out result);
        if (iFlag)
            return;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        this.SysInfo("window.alert(\"" + result + "\");");
    }

    protected string strParm()
    {
        string str1 = " 1=1 ";
        string str2 = FunLibrary.ChkInput(this.tbDateB.Text);
        string str3 = FunLibrary.ChkInput(this.tbDateE.Text);
        if (!str2.Equals(""))
            str1 += string.Format(" and ArrivedTime>='{0}'", (object)str2);
        if (!str3.Equals(""))
            str1 += string.Format(" and ArrivedTime<='{0}'", (object)str3);
        if (!this.ddlBranch.SelectedValue.Equals("-1"))
            str1 += string.Format(" and Dept='{0}' ", (object)this.ddlBranch.SelectedItem.Text.Trim());
        return str1;
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }
}
