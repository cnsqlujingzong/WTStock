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

public partial class Branch_Office_LateSetMod : Page, IRequiresSessionState
{
	

	private int id;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"].Replace("l", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALLateSet dALLateSet = new DALLateSet();
			LateSetInfo model = dALLateSet.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlType.Items.Count; i++)
				{
					if (this.ddlType.Items[i].Text == model.Type)
					{
						this.ddlType.Items[i].Selected = true;
						break;
					}
				}
				this.tbStart.Text = model.StartMin.ToString();
				this.tbEnd.Text = model.EndMin.ToString();
				this.tbMoney.Text = model.dMoney.ToString();
				this.tbRemark.Text = model.Remark;
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		LateSetInfo lateSetInfo = new LateSetInfo();
		lateSetInfo.ID = this.id;
		lateSetInfo.Type = this.ddlType.SelectedValue;
		decimal dMoney = 0m;
		decimal.TryParse(this.tbMoney.Text, out dMoney);
		int startMin = 0;
		int endMin = 0;
		int.TryParse(this.tbStart.Text, out startMin);
		int.TryParse(this.tbEnd.Text, out endMin);
		lateSetInfo.StartMin = startMin;
		lateSetInfo.EndMin = endMin;
		lateSetInfo.dMoney = dMoney;
		lateSetInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALLateSet dALLateSet = new DALLateSet();
		string str;
		int num = dALLateSet.Update(lateSetInfo, "", out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"btnRef2\").click();");
		}
		else if (num == -1)
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
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
