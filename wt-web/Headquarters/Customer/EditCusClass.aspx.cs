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

public partial class Headquarters_Customer_EditCusClass : Page, IRequiresSessionState
{
	private string id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r4"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			int num2 = 0;
			this.slGdsClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slGdsClass);
			int num3 = 0;
			this.ddlArea.DataSource = DALCommon.GetList_HL(0, "AreaList", "", 0, 0, "", " Array asc ", out num3);
			this.ddlArea.DataTextField = "_Name";
			this.ddlArea.DataValueField = "ID";
			this.ddlArea.DataBind();
			this.ddlArea.Items.Insert(0, new ListItem("", "-1"));
			OtherFunction.BindStaff(this.ddlSeller, "bSeller=1 and DeptID=1 ");
			OtherFunction.BindMember(this.ddlMember);
			OtherFunction.BindCustomerStatus(this.ddlStatus);
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALCustomerList dALCustomerList = new DALCustomerList();
		int num = 0;
		string strclassid = "";
		int istatus = 0;
		string strarea = "";
		int imem = 0;
		int bback = 0;
		int btrack = 0;
		int sellerid = 0;
		int istop = 0;
		decimal dDisposition = 0m;
		int int_a;
		if (this.CheckBox1.Checked)
		{
			int_a = 1;
			strclassid = this.slGdsClass.Items[this.slGdsClass.SelectedIndex].Value;
		}
		else
		{
			int_a = 0;
		}
		int int_b;
		if (this.CheckBox2.Checked)
		{
			int_b = 1;
			if (this.ddlStatus.SelectedValue.ToString() == "-1")
			{
				istatus = 0;
			}
			else
			{
				istatus = int.Parse(this.ddlStatus.SelectedValue.ToString());
			}
		}
		else
		{
			int_b = 0;
		}
		int int_c;
		if (this.CheckBox3.Checked)
		{
			int_c = 1;
			if (this.ddlArea.SelectedValue.ToString() == "-1")
			{
				strarea = "";
			}
			else
			{
				strarea = this.ddlArea.SelectedItem.Text;
			}
		}
		else
		{
			int_c = 0;
		}
		int int_d;
		if (this.CheckBox4.Checked)
		{
			int_d = 1;
			if (this.ddlMember.SelectedValue.ToString() == "-1")
			{
				imem = 0;
			}
			else
			{
				imem = int.Parse(this.ddlMember.SelectedValue.ToString());
			}
		}
		else
		{
			int_d = 0;
		}
		int int_e;
		if (this.CheckBox5.Checked)
		{
			int_e = 1;
			if (this.ddlSeeBack.SelectedValue == "")
			{
				bback = 0;
			}
			else
			{
				bback = int.Parse(this.ddlSeeBack.SelectedValue.ToString());
			}
		}
		else
		{
			int_e = 0;
		}
		int int_f;
		if (this.CheckBox6.Checked)
		{
			int_f = 1;
			if (this.ddlbTrace.SelectedValue.ToString() == "")
			{
				btrack = 0;
			}
			else
			{
				btrack = int.Parse(this.ddlbTrace.SelectedValue.ToString());
			}
		}
		else
		{
			int_f = 0;
		}
		int int_g;
		if (this.CheckBox7.Checked)
		{
			int_g = 1;
			if (this.ddlSeller.SelectedValue.ToString() == "-1")
			{
				sellerid = 0;
			}
			else
			{
				sellerid = int.Parse(this.ddlSeller.SelectedValue.ToString());
			}
		}
		else
		{
			int_g = 0;
		}
		int int_h;
		if (this.CheckBox8.Checked)
		{
			int_h = 1;
			int.TryParse(this.ddlStop.SelectedValue, out istop);
		}
		else
		{
			int_h = 0;
		}
		int int_i;
		if (this.CheckBox9.Checked)
		{
			int_i = 1;
			decimal.TryParse(this.tbDisposition.Text, out dDisposition);
		}
		else
		{
			int_i = 0;
		}
		dALCustomerList.UpdateClass(this.id.TrimEnd(new char[]
		{
			','
		}), int_a, int_b, int_c, int_d, int_e, int_f, int_g, int_h, int_i, strclassid, istatus, strarea, imem, bback, btrack, sellerid, istop, dDisposition);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！客户信息已修改！');");
		}
		else
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作失败！请查看错误日志');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
