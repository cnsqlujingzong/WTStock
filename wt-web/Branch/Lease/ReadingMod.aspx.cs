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

public partial class Branch_Lease_ReadingMod : Page, IRequiresSessionState
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
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r15"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]) + " and Status=0");
			DataTable dataTable = DALCommon.GetDataList("zl_meterreading", "", " ID=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbDate.Text = dataTable.Rows[0]["_Date"].ToString();
				string b = dataTable.Rows[0]["Operator"].ToString();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == b)
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbQtyType.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbQty.Text = dataTable.Rows[0]["Qty"].ToString();
				this.tbLoss.Text = dataTable.Rows[0]["Loss"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["WRemark"].ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALMeterReading dALMeterReading = new DALMeterReading();
		dALMeterReading.Update(new MeterReadingInfo
		{
			ID = this.id,
			_Date = this.tbDate.Text,
			OperatorID = int.Parse(this.ddlOperator.SelectedValue),
			Qty = int.Parse(this.tbQty.Text),
			Loss = int.Parse(this.tbLoss.Text),
			Remark = FunLibrary.ChkInput(this.tbRemark.Text)
		});
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
