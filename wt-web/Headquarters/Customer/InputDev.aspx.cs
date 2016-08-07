using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Customer_InputDev : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
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
					for (int i = 1; i <= 35; i++)
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
			if (this.ddl1.Items[j].Text == "客户名称")
			{
				this.ddl1.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl2.Items.Count; j++)
		{
			if (this.ddl2.Items[j].Text == "客户编号")
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
			if (this.ddl4.Items[j].Text == "所属部门")
			{
				this.ddl4.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl5.Items.Count; j++)
		{
			if (this.ddl5.Items[j].Text == "联系电话")
			{
				this.ddl5.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl6.Items.Count; j++)
		{
			if (this.ddl6.Items[j].Text == "手机号码")
			{
				this.ddl6.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl7.Items.Count; j++)
		{
			if (this.ddl7.Items[j].Text == "传真")
			{
				this.ddl7.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl8.Items.Count; j++)
		{
			if (this.ddl8.Items[j].Text == "邮编")
			{
				this.ddl8.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl9.Items.Count; j++)
		{
			if (this.ddl9.Items[j].Text == "地址")
			{
				this.ddl9.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl10.Items.Count; j++)
		{
			if (this.ddl10.Items[j].Text == "品牌")
			{
				this.ddl10.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl11.Items.Count; j++)
		{
			if (this.ddl11.Items[j].Text == "类别")
			{
				this.ddl11.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl12.Items.Count; j++)
		{
			if (this.ddl12.Items[j].Text == "型号")
			{
				this.ddl12.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl13.Items.Count; j++)
		{
			if (this.ddl13.Items[j].Text == "序列号1")
			{
				this.ddl13.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl14.Items.Count; j++)
		{
			if (this.ddl14.Items[j].Text == "序列号2")
			{
				this.ddl14.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl15.Items.Count; j++)
		{
			if (this.ddl15.Items[j].Text == "外观")
			{
				this.ddl15.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl16.Items.Count; j++)
		{
			if (this.ddl16.Items[j].Text == "购买时间")
			{
				this.ddl16.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl17.Items.Count; j++)
		{
			if (this.ddl17.Items[j].Text == "经销商")
			{
				this.ddl17.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl18.Items.Count; j++)
		{
			if (this.ddl18.Items[j].Text == "购买发票")
			{
				this.ddl18.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl19.Items.Count; j++)
		{
			if (this.ddl19.Items[j].Text == "保修期")
			{
				this.ddl19.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl20.Items.Count; j++)
		{
			if (this.ddl20.Items[j].Text == "保修情况")
			{
				this.ddl20.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl21.Items.Count; j++)
		{
			if (this.ddl21.Items[j].Text == "厂家保修开始")
			{
				this.ddl21.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl22.Items.Count; j++)
		{
			if (this.ddl22.Items[j].Text == "厂家保修截止")
			{
				this.ddl22.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl23.Items.Count; j++)
		{
			if (this.ddl23.Items[j].Text == "最近维修时间")
			{
				this.ddl23.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl24.Items.Count; j++)
		{
			if (this.ddl24.Items[j].Text == "合同保修开始")
			{
				this.ddl24.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl25.Items.Count; j++)
		{
			if (this.ddl25.Items[j].Text == "合同保修截止")
			{
				this.ddl25.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl26.Items.Count; j++)
		{
			if (this.ddl26.Items[j].Text == "维修保修截止")
			{
				this.ddl26.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl27.Items.Count; j++)
		{
			if (this.ddl27.Items[j].Text == "维修合同编号")
			{
				this.ddl27.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl28.Items.Count; j++)
		{
			if (this.ddl28.Items[j].Text == "安装日期")
			{
				this.ddl28.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl29.Items.Count; j++)
		{
			if (this.ddl29.Items[j].Text == "备注")
			{
				this.ddl29.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl30.Items.Count; j++)
		{
			if (this.ddl30.Items[j].Text == "机器编号")
			{
				this.ddl30.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl31.Items.Count; j++)
		{
			if (this.ddl31.Items[j].Text == "自定义1")
			{
				this.ddl31.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl32.Items.Count; j++)
		{
			if (this.ddl32.Items[j].Text == "自定义2")
			{
				this.ddl32.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl33.Items.Count; j++)
		{
			if (this.ddl33.Items[j].Text == "自定义3")
			{
				this.ddl33.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl34.Items.Count; j++)
		{
			if (this.ddl34.Items[j].Text == "自定义4")
			{
				this.ddl34.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl35.Items.Count; j++)
		{
			if (this.ddl35.Items[j].Text == "自定义5")
			{
				this.ddl35.Items[j].Selected = true;
				break;
			}
		}
	}

	protected void InitDDL()
	{
		for (int i = 1; i <= 35; i++)
		{
			string id = "ddl" + i;
			DropDownList dropDownList = this.FindControl(id) as DropDownList;
			dropDownList.Items.Clear();
			dropDownList.Items.Add(new ListItem("", ""));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.lbFaillist.Text = "";
		DALDeviceList dALDeviceList = new DALDeviceList();
		string text = string.Empty;
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
		int ideptid = 1;
		string struserdef = "";
		string struserdef2 = "";
		string struserdef3 = "";
		string struserdef4 = "";
		string struserdef5 = "";
		string text2 = "";
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			string strname = "";
			string text3 = "";
			string strlinkman = "";
			string strdept = "";
			string strtel = "";
			string strtel2 = "";
			string strfax = "";
			string strzip = "";
			string stradr = "";
			string strbrand = "";
			string strclass = "";
			string strmodel = "";
			string text4 = "";
			string strsn = "";
			string straspect = "";
			string strbuydate = "";
			string strbuyfrom = "";
			string strinvoice = "";
			string strprot = "";
			string strrepstatus = "";
			string strwstart = "";
			string strwend = "";
			string strlastdate = "";
			string strpstart = "";
			string strpend = "";
			string strfind = "";
			string strcontractno = "";
			string strinstall = "";
			string strremark = "";
			string text5 = "";
			if (this.ddl1.SelectedItem.Text != "")
			{
				strname = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl1.SelectedItem.Text].ToString());
			}
			if (this.cbsys.Checked)
			{
				text3 = "";
			}
			else if (this.ddl2.SelectedItem.Text != "")
			{
				text3 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl2.SelectedItem.Text].ToString());
			}
			if (this.ddl3.SelectedItem.Text != "")
			{
				strlinkman = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl3.SelectedItem.Text].ToString());
			}
			if (this.ddl4.SelectedItem.Text != "")
			{
				strdept = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl4.SelectedItem.Text].ToString());
			}
			if (this.ddl5.SelectedItem.Text != "")
			{
				strtel = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl5.SelectedItem.Text].ToString());
			}
			if (this.ddl6.SelectedItem.Text != "")
			{
				strtel2 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl6.SelectedItem.Text].ToString());
			}
			if (this.ddl7.SelectedItem.Text != "")
			{
				strfax = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl7.SelectedItem.Text].ToString());
			}
			if (this.ddl8.SelectedItem.Text != "")
			{
				strzip = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl8.SelectedItem.Text].ToString());
			}
			if (this.ddl9.SelectedItem.Text != "")
			{
				stradr = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl9.SelectedItem.Text].ToString());
			}
			if (this.ddl10.SelectedItem.Text != "")
			{
				strbrand = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl10.SelectedItem.Text].ToString());
			}
			if (this.ddl11.SelectedItem.Text != "")
			{
				strclass = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl11.SelectedItem.Text].ToString());
			}
			if (this.ddl12.SelectedItem.Text != "")
			{
				strmodel = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl12.SelectedItem.Text].ToString());
			}
			if (this.ddl13.SelectedItem.Text != "")
			{
				text4 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl13.SelectedItem.Text].ToString());
			}
			if (this.ddl14.SelectedItem.Text != "")
			{
				strsn = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl14.SelectedItem.Text].ToString());
			}
			if (this.ddl15.SelectedItem.Text != "")
			{
				straspect = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl15.SelectedItem.Text].ToString());
			}
			if (this.ddl16.SelectedItem.Text != "")
			{
				strbuydate = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl16.SelectedItem.Text].ToString());
			}
			if (this.ddl17.SelectedItem.Text != "")
			{
				strbuyfrom = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl17.SelectedItem.Text].ToString());
			}
			if (this.ddl18.SelectedItem.Text != "")
			{
				strinvoice = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl18.SelectedItem.Text].ToString());
			}
			if (this.ddl19.SelectedItem.Text != "")
			{
				strprot = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl19.SelectedItem.Text].ToString());
			}
			if (this.ddl20.SelectedItem.Text != "")
			{
				strrepstatus = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl20.SelectedItem.Text].ToString());
			}
			if (this.ddl21.SelectedItem.Text != "")
			{
				strwstart = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl21.SelectedItem.Text].ToString());
			}
			if (this.ddl22.SelectedItem.Text != "")
			{
				strwend = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl22.SelectedItem.Text].ToString());
			}
			if (this.ddl23.SelectedItem.Text != "")
			{
				strlastdate = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl23.SelectedItem.Text].ToString());
			}
			if (this.ddl24.SelectedItem.Text != "")
			{
				strpstart = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl24.SelectedItem.Text].ToString());
			}
			if (this.ddl25.SelectedItem.Text != "")
			{
				strpend = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl25.SelectedItem.Text].ToString());
			}
			if (this.ddl26.SelectedItem.Text != "")
			{
				strfind = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl26.SelectedItem.Text].ToString());
			}
			if (this.ddl27.SelectedItem.Text != "")
			{
				strcontractno = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl27.SelectedItem.Text].ToString());
			}
			if (this.ddl28.SelectedItem.Text != "")
			{
				strinstall = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl28.SelectedItem.Text].ToString());
			}
			if (this.ddl29.SelectedItem.Text != "")
			{
				strremark = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl29.SelectedItem.Text].ToString());
			}
			if (this.ddl30.SelectedItem.Text != "")
			{
				text5 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl30.SelectedItem.Text].ToString());
			}
			if (this.ddl31.SelectedItem.Text != "")
			{
				struserdef = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl31.SelectedItem.Text].ToString());
			}
			if (this.ddl32.SelectedItem.Text != "")
			{
				struserdef2 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl32.SelectedItem.Text].ToString());
			}
			if (this.ddl33.SelectedItem.Text != "")
			{
				struserdef3 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl33.SelectedItem.Text].ToString());
			}
			if (this.ddl34.SelectedItem.Text != "")
			{
				struserdef4 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl34.SelectedItem.Text].ToString());
			}
			if (this.ddl35.SelectedItem.Text != "")
			{
				struserdef5 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl35.SelectedItem.Text].ToString());
			}
			int num3 = dALDeviceList.InputDevice(ideptid, strname, text3, strlinkman, strdept, strtel, strtel2, strfax, strzip, stradr, strbrand, strclass, strmodel, text4, strsn, straspect, strbuydate, strbuyfrom, strinvoice, strprot, strrepstatus, strwstart, strwend, strlastdate, strpstart, strpend, strfind, strcontractno, strinstall, strremark, text5, struserdef, struserdef2, struserdef3, struserdef4, struserdef5, this.cbCover.Checked, out text2);
			if (num3 == 0)
			{
				num++;
			}
			else
			{
				string text6 = text;
				text = string.Concat(new string[]
				{
					text6,
					"<tr><td>",
					text4,
					"</td><td>",
					text5,
					"</td><td>",
					text3,
					"</td><td>",
					text2,
					"</tr>"
				});
				num2++;
			}
		}
		if (num2 == 0)
		{
			this.SysInfo("window.alert(\"导入完成！成功导入" + num.ToString() + "条记录\");parent.CloseDialog('1');");
		}
		else if (num == 0)
		{
			this.SysInfo("window.alert(\"导入全部失败！失败原因：序列号已存在或机器编号重复\");");
		}
		else
		{
			string text7 = base.Server.MapPath("~/Errorlog/");
			if (!Directory.Exists(text7))
			{
				Directory.CreateDirectory(text7);
			}
			string str = DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
			string path = text7 + str;
			StreamWriter streamWriter = File.CreateText(path);
			text = "<html><meta http-equiv=\"content-type\"content=\"text/html; charset=UTF-8\"/><style type=\"text/css\">td{padding-left:10px;padding-right:10px;}</style><body><table><tr><td>序列号1</td><td>机器编号</td><td>客户编号</td><td>失败原因</td></tr>" + text + "</table></body></html>";
			streamWriter.Write(text);
			streamWriter.Flush();
			streamWriter.Close();
			this.lbFaillist.Text = "<a href='../../Errorlog/" + str + "' target='_blank' style='color:blue;'>查看失败列表</a>";
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert(\"导入完成！成功导入",
				num.ToString(),
				"条记录，失败",
				num2.ToString(),
				"条记录\");"
			}));
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}
}
