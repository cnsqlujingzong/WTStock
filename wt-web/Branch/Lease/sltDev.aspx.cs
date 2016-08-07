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

public partial class Branch_Lease_sltDev : Page, IRequiresSessionState
{


	private int id;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int rightID = int.Parse((string)this.Session["Session_wtPurBID"]);
			DALRight dALRight = new DALRight();
			if (!dALRight.GetRight(rightID, "zl_r6"))
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
				base.Response.End();
			}
			this.BindData("");
		}
	}

	protected void BindData(string strWhere)
	{
		string text = "";
		if (base.Request.QueryString["ids"] != null)
		{
			text = base.Request.QueryString["ids"].Trim().Trim(new char[]
			{
				','
			});
		}
		string text2 = strWhere + string.Format("BillID in(select ID from Lease where  status=1 and customerid=(select top 1 customerID from zl_leasedevice where id={0})) and DevStatus='正常' and DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]), this.id);
		if (!text.Equals(""))
		{
			text2 += string.Format(" and ID not in({0})", text);
		}
		DataSet dataList = DALCommon.GetDataList("zl_leasedevice", "", text2);
		this.gvdata.DataSource = dataList;
		this.gvdata.DataBind();
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string text = "";
		string text2 = this.tbCon.Text.Trim();
		if (text2 != "")
		{
			string selectedValue = this.ddlKey.SelectedValue;
			switch (selectedValue)
			{
			case "0":
				text += string.Format("  (DeviceNO like '%{0}%' or Brand like '%{0}%' or Class like '%{0}%' or Model like '%{0}%' or ProductSN1 like '%{0}%' or GoodsNO like '%{0}%') and ", text2);
				break;
			case "1":
				text += string.Format(" DeviceNO like '%{0}%' and ", text2);
				break;
			case "2":
				text += string.Format(" Brand like '%{0}%' and ", text2);
				break;
			case "3":
				text += string.Format(" Class like '%{0}%' and ", text2);
				break;
			case "4":
				text += string.Format(" Model like '%{0}%' and ", text2);
				break;
			case "5":
				text += string.Format(" ProductSN1 like '%{0}%' and ", text2);
				break;
			case "6":
				text += string.Format(" GoodsNO like '%{0}%' and ", text2);
				break;
			}
		}
		this.BindData(text);
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		string text = "," + this.hfreclist.Value.Trim().Trim(new char[]
		{
			','
		}) + ",";
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["id"] = e.Row.Cells[1].Text;
			if (text.Contains("," + e.Row.Cells[1].Text + ","))
			{
				e.Row.Cells[1].Text = "<input id=\"cb" + e.Row.Cells[1].Text + "\" type=\"checkbox\" checked=\"checked\" onclick=\"cbone(this);\"/>";
				e.Row.Attributes.Add("style", "background:#D6F1F8;");
			}
		}
	}
}
