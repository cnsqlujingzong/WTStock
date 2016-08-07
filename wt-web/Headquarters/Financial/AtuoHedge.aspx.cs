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

public partial class Headquarters_Financial_AtuoHedge : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "zk_r15"))
				{
					this.btnSave.Enabled = false;
				}
			}
			DALArrearage dALArrearage = new DALArrearage();
			ArrearageInfo model = dALArrearage.GetModel(this.id);
			if (model != null)
			{
				this.tbRec.Text = model.Rec.ToString("#0.00");
				this.tbDue.Text = model.Due.ToString("#0.00");
				if (model.Rec > model.Due)
				{
					this.tbMoney.Text = model.Due.ToString("#0.00");
				}
				else
				{
					this.tbMoney.Text = model.Rec.ToString("#0.00");
				}
				OtherFunction.BindChargeAccount(this.ddlAccount, " DeptID=1");
				if (model.Rec == 0m)
				{
					this.lbMod.Text = "应收款为0，不能够进行对冲！";
					this.lbMod.Attributes.Add("class", "si2");
					this.btnSave.Enabled = false;
				}
				if (model.Due == 0m)
				{
					this.lbMod.Text = "应付款为0，不能够进行对冲！";
					this.lbMod.Attributes.Add("class", "si2");
					this.btnSave.Enabled = false;
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALArrearage dALArrearage = new DALArrearage();
		decimal dAmount = 0m;
		decimal.TryParse(this.tbMoney.Text, out dAmount);
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALArrearage.AtuoHedge(this.id, dAmount, iOperator, int.Parse(this.ddlAccount.SelectedValue), out empty);
		if (num == 0)
		{
			this.SysInfo("window.alert('" + empty + "');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
