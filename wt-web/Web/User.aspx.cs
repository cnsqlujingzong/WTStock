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

public partial class Web_User : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		if (!base.IsPostBack)
		{
			string name = (string)this.Session["Session_Web_Name"];
			DALAssociator dALAssociator = new DALAssociator();
			AssociatorInfo model = dALAssociator.GetModel(name);
			if (model != null)
			{
				this.tbname.Text = model._Name;
				this.tbcorp.Text = model.Company;
				this.tbman.Text = model.LinkMan;
				this.tbatel.Text = model.Tel;
				this.tbaadr.Text = model.Adr;
				this.tbemail.Text = model.Email;
				int customerID = model.CustomerID;
				if (customerID > 0)
				{
					DALCustomerList dALCustomerList = new DALCustomerList();
					CustomerListInfo model2 = dALCustomerList.GetModel(customerID);
					if (model2 != null)
					{
						this.tbCusName.Text = model2._Name;
						this.tbLinkMan.Text = model2.LinkMan;
						this.tbTel.Text = model2.Tel;
						this.tbArea.Text = model2.Area;
						this.tbAdr.Text = model2.Adr;
					}
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string name = (string)this.Session["Session_Web_Name"];
		DALAssociator dALAssociator = new DALAssociator();
		AssociatorInfo model = dALAssociator.GetModel(name);
		model.Company = FunLibrary.ChkInput(this.tbcorp.Text);
		model.LinkMan = FunLibrary.ChkInput(this.tbman.Text);
		model.Tel = FunLibrary.ChkInput(this.tbatel.Text);
		model.Adr = FunLibrary.ChkInput(this.tbaadr.Text);
		model.Email = FunLibrary.ChkInput(this.tbemail.Text);
		dALAssociator.Update(model);
		base.ClientScript.RegisterStartupScript(base.GetType(), "notice", "alert(\"会员信息已经更新.\");", true);
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
