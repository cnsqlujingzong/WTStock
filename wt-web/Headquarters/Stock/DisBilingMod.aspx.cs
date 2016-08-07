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

public partial class Headquarters_Stock_DisBilingMod : Page, IRequiresSessionState
{
	private int id;

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
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
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
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r49"))
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
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.bDisblingControl)
			{
				this.hfControl.Value = "1";
				this.cbStockOut.Visible = true;
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			OtherFunction.BindStocks(this.ddlStock, " DeptID=1 and bStop=0 ");
			DALDisassembling dALDisassembling = new DALDisassembling();
			DisassemblingInfo model2 = dALDisassembling.GetModel(this.id);
			if (model2 != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model2.BillID;
				this.tbDate.Text = model2._Date;
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model2.OperatorID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlStock.Items.Count; i++)
				{
					if (this.ddlStock.Items[i].Value == model2.StockID.ToString())
					{
						this.ddlStock.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlType.Items.Count; i++)
				{
					if (this.ddlType.Items[i].Text == model2.bType)
					{
						this.ddlType.Items[i].Selected = true;
						break;
					}
				}
				this.tbGoodsNO.Text = model2.GoodsNO;
				this.tbGoodsName.Text = model2._Name;
				this.tbSpec.Text = model2.Spec;
				this.tbBrand.Text = model2.Brand;
				this.tbRemark.Text = model2.Remark;
				this.hfQty.Value = (this.tbQty.Text = model2.Qty.ToString("#0.00"));
				this.tbPrice.Text = model2.Price.ToString("#0.00");
				if (model2.bType == "组装")
				{
					this.lbType.Text = "入";
				}
				this.tbAQty.Text = "0.00";
				this.tbAmount.Text = "0.00";
				this.AddEmpty();
				this.hfUnitsID.Value = model2.UnitID.ToString();
				this.hfSNs.Value = model2.SN.Trim();
				this.cbStockOut.Checked = model2.bStockOut;
				this.hfGoodsID.Value = model2.GoodsID.ToString();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("ck_disassemblingdetail", "", " BillID=" + this.id.ToString()).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString()).ToString("#0.00");
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()).ToString("#0.00");
					dataRow[8] = decimal.Parse(dataTable.Rows[i]["Total"].ToString()).ToString("#0.00");
					dataRow[9] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[10] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[11] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					dataRow[12] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					dataRow[13] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
					dataRow[14] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[15] = 1;
					dataRow[16] = dataTable.Rows[i]["SN"].ToString();
					this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Total"].ToString())).ToString("#0.00");
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
				if (model2.sStatus == "已审核")
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
				if (model2.DeptID != 1)
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "总部只能修改自己的拆装单.";
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
		dataRow[5] = "";
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		dataRow[9] = "";
		dataRow[10] = "";
		dataRow[11] = 0;
		dataRow[12] = 0;
		dataRow[13] = 0;
		dataRow[14] = 0;
		dataRow[15] = 0;
		dataRow[16] = "";
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
			Label label = e.Row.FindControl("lbAmount") as Label;
			HiddenField hiddenField = e.Row.FindControl("hfSN") as HiddenField;
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
			e.Row.Cells[3].Attributes.Add("ondblclick", "SltStock1();");
			e.Row.Cells[9].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[9].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[9].Attributes.Add("ondblclick", "SltUnitQty1('" + textBox.ClientID + "');");
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			e.Row.Cells[11].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			htmlInputButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('p",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');SltPrice1('2','",
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
		this.SysInfo("if(document.getElementById('hfControl'))chkcx();");
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
			this.tbAmount.Text = "0";
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
					dataRow[14] = 0;
					dataRow[15] = 0;
					dataRow[16] = "";
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
						dataRow[14] = 0;
						dataRow[15] = 0;
						dataRow[16] = "";
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
				gridViewSource.Rows[i][12] = int.Parse(this.hfRecIDs.Value);
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
				gridViewSource.Rows[i][14] = int.Parse(this.hfRecIDs.Value);
			}
		}
		this.BindData();
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
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
			gridViewSource.Rows[i]["SN"] = hiddenField.Value.Trim();
			d += decimal.Parse(textBox.Text);
			d2 += decimal.Parse(textBox.Text) * decimal.Parse(textBox2.Text);
		}
		this.tbAQty.Text = d.ToString("#0.00");
		this.tbAmount.Text = d2.ToString("#0.00");
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
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.AddEmpty();
	}

	protected void btnChkParts_Click(object sender, EventArgs e)
	{
		if (this.hfControl.Value.Trim().Equals("1") && !(this.ddlType.SelectedValue != "1"))
		{
			string text = this.hfSNs.Value.Trim();
			if (!(text == ""))
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
						if (dataTable2.Select("GoodsNO='" + gridViewSource.Rows[i]["GoodsNO"].ToString() + "'").Length == 0)
						{
							gridViewSource.Rows[i].Delete();
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
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
			this.BindData();
		}
		else
		{
			string str;
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				DALDisassembling dALDisassembling = new DALDisassembling();
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
				dALDisassembling.ChkDis(1, this.id, iOperator, out str);
				this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
				this.BindData();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
			this.BindData();
		}
		else
		{
			string str;
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该拆装单已保存');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
				this.BindData();
			}
		}
	}

	protected int BillUpdate(out string strMsg)
	{
		DisassemblingInfo disassemblingInfo = new DisassemblingInfo();
		disassemblingInfo.ID = this.id;
		disassemblingInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		disassemblingInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		disassemblingInfo.PersonID = int.Parse(this.Session["Session_wtUserID"].ToString());
		disassemblingInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		disassemblingInfo.Price = decimal.Parse(this.tbPrice.Text);
		disassemblingInfo.Qty = decimal.Parse(this.tbQty.Text);
		disassemblingInfo.StockID = int.Parse(this.ddlStock.SelectedValue);
		disassemblingInfo.SN = this.hfSNs.Value.Trim();
		disassemblingInfo.bStockOut = this.cbStockOut.Checked;
		disassemblingInfo.Type = int.Parse(this.ddlType.SelectedValue);
		string text = "";
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<DisassemblingDetailInfo> list = new List<DisassemblingDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					DisassemblingDetailInfo disassemblingDetailInfo = new DisassemblingDetailInfo();
					disassemblingDetailInfo.ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString());
					disassemblingDetailInfo.StockID = int.Parse(gridViewSource.Rows[i]["StockID"].ToString());
					disassemblingDetailInfo.GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString());
					disassemblingDetailInfo.UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString());
					disassemblingDetailInfo.Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString());
					disassemblingDetailInfo.Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString());
					disassemblingDetailInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					disassemblingDetailInfo.SN = gridViewSource.Rows[i]["SN"].ToString();
					if (disassemblingDetailInfo.ID > 0)
					{
						text = text + disassemblingDetailInfo.ID.ToString() + ",";
					}
					list.Add(disassemblingDetailInfo);
				}
			}
			disassemblingInfo.DisassemblingDetailInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"DisassemblingDetail",
				this.hfdellist.Value
			});
		}
		string[] array = new string[]
		{
			"DisassemblingDetail",
			string.Format("select ID from DisassemblingDetail where BillID={0}", this.id)
		};
		if (!text.Equals(""))
		{
			string[] array2;
			(array2 = array)[1] = array2[1] + string.Format(" and ID not in({0})", text.Trim(new char[]
			{
				','
			}));
		}
		list2.Add(array);
		DALDisassembling dALDisassembling = new DALDisassembling();
		return dALDisassembling.Update(disassemblingInfo, list2, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
