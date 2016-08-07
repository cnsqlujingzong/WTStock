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

public partial class Headquarters_Purchase_SchPurPlan : Page, IRequiresSessionState
{
	private int pageSize = 15;

	private decimal dqty = 0m;

	private decimal tqty = 0m;

	private decimal dprice = 0m;

	private decimal dre1 = 0m;

	private decimal dre2 = 0m;

	private decimal dtotal = 0m;

	private decimal dpqty = 0m;

	private decimal dtaxamount = 0m;

	private decimal dgoodsamount = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "cg_r11"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "cg_r13"))
				{
					this.btnChk.Enabled = false;
				}
				if (!dALRight.GetRight(num, "cg_r14"))
				{
					this.btnChkU.Enabled = false;
				}
				if (!dALRight.GetRight(num, "cg_r15"))
				{
					this.btnDel.Enabled = false;
					this.btnClose.Enabled = false;
				}
				if (!dALRight.GetRight(num, "cg_r16"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "cg_r17"))
				{
					this.btnPrint.Visible = false;
				}
				if (dALRight.GetRight(num, "jc_r27"))
				{
					this.hfBuyPrice.Value = "1";
				}
				if (dALRight.GetRight(num, "cg_r18"))
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
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (OperatorID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or OperatorID is null)";
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "cg_purchaseplan", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
						HiddenField expr_2ED = this.hfTbTitle;
						expr_2ED.Value = expr_2ED.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_33D = this.hfTbField;
						expr_33D.Value = expr_33D.Value + "," + dataField;
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
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALPurchasePlan dALPurchasePlan = new DALPurchasePlan();
					text += dALPurchasePlan.GetSchWhere(schid, text2);
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModBill();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[2].Text == "待审核")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
				e.Row.Cells[1].Attributes.Add("class", "tred");
			}
			else if (e.Row.Cells[2].Text == "已审核")
			{
				e.Row.Attributes.Add("style", "color:#008000");
				e.Row.Cells[1].Attributes.Add("class", "tgreen");
			}
			else if (e.Row.Cells[2].Text == "已关闭")
			{
				e.Row.Attributes.Add("style", "color:#000000");
				e.Row.Cells[1].Attributes.Add("class", "tblack");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALPurchasePlan dALPurchasePlan = new DALPurchasePlan();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALPurchasePlan.ChkPurchasePlan(iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "ChkID('" + this.hfRecID.Value + "');";
		if (num != 0)
		{
			text = text + "window.alert('" + empty + "');";
		}
		this.SysInfo(text);
	}

	protected void btnChkU_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALPurchasePlan dALPurchasePlan = new DALPurchasePlan();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALPurchasePlan.ChkPurchasePlanU(iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "ChkID('" + this.hfRecID.Value + "');";
		if (num != 0)
		{
			text = text + "window.alert('" + empty + "');";
		}
		this.SysInfo(text);
	}

	protected void btnClose_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALPurchasePlan dALPurchasePlan = new DALPurchasePlan();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALPurchasePlan.SwitchPlan(iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.hfRecID.Value = "-1";
		string text = "ChkID('" + this.hfRecID.Value + "');";
		if (num != 0)
		{
			text = text + "window.alert('" + empty + "');";
		}
		this.SysInfo(text);
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALPurchasePlan dALPurchasePlan = new DALPurchasePlan();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALPurchasePlan.Delete(iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			}));
			this.ShowDetail();
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
		DataTable dt = DALCommon.GetDataList("cg_purchaseplan", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "采购订单", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (this.hfBuyPrice.Value.Trim().Equals("1"))
		{
			e.Row.Cells[13].Visible = false;
			e.Row.Cells[9].Visible = false;
			e.Row.Cells[10].Visible = false;
			e.Row.Cells[11].Visible = false;
			e.Row.Cells[12].Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding-right:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			decimal.TryParse(e.Row.Cells[7].Text, out this.tqty);
			decimal.TryParse(e.Row.Cells[9].Text, out this.dprice);
			this.dqty += this.tqty;
			this.dtotal += this.tqty * this.dprice;
			decimal.TryParse(e.Row.Cells[8].Text, out this.tqty);
			this.dpqty += this.tqty;
			decimal.TryParse(e.Row.Cells[12].Text, out this.dre1);
			this.dtaxamount += this.dre1;
			decimal.TryParse(e.Row.Cells[13].Text, out this.dre2);
			this.dgoodsamount += this.dre2;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[7].Text = this.dqty.ToString("#0.00");
			e.Row.Cells[8].Text = this.dpqty.ToString("#0.00");
			e.Row.Cells[10].Text = this.dtotal.ToString("#0.00");
			e.Row.Cells[12].Text = this.dtaxamount.ToString("#0.00");
			e.Row.Cells[13].Text = this.dgoodsamount.ToString("#0.00");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void SysInfo2(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		string a = DALCommon.GetDataList("PurchasePlan", "Status", " ID=" + this.hfRecID.Value).Tables[0].Rows[0][0].ToString();
		if (a == "3")
		{
			this.SysInfo2("$('btnClose').value='开启';");
		}
		else
		{
			this.SysInfo2("$('btnClose').value='关闭'");
		}
		this.GridView2.DataSource = DALCommon.GetDataList("cg_purchaseplandetail", "", " BillID=" + this.hfRecID.Value);
		this.GridView2.DataBind();
	}
}
