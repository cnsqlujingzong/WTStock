using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Customer_InputDevConf : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
		}
	}

	protected void btnUp_Click(object sender, EventArgs e)
	{
		string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + base.Server.MapPath(this.hfPath.Value) + ";Extended Properties=Excel 8.0";
		OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
		oleDbConnection.Open();
		DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[]
		{
			null,
			null,
			null,
			"TABLE"
		});
		for (int i = 0; i < oleDbSchemaTable.Rows.Count; i++)
		{
			this.ddlTableName.Items.Add(new ListItem(oleDbSchemaTable.Rows[i]["TABLE_NAME"].ToString().Replace("$", ""), oleDbSchemaTable.Rows[i]["TABLE_NAME"].ToString().Replace("$", "")));
		}
	}

	protected void ddlTableName_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.InitDDL();
		string str = base.Server.MapPath(this.hfPath.Value);
		string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";data source=" + str;
		OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
		string text = this.ddlTableName.SelectedItem.Text;
		OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM [" + text + "$]", oleDbConnection);
		oleDbConnection.Open();
		OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.SchemaOnly);
		DataTable schemaTable = oleDbDataReader.GetSchemaTable();
		oleDbDataReader.Close();
		if (schemaTable != null)
		{
			foreach (DataRow dataRow in schemaTable.Rows)
			{
				string text2 = (string)dataRow["ColumnName"];
				if (text2 != "F1")
				{
					for (int i = 1; i <= 7; i++)
					{
						string text3 = "ddl" + i;
						DropDownList dropDownList = this.FindControl(text3) as DropDownList;
						dropDownList.Items.Add(new ListItem(text2, text2));
					}
				}
			}
		}
		for (int j = 0; j < this.ddl1.Items.Count; j++)
		{
			if (this.ddl1.Items[j].Text == "名称")
			{
				this.ddl1.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl2.Items.Count; j++)
		{
			if (this.ddl2.Items[j].Text == "参数")
			{
				this.ddl2.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl3.Items.Count; j++)
		{
			if (this.ddl3.Items[j].Text == "序列号")
			{
				this.ddl3.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl4.Items.Count; j++)
		{
			if (this.ddl4.Items[j].Text == "保修期")
			{
				this.ddl4.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl5.Items.Count; j++)
		{
			if (this.ddl5.Items[j].Text == "购买日期")
			{
				this.ddl5.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl6.Items.Count; j++)
		{
			if (this.ddl6.Items[j].Text == "截止日期")
			{
				this.ddl6.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl7.Items.Count; j++)
		{
			if (this.ddl7.Items[j].Text == "备注")
			{
				this.ddl7.Items[j].Selected = true;
				break;
			}
		}
	}

	protected void InitDDL()
	{
		for (int i = 1; i <= 7; i++)
		{
			string text = "ddl" + i;
			DropDownList dropDownList = this.FindControl(text) as DropDownList;
			dropDownList.Items.Clear();
			dropDownList.Items.Add(new ListItem("", ""));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + base.Server.MapPath(this.hfPath.Value) + ";Extended Properties=Excel 8.0";
		OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
		oleDbConnection.Open();
		DataSet dataSet = new DataSet();
		string selectCommandText = "select * from [" + this.ddlTableName.SelectedItem.Text + "$]";
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommandText, oleDbConnection);
		oleDbDataAdapter.Fill(dataSet, "[" + this.ddlTableName.SelectedItem.Text + "$]");
		oleDbDataAdapter.Dispose();
		DataTable dataTable = dataSet.Tables["[" + this.ddlTableName.SelectedItem.Text + "$]"];
		oleDbConnection.Close();
		oleDbDataAdapter.Dispose();
		List<string[]> list = new List<string[]>();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			list.Add(new string[]
			{
				(this.ddl1.SelectedItem.Text == "") ? "" : FunLibrary.ChkInput(dataTable.Rows[i][this.ddl1.SelectedItem.Text].ToString()),
				(this.ddl2.SelectedItem.Text == "") ? "" : FunLibrary.ChkInput(dataTable.Rows[i][this.ddl2.SelectedItem.Text].ToString()),
				(this.ddl3.SelectedItem.Text == "") ? "" : FunLibrary.ChkInput(dataTable.Rows[i][this.ddl3.SelectedItem.Text].ToString()),
				(this.ddl4.SelectedItem.Text == "") ? "" : FunLibrary.ChkInput(dataTable.Rows[i][this.ddl4.SelectedItem.Text].ToString()),
				(this.ddl5.SelectedItem.Text == "") ? "" : FunLibrary.ChkInput(dataTable.Rows[i][this.ddl5.SelectedItem.Text].ToString()),
				(this.ddl6.SelectedItem.Text == "") ? "" : FunLibrary.ChkInput(dataTable.Rows[i][this.ddl6.SelectedItem.Text].ToString()),
				(this.ddl7.SelectedItem.Text == "") ? "" : FunLibrary.ChkInput(dataTable.Rows[i][this.ddl7.SelectedItem.Text].ToString())
			});
		}
		DALDeviceConfig dALDeviceConfig = new DALDeviceConfig();
		string str;
		int num = dALDeviceConfig.Add(list, this.id.ToString(), out str);
		if (num == 0)
		{
			this.SysInfo("window.alert(\"导入完成！\");parent.CloseDialog('1');");
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

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}
}
