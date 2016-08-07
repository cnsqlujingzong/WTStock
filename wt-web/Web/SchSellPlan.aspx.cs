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

public partial class Web_SchSellPlan : Page, IRequiresSessionState
{
    private int pageSize = 15;
    private Decimal dqty = new Decimal(0);
    private Decimal tqty = new Decimal(0);
    private Decimal dprice = new Decimal(0);
    private Decimal dtotal = new Decimal(0);
    private Decimal ddtotal = new Decimal(0);
    private Decimal dsqty = new Decimal(0);
    private Decimal dre1 = new Decimal(0);
    private Decimal dre2 = new Decimal(0);
    private Decimal dtaxamount = new Decimal(0);
    private Decimal dgoodsamount = new Decimal(0);
 

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ChkWebUser();
        if (this.IsPostBack)
            return;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void btnClr_Click(object sender, EventArgs e)
    {
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
        this.ShowDetail();
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        if (this.hfOrder.Value != "ID")
            this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
        this.ShowDetail();
    }

    protected void btnSch_Click(object sender, EventArgs e)
    {
        this.hfSch.Value = "0";
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void btnFsh_Click(object sender, EventArgs e)
    {
        this.hfSch.Value = "-1";
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void FillData(string sortExpression, string direction)
    {
        int count = 0;
        string strCondition = this.strParm();
        string fldSort = sortExpression + " " + direction;
        this.hfSql.Value = strCondition;
        this.gvdata.DataSource = (object)DALCommon.GetList_HL(1, "xs_sellplan", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, fldSort, out count);
        this.gvdata.DataBind();
        this.lbCount.Text = count.ToString();
        if (this.lbCount.Text == "0")
        {
            this.lbCount.Visible = false;
            this.lbPage.Visible = false;
            this.lbCountText.Visible = false;
        }
        else
        {
            this.lbCount.Visible = true;
            this.lbPage.Visible = true;
            this.lbCountText.Visible = true;
        }
        this.jsPager.PageSize = this.pageSize;
        this.jsPager.RecordCount = count;
        this.hfTbTitle.Value = this.hfTbField.Value = string.Empty;
        if (this.gvdata.Rows.Count <= 0)
            return;
        for (int index = 0; index < this.gvdata.HeaderRow.Cells.Count; ++index)
        {
            string dataField = ((BoundField)this.gvdata.Columns[index]).DataField;
            string text = this.gvdata.HeaderRow.Cells[index].Text;
            if (dataField != "" && dataField != "ID")
            {
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("id", dataField);
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("onclick", "HeaderOrder('" + dataField + "','" + text + "');");
                this.gvdata.HeaderRow.Cells[index].Attributes.Add("onmouseover", "this.style.cursor='default';");
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

    protected void jsPager_PageChanged(object sender, EventArgs e)
    {
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected string strParm()
    {
        string str = " CustomerNO='" + new DALAssociator().GetModel(int.Parse(this.Session["Session_Web_ID"].ToString())).CustomerNO + "' ";
        string strcon = FunLibrary.ChkInput(this.tbCon.Text);
        if (this.hfSch.Value == "0" && this.ddlKey.SelectedValue != "-1")
        {
            int result = 0;
            int.TryParse(this.ddlKey.SelectedValue, out result);
            if (strcon != "")
            {
                DALSellPlan dalSellPlan = new DALSellPlan();
                str += dalSellPlan.GetSchWhere(result, strcon);
            }
        }
        return str;
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            if (e.Row.Cells[1].Text == "待审核")
                e.Row.Attributes.Add("style", "color:#ff0000");
            else if (e.Row.Cells[1].Text == "已审核")
                e.Row.Attributes.Add("style", "color:#008000");
            if (e.Row.Cells[11].Text == "已执行")
                e.Row.Attributes.Add("style", "color:black");
        }
        if (e.Row.RowType != DataControlRowType.Footer)
            return;
        this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
    }

    protected void btnChk_Click(object sender, EventArgs e)
    {
        int result1 = 0;
        int.TryParse(this.hfRecID.Value, out result1);
        DALSellPlan dalSellPlan = new DALSellPlan();
        string strMsg = string.Empty;
        int result2 = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result2);
        int num = dalSellPlan.ChkSellPlan(1, result1, result2, out strMsg);
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        string str1 = "";
        string str2;
        if (num != 0)
            str2 = str1 + "window.alert('" + strMsg + "');ChkID('" + this.hfRecID.Value + "');";
        else
            str2 = "ChkID('" + this.hfRecID.Value + "');";
        this.SysInfo(str2);
    }

    protected void btnChkU_Click(object sender, EventArgs e)
    {
        int result1 = 0;
        int.TryParse(this.hfRecID.Value, out result1);
        DALSellPlan dalSellPlan = new DALSellPlan();
        string strMsg = string.Empty;
        int result2 = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result2);
        int num = dalSellPlan.ChkSellPlanU(1, result1, result2, out strMsg);
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        string str1 = "";
        string str2;
        if (num != 0)
            str2 = str1 + "window.alert('" + strMsg + "');ChkID('" + this.hfRecID.Value + "');";
        else
            str2 = "ChkID('" + this.hfRecID.Value + "');";
        this.SysInfo(str2);
    }

    protected void btnEnd_Click(object sender, EventArgs e)
    {
        int result1 = 0;
        int.TryParse(this.hfRecID.Value, out result1);
        DALSellPlan dalSellPlan = new DALSellPlan();
        string strMsg = string.Empty;
        int result2 = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result2);
        int num = dalSellPlan.ChkEnd(1, result1, result2, out strMsg);
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        string str1 = "";
        string str2;
        if (num != 0)
            str2 = str1 + "window.alert('" + strMsg + "');ChkID('" + this.hfRecID.Value + "');";
        else
            str2 = "ChkID('" + this.hfRecID.Value + "');";
        this.SysInfo(str2);
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        int result1 = 0;
        int.TryParse(this.hfRecID.Value, out result1);
        DALSellPlan dalSellPlan = new DALSellPlan();
        string strMsg = string.Empty;
        int result2 = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result2);
        int num = dalSellPlan.Delete(1, result1, result2, out strMsg);
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        if (num == 0)
        {
            this.hfRecID.Value = "-1";
        }
        else
        {
            this.SysInfo("window.alert('" + strMsg + "');ChkID('" + this.hfRecID.Value + "');");
            this.ShowDetail();
        }
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = DALCommon.GetDataList("xs_sellplan", this.hfTbField.Value, this.hfSql.Value + " order by " + this.hfOrderName.Value + " " + this.hfOrder.Value).Tables[0];
        string[] TbTitle = this.hfTbTitle.Value.Split(',');
        string result = string.Empty;
        bool iFlag = false;
        DataToExcel.DataTableToExcel(dt, TbTitle, Guid.NewGuid().ToString() + ".xls", "销售订单", out iFlag, out result);
        if (iFlag)
            return;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        this.SysInfo("window.alert(\"" + result + "\");");
    }

    protected void btnExcelDe_Click(object sender, EventArgs e)
    {
        DataTable dt = DALCommon.GetDataList("xs_sellplandetail", this.hfTbFieldDe.Value, " BillID=" + this.hfRecID.Value).Tables[0];
        string[] TbTitle = this.hfTbTitleDe.Value.Split(',');
        string result = string.Empty;
        bool iFlag = false;
        DataToExcel.DataTableToExcel(dt, TbTitle, Guid.NewGuid().ToString() + ".xls", "销售订单明细", out iFlag, out result);
        if (iFlag)
            return;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        this.ShowDetail();
        this.SysInfo("window.alert(\"" + result + "\");");
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
            e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            e.Row.Cells[1].Attributes.Add("style", "width:30px;padding-right:0px;background:#ECE9D8;text-align:center;");
            e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
            Decimal.TryParse(e.Row.Cells[8].Text, out this.tqty);
            Decimal.TryParse(e.Row.Cells[10].Text, out this.dprice);
            this.dqty += this.tqty;
            Decimal.TryParse(e.Row.Cells[12].Text, out this.dtotal);
            this.ddtotal += this.dtotal;
            Decimal.TryParse(e.Row.Cells[14].Text, out this.dre1);
            this.dtaxamount += this.dre1;
            Decimal.TryParse(e.Row.Cells[15].Text, out this.dre2);
            this.dgoodsamount += this.dre2;
        }
        if (e.Row.RowType != DataControlRowType.Footer)
            return;
        e.Row.Cells[1].Text = "合计";
        e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
        e.Row.Cells[8].Text = this.dqty.ToString("#0.00");
        e.Row.Cells[12].Text = this.ddtotal.ToString("#0.00");
        e.Row.Cells[14].Text = this.dtaxamount.ToString("#0.00");
        e.Row.Cells[15].Text = this.dgoodsamount.ToString("#0.00");
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        this.ShowDetail();
    }

    protected void ShowDetail()
    {
        this.GridView2.DataSource = (object)DALCommon.GetDataList("xs_sellplandetail", "", " BillID=" + this.hfRecID.Value);
        this.GridView2.DataBind();
        this.hfTbFieldDe.Value = this.hfTbTitleDe.Value = string.Empty;
        if (this.GridView2.Rows.Count <= 0)
            return;
        for (int index = 0; index < this.GridView2.HeaderRow.Cells.Count; ++index)
        {
            string dataField = ((BoundField)this.GridView2.Columns[index]).DataField;
            string text = this.GridView2.HeaderRow.Cells[index].Text;
            if (dataField != "" && dataField != "ID")
            {
                if (this.hfTbTitleDe.Value == string.Empty)
                {
                    this.hfTbTitleDe.Value = text;
                }
                else
                {
                    HiddenField hiddenField = this.hfTbTitleDe;
                    string str = hiddenField.Value + "," + text;
                    hiddenField.Value = str;
                }
                if (this.hfTbFieldDe.Value == string.Empty)
                {
                    this.hfTbFieldDe.Value = dataField;
                }
                else
                {
                    HiddenField hiddenField = this.hfTbFieldDe;
                    string str = hiddenField.Value + "," + dataField;
                    hiddenField.Value = str;
                }
            }
        }
    }

    public void ChkWebUser()
    {
        if (this.Session["Session_Web_Name"] != null && this.Session["Session_Web_ID"] != null)
            return;
        this.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
        this.Response.End();
    }
}
