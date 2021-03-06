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

public partial class Headquarters_Services_ModO : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].ToString().Replace("o", ""), out this.id);
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
				if (!dALRight.GetRight(num, "gd_r22"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			DataTable dataTable = DALCommon.GetDataList("fw_servicesoffer", "", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbDate.Text = dataTable.Rows[0]["_Date"].ToString();
				string b = dataTable.Rows[0]["Seller"].ToString();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == b)
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbAmount.Text = dataTable.Rows[0]["dAmount"].ToString();
				if (dataTable.Rows[0]["CusConf"].ToString() != "")
				{
					this.cbCusConf.Checked = true;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServiceOffer dALServiceOffer = new DALServiceOffer();
		ServiceOfferInfo serviceOfferInfo = new ServiceOfferInfo();
		serviceOfferInfo.ID = this.id;
		serviceOfferInfo._Date = this.tbDate.Text;
		serviceOfferInfo.SellerID = int.Parse(this.ddlOperator.SelectedValue);
		decimal dAmount = 0m;
		decimal.TryParse(this.tbAmount.Text, out dAmount);
		serviceOfferInfo.dAmount = dAmount;
		serviceOfferInfo.bCusConf = this.cbCusConf.Checked;
		serviceOfferInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		dALServiceOffer.Update(serviceOfferInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
