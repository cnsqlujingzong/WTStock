using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Headquarters_Lease_EditFormula : Page, IRequiresSessionState
{

	private string tbformula;

	private string formula;

	private string fid;

	private string f;

	private int ff;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("StartQty", typeof(int)));
				dataTable.Columns.Add(new DataColumn("EndQty", typeof(int)));
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
		FunLibrary.ChkHead();
		this.tbformula = base.Request["tbformula"];
		this.formula = base.Request["formula"];
		this.fid = base.Request["fid"];
		int.TryParse(base.Request["ff"], out this.ff);
		if (this.tbformula == null || this.formula == null)
		{
			base.Response.Write("参数传入错误，请重新打开编辑窗口");
			base.Response.End();
		}
		if (this.fid == null || this.fid == string.Empty)
		{
			if (this.ff == 0)
			{
				this.fid = "iframeDialog";
				this.f = "2";
			}
			else
			{
				this.fid = "iframeDialog1";
				this.f = "2";
			}
		}
		else
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			this.hfFormula.Value = this.formula;
			this.AddEmpty();
			this.FillData();
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = 0;
		dataRow[1] = 0;
		dataRow[2] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void FillData()
	{
		if (this.formula != null && this.formula != string.Empty)
		{
			string[] array = this.formula.Split(new char[]
			{
				'$'
			});
			for (int i = 0; i < array.Length; i++)
			{
				this.NewRow(i, array[i]);
			}
		}
		this.BindData();
	}

	protected void NewRow(int id, string str)
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		string[] array = str.Split(new char[]
		{
			'|'
		});
		dataRow[0] = array[0].ToString();
		dataRow[1] = array[1].ToString();
		dataRow[2] = array[2].ToString();
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		decimal num = 0m;
		int num2 = 0;
		int num3 = 0;
		decimal.TryParse(this.tbPrice.Text, out num);
		int.TryParse(this.tbStartQty.Text, out num2);
		int.TryParse(this.tbEndQty.Text, out num3);
		dataRow[0] = num;
		dataRow[1] = num2;
		dataRow[2] = num3;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.CrFormula();
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.FillData();
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.CrFormula();
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.FillData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex == 0)
		{
			e.Row.Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[0].Attributes.Add("style", "background:#ECE9D8;");
		}
	}

	private void CrFormula()
	{
		DataTable gridViewSource = this.GridViewSource;
		string text = "";
		for (int i = 1; i < gridViewSource.Rows.Count; i++)
		{
			if (text == "")
			{
				text = string.Concat(new string[]
				{
					gridViewSource.Rows[i]["Price"].ToString(),
					"|",
					gridViewSource.Rows[i]["StartQty"].ToString(),
					"|",
					gridViewSource.Rows[i]["EndQty"].ToString()
				});
			}
			else
			{
				text = string.Concat(new string[]
				{
					text,
					"$",
					gridViewSource.Rows[i]["Price"].ToString(),
					"|",
					gridViewSource.Rows[i]["StartQty"].ToString(),
					"|",
					gridViewSource.Rows[i]["EndQty"].ToString()
				});
			}
		}
		this.formula = text;
		this.hfFormula.Value = text;
		this.SysInfo(string.Concat(new string[]
		{
			"parent.",
			this.fid,
			".document.getElementById(\"",
			this.tbformula,
			"\").value='",
			base.Server.HtmlEncode(text),
			"';"
		}));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
