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
using wt.DB;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Headquarters_Services_SerMod : Page, IRequiresSessionState
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
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALRight dALRight = new DALRight();
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				if (!dALRight.GetRight(num, "gd_r8"))
				{
					this.btnAdd.Enabled = false;
				}
				if (dALRight.GetRight(num, "gd_r35"))
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
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0 and bDestClerk=1");
         //   ddlOperator.SelectedValue = Session["Session_wtUserID"].ToString();
			OtherFunction.BindProductAspect(this.ddlAspect);
			OtherFunction.BindServicesType(this.ddlType);
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindProductModel(this.ddlModel, "");
			OtherFunction.BindWarranty(this.ddlRepStatus);
			OtherFunction.BindArea(this.ddlArea);
			OtherFunction.BindTakeStyle(this.ddlTake);
			OtherFunction.BindSupplier(this.ddlChargeCorp, " bChargeCorp=1 and bStop=0 ");
			OtherFunction.BindSndStyle(this.ddlSndStyle, " DeptID=1 ");
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
			this.ddlChargeCorp.Items.Remove(new ListItem("新建...", "0"));
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
                this.tbTakeTime.Text = dataTable.Rows[0]["Time_TakeOver"] == null ? "" : string.Format("{0:yyyy-MM-dd hh:mm:ss}", Convert.ToDateTime(dataTable.Rows[0]["Time_TakeOver"]));
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

                //by coding 
                this.cmbProvince.SelectedValue = dataTable.Rows[0]["cmbProver"].ToString();
                cmbProvince_SelectedIndexChanged(null,null);
                this.cmbCity.SelectedValue = dataTable.Rows[0]["cmbCity"].ToString();
                this.tbwangdian.Text = dataTable.Rows[0]["BranchName"].ToString();
             
               // string[] s = this.ddl_branchFax.Text.Trim().Split('-');
               // servicesInfo.BranchRatio = Convert.ToDecimal(s[1]);
              //  servicesInfo.BranchRatioType = s[0]; 
                DataTable tb = DALCommon.GetDataList("BranchList", "_Name, CAST(TR_jsfw as varchar(10))+'-'+CAST(TR_zzsxx as varchar(10))+'-'+CAST(TR_zzsjx as varchar(10))+'-'+CAST(TR_ptfp as varchar(10)) as TR ", " [_Name]='" + dataTable.Rows[0]["BranchName"].ToString() + "'").Tables[0];
                CreatDropList(tb);
                if (tb.Rows.Count > 0)
                {
                    ddl_branchFax.SelectedValue = dataTable.Rows[0]["BranchRatioType"].ToString() + "-" + dataTable.Rows[0]["BranchRatio"].ToString();
                }
             
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
                this.tbCmpTime.Text =string.IsNullOrEmpty(dataTable.Rows[0]["Time_Complete"].ToString())?"": string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dataTable.Rows[0]["Time_Complete"]));
				DALCustomerList dALCustomerList = new DALCustomerList();
				this.tbCusLevel.Text = dALCustomerList.getCusMember(int.Parse(this.hfCusID.Value));
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == dataTable.Rows[0]["Operator"].ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
                this.tbDate.Text = dataTable.Rows[0]["Time_Make"] == null ? string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) : string.Format("{0:yyyy-MM-dd hh:mm:ss}", Convert.ToDateTime(dataTable.Rows[0]["Time_Make"]));
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
                this.tbSubTime.Text =string.IsNullOrEmpty( dataTable.Rows[0]["SubscribeTime"].ToString()) ? "" : string.Format("{0:yyyy-MM-dd hh:mm:ss}", Convert.ToDateTime(dataTable.Rows[0]["SubscribeTime"]));//dataTable.Rows[0]["SubscribeTime"].ToString();
				this.tbSubContTime.Text = dataTable.Rows[0]["SubscribeConnectTime"].ToString();
				this.tbSubPrice.Text = dataTable.Rows[0]["SubscribePrice"].ToString();
				this.tbSubCharge.Text = dataTable.Rows[0]["PreCharge"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbPostage.Text = dataTable.Rows[0]["Postage"].ToString();
				this.tbPostNO.Text = dataTable.Rows[0]["PostNO"].ToString();
				this.tbContNO.Text = dataTable.Rows[0]["ContractNO"].ToString();
				this.tbDeviceNO.Text = dataTable.Rows[0]["DeviceNO"].ToString();
				this.hfPath.Value = dataTable.Rows[0]["Path"].ToString();
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
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString() + "," + dataTable.Rows[0]["Tel2"].ToString();
				this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
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
        //by coding 
        servicesInfo.CmbProver = FunLibrary.ChkInput(this.cmbProvince.Text);
        servicesInfo.CmbCity = FunLibrary.ChkInput(this.cmbCity.Text);
        servicesInfo.BranchName = FunLibrary.ChkInput(this.tbwangdian.Text);
        string[] s = this.ddl_branchFax.Text.Trim().Split('-');
        servicesInfo.BranchRatio = Convert.ToDecimal(s[1]);
        servicesInfo.BranchRatioType = s[0]; 

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
				string text = gridViewSource.Rows[i]["RecID"].ToString();
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
		string text2 = this.hfAttachs.Value.Trim().Trim(new char[]
		{
			','
		});
		dALServices.UpdateAttachs(this.id, 1, this.hfAttachs.Value.Trim().Trim(new char[]
		{
			','
		}));
		if (num3 == 0)
		{
			DbHelperSQL.InsertErrorLogs(2, int.Parse((string)this.Session["Session_wtUserID"]), this.id, "修改服务单", 0);
			this.SysInfo("window.alert('操作成功！服务单已保存');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert(\"" + str + "\");");
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
				this.tbModel.Text = this.ddlModel.SelectedItem.Text;
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

    private void CreatDropList(DataTable dataTable)
    {
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
     
        UpdatePanel2.Update();
    }
}
