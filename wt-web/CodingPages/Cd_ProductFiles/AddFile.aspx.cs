using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_ProductFiles_AddFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pid = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(pid))
        {
            Coding.Stock.DAL.Cd_ProductFiles bll = new Coding.Stock.DAL.Cd_ProductFiles();
            DataSet ds = bll.GetList(string.Format(" ProID={0}", pid));
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();
        }
    }
}