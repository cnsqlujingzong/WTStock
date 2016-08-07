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
using wt.Model;
using wt.OtherLibrary;

public partial class Headquarters_Customer_CusClassAdm : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r1"))
				{
					this.btnAdds.Enabled = false;
					this.btnMod.Enabled = false;
					this.btnDel.Enabled = false;
					this.btnAdd.Enabled = false;
				}
			}
			this.SetEnable();
			this.FillData();
			this.BindDDL();
		}
	}

	protected void FillData()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array asc", out num).Tables[0];
		this.TreeView1.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.TreeView1.Nodes.Add(treeNode);
		OtherFunction.BindTreeNode2(treeNode, dt, treeNode.Value);
		this.TreeView1.ExpandAll();
	}

	protected void CleanText()
	{
		this.tbName.Text = string.Empty;
		this.tbArray.Text = string.Empty;
	}

	protected void SetEnable()
	{
		this.tbName.Enabled = false;
		this.tbArray.Enabled = false;
		this.ddlFather.Enabled = false;
	}

	protected void SetDisEnable()
	{
		this.tbName.Enabled = true;
		this.tbArray.Enabled = true;
		this.ddlFather.Enabled = true;
	}

	protected void btnAdds_Click(object sender, EventArgs e)
	{
		if (this.btnAdds.Text == "新建分类")
		{
			this.btnDel.Enabled = false;
			this.btnMod.Enabled = false;
			this.btnAdd.Enabled = false;
			this.btnAdds.Text = "保存";
			this.CleanText();
			this.ddlFather.SelectedIndex = -1;
			this.SetDisEnable();
			this.SysInfoSlt("ChkFocus();");
		}
		else
		{
			DALDataClass dALDataClass = new DALDataClass();
			DataClassInfo dataClassInfo = new DataClassInfo();
			dataClassInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			dataClassInfo.Father = new int?(int.Parse(this.ddlFather.SelectedValue));
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			dataClassInfo.Array = array;
			string str;
			int num = dALDataClass.Add("CustomerClass", dataClassInfo, out str);
			if (num == 0)
			{
				this.btnDel.Enabled = true;
				this.btnMod.Enabled = true;
				this.btnAdd.Enabled = true;
				this.btnAdds.Text = "新建分类";
				this.SysInfoSlt("document.getElementById('btnAdds').focus();");
				this.SetEnable();
				this.FillData();
				this.BindDDL();
				this.hfRecID.Value = "-1";
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

	protected void btnMod_Click(object sender, EventArgs e)
	{
		if (this.btnMod.Text == "修改")
		{
			this.btnDel.Enabled = false;
			this.btnAdds.Enabled = false;
			this.btnAdd.Enabled = false;
			this.btnMod.Text = "保存";
			this.SetDisEnable();
		}
		else
		{
			DALDataClass dALDataClass = new DALDataClass();
			DataClassInfo dataClassInfo = new DataClassInfo();
			dataClassInfo.ID = int.Parse(this.hfRecID.Value);
			dataClassInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			int iNewParentid = int.Parse(this.ddlFather.SelectedValue);
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			dataClassInfo.Array = array;
			string chkfld = string.Empty;
			if (dataClassInfo._Name != this.hfTemp.Value)
			{
				chkfld = dataClassInfo._Name;
			}
			string str;
			int num = dALDataClass.Update(0, "CustomerClass", dataClassInfo, chkfld, iNewParentid, out str);
			if (num == 0)
			{
				this.hfRecID.Value = dataClassInfo.ID.ToString();
				this.btnDel.Enabled = true;
				this.btnAdds.Enabled = true;
				this.btnAdd.Enabled = true;
				this.btnMod.Text = "修改";
				this.SysInfoSlt("document.getElementById('btnMod').focus();");
				this.SetEnable();
				this.FillData();
				this.BindDDL();
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

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iD = int.Parse(this.hfRecID.Value);
		DALDataClass dALDataClass = new DALDataClass();
		string empty = string.Empty;
		int num = dALDataClass.Delete("CustomerClass", iD, out empty);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
			this.FillData();
			this.hfRecID.Value = "-1";
			this.CleanText();
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.btnAdd.Text == "新建子类")
		{
			this.btnDel.Enabled = false;
			this.btnMod.Enabled = false;
			this.btnAdds.Enabled = false;
			this.btnAdd.Text = "保存";
			this.CleanText();
			this.ddlFather.SelectedValue = this.hfRecID.Value;
			this.SetDisEnable();
			this.SysInfoSlt("ChkFocus();");
		}
		else
		{
			DALDataClass dALDataClass = new DALDataClass();
			DataClassInfo dataClassInfo = new DataClassInfo();
			dataClassInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			dataClassInfo.Father = new int?(int.Parse(this.ddlFather.SelectedValue));
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			dataClassInfo.Array = array;
			string str;
			int num = dALDataClass.Add("CustomerClass", dataClassInfo, out str);
			if (num == 0)
			{
				this.btnDel.Enabled = true;
				this.btnMod.Enabled = true;
				this.btnAdds.Enabled = true;
				this.btnAdd.Text = "新建子类";
				this.SysInfoSlt("document.getElementById('btnAdd').focus();");
				this.SetEnable();
				this.FillData();
				this.BindDDL();
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

	protected void BindDDL()
	{
		this.ddlFather.Items.Clear();
		int num = 0;
		this.ddlFather.Items.Add(new ListItem("", "-1"));
		DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
		OtherFunction.BindDrpClass("-1", dt, "├", "0", this.ddlFather);
	}

	protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tbName.Text = this.TreeView1.SelectedNode.Text;
		this.hfTemp.Value = this.TreeView1.SelectedNode.Text;
		this.hfDepth.Value = this.TreeView1.SelectedNode.Depth.ToString();
		this.hfRecID.Value = this.TreeView1.SelectedNode.Value;
		this.hfValuePath.Value = this.TreeView1.SelectedNode.ValuePath;
		DALDataClass dALDataClass = new DALDataClass();
		DataClassInfo model = dALDataClass.GetModel("CustomerClass", int.Parse(this.hfRecID.Value));
		if (model != null)
		{
			this.tbArray.Text = model.Array.ToString();
		}
		if (this.TreeView1.FindNode(this.hfValuePath.Value).Parent != null)
		{
			this.hfFather.Value = this.TreeView1.FindNode(this.hfValuePath.Value).Parent.Value;
			this.ddlFather.SelectedValue = this.hfFather.Value;
		}
		else
		{
			this.tbName.Text = string.Empty;
			this.hfFather.Value = "-1";
			this.ddlFather.SelectedValue = "-1";
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void SysInfoSlt(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}
}
