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

public partial class Branch_Services_SerCancel : Page, IRequiresSessionState
{


	private string id;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r19"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindCancelReason(this.ddlCancel);
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALServices dALServices = new DALServices();
		int num = 0;
		int num2 = 0;
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
				if (dALServices.isHaveSupplies(num3))
				{
					this.SysInfo("parent.CloseDialog('2');window.alert('����ʧ�ܣ�����ɾ��������/�Ĳġ�����ĵ��ݣ�');");
					return;
				}
				int num4 = dALServices.FWCancel(num3, int.Parse((string)this.Session["Session_wtBranchID"]), int.Parse((string)this.Session["Session_wtUserBID"]), FunLibrary.ChkInput(this.tbCaReason.Value), out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('2');window.alert('�����ɹ���" + num2.ToString() + "��������ȡ��');");
			return;
		}
		if (num2 == 0)
		{
			this.SysInfo("parent.CloseDialog('2');window.alert('����ʧ�ܣ�" + num.ToString() + "������״̬�ѱ仯����ˢ�º������');");
			return;
		}
		this.SysInfo(string.Concat(new string[]
		{
			"parent.CloseDialog('2');window.alert('",
			num2.ToString(),
			"��������ȡ����",
			num.ToString(),
			"������״̬�ѱ仯����ˢ�º������');"
		}));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
