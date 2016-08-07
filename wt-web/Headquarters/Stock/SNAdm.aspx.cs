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

public partial class Headquarters_Stock_SNAdm : Page, IRequiresSessionState
{
	private int pageSize = 20;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r7"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=7");
					base.Response.End();
				}
				if (dALRight.GetRight(num, "jc_r36"))
				{
					this.hfPurCostPrice.Value = "1";
				}
			}
			this.LoadClass();
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
			this.ddlStock.Items.Insert(0, new ListItem("全部", "-1"));
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
		Headquarters_Stock_SNAdm.BindTreeNode(treeNode, dt, treeNode.Value);
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
			Headquarters_Stock_SNAdm.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
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
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void LoadField()
	{
		int userID = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out userID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 4, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvdata.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.gvdata.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "Status";
			boundField.HeaderText = "状态";
			this.gvdata.Columns.Add(boundField);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				this.gvdata.Columns.Add(boundField2);
			}
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ck_stocksn", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
							HiddenField expr_2B6 = this.hfTbTitle;
							expr_2B6.Value = expr_2B6.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_306 = this.hfTbField;
							expr_306.Value = expr_306.Value + "," + dataField;
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
		if (this.ddlType.SelectedValue != "-1")
		{
			text = text + " and Status='" + this.ddlType.SelectedValue + "'";
		}
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (text2 != "")
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						" and ",
						this.ddlKey.SelectedValue,
						" like '%",
						text2,
						"%'"
					});
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
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		DALRight dALRight = new DALRight();
		int num = int.Parse((string)this.Session["Session_wtPurID"]);
		if (num > 0)
		{
			if (dALRight.GetRight(num, "ck_r85"))
			{
				e.Row.Cells[10].Visible = false;
				e.Row.Cells[11].Visible = false;
			}
		}
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (this.hfPurCostPrice.Value == "1")
		{
			e.Row.Cells[10].Visible = (e.Row.Cells[11].Visible = false);
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "离库")
			{
				e.Row.Attributes.Add("style", "color: #ff0000");
			}
			else if (e.Row.Cells[1].Text == "在库")
			{
				e.Row.Attributes.Add("style", "color: #008000");
			}
			if (num > 0)
			{
				if (!dALRight.GetRight(num, "ck_r85"))
				{
					e.Row.Cells[4].Text = string.Concat(new string[]
					{
						"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Goods('",
						e.Row.Cells[4].Text,
						"')\">",
						e.Row.Cells[4].Text,
						"</a>"
					});
				}
			}
			else
			{
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Goods('",
					e.Row.Cells[4].Text,
					"')\">",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			e.Row.Cells[14].Text = string.Concat(new string[]
			{
				"<a href=\"#\" style=\"color:#0000ff\" onclick=\"StockIN('",
				e.Row.Cells[14].Text,
				"')\">",
				e.Row.Cells[14].Text,
				"</a>"
			});
			e.Row.Cells[18].Text = string.Concat(new string[]
			{
				"<a href=\"#\" style=\"color:#0000ff\" onclick=\"StockOut('",
				e.Row.Cells[18].Text,
				"')\">",
				e.Row.Cells[18].Text,
				"</a>"
			});
			if (e.Row.Cells[16].Text == "采购入库")
			{
				e.Row.Cells[17].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Purchase('",
					e.Row.Cells[17].Text,
					"','采购单')\">",
					e.Row.Cells[17].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[16].Text == "员工退料")
			{
				e.Row.Cells[17].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"BroughtBack('",
					e.Row.Cells[17].Text,
					"','退料单')\">",
					e.Row.Cells[17].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[16].Text == "销售退货")
			{
				e.Row.Cells[17].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Sell('",
					e.Row.Cells[17].Text,
					"','销售退货单')\">",
					e.Row.Cells[17].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[16].Text == "租赁退还" || e.Row.Cells[16].Text == "设备更换" || e.Row.Cells[16].Text == "租赁退机")
			{
				e.Row.Cells[17].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Lease('",
					e.Row.Cells[17].Text,
					"')\">",
					e.Row.Cells[17].Text,
					"</a>"
				});
			}
			if (e.Row.Cells[20].Text == "员工领料")
			{
				e.Row.Cells[21].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"BroughtBack('",
					e.Row.Cells[21].Text,
					"','领料单')\">",
					e.Row.Cells[21].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[20].Text == "销售出库")
			{
				e.Row.Cells[21].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Sell('",
					e.Row.Cells[21].Text,
					"','销售单')\">",
					e.Row.Cells[21].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[20].Text == "采购退货")
			{
				e.Row.Cells[21].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Purchase('",
					e.Row.Cells[21].Text,
					"','采购退货单')\">",
					e.Row.Cells[21].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[20].Text == "租赁" || e.Row.Cells[20].Text == "租赁增机")
			{
				e.Row.Cells[21].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Lease('",
					e.Row.Cells[21].Text,
					"')\">",
					e.Row.Cells[21].Text,
					"</a>"
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
		DALStockSN dALStockSN = new DALStockSN();
		int num = dALStockSN.Delete(int.Parse(this.hfRecID.Value), out empty);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.hfRecID.Value = "-1";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + this.ddlBranch.SelectedValue);
		}
		else
		{
			this.ddlStock.Items.Clear();
			this.ddlStock.Items.Insert(0, new ListItem("全部", "-1"));
		}
	}

	protected void ddlStock_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.hfRecID.Value = "-1";
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
		DataTable dt = DALCommon.GetDataList("ck_stocksn", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "序列号库", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
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

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
