using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using Wuqi.Webdiyer;

public partial class Headquarters_Sell_SltSellContract : Page, IRequiresSessionState
{
	private int pageSize = 15;

	private string strfid;

	private string f;

	private string flag;

	public string Str_Fid
	{
		get
		{
			return this.strfid;
		}
	}

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	public string Str_Flag
	{
		get
		{
			return this.flag;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.strfid = base.Request["fid"];
		this.flag = base.Request["f"];
		if (this.flag == null || this.flag == string.Empty)
		{
			this.flag = "2";
		}
		if (this.strfid == null || this.strfid == string.Empty)
		{
			this.strfid = "iframeDialog";
			this.f = "1";
		}
		else
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "xs_r11"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (dALRight.GetRight(num, "xs_r19"))
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

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "v_saleContract", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvdata.DataBind();
		this.lbCount.Text = "总记录：" + recordCount.ToString();
		if (this.lbCount.Text == "总记录：0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
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
		string text = " DeptID=1 and Status in(1,2) ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int num = 0;
				int.TryParse(this.ddlKey.SelectedValue, out num);
				if (text2 != "")
				{
					switch (num)
					{
					case 1:
						text = text + " and _Date in ('" + text2 + " 00:00:00 ')";
						break;
					case 2:
						text = text + " and ConstractNO ='" + text2 + "'";
						break;
					case 3:
						text = text + " and CustomerName like '%" + text2 + "%'";
						break;
					case 4:
						text = text + " and LinkMan like '%" + text2 + "%'";
						break;
					case 5:
						text = text + " and Tel='" + text2 + "'";
						break;
					case 6:
						text = text + " and Seller like '%" + text2 + "%'";
						break;
					case 7:
						text = text + " and Operator like '%" + text2 + "%'";
						break;
					case 8:
						text = text + " and Remark like '%" + text2 + "%'";
						break;
					}
				}
			}
			string text3 = text;
			text = string.Concat(new string[]
			{
				text3,
				" and (ContractNO like '%",
				text2,
				"%' or CustomerName like '%",
				text2,
				"%' or LinkMan like '%",
				text2,
				"%' or Tel='",
				text2,
				"' or Seller like '%",
				text2,
				"%' or Operator like '%",
				text2,
				"%' or Remark like '%",
				text2,
				"%')"
			});
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "SltPurPlan();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[2].Text == "1")
			{
				e.Row.Cells[2].Text = "待执行";
			}
			else
			{
				e.Row.Cells[2].Text = "执行中";
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[8].Text == "&nbsp;")
			{
				e.Row.Cells[8].Text = Convert.ToDouble(0).ToString("#0.00");
			}
			if (e.Row.Cells[11].Text == "&nbsp;")
			{
				e.Row.Cells[11].Text = Convert.ToDouble(0).ToString("#0.00");
			}
			else
			{
				e.Row.Cells[11].Text = Convert.ToDouble(e.Row.Cells[12].Text).ToString("#0.00");
			}
		}
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		if (this.hfRecID.Value != "")
		{
			this.GridView2.DataSource = DALCommon.GetDataList("v_salecontractdetail", "", " ContractID=" + this.hfRecID.Value);
			this.GridView2.DataBind();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
