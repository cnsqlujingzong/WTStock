using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Stock_SNStockOUT : Page, IRequiresSessionState
{

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Date", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Operator", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
				dataTable.Columns.Add(new DataColumn("OperationID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StockName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	private DataTable GridViewSourceSN
	{
		get
		{
			if (this.ViewState["ListSN"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				this.ViewState["ListSN"] = dataTable;
			}
			return (DataTable)this.ViewState["ListSN"];
		}
		set
		{
			this.ViewState["ListSN"] = value;
		}
	}

	private DataTable GridViewSourceSN2
	{
		get
		{
			if (this.ViewState["ListSN2"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				this.ViewState["ListSN2"] = dataTable;
			}
			return (DataTable)this.ViewState["ListSN2"];
		}
		set
		{
			this.ViewState["ListSN2"] = value;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r9"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.AddEmpty();
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = "";
		dataRow[6] = "";
		dataRow[7] = "";
		dataRow[8] = "";
		dataRow[9] = "";
		dataRow[10] = "";
		dataRow[11] = "";
		dataRow[12] = 0;
		dataRow[13] = 0;
		dataRow[14] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
		}
	}

	protected void gvSN_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
		}
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	private void BindDataSN()
	{
		this.CollectData();
		this.GridViewSourceSN2.Clear();
		DataTable gridViewSourceSN = this.GridViewSourceSN2;
		DataRow[] array = this.GridViewSourceSN.Select(" ID=" + this.hfRecID.Value);
		DataRow[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			DataRow dataRow = array2[i];
			DataRow dataRow2 = gridViewSourceSN.NewRow();
			dataRow2[0] = dataRow["SN"].ToString();
			dataRow2[1] = dataRow["ID"].ToString();
			dataRow2[2] = dataRow["RecID"].ToString();
			gridViewSourceSN.Rows.Add(dataRow2);
		}
		this.gvSN.DataSource = gridViewSourceSN;
		this.gvSN.DataBind();
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
		this.gvSN.DataSource = null;
		this.gvSN.DataBind();
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfreclist.Value.EndsWith(","))
		{
			text = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfreclist.Value;
		}
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("sn_stockoutdetail", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["ID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["Type"].ToString();
						dataRow[1] = dataTable.Rows[i]["BillID"].ToString();
						dataRow[2] = dataTable.Rows[i]["_Date"].ToString();
						dataRow[3] = dataTable.Rows[i]["Operator"].ToString();
						dataRow[4] = dataTable.Rows[i]["Reason"].ToString();
						dataRow[5] = dataTable.Rows[i]["OperationID"].ToString();
						dataRow[6] = dataTable.Rows[i]["StockName"].ToString();
						dataRow[7] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[8] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[9] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[10] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[11] = "";
						decimal num;
						decimal.TryParse(dataTable.Rows[i]["Qty"].ToString(), out num);
						dataRow[12] = num;
						dataRow[13] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
						dataRow[14] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[15] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
						gridViewSource.Rows.Add(dataRow);
						DataTable gridViewSourceSN = this.GridViewSourceSN;
						int num2 = 0;
						while (num2 < num)
						{
							DataRow dataRow2 = gridViewSourceSN.NewRow();
							dataRow2[0] = "";
							dataRow2[1] = int.Parse(dataTable.Rows[i]["ID"].ToString());
							dataRow2[2] = gridViewSourceSN.Rows.Count;
							gridViewSourceSN.Rows.Add(dataRow2);
							num2++;
						}
					}
				}
				this.BindData();
			}
		}
	}

	private void CollectData()
	{
		DataTable gridViewSourceSN = this.GridViewSourceSN2;
		for (int i = 0; i < this.gvSN.Rows.Count; i++)
		{
			TextBox textBox = this.gvSN.Rows[i].FindControl("tbSN") as TextBox;
			int index = 0;
			int.TryParse(gridViewSourceSN.Rows[i]["RecID"].ToString(), out index);
			DataTable gridViewSourceSN2 = this.GridViewSourceSN;
			gridViewSourceSN2.Rows[index]["SN"] = textBox.Text;
		}
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.BindDataSN();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.GridViewSourceSN.Clear();
		this.GridViewSourceSN2.Clear();
		this.hfRecID.Value = "-1";
		this.hfreclist.Value = "";
		this.BindData();
		this.gvSN.DataSource = null;
		this.gvSN.DataBind();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！请添加出库明细');");
		}
		else
		{
			DataTable gridViewSource = this.GridViewSource;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				DataRow[] array = this.GridViewSourceSN.Select(" ID=" + gridViewSource.Rows[i]["ID"].ToString());
				DataRow[] array2 = array;
				for (int j = 0; j < array2.Length; j++)
				{
					DataRow dataRow = array2[j];
					if (FunLibrary.ChkInput(dataRow["SN"].ToString()) == "")
					{
						this.SysInfo(string.Concat(new string[]
						{
							"window.alert('出库单号：",
							gridViewSource.Rows[i]["BillID"].ToString(),
							" 产品编号：",
							gridViewSource.Rows[i]["GoodsNO"].ToString(),
							" 序列号为空，请添加！');"
						}));
						return;
					}
				}
			}
			List<string[]> list = new List<string[]>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				DataRow[] array = this.GridViewSourceSN.Select(" ID=" + gridViewSource.Rows[i]["ID"].ToString());
				DataRow[] array2 = array;
				for (int j = 0; j < array2.Length; j++)
				{
					DataRow dataRow = array2[j];
					list.Add(new string[]
					{
						"1",
						dataRow["ID"].ToString(),
						dataRow["SN"].ToString()
					});
				}
			}
			DALStockSN dALStockSN = new DALStockSN();
			string str = "";
			int num = dALStockSN.SN_StockOUT(list, out str);
			if (num == 0)
			{
				this.SysInfo("parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert(\"" + str + "\");");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
