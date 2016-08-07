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

public partial class Branch_Basic_SltDevConfItem : Page, IRequiresSessionState
{
	private int pageSize = 18;

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
		bool btel = false;
		if (base.Request.QueryString["itel"] != null)
		{
			btel = true;
		}
		FunLibrary.ChkBran(btel);
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
			this.f = "1";
		}
		if (!base.IsPostBack)
		{
			this.LoadClass();
			this.FillData();
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "ProductClass", "", 0, 0, "", " ID Asc", out num).Tables[0];
		this.tv.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.tv.Nodes.Add(treeNode);
		this.InitFirst(dt, treeNode);
		this.tv.Nodes[0].Selected = true;
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
		string strCondition = this.strParm();
		string fldSort = "ID desc";
		this.gvcus.DataSource = DALCommon.GetList_HL(1, "jc_deviceconfitem", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, fldSort, out recordCount);
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
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected string strParm()
	{
		string text = " DeptID=" + (string)this.Session["Session_wtBranchID"];
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
		{
			if (this.hfClass.Value == "0")
			{
				text += " and ProductClassID is null ";
			}
			else
			{
				text = text + " and ProductClassID=" + this.hfClass.Value.Replace("'", "");
			}
		}
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
		return text;
	}

	protected void gvcus_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		string[] array = this.hfreclist.Value.Split(new char[]
		{
			'^'
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
			this.lbPage.Text = "当前页:" + this.gvcus.Rows.Count.ToString();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tv_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tv.SelectedNode.Expanded = new bool?(true);
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tv.SelectedNode.Value;
		this.FillData();
	}
}
