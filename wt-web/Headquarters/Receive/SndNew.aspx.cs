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

public partial class Headquarters_Receive_SndNew : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "fh_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "fh_r2"))
				{
					this.btnConfSnd.Enabled = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(25, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("", "-1"));
			this.ddlBranch.Items.Remove(new ListItem("总部", "1"));
			OtherFunction.BindSndStyle(this.ddlShipStyle, " DeptID=1 ");
			this.ddlBranch.Enabled = false;
		}
	}

	protected void btnConfSnd_Click(object sender, EventArgs e)
	{
		int iTbid;
		int num = this.BillAdd(out iTbid);
		if (num == 0)
		{
			string empty = string.Empty;
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			num = dALRcvSnd.ConfSnd(iTbid, int.Parse(this.ddlShipStyle.SelectedValue), FunLibrary.ChkInput(this.tbSndNo.Text), out empty);
			if (num == 0)
			{
				this.BuildAccount();
				this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！该发货单转入待收货确认');");
			}
			else
			{
				this.SysInfo("window.alert(\"" + empty + "\");");
			}
			this.ClearText();
			this.hfPrintID.Value = iTbid.ToString();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num;
		if (this.BillAdd(out num) == 0)
		{
			this.SysInfo("window.alert('操作成功！发货单已生成');");
			this.ClearText();
			this.hfPrintID.Value = num.ToString();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected int BillAdd(out int iTbid)
	{
		RcvSndInfo rcvSndInfo = new RcvSndInfo();
		rcvSndInfo.DeptID = new int?(1);
		rcvSndInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		rcvSndInfo.OperatorID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		rcvSndInfo.PersonID = new int?(int.Parse(this.Session["Session_wtUserID"].ToString()));
		rcvSndInfo.OperationType = this.ddlSndType.SelectedItem.Text;
		rcvSndInfo.RcvType = this.ddlRcvObj.SelectedItem.Text;
		rcvSndInfo.RcvDeptID = new int?(int.Parse(this.ddlBranch.SelectedValue));
		rcvSndInfo.CorpName = this.tbCusName.Text;
		rcvSndInfo.LinkMan = this.tbLinkMan.Text;
		rcvSndInfo.Tel = this.tbTel.Text;
		rcvSndInfo.Adr = this.tbAdr.Text;
		rcvSndInfo.Zip = this.tbZip.Text;
		rcvSndInfo.Summary = this.tbSummary.Text;
		rcvSndInfo.SndStyleID = new int?(int.Parse(this.ddlShipStyle.SelectedValue));
		rcvSndInfo.PostNO = this.tbSndNo.Text;
		rcvSndInfo.Postage = new decimal?((this.tbPostage.Text.Trim() == string.Empty) ? 0m : decimal.Parse(this.tbPostage.Text));
		rcvSndInfo.Remark = this.tbRemark.Text;
		DALRcvSnd dALRcvSnd = new DALRcvSnd();
		int result = dALRcvSnd.Add(rcvSndInfo, out iTbid);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(25, 0);
		this.tbCusName.Text = string.Empty;
		this.tbLinkMan.Text = string.Empty;
		this.tbTel.Text = string.Empty;
		this.tbZip.Text = string.Empty;
		this.tbAdr.Text = string.Empty;
		this.ddlBranch.ClearSelection();
		this.tbSummary.Text = string.Empty;
		this.ddlShipStyle.ClearSelection();
		this.tbPostage.Text = string.Empty;
		this.tbSndNo.Text = string.Empty;
		this.tbRemark.Text = string.Empty;
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void ddlRcvObj_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlRcvObj.SelectedItem.Text == "网点")
		{
			this.ddlBranch.Enabled = true;
		}
		else
		{
			this.ddlBranch.Enabled = false;
		}
		this.tbCusName.Text = string.Empty;
		this.tbLinkMan.Text = string.Empty;
		this.tbTel.Text = string.Empty;
		this.tbZip.Text = string.Empty;
		this.tbAdr.Text = string.Empty;
	}

	protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlBranch.SelectedValue != "-1")
		{
			DataTable dataTable = DALCommon.GetDataList("BranchList", "", "[ID]=" + this.ddlBranch.SelectedValue).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["CorpName"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbZip.Text = dataTable.Rows[0]["Zip"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
			}
		}
	}

	protected int BuildAccount()
	{
		int result;
		if (string.IsNullOrEmpty(this.tbPostage.Text))
		{
			result = -1;
		}
		else if (this.ddlShipStyle.SelectedValue == "-1")
		{
			result = -1;
		}
		else
		{
			string text = this.ddlShipStyle.SelectedItem.Text;
			DALCustomerList dALCustomerList = new DALCustomerList();
			bool flag = dALCustomerList.ExistCus(text);
			if (flag)
			{
				IncomeExpensesInfo incomeExpensesInfo = new IncomeExpensesInfo();
				incomeExpensesInfo.DeptID = new int?(1);
				incomeExpensesInfo._Date = DateTime.Now.ToShortDateString();
				incomeExpensesInfo.PersonID = new int?(int.Parse(this.Session["Session_wtUserID"].ToString()));
				incomeExpensesInfo.RecType = "其他付款";
				incomeExpensesInfo.CusType = new int?(1);
				incomeExpensesInfo.CustomerID = new int?(dALCustomerList.getCustomerID(text));
				incomeExpensesInfo.DueMoney = decimal.Parse(this.tbPostage.Text);
				incomeExpensesInfo.RealDueMoney = incomeExpensesInfo.DueMoney;
				incomeExpensesInfo.Remark = "快递发货产生的相关运费";
				string empty = string.Empty;
				DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
				int num2;
				int num = dALIncomeExpenses.Add(incomeExpensesInfo, 2, out num2, out empty);
				result = num;
			}
			else
			{
				string text2;
				int value;
				dALCustomerList.Add(new CustomerListInfo
				{
					_Name = text,
					DeptID = new int?(1)
				}, true, out text2, out value);
				IncomeExpensesInfo incomeExpensesInfo = new IncomeExpensesInfo();
				incomeExpensesInfo.DeptID = new int?(1);
				incomeExpensesInfo._Date = DateTime.Now.ToShortDateString();
				incomeExpensesInfo.PersonID = new int?(int.Parse(this.Session["Session_wtUserID"].ToString()));
				incomeExpensesInfo.RecType = "其他付款";
				incomeExpensesInfo.CusType = new int?(1);
				incomeExpensesInfo.CustomerID = new int?(value);
				incomeExpensesInfo.DueMoney = decimal.Parse(this.tbPostage.Text);
				incomeExpensesInfo.RealDueMoney = incomeExpensesInfo.DueMoney;
				incomeExpensesInfo.Remark = "快递发货产生的相关运费";
				string empty = string.Empty;
				DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
				int num2;
				int num = dALIncomeExpenses.Add(incomeExpensesInfo, 2, out num2, out empty);
				result = num;
			}
		}
		return result;
	}
}
