using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Stat_SchHMaterialDe : Page, IRequiresSessionState
{

	private string type;
    
	public string Str_Type
	{
		get
		{
			return this.type;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r58"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbNO.Text).Replace("\"", "");
		string text2 = FunLibrary.ChkInput(this.tbCusName.Text).Replace("\"", "");
		string text3 = FunLibrary.ChkInput(this.tbLinkMan.Text).Replace("\"", "");
		string text4 = FunLibrary.ChkInput(this.tbTel.Text).Replace("\"", "");
		string text5 = FunLibrary.ChkInput(this.tbDUser.Text).Replace("\"", "");
		string text6 = FunLibrary.ChkInput(this.tbDUsePeoTel.Text).Replace("\"", "");
		string text7 = FunLibrary.ChkInput(this.tbDName.Text).Replace("\"", "");
		string text8 = FunLibrary.ChkInput(this.tbDPra.Text).Replace("\"", "");
		string text9 = FunLibrary.ChkInput(this.tbDSN.Text).Replace("\"", "");
		string text10 = FunLibrary.ChkInput(this.tbBuydate.Text).Replace("\"", "");
		string text11 = FunLibrary.ChkInput(this.tbMNO.Text).Replace("\"", "");
		string text12 = FunLibrary.ChkInput(this.tbMName.Text).Replace("\"", "");
		string text13 = this.tbMQty.Text;
		string text14 = this.tbMPrice.Text;
		string text15 = this.tbMtotal.Text;
		string text16 = FunLibrary.ChkInput(this.tbMSN.Text).Replace("\"", "");
		string text17 = this.tbMChengben.Text;
		string text18 = FunLibrary.ChkInput(this.tbAcceptTimeBegin.Text).Replace("\"", "");
		string text19 = FunLibrary.ChkInput(this.tbAcceptTimeEnd.Text).Replace("\"", "");
		string text20 = " 1=1";
		if (text != "")
		{
			text20 = text20 + " and billid  like '%" + text + "%'";
		}
		if (text2 != "")
		{
			text20 = text20 + " and CustomerName  like '%" + text2 + "%'";
		}
		if (text3 != "")
		{
			text20 = text20 + " and LinkMan  like '%" + text3 + "%'";
		}
		if (text4 != "")
		{
			text20 = text20 + " and Tel  like '%" + text4 + "%'";
		}
		if (text5 != "")
		{
			text20 = text20 + " and UsePerson  like '%" + text5 + "%'";
		}
		if (text6 != "-1")
		{
			text20 = text20 + " and UsePersonTel  like '%" + text6 + "%'";
		}
		if (text7 != "")
		{
			text20 = text20 + " and D_Name  like '%" + text7 + "%'";
		}
		if (text8 != "")
		{
			text20 = text20 + " and D_Parameters  like '%" + text8 + "%'";
		}
		if (text9 != "")
		{
			text20 = text20 + " and D_SN  like '%" + text9 + "%'";
		}
		if (text10 != "")
		{
			text20 = text20 + " and D_BuyDate  like '%" + text10 + "%'";
		}
		if (text11 != "")
		{
			text20 = text20 + " and M_GoodsNO  like '%" + text11 + "%'";
		}
		if (text12 != "")
		{
			text20 = text20 + " and M_Name  like '%" + text12 + "%'";
		}
		if (text13 != "")
		{
			object obj = text20;
			text20 = string.Concat(new object[]
			{
				obj,
				" and M_Qty  like '%",
				int.Parse(text13),
				"%'"
			});
		}
		if (text14 != "")
		{
			object obj = text20;
			text20 = string.Concat(new object[]
			{
				obj,
				" and M_Price  like '%",
				decimal.Parse(text14),
				"%'"
			});
		}
		if (text15 != "")
		{
			object obj = text20;
			text20 = string.Concat(new object[]
			{
				obj,
				" and M_Total  like '%",
				decimal.Parse(text15),
				"%'"
			});
		}
		if (text16 != "")
		{
			text20 = text20 + " and M_SN  like '%" + text16 + "%'";
		}
		if (text17 != "")
		{
			object obj = text20;
			text20 = string.Concat(new object[]
			{
				obj,
				" and M_CostPrice  like '%",
				decimal.Parse(text17),
				"%'"
			});
		}
		if (text18 != "" && text19 != "")
		{
			string text21 = text20;
			text20 = string.Concat(new string[]
			{
				text21,
				" and (Time_Make between '",
				text18,
				"' and '",
				text19,
				"')"
			});
		}
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", "parent.RefreshSchH(\"" + text20 + "\");parent.CloseDialog();", true);
	}
}
