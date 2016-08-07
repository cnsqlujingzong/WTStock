using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;

public partial class Web_ReportView : Page, IRequiresSessionState
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
			DataTable dataTable = DALCommon.GetDataList("fw_netservices", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbTimeTake.Text = dataTable.Rows[0]["_Date"].ToString();
				this.ddlType.Items.Add(new ListItem(dataTable.Rows[0]["ServicesType"].ToString(), dataTable.Rows[0]["ServicesType"].ToString()));
				this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbUsePerson.Text = dataTable.Rows[0]["UsePerson"].ToString();
				this.tbDept.Value = dataTable.Rows[0]["UsePersonDept"].ToString();
				this.tbUsePersonTel.Text = dataTable.Rows[0]["UsePersonTel"].ToString();
				this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
				this.tbClass.Text = dataTable.Rows[0]["ProductClass"].ToString();
				this.tbModel.Text = dataTable.Rows[0]["ProductModel"].ToString();
				this.tbAspect.Text = dataTable.Rows[0]["Aspect"].ToString();
				this.tbSN1.Text = dataTable.Rows[0]["ProductSN1"].ToString();
				this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
				this.tbAcc.Text = dataTable.Rows[0]["Accessory"].ToString();
				this.tbBuyTime.Text = dataTable.Rows[0]["BuyDate"].ToString();
				this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
				this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
				this.tbDeviceNO.Text = dataTable.Rows[0]["DeviceNO"].ToString();
				this.ddlRepStatus.Items.Add(new ListItem(dataTable.Rows[0]["Warranty"].ToString(), dataTable.Rows[0]["Warranty"].ToString()));
				this.ddlPRI.Items.Add(new ListItem(dataTable.Rows[0]["ServiceLevel"].ToString(), dataTable.Rows[0]["ServiceLevel"].ToString()));
				this.ddlSndStyle.Items.Add(new ListItem(dataTable.Rows[0]["SndStyle"].ToString(), dataTable.Rows[0]["SndStyle"].ToString()));
				this.tbFault.Text = dataTable.Rows[0]["Fault"].ToString();
				this.tbSubTime.Text = dataTable.Rows[0]["SubscribeTime"].ToString();
				this.tbPostNO.Text = dataTable.Rows[0]["PostNO"].ToString();
				this.tbPostage.Text = dataTable.Rows[0]["Postage"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
			}
		}
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
