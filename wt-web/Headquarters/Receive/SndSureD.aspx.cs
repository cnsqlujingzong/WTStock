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

public partial class Headquarters_Receive_SndSureD : Page, IRequiresSessionState
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
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindSndStyle(this.ddlSndStyle, " DeptID=1 ");
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			RcvSndInfo model = dALRcvSnd.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlSndStyle.Items.Count; i++)
				{
					if (this.ddlSndStyle.Items[i].Value == model.SndStyleID.ToString())
					{
						this.ddlSndStyle.Items[i].Selected = true;
						break;
					}
				}
				this.tbPostNO.Text = model.PostNO;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALRcvSnd dALRcvSnd = new DALRcvSnd();
		int num = dALRcvSnd.ConfSnd(this.id, int.Parse(this.ddlSndStyle.SelectedValue), FunLibrary.ChkInput(this.tbPostNO.Text), out empty);
		if (num == 0)
		{
			this.BuildAccount();
			this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！该发货单转入待收货确认');");
		}
		else
		{
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected int BuildAccount()
	{
		DALRcvSnd dALRcvSnd = new DALRcvSnd();
		RcvSndInfo model = dALRcvSnd.GetModel(this.id);
		int result;
		if (model == null)
		{
			result = -1;
		}
		else
		{
			DALShippingStyle dALShippingStyle = new DALShippingStyle();
			if (model.SndStyleID.HasValue)
			{
				string text = this.ddlSndStyle.SelectedItem.Text;
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
					if (model.Postage.HasValue)
					{
						incomeExpensesInfo.DueMoney = model.Postage.Value;
					}
					else
					{
						incomeExpensesInfo.DueMoney = 0m;
					}
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
					if (model.Postage.HasValue)
					{
						incomeExpensesInfo.DueMoney = model.Postage.Value;
					}
					else
					{
						incomeExpensesInfo.DueMoney = 0m;
					}
					incomeExpensesInfo.RealDueMoney = incomeExpensesInfo.DueMoney;
					incomeExpensesInfo.Remark = "快递发货产生的相关运费";
					string empty = string.Empty;
					DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
					int num2;
					int num = dALIncomeExpenses.Add(incomeExpensesInfo, 2, out num2, out empty);
					result = num;
				}
			}
			else
			{
				result = -1;
			}
		}
		return result;
	}
}
