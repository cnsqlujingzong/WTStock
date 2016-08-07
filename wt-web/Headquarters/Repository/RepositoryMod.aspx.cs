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
using wt.OtherLibrary;

public partial class Headquarters_Repository_RepositoryMod : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
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
				if (!dALRight.GetRight(num, "bg_r12"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindRepositoryClass(this.ddlClass, "");
			DALRepository dALRepository = new DALRepository();
			RepositoryInfo model = dALRepository.GetModel(this.id);
			if (model != null)
			{
				this.tbTitle.Text = model.Title;
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Value == model.ClassID.ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						break;
					}
				}
				for (int j = 0; j < this.ddlAccessLevel.Items.Count; j++)
				{
					if (this.ddlAccessLevel.Items[j].Value == model.AccessLevel.ToString())
					{
						this.ddlAccessLevel.Items[j].Selected = true;
						break;
					}
				}
				this.cb1.Checked = model.bTechnician;
				this.cb2.Checked = model.bSeller;
				this.cb3.Checked = model.bStockMan;
				this.cb4.Checked = model.bDestClerk;
				this.cb5.Checked = model.bAccountant;
				this.content.Value = model.Content;
				if (model.AuthorID != int.Parse((string)this.Session["Session_wtUserID"]))
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "只能修改自己的知识";
					this.lbMod.Attributes.Add("class", "si3");
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		RepositoryInfo repositoryInfo = new RepositoryInfo();
		repositoryInfo.ID = this.id;
		repositoryInfo.Title = this.tbTitle.Text;
		repositoryInfo.Content = this.content.Value;
		repositoryInfo.ClassID = int.Parse(this.ddlClass.SelectedValue);
		repositoryInfo.AccessLevel = int.Parse(this.ddlAccessLevel.SelectedValue);
		repositoryInfo.bTechnician = this.cb1.Checked;
		repositoryInfo.bSeller = this.cb2.Checked;
		repositoryInfo.bStockMan = this.cb3.Checked;
		repositoryInfo.bDestClerk = this.cb4.Checked;
		repositoryInfo.bAccountant = this.cb5.Checked;
		DALRepository dALRepository = new DALRepository();
		dALRepository.Update(repositoryInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
