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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Id);
				}
			}
		}
			
	private void ShowInfo(int Id)
	{
		Coding.Stock.BLL.Cd_productType bll=new Coding.Stock.BLL.Cd_productType();
		Coding.Stock.Model.Cd_productType model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtTypeName.Text=model.TypeName;
		this.txtDesc.Text=model.Desc;
		this.txtCommon.Text=model.Common;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTypeName.Text.Trim().Length==0)
			{
				strErr+="TypeName不能为空！\\n";	
			}
			if(this.txtDesc.Text.Trim().Length==0)
			{
				strErr+="Desc不能为空！\\n";	
			}
			if(this.txtCommon.Text.Trim().Length==0)
			{
				strErr+="Common不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string TypeName=this.txtTypeName.Text;
			string Desc=this.txtDesc.Text;
			string Common=this.txtCommon.Text;


			Coding.Stock.Model.Cd_productType model=new Coding.Stock.Model.Cd_productType();
			model.Id=Id;
			model.TypeName=TypeName;
			model.Desc=Desc;
			model.Common=Common;

			Coding.Stock.BLL.Cd_productType bll=new Coding.Stock.BLL.Cd_productType();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
