using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Model;

public partial class Web_Password : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string text = (string)this.Session["Session_Web_Name"];
		DALAssociator dALAssociator = new DALAssociator();
		AssociatorInfo model = dALAssociator.GetModel(text);
		if (model != null)
		{
			if (model.Password != this.tbPswOld.Text)
			{
				base.ClientScript.RegisterStartupScript(base.GetType(), "notice", "alert(\"�޸�ʧ�ܣ�ԭ�������벻��ȷ\");", true);
			}
			else
			{
				dALAssociator.UpdatePsw(text, this.tbPsw.Text);
				base.ClientScript.RegisterStartupScript(base.GetType(), "notice", "alert(\"�����޸ĳɹ�������������Ч\");", true);
			}
		}
	}

	public void ChkWebUser()
	{
		if (this.Session["Session_Web_Name"] == null || this.Session["Session_Web_ID"] == null)
		{
			base.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
			base.Response.End();
		}
	}
}
