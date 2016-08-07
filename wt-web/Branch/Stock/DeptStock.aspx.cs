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
using Wuqi.Webdiyer;

public partial class Branch_Stock_DeptStock : Page, IRequiresSessionState
{
	private int pageSize = 200;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r65"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=5");
					base.Response.End();
				}
				if (dALRight.GetRight(num, "jc_r14"))
				{
					this.hfPurCostPrice.Value = "1";
				}
			}
			this.LoadClass();
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "GoodsClass", "", 0, 0, "Father=-1", " Array Asc", out num).Tables[0];
		this.tvgds.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.tvgds.Nodes.Add(treeNode);
		Branch_Stock_DeptStock.BindTreeNode(treeNode, dt, treeNode.Value);
		TreeNode treeNode2 = new TreeNode();
		treeNode2.Value = "0";
		treeNode2.Text = "未分类";
		this.tvgds.Nodes[0].ChildNodes.Add(treeNode2);
		this.tvgds.Nodes[0].Selected = true;
		this.tvgds.ExpandDepth = 1;
	}

	public static void BindTreeNode(TreeNode node, DataTable dt, string parentid)
	{
		DataRow[] array = dt.Select(" Father=" + parentid);
		DataRow[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			DataRow dataRow = array2[i];
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["_Name"].ToString();
			treeNode.Value = dataRow["ID"].ToString();
			treeNode.ToolTip = dataRow["_Level"].ToString();
			node.ChildNodes.Add(treeNode);
			Branch_Stock_DeptStock.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
		}
	}

	protected void tvgds_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
	{
		if (e.Node.ChildNodes.Count != 0)
		{
			this.AddChild(e.Node, e.Node.Value);
		}
	}

	protected void AddChilds(TreeNode node)
	{
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "1";
		treeNode.Value = "1";
		treeNode.ToolTip = "1";
		node.ChildNodes.Add(treeNode);
	}

	protected void AddChild(TreeNode node, string strID)
	{
		if (strID != "")
		{
			DataTable dataTable = DALCommon.GetList("GoodsClass", "[ID],_Name,_Level,Father", "Father= " + strID + " order by Array Asc").Tables[0];
			if (!dataTable.Rows.Count.Equals(0))
			{
				node.ChildNodes.Clear();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					TreeNode treeNode = new TreeNode();
					treeNode.Text = dataTable.Rows[i]["_Name"].ToString();
					treeNode.Value = dataTable.Rows[i]["ID"].ToString();
					treeNode.ToolTip = dataTable.Rows[i]["_Level"].ToString();
					node.ChildNodes.Add(treeNode);
					DataTable dataTable2 = DALCommon.GetList("GoodsClass", "1", " Father=" + dataTable.Rows[i]["ID"].ToString()).Tables[0];
					if (!dataTable2.Rows.Count.Equals(0))
					{
						this.AddChilds(treeNode);
					}
				}
			}
		}
		if (node.Depth == 0)
		{
			TreeNode treeNode2 = new TreeNode();
			treeNode2.Value = "-2";
			treeNode2.Text = "未分类";
			this.tvgds.Nodes[0].ChildNodes.Add(treeNode2);
			this.tvgds.Nodes[0].Selected = true;
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
		this.lbAStock.Text = "0.00";
		this.lbAmount.Text = "0.00";
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		int num = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out num);
		int num2 = int.Parse((string)this.Session["Session_wtPurBID"]);
		if (num2 > 0)
		{
			DALRight dALRight = new DALRight();
			if (dALRight.GetRight(num2, "ck_r78"))
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" and (StockAdmID1=",
					num,
					" or StockAdmID2=",
					num,
					" or charindex('",
					this.Session["Session_wtUserB"].ToString(),
					"',OtherStockAdm)>0) "
				});
			}
		}
		DataTable dataTable = DALCommon.GetDataList("ck_stockdepthb", "sum(isnull(Stock,0)) as Qty,sum(isnull(StockAmount,0)) as Amount", text).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.lbAStock.Text = dataTable.Rows[0]["Qty"].ToString();
			this.lbAmount.Text = dataTable.Rows[0]["Amount"].ToString();
		}
		this.gvgds.DataSource = DALCommon.GetList_HL(1, "ck_stockdepthb", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (dataField != "ID" && text2 != "Flag")
				{
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_435 = this.hfTbTitle;
						expr_435.Value = expr_435.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_487 = this.hfTbField;
						expr_487.Value = expr_487.Value + "," + dataField;
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
		if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
		{
			if (this.hfClass.Value == "0")
			{
				text += " and ClassID is null ";
			}
			else
			{
				text = text + " and _Level like '" + this.hfClass.Value + "%'";
			}
		}
		else if (this.hfClassID.Value == "-2")
		{
			text += " and ClassID is null ";
		}
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALGoods dALGoods = new DALGoods();
					text += dALGoods.GetSchWhere(schid, text2);
				}
			}
		}
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text = text + " and DeptID=" + this.ddlBranch.SelectedValue;
		}
		if (this.ddlStock.SelectedValue != "-1")
		{
			text = text + " and StockID=" + this.ddlStock.SelectedValue;
		}
		if (this.cbzerostk.Checked)
		{
			text += " and Stock<>0 ";
		}
		return text;
	}

	protected void gvgds_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (this.hfPurCostPrice.Value == "1")
		{
			e.Row.Cells[9].Visible = (e.Row.Cells[11].Visible = false);
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkWarming();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "√")
			{
				e.Row.Attributes.Add("style", "color:#999;");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvgds.Rows.Count.ToString();
		}
	}

	protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlBranch.SelectedValue != "-1")
		{
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + this.ddlBranch.SelectedValue);
		}
		else
		{
			this.ddlStock.Items.Clear();
			this.ddlStock.Items.Insert(0, new ListItem("全部", "-1"));
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.hfRecID.Value = "-1";
	}

	protected void ddlStock_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.hfRecID.Value = "-1";
	}

	protected void cbzerostk_CheckedChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		this.hfClass.Value = this.tvgds.SelectedNode.ToolTip;
		this.hfClassID.Value = this.tvgds.SelectedNode.Value;
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
		DataTable dt = DALCommon.GetDataList("ck_stockdepthb", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "DeptStock", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}
}
