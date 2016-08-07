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

public partial class Headquarters_Stock_WarningMod : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].ToString().Replace("s", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			OtherFunction.BindStockLoc(this.ddlStockLoc, "DeptID=1");
			DALStockDept dALStockDept = new DALStockDept();
			StockDeptInfo model = dALStockDept.GetModel(this.id);
			if (model != null)
			{
				this.tbStockName.Text = model.StockName;
				this.tbGoodsNO.Text = model.GoodsNO;
				this.tbName.Text = model._Name;
				this.tbStock.Text = model.Stock.ToString("#0.00");
				this.tbCost.Text = model.CostPrice.ToString("#0.00");
				this.tbDownwarning.Text = model.downWarning.ToString("#0.00");
				this.tbUpwarning.Text = model.upWarning.ToString("#0.00");
				this.tbRemark.Text = model.Remark;
				for (int i = 0; i < this.ddlStockLoc.Items.Count; i++)
				{
					if (this.ddlStockLoc.Items[i].Value == model.StockLocID.ToString())
					{
						this.ddlStockLoc.Items[i].Selected = true;
						break;
					}
				}
				if (model.DeptID > 1)
				{
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "总部只能修改自己的分仓库信息.";
					this.lbMod.Attributes.Add("class", "si3");
				}
				int num = int.Parse((string)this.Session["Session_wtPurID"]);
				if (num > 0)
				{
					DALRight dALRight = new DALRight();
					if (dALRight.GetRight(num, "jc_r36"))
					{
						this.tbCost.Visible = false;
					}
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALStockDept dALStockDept = new DALStockDept();
		StockDeptInfo stockDeptInfo = new StockDeptInfo();
		stockDeptInfo.ID = this.id;
		stockDeptInfo.StockLocID = int.Parse(this.ddlStockLoc.SelectedValue);
		decimal num = 0m;
		decimal.TryParse(this.tbDownwarning.Text, out num);
		stockDeptInfo.downWarning = num;
		decimal.TryParse(this.tbUpwarning.Text, out num);
		stockDeptInfo.upWarning = num;
		stockDeptInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		string str = "";
		int num2 = dALStockDept.Update(stockDeptInfo, out str);
		if (num2 == 0)
		{
			this.SysInfo("parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert(\"" + str + "\");");
		}
	}

	protected void btnStockLoc_Click(object sender, EventArgs e)
	{
		if (this.hfStockLoc.Value != string.Empty)
		{
			OtherFunction.BindStockLoc(this.ddlStockLoc, "DeptID=1");
			this.ddlStockLoc.ClearSelection();
			this.ddlStockLoc.Items.FindByText(this.hfStockLoc.Value).Selected = true;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
