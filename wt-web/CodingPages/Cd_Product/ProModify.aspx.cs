using Coding.Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_Product_ProModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                int ID = (Convert.ToInt32(Request.Params["id"]));
                ShowInfo(ID);
            }
        }
    }

    private void ShowInfo(int ID)
    {
        Coding.Stock.DAL.Cd_Product bll = new Coding.Stock.DAL.Cd_Product();
        Coding.Stock.Model.Cd_Product model = bll.GetModel(ID);
        this.lblID.Text = model.ID.ToString();
        this.txtProName.Text = model.ProName;
        this.txtProSeri.Text = model.ProSeri;
        this.txtProModel.Text = model.ProModel;
        this.txtProDescribe.Text = model.ProDescribe;

    }

    public void btnSave_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtProName.Text.Trim().Length == 0)
        {
            strErr += "ProName不能为空！\\n";
        }
        if (this.txtProSeri.Text.Trim().Length == 0)
        {
            strErr += "ProSeri不能为空！\\n";
        }
        if (this.txtProModel.Text.Trim().Length == 0)
        {
            strErr += "ProModel不能为空！\\n";
        }
        if (this.txtProDescribe.Text.Trim().Length == 0)
        {
            strErr += "ProDescribe不能为空！\\n";
        }

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        int ID = int.Parse(this.lblID.Text);
        string ProName = this.txtProName.Text;
        string ProSeri = this.txtProSeri.Text;
        string ProModel = this.txtProModel.Text;
        string ProDescribe = this.txtProDescribe.Text;


        Coding.Stock.Model.Cd_Product model = new Coding.Stock.Model.Cd_Product();
        model.ID = ID;
        model.ProName = ProName;
        model.ProSeri = ProSeri;
        model.ProModel = ProModel;
        model.ProDescribe = ProDescribe;

        Coding.Stock.DAL.Cd_Product bll = new Coding.Stock.DAL.Cd_Product();
        bll.Update(model);
        Coding.Stock.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");

    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
    }
}