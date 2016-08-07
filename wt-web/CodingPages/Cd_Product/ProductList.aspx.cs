using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_Product_ProductList : System.Web.UI.Page
{
    Coding.Stock.DAL.Cd_ProTypeAttr bll = new Coding.Stock.DAL.Cd_ProTypeAttr();
    Coding.Stock.DAL.Cd_productType bll2 = new Coding.Stock.DAL.Cd_productType();
    Coding.Stock.DAL.Cd_ProAtts bll3 = new Coding.Stock.DAL.Cd_ProAtts();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id=Request.QueryString["id"];
        Coding.Stock.Model.Cd_productType proType = bll2.GetModel(Convert.ToInt32(id));
        Label1.Text ="产品类型：" +proType.TypeName;
        DataTable proTypeAttr = bll.GetList(" ProTypeID=" + id).Tables[0];
        StringBuilder sb = new StringBuilder();
        sb.Append(" select  ID ");
        for (int i=0;i< proTypeAttr.Rows.Count;i++)
        {
         //   if (i == 0)
         //   {
          //      sb.Append(proTypeAttr.Rows[i]["AttName"].ToString() + " as '" + proTypeAttr.Rows[i]["DisplayAttrName"].ToString() + "' ");
         //   }
         //   else {
                sb.Append(","+proTypeAttr.Rows[i]["AttName"].ToString() + " as '" + proTypeAttr.Rows[i]["DisplayAttrName"].ToString() + "' ");
           // }
          
        }
        sb.Append(" from Cd_ProAtts where protypeid="+id);
       GridView1.DataSource= bll3.GetListBysql(sb.ToString());    
       GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        string kw=txt_keyword.Text.Trim();
        DataTable proTypeAttr = bll.GetList(" ProTypeID=" + id).Tables[0];
        StringBuilder sb = new StringBuilder();
        StringBuilder strWhere = new StringBuilder("");
        sb.Append(" select  ID ");
        for (int i = 0; i < proTypeAttr.Rows.Count; i++)
        {     
            sb.Append("," + proTypeAttr.Rows[i]["AttName"].ToString() + " as '" + proTypeAttr.Rows[i]["DisplayAttrName"].ToString() + "' ");
            if (i == 0)
            {
                strWhere.Append( proTypeAttr.Rows[i]["AttName"].ToString() + " like '%" + kw + "%' ");
            }
            else {
                strWhere.Append(" or " + proTypeAttr.Rows[i]["AttName"].ToString() + " like '%" + kw + "%'  ");
            }
        }
        sb.Append(" from Cd_ProAtts ");
        if (!string.IsNullOrEmpty(kw))
        {
            sb.Append(" where  "+strWhere.ToString());
        }
        GridView1.DataSource = bll3.GetListBysql(sb.ToString());
        GridView1.DataBind();
    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}