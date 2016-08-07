using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Coding.Stock.Web.Cd_productType
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTypeName.Text.Trim().Length==0)
			{
				strErr+="TypeName不能为空！\\n";	
			}
	

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string TypeName=this.txtTypeName.Text;
			string Desc=this.txtDesc.Text;
			string Common=this.txtCommon.Text;

			Coding.Stock.Model.Cd_productType model=new Coding.Stock.Model.Cd_productType();
			model.TypeName=TypeName;
			model.Desc=Desc;
			model.Common=Common;

			Coding.Stock.BLL.Cd_productType bll=new Coding.Stock.BLL.Cd_productType();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
