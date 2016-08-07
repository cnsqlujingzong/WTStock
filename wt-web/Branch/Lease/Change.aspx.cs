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

public partial class Branch_Lease_Change : Page, IRequiresSessionState
{
	private int id;

	private static decimal dinputcount = 0m;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int rightID = int.Parse((string)this.Session["Session_wtPurBID"]);
			DALRight dALRight = new DALRight();
			if (!dALRight.GetRight(rightID, "zl_r6"))
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
				base.Response.End();
			}
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindProductClass(this.ddlClass);
			OtherFunction.BindProductModel(this.ddlModel, "");
			OtherFunction.BindStocks(this.ddlInStock, " DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]) + " and bStop=0 ");
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]) + " and bStop=0 ");
			DataTable dataTable = DALCommon.GetDataList("zl_leasedevice", "", string.Concat(new object[]
			{
				"  [ID]=",
				this.id.ToString(),
				" and DeptID=",
				this.Session["Session_wtBranchID"]
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Text == dataTable.Rows[0]["Brand"].ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
						break;
					}
				}
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["Class"].ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						this.tbClass.Text = this.ddlClass.SelectedItem.Text;
						break;
					}
				}
				for (int i = 0; i < this.ddlModel.Items.Count; i++)
				{
					if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["Model"].ToString())
					{
						this.ddlModel.Items[i].Selected = true;
						this.tbModel.Text = this.ddlModel.SelectedItem.Text;
						break;
					}
				}
				for (int i = 0; i < this.ddlInStock.Items.Count; i++)
				{
					if (this.ddlInStock.Items[i].Text == dataTable.Rows[0]["StockName"].ToString())
					{
						this.ddlInStock.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlStock.Items.Count; i++)
				{
					if (this.ddlStock.Items[i].Text == dataTable.Rows[0]["StockName"].ToString())
					{
						this.ddlStock.Items[i].Selected = true;
						break;
					}
				}
				if (dataTable.Rows[0]["iCount"].ToString() != "")
				{
					decimal.TryParse(dataTable.Rows[0]["iCount"].ToString(), out Branch_Lease_Change.dinputcount);
				}
				if (Branch_Lease_Change.dinputcount == 0m)
				{
					Branch_Lease_Change.dinputcount = 1m;
				}
				this.tbInCount.Text = Branch_Lease_Change.dinputcount.ToString();
				this.hfGoodsNO.Value = (this.tbGoodsNO.Text = dataTable.Rows[0]["GoodsNO"].ToString());
				this.hfGoodsID.Value = dataTable.Rows[0]["GoodsID"].ToString();
				this.hfType.Value = dataTable.Rows[0]["Type"].ToString();
				this.tbQty.Text = dataTable.Rows[0]["StrQty"].ToString();
				if (dataTable.Rows[0]["Type"].ToString() == "非抄表类租赁")
				{
					this.tbOutCount.Visible = true;
					this.lbCount.Text = "出库数量：";
					this.edit.Visible = false;
					this.lbInCount.Visible = true;
					this.tbInCount.Visible = true;
					this.tr.Visible = true;
				}
				else
				{
					this.tbOutCount.Visible = false;
					this.lbCount.Text = "计数器：";
					this.edit.Visible = true;
					this.lbInCount.Visible = false;
					this.tbInCount.Visible = false;
					this.tr.Visible = false;
				}
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.ddlGoodsName.Items.Add(new ListItem(dataTable.Rows[i]["GoodsNO"].ToString(), dataTable.Rows[i]["GoodsID"].ToString()));
				}
			}
		}
	}

	protected void btngetgds_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbGoodsNO.Text);
		if (this.hfGoodsID.Value != "" || text != "")
		{
			string strCondition;
			if (text != "")
			{
				strCondition = "GoodsNO='" + text + "'";
			}
			else
			{
				strCondition = "[ID]=" + this.hfGoodsID.Value;
			}
			DataTable dataTable = DALCommon.GetDataList("ck_goods", "[ID],GoodsNO,_Name,BrandID,ClassName,Spec,StockID", strCondition).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.hfGoodsNO.Value = (this.tbGoodsNO.Text = dataTable.Rows[0]["GoodsNO"].ToString() + " " + dataTable.Rows[0]["_Name"].ToString());
				this.hfGoodsID.Value = dataTable.Rows[0]["ID"].ToString();
				if (this.ddlStock.SelectedValue == "-1")
				{
					this.ddlStock.ClearSelection();
					for (int i = 0; i < this.ddlStock.Items.Count; i++)
					{
						if (this.ddlStock.Items[i].Value == dataTable.Rows[0]["StockID"].ToString())
						{
							this.ddlStock.Items[i].Selected = true;
							break;
						}
					}
				}
				this.ddlBrand.ClearSelection();
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Value == dataTable.Rows[0]["BrandID"].ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						this.tbBrand.Text = this.ddlBrand.Items[i].Text;
						break;
					}
				}
				if (this.ddlBrand.SelectedValue == "-1")
				{
					this.tbBrand.Text = "";
				}
				this.ddlClass.ClearSelection();
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["ClassName"].ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						this.tbClass.Text = this.ddlClass.Items[i].Text;
						break;
					}
				}
				if (this.ddlClass.SelectedValue == "-1")
				{
					this.tbClass.Text = "";
				}
				this.ddlModel.ClearSelection();
				for (int i = 0; i < this.ddlModel.Items.Count; i++)
				{
					if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["Spec"].ToString())
					{
						this.ddlModel.Items[i].Selected = true;
						this.tbModel.Text = this.ddlModel.Items[i].Text;
						break;
					}
				}
				if (this.ddlModel.SelectedValue == "-1")
				{
					this.tbModel.Text = "";
				}
			}
		}
	}

	protected void btnsngetgds_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbSN.Text);
		if (this.hfSNID.Value != "" || text != "")
		{
			string strCondition;
			if (text != "")
			{
				strCondition = " SN='" + text + "'";
			}
			else
			{
				strCondition = "[ID]=" + this.hfSNID.Value;
			}
			DataTable dataTable = DALCommon.GetDataList("ck_stocksn", "[GoodsID],GoodsNO,_Name,BrandID,ClassName,Spec,StockID,SN", strCondition).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbGoodsNO.Text = dataTable.Rows[0]["GoodsNO"].ToString() + " " + dataTable.Rows[0]["_Name"].ToString();
				this.hfGoodsID.Value = dataTable.Rows[0]["GoodsID"].ToString();
				if (this.ddlStock.SelectedValue == "-1")
				{
					this.ddlStock.ClearSelection();
					for (int i = 0; i < this.ddlStock.Items.Count; i++)
					{
						if (this.ddlStock.Items[i].Value == dataTable.Rows[0]["StockID"].ToString())
						{
							this.ddlStock.Items[i].Selected = true;
							break;
						}
					}
				}
				this.ddlBrand.ClearSelection();
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Value == dataTable.Rows[0]["BrandID"].ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						this.tbBrand.Text = this.ddlBrand.Items[i].Text;
						break;
					}
				}
				if (this.ddlBrand.SelectedValue == "-1")
				{
					this.tbBrand.Text = "";
				}
				this.ddlClass.ClearSelection();
				for (int i = 0; i < this.ddlClass.Items.Count; i++)
				{
					if (this.ddlClass.Items[i].Text == dataTable.Rows[0]["ClassName"].ToString())
					{
						this.ddlClass.Items[i].Selected = true;
						this.tbClass.Text = this.ddlClass.Items[i].Text;
						break;
					}
				}
				if (this.ddlClass.SelectedValue == "-1")
				{
					this.tbClass.Text = "";
				}
				this.ddlModel.ClearSelection();
				for (int i = 0; i < this.ddlModel.Items.Count; i++)
				{
					if (this.ddlModel.Items[i].Text == dataTable.Rows[0]["Spec"].ToString())
					{
						this.ddlModel.Items[i].Selected = true;
						this.tbModel.Text = this.ddlModel.Items[i].Text;
						break;
					}
				}
				if (this.ddlModel.SelectedValue == "-1")
				{
					this.tbModel.Text = "";
				}
				this.hfSN.Value = (this.tbSN.Text = dataTable.Rows[0]["SN"].ToString());
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int iGoodsid = 0;
		int.TryParse(this.hfGoodsID.Value, out iGoodsid);
		int iInStockid = int.Parse(this.ddlInStock.SelectedValue);
		int num = 0;
		int.TryParse(this.tbInCount.Text, out num);
		if (num == 0)
		{
			num = 1;
		}
		int ingoodsID = int.Parse(this.ddlGoodsName.SelectedValue);
		decimal dPrice = 0m;
		decimal.TryParse(this.tbPrice.Text, out dPrice);
		decimal num2 = 0m;
		decimal doutprice = 0m;
		decimal.TryParse(this.tbOutPrice.Text, out doutprice);
		if (this.hfType.Value == "租赁")
		{
			num2 = Branch_Lease_Change.dinputcount;
		}
		else
		{
			decimal.TryParse(this.tbOutCount.Text, out num2);
			if (num2 == 0m)
			{
				num2 = 1m;
			}
		}
		string str = "";
		DALLease dALLease = new DALLease();
		int num3 = dALLease.ChkZLHJ(doutprice, num, ingoodsID, this.id, int.Parse(this.ddlBrand.SelectedValue), int.Parse(this.ddlClass.SelectedValue), int.Parse(this.ddlModel.SelectedValue), FunLibrary.ChkInput(this.tbSN.Text), iInStockid, dPrice, iGoodsid, int.Parse(this.ddlStock.SelectedValue), int.Parse(this.Session["Session_wtUserBID"].ToString()), FunLibrary.ChkInput(this.tbDeviceNO.Text), FunLibrary.ChkInput(this.tbQty.Text), num2, out str);
		if (num3 == 0)
		{
			if (this.tbQty.Text.Contains(";"))
			{
				string[] array = this.tbQty.Text.Split(new char[]
				{
					';'
				});
				for (int i = 0; i < array.Length; i++)
				{
					this.insertCount(array[i], array.Length - 1 - i);
				}
			}
			else
			{
				this.insertCount(this.tbQty.Text, 0);
			}
			this.SysInfo("window.alert('操作成功！机器已更换');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + str + "');");
		}
	}

	private void insertCount(string strs, int count)
	{
		DALLease dALLease = new DALLease();
		string[] array = strs.Split(new char[]
		{
			','
		});
		string qtyName = string.Empty;
		string s = string.Empty;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		if (array.Length > 1)
		{
			qtyName = array[0];
			s = array[1];
			text2 = array[2];
			text = array[3];
			text3 = array[4];
			text4 = array[5];
		}
		int num = dALLease.getLastMeterReadingID() + 1;
		int lastDeviceID = dALLease.getLastDeviceID();
		int qty = 0;
		int.TryParse(s, out qty);
		int qtyType = dALLease.getQtyType(qtyName);
		int leaseDeviceID = dALLease.getLeaseDeviceID();
		bool flag = true;
		if (leaseDeviceID == 0)
		{
			flag = false;
			this.SysInfo("window.alert('该次换机之后需做首次抄表！');");
		}
		if (flag)
		{
			dALLease.insertValue(num, leaseDeviceID - count, lastDeviceID, int.Parse(this.Session["Session_wtUserBID"].ToString()), qtyType, qty);
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void btnRefBrand_Click(object sender, EventArgs e)
	{
		OtherFunction.BindProductBrand(this.ddlBrand);
		if (this.hfBrand.Value != string.Empty)
		{
			this.ddlBrand.ClearSelection();
			this.ddlBrand.Items.FindByText(this.hfBrand.Value).Selected = true;
			this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
		}
	}

	protected void btnRefClass_Click(object sender, EventArgs e)
	{
		OtherFunction.BindProductClass(this.ddlClass);
		if (this.hfClass.Value != string.Empty)
		{
			this.ddlClass.ClearSelection();
			this.ddlClass.Items.FindByText(this.hfClass.Value).Selected = true;
			this.tbClass.Text = this.ddlClass.SelectedItem.Text;
		}
	}

	protected void btnRefModel_Click(object sender, EventArgs e)
	{
		if (this.hfModelID.Value != "")
		{
			OtherFunction.BindProductModel(this.ddlModel, "");
			DataTable dataTable = DALCommon.GetDataList("jc_productmodel", "", "ID=" + this.hfModelID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.ddlBrand.ClearSelection();
				this.ddlBrand.Items.FindByText(dataTable.Rows[0]["Brand"].ToString()).Selected = true;
				this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
				this.ddlClass.ClearSelection();
				this.ddlClass.Items.FindByText(dataTable.Rows[0]["Class"].ToString()).Selected = true;
				this.tbClass.Text = this.ddlClass.SelectedItem.Text;
				this.ddlModel.ClearSelection();
				this.ddlModel.Items.FindByText(dataTable.Rows[0]["_Name"].ToString()).Selected = true;
				this.tbModel.Text = this.ddlModel.SelectedItem.Text;
			}
		}
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
	}
}
