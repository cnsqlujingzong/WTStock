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

public partial class Headquarters_Stock_StockCheck : Page, IRequiresSessionState
{
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
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r61"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r63"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r68"))
				{
					this.btnPrint.Visible = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(15, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindStocks(this.ddlStock, " DeptID=1 and bStop=0 ");
			this.AddEmpty();
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
		e.Row.Cells[0].Visible = (e.Row.Cells[7].Visible = false);
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
			"StockID=",
			this.ddlStock.SelectedValue,
			" and ",
			this.ddlSchFld.SelectedValue,
			"='",
			text,
			"' and DeptID=1"
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
				"StockID=",
				this.ddlStock.SelectedValue,
				" and [ID] in(",
				text,
				") and DeptID=1 order by GoodsNO "
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text2 = "";
					string[] array = new string[300];
					if (this.hfQtylist.Value.ToString() != "" && this.hfQtylist.Value.ToString() != null)
					{
						text2 = this.hfQtylist.Value.ToString();
						text2 = text2.TrimEnd(new char[]
						{
							','
						});
						array = text2.Split(new char[]
						{
							','
						});
					}
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
						if (text2.ToString() == "" || text2.ToString() == null)
						{
							dataRow[6] = 0;
						}
						else
						{
							for (int k = 0; k < 300; k++)
							{
								string[] array2 = array[k].Split(new char[]
								{
									'|'
								});
								if (array2[0] == dataTable.Rows[i]["GoodsNO"].ToString())
								{
									dataRow[6] = array2[1];
									break;
								}
							}
						}
						dataRow[7] = "";
						dataRow[8] = int.Parse(dataTable.Rows[i]["StockLocID"].ToString());
						dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.hfQtylist.Value = "";
		this.SysInfo("$('tbCon').focus();");
	}

	protected void ddlStock_SelectedIndexChanged(object sender, EventArgs e)
	{
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
		if (this.GridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！请添加产品!');$('" + this.tbCon.ClientID + "').select();");
		}
		else
		{
			int iTbid;
			int num = this.BillAdd(out iTbid);
			if (num == 0)
			{
				DALStockCheck dALStockCheck = new DALStockCheck();
				string empty = string.Empty;
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
				dALStockCheck.ChkStockCheck(1, iTbid, iOperator, out empty);
				this.SysInfo("window.alert(\"" + empty + "\");");
				this.ClearText();
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
			this.SysInfo("window.alert('操作失败！请添加产品!');$('" + this.tbCon.ClientID + "').select();");
		}
		else
		{
			int num2;
			int num = this.BillAdd(out num2);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该盘点单已保存');");
				this.ClearText();
			}
			else
			{
				this.SysInfo("window.alert('操作失败！请查看错误日志');");
			}
		}
	}

	protected int BillAdd(out int iTbid)
	{
		StockCheckInfo stockCheckInfo = new StockCheckInfo();
		stockCheckInfo.DeptID = 1;
		stockCheckInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		stockCheckInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		stockCheckInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		stockCheckInfo.StockID = int.Parse(this.ddlStock.SelectedValue);
		stockCheckInfo.Status = 1;
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
		DALStockCheck dALStockCheck = new DALStockCheck();
		int result = dALStockCheck.Add(stockCheckInfo, out iTbid);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(15, 0);
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
		this.ddlStock.ClearSelection();
		this.ddlStock.Items.FindByText("").Selected = true;
		this.tbRemark.Text = "";
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
