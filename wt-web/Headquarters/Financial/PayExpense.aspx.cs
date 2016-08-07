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
using Wuqi.Webdiyer;

public partial class Headquarters_Financial_PayExpense : Page, IRequiresSessionState
{
	private int pageSize = 20;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r21"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			OtherFunction.BindChargeAccount(this.ddlChargeAccount, " DeptID=1");
			OtherFunction.BindChargeItem(this.ddlItem, " Type=1 and DeptID=1");
			DataTable dataTable = DALCommon.GetDataList("SysParm", "bHeadBln", "ID=1").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0][0].ToString().Trim().Equals("1") || dataTable.Rows[0][0].ToString().Trim().ToLower().Equals("true"))
				{
					this.hfHeadBln.Value = "1";
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfOrder.Value != "ID")
		{
			this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
		}
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		DataSet dataList = DALCommon.GetDataList("zk_expense", "isnull(sum(dMoney),0)", text);
		this.Label1.Text = dataList.Tables[0].Rows[0][0].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "zk_expense", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvdata.DataBind();
		this.lbCount.Text = recordCount.ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
			this.lbCountText.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
			this.lbCountText.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				if (i > 0)
				{
					string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
					string text2 = this.gvdata.HeaderRow.Cells[i].Text;
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("id", dataField);
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
					{
						"HeaderOrder('",
						dataField,
						"','",
						text2,
						"');"
					}));
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_2F9 = this.hfTbTitle;
						expr_2F9.Value = expr_2F9.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_34B = this.hfTbField;
						expr_34B.Value = expr_34B.Value + "," + dataField;
					}
				}
			}
		}
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " Status='待发放' ";
		if (!this.hfHeadBln.Value.Trim().Equals("1"))
		{
			text += " and DeptID=1 ";
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (text2 != "")
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						"and ",
						this.ddlKey.SelectedValue,
						" like '%",
						text2,
						"%'"
					});
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModBill();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse(this.hfRecID.Value, out num);
		if (num > 0)
		{
			DALExpense dALExpense = new DALExpense();
			ExpenseInfo expenseInfo = new ExpenseInfo();
			expenseInfo.ID = num;
			expenseInfo.PaymentOperID = int.Parse(this.ddlOperator.SelectedValue);
			expenseInfo.PaymentDate = this.tbDate.Text;
			expenseInfo.ItemID = int.Parse(this.ddlItem.SelectedValue);
			expenseInfo.AccountID = int.Parse(this.ddlChargeAccount.SelectedValue);
			expenseInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			string str = "";
			int num2 = dALExpense.ExpPayChk(expenseInfo, out str);
			if (num2 == 0)
			{
				this.hfRecID.Value = "-1";
				this.SysInfo("window.alert('操作成功！报销申请款项已发放');");
				this.ddlOperator.ClearSelection();
				string b = (string)this.Session["Session_wtUser"];
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == b)
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.ddlChargeAccount.ClearSelection();
				this.ddlItem.ClearSelection();
				this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				this.tbRemark.Text = "";
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnBack_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse(this.hfRecID.Value, out num);
		if (num > 0)
		{
			DALExpense dALExpense = new DALExpense();
			ExpenseInfo expenseInfo = new ExpenseInfo();
			expenseInfo.ID = num;
			expenseInfo.PaymentOperID = int.Parse(this.ddlOperator.SelectedValue);
			expenseInfo.PaymentDate = this.tbDate.Text;
			expenseInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			string str = "";
			int num2 = dALExpense.BackChk(expenseInfo, "待审核", out str);
			if (num2 == 0)
			{
				this.hfRecID.Value = "-1";
				this.SysInfo("window.alert('驳回成功！报销申请已驳回‘主管审核’');");
				this.ddlOperator.ClearSelection();
				string b = (string)this.Session["Session_wtUser"];
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == b)
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.ddlChargeAccount.ClearSelection();
				this.ddlItem.ClearSelection();
				this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				this.tbRemark.Text = "";
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			DataTable dataTable = DALCommon.GetDataList("zk_expense", "", " [ID]=" + this.hfRecID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
			}
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strCondition = string.Concat(new string[]
		{
			this.hfSql.Value,
			" order by ",
			this.hfOrderName.Value,
			" ",
			this.hfOrder.Value
		});
		DataTable dt = DALCommon.GetDataList("zk_expense", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "expense", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
