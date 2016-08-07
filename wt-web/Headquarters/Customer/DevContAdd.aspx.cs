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

public partial class Headquarters_Customer_DevContAdd : Page, IRequiresSessionState
{
	private int id;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Brand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Class", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Model", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Level", typeof(string)));
				dataTable.Columns.Add(new DataColumn("bRepair", typeof(bool)));
				dataTable.Columns.Add(new DataColumn("bConsumables", typeof(bool)));
				dataTable.Columns.Add(new DataColumn("bMaterial", typeof(bool)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("LevelID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("DeviceNO", typeof(string)));
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
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r21"))
				{
					this.btnAdd.Enabled = false;
				}
			}
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
			OtherFunction.BindServiceLevel(this.ddlServiceLevel);
			this.ddlType.DataSource = DALCommon.GetDataList("ContractType", "", "");
			this.ddlType.DataTextField = "_Name";
			this.ddlType.DataValueField = "ID";
			this.ddlType.DataBind();
			this.ddlType.Items.Insert(0, new ListItem("", "-1"));
			if (this.id > 0)
			{
				DataTable dataTable = DALCommon.GetDataList("ks_customer", "_Name,LinkMan,Tel,Adr", " ID=" + this.id).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
					this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
					this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
					this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
					this.hfCusID.Value = this.id.ToString();
				}
			}
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
		dataRow[5] = false;
		dataRow[6] = false;
		dataRow[7] = false;
		dataRow[8] = "";
		dataRow[9] = 0;
		dataRow[10] = 0;
		dataRow[11] = "";
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
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;");
			DropDownList dropDownList = e.Row.FindControl("ddlLevel") as DropDownList;
			TextBox textBox = e.Row.FindControl("tbLevel") as TextBox;
			for (int i = 0; i < this.ddlServiceLevel.Items.Count; i++)
			{
				dropDownList.Items.Add(new ListItem(this.ddlServiceLevel.Items[i].Text, this.ddlServiceLevel.Items[i].Value));
			}
			for (int i = 0; i < dropDownList.Items.Count; i++)
			{
				if (dropDownList.Items[i].Text == textBox.Text)
				{
					dropDownList.Items[i].Selected = true;
					break;
				}
			}
			RadioButton radioButton = e.Row.Cells[2].FindControl("rbxz") as RadioButton;
			if (radioButton != null)
			{
				radioButton.Attributes.Add("onclick", string.Concat(new string[]
				{
					"onClientClick('",
					radioButton.ClientID,
					"','",
					e.Row.Cells[0].Text,
					"')"
				}));
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
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			DropDownList dropDownList = this.gvdata.Rows[i].FindControl("ddlLevel") as DropDownList;
			CheckBox checkBox = this.gvdata.Rows[i].FindControl("cbRepair") as CheckBox;
			CheckBox checkBox2 = this.gvdata.Rows[i].FindControl("cbConsumables") as CheckBox;
			CheckBox checkBox3 = this.gvdata.Rows[i].FindControl("cbMaterial") as CheckBox;
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbDevNO") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Level"] = dropDownList.SelectedItem.Text;
			gridViewSource.Rows[i]["SN"] = FunLibrary.ChkInput(textBox2.Text);
			gridViewSource.Rows[i]["bRepair"] = checkBox.Checked;
			gridViewSource.Rows[i]["bConsumables"] = checkBox2.Checked;
			gridViewSource.Rows[i]["bMaterial"] = checkBox3.Checked;
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox.Text);
			gridViewSource.Rows[i]["LevelID"] = dropDownList.SelectedItem.Value;
			gridViewSource.Rows[i]["DeviceNO"] = textBox3.Text.Trim();
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void btnChkDev_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfDevID.Value.EndsWith(","))
		{
			text = this.hfDevID.Value.Remove(this.hfDevID.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfDevID.Value;
		}
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ks_device", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["ID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[1] = dataTable.Rows[i]["ProductClass"].ToString();
						dataRow[2] = dataTable.Rows[i]["ProductModel"].ToString();
						dataRow[3] = dataTable.Rows[i]["ProductSN1"].ToString();
						dataRow[4] = "";
						dataRow[5] = false;
						dataRow[6] = false;
						dataRow[7] = false;
						dataRow[8] = "";
						dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[10] = 0;
						dataRow[11] = dataTable.Rows[i]["DeviceNO"].ToString();
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.SysInfo("$('" + this.tbCon.ClientID + "').focus();");
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		string text2 = string.Concat(new string[]
		{
			" (ProductSN1='",
			text,
			"' or ProductSN2='",
			text,
			"') "
		});
		if (this.hfCusID.Value != "")
		{
			text2 = text2 + " and CustomerID=" + this.hfCusID.Value;
		}
		DataTable dataTable = DALCommon.GetDataList("ks_device", "", text2).Tables[0];
		string text3 = "$('" + this.tbCon.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < gridViewSource.Rows.Count; j++)
				{
					if (gridViewSource.Rows[j]["ID"].ToString() == dataTable.Rows[i]["ID"].ToString())
					{
						flag = false;
					}
				}
				if (flag)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[1] = dataTable.Rows[i]["ProductClass"].ToString();
					dataRow[2] = dataTable.Rows[i]["ProductModel"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductSN1"].ToString();
					dataRow[4] = "";
					dataRow[5] = false;
					dataRow[6] = false;
					dataRow[7] = false;
					dataRow[8] = "";
					dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[10] = 0;
					dataRow[11] = dataTable.Rows[i]["DeviceNO"].ToString();
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
		else
		{
			text3 += "window.alert('操作失败！没有该序列号的机器档案');";
		}
		this.SysInfo(text3);
	}

	protected void btnCopy_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		DataRow[] array = gridViewSource.Select(" ID= " + this.hfRecID.Value);
		int num = 0;
		int.TryParse(this.tbCount.Text, out num);
		if (num != 0)
		{
			if (array.Length > 0)
			{
				for (int i = 0; i < num; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = array[0]["Brand"].ToString();
					dataRow[1] = array[0]["Class"].ToString();
					dataRow[2] = array[0]["Model"].ToString();
					dataRow[3] = "";
					dataRow[4] = array[0]["Level"].ToString();
					dataRow[5] = bool.Parse(array[0]["bRepair"].ToString());
					dataRow[6] = bool.Parse(array[0]["bConsumables"].ToString());
					dataRow[7] = bool.Parse(array[0]["bMaterial"].ToString());
					dataRow[8] = array[0]["Remark"].ToString();
					dataRow[9] = int.Parse(array[0]["ID"].ToString());
					dataRow[10] = int.Parse(array[0]["LevelID"].ToString());
					dataRow[11] = "";
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加机器明细');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			int num = 0;
			int.TryParse(this.hfCusID.Value, out num);
			string text = "";
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
				num3 = dALCustomerList.Add(customerListInfo, true, out text, out num);
				if (num3 != 0)
				{
					return;
				}
			}
			MaintenanceContractInfo maintenanceContractInfo = new MaintenanceContractInfo();
			maintenanceContractInfo.DeptID = 1;
			maintenanceContractInfo.CustomerID = num;
			maintenanceContractInfo.CustomerName = FunLibrary.ChkInput(this.tbCusName.Text);
			maintenanceContractInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
			maintenanceContractInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
			maintenanceContractInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
			maintenanceContractInfo.ContractTypeID = int.Parse(this.ddlType.SelectedValue);
			maintenanceContractInfo._Date = this.tbDate.Text;
			maintenanceContractInfo.SellerID = int.Parse(this.ddlOperator.SelectedValue);
			maintenanceContractInfo.OperatorID = int.Parse((string)this.Session["Session_wtUserID"]);
			maintenanceContractInfo.ContractNO = FunLibrary.ChkInput(this.tbContract.Text);
			maintenanceContractInfo.StartDate = this.tbStartDate.Text;
			maintenanceContractInfo.EndDate = this.tbEndDate.Text;
			maintenanceContractInfo.Summary = FunLibrary.ChkInput(this.tbSummary.Text);
			decimal dAmount = 0m;
			decimal.TryParse(this.tbAmount.Text, out dAmount);
			maintenanceContractInfo.dAmount = dAmount;
			decimal dInCash = 0m;
			decimal.TryParse(this.tbInCash.Text, out dInCash);
			maintenanceContractInfo.dInCash = dInCash;
			maintenanceContractInfo.Accessory = FunLibrary.ChkInput(this.hfUpload.Value);
			maintenanceContractInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count > 0)
			{
				List<ContractDetailInfo> list = new List<ContractDetailInfo>();
				for (int i = 0; i < gridViewSource.Rows.Count; i++)
				{
					if (int.Parse(gridViewSource.Rows[i]["ID"].ToString()) > 0)
					{
						list.Add(new ContractDetailInfo
						{
							DeviceID = int.Parse(gridViewSource.Rows[i]["ID"].ToString()),
							ProductSN = gridViewSource.Rows[i]["SN"].ToString(),
							ServiceLevelID = int.Parse(gridViewSource.Rows[i]["LevelID"].ToString()),
							bRepair = bool.Parse(gridViewSource.Rows[i]["bRepair"].ToString()),
							bMaterial = bool.Parse(gridViewSource.Rows[i]["bMaterial"].ToString()),
							bConsumables = bool.Parse(gridViewSource.Rows[i]["bConsumables"].ToString()),
							Remark = gridViewSource.Rows[i]["Remark"].ToString(),
							DeviceNO = gridViewSource.Rows[i]["DeviceNO"].ToString()
						});
					}
				}
				maintenanceContractInfo.ContractDetailInfos = list;
			}
			DALMaintenanceContract dALMaintenanceContract = new DALMaintenanceContract();
			int num4;
			num3 = dALMaintenanceContract.Add(maintenanceContractInfo, out num4);
			if (num3 == 0)
			{
				this.SysInfo("window.alert('操作成功！服务合同已保存');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！请查看错误日志');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnCusInfo_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "LinkMan,Tel,Adr", " ID=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				return;
			}
		}
		string text = FunLibrary.ChkInput(this.tbCusName.Text);
		if (text != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "[ID],LinkMan,Tel,Adr", " _Name='" + text + "'").Tables[0];
			if (dataTable.Rows.Count > 1)
			{
				this.SysInfo("ConfCusInfo();");
			}
			else if (dataTable.Rows.Count == 1)
			{
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

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
	}
}
