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

public partial class Web_DeviceView : Page, IRequiresSessionState
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
			DataTable dataTable = DALCommon.GetDataList("ks_device", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				DALAssociator dALAssociator = new DALAssociator();
				AssociatorInfo model = dALAssociator.GetModel((string)this.Session["Session_Web_Name"]);
				if (model != null)
				{
					if (!(model.CustomerID.ToString() != dataTable.Rows[0]["CustomerID"].ToString()))
					{
						this.tbName.Text = dataTable.Rows[0]["LinkMan"].ToString();
						this.tbDept.Text = dataTable.Rows[0]["CusDept"].ToString();
						this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
						this.tbTel2.Text = dataTable.Rows[0]["Tel2"].ToString();
						this.tbFax.Text = dataTable.Rows[0]["Fax"].ToString();
						this.tbZip.Text = dataTable.Rows[0]["Zip"].ToString();
						this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
						this.tbDeviceNO.Text = dataTable.Rows[0]["DeviceNO"].ToString();
						this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
						this.tbClass.Text = dataTable.Rows[0]["ProductClass"].ToString();
						this.tbModel.Text = dataTable.Rows[0]["ProductModel"].ToString();
						this.tbSN1.Text = dataTable.Rows[0]["ProductSN1"].ToString();
						this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
						this.tbAspect.Text = dataTable.Rows[0]["ProductAspect"].ToString();
						this.tbBuyDate.Text = dataTable.Rows[0]["BuyDate"].ToString();
						this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
						this.tbInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
						this.tbInStall.Text = dataTable.Rows[0]["InstallDate"].ToString();
						this.tbProt.Text = dataTable.Rows[0]["MaintenancePeriod"].ToString();
						this.tbRepStatus.Text = dataTable.Rows[0]["Warranty"].ToString();
						this.tbWStart.Text = dataTable.Rows[0]["WarrantyStart"].ToString();
						this.tbWEnd.Text = dataTable.Rows[0]["WarrantyEnd"].ToString();
						this.tbRepNum.Text = dataTable.Rows[0]["RepairTimes"].ToString();
						this.tbFinD.Text = dataTable.Rows[0]["RepairWarrantyEnd"].ToString();
						this.tbLastDate.Text = dataTable.Rows[0]["Repairlately"].ToString();
						this.tbPStart.Text = dataTable.Rows[0]["ContractWarrantyStart"].ToString();
						this.tbPEnd.Text = dataTable.Rows[0]["ContractWarrantyEnd"].ToString();
						this.tbContractNO.Text = dataTable.Rows[0]["ContractNO"].ToString();
						this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
						string strCondition = string.Concat(new string[]
						{
							" ProductSN1='",
							dataTable.Rows[0]["ProductSN1"].ToString(),
							"' and DeviceNO='",
							dataTable.Rows[0]["DeviceNO"].ToString(),
							"' and CustomerID=",
							dataTable.Rows[0]["CustomerID"].ToString()
						});
						this.GridView1.DataSource = DALCommon.GetDataList("fw_services", "", strCondition);
						this.GridView1.DataBind();
					}
				}
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.bgColor='#ffffd1'");
			e.Row.Attributes.Add("onmouseout", "this.bgColor=''");
			e.Row.Cells[10].Text = "<a href=\"SerView.aspx?id=" + e.Row.Cells[0].Text + "\" title=\"查看详细信息\">查看</a>";
			string text = e.Row.Cells[3].Text;
			if (text == "待处理")
			{
				e.Row.Cells[3].Text = "<span style=\"color:#fff;background:#ff0000\">" + text + "</span>";
			}
			else if (text == "待结算")
			{
				e.Row.Cells[3].Text = "<span style=\"color:#fff;background:#0000ff\">" + text + "</span>";
			}
			else if (text == "待回访")
			{
				e.Row.Cells[3].Text = "<span style=\"color:#fff;background:#008000\">" + text + "</span>";
			}
			else if (text == "已取消")
			{
				e.Row.Cells[3].Text = "<span style=\"color:#fff;background:#848284\">" + text + "</span>";
			}
			else if (text == "已结束")
			{
				e.Row.Cells[3].Text = "<span style=\"color:#fff;background:#840000\">" + text + "</span>";
			}
			else if (text == "送修")
			{
				e.Row.Cells[3].Text = "<span style=\"color:#fff;background:#8a4000\">" + text + "</span>";
			}
			else if (text == "待审核")
			{
				e.Row.Cells[3].Text = "<span style=\"color:#fff;background:#333\">" + text + "</span>";
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
