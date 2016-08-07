using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Stat_StSerMaterialDe : Page, IRequiresSessionState
{
	
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
			this.FillData();
		}
	}

	protected void FillData()
	{
		int num = 0;
		int.TryParse(base.Request.QueryString["id"], out num);
		if (num != 0)
		{
			DateTime minValue = DateTime.MinValue;
			DateTime datee = DateTime.MinValue;
			if (base.Request.QueryString["sd"] != null)
			{
				DateTime.TryParse(base.Request.QueryString["sd"], out minValue);
			}
			if (base.Request.QueryString["ed"] != null)
			{
				DateTime.TryParse(base.Request.QueryString["ed"], out datee);
				if (!datee.Equals(DateTime.MinValue))
				{
					datee = datee.AddDays(1.0).AddSeconds(-1.0);
				}
			}
			DALServices dALServices = new DALServices();
			DataSet dataSource = dALServices.SerMaterialDe(num, minValue, datee, int.Parse(this.Session["Session_wtBranchID"].ToString()), base.Request.QueryString["hc"] != null);
			this.gvdata.DataSource = dataSource;
			this.gvdata.DataBind();
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		e.Row.Cells[2].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "待处理")
			{
				e.Row.Attributes.Add("style", "color: #ff0000");
			}
			else if (e.Row.Cells[1].Text == "待结算")
			{
				e.Row.Attributes.Add("style", "color: #0000ff");
			}
			else if (e.Row.Cells[1].Text == "处理中")
			{
				e.Row.Attributes.Add("style", "color: #008000");
			}
			else if (e.Row.Cells[1].Text == "已取消")
			{
				e.Row.Attributes.Add("style", "color:#848284");
			}
			else if (e.Row.Cells[1].Text == "已结束")
			{
				e.Row.Attributes.Add("style", "color:#840000");
			}
			else if (e.Row.Cells[1].Text == "送修")
			{
				e.Row.Attributes.Add("style", "color:#8a4000");
			}
			else if (e.Row.Cells[1].Text == "待审核")
			{
				e.Row.Attributes.Add("style", "color:#333333");
			}
		}
	}
}
