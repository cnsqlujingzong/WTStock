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

public partial class Headquarters_Basic_StSerMap : Page, IRequiresSessionState
{
	private string userid;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.userid = base.Request["id"];
		if (this.userid == null || this.userid == "")
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r38"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.FillData();
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.FillData();
	}

	protected void FillData()
	{
		string text = " staffID=" + this.userid + " and DeptID=1";
		if (this.tbDateB.Text.Trim() != string.Empty)
		{
			text = text + " and CreateTime>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
		}
		if (this.tbDateE.Text.Trim() != string.Empty)
		{
			text = text + " and CreateTime<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'";
		}
		text += " and Coordinate<>''";
		DataTable dataTable = DALCommon.GetDataList("Coordinates", "*", text).Tables[0];
		string text2 = "";
		if (dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				string a = dataTable.Rows[i]["Coordinate"].ToString();
				if (a != "")
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"addMarker(new BMap.Point(",
						dataTable.Rows[i]["Coordinate"].ToString(),
						"),'",
						dataTable.Rows[i]["CreateTime"].ToString(),
						"');"
					});
				}
			}
		}
		if (text2 != "")
		{
			this.Page.ClientScript.RegisterStartupScript(base.GetType(), "keys", text2, true);
		}
	}
}
