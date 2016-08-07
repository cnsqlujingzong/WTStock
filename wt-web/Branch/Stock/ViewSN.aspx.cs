using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Branch_Stock_ViewSN : Page, IRequiresSessionState
{
	
	private string snvalue;
    

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.snvalue = base.Request["sn"];
		this.hfSN.Value = this.snvalue;
		this.FillData();
	}

	protected void FillData()
	{
		if (this.snvalue != null && this.snvalue != string.Empty)
		{
			string[] array = this.snvalue.Split(new char[]
			{
				','
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
		dataRow[0] = str;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[0].Attributes.Add("style", "background:#ECE9D8;");
		}
	}
}
