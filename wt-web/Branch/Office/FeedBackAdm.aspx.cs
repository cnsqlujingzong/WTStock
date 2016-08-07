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
using Wuqi.Webdiyer;

public partial class Branch_Office_FeedBackAdm : Page, IRequiresSessionState
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
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "FeedBack", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
		string text = " DeptID=" + int.Parse(this.Session["Session_wtBranchID"].ToString());
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
							" and (CreateDate like '%",
							text2,
							"%' or CreateOperator like '%",
							text2,
							"%' or CheckDate like '%",
							text2,
							"%' or CheckOperator like '%",
							text2,
							"%' or Remark like '%",
							text2,
							"%' or Context like '%",
							text2,
							"%')"
						});
					}
					else if (this.ddlKey.SelectedValue == "curStatus")
					{
						string text4 = text2;
						if (text4 != null)
						{
							if (!(text4 == "已审核"))
							{
								if (!(text4 == "未审核"))
								{
								}
							}
							else
							{
								text += " and curStatus=1";
							}
						}
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
			if (e.Row.Cells[1].Text == "0")
			{
				e.Row.Cells[1].Text = "未审核";
				e.Row.Attributes.Add("style", "color: #ff0000");
			}
			else if (e.Row.Cells[1].Text == "1")
			{
				e.Row.Cells[1].Text = "已审核";
				e.Row.Attributes.Add("style", "color: #008000");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		string value = this.hfRecID.Value;
		int id;
		int.TryParse(value, out id);
		FeedBackInfo feedBackInfo = new FeedBackInfo();
		DALFeedBack dALFeedBack = new DALFeedBack();
		feedBackInfo = dALFeedBack.GetList(id);
		int num = int.Parse((string)this.Session["Session_wtPurBID"]);
		if (feedBackInfo == null)
		{
			this.SysInfo("window.alert('记录错误！');");
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
		else if ((feedBackInfo.DeptID == 1 && feedBackInfo.CreateOperator == this.Session["Session_wtUserB"].ToString()) || num == 0)
		{
			string empty = string.Empty;
			int num2 = DALCommon.DeteleData("FeedBack", "[ID]=" + this.hfRecID.Value, out empty);
			if (num2 == 0)
			{
				this.hfRecID.Value = "-1";
			}
			else if (num2 == -1)
			{
				this.SysInfo("window.alert('" + empty + "');");
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');");
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
		else
		{
			this.SysInfo("window.alert('只能删除自己建立的反馈单！');");
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		DataTable dt = DALCommon.GetDataList("oa_tasklist", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "task", out flag, out empty);
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

	protected void btnChk_Click(object sender, EventArgs e)
	{
		FeedBackInfo feedBackInfo = new FeedBackInfo();
		DALFeedBack dALFeedBack = new DALFeedBack();
		feedBackInfo.ID = int.Parse(this.hfRecID.Value);
		feedBackInfo.curStatus = 1;
		feedBackInfo.CheckDate = DateTime.Now.ToShortDateString();
		feedBackInfo.CheckOperator = this.Session["Session_wtUserB"].ToString();
		int num = dALFeedBack.Update(feedBackInfo);
		if (num > 0)
		{
			this.SysInfo("window.alert('审核成功！');");
		}
		else
		{
			this.SysInfo("window.alert('审核失败！');");
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}
}
