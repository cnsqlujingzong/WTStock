using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Services_SerConf : Page, IRequiresSessionState
{
	private string id;

	private string flag;

	public string str_flag
	{
		get
		{
			return this.flag;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.id = base.Request["id"];
		if (this.id == null || this.id == "")
		{
			base.Response.End();
		}
		this.flag = base.Request["iflag"];
		if (this.flag == "" || this.flag == null)
		{
			this.flag = "";
		}
		if (!base.IsPostBack)
		{
			this.tbDate.Text = DateTime.Now.ToString();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALServices dALServices = new DALServices();
		int num = 0;
		int num2 = 0;
		string str = "";
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
				int num4 = dALServices.SerConf(1, num3, int.Parse((string)this.Session["Session_wtUserID"]), "", FunLibrary.ChkInput(this.tbDate.Text), out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else if (num4 == -1)
				{
					str = str + empty + ";";
					num++;
				}
			}
		}
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog1('1');window.alert('操作成功！" + num2.ToString() + "条服务单已确认');");
		}
		else if (num2 == 0)
		{
			this.SysInfo("parent.CloseDialog1('1');window.alert('操作失败！" + num.ToString() + "条服务单已确认，不能够重复确认');");
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"parent.CloseDialog1('1');window.alert('",
				num2.ToString(),
				"条服务单已确认；",
				num.ToString(),
				"条服务单已确认，不能够重复确认');"
			}));
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
