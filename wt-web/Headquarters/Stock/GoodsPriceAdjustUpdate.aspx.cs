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

public partial class Headquarters_Stock_GoodsPriceAdjustUpdate : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r4"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			PriceAdjust priceAdjust = new PriceAdjust();
			DALPriceAdjust dALPriceAdjust = new DALPriceAdjust();
			priceAdjust = dALPriceAdjust.GetModel(this.id);
			for (int i = 0; i < this.ddlpricename1.Items.Count; i++)
			{
				if (this.ddlpricename1.Items[i].Text == priceAdjust._pricename1.ToString())
				{
					this.ddlpricename1.Items[i].Selected = true;
					break;
				}
			}
			for (int i = 0; i < this.ddlpricename2.Items.Count; i++)
			{
				if (this.ddlpricename2.Items[i].Text == priceAdjust._pricename2.ToString())
				{
					this.ddlpricename2.Items[i].Selected = true;
					break;
				}
			}
			for (int i = 0; i < this.ddlseparator.Items.Count; i++)
			{
				if (this.ddlseparator.Items[i].Text == priceAdjust._separator.ToString())
				{
					this.ddlseparator.Items[i].Selected = true;
					break;
				}
			}
			this.tboxPrice.Text = priceAdjust.Price.ToString();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string text = "";
		string text2 = "";
		int num = int.Parse(this.ddlpricename1.SelectedValue.ToString());
		int num2 = int.Parse(this.ddlpricename2.SelectedValue.ToString());
		if (num == 1)
		{
			text = "PriceDetail";
		}
		else if (num == 2)
		{
			text = "PriceCost";
		}
		else if (num == 3)
		{
			text = "PriceInner";
		}
		else if (num == 4)
		{
			text = "PriceWholesale1";
		}
		else if (num == 5)
		{
			text = "PriceWholesale2";
		}
		else if (num == 6)
		{
			text = "PriceWholesale3";
		}
		if (num2 == 1)
		{
			text2 = "PriceDetail";
		}
		else if (num2 == 2)
		{
			text2 = "PriceCost";
		}
		else if (num2 == 3)
		{
			text2 = "PriceInner";
		}
		else if (num2 == 4)
		{
			text2 = "PriceWholesale1";
		}
		else if (num2 == 5)
		{
			text2 = "PriceWholesale2";
		}
		else if (num2 == 6)
		{
			text2 = "PriceWholesale3";
		}
		try
		{
			PriceAdjust priceAdjust = new PriceAdjust();
			DALPriceAdjust dALPriceAdjust = new DALPriceAdjust();
			decimal num3 = 0m;
			decimal.TryParse(this.tboxPrice.Text, out num3);
			priceAdjust.Godsadjustconfigid = this.id;
			priceAdjust.Pricename1 = this.ddlpricename1.SelectedItem.Text;
			priceAdjust.Pricename2 = this.ddlpricename2.SelectedItem.Text;
			priceAdjust.Separator = this.ddlseparator.SelectedItem.Text;
			priceAdjust.Price = num3;
			priceAdjust.Formula = string.Concat(new object[]
			{
				"",
				text,
				"=isnull(",
				text2,
				",0)",
				this.ddlseparator.SelectedItem.Text,
				"",
				num3,
				""
			});
			PriceAdjust priceAdjust2 = new PriceAdjust();
			priceAdjust2 = dALPriceAdjust.GetModel(this.id);
			if (this.ddlpricename1.SelectedItem.Text == priceAdjust2.Pricename1.ToString())
			{
				dALPriceAdjust.Update(priceAdjust);
				this.SysInfo("parent.CloseDialog1('1');window.alert('修改成功！');parent.iframeDialog.document.getElementById('Refresh').click();");
			}
			else if (this.ddlpricename1.SelectedItem.Text != priceAdjust2.Pricename1.ToString())
			{
				int num4 = int.Parse(DALCommon.TCount("PriceAdjust", " pricename1='" + this.ddlpricename1.SelectedItem.Text + "'"));
				if (num4 < 1)
				{
					dALPriceAdjust.Update_All(priceAdjust);
					this.SysInfo("parent.CloseDialog1('1');window.alert('修改成功！');parent.iframeDialog.document.getElementById('Refresh').click();");
				}
				else
				{
					this.SysInfo("window.alert('保存失败！【需调价的价格】已存在，请重新输入！');");
				}
			}
		}
		catch
		{
			this.SysInfo("window.alert('修改出错！');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
