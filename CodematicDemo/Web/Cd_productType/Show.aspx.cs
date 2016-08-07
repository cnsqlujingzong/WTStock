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
namespace Coding.Stock.Web.Cd_productType
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int Id=(Convert.ToInt32(strid));
					ShowInfo(Id);
				}
			}
		}
		
	private void ShowInfo(int Id)
	{
		Coding.Stock.BLL.Cd_productType bll=new Coding.Stock.BLL.Cd_productType();
		Coding.Stock.Model.Cd_productType model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblTypeName.Text=model.TypeName;
		this.lblDesc.Text=model.Desc;
		this.lblCommon.Text=model.Common;

	}


    }
}
