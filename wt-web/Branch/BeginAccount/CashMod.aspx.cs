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

public partial class Branch_BeginAccount_CashMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "qc_r5"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			DALAccount dALAccount = new DALAccount();
			AccountInfo model = dALAccount.GetModel(this.id);
			if (model != null)
			{
				this.tbName.Text = model._Name;
				this.tbMoney.Text = model.BeginMoney.ToString("#0.00");
				if (model.BeginStatus == 1)
				{
					this.tbMoney.ReadOnly = true;
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "期初已初始化，无法修改";
					this.lbMod.Attributes.Add("class", "si3");
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALAccount dALAccount = new DALAccount();
		AccountInfo model = dALAccount.GetModel(this.id);
		model.ID = this.id;
		decimal beginMoney = 0m;
		decimal.TryParse(this.tbMoney.Text, out beginMoney);
		model.BeginMoney = beginMoney;
		string empty = string.Empty;
		int num = dALAccount.UpdateBegin(model, out empty);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
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
