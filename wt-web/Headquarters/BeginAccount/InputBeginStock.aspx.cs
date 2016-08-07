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

public partial class Headquarters_BeginAccount_InputBeginStock : Page, IRequiresSessionState
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
		FunLibrary.ChkHead();
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
					for (int i = 1; i <= 3; i++)
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
			if (this.ddl2.Items[j].Text == "期初库存")
			{
				this.ddl2.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl3.Items.Count; j++)
		{
			if (this.ddl3.Items[j].Text == "期初成本价")
			{
				this.ddl3.Items[j].Selected = true;
				break;
			}
		}
	}

	protected void InitDDL()
	{
		for (int i = 1; i <= 3; i++)
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
		decimal num2 = 0m;
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			if (this.ddl1.SelectedItem.Text != "")
			{
				text = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl1.SelectedItem.Text].ToString());
			}
			if (this.ddl2.SelectedItem.Text != "")
			{
				int.TryParse(FunLibrary.ChkInput(dataTable.Rows[i][this.ddl2.SelectedItem.Text].ToString()), out num);
			}
			if (this.ddl3.SelectedItem.Text != "")
			{
				decimal.TryParse(FunLibrary.ChkInput(dataTable.Rows[i][this.ddl3.SelectedItem.Text].ToString()), out num2);
			}
			DataTable dataTable2 = DALCommon.GetDataList("ck_goods", "", "GoodsNO='" + text + "'").Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				HiddenField expr_24C = this.hfreclist;
				expr_24C.Value = expr_24C.Value + dataTable2.Rows[0]["ID"].ToString() + ",";
				DataRow[] array = dataTable.Select(this.ddl1.SelectedItem.Text + "='" + text + "'");
				if (array.Length > 1)
				{
					num = 0;
					int num3 = 0;
					for (int j = 0; j < array.Length; j++)
					{
						int.TryParse(FunLibrary.ChkInput(array[j][this.ddl2.SelectedItem.Text].ToString()), out num3);
						num += num3;
					}
				}
				if (num.ToString() == "" || num.ToString() == null)
				{
					num = 1;
				}
				HiddenField expr_351 = this.hfQtylist;
				expr_351.Value = expr_351.Value + num.ToString() + ",";
				if (num2.ToString() == "" || num2.ToString() == null)
				{
					num2 = 0m;
				}
				HiddenField expr_3B0 = this.hfPriceList;
				expr_3B0.Value = expr_3B0.Value + num2.ToString() + ",";
			}
		}
		this.SysInfo(" ChkSltList();");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}
}
