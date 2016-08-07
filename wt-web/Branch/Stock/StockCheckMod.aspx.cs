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

public partial class Branch_Stock_StockCheckMod : Page, IRequiresSessionState
{
	private int id;



	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("StockLoc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Stock", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StockLocID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
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
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r61"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r59"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r64"))
				{
					this.btnPrint.Visible = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			DALStockCheck dALStockCheck = new DALStockCheck();
			StockCheckInfo model = dALStockCheck.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				OtherFunction.BindStocks(this.ddlStock, "[ID]=" + model.StockID.ToString());
				this.ddlStock.Items.Remove(new ListItem("", "-1"));
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.OperatorID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbRemark.Text = model.Remark;
				this.AddEmpty();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("ck_stockcheckdetail", "", " BillID=" + this.id.ToString()).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockLoc"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[5] = decimal.Parse(dataTable.Rows[i]["Stock"].ToString()).ToString("#0.00");
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString()).ToString("#0.00");
					dataRow[7] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[8] = int.Parse(dataTable.Rows[i]["StockLocID"].ToString());
					dataRow[9] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					dataRow[10] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[11] = 1;
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
				if (model.Status == 2)
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "该单据已经审核，修改无法保存";
					this.lbMod.Attributes.Add("class", "si2");
				}
				else
				{
					this.lbMod.Text = "若手工输入编号或条码，输入完成后回车";
					this.lbMod.Attributes.Add("class", "si1");
				}
				if (model.DeptID != int.Parse((string)this.Session["Session_wtBranchID"]))
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "只能修改本部门的盘点单.";
					this.lbMod.Attributes.Add("class", "si2");
				}
			}
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
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = "";
		dataRow[8] = 0;
		dataRow[9] = 0;
		dataRow[10] = 0;
		dataRow[11] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;padding-right:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[10].Attributes.Add("style", "padding-left:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[8].Attributes.Add("class", "tbbg");
			e.Row.Cells[9].Attributes.Add("class", "tbbg");
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ck_goods_check", "", string.Concat(new string[]
		{
			" StockID=",
			this.ddlStock.SelectedValue,
			" and ",
			this.ddlSchFld.SelectedValue,
			"='",
			text,
			"' and DeptID=",
			(string)this.Session["Session_wtBranchID"]
		})).Tables[0];
		string text2 = "$('" + this.tbCon.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < gridViewSource.Rows.Count; j++)
				{
					if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
					{
						flag = false;
					}
				}
				if (flag)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockLoc"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[4] = dataTable.Rows[i]["Brand"].ToString();
					dataRow[5] = decimal.Parse(dataTable.Rows[i]["Stock"].ToString());
					dataRow[6] = 0;
					dataRow[7] = "";
					dataRow[8] = int.Parse(dataTable.Rows[i]["StockLocID"].ToString());
					dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[10] = 0;
					dataRow[11] = 0;
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
		else
		{
			text2 += "window.alert('没有该产品信息！');";
		}
		this.SysInfo(text2);
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
			DataTable dataTable = DALCommon.GetDataList("ck_goods_check", "", string.Concat(new string[]
			{
				" StockID=",
				this.ddlStock.SelectedValue,
				" and [ID] in(",
				text,
				")  and DeptID=",
				(string)this.Session["Session_wtBranchID"]
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["StockLoc"].ToString();
						dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[4] = dataTable.Rows[i]["Brand"].ToString();
						dataRow[5] = decimal.Parse(dataTable.Rows[i]["Stock"].ToString());
						dataRow[6] = 0;
						dataRow[7] = "";
						dataRow[8] = int.Parse(dataTable.Rows[i]["StockLocID"].ToString());
						dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[10] = 0;
						dataRow[11] = 0;
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.SysInfo("$('tbCon').focus();");
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
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox2.Text);
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (i == e.RowIndex)
			{
				if (int.Parse(gridViewSource.Rows[i]["iFlag"].ToString()) == 1)
				{
					if (this.hfdellist.Value == string.Empty)
					{
						this.hfdellist.Value = gridViewSource.Rows[i]["RecID"].ToString();
					}
					else
					{
						HiddenField expr_AA = this.hfdellist;
						expr_AA.Value = expr_AA.Value + "," + gridViewSource.Rows[i]["RecID"].ToString();
					}
				}
			}
		}
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		this.CollectData();
		this.BindData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品!');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			string str;
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				DALStockCheck dALStockCheck = new DALStockCheck();
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
				dALStockCheck.ChkStockCheck(int.Parse((string)this.Session["Session_wtBranchID"]), this.id, iOperator, out str);
				this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		this.BindData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品!');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			string str;
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该盘点单已保存');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected int BillUpdate(out string strMsg)
	{
		StockCheckInfo stockCheckInfo = new StockCheckInfo();
		stockCheckInfo.ID = this.id;
		stockCheckInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		stockCheckInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		stockCheckInfo.StockID = int.Parse(this.ddlStock.SelectedValue);
		stockCheckInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DataTable gridViewSource = this.GridViewSource;
		decimal qty = 0m;
		if (gridViewSource.Rows.Count > 0)
		{
			List<StockCheckDetailInfo> list = new List<StockCheckDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					StockCheckDetailInfo stockCheckDetailInfo = new StockCheckDetailInfo();
					stockCheckDetailInfo.ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString());
					stockCheckDetailInfo.StockLocID = int.Parse(gridViewSource.Rows[i]["StockLocID"].ToString());
					stockCheckDetailInfo.GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString());
					decimal.TryParse(gridViewSource.Rows[i]["Qty"].ToString(), out qty);
					stockCheckDetailInfo.Qty = qty;
					stockCheckDetailInfo.Stock = decimal.Parse(gridViewSource.Rows[i]["Stock"].ToString());
					stockCheckDetailInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					list.Add(stockCheckDetailInfo);
				}
			}
			stockCheckInfo.StockCheckDetailInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"StockCheckDetail",
				this.hfdellist.Value
			});
		}
		DALStockCheck dALStockCheck = new DALStockCheck();
		return dALStockCheck.Update(stockCheckInfo, list2, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
