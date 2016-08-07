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

public partial class Branch_Lease_DeviceAdd : Page, IRequiresSessionState
{

	private int id;

	private static string type = string.Empty;

	
	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Stock", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("iCount", typeof(decimal)));
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
				if (!dALRight.GetRight(num, "zl_r14"))
				{
					this.lbMod.Text = "你没有修改业务的权限！";
					this.lbMod.Attributes.Add("class", "si2");
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]) + " and bStop=0 and bReject=0 ");
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindProductModel(this.ddlModel, "");
			this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
			this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
			this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
			this.AddEmpty();
			string strCondition = " [ID]=" + this.id;
			DataTable dataTable = DALCommon.GetDataList("zl_lease", "", strCondition).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString();
				this.tbAutoNO.Text = dataTable.Rows[0]["ContractNO"].ToString();
				this.tbRent.Text = dataTable.Rows[0]["Rent"].ToString();
				this.tbStartDate.Text = dataTable.Rows[0]["StartDate"].ToString();
				this.tbEndDate.Text = dataTable.Rows[0]["EndDate"].ToString();
				this.tbChargeCycle.Text = dataTable.Rows[0]["ChargeCycle"].ToString();
				Branch_Lease_DeviceAdd.type = dataTable.Rows[0]["Type"].ToString();
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
				if (dataTable.Rows[0]["curStatus"].ToString() != "正常")
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "只有正常的业务单据才能增机！";
					this.lbMod.Attributes.Add("class", "si2");
				}
			}
			if (Branch_Lease_DeviceAdd.type == "非抄表类租赁")
			{
				this.tbRent.Enabled = false;
			}
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
		if (Branch_Lease_DeviceAdd.type != "非抄表类租赁")
		{
			e.Row.Cells[3].Visible = (e.Row.Cells[4].Visible = (e.Row.Cells[5].Visible = false));
		}
		else
		{
			e.Row.Cells[12].Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[0].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			TextBox textBox = e.Row.FindControl("tbStock") as TextBox;
			DropDownList dropDownList = e.Row.FindControl("ddlStock") as DropDownList;
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
			DropDownList dropDownList2 = e.Row.FindControl("ddlBrand") as DropDownList;
			for (int i = 0; i < this.ddlBrand.Items.Count; i++)
			{
				dropDownList2.Items.Add(new ListItem(this.ddlBrand.Items[i].Text, this.ddlBrand.Items[i].Value));
			}
			for (int i = 0; i < dropDownList2.Items.Count; i++)
			{
				if (dropDownList2.Items[i].Text == textBox2.Text)
				{
					dropDownList2.Items[i].Selected = true;
					break;
				}
			}
			TextBox textBox3 = e.Row.FindControl("tbClass") as TextBox;
			DropDownList dropDownList3 = e.Row.FindControl("ddlClass") as DropDownList;
			for (int i = 0; i < this.ddlClass.Items.Count; i++)
			{
				dropDownList3.Items.Add(new ListItem(this.ddlClass.Items[i].Text, this.ddlClass.Items[i].Value));
			}
			for (int i = 0; i < dropDownList3.Items.Count; i++)
			{
				if (dropDownList3.Items[i].Text == textBox3.Text)
				{
					dropDownList3.Items[i].Selected = true;
					break;
				}
			}
			TextBox textBox4 = e.Row.FindControl("tbModel") as TextBox;
			DropDownList dropDownList4 = e.Row.FindControl("ddlModel") as DropDownList;
			for (int i = 0; i < this.ddlModel.Items.Count; i++)
			{
				dropDownList4.Items.Add(new ListItem(this.ddlModel.Items[i].Text, this.ddlModel.Items[i].Value));
			}
			for (int i = 0; i < dropDownList4.Items.Count; i++)
			{
				if (dropDownList4.Items[i].Text == textBox4.Text)
				{
					dropDownList4.Items[i].Selected = true;
					break;
				}
			}
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
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbCount") as TextBox;
			DropDownList dropDownList = this.gvdata.Rows[i].FindControl("ddlStock") as DropDownList;
			DropDownList dropDownList2 = this.gvdata.Rows[i].FindControl("ddlBrand") as DropDownList;
			DropDownList dropDownList3 = this.gvdata.Rows[i].FindControl("ddlClass") as DropDownList;
			DropDownList dropDownList4 = this.gvdata.Rows[i].FindControl("ddlModel") as DropDownList;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbDeviceNO") as TextBox;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbSN1") as TextBox;
			TextBox textBox5 = this.gvdata.Rows[i].FindControl("tbSN2") as TextBox;
			TextBox textBox6 = this.gvdata.Rows[i].FindControl("tbstrQty") as TextBox;
			TextBox textBox7 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Stock"] = dropDownList.SelectedItem.Text;
			gridViewSource.Rows[i]["Brand"] = dropDownList2.SelectedItem.Text;
			gridViewSource.Rows[i]["Class"] = dropDownList3.SelectedItem.Text;
			gridViewSource.Rows[i]["Model"] = dropDownList4.SelectedItem.Text;
			gridViewSource.Rows[i]["DeviceNO"] = FunLibrary.ChkInput(textBox3.Text);
			gridViewSource.Rows[i]["SN1"] = FunLibrary.ChkInput(textBox4.Text);
			gridViewSource.Rows[i]["SN2"] = FunLibrary.ChkInput(textBox5.Text);
			gridViewSource.Rows[i]["strQty"] = FunLibrary.ChkInput(textBox6.Text);
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox7.Text);
			int num = 0;
			int.TryParse(dropDownList.SelectedItem.Value, out num);
			gridViewSource.Rows[i]["iStock"] = num;
			gridViewSource.Rows[i]["iBrand"] = int.Parse(dropDownList2.SelectedItem.Value);
			gridViewSource.Rows[i]["iClass"] = int.Parse(dropDownList3.SelectedItem.Value);
			gridViewSource.Rows[i]["iModel"] = int.Parse(dropDownList4.SelectedItem.Value);
			int num2 = 0;
			int.TryParse(textBox2.Text, out num2);
			if (num2 == 0)
			{
				num2 = 1;
			}
			gridViewSource.Rows[i]["iCount"] = num2;
			decimal num3 = 0m;
			num3 = (decimal.TryParse(textBox.Text, out num3) ? num3 : 0m);
			gridViewSource.Rows[i]["dPrice"] = num3;
			gridViewSource.Rows[i]["dTotal"] = num2 * num3;
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
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
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and Status='在库' and DeptID=",
				int.Parse((string)this.Session["Session_wtBranchID"]),
				" "
			});
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
				this.ddlClass.ClearSelection();
				for (int j = 0; j < this.ddlClass.Items.Count; j++)
				{
					if (this.ddlClass.Items[j].Text == dataTable.Rows[i]["ClassName"].ToString())
					{
						value = this.ddlClass.Items[j].Text;
						num = int.Parse(this.ddlClass.Items[j].Value);
						this.ddlClass.Items[j].Selected = true;
						break;
					}
				}
				if (this.ddlClass.SelectedValue == "-1")
				{
					value = "";
					num = 0;
				}
				string value2 = "";
				int num2 = 0;
				this.ddlModel.ClearSelection();
				for (int j = 0; j < this.ddlModel.Items.Count; j++)
				{
					if (this.ddlModel.Items[j].Text == dataTable.Rows[i]["Spec"].ToString())
					{
						value2 = this.ddlModel.Items[j].Text;
						num2 = int.Parse(this.ddlModel.Items[j].Value);
						this.ddlModel.Items[j].Selected = true;
						break;
					}
				}
				if (this.ddlModel.SelectedValue == "-1")
				{
					value2 = "";
					num2 = 0;
				}
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
					this.ddlClass.ClearSelection();
					for (int j = 0; j < this.ddlClass.Items.Count; j++)
					{
						if (this.ddlClass.Items[j].Text == dataTable.Rows[i]["ClassName"].ToString())
						{
							value = this.ddlClass.Items[j].Text;
							num = int.Parse(this.ddlClass.Items[j].Value);
							this.ddlClass.Items[j].Selected = true;
							break;
						}
					}
					if (this.ddlClass.SelectedValue == "-1")
					{
						value = "";
						num = 0;
					}
					string value2 = "";
					int num2 = 0;
					this.ddlModel.ClearSelection();
					for (int j = 0; j < this.ddlModel.Items.Count; j++)
					{
						if (this.ddlModel.Items[j].Text == dataTable.Rows[i]["Spec"].ToString())
						{
							value2 = this.ddlModel.Items[j].Text;
							num2 = int.Parse(this.ddlModel.Items[j].Value);
							this.ddlModel.Items[j].Selected = true;
							break;
						}
					}
					if (this.ddlModel.SelectedValue == "-1")
					{
						value2 = "";
						num2 = 0;
					}
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
					this.ddlClass.ClearSelection();
					for (int j = 0; j < this.ddlClass.Items.Count; j++)
					{
						if (this.ddlClass.Items[j].Text == dataTable.Rows[i]["ClassName"].ToString())
						{
							value = this.ddlClass.Items[j].Text;
							num = int.Parse(this.ddlClass.Items[j].Value);
							this.ddlClass.Items[j].Selected = true;
							break;
						}
					}
					if (this.ddlClass.SelectedValue == "-1")
					{
						value = "";
						num = 0;
					}
					string value2 = "";
					int num2 = 0;
					this.ddlModel.ClearSelection();
					for (int j = 0; j < this.ddlModel.Items.Count; j++)
					{
						if (this.ddlModel.Items[j].Text == dataTable.Rows[i]["Spec"].ToString())
						{
							value2 = this.ddlModel.Items[j].Text;
							num2 = int.Parse(this.ddlModel.Items[j].Value);
							this.ddlModel.Items[j].Selected = true;
							break;
						}
					}
					if (this.ddlModel.SelectedValue == "-1")
					{
						value2 = "";
						num2 = 0;
					}
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
					gridViewSource.Rows.Add(dataRow);
				}
				this.BindData();
			}
		}
		this.SysInfo("$('" + this.tbCon.ClientID + "').focus();");
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
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
			LeaseInfo leaseInfo = new LeaseInfo();
			leaseInfo.ID = this.id;
			leaseInfo.ContractNO = FunLibrary.ChkInput(this.tbAutoNO.Text);
			leaseInfo.StartDate = FunLibrary.ChkInput(this.tbStartDate.Text);
			leaseInfo.EndDate = FunLibrary.ChkInput(this.tbEndDate.Text);
			decimal rent = 0m;
			decimal.TryParse(this.tbRent.Text, out rent);
			leaseInfo.Rent = rent;
			int chargeCycle = 0;
			int.TryParse(this.tbChargeCycle.Text, out chargeCycle);
			leaseInfo.ChargeCycle = chargeCycle;
			leaseInfo.Accessory = this.hfPath.Value;
			decimal d = 0m;
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count > 0)
			{
				decimal d2 = 0m;
				List<LeaseDeviceInfo> list = new List<LeaseDeviceInfo>();
				for (int i = 1; i < gridViewSource.Rows.Count; i++)
				{
					LeaseDeviceInfo leaseDeviceInfo = new LeaseDeviceInfo();
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
					decimal.TryParse(gridViewSource.Rows[i]["dTotal"].ToString(), out d2);
					d += d2;
					list.Add(leaseDeviceInfo);
				}
				leaseInfo.LeaseDeviceInfos = list;
			}
			string str = "";
			DALLease dALLease = new DALLease();
			int num = dALLease.UpdateAdd(leaseInfo, (string)this.Session["Session_wtUserBID"], out str);
			if (num == 0)
			{
				this.SysInfo("window.alert(\"操作成功！租赁机器增加成功\");parent.CloseDialog('1');");
			}
			else if (num == -1)
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

	protected void SysInfoDe(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", str, true);
	}
}
