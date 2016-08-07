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
using Wuqi.Webdiyer;

public partial class Headquarters_Financial_SchExpense : Page, IRequiresSessionState
{
	private int pageSize = 15;

	private decimal dtotal = 0m;

	private decimal dprice = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r22"))
				{
					this.hfview.Value = "1";
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Add(new ListItem("全部", "-1"));
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
		DataSet dataList = DALCommon.GetDataList("zk_expense", "isnull(sum(case when status='待审核' then dMoney else 0 end),0),isnull(sum(case when status='待发放' then dMoney else 0 end),0),isnull(sum(case when status='已完成' then dMoney else 0 end),0)", text);
		this.Label1.Text = dataList.Tables[0].Rows[0][0].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.Label2.Text = dataList.Tables[0].Rows[0][1].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.Label3.Text = dataList.Tables[0].Rows[0][2].ToString().TrimEnd(new char[]
		{
			'0'
		}).TrimEnd(new char[]
		{
			'.'
		});
		this.gvbranch.DataSource = DALCommon.GetList_HL(1, "zk_expense", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
						HiddenField expr_3F1 = this.hfTbTitle;
						expr_3F1.Value = expr_3F1.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_443 = this.hfTbField;
						expr_443.Value = expr_443.Value + "," + dataField;
					}
				}
			}
		}
		this.hfTbTitleDetail.Value = "当前状态,部门,申请日期,报销人,总金额,关联业务,摘要,审核日期,审核人,发放日期,发放人,付款帐户,收支项目,出发地点,目的地点,备注,项目名称,金额,明细备注";
		this.hfTbFieldDetail.Value = "Status,Dept,_Date,Operator,dMoney,RelatedBusiness,Summary,ChkDate,ChkOperator,PaymentDate,PaymentOper,Account,Item,FromAdr,ToAdr,Remark1,_Name,Price,Remark";
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
				if (!this.tbDateE.Text.Trim().Equals(""))
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
		if (this.hfview.Value == "1")
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" and Operator='",
				this.Session["Session_wtUser"],
				"'"
			});
		}
		return text;
	}

	protected void gvbranch_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModBill();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "待发放")
			{
				e.Row.Attributes.Add("style", "color:#0000ff");
			}
			else if (e.Row.Cells[1].Text == "待审核")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
			else if (e.Row.Cells[1].Text == "已取消")
			{
				e.Row.Attributes.Add("style", "color:#848284");
			}
			else
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
		}
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
		this.GridView2.DataSource = DALCommon.GetDataList("zk_expensedetail", "", " BillID=" + this.hfRecID.Value);
		this.GridView2.DataBind();
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
			decimal.TryParse(e.Row.Cells[2].Text, out this.dprice);
			this.dtotal += this.dprice;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[0].Text = "合计";
			e.Row.Cells[0].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[2].Text = this.dtotal.ToString("#0.00");
		}
	}
}
