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

public partial class Branch_Financial_Expense : Page, IRequiresSessionState
{


	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ItemID", typeof(int)));
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
				if (!dALRight.GetRight(num, "zk_r19"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "zk_r20"))
				{
					this.btnChk.Enabled = false;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
			this.tbAmount.Text = "0.00";
			this.AddEmpty();
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		dataRow[1] = 0;
		dataRow[2] = "";
		dataRow[3] = 0;
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
			TextBox textBox = e.Row.FindControl("tbAmount") as TextBox;
			LinkButton linkButton = e.Row.FindControl("lbDel") as LinkButton;
			textBox.Attributes.Add("oldNum", textBox.Text);
			linkButton.Attributes.Add("num", e.Row.RowIndex.ToString());
			linkButton.Attributes.Add("onclick", "ChkAmountee(this,'" + textBox.ClientID + "');");
			textBox.Attributes.Add("onblur", "ValidateMoneyee(this);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[3].Attributes.Add("class", "tbbg");
			e.Row.Cells[4].Attributes.Add("class", "tbbg");
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ExpenseItem", "", string.Concat(new string[]
		{
			" DeptID=",
			(string)this.Session["Session_wtBranchID"],
			this.ddlSchFld.SelectedValue,
			"='",
			text,
			"'"
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
					if (gridViewSource.Rows[j]["ItemID"].ToString() == dataTable.Rows[i]["ID"].ToString())
					{
						flag = false;
					}
				}
				if (flag)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[1] = "0.00";
					dataRow[2] = "";
					dataRow[3] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
		else
		{
			text2 += "window.alert('操作失败！项目名称不存在');";
		}
		this.SysInfo(text2);
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
			DataTable dataTable = DALCommon.GetDataList("ExpenseItem", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["ItemID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[1] = "0.00";
						dataRow[2] = "";
						dataRow[3] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						gridViewSource.Rows.Add(dataRow);
					}
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
		decimal d = 0m;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbAmount") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Total"] = textBox.Text;
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox2.Text);
			d += decimal.Parse(textBox.Text);
		}
		this.tbAmount.Text = d.ToString("#0.00");
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
		this.tbAmount.Text = "0.00";
		this.AddEmpty();
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		this.CollectData();
		int num;
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加报销项目');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else if (this.BillAdd(2, out num) == 0)
		{
			this.SysInfo("window.alert('操作成功！该报销申请已转入款项发放！');");
			this.ClearText();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		int num;
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加报销项目');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else if (this.BillAdd(1, out num) == 0)
		{
			this.SysInfo("window.alert('操作成功！该报销申请已转入主管审核！');");
			this.ClearText();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected int BillAdd(int iflag, out int iTbid)
	{
		ExpenseInfo expenseInfo = new ExpenseInfo();
		expenseInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		expenseInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		expenseInfo.DeptID = int.Parse((string)this.Session["Session_wtBranchID"]);
		expenseInfo.dMoney = 0m;
		expenseInfo.Summary = FunLibrary.ChkInput(this.tbSummary.Text);
		expenseInfo.Accessory = this.hfPath.Value;
		expenseInfo.RelatedBusiness = this.tbRelatedServices.Text.Trim();
		expenseInfo.FromAdr = FunLibrary.ChkInput(this.tbFromAdr.Text);
		expenseInfo.ToAdr = FunLibrary.ChkInput(this.tbToAdr.Text);
		if (iflag == 1)
		{
			expenseInfo.Status = "待审核";
			expenseInfo.ChkDate = "";
			expenseInfo.ChkOperatorID = 0;
		}
		else
		{
			expenseInfo.Status = "待发放";
			expenseInfo.ChkDate = DateTime.Now.ToString("yyyy-MM-dd");
			expenseInfo.ChkOperatorID = int.Parse(this.Session["Session_wtUserBID"].ToString());
		}
		expenseInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<ExpenseDetailInfo> list = new List<ExpenseDetailInfo>();
			decimal num = 0m;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["ItemID"].ToString()) > 0)
				{
					ExpenseDetailInfo expenseDetailInfo = new ExpenseDetailInfo();
					expenseDetailInfo.ItemID = int.Parse(gridViewSource.Rows[i]["ItemID"].ToString());
					decimal.TryParse(gridViewSource.Rows[i]["Total"].ToString(), out num);
					expenseDetailInfo.Price = num;
					expenseDetailInfo.Remark = gridViewSource.Rows[i]["Remark"].ToString();
					expenseInfo.dMoney += num;
					list.Add(expenseDetailInfo);
				}
			}
			expenseInfo.ExpenseDetailInfos = list;
		}
		string empty = string.Empty;
		DALExpense dALExpense = new DALExpense();
		return dALExpense.Add(expenseInfo, out iTbid);
	}

	protected void ClearText()
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.tbAmount.Text = "0.00";
		this.tbSummary.Text = (this.tbRemark.Text = string.Empty);
		this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		string b = (string)this.Session["Session_wtUserB"];
		this.ddlOperator.ClearSelection();
		for (int i = 0; i < this.ddlOperator.Items.Count; i++)
		{
			if (this.ddlOperator.Items[i].Text == b)
			{
				this.ddlOperator.Items[i].Selected = true;
				break;
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
