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
using wt.OtherLibrary;

public partial class Headquarters_Lease_DevBack : Page, IRequiresSessionState
{
	private int id;

	public new int ID
	{
		get
		{
			return this.id;
		}
	}

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
			int rightID = int.Parse((string)this.Session["Session_wtPurID"]);
			DALRight dALRight = new DALRight();
			if (!dALRight.GetRight(rightID, "zl_r6"))
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
				base.Response.End();
			}
			OtherFunction.BindStocks(this.ddlInStock, " DeptID=1 and bStop=0 ");
			DataTable dataTable = DALCommon.GetDataList("zl_leasedevice", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < this.ddlInStock.Items.Count; i++)
				{
					if (this.ddlInStock.Items[i].Text == dataTable.Rows[0]["StockName"].ToString())
					{
						this.ddlInStock.Items[i].Selected = true;
						break;
					}
				}
				this.tbInGoodsNO.Text = dataTable.Rows[0]["GoodsNO"].ToString();
				this.hfType.Value = dataTable.Rows[0]["Type"].ToString();
				this.tbInCount.Text = dataTable.Rows[0]["iCount"].ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int iInStockid = int.Parse(this.ddlInStock.SelectedValue);
		decimal dPrice = 0m;
		decimal.TryParse(this.tbPrice.Text, out dPrice);
		string str = "";
		DALLease dALLease = new DALLease();
		int iCount = 0;
		int.TryParse(this.tbInCount.Text, out iCount);
		int num = dALLease.ChkZLTJ(this.id, iInStockid, dPrice, int.Parse(this.Session["Session_wtUserID"].ToString()), iCount, out str);
		if (num == 0)
		{
			this.SysInfo("window.alert('操作成功！该机器已退机成功');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + str + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
