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

public partial class Headquarters_Services_DeviceAdd : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.bFaultNoInput)
			{
				this.tbFault.Attributes["onfocus"] = "blur();";
			}
			OtherFunction.BindProductAspect(this.ddlAspect);
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindProductModel(this.ddlModel, "");
			OtherFunction.BindWarranty(this.ddlRepStatus);
			OtherFunction.BindServiceLevel(this.ddlPRI);
			this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
			this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
			this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
			this.ddlAspect.Items.Remove(new ListItem("新建...", "0"));
			this.ddlRepStatus.Items.Remove(new ListItem("新建...", "0"));
		}
	}

	protected void btnChkSN_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbSN1.Text);
		if (text != "")
		{
			string strCondition = " ProductSN1='" + text + "' ";
			DataTable dataTable = DALCommon.GetDataList("ks_device", "", strCondition).Tables[0];
			if (dataTable.Rows.Count == 1)
			{
				OtherFunction.BindProductBrand(this.ddlBrand);
				OtherFunction.BindProductClass(this.ddlClass);
				OtherFunction.BindProductModel(this.ddlModel, "");
				this.ddlBrand.ClearSelection();
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Text == dataTable.Rows[0]["ProductBrand"].ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						break;
					}
				}
				this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
				this.ddlClass.ClearSelection();
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["ProductClass"].ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbClass.Text = dataTable.Rows[0]["ProductClass"].ToString();
				this.ddlModel.ClearSelection();
				for (int i = 0; i < this.ddlModel.Items.Count; i++)
				{
					if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["ProductModel"].ToString())
					{
						this.ddlModel.Items[i].Selected = true;
						break;
					}
				}
				this.tbModel.Text = dataTable.Rows[0]["ProductModel"].ToString();
				this.tbAspect.Text = dataTable.Rows[0]["ProductAspect"].ToString();
				this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
				this.ddlRepStatus.ClearSelection();
				this.ddlRepStatus.Items.FindByText(dataTable.Rows[0]["Warranty"].ToString()).Selected = true;
				this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
				this.tbBuyTime.Text = dataTable.Rows[0]["BuyDate"].ToString();
				this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
				this.hfDevID.Value = dataTable.Rows[0]["ID"].ToString();
				this.tbDeviceNO.Text = dataTable.Rows[0]["DeviceNO"].ToString();
			}
			else
			{
				this.hfDevID.Value = "";
			}
		}
	}

	protected void btnChkNO_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbDeviceNO.Text);
		if (text != "")
		{
			string strCondition = " DeviceNO='" + text + "' ";
			DataTable dataTable = DALCommon.GetDataList("ks_device", "", strCondition).Tables[0];
			if (dataTable.Rows.Count == 1)
			{
				OtherFunction.BindProductBrand(this.ddlBrand);
				OtherFunction.BindProductClass(this.ddlClass);
				OtherFunction.BindProductModel(this.ddlModel, "");
				this.ddlBrand.ClearSelection();
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Text == dataTable.Rows[0]["ProductBrand"].ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						break;
					}
				}
				this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
				this.ddlClass.ClearSelection();
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["ProductClass"].ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbClass.Text = dataTable.Rows[0]["ProductClass"].ToString();
				this.ddlModel.ClearSelection();
				for (int i = 0; i < this.ddlModel.Items.Count; i++)
				{
					if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["ProductModel"].ToString())
					{
						this.ddlModel.Items[i].Selected = true;
						break;
					}
				}
				this.tbModel.Text = dataTable.Rows[0]["ProductModel"].ToString();
				this.tbAspect.Text = dataTable.Rows[0]["ProductAspect"].ToString();
				this.tbSN1.Text = dataTable.Rows[0]["ProductSN1"].ToString();
				this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
				this.ddlRepStatus.ClearSelection();
				this.ddlRepStatus.Items.FindByText(dataTable.Rows[0]["Warranty"].ToString()).Selected = true;
				this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
				this.tbBuyTime.Text = dataTable.Rows[0]["BuyDate"].ToString();
				this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
				this.hfDevID.Value = dataTable.Rows[0]["ID"].ToString();
			}
			else
			{
				this.hfDevID.Value = "";
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		text = FunLibrary.ChkInput(this.tbDeviceNO.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbBrand.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbClass.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbModel.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbSN1.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbSN2.Text) + ",";
		text = text + this.ddlRepStatus.SelectedItem.Text + ",";
		text = text + FunLibrary.ChkInput(this.tbAspect.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbFault.Text).Replace(",", "^") + ",";
		text = text + FunLibrary.ChkInput(this.tbAcc.Text) + ",";
		text = text + this.ddlPRI.SelectedItem.Text + ",";
		text = text + FunLibrary.ChkInput(this.tbBuyFrom.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbBuyTime.Text) + ",";
		text = text + FunLibrary.ChkInput(this.tbBuyInvoice.Text) + ",";
		decimal num = 0m;
		decimal.TryParse(this.tbPoint.Text, out num);
		text = text + num.ToString() + ",";
		text = text + this.cbRe.Checked.ToString() + ",";
		text = text + this.ddlBrand.SelectedValue + ",";
		text = text + this.ddlClass.SelectedValue + ",";
		text = text + this.ddlModel.SelectedValue + ",";
		text = text + this.ddlRepStatus.SelectedValue + ",";
		text = text + this.ddlPRI.SelectedValue + ",";
		text += this.hfFault.Value.Replace(",", "^");
		this.SysInfo("ChkAdd('" + text + "');");
		if (!this.cbClose.Checked)
		{
			this.ClearText();
		}
	}

	public void ClearText()
	{
		this.tbBrand.Text = string.Empty;
		this.tbClass.Text = string.Empty;
		this.tbModel.Text = string.Empty;
		this.ddlBrand.ClearSelection();
		this.ddlClass.ClearSelection();
		this.ddlModel.ClearSelection();
		for (int i = 0; i < this.ddlBrand.Items.Count; i++)
		{
			if (this.ddlBrand.Items[i].Text == "")
			{
				this.ddlBrand.Items[i].Selected = false;
				break;
			}
		}
		for (int i = 0; i < this.ddlClass.Items.Count; i++)
		{
			if (this.ddlClass.Items[i].Text == "")
			{
				this.ddlClass.Items[i].Selected = false;
				break;
			}
		}
		for (int i = 0; i < this.ddlModel.Items.Count; i++)
		{
			if (this.ddlModel.Items[i].Text == "")
			{
				this.ddlModel.Items[i].Selected = false;
				break;
			}
		}
		this.tbAspect.Text = string.Empty;
		this.tbSN1.Text = string.Empty;
		this.tbSN2.Text = string.Empty;
		this.tbAcc.Text = string.Empty;
		this.tbBuyFrom.Text = string.Empty;
		this.tbBuyTime.Text = string.Empty;
		this.tbBuyInvoice.Text = string.Empty;
		this.tbFault.Text = string.Empty;
		this.ddlRepStatus.ClearSelection();
		this.ddlPRI.ClearSelection();
		this.cbRe.Checked = false;
		this.tbPoint.Text = string.Empty;
		this.tbDeviceNO.Text = string.Empty;
		this.hfNO.Value = (this.hfSN.Value = "");
		this.hfFault.Value = "";
	}

	protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.GetProductModel();
	}

	protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.GetProductModel();
	}

	protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlModel.SelectedValue != "-1")
		{
			DataTable dataTable = DALCommon.GetDataList("jc_productmodel", "", "ID=" + this.ddlModel.SelectedValue).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.ddlBrand.ClearSelection();
				this.ddlBrand.Items.FindByText(dataTable.Rows[0]["Brand"].ToString()).Selected = true;
				this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
				this.ddlClass.ClearSelection();
				this.ddlClass.Items.FindByText(dataTable.Rows[0]["Class"].ToString()).Selected = true;
				this.tbClass.Text = this.ddlClass.SelectedItem.Text;
			}
		}
	}

	protected void GetProductModel()
	{
		string text = string.Empty;
		if (this.ddlBrand.SelectedValue != "0" && this.ddlBrand.SelectedValue != "-1")
		{
			text = text + " BrandID=" + this.ddlBrand.SelectedValue;
		}
		if (this.ddlClass.SelectedValue != "0" && this.ddlClass.SelectedValue != "-1")
		{
			if (text == string.Empty)
			{
				text = text + " ClassID=" + this.ddlClass.SelectedValue;
			}
			else
			{
				text = text + " and ClassID=" + this.ddlClass.SelectedValue;
			}
		}
		this.tbModel.Text = "";
		OtherFunction.BindProductModel(this.ddlModel, text);
		this.ddlBrand.Items.Remove(new ListItem("新建...", "0"));
		this.ddlClass.Items.Remove(new ListItem("新建...", "0"));
		this.ddlModel.Items.Remove(new ListItem("新建...", "0"));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
