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

public partial class Branch_Lease_DevBackBat : Page, IRequiresSessionState
{

    private DataSet dsstock = null;
	private int id;

	

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("StockID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("InMoney", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("iCount", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ProductSN1", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DeviceNO", typeof(string)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	public new int ID
	{
		get
		{
			return this.id;
		}
	}

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
			DataSet dataList = DALCommon.GetDataList("zl_leasedevice", "ID,GoodsID,iCount,GoodsNO,StockID,OutPrice,ProductSN1,DeviceNO", string.Format("BillID in(select ID from Lease where  status=1 and customerid=(select top 1 customerID from zl_leasedevice where Billid={0})) and DevStatus='正常' and DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]), this.id));
			if (dataList.Tables[0].Rows.Count > 0)
			{
				DataTable gridViewSource = this.GridViewSource;
				for (int i = 0; i < dataList.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow["ID"] = dataList.Tables[0].Rows[i]["ID"].ToString();
					dataRow["GoodsNO"] = dataList.Tables[0].Rows[i]["GoodsNO"].ToString();
					dataRow["GoodsID"] = dataList.Tables[0].Rows[i]["GoodsID"].ToString();
					dataRow["StockID"] = dataList.Tables[0].Rows[i]["StockID"].ToString();
					dataRow["InMoney"] = dataList.Tables[0].Rows[i]["OutPrice"].ToString();
					dataRow["iCount"] = dataList.Tables[0].Rows[i]["iCount"].ToString();
					dataRow["ProductSN1"] = dataList.Tables[0].Rows[i]["ProductSN1"].ToString();
					dataRow["DeviceNO"] = dataList.Tables[0].Rows[i]["DeviceNO"].ToString();
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
			}
			this.BindData();
		}
	}

	protected void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Style["display"] = "none";
		e.Row.Cells[1].Visible = false;
		e.Row.Cells[2].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			if (this.dsstock == null)
			{
				this.dsstock = DALCommon.GetDataList("StockList", "ID,_Name", "DeptID=" + this.Session["Session_wtBranchID"].ToString());
			}
			DropDownList dropDownList = (DropDownList)e.Row.FindControl("ddlStock");
			dropDownList.DataSource = this.dsstock;
			dropDownList.DataTextField = "_Name";
			dropDownList.DataValueField = "ID";
			dropDownList.DataBind();
			dropDownList.Items.Insert(0, new ListItem("", "-1"));
			dropDownList.SelectedValue = e.Row.Cells[1].Text.Trim();
			TextBox textBox = (TextBox)e.Row.FindControl("tbMoney");
			textBox.Attributes["onblur"] = "ChkMoney(this)";
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void CollectData()
	{
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = (TextBox)this.gvdata.Rows[i].FindControl("tbInCount");
			TextBox textBox2 = (TextBox)this.gvdata.Rows[i].FindControl("tbMoney");
			DropDownList dropDownList = (DropDownList)this.gvdata.Rows[i].FindControl("ddlStock");
			gridViewSource.Rows[i]["InMoney"] = textBox2.Text.Trim();
			gridViewSource.Rows[i]["StockID"] = dropDownList.SelectedValue;
			gridViewSource.Rows[i]["iCount"] = textBox.Text;
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		DALLease dALLease = new DALLease();
		int num = 0;
		int num2 = 0;
		string text = string.Empty;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			int iInStockid = 0;
			int num3 = 0;
			decimal dPrice = 0m;
			string empty = string.Empty;
			int.TryParse(gridViewSource.Rows[i]["StockID"].ToString(), out iInStockid);
			int.TryParse(gridViewSource.Rows[i]["GoodsID"].ToString(), out num3);
			decimal.TryParse(gridViewSource.Rows[i]["InMoney"].ToString(), out dPrice);
			int iCount = 0;
			int.TryParse(gridViewSource.Rows[i]["iCount"].ToString(), out iCount);
			int num4 = dALLease.ChkZLTJ(this.id, iInStockid, dPrice, int.Parse(this.Session["Session_wtUserBID"].ToString()), iCount, out empty);
			if (num4 == 0)
			{
				num++;
			}
			else
			{
				num2++;
				text += string.Format("机器编号：{0}；序列号1：{1}；失败原因：{2}\\n", gridViewSource.Rows[i]["DeviceNO"].ToString(), gridViewSource.Rows[i]["ProductSN1"].ToString(), empty);
			}
		}
		if (num2 == 0 && num > 0)
		{
			this.SysInfo(string.Format("window.alert('操作成功！{0}台机器已退机成功');parent.CloseDialog('1');", num));
		}
		else if (num2 > 0 && num > 0)
		{
			this.SysInfo(string.Format("window.alert('{0}台机器已退机成功，{1}台机器退机失败，失败原因：\\n{2}');parent.CloseDialog('1');", num, num2, text));
		}
		else if (num2 > 0 && num == 0)
		{
			this.SysInfo(string.Format("window.alert('退机失败，失败原因：\\n{2}');", num, num2, text));
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void btnSltIDs_Click(object sender, EventArgs e)
	{
		string text = this.hfidlist.Value.Trim().Trim(new char[]
		{
			','
		});
		if (text != "")
		{
			DataSet dataList = DALCommon.GetDataList("zl_leasedevice", "ID,GoodsID,iCount,GoodsNO,StockID,OutPrice,DeviceNO,ProductSN1", string.Format("BillID in({0}) and DevStatus='正常' and DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]), text));
			DataTable gridViewSource = this.GridViewSource;
			for (int i = 0; i < dataList.Tables[0].Rows.Count; i++)
			{
				if (gridViewSource.Select("ID=" + dataList.Tables[0].Rows[i]["ID"].ToString()).Length == 0)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow["ID"] = dataList.Tables[0].Rows[i]["ID"].ToString();
					dataRow["GoodsNO"] = dataList.Tables[0].Rows[i]["GoodsNO"].ToString();
					dataRow["GoodsID"] = dataList.Tables[0].Rows[i]["GoodsID"].ToString();
					dataRow["StockID"] = dataList.Tables[0].Rows[i]["StockID"].ToString();
					dataRow["InMoney"] = dataList.Tables[0].Rows[i]["OutPrice"].ToString();
					dataRow["iCount"] = dataList.Tables[0].Rows[i]["iCount"].ToString();
					dataRow["ProductSN1"] = dataList.Tables[0].Rows[i]["ProductSN1"].ToString();
					dataRow["DeviceNO"] = dataList.Tables[0].Rows[i]["DeviceNO"].ToString();
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.GridViewSource = gridViewSource;
			this.BindData();
		}
	}

	protected void btnClear_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.BindData();
	}
}
