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
using Wuqi.Webdiyer;

public partial class Headquarters_Basic_RepairClassAdm : Page, IRequiresSessionState
{

	private int pageSize = 10;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r14"))
				{
					this.btnAdd.Enabled = false;
					this.btnDel.Enabled = false;
					this.btnMod.Enabled = false;
				}
			}
			this.FillData();
			this.SetEnable();
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (this.jsPager.CurrentPageIndex - 1) * 10);
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "��ǰҳ:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected void FillData()
	{
		int recordCount = 0;
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "RepairClass", "", this.pageSize, this.jsPager.CurrentPageIndex, "", " Array Asc", out recordCount);
		this.GridView1.DataBind();
		this.lbCount.Text = "�ܼ�¼:" + recordCount.ToString();
		if (this.lbCount.Text == "�ܼ�¼:0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
	}

	protected void btnRef_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
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
	}

	protected void SetDisEnable()
	{
		this.tbName.Enabled = true;
		this.tbArray.Enabled = true;
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.btnAdd.Text == "�½�")
		{
			this.btnAdd.Text = "����";
			this.SetDisEnable();
			this.CleanText();
			this.btnMod.Enabled = false;
			this.btnDel.Enabled = false;
			this.hfRecID.Value = "-1";
			this.SysInfo("ChkFocus();");
		}
		else
		{
			BaseInfo baseInfo = new BaseInfo();
			DALBaseInfo dALBaseInfo = new DALBaseInfo();
			baseInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			baseInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			baseInfo.Array = array;
			if (this.hfRecID.Value == "-1")
			{
				this.hfTemp.Value = baseInfo._Name;
				string str;
				int num2;
				int num = dALBaseInfo.Add("RepairClass", baseInfo, "ά�����", false, out str, out num2);
				if (num == 0)
				{
					this.hfRecID.Value = num2.ToString();
				}
				else
				{
					if (num == -1)
					{
						this.SysInfo("window.alert('" + str + "');$('tbName').select();");
						return;
					}
					this.SysInfo("window.alert('ϵͳ������鿴������־');$('tbName').select();");
					return;
				}
			}
			else
			{
				baseInfo.ID = int.Parse(this.hfRecID.Value);
				string text = string.Empty;
				if (baseInfo._Name != this.hfTemp.Value)
				{
					text = text + " _Name='" + baseInfo._Name + "'";
				}
				string str;
				int num = dALBaseInfo.Update("RepairClass", baseInfo, text, out str);
				if (num == 0)
				{
					this.hfRecID.Value = baseInfo.ID.ToString();
				}
				else
				{
					if (num == -1)
					{
						this.SysInfo("window.alert('" + str + "');$('tbName').select();");
						return;
					}
					this.SysInfo("window.alert('ϵͳ������鿴������־');$('tbName').select();");
					return;
				}
			}
			this.FillData();
			this.btnAdd.Text = "�½�";
			this.SetEnable();
			this.btnMod.Enabled = true;
			this.btnDel.Enabled = true;
			if (this.hfRecID.Value != "-1")
			{
				this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
			}
		}
	}

	protected void btnMod_Click(object sender, EventArgs e)
	{
		string str = string.Empty;
		if (this.btnMod.Text == "�޸�")
		{
			this.btnMod.Text = "����";
			this.SetDisEnable();
			this.btnAdd.Enabled = false;
			this.btnDel.Enabled = false;
			str = "ChkFocus();ChkID('" + this.hfRecID.Value + "');";
		}
		else
		{
			BaseInfo baseInfo = new BaseInfo();
			DALBaseInfo dALBaseInfo = new DALBaseInfo();
			baseInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			baseInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			baseInfo.ID = int.Parse(this.hfRecID.Value);
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			baseInfo.Array = array;
			string text = string.Empty;
			if (baseInfo._Name != this.hfTemp.Value)
			{
				text = text + " _Name='" + baseInfo._Name + "'";
			}
			string str2;
			int num = dALBaseInfo.Update("RepairClass", baseInfo, text, out str2);
			if (num == 0)
			{
				this.hfRecID.Value = baseInfo.ID.ToString();
				this.FillData();
				this.btnMod.Text = "�޸�";
				this.SetEnable();
				this.btnAdd.Enabled = true;
				this.btnDel.Enabled = true;
				str = "ChkID('" + this.hfRecID.Value + "');";
			}
			else
			{
				if (num == -1)
				{
					this.SysInfo("window.alert('" + str2 + "');$('tbName').select();");
					return;
				}
				this.SysInfo("window.alert('ϵͳ������鿴������־');$('tbName').select();");
				return;
			}
		}
		this.SysInfo(str);
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iD = int.Parse(this.hfRecID.Value);
		DALBaseInfo dALBaseInfo = new DALBaseInfo();
		string empty = string.Empty;
		int num = dALBaseInfo.Delete("RepairClass", iD, out empty);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('ϵͳ������鿴������־');");
		}
		this.FillData();
		this.hfRecID.Value = "-1";
		this.CleanText();
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			DALBaseInfo dALBaseInfo = new DALBaseInfo();
			BaseInfo model = dALBaseInfo.GetModel("RepairClass", int.Parse(this.hfRecID.Value));
			this.tbName.Text = model._Name;
			this.hfTemp.Value = model._Name;
			this.tbArray.Text = model.Array.ToString();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}