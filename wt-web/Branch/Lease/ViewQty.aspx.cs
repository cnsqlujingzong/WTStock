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

public partial class Branch_Lease_ViewQty : Page, IRequiresSessionState
{


	private string fid;

	private string f;

	private int id;

	

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("QtyTypeName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BeginQty", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ChargeStyle", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Rated", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SuperZhangFee", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CostPrice", typeof(string)));
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
			return this.fid;
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
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		this.fid = base.Request["fid"];
		if (this.fid == null || this.fid == string.Empty)
		{
			this.fid = "iframeDialog";
			this.f = "3";
		}
		else
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			this.FillData();
			DataTable dataTable = DALCommon.GetDataList("zl_leasedetail", "", " BillID=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["DevStatus"].ToString() == "已退机" || dataTable.Rows[0]["DevStatus"].ToString() == "已换机")
				{
					this.btnSave.Visible = false;
				}
			}
			else
			{
				this.btnSave.Visible = false;
			}
		}
	}

	private void FillData()
	{
		DataTable dataTable = DALCommon.GetDataList("zl_leasedetail", "", " BillID=" + this.id).Tables[0];
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			DataRow dataRow = gridViewSource.NewRow();
			dataRow[0] = dataTable.Rows[i]["ID"].ToString();
			dataRow[1] = dataTable.Rows[i]["QtyTypeName"].ToString();
			dataRow[2] = dataTable.Rows[i]["BeginQty"].ToString();
			dataRow[3] = dataTable.Rows[i]["ChargeStyle"].ToString();
			dataRow[4] = dataTable.Rows[i]["Rated"].ToString();
			dataRow[5] = dataTable.Rows[i]["SuperZhangFee"].ToString();
			dataRow[6] = dataTable.Rows[i]["CostPrice"].ToString();
			gridViewSource.Rows.Add(dataRow);
		}
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbRated") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbSuperZhangFee") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbCostPrice") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Rated"] = FunLibrary.ChkInput(textBox.Text);
			gridViewSource.Rows[i]["SuperZhangFee"] = FunLibrary.ChkInput(textBox2.Text);
			gridViewSource.Rows[i]["CostPrice"] = FunLibrary.ChkInput(textBox3.Text);
		}
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		DALLease dALLease = new DALLease();
		decimal rated = 0m;
		decimal supzhangfree = 0m;
		decimal costprice = 0m;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			int num;
			int.TryParse(gridViewSource.Rows[i]["ID"].ToString(), out num);
			decimal.TryParse(gridViewSource.Rows[i]["Rated"].ToString(), out rated);
			decimal.TryParse(gridViewSource.Rows[i]["SuperZhangFee"].ToString(), out supzhangfree);
			decimal.TryParse(gridViewSource.Rows[i]["CostPrice"].ToString(), out costprice);
			int num2 = dALLease.updateCounter(num, rated, supzhangfree, costprice);
			if (num2 != 1)
			{
				ScriptManager.RegisterStartupScript(this, base.GetType(), "关闭", "window.alert('保存失败!');document.getElementById('btnClose').click()", true);
				return;
			}
		}
		ScriptManager.RegisterStartupScript(this, base.GetType(), "关闭对话框", "window.alert('保存成功!');document.getElementById('btnClose').click()", true);
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[4].Text == "阶梯计费法")
			{
				e.Row.Cells[4].Text = "阶梯计费法<a href=\"#\" onclick=\"ViewFormula('" + e.Row.Cells[0].Text + "')\">查看公式</a>";
			}
		}
	}
}
