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

public partial class Branch_Stat_StSerMap : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "tj_r31"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			this.tbCity.Text = model.City;
			this.FillData();
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.FillData();
	}

	protected void FillData()
	{
		string text = " 1=1 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DisposalID=" + this.ddlBranch.SelectedValue + "";
		}
		if (this.tbDateB.Text.Trim() != string.Empty)
		{
			text = text + " and Time_TakeOver>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
		}
		if (this.tbDateE.Text.Trim() != string.Empty)
		{
			text = text + " and Time_TakeOver<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'";
		}
		DataTable dataTable = DALCommon.GetDataList("fw_services", "[ID],BillID,curStatus,CustomerName,LinkMan,Tel,Coordinates", text).Tables[0];
		string text2 = "";
		if (dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				string a = dataTable.Rows[i]["Coordinates"].ToString();
				if (a != "")
				{
					string text3 = dataTable.Rows[i]["curStatus"].ToString();
					string text4 = "服务状态：" + dataTable.Rows[i]["curStatus"].ToString() + "<br/>";
					text4 = text4 + "客户名称：" + dataTable.Rows[i]["CustomerName"].ToString() + "<br/>";
					if (dataTable.Rows[i]["LinkMan"].ToString() != "")
					{
						text4 = text4 + "报修人：" + dataTable.Rows[i]["LinkMan"].ToString() + "<br/>";
					}
					if (dataTable.Rows[i]["Tel"].ToString() != "")
					{
						text4 = text4 + "报修人电话：" + dataTable.Rows[i]["Tel"].ToString() + "<br/>";
					}
					string text5 = text2;
					text2 = string.Concat(new string[]
					{
						text5,
						"addMarker(new BMap.Point(",
						dataTable.Rows[i]["Coordinates"].ToString(),
						"), '",
						text3,
						"',",
						dataTable.Rows[i]["ID"].ToString(),
						",'",
						dataTable.Rows[i]["BillID"].ToString(),
						"','",
						text4,
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
