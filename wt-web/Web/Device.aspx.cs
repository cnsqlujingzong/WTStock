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
using wt.Model;
using Wuqi.Webdiyer;

public partial class Web_Device : Page, IRequiresSessionState
{
	private string user;
	private int pageSize = 20;

	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		this.user = (string)this.Session["Session_Web_Name"];
		if (!base.IsPostBack)
		{
			this.hfcusid.Value = "-1";
			DALAssociator dALAssociator = new DALAssociator();
			AssociatorInfo model = dALAssociator.GetModel(this.user);
			if (model != null)
			{
				if (model.CustomerID > 0)
				{
					this.hfcusid.Value = model.CustomerID.ToString();
				}
			}
			this.DisplayData();
		}
	}

	public void ChkWebUser()
	{
		if (this.Session["Session_Web_Name"] == null || this.Session["Session_Web_ID"] == null)
		{
			base.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
			base.Response.End();
		}
	}

	protected void DisplayData()
	{
		this.hfrecid.Value = string.Empty;
		this.hfreclist.Value = string.Empty;
		int num = 0;
		string text = this.strParm() + " and CustomerID=" + this.hfcusid.Value;
		this.hfSql.Value = text;
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "ks_device", "", this.pageSize, this.jsPager.CurrentPageIndex, text, "ID Desc", out num);
		this.GridView1.DataBind();
		if (num == 0)
		{
			this.d_empty.Visible = true;
			this.d_page.Visible = false;
		}
		else
		{
			this.d_empty.Visible = false;
			this.d_page.Visible = true;
		}
		this.lbCount.Text = "总记录:" + num.ToString();
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = num;
	}

	protected void btnfresh_Click(object sender, EventArgs e)
	{
		this.DisplayData();
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.DisplayData();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onmouseover", "this.bgColor='#ffffd1'");
			e.Row.Attributes.Add("onmouseout", "this.bgColor=''");
			e.Row.Cells[0].Text = "<input id=\"cb" + e.Row.Cells[1].Text + "\" type=\"checkbox\" class=\"cb1\" onclick=\"cbone(this);\"/>";
			e.Row.Cells[11].Text = "<a href=\"DeviceView.aspx?id=" + e.Row.Cells[1].Text + "\" title=\"查看机器档案\">查看</a>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected string strParm()
	{
		string text = " 1=1 ";
		if (this.ddlkey.SelectedValue != "-1")
		{
			if (this.tbcon.Text.Trim() != "")
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"and ",
					this.ddlkey.SelectedValue,
					" like '%",
					FunLibrary.ChkInput(this.tbcon.Text),
					"%'"
				});
			}
		}
		return text;
	}

	protected void btnsch_Click(object sender, EventArgs e)
	{
		this.DisplayData();
		this.ReturnStr("查询完毕.");
	}

	protected void ReturnStr(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "ReturnStr", "document.getElementById(\"span_info\").style.display=\"inline\";document.getElementById(\"span_info\").innerHTML=\"" + str + "\";", true);
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string value = this.hfSql.Value;
		DataTable dt = DALCommon.GetDataList("ks_device", "LinkMan,CusDept,DeviceNO,ProductClass,ProductBrand,ProductModel,ProductSN1,Warranty,RepairTimes", value).Tables[0];
		string[] tbTitle = new string[]
		{
			"联系人",
			"所属部门",
			"机器编号",
			"类别",
			"品牌",
			"型号",
			"序列号1",
			"保修情况",
			"维修次"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "device", out flag, out empty);
		if (!flag)
		{
			this.DisplayData();
		}
	}
}
