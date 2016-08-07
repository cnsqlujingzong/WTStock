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

public partial class Headquarters_Customer_ComtMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "kh_r26"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, " DeptID=1 ");
			OtherFunction.BindStaff(this.ddlDoOperator, " DeptID=1 ");
			DataTable dataTable = DALCommon.GetDataList("ks_complaint", "", " [ID]=" + this.id).Tables[0];
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
				for (int i = 0; i < this.ddlDoOperator.Items.Count; i++)
				{
					if (this.ddlDoOperator.Items[i].Text == dataTable.Rows[0]["DoOperator"].ToString())
					{
						this.ddlDoOperator.Items[i].Selected = true;
						break;
					}
				}
				this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbContent.Text = dataTable.Rows[0]["Content"].ToString();
				this.tbOperationID.Text = dataTable.Rows[0]["OperationID"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
				if (dataTable.Rows[0]["Status"].ToString() == "已审核")
				{
					this.lbMod.Text = "该投诉已处理，不能再次处理";
					this.lbMod.Attributes.Add("class", "si3");
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnCusInfo_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "LinkMan,Tel,Adr", " [ID]=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		ComplaintInfo complaintInfo = new ComplaintInfo();
		complaintInfo.ID = this.id;
		complaintInfo._Date = DateTime.Parse(this.tbDate.Text);
		complaintInfo.OpetatorID = int.Parse(this.ddlOperator.SelectedValue);
		DALCustomerList dALCustomerList = new DALCustomerList();
		DataTable dataTable = dALCustomerList.GetCusData(this.tbCusName.Text.Trim()).Tables[0];
		if (dataTable.Rows.Count <= 0)
		{
			this.SysInfo("window.alert('该客户不存在，请先在客户列表中添加!')");
		}
		else
		{
			if (this.hfCusID.Value == "")
			{
				if (dataTable.Rows.Count > 1)
				{
					this.SysInfo("window.alert('该客户信息存在多条，请客户列表中选择!')");
					return;
				}
				if (dataTable.Rows.Count == 1)
				{
					this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
				}
			}
			complaintInfo.CustomerName = this.tbCusName.Text;
			complaintInfo.LinkMan = this.tbLinkMan.Text;
			complaintInfo.Tel = this.tbTel.Text;
			complaintInfo.Content = this.tbContent.Text;
			complaintInfo.DoOperator = this.ddlDoOperator.SelectedItem.Text;
			complaintInfo.OperationID = this.tbOperationID.Text;
			complaintInfo.Remark = this.tbRemark.Text;
			complaintInfo.CustomerID = int.Parse(this.hfCusID.Value);
			DALComplaint dALComplaint = new DALComplaint();
			dALComplaint.Update(complaintInfo);
			this.SysInfo("window.alert('操作成功！该投诉信息已保存');parent.CloseDialog('1');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
