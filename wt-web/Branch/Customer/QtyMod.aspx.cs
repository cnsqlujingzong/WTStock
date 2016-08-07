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

public partial class Branch_Customer_QtyMod : Page, IRequiresSessionState
{
	private int id;



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
			OtherFunction.BindStaff(this.ddlOperator, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			OtherFunction.BindQtyType(this.ddlQty);
			DataTable dataTable = DALCommon.GetDataList("ks_qtylist", "", "[ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbDate.Text = dataTable.Rows[0]["_Date"].ToString();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == dataTable.Rows[0]["Operator"].ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlQty.Items.Count; i++)
				{
					if (this.ddlQty.Items[i].Text == dataTable.Rows[0]["QtyType"].ToString())
					{
						this.ddlQty.Items[i].Selected = true;
						break;
					}
				}
				this.tbQty.Text = dataTable.Rows[0]["Qty"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbAllowance.Text = dataTable.Rows[0]["Allowance"].ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALQtyList dALQtyList = new DALQtyList();
		QtyListInfo qtyListInfo = new QtyListInfo();
		qtyListInfo.ID = this.id;
		qtyListInfo._Date = DateTime.Parse(this.tbDate.Text);
		qtyListInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		int qty = 0;
		int.TryParse(this.tbQty.Text, out qty);
		qtyListInfo.Qty = qty;
		qtyListInfo.QtyType = this.ddlQty.SelectedItem.Text;
		qtyListInfo.Remark = this.tbRemark.Text;
		qtyListInfo.Allowance = this.tbAllowance.Text;
		dALQtyList.Update(qtyListInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
