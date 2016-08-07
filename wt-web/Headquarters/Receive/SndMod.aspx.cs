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

public partial class Headquarters_Receive_SndMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "fh_r2"))
				{
					this.btnAdd.Enabled = false;
					this.btnConfSnd.Enabled = false;
				}
			}
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			RcvSndInfo model = dALRcvSnd.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				OtherFunction.BindStaff(this.ddlOperator, " DeptID=1 and Status=0");
				OtherFunction.BindSndStyle(this.ddlShipStyle, " DeptID=1 ");
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.OperatorID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.ddlSndType.Items.FindByText(model.OperationType).Selected = true;
				this.ddlRcvObj.Items.FindByText(model.RcvType).Selected = true;
				if (model.RcvType == "网点")
				{
					DataTable dataTable = DALCommon.GetDataList("BranchList", "_Name", "[ID]=" + model.RcvDeptID).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.ddlBranch.Items.Add(new ListItem(dataTable.Rows[0]["_Name"].ToString(), dataTable.Rows[0]["_Name"].ToString()));
					}
				}
				this.tbCusName.Text = model.CorpName;
				this.tbLinkMan.Text = model.LinkMan;
				this.tbTel.Text = model.Tel;
				this.tbAdr.Text = model.Adr;
				this.tbZip.Text = model.Zip;
				this.tbSummary.Text = model.Summary;
				for (int i = 0; i < this.ddlShipStyle.Items.Count; i++)
				{
					if (this.ddlShipStyle.Items[i].Value == model.SndStyleID.ToString())
					{
						this.ddlShipStyle.Items[i].Selected = true;
						break;
					}
				}
				this.tbSndNo.Text = model.PostNO;
				this.tbPostage.Text = model.Postage.ToString();
				this.tbRemark.Text = model.Remark;
			}
		}
	}

	protected void btnConfSnd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = this.BillAdd(out empty);
		if (num == 0)
		{
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			num = dALRcvSnd.ConfSnd(this.id, int.Parse(this.ddlShipStyle.SelectedValue), FunLibrary.ChkInput(this.tbSndNo.Text), out empty);
			if (num == 0)
			{
				this.BuildAccount();
				this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！该发货单转入待收货确认');");
			}
			else
			{
				this.SysInfo("window.alert(\"" + empty + "\");");
			}
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + empty + "');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string str = "";
		if (this.BillAdd(out str) == 0)
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！发货单已生成');");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + str + "');");
		}
	}

	protected int BillAdd(out string strMsg)
	{
		RcvSndInfo rcvSndInfo = new RcvSndInfo();
		rcvSndInfo.ID = this.id;
		rcvSndInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		rcvSndInfo.OperatorID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		rcvSndInfo.OperationType = this.ddlSndType.SelectedItem.Text;
		rcvSndInfo.RcvType = this.ddlRcvObj.SelectedItem.Text;
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
		return dALRcvSnd.Update(rcvSndInfo, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
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
