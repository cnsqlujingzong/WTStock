
using System;
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

public partial class Branch_Office_SltRcv : Page, IRequiresSessionState
{

	private int pageSize = 18;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			this.FillData();
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("不限制", ""));
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
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "jc_staff", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.gvdata.DataBind();
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
		string text = "1=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.ddlBranch.SelectedItem.Value != "")
		{
			text = text + " and Dept ='" + this.ddlBranch.SelectedItem.Text + "'";
		}
		if (text2 != "")
		{
			text = text + " and _Name like '%" + text2 + "%'";
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		string text = string.Empty;
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			'^'
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			text = e.Row.Cells[2].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "ChkPassOne();");
			e.Row.Attributes.Add("onclick", "ChkValue('" + text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			CheckBox checkBox = e.Row.FindControl("cb") as CheckBox;
			checkBox.Attributes.Add("onclick", string.Concat(new string[]
			{
				"CbView('",
				e.Row.Cells[0].Text,
				"','",
				text,
				"','",
				checkBox.ClientID,
				"');"
			}));
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToString() == e.Row.Cells[0].Text)
				{
					checkBox.Checked = true;
					break;
				}
			}
			e.Row.Cells[3].Attributes.Add("style", "width:30px;padding-right:0px;");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
