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

public partial class Headquarters_Basic_StockListMod : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
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
			OtherFunction.BindStaff(this.ddlStkAdm, " DeptID=1 ");
			OtherFunction.BindStaff(this.ddlStkAdm2, " DeptID=1 ");
			DALStockList dALStockList = new DALStockList();
			StockListInfo model = dALStockList.GetModel(this.id);
			if (model != null)
			{
				this.hfName.Value = (this.tbName.Text = model._Name);
				this.tbAdr.Text = model.StockSite;
				this.tbRemark.Text = model.Remark;
				this.bStop.Checked = model.bStop;
				this.tbStkAdms.Text = model.OtherStockAdm;
				if (model.bReject)
				{
					this.ddlAttr.Items.FindByText("��Ʒ").Selected = true;
				}
				for (int i = 0; i < this.ddlStkAdm.Items.Count; i++)
				{
					if (this.ddlStkAdm.Items[i].Value == model.StockAdmID1.ToString())
					{
						this.ddlStkAdm.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlStkAdm2.Items.Count; i++)
				{
					if (this.ddlStkAdm2.Items[i].Value == model.StockAdmID2.ToString())
					{
						this.ddlStkAdm2.Items[i].Selected = true;
						break;
					}
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		StockListInfo stockListInfo = new StockListInfo();
		stockListInfo.ID = this.id;
		stockListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		stockListInfo.StockAdmID1 = new int?(int.Parse(this.ddlStkAdm.SelectedValue));
		stockListInfo.StockAdmID2 = new int?(int.Parse(this.ddlStkAdm2.SelectedValue));
		stockListInfo.StockSite = FunLibrary.ChkInput(this.tbAdr.Text);
		stockListInfo.bStop = this.bStop.Checked;
		stockListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		stockListInfo.OtherStockAdm = FunLibrary.ChkInput(this.tbStkAdms.Text);
		string chkfld = string.Empty;
		if (stockListInfo._Name != this.hfName.Value)
		{
			chkfld = " _Name='" + stockListInfo._Name + "' and DeptID is null";
		}
		DALStockList dALStockList = new DALStockList();
		string str;
		int num = dALStockList.Update(stockListInfo, chkfld, out str);
		if (num == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + str + "');$('tbName').select();");
		}
		else
		{
			this.SysInfo("window.alert('ϵͳ������鿴������־');$('tbName').select();");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
