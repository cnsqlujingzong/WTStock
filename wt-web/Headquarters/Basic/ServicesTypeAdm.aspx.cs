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

public partial class Headquarters_Basic_ServicesTypeAdm : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "jc_r12"))
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
			this.lbPage.Text = "当前页:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected void FillData()
	{
		int recordCount = 0;
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "ServicesType", "[ID],[_Name],bCall=case when bCall=1 then '√' else '' end,Array", this.pageSize, this.jsPager.CurrentPageIndex, "", " Array asc", out recordCount);
		this.GridView1.DataBind();
		this.lbCount.Text = "总记录:" + recordCount.ToString();
		if (this.lbCount.Text == "总记录:0")
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

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void CleanText()
	{
		this.tbName.Text = string.Empty;
		this.cbCall.Checked = false;
		this.tbArray.Text = string.Empty;
	}

	protected void SetEnable()
	{
		this.tbName.Enabled = false;
		this.cbCall.Enabled = false;
		this.tbArray.Enabled = false;
	}

	protected void SetDisEnable()
	{
		this.tbName.Enabled = true;
		this.cbCall.Enabled = true;
		this.tbArray.Enabled = true;
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.btnAdd.Text == "新建")
		{
			this.btnAdd.Text = "保存";
			this.SetDisEnable();
			this.CleanText();
			this.btnMod.Enabled = false;
			this.btnDel.Enabled = false;
			this.hfRecID.Value = "-1";
			this.SysInfo("ChkFocus();");
		}
		else
		{
			ServicesTypeInfo servicesTypeInfo = new ServicesTypeInfo();
			DALServicesType dALServicesType = new DALServicesType();
			servicesTypeInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			servicesTypeInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			servicesTypeInfo.bCall = this.cbCall.Checked;
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			servicesTypeInfo.Array = array;
			if (this.hfRecID.Value == "-1")
			{
				this.hfTemp.Value = servicesTypeInfo._Name;
				string str;
				int num2;
				int num = dALServicesType.Add(servicesTypeInfo, out str, out num2);
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
					this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
					return;
				}
			}
			else
			{
				servicesTypeInfo.ID = int.Parse(this.hfRecID.Value);
				string text = string.Empty;
				if (servicesTypeInfo._Name != this.hfTemp.Value)
				{
					text = text + " _Name='" + servicesTypeInfo._Name + "'";
				}
				string str;
				int num = dALServicesType.Update(servicesTypeInfo, text, out str);
				if (num == 0)
				{
					this.hfRecID.Value = servicesTypeInfo.ID.ToString();
				}
				else
				{
					if (num == -1)
					{
						this.SysInfo("window.alert('" + str + "');$('tbName').select();");
						return;
					}
					this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
					return;
				}
			}
			this.FillData();
			this.btnAdd.Text = "新建";
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
		if (this.btnMod.Text == "修改")
		{
			this.btnMod.Text = "保存";
			this.SetDisEnable();
			this.btnAdd.Enabled = false;
			this.btnDel.Enabled = false;
			str = "ChkFocus();ChkID('" + this.hfRecID.Value + "');";
		}
		else
		{
			ServicesTypeInfo servicesTypeInfo = new ServicesTypeInfo();
			DALServicesType dALServicesType = new DALServicesType();
			servicesTypeInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			servicesTypeInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			servicesTypeInfo.ID = int.Parse(this.hfRecID.Value);
			servicesTypeInfo.bCall = this.cbCall.Checked;
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			servicesTypeInfo.Array = array;
			string text = string.Empty;
			if (servicesTypeInfo._Name != this.hfTemp.Value)
			{
				text = text + " _Name='" + servicesTypeInfo._Name + "'";
			}
			string str2;
			int num = dALServicesType.Update(servicesTypeInfo, text, out str2);
			if (num == 0)
			{
				this.hfRecID.Value = servicesTypeInfo.ID.ToString();
				this.FillData();
				this.btnMod.Text = "修改";
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
				this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
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
		int num = dALBaseInfo.Delete("ServicesType", iD, out empty);
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
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.FillData();
		this.hfRecID.Value = "-1";
		this.CleanText();
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			DALServicesType dALServicesType = new DALServicesType();
			ServicesTypeInfo model = dALServicesType.GetModel(int.Parse(this.hfRecID.Value));
			this.tbName.Text = model._Name;
			this.hfTemp.Value = model._Name;
			this.cbCall.Checked = model.bCall;
			this.tbArray.Text = model.Array.ToString();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
