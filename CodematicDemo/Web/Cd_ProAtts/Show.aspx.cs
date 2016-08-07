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
namespace Coding.Stock.Web.Cd_ProAtts
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
		Coding.Stock.BLL.Cd_ProAtts bll=new Coding.Stock.BLL.Cd_ProAtts();
		Coding.Stock.Model.Cd_ProAtts model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblProTypeID.Text=model.ProTypeID.ToString();
		this.lblA100_1.Text=model.A100_1;
		this.lblA100_2.Text=model.A100_2;
		this.lblA100_3.Text=model.A100_3;
		this.lblA100_4.Text=model.A100_4;
		this.lblA100_5.Text=model.A100_5;
		this.lblA100_6.Text=model.A100_6;
		this.lblA100_7.Text=model.A100_7;
		this.lblA100_8.Text=model.A100_8;
		this.lblA100_9.Text=model.A100_9;
		this.lblA100_10.Text=model.A100_10;
		this.lblA100_11.Text=model.A100_11;
		this.lblA100_12.Text=model.A100_12;
		this.lblA100_13.Text=model.A100_13;
		this.lblA100_14.Text=model.A100_14;
		this.lblA100_15.Text=model.A100_15;
		this.lblA100_16.Text=model.A100_16;
		this.lblA100_17.Text=model.A100_17;
		this.lblA100_18.Text=model.A100_18;
		this.lblA100_19.Text=model.A100_19;
		this.lblA100_20.Text=model.A100_20;
		this.lblA100_21.Text=model.A100_21;
		this.lblA100_22.Text=model.A100_22;
		this.lblA100_23.Text=model.A100_23;
		this.lblA100_24.Text=model.A100_24;
		this.lblA100_25.Text=model.A100_25;
		this.lblA100_26.Text=model.A100_26;
		this.lblA100_27.Text=model.A100_27;
		this.lblA100_28.Text=model.A100_28;
		this.lblA100_29.Text=model.A100_29;
		this.lblA100_30.Text=model.A100_30;
		this.lblA100_31.Text=model.A100_31;
		this.lblA100_32.Text=model.A100_32;
		this.lblA100_33.Text=model.A100_33;
		this.lblA100_34.Text=model.A100_34;
		this.lblA100_35.Text=model.A100_35;
		this.lblA100_36.Text=model.A100_36;
		this.lblA100_37.Text=model.A100_37;
		this.lblA100_38.Text=model.A100_38;
		this.lblA100_39.Text=model.A100_39;
		this.lblA100_40.Text=model.A100_40;
		this.lblA100_41.Text=model.A100_41;
		this.lblA100_42.Text=model.A100_42;
		this.lblA100_43.Text=model.A100_43;
		this.lblA100_44.Text=model.A100_44;
		this.lblA100_45.Text=model.A100_45;
		this.lblA100_46.Text=model.A100_46;
		this.lblA100_47.Text=model.A100_47;
		this.lblA100_48.Text=model.A100_48;
		this.lblA100_49.Text=model.A100_49;
		this.lblA100_50.Text=model.A100_50;

	}


    }
}
