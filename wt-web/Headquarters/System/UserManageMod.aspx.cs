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

public partial class Headquarters_System_UserManageMod : Page, IRequiresSessionState
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
			if ((string)this.Session["Session_wtPur"] != "系统管理员")
			{
				this.lbInfo.Visible = true;
				this.lbInfo.Text = "无操作权限，只有系统管理员才能添加用户。";
				this.btnAdd.Enabled = false;
			}
			OtherFunction.BindStaff(this.ddlStaff, " DeptID=1 and Status=0 ");
			this.ddlRight.DataSource = DALCommon.GetDataList("[Right]", " [ID],[_Name] ", " DeptID=1 ").Tables[0];
			this.ddlRight.DataValueField = "ID";
			this.ddlRight.DataTextField = "_Name";
			this.ddlRight.DataBind();
			this.ddlRight.Items.Insert(0, new ListItem("", "-1"));
			DALUserManage dALUserManage = new DALUserManage();
			UserManageInfo model = dALUserManage.GetModel(this.id);
			if (model != null)
			{
				for (int i = 0; i < this.ddlStaff.Items.Count; i++)
				{
					if (this.ddlStaff.Items[i].Value == model.StaffID.ToString())
					{
						this.ddlStaff.Items[i].Selected = true;
						this.tbName.Text = this.ddlStaff.Items[i].Text;
						break;
					}
				}
				this.tbPsw.Attributes.Add("value", "**********");
				this.tbPsw.Attributes.Add("disabled", "disabled");
				for (int i = 0; i < this.ddlRight.Items.Count; i++)
				{
					if (this.ddlRight.Items[i].Value == model.RightID.ToString())
					{
						this.ddlRight.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlStatus.Items.Count; i++)
				{
					if (this.ddlStatus.Items[i].Text == model.Status)
					{
						this.ddlStatus.Items[i].Selected = true;
						break;
					}
				}
				this.hfTemp.Value = model.StaffID.ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.tbName.Text.Trim() == string.Empty || this.tbPsw.Text.Trim().Length > 20 || this.tbPsw.Text.Trim().Length < 7)
		{
			this.SysInfo("window.alert('保存失败！密码长度必须在7-20位之间');$('tbName').select();");
		}
		else
		{
			UserManageInfo userManageInfo = new UserManageInfo();
			userManageInfo.ID = this.id;
			userManageInfo.StaffID = int.Parse(this.ddlStaff.SelectedValue);
			userManageInfo.Pwd = FunLibrary.StrEncode(FunLibrary.ChkInput(this.tbPsw.Text));
			userManageInfo.RightID = int.Parse(this.ddlRight.SelectedValue);
			userManageInfo.Status = ((this.ddlRight.SelectedItem.Text == "系统管理员") ? "正常" : this.ddlStatus.SelectedItem.Text);
			string chkfld = "";
			if (userManageInfo.StaffID.ToString() != this.hfTemp.Value)
			{
				chkfld = " DeptID=1 and StaffID=" + this.ddlStaff.SelectedValue;
			}
			DALUserManage dALUserManage = new DALUserManage();
			if (this.ddlRight.SelectedItem.Text != "系统管理员")
			{
				int delAdm = dALUserManage.GetDelAdm(1, this.id);
				if (delAdm == 0)
				{
					this.SysInfo("window.alert('操作失败！系统中需要保留至少一个管理员');");
					return;
				}
			}
			string str;
			int num = dALUserManage.Update(userManageInfo, chkfld, this.cb_ps.Checked, out str);
			if (num == 0)
			{
				this.SysInfo("parent.CloseDialog('1');");
			}
			else if (num == -1)
			{
				this.SysInfo("window.alert('" + str + "');$('tbName').select();");
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
