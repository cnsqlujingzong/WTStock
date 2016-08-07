using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_System_RightGroupAdd : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "系统管理员")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=Right");
				base.Response.End();
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (FunLibrary.ChkInput(this.tbName.Text) == "系统管理员")
		{
			this.SysInfo("window.alert('操作失败！该权限名不可用');");
		}
		else
		{
			RightInfo rightInfo = new RightInfo();
			DALRight dALRight = new DALRight();
			rightInfo.DeptID = 1;
			rightInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			List<RightDetailInfo> list = new List<RightDetailInfo>();
			for (int i = 1; i <= 83; i++)
			{
				string text = "ck_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 18; i++)
			{
				string text = "cg_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 19; i++)
			{
				string text = "xs_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 27; i++)
			{
				string text = "gd_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 27; i++)
			{
				string text = "zl_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 35; i++)
			{
				string text = "kh_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 23; i++)
			{
				string text = "zk_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 30; i++)
			{
				string text = "bg_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 4; i++)
			{
				string text = "fh_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 5; i++)
			{
				string text = "qc_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 70; i++)
			{
				string text = "tj_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 36; i++)
			{
				string text = "jc_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			rightInfo.RightDetailInfos = list;
			int num2;
			int num = dALRight.Add(rightInfo, out num2);
			if (num == 0)
			{
				this.SysInfo("window.alert('保存成功！权限组已添加');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
