using System;
using System.Collections;
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

public partial class Headquarters_Services_ServicesAdd : Page, IRequiresSessionState
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
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Parameter", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MaintenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BuyDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MaintenanceEnd", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("DevConfID", typeof(int)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	public string Str_Tel
	{
		get
		{
			return this.strtel;
		}
	}

	public string Str_CusID
	{
		get
		{
			return this.cusid.ToString();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		bool flag = false;
		if (base.Request.QueryString["itel"] != null)
		{
			flag = true;
		}
		FunLibrary.ChkHead(flag);
		int.TryParse(base.Request["cusid"], out this.cusid);
		int.TryParse(base.Request["itel"], out this.itel);
		this.strtel = base.Request["tel"];
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			DALRight dALRight = new DALRight();
			if (num > 0)
			{
				if (!dALRight.GetRight(num, "gd_r6"))
				{
					this.btnAdd.Enabled = false;
				}
				if (dALRight.GetRight(num, "gd_r35"))
				{
					this.tbTakeTime.Enabled = false;
				}
				if (!dALRight.GetRight(num, "kh_r3"))
				{
					this.hfAddCus.Value = "1";
				}
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.bFaultNoInput)
			{
				this.tbFault.Attributes["onfocus"] = "blur();";
			}
			this.tbBillID.Text = DALCommon.CreateID(22, 0);
			this.tbTakeTime.Text = (this.tbDate.Text = string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now));
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0 and bDestClerk=1 ");
            ddlOperator.SelectedValue = Session["Session_wtUserID"].ToString();
			OtherFunction.BindProductAspect(this.ddlAspect);
			OtherFunction.BindServicesType(this.ddlType);
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindProductModel(this.ddlModel, "");
			OtherFunction.BindWarranty(this.ddlRepStatus);
			OtherFunction.BindArea(this.ddlArea);
			OtherFunction.BindTakeStyle(this.ddlTake);
			OtherFunction.BindSupplier(this.ddlChargeCorp, " bChargeCorp=1 and bStop=0 ");
			this.ddlChargeCorp.Items.Remove(new ListItem("新建...", "0"));
			OtherFunction.BindSndStyle(this.ddlSndStyle, " DeptID=1 ");
			OtherFunction.BindServiceLevel(this.ddlPRI);
			if (flag)
			{
				this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
				this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
				this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
				this.ddlRepStatus.Items.Remove(new ListItem("新建...", "0"));
			}
			if (num > 0)
			{
				if (!dALRight.GetRight(num, "jc_r9"))
				{
					this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
				}
				if (!dALRight.GetRight(num, "jc_r10"))
				{
					this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
				}
				if (!dALRight.GetRight(num, "jc_r11"))
				{
					this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
				}
				if (!dALRight.GetRight(num, "jc_r13"))
				{
					this.ddlRepStatus.Items.Remove(new ListItem("新建...", "0"));
				}
			}
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.AddEmpty();
			if (this.cusid > 0)
			{
				DataTable dataTable = DALCommon.GetDataList("ks_customer", "", " [ID]=" + this.cusid.ToString()).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
					this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
					this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
					this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
					this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
					this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
					this.tbCusLevel.Text = dataTable.Rows[0]["Member"].ToString();
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
				DataTable dataTable = DALCommon.GetDataList("ks_customer", "", string.Concat(new string[]
				{
					" (Tel='",
					this.strtel,
					"' or Tel2='",
					this.strtel,
					"') "
				})).Tables[0];
				this.tbTel.Text = this.strtel;
				if (dataTable.Rows.Count == 1)
				{
					this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
					this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
					this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
					this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
					this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
					this.tbCusLevel.Text = dataTable.Rows[0]["Member"].ToString();
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
				this.tbCusLevel.Text = dataTable.Rows[0]["Member"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString() + "," + dataTable.Rows[0]["Tel2"].ToString();
				this.tbTel.Text = this.tbTel.Text.Trim(new char[]
				{
					','
				});
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
				this.tbCusLevel.Text = dataTable.Rows[0]["Member"].ToString();
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

	protected void VerifyWarrant(DataTable dt)
	{
		string text = dt.Rows[0]["WarrantyEnd"].ToString().Trim();
		string text2 = dt.Rows[0]["ContractWarrantyEnd"].ToString().Trim();
		string text3 = dt.Rows[0]["RepairWarrantyEnd"].ToString().Trim();
		if (!text3.Equals(""))
		{
			if (DateTime.Parse(text3).AddDays(1.0) > DateTime.Today)
			{
				if (this.ddlRepStatus.Items.FindByText("维修保修期") != null)
				{
					this.ddlRepStatus.ClearSelection();
					this.ddlRepStatus.Items.FindByText("维修保修期").Selected = true;
				}
			}
		}
		if (!text2.Equals(""))
		{
			if (DateTime.Parse(text2).AddDays(1.0) > DateTime.Today)
			{
				if (this.ddlRepStatus.Items.FindByText("合同保修期") != null)
				{
					this.ddlRepStatus.ClearSelection();
					this.ddlRepStatus.Items.FindByText("合同保修期").Selected = true;
				}
			}
		}
		if (!text.Equals(""))
		{
			if (DateTime.Parse(text).AddDays(1.0) > DateTime.Today)
			{
				if (this.ddlRepStatus.Items.FindByText("厂家保修期") != null)
				{
					this.ddlRepStatus.ClearSelection();
					this.ddlRepStatus.Items.FindByText("厂家保修期").Selected = true;
				}
			}
		}
	}

	protected void btnChkSN_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbSN1.Text);
		if (text != "")
		{
			string strCondition = " ProductSN1='" + text + "' ";
			DataTable dataTable = DALCommon.GetDataList("ks_device", "", strCondition).Tables[0];
			if (dataTable.Rows.Count > 1)
			{
				this.SysInfo2("ConfInfo();");
			}
			else
			{
				DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[ID]", " ProductSN1='" + text + "' ").Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					this.lbRepCount.Text = "维修次数：" + dataTable2.Rows.Count;
				}
				if (dataTable.Rows.Count == 1)
				{
					OtherFunction.BindProductBrand(this.ddlBrand);
					OtherFunction.BindProductClass(this.ddlClass);
					OtherFunction.BindProductModel(this.ddlModel, "");
					this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
					this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
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
					this.btnValiCus_Click(sender, e);
					this.tbUsePerson.Text = dataTable.Rows[0]["LinkMan"].ToString();
					this.tbDept.Text = dataTable.Rows[0]["CusDept"].ToString();
					string text2 = dataTable.Rows[0]["Tel"].ToString();
					string text3 = dataTable.Rows[0]["Tel2"].ToString();
					if (text2.Contains(text3))
					{
						this.tbUsePersonTel.Text = text2;
					}
					else
					{
						this.tbUsePersonTel.Text = text2 + "," + text3;
					}
					this.tbUsePersonTel.Text = this.tbUsePersonTel.Text.Trim(new char[]
					{
						','
					});
					if (dataTable.Rows[0]["Adr"].ToString() != "")
					{
						this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
					}
					this.ddlBrand.ClearSelection();
					for (int i = 0; i < this.ddlBrand.Items.Count; i++)
					{
						if (this.ddlBrand.Items[i].Text == dataTable.Rows[0]["ProductBrand"].ToString())
						{
							this.ddlBrand.Items[i].Selected = true;
							break;
						}
					}
					this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
					this.ddlClass.ClearSelection();
					for (int i = 0; i < this.ddlClass.Items.Count; i++)
					{
						if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["ProductClass"].ToString())
						{
							this.ddlClass.Items[i].Selected = true;
							break;
						}
					}
					this.tbClass.Text = dataTable.Rows[0]["ProductClass"].ToString();
					this.ddlModel.ClearSelection();
					for (int i = 0; i < this.ddlModel.Items.Count; i++)
					{
						if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["ProductModel"].ToString())
						{
							this.ddlModel.Items[i].Selected = true;
							break;
						}
					}
					this.tbModel.Text = dataTable.Rows[0]["ProductModel"].ToString();
					this.tbAspect.Text = dataTable.Rows[0]["ProductAspect"].ToString();
					this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
					this.ddlRepStatus.ClearSelection();
					this.ddlRepStatus.Items.FindByText(dataTable.Rows[0]["Warranty"].ToString()).Selected = true;
					this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
					this.tbBuyTime.Text = dataTable.Rows[0]["BuyDate"].ToString();
					this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
					this.hfDevID.Value = dataTable.Rows[0]["ID"].ToString();
					this.tbDeviceNO.Text = dataTable.Rows[0]["DeviceNO"].ToString();
					if (!dataTable.Rows[0]["Technicians"].ToString().Trim().Equals(""))
					{
						this.tbDisposal.Text = dataTable.Rows[0]["Technicians"].ToString();
					}
					DataTable dataTable3 = DALCommon.GetDataList("DeviceConfig", "", " DeviceID=" + dataTable.Rows[0]["ID"].ToString()).Tables[0];
					if (dataTable3.Rows.Count > 0)
					{
						DataTable gridViewSource = this.GridViewSource;
						for (int i = 0; i < dataTable3.Rows.Count; i++)
						{
							DataRow dataRow = gridViewSource.NewRow();
							dataRow[0] = dataTable3.Rows[i]["_Name"].ToString();
							dataRow[1] = dataTable3.Rows[i]["Parameter"].ToString();
							dataRow[2] = dataTable3.Rows[i]["SN"].ToString();
							dataRow[3] = dataTable3.Rows[i]["MaintenancePeriod"].ToString();
							dataRow[4] = dataTable3.Rows[i]["BuyDate"].ToString();
							dataRow[5] = dataTable3.Rows[i]["MaintenanceEnd"].ToString();
							dataRow[6] = dataTable3.Rows[i]["Remark"].ToString();
							dataRow[7] = gridViewSource.Rows.Count;
							int num = 0;
							int.TryParse(dataTable3.Rows[i]["ID"].ToString(), out num);
							dataRow[8] = num;
							gridViewSource.Rows.Add(dataRow);
						}
						this.BindData();
					}
				}
				else
				{
					this.hfDevID.Value = "";
				}
			}
		}
	}

	protected void btnChkNO_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbDeviceNO.Text);
		if (text != "")
		{
			string strCondition = " DeviceNO='" + text + "' ";
			DataTable dataTable = DALCommon.GetDataList("ks_device", "", strCondition).Tables[0];
			DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[ID]", " DeviceNO='" + text + "' ").Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				this.lbRepCount.Text = "维修次数：" + dataTable2.Rows.Count;
			}
			if (dataTable.Rows.Count == 1)
			{
				OtherFunction.BindProductBrand(this.ddlBrand);
				OtherFunction.BindProductClass(this.ddlClass);
				OtherFunction.BindProductModel(this.ddlModel, "");
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
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
				this.btnValiCus_Click(sender, e);
				this.tbUsePerson.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbDept.Text = dataTable.Rows[0]["CusDept"].ToString();
				this.tbUsePersonTel.Text = dataTable.Rows[0]["Tel"].ToString() + "," + dataTable.Rows[0]["Tel2"].ToString();
				this.tbUsePersonTel.Text = this.tbUsePersonTel.Text.Trim(new char[]
				{
					','
				});
				if (dataTable.Rows[0]["Adr"].ToString() != "")
				{
					this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				}
				this.ddlBrand.ClearSelection();
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Text == dataTable.Rows[0]["ProductBrand"].ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						break;
					}
				}
				this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
				this.ddlClass.ClearSelection();
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["ProductClass"].ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbClass.Text = dataTable.Rows[0]["ProductClass"].ToString();
				this.ddlModel.ClearSelection();
				for (int i = 0; i < this.ddlModel.Items.Count; i++)
				{
					if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["ProductModel"].ToString())
					{
						this.ddlModel.Items[i].Selected = true;
						break;
					}
				}
				this.tbModel.Text = dataTable.Rows[0]["ProductModel"].ToString();
				this.tbAspect.Text = dataTable.Rows[0]["ProductAspect"].ToString();
				this.tbSN1.Text = dataTable.Rows[0]["ProductSN1"].ToString();
				this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
				this.ddlRepStatus.ClearSelection();
				this.ddlRepStatus.Items.FindByText(dataTable.Rows[0]["Warranty"].ToString()).Selected = true;
				this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
				this.tbBuyTime.Text = dataTable.Rows[0]["BuyDate"].ToString();
				this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
				this.hfDevID.Value = dataTable.Rows[0]["ID"].ToString();
				if (!dataTable.Rows[0]["Technicians"].ToString().Trim().Equals(""))
				{
					this.tbDisposal.Text = dataTable.Rows[0]["Technicians"].ToString();
				}
				DataTable dataTable3 = DALCommon.GetDataList("DeviceConfig", "", " DeviceID=" + dataTable.Rows[0]["ID"].ToString()).Tables[0];
				if (dataTable3.Rows.Count > 0)
				{
					DataTable gridViewSource = this.GridViewSource;
					for (int i = 0; i < dataTable3.Rows.Count; i++)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable3.Rows[i]["_Name"].ToString();
						dataRow[1] = dataTable3.Rows[i]["Parameter"].ToString();
						dataRow[2] = dataTable3.Rows[i]["SN"].ToString();
						dataRow[3] = dataTable3.Rows[i]["MaintenancePeriod"].ToString();
						dataRow[4] = dataTable3.Rows[i]["BuyDate"].ToString();
						dataRow[5] = dataTable3.Rows[i]["MaintenanceEnd"].ToString();
						dataRow[6] = dataTable3.Rows[i]["Remark"].ToString();
						dataRow[7] = gridViewSource.Rows.Count;
						int num = 0;
						int.TryParse(dataTable3.Rows[i]["ID"].ToString(), out num);
						dataRow[8] = num;
						gridViewSource.Rows.Add(dataRow);
					}
					this.BindData();
				}
			}
			else
			{
				this.hfDevID.Value = "";
			}
		}
	}

	protected void btnChkDev_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.hfDevID.Value);
		if (text != "")
		{
			string strCondition = " ID=" + text;
			DataTable dataTable = DALCommon.GetDataList("ks_device", "", strCondition).Tables[0];
			if (dataTable.Rows.Count > 1)
			{
				this.SysInfo2("ConfInfo();");
			}
			else if (dataTable.Rows.Count == 1)
			{
				OtherFunction.BindProductBrand(this.ddlBrand);
				OtherFunction.BindProductClass(this.ddlClass);
				OtherFunction.BindProductModel(this.ddlModel, "");
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
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
				this.btnValiCus_Click(sender, e);
				this.tbUsePerson.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbDept.Text = dataTable.Rows[0]["CusDept"].ToString();
				this.tbUsePersonTel.Text = dataTable.Rows[0]["Tel"].ToString() + "," + dataTable.Rows[0]["Tel2"].ToString();
				this.tbUsePersonTel.Text = this.tbUsePersonTel.Text.Trim(new char[]
				{
					','
				});
				if (dataTable.Rows[0]["Adr"].ToString() != "")
				{
					this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				}
				this.ddlBrand.ClearSelection();
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Text == dataTable.Rows[0]["ProductBrand"].ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						break;
					}
				}
				this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
				this.ddlClass.ClearSelection();
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["ProductClass"].ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbClass.Text = dataTable.Rows[0]["ProductClass"].ToString();
				this.ddlModel.ClearSelection();
				for (int i = 0; i < this.ddlModel.Items.Count; i++)
				{
					if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["ProductModel"].ToString())
					{
						this.ddlModel.Items[i].Selected = true;
						break;
					}
				}
				this.tbModel.Text = dataTable.Rows[0]["ProductModel"].ToString();
				this.tbAspect.Text = dataTable.Rows[0]["ProductAspect"].ToString();
				string text2 = dataTable.Rows[0]["ProductSN1"].ToString();
				this.tbSN1.Text = text2;
				this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
				string text3 = dataTable.Rows[0]["DeviceNO"].ToString();
				this.tbDeviceNO.Text = text3;
				if (text2 != "")
				{
					DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[ID]", " ProductSN1='" + text2 + "' ").Tables[0];
					if (dataTable2.Rows.Count > 0)
					{
						this.lbRepCount.Text = "维修次数：" + dataTable2.Rows.Count;
					}
				}
				else if (text3 != "")
				{
					DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[ID]", " DeviceNO='" + text3 + "' ").Tables[0];
					if (dataTable2.Rows.Count > 0)
					{
						this.lbRepCount.Text = "维修次数：" + dataTable2.Rows.Count;
					}
				}
				this.ddlRepStatus.ClearSelection();
				this.ddlRepStatus.Items.FindByText(dataTable.Rows[0]["Warranty"].ToString()).Selected = true;
				this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
				this.tbBuyTime.Text = dataTable.Rows[0]["BuyDate"].ToString();
				this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
				if (!dataTable.Rows[0]["Technicians"].ToString().Trim().Equals(""))
				{
					this.tbDisposal.Text = dataTable.Rows[0]["Technicians"].ToString();
				}
				DataTable dataTable3 = DALCommon.GetDataList("DeviceConfig", "", " DeviceID=" + text).Tables[0];
				if (dataTable3.Rows.Count > 0)
				{
					DataTable gridViewSource = this.GridViewSource;
					for (int i = 0; i < dataTable3.Rows.Count; i++)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable3.Rows[i]["_Name"].ToString();
						dataRow[1] = dataTable3.Rows[i]["Parameter"].ToString();
						dataRow[2] = dataTable3.Rows[i]["SN"].ToString();
						dataRow[3] = dataTable3.Rows[i]["MaintenancePeriod"].ToString();
						dataRow[4] = dataTable3.Rows[i]["BuyDate"].ToString();
						dataRow[5] = dataTable3.Rows[i]["MaintenanceEnd"].ToString();
						dataRow[6] = dataTable3.Rows[i]["Remark"].ToString();
						dataRow[7] = gridViewSource.Rows.Count;
						int num = 0;
						int.TryParse(dataTable3.Rows[i]["ID"].ToString(), out num);
						dataRow[8] = num;
						gridViewSource.Rows.Add(dataRow);
					}
					this.BindData();
				}
			}
		}
	}

	protected void SysInfo2(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", str, true);
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
		dataRow[7] = gridViewSource.Rows.Count;
		dataRow[8] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void btnAddEmpty_Click(object sender, EventArgs e)
	{
		this.CollectData();
		this.AddEmpty();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.GridView1.Rows.Count; i++)
		{
			TextBox textBox = this.GridView1.Rows[i].FindControl("tbName") as TextBox;
			TextBox textBox2 = this.GridView1.Rows[i].FindControl("tbParameter") as TextBox;
			TextBox textBox3 = this.GridView1.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox4 = this.GridView1.Rows[i].FindControl("tbPeriod") as TextBox;
			TextBox textBox5 = this.GridView1.Rows[i].FindControl("tbBuyDate") as TextBox;
			TextBox textBox6 = this.GridView1.Rows[i].FindControl("tbMaintenanceEnd") as TextBox;
			TextBox textBox7 = this.GridView1.Rows[i].FindControl("tbRemark") as TextBox;
			TextBox textBox8 = this.GridView1.Rows[i].FindControl("tbConfID") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i][0] = FunLibrary.ChkInput(textBox.Text);
			gridViewSource.Rows[i][1] = FunLibrary.ChkInput(textBox2.Text);
			gridViewSource.Rows[i][2] = FunLibrary.ChkInput(textBox3.Text);
			gridViewSource.Rows[i][3] = FunLibrary.ChkInput(textBox4.Text);
			gridViewSource.Rows[i][4] = FunLibrary.ChkInput(textBox5.Text);
			gridViewSource.Rows[i][5] = FunLibrary.ChkInput(textBox6.Text);
			gridViewSource.Rows[i][6] = FunLibrary.ChkInput(textBox7.Text);
			gridViewSource.Rows[i][8] = FunLibrary.ChkInput(textBox8.Text);
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	private void BindData()
	{
		this.GridView1.DataSource = this.GridViewSource;
		this.GridView1.DataBind();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[10].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("jc_deviceconfitem", "", " ProductClass like '%" + str + "%' ").Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = dataTable.Rows[i]["_Name"].ToString();
				dataRow[1] = dataTable.Rows[i]["Parameter"].ToString();
				dataRow[2] = "";
				dataRow[3] = dataTable.Rows[i]["MaintenancePeriod"].ToString();
				dataRow[4] = "";
				dataRow[5] = "";
				dataRow[6] = dataTable.Rows[i]["Remark"].ToString();
				dataRow[7] = gridViewSource.Rows.Count;
				int num = 0;
				int.TryParse(gridViewSource.Rows[i]["ID"].ToString(), out num);
				dataRow[8] = num;
				gridViewSource.Rows.Add(dataRow);
			}
			this.BindData();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！没有该类别的配置项');$('" + this.tbCon.ClientID + "').select();");
		}
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		this.CollectData();
		string text = string.Empty;
		if (this.hfRecID.Value.EndsWith(","))
		{
			text = this.hfRecID.Value.Remove(this.hfRecID.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfRecID.Value;
		}
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("jc_deviceconfitem", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[1] = dataTable.Rows[i]["Parameter"].ToString();
					dataRow[2] = "";
					dataRow[3] = dataTable.Rows[i]["MaintenancePeriod"].ToString();
					dataRow[4] = "";
					dataRow[5] = "";
					dataRow[6] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[7] = gridViewSource.Rows.Count;
					int num = 0;
					int.TryParse(gridViewSource.Rows[i]["ID"].ToString(), out num);
					dataRow[8] = num;
					gridViewSource.Rows.Add(dataRow);
				}
			}
		}
		this.BindData();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num = 0;
		int num2 = 0;
		int.TryParse(this.hfCusID.Value, out num);
		int.TryParse(this.hfDevID.Value, out num2);
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
		int num4;
		if (num == 0 || num3 == 1)
		{
			if (this.hfAddCus.Value == "1")
			{
				this.SysInfo("window.alert('没有添加客户的权限!')");
				return;
			}
			CustomerListInfo customerListInfo = new CustomerListInfo();
			customerListInfo.DeptID = new int?(1);
			customerListInfo._Name = FunLibrary.ChkInput(this.tbCusName.Text);
			customerListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbCusName.Text));
			customerListInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
			customerListInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
			customerListInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
			customerListInfo.SellerID = new int?(int.Parse(this.ddlOperator.SelectedValue));
			customerListInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
			customerListInfo.OperatorID = int.Parse((string)this.Session["Session_wtUserID"]);
			DALCustomerList dALCustomerList = new DALCustomerList();
			string str;
			num4 = dALCustomerList.Add(customerListInfo, true, out str, out num);
			if (num4 == -1)
			{
				this.SysInfo("window.alert(\"" + str + "\");");
				return;
			}
			if (num4 > 0)
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');");
				return;
			}
			this.hfCusID.Value = num.ToString();
		}
		string text = FunLibrary.ChkInput(this.tbSN1.Text);
		string text2 = FunLibrary.ChkInput(this.tbDeviceNO.Text);
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
				this.SysInfo("window.alert('操作失败！该客户的该机器正在维修中...');");
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
				this.SysInfo("window.alert('操作失败！该客户的该机器正在维修中...');");
				return;
			}
		}
		DALServices dALServices = new DALServices();
		ServicesInfo servicesInfo = new ServicesInfo();
		servicesInfo.TakeOverID = 1;
		servicesInfo.DisposalID = 1;
		servicesInfo.curStatus = "待处理";
		servicesInfo.TypeID = int.Parse(this.ddlType.SelectedValue);
		servicesInfo.TakeStyleID = int.Parse(this.ddlTake.SelectedValue);
		servicesInfo.Time_Make = FunLibrary.ChkInput(this.tbDate.Text);
		servicesInfo.Time_TakeOver = FunLibrary.ChkInput(this.tbTakeTime.Text);
		servicesInfo.Time_Complete = FunLibrary.ChkInput(this.tbCmpTime.Text);
		servicesInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		servicesInfo.PersonID = int.Parse((string)this.Session["Session_wtUserID"]);
		servicesInfo.DisposalOper = FunLibrary.ChkInput(this.tbDisposal.Text);
		servicesInfo.CustomerID = num;
		servicesInfo.CustomerName = FunLibrary.ChkInput(this.tbCusName.Text);
		servicesInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		servicesInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		servicesInfo.UsePerson = FunLibrary.ChkInput(this.tbUsePerson.Text);
		servicesInfo.UsePersonDept = FunLibrary.ChkInput(this.tbDept.Text);
		servicesInfo.UsePersonTel = FunLibrary.ChkInput(this.tbUsePersonTel.Text);
        //by coding 
        servicesInfo.CmbProver = FunLibrary.ChkInput(this.cmbProvince.Text);
        servicesInfo.CmbCity= FunLibrary.ChkInput(this.cmbCity.Text);
        servicesInfo.BranchName = FunLibrary.ChkInput(this.tbwangdian.Text);
        string[] s= this.ddl_branchFax.Text.Trim().Split('-');
        servicesInfo.BranchRatio =Convert.ToDecimal(s[1]);
        servicesInfo.BranchRatioType = s[0]; 
        //end
        servicesInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
		servicesInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
		servicesInfo.ProductBrandID = int.Parse(this.ddlBrand.SelectedValue);
		servicesInfo.ProductClassID = int.Parse(this.ddlClass.SelectedValue);
		servicesInfo.ProductModelID = int.Parse(this.ddlModel.SelectedValue);
		servicesInfo.ProductSN1 = FunLibrary.ChkInput(this.tbSN1.Text);
		servicesInfo.ProductSN2 = FunLibrary.ChkInput(this.tbSN2.Text);
		servicesInfo.BuyDate = FunLibrary.ChkInput(this.tbBuyTime.Text);
		servicesInfo.BuyFrom = FunLibrary.ChkInput(this.tbBuyFrom.Text);
		servicesInfo.Aspect = FunLibrary.ChkInput(this.tbAspect.Text);
		servicesInfo.Accessory = FunLibrary.ChkInput(this.tbAcc.Text);
		servicesInfo.Fault = FunLibrary.ChkInput(this.tbFault.Text);
		servicesInfo.WarrantyID = int.Parse(this.ddlRepStatus.SelectedValue);
		servicesInfo.BuyInvoice = FunLibrary.ChkInput(this.tbBuyInvoice.Text);
		decimal num5 = 0m;
		decimal.TryParse(this.tbPoint.Text, out num5);
		servicesInfo.dPoint = num5;
		servicesInfo.bAgain = this.cbRe.Checked;
		servicesInfo.SaveID = FunLibrary.ChkInput(this.tbSaveID.Text);
		servicesInfo.SupplierID = FunLibrary.ChkInput(this.tbCorpID.Text);
		servicesInfo.WarrantyChargeCorpID = int.Parse(this.ddlChargeCorp.SelectedValue);
		servicesInfo.SubscribeTime = FunLibrary.ChkInput(this.tbSubTime.Text);
		servicesInfo.SubscribeConnectTime = FunLibrary.ChkInput(this.tbSubContTime.Text);
		decimal.TryParse(this.tbSubPrice.Text, out num5);
		servicesInfo.SubscribePrice = num5;
		decimal.TryParse(this.tbSubCharge.Text, out num5);
		servicesInfo.PreCharge = num5;
		decimal.TryParse(this.tbPostage.Text, out num5);
		servicesInfo.Postage = num5;
		servicesInfo.PostNO = FunLibrary.ChkInput(this.tbPostNO.Text);
		servicesInfo.SndStyleID = int.Parse(this.ddlSndStyle.SelectedValue);
		servicesInfo.ServiceLevelID = int.Parse(this.ddlPRI.SelectedValue);
		servicesInfo.ContractNO = FunLibrary.ChkInput(this.tbContNO.Text);
		servicesInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		servicesInfo.DeviceNO = FunLibrary.ChkInput(this.tbDeviceNO.Text);
		servicesInfo.Path = FunLibrary.ChkInput(this.hfPath.Value);
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<ServicesDeviceConfInfo> list = new List<ServicesDeviceConfInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				string a = string.Concat(new string[]
				{
					gridViewSource.Rows[i]["_Name"].ToString(),
					gridViewSource.Rows[i]["Parameter"].ToString(),
					gridViewSource.Rows[i]["SN"].ToString(),
					gridViewSource.Rows[i]["MaintenancePeriod"].ToString(),
					gridViewSource.Rows[i]["MaintenanceEnd"].ToString(),
					gridViewSource.Rows[i]["BuyDate"].ToString(),
					gridViewSource.Rows[i]["Remark"].ToString()
				});
				if (int.Parse(gridViewSource.Rows[i]["ID"].ToString()) > 0 && a != "")
				{
					ServicesDeviceConfInfo servicesDeviceConfInfo = new ServicesDeviceConfInfo();
					servicesDeviceConfInfo._Name = gridViewSource.Rows[i]["_Name"].ToString();
					servicesDeviceConfInfo.Parameter = gridViewSource.Rows[i]["Parameter"].ToString();
					servicesDeviceConfInfo.SN = gridViewSource.Rows[i]["SN"].ToString();
					servicesDeviceConfInfo.MaintenancePeriod = gridViewSource.Rows[i]["MaintenancePeriod"].ToString();
					servicesDeviceConfInfo.MaintenanceEnd = gridViewSource.Rows[i]["MaintenanceEnd"].ToString();
					servicesDeviceConfInfo.BuyDate = gridViewSource.Rows[i]["BuyDate"].ToString();
					servicesDeviceConfInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					int devConfID = 0;
					int.TryParse(gridViewSource.Rows[i]["DevConfID"].ToString(), out devConfID);
					servicesDeviceConfInfo.DevConfID = devConfID;
					list.Add(servicesDeviceConfInfo);
				}
			}
			servicesInfo.ServicesDeviceConfInfos = list;
		}
		int iTbid;
		num4 = dALServices.Add(servicesInfo, this.hfFault.Value.Trim(), out iTbid);
		string text3 = this.hfAttachs.Value.Trim().Trim(new char[]
		{
			','
		});
		if (text3.Length > 0)
		{
			dALServices.UpdateAttachs(iTbid, 1, this.hfAttachs.Value.Trim().Trim(new char[]
			{
				','
			}));
		}
		if (num4 == 0)
		{
			this.hfPrintID.Value = iTbid.ToString();
			string text4 = "window.alert('操作成功！服务单已保存');";
			if (this.itel == 0)
			{
				text4 += "parent.RefrhClr();";
				this.ClearCusText();
			}
			else
			{
				this.ClearText();
			}
			this.SysInfo(text4);
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.tbBillID.Text = DALCommon.CreateID(22, 0);
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
		this.ClearText();
	}

	protected void ClearText()
	{
		this.tbBrand.Text = string.Empty;
		this.tbClass.Text = string.Empty;
		this.tbModel.Text = string.Empty;
		this.ddlBrand.ClearSelection();
		for (int i = 0; i < this.ddlBrand.Items.Count; i++)
		{
			if (this.ddlBrand.Items[i].Text == "")
			{
				this.ddlBrand.Items[i].Selected = false;
				break;
			}
		}
		this.ddlClass.ClearSelection();
		for (int i = 0; i < this.ddlClass.Items.Count; i++)
		{
			if (this.ddlClass.Items[i].Text == "")
			{
				this.ddlClass.Items[i].Selected = false;
				break;
			}
		}
		this.ddlModel.ClearSelection();
		for (int i = 0; i < this.ddlModel.Items.Count; i++)
		{
			if (this.ddlModel.Items[i].Text == "")
			{
				this.ddlModel.Items[i].Selected = false;
				break;
			}
		}
		for (int i = 0; i < this.ddlChargeCorp.Items.Count; i++)
		{
			if (this.ddlChargeCorp.Items[i].Text == "")
			{
				this.ddlChargeCorp.Items[i].Selected = false;
				break;
			}
		}
		this.tbAspect.Text = string.Empty;
		this.tbSN1.Text = string.Empty;
		this.tbSN2.Text = string.Empty;
		this.tbAcc.Text = string.Empty;
		this.tbBuyFrom.Text = string.Empty;
		this.tbBuyTime.Text = string.Empty;
		this.tbBuyInvoice.Text = string.Empty;
		this.tbFault.Text = string.Empty;
		this.ddlRepStatus.ClearSelection();
		this.ddlPRI.ClearSelection();
		this.cbRe.Checked = false;
		this.tbSaveID.Text = string.Empty;
		this.tbCorpID.Text = string.Empty;
		this.tbDisposal.Text = string.Empty;
		this.tbSubTime.Text = string.Empty;
		this.tbSubPrice.Text = string.Empty;
		this.tbSubCharge.Text = string.Empty;
		this.tbRemark.Text = string.Empty;
		this.tbPoint.Text = string.Empty;
		this.hfDevID.Value = string.Empty;
		this.tbPostNO.Text = string.Empty;
		this.tbPostage.Text = string.Empty;
		this.tbDeviceNO.Text = string.Empty;
		this.tbSubContTime.Text = string.Empty;
		this.tbCmpTime.Text = string.Empty;
		this.hfNO.Value = (this.hfSN.Value = "");
		this.hfPath.Value = "";
		this.GridViewSource.Clear();
		this.BindData();
		this.AddEmpty();
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

	protected void btnRefBrand_Click(object sender, EventArgs e)
	{
		OtherFunction.BindProductBrand(this.ddlBrand);
		if (this.hfBrand.Value != string.Empty)
		{
			this.ddlBrand.ClearSelection();
			this.ddlBrand.Items.FindByText(this.hfBrand.Value).Selected = true;
			this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
		}
	}

	protected void btnRefClass_Click(object sender, EventArgs e)
	{
		OtherFunction.BindProductClass(this.ddlClass);
		if (this.hfClass.Value != string.Empty)
		{
			this.ddlClass.ClearSelection();
			this.ddlClass.Items.FindByText(this.hfClass.Value).Selected = true;
			this.tbClass.Text = this.ddlClass.SelectedItem.Text;
		}
	}

	protected void btnRefModel_Click(object sender, EventArgs e)
	{
		if (this.hfModelID.Value != "")
		{
			OtherFunction.BindProductModel(this.ddlModel, "");
			DataTable dataTable = DALCommon.GetDataList("jc_productmodel", "", "ID=" + this.hfModelID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.ddlBrand.ClearSelection();
				this.ddlBrand.Items.FindByText(dataTable.Rows[0]["Brand"].ToString()).Selected = true;
				this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
				this.ddlClass.ClearSelection();
				this.ddlClass.Items.FindByText(dataTable.Rows[0]["Class"].ToString()).Selected = true;
				this.tbClass.Text = this.ddlClass.SelectedItem.Text;
				this.ddlModel.ClearSelection();
				this.ddlModel.Items.FindByText(dataTable.Rows[0]["_Name"].ToString()).Selected = true;
				this.tbModel.Text = this.ddlModel.SelectedItem.Text;
			}
		}
	}

	protected void btnRefWarranty_Click(object sender, EventArgs e)
	{
		OtherFunction.BindWarranty(this.ddlRepStatus);
		if (this.hfWarranty.Value != string.Empty)
		{
			this.ddlRepStatus.ClearSelection();
			this.ddlRepStatus.Items.FindByText(this.hfWarranty.Value).Selected = true;
		}
	}

	protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.GetProductModel();
	}

	protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.GetProductModel();
	}

	protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlModel.SelectedValue != "-1")
		{
			DataTable dataTable = DALCommon.GetDataList("jc_productmodel", "", "ID=" + this.ddlModel.SelectedValue).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.ddlBrand.ClearSelection();
				this.ddlBrand.Items.FindByText(dataTable.Rows[0]["Brand"].ToString()).Selected = true;
				this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
				this.ddlClass.ClearSelection();
				this.ddlClass.Items.FindByText(dataTable.Rows[0]["Class"].ToString()).Selected = true;
				this.tbClass.Text = this.ddlClass.SelectedItem.Text;
			}
		}
	}

	protected void GetProductModel()
	{
		string text = string.Empty;
		if (this.ddlBrand.SelectedValue != "0" && this.ddlBrand.SelectedValue != "-1")
		{
			text = text + " BrandID=" + this.ddlBrand.SelectedValue;
		}
		if (this.ddlClass.SelectedValue != "0" && this.ddlClass.SelectedValue != "-1")
		{
			if (text == string.Empty)
			{
				text = text + " ClassID=" + this.ddlClass.SelectedValue;
			}
			else
			{
				text = text + " and ClassID=" + this.ddlClass.SelectedValue;
			}
		}
		OtherFunction.BindProductModel(this.ddlModel, text);
		bool flag = false;
		for (int i = 0; i < this.ddlModel.Items.Count; i++)
		{
			if (this.ddlModel.Items[i].Text == this.tbModel.Text)
			{
				this.ddlModel.Items[i].Selected = true;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			this.tbModel.Text = "";
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
    protected void ddl_branchFax_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnWangdian_Click(object sender, EventArgs e)
    {
        if (this.hfwangdianID.Value != "")
        {
            //技术服务+增值税销项+增值税进项+普通发票
            DataTable dataTable = DALCommon.GetDataList("BranchList", "_Name, CAST(TR_jsfw as varchar(10))+'-'+CAST(TR_zzsxx as varchar(10))+'-'+CAST(TR_zzsjx as varchar(10))+'-'+CAST(TR_ptfp as varchar(10)) as TR ", " [ID]=" + this.hfwangdianID.Value).Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                tbwangdian.Text = dataTable.Rows[0]["_Name"].ToString();
                //tbwdTaxrate.Text = dataTable.Rows[0]["TaxRate"].ToString();
                ddl_branchFax.Items.Clear();
                string[] taxs = dataTable.Rows[0]["TR"].ToString().Split('-');
                ListItem li0 = new ListItem("不含税", "no-0");
                ListItem li1 = new ListItem("技术服务费：" + Math.Round(decimal.Parse(taxs[0]) * 100, 2) + "%", "jsfw-" + taxs[0]);
                ListItem li2 = new ListItem("增值税销项：" + Math.Round(decimal.Parse(taxs[1]) * 100, 2) + "%", "zzsxx-" + taxs[1]);
                ListItem li3 = new ListItem("增值税进项：" + Math.Round(decimal.Parse(taxs[2]) * 100, 2) + "%", "zzsjx-" + taxs[2]);
                ListItem li4 = new ListItem("普通发票：" + Math.Round(decimal.Parse(taxs[3]) * 100, 2) + "%", "ptfp-" + taxs[3]);
                ddl_branchFax.Items.Add(li0);
                ddl_branchFax.Items.Add(li1);
                ddl_branchFax.Items.Add(li2);
                ddl_branchFax.Items.Add(li3);
                ddl_branchFax.Items.Add(li4);
            }
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script> addressInit('cmbProvince', 'cmbCity', 'cmbArea', '北京', '北京', '东城区');</script>"); 
        //tbGoodsAmount.Text = tbAmount.Text;
    }
    protected void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList retIArr = new ArrayList();
        retIArr.Add(new string[] { "北京市", "东城|西城|崇文|宣武|朝阳|丰台|石景山|海淀|门头沟|房山|通州|顺义|昌平|大兴|平谷|怀柔|密云|延庆" });
        retIArr.Add(new string[] { "上海市", "黄浦|卢湾|徐汇|长宁|静安|普陀|闸北|虹口|杨浦|闵行|宝山|嘉定|浦东|金山|松江|青浦|南汇|奉贤|崇明" });
        retIArr.Add(new string[] { "天津市", "和平|东丽|河东|西青|河西|津南|南开|北辰|河北|武清|红挢|塘沽|汉沽|大港|宁河|静海|宝坻|蓟县" });
        retIArr.Add(new string[] { "重庆市", "万州|涪陵|渝中|大渡口|江北|沙坪坝|九龙坡|南岸|北碚|万盛|双挢|渝北|巴南|黔江|长寿|綦江|潼南|铜梁 |大足|荣昌|壁山|梁平|城口|丰都|垫江|武隆|忠县|开县|云阳|奉节|巫山|巫溪|石柱|秀山|酉阳|彭水|江津|合川|永川|南川" });
        retIArr.Add(new string[] { "河北省", "石家庄|邯郸|邢台|保定|张家口|承德|廊坊|唐山|秦皇岛|沧州|衡水" });
        retIArr.Add(new string[] { "山西省", "太原|大同|阳泉|长治|晋城|朔州|吕梁|忻州|晋中|临汾|运城" });
        retIArr.Add(new string[] { "内蒙古自治区", "呼和浩特|包头|乌海|赤峰|呼伦贝尔盟|阿拉善盟|哲里木盟|兴安盟|乌兰察布盟|锡林郭勒盟|巴彦淖尔盟|伊克昭盟" });
        retIArr.Add(new string[] { "辽宁省", "沈阳|大连|鞍山|抚顺|本溪|丹东|锦州|营口|阜新|辽阳|盘锦|铁岭|朝阳|葫芦岛" });
        retIArr.Add(new string[] { "吉林省", "长春|吉林|四平|辽源|通化|白山|松原|白城|延边" });
        retIArr.Add(new string[] { "黑龙江省", "哈尔滨|齐齐哈尔|牡丹江|佳木斯|大庆|绥化|鹤岗|鸡西|黑河|双鸭山|伊春|七台河|大兴安岭" });
        retIArr.Add(new string[] { "江苏省", "南京|镇江|苏州|南通|扬州|盐城|徐州|连云港|常州|无锡|宿迁|泰州|淮安" });
        retIArr.Add(new string[] { "浙江省", "杭州|宁波|温州|嘉兴|湖州|绍兴|金华|衢州|舟山|台州|丽水" });
        retIArr.Add(new string[] { "安徽省", "合肥|芜湖|蚌埠|马鞍山|淮北|铜陵|安庆|黄山|滁州|宿州|池州|淮南|巢湖|阜阳|六安|宣城|亳州" });
        retIArr.Add(new string[] { "福建省", "福州|厦门|莆田|三明|泉州|漳州|南平|龙岩|宁德" });
        retIArr.Add(new string[] { "江西省", "南昌市|景德镇|九江|鹰潭|萍乡|新馀|赣州|吉安|宜春|抚州|上饶" });
        retIArr.Add(new string[] { "山东省", "济南|青岛|淄博|枣庄|东营|烟台|潍坊|济宁|泰安|威海|日照|莱芜|临沂|德州|聊城|滨州|菏泽" });
        retIArr.Add(new string[] { "河南省", "郑州|开封|洛阳|平顶山|安阳|鹤壁|新乡|焦作|濮阳|许昌|漯河|三门峡|南阳|商丘|信阳|周口|驻马店|济源" });
        retIArr.Add(new string[] { "湖北省", "武汉|宜昌|荆州|襄樊|黄石|荆门|黄冈|十堰|恩施|潜江|天门|仙桃|随州|咸宁|孝感|鄂州" });
        retIArr.Add(new string[] { "湖南省", "长沙|常德|株洲|湘潭|衡阳|岳阳|邵阳|益阳|娄底|怀化|郴州|永州|湘西|张家界" });
        retIArr.Add(new string[] { "广东省", "广州|深圳|珠海|汕头|东莞|中山|佛山|韶关|江门|湛江|茂名|肇庆|惠州|梅州|汕尾|河源|阳江|清远|潮州|揭阳|云浮" });
        retIArr.Add(new string[] { "湖南省", "长沙|常德|株洲|湘潭|衡阳|岳阳|邵阳|益阳|娄底|怀化|郴州|永州|湘西|张家界" });
        retIArr.Add(new string[] { "广西壮族自治区", "南宁|柳州|桂林|梧州|北海|防城港|钦州|贵港|玉林|南宁地区|柳州地区|贺州|百色|河池" });
        retIArr.Add(new string[] { "海南省", "海口|三亚" });
        retIArr.Add(new string[] { "四川省", "成都|绵阳|德阳|自贡|攀枝花|广元|内江|乐山|南充|宜宾|广安|达川|雅安|眉山|甘孜|凉山|泸州" });
        retIArr.Add(new string[] { "贵州省", "贵阳|六盘水|遵义|安顺|铜仁|黔西南|毕节|黔东南|黔南" });
        retIArr.Add(new string[] { "云南省", "昆明|大理|曲靖|玉溪|昭通|楚雄|红河|文山|思茅|西双版纳|保山|德宏|丽江|怒江|迪庆|临沧" });
        retIArr.Add(new string[] { "西藏自治区", "拉萨|日喀则|山南|林芝|昌都|阿里|那曲" });
        retIArr.Add(new string[] { "陕西省", "西安|宝鸡|咸阳|铜川|渭南|延安|榆林|汉中|安康|商洛" });
        retIArr.Add(new string[] { "甘肃省", "兰州|嘉峪关|金昌|白银|天水|酒泉|张掖|武威|定西|陇南|平凉|庆阳|临夏|甘南" });
        retIArr.Add(new string[] { "宁夏回族自治区", "银川|石嘴山|吴忠|固原" });
        retIArr.Add(new string[] { "青海省", "西宁|海东|海南|海北|黄南|玉树|果洛|海西" });
        retIArr.Add(new string[] { "新疆维吾尔族自治区", "乌鲁木齐|石河子|克拉玛依|伊犁|巴音郭勒|昌吉|克孜勒苏柯尔克孜|博尔塔拉|吐鲁番|哈密|喀什|和田|阿克苏" });
        retIArr.Add(new string[] { "香港特别行政区", "香港特别行政区" });
        retIArr.Add(new string[] { "澳门特别行政区", "澳门特别行政区" });
        retIArr.Add(new string[] { "台湾省", "台北|高雄|台中|台南|屏东|南投|云林|新竹|彰化|苗栗|嘉义|花莲|桃园|宜兰|基隆|台东|金门|马祖|澎湖" });
        retIArr.Add(new string[] { "其它", "北美洲|南美洲|亚洲|非洲|欧洲|大洋洲" });

        foreach (string[] item in retIArr)
        {
            //如果选择了省
            if (item[0].ToString() == cmbProvince.SelectedValue)
            {
                string[] tmpcityArray = item[1].ToString().Split('|');
                cmbCity.Items.Clear();
                for (int j = 0; j < tmpcityArray.Length; j++)
                {
                    cmbCity.Items.Add(tmpcityArray[j].ToString());
                }
            }
        }
    }
}
