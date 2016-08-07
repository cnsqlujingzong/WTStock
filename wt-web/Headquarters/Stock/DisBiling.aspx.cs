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

public partial class Headquarters_Stock_DisBiling : Page, IRequiresSessionState
{
	private int flag;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("StockName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StockID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
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
		int.TryParse(base.Request["flag"], out this.flag);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r45"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r47"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r52"))
				{
					this.btnPrint.Visible = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(11, 0);
			this.tbDate.Text = DateTime.Now.ToString();
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
			this.tbAQty.Text = "0.00";
			this.tbAmount.Text = "0.00";
			this.tbPrice.Text = "0.00";
			this.tbQty.Text = "1";
			this.AddEmpty();
			if (this.flag == 1)
			{
				this.lbType.Text = "入";
				this.ddlType.ClearSelection();
				this.ddlType.Items.FindByValue("2").Selected = true;
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.bDisblingControl)
			{
				this.hfControl.Value = "1";
				this.cbStockOut.Visible = true;
				this.tbQty.Text = "1";
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
		dataRow[5] = "";
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		dataRow[9] = "";
		dataRow[10] = "";
		dataRow[11] = 0;
		dataRow[12] = 0;
		dataRow[13] = 0;
		dataRow[14] = "";
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
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbPrice") as TextBox;
			HiddenField hiddenField = e.Row.FindControl("hfSN") as HiddenField;
			Label label = e.Row.FindControl("lbAmount") as Label;
			LinkButton linkButton = e.Row.FindControl("lbDel") as LinkButton;
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox2.Attributes.Add("oldNum", textBox2.Text);
			label.Attributes.Add("oldNum", label.Text);
			linkButton.Attributes.Add("num", e.Row.RowIndex.ToString());
			linkButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkAmount(this,'",
				label.ClientID,
				"','",
				textBox.ClientID,
				"');"
			}));
			textBox.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateNum(this,'",
				textBox2.ClientID,
				"','",
				label.ClientID,
				"');"
			}));
			textBox2.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateMoney(this,'",
				textBox.ClientID,
				"','",
				label.ClientID,
				"');"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[3].Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Cells[3].Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[3].Attributes.Add("ondblclick", "SltStock();");
			e.Row.Cells[9].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[9].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[9].Attributes.Add("ondblclick", "SltUnitQty('" + textBox.ClientID + "');");
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			e.Row.Cells[11].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			htmlInputButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('p",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');SltPrice('2','",
				textBox2.ClientID,
				"');"
			}));
			e.Row.Cells[10].Text = string.Concat(new string[]
			{
				"<a href=\"#\" onclick=\"EditSN('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"','",
				hiddenField.ClientID,
				"','",
				textBox.ClientID,
				"',1);\">编辑序列号</a>"
			});
		}
		this.SysInfo("chkcx();");
	}

	protected void btnchkgoods_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbGoodsNO.Text.Trim());
		this.GridViewSource.Clear();
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.AddEmpty();
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ck_goods", "", "GoodsNO='" + str + "'").Tables[0];
		decimal d = 0m;
		if (dataTable.Rows.Count > 0)
		{
			decimal.TryParse(this.tbQty.Text, out d);
			if (d == 0m)
			{
				d = 1m;
			}
			this.tbQty.Text = d.ToString();
			this.ddlStock.ClearSelection();
			for (int i = 0; i < this.ddlStock.Items.Count; i++)
			{
				if (this.ddlStock.Items[i].Value == dataTable.Rows[0]["StockID"].ToString())
				{
					this.ddlStock.Items[i].Selected = true;
					break;
				}
			}
			this.tbGoodsName.Text = dataTable.Rows[0]["_Name"].ToString();
			this.hfGoodsID.Value = dataTable.Rows[0]["ID"].ToString();
			this.tbSpec.Text = dataTable.Rows[0]["Spec"].ToString();
			this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
			this.tbPrice.Text = dataTable.Rows[0]["PriceCost"].ToString();
			this.hfGoodsNO.Value = dataTable.Rows[0]["GoodsNO"].ToString();
			this.hfQty.Value = this.tbQty.Text;
			this.hfUnitsID.Value = dataTable.Rows[0]["GoodsUnitID"].ToString();
			DataTable dataTable2 = DALCommon.GetDataList("ck_slt_dismounting", "", "DisGoodsNO='" + str + "'").Tables[0];
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = dataTable2.Rows[i]["StockName"].ToString();
				dataRow[1] = dataTable2.Rows[i]["GoodsNO"].ToString();
				dataRow[2] = dataTable2.Rows[i]["_Name"].ToString();
				dataRow[3] = dataTable2.Rows[i]["Spec"].ToString();
				dataRow[4] = dataTable2.Rows[i]["ProductBrand"].ToString();
				dataRow[5] = dataTable2.Rows[i]["Unit"].ToString();
				dataRow[6] = d * decimal.Parse(dataTable2.Rows[i]["Qty"].ToString());
				dataRow[7] = decimal.Parse(dataTable2.Rows[i]["PriceCost"].ToString());
				dataRow[8] = d * decimal.Parse(dataTable2.Rows[i]["PriceCost"].ToString());
				dataRow[9] = dataTable2.Rows[i]["MainTenancePeriod"].ToString();
				dataRow[10] = "";
				dataRow[11] = int.Parse(dataTable2.Rows[i]["StockID"].ToString());
				dataRow[12] = int.Parse(dataTable2.Rows[i]["GoodsID"].ToString());
				dataRow[13] = int.Parse(dataTable2.Rows[i]["GoodsUnitID"].ToString());
				dataRow[14] = "";
				this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + d * decimal.Parse(dataTable2.Rows[i]["Qty"].ToString())).ToString("#0.00");
				this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + d * decimal.Parse(dataTable2.Rows[i]["PriceCost"].ToString())).ToString("#0.00");
				gridViewSource.Rows.Add(dataRow);
			}
			this.BindData();
		}
		else
		{
			this.tbGoodsNO.Text = (this.tbGoodsName.Text = (this.tbSpec.Text = (this.tbBrand.Text = "")));
			this.tbPrice.Text = "0.00";
			this.tbQty.Text = "1";
			this.hfGoodsID.Value = "";
			this.SysInfo("$('" + this.tbGoodsNO.ClientID + "').focus();window.alert('没有该产品信息！');");
		}
	}

	protected void btnchkgdsqty_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbGoodsNO.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ck_slt_dismounting", "", "DisGoodsNO='" + str + "'").Tables[0];
		decimal d = 0m;
		decimal.TryParse(this.tbQty.Text, out d);
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				for (int j = 0; j < gridViewSource.Rows.Count; j++)
				{
					if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["GoodsID"].ToString())
					{
						gridViewSource.Rows[j]["Qty"] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString()) * d;
						gridViewSource.Rows[j]["Total"] = Convert.ToDouble(decimal.Parse(dataTable.Rows[i]["Qty"].ToString()) * d * decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
						this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) - decimal.Parse(dataTable.Rows[i]["Qty"].ToString()) * decimal.Parse(this.hfQty.Value) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString()) * d).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
					}
				}
			}
			this.BindData();
		}
		this.hfQty.Value = this.tbQty.Text;
		this.SysInfo("chkcx();");
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ck_goods", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
		string text = "$('" + this.tbCon.ClientID + "').select();";
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
						decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
						gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
						flag = false;
					}
				}
				if (flag)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[6] = 1;
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
					dataRow[8] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
					dataRow[9] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[10] = "";
					dataRow[11] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					dataRow[12] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[13] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
					dataRow[14] = "";
					decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00");
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
		else
		{
			text += "window.alert('操作失败！没有该产品信息');";
		}
		this.SysInfo(text);
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
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							string text2 = gridViewSource.Rows[i]["Qty"].ToString();
							decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
							gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
							decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
						dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[6] = 1;
						dataRow[7] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
						dataRow[8] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
						dataRow[9] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[10] = "";
						dataRow[11] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
						dataRow[12] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[13] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
						dataRow[14] = "";
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00");
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.SysInfo("$('tbCon').focus();");
	}

	protected void btnSltStock_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["GoodsID"].ToString() == this.hfRecID.Value)
			{
				gridViewSource.Rows[i][0] = this.hfName.Value;
				gridViewSource.Rows[i][11] = int.Parse(this.hfRecIDs.Value);
			}
		}
		this.BindData();
	}

	protected void btnSltUnit_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["GoodsID"].ToString() == this.hfRecID.Value.Replace("u", ""))
			{
				gridViewSource.Rows[i][5] = this.hfName.Value;
				gridViewSource.Rows[i][13] = int.Parse(this.hfRecIDs.Value);
			}
		}
		this.BindData();
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
		if (this.ddlType.SelectedValue == "1")
		{
			this.lbType.Text = "出";
		}
		else
		{
			this.lbType.Text = "入";
		}
	}

	protected void CollectData()
	{
		decimal d = 0m;
		decimal d2 = 0m;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			HiddenField hiddenField = this.gvdata.Rows[i].FindControl("hfSN") as HiddenField;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["Price"] = textBox2.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox2.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox3.Text);
			gridViewSource.Rows[i]["SN"] = hiddenField.Value;
			d += decimal.Parse(textBox.Text);
			d2 += decimal.Parse(textBox.Text) * decimal.Parse(textBox2.Text);
		}
		this.tbAQty.Text = d.ToString("#0.00");
		this.tbAmount.Text = d2.ToString("#0.00");
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
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.AddEmpty();
	}

	protected void btnChkParts_Click(object sender, EventArgs e)
	{
		if (this.hfControl.Value.Trim().Equals("1") && !(this.ddlType.SelectedValue != "1"))
		{
			string text = this.hfSNs.Value.Trim();
			if (text == "")
			{
				this.SysInfo("chkcx();");
			}
			else
			{
				string str = FunLibrary.ChkInput(this.tbGoodsNO.Text.Trim());
				this.tbAQty.Text = "0.00";
				this.tbAmount.Text = "0.00";
				this.AddEmpty();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("ck_goods", "", "GoodsNO='" + str + "'").Tables[0];
				decimal d = 0m;
				if (dataTable.Rows.Count > 0)
				{
					decimal.TryParse(this.tbQty.Text, out d);
					if (d == 0m)
					{
						d = 1m;
					}
					this.tbQty.Text = d.ToString();
					this.ddlStock.ClearSelection();
					for (int i = 0; i < this.ddlStock.Items.Count; i++)
					{
						if (this.ddlStock.Items[i].Value == dataTable.Rows[0]["StockID"].ToString())
						{
							this.ddlStock.Items[i].Selected = true;
							break;
						}
					}
					this.tbGoodsName.Text = dataTable.Rows[0]["_Name"].ToString();
					this.hfGoodsID.Value = dataTable.Rows[0]["ID"].ToString();
					this.tbSpec.Text = dataTable.Rows[0]["Spec"].ToString();
					this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
					this.tbPrice.Text = dataTable.Rows[0]["PriceCost"].ToString();
					this.hfGoodsNO.Value = dataTable.Rows[0]["GoodsNO"].ToString();
					this.hfQty.Value = this.tbQty.Text;
					this.hfUnitsID.Value = dataTable.Rows[0]["GoodsUnitID"].ToString();
					DataTable dataTable2 = DALCommon.GetDataList("ck_slt_dismounting", "", string.Format(" DisMountingID={0} and GoodsID in(select dm.GoodsID from \r\n            Dismounting dm left join(select sum(dd.Qty) ac,dd.GoodsID from DisassemblingDetail dd left join Disassembling d on dd.BillID=d.ID where d.SN='{1}' and d.Type=1 and d.Status=2\r\n            group by dd.GoodsID)a on dm.GoodsID=a.GoodsID where DismountingID=(select top 1 GoodsID from StockSN ss left join StockInDetail sid on ss.StockINDeID=sid.ID\r\n            where ss.SN='{1}') and isnull(dm.Qty,0)>isnull(a.ac,0))", this.hfGoodsID.Value, text)).Tables[0];
					for (int i = 0; i < gridViewSource.Rows.Count; i++)
					{
						string text2 = gridViewSource.Rows[i]["GoodsNO"].ToString();
						if (text2 != "" && dataTable2.Select("GoodsNO='" + text2 + "'").Length == 0)
						{
							gridViewSource.Rows[i].Delete();
							i--;
						}
					}
					this.BindData();
				}
				else
				{
					this.tbGoodsNO.Text = (this.tbGoodsName.Text = (this.tbSpec.Text = (this.tbBrand.Text = "")));
					this.tbPrice.Text = "0.00";
					this.tbQty.Text = "1";
					this.hfGoodsID.Value = "";
					this.SysInfo("$('" + this.tbGoodsNO.ClientID + "').focus();window.alert('没有该产品信息！');");
				}
			}
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", string.Concat(new string[]
			{
				"window.alert('操作失败！请添加[",
				this.ddlType.SelectedItem.Text,
				"]产品明细');$('",
				this.tbCon.ClientID,
				"').select();"
			}), true);
		}
		else
		{
			int iTbid;
			int num = this.BillAdd(out iTbid);
			if (num == 0)
			{
				DALDisassembling dALDisassembling = new DALDisassembling();
				string empty = string.Empty;
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
				dALDisassembling.ChkDis(1, iTbid, iOperator, out empty);
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
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", string.Concat(new string[]
			{
				"window.alert('操作失败！请添加[",
				this.ddlType.SelectedItem.Text,
				"]产品明细');$('",
				this.tbCon.ClientID,
				"').select();"
			}), true);
		}
		else
		{
			int num2;
			int num = this.BillAdd(out num2);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该拆装单已保存');");
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
		DisassemblingInfo disassemblingInfo = new DisassemblingInfo();
		disassemblingInfo.DeptID = 1;
		disassemblingInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		disassemblingInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		disassemblingInfo.StockID = int.Parse(this.ddlStock.SelectedValue);
		disassemblingInfo.GoodsID = int.Parse(this.hfGoodsID.Value);
		disassemblingInfo.Price = decimal.Parse(this.tbPrice.Text);
		disassemblingInfo.Qty = decimal.Parse(this.tbQty.Text);
		disassemblingInfo.UnitID = int.Parse(this.hfUnitsID.Value);
		disassemblingInfo.PersonID = int.Parse(this.Session["Session_wtUserID"].ToString());
		disassemblingInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		disassemblingInfo.Type = int.Parse(this.ddlType.SelectedValue);
		disassemblingInfo.SN = this.hfSNs.Value;
		disassemblingInfo.bStockOut = this.cbStockOut.Checked;
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<DisassemblingDetailInfo> list = new List<DisassemblingDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new DisassemblingDetailInfo
					{
						StockID = int.Parse(gridViewSource.Rows[i]["StockID"].ToString()),
						GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()),
						UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString()),
						Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()),
						Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString()),
						Remark = gridViewSource.Rows[i]["Remark"].ToString(),
						SN = gridViewSource.Rows[i]["SN"].ToString()
					});
				}
			}
			disassemblingInfo.DisassemblingDetailInfos = list;
		}
		DALDisassembling dALDisassembling = new DALDisassembling();
		int result = dALDisassembling.Add(disassemblingInfo, out iTbid);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(11, 0);
		this.tbDate.Text = DateTime.Now.ToString();
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
		this.tbQty.Text = "1";
		this.tbPrice.Text = "0.00";
		this.tbGoodsNO.Text = "";
		this.tbGoodsName.Text = (this.tbSpec.Text = (this.tbBrand.Text = (this.hfGoodsID.Value = (this.hfUnitsID.Value = ""))));
		this.tbRemark.Text = "";
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.hfSNs.Value = "";
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
