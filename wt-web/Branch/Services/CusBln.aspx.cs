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

public partial class Branch_Services_CusBln : Page, IRequiresSessionState
{
	

	private string id;

	private int type;

	private string corp;

	private int corpid;

	
	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("BillID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ChargeValue", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("WarrantyEndDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WarrantyBound", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ChargeCorp", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WarrantyChargeValue", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ProductModel", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductSN1", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductClass", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WarrantyChargeCorpID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Fee_Materail", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Fee_Labor", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Fee_Add", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ExtraCost", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("PreMoney", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("dPoint", typeof(decimal)));
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
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		this.corp = base.Request["corp"];
		int.TryParse(base.Request["corpid"], out this.corpid);
		int.TryParse(base.Request["type"], out this.type);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r11"))
				{
					this.btnAdd.Enabled = false;
				}
			}
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
			OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
			OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
			OtherFunction.BindGoodsGone(this.ddlGoneType);
			this.tbGoneDate.Text = (this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd"));
			this.tbPreMoney.Text = (this.tbAmount.Text = "0.00");
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID] in(" + this.id.TrimEnd(new char[]
			{
				','
			}) + ")").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.corp = (this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString());
				int.TryParse(dataTable.Rows[0]["CustomerID"].ToString(), out this.corpid);
				int.TryParse(dataTable.Rows[0]["CusType"].ToString(), out this.type);
				DALSysParm dALSysParm = new DALSysParm();
				SysParmInfo sysParm = dALSysParm.GetSysParm();
				string value = DateTime.Now.AddDays(30.0).ToString("yyyy-MM-dd");
				int warrantyCycle = sysParm.WarrantyCycle;
				if (warrantyCycle > 0)
				{
					value = DateTime.Now.AddDays((double)warrantyCycle).ToString("yyyy-MM-dd");
				}
				else
				{
					value = DateTime.Now.ToString("yyyy-MM-dd");
				}
				decimal d = 0m;
				decimal num2 = 0m;
				decimal d2 = 0m;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["BillID"].ToString();
					dataRow[1] = dataTable.Rows[i]["Fee_Total"].ToString();
					dataRow[2] = decimal.Parse(dataTable.Rows[i]["InCash"].ToString()).ToString("#0.00");
					dataRow[3] = value;
					dataRow[4] = "";
					dataRow[5] = dataTable.Rows[i]["ChargeCorp"].ToString();
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["WarrantyChargeValue"].ToString()).ToString("#0.00");
					dataRow[7] = dataTable.Rows[i]["ProductModel"].ToString();
					dataRow[8] = dataTable.Rows[i]["ProductSN1"].ToString();
					dataRow[9] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[10] = dataTable.Rows[i]["ProductClass"].ToString();
					dataRow[11] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[12] = int.Parse(dataTable.Rows[i]["WarrantyChargeCorpID"].ToString());
					dataRow[13] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[14] = decimal.Parse(dataTable.Rows[i]["Fee_Materail"].ToString()).ToString("#0.00");
					dataRow[15] = decimal.Parse(dataTable.Rows[i]["Fee_Labor"].ToString()).ToString("#0.00");
					dataRow[16] = decimal.Parse(dataTable.Rows[i]["Fee_Add"].ToString()).ToString("#0.00");
					dataRow[17] = decimal.Parse(dataTable.Rows[i]["ExtraCost"].ToString()).ToString("#0.00");
					dataRow[18] = decimal.Parse(dataTable.Rows[i]["PreMoney"].ToString()).ToString("#0.00");
					dataRow[19] = decimal.Parse(dataTable.Rows[i]["dPoint"].ToString()).ToString("#0.00");
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Fee_Total"].ToString())).ToString("#0.00");
					decimal.TryParse(dataRow[2].ToString(), out d2);
					d += d2;
					decimal.TryParse(dataRow[18].ToString(), out d2);
					num2 += d2;
					gridViewSource.Rows.Add(dataRow);
				}
				this.tbPreMoney.Text = num2.ToString("#0.00");
				this.tbRealMoney.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) - num2).ToString("#0.00");
				this.tbChargeMoney.Text = d.ToString("#0.00");
				this.GridViewSource = gridViewSource;
				this.BindData();
			}
		}
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
		decimal num = 0m;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbChargeValue") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbWarrantyEndDate") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbWarrantyBound") as TextBox;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			TextBox textBox5 = this.gvdata.Rows[i].FindControl("tbPreMoney") as TextBox;
			TextBox textBox6 = this.gvdata.Rows[i].FindControl("tbFeeAdd") as TextBox;
			TextBox textBox7 = this.gvdata.Rows[i].FindControl("tbCostAdd") as TextBox;
			TextBox textBox8 = this.gvdata.Rows[i].FindControl("tbPoint") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["ChargeValue"] = textBox.Text;
			gridViewSource.Rows[i]["WarrantyEndDate"] = textBox2.Text;
			gridViewSource.Rows[i]["WarrantyBound"] = textBox3.Text;
			gridViewSource.Rows[i]["Remark"] = textBox4.Text;
			gridViewSource.Rows[i]["PreMoney"] = textBox5.Text;
			gridViewSource.Rows[i]["Fee_Add"] = textBox6.Text;
			gridViewSource.Rows[i]["ExtraCost"] = textBox7.Text;
			gridViewSource.Rows[i]["dPoint"] = textBox8.Text;
			gridViewSource.Rows[i]["Amount"] = Convert.ToDouble(decimal.Parse(textBox6.Text) + decimal.Parse(this.gvdata.Rows[i].Cells[6].Text) + decimal.Parse(this.gvdata.Rows[i].Cells[7].Text)).ToString("#0.00");
			decimal.TryParse(gridViewSource.Rows[i]["Amount"].ToString(), out d2);
			d += d2;
			decimal.TryParse(gridViewSource.Rows[i]["PreMoney"].ToString(), out d2);
			num += d2;
		}
		this.tbAmount.Text = d.ToString("#0.00");
		this.tbPreMoney.Text = num.ToString("#0.00");
		this.tbRealMoney.Text = Convert.ToDouble(d - num).ToString("#0.00");
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;");
			TextBox textBox = e.Row.FindControl("tbChargeValue") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbFeeAdd") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			TextBox textBox3 = e.Row.FindControl("tbPreMoney") as TextBox;
			TextBox textBox4 = e.Row.FindControl("tbCostAdd") as TextBox;
			TextBox textBox5 = e.Row.FindControl("tbPoint") as TextBox;
			textBox3.Attributes.Add("oldNum", textBox3.Text);
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox.Attributes.Add("onblur", "ChkMoney(this);");
			textBox4.Attributes.Add("oldNum", textBox4.Text);
			textBox4.Attributes.Add("onblur", "ChkMoney(this);");
			textBox5.Attributes.Add("oldNum", textBox5.Text);
			textBox5.Attributes.Add("onblur", "ChkMoney(this);");
			label.Attributes.Add("oldNum", label.Text);
			textBox2.Attributes.Add("oldNum", textBox2.Text);
			textBox2.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ChkFeeAdd(this,'",
				label.ClientID,
				"','",
				textBox.ClientID,
				"');"
			}));
			textBox3.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ChkPreMoney(this,'",
				label.ClientID,
				"','",
				textBox.ClientID,
				"');"
			}));
			textBox.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ChkChargeValue(this,'",
				label.ClientID,
				"','",
				textBox3.ClientID,
				"');"
			}));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		decimal amount;
		decimal.TryParse(this.tbRealMoney.Text, out amount);
		decimal dPreMoney = 0m;
		decimal.TryParse(this.tbPreMoney.Text, out dPreMoney);
		decimal dRealMoney = 0m;
		decimal.TryParse(this.tbRealMoney.Text, out dRealMoney);
		decimal d = 0m;
		decimal d2 = 0m;
		decimal num = 0m;
		decimal.TryParse(this.tbChargeMoney.Text, out num);
		decimal d3 = 0m;
		decimal d4 = 0m;
		string text = "";
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			decimal.TryParse(gridViewSource.Rows[i]["ChargeValue"].ToString(), out d3);
			d += d3;
			decimal.TryParse(gridViewSource.Rows[i]["PreMoney"].ToString(), out d3);
			d4 += d3;
			if (text == "")
			{
				text = gridViewSource.Rows[i]["BillID"].ToString();
			}
			else
			{
				text = text + ";" + gridViewSource.Rows[i]["BillID"].ToString();
			}
		}
		if (d != num)
		{
			this.SysInfo("window.alert('操作失败！现结金额与单据明细不符，请修改！');");
			this.BindData();
		}
		else
		{
			decimal.TryParse(this.tbPreMoney.Text, out d2);
			if (d4 != d2)
			{
				this.SysInfo("window.alert('操作失败！优惠金额与单据明细不符，请修改！');");
				this.BindData();
			}
			else
			{
				int customerID = new DALServices().getCustomerID(this.id.TrimEnd(new char[]
				{
					','
				}));
				decimal d5 = 0m;
				decimal.TryParse(this.tbChargeMoney.Text, out d5);
				decimal positionAmount = new DALCustomerList().getPositionAmount(customerID);
				if (positionAmount > 0m)
				{
					decimal balance = new DALArrearage().getBalance(customerID);
					decimal d6 = 0m;
					decimal.TryParse(this.tbRealMoney.Text, out d6);
					if (positionAmount - balance - d6 + d5 < 0m)
					{
						this.SysInfo("window.alert('结算失败，客户信誉额度不足，无法挂账！');");
						return;
					}
				}
				string str = "";
				DALServices dALServices = new DALServices();
				int num2 = 0;
				decimal num3 = 0m;
				decimal num4 = 0m;
				decimal num5 = 0m;
				decimal num6 = 0m;
				int iOperator = int.Parse((string)this.Session["Session_wtUserBID"]);
				int iSKRid = int.Parse(this.ddlOperator.SelectedValue);
				string text2 = FunLibrary.ChkInput(this.tbGoneType.Text);
				string text3 = FunLibrary.ChkInput(this.tbGoneDate.Text);
				if (gridViewSource.Rows.Count > 0)
				{
					List<string[]> list = new List<string[]>();
					for (int j = 0; j < gridViewSource.Rows.Count; j++)
					{
						string[] array = new string[3];
						array[0] = "ServicesList";
						string text4 = "";
						decimal.TryParse(gridViewSource.Rows[j]["ChargeValue"].ToString(), out num3);
						text4 = text4 + " InCash=" + num3.ToString();
						decimal.TryParse(gridViewSource.Rows[j]["PreMoney"].ToString(), out num4);
						text4 = text4 + " ,PreMoney=" + num4.ToString();
						decimal.TryParse(gridViewSource.Rows[j]["dpoint"].ToString(), out num6);
						text4 = text4 + ",dpoint=" + num6;
						decimal.TryParse(gridViewSource.Rows[j]["Fee_Add"].ToString(), out num5);
						text4 = text4 + " ,Fee_Add=" + num5.ToString();
						decimal.TryParse(gridViewSource.Rows[j]["ExtraCost"].ToString(), out num4);
						text4 = text4 + " ,ExtraCost=" + num4.ToString();
						string str2 = gridViewSource.Rows[j]["WarrantyEndDate"].ToString();
						text4 = text4 + ",WarrantyEndDate='" + str2 + "'";
						string str3 = gridViewSource.Rows[j]["WarrantyBound"].ToString();
						text4 = text4 + ",WarrantyBound='" + str3 + "'";
						string str4 = gridViewSource.Rows[j]["Remark"].ToString();
						text4 = text4 + ",Remark='" + str4 + "'";
						text4 = text4 + ",GoodsTo='" + text2 + "'";
						if (text3 != "")
						{
							text4 = text4 + ",ConnectDate='" + text3 + "'";
						}
						else
						{
							text4 += ",ConnectDate=null";
						}
						array[1] = text4;
						int.TryParse(gridViewSource.Rows[j]["ID"].ToString(), out num2);
						array[2] = " [ID]=" + num2.ToString();
						list.Add(array);
					}
					int num7 = dALServices.UpdateCusBln(list, out str);
					if (this.corpid == 0 || this.type == 0 || this.corp == null || this.corp == "")
					{
						DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID] in(" + this.id.TrimEnd(new char[]
						{
							','
						}) + ")").Tables[0];
						if (dataTable.Rows.Count > 0)
						{
							int.TryParse(dataTable.Rows[0]["CustomerID"].ToString(), out this.corpid);
							int.TryParse(dataTable.Rows[0]["CusType"].ToString(), out this.type);
						}
					}
					if (num7 == 0)
					{
						decimal invoiceAmount = 0m;
						decimal.TryParse(this.tbInvoiceAmount.Text, out invoiceAmount);
						num7 = dALServices.CusBln(int.Parse((string)this.Session["Session_wtBranchID"]), this.id.TrimEnd(new char[]
						{
							','
						}), text, iOperator, iSKRid, this.type, this.corpid, DateTime.Parse(this.tbDate.Text), amount, int.Parse(this.ddlChargeStyle.SelectedValue), int.Parse(this.ddlChargeAccount.SelectedValue), int.Parse(this.ddlInvoiceClass.SelectedValue), FunLibrary.ChkInput(this.tbInvoiceNO.Text), text2, num, dPreMoney, dRealMoney, FunLibrary.ChkInput(this.tbRemark.Text), FunLibrary.ChkInput(this.tbInvoiceDate.Text), invoiceAmount, FunLibrary.ChkInput(this.tbVoucherNO.Text), out str);
						if (num7 == 0)
						{
							this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！服务单已结算完成');");
						}
						else
						{
							this.SysInfo("window.alert('操作失败！" + str + "');");
						}
					}
					else
					{
						this.SysInfo("window.alert('操作失败！" + str + "');");
					}
				}
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
