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
using wt.OtherLibrary;

public partial class Headquarters_Tool_LayoutUserAdd : Page, IRequiresSessionState
{
	private string classid;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.classid = base.Request["classid"];
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "系统管理员")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=LayoutUserAdd");
				base.Response.End();
			}
			OtherFunction.BindStaff(this.ddlUser, " DeptID=1 ");
			DataTable dataSource = DALCommon.GetDataList("LayoutClass", "[ID],[_Name]", "DeptID=1").Tables[0];
			this.ddlRight.DataSource = dataSource;
			this.ddlRight.DataTextField = "_Name";
			this.ddlRight.DataValueField = "ID";
			this.ddlRight.DataBind();
			this.ddlRight.Items.Insert(0, new ListItem("", ""));
			if (this.classid != null)
			{
				for (int i = 0; i < this.ddlRight.Items.Count; i++)
				{
					if (this.ddlRight.Items[i].Value == this.classid)
					{
						this.ddlRight.Items[i].Selected = true;
						break;
					}
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALSys dALSys = new DALSys();
		string str = "";
		int num = dALSys.AddLayoutUser(1, int.Parse(this.ddlRight.SelectedValue), int.Parse(this.ddlUser.SelectedValue), out str);
		if (num == 0)
		{
			this.SysInfo("window.alert('添加成功！');parent.CloseDialog1();parent.iframeDialog.$(\"btnClr\").click();");
		}
		else
		{
			this.SysInfo("window.alert(\"" + str + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
