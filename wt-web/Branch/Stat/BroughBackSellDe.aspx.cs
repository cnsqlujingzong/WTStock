// Decompiled with JetBrains decompiler
// Type: Branch_Stat_BroughBackSellDe
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

public partial class Branch_Stat_BroughBackSellDe : Page, IRequiresSessionState
{
    private Decimal dr1 = new Decimal(0);
    private Decimal dr2 = new Decimal(0);
    private Decimal dr3 = new Decimal(0);
    private Decimal dr4 = new Decimal(0);
    private Decimal dtest = new Decimal(0);
    private string GoodsNO;
    private string startdate;
    private string enddate;
    private int deptid;
    private int iflag;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkBran();
        string[] strArray = this.Request["v"].Split(',');
        this.startdate = strArray[0];
        this.enddate = strArray[1];
        int.TryParse(strArray[2], out this.deptid);
        this.GoodsNO = this.Request["id"].Split(',')[1];
        if (this.IsPostBack)
            return;
        string str = " 1=1 ";
        string strCondition;
        if (this.deptid == -1)
            strCondition = str + " and ChkDate between '" + this.startdate + "' and '" + this.enddate + " 23:59:59'  and GoodsNO = '" + this.GoodsNO + "'";
        else
            strCondition = str + (object)" and ChkDate between '" + this.startdate + "' and '" + this.enddate + " 23:59:59'  and GoodsNO = '" + this.GoodsNO + "' and DeptID = " + (string)(object)this.deptid;
        this.gvdata.DataSource = (object)DALCommon.GetDataList("v_lt_detail", "*", strCondition);
        this.gvdata.DataBind();
        if (this.gvdata.Rows.Count > 0)
        {
            this.lbTitle.Visible = true;
            this.lbCount.Text = this.gvdata.Rows.Count.ToString() + " 条";
        }
        else
            this.lbTitle.Visible = false;
        this.hfCount.Value = this.gvdata.Rows.Count.ToString();
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string str = " 1=1 ";
        string strCondition;
        if (this.deptid == -1)
            strCondition = str + " and ChkDate between '" + this.startdate + "' and '" + this.enddate + " 23:59:59'  and GoodsNO = '" + this.GoodsNO + "'";
        else
            strCondition = str + (object)" and ChkDate between '" + this.startdate + "' and '" + this.enddate + " 23:59:59'  and GoodsNO = '" + this.GoodsNO + "' and DeptID = " + (string)(object)this.deptid;
        DataTable dt = DALCommon.GetDataList("v_lt_detail", "BillID,AppOperator,StockName,GoodsNO,_Name,Spec,Unit,ChkDate,Qty,CostPrice,OperationID,[Type]", strCondition).Tables[0];
        string[] TbTitle = new string[12]
    {
      "单据编号",
      "领料人",
      "仓库",
      "商品编号",
      "商品名称",
      "规格",
      "单位",
      "审核日期",
      "数量",
      "成本",
      "服务单号",
      "单据类型"
    };
        string result = string.Empty;
        bool iFlag = false;
        DataToExcel.DataTableToExcel(dt, TbTitle, Guid.NewGuid().ToString() + ".xls", "detail", out iFlag, out result);
    }
}
