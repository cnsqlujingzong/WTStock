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

public partial class Branch_Stock_LendingAdd : Page, IRequiresSessionState
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
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
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
				if (!dALRight.GetRight(num, "ck_r66"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(28, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bStop=0");
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
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
		dataRow[6] = "";
		dataRow[7] = "";
		dataRow[8] = 0;
		dataRow[9] = 0;
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
			TextBox textBox2 = e.Row.FindControl("tbSN") as TextBox;
			textBox.Attributes.Add("oldNum", textBox.Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[9].Text = string.Concat(new string[]
			{
				"<a href=\"#\" onclick=\"EditSN('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"','",
				textBox2.ClientID,
				"','",
				textBox.ClientID,
				"');\">编辑序列号</a>"
			});
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ck_goods", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
		string text = "$('" + this.tbCon.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
				dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
				dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
				dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
				dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
				dataRow[5] = 1;
				dataRow[6] = "";
				dataRow[7] = "";
				dataRow[8] = int.Parse(dataTable.Rows[i]["ID"].ToString());
				dataRow[9] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
				gridViewSource.Rows.Add(dataRow);
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
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[5] = 1;
					dataRow[6] = "";
					dataRow[7] = "";
					dataRow[8] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[9] = int.Parse(dataTable.Rows[i]["GoodsUnitID"].ToString());
					gridViewSource.Rows.Add(dataRow);
				}
				this.BindData();
			}
		}
		this.SysInfo("$('tbCon').focus();");
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
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Qty"] = textBox.Text;
			gridViewSource.Rows[i]["SN"] = textBox2.Text;
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox3.Text);
		}
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
		this.AddEmpty();
	}

	protected void btnCusInfo_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value != "")
		{
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "LinkMan,Tel,Adr", " [ID]=" + this.hfCusID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.hfCusID.Value == "")
		{
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "[ID]", " _Name='" + FunLibrary.ChkInput(this.tbCusName.Text) + "' ").Tables[0];
			if (dataTable.Rows.Count != 1)
			{
				this.hfCusID.Value = "";
				this.SysInfo("window.alert('操作失败！客户不存在，请添加');$(\"tbCusName\").focus()");
				return;
			}
			this.hfCusID.Value = dataTable.Rows[0]["ID"].ToString();
		}
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加产品');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			string str = "";
			int num2;
			int num = this.BillAdd(out num2, out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！该借出单已保存');");
				this.ClearText();
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
	}

	protected int BillAdd(out int iTbid, out string strMsg)
	{
		LendingReturnInfo lendingReturnInfo = new LendingReturnInfo();
		lendingReturnInfo.DeptID = int.Parse((string)this.Session["Session_wtBranchID"]);
		lendingReturnInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		lendingReturnInfo.iOperator = int.Parse(this.ddlOperator.SelectedValue);
		lendingReturnInfo.CustomerID = int.Parse(this.hfCusID.Value);
		lendingReturnInfo.iPerson = int.Parse(this.Session["Session_wtUserBID"].ToString());
		lendingReturnInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		decimal deposit = 0m;
		decimal.TryParse(this.tbDeposit.Text, out deposit);
		lendingReturnInfo.Deposit = deposit;
		lendingReturnInfo.OperationID = FunLibrary.ChkInput(this.tbOperationID.Text);
		lendingReturnInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		lendingReturnInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		lendingReturnInfo.WDate = FunLibrary.ChkInput(this.tbWDate.Text);
		lendingReturnInfo.iStock = int.Parse(this.ddlStock.SelectedValue);
		lendingReturnInfo.curStatus = "待归还";
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<LendingReturnDetailInfo> list = new List<LendingReturnDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new LendingReturnDetailInfo
					{
						GoodsID = int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()),
						UnitID = int.Parse(gridViewSource.Rows[i]["UnitID"].ToString()),
						Qty = decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString()),
						SN = gridViewSource.Rows[i]["SN"].ToString(),
						Remark = gridViewSource.Rows[i]["Remark"].ToString()
					});
				}
			}
			lendingReturnInfo.LendingReturnDetailInfos = list;
		}
		DALLendingReturn dALLendingReturn = new DALLendingReturn();
		int result = dALLendingReturn.Add(lendingReturnInfo, out iTbid, out strMsg);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(28, 0);
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
		this.ddlStock.ClearSelection();
		for (int i = 0; i < this.ddlStock.Items.Count; i++)
		{
			if (this.ddlStock.Items[i].Text == "")
			{
				this.ddlStock.Items[i].Selected = true;
				break;
			}
		}
		this.hfCusID.Value = "";
		this.tbCusName.Text = "";
		this.tbRemark.Text = "";
		this.hfOperationID.Value = (this.hfSltID.Value = "");
		this.tbTel.Text = "";
		this.tbLinkMan.Text = "";
		this.tbDeposit.Text = "";
		this.tbOperationID.Text = "";
		this.tbWDate.Text = "";
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
