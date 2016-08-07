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

public partial class Headquarters_Office_DocMod : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "bg_r4"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindDocClass(this.ddlClass, "");
			DALOA_Doc dALOA_Doc = new DALOA_Doc();
			OA_DocInfo model = dALOA_Doc.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Value == model.ClassID.ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbName.Text = model.Title;
				this.hfUpload.Value = model.FilePath;
				this.hfFileSize.Value = model.FileSize.ToString();
				if (this.hfUpload.Value != string.Empty)
				{
					string[] array = this.hfUpload.Value.Split(new char[]
					{
						'/'
					});
					string text = array[1];
					this.dUpload.InnerHtml = string.Concat(new string[]
					{
						"<img src='../../Public/Images/dmony.gif' /> <a href=../Document/",
						model.FilePath,
						" target=_blank >",
						text,
						"</a> (",
						Convert.ToString(model.FileSize / 1024),
						"kb)"
					});
				}
				if (model.DeptID != 1)
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "总部只能修改自己的文档";
					this.lbMod.Attributes.Add("class", "si3");
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		OA_DocInfo oA_DocInfo = new OA_DocInfo();
		oA_DocInfo.ID = this.id;
		oA_DocInfo.Title = FunLibrary.ChkInput(this.tbName.Text);
		oA_DocInfo.ClassID = new int?(int.Parse(this.ddlClass.SelectedValue));
		oA_DocInfo.FilePath = this.hfUpload.Value;
		if (this.hfUpload.Value != "")
		{
			string[] array = this.hfUpload.Value.Split(new char[]
			{
				'.'
			});
			oA_DocInfo.FileName = array[1];
		}
		else
		{
			oA_DocInfo.FileName = "";
		}
		if (this.hfFileSize.Value != "")
		{
			oA_DocInfo.FileSize = new int?(int.Parse(this.hfFileSize.Value));
		}
		DALOA_Doc dALOA_Doc = new DALOA_Doc();
		string text = "";
		int num = dALOA_Doc.Update(oA_DocInfo, out text);
		if (num == 0)
		{
			this.SysInfo("window.alert('保存成功！文档已经更新');parent.CloseDialog('1');");
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
