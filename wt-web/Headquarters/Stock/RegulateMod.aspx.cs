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

public partial class Headquarters_Stock_RegulateMod : Page, IRequiresSessionState
{
	private int id;

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
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("RegulatePrice", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("RegulateTotal", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
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
				if (!dALRight.GetRight(num, "ck_r57"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r55"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r60"))
				{
					this.btnPrint.Visible = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			OtherFunction.BindStocks(this.ddlStock, " DeptID=1 and bStop=0 and bReject=0 ");
			DALRegulate dALRegulate = new DALRegulate();
			RegulateInfo model = dALRegulate.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.OperatorID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlStock.Items.Count; i++)
				{
					if (this.ddlStock.Items[i].Value == model.StockID.ToString())
					{
						this.ddlStock.Items[i].Selected = true;
						break;
					}
				}
				this.tbRemark.Text = model.Remark;
				this.AddEmpty();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("ck_regulatedetail", "", " BillID=" + this.id.ToString()).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = decimal.Parse(dataTable.Rows[i]["Qty"].ToString());
					dataRow[5] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["Total"].ToString());
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["RegulatePrice"].ToString());
					dataRow[8] = decimal.Parse(dataTable.Rows[i]["RegulateTotal"].ToString());
					dataRow[9] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					dataRow[11] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[12] = 1;
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
				if (model.Status == 2)
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "该单据已经审核，修改无法保存";
					this.lbMod.Attributes.Add("class", "si2");
				}
				else
				{
					this.lbMod.Text = "若手工输入编号或条码，输入完成后回车";
					this.lbMod.Attributes.Add("class", "si1");
				}
				if (model.DeptID != 1)
				{
					this.btnClean.Enabled = false;
					this.btnAdd.Enabled = false;
					this.btnChk.Enabled = false;
					this.lbMod.Text = "总部只能修改自己的调价单.";
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
		dataRow[4] = 0;
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		dataRow[9] = "";
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
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;padding-right:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[2].Attributes.Add("style", "padding-left:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[6].Attributes.Add("class", "tbbg");
			e.Row.Cells[9].Attributes.Add("class", "tbbg");
			e.Row.Cells[11].Attributes.Add("class", "tbbg");
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			TextBox textBox2 = e.Row.FindControl("tbRegulatePrice") as TextBox;
			Label label2 = e.Row.FindControl("lbRegulateAmount") as Label;
			textBox.Attributes.Add("onchange", string.Concat(new string[]
			{
				"ValiNum(this,'",
				e.Row.Cells[7].Text,
				"','",
				label.ClientID,
				"');GetGoodsPrice('",
				e.Row.Cells[0].Text,
				"');"
			}));
			textBox2.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValiMoney(this,'",
				textBox.ClientID,
				"','",
				label2.ClientID,
				"');"
			}));
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		if (this.ddlStock.SelectedValue == "-1")
		{
			this.SysInfo("alert('请先选择仓库！');");
		}
		else
		{
			string text = FunLibrary.ChkInput(this.tbCon.Text.Trim());
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable = DALCommon.GetDataList("ck_stockdept", "", string.Concat(new string[]
			{
				this.ddlSchFld.SelectedValue,
				"='",
				text,
				"' and DeptID=1 and StockID=",
				this.ddlStock.SelectedValue
			})).Tables[0];
			string text2 = "$('" + this.tbCon.ClientID + "').select();";
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 0; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["GoodsID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[4] = decimal.Parse(dataTable.Rows[i]["Stock"].ToString());
						dataRow[5] = decimal.Parse(dataTable.Rows[i]["CostPrice"].ToString());
						dataRow[6] = decimal.Parse(dataTable.Rows[i]["CostAmount"].ToString());
						dataRow[7] = "0.00";
						dataRow[8] = "0.00";
						dataRow[9] = "";
						dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
						dataRow[11] = 0;
						dataRow[12] = 0;
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
			else
			{
				text2 += "window.alert('没有该产品信息！');";
			}
			this.SysInfo(text2);
		}
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		if (this.ddlStock.SelectedValue == "-1")
		{
			this.SysInfo("alert('请先选择仓库！');");
		}
		else
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
			DataTable gridViewSource = this.GridViewSource;
			if (text != string.Empty)
			{
				DataTable dataTable = DALCommon.GetDataList("ck_stockdept", "", " DeptID=1 and [GoodsID] in(" + text + ") and StockID=" + this.ddlStock.SelectedValue).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.CollectData();
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						bool flag = true;
						for (int j = 1; j < gridViewSource.Rows.Count; j++)
						{
							if (gridViewSource.Rows[j]["GoodsID"].ToString() == dataTable.Rows[i]["GoodsID"].ToString())
							{
								flag = false;
							}
						}
						if (flag)
						{
							DataRow dataRow = gridViewSource.NewRow();
							dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
							dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
							dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
							dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
							dataRow[4] = decimal.Parse(dataTable.Rows[i]["Stock"].ToString());
							dataRow[5] = decimal.Parse(dataTable.Rows[i]["CostPrice"].ToString());
							dataRow[6] = decimal.Parse(dataTable.Rows[i]["CostAmount"].ToString());
							dataRow[7] = "0.00";
							dataRow[8] = "0.00";
							dataRow[9] = "";
							dataRow[10] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
							dataRow[11] = 0;
							dataRow[12] = 0;
							gridViewSource.Rows.Add(dataRow);
						}
					}
					this.BindData();
				}
			}
			this.SysInfo("$('tbCon').focus();");
		}
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbRegulatePrice") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(this.gvdata.Rows[i].Cells[7].Text)).ToString("#0.00");
			gridViewSource.Rows[i]["RegulatePrice"] = textBox2.Text;
			gridViewSource.Rows[i]["RegulateTotal"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox2.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox3.Text);
		}
	}

	protected void btnGetGoodsPrice_Click(object sender, EventArgs e)
	{
		this.CollectData();
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			DataTable gridViewSource = this.GridViewSource;
			if (this.hfGoodsID.Value == this.gvdata.Rows[i].Cells[0].Text)
			{
				decimal num = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString());
				decimal num2;
				DALCommon.GetGoodsPrice(1, int.Parse(this.ddlStock.SelectedValue), int.Parse(this.hfGoodsID.Value), num, out num2);
				gridViewSource.Rows[i]["Price"] = num2;
				gridViewSource.Rows[i]["Total"] = Convert.ToDouble(num * num2).ToString("#0.00");
				break;
			}
		}
		this.BindData();
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
		this.AddEmpty();
	}

	protected void btnChk_Click(object sender, EventArgs e)
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
				DALRegulate dALRegulate = new DALRegulate();
				int iOperator = 0;
				int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
				dALRegulate.ChkRegulate(1, this.id, iOperator, out str);
				this.SysInfo("window.alert('" + str + "');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
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
				this.SysInfo("window.alert('操作成功！该调价单已保存');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected int BillUpdate(out string strMsg)
	{
		RegulateInfo regulateInfo = new RegulateInfo();
		regulateInfo.ID = this.id;
		regulateInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		regulateInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		regulateInfo.StockID = int.Parse(this.ddlStock.SelectedValue);
		regulateInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<RegulateDetailInfo> list = new List<RegulateDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new RegulateDetailInfo
					{
						ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString()),
						GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()),
						Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()),
						Price = decimal.Parse(gridViewSource.Rows[i]["Price"].ToString()),
						RegulatePrice = decimal.Parse(gridViewSource.Rows[i]["RegulatePrice"].ToString()),
						Remark = gridViewSource.Rows[i]["Remark"].ToString()
					});
				}
			}
			regulateInfo.RegulateDetailInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"RegulateDetail",
				this.hfdellist.Value
			});
		}
		DALRegulate dALRegulate = new DALRegulate();
		return dALRegulate.Update(regulateInfo, list2, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
