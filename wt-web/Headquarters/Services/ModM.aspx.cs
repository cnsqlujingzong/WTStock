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

public partial class Headquarters_Services_ModM : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].Replace("m", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r9"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DataTable dataTable = DALCommon.GetDataList("fw_servicesmaterial", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbGoodsNO.Text = dataTable.Rows[0]["GoodsNO"].ToString();
				this.tbName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbSpec.Text = dataTable.Rows[0]["Spec"].ToString();
				this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
				this.tbUnit.Text = dataTable.Rows[0]["Unit"].ToString();
				this.tbQty.Text = dataTable.Rows[0]["Qty"].ToString();
				this.tbPrice.Text = dataTable.Rows[0]["Price"].ToString();
				this.tbAmount.Text = dataTable.Rows[0]["Total"].ToString();
				this.tbProt.Value = dataTable.Rows[0]["MaintenancePeriod"].ToString();
				this.tbProtEnd.Text = dataTable.Rows[0]["PeriodEndDate"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbSN.Text = dataTable.Rows[0]["SN"].ToString();
				this.tbTaxRate.Text = dataTable.Rows[0]["TaxRate"].ToString().TrimEnd(new char[]
				{
					'0'
				}).TrimEnd(new char[]
				{
					'.'
				});
				this.tbTaxAmount.Text = dataTable.Rows[0]["TaxAmount"].ToString().TrimEnd(new char[]
				{
					'0'
				}).TrimEnd(new char[]
				{
					'.'
				});
				for (int i = 0; i < this.ddlChargeStyle.Items.Count; i++)
				{
					if (this.ddlChargeStyle.Items[i].Text == dataTable.Rows[0]["ChargeStyle"].ToString())
					{
						this.ddlChargeStyle.Items[i].Selected = true;
						break;
					}
				}
				this.cbOutSourcing.Checked = !(dataTable.Rows[0]["OutSourcing"].ToString() == "");
				this.tbOutPrice.Text = dataTable.Rows[0]["OutCostPrice"].ToString();
				decimal d = 0m;
				decimal.TryParse(dataTable.Rows[0]["LQty"].ToString(), out d);
				decimal d2 = 0m;
				decimal.TryParse(dataTable.Rows[0]["Qty"].ToString(), out d2);
				if (d >= d2)
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "备件已领料，请先退料后再修改！";
					this.lbMod.Attributes.Add("class", "si2");
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServicesMaterial dALServicesMaterial = new DALServicesMaterial();
		ServicesMaterialInfo servicesMaterialInfo = new ServicesMaterialInfo();
		servicesMaterialInfo.ID = this.id;
		decimal num = 0m;
		decimal.TryParse(this.tbQty.Text, out num);
		servicesMaterialInfo.Qty = num;
		decimal.TryParse(this.tbPrice.Text, out num);
		servicesMaterialInfo.Price = num;
		servicesMaterialInfo.MaintenancePeriod = this.tbProt.Value;
		servicesMaterialInfo.PeriodEndDate = this.tbProtEnd.Text;
		servicesMaterialInfo.ChargeStyle = this.ddlChargeStyle.SelectedItem.Text;
		servicesMaterialInfo.Remark = this.tbRemark.Text;
		servicesMaterialInfo.SN = this.tbSN.Text;
		servicesMaterialInfo.OutSourcing = this.cbOutSourcing.Checked;
		decimal.TryParse(this.tbOutPrice.Text, out num);
		servicesMaterialInfo.CostPrice = num;
		decimal taxRate = 0m;
		decimal.TryParse(this.tbTaxRate.Text, out taxRate);
		servicesMaterialInfo.TaxRate = taxRate;
		dALServicesMaterial.Update(servicesMaterialInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
