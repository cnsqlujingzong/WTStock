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

public partial class Branch_Office_AnnMod : Page, IRequiresSessionState
{
	
	private int id;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r6"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DALOA_Annunciate dALOA_Annunciate = new DALOA_Annunciate();
			OA_AnnunciateInfo model = dALOA_Annunciate.GetModel(this.id);
			if (model != null)
			{
				this.tbTitle.Text = model.Title;
				this.tbContent.Text = model.Content;
				if (model.DeptID != 1)
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "总部只能修改自己的公告";
					this.lbMod.Attributes.Add("class", "si3");
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		OA_AnnunciateInfo oA_AnnunciateInfo = new OA_AnnunciateInfo();
		oA_AnnunciateInfo.ID = this.id;
		oA_AnnunciateInfo.Title = FunLibrary.ChkInput(this.tbTitle.Text);
		oA_AnnunciateInfo.Content = FunLibrary.ChkInput(this.tbContent.Text);
		DALOA_Annunciate dALOA_Annunciate = new DALOA_Annunciate();
		string text = "";
		int num = dALOA_Annunciate.Update(oA_AnnunciateInfo, out text);
		if (num == 0)
		{
			this.SysInfo("window.alert('保存成功！公告信息已更新');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
