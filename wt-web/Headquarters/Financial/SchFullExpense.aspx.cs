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

public partial class Headquarters_Financial_SchFullExpense : Page, IRequiresSessionState
{

	private int pageSize = 20;

	private bool blayout = false;

	private int itake = 23;

	private int iflag;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r24"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.FillData();
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM") + "-01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData();
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.FillData();
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.FillData();
	}

	protected void LoadField(DataSet ds)
	{
		DataTable dataTable = ds.Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvdata.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "姓名";
			boundField.HeaderText = "姓名";
			this.gvdata.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "所属网点";
			boundField.HeaderText = "所属网点";
			this.gvdata.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "日期";
			boundField.HeaderText = "日期";
			this.gvdata.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "关联业务";
			boundField.HeaderText = "关联业务";
			this.gvdata.Columns.Add(boundField);
			for (int i = 4; i < dataTable.Columns.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				if (i == dataTable.Columns.Count - 1)
				{
					boundField2.HeaderText = dataTable.Columns[i].Caption.ToString();
					boundField2.DataField = dataTable.Columns[i].Caption.ToString();
				}
				else
				{
					boundField2.HeaderText = dataTable.Columns[i].Caption.ToString().TrimStart(new char[]
					{
						'c'
					});
					boundField2.DataField = dataTable.Columns[i].Caption.ToString();
				}
				this.gvdata.Columns.Add(boundField2);
			}
			this.blayout = true;
		}
	}

	protected void FillData()
	{
		int flag = 0;
		int.TryParse(this.ddlKey.SelectedValue, out flag);
		DataSet listBX = DALCommon.GetListBX(this.tbDateB.Text, this.tbDateE.Text, this.ddlStatus.SelectedValue, flag, this.tbCon.Text, "");
		this.LoadField(listBX);
		DataTable dataSource = listBX.Tables[0];
		this.gvdata.DataSource = dataSource;
		this.gvdata.DataBind();
		this.lbCount.Text = (listBX.Tables[0].Rows.Count - 1).ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Text = "无信息记录";
			this.lbPage.Visible = false;
			this.lbCountText.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
			this.lbCountText.Visible = true;
		}
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
	}

	protected string strParm()
	{
		return "  ";
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[4].Visible = false;
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnExcelDe_Click(object sender, EventArgs e)
	{
		int flag = 0;
		int.TryParse(this.ddlKey.SelectedValue, out flag);
		DataSet listBX = DALCommon.GetListBX(this.tbDateB.Text, this.tbDateE.Text, this.ddlStatus.SelectedValue, flag, this.tbCon.Text, "");
		DataToExcel.CreateExcel(listBX);
	}
}
