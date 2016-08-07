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

public partial class Headquarters_Stock_SltUnitQty : Page, IRequiresSessionState
{
	private string strfid;

	private string f;

	private string id;

	private string uid;

	private string qty;

	private string tbqty;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UnitRelation", typeof(decimal)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
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

	public string Str_tbqty
	{
		get
		{
			return this.tbqty;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.id = base.Request["id"];
		this.uid = base.Request["uid"];
		this.qty = base.Request["qty"];
		this.tbqty = base.Request["tbqty"];
		if (this.id == null || this.id == string.Empty || this.uid == null || this.uid == string.Empty || this.qty == null || this.qty == string.Empty || this.tbqty == null)
		{
			base.Response.End();
		}
		this.strfid = base.Request["fid"];
		if (this.strfid == null || this.strfid == string.Empty)
		{
			this.strfid = "iframeDialog";
			this.f = "1";
		}
		else
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			this.FillData();
		}
	}

	protected void FillData()
	{
		string strCondition = " GoodsID=" + this.id.Replace("q", "");
		DataTable dataTable = DALCommon.GetDataList("ck_goodsunit", "", strCondition).Tables[0];
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			DataRow dataRow = gridViewSource.NewRow();
			dataRow[0] = dataTable.Rows[i]["ID"].ToString();
			dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
			dataRow[2] = "";
			dataRow[3] = dataTable.Rows[i]["UnitRelation"].ToString();
			gridViewSource.Rows.Add(dataRow);
		}
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i][2] = textBox.Text;
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Cells[2].Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[0].Text == this.uid)
			{
				TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
				textBox.Text = this.qty;
			}
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnConf_Click(object sender, EventArgs e)
	{
		decimal num = 0m;
		decimal num2 = 0m;
		decimal num3 = 0m;
		decimal.TryParse(this.qty, out num3);
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			decimal.TryParse(gridViewSource.Rows[i]["Qty"].ToString(), out num);
			num2 += num;
		}
		if (num2 == 0m)
		{
			this.SysInfo("window.alert('操作失败！请输入数量.');");
			this.BindData();
		}
		else
		{
			decimal d = 0m;
			num = 0m;
			num2 = 0m;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (gridViewSource.Rows[i]["ID"].ToString() == this.uid)
				{
					d = decimal.Parse(gridViewSource.Rows[i]["UnitRelation"].ToString());
				}
			}
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				decimal.TryParse(gridViewSource.Rows[i]["Qty"].ToString(), out num);
				num2 += num * decimal.Parse(gridViewSource.Rows[i]["UnitRelation"].ToString()) / d;
			}
			this.SysInfo("ChkSltList('" + num2 + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
