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

public partial class Branch_Services_SchFullServices : Page, IRequiresSessionState
{
	

	private int pageSize = 20;

	private bool blayout = false;

	private int itake = 23;

	private int iflag;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "gd_r12"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "gd_r15"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(num, "gd_r14"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "gd_r13"))
				{
					this.btnDel.Enabled = false;
				}
				if (dALRight.GetRight(num, "gd_r17"))
				{
					this.hfTecPur.Value = "0";
				}
				else
				{
					this.hfTecPur.Value = "1";
				}
				if (dALRight.GetRight(num, "gd_r20"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserBID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
				}
				if (dALRight.GetRight(num, "gd_r21"))
				{
					this.hfPurDept.Value = "1";
				}
				if (dALRight.GetRight(num, "gd_r23"))
				{
					this.hfPurOPDept.Value = "1";
				}
				if (dALRight.GetRight(num, "gd_r30"))
				{
					this.hfTecDept.Value = "1";
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

	protected void LoadField()
	{
		int userID = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out userID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 14, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvdata.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.gvdata.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "curStatus";
			boundField.HeaderText = "当前状态";
			this.gvdata.Columns.Add(boundField);
			this.itake = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				if (dataTable.Rows[i]["FieldName"].ToString() == "TakeSteps")
				{
					this.itake = i + 2;
				}
				this.gvdata.Columns.Add(boundField2);
			}
			this.blayout = true;
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		this.LoadField();
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : string.Concat(new string[]
		{
			this.hfParm.Value,
			" and (DisposalID=",
			(string)this.Session["Session_wtBranchID"],
			" or TakeOverID=",
			(string)this.Session["Session_wtBranchID"],
			")"
		});
		string strSort = sortExpression + " " + direction;
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserBID"] + ")) or SellerID is null)";
		}
		if (this.hfPurOPDept.Value == "1")
		{
			text = text + " and (OperatorID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserBID"] + ")) or OperatorID is null)";
		}
		if (this.hfTecPur.Value == "0")
		{
			text = text + " and CHARINDEX('" + (string)this.Session["Session_wtUserB"] + "',DisposalOper)>0 ";
		}
		if (this.hfTecDept.Value == "1")
		{
			text = text + " and (DisposalOper in(select _Name from StaffList where bTechnician=1 and StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserBID"] + ")) or DisposalOper is null)";
		}
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		text = text.Replace("'", "''");
		this.hfSql.Value = text;
		DALServices dALServices = new DALServices();
		DataSet fullServices = dALServices.GetFullServices(text, strSort, this.pageSize, this.jsPager.CurrentPageIndex, 1, out recordCount);
		this.DealFields(fullServices, true);
		this.gvdata.DataSource = fullServices;
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
		bool flag = true;
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				if (i > 1)
				{
					if (flag && (this.gvdata.HeaderRow.Cells[i].Text.IndexOf("故障部件") >= 0 || this.gvdata.HeaderRow.Cells[i].Text == "出发地点"))
					{
						flag = false;
					}
					string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
					string text2 = this.gvdata.HeaderRow.Cells[i].Text;
					if (flag)
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
					}
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
					if (dataField != "ID" && flag)
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_542 = this.hfTbTitle;
							expr_542.Value = expr_542.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_594 = this.hfTbField;
							expr_594.Value = expr_594.Value + "," + dataField;
						}
					}
				}
			}
		}
	}

	protected string[] DealFields(DataSet ds, bool addcol)
	{
		string text = ",";
		string text2 = ",";
		int num = 1;
		string text3 = "Goods" + num;
		string text4 = "Qty" + num;
		string text5 = "GoodsNO" + num;
		string text6 = "故障部件" + num;
		string text7 = "部件编号" + num;
		string text8 = "消耗数量" + num;
		while (ds.Tables[0].Columns["Goods" + num] != null)
		{
			if (addcol)
			{
				BoundField boundField = new BoundField();
				boundField.DataField = text3;
				boundField.HeaderText = text6;
				this.gvdata.Columns.Add(boundField);
				BoundField boundField2 = new BoundField();
				boundField2.DataField = text5;
				boundField2.HeaderText = text7;
				this.gvdata.Columns.Add(boundField2);
				BoundField boundField3 = new BoundField();
				boundField3.DataField = text4;
				boundField3.HeaderText = text8;
				this.gvdata.Columns.Add(boundField3);
			}
			else
			{
				text += string.Format("{0},{1},{2},", text6, text7, text8);
				text2 += string.Format("{0},{1},{2},", text3, text5, text4);
			}
			num++;
			text3 = "Goods" + num;
			text4 = "Qty" + num;
			text5 = "GoodsNO" + num;
			text6 = "故障部件" + num;
			text7 = "部件编号" + num;
			text8 = "消耗数量" + num;
		}
		num = ds.Tables[0].Columns.IndexOf("ToAdr") + 1;
		if (addcol)
		{
			BoundField boundField4 = new BoundField();
			boundField4.DataField = "FromAdr";
			boundField4.HeaderText = "出发地点";
			this.gvdata.Columns.Add(boundField4);
			BoundField boundField5 = new BoundField();
			boundField5.DataField = "ToAdr";
			boundField5.HeaderText = "目的地点";
			this.gvdata.Columns.Add(boundField5);
		}
		else
		{
			text += "出发地点,目的地点,";
			text2 += "FromAdr,ToAdr,";
		}
		while (ds.Tables[0].Columns[num].Caption.Trim().IndexOf("列") >= 0)
		{
			if (addcol)
			{
				BoundField boundField6 = new BoundField();
				boundField6.DataField = ds.Tables[0].Columns[num].Caption;
				boundField6.HeaderText = ds.Tables[0].Columns[num].Caption.Substring(1);
				boundField6.DataFormatString = "{0:f2}";
				this.gvdata.Columns.Add(boundField6);
			}
			else
			{
				text = text + ds.Tables[0].Columns[num].Caption.Substring(1) + ",";
				text2 = text2 + ds.Tables[0].Columns[num].Caption + ",";
			}
			num++;
		}
		if (addcol)
		{
			BoundField boundField7 = new BoundField();
			boundField7.DataField = "VisCusDate";
			boundField7.HeaderText = "回访日期";
			this.gvdata.Columns.Add(boundField7);
			BoundField boundField8 = new BoundField();
			boundField8.DataField = "VisCus";
			boundField8.HeaderText = "被回访人";
			this.gvdata.Columns.Add(boundField8);
			BoundField boundField9 = new BoundField();
			boundField9.DataField = "Opinion";
			boundField9.HeaderText = "客户意见";
			this.gvdata.Columns.Add(boundField9);
			BoundField boundField10 = new BoundField();
			boundField10.DataField = "CusRe";
			boundField10.HeaderText = "回访备注";
			this.gvdata.Columns.Add(boundField10);
		}
		else
		{
			text += "回访日期,被回访人,客户意见,回访备注,";
			text2 += "VisCusDate,VisCus,Opinion,CusRe,";
		}
		return new string[]
		{
			text,
			text2
		};
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = string.Concat(new string[]
		{
			" (DisposalID=",
			(string)this.Session["Session_wtBranchID"],
			" or TakeOverID=",
			(string)this.Session["Session_wtBranchID"],
			")"
		});
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALServices dALServices = new DALServices();
					text += dALServices.GetSchWhere(schid, text2);
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		e.Row.Cells[2].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "待处理")
			{
				e.Row.Attributes.Add("style", "color: #ff0000");
			}
			else if (e.Row.Cells[1].Text == "待结算")
			{
				e.Row.Attributes.Add("style", "color: #0000ff");
			}
			else if (e.Row.Cells[1].Text == "处理中")
			{
				e.Row.Attributes.Add("style", "color: #008000");
			}
			else if (e.Row.Cells[1].Text == "已取消")
			{
				e.Row.Attributes.Add("style", "color:#848284");
			}
			else if (e.Row.Cells[1].Text == "已结束")
			{
				e.Row.Attributes.Add("style", "color:#840000");
			}
			else if (e.Row.Cells[1].Text == "送修")
			{
				e.Row.Attributes.Add("style", "color:#8a4000");
			}
			else if (e.Row.Cells[1].Text == "待审核")
			{
				e.Row.Attributes.Add("style", "color:#333333");
			}
			if (this.blayout)
			{
				if (this.itake > 2)
				{
					if (e.Row.Cells[this.itake].Text.Length > 16)
					{
						e.Row.Cells[this.itake].Text = string.Concat(new string[]
						{
							"<a href=\"#\" style=\"color:#0000ff\" title=\"",
							e.Row.Cells[this.itake].Text,
							"\" onclick=\"ShowTA('",
							e.Row.Cells[0].Text,
							"')\">",
							e.Row.Cells[this.itake].Text.Substring(0, 16),
							"...</a>"
						});
					}
				}
			}
			else if (e.Row.Cells[this.itake].Text.Length > 16)
			{
				e.Row.Cells[this.itake].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[this.itake].Text,
					"\" onclick=\"ShowTA('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[this.itake].Text.Substring(0, 16),
					"...</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALServices dALServices = new DALServices();
		int num = 0;
		int num2 = 0;
		int.TryParse(this.hfRecID.Value, out num2);
		if (num2 > 0)
		{
			num = dALServices.ChkDel(num2, int.Parse((string)this.Session["Session_wtUserBID"]), out empty);
		}
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
		else
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			}));
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = string.Concat(new string[]
		{
			this.hfSql.Value,
			" order by ",
			this.hfOrderName.Value,
			" ",
			this.hfOrder.Value
		});
		text = text.Replace("''", "'");
		DALServices dALServices = new DALServices();
		int num = 0;
		DataSet fullServices = dALServices.GetFullServices(this.hfSql.Value, this.hfOrderName.Value + " " + this.hfOrder.Value, 0, 0, 0, out num);
		DataTable dataTable = fullServices.Tables[0];
		string[] array = this.DealFields(fullServices, false);
		string text2 = this.hfTbTitle.Value.Trim() + array[0].Trim();
		string text3 = this.hfTbField.Value.Trim() + array[1].Trim();
		string[] tbTitle = text2.TrimEnd(new char[]
		{
			','
		}).Split(new char[]
		{
			','
		});
		string[] array2 = text3.TrimEnd(new char[]
		{
			','
		}).Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		for (int i = 0; i < array2.Length; i++)
		{
			dataTable.Columns[array2[i]].SetOrdinal(i);
		}
		while (dataTable.Columns.Count != array2.Length)
		{
			dataTable.Columns.Remove(dataTable.Columns[array2.Length].Caption);
		}
		int count = dataTable.Columns.Count;
		DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "Services", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
