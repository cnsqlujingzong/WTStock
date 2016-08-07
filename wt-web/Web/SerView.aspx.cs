using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Model;

public partial class Web_SerView : Page, IRequiresSessionState
{

	private int id;



	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				DALAssociator dALAssociator = new DALAssociator();
				AssociatorInfo model = dALAssociator.GetModel((string)this.Session["Session_Web_Name"]);
				if (model != null)
				{
					if (!(model.CustomerID.ToString() != dataTable.Rows[0]["CustomerID"].ToString()))
					{
						this.tbUsePerson.Text = dataTable.Rows[0]["LinkMan"].ToString();
						this.tbUsePersonTel.Text = dataTable.Rows[0]["Tel"].ToString();
						this.tbDept.Text = dataTable.Rows[0]["UsePersonDept"].ToString();
						this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
						this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
						this.ddlcurStatus.Items.Insert(0, new ListItem(dataTable.Rows[0]["curStatus"].ToString(), dataTable.Rows[0]["curStatus"].ToString()));
						this.ddlOpType.Items.Insert(0, new ListItem(dataTable.Rows[0]["ServicesType"].ToString(), dataTable.Rows[0]["ServicesType"].ToString()));
						this.ddlSndStyle.Items.Insert(0, new ListItem(dataTable.Rows[0]["SndStyle"].ToString(), dataTable.Rows[0]["SndStyle"].ToString()));
						this.ddlServiceLevel.Items.Insert(0, new ListItem(dataTable.Rows[0]["_PRI"].ToString(), dataTable.Rows[0]["_PRI"].ToString()));
						this.tbTakeTime.Text = dataTable.Rows[0]["Time_Make"].ToString();
						this.tbTakeOver.Text = dataTable.Rows[0]["Time_Over"].ToString();
						this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
						this.tbSubTime.Text = dataTable.Rows[0]["SubscribeTime"].ToString();
						this.tbStyle.Value = dataTable.Rows[0]["ProductModel"].ToString();
						this.tbType.Value = dataTable.Rows[0]["ProductClass"].ToString();
						this.tbBrand.Value = dataTable.Rows[0]["ProductBrand"].ToString();
						this.tbSN1.Text = dataTable.Rows[0]["ProductSN1"].ToString();
						this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
						this.tbAcc.Text = dataTable.Rows[0]["Accessory"].ToString();
						this.tbAspect.Value = dataTable.Rows[0]["Aspect"].ToString();
						this.ddlStatus.Items.Insert(0, new ListItem(dataTable.Rows[0]["Warranty"].ToString(), dataTable.Rows[0]["Warranty"].ToString()));
						this.tbBuyDate.Text = dataTable.Rows[0]["BuyDate"].ToString();
						this.tbBuyStore.Value = dataTable.Rows[0]["BuyFrom"].ToString();
						this.tbFault.Text = dataTable.Rows[0]["Fault"].ToString();
						this.tbDeviceNO.Text = dataTable.Rows[0]["DeviceNO"].ToString();
						this.tbPostage.Text = dataTable.Rows[0]["Postage"].ToString();
						this.tbPostNO.Text = dataTable.Rows[0]["PostNO"].ToString();
						this.FillData();
						this.FillItemData();
					}
				}
			}
		}
	}

	protected void FillData()
	{
		this.GridView1.DataSource = DALCommon.GetDataList("fw_servicesmaterial", "", " [BillID]=" + this.id.ToString() + " and ChargeStyle='客付'").Tables[0];
		this.GridView1.DataBind();
	}

	protected void FillItemData()
	{
		this.GridView2.DataSource = DALCommon.GetDataList("fw_servicesitem", "", " [BillID]=" + this.id.ToString() + " and ChargeStyle='客付'").Tables[0];
		this.GridView2.DataBind();
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
