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

public partial class Headquarters_Basic_ProductModelAdm : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "jc_r11"))
				{
					this.btnAdd.Enabled = false;
					this.btnDel.Enabled = false;
					this.btnMod.Enabled = false;
				}
			}
			this.FillData();
			this.SetEnable();
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
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
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "jc_productmodel", "", this.pageSize, this.jsPager.CurrentPageIndex, "", " ID Desc", out recordCount);
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
		this.tbPeriod.Text = string.Empty;
		this.ddlBrand.ClearSelection();
		this.ddlClass.ClearSelection();
		this.ddlBrand.Items[0].Selected = true;
		this.ddlClass.Items[0].Selected = true;
	}

	protected void SetEnable()
	{
		this.tbName.Enabled = false;
		this.tbPeriod.Enabled = false;
		this.ddlBrand.Enabled = false;
		this.ddlClass.Enabled = false;
	}

	protected void SetDisEnable()
	{
		this.tbName.Enabled = true;
		this.tbPeriod.Enabled = true;
		this.ddlBrand.Enabled = true;
		this.ddlClass.Enabled = true;
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
			ProductModelInfo productModelInfo = new ProductModelInfo();
			DALProductModel dALProductModel = new DALProductModel();
			productModelInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			productModelInfo.BrandID = new int?(int.Parse(this.ddlBrand.SelectedValue));
			productModelInfo.ClassID = new int?(int.Parse(this.ddlClass.SelectedValue));
			int value = 0;
			int.TryParse(this.tbPeriod.Text, out value);
			productModelInfo.Period = new int?(value);
			productModelInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			if (this.hfRecID.Value == "-1")
			{
				this.hfTemp.Value = productModelInfo._Name + productModelInfo.ClassID.ToString() + productModelInfo.BrandID.ToString();
				string str;
				int num2;
				int num = dALProductModel.Add(productModelInfo, out str, out num2);
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
				productModelInfo.ID = int.Parse(this.hfRecID.Value);
				string chkfld = string.Empty;
				if (productModelInfo._Name + productModelInfo.ClassID.ToString() + productModelInfo.BrandID.ToString() != this.hfTemp.Value)
				{
					chkfld = string.Concat(new string[]
					{
						"_Name='",
						productModelInfo._Name,
						"' and ClassID=",
						productModelInfo.ClassID.ToString(),
						" and BrandID=",
						productModelInfo.BrandID.ToString()
					});
				}
				string str;
				int num = dALProductModel.Update(productModelInfo, chkfld, out str);
				if (num == 0)
				{
					this.hfRecID.Value = productModelInfo.ID.ToString();
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
			ProductModelInfo productModelInfo = new ProductModelInfo();
			DALProductModel dALProductModel = new DALProductModel();
			productModelInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			productModelInfo.ID = int.Parse(this.hfRecID.Value);
			productModelInfo.BrandID = new int?(int.Parse(this.ddlBrand.SelectedValue));
			productModelInfo.ClassID = new int?(int.Parse(this.ddlClass.SelectedValue));
			int value = 0;
			int.TryParse(this.tbPeriod.Text, out value);
			productModelInfo.Period = new int?(value);
			productModelInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			string chkfld = string.Empty;
			if (productModelInfo._Name + productModelInfo.ClassID.ToString() + productModelInfo.BrandID.ToString() != this.hfTemp.Value)
			{
				chkfld = string.Concat(new string[]
				{
					"_Name='",
					productModelInfo._Name,
					"' and ClassID=",
					productModelInfo.ClassID.ToString(),
					" and BrandID=",
					productModelInfo.BrandID.ToString()
				});
			}
			string str2;
			int num = dALProductModel.Update(productModelInfo, chkfld, out str2);
			if (num == 0)
			{
				this.hfRecID.Value = productModelInfo.ID.ToString();
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
		int num = DALCommon.DeteleData("ProductModel", "[ID]=" + this.hfRecID.Value, out empty);
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
			DALProductModel dALProductModel = new DALProductModel();
			ProductModelInfo model = dALProductModel.GetModel(int.Parse(this.hfRecID.Value));
			this.tbName.Text = model._Name;
			this.ddlBrand.ClearSelection();
			this.ddlBrand.Items.FindByValue(model.BrandID.ToString()).Selected = true;
			this.ddlClass.ClearSelection();
			this.ddlClass.Items.FindByValue(model.ClassID.ToString()).Selected = true;
			this.tbPeriod.Text = model.Period.ToString();
			this.hfTemp.Value = model._Name + model.ClassID.ToString() + model.BrandID.ToString();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnRefBrand_Click(object sender, EventArgs e)
	{
		OtherFunction.BindProductBrand(this.ddlBrand);
		if (this.hfBrand.Value != string.Empty)
		{
			this.ddlBrand.ClearSelection();
			this.ddlBrand.Items.FindByText(this.hfBrand.Value).Selected = true;
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

	protected void btnRef_Click(object sender, EventArgs e)
	{
		OtherFunction.BindProductBrand(this.ddlBrand);
		OtherFunction.BindProductClass(this.ddlClass);
		this.hfRecID.Value = "-1";
		this.FillData();
	}
}
