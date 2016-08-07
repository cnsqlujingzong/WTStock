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
using Wuqi.Webdiyer;

public partial class Branch_Financial_SltCus : Page, IRequiresSessionState
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
		FunLibrary.ChkBran();
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
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfOrder.Value != "")
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
		string text2 = sortExpression + " " + direction;
		if (text2.Trim().Equals(""))
		{
			text2 = " CustomerID desc ";
		}
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		this.hfSql.Value = text;
		this.gvcus.DataSource = DALCommon.GetList_HL(1, "ks_customer2", "", this.pageSize, this.jsPager.CurrentPageIndex, text, text2.Trim(), out recordCount);
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
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo model = dALSysParm.GetModel(1);
		string text = string.Empty;
		if (model.CustomerShar == 1)
		{
			text = text + " (DeptID=" + (string)this.Session["Session_wtBranchID"] + " or DeptID=0)";
		}
		else
		{
			text = " 1=1 ";
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int num = 0;
				int.TryParse(this.ddlKey.SelectedValue, out num);
				if (text2 != "")
				{
					switch (num)
					{
					case 1:
						text += string.Format(" and CustomerNO like '%{0}%'", text2);
						break;
					case 2:
						text += string.Format(" and _Name like '%{0}%'", text2);
						break;
					case 3:
						text += string.Format(" and LinkMan like '%{0}%'", text2);
						break;
					case 4:
						text += string.Format(" and Tel like '%{0}%'", text2);
						break;
					default:
						text += string.Format(" and (CustomerNO like '%{0}%' or _Name like '%{0}%' or LinkMan like '%{0}%' or Tel like '%{0}%')", text2);
						break;
					}
				}
			}
		}
		return text;
	}

	protected void gvcus_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[7].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			text2 = e.Row.Cells[2].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text = e.Row.Cells[3].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			text3 = e.Row.Cells[7].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
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
}
