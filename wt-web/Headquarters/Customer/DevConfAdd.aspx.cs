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

public partial class Headquarters_Customer_DevConfAdd : Page, IRequiresSessionState
{

	private int id;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Parameter", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MaintenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BuyDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MaintenanceEnd", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
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
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id != 0)
		{
			if (!base.IsPostBack)
			{
				int num = int.Parse((string)this.Session["Session_wtPurID"]);
				if (num > 0)
				{
					DALRight dALRight = new DALRight();
					if (!dALRight.GetRight(num, "kh_r7"))
					{
						this.btnAdd.Enabled = false;
					}
				}
				this.AddEmpty();
			}
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
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.GridView1.Rows.Count; i++)
		{
			TextBox textBox = this.GridView1.Rows[i].FindControl("tbName") as TextBox;
			TextBox textBox2 = this.GridView1.Rows[i].FindControl("tbParameter") as TextBox;
			TextBox textBox3 = this.GridView1.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox4 = this.GridView1.Rows[i].FindControl("tbPeriod") as TextBox;
			TextBox textBox5 = this.GridView1.Rows[i].FindControl("tbBuyDate") as TextBox;
			TextBox textBox6 = this.GridView1.Rows[i].FindControl("tbMaintenanceEnd") as TextBox;
			TextBox textBox7 = this.GridView1.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i][0] = FunLibrary.ChkInput(textBox.Text);
			gridViewSource.Rows[i][1] = FunLibrary.ChkInput(textBox2.Text);
			gridViewSource.Rows[i][2] = FunLibrary.ChkInput(textBox3.Text);
			gridViewSource.Rows[i][3] = FunLibrary.ChkInput(textBox4.Text);
			gridViewSource.Rows[i][4] = FunLibrary.ChkInput(textBox5.Text);
			gridViewSource.Rows[i][5] = FunLibrary.ChkInput(textBox6.Text);
			gridViewSource.Rows[i][6] = FunLibrary.ChkInput(textBox7.Text);
			string a = string.Concat(new string[]
			{
				gridViewSource.Rows[i][0].ToString(),
				gridViewSource.Rows[i][1].ToString(),
				gridViewSource.Rows[i][2].ToString(),
				gridViewSource.Rows[i][3].ToString(),
				gridViewSource.Rows[i][4].ToString(),
				gridViewSource.Rows[i][5].ToString(),
				gridViewSource.Rows[i][6].ToString()
			});
			if (a == string.Empty)
			{
				gridViewSource.Rows[i].Delete();
			}
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("jc_deviceconfitem", "", " ProductClass like '%" + str + "%' ").Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = dataTable.Rows[i]["_Name"].ToString();
				dataRow[1] = dataTable.Rows[i]["Parameter"].ToString();
				dataRow[2] = "";
				dataRow[3] = dataTable.Rows[i]["MaintenancePeriod"].ToString();
				dataRow[4] = "";
				dataRow[5] = "";
				dataRow[6] = dataTable.Rows[i]["Remark"].ToString();
				gridViewSource.Rows.Add(dataRow);
			}
			this.BindData();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！没有该类别的配置项');$('" + this.tbCon.ClientID + "').select();");
		}
	}

	protected void btnId_Click(object sender, EventArgs e)
	{
		this.CollectData();
		string text = string.Empty;
		if (this.hfRecID.Value.EndsWith(","))
		{
			text = this.hfRecID.Value.Remove(this.hfRecID.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfRecID.Value;
		}
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("jc_deviceconfitem", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[1] = dataTable.Rows[i]["Parameter"].ToString();
					dataRow[2] = "";
					dataRow[3] = dataTable.Rows[i]["MaintenancePeriod"].ToString();
					dataRow[4] = "";
					dataRow[5] = "";
					dataRow[6] = dataTable.Rows[i]["Remark"].ToString();
					gridViewSource.Rows.Add(dataRow);
				}
			}
		}
		this.BindData();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		this.AddEmpty();
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	private void BindData()
	{
		this.GridView1.DataSource = this.GridViewSource;
		this.GridView1.DataBind();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (this.GridViewSource.Rows.Count == 0)
		{
			this.SysInfo("window.alert('操作失败！请机器配置信息');$('" + this.tbCon.ClientID + "').select();");
		}
		else
		{
			this.CollectData();
			DataTable gridViewSource = this.GridViewSource;
			List<string[]> list = new List<string[]>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				list.Add(new string[]
				{
					gridViewSource.Rows[i]["_Name"].ToString(),
					gridViewSource.Rows[i]["Parameter"].ToString(),
					gridViewSource.Rows[i]["SN"].ToString(),
					gridViewSource.Rows[i]["MaintenancePeriod"].ToString(),
					gridViewSource.Rows[i]["MaintenanceEnd"].ToString(),
					gridViewSource.Rows[i]["BuyDate"].ToString(),
					gridViewSource.Rows[i]["Remark"].ToString()
				});
			}
			DALDeviceConfig dALDeviceConfig = new DALDeviceConfig();
			string str;
			int num = dALDeviceConfig.Add(list, this.id.ToString(), out str);
			if (num == 0)
			{
				this.SysInfo("parent.CloseDialog('1');");
			}
			else if (num == -1)
			{
				this.SysInfo("window.alert('" + str + "');");
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');");
			}
		}
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.BindData();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
