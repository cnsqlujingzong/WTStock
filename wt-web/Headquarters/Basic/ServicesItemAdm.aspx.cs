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

public partial class Headquarters_Basic_ServicesItemAdm : Page, IRequiresSessionState
{

	private int pageSize = 8;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r18"))
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
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (this.jsPager.CurrentPageIndex - 1) * 8);
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected void FillData()
	{
		int recordCount = 0;
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "ServicesItemList", "", this.pageSize, this.jsPager.CurrentPageIndex, "", " ID Desc", out recordCount);
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
		this.tbItemID.Text = string.Empty;
		this.tbName.Text = string.Empty;
		this.tbPrice.Text = string.Empty;
		this.tbPricew.Text = string.Empty;
		this.tbDeduct.Text = string.Empty;
	}

	protected void SetEnable()
	{
		this.tbItemID.Enabled = false;
		this.tbName.Enabled = false;
		this.tbPrice.Enabled = false;
		this.tbPricew.Enabled = false;
		this.tbDeduct.Enabled = false;
	}

	protected void SetDisEnable()
	{
		if (this.cbsys.Checked)
		{
			this.tbItemID.Enabled = false;
		}
		else
		{
			this.tbItemID.Enabled = true;
		}
		this.tbName.Enabled = true;
		this.tbPrice.Enabled = true;
		this.tbPricew.Enabled = true;
		this.tbDeduct.Enabled = true;
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
			ServicesItemListInfo servicesItemListInfo = new ServicesItemListInfo();
			DALServicesItemList dALServicesItemList = new DALServicesItemList();
			servicesItemListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			servicesItemListInfo.ItemNO = FunLibrary.ChkInput(this.tbItemID.Text);
			decimal value = 0m;
			decimal value2 = 0m;
			decimal value3 = 0m;
			decimal.TryParse(this.tbPrice.Text, out value);
			decimal.TryParse(this.tbPricew.Text, out value2);
			decimal.TryParse(this.tbDeduct.Text, out value3);
			servicesItemListInfo.Price = new decimal?(value);
			servicesItemListInfo.WarrantyPrice = new decimal?(value2);
			servicesItemListInfo.TecDeduct = new decimal?(value3);
			servicesItemListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			if (this.hfRecID.Value == "-1")
			{
				this.hfTemp.Value = servicesItemListInfo.ItemNO;
				if (this.cbsys.Checked)
				{
					servicesItemListInfo.ItemNO = DALCommon.CreateID(2, 1);
				}
				string str;
				int num2;
				int num = dALServicesItemList.Add(servicesItemListInfo, out str, out num2);
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
				servicesItemListInfo.ID = int.Parse(this.hfRecID.Value);
				string chkfld = string.Empty;
				if (servicesItemListInfo.ItemNO != this.hfTemp.Value)
				{
					if (this.cbsys.Checked)
					{
						servicesItemListInfo.ItemNO = DALCommon.CreateID(2, 1);
					}
					chkfld = "ItemNO='" + servicesItemListInfo.ItemNO + "'";
				}
				string str;
				int num = dALServicesItemList.Update(servicesItemListInfo, chkfld, out str);
				if (num == 0)
				{
					this.hfRecID.Value = servicesItemListInfo.ID.ToString();
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
			this.hfTemp.Value = servicesItemListInfo.ItemNO;
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
			ServicesItemListInfo servicesItemListInfo = new ServicesItemListInfo();
			DALServicesItemList dALServicesItemList = new DALServicesItemList();
			servicesItemListInfo.ID = int.Parse(this.hfRecID.Value);
			servicesItemListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			servicesItemListInfo.ItemNO = FunLibrary.ChkInput(this.tbItemID.Text);
			decimal value = 0m;
			decimal value2 = 0m;
			decimal value3 = 0m;
			decimal.TryParse(this.tbPrice.Text, out value);
			decimal.TryParse(this.tbPricew.Text, out value2);
			decimal.TryParse(this.tbDeduct.Text, out value3);
			servicesItemListInfo.Price = new decimal?(value);
			servicesItemListInfo.WarrantyPrice = new decimal?(value2);
			servicesItemListInfo.TecDeduct = new decimal?(value3);
			servicesItemListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			string chkfld = string.Empty;
			if (servicesItemListInfo.ItemNO != this.hfTemp.Value)
			{
				if (this.cbsys.Checked)
				{
					servicesItemListInfo.ItemNO = DALCommon.CreateID(2, 1);
				}
				chkfld = "ItemNO='" + servicesItemListInfo.ItemNO + "'";
			}
			string str2;
			int num = dALServicesItemList.Update(servicesItemListInfo, chkfld, out str2);
			if (num == 0)
			{
				this.hfRecID.Value = servicesItemListInfo.ID.ToString();
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
		int num = DALCommon.DeteleData("ServicesItemList", "[ID]=" + this.hfRecID.Value, out empty);
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
			DALServicesItemList dALServicesItemList = new DALServicesItemList();
			ServicesItemListInfo model = dALServicesItemList.GetModel(int.Parse(this.hfRecID.Value));
			this.tbName.Text = model._Name;
			this.hfTemp.Value = model.ItemNO;
			this.tbItemID.Text = model.ItemNO;
			this.tbPrice.Text = Convert.ToDouble(model.Price).ToString("#0.00");
			this.tbPricew.Text = Convert.ToDouble(model.WarrantyPrice).ToString("#0.00");
			this.tbDeduct.Text = Convert.ToDouble(model.TecDeduct).ToString("#0.00");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnRef_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
		this.CleanText();
	}
}
