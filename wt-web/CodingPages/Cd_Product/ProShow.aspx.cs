using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_Product_ProShow : System.Web.UI.Page
{
    public string strid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                strid = Request.Params["id"];
                int ID = (Convert.ToInt32(strid));
                ShowInfo(ID);
            }
        }
    }

    private void ShowInfo(int ID)
    {
        Coding.Stock.DAL.Cd_Product bll = new Coding.Stock.DAL.Cd_Product();
        Coding.Stock.Model.Cd_Product model = bll.GetModel(ID);
        this.lblID.Text = model.ID.ToString();
        this.lblProName.Text = model.ProName;
        this.lblProSeri.Text = model.ProSeri;
        this.lblProModel.Text = model.ProModel;
        this.lblProDescribe.Text = model.ProDescribe;

    }

}