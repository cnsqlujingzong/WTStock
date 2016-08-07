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

public partial class Headquarters_Customer_ComtAdd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r25"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, " DeptID=1 ");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlDoOperator, " DeptID=1 ");
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
			if (this.hfCusID.Value == "-1")
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
			complaintInfo.Status = "待处理";
			complaintInfo.CustomerID = int.Parse(this.hfCusID.Value);
			DALComplaint dALComplaint = new DALComplaint();
			dALComplaint.Add(complaintInfo);
			this.SysInfo("window.alert('操作成功！该投诉信息已建立');parent.CloseDialog('1');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
