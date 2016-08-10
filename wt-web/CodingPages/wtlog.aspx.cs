using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_wtlog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       string kw=  txt_keyword.Text.Trim();
       if (!string.IsNullOrEmpty(kw))
       {
           string SQ_sellplan = "select a.* ,b.billID as billnum from WTLog a left join SellPlan b on a.BillID=b.ID or a.BillID=b.BillID where b.BillID like '%" + kw + "%'  ";
           string SQ_sell = "select a.* ,b.billID as billnum from WTLog a left join Sell b on a.BillID=b.ID or a.BillID=b.BillID where b.BillID like '%" + kw + "%'  ";
           DataTable dt_sellplan = DbHelperSQL.Query(SQ_sellplan).Tables[0];
           DataTable dt_sell = DbHelperSQL.Query(SQ_sell).Tables[0];
           dt_sell.Merge(dt_sellplan);
           GridView1.DataSource = dt_sell;
           GridView1.DataBind();
       }
    
    }
}