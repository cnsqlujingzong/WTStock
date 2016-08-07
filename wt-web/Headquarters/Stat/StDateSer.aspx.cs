// Decompiled with JetBrains decompiler
// Type: Headquarters_Stat_StDateSer
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

public partial class Headquarters_Stat_StDateSer : Page, IRequiresSessionState
{
    private Decimal dr1 = new Decimal(0);
    private Decimal dr2 = new Decimal(0);
    private Decimal dr3 = new Decimal(0);
    private Decimal dr4 = new Decimal(0);
    private Decimal dr5 = new Decimal(0);
    private Decimal dr6 = new Decimal(0);
    private Decimal dtest = new Decimal(0);
    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkHead();
        if (this.IsPostBack)
            return;
        int RightID = int.Parse((string)this.Session["Session_wtPurID"]);
        if (RightID > 0 && !new DALRight().GetRight(RightID, "tj_r36"))
        {
            this.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
            this.Response.End();
        }
        OtherFunction.BindBranch(this.ddlBranch);
        this.ddlBranch.Items.Insert(0, new ListItem("请选择部门", "-1"));
        this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
        if (this.tbDate.Text.Trim().Equals(""))
            this.SysInfo("alert('请选择日期！');");
        else if (this.ddlStaff.SelectedValue.Trim().Equals("0"))
        {
            this.SysInfo("alert('请选择员工！');");
        }
        else
        {
            FunLibrary.ChkInput(this.tbDate.Text);
            DALServices dalServices = new DALServices();
            string TecName = string.Empty;
            if (this.ddlStaff.SelectedValue != "0")
                TecName = this.ddlStaff.SelectedItem.Text.Trim();
            DataSet techDayWork = dalServices.GetTechDayWork(int.Parse(this.ddlBranch.SelectedValue), TecName, this.tbDate.Text);
            this.gvdata.DataSource = (object)techDayWork.Tables[0];
            this.lbCount.Text = techDayWork.Tables[0].Rows.Count.ToString();
            this.Label1.Text = techDayWork.Tables[1].Rows[0][0].ToString();
            this.Label2.Text = techDayWork.Tables[2].Rows[0][0].ToString();
            if (this.lbCount.Text == "0")
            {
                this.lbCount.Visible = false;
            }
            else
            {
                this.lbCount.Visible = true;
                this.lbCount.Text = "总记录：" + this.lbCount.Text;
            }
            this.gvdata.DataBind();
        }
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;
        e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
        e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
        e.Row.Attributes.Add("ondblclick", "ChkView();");
        e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        if (this.tbDate.Text.Trim().Equals(""))
            this.SysInfo("alert('请选择日期！');");
        else if (this.ddlStaff.SelectedValue.Trim().Equals("0"))
        {
            this.SysInfo("alert('请选择员工！');");
        }
        else
        {
            FunLibrary.ChkInput(this.tbDate.Text);
            DALServices dalServices = new DALServices();
            string TecName = string.Empty;
            if (this.ddlStaff.SelectedValue != "0")
                TecName = this.ddlStaff.SelectedItem.Text.Trim();
            DataSet techDayWork = dalServices.GetTechDayWork(int.Parse(this.ddlBranch.SelectedValue), TecName, this.tbDate.Text);
            DataTable dt = techDayWork.Tables[0];
            string[] strArray = "BillID,CustomerName,ProductBrand,ProductClass,ProductModel,Time_TakeOver,FirstDo,visitdate,fintime,SerItem,ReadNum,SerMaterial,TakeSteps".Split(',');
            int length = strArray.Length;
            for (int ordinal = 0; ordinal < length; ++ordinal)
                dt.Columns[strArray[ordinal]].SetOrdinal(ordinal);
            while (dt.Columns.Count > strArray.Length)
                dt.Columns.Remove(dt.Columns[length]);
            DataRow row = dt.NewRow();
            row["CustomerName"] = (object)"本日处理完工派工单小计：";
            row["ProductBrand"] = (object)techDayWork.Tables[1].Rows[0][0].ToString();
            row["ProductClass"] = (object)"未处理派工单小计：";
            row["ProductModel"] = (object)techDayWork.Tables[2].Rows[0][0].ToString();
            dt.Rows.Add(row);
            string[] TbTitle = "服务单号,客户名称,机器品牌,机器类别,机器型号,受理时间,反应时间,上门时间,完成时间,服务项目,计数器,备件/耗材,处理措施".Split(',');
            bool iFlag;
            string result;
            DataToExcel.DataTableToExcel(dt, TbTitle, Guid.NewGuid().ToString() + ".xls", "技术员工作日志", out iFlag, out result);
        }
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlStaff.Items.Clear();
        if (!this.ddlBranch.SelectedValue.Equals("-1"))
        {
            this.ddlStaff.DataSource = (object)DALCommon.GetDataList("StaffList", "ID,_Name", "bTechnician=1 and DeptID=" + this.ddlBranch.SelectedValue);
            this.ddlStaff.DataTextField = "_Name";
            this.ddlStaff.DataValueField = "ID";
            this.ddlStaff.DataBind();
        }
        this.ddlStaff.Items.Insert(0, new ListItem("请选择员工", "0"));
    }
}
