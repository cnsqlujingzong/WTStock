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

public partial class Headquarters_Stock_SltSN : Page, IRequiresSessionState
{
	private int pageSize = 18;

	private string strfid;

	private string f;

	private int gid;

	private string iflag;

	private string strcls = "";

	private string strff;

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

	public string Str_Cls
	{
		get
		{
			return this.strcls;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.strfid = base.Request["fid"];
		this.iflag = base.Request["iflag"];
		this.strff = base.Request["ff"];
		if (this.iflag == null)
		{
			this.iflag = "";
		}
		if (this.strfid == null || this.strfid == string.Empty)
		{
			this.strfid = "iframeDialog" + this.iflag;
			this.f = this.iflag;
			this.strcls = "";
		}
		else
		{
			this.strcls = "1";
			this.f = this.iflag;
		}
		if (this.strff != null && this.strff == "1")
		{
			this.strcls = "1";
			this.f = "1";
		}
		int.TryParse(base.Request["gid"], out this.gid);
		if (!base.IsPostBack)
		{
			this.LoadClass();
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
		Headquarters_Stock_SltSN.BindTreeNode(treeNode, dt, treeNode.Value);
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
			Headquarters_Stock_SltSN.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
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

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ck_stocksn", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (i > 1)
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
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " Status='在库' and DeptID=1 ";
		if (this.gid > 0)
		{
			text = text + " and GoodsID=" + this.gid.ToString();
		}
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
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
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
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		string[] array = this.hfreclist.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "SltBill();");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" onclick=\"cbone(this);\"/>";
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToString() == e.Row.Cells[0].Text)
				{
					e.Row.Cells[1].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" checked=\"checked\" onclick=\"cbone(this);\"/>";
					e.Row.Attributes.Add("style", "background:#D6F1F8;");
					break;
				}
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
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
