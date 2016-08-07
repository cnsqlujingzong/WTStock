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

public partial class Branch_Lease_Release : Page, IRequiresSessionState
{
	
	private int pageSize = 15;

	private static int leaseType;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r7"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "zl_r13"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zl_r17"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(num, "zl_r18"))
				{
					this.btnPrint2.Visible = false;
				}
				if (dALRight.GetRight(num, "zl_r26"))
				{
					this.hfPurDept.Value = "1";
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
			this.ShowDetail();
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
			this.ShowDetail();
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
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
		string text = (this.hfParm.Value == "-1") ? this.strParm() : string.Concat(new object[]
		{
			this.hfParm.Value,
			" and DeptID=",
			int.Parse((string)this.Session["Session_wtBranchID"]),
			" and Status=1"
		});
		string fldSort = sortExpression + " " + direction;
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserBID"] + ")) or SellerID is null)";
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "zl_lease", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (i > 1)
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
						HiddenField expr_345 = this.hfTbTitle;
						expr_345.Value = expr_345.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_397 = this.hfTbField;
						expr_397.Value = expr_397.Value + "," + dataField;
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
		string text = " DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]) + " and Status=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALLease dALLease = new DALLease();
					text += dALLease.GetSchWhere(schid, text2);
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
			if (e.Row.Cells[1].Text == "抄表类租赁")
			{
				e.Row.Attributes.Add("style", "color:#0000ff");
			}
			else if (e.Row.Cells[1].Text == "非抄表类租赁")
			{
				e.Row.Attributes.Add("style", "color:#68031E");
			}
			else if (e.Row.Cells[1].Text == "全保")
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
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
		DataTable dt = DALCommon.GetDataList("zl_lease", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "Lease", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnExcel2_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			DataTable dt = DALCommon.GetDataList("zl_leasecharge", "OperationID,strStatus,_Date,Operator,StartDate,EndDate,Cycle,ShangQty,BenQty,Rent,SuperZhangFee,dRec,InCash,Remark", " BillID=" + this.hfRecID.Value).Tables[0];
			string[] tbTitle = new string[]
			{
				"结算单号",
				"状态",
				"日期",
				"经办人",
				"起始日期",
				"终止日期",
				"周期",
				"上期计数",
				"本期计数",
				"基础月租",
				"超张费",
				"合计应收",
				"现收金额",
				"结算备注"
			};
			string empty = string.Empty;
			bool flag = false;
			DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "lecharge", out flag, out empty);
			if (!flag)
			{
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				this.SysInfo("window.alert('" + empty + "');");
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (Branch_Lease_Release.leaseType != 2)
		{
			e.Row.Cells[6].Visible = false;
		}
		else
		{
			e.Row.Cells[13].Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[11].Text = "<a href=\"#\" onclick=\"ViewQty('" + e.Row.Cells[0].Text + "')\">查看计数器</a>";
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('q" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tq" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "j" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('j" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tj" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[3].Text == "待结算")
			{
				e.Row.Cells[3].Attributes.Add("style", "color:#ff0000;");
			}
			else if (e.Row.Cells[3].Text == "已结算")
			{
				e.Row.Cells[3].Attributes.Add("style", "color:#0000ff;");
			}
			else if (e.Row.Cells[3].Text == "被取消")
			{
				e.Row.Cells[3].Attributes.Add("style", "color:#848284;");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		Branch_Lease_Release.leaseType = new DALLease().getLeaseType(int.Parse(this.hfRecID.Value));
		this.GridView1.DataSource = DALCommon.GetDataList("zl_leasedevice", "", " BillID=" + this.hfRecID.Value);
		this.GridView1.DataBind();
		this.GridView2.DataSource = DALCommon.GetDataList("zl_meterreading", "", " BillID=" + this.hfRecID.Value + " order by [_Date] desc");
		this.GridView2.DataBind();
		this.GridView3.DataSource = DALCommon.GetDataList("zl_leasecharge", "", " BillID=" + this.hfRecID.Value);
		this.GridView3.DataBind();
	}
}
