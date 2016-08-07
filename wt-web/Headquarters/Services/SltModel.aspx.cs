using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using Wuqi.Webdiyer;

public partial class Headquarters_Services_SltModel : Page, IRequiresSessionState
{
	private int pageSize = 18;

	private string strfid;

	private string f;

	private string flag;

	private string strBrand = "";

	private string strClass = "";

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
		FunLibrary.ChkHead(btel);
		this.strBrand = base.Request["sBrand"].ToString();
		this.strClass = base.Request["sClass"].ToString();
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
		if (this.flag == "x")
		{
			this.strfid = "iframeDialog1";
			this.f = "2";
		}
		if (!base.IsPostBack)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ks_Model", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
		string text = " [ID]>0 ";
		if (this.strBrand != "")
		{
			text = text + "and  ProductBrand='" + this.strBrand + "'";
		}
		if (this.strClass != "")
		{
			text = text + "and  ProductClass='" + this.strClass + "'";
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (text2 != "")
		{
			string text3 = text;
			text = string.Concat(new string[]
			{
				text3,
				" and (_Name like '%",
				text2,
				"%' or ProductClass like '%",
				text2,
				"%' or ProductBrand like '%",
				text2,
				"%')"
			});
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			'^'
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			text = e.Row.Cells[2].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text2 = e.Row.Cells[3].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text3 = e.Row.Cells[4].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkValue('",
				text,
				"','",
				text2,
				"','",
				text3,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ChkPass();");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:5px;");
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
