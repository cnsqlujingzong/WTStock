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
namespace Coding.Stock.Web.Cd_ProAtts
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtProTypeID.Text))
			{
				strErr+="ProTypeID格式错误！\\n";	
			}
			if(this.txtA100_1.Text.Trim().Length==0)
			{
				strErr+="A100_1不能为空！\\n";	
			}
			if(this.txtA100_2.Text.Trim().Length==0)
			{
				strErr+="A100_2不能为空！\\n";	
			}
			if(this.txtA100_3.Text.Trim().Length==0)
			{
				strErr+="A100_3不能为空！\\n";	
			}
			if(this.txtA100_4.Text.Trim().Length==0)
			{
				strErr+="A100_4不能为空！\\n";	
			}
			if(this.txtA100_5.Text.Trim().Length==0)
			{
				strErr+="A100_5不能为空！\\n";	
			}
			if(this.txtA100_6.Text.Trim().Length==0)
			{
				strErr+="A100_6不能为空！\\n";	
			}
			if(this.txtA100_7.Text.Trim().Length==0)
			{
				strErr+="A100_7不能为空！\\n";	
			}
			if(this.txtA100_8.Text.Trim().Length==0)
			{
				strErr+="A100_8不能为空！\\n";	
			}
			if(this.txtA100_9.Text.Trim().Length==0)
			{
				strErr+="A100_9不能为空！\\n";	
			}
			if(this.txtA100_10.Text.Trim().Length==0)
			{
				strErr+="A100_10不能为空！\\n";	
			}
			if(this.txtA100_11.Text.Trim().Length==0)
			{
				strErr+="A100_11不能为空！\\n";	
			}
			if(this.txtA100_12.Text.Trim().Length==0)
			{
				strErr+="A100_12不能为空！\\n";	
			}
			if(this.txtA100_13.Text.Trim().Length==0)
			{
				strErr+="A100_13不能为空！\\n";	
			}
			if(this.txtA100_14.Text.Trim().Length==0)
			{
				strErr+="A100_14不能为空！\\n";	
			}
			if(this.txtA100_15.Text.Trim().Length==0)
			{
				strErr+="A100_15不能为空！\\n";	
			}
			if(this.txtA100_16.Text.Trim().Length==0)
			{
				strErr+="A100_16不能为空！\\n";	
			}
			if(this.txtA100_17.Text.Trim().Length==0)
			{
				strErr+="A100_17不能为空！\\n";	
			}
			if(this.txtA100_18.Text.Trim().Length==0)
			{
				strErr+="A100_18不能为空！\\n";	
			}
			if(this.txtA100_19.Text.Trim().Length==0)
			{
				strErr+="A100_19不能为空！\\n";	
			}
			if(this.txtA100_20.Text.Trim().Length==0)
			{
				strErr+="A100_20不能为空！\\n";	
			}
			if(this.txtA100_21.Text.Trim().Length==0)
			{
				strErr+="A100_21不能为空！\\n";	
			}
			if(this.txtA100_22.Text.Trim().Length==0)
			{
				strErr+="A100_22不能为空！\\n";	
			}
			if(this.txtA100_23.Text.Trim().Length==0)
			{
				strErr+="A100_23不能为空！\\n";	
			}
			if(this.txtA100_24.Text.Trim().Length==0)
			{
				strErr+="A100_24不能为空！\\n";	
			}
			if(this.txtA100_25.Text.Trim().Length==0)
			{
				strErr+="A100_25不能为空！\\n";	
			}
			if(this.txtA100_26.Text.Trim().Length==0)
			{
				strErr+="A100_26不能为空！\\n";	
			}
			if(this.txtA100_27.Text.Trim().Length==0)
			{
				strErr+="A100_27不能为空！\\n";	
			}
			if(this.txtA100_28.Text.Trim().Length==0)
			{
				strErr+="A100_28不能为空！\\n";	
			}
			if(this.txtA100_29.Text.Trim().Length==0)
			{
				strErr+="A100_29不能为空！\\n";	
			}
			if(this.txtA100_30.Text.Trim().Length==0)
			{
				strErr+="A100_30不能为空！\\n";	
			}
			if(this.txtA100_31.Text.Trim().Length==0)
			{
				strErr+="A100_31不能为空！\\n";	
			}
			if(this.txtA100_32.Text.Trim().Length==0)
			{
				strErr+="A100_32不能为空！\\n";	
			}
			if(this.txtA100_33.Text.Trim().Length==0)
			{
				strErr+="A100_33不能为空！\\n";	
			}
			if(this.txtA100_34.Text.Trim().Length==0)
			{
				strErr+="A100_34不能为空！\\n";	
			}
			if(this.txtA100_35.Text.Trim().Length==0)
			{
				strErr+="A100_35不能为空！\\n";	
			}
			if(this.txtA100_36.Text.Trim().Length==0)
			{
				strErr+="A100_36不能为空！\\n";	
			}
			if(this.txtA100_37.Text.Trim().Length==0)
			{
				strErr+="A100_37不能为空！\\n";	
			}
			if(this.txtA100_38.Text.Trim().Length==0)
			{
				strErr+="A100_38不能为空！\\n";	
			}
			if(this.txtA100_39.Text.Trim().Length==0)
			{
				strErr+="A100_39不能为空！\\n";	
			}
			if(this.txtA100_40.Text.Trim().Length==0)
			{
				strErr+="A100_40不能为空！\\n";	
			}
			if(this.txtA100_41.Text.Trim().Length==0)
			{
				strErr+="A100_41不能为空！\\n";	
			}
			if(this.txtA100_42.Text.Trim().Length==0)
			{
				strErr+="A100_42不能为空！\\n";	
			}
			if(this.txtA100_43.Text.Trim().Length==0)
			{
				strErr+="A100_43不能为空！\\n";	
			}
			if(this.txtA100_44.Text.Trim().Length==0)
			{
				strErr+="A100_44不能为空！\\n";	
			}
			if(this.txtA100_45.Text.Trim().Length==0)
			{
				strErr+="A100_45不能为空！\\n";	
			}
			if(this.txtA100_46.Text.Trim().Length==0)
			{
				strErr+="A100_46不能为空！\\n";	
			}
			if(this.txtA100_47.Text.Trim().Length==0)
			{
				strErr+="A100_47不能为空！\\n";	
			}
			if(this.txtA100_48.Text.Trim().Length==0)
			{
				strErr+="A100_48不能为空！\\n";	
			}
			if(this.txtA100_49.Text.Trim().Length==0)
			{
				strErr+="A100_49不能为空！\\n";	
			}
			if(this.txtA100_50.Text.Trim().Length==0)
			{
				strErr+="A100_50不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ProTypeID=int.Parse(this.txtProTypeID.Text);
			string A100_1=this.txtA100_1.Text;
			string A100_2=this.txtA100_2.Text;
			string A100_3=this.txtA100_3.Text;
			string A100_4=this.txtA100_4.Text;
			string A100_5=this.txtA100_5.Text;
			string A100_6=this.txtA100_6.Text;
			string A100_7=this.txtA100_7.Text;
			string A100_8=this.txtA100_8.Text;
			string A100_9=this.txtA100_9.Text;
			string A100_10=this.txtA100_10.Text;
			string A100_11=this.txtA100_11.Text;
			string A100_12=this.txtA100_12.Text;
			string A100_13=this.txtA100_13.Text;
			string A100_14=this.txtA100_14.Text;
			string A100_15=this.txtA100_15.Text;
			string A100_16=this.txtA100_16.Text;
			string A100_17=this.txtA100_17.Text;
			string A100_18=this.txtA100_18.Text;
			string A100_19=this.txtA100_19.Text;
			string A100_20=this.txtA100_20.Text;
			string A100_21=this.txtA100_21.Text;
			string A100_22=this.txtA100_22.Text;
			string A100_23=this.txtA100_23.Text;
			string A100_24=this.txtA100_24.Text;
			string A100_25=this.txtA100_25.Text;
			string A100_26=this.txtA100_26.Text;
			string A100_27=this.txtA100_27.Text;
			string A100_28=this.txtA100_28.Text;
			string A100_29=this.txtA100_29.Text;
			string A100_30=this.txtA100_30.Text;
			string A100_31=this.txtA100_31.Text;
			string A100_32=this.txtA100_32.Text;
			string A100_33=this.txtA100_33.Text;
			string A100_34=this.txtA100_34.Text;
			string A100_35=this.txtA100_35.Text;
			string A100_36=this.txtA100_36.Text;
			string A100_37=this.txtA100_37.Text;
			string A100_38=this.txtA100_38.Text;
			string A100_39=this.txtA100_39.Text;
			string A100_40=this.txtA100_40.Text;
			string A100_41=this.txtA100_41.Text;
			string A100_42=this.txtA100_42.Text;
			string A100_43=this.txtA100_43.Text;
			string A100_44=this.txtA100_44.Text;
			string A100_45=this.txtA100_45.Text;
			string A100_46=this.txtA100_46.Text;
			string A100_47=this.txtA100_47.Text;
			string A100_48=this.txtA100_48.Text;
			string A100_49=this.txtA100_49.Text;
			string A100_50=this.txtA100_50.Text;

			Coding.Stock.Model.Cd_ProAtts model=new Coding.Stock.Model.Cd_ProAtts();
			model.ProTypeID=ProTypeID;
			model.A100_1=A100_1;
			model.A100_2=A100_2;
			model.A100_3=A100_3;
			model.A100_4=A100_4;
			model.A100_5=A100_5;
			model.A100_6=A100_6;
			model.A100_7=A100_7;
			model.A100_8=A100_8;
			model.A100_9=A100_9;
			model.A100_10=A100_10;
			model.A100_11=A100_11;
			model.A100_12=A100_12;
			model.A100_13=A100_13;
			model.A100_14=A100_14;
			model.A100_15=A100_15;
			model.A100_16=A100_16;
			model.A100_17=A100_17;
			model.A100_18=A100_18;
			model.A100_19=A100_19;
			model.A100_20=A100_20;
			model.A100_21=A100_21;
			model.A100_22=A100_22;
			model.A100_23=A100_23;
			model.A100_24=A100_24;
			model.A100_25=A100_25;
			model.A100_26=A100_26;
			model.A100_27=A100_27;
			model.A100_28=A100_28;
			model.A100_29=A100_29;
			model.A100_30=A100_30;
			model.A100_31=A100_31;
			model.A100_32=A100_32;
			model.A100_33=A100_33;
			model.A100_34=A100_34;
			model.A100_35=A100_35;
			model.A100_36=A100_36;
			model.A100_37=A100_37;
			model.A100_38=A100_38;
			model.A100_39=A100_39;
			model.A100_40=A100_40;
			model.A100_41=A100_41;
			model.A100_42=A100_42;
			model.A100_43=A100_43;
			model.A100_44=A100_44;
			model.A100_45=A100_45;
			model.A100_46=A100_46;
			model.A100_47=A100_47;
			model.A100_48=A100_48;
			model.A100_49=A100_49;
			model.A100_50=A100_50;

			Coding.Stock.BLL.Cd_ProAtts bll=new Coding.Stock.BLL.Cd_ProAtts();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
