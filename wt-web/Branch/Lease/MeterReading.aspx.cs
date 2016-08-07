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

public partial class Branch_Lease_MeterReading : Page, IRequiresSessionState
{
	

	private int pageSize = 20;

	private int iFlag;

	private string idl = string.Empty;

	private static int leaseType;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["iFlag"], out this.iFlag);
		this.idl = "," + this.hfcbID.Value.Trim().Trim(new char[]
		{
			','
		}) + ",";
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r2"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "zl_r13"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zl_r16"))
				{
					this.btnDelD.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zl_r17"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(num, "zl_r18"))
				{
					this.btnPrint2.Visible = false;
				}
				if (!dALRight.GetRight(num, "zl_r23"))
				{
					this.btnChkU.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zl_r24"))
				{
					this.btnChkCU.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zl_r25"))
				{
					this.btnDelC.Enabled = false;
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
		this.hfcbID.Value = "";
		this.hfCusID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
			this.ShowDetail();
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfCusID.Value = "";
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
		this.hfcbID.Value = "";
		this.hfCusID.Value = "";
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfParm.Value = "-1";
		this.hfcbID.Value = "";
		this.hfCusID.Value = "";
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
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
					if (dataField != "" && dataField != "ID")
					{
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
							HiddenField expr_375 = this.hfTbTitle;
							expr_375.Value = expr_375.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_3C7 = this.hfTbField;
							expr_3C7.Value = expr_3C7.Value + "," + dataField;
						}
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
		if (this.iFlag == 2)
		{
			text += " and datediff(d,dateadd(dd,3,getdate()),dateadd(dd,ChargeCycle,ChargeDate))<=0 ";
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int num = 0;
				int.TryParse(this.ddlKey.SelectedValue, out num);
				if (text2 != "")
				{
					DALLease dALLease = new DALLease();
					text += dALLease.GetSchWhere(num, text2);
				}
				else
				{
					if (num == 22)
					{
						text += " and datediff(day, getdate(),dateadd(day,chargecycle,readingdate)) between 0 and 7 ";
					}
					if (num == 23)
					{
						text += " and datediff(day, getdate(),dateadd(day,chargecycle,readingdate)) < 0 ";
					}
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
			if (this.idl.Contains("," + e.Row.Cells[0].Text + ","))
			{
				e.Row.Cells[1].Text = string.Concat(new string[]
				{
					"<input id=\"cb",
					e.Row.Cells[0].Text,
					"\" type=\"checkbox\" checked=\"checked\" onclick=\"SltValue('",
					e.Row.Cells[0].Text,
					"',this);\"/>"
				});
			}
			else
			{
				e.Row.Cells[1].Text = string.Concat(new string[]
				{
					"<input id=\"cb",
					e.Row.Cells[0].Text,
					"\" type=\"checkbox\" onclick=\"SltValue('",
					e.Row.Cells[0].Text,
					"',this);\"/>"
				});
			}
			if (e.Row.Cells[2].Text == "抄表类租赁")
			{
				e.Row.Attributes.Add("style", "color:#0000ff");
			}
			else if (e.Row.Cells[2].Text == "非抄表类租赁")
			{
				e.Row.Attributes.Add("style", "color:#68031E");
			}
			else if (e.Row.Cells[2].Text == "全保")
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnChkU_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALLease dALLease = new DALLease();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
		int deptID = 0;
		int.TryParse(this.Session["Session_wtBranchID"].ToString(), out deptID);
		int num = dALLease.LeaseChkU(deptID, iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
		}
		this.SysInfo(text);
	}

	protected void btnChkCU_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID2.Value.Replace("j", ""), out iTbid);
		DALLease dALLease = new DALLease();
		string empty = string.Empty;
		int iOperator = 0;
		int deptID = 0;
		int.TryParse(this.Session["Session_wtBranchID"].ToString(), out deptID);
		int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
		int num = dALLease.LeaseChargeChkU(deptID, iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
		}
		this.SysInfoC(text);
		this.GridView3.DataSource = DALCommon.GetDataList("zl_leasecharge", "", " BillID=" + this.hfRecID.Value);
		this.GridView3.DataBind();
	}

	protected void btnCancelC_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID2.Value.Replace("j", ""), out iTbid);
		DALLease dALLease = new DALLease();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
		int num = dALLease.LeaseChargeCancel(iTbid, 1, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
		}
		this.SysInfoC(text);
		this.GridView3.DataSource = DALCommon.GetDataList("zl_leasecharge", "", " BillID=" + this.hfRecID.Value);
		this.GridView3.DataBind();
	}

	protected void btnDelC_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID2.Value.Replace("j", ""), out iTbid);
		DALLease dALLease = new DALLease();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
		int num = dALLease.ChkChargeDel(iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
		}
		this.SysInfoC(text);
		this.GridView3.DataSource = DALCommon.GetDataList("zl_leasecharge", "", " BillID=" + this.hfRecID.Value);
		this.GridView3.DataBind();
	}

	protected void SysInfoC(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.UpdatePanel4.GetType(), "SysInfo", str, true);
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

	protected void bteEx_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			DataTable dt = DALCommon.GetDataList("zl_leasedevice", "DevStatus,StockName,GoodsNO,DeviceNO,Brand,Class,Model,ProductSN1,ProductSN2,Remark", " BillID=" + this.hfRecID.Value).Tables[0];
			string[] tbTitle = new string[]
			{
				"机器状态",
				"仓库",
				"租赁机器",
				"机器编号",
				"机器品牌",
				"类别",
				"型号",
				"序列号",
				"序列号2",
				"备注"
			};
			string empty = string.Empty;
			bool flag = false;
			DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "mechine", out flag, out empty);
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
		if (Branch_Lease_MeterReading.leaseType != 2)
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
			e.Row.Cells[13].Text = "<a href=\"#\" onclick=\"ViewQty('" + e.Row.Cells[0].Text + "')\">查看计数器</a>";
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
			e.Row.Attributes.Add("ondblclick", "ModD();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnDelD_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("MeterReading", " [ID]=" + this.hfRecID2.Value.Replace("q", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfoq("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfoq("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView2.DataSource = DALCommon.GetDataList("zl_meterreading", "", " BillID=" + this.hfRecID.Value + " order by [_Date] desc");
		this.GridView2.DataBind();
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

	protected void SysInfoq(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.UpdatePanel3.GetType(), "SysInfo", str, true);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		Branch_Lease_MeterReading.leaseType = new DALLease().getLeaseType(int.Parse(this.hfRecID.Value));
		this.GridView1.DataSource = DALCommon.GetDataList("zl_leasedevice", "", " BillID=" + this.hfRecID.Value);
		this.GridView1.DataBind();
		this.GridView2.DataSource = DALCommon.GetDataList("zl_meterreading", "", " BillID=" + this.hfRecID.Value + " order by [_Date] desc");
		this.GridView2.DataBind();
		this.GridView3.DataSource = DALCommon.GetDataList("zl_leasecharge", "", " BillID=" + this.hfRecID.Value);
		this.GridView3.DataBind();
	}

	protected void btnExcelDetail_Click(object sender, EventArgs e)
	{
		DataTable dataTable = DALCommon.GetDataList("zl_meterreading", "_Date,Operator,DeviceNO,ProductSN1,_Name,Qty,Loss,WRemark", " BillID=" + this.hfRecID.Value + " order by [_Date] desc").Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			string[] tbTitle = new string[]
			{
				"读数日期",
				"读数人",
				"机器编号",
				"机器序列号",
				"计数器类型",
				"计数",
				"损耗张数",
				"备注"
			};
			string empty = string.Empty;
			bool flag = false;
			DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "zl_meterreading", out flag, out empty);
			if (!flag)
			{
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				this.SysInfo("window.alert('" + empty + "');");
			}
		}
		else
		{
			this.SysInfoq("window.alert('该租赁单无抄表记录');");
		}
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}
}
