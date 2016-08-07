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
using wt.DB;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Branch_Services_SerMod : Page, IRequiresSessionState
{
	private int id;



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
			DALRight dALRight = new DALRight();
			if (num > 0)
			{
				if (!dALRight.GetRight(num, "gd_r6"))
				{
					this.btnAdd.Enabled = false;
				}
				if (dALRight.GetRight(num, "gd_r29"))
				{
					this.tbTakeTime.Enabled = false;
				}
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.bFaultNoInput)
			{
				this.tbFault.Attributes["onfocus"] = "blur();";
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0 and bDestClerk=1");
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
			OtherFunction.BindSndStyle(this.ddlSndStyle, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindServiceLevel(this.ddlPRI);
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
			this.AddEmpty();
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbBillID.Text = dataTable.Rows[0]["BillID"].ToString();
				for (int i = 0; i < this.ddlType.Items.Count; i++)
				{
					if (this.ddlType.Items[i].Text == dataTable.Rows[0]["ServicesType"].ToString())
					{
						this.ddlType.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlTake.Items.Count; i++)
				{
					if (this.ddlTake.Items[i].Text == dataTable.Rows[0]["TakeStyle"].ToString())
					{
						this.ddlTake.Items[i].Selected = true;
						break;
					}
				}
				this.tbTakeTime.Text = dataTable.Rows[0]["Time_TakeOver"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
				this.ddlDept.DataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
				this.ddlDept.DataTextField = "_Name";
				this.ddlDept.DataValueField = "ID";
				this.ddlDept.DataBind();
				this.ddlDept.Items.Insert(0, new ListItem("", ""));
				DataTable dataTable2 = DALCommon.GetList("SerAttach", "ID", "BillID=" + this.id + " and iType=1").Tables[0];
				string text = string.Empty;
				foreach (DataRow dataRow in dataTable2.Rows)
				{
					text = text + dataRow["ID"].ToString().Trim() + ",";
				}
				this.hfAttachs.Value = text.Trim(new char[]
				{
					','
				});
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
				this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbUsePerson.Text = dataTable.Rows[0]["UsePerson"].ToString();
				this.tbUsePersonTel.Text = dataTable.Rows[0]["UsePersonTel"].ToString();
				this.tbDept.Text = dataTable.Rows[0]["UsePersonDept"].ToString();
				this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.tbCmpTime.Text = dataTable.Rows[0]["Time_Complete"].ToString();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == dataTable.Rows[0]["Operator"].ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbDate.Text = dataTable.Rows[0]["Time_Make"].ToString();
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Text == dataTable.Rows[0]["ProductBrand"].ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
						break;
					}
				}
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["ProductClass"].ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						this.tbClass.Text = this.ddlClass.SelectedItem.Text;
						break;
					}
				}
				for (int i = 0; i < this.ddlModel.Items.Count; i++)
				{
					if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["ProductModel"].ToString())
					{
						this.ddlModel.Items[i].Selected = true;
						this.tbModel.Text = this.ddlModel.SelectedItem.Text;
						break;
					}
				}
				this.tbAspect.Text = dataTable.Rows[0]["Aspect"].ToString();
				this.tbSN1.Text = dataTable.Rows[0]["ProductSN1"].ToString();
				this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
				this.tbAcc.Text = dataTable.Rows[0]["Accessory"].ToString();
				this.tbFault.Text = dataTable.Rows[0]["Fault"].ToString();
				for (int i = 0; i < this.ddlRepStatus.Items.Count; i++)
				{
					if (this.ddlRepStatus.Items[i].Text == dataTable.Rows[0]["Warranty"].ToString())
					{
						this.ddlRepStatus.Items[i].Selected = true;
						break;
					}
				}
				this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
				this.tbBuyTime.Text = dataTable.Rows[0]["BuyDate"].ToString();
				this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
				this.tbPoint.Text = dataTable.Rows[0]["dPoint"].ToString();
				if (dataTable.Rows[0]["bRepair"].ToString() != "")
				{
					this.cbRe.Checked = true;
				}
				if (dataTable.Rows[0]["bAgain"].ToString() != "")
				{
					this.cbAgain.Checked = true;
				}
				this.tbSaveID.Text = dataTable.Rows[0]["SaveID"].ToString();
				this.tbCorpID.Text = dataTable.Rows[0]["SupplierID"].ToString();
				for (int i = 0; i < this.ddlChargeCorp.Items.Count; i++)
				{
					if (this.ddlChargeCorp.Items[i].Value == dataTable.Rows[0]["WarrantyChargeCorpID"].ToString())
					{
						this.ddlChargeCorp.Items[i].Selected = true;
						break;
					}
				}
				this.tbDisposal.Text = dataTable.Rows[0]["DisposalOper"].ToString();
				this.tbSubTime.Text = dataTable.Rows[0]["SubscribeTime"].ToString();
				this.tbSubContTime.Text = dataTable.Rows[0]["SubscribeConnectTime"].ToString();
				this.tbSubPrice.Text = dataTable.Rows[0]["SubscribePrice"].ToString();
				this.tbSubCharge.Text = dataTable.Rows[0]["PreCharge"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbPostage.Text = dataTable.Rows[0]["Postage"].ToString();
				this.tbPostNO.Text = dataTable.Rows[0]["PostNO"].ToString();
				this.tbContNO.Text = dataTable.Rows[0]["ContractNO"].ToString();
				this.tbDeviceNO.Text = dataTable.Rows[0]["DeviceNO"].ToString();
				this.hfPath.Value = dataTable.Rows[0]["Path"].ToString();
				DALCustomerList dALCustomerList = new DALCustomerList();
				this.tbCusLevel.Text = dALCustomerList.getCusMember(int.Parse(this.hfCusID.Value));
				DataTable dataTable3 = DALCommon.GetDataList("ServicesFault", "FaultID", " [BillID]=" + this.id.ToString()).Tables[0];
				if (dataTable3.Rows.Count > 0)
				{
					string text2 = string.Empty;
					foreach (DataRow dataRow in dataTable3.Rows)
					{
						text2 = text2 + dataRow["FaultID"].ToString() + ",";
					}
					this.hfFault.Value = text2.Trim().Trim(new char[]
					{
						','
					});
				}
				if (this.hfPath.Value != "")
				{
					string text3 = this.hfPath.Value.Substring(this.hfPath.Value.LastIndexOf('/') + 1);
					this.dUpload.InnerHtml = "<img src='../../Public/Images/dmony.gif' /> <a href=\"" + this.hfPath.Value + "\" target=_blank >附件</a>";
				}
				for (int i = 0; i < this.ddlSndStyle.Items.Count; i++)
				{
					if (this.ddlSndStyle.Items[i].Value == dataTable.Rows[0]["SndStyleID"].ToString())
					{
						this.ddlSndStyle.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlPRI.Items.Count; i++)
				{
					if (this.ddlPRI.Items[i].Value == dataTable.Rows[0]["ServiceLevelID"].ToString())
					{
						this.ddlPRI.Items[i].Selected = true;
						break;
					}
				}
			}
			DataTable dataTable4 = DALCommon.GetDataList("ServicesDeviceConf", "", " [BillID]=" + this.id.ToString()).Tables[0];
			if (dataTable4.Rows.Count > 0)
			{
				DataTable gridViewSource = this.GridViewSource;
				for (int i = 0; i < dataTable4.Rows.Count; i++)
				{
					DataRow dataRow2 = gridViewSource.NewRow();
					dataRow2[0] = dataTable4.Rows[i]["_Name"].ToString();
					dataRow2[1] = dataTable4.Rows[i]["Parameter"].ToString();
					dataRow2[2] = dataTable4.Rows[i]["SN"].ToString();
					dataRow2[3] = dataTable4.Rows[i]["MaintenancePeriod"].ToString();
					dataRow2[4] = dataTable4.Rows[i]["BuyDate"].ToString();
					dataRow2[5] = dataTable4.Rows[i]["MaintenanceEnd"].ToString();
					dataRow2[6] = dataTable4.Rows[i]["Remark"].ToString();
					dataRow2[7] = gridViewSource.Rows.Count;
					dataRow2[8] = int.Parse(dataTable4.Rows[i]["ID"].ToString());
					dataRow2[9] = 1;
					gridViewSource.Rows.Add(dataRow2);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
			}
		}
	}

	protected void btnValiCus_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "", " ID=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				if (dataTable.Rows[0]["Tel"].ToString() == "")
				{
					this.tbTel.Text = dataTable.Rows[0]["Tel2"].ToString();
				}
				else
				{
					this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString() + "," + dataTable.Rows[0]["Tel2"].ToString();
				}
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
		string text = FunLibrary.ChkInput(this.tbCusName.Text);
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

	protected void btnChkSN_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbSN1.Text);
		if (text != "")
		{
			string text2 = " ProductSN1='" + text + "' ";
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.CustomerShar == 1)
			{
				text2 = text2 + " and DeptID=" + (string)this.Session["Session_wtBranchID"];
			}
			DataTable dataTable = DALCommon.GetDataList("ks_device", "", text2).Tables[0];
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
				DataTable dataTable2 = DALCommon.GetDataList("DeviceConfig", "", " DeviceID=" + dataTable.Rows[0]["ID"].ToString()).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					DataTable gridViewSource = this.GridViewSource;
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable2.Rows[i]["_Name"].ToString();
						dataRow[1] = dataTable2.Rows[i]["Parameter"].ToString();
						dataRow[2] = dataTable2.Rows[i]["SN"].ToString();
						dataRow[3] = dataTable2.Rows[i]["MaintenancePeriod"].ToString();
						dataRow[4] = dataTable2.Rows[i]["BuyDate"].ToString();
						dataRow[5] = dataTable2.Rows[i]["MaintenanceEnd"].ToString();
						dataRow[6] = dataTable2.Rows[i]["Remark"].ToString();
						dataRow[7] = gridViewSource.Rows.Count;
						dataRow[8] = 0;
						dataRow[9] = 0;
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
				DataTable dataTable2 = DALCommon.GetDataList("DeviceConfig", "", " DeviceID=" + text).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					DataTable gridViewSource = this.GridViewSource;
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable2.Rows[i]["_Name"].ToString();
						dataRow[1] = dataTable2.Rows[i]["Parameter"].ToString();
						dataRow[2] = dataTable2.Rows[i]["SN"].ToString();
						dataRow[3] = dataTable2.Rows[i]["MaintenancePeriod"].ToString();
						dataRow[4] = dataTable2.Rows[i]["BuyDate"].ToString();
						dataRow[5] = dataTable2.Rows[i]["MaintenanceEnd"].ToString();
						dataRow[6] = dataTable2.Rows[i]["Remark"].ToString();
						dataRow[7] = gridViewSource.Rows.Count;
						dataRow[8] = 0;
						dataRow[9] = 0;
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
		dataRow[9] = 0;
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
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i][0] = FunLibrary.ChkInput(textBox.Text);
			gridViewSource.Rows[i][1] = FunLibrary.ChkInput(textBox2.Text);
			gridViewSource.Rows[i][2] = FunLibrary.ChkInput(textBox3.Text);
			gridViewSource.Rows[i][3] = FunLibrary.ChkInput(textBox4.Text);
			gridViewSource.Rows[i][4] = FunLibrary.ChkInput(textBox5.Text);
			gridViewSource.Rows[i][5] = FunLibrary.ChkInput(textBox6.Text);
			gridViewSource.Rows[i][6] = FunLibrary.ChkInput(textBox7.Text);
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
				dataRow[8] = 0;
				dataRow[9] = 0;
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
					dataRow[8] = 0;
					dataRow[9] = 0;
					gridViewSource.Rows.Add(dataRow);
				}
			}
		}
		this.BindData();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int customerID = 0;
		int num = 0;
		int.TryParse(this.hfCusID.Value, out customerID);
		int.TryParse(this.hfDevID.Value, out num);
		DALServices dALServices = new DALServices();
		ServicesInfo servicesInfo = new ServicesInfo();
		servicesInfo.ID = this.id;
		servicesInfo.TypeID = int.Parse(this.ddlType.SelectedValue);
		servicesInfo.TakeStyleID = int.Parse(this.ddlTake.SelectedValue);
		servicesInfo.Time_Make = FunLibrary.ChkInput(this.tbDate.Text);
		servicesInfo.Time_TakeOver = FunLibrary.ChkInput(this.tbTakeTime.Text);
		servicesInfo.Time_Complete = FunLibrary.ChkInput(this.tbCmpTime.Text);
		servicesInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		servicesInfo.DisposalOper = FunLibrary.ChkInput(this.tbDisposal.Text);
		servicesInfo.CustomerID = customerID;
		servicesInfo.CustomerName = FunLibrary.ChkInput(this.tbCusName.Text);
		servicesInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		servicesInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		servicesInfo.UsePerson = FunLibrary.ChkInput(this.tbUsePerson.Text);
		servicesInfo.UsePersonDept = FunLibrary.ChkInput(this.tbDept.Text);
		servicesInfo.UsePersonTel = FunLibrary.ChkInput(this.tbUsePersonTel.Text);
		servicesInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
		servicesInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
		servicesInfo.ProductBrandID = int.Parse(this.ddlBrand.SelectedValue);
		servicesInfo.ProductClassID = int.Parse(this.ddlClass.SelectedValue);
		servicesInfo.ProductModelID = int.Parse(this.ddlModel.SelectedValue);
		string text = this.ddlModel.SelectedItem.Text;
		servicesInfo.ProductSN1 = FunLibrary.ChkInput(this.tbSN1.Text);
		servicesInfo.ProductSN2 = FunLibrary.ChkInput(this.tbSN2.Text);
		servicesInfo.BuyDate = FunLibrary.ChkInput(this.tbBuyTime.Text);
		servicesInfo.BuyFrom = FunLibrary.ChkInput(this.tbBuyFrom.Text);
		servicesInfo.Aspect = FunLibrary.ChkInput(this.tbAspect.Text);
		servicesInfo.Accessory = FunLibrary.ChkInput(this.tbAcc.Text);
		servicesInfo.Fault = FunLibrary.ChkInput(this.tbFault.Text);
		servicesInfo.WarrantyID = int.Parse(this.ddlRepStatus.SelectedValue);
		servicesInfo.BuyInvoice = FunLibrary.ChkInput(this.tbBuyInvoice.Text);
		decimal num2 = 0m;
		decimal.TryParse(this.tbPoint.Text, out num2);
		servicesInfo.dPoint = num2;
		servicesInfo.bRepair = this.cbRe.Checked;
		servicesInfo.bAgain = this.cbAgain.Checked;
		servicesInfo.SaveID = FunLibrary.ChkInput(this.tbSaveID.Text);
		servicesInfo.SupplierID = FunLibrary.ChkInput(this.tbCorpID.Text);
		servicesInfo.WarrantyChargeCorpID = int.Parse(this.ddlChargeCorp.SelectedValue);
		servicesInfo.SubscribeTime = FunLibrary.ChkInput(this.tbSubTime.Text);
		servicesInfo.SubscribeConnectTime = FunLibrary.ChkInput(this.tbSubContTime.Text);
		decimal.TryParse(this.tbSubPrice.Text, out num2);
		servicesInfo.SubscribePrice = num2;
		decimal.TryParse(this.tbSubCharge.Text, out num2);
		servicesInfo.PreCharge = num2;
		decimal.TryParse(this.tbPostage.Text, out num2);
		servicesInfo.Postage = num2;
		servicesInfo.PostNO = FunLibrary.ChkInput(this.tbPostNO.Text);
		servicesInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		servicesInfo.SndStyleID = int.Parse(this.ddlSndStyle.SelectedValue);
		servicesInfo.ServiceLevelID = int.Parse(this.ddlPRI.SelectedValue);
		servicesInfo.ContractNO = FunLibrary.ChkInput(this.tbContNO.Text);
		servicesInfo.DeviceNO = FunLibrary.ChkInput(this.tbDeviceNO.Text);
		servicesInfo.Path = FunLibrary.ChkInput(this.hfPath.Value);
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<ServicesDeviceConfInfo> list = new List<ServicesDeviceConfInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				string text2 = gridViewSource.Rows[i]["RecID"].ToString();
				if (int.Parse(gridViewSource.Rows[i]["ID"].ToString()) > 0)
				{
					list.Add(new ServicesDeviceConfInfo
					{
						ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString()),
						_Name = gridViewSource.Rows[i]["_Name"].ToString(),
						Parameter = gridViewSource.Rows[i]["Parameter"].ToString(),
						SN = gridViewSource.Rows[i]["SN"].ToString(),
						MaintenancePeriod = gridViewSource.Rows[i]["MaintenancePeriod"].ToString(),
						MaintenanceEnd = gridViewSource.Rows[i]["MaintenanceEnd"].ToString(),
						BuyDate = gridViewSource.Rows[i]["BuyDate"].ToString(),
						Remark = gridViewSource.Rows[i]["Remark"].ToString()
					});
				}
			}
			servicesInfo.ServicesDeviceConfInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"ServicesDeviceConf",
				this.hfdellist.Value
			});
		}
		string str;
		int num3 = dALServices.Update(servicesInfo, list2, out str);
		int num4 = dALServices.UpdateFault(this.id, this.hfFault.Value.Trim().Trim(new char[]
		{
			','
		}));
		string text3 = this.hfAttachs.Value.Trim().Trim(new char[]
		{
			','
		});
		dALServices.UpdateAttachs(this.id, 1, this.hfAttachs.Value.Trim().Trim(new char[]
		{
			','
		}));
		if (num3 == 0)
		{
			DbHelperSQL.InsertErrorLogs(2, int.Parse((string)this.Session["Session_wtUserBID"]), this.id, "修改服务单", 0);
			this.SysInfo("window.alert('操作成功！服务单已保存');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('" + str + "');");
		}
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
}
