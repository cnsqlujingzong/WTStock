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

public partial class Headquarters_Office_AnnAdd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r6"))
				{
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		OA_AnnunciateInfo oA_AnnunciateInfo = new OA_AnnunciateInfo();
		oA_AnnunciateInfo.Title = FunLibrary.ChkInput(this.tbTitle.Text);
		oA_AnnunciateInfo.Content = FunLibrary.ChkInput(this.tbContent.Text);
		oA_AnnunciateInfo.AuthorID = new int?(int.Parse((string)this.Session["Session_wtUserID"]));
		oA_AnnunciateInfo.DeptID = new int?(1);
		DALOA_Annunciate dALOA_Annunciate = new DALOA_Annunciate();
		string text = "";
		int num = 0;
		int num2 = dALOA_Annunciate.Add(oA_AnnunciateInfo, out text, out num);
		if (num2 == 0)
		{
			this.SysInfo("window.alert('����ɹ����¹����Ѿ�����');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('����ʧ�ܣ���鿴������־');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
