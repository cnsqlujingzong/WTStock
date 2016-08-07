using Coding.Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_ProType_ProTypeAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strErr = "";
        if (this.txtTypeName.Text.Trim().Length == 0)
        {
            strErr += "类型名称不能为空！\\n";
        }
  

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        string TypeName = this.txtTypeName.Text;
        string Desc = this.txtDesc.Text;
        string Common = this.txtCommon.Text;

        Coding.Stock.Model.Cd_productType model = new Coding.Stock.Model.Cd_productType();
        model.TypeName = TypeName;
        model.Desc = Desc;
        model.Common = Common;

        Coding.Stock.DAL.Cd_productType bll = new Coding.Stock.DAL.Cd_productType();
        bll.Add(model);
       MessageBox.ShowAndRedirect(this, "保存成功！", "ProTypeAdd.aspx");

    }
    public void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProTypeList.aspx");
    }
}