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
using wt.OtherLibrary;

public partial class Headquarters_Basic_InputSuplierList : Page, IRequiresSessionState
{
	private int iflag;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r33"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			int num2 = 0;
			this.slSupClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "SupplierClass", "", 0, 0, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slSupClass);
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
					for (int i = 1; i <= 14; i++)
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
			if (this.ddl1.Items[j].Text == "厂商名称")
			{
				this.ddl1.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl2.Items.Count; j++)
		{
			if (this.ddl2.Items[j].Text == "厂商编号")
			{
				this.ddl2.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl3.Items.Count; j++)
		{
			if (this.ddl3.Items[j].Text == "联系人")
			{
				this.ddl3.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl4.Items.Count; j++)
		{
			if (this.ddl4.Items[j].Text == "联系电话")
			{
				this.ddl4.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl5.Items.Count; j++)
		{
			if (this.ddl5.Items[j].Text == "手机号")
			{
				this.ddl5.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl6.Items.Count; j++)
		{
			if (this.ddl6.Items[j].Text == "传真")
			{
				this.ddl6.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl7.Items.Count; j++)
		{
			if (this.ddl7.Items[j].Text == "邮编")
			{
				this.ddl7.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl8.Items.Count; j++)
		{
			if (this.ddl8.Items[j].Text == "EMail")
			{
				this.ddl8.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl9.Items.Count; j++)
		{
			if (this.ddl9.Items[j].Text == "账户")
			{
				this.ddl9.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl10.Items.Count; j++)
		{
			if (this.ddl10.Items[j].Text == "地址")
			{
				this.ddl10.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl11.Items.Count; j++)
		{
			if (this.ddl11.Items[j].Text == "备注")
			{
				this.ddl11.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl12.Items.Count; j++)
		{
			if (this.ddl12.Items[j].Text == "送修厂商")
			{
				this.ddl12.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl13.Items.Count; j++)
		{
			if (this.ddl13.Items[j].Text == "产品供应商")
			{
				this.ddl13.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl14.Items.Count; j++)
		{
			if (this.ddl14.Items[j].Text == "特约维修结算厂商")
			{
				this.ddl14.Items[j].Selected = true;
				break;
			}
		}
	}

	protected void InitDDL()
	{
		for (int i = 1; i <= 14; i++)
		{
			string id = "ddl" + i;
			DropDownList dropDownList = this.FindControl(id) as DropDownList;
			dropDownList.Items.Clear();
			dropDownList.Items.Add(new ListItem("", ""));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALSupplierList dALSupplierList = new DALSupplierList();
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
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			string strname = "";
			string strsupno = "";
			int strsupclass = int.Parse(this.slSupClass.Items[this.slSupClass.SelectedIndex].Value);
			string strlinkman = "";
			string strtel = "";
			string strtel2 = "";
			string strfax = "";
			string strzip = "";
			string strEMail = "";
			string straccount = "";
			string stradr = "";
			string strremark = "";
			string strtransmitcorp = "";
			string strsuplier = "";
			string strchargecorp = "";
			int depetid = 1;
			if (this.ddl1.SelectedItem.Text != "")
			{
				strname = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl1.SelectedItem.Text].ToString());
			}
			if (this.cbsys.Checked)
			{
				strsupno = "";
			}
			else if (this.ddl2.SelectedItem.Text != "")
			{
				strsupno = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl2.SelectedItem.Text].ToString());
			}
			if (this.ddl3.SelectedItem.Text != "")
			{
				strlinkman = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl3.SelectedItem.Text].ToString());
			}
			if (this.ddl4.SelectedItem.Text != "")
			{
				strtel = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl4.SelectedItem.Text].ToString());
			}
			if (this.ddl5.SelectedItem.Text != "")
			{
				strtel2 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl5.SelectedItem.Text].ToString());
			}
			if (this.ddl6.SelectedItem.Text != "")
			{
				strfax = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl6.SelectedItem.Text].ToString());
			}
			if (this.ddl7.SelectedItem.Text != "")
			{
				strzip = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl7.SelectedItem.Text].ToString());
			}
			if (this.ddl8.SelectedItem.Text != "")
			{
				strEMail = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl8.SelectedItem.Text].ToString());
			}
			if (this.ddl9.SelectedItem.Text != "")
			{
				straccount = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl9.SelectedItem.Text].ToString());
			}
			if (this.ddl10.SelectedItem.Text != "")
			{
				stradr = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl10.SelectedItem.Text].ToString());
			}
			if (this.ddl11.SelectedItem.Text != "")
			{
				strremark = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl11.SelectedItem.Text].ToString());
			}
			if (this.ddl12.SelectedItem.Text != "")
			{
				strtransmitcorp = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl12.SelectedItem.Text].ToString());
			}
			if (this.ddl13.SelectedItem.Text != "")
			{
				strsuplier = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl13.SelectedItem.Text].ToString());
			}
			if (this.ddl14.SelectedItem.Text != "")
			{
				strchargecorp = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl14.SelectedItem.Text].ToString());
			}
			string text;
			int num3 = dALSupplierList.Add_Sup(strname, strsupno, strsupclass, strlinkman, strtel, strtel2, strfax, strzip, strEMail, straccount, stradr, strremark, strtransmitcorp, strsuplier, strchargecorp, depetid, out text);
			if (num3 == 0)
			{
				num++;
			}
			else
			{
				num2++;
			}
		}
		if (num2 == 0)
		{
			this.SysInfo("window.alert(\"导入完成！成功导入" + num.ToString() + "条记录\");parent.CloseDialog('1');");
		}
		else if (num == 0)
		{
			this.SysInfo("window.alert(\"导入全部失败！厂商信息已存在\");");
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert(\"导入完成！成功导入",
				num.ToString(),
				"条记录，失败",
				num2.ToString(),
				"条记录，失败原因：厂商信息已存在\");parent.CloseDialog('1');"
			}));
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}
}
