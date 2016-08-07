using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Customer_AgainTrack : Page, IRequiresSessionState
{
	private int id;

	private int iOperator;

	private string strdate;

	private string str;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		this.str = base.Request["str"];
		if (this.str == null)
		{
			this.str = "";
		}
		this.strdate = base.Request["strdate"];
		if (this.strdate == "")
		{
			this.strdate = DateTime.Now.ToString("yyyy-MM-dd");
		}
		int.TryParse(base.Request["stroper"], out this.iOperator);
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
				if (!dALRight.GetRight(num, "kh_r11"))
				{
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALConsumablesTrack dALConsumablesTrack = new DALConsumablesTrack();
		string str = "";
		string text = this.tbDate.Text;
		int num = dALConsumablesTrack.ChkDoTrack(this.id, this.iOperator, this.strdate, this.str, true, text, out str);
		if (num == 0)
		{
			this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('" + str + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
