using System;
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

public partial class Headquarters_Stat_TecDeduct : Page, IRequiresSessionState
{
	private int pageSize = 20;

	private decimal drec1 = 0m;

	private decimal drec = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r27"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=asdf");
					base.Response.End();
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Add(new ListItem("全部", "-1"));
			this.tbStartDate.Text = DateTime.Now.ToString("yyyy-MM") + "-01";
			this.tbEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		this.gvgds.DataSource = DALCommon.GetList_HL(0, "v_ServicesVisitResult", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvgds.DataBind();
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
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " (bCall='√' or bCall='☆') and score is not null ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		string text2 = FunLibrary.ChkInput(this.tbStartDate.Text);
		string text3 = FunLibrary.ChkInput(this.tbEndDate.Text);
		string text4 = FunLibrary.ChkInput(this.tbCon.Text);
		if (text4 != "")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				string selectedValue = this.ddlKey.SelectedValue;
				if (selectedValue != null)
				{
					if (!(selectedValue == "0"))
					{
						if (!(selectedValue == "1"))
						{
							if (!(selectedValue == "2"))
							{
								if (!(selectedValue == "3"))
								{
									if (selectedValue == "4")
									{
										text = text + " and VisitedName like '%" + text4 + "%'";
									}
								}
								else
								{
									text = text + " and VisitOperator like '%" + text4 + "%'";
								}
							}
							else
							{
								text = text + " and DisposalOper='" + text4 + "'";
							}
						}
						else
						{
							text = text + " and BillID like '%" + text4 + "%'";
						}
					}
					else
					{
						string text5 = text;
						text = string.Concat(new string[]
						{
							text5,
							" and (BillID like '%",
							text4,
							"%' or DisposalOper like '%",
							text4,
							"%' or VisitOperator like '%",
							text4,
							"%' or VisitedName like '%",
							text4,
							"%')"
						});
					}
				}
			}
		}
		if (text2 != "" || text3 != "")
		{
			string text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" and VisitDate between '",
				text2,
				"' and '",
				text3,
				"'"
			});
		}
		return text;
	}

	protected void gvgds_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[9].Text, out this.drec1);
			this.drec += this.drec1;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计:";
			e.Row.Cells[9].Text = this.drec.ToString("#0.00");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
	}
}
