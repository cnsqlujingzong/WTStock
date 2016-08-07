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

public partial class Headquarters_Lease_LeaseMod : Page, IRequiresSessionState
{
	private int id;

	private string ids;

	private string f;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Stock", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("iCount", typeof(int)));
				dataTable.Columns.Add(new DataColumn("dPrice", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("dTotal", typeof(decimal)));
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
				dataTable.Columns.Add(new DataColumn("Attr", typeof(string)));
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
				if (!dALRight.GetRight(num, "zl_r14"))
				{
					this.lbMod.Text = "你没有修改业务的权限！";
					this.lbMod.Attributes.Add("class", "si2");
					this.btnAdd.Enabled = false;
				}
			}
			string strCondition;
			if (this.id == 0)
			{
				strCondition = " BillID='" + this.ids + "'";
			}
			else
			{
				strCondition = " [ID]=" + this.id;
			}
			OtherFunction.BindStocks(this.ddlStock, " DeptID=1 and bStop=0 and bReject=0 ");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0 and bSeller=1");
			this.AddEmpty();
			DataTable dataTable = DALCommon.GetDataList("zl_lease", "", strCondition).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.id = int.Parse(dataTable.Rows[0]["ID"].ToString());
				this.tbBillID.Text = dataTable.Rows[0]["BillID"].ToString();
				this.tbDate.Text = dataTable.Rows[0]["_Date"].ToString();
				string b = dataTable.Rows[0]["Seller"].ToString();
				this.ddlOperator.ClearSelection();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == b)
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.hfPrintID.Value = this.id.ToString();
				this.ddlType.ClearSelection();
				for (int i = 0; i < this.ddlType.Items.Count; i++)
				{
					if (this.ddlType.Items[i].Text == dataTable.Rows[0]["Type"].ToString())
					{
						this.ddlType.Items[i].Selected = true;
						if (dataTable.Rows[0]["Type"].ToString() == "非抄表类租赁")
						{
							this.tbRent.Enabled = false;
							this.lbRent.Text = "租机总额：";
						}
						break;
					}
				}
				this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.tbAutoNO.Text = dataTable.Rows[0]["ContractNO"].ToString();
				this.tbDeposit.Text = dataTable.Rows[0]["Deposit"].ToString();
				this.tbRent.Text = dataTable.Rows[0]["Rent"].ToString();
				this.tbStartDate.Text = dataTable.Rows[0]["StartDate"].ToString();
				this.tbEndDate.Text = dataTable.Rows[0]["EndDate"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbChargeCycle.Text = dataTable.Rows[0]["ChargeCycle"].ToString();
				this.hfPath.Value = dataTable.Rows[0]["Accessory"].ToString();
				if (this.hfPath.Value != "")
				{
					string text = this.hfPath.Value.Substring(this.hfPath.Value.LastIndexOf('/') + 1);
					this.dUpload.InnerHtml = string.Concat(new string[]
					{
						"<img src='../../Public/Images/dmony.gif' /> <a href=\"",
						this.hfPath.Value,
						"\" target=_blank >",
						text,
						"</a>"
					});
				}
				if (dataTable.Rows[0]["curStatus"].ToString() != "待审核")
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "只有待审核的业务单才能修改！";
					this.lbMod.Attributes.Add("class", "si2");
				}
			}
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable2 = DALCommon.GetDataList("zl_leasedevice", "", " BillID=" + this.id).Tables[0];
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			decimal num7 = 0m;
			decimal num8 = 0m;
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = dataTable2.Rows[i]["StockName"].ToString();
				dataRow[1] = dataTable2.Rows[i]["GoodsNO"].ToString();
				decimal.TryParse(dataTable2.Rows[i]["iCount"].ToString(), out num7);
				decimal.TryParse(dataTable2.Rows[i]["LeasePrice"].ToString(), out num8);
				dataRow[2] = num7;
				dataRow[3] = num8;
				dataRow[4] = num7 * num8;
				dataRow[5] = dataTable2.Rows[i]["DeviceNO"].ToString();
				dataRow[6] = dataTable2.Rows[i]["Brand"].ToString();
				dataRow[7] = dataTable2.Rows[i]["Class"].ToString();
				dataRow[8] = dataTable2.Rows[i]["Model"].ToString();
				dataRow[9] = dataTable2.Rows[i]["ProductSN1"].ToString();
				dataRow[10] = dataTable2.Rows[i]["ProductSN2"].ToString();
				dataRow[11] = dataTable2.Rows[i]["StrQty"].ToString();
				dataRow[12] = dataTable2.Rows[i]["Remark"].ToString();
				int.TryParse(dataTable2.Rows[i]["StockID"].ToString(), out num2);
				int.TryParse(dataTable2.Rows[i]["GoodsID"].ToString(), out num3);
				int.TryParse(dataTable2.Rows[i]["BrandID"].ToString(), out num4);
				int.TryParse(dataTable2.Rows[i]["ClassID"].ToString(), out num5);
				int.TryParse(dataTable2.Rows[i]["ModelID"].ToString(), out num6);
				dataRow[13] = num2;
				dataRow[14] = num3;
				dataRow[15] = num4;
				dataRow[16] = num5;
				dataRow[17] = num6;
				dataRow[18] = "";
				dataRow[19] = int.Parse(dataTable2.Rows[i]["ID"].ToString());
				dataRow[20] = 1;
				gridViewSource.Rows.Add(dataRow);
			}
			this.GridViewSource = gridViewSource;
			this.BindData();
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		dataRow[1] = "";
		dataRow[2] = 1;
		dataRow[3] = 0;
		dataRow[4] = 0;
		dataRow[5] = "";
		dataRow[6] = "";
		dataRow[7] = "";
		dataRow[8] = "";
		dataRow[9] = "";
		dataRow[10] = "";
		dataRow[11] = "";
		dataRow[12] = "";
		dataRow[13] = 0;
		dataRow[14] = 0;
		dataRow[15] = 0;
		dataRow[16] = 0;
		dataRow[17] = 0;
		dataRow[18] = "";
		dataRow[19] = 0;
		dataRow[20] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (this.ddlType.SelectedValue != "2")
		{
			e.Row.Cells[3].Visible = false;
			e.Row.Cells[4].Visible = false;
			e.Row.Cells[5].Visible = false;
		}
		else
		{
			e.Row.Cells[11].Visible = false;
			e.Row.Cells[12].Visible = false;
		}
		if (e.Row.RowIndex == 0)
		{
			e.Row.Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[0].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			TextBox textBox = e.Row.FindControl("tbStock") as TextBox;
			DropDownList dropDownList = e.Row.FindControl("ddlStock") as DropDownList;
			dropDownList.ClearSelection();
			for (int i = 0; i < this.ddlStock.Items.Count; i++)
			{
				if (this.ddlStock.Items[i].Text != "")
				{
					dropDownList.Items.Add(new ListItem(this.ddlStock.Items[i].Text, this.ddlStock.Items[i].Value));
				}
			}
			for (int i = 0; i < dropDownList.Items.Count; i++)
			{
				if (dropDownList.Items[i].Text == textBox.Text)
				{
					dropDownList.Items[i].Selected = true;
					break;
				}
			}
			TextBox textBox2 = e.Row.FindControl("tbBrand") as TextBox;
			textBox2.Attributes.Add("onmousedown", "getSearchResult1('../Customer/SchBrand.aspx','" + textBox2.ClientID + "','hfBrand','1','',event);");
			textBox2.Attributes.Add("onkeyup", "getSearchResult1('../Customer/SchBrand.aspx','" + textBox2.ClientID + "','hfBrand','1','',event);");
			textBox2.Attributes.Add("AutoCompleteType", "Disabled");
			TextBox textBox3 = e.Row.FindControl("tbClass") as TextBox;
			textBox3.Attributes.Add("onmousedown", "getSearchResult1('../Customer/SchClass.aspx','" + textBox3.ClientID + "','hfClass','1','',event);");
			textBox3.Attributes.Add("onkeyup", "getSearchResult1('../Customer/SchClass.aspx','" + textBox3.ClientID + "','hfClass','1','',event);");
			textBox3.Attributes.Add("AutoCompleteType", "Disabled");
			TextBox textBox4 = e.Row.FindControl("tbModel") as TextBox;
			textBox4.Attributes.Add("onmousedown", "getSearchResult1('../Customer/SchModel.aspx','" + textBox4.ClientID + "','hfModel','1','',event);");
			textBox4.Attributes.Add("onkeyup", "getSearchResult1('../Customer/SchModel.aspx','" + textBox4.ClientID + "','hfModel','1','',event);");
			textBox4.Attributes.Add("AutoCompleteType", "Disabled");
			HyperLink hyperLink = e.Row.FindControl("hlstrQty") as HyperLink;
			TextBox textBox5 = e.Row.FindControl("tbstrQty") as TextBox;
			hyperLink.Attributes.Add("onclick", "EditQty('" + textBox5.ClientID + "')");
			TextBox textBox6 = e.Row.FindControl("tbPrice") as TextBox;
			TextBox textBox7 = e.Row.FindControl("tbCount") as TextBox;
			Label label = e.Row.FindControl("tbTotal") as Label;
			textBox6.Attributes.Add("onblur", string.Concat(new string[]
			{
				"calcAmountByPrice(this,'",
				textBox7.ClientID,
				"','",
				label.ClientID,
				"');Caculate();"
			}));
			textBox7.Attributes.Add("onblur", string.Concat(new string[]
			{
				"calcAmountByCount(this,'",
				textBox6.ClientID,
				"','",
				label.ClientID,
				"');Caculate();"
			}));
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
			DropDownList dropDownList = this.gvdata.Rows[i].FindControl("ddlStock") as DropDownList;
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbBrand") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbClass") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbModel") as TextBox;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox5 = this.gvdata.Rows[i].FindControl("tbCount") as TextBox;
			TextBox textBox6 = this.gvdata.Rows[i].FindControl("tbDeviceNO") as TextBox;
			TextBox textBox7 = this.gvdata.Rows[i].FindControl("tbSN1") as TextBox;
			TextBox textBox8 = this.gvdata.Rows[i].FindControl("tbSN2") as TextBox;
			TextBox textBox9 = this.gvdata.Rows[i].FindControl("tbstrQty") as TextBox;
			TextBox textBox10 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Stock"] = dropDownList.SelectedItem.Text;
			gridViewSource.Rows[i]["Brand"] = textBox.Text;
			gridViewSource.Rows[i]["Class"] = textBox2.Text;
			gridViewSource.Rows[i]["Model"] = textBox3.Text;
			gridViewSource.Rows[i]["DeviceNO"] = FunLibrary.ChkInput(textBox6.Text);
			gridViewSource.Rows[i]["SN1"] = FunLibrary.ChkInput(textBox7.Text);
			gridViewSource.Rows[i]["SN2"] = FunLibrary.ChkInput(textBox8.Text);
			gridViewSource.Rows[i]["strQty"] = FunLibrary.ChkInput(textBox9.Text);
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox10.Text);
			int num = 0;
			int.TryParse(dropDownList.SelectedItem.Value, out num);
			gridViewSource.Rows[i]["iStock"] = num;
			gridViewSource.Rows[i]["iBrand"] = DALCommon.GetID("ProductBrand", "_Name='" + textBox.Text + "'");
			gridViewSource.Rows[i]["iClass"] = DALCommon.GetID("ProductClass", "_Name='" + textBox2.Text + "'");
			gridViewSource.Rows[i]["iModel"] = DALCommon.GetID("ProductModel", "_Name='" + textBox3.Text + "'");
			int num2 = 0;
			int.TryParse(textBox5.Text, out num2);
			if (num2 == 0)
			{
				num2 = 1;
			}
			gridViewSource.Rows[i]["iCount"] = num2;
			decimal num3 = 0m;
			num3 = (decimal.TryParse(textBox4.Text, out num3) ? num3 : 0m);
			gridViewSource.Rows[i]["dPrice"] = num3;
			gridViewSource.Rows[i]["dTotal"] = num2 * num3;
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
				dataRow[2] = 1;
				dataRow[3] = 0;
				dataRow[4] = 0;
				dataRow[5] = "";
				dataRow[6] = dataTable.Rows[i]["ProductBrand"].ToString();
				dataRow[7] = value;
				dataRow[8] = value2;
				dataRow[9] = dataTable.Rows[i]["SN"].ToString();
				dataRow[10] = "";
				dataRow[11] = "";
				dataRow[12] = "";
				dataRow[13] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
				if (this.ddlSchFld.SelectedValue == "SN")
				{
					dataRow[14] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
				}
				else
				{
					dataRow[14] = int.Parse(dataTable.Rows[i]["ID"].ToString());
				}
				int num3 = 0;
				int.TryParse(dataTable.Rows[i]["BrandID"].ToString(), out num3);
				dataRow[15] = num3;
				dataRow[16] = num;
				dataRow[17] = num2;
				dataRow[18] = "";
				dataRow[19] = 0;
				dataRow[20] = 0;
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
					dataRow[2] = 1;
					dataRow[3] = 0;
					dataRow[4] = 0;
					dataRow[5] = "";
					dataRow[6] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[7] = value;
					dataRow[8] = value2;
					dataRow[9] = "";
					dataRow[10] = "";
					dataRow[11] = "";
					dataRow[12] = "";
					dataRow[13] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					dataRow[14] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					int num3 = 0;
					int.TryParse(dataTable.Rows[i]["BrandID"].ToString(), out num3);
					dataRow[15] = num3;
					dataRow[16] = num;
					dataRow[17] = num2;
					dataRow[18] = "";
					dataRow[19] = 0;
					dataRow[20] = 0;
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
					dataRow[2] = 1;
					dataRow[3] = 0;
					dataRow[4] = 0;
					dataRow[5] = "";
					dataRow[6] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[7] = value;
					dataRow[8] = value2;
					dataRow[9] = dataTable.Rows[i]["SN"].ToString();
					dataRow[10] = "";
					dataRow[11] = "";
					dataRow[12] = "";
					dataRow[13] = int.Parse(dataTable.Rows[i]["StockID"].ToString());
					dataRow[14] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					int num3 = 0;
					int.TryParse(dataTable.Rows[i]["BrandID"].ToString(), out num3);
					dataRow[15] = num3;
					dataRow[16] = num;
					dataRow[17] = num2;
					dataRow[18] = "";
					dataRow[19] = 0;
					dataRow[20] = 0;
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
					dataRow[2] = 1;
					dataRow[3] = 0;
					dataRow[4] = 0;
					dataRow[5] = dataTable2.Rows[i]["DeviceNO"].ToString();
					dataRow[6] = dataTable2.Rows[i]["Brand"].ToString();
					dataRow[7] = dataTable2.Rows[i]["Class"].ToString();
					dataRow[8] = dataTable2.Rows[i]["Model"].ToString();
					dataRow[9] = dataTable2.Rows[i]["ProductSN1"].ToString();
					dataRow[10] = dataTable2.Rows[i]["ProductSN2"].ToString();
					dataRow[11] = dataTable2.Rows[i]["StrQty"].ToString();
					dataRow[12] = dataTable2.Rows[i]["Remark"].ToString();
					dataRow[13] = int.Parse(dataTable2.Rows[i]["StockID"].ToString());
					dataRow[14] = int.Parse(dataTable2.Rows[i]["GoodsID"].ToString());
					int num2 = 0;
					int.TryParse(dataTable2.Rows[i]["BrandID"].ToString(), out num2);
					dataRow[15] = num2;
					int num3 = 0;
					int.TryParse(dataTable2.Rows[i]["ClassID"].ToString(), out num3);
					dataRow[16] = num3;
					int num4 = 0;
					int.TryParse(dataTable2.Rows[i]["ModelID"].ToString(), out num4);
					dataRow[17] = num4;
					dataRow[18] = "";
					dataRow[19] = 0;
					dataRow[20] = 0;
					gridViewSource.Rows.Add(dataRow);
				}
				this.BindData();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！请添加【租赁机器】明细！');");
		}
		else
		{
			string str = "";
			int num = 0;
			int.TryParse(this.hfCusID.Value, out num);
			int num2 = 0;
			if (num > 0)
			{
				DataTable dataTable = DALCommon.GetDataList("CustomerList", "[ID]", string.Concat(new object[]
				{
					" [ID]=",
					num,
					" and _Name='",
					FunLibrary.ChkInput(this.tbCusName.Text),
					"'"
				})).Tables[0];
				if (dataTable.Rows.Count == 0)
				{
					num2 = 1;
				}
			}
			int num3;
			if (num == 0 || num2 == 1)
			{
				CustomerListInfo customerListInfo = new CustomerListInfo();
				customerListInfo.DeptID = new int?(1);
				customerListInfo._Name = FunLibrary.ChkInput(this.tbCusName.Text);
				customerListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbCusName.Text));
				customerListInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
				customerListInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
				customerListInfo.SellerID = new int?(int.Parse(this.ddlOperator.SelectedValue));
				customerListInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
				customerListInfo.OperatorID = int.Parse((string)this.Session["Session_wtUserID"]);
				DALCustomerList dALCustomerList = new DALCustomerList();
				num3 = dALCustomerList.Add(customerListInfo, true, out str, out num);
				if (num3 != 0)
				{
					this.SysInfo("window.alert('" + str + "');");
					return;
				}
			}
			LeaseInfo leaseInfo = new LeaseInfo();
			leaseInfo.ID = this.id;
			leaseInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
			leaseInfo.SellerID = int.Parse(this.ddlOperator.SelectedValue);
			leaseInfo.CustomerID = num;
			leaseInfo.Type = int.Parse(this.ddlType.SelectedValue);
			leaseInfo.CustomerName = FunLibrary.ChkInput(this.tbCusName.Text);
			leaseInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
			leaseInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
			leaseInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
			leaseInfo.ContractNO = FunLibrary.ChkInput(this.tbAutoNO.Text);
			leaseInfo.StartDate = FunLibrary.ChkInput(this.tbStartDate.Text);
			leaseInfo.EndDate = FunLibrary.ChkInput(this.tbEndDate.Text);
			decimal deposit = 0m;
			decimal.TryParse(this.tbDeposit.Text, out deposit);
			leaseInfo.Deposit = deposit;
			int chargeCycle = 0;
			int.TryParse(this.tbChargeCycle.Text, out chargeCycle);
			leaseInfo.ChargeCycle = chargeCycle;
			leaseInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			leaseInfo.Accessory = this.hfPath.Value;
			decimal num4 = 0m;
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count > 0)
			{
				decimal d = 0m;
				List<LeaseDeviceInfo> list = new List<LeaseDeviceInfo>();
				for (int i = 1; i < gridViewSource.Rows.Count; i++)
				{
					LeaseDeviceInfo leaseDeviceInfo = new LeaseDeviceInfo();
					leaseDeviceInfo.ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString());
					leaseDeviceInfo.GoodsID = int.Parse(gridViewSource.Rows[i]["iGoods"].ToString());
					leaseDeviceInfo.StockID = int.Parse(gridViewSource.Rows[i]["iStock"].ToString());
					leaseDeviceInfo.BrandID = int.Parse(gridViewSource.Rows[i]["iBrand"].ToString());
					leaseDeviceInfo.ClassID = int.Parse(gridViewSource.Rows[i]["iClass"].ToString());
					leaseDeviceInfo.ModelID = int.Parse(gridViewSource.Rows[i]["iModel"].ToString());
					leaseDeviceInfo.ProductSN1 = gridViewSource.Rows[i]["SN1"].ToString();
					leaseDeviceInfo.ProductSN2 = gridViewSource.Rows[i]["SN2"].ToString();
					leaseDeviceInfo.DeviceNO = gridViewSource.Rows[i]["DeviceNO"].ToString();
					leaseDeviceInfo.StrQty = FunLibrary.ChkInput(gridViewSource.Rows[i]["strQty"].ToString());
					leaseDeviceInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					leaseDeviceInfo.iCount = int.Parse(gridViewSource.Rows[i]["iCount"].ToString());
					leaseDeviceInfo.LeasePrice = decimal.Parse(gridViewSource.Rows[i]["dPrice"].ToString());
					decimal.TryParse(gridViewSource.Rows[i]["dTotal"].ToString(), out d);
					num4 += d;
					list.Add(leaseDeviceInfo);
				}
				leaseInfo.LeaseDeviceInfos = list;
			}
			if (leaseInfo.Type == 1 || leaseInfo.Type == 3)
			{
				decimal rent = 0m;
				decimal.TryParse(this.tbRent.Text, out rent);
				leaseInfo.Rent = rent;
			}
			else
			{
				leaseInfo.Rent = num4;
			}
			List<string[]> list2 = new List<string[]>();
			if (this.hfdellist.Value != string.Empty)
			{
				list2.Add(new string[]
				{
					"LeaseDevice",
					this.hfdellist.Value
				});
			}
			DALLease dALLease = new DALLease();
			num3 = dALLease.Update2(leaseInfo, (string)this.Session["Session_wtUserID"], list2, out str);
			if (num3 == 0)
			{
				this.SysInfo("window.alert(\"操作成功！业务单已保存\");parent.CloseDialog('1');");
			}
			else if (num3 == -1)
			{
				this.SysInfo("window.alert('" + str + "');");
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlType.SelectedValue != "2")
		{
			this.tbRent.Enabled = true;
			this.lbRent.Text = "基础月租：";
		}
		else
		{
			this.lbRent.Text = "租机费用：";
			this.tbRent.Enabled = false;
		}
		this.GridViewSource.Clear();
		this.AddEmpty();
	}
}
