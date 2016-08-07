using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Services_BlnBack : Page, IRequiresSessionState
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
		DALServices dALServices = new DALServices();
		int num = 0;
		int num2 = 0;
		string text = "";
		string[] array = this.id.Split(new char[]
		{
			','
		});
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			if (num3 != 0)
			{
				int num4 = dALServices.BlnBack(num3, int.Parse((string)this.Session["Session_wtUserID"]), FunLibrary.ChkInput(this.tbReason.Text), out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else if (num4 == -1)
				{
					text = text + empty + ";";
					num++;
				}
			}
		}
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！" + num2.ToString() + "条服务单已被驳回');");
		}
		else if (num2 == 0)
		{
			this.SysInfo("parent.CloseDialog('2');window.alert('" + text + "');");
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"parent.CloseDialog('2');window.alert('",
				num2.ToString(),
				"条服务单已被驳回；",
				text,
				"');"
			}));
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
