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
namespace Coding.Stock.Web.Cd_ProTypeAttr
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
		Coding.Stock.BLL.Cd_ProTypeAttr bll=new Coding.Stock.BLL.Cd_ProTypeAttr();
		Coding.Stock.Model.Cd_ProTypeAttr model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtProTypeID.Text=model.ProTypeID.ToString();
		this.txtAttName.Text=model.AttName;
		this.txtDisplayAttrName.Text=model.DisplayAttrName;
		this.txtOrderby.Text=model.Orderby.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtProTypeID.Text))
			{
				strErr+="ProTypeID格式错误！\\n";	
			}
			if(this.txtAttName.Text.Trim().Length==0)
			{
				strErr+="AttName不能为空！\\n";	
			}
			if(this.txtDisplayAttrName.Text.Trim().Length==0)
			{
				strErr+="DisplayAttrName不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtOrderby.Text))
			{
				strErr+="Orderby格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			int ProTypeID=int.Parse(this.txtProTypeID.Text);
			string AttName=this.txtAttName.Text;
			string DisplayAttrName=this.txtDisplayAttrName.Text;
			int Orderby=int.Parse(this.txtOrderby.Text);


			Coding.Stock.Model.Cd_ProTypeAttr model=new Coding.Stock.Model.Cd_ProTypeAttr();
			model.Id=Id;
			model.ProTypeID=ProTypeID;
			model.AttName=AttName;
			model.DisplayAttrName=DisplayAttrName;
			model.Orderby=Orderby;

			Coding.Stock.BLL.Cd_ProTypeAttr bll=new Coding.Stock.BLL.Cd_ProTypeAttr();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
