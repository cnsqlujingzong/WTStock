using System;
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

public partial class Branch_Services_ServicesAddBat : Page, IRequiresSessionState
{
	
	private int cusid;

	private string strtel;

	private int itel;

	

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("DeviceNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Brand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Class", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Model", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN1", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN2", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Warranty", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Aspect", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Fault", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Accessory", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ServiceLevel", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BuyFrom", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BuyDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BuyInvoice", typeof(string)));
				dataTable.Columns.Add(new DataColumn("dPoint", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("bRepair", typeof(bool)));
				dataTable.Columns.Add(new DataColumn("BrandID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ClassID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ModelID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("WarrantyID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ServiceLevelID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("FaultIDs", typeof(string)));
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
		int.TryParse(base.Request["cusid"], out this.cusid);
		int.TryParse(base.Request["itel"], out this.itel);
		this.strtel = base.Request["tel"];
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r6"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(22, 0);
			this.tbTakeTime.Text = (this.tbDate.Text = DateTime.Now.ToString());
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0 and bDestClerk=1 ");
			OtherFunction.BindServicesType(this.ddlType);
			OtherFunction.BindArea(this.ddlArea);
			OtherFunction.BindTakeStyle(this.ddlTake);
			OtherFunction.BindSupplier(this.ddlChargeCorp, " bChargeCorp=1 and bStop=0 ");
			this.ddlChargeCorp.Items.Remove(new ListItem("新建...", "0"));
			OtherFunction.BindSndStyle(this.ddlSndStyle, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			string text = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == text)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			DataTable dataTable = DALCommon.GetDataList("StaffList", "[ID]", " bTechnician=1 and [ID]=" + (string)this.Session["Session_wtUserBID"]).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbDisposal.Text = text;
			}
			if (this.cusid > 0)
			{
				DataTable dataTable2 = DALCommon.GetDataList("ks_customer", "", " [ID]=" + this.cusid.ToString()).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					this.tbCusName.Text = dataTable2.Rows[0]["_Name"].ToString();
					this.tbLinkMan.Text = dataTable2.Rows[0]["LinkMan"].ToString();
					this.tbTel.Text = dataTable2.Rows[0]["Tel"].ToString();
					this.tbArea.Text = dataTable2.Rows[0]["Area"].ToString();
					this.tbAdr.Text = dataTable2.Rows[0]["Adr"].ToString();
					this.hfCusID.Value = dataTable2.Rows[0]["ID"].ToString();
					this.ddlDept.DataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
					this.ddlDept.DataTextField = "_Name";
					this.ddlDept.DataValueField = "ID";
					this.ddlDept.DataBind();
					this.ddlDept.Items.Insert(0, new ListItem("", ""));
					DataTable dataSource = DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
					this.ddlLinkMan.DataSource = dataSource;
					this.ddlLinkMan.DataTextField = "_Name";
					this.ddlLinkMan.DataValueField = "ID";
					this.ddlLinkMan.DataBind();
					this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
					this.ddlUsePerson.DataSource = dataSource;
					this.ddlUsePerson.DataTextField = "_Name";
					this.ddlUsePerson.DataValueField = "ID";
					this.ddlUsePerson.DataBind();
					this.ddlUsePerson.Items.Insert(0, new ListItem("", ""));
				}
			}
			else if (this.strtel != null && this.strtel != "")
			{
				DataTable dataTable2 = DALCommon.GetDataList("ks_customer", "", string.Concat(new string[]
				{
					" (Tel='",
					this.strtel,
					"' or Tel2='",
					this.strtel,
					"') "
				})).Tables[0];
				this.tbTel.Text = this.strtel;
				if (dataTable2.Rows.Count == 1)
				{
					this.tbCusName.Text = dataTable2.Rows[0]["_Name"].ToString();
					this.tbLinkMan.Text = dataTable2.Rows[0]["LinkMan"].ToString();
					this.tbArea.Text = dataTable2.Rows[0]["Area"].ToString();
					this.tbAdr.Text = dataTable2.Rows[0]["Adr"].ToString();
					this.hfCusID.Value = dataTable2.Rows[0]["ID"].ToString();
					this.ddlDept.DataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
					this.ddlDept.DataTextField = "_Name";
					this.ddlDept.DataValueField = "ID";
					this.ddlDept.DataBind();
					this.ddlDept.Items.Insert(0, new ListItem("", ""));
					DataTable dataSource = DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
					this.ddlLinkMan.DataSource = dataSource;
					this.ddlLinkMan.DataTextField = "_Name";
					this.ddlLinkMan.DataValueField = "ID";
					this.ddlLinkMan.DataBind();
					this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
					this.ddlUsePerson.DataSource = dataSource;
					this.ddlUsePerson.DataTextField = "_Name";
					this.ddlUsePerson.DataValueField = "ID";
					this.ddlUsePerson.DataBind();
					this.ddlUsePerson.Items.Insert(0, new ListItem("", ""));
				}
				else
				{
					this.hfCusID.Value = "";
				}
			}
			this.AddEmpty();
			this.tbCount.Text = "0";
		}
	}

	protected void btnValiCus_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbCusName.Text);
		if (text == "")
		{
			this.hfCusID.Value = "";
		}
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "", " ID=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.ddlDept.DataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
				this.ddlDept.DataTextField = "_Name";
				this.ddlDept.DataValueField = "ID";
				this.ddlDept.DataBind();
				this.ddlDept.Items.Insert(0, new ListItem("", ""));
				DataTable dataSource = DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
				this.ddlLinkMan.DataSource = dataSource;
				this.ddlLinkMan.DataTextField = "_Name";
				this.ddlLinkMan.DataValueField = "ID";
				this.ddlLinkMan.DataBind();
				this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
				this.ddlUsePerson.DataSource = dataSource;
				this.ddlUsePerson.DataTextField = "_Name";
				this.ddlUsePerson.DataValueField = "ID";
				this.ddlUsePerson.DataBind();
				this.ddlUsePerson.Items.Insert(0, new ListItem("", ""));
				return;
			}
		}
		if (text != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "", " _Name='" + text + "'").Tables[0];
			if (dataTable.Rows.Count > 1)
			{
				this.SysInfo("ConfCusInfo();");
			}
			else if (dataTable.Rows.Count == 1)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
				this.ddlDept.DataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
				this.ddlDept.DataTextField = "_Name";
				this.ddlDept.DataValueField = "ID";
				this.ddlDept.DataBind();
				this.ddlDept.Items.Insert(0, new ListItem("", ""));
				DataTable dataSource = DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
				this.ddlLinkMan.DataSource = dataSource;
				this.ddlLinkMan.DataTextField = "_Name";
				this.ddlLinkMan.DataValueField = "ID";
				this.ddlLinkMan.DataBind();
				this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
				this.ddlUsePerson.DataSource = dataSource;
				this.ddlUsePerson.DataTextField = "_Name";
				this.ddlUsePerson.DataValueField = "ID";
				this.ddlUsePerson.DataBind();
				this.ddlUsePerson.Items.Insert(0, new ListItem("", ""));
			}
			else
			{
				this.hfCusID.Value = "";
			}
		}
	}

	protected void ddlLinkMan_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetList("CustomerLinkMan", "[ID],LinkManDept,tel_Office,tel_Mobile,Fax,Adr", string.Concat(new string[]
			{
				" CustomerID=",
				this.hfCusID.Value,
				" and _Name='",
				FunLibrary.ChkInput(this.tbLinkMan.Text),
				"'"
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbTel.Text = dataTable.Rows[0]["tel_Office"].ToString();
			}
		}
	}

	protected void ddlUsePerson_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetList("CustomerLinkMan", "[ID],LinkManDept,tel_Office,tel_Mobile,Fax,Adr", string.Concat(new string[]
			{
				" CustomerID=",
				this.hfCusID.Value,
				" and _Name='",
				FunLibrary.ChkInput(this.tbUsePerson.Text),
				"'"
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbUsePersonTel.Text = dataTable.Rows[0]["tel_Office"].ToString();
				this.tbDept.Text = dataTable.Rows[0]["LinkManDept"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
			}
		}
	}

	protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetList("CustomerDept", "[ID],_Name,LinkMan,Tel", string.Concat(new string[]
			{
				" CustomerID=",
				this.hfCusID.Value,
				" and _Name='",
				FunLibrary.ChkInput(this.tbDept.Text),
				"'"
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				if (FunLibrary.ChkInput(this.tbUsePerson.Text) == "")
				{
					this.tbUsePerson.Text = dataTable.Rows[0]["LinkMan"].ToString();
				}
				if (FunLibrary.ChkInput(this.tbUsePersonTel.Text) == "")
				{
					this.tbUsePersonTel.Text = dataTable.Rows[0]["Tel"].ToString();
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
		dataRow[6] = "";
		dataRow[7] = "";
		dataRow[8] = "";
		dataRow[9] = "";
		dataRow[10] = "";
		dataRow[11] = "";
		dataRow[12] = "";
		dataRow[13] = "";
		dataRow[14] = 0;
		dataRow[15] = 0;
		dataRow[16] = 0;
		dataRow[17] = 0;
		dataRow[18] = 0;
		dataRow[19] = 0;
		dataRow[20] = 0;
		int num = 0;
		int.TryParse(this.hfCount.Value, out num);
		dataRow[21] = num;
		dataRow[22] = "";
		this.hfCount.Value = "0";
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
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
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('d" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModD();");
		}
	}

	protected void btnAddD_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		string[] array = this.hfDevice.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (array[4].ToString() != "")
			{
				if (gridViewSource.Rows[i]["SN1"].ToString() == array[4].ToString())
				{
					this.SysInfo2("window.alert(\"操作失败！报修序列号已存在\");ChkID('" + gridViewSource.Rows[i]["ID"].ToString() + "');");
					return;
				}
			}
		}
		dataRow[0] = array[0].ToString();
		dataRow[1] = array[1].ToString();
		dataRow[2] = array[2].ToString();
		dataRow[3] = array[3].ToString();
		dataRow[4] = array[4].ToString();
		dataRow[5] = array[5].ToString();
		dataRow[6] = array[6].ToString();
		dataRow[7] = array[7].ToString();
		dataRow[8] = array[8].ToString().Replace("^", ",");
		dataRow[9] = array[9].ToString();
		dataRow[10] = array[10].ToString();
		dataRow[11] = array[11].ToString();
		dataRow[12] = array[12].ToString();
		dataRow[13] = array[13].ToString();
		dataRow[14] = array[14].ToString();
		dataRow[15] = array[15].ToString();
		dataRow[16] = array[16].ToString();
		dataRow[17] = array[17].ToString();
		dataRow[18] = array[18].ToString();
		dataRow[19] = array[19].ToString();
		dataRow[20] = array[20].ToString();
		int num;
		int.TryParse(this.hfCount.Value, out num);
		dataRow[21] = num + 1;
		dataRow[22] = array[21].ToString().Replace("^", ",");
		this.hfCount.Value = dataRow[21].ToString();
		gridViewSource.Rows.Add(dataRow);
		this.BindData();
	}

	protected void btnModD_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		string[] array = this.hfDevice.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["ID"].ToString() != this.hfRecID.Value.Replace("d", ""))
			{
				if (array[4].ToString() != "")
				{
					if (gridViewSource.Rows[i]["SN1"].ToString() == array[4].ToString())
					{
						this.SysInfo2("window.alert(\"操作失败！报修序列号已存在\");ChkID('" + gridViewSource.Rows[i]["ID"].ToString() + "');");
						return;
					}
				}
			}
		}
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["ID"].ToString() == this.hfRecID.Value.Replace("d", ""))
			{
				gridViewSource.Rows[i][0] = array[0].ToString();
				gridViewSource.Rows[i][1] = array[1].ToString();
				gridViewSource.Rows[i][2] = array[2].ToString();
				gridViewSource.Rows[i][3] = array[3].ToString();
				gridViewSource.Rows[i][4] = array[4].ToString();
				gridViewSource.Rows[i][5] = array[5].ToString();
				gridViewSource.Rows[i][6] = array[6].ToString();
				gridViewSource.Rows[i][7] = array[7].ToString();
				gridViewSource.Rows[i][8] = array[8].ToString().Replace("^", ",");
				gridViewSource.Rows[i][9] = array[9].ToString();
				gridViewSource.Rows[i][10] = array[10].ToString();
				gridViewSource.Rows[i][11] = array[11].ToString();
				gridViewSource.Rows[i][12] = array[12].ToString();
				gridViewSource.Rows[i][13] = array[13].ToString();
				gridViewSource.Rows[i][14] = array[14].ToString();
				gridViewSource.Rows[i][15] = array[15].ToString();
				gridViewSource.Rows[i][16] = array[16].ToString();
				gridViewSource.Rows[i][17] = array[17].ToString();
				gridViewSource.Rows[i][18] = array[18].ToString();
				gridViewSource.Rows[i][19] = array[19].ToString();
				gridViewSource.Rows[i][20] = array[20].ToString();
				gridViewSource.Rows[i][22] = array[21].ToString().Replace("^", ",");
			}
		}
		this.BindData();
		this.SysInfo2("ChkID('" + this.hfRecID.Value + "');");
	}

	protected void btnDelD_Click(object sender, EventArgs e)
	{
		if (!(this.hfRecID.Value == "-1"))
		{
			DataTable gridViewSource = this.GridViewSource;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (gridViewSource.Rows[i]["ID"].ToString() == this.hfRecID.Value.Replace("d", ""))
				{
					gridViewSource.Rows.RemoveAt(i);
				}
			}
			this.BindData();
			this.hfRecID.Value = "-1";
		}
	}

	protected void btnShowD_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow[] array = gridViewSource.Select(" ID= " + this.hfRecID.Value.Replace("d", ""));
		if (array.Length > 0)
		{
			this.hfDevice.Value = array[0]["DeviceNO"].ToString() + ",";
			HiddenField expr_72 = this.hfDevice;
			expr_72.Value = expr_72.Value + array[0]["Brand"].ToString() + ",";
			HiddenField expr_A0 = this.hfDevice;
			expr_A0.Value = expr_A0.Value + array[0]["Class"].ToString() + ",";
			HiddenField expr_CE = this.hfDevice;
			expr_CE.Value = expr_CE.Value + array[0]["Model"].ToString() + ",";
			HiddenField expr_FC = this.hfDevice;
			expr_FC.Value = expr_FC.Value + array[0]["SN1"].ToString() + ",";
			HiddenField expr_12A = this.hfDevice;
			expr_12A.Value = expr_12A.Value + array[0]["SN2"].ToString() + ",";
			HiddenField expr_158 = this.hfDevice;
			expr_158.Value = expr_158.Value + array[0]["Warranty"].ToString() + ",";
			HiddenField expr_186 = this.hfDevice;
			expr_186.Value = expr_186.Value + array[0]["Aspect"].ToString() + ",";
			HiddenField expr_1B4 = this.hfDevice;
			expr_1B4.Value = expr_1B4.Value + array[0]["Fault"].ToString().Replace(",", "^") + ",";
			HiddenField expr_1F1 = this.hfDevice;
			expr_1F1.Value = expr_1F1.Value + array[0]["Accessory"].ToString() + ",";
			HiddenField expr_21F = this.hfDevice;
			expr_21F.Value = expr_21F.Value + array[0]["ServiceLevel"].ToString() + ",";
			HiddenField expr_24D = this.hfDevice;
			expr_24D.Value = expr_24D.Value + array[0]["BuyFrom"].ToString() + ",";
			HiddenField expr_27B = this.hfDevice;
			expr_27B.Value = expr_27B.Value + array[0]["BuyDate"].ToString() + ",";
			HiddenField expr_2A9 = this.hfDevice;
			expr_2A9.Value = expr_2A9.Value + array[0]["BuyInvoice"].ToString() + ",";
			HiddenField expr_2D7 = this.hfDevice;
			expr_2D7.Value = expr_2D7.Value + array[0]["dPoint"].ToString() + ",";
			HiddenField expr_305 = this.hfDevice;
			expr_305.Value = expr_305.Value + array[0]["bRepair"].ToString() + ",";
			HiddenField expr_333 = this.hfDevice;
			expr_333.Value = expr_333.Value + array[0]["BrandID"].ToString() + ",";
			HiddenField expr_361 = this.hfDevice;
			expr_361.Value = expr_361.Value + array[0]["ClassID"].ToString() + ",";
			HiddenField expr_38F = this.hfDevice;
			expr_38F.Value = expr_38F.Value + array[0]["ModelID"].ToString() + ",";
			HiddenField expr_3BD = this.hfDevice;
			expr_3BD.Value = expr_3BD.Value + array[0]["WarrantyID"].ToString() + ",";
			HiddenField expr_3EB = this.hfDevice;
			expr_3EB.Value = expr_3EB.Value + array[0]["ServiceLevelID"].ToString() + ",";
			HiddenField expr_419 = this.hfDevice;
			expr_419.Value += array[0]["FaultIDs"].ToString().Replace(",", "^");
		}
		this.BindData();
		this.SysInfo2("ChkID('" + this.hfRecID.Value + "');");
	}

	protected void btnCopy_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow[] array = gridViewSource.Select(" ID= " + this.hfRecID.Value.Replace("d", ""));
		int num = 0;
		int.TryParse(this.tbCount.Text, out num);
		if (num != 0)
		{
			if (array.Length > 0)
			{
				for (int i = 0; i < num; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = "";
					dataRow[1] = array[0]["Brand"].ToString();
					dataRow[2] = array[0]["Class"].ToString();
					dataRow[3] = array[0]["Model"].ToString();
					dataRow[4] = "";
					dataRow[5] = array[0]["SN2"].ToString();
					dataRow[6] = array[0]["Warranty"].ToString();
					dataRow[7] = array[0]["Aspect"].ToString();
					dataRow[8] = array[0]["Fault"].ToString();
					dataRow[9] = array[0]["Accessory"].ToString();
					dataRow[10] = array[0]["ServiceLevel"].ToString();
					dataRow[11] = array[0]["BuyFrom"].ToString();
					dataRow[12] = array[0]["BuyDate"].ToString();
					dataRow[13] = array[0]["BuyInvoice"].ToString();
					dataRow[14] = array[0]["dPoint"].ToString();
					dataRow[15] = array[0]["bRepair"].ToString();
					dataRow[16] = array[0]["BrandID"].ToString();
					dataRow[17] = array[0]["ClassID"].ToString();
					dataRow[18] = array[0]["ModelID"].ToString();
					dataRow[19] = array[0]["WarrantyID"].ToString();
					dataRow[20] = array[0]["ServiceLevelID"].ToString();
					int num2;
					int.TryParse(this.hfCount.Value, out num2);
					dataRow[21] = num2 + 1;
					dataRow[22] = array[0]["FaultIDs"].ToString();
					this.hfCount.Value = dataRow[21].ToString();
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
	}

	protected void SysInfo2(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", str, true);
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num = 0;
		int num2 = 0;
		int.TryParse(this.hfCusID.Value, out num);
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！请添加机器信息');");
		}
		else
		{
			int num3 = 0;
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
					num3 = 1;
				}
			}
			if (num == 0 || num3 == 1)
			{
				CustomerListInfo customerListInfo = new CustomerListInfo();
				customerListInfo.DeptID = new int?(int.Parse((string)this.Session["Session_wtBranchID"]));
				customerListInfo._Name = FunLibrary.ChkInput(this.tbCusName.Text);
				customerListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbCusName.Text));
				customerListInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
				customerListInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
				customerListInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
				customerListInfo.SellerID = new int?(int.Parse(this.ddlOperator.SelectedValue));
				customerListInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
				customerListInfo.OperatorID = int.Parse((string)this.Session["Session_wtUserBID"]);
				DALCustomerList dALCustomerList = new DALCustomerList();
				string str;
				num2 = dALCustomerList.Add(customerListInfo, true, out str, out num);
				if (num2 == -1)
				{
					this.SysInfo("window.alert('" + str + "');");
					return;
				}
				if (num2 > 0)
				{
					this.SysInfo("window.alert('系统错误！请查看错误日志');");
					return;
				}
				this.hfCusID.Value = num.ToString();
			}
			for (int i = 1; i < gridViewSource.Rows.Count; i++)
			{
				string text = gridViewSource.Rows[i]["SN1"].ToString();
				string text2 = gridViewSource.Rows[i]["DeviceNO"].ToString();
				if (text != "")
				{
					DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[ID]", string.Concat(new object[]
					{
						" CustomerID=",
						num,
						" and ProductSN1='",
						text,
						"' and (curStatus='待处理' or curStatus='处理中')"
					})).Tables[0];
					if (dataTable2.Rows.Count > 0)
					{
						this.SysInfo("window.alert('操作失败！该客户的机器【" + text + "】正在维修中...');");
						return;
					}
				}
				else if (text2 != "")
				{
					DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[ID]", string.Concat(new object[]
					{
						" CustomerID=",
						num,
						" and DeviceNO='",
						text2,
						"' and (curStatus='待处理' or curStatus='处理中')"
					})).Tables[0];
					if (dataTable2.Rows.Count > 0)
					{
						this.SysInfo("window.alert('操作失败！该客户的机器【" + text2 + "】正在维修中...');");
						return;
					}
				}
			}
			decimal num4 = 0m;
			DALServices dALServices = new DALServices();
			ServicesInfo servicesInfo = new ServicesInfo();
			servicesInfo.TakeOverID = int.Parse((string)this.Session["Session_wtBranchID"]);
			servicesInfo.DisposalID = int.Parse((string)this.Session["Session_wtBranchID"]);
			servicesInfo.curStatus = "待处理";
			servicesInfo.TypeID = int.Parse(this.ddlType.SelectedValue);
			servicesInfo.TakeStyleID = int.Parse(this.ddlTake.SelectedValue);
			servicesInfo.Time_Make = FunLibrary.ChkInput(this.tbDate.Text);
			servicesInfo.Time_TakeOver = FunLibrary.ChkInput(this.tbTakeTime.Text);
			servicesInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
			servicesInfo.PersonID = int.Parse((string)this.Session["Session_wtUserBID"]);
			servicesInfo.DisposalOper = FunLibrary.ChkInput(this.tbDisposal.Text);
			servicesInfo.CustomerID = num;
			servicesInfo.CustomerName = FunLibrary.ChkInput(this.tbCusName.Text);
			servicesInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
			servicesInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
			servicesInfo.UsePerson = FunLibrary.ChkInput(this.tbUsePerson.Text);
			servicesInfo.UsePersonDept = FunLibrary.ChkInput(this.tbDept.Text);
			servicesInfo.UsePersonTel = FunLibrary.ChkInput(this.tbUsePersonTel.Text);
			servicesInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
			servicesInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
			servicesInfo.SaveID = FunLibrary.ChkInput(this.tbSaveID.Text);
			servicesInfo.SupplierID = FunLibrary.ChkInput(this.tbCorpID.Text);
			servicesInfo.WarrantyChargeCorpID = int.Parse(this.ddlChargeCorp.SelectedValue);
			servicesInfo.SubscribeTime = FunLibrary.ChkInput(this.tbSubTime.Text);
			servicesInfo.SubscribeConnectTime = FunLibrary.ChkInput(this.tbSubContTime.Text);
			decimal.TryParse(this.tbSubPrice.Text, out num4);
			servicesInfo.SubscribePrice = num4;
			decimal.TryParse(this.tbSubCharge.Text, out num4);
			servicesInfo.PreCharge = num4;
			decimal.TryParse(this.tbPostage.Text, out num4);
			servicesInfo.Postage = num4;
			servicesInfo.PostNO = FunLibrary.ChkInput(this.tbPostNO.Text);
			servicesInfo.SndStyleID = int.Parse(this.ddlSndStyle.SelectedValue);
			servicesInfo.ContractNO = FunLibrary.ChkInput(this.tbContNO.Text);
			servicesInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			servicesInfo.Path = FunLibrary.ChkInput(this.hfPath.Value);
			string str2 = DALCommon.CreateID(22, 1);
			for (int i = 1; i < gridViewSource.Rows.Count; i++)
			{
				servicesInfo.BillID = str2 + "-000".Substring(0, 4 - i.ToString().Length) + i.ToString();
				servicesInfo.DeviceNO = gridViewSource.Rows[i]["DeviceNO"].ToString();
				servicesInfo.ProductBrandID = int.Parse(gridViewSource.Rows[i]["BrandID"].ToString());
				servicesInfo.ProductClassID = int.Parse(gridViewSource.Rows[i]["ClassID"].ToString());
				servicesInfo.ProductModelID = int.Parse(gridViewSource.Rows[i]["ModelID"].ToString());
				servicesInfo.ProductSN1 = FunLibrary.ChkInput(gridViewSource.Rows[i]["SN1"].ToString());
				servicesInfo.ProductSN2 = FunLibrary.ChkInput(gridViewSource.Rows[i]["SN2"].ToString());
				servicesInfo.BuyDate = FunLibrary.ChkInput(gridViewSource.Rows[i]["BuyDate"].ToString());
				servicesInfo.BuyFrom = FunLibrary.ChkInput(gridViewSource.Rows[i]["BuyFrom"].ToString());
				servicesInfo.Aspect = FunLibrary.ChkInput(gridViewSource.Rows[i]["Aspect"].ToString());
				servicesInfo.Accessory = FunLibrary.ChkInput(gridViewSource.Rows[i]["Accessory"].ToString());
				servicesInfo.Fault = FunLibrary.ChkInput(gridViewSource.Rows[i]["Fault"].ToString());
				servicesInfo.WarrantyID = int.Parse(gridViewSource.Rows[i]["WarrantyID"].ToString());
				servicesInfo.BuyInvoice = FunLibrary.ChkInput(gridViewSource.Rows[i]["BuyInvoice"].ToString());
				decimal.TryParse(gridViewSource.Rows[i]["dPoint"].ToString(), out num4);
				servicesInfo.dPoint = num4;
				servicesInfo.bAgain = bool.Parse(gridViewSource.Rows[i]["bRepair"].ToString());
				servicesInfo.ServiceLevelID = int.Parse(gridViewSource.Rows[i]["ServiceLevelID"].ToString());
				string faults = gridViewSource.Rows[i]["FaultIDs"].ToString();
				int num5;
				num2 = dALServices.AddBat(servicesInfo, faults, out num5);
				this.hfPrintID.Value = servicesInfo.BillID;
			}
			if (num2 == 0)
			{
				string text3 = "window.alert('操作成功！服务单已保存');";
				if (this.itel == 0)
				{
					text3 += "parent.RefrhClr();";
				}
				this.SysInfo(text3);
				this.ClearCusText();
				this.tbBillID.Text = DALCommon.CreateID(22, 0);
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');");
			}
		}
	}

	protected void ClearCusText()
	{
		this.tbCusName.Text = string.Empty;
		this.hfCusID.Value = string.Empty;
		this.tbLinkMan.Text = string.Empty;
		this.tbTel.Text = string.Empty;
		this.tbAdr.Text = string.Empty;
		this.tbArea.Text = string.Empty;
		this.tbUsePerson.Text = (this.tbUsePersonTel.Text = (this.tbDept.Text = string.Empty));
		this.hfPath.Value = "";
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.BindData();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.ClearCusText();
	}

	protected void btnRef_Click(object sender, EventArgs e)
	{
		OtherFunction.BindArea(this.ddlArea);
		if (this.hfArea.Value != string.Empty)
		{
			this.ddlArea.ClearSelection();
			this.ddlArea.Items.FindByText(this.hfArea.Value).Selected = true;
			this.tbArea.Text = this.ddlArea.SelectedItem.Text;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
