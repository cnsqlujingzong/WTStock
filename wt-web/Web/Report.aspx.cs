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

public partial class Web_Report : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		if (!base.IsPostBack)
		{
			this.tbTimeTake.Text = DateTime.Now.ToString();
			OtherFunction.BindProductAspect(this.ddlAspect);
			OtherFunction.BindServicesType(this.ddlType);
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindProductModel(this.ddlModel, "");
			OtherFunction.BindWarranty(this.ddlRepStatus);
			OtherFunction.BindArea(this.ddlArea);
			OtherFunction.BindSndStyle(this.ddlSndStyle, " DeptID=1 ");
			OtherFunction.BindServiceLevel(this.ddlPRI);
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlArea.Items.Remove(new ListItem("新建...", "0"));
			this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
			this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
			this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
			this.ddlRepStatus.Items.Remove(new ListItem("新建...", "0"));
			DALAssociator dALAssociator = new DALAssociator();
			AssociatorInfo model = dALAssociator.GetModel((string)this.Session["Session_Web_Name"]);
			if (model != null)
			{
				this.hfCusID.Value = model.CustomerID.ToString();
			}
			if (this.hfCusID.Value != string.Empty)
			{
				DALCustomerList dALCustomerList = new DALCustomerList();
				CustomerListInfo model2 = dALCustomerList.GetModel(int.Parse(this.hfCusID.Value));
				if (model2 != null)
				{
					this.tbCusName.Text = model2._Name;
					this.tbLinkMan.Text = model2.LinkMan;
					this.tbTel.Text = model2.Tel;
					this.tbAdr.Text = model2.Adr;
					this.tbArea.Text = model2.Area;
				}
				this.ddlDept.DataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
				this.ddlDept.DataTextField = "_Name";
				this.ddlDept.DataValueField = "ID";
				this.ddlDept.DataBind();
				this.ddlDept.Items.Insert(0, new ListItem("", ""));
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int customerID = 0;
		int num = 0;
		int.TryParse(this.hfCusID.Value, out customerID);
		int.TryParse(this.hfDevID.Value, out num);
		DALNetServices dALNetServices = new DALNetServices();
		NetServicesInfo netServicesInfo = new NetServicesInfo();
		int assID;
		int.TryParse((string)this.Session["Session_Web_ID"], out assID);
		netServicesInfo.AssID = assID;
		netServicesInfo.Status = "待审核";
		netServicesInfo.TypeID = int.Parse(this.ddlType.SelectedValue);
		netServicesInfo._Date = DateTime.Now.ToString();
		netServicesInfo.CustomerID = customerID;
		netServicesInfo.CustomerName = FunLibrary.ChkInput(this.tbCusName.Text);
		netServicesInfo.DeviceNO = FunLibrary.ChkInput(this.tbDeviceNO.Text);
		string text = FunLibrary.ChkInput(this.tbUsePerson.Text);
		string text2 = FunLibrary.ChkInput(this.tbUsePersonTel.Text);
		if (text == "")
		{
			text = FunLibrary.ChkInput(this.tbLinkMan.Text);
		}
		if (text2 == "")
		{
			text2 = FunLibrary.ChkInput(this.tbTel.Text);
		}
		netServicesInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		netServicesInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		netServicesInfo.UsePerson = text;
		netServicesInfo.UsePersonDept = FunLibrary.ChkInput(this.tbDept.Text);
		netServicesInfo.UsePersonTel = text2;
		netServicesInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
		netServicesInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
		netServicesInfo.ProductBrandID = int.Parse(this.ddlBrand.SelectedValue);
		netServicesInfo.ProductClassID = int.Parse(this.ddlClass.SelectedValue);
		netServicesInfo.ProductModelID = int.Parse(this.ddlModel.SelectedValue);
		netServicesInfo.ProductSN1 = FunLibrary.ChkInput(this.tbSN1.Text);
		netServicesInfo.ProductSN2 = FunLibrary.ChkInput(this.tbSN2.Text);
		netServicesInfo.Aspect = FunLibrary.ChkInput(this.tbAspect.Text);
		netServicesInfo.Accessory = FunLibrary.ChkInput(this.tbAcc.Text);
		netServicesInfo.Fault = FunLibrary.ChkInput(this.tbFault.Text);
		netServicesInfo.WarrantyID = int.Parse(this.ddlRepStatus.SelectedValue);
		netServicesInfo.BuyInvoice = FunLibrary.ChkInput(this.tbBuyInvoice.Text);
		netServicesInfo.BuyDate = FunLibrary.ChkInput(this.tbBuyTime.Text);
		netServicesInfo.BuyFrom = FunLibrary.ChkInput(this.tbBuyFrom.Text);
		netServicesInfo.SubscribeTime = FunLibrary.ChkInput(this.tbSubTime.Text);
		decimal postage;
		decimal.TryParse(this.tbPostage.Text, out postage);
		netServicesInfo.Postage = postage;
		netServicesInfo.PostNO = FunLibrary.ChkInput(this.tbPostNO.Text);
		netServicesInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		netServicesInfo.SndStyleID = int.Parse(this.ddlSndStyle.SelectedValue);
		netServicesInfo.ServiceLevelID = int.Parse(this.ddlPRI.SelectedValue);
		netServicesInfo.IBranch = int.Parse(this.ddlBranch.SelectedValue);
		string text3;
		int num3;
		int num2 = dALNetServices.Add(netServicesInfo, out text3, out num3);
		if (num2 == 0)
		{
			base.ClientScript.RegisterStartupScript(base.GetType(), "notice", "alert(\"提交成功！请耐心等待，我们会尽快联系您.\");", true);
			this.tbTimeTake.Text = DateTime.Now.ToString();
			this.ClearText();
		}
		else
		{
			base.ClientScript.RegisterStartupScript(base.GetType(), "notice", "alert(\"系统错误！请联系我们\");", true);
		}
	}

	protected void ClearText()
	{
		this.tbBrand.Text = string.Empty;
		this.tbClass.Text = string.Empty;
		this.tbModel.Text = string.Empty;
		for (int i = 0; i < this.ddlBrand.Items.Count; i++)
		{
			if (this.ddlBrand.Items[i].Text == "")
			{
				this.ddlBrand.Items[i].Selected = false;
				break;
			}
		}
		for (int i = 0; i < this.ddlClass.Items.Count; i++)
		{
			if (this.ddlClass.Items[i].Text == "")
			{
				this.ddlClass.Items[i].Selected = false;
				break;
			}
		}
		for (int i = 0; i < this.ddlModel.Items.Count; i++)
		{
			if (this.ddlModel.Items[i].Text == "")
			{
				this.ddlModel.Items[i].Selected = false;
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
		this.tbSubTime.Text = string.Empty;
		this.tbRemark.Text = string.Empty;
		this.hfDevID.Value = string.Empty;
		this.tbPostNO.Text = string.Empty;
		this.tbPostage.Text = string.Empty;
		this.tbDeviceNO.Text = "";
		for (int i = 0; i < this.ddlSndStyle.Items.Count; i++)
		{
			if (this.ddlSndStyle.Items[i].Text == "")
			{
				this.ddlSndStyle.Items[i].Selected = false;
				break;
			}
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
		this.tbModel.Text = "";
		OtherFunction.BindProductModel(this.ddlModel, text);
		this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
	}

	public void ChkWebUser()
	{
		if (this.Session["Session_Web_Name"] == null || this.Session["Session_Web_ID"] == null)
		{
			base.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
			base.Response.End();
		}
	}
}
