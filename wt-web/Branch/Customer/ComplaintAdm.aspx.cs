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

public partial class Branch_Customer_ComplaintAdm : Page, IRequiresSessionState
{
	private int pageSize = 20;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r20"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "kh_r24"))
				{
					this.btnDel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "kh_r21"))
				{
					this.btnNew.Disabled = true;
				}
				if (!dALRight.GetRight(num, "kh_r22"))
				{
					this.btnMod.Disabled = true;
				}
				if (!dALRight.GetRight(num, "kh_r23"))
				{
					this.btnDo.Disabled = true;
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

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : this.hfParm.Value;
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ks_complaint", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
					if (dataField != "ID")
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_2C9 = this.hfTbTitle;
							expr_2C9.Value = expr_2C9.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_319 = this.hfTbField;
							expr_319.Value = expr_319.Value + "," + dataField;
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
		string text = " DeptID=" + (string)this.Session["Session_wtBranchID"];
		string text2 = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (text2 != "")
				{
					if (this.ddlKey.SelectedValue == "0")
					{
						string text3 = text;
						text = string.Concat(new string[]
						{
							text3,
							" and (Status like '%",
							text2,
							"%' or _Date like '%",
							text2,
							"%' or Operator like '%",
							text2,
							"%' or CustomerName like '%",
							text2,
							"%' or LinkMan like '%",
							text2,
							"%' or Tel like '%",
							text2,
							"%' or Content like '%",
							text2,
							"%' or OperationID like '%",
							text2,
							"%' or DoOperator like '%",
							text2,
							"%' or DoDate like '%",
							text2,
							"%' or Result like '%",
							text2,
							"%' or Measures like '%",
							text2,
							"%' or Remark like '%",
							text2,
							"%' or Dept like '%",
							text2,
							"%')"
						});
					}
					else
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
			e.Row.Attributes.Add("ondblclick", "ModClick();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "待处理")
			{
				e.Row.Attributes.Add("style", "color: #ff0000");
			}
			else if (e.Row.Cells[1].Text == "已处理")
			{
				e.Row.Attributes.Add("style", "color: #008000");
			}
			else if (e.Row.Cells[1].Text == "被取消")
			{
				e.Row.Attributes.Add("style", "color:#848284");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfRecID.Value, out num);
		string str = "ChkID('" + this.hfRecID.Value + "');";
		DataTable dataTable = DALCommon.GetDataList("ks_complaint", "Status", " [ID]=" + num).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			if (dataTable.Rows[0]["Status"].ToString() == "待处理")
			{
				DALComplaint dALComplaint = new DALComplaint();
				dALComplaint.UpdateCancel(num, "被取消");
			}
			else
			{
				str = "window.alert('操作失败！只有待处理的投诉才能[取消]');ChkID('" + this.hfRecID.Value + "');";
			}
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.SysInfo(str);
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
		DataTable dt = DALCommon.GetDataList("ks_complaint", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "ComtAdm", out flag, out empty);
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
