using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_Product_Default : System.Web.UI.Page
{
    Coding.Stock.DAL.Cd_ProAtts bll3 = new Coding.Stock.DAL.Cd_ProAtts();
    protected void Page_Load(object sender, EventArgs e)
    {
       int iOperator = int.Parse((string)(Session["Session_wtUserID"]));
        string id = Request.QueryString["id"];
        string tid = Request.QueryString["tid"];
        if (!string.IsNullOrEmpty(id))
        {
            bll3.Delete(Convert.ToInt32(id));
        }
        Coding.Stock.Common.MessageBox.ShowAndRedirect(this,"删除已经成功！", "/CodingPages/Cd_Product/ProductList.aspx?id="+tid);
    }
}