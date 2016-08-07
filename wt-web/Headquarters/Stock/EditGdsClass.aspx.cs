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

public partial class Headquarters_Stock_EditGdsClass : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "ck_r4"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			int num2 = 0;
			this.slGdsClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "GoodsClass", "", 0, 0, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slGdsClass);
			OtherFunction.BindStock(this.ddlDefaultstock, " DeptID=1 and bStop=0");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int icbGoodType;
		if (this.cbGoodType.Checked)
		{
			icbGoodType = 1;
		}
		else
		{
			icbGoodType = 0;
		}
		int iDefaultstock;
		if (this.cbDefaultstock.Checked)
		{
			iDefaultstock = 1;
		}
		else
		{
			iDefaultstock = 0;
		}
		int ibStock;
		if (this.cbbStock.Checked)
		{
			ibStock = 1;
		}
		else
		{
			ibStock = 0;
		}
		int ibSNTrack;
		if (this.cbSNTrack.Checked)
		{
			ibSNTrack = 1;
		}
		else
		{
			ibSNTrack = 0;
		}
		int iMainTenancePeriod;
		if (this.cbMainTenancePeriod.Checked)
		{
			iMainTenancePeriod = 1;
		}
		else
		{
			iMainTenancePeriod = 0;
		}
		string value = this.slGdsClass.Items[this.slGdsClass.SelectedIndex].Value;
		int int_stockid = int.Parse(this.ddlDefaultstock.SelectedValue);
		int int_bStock = 0;
		if (int.Parse(this.ddlBStock.SelectedValue) == 1)
		{
			int_bStock = 1;
		}
		if (int.Parse(this.ddlBStock.SelectedValue) == 2)
		{
			int_bStock = 0;
		}
		int int_bSNtrack = 0;
		if (int.Parse(this.ddlSNTrack.SelectedValue) == 1)
		{
			int_bSNtrack = 1;
		}
		if (int.Parse(this.ddlSNTrack.SelectedValue) == 2)
		{
			int_bSNtrack = 0;
		}
		string str_MainTenancePeriod = FunLibrary.ChkInput(this.tbProt.Value);
		DALGoods dALGoods = new DALGoods();
		int num = 0;
		dALGoods.UpdateClass(this.id.TrimEnd(new char[]
		{
			','
		}), icbGoodType, iDefaultstock, ibStock, ibSNTrack, iMainTenancePeriod, value, int_stockid, int_bStock, int_bSNtrack, str_MainTenancePeriod);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！产品信息已修改！');");
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

	protected void cbGoodType_CheckedChanged(object sender, EventArgs e)
	{
		this.ddlBStock.Enabled = true;
		this.ddlDefaultstock.Enabled = true;
		this.ddlSNTrack.Enabled = true;
	}
}
