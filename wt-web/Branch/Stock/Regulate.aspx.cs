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

public  partial class Branch_Stock_Regulate : Page, IRequiresSessionState
{
	

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("RegulatePrice", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("RegulateTotal", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
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
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r49"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r51"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r56"))
				{
					this.btnPrint.Visible = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(14, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bStop=0 and bReject=0 ");
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
		dataRow[4] = 0;
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		dataRow[9] = "";
		dataRow[10] = 0;
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
			e.Row.Cells[2].Attributes.Add("style", "padding-left:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[6].Attributes.Add("class", "tbbg");
			e.Row.Cells[9].Attributes.Add("class", "tbbg");
			e.Row.Cells[11].Attributes.Add("class", "tbbg");
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			TextBox textBox2 = e.Row.FindControl("tbRegulatePrice") as TextBox;
			Label label2 = e.Row.FindControl("lbRegulateAmount") as Label;
			textBox.Attributes.Add("onchange", string.Concat(new string[]
			{
				"ValiNum(this,'",
				e.Row.Cells[7].Text,
				"','",
				label.ClientID,
				"');GetGoodsPrice('",
				e.Row.Cells[0].Text,
				"');"
			}));
			textBox2.Attributes.Add("onchange", string.Concat(new string[]
			{
				"ValiMoney(this,'",
				textBox.ClientID,
				"','",
				label2.ClientID,
				"');"
			}));
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		if (this.ddlStock.SelectedValue == "-1")
		{
			this.SysInfo("alert('请先选择仓库！');");
		}
		else
		{
			string text = FunLibrary.ChkInput(this.tbCon.Text.Trim());
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable = DALCommon.GetDataList("ck_stockdept", "", string.Concat(new string[]
			{
				this.ddlSchFld.SelectedValue,
				"='",
				text,
				"' and DeptID=",
				(string)this.Session["Session_wtBranchID"],
				" and StockID=",
				this.ddlStock.SelectedValue
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
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["GoodsID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[4] = decimal.Parse(dataTable.Rows[i]["Stock"].ToString());
						dataRow[5] = decimal.Parse(dataTable.Rows[i]["CostPrice"].ToString());
						dataRow[6] = decimal.Parse(dataTable.Rows[i]["CostAmount"].ToString());
						dataRow[7] = "0.00";
						dataRow[8] = "0.00";
						dataRow[9] = "";
						dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
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
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		if (this.ddlStock.SelectedValue == "-1")
		{
			this.SysInfo("alert('请先选择仓库！');");
		}
		else
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
				DataTable dataTable = DALCommon.GetDataList("ck_stockdept", "", string.Concat(new string[]
				{
					" DeptID=",
					(string)this.Session["Session_wtBranchID"],
					" and [GoodsID] in(",
					text,
					") and StockID=",
					this.ddlStock.SelectedValue
				})).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.CollectData();
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						bool flag = true;
						for (int j = 1; j < gridViewSource.Rows.Count; j++)
						{
							if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["GoodsID"].ToString())
							{
								flag = false;
							}
						}
						if (flag)
						{
							DataRow dataRow = gridViewSource.NewRow();
							dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
							dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
							dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
							dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
							dataRow[4] = decimal.Parse(dataTable.Rows[i]["Stock"].ToString());
							dataRow[5] = decimal.Parse(dataTable.Rows[i]["CostPrice"].ToString());
							dataRow[6] = decimal.Parse(dataTable.Rows[i]["CostAmount"].ToString());
							dataRow[7] = "0.00";
							dataRow[8] = "0.00";
							dataRow[9] = "";
							dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
							gridViewSource.Rows.Add(dataRow);
						}
					}
					this.BindData();
				}
			}
			this.SysInfo("$('tbCon').focus();");
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
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbRegulatePrice") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(this.gvdata.Rows[i].Cells[7].Text)).ToString("#0.00");
			gridViewSource.Rows[i]["RegulatePrice"] = textBox2.Text;
			gridViewSource.Rows[i]["RegulateTotal"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox2.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox3.Text);
		}
	}

	protected void btnGetGoodsPrice_Click(object sender, EventArgs e)
	{
		this.CollectData();
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			DataTable gridViewSource = this.GridViewSource;
			if (this.hfGoodsID.Value == this.gvdata.Rows[i].Cells[0].Text)
			{
				decimal num = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString());
				decimal num2;
				DALCommon.GetGoodsPrice(1, int.Parse(this.ddlStock.SelectedValue), int.Parse(this.hfGoodsID.Value), num, out num2);
				gridViewSource.Rows[i]["Price"] = num2;
				gridViewSource.Rows[i]["Total"] = Convert.ToDouble(num * num2).ToString("#0.00");
				break;
			}
		}
		this.BindData();
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
				DALRegulate dALRegulate = new DALRegulate();
				string empty = string.Empty;
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
				dALRegulate.ChkRegulate(int.Parse((string)this.Session["Session_wtBranchID"]), iTbid, iOperator, out empty);
				this.SysInfo("window.alert('" + empty + "');");
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
				this.SysInfo("window.alert('操作成功！该调价单已保存');");
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
		RegulateInfo regulateInfo = new RegulateInfo();
		regulateInfo.DeptID = int.Parse((string)this.Session["Session_wtBranchID"]);
		regulateInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		regulateInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		regulateInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		regulateInfo.StockID = int.Parse(this.ddlStock.SelectedValue);
		regulateInfo.Status = 1;
		int personID = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out personID);
		regulateInfo.PersonID = personID;
		DataTable gridViewSource = this.GridViewSource;
		decimal qty = 0m;
		if (gridViewSource.Rows.Count > 0)
		{
			List<RegulateDetailInfo> list = new List<RegulateDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					RegulateDetailInfo regulateDetailInfo = new RegulateDetailInfo();
					regulateDetailInfo.GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString());
					decimal.TryParse(gridViewSource.Rows[i]["Qty"].ToString(), out qty);
					regulateDetailInfo.Qty = qty;
					regulateDetailInfo.Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString());
					regulateDetailInfo.RegulatePrice = decimal.Parse(gridViewSource.Rows[i]["RegulatePrice"].ToString());
					regulateDetailInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					list.Add(regulateDetailInfo);
				}
			}
			regulateInfo.RegulateDetailInfos = list;
		}
		DALRegulate dALRegulate = new DALRegulate();
		int result = dALRegulate.Add(regulateInfo, out iTbid);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(14, 0);
		this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		this.ddlOperator.ClearSelection();
		string b = (string)this.Session["Session_wtUserB"];
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
