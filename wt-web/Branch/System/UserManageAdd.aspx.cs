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

public partial class Branch_System_UserManageAdd : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPurB"] != "系统管理员")
			{
				this.lbInfo.Visible = true;
				this.lbInfo.Text = "无操作权限，只有系统管理员才能添加用户。";
				this.btnAdd.Enabled = false;
			}
			OtherFunction.BindStaff(this.ddlStaff, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0 ");
			this.ddlRight.DataSource = DALCommon.GetDataList("[Right]", " [ID],[_Name] ", " DeptID=" + (string)this.Session["Session_wtBranchID"]).Tables[0];
			this.ddlRight.DataValueField = "ID";
			this.ddlRight.DataTextField = "_Name";
			this.ddlRight.DataBind();
			this.ddlRight.Items.Insert(0, new ListItem("", "-1"));
			int num = int.Parse(DALCommon.GetDataList("SysParm", "count(1)", "bSim=1 or BranchNum>(select count(1) from UserManage)").Tables[0].Rows[0][0].ToString());
			this.hfOverFlag.Value = num.ToString();
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
			userManageInfo.DeptID = int.Parse((string)this.Session["Session_wtBranchID"]);
			userManageInfo.StaffID = int.Parse(this.ddlStaff.SelectedValue);
			userManageInfo.Pwd = FunLibrary.StrEncode(FunLibrary.ChkInput(this.tbPsw.Text));
			userManageInfo.RightID = int.Parse(this.ddlRight.SelectedValue);
			userManageInfo.Status = ((this.ddlRight.SelectedItem.Text == "系统管理员") ? "正常" : this.ddlStatus.SelectedItem.Text);
			DALUserManage dALUserManage = new DALUserManage();
			string str;
			int num2;
			int num = dALUserManage.Add(userManageInfo, out str, out num2);
			if (num == 0)
			{
				if (this.cbClose.Checked)
				{
					this.SysInfo("parent.CloseDialog('1');");
				}
				else
				{
					this.SysInfo("$('tbName').select();");
					this.ClearText();
				}
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

	protected void ClearText()
	{
		this.tbName.Text = (this.tbPsw.Text = "");
		this.ddlStaff.ClearSelection();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
