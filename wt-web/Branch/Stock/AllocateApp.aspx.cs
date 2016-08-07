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

public partial class Branch_Stock_AllocateApp : Page, IRequiresSessionState
{


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
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r31"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=35");
					base.Response.End();
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(10, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			OtherFunction.BindBranch(this.ddlAppBranch);
			this.ddlAppBranch.SelectedValue = (string)this.Session["Session_wtBranchID"];
			this.ddlBranch.Items.Insert(0, new ListItem("", "-1"));
			this.tbAQty.Text = "0.00";
			this.AddEmpty();
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
			e.Row.Cells[7].Attributes.Add("ondblclick", "SltUnit();");
			e.Row.Cells[8].Attributes.Add("class", "tbbg");
			e.Row.Cells[10].Attributes.Add("class", "tbbg");
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		int iGoodsid = 0;
		int iUnitid = 0;
		decimal num = 0m;
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ck_goods", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		int num2 = 3;
		if (sysParm != null)
		{
			num2 = sysParm.AllocatePrice;
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
				int.TryParse(dataTable.Rows[i]["ID"].ToString(), out iGoodsid);
				int.TryParse(dataTable.Rows[i]["UnitID"].ToString(), out iUnitid);
				DataTable dataTable2 = DALCommon.GetGoodsPriceList(3, int.Parse(this.Session["Session_wtBranchID"].ToString()), iGoodsid, iUnitid, 0, -1).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					decimal.TryParse(dataTable2.Rows[0]["Price"].ToString(), out num);
				}
				if (flag)
				{
					decimal num3;
					switch (num2)
					{
					case 1:
						num3 = decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString());
						break;
					case 2:
						num3 = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
						break;
					case 3:
						num3 = decimal.Parse(dataTable.Rows[i]["PriceInner"].ToString());
						break;
					case 4:
						num3 = decimal.Parse(dataTable.Rows[i]["PriceWholesale1"].ToString());
						break;
					case 5:
						num3 = decimal.Parse(dataTable.Rows[i]["PriceWholesale2"].ToString());
						break;
					case 6:
						num3 = decimal.Parse(dataTable.Rows[i]["PriceWholesale3"].ToString());
						break;
					case 7:
						num3 = num;
						break;
					default:
						num3 = decimal.Parse(dataTable.Rows[i]["PriceInner"].ToString());
						break;
					}
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[5] = 1;
					dataRow[6] = num3;
					dataRow[7] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[8] = "";
					dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
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
		int iGoodsid = 0;
		int iUnitid = 0;
		decimal num = 0m;
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
		int num2 = 3;
		if (sysParm != null)
		{
			num2 = sysParm.AllocatePrice;
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
					int.TryParse(dataTable.Rows[i]["ID"].ToString(), out iGoodsid);
					int.TryParse(dataTable.Rows[i]["UnitID"].ToString(), out iUnitid);
					DataTable dataTable2 = DALCommon.GetGoodsPriceList(3, int.Parse(this.Session["Session_wtBranchID"].ToString()), iGoodsid, iUnitid, 0, -1).Tables[0];
					if (flag)
					{
						decimal num3;
						switch (num2)
						{
						case 1:
							num3 = decimal.Parse(dataTable.Rows[i]["PriceDetail"].ToString());
							break;
						case 2:
							num3 = decimal.Parse(dataTable.Rows[i]["PriceCost"].ToString());
							break;
						case 3:
							num3 = decimal.Parse(dataTable.Rows[i]["PriceInner"].ToString());
							break;
						case 4:
							num3 = decimal.Parse(dataTable.Rows[i]["PriceWholesale1"].ToString());
							break;
						case 5:
							num3 = decimal.Parse(dataTable.Rows[i]["PriceWholesale2"].ToString());
							break;
						case 6:
							num3 = decimal.Parse(dataTable.Rows[i]["PriceWholesale3"].ToString());
							break;
						case 7:
							num3 = num;
							break;
						default:
							num3 = decimal.Parse(dataTable.Rows[i]["PriceInner"].ToString());
							break;
						}
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
						dataRow[5] = 1;
						dataRow[6] = num3;
						dataRow[7] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[8] = "";
						dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
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
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			int num2;
			int num = this.BillAdd(out num2);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该调拨申请已递交');");
				this.ClearText();
			}
			else
			{
				this.SysInfo("window.alert('操作失败！请查看错误日志');");
			}
		}
	}

	protected int BillAdd(out int iTbid)
	{
		AllocateInfo allocateInfo = new AllocateInfo();
		allocateInfo.FromDept = new int?(int.Parse((string)this.Session["Session_wtBranchID"]));
		allocateInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		allocateInfo.ToDept = new int?(int.Parse(this.ddlBranch.SelectedValue));
		allocateInfo.PersonID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		allocateInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
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
		DALAllocate dALAllocate = new DALAllocate();
		return dALAllocate.Add(allocateInfo, out iTbid);
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(10, 0);
		this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		this.ddlOperator.ClearSelection();
		string b = (string)this.Session["Session_wtUserB"];
		for (int i = 0; i < this.ddlOperator.Items.Count; i++)
		{
			if (this.ddlOperator.Items[i].Text == b)
			{
				this.ddlOperator.Items[i].Selected = true;
				break;
			}
		}
		this.ddlBranch.ClearSelection();
		this.ddlBranch.Items.FindByText("").Selected = true;
		this.tbRemark.Text = "";
		this.tbAQty.Text = "0.00";
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
