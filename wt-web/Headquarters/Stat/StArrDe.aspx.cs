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

public partial class Headquarters_Stat_StArrDe : Page, IRequiresSessionState
{
	private decimal drec1 = 0m;

	private decimal drec2 = 0m;

	private decimal drec3 = 0m;

	private decimal dtest = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r48"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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

	protected void FillData(string sortExpression, string direction)
	{
		int num = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and Status='已审核' and Type='收款单'");
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(0, "zk_arrearagedetail2", "", 0, 0, text, fldSort, out num);
		this.gvdata.DataBind();
		this.lbCount.Text = num.ToString();
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
							HiddenField expr_235 = this.hfTbTitle;
							expr_235.Value = expr_235.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_287 = this.hfTbField;
							expr_287.Value = expr_287.Value + "," + dataField;
						}
					}
				}
			}
		}
	}

	protected string strParm()
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string text3 = " Status=1 ";
		if (this.r1.Checked)
		{
			text3 += " and Type='应收款'";
		}
		else
		{
			text3 += " and Type='应付款'";
		}
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and convert(char(10),_Date,120)>='" + text + "'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and convert(char(10),_Date,120)<='" + text2 + " 23:59:59'";
		}
		string text4 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (text4 != "")
				{
					string text5 = text3;
					text3 = string.Concat(new string[]
					{
						text5,
						"and ",
						this.ddlKey.SelectedValue,
						" like '%",
						text4,
						"%'"
					});
				}
			}
		}
		return text3;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[3].Text.Trim().Contains("采购"))
			{
				e.Row.Attributes["ondblclick"] = "ChkCG(\"" + e.Row.Cells[4].Text.Trim() + "\")";
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("服务合同"))
			{
				e.Row.Attributes["ondblclick"] = "ChkHT(\"" + e.Row.Cells[4].Text.Trim() + "\")";
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("完工结算"))
			{
				e.Row.Attributes["ondblclick"] = "ChkGD(\"" + e.Row.Cells[4].Text.Trim() + "\")";
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("网点调拨"))
			{
				e.Row.Attributes["ondblclick"] = "ChkDB(\"" + e.Row.Cells[4].Text.Trim() + "\")";
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("销售"))
			{
				e.Row.Attributes["ondblclick"] = "ChkXS(\"" + e.Row.Cells[4].Text.Trim() + "\")";
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("租金结算"))
			{
				e.Row.Attributes["ondblclick"] = "ChkJS(\"" + e.Row.Cells[4].Text.Trim() + "\")";
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("收货结算"))
			{
				e.Row.Attributes["ondblclick"] = "ChkGD(\"" + e.Row.Cells[4].Text.Trim() + "\")";
			}
			else if (e.Row.Cells[3].Text.Trim().Contains("预收款") || e.Row.Cells[3].Text.Trim().Contains("预付款"))
			{
				e.Row.Attributes["ondblclick"] = "ChkSFK(\"" + e.Row.Cells[4].Text.Trim() + "\")";
			}
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.drec1 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.drec2 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.drec3 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计:";
			e.Row.Cells[7].Text = this.drec1.ToString("#0.00");
			e.Row.Cells[8].Text = this.drec2.ToString("#0.00");
			e.Row.Cells[9].Text = this.drec3.ToString("#0.00");
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
		DataTable dt = DALCommon.GetDataList("zk_arrearagedetail2", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "arrde", out flag, out empty);
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
