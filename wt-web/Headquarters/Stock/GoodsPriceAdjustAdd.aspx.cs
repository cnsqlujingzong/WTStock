using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_Stock_GoodsPriceAdjustAdd : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			FunLibrary.ChkHead();
			if (!base.IsPostBack)
			{
				int num = int.Parse((string)this.Session["Session_wtPurID"]);
				if (num > 0)
				{
					DALRight dALRight = new DALRight();
					if (!dALRight.GetRight(num, "ck_r3"))
					{
						this.btnAdd.Enabled = false;
					}
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num = int.Parse(DALCommon.TCount("PriceAdjust", " pricename1='" + this.ddlpricename1.SelectedItem.Text + "'"));
		if (num < 1)
		{
			string text = "";
			string text2 = "";
			int num2 = int.Parse(this.ddlpricename1.SelectedValue.ToString());
			int num3 = int.Parse(this.ddlpricename2.SelectedValue.ToString());
			if (num2 == 1)
			{
				text = "PriceDetail";
			}
			else if (num2 == 2)
			{
				text = "PriceCost";
			}
			else if (num2 == 3)
			{
				text = "PriceInner";
			}
			else if (num2 == 4)
			{
				text = "PriceWholesale1";
			}
			else if (num2 == 5)
			{
				text = "PriceWholesale2";
			}
			else if (num2 == 6)
			{
				text = "PriceWholesale3";
			}
			if (num3 == 1)
			{
				text2 = "PriceDetail";
			}
			else if (num3 == 2)
			{
				text2 = "PriceCost";
			}
			else if (num3 == 3)
			{
				text2 = "PriceInner";
			}
			else if (num3 == 4)
			{
				text2 = "PriceWholesale1";
			}
			else if (num3 == 5)
			{
				text2 = "PriceWholesale2";
			}
			else if (num3 == 6)
			{
				text2 = "PriceWholesale3";
			}
			try
			{
				decimal num4 = 0m;
				decimal.TryParse(this.tboxPrice.Text, out num4);
				PriceAdjust priceAdjust = new PriceAdjust();
				DALPriceAdjust dALPriceAdjust = new DALPriceAdjust();
				priceAdjust.Selectflag = true;
				priceAdjust.Pricename1 = this.ddlpricename1.SelectedItem.Text;
				priceAdjust.Pricename2 = this.ddlpricename2.SelectedItem.Text;
				priceAdjust.Separator = this.ddlseparator.SelectedItem.Text;
				priceAdjust.Price = num4;
				priceAdjust.Formula = string.Concat(new object[]
				{
					"",
					text,
					"=isnull(",
					text2,
					",0)",
					this.ddlseparator.SelectedItem.Text,
					"",
					num4,
					""
				});
				dALPriceAdjust.Add(priceAdjust);
				this.SysInfo("parent.CloseDialog1('1');parent.iframeDialog.document.getElementById('Refresh').click();");
			}
			catch
			{
				this.SysInfo("window.alert('出错！');");
			}
		}
		else
		{
			this.SysInfo("window.alert('保存失败！【需调价的价格】重复，请重新输入！');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
