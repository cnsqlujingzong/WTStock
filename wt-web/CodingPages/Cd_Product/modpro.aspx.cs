using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_Product_modpro : System.Web.UI.Page
{
    Coding.Stock.DAL.Cd_ProTypeAttr bll = new Coding.Stock.DAL.Cd_ProTypeAttr();
    Coding.Stock.DAL.Cd_productType bll2 = new Coding.Stock.DAL.Cd_productType();
    Coding.Stock.DAL.Cd_ProAtts bll3 = new Coding.Stock.DAL.Cd_ProAtts();
    protected void Page_Load(object sender, EventArgs e)
    {
       // modpro.aspx?id=18&&tid=1
     
     

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string id = Request.Params["hid"].ToString();
            string tid = Request.Params["htid"].ToString();
            System.Data.DataTable proTypeAttr = bll.GetList(" ProTypeID=" + tid).Tables[0];
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(" UPDATE [Cd_ProAtts]   SET ");
            for (int i = 0; i < proTypeAttr.Rows.Count; i++)
            {
                string v = proTypeAttr.Rows[i]["AttName"].ToString();
                if (i == 0)
                {
                    sb.Append(v + "='" + Request.Params[v].ToString() + "'");
                }
                else
                {
                    sb.Append("," + v + "='" + Request.Params[v].ToString() + "'");
                }
            }
            sb.Append(" where  ID=" + id + "  and [ProTypeID]=" + tid);
            bool r = bll3.runSQL2(sb.ToString());
            if (r)
            {
                Coding.Stock.Common.MessageBox.ShowAndRedirect(this, "修改成功", "/CodingPages/Cd_Product/ProductList.aspx?id=" + tid);
            }
            else
            {
                Coding.Stock.Common.MessageBox.Show(this, "修改失败请稍后再试！");
            }
        }
        catch (Exception ex)
        {
            Coding.Stock.Common.MessageBox.Show(this, "异常："+ex.Message);
        }
    }
}