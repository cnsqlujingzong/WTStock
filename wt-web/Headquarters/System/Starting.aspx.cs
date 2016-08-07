using System;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Starting : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "系统管理员")
			{
				this.btnSave.Enabled = false;
				this.lbInfo.Text = "无操作权限!";
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALUserManage dALUserManage = new DALUserManage();
		UserManageInfo model = dALUserManage.GetModel(int.Parse((string)this.Session["Session_wtUserID"]), 1);
		if (model == null)
		{
			this.SysInfo("alert('该用户名不存在.');");
		}
        else if (FunLibrary.StrDecode(model.Pwd) != this.tbAdminPs2.Text)
		{
			this.SysInfo("alert('密码验证失败.');");
		}
		else if (!this.cb1.Checked && !this.cb2.Checked && !this.cb3.Checked && !this.cb4.Checked && !this.cb5.Checked && !this.cb6.Checked && !this.cb7.Checked && !this.cb8.Checked && !this.cb9.Checked && !this.cb10.Checked && !this.cb11.Checked && !this.cb12.Checked)
		{
			this.SysInfo("window.alert('没有要进行初始化的数据');");
		}
		else
		{
			int i = this.cb1.Checked ? 1 : 0;
			int i2 = this.cb2.Checked ? 1 : 0;
			int i3 = this.cb3.Checked ? 1 : 0;
			int i4 = this.cb4.Checked ? 1 : 0;
			int i5 = this.cb5.Checked ? 1 : 0;
			int i6 = this.cb6.Checked ? 1 : 0;
			int i7 = this.cb7.Checked ? 1 : 0;
			int num = this.cb8.Checked ? 1 : 0;
			int i8 = this.cb9.Checked ? 1 : 0;
			int i9 = this.cb10.Checked ? 1 : 0;
			int num2 = this.cb11.Checked ? 1 : 0;
			int i10 = this.cb12.Checked ? 1 : 0;
			DALSys dALSys = new DALSys();
			int num3 = dALSys.SysInit(i, i2, i3, i4, i5, i6, i7, num, i8, i9, num2, i10, (string)this.Session["Session_wtUser"]);
			if (num3 == 0)
			{
				if (num == 1)
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(base.Server.MapPath("../Document"));
					if (Directory.Exists(directoryInfo.ToString()))
					{
						this.DeleteFile(directoryInfo);
					}
					directoryInfo = new DirectoryInfo(base.Server.MapPath("../RepImages"));
					if (Directory.Exists(directoryInfo.ToString()))
					{
						this.DeleteFile(directoryInfo);
					}
				}
				if (num2 == 1)
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(base.Server.MapPath("../Images"));
					if (Directory.Exists(directoryInfo.ToString()))
					{
						this.DeleteFile(directoryInfo);
					}
				}
				this.SysInfo("window.alert('初始化已完成！数据已清空');");
			}
			else
			{
				this.SysInfo("window.alert('系统初始化失败！');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void DeleteFile(DirectoryInfo path)
	{
		DirectoryInfo[] directories = path.GetDirectories();
		for (int i = 0; i < directories.Length; i++)
		{
			DirectoryInfo path2 = directories[i];
			this.DeleteFile(path2);
		}
		FileInfo[] files = path.GetFiles();
		for (int i = 0; i < files.Length; i++)
		{
			FileInfo fileInfo = files[i];
			fileInfo.Delete();
		}
	}
}
