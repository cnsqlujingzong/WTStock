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
using Wuqi.Webdiyer;

public partial class Branch_Stat_ExpenseDetail : Page, IRequiresSessionState
{
	private int pageSize = 25;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : this.hfParm.Value;
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		DataSet dataList = DALCommon.GetDataList("zk_expense", "isnull(sum(case when status='已完成' then dMoney else 0 end),0)", text);
		this.Label3.Text = dataList.Tables[0].Rows[0][0].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.gvbranch.DataSource = DALCommon.GetList_HL(1, "v_zk_excel_expensedetail", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvbranch.DataBind();
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
		if (this.gvbranch.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvbranch.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvbranch.Columns[i]).DataField;
				string text2 = this.gvbranch.HeaderRow.Cells[i].Text;
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("id", dataField);
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					dataField,
					"','",
					text2,
					"');"
				}));
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
				if (dataField != "ID" && dataField != "")
				{
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_341 = this.hfTbTitle;
						expr_341.Value = expr_341.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_393 = this.hfTbField;
						expr_393.Value = expr_393.Value + "," + dataField;
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
		string text = " 1=1 ";
		if (!this.ddlBranch.SelectedValue.Trim().Equals("-1"))
		{
			text = text + " and DeptID=" + this.ddlBranch.SelectedValue + " ";
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue == "_Date" || this.ddlKey.SelectedValue == "ChkDate" || this.ddlKey.SelectedValue == "PaymentDate")
			{
				if (text2 != "")
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						"and ",
						this.ddlKey.SelectedValue,
						" >= '",
						text2,
						"'"
					});
				}
				if (this.tbDateE.Text.Trim().Equals(""))
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						"and ",
						this.ddlKey.SelectedValue,
						" <= '",
						this.tbDateE.Text,
						"'"
					});
				}
			}
			else if (this.ddlKey.SelectedValue != "-1")
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
		return text + "and status='已完成' ";
	}

	protected void gvbranch_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvbranch.Rows.Count.ToString();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALExpense dALExpense = new DALExpense();
		string empty = string.Empty;
		int num = dALExpense.ExpDel(iTbid, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (num != 0)
		{
			this.SysInfo(string.Concat(new string[]
			{
				"ChkID('",
				this.hfRecID.Value,
				"');window.alert('",
				empty,
				"');"
			}));
		}
		else
		{
			this.hfRecID.Value = "-1";
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
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
		DataTable dt = DALCommon.GetDataList("v_zk_excel_expensedetail", this.hfTbField.Value, strCondition).Tables[0];
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

	protected void btnChkU_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALExpense dALExpense = new DALExpense();
		string empty = string.Empty;
		int num = dALExpense.ExpChkU(iTbid, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (num != 0)
		{
			this.SysInfo(string.Concat(new string[]
			{
				"ChkID('",
				this.hfRecID.Value,
				"');window.alert('",
				empty,
				"');"
			}));
		}
		else
		{
			this.hfRecID.Value = "-1";
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}
