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

public partial class Branch_Stock_SltGoods : Page, IRequiresSessionState
{
	
	private int pageSize = 18;

	private string strfid;

	private string f;

	private string id;

	private string flag;

	private string ifd;

	private bool _bga;

	
	public bool bGA
	{
		get
		{
			return this._bga;
		}
	}

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

	public string Str_Ifd
	{
		get
		{
			return this.ifd;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.strfid = base.Request["fid"];
		this.id = base.Request["id"];
		this.flag = base.Request["flag"];
		this.ifd = base.Request["f"];
		if (this.flag == null || this.flag == "")
		{
			this.flag = "2";
		}
		else
		{
			this.flag = "1";
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
		if (this.ifd == null || this.ifd == "")
		{
			this.ifd = "1";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			DALRight dALRight = new DALRight();
			this._bga = dALRight.BranchAddGoods(num, int.Parse(this.Session["Session_wtBranchID"].ToString()));
			if (num > 0)
			{
				if (dALRight.GetRight(num, "jc_r12"))
				{
					this.hfPurCost.Value = "1";
				}
				if (dALRight.GetRight(num, "jc_r13"))
				{
					this.hfPurProv.Value = "1";
				}
				if (!dALRight.GetRight(num, "ck_r1"))
				{
					this.hfStock.Value = "1";
				}
				if (!dALRight.GetRight(num, "ck_r2"))
				{
					this.hfStockR.Value = "1";
				}
			}
			this.LoadClass();
			this.FillData();
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
		Branch_Stock_SltGoods.BindTreeNode(treeNode, dt, treeNode.Value);
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
			Branch_Stock_SltGoods.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
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
		this.FillData();
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void FillData()
	{
		int recordCount = 0;
		string text = this.strParm();
		if (this.id != null && this.id != string.Empty)
		{
			text = text + " and ID<>" + this.id;
		}
		string fldSort = "ID desc";
		this.gvgds.DataSource = DALCommon.GetList_HL(1, "ck_goods", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvgds.DataBind();
		this.lbCount.Text = "总记录:" + recordCount.ToString();
		if (this.lbCount.Text == "总记录:0")
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
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected string strParm()
	{
		string text = " bStop='' ";
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
		return text;
	}

	protected void gvgds_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (this.hfPurCost.Value == "1")
		{
			e.Row.Cells[9].Visible = false;
		}
		if (this.hfPurProv.Value == "1")
		{
			e.Row.Cells[16].Visible = false;
		}
		string[] array = this.hfreclist.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkSltList();");
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
			this.lbPage.Text = "当前页:" + this.gvgds.Rows.Count.ToString();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tvgds_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tvgds.SelectedNode.Expanded = new bool?(true);
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tvgds.SelectedNode.ToolTip;
		this.hfClassID.Value = this.tvgds.SelectedNode.Value;
		this.FillData();
	}

	protected void btnStockDept_Click(object sender, EventArgs e)
	{
		this.GetStockDept();
	}

	protected void GetStockDept()
	{
		string str = " and DeptID=" + (string)this.Session["Session_wtBranchID"];
		if (this.hfStock.Value == "1")
		{
			str = " and bReject<>1 ";
		}
		if (this.hfStockR.Value == "1")
		{
			str = " and bReject<>0 ";
		}
		this.GridView1.DataSource = DALCommon.GetDataList("ck_stockdept", "", " GoodsID=" + this.hfRecID.Value + str).Tables[0];
		this.GridView1.DataBind();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID2('s" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[3].Attributes.Add("style", "font-weight:bold;");
		}
	}
}
