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

public partial class Headquarters_Services_NewDeduct : Page, IRequiresSessionState
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
			DataTable dataTable = DALCommon.GetDataList("ServicesList", "", "[ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.hfDept.Value = dataTable.Rows[0]["DisposalID"].ToString();
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "Status=0");
			OtherFunction.BindBranch(this.ddlDept);
			this.ddlDept.Items.Insert(0, new ListItem(""));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALBillDeduct dALBillDeduct = new DALBillDeduct();
		BillDeductInfo billDeductInfo = new BillDeductInfo();
		billDeductInfo.BillID = this.id;
		billDeductInfo.Time_Finish = DateTime.Parse(this.tbDate.Text);
		billDeductInfo.StaffID = int.Parse(this.ddlOperator.SelectedValue);
		decimal deduct = 0m;
		decimal.TryParse(this.tbDeduct.Text, out deduct);
		billDeductInfo.Deduct = deduct;
		billDeductInfo.DeptID = int.Parse(this.hfDept.Value);
		string str = "";
		int num = 0;
		int num2 = dALBillDeduct.Add(billDeductInfo, out str, out num);
		if (num2 == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert(\"" + str + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlDept.SelectedValue != "")
		{
			OtherFunction.BindStaff(this.ddlOperator, "Status=0 and DeptID=" + this.ddlDept.SelectedValue);
		}
	}
}
