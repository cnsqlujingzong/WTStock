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

public partial class Branch_Customer_SltSup : Page, IRequiresSessionState
{
	

	private int pageSize = 18;

	private string f;

	private string d;

	private string strfid;

	
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

	public string Str_D
	{
		get
		{
			return this.d;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.f = base.Request["f"];
		if (this.f == null)
		{
			this.f = string.Empty;
		}
		this.strfid = base.Request["fid"];
		this.d = base.Request["d"];
		if (this.d != "1")
		{
			this.d = "2";
		}
		if (this.strfid == null || this.strfid == string.Empty)
		{
			this.strfid = "iframeDialog";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (dALRight.GetRight(num, "jc_r13"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "SupplierClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
		this.tvsup.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.tvsup.Nodes.Add(treeNode);
		OtherFunction.BindTreeNode(treeNode, dt, treeNode.Value);
		TreeNode treeNode2 = new TreeNode();
		treeNode2.Value = "0";
		treeNode2.Text = "未分类";
		this.tvsup.Nodes[0].ChildNodes.Add(treeNode2);
		this.tvsup.Nodes[0].Selected = true;
		this.tvsup.ExpandDepth = 1;
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
		this.gvsup.DataSource = DALCommon.GetList_HL(1, "ks_supplier", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvsup.DataBind();
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
		if (this.gvsup.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvsup.HeaderRow.Cells.Count; i++)
			{
				this.gvsup.HeaderRow.Cells[i].Attributes.Add("id", ((BoundField)this.gvsup.Columns[i]).DataField);
				this.gvsup.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					((BoundField)this.gvsup.Columns[i]).DataField,
					"','",
					this.gvsup.HeaderRow.Cells[i].Text,
					"');"
				}));
				this.gvsup.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
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
		string text = " bStop='' and DeptID=" + (string)this.Session["Session_wtBranchID"] + " ";
		if (this.f == "1")
		{
			text += "and bSupplier='√'";
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
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALSupplierList dALSupplierList = new DALSupplierList();
					text += dALSupplierList.GetSchWhere(schid, text2);
				}
			}
		}
		return text;
	}

	protected void gvsup_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		string empty = string.Empty;
		string text = string.Empty;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			text = e.Row.Cells[3].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkIDSup('",
				text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ChkSup();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvsup.Rows.Count.ToString();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tvsup_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tvsup.SelectedNode.Expanded = new bool?(true);
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tvsup.SelectedNode.Value;
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}
}
