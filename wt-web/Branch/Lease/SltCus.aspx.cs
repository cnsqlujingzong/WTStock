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
using wt.OtherLibrary;
using Wuqi.Webdiyer;

public partial class Branch_Lease_SltCus : Page, IRequiresSessionState
{


	private int pageSize = 18;

	private string strfid;

	private string strname;

	
	public string Str_Fid
	{
		get
		{
			return this.strfid;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.strname = base.Request["strname"];
		if (this.strname == null)
		{
			this.strname = "";
		}
		this.strfid = base.Request["fid"];
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
				if (!dALRight.GetRight(num, "kh_r2"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (dALRight.GetRight(num, "kh_r18"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserBID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
				}
			}
			this.tbCon.Text = this.strname;
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
		this.tvcus.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.tvcus.Nodes.Add(treeNode);
		OtherFunction.BindTreeNode(treeNode, dt, treeNode.Value);
		TreeNode treeNode2 = new TreeNode();
		treeNode2.Value = "0";
		treeNode2.Text = "未分类";
		this.tvcus.Nodes[0].ChildNodes.Add(treeNode2);
		this.tvcus.Nodes[0].Selected = true;
		this.tvcus.ExpandDepth = 1;
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
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo model = dALSysParm.GetModel(1);
		if (model.CustomerShar == 1)
		{
			text = text + " and RegDept=" + (string)this.Session["Session_wtBranchID"];
		}
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		this.hfSql.Value = text;
		this.gvcus.DataSource = DALCommon.GetList_HL(1, "ks_customer", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvcus.DataBind();
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
		if (this.gvcus.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvcus.HeaderRow.Cells.Count; i++)
			{
				this.gvcus.HeaderRow.Cells[i].Attributes.Add("id", ((BoundField)this.gvcus.Columns[i]).DataField);
				this.gvcus.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					((BoundField)this.gvcus.Columns[i]).DataField,
					"','",
					this.gvcus.HeaderRow.Cells[i].Text,
					"');"
				}));
				this.gvcus.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
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
		string text = " bStop='' ";
		if (this.cbDept.Checked)
		{
			text = text + " and RegDept=" + (string)this.Session["Session_wtBranchID"];
		}
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
		if (this.ddlKey.SelectedValue != "-1")
		{
			int schid = 0;
			int.TryParse(this.ddlKey.SelectedValue, out schid);
			if (text2 != "")
			{
				DALCustomerList dALCustomerList = new DALCustomerList();
				text += dALCustomerList.GetSchWhere(schid, text2);
			}
		}
		return text;
	}

	protected void gvcus_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		string text5 = string.Empty;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			text = e.Row.Cells[3].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text2 = e.Row.Cells[4].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text3 = e.Row.Cells[5].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text4 = e.Row.Cells[12].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text5 = e.Row.Cells[7].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkIDCus('",
				text,
				"','",
				text2,
				"','",
				text3,
				"','",
				text4,
				"','",
				text5,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ChkCus();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvcus.Rows.Count.ToString();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tvcus_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tvcus.SelectedNode.Expanded = new bool?(true);
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tvcus.SelectedNode.Value;
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void cbDept_CheckedChanged(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}
}
