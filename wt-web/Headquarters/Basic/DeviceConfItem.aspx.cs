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
using Wuqi.Webdiyer;

public partial class Headquarters_Basic_DeviceConfItem : Page, IRequiresSessionState
{
	private int pageSize = 10;
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			OtherFunction.BindProductClass(this.ddlClass);
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r21"))
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
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "jc_deviceconfitem", "", this.pageSize, this.jsPager.CurrentPageIndex, " DeptID=1 ", " ID Desc", out recordCount);
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
		this.tbParam.Text = string.Empty;
		this.tbProt.Value = string.Empty;
		this.tbRemark.Text = string.Empty;
		this.ddlClass.ClearSelection();
		this.ddlClass.Items.FindByText("").Selected = true;
	}

	protected void SetEnable()
	{
		this.tbName.Enabled = false;
		this.tbParam.Enabled = false;
		this.tbProt.Disabled = true;
		this.tbRemark.Enabled = false;
		this.ddlClass.Enabled = false;
		this.slProt.Disabled = true;
	}

	protected void SetDisEnable()
	{
		this.tbName.Enabled = true;
		this.tbParam.Enabled = true;
		this.tbProt.Disabled = false;
		this.tbRemark.Enabled = true;
		this.ddlClass.Enabled = true;
		this.slProt.Disabled = false;
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
			DALDeviceConfItem dALDeviceConfItem = new DALDeviceConfItem();
			DeviceConfItemInfo deviceConfItemInfo = new DeviceConfItemInfo();
			deviceConfItemInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			deviceConfItemInfo.ProductClassID = int.Parse(this.ddlClass.SelectedValue);
			deviceConfItemInfo.Parameter = FunLibrary.ChkInput(this.tbParam.Text);
			deviceConfItemInfo.MaintenancePeriod = FunLibrary.ChkInput(this.tbProt.Value);
			deviceConfItemInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			deviceConfItemInfo.DeptID = new int?(1);
			if (this.hfRecID.Value == "-1")
			{
				string str;
				int num2;
				int num = dALDeviceConfItem.Add(deviceConfItemInfo, out str, out num2);
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
				deviceConfItemInfo.ID = int.Parse(this.hfRecID.Value);
				string str;
				int num = dALDeviceConfItem.Update(deviceConfItemInfo, out str);
				if (num == 0)
				{
					this.hfRecID.Value = deviceConfItemInfo.ID.ToString();
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
			DALDeviceConfItem dALDeviceConfItem = new DALDeviceConfItem();
			DeviceConfItemInfo deviceConfItemInfo = new DeviceConfItemInfo();
			deviceConfItemInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			deviceConfItemInfo.ProductClassID = int.Parse(this.ddlClass.SelectedValue);
			deviceConfItemInfo.Parameter = FunLibrary.ChkInput(this.tbParam.Text);
			deviceConfItemInfo.MaintenancePeriod = FunLibrary.ChkInput(this.tbProt.Value);
			deviceConfItemInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			deviceConfItemInfo.ID = int.Parse(this.hfRecID.Value);
			string str2;
			int num = dALDeviceConfItem.Update(deviceConfItemInfo, out str2);
			if (num == 0)
			{
				this.hfRecID.Value = deviceConfItemInfo.ID.ToString();
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
		string empty = string.Empty;
		int num = DALCommon.DeteleData("DeviceConfItem", "[ID]=" + this.hfRecID.Value, out empty);
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
			DALDeviceConfItem dALDeviceConfItem = new DALDeviceConfItem();
			DeviceConfItemInfo model = dALDeviceConfItem.GetModel(int.Parse(this.hfRecID.Value));
			if (model != null)
			{
				this.tbName.Text = model._Name;
				this.ddlClass.ClearSelection();
				this.ddlClass.Items.FindByValue(model.ProductClassID.ToString()).Selected = true;
				this.tbParam.Text = model.Parameter;
				this.tbProt.Value = model.MaintenancePeriod;
				this.tbRemark.Text = model.Remark;
			}
		}
	}

	protected void btnRefClass_Click(object sender, EventArgs e)
	{
		OtherFunction.BindProductClass(this.ddlClass);
		if (this.hfClass.Value != string.Empty)
		{
			this.ddlClass.ClearSelection();
			this.ddlClass.Items.FindByText(this.hfClass.Value).Selected = true;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
