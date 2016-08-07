using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_ProType_ProTypeDetail : System.Web.UI.Page
{
    public string strid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                strid = Request.Params["id"];
                int Id = (Convert.ToInt32(strid));
                ShowInfo(Id);
            }
        }
    }

    private void ShowInfo(int Id)
    {
        Coding.Stock.DAL.Cd_productType bll = new Coding.Stock.DAL.Cd_productType();
        Coding.Stock.Model.Cd_productType model = bll.GetModel(Id);
        this.lblId.Text = model.Id.ToString();
        this.lblTypeName.Text = model.TypeName;
        this.lblDesc.Text = model.Desc;
        this.lblCommon.Text = model.Common;

    }

}