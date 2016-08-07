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

public partial class Headquarters_Lease_LeaseView : Page, IRequiresSessionState
{

	private int id;

	private string ids;

	private string f;

	private static string leaseType = string.Empty;

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		this.ids = base.Request["ids"];
		if (this.id == 0 && this.ids == null)
		{
			base.Response.End();
		}
		this.f = base.Request["f"];
		if (this.f == null || this.f == "")
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r14"))
				{
					this.lbMod.Text = "你没有修改业务的权限！";
					this.lbMod.Attributes.Add("class", "si2");
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0 and bSeller=1");
			string strCondition;
			if (this.id == 0)
			{
				strCondition = " BillID='" + this.ids + "'";
			}
			else
			{
				strCondition = " [ID]=" + this.id;
			}
			DataTable dataTable = DALCommon.GetDataList("zl_lease", "", strCondition).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.id = int.Parse(dataTable.Rows[0]["ID"].ToString());
				this.tbBillID.Text = dataTable.Rows[0]["BillID"].ToString();
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
				this.hfPrintID.Value = this.id.ToString();
				Headquarters_Lease_LeaseView.leaseType = (this.tbType.Text = dataTable.Rows[0]["Type"].ToString());
				this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.tbAutoNO.Text = dataTable.Rows[0]["ContractNO"].ToString();
				this.tbDeposit.Text = dataTable.Rows[0]["Deposit"].ToString();
				this.tbRent.Text = dataTable.Rows[0]["Rent"].ToString();
				this.tbStartDate.Text = dataTable.Rows[0]["StartDate"].ToString();
				this.tbEndDate.Text = dataTable.Rows[0]["EndDate"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbChargeCycle.Text = dataTable.Rows[0]["ChargeCycle"].ToString();
				this.hfPath.Value = dataTable.Rows[0]["Accessory"].ToString();
				if (this.hfPath.Value != "")
				{
					string text = this.hfPath.Value.Substring(this.hfPath.Value.LastIndexOf('/') + 1);
					this.dUpload.InnerHtml = string.Concat(new string[]
					{
						"<img src='../../Public/Images/dmony.gif' /> <a href=\"",
						this.hfPath.Value,
						"\" target=_blank >",
						text,
						"</a>"
					});
				}
				if (dataTable.Rows[0]["curStatus"].ToString() != "正常")
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "只有正常的业务单据才能修改！";
					this.lbMod.Attributes.Add("class", "si2");
				}
			}
			this.gvdata.DataSource = DALCommon.GetDataList("zl_leasedevice", "", " BillID=" + this.id);
			this.gvdata.DataBind();
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (Headquarters_Lease_LeaseView.leaseType == "非抄表类租赁")
		{
			e.Row.Cells[12].Visible = false;
			e.Row.Cells[13].Visible = false;
		}
		else
		{
			e.Row.Cells[5].Visible = false;
			e.Row.Cells[6].Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[13].Text = "<a href=\"#\" onclick=\"ViewQty('" + e.Row.Cells[0].Text + "')\">查看计数器</a>";
		}
	}

	protected void btnCusInfo_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "_Name,LinkMan,Tel,Adr", " ID=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				return;
			}
		}
		string text = FunLibrary.ChkInput(this.tbCusName.Text);
		if (text != "")
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "[ID],_Name,LinkMan,Tel,Adr", " _Name='" + text + "'").Tables[0];
			if (dataTable.Rows.Count > 1)
			{
				this.SysInfo("ConfCusInfo();");
			}
			else if (dataTable.Rows.Count == 1)
			{
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
			}
			else
			{
				this.hfCusID.Value = "";
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string str = "";
		int num = 0;
		int.TryParse(this.hfCusID.Value, out num);
		int num2 = 0;
		if (num > 0)
		{
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "[ID]", string.Concat(new object[]
			{
				" [ID]=",
				num,
				" and _Name='",
				FunLibrary.ChkInput(this.tbCusName.Text),
				"'"
			})).Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				num2 = 1;
			}
		}
		int num3;
		if (num == 0 || num2 == 1)
		{
			CustomerListInfo customerListInfo = new CustomerListInfo();
			customerListInfo.DeptID = new int?(1);
			customerListInfo._Name = FunLibrary.ChkInput(this.tbCusName.Text);
			customerListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbCusName.Text));
			customerListInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
			customerListInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
			customerListInfo.SellerID = new int?(int.Parse(this.ddlOperator.SelectedValue));
			customerListInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
			customerListInfo.OperatorID = int.Parse((string)this.Session["Session_wtUserID"]);
			DALCustomerList dALCustomerList = new DALCustomerList();
			num3 = dALCustomerList.Add(customerListInfo, true, out str, out num);
			if (num3 != 0)
			{
				this.SysInfo("window.alert('" + str + "');");
				return;
			}
		}
		LeaseInfo leaseInfo = new LeaseInfo();
		leaseInfo.ID = this.id;
		leaseInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		leaseInfo.SellerID = int.Parse(this.ddlOperator.SelectedValue);
		leaseInfo.CustomerID = num;
		leaseInfo.CustomerName = FunLibrary.ChkInput(this.tbCusName.Text);
		leaseInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		leaseInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		leaseInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
		leaseInfo.ContractNO = FunLibrary.ChkInput(this.tbAutoNO.Text);
		leaseInfo.StartDate = FunLibrary.ChkInput(this.tbStartDate.Text);
		leaseInfo.EndDate = FunLibrary.ChkInput(this.tbEndDate.Text);
		decimal rent = 0m;
		decimal.TryParse(this.tbRent.Text, out rent);
		leaseInfo.Rent = rent;
		int chargeCycle = 0;
		int.TryParse(this.tbChargeCycle.Text, out chargeCycle);
		leaseInfo.ChargeCycle = chargeCycle;
		leaseInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		leaseInfo.Accessory = this.hfPath.Value;
		DALLease dALLease = new DALLease();
		num3 = dALLease.Update(leaseInfo, (string)this.Session["Session_wtUserID"], out str);
		if (num3 == 0)
		{
			this.SysInfo("window.alert(\"操作成功！业务单已保存\");parent.CloseDialog('1');");
		}
		else if (num3 == -1)
		{
			this.SysInfo("window.alert('" + str + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
