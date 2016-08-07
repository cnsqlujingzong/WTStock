using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.OtherLibrary;

public partial class Headquarters_Financial_EditExpense : Page, IRequiresSessionState
{
	private string id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
			OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=1");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALIncomeExpenses dALIncomeExpenses = new DALIncomeExpenses();
		this.id = this.id.TrimEnd(new char[]
		{
			','
		});
		string text = string.Empty;
		if (this.CheckBox1.Checked)
		{
			if (this.ddlChargeStyle.SelectedValue != "")
			{
				text = this.ddlChargeStyle.SelectedValue;
			}
		}
		if (text != string.Empty)
		{
			int num = dALIncomeExpenses.UpdateDate(" ChargeModeID=" + text, " [ID] in (" + this.id + ") and Status = 1");
			if (num != 0)
			{
				this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！');");
			}
		}
		string text2 = string.Empty;
		if (this.CheckBox2.Checked)
		{
			if (this.ddlChargeAccount.SelectedValue != "")
			{
				text2 = this.ddlChargeAccount.SelectedValue;
			}
		}
		if (text2 != string.Empty)
		{
			int num = dALIncomeExpenses.UpdateDate(" AccountID=" + text2, " [ID] in (" + this.id + ") and Status = 1");
			if (num != 0)
			{
				this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！');");
			}
		}
		if (text != string.Empty && text2 != string.Empty)
		{
			int num = dALIncomeExpenses.UpdateDate(" ChargeModeID=" + text + ",AccountID=" + text2, " [ID] in (" + this.id + ") and Status = 1");
			if (num != 0)
			{
				this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
