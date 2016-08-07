using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Services_OverBack : Page, IRequiresSessionState
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
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		string text = string.Empty;
		DALServices dALServices = new DALServices();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string[] array = this.id.Split(new char[]
		{
			','
		});
		int num5 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num5);
			if (num5 != 0)
			{
				int num6 = dALServices.OverBack(num5, int.Parse((string)this.Session["Session_wtUserID"]), FunLibrary.ChkInput(this.tbReason.Text), out empty);
				if (num6 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
				if (this.ddlBackTo.SelectedValue == "2" && num6 == 0)
				{
					num6 = dALServices.BlnBack(num5, int.Parse((string)this.Session["Session_wtUserID"]), FunLibrary.ChkInput(this.tbReason.Text), out empty);
					if (num6 == 0)
					{
						num4++;
					}
					else
					{
						num3++;
					}
				}
			}
			if (!empty.Trim().Equals("操作失败！该服务单状态已变化，请刷新后操作！") && !empty.Trim().Equals("操作成功！该服务单已【驳回】！"))
			{
				text += empty;
			}
		}
		string text2 = string.Empty;
		if (num3 == 0 && num == 0)
		{
			if ((this.ddlBackTo.SelectedValue == "1" && num == 0) || this.ddlBackTo.SelectedValue == "1")
			{
				text2 += "操作成功！";
			}
		}
		if (num4 == 0 && num2 == 0)
		{
			text2 += "操作失败！";
		}
		if (num4 > 0)
		{
			text2 = text2 + num4.ToString() + "条服务单已被驳回到服务中心；";
		}
		if (num2 - num4 > 0)
		{
			text2 = text2 + (num2 - num4).ToString() + "条服务单已被驳回到完工结算；";
		}
		if (num > 0 || num3 > 0)
		{
			text2 = text2 + (num + num3).ToString() + "条服务单驳回失败";
			if (text.Length > 0)
			{
				text2 = text2 + "；错误信息：" + text;
			}
			else
			{
				text2 += "，服务单状态已变化，请刷新后操作！";
			}
		}
		this.SysInfo(string.Format("parent.CloseDialog('2');window.alert('{0}');", text2.Trim(new char[]
		{
			'；'
		})));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
