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

public partial class Headquarters_Customer_SltCus2 : Page, IRequiresSessionState
{
	private int pageSize = 18;

	private string strfid;

	private string f;

	private int x;

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

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.strfid = base.Request["fid"];
		if (this.strfid == null || this.strfid == string.Empty)
		{
			this.strfid = "iframeDialog";
		}
		this.f = base.Request["f"];
		if (this.f == null || this.f == "")
		{
			this.f = "1";
		}
		else
		{
			this.f = Convert.ToDouble(1 + int.Parse(this.f)).ToString();
		}
		int.TryParse(base.Request["x"], out this.x);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
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
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
				}
				if (dALRight.GetRight(num, "kh_r29"))
				{
					this.hfPur1.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r35"))
				{
					this.hfPurDept.Value = "1";
				}
			}
			if (this.x == 1)
			{
				this.btnAss.Visible = true;
				this.btnAdd.Visible = false;
			}
			else
			{
				this.btnAss.Visible = false;
				this.btnAdd.Visible = true;
			}
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
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		if (this.hfPur1.Value != "")
		{
			text = text + " and SellerID=" + (string)this.Session["Session_wtUserID"];
		}
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or SellerID is null)";
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
			text += " and RegDept=1";
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
		if (this.hfSch.Value == "0")
		{
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
		}
		return text;
	}

	protected void gvcus_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		string text = string.Empty;
		string text2 = string.Empty;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			text2 = e.Row.Cells[2].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text = e.Row.Cells[3].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkIDCus('",
				text,
				"','",
				text2,
				"');"
			}));
			if (this.x == 0)
			{
				e.Row.Attributes.Add("ondblclick", "ChkCus();");
			}
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
