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

public partial class Branch_Services_SltoubleStepsList : Page, IRequiresSessionState
{
	private int pageSize = 18;

	private string strfid;

	private string f;

	private string flag;

	private string x;

	private string strid;

	

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

	public string Str_ID
	{
		get
		{
			return this.strid;
		}
	}



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.strfid = base.Request["fid"];
		this.flag = base.Request["f"];
		this.x = base.Request["x"];
		this.strid = base.Request["strid"];
		if (this.x == null || this.x == string.Empty)
		{
			this.x = "2";
		}
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
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
			}
			OtherFunction.BindProductClass(this.ddlProduct);
			this.ddlProduct.Items.Remove(new ListItem("新建...", "0"));
			this.ddlProduct.Items.Remove(new ListItem("", "-1"));
			this.ddlProduct.Items.Insert(0, new ListItem("请选择产品类别", "-1"));
			this.ddlRepClass_SelectedIndexChanged(sender, e);
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
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "jc_troubleSteps", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvdata.DataBind();
		this.lbCount.Text = "总记录:" + recordCount.ToString();
		if (this.lbCount.Text == "总记录:0")
		{
			this.lbCount.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
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
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		string[] array = text2.Split(new string[]
		{
			" "
		}, StringSplitOptions.RemoveEmptyEntries);
		if (!this.ddlProduct.SelectedValue.Equals("-1"))
		{
			text = text + " and ProductClassID=" + this.ddlProduct.SelectedValue;
		}
		if (!this.ddlRepClass.SelectedValue.Equals("-1"))
		{
			text = text + " and RepairClassID=" + this.ddlRepClass.SelectedValue;
		}
		if (!this.ddlTroubClass.SelectedValue.Equals("-1"))
		{
			text = text + " and TroubleClassID=" + this.ddlTroubClass.SelectedValue;
		}
		if (!this.ddlTroubleName.SelectedValue.Equals("-1"))
		{
			text = text + " and Summary='" + this.ddlTroubleName.SelectedItem.Text + "'";
		}
		for (int i = 0; i < array.Length; i++)
		{
			string text3 = text;
			text = string.Concat(new string[]
			{
				text3,
				" and (GoodsClass like '%",
				array[i],
				"%' or Summary like '%",
				array[i],
				"%' or  Take_Steps like '%",
				array[i],
				"%' or  TroubleClass like '%",
				array[i],
				"%' or  RepairClass like '%",
				array[i],
				"%') "
			});
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
			text = e.Row.Cells[6].Text.Replace("'", "").Replace("\"", "").Replace("&nbsp;", "");
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkValue('",
				text,
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
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ddlRepClass.Items.Clear();
		if (!this.ddlProduct.SelectedValue.Equals("-1"))
		{
			DataSet dataList = DALCommon.GetDataList("RepairClass", "ID,_Name", string.Format("ID in(select RepairClassID from TroubleList where ProductClassID={0}) order by Array", this.ddlProduct.SelectedValue));
			this.ddlRepClass.DataSource = dataList;
			this.ddlRepClass.DataTextField = "_Name";
			this.ddlRepClass.DataValueField = "ID";
			this.ddlRepClass.DataBind();
		}
		this.ddlRepClass.Items.Insert(0, new ListItem("请选择维修类别", "-1"));
		this.ddlRepClass_SelectedIndexChanged(sender, e);
	}

	protected void ddlRepClass_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ddlTroubClass.Items.Clear();
		if (!this.ddlRepClass.SelectedValue.Equals("-1"))
		{
			DataSet dataList = DALCommon.GetDataList("TroubleClass", "ID,_Name", string.Format("ID in(select TroubleClassID from TroubleList where ProductClassID={0} and RepairClassID={1})", this.ddlProduct.SelectedValue, this.ddlRepClass.SelectedValue));
			this.ddlTroubClass.DataSource = dataList;
			this.ddlTroubClass.DataTextField = "_Name";
			this.ddlTroubClass.DataValueField = "ID";
			this.ddlTroubClass.DataBind();
		}
		this.ddlTroubClass.Items.Insert(0, new ListItem("请选择故障类别", "-1"));
		this.ddlTroubClass_SelectedIndexChanged(sender, e);
	}

	protected void ddlTroubClass_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ddlTroubleName.Items.Clear();
		if (!this.ddlTroubClass.SelectedValue.Equals("-1"))
		{
			DataSet dataList = DALCommon.GetDataList("TroubleList", "ID,Summary", string.Format("ProductClassID={0} and RepairClassID={1} and TroubleClassID={2}", this.ddlProduct.SelectedValue, this.ddlRepClass.SelectedValue, this.ddlTroubClass.SelectedValue));
			this.ddlTroubleName.DataSource = dataList;
			this.ddlTroubleName.DataTextField = "Summary";
			this.ddlTroubleName.DataValueField = "ID";
			this.ddlTroubleName.DataBind();
		}
		this.ddlTroubleName.Items.Insert(0, new ListItem("请选择故障名称", "-1"));
		this.ddlTroubleName_SelectedIndexChanged(sender, e);
	}

	protected void ddlTroubleName_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}
}
