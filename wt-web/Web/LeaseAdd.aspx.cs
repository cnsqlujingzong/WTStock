using System;
using System.Collections.Generic;
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
using wt.OtherLibrary;

public partial class Web_LeaseAdd : Page, IRequiresSessionState
{
	private int flag = -2;



	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Stock", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DeviceNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Brand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Class", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Model", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN1", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN2", typeof(string)));
				dataTable.Columns.Add(new DataColumn("strQty", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("iStock", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iGoods", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iBrand", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iClass", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iModel", typeof(int)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}



	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		if (!base.IsPostBack)
		{
			string s = this.Session["Session_Web_ID"].ToString();
			DALAssociator dALAssociator = new DALAssociator();
			this.hfCusID.Value = dALAssociator.getCusID(int.Parse(s)).ToString();
			DALCustomerList dALCustomerList = new DALCustomerList();
			CustomerListInfo model = dALCustomerList.GetModel(int.Parse(this.hfCusID.Value));
			if (model != null)
			{
				this.tbCusName.Text = model._Name;
			}
			this.tbBillID.Text = DALCommon.CreateID(13, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0 and bSeller=1");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindStocks(this.ddlStock, " DeptID=1 and bStop=0 and bReject=0 ");
			this.AddEmpty();
			this.tbChargeCycle.Text = "30";
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = "";
		dataRow[6] = "";
		dataRow[7] = "";
		dataRow[8] = "";
		dataRow[9] = "";
		dataRow[10] = 0;
		dataRow[11] = 0;
		dataRow[12] = 0;
		dataRow[13] = 0;
		dataRow[14] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex == 0)
		{
			e.Row.Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[0].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			DataTable gridViewSource = this.GridViewSource;
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void btnCusInfo_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "_Name,LinkMan,Tel,Adr", " ID=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				return;
			}
		}
		string text = FunLibrary.ChkInput(this.tbCusName.Text);
		if (text != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "[ID],_Name,LinkMan,Tel,Adr", " _Name='" + text + "'").Tables[0];
			if (dataTable.Rows.Count > 1)
			{
				this.SysInfo("ConfCusInfo();");
			}
			else if (dataTable.Rows.Count == 1)
			{
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
			}
			else
			{
				this.hfCusID.Value = "";
			}
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		string tblName = "ck_goods";
		string text = this.ddlSchFld.SelectedValue + "='" + str + "'";
		if (this.ddlSchFld.SelectedValue == "SN")
		{
			tblName = "ck_stocksn";
			text += " and Status='在库' and DeptID=1 ";
		}
		DataTable dataTable = DALCommon.GetDataList(tblName, "", text).Tables[0];
		string text2 = "$('" + this.tbCon.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				string value = "";
				int num = 0;
				string value2 = "";
				int num2 = 0;
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
				dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString() + " " + dataTable.Rows[i]["_Name"].ToString();
				dataRow[2] = "";
				dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
				dataRow[4] = value;
				dataRow[5] = value2;
				dataRow[6] = dataTable.Rows[i]["SN"].ToString();
				dataRow[7] = "";
				dataRow[8] = "";
				dataRow[9] = "";
				dataRow[10] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
				if (this.ddlSchFld.SelectedValue == "SN")
				{
					dataRow[11] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
				}
				else
				{
					dataRow[11] = int.Parse(dataTable.Rows[i]["ID"].ToString());
				}
				int num3 = 0;
				int.TryParse(dataTable.Rows[i]["BrandID"].ToString(), out num3);
				dataRow[12] = num3;
				dataRow[13] = num;
				dataRow[14] = num2;
				gridViewSource.Rows.Add(dataRow);
			}
			this.BindData();
		}
		else
		{
			text2 += "window.alert('操作失败！没有该产品信息');";
		}
		this.SysInfo(text2);
	}

	protected void btnAddGoods_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfGoodsNO.Value != "")
		{
			text = this.hfGoodsNO.Value;
		}
		DALStockList dALStockList = new DALStockList();
		int stockID = dALStockList.GetStockID();
		if (stockID == -1)
		{
			this.SysInfo("window.alert('操作失败！请联系管理员添加仓库!');");
		}
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string value = "";
					int num = 0;
					string value2 = "";
					int num2 = 0;
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString() + " " + dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = "";
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = value;
					dataRow[5] = value2;
					dataRow[6] = "";
					dataRow[7] = "";
					dataRow[8] = "";
					dataRow[9] = "";
					dataRow[10] = stockID;
					dataRow[11] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					int num3 = 0;
					int.TryParse(dataTable.Rows[i]["BrandID"].ToString(), out num3);
					dataRow[12] = num3;
					dataRow[13] = num;
					dataRow[14] = num2;
					gridViewSource.Rows.Add(dataRow);
				}
				this.BindData();
			}
		}
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfreclist.Value.EndsWith(","))
		{
			text = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfreclist.Value;
		}
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string value = "";
					int num = 0;
					string value2 = "";
					int num2 = 0;
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString() + " " + dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = "";
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = value;
					dataRow[5] = value2;
					dataRow[6] = "";
					dataRow[7] = "";
					dataRow[8] = "";
					dataRow[9] = "";
					dataRow[10] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					dataRow[11] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					int num3 = 0;
					int.TryParse(dataTable.Rows[i]["BrandID"].ToString(), out num3);
					dataRow[12] = num3;
					dataRow[13] = num;
					dataRow[14] = num2;
					gridViewSource.Rows.Add(dataRow);
				}
				this.BindData();
			}
		}
		this.SysInfo("$('" + this.tbCon.ClientID + "').focus();");
	}

	protected void btnsngetgds_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfreclist.Value.EndsWith(","))
		{
			text = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfreclist.Value;
		}
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ck_stocksn", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string value = "";
					int num = 0;
					string value2 = "";
					int num2 = 0;
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString() + " " + dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = "";
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = value;
					dataRow[5] = value2;
					dataRow[6] = dataTable.Rows[i]["SN"].ToString();
					dataRow[7] = "";
					dataRow[8] = "";
					dataRow[9] = "";
					dataRow[10] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					dataRow[11] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					int num3 = 0;
					int.TryParse(dataTable.Rows[i]["BrandID"].ToString(), out num3);
					dataRow[12] = num3;
					dataRow[13] = num;
					dataRow[14] = num2;
					gridViewSource.Rows.Add(dataRow);
				}
				this.BindData();
			}
		}
		this.SysInfo("$('" + this.tbCon.ClientID + "').focus();");
	}

	protected void btnSltBill_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfSltID.Value, out num);
		DataTable gridViewSource = this.GridViewSource;
		if (num != 0)
		{
			DataTable dataTable = DALCommon.GetDataList("zl_lease", "", " [ID]=" + num).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.tbAutoNO.Text = dataTable.Rows[0]["ContractNO"].ToString();
				this.tbStartDate.Text = dataTable.Rows[0]["StartDate"].ToString();
				this.tbEndDate.Text = dataTable.Rows[0]["EndDate"].ToString();
				this.tbChargeCycle.Text = dataTable.Rows[0]["ChargeCycle"].ToString();
				this.tbRent.Text = dataTable.Rows[0]["Rent"].ToString();
				this.tbDeposit.Text = dataTable.Rows[0]["Deposit"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
			}
			DataTable dataTable2 = DALCommon.GetDataList("zl_leasedevice", "", " BillID=" + num.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable2.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable2.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable2.Rows[i]["DeviceNO"].ToString();
					dataRow[3] = dataTable2.Rows[i]["Brand"].ToString();
					dataRow[4] = dataTable2.Rows[i]["Class"].ToString();
					dataRow[5] = dataTable2.Rows[i]["Model"].ToString();
					dataRow[6] = dataTable2.Rows[i]["ProductSN1"].ToString();
					dataRow[7] = dataTable2.Rows[i]["ProductSN2"].ToString();
					dataRow[8] = dataTable2.Rows[i]["StrQty"].ToString();
					dataRow[9] = dataTable2.Rows[i]["Remark"].ToString();
					dataRow[10] = int.Parse(dataTable2.Rows[i]["StockID"].ToString());
					dataRow[11] = int.Parse(dataTable2.Rows[i]["GoodsID"].ToString());
					int num2 = 0;
					int.TryParse(dataTable2.Rows[i]["BrandID"].ToString(), out num2);
					dataRow[12] = num2;
					int num3 = 0;
					int.TryParse(dataTable2.Rows[i]["ClassID"].ToString(), out num3);
					dataRow[13] = num3;
					int num4 = 0;
					int.TryParse(dataTable2.Rows[i]["ModelID"].ToString(), out num4);
					dataRow[14] = num4;
					gridViewSource.Rows.Add(dataRow);
				}
				this.BindData();
			}
		}
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			this.SysInfoDe("window.alert('操作失败！请添加【租赁机器】明细！');");
		}
		else
		{
			string str = "";
			int num2;
			int num = this.BillAdd(1, out num2, out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该业务已保存并审核通过');");
				this.ClearText();
			}
			else if (num == -1)
			{
				this.SysInfo("window.alert('" + str + "');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！请查看错误日志');");
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			this.SysInfoDe("window.alert('操作失败！请添加【租赁机器】明细！');");
		}
		else
		{
			string str = "";
			int num2;
			int num = this.BillAdd(0, out num2, out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该业务已保存');");
				this.ClearText();
			}
			else if (num == -1)
			{
				this.SysInfo("window.alert('" + str + "');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！请查看错误日志');");
			}
		}
	}

	protected int BillAdd(int bch, out int iTbid, out string strMsg)
	{
		int num = -1;
		DALAssociator dALAssociator = new DALAssociator();
		AssociatorInfo model = dALAssociator.GetModel(int.Parse(this.Session["Session_Web_ID"].ToString()));
		if (model.CustomerID > 0)
		{
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "[ID]", string.Concat(new object[]
			{
				" [ID]=",
				model.CustomerID,
				" and _Name='",
				model.CustomerName,
				"'"
			})).Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				num = 1;
			}
		}
		int result;
		if (model.CustomerID == 0 || num == 1)
		{
			this.SysInfoDe("window.alert('操作失败！请联系管理员,在“保修会员管理”中设置“关联审核”');");
			iTbid = -1;
			strMsg = "操作失败！请联系管理员,在“保修会员管理”中设置“关联审核”";
			result = -1;
		}
		else
		{
			LeaseInfo leaseInfo = new LeaseInfo();
			leaseInfo.DeptID = 1;
			leaseInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
			leaseInfo.CustomerID = model.CustomerID;
			leaseInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			leaseInfo.CustomerName = model.CustomerName;
			leaseInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
			leaseInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
			leaseInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
			leaseInfo.Status = 0;
			leaseInfo.StartDate = FunLibrary.ChkInput(this.tbStartDate.Text);
			leaseInfo.EndDate = FunLibrary.ChkInput(this.tbEndDate.Text);
			decimal rent = 0m;
			decimal.TryParse(this.tbRent.Text, out rent);
			leaseInfo.Rent = rent;
			decimal deposit = 0m;
			decimal.TryParse(this.tbDeposit.Text, out deposit);
			leaseInfo.Deposit = deposit;
			int chargeCycle = 0;
			int.TryParse(this.tbChargeCycle.Text, out chargeCycle);
			leaseInfo.ChargeCycle = chargeCycle;
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count > 0)
			{
				List<LeaseDeviceInfo> list = new List<LeaseDeviceInfo>();
				for (int i = 1; i < gridViewSource.Rows.Count; i++)
				{
					list.Add(new LeaseDeviceInfo
					{
						GoodsID = int.Parse(gridViewSource.Rows[i]["iGoods"].ToString()),
						Remark = gridViewSource.Rows[i]["Remark"].ToString()
					});
				}
				leaseInfo.LeaseDeviceInfos = list;
			}
			DALLease dALLease = new DALLease();
			this.flag = dALLease.Add(leaseInfo, bch, 0, out iTbid, out strMsg);
			this.hfPrintID.Value = iTbid.ToString();
			result = this.flag;
		}
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(13, 0);
		this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		this.ddlOperator.ClearSelection();
		string b = (string)this.Session["Session_wtUser"];
		for (int i = 0; i < this.ddlOperator.Items.Count; i++)
		{
			if (this.ddlOperator.Items[i].Text == b)
			{
				this.ddlOperator.Items[i].Selected = true;
				break;
			}
		}
		this.hfCusID.Value = "";
		this.hfPath.Value = "";
		this.tbCusName.Text = "";
		this.tbRemark.Text = "";
		this.tbLinkMan.Text = "";
		this.tbTel.Text = "";
		this.tbAutoNO.Text = "";
		this.tbAdr.Text = "";
		this.tbStartDate.Text = "";
		this.tbEndDate.Text = "";
		this.tbDeposit.Text = "";
		this.tbRent.Text = "";
		this.tbChargeCycle.Text = "30";
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void SysInfoDe(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", str, true);
	}

	public void ChkWebUser()
	{
		if (this.Session["Session_Web_Name"] == null || this.Session["Session_Web_ID"] == null)
		{
			base.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
			base.Response.End();
		}
	}
}
