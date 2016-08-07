using System;
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

public partial class Branch_Stock_InputStockCheck : Page, IRequiresSessionState
{
	private string strfid;

	private string f;

	

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
    
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
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
					for (int i = 1; i <= 2; i++)
					{
						string id = "ddl" + i;
						DropDownList dropDownList = this.FindControl(id) as DropDownList;
						dropDownList.Items.Add(new ListItem(text2, text2));
					}
				}
			}
		}
		for (int j = 0; j < this.ddl1.Items.Count; j++)
		{
			if (this.ddl1.Items[j].Text == "产品编号")
			{
				this.ddl1.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl2.Items.Count; j++)
		{
			if (this.ddl2.Items[j].Text == "实际数量")
			{
				this.ddl2.Items[j].Selected = true;
				break;
			}
		}
	}

	protected void InitDDL()
	{
		for (int i = 1; i <= 2; i++)
		{
			string id = "ddl" + i;
			DropDownList dropDownList = this.FindControl(id) as DropDownList;
			dropDownList.Items.Clear();
			dropDownList.Items.Add(new ListItem("", ""));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALGoods dALGoods = new DALGoods();
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
		string text = "";
		int num = 0;
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			if (this.ddl1.SelectedItem.Text != "")
			{
				text = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl1.SelectedItem.Text].ToString());
			}
			if (this.ddl2.SelectedItem.Text != "")
			{
				num = int.Parse(FunLibrary.ChkInput(dataTable.Rows[i][this.ddl2.SelectedItem.Text].ToString()));
			}
			DataTable dataTable2 = DALCommon.GetDataList("ck_goods_check", "", string.Concat(new string[]
			{
				"GoodsNO='",
				text,
				"'and DeptID=",
				(string)this.Session["Session_wtBranchID"],
				""
			})).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				HiddenField expr_220 = this.hfreclist;
				expr_220.Value = expr_220.Value + dataTable2.Rows[0]["ID"].ToString() + ",";
				if (num.ToString() == "" || num.ToString() == null)
				{
					num = 0;
				}
				HiddenField expr_28F = this.hfQtylist;
				expr_28F.Value = expr_28F.Value + num.ToString() + ",";
			}
		}
		this.SysInfo(" ChkSltList();");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}
}
