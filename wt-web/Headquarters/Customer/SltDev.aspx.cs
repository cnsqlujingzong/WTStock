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

public partial class Headquarters_Customer_SltDev : Page, IRequiresSessionState
{

	private int pageSize = 10;

	private string strfid;

	private string f;

	private string flag;

	private string psn;

	private string strname;

	private string x;

	private int icusid;

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

	public string Str_X
	{
		get
		{
			return this.x;
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
		this.psn = base.Request["psn"];
		if (this.psn == null)
		{
			this.psn = "";
		}
		this.strname = base.Request["strname"];
		if (this.strname == null)
		{
			this.strname = "";
		}
		this.x = base.Request["x"];
		if (this.x == null)
		{
			this.x = "";
		}
		this.strfid = base.Request["fid"];
		int.TryParse(base.Request["cusid"], out this.icusid);
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
			this.f = "";
		}
		if (base.Request.QueryString["cid"] != null && !base.Request.QueryString["cid"].TrimStart(new char[0]).Equals(""))
		{
			this.btnNew.Attributes["onclick"] = "parent.ShowDialog2(750, 430, 'Customer/DeviceAdd.aspx?f=2&id=" + base.Request.QueryString["cid"].Trim() + "', '新建机器档案');";
		}
		if (!base.IsPostBack)
		{
			if (this.psn != "")
			{
				this.tbCon.Text = this.psn;
			}
			else
			{
				this.tbCon.Text = this.strname;
			}
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r6"))
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
		if (this.tbCon.Text != "")
		{
			if (this.icusid > 0)
			{
				text = text + " and CustomerID=" + this.icusid;
			}
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ks_device", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
		string text = " 1=1 ";
		if (this.ddlKey.SelectedValue != "-1")
		{
			int schid = 0;
			int.TryParse(this.ddlKey.SelectedValue, out schid);
			string text2 = FunLibrary.ChkInput(this.tbCon.Text);
			if (text2 != "")
			{
				DALDeviceList dALDeviceList = new DALDeviceList();
				text += dALDeviceList.GetSchWhere(schid, text2);
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		string[] array = this.hfreclist.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkSltList();");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:5px;");
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

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('q" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tq" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "a" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('a" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "ta" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[4].Text != "")
			{
				e.Row.Cells[4].Text = "<a href=\"" + e.Row.Cells[4].Text + "\" target=\"_blank\" style=\"color:#0000ff\" >查看</a>";
			}
		}
	}

	protected void ShowDetail()
	{
		int num = 0;
		this.GridView2.DataSource = DALCommon.GetList_HL(0, "DeviceConfig", "", 0, 0, " DeviceID=" + this.hfRecID.Value, " ID desc ", out num);
		this.GridView2.DataBind();
		this.FillDataa();
		this.FillDatale();
		this.FillDatab();
		DataTable dataTable = DALCommon.GetDataList("ks_device", "ProductSN1", "[ID]=" + this.hfRecID.Value).Tables[0];
		string text = " DeviceID=" + this.hfRecID.Value;
		if (dataTable.Rows.Count > 0)
		{
			text = text + " or SN='" + dataTable.Rows[0]["ProductSN1"].ToString() + "'";
		}
		this.GridView3.DataSource = DALCommon.GetDataList("ks_qtylist", "", text);
		this.GridView3.DataBind();
	}

	protected void FillDataa()
	{
		this.GridView4.DataSource = DALCommon.GetDataList("ks_deviceaccessory", "", " DeviceID=" + this.hfRecID.Value + " order by ID desc");
		this.GridView4.DataBind();
	}

	protected void FillDatale()
	{
		string strCondition = " DeviceID=" + this.hfRecID.Value;
		this.GridView5.DataSource = DALCommon.GetDataList("zl_meterreading", "", strCondition);
		this.GridView5.DataBind();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "le" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('le" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "LeaseV();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}

	protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "led" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('led" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tled" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void FillDatab()
	{
		string text = " 1=1 ";
		string text2 = " 1=1 ";
		DataTable dataTable = DALCommon.GetDataList("ks_device", "CustomerID,ProductSN1,ProductBrand,ProductClass,ProductModel", "[ID]=" + this.hfRecID.Value).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			text = text + " and CustomerID=" + dataTable.Rows[0]["CustomerID"].ToString();
			string text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				" and CustomerID=",
				dataTable.Rows[0]["CustomerID"].ToString(),
				" and [ID] in(select [BillID] from zl_leasedevice where DeviceID=",
				this.hfRecID.Value,
				")"
			});
			if (dataTable.Rows[0]["ProductSN1"].ToString() != "")
			{
				text = text + " and ProductSN1='" + dataTable.Rows[0]["ProductSN1"].ToString() + "'";
			}
			else
			{
				text3 = text;
				text = string.Concat(new string[]
				{
					text3,
					" and ProductBrand='",
					dataTable.Rows[0]["ProductBrand"].ToString(),
					"' and ProductClass='",
					dataTable.Rows[0]["ProductClass"].ToString(),
					"' and ProductModel='",
					dataTable.Rows[0]["ProductModel"].ToString(),
					"'"
				});
			}
		}
		this.GridView1.DataSource = DALCommon.GetDataList("zl_lease", "", text2);
		this.GridView1.DataBind();
		this.GridView6.DataSource = DALCommon.GetDataList("fw_services", "", text);
		this.GridView6.DataBind();
	}

	protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "b" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('b" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "SerV();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[20].Text.Length > 16)
			{
				e.Row.Cells[20].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[20].Text,
					"\" onclick=\"ShowTA('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[20].Text.Substring(0, 16),
					"...</a>"
				});
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
