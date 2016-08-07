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

public partial class Branch_Office_DocAdd : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r2"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindDocClass(this.ddlClass, "");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		OA_DocInfo oA_DocInfo = new OA_DocInfo();
		oA_DocInfo.Title = FunLibrary.ChkInput(this.tbName.Text);
		oA_DocInfo.ClassID = new int?(int.Parse(this.ddlClass.SelectedValue));
		oA_DocInfo.AuthorID = new int?(int.Parse((string)this.Session["Session_wtUserBID"]));
		oA_DocInfo.DeptID = new int?(int.Parse((string)this.Session["Session_wtBranchID"]));
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
		int num = 0;
		int num2 = dALOA_Doc.Add(oA_DocInfo, out text, out num);
		if (num2 == 0)
		{
			this.SysInfo("window.alert('保存成功！新文档已经建立');parent.CloseDialog('1');");
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
