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

public partial class Headquarters_Stock_StockOutMod : Page, IRequiresSessionState
{

	private int id;

	private string ids;

	private string f;

	private static bool bSeeBasePrice = true;

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
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StockID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ClassName", typeof(string)));
                dataTable.Columns.Add(new DataColumn("huoqi", typeof(string)));
                dataTable.Columns.Add(new DataColumn("chengse", typeof(string)));
                dataTable.Columns.Add(new DataColumn("baozhuang", typeof(string)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		this.ids = base.Request["ids"];
		if (this.id == 0 && this.ids == null)
		{
			base.Response.End();
		}
		this.f = base.Request["f"];
		if (this.f == null || this.f == "")
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r23"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r21"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r26"))
				{
					this.btnPrint.Visible = false;
				}
				if (dALRight.GetRight(num, "ck_r85"))
				{
					Headquarters_Stock_StockOutMod.bSeeBasePrice = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			OtherFunction.BindOutReason(this.ddlReason, "");
			DALStockOUT dALStockOUT = new DALStockOUT();
			if (this.id == 0)
			{
				this.id = dALStockOUT.GetID(this.ids);
			}
			StockOUTInfo model = dALStockOUT.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
                this.ddl_fatype.Text = model.SendName;
                this.tb_famonty .Text= model.SendMoney;
                this.tb_fanum.Text = model.SendNum;
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.OperatorID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlReason.Items.Count; i++)
				{
					if (this.ddlReason.Items[i].Value == model.ReasonID.ToString())
					{
						this.ddlReason.Items[i].Selected = true;
						break;
					}
				}
				this.tbRemark.Text = model.Remark;
				this.tbAQty.Text = "0.00";
				this.tbAmount.Text = "0.00";
				this.AddEmpty();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("ck_stockoutdetail", "", " BillID=" + this.id.ToString()).Tables[0];
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
					dataRow[10] = dataTable.Rows[i]["SN"].ToString();
					dataRow[11] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[12] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					dataRow[13] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					dataRow[14] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
					dataRow[15] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[16] = 1;
					dataRow[17] = dataTable.Rows[i]["ClassName"].ToString();

                    dataRow[18] = dataTable.Rows[i]["huoqi"].ToString();
                    dataRow[19] = dataTable.Rows[i]["chengse"].ToString();
                    dataRow[20] = dataTable.Rows[i]["baozhuang"].ToString();

					this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["Qty"].ToString())).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Total"].ToString())).ToString("#0.00");
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
				if (model.DeptID != 1)
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "总部只能修改自己的出库单.";
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
		dataRow[11] = "";
		dataRow[12] = 0;
		dataRow[13] = 0;
		dataRow[14] = 0;
		dataRow[15] = 0;
		dataRow[16] = 0;
		dataRow[17] = "";
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
		if (!Headquarters_Stock_StockOutMod.bSeeBasePrice)
		{
			e.Row.Cells[12].Visible = (e.Row.Cells[13].Visible = false);
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbPrice") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			LinkButton linkButton = e.Row.FindControl("lbDel") as LinkButton;
			TextBox textBox3 = e.Row.FindControl("tbSN") as TextBox;
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
			e.Row.Cells[9].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
			e.Row.Cells[9].Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[9].Attributes.Add("ondblclick", "SltUnit1();");
			e.Row.Cells[10].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[10].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[10].Attributes.Add("ondblclick", "SltUnitQty1('" + textBox.ClientID + "');");
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			e.Row.Cells[12].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
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
			e.Row.Cells[11].Text = string.Concat(new string[]
			{
				"<a href=\"#\" onclick=\"EditSN('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"','",
				textBox3.ClientID,
				"','",
				textBox.ClientID,
				"');\">编辑序列号</a>"
			});
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
					dataRow[0] = dataTable.Rows[i]["StockName"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[3] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[4] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[5] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[6] = 1;
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString());
					dataRow[8] = decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString());
					dataRow[9] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[10] = "";
					dataRow[11] = "";
					int num = 0;
					int.TryParse(dataTable.Rows[i]["StockID"].ToString(), out num);
					dataRow[12] = num;
					dataRow[13] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[14] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
					dataRow[15] = 0;
					dataRow[16] = 0;
					dataRow[17] = dataTable.Rows[i]["ClassName"].ToString();
					decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString())).ToString("#0.00");
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
						dataRow[7] = decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString());
						dataRow[8] = decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString());
						dataRow[9] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[10] = "";
						dataRow[11] = "";
						int num = 0;
						int.TryParse(dataTable.Rows[i]["StockID"].ToString(), out num);
						dataRow[12] = num;
						dataRow[13] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[14] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
						dataRow[15] = 0;
						dataRow[16] = 0;
						dataRow[17] = dataTable.Rows[i]["ClassName"].ToString();
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString())).ToString("#0.00");
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
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["SN"] = textBox2.Text;
			gridViewSource.Rows[i]["Price"] = textBox3.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox4.Text);
			d += decimal.Parse(textBox.Text);
			d2 += decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text);
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

	protected void btnChk_Click(object sender, EventArgs e)
	{
		this.CollectData();
		this.BindData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			string str;
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				DALStockOUT dALStockOUT = new DALStockOUT();
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
				dALStockOUT.ChkStockOut(1, this.id, iOperator, out str);
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
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			string str;
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该出库单已保存');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected int BillUpdate(out string strMsg)
	{
		StockOUTInfo stockOUTInfo = new StockOUTInfo();
		stockOUTInfo.ID = this.id;
		stockOUTInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		stockOUTInfo.OperatorID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		stockOUTInfo.ReasonID = new int?(int.Parse(this.ddlReason.SelectedValue));
		stockOUTInfo.PersonID = new int?(int.Parse(this.Session["Session_wtUserID"].ToString()));
		stockOUTInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
        stockOUTInfo.SendMoney = FunLibrary.ChkInput(this.tb_famonty.Text);
        stockOUTInfo.SendName = FunLibrary.ChkInput(this.ddl_fatype.SelectedValue);
        stockOUTInfo.SendNum = FunLibrary.ChkInput(this.tb_fanum.Text);
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<StockOUTDetailInfo> list = new List<StockOUTDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new StockOUTDetailInfo
					{
						ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString()),
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
			stockOUTInfo.StockOUTDetailInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"StockOUTDetail",
				this.hfdellist.Value
			});
		}
		DALStockOUT dALStockOUT = new DALStockOUT();
		return dALStockOUT.Update(stockOUTInfo, list2, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
