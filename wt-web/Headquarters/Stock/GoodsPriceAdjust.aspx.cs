using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Stock_GoodsPriceAdjust : Page, IRequiresSessionState
{
	private string id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
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
					this.btnDel.Enabled = false;
					this.btnStart.Enabled = false;
				}
			}
			this.FillDate();
		}
	}

	public void FillDate()
	{
		this.gvgds.DataSource = DALCommon.GetDataList("PriceAdjust", "goodsadjustconfigid,selectflag,pricename1,pricename2,separator,price,formula", "1=1");
		this.gvgds.DataBind();
	}

	protected void gvgds_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[1].Visible = false;
		e.Row.Cells[6].Visible = false;
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ShowGds();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = string.Concat(new string[]
			{
				"<input id=\"cb",
				e.Row.Cells[6].Text,
				"\" type=\"checkbox\" onclick=\"SltValue('",
				e.Row.Cells[6].Text,
				"',this);\"/>"
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToString() == e.Row.Cells[0].Text)
				{
					e.Row.Cells[0].Text = string.Concat(new string[]
					{
						"<input id=\"cb",
						e.Row.Cells[6].Text,
						"\" type=\"checkbox\" checked=\"checked\" onclick=\"SltValue('",
						e.Row.Cells[6].Text,
						"',this);\"/>"
					});
					break;
				}
			}
		}
	}

	protected void Refresh_Click(object sender, EventArgs e)
	{
		this.FillDate();
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		string text = "";
		int num = int.Parse(this.hfRecID.Value);
		int num2 = DALCommon.DeteleData("PriceAdjust", "goodsadjustconfigid=" + num + "", out text);
		if (num2 == 0)
		{
			this.FillDate();
		}
		else
		{
			this.SysInfo("window.alert('删除失败！');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void btnStart_Click(object sender, EventArgs e)
	{
		try
		{
			string value = this.hfcbID.Value;
			value.TrimEnd(new char[]
			{
				','
			});
			DALPriceAdjust dALPriceAdjust = new DALPriceAdjust();
			string str;
			int num = dALPriceAdjust.updatePrice(value.TrimEnd(new char[]
			{
				','
			}), this.id.TrimEnd(new char[]
			{
				','
			}), out str);
			if (num == 0)
			{
				this.SysInfo("parent.CloseDialog('1');window.alert('调整成功！');");
			}
			else
			{
				this.SysInfo("window.alert(\"" + str + "\");");
			}
		}
		catch
		{
			this.SysInfo("window.alert('失败！');");
		}
	}
}
