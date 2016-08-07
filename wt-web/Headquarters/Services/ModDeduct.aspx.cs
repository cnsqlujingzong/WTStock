using System;
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

public partial class Headquarters_Services_ModDeduct : Page, IRequiresSessionState
{
	private int id;

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
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r14"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "Status=0");
			DALBillDeduct dALBillDeduct = new DALBillDeduct();
			BillDeductInfo model = dALBillDeduct.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.StaffID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbDate.Text = model.Time_Finish.ToString("yyyy-MM-dd");
				this.tbDeduct.Text = model.Deduct.ToString("#0.00");
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALBillDeduct dALBillDeduct = new DALBillDeduct();
		BillDeductInfo billDeductInfo = new BillDeductInfo();
		billDeductInfo.ID = this.id;
		billDeductInfo.Time_Finish = DateTime.Parse(this.tbDate.Text);
		billDeductInfo.StaffID = int.Parse(this.ddlOperator.SelectedValue);
		decimal deduct = 0m;
		decimal.TryParse(this.tbDeduct.Text, out deduct);
		billDeductInfo.Deduct = deduct;
		dALBillDeduct.Update(billDeductInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
