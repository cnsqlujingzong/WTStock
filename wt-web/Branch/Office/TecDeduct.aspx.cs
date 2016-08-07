using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.DB;
using wt.Library;
using Wuqi.Webdiyer;

public partial class Branch_Office_TecDeduct : Page, IRequiresSessionState
{
	private int pageSize = 20;

	private decimal drec1 = 0m;

	private decimal drec = 0m;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r25"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=asdf");
					base.Response.End();
				}
				if (dALRight.GetRight(num, "bg_r29"))
				{
					this.hfvalue.Value = "1";
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.tbStartDate.Text = (this.tbEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd"));
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "StaffList", "[ID],[_Name]", 0, 0, " DeptID = " + (string)this.Session["Session_wtBranchID"] + " and Status=0 ", " ID Asc", out num).Tables[0];
		this.tvgds.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部";
		treeNode.Value = "-1";
		this.tvgds.Nodes.Add(treeNode);
		this.InitFirst(dt, treeNode);
		this.tvgds.Nodes[0].Selected = true;
	}

	protected void InitFirst(DataTable dt, TreeNode menu)
	{
		if (!dt.Rows.Count.Equals(0))
		{
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Text = dt.Rows[i]["_Name"].ToString();
				treeNode.Value = dt.Rows[i]["ID"].ToString();
				menu.ChildNodes.Add(treeNode);
			}
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
		this.gvgds.DataSource = DALCommon.GetList_HL(1, "tc_detail", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvgds.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvgds.HeaderRow.Cells.Count; i++)
			{
				if (i > 0)
				{
					string dataField = ((BoundField)this.gvgds.Columns[i]).DataField;
					string text2 = this.gvgds.HeaderRow.Cells[i].Text;
					this.gvgds.HeaderRow.Cells[i].Attributes.Add("id", dataField);
					this.gvgds.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
					{
						"HeaderOrder('",
						dataField,
						"','",
						text2,
						"');"
					}));
					this.gvgds.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_288 = this.hfTbTitle;
						expr_288.Value = expr_288.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_2D8 = this.hfTbField;
						expr_2D8.Value = expr_2D8.Value + "," + dataField;
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
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		string text2 = FunLibrary.ChkInput(this.tbStartDate.Text);
		string text3 = FunLibrary.ChkInput(this.tbEndDate.Text);
		if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
		{
			text = text + " and OperatorID=" + this.hfClass.Value.Replace("'", "");
		}
		if (text2 != "")
		{
			text = text + " and Time_Finish>='" + text2 + "' ";
		}
		if (text3 != "")
		{
			text = text + " and Time_Finish<='" + text3 + " 23:59:59'";
		}
		if (this.hfvalue.Value == "1")
		{
			if (int.Parse((string)this.Session["Session_wtPurBID"]) > 0)
			{
				text = text + " and OperatorID=" + (string)this.Session["Session_wtUserBID"];
			}
		}
		if (this.ddlTypes.SelectedValue != "")
		{
			text = text + " and Types='" + this.ddlTypes.SelectedValue + "'";
		}
		return text;
	}

	protected void gvgds_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[10].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[7].Text,
				"','",
				e.Row.Cells[10].Text,
				"')"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			decimal.TryParse(e.Row.Cells[9].Text, out this.drec1);
			this.drec += this.drec1;
			if (e.Row.Cells[8].Text == "未收款")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
			else
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
			if (e.Row.Cells[7].Text == "销售")
			{
				e.Row.Cells[5].Text = string.Concat(new string[]
				{
					"<a href=\"#\" onclick=\"Sell('",
					e.Row.Cells[5].Text,
					"');\">",
					e.Row.Cells[5].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[7].Text == "服务")
			{
				e.Row.Cells[5].Text = string.Concat(new string[]
				{
					"<a href=\"#\" onclick=\"Services('",
					e.Row.Cells[5].Text,
					"');\">",
					e.Row.Cells[5].Text,
					"</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvgds.Rows.Count.ToString();
			e.Row.Cells[1].Text = "合计:";
			e.Row.Cells[9].Text = this.drec.ToString("#0.0000");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tvgds_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tvgds.SelectedNode.Expanded = new bool?(true);
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tvgds.SelectedNode.Value;
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		DataTable dt = DALCommon.GetDataList("tc_detail", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "tcde", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			int.TryParse((string)this.Session["Session_wtUserBID"], out num);
			int id = 0;
			int.TryParse(this.hfRID.Value, out id);
			string strTbName = "";
			if (this.hfType.Value.ToString() == "销售")
			{
				strTbName = "SellDeduct";
			}
			if (this.hfType.Value.ToString() == "服务")
			{
				strTbName = "BillDeduct";
			}
			this.DeleteDate(id, strTbName);
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('删除成功');");
		}
		catch
		{
			this.SysInfo("window.alert('操作异常！删除失败');");
		}
	}

	public void DeleteDate(int id, string strTbName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("delete " + strTbName + " ");
		stringBuilder.Append(" where ID=" + id.ToString());
		DbHelperSQL.ExecuteSql(stringBuilder.ToString());
	}
}
