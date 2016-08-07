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

public partial class Branch_Services_SchServices : Page, IRequiresSessionState
{
	private int pageSize = 20;

	private bool blayout = false;

	private int itake = 22;

	

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
		int deptID = 0;
		int.TryParse((string)this.Session["Session_wtBranchID"], out deptID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, deptID, 14, 0, userID).Tables[0];
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
			" or BranchID=",
			(string)this.Session["Session_wtBranchID"],
			")"
		});
		string fldSort = sortExpression + " " + direction;
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
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "fw_services", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
					string text2 = ((BoundField)this.gvdata.Columns[i]).DataField;
					string text3 = this.gvdata.HeaderRow.Cells[i].Text;
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
					if (text2 == "Speding")
					{
						text2 = "timeout";
						text3 = "timeout";
						this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
						{
							"HeaderOrder('",
							text2,
							"','",
							text3,
							"');"
						}));
					}
					else
					{
						this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
						{
							"HeaderOrder('",
							text2,
							"','",
							text3,
							"');"
						}));
						if (text2 != "ID")
						{
							if (this.hfTbTitle.Value == string.Empty)
							{
								this.hfTbTitle.Value = text3;
							}
							else
							{
								HiddenField expr_509 = this.hfTbTitle;
								expr_509.Value = expr_509.Value + "," + text3;
							}
							if (this.hfTbField.Value == string.Empty)
							{
								this.hfTbField.Value = text2;
							}
							else
							{
								HiddenField expr_55B = this.hfTbField;
								expr_55B.Value = expr_55B.Value + "," + text2;
							}
						}
					}
				}
			}
		}
		HiddenField expr_5A6 = this.hfTbField;
		expr_5A6.Value += ",Speding";
		HiddenField expr_5C2 = this.hfTbTitle;
		expr_5C2.Value += ",处理时间";
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
			" or BranchID=",
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
			this.SysInfo("window.alert('" + empty + "');");
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
		string strCondition = string.Concat(new string[]
		{
			this.hfSql.Value,
			" order by ",
			this.hfOrderName.Value,
			" ",
			this.hfOrder.Value
		});
		DataTable dt = DALCommon.GetDataList("fw_services", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "Services", out flag, out empty);
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
