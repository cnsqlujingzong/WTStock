using System;
using System.Collections.Generic;
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

public partial class Headquarters_Stock_AllocateMod : Page, IRequiresSessionState
{
	private int id;

	private string ids;

	private string f;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

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
		DALAllocate dALAllocate = new DALAllocate();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			if (base.Request["ids"] != null)
			{
				this.id = dALAllocate.GetIds(base.Request["ids"].Trim());
			}
		}
		if (this.id == 0)
		{
			base.Response.End();
		}
		this.f = base.Request["f"];
		if (this.f == null || this.f == "")
		{
			this.f = "";
		}
		string text = base.Request["n"];
		if (text == "1" && text != null)
		{
			this.btnAdd.Visible = false;
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r37"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r44"))
				{
					this.btnPrint.Visible = false;
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			OtherFunction.BindBranch(this.ddlAppBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("", "-1"));
			AllocateInfo model = dALAllocate.GetModel(this.id);
			OtherFunction.BindStaff(this.ddlOperator, "(DeptID=1 and Status=0) or ID=" + model.PersonID);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				this.ddlAppBranch.SelectedValue = model.FromDept.ToString();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.PersonID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlBranch.Items.Count; i++)
				{
					if (this.ddlBranch.Items[i].Value == model.ToDept.ToString())
					{
						this.ddlBranch.Items[i].Selected = true;
						break;
					}
				}
				this.tbRemark.Text = model.Remark;
				this.tbAQty.Text = "0.00";
				this.AddEmpty();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("ck_allocatedetail", "", " BillID=" + this.id.ToString()).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[5] = decimal.Parse(dataTable.Rows[i]["AppQty"].ToString()).ToString("#0.00");
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()).ToString("#0.00");
					dataRow[7] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[8] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[9] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					dataRow[10] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
					dataRow[11] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[12] = 1;
					this.tbAQty.Text = Convert.ToDouble(decimal.Parse(this.tbAQty.Text) + decimal.Parse(dataTable.Rows[i]["AppQty"].ToString())).ToString("#0.00");
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
				if (model.Status != 1 && model.Status != 6)
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "只有待审核的调拨单才能修改！";
					this.lbMod.Attributes.Add("class", "si2");
				}
				else
				{
					this.lbMod.Text = "若手工输入编号或条码，输入完成后回车";
					this.lbMod.Attributes.Add("class", "si1");
				}
				if (model.FromDept != 1 && model.PersonID != int.Parse(this.Session["Session_wtUserID"].ToString()))
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.lbMod.Text = "总部只能修改自己的调拨单.";
					this.lbMod.Attributes.Add("class", "si2");
				}
			}
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = "";
		dataRow[8] = "";
		dataRow[9] = 0;
		dataRow[10] = 0;
		dataRow[11] = 0;
		dataRow[12] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			LinkButton linkButton = e.Row.FindControl("lbDel") as LinkButton;
			textBox.Attributes.Add("oldNum", textBox.Text);
			linkButton.Attributes.Add("num", e.Row.RowIndex.ToString());
			linkButton.Attributes.Add("onclick", "ChkAmounta(this,'" + textBox.ClientID + "');");
			textBox.Attributes.Add("onchange", "ValidateNuma(this);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[7].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
			e.Row.Cells[7].Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[7].Attributes.Add("ondblclick", "SltUnit1();");
			e.Row.Cells[8].Attributes.Add("class", "tbbg");
			e.Row.Cells[10].Attributes.Add("class", "tbbg");
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ck_goods", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		int num = 3;
		if (sysParm != null)
		{
			num = sysParm.AllocatePrice;
		}
		string text = "$('" + this.tbCon.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < gridViewSource.Rows.Count; j++)
				{
					if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
					{
						decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						flag = false;
					}
				}
				if (flag)
				{
					decimal num2;
					switch (num)
					{
					case 1:
						num2 = decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString());
						break;
					case 2:
						num2 = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
						break;
					case 3:
						num2 = decimal.Parse(dataTable.Rows[i]["PriceInner"].ToString());
						break;
					case 4:
						num2 = decimal.Parse(dataTable.Rows[i]["PriceWholesale1"].ToString());
						break;
					case 5:
						num2 = decimal.Parse(dataTable.Rows[i]["PriceWholesale2"].ToString());
						break;
					case 6:
						num2 = decimal.Parse(dataTable.Rows[i]["PriceWholesale3"].ToString());
						break;
					default:
						num2 = decimal.Parse(dataTable.Rows[i]["PriceInner"].ToString());
						break;
					}
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[5] = 1;
					dataRow[6] = num2;
					dataRow[7] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[8] = "";
					dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
					dataRow[11] = 0;
					dataRow[12] = 0;
					decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
		else
		{
			text += "window.alert('操作失败！没有该产品信息');";
		}
		this.SysInfo(text);
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfreclist.Value.EndsWith(","))
		{
			text = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfreclist.Value;
		}
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		int num = 3;
		if (sysParm != null)
		{
			num = sysParm.AllocatePrice;
		}
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							string text2 = gridViewSource.Rows[i]["Qty"].ToString();
							decimal Qty = decimal.Parse(gridViewSource.Rows[j]["Qty"].ToString());  ++Qty; gridViewSource.Rows[j]["Qty"] = Qty;
							decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
							flag = false;
						}
					}
					if (flag)
					{
						decimal num2;
						switch (num)
						{
						case 1:
							num2 = decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString());
							break;
						case 2:
							num2 = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
							break;
						case 3:
							num2 = decimal.Parse(dataTable.Rows[i]["PriceInner"].ToString());
							break;
						case 4:
							num2 = decimal.Parse(dataTable.Rows[i]["PriceWholesale1"].ToString());
							break;
						case 5:
							num2 = decimal.Parse(dataTable.Rows[i]["PriceWholesale2"].ToString());
							break;
						case 6:
							num2 = decimal.Parse(dataTable.Rows[i]["PriceWholesale3"].ToString());
							break;
						default:
							num2 = decimal.Parse(dataTable.Rows[i]["PriceInner"].ToString());
							break;
						}
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[5] = 1;
						dataRow[6] = num2;
						dataRow[7] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[8] = "";
						dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
						dataRow[11] = 0;
						dataRow[12] = 0;
						decimal AQty=decimal.Parse(this.tbAQty.Text);  ++AQty; this.tbAQty.Text = Convert.ToDouble(AQty).ToString("#0.00");
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.SysInfo("$('tbCon').focus();");
	}

	protected void btnSltUnit_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["GoodsID"].ToString() == this.hfRecID.Value.Replace("u", ""))
			{
				gridViewSource.Rows[i][4] = this.hfName.Value;
				gridViewSource.Rows[i][10] = int.Parse(this.hfRecIDs.Value);
				DataTable dataTable = DALCommon.GetDataList("GoodsUnit", "", "[ID]=" + this.hfRecID.Value.Replace("u", "")).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					gridViewSource.Rows[i][6] = decimal.Parse(dataTable.Rows[0]["PriceInner"].ToString());
				}
			}
		}
		this.BindData();
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void CollectData()
	{
		decimal d = 0m;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox2.Text);
			d += decimal.Parse(textBox.Text);
		}
		this.tbAQty.Text = d.ToString("#0.00");
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (i == e.RowIndex)
			{
				if (int.Parse(gridViewSource.Rows[i]["iFlag"].ToString()) == 1)
				{
					if (this.hfdellist.Value == string.Empty)
					{
						this.hfdellist.Value = gridViewSource.Rows[i]["RecID"].ToString();
					}
					else
					{
						HiddenField expr_AA = this.hfdellist;
						expr_AA.Value = expr_AA.Value + "," + gridViewSource.Rows[i]["RecID"].ToString();
					}
				}
			}
		}
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.tbAQty.Text = "0.00";
		this.AddEmpty();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		this.BindData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			string str;
			int num = this.BillUpdate(out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该调拨单已保存');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected int BillUpdate(out string strMsg)
	{
		AllocateInfo allocateInfo = new AllocateInfo();
		allocateInfo.ID = this.id;
		allocateInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		allocateInfo.PersonID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		allocateInfo.ToDept = new int?(int.Parse(this.ddlBranch.SelectedValue));
		allocateInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		allocateInfo.FromDept = new int?(int.Parse(this.ddlAppBranch.SelectedValue));
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<AllocateDetailInfo> list = new List<AllocateDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new AllocateDetailInfo
					{
						ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString()),
						GoodsID = new int?(int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString())),
						UnitID = new int?(int.Parse(gridViewSource.Rows[i]["UnitID"].ToString())),
						AppQty = new decimal?(decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString())),
						Price = new decimal?(decimal.Parse(gridViewSource.Rows[i]["Price"].ToString())),
						Remark = gridViewSource.Rows[i]["Remark"].ToString()
					});
				}
			}
			allocateInfo.AllocateDetailInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"AllocateDetail",
				this.hfdellist.Value
			});
		}
		DALAllocate dALAllocate = new DALAllocate();
		return dALAllocate.UpdateMod(allocateInfo, list2, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
