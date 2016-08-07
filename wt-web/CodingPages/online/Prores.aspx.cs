using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_online_Prores : System.Web.UI.Page
{
    Coding.Stock.DAL.Cd_ProImg bll = new Coding.Stock.DAL.Cd_ProImg();
    Coding.Stock.DAL.Cd_ProductFiles bll2 = new Coding.Stock.DAL.Cd_ProductFiles();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id=Request.QueryString["id"];
        string pn=Request.QueryString["pn"];
        if (!string.IsNullOrEmpty(id))
        {
            lb_pn.Text = pn;       
          DataSet ds = bll.GetList(string.Format(" ProID={0}", id));
          Repeater1.DataSource = ds.Tables[0];
          Repeater1.DataBind();
       
          DataSet ds2 = bll2.GetList(string.Format(" ProID={0}", id));
          Repeater2.DataSource = ds2.Tables[0];
          Repeater2.DataBind();
        }
    }
}