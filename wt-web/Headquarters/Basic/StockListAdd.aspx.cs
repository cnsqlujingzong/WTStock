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

public partial class Headquarters_Basic_StockListAdd : Page, IRequiresSessionState
{
	private string f;

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.f = base.Request["f"];
		if (this.f == null)
		{
			this.f = string.Empty;
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r8"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlStkAdm, "bStockMan=1 and DeptID=1 ");
			OtherFunction.BindStaff(this.ddlStkAdm2, "bStockMan=1 and DeptID=1 ");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		StockListInfo stockListInfo = new StockListInfo();
		stockListInfo.DeptID = new int?(1);
		stockListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		stockListInfo.StockAdmID1 = new int?(int.Parse(this.ddlStkAdm.SelectedValue));
		stockListInfo.StockAdmID2 = new int?(int.Parse(this.ddlStkAdm2.SelectedValue));
		int num;
		int.TryParse(this.ddlAttr.SelectedValue, out num);
		if (num == 1)
		{
			stockListInfo.bReject = true;
		}
		else
		{
			stockListInfo.bReject = false;
		}
		stockListInfo.bStop = this.bStop.Checked;
		stockListInfo.StockSite = FunLibrary.ChkInput(this.tbAdr.Text);
		stockListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		stockListInfo.OtherStockAdm = FunLibrary.ChkInput(this.tbStkAdms.Text);
		DALStockList dALStockList = new DALStockList();
		string str;
		int num3;
		int num2 = dALStockList.Add(stockListInfo, out str, out num3);
		if (num2 == 0)
		{
			if (this.f == "")
			{
				if (this.cbClose.Checked)
				{
					this.SysInfo("parent.CloseDialog('1');");
				}
				else
				{
					this.SysInfo("$('tbName').select();");
					this.ClearText();
				}
			}
			else
			{
				if (this.bStop.Checked)
				{
					stockListInfo._Name = "";
				}
				if (this.f == "1")
				{
					this.SysInfo("parent.CloseDialog1();parent.iframeDialog.$(\"hfStock\").value='" + stockListInfo._Name + "';parent.iframeDialog.$(\"btnRefStock\").click();");
				}
				else
				{
					this.SysInfo("parent.CloseDialog2();parent.iframeDialog1.$(\"hfStock\").value='" + stockListInfo._Name + "';parent.iframeDialog1.$(\"btnRefStock\").click();");
				}
			}
		}
		else if (num2 == -1)
		{
			this.SysInfo("window.alert('" + str + "');$('tbName').select();");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
		}
	}

	protected void ClearText()
	{
		this.tbName.Text = (this.tbAdr.Text = (this.tbRemark.Text = ""));
		this.ddlStkAdm.ClearSelection();
		this.ddlStkAdm.Items.FindByValue("-1").Selected = true;
		this.ddlStkAdm2.ClearSelection();
		this.ddlStkAdm2.Items.FindByValue("-1").Selected = true;
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
