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

public partial class Headquarters_Customer_AssMod : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request.QueryString["id"], out this.id);
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
				if (!dALRight.GetRight(num, "kh_r12"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			DALAssociator dALAssociator = new DALAssociator();
			AssociatorInfo model = dALAssociator.GetModel(this.id);
			if (model != null)
			{
				this.hfCusID.Value = model.CustomerID.ToString();
				this.tbCusName.Text = model.CustomerName;
				this.tbCusNO.Text = model.CustomerNO;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALAssociator dALAssociator = new DALAssociator();
		dALAssociator.UpdateID(this.id, int.Parse(this.hfCusID.Value));
		this.SysInfo("window.alert('操作成功！会员信息已更新');parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
