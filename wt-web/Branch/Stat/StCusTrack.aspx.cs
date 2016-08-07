//using System;
//using System.Data;
//using System.Web;
//using System.Web.Profile;
//using System.Web.SessionState;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using wt.DAL;
//using wt.Library;
//using wt.OtherLibrary;

//public class Branch_Stat_StCusTrack : Page, IRequiresSessionState
//{
//    protected ScriptManager ScriptManager1;

//    protected DropDownList ddlBranch;

//    protected TextBox tbDateB;

//    protected TextBox tbDateE;

//    protected TextBox tbOperator;

//    protected Button btnSch;

//    protected Button btnExcel;

//    protected Button btnOrder;

//    protected GridView gvdata;

//    protected HiddenField hfRecID;

//    protected HiddenField hfSch;

//    protected HiddenField hfOrderName;

//    protected HiddenField hfOrderTitle;

//    protected HiddenField hfOrder;

//    protected HiddenField hfSql;

//    protected HiddenField hfTbTitle;

//    protected HiddenField hfTbField;

//    protected HiddenField hfPurArea;

//    protected Label lbCount;

//    protected UpdatePanel UpdatePanel1;

//    protected HtmlForm form1;

//    private decimal dr4 = 0m;

//    private decimal dr5 = 0m;

//    private decimal dr6 = 0m;

//    private decimal dr7 = 0m;

//    private decimal dr8 = 0m;

//    private decimal dr9 = 0m;

//    private decimal dr10 = 0m;

//    private decimal dtest = 0m;

//    protected DefaultProfile Profile
//    {
//        get
//        {
//            return (DefaultProfile)this.Context.Profile;
//        }
//    }

//    protected HttpApplication ApplicationInstance
//    {
//        get
//        {
//            return this.Context.ApplicationInstance;
//        }
//    }

//    protected void Page_Load(object sender, EventArgs e)
//    {
//        FunLibrary.ChkBran();
//        if (!base.IsPostBack)
//        {
//            int num = int.Parse((string)this.Session["Session_wtPurBID"]);
//            if (num > 0)
//            {
//                DALRight dALRight = new DALRight();
//                if (dALRight.GetRight(num, "kh_r10"))
//                {
//                    DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserBID"]).Tables[0];
//                    if (dataTable.Rows.Count > 0)
//                    {
//                        this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
//                    }
//                }
//            }
//            OtherFunction.BindBranch(this.ddlBranch);
//            this.ddlBranch.Items.Add(new ListItem(this.Session["Session_wtBranch"].ToString(), this.Session["Session_wtBranchID"].ToString()));
//            this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-01");
//            this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
//            this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
//        }
//    }

//    protected void btnOrder_Click(object sender, EventArgs e)
//    {
//        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
//        if (this.hfOrder.Value != "ID")
//        {
//            this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
//        }
//        if (this.hfRecID.Value != "-1")
//        {
//            this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
//        }
//    }

//    protected void btnSch_Click(object sender, EventArgs e)
//    {
//        this.hfSch.Value = "0";
//        this.hfRecID.Value = "-1";
//        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
//    }

//    protected void FillData(string sortExpression, string direction)
//    {
//        string text = FunLibrary.ChkInput(this.tbDateB.Text);
//        string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
//        string text3 = " 1=1 ";
//        string text4 = sortExpression + " " + direction;
//        if (text4.Trim().Equals(""))
//        {
//            text4 = "_Date";
//        }
//        int num = 0;
//        if (this.ddlBranch.SelectedValue != "-1")
//        {
//            text3 = text3 + " and OperatorDept=" + this.ddlBranch.SelectedValue;
//        }
//        if (text != "")
//        {
//            text3 = text3 + " and convert(char(10),_Date,120)>='" + text + "'";
//        }
//        if (text2 != "")
//        {
//            text3 = text3 + " and convert(char(10),_Date,120)<='" + text2 + " 23:59:59'";
//        }
//        if (!this.tbOperator.Text.Trim().Equals(""))
//        {
//            text3 += string.Format(" and Operator like '%{0}%'", this.tbOperator.Text.Trim());
//        }
//        if (this.hfPurArea.Value != "")
//        {
//            text3 = text3 + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
//        }
//        this.gvdata.DataSource = DALCommon.GetList_HL(0, "ks_customertrack", "", 0, 0, text3, text4, out num);
//        this.gvdata.DataBind();
//        this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
//        if (this.gvdata.Rows.Count > 0)
//        {
//            for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
//            {
//                if (i > 0)
//                {
//                    string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
//                    string text5 = this.gvdata.HeaderRow.Cells[i].Text;
//                    this.gvdata.HeaderRow.Cells[i].Attributes.Add("id", dataField);
//                    this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
//                    {
//                        "HeaderOrder('",
//                        dataField,
//                        "','",
//                        text5,
//                        "');"
//                    }));
//                    this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
//                    if (dataField != "ID")
//                    {
//                        if (this.hfTbTitle.Value == string.Empty)
//                        {
//                            this.hfTbTitle.Value = text5;
//                        }
//                        else
//                        {
//                            HiddenField expr_33C = this.hfTbTitle;
//                            expr_33C.Value = expr_33C.Value + "," + text5;
//                        }
//                        if (this.hfTbField.Value == string.Empty)
//                        {
//                            this.hfTbField.Value = dataField;
//                        }
//                        else
//                        {
//                            HiddenField expr_38E = this.hfTbField;
//                            expr_38E.Value = expr_38E.Value + "," + dataField;
//                        }
//                    }
//                }
//            }
//        }
//    }

//    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
//    {
//        e.Row.Cells[0].Visible = false;
//        e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
//        if (e.Row.RowType == DataControlRowType.DataRow)
//        {
//            e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
//            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
//            e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
//            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
//            e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
//        }
//        if (e.Row.RowType == DataControlRowType.Footer)
//        {
//        }
//    }

//    protected void btnExcel_Click(object sender, EventArgs e)
//    {
//        string text = FunLibrary.ChkInput(this.tbDateB.Text);
//        string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
//        string text3 = " 1=1 ";
//        int num = 0;
//        if (this.ddlBranch.SelectedValue != "-1")
//        {
//            text3 = text3 + " and OperatorDept=" + this.ddlBranch.SelectedValue;
//        }
//        if (text != "")
//        {
//            text3 = text3 + " and convert(char(10),_Date,120)>='" + text + "'";
//        }
//        if (text2 != "")
//        {
//            text3 = text3 + " and convert(char(10),_Date,120)<='" + text2 + " 23:59:59'";
//        }
//        if (!this.tbOperator.Text.Trim().Equals(""))
//        {
//            text3 += string.Format(" and Operator like '%{0}%'", this.tbOperator.Text.Trim());
//        }
//        string value = this.hfOrderName.Value;
//        string value2 = this.hfOrder.Value;
//        string fldSort = value + " " + value2;
//        DataTable dt = DALCommon.GetList_HL(0, "ks_customertrack", this.hfTbField.Value, 0, 0, text3, fldSort, out num).Tables[0];
//        string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
//        {
//            ','
//        });
//        string empty = string.Empty;
//        bool flag = false;
//        DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "客户跟踪汇总", out flag, out empty);
//        if (!flag)
//        {
//            this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
//            this.SysInfo("window.alert(\"" + empty + "\");");
//        }
//    }

//    protected void SysInfo(string str)
//    {
//        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
//    }
//}

// Decompiled with JetBrains decompiler
// Type: Branch_Stat_StCusTrack
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

public partial class Branch_Stat_StCusTrack : Page, IRequiresSessionState
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
        FunLibrary.ChkBran();
        if (this.IsPostBack)
            return;
        int RightID = int.Parse((string)this.Session["Session_wtPurBID"]);
        if (RightID > 0 && new DALRight().GetRight(RightID, "kh_r10"))
        {
            DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserBID"]).Tables[0];
            if (dataTable.Rows.Count > 0)
                this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
        }
        OtherFunction.BindBranch(this.ddlBranch);
        this.ddlBranch.Items.Add(new ListItem(this.Session["Session_wtBranch"].ToString(), this.Session["Session_wtBranchID"].ToString()));
        TextBox textBox1 = this.tbDateB;
        DateTime now = DateTime.Now;
        string str1 = now.ToString("yyyy-MM-01");
        textBox1.Text = str1;
        TextBox textBox2 = this.tbDateE;
        now = DateTime.Now;
        string str2 = now.ToString("yyyy-MM-dd");
        textBox2.Text = str2;
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
        {

        }

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
