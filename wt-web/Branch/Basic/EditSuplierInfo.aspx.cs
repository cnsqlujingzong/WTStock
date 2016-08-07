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

public partial class Branch_Basic_EditSuplierInfo : Page, IRequiresSessionState
{
	private string id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		DALSupplierList dALSupplierList = new DALSupplierList();
		string text = this.id.Trim(new char[]
		{
			','
		});
		string[] array = text.Split(new char[]
		{
			','
		});
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string s = array2[i];
			SupplierListInfo model = dALSupplierList.GetModel(int.Parse(s));
			if (model.DeptID.ToString() != this.Session["Session_wtBranchID"].ToString())
			{
				this.btnAdd.Visible = false;
				break;
			}
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r33"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			int num2 = 0;
			this.ddl1.DataSource = DALCommon.GetList_HL(0, "SupplierClass", "", 0, 0, "", " Array Asc", out num2).Tables[0];
			this.ddl1.DataTextField = "_Name";
			this.ddl1.DataValueField = "ID";
			this.ddl1.DataBind();
			this.ddl1.Items.Insert(0, new ListItem("", "-1"));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALSupplierList dALSupplierList = new DALSupplierList();
		int num = 0;
		int int_ = 0;
		int int_2 = 0;
		int int_3 = 0;
		int int_4 = 0;
		int int_a;
		if (this.CheckBox1.Checked)
		{
			int_a = 1;
			if (this.ddl1.SelectedValue == "-1")
			{
				int_ = 0;
			}
			else
			{
				int_ = int.Parse(this.ddl1.SelectedValue.ToString());
			}
		}
		else
		{
			int_a = 0;
		}
		int int_b;
		if (this.CheckBox2.Checked)
		{
			int_b = 1;
			if (this.ddl2.SelectedValue == "")
			{
				int_2 = 0;
			}
			else
			{
				int_2 = int.Parse(this.ddl2.SelectedValue.ToString());
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
			if (this.ddl3.SelectedValue == "")
			{
				int_3 = 0;
			}
			else
			{
				int_3 = int.Parse(this.ddl3.SelectedValue.ToString());
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
			if (this.ddl4.SelectedValue == "")
			{
				int_4 = 0;
			}
			else
			{
				int_4 = int.Parse(this.ddl4.SelectedValue.ToString());
			}
		}
		else
		{
			int_d = 0;
		}
		dALSupplierList.UpdateClass(this.id.TrimEnd(new char[]
		{
			','
		}), int_a, int_b, int_c, int_d, int_, int_2, int_3, int_4);
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
