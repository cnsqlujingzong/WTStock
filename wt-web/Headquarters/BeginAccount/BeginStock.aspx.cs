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

public partial class Headquarters_BeginAccount_BeginStock : Page, IRequiresSessionState
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
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
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
				if (!dALRight.GetRight(num, "qc_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindStocks(this.ddlStock, " DeptID=1 and bStop=0 ");
			this.tbAQty.Text = "0.00";
			this.tbAmount.Text = "0.00";
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
		dataRow[7] = 0;
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
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbPrice") as TextBox;
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
			e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;padding-right:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[11].Attributes.Add("style", "padding-left:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[8].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[8].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[8].Attributes.Add("ondblclick", "SltUnitQty('" + textBox.ClientID + "');");
			e.Row.Cells[9].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			e.Row.Cells[9].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('p",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[9].Attributes.Add("ondblclick", "SltPrice('1','" + textBox2.ClientID + "');");
			e.Row.Cells[8].Attributes.Add("class", "tbbg");
			e.Row.Cells[9].Attributes.Add("class", "tbbg");
		}
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
					dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[5] = 1;
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
					dataRow[8] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[9] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
					decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00");
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
		else
		{
			text += "window.alert('没有该产品信息！');";
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
				string[] array = text.Split(new char[]
				{
					','
				});
				string text2 = "";
				string[] array2 = new string[100];
				if (this.hfQtylist.Value.ToString() != "" && this.hfQtylist.Value.ToString() != null)
				{
					text2 = this.hfQtylist.Value.ToString();
					text2 = text2.TrimEnd(new char[]
					{
						','
					});
					array2 = text2.Split(new char[]
					{
						','
					});
				}
				string text3 = "";
				string[] array3 = new string[100];
				if (this.hfPriceList.Value.ToString() != null && this.hfPriceList.Value.ToString() != "")
				{
					text3 = this.hfPriceList.Value.ToString();
					text3 = text3.TrimEnd(new char[]
					{
						','
					});
					array3 = text3.Split(new char[]
					{
						','
					});
				}
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							string text4 = gridViewSource.Rows[i]["Qty"].ToString();
							decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
							gridViewSource.Rows[j]["Total"] = decimal.Parse(gridViewSource.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString());
							decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(gridViewSource.Rows[j]["Price"].ToString())).ToString("#0.00");
							flag = false;
						}
					}
					int num = -1;
					for (int k = 0; k < array.Length; k++)
					{
						if (dataTable.Rows[i]["ID"].ToString().Trim().Equals(array[k]))
						{
							num = k;
							break;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
						if (text2.ToString() == "" || text2.ToString() == null || num == -1)
						{
							dataRow[5] = 1;
						}
						else
						{
							dataRow[5] = int.Parse(array2[num].ToString());
						}
						if (text3.ToString() == "" || text3.ToString() == null || num == -1)
						{
							dataRow[6] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
							dataRow[7] = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
							decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString())).ToString("#0.00");
						}
						else
						{
							dataRow[6] = decimal.Parse(array3[num].ToString());
							dataRow[7] = decimal.Parse(array3[num].ToString()) * int.Parse(array2[num].ToString());
							this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + int.Parse(array2[num].ToString())).ToString("#0.00");
							this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(array3[num].ToString()) * int.Parse(array2[num].ToString())).ToString("#0.00");
						}
						dataRow[8] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[9] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.hfPriceList.Value = "";
		this.hfQtylist.Value = "";
		this.SysInfo("$('tbCon').focus();");
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
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["Price"] = textBox2.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox2.Text)).ToString("#0.00");
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

	protected void btnChk_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			int stockID = 0;
			int.TryParse(this.ddlStock.SelectedValue, out stockID);
			BeginStockListInfo beginStockListInfo = new BeginStockListInfo();
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count > 0)
			{
				List<BeginStockInfo> list = new List<BeginStockInfo>();
				for (int i = 0; i < gridViewSource.Rows.Count; i++)
				{
					if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
					{
						list.Add(new BeginStockInfo
						{
							DeptID = 1,
							GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()),
							StockID = stockID,
							BeginStock = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()),
							BeginCost = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString())
						});
					}
				}
				beginStockListInfo.BeginStockInfos = list;
			}
			DALBeginStock dALBeginStock = new DALBeginStock();
			string empty = string.Empty;
			int iOperator = 0;
			int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
			int num = dALBeginStock.Update(beginStockListInfo, 1, iOperator, out empty);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！期初产品库存已建立');");
				this.ClearText();
			}
			else
			{
				this.SysInfo("window.alert('" + empty + "');");
			}
		}
	}

	protected void ClearText()
	{
		this.ddlStock.ClearSelection();
		this.ddlStock.Items.FindByText("").Selected = true;
		this.tbAQty.Text = "0.00";
		this.tbAmount.Text = "0.00";
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
