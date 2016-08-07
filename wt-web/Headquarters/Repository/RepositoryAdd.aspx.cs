using System;
using System.Data;
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

public partial class Headquarters_Repository_RepositoryAdd : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r11"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindRepositoryClass(this.ddlClass, "");
			if (this.id > 0)
			{
				DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID]=" + this.id.ToString()).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.tbTitle.Text = dataTable.Rows[0]["Fault"].ToString();
					DataTable dataTable2 = DALCommon.GetDataList("fw_servicesprocess", "", " [BillID]=" + this.id.ToString()).Tables[0];
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						int num2 = i + 1;
						HtmlTextArea expr_15F = this.content;
						string value = expr_15F.Value;
						expr_15F.Value = string.Concat(new string[]
						{
							value,
							num2.ToString(),
							"��",
							dataTable2.Rows[i]["TakeSteps"].ToString(),
							"<br/>"
						});
					}
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		RepositoryInfo repositoryInfo = new RepositoryInfo();
		repositoryInfo.Title = this.tbTitle.Text;
		repositoryInfo.AuthorID = int.Parse((string)this.Session["Session_wtUserID"]);
		repositoryInfo.DeptID = 1;
		repositoryInfo.Content = this.content.Value;
		repositoryInfo.ClassID = int.Parse(this.ddlClass.SelectedValue);
		repositoryInfo.AccessLevel = int.Parse(this.ddlAccessLevel.SelectedValue);
		repositoryInfo.bTechnician = this.cb1.Checked;
		repositoryInfo.bSeller = this.cb2.Checked;
		repositoryInfo.bStockMan = this.cb3.Checked;
		repositoryInfo.bDestClerk = this.cb4.Checked;
		repositoryInfo.bAccountant = this.cb5.Checked;
		repositoryInfo._Date = DateTime.Now;
		DALRepository dALRepository = new DALRepository();
		dALRepository.Add(repositoryInfo);
		this.SysInfo("window.alert('����ɹ�����֪ʶ�Ѿ�����');parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
