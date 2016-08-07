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
using wt.OtherLibrary;

public partial class Headquarters_Stock_InputGoods : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = 0;
			this.slGdsClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "GoodsClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slGdsClass);
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
					for (int i = 1; i <= 27; i++)
					{
						string id = "ddl" + i;
						DropDownList dropDownList = this.FindControl(id) as DropDownList;
						dropDownList.Items.Add(new ListItem(text2, text2));
					}
					DropDownList dropDownList2 = this.FindControl("ddlClass") as DropDownList;
					dropDownList2.Items.Add(new ListItem(text2, text2));
				}
			}
		}
		for (int j = 0; j < this.ddl1.Items.Count; j++)
		{
			if (this.ddl1.Items[j].Text == "产品名称")
			{
				this.ddl1.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl2.Items.Count; j++)
		{
			if (this.ddl2.Items[j].Text == "产品编号")
			{
				this.ddl2.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl3.Items.Count; j++)
		{
			if (this.ddl3.Items[j].Text == "属性")
			{
				this.ddl3.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl4.Items.Count; j++)
		{
			if (this.ddl4.Items[j].Text == "规格")
			{
				this.ddl4.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl5.Items.Count; j++)
		{
			if (this.ddl5.Items[j].Text == "品牌")
			{
				this.ddl5.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl6.Items.Count; j++)
		{
			if (this.ddl6.Items[j].Text == "单位")
			{
				this.ddl6.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl7.Items.Count; j++)
		{
			if (this.ddl7.Items[j].Text == "零售价")
			{
				this.ddl7.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl8.Items.Count; j++)
		{
			if (this.ddl8.Items[j].Text == "进货价")
			{
				this.ddl8.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl9.Items.Count; j++)
		{
			if (this.ddl9.Items[j].Text == "内部价")
			{
				this.ddl9.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl10.Items.Count; j++)
		{
			if (this.ddl10.Items[j].Text == "旧货价")
			{
				this.ddl10.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl11.Items.Count; j++)
		{
			if (this.ddl11.Items[j].Text == "替代价")
			{
				this.ddl11.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl12.Items.Count; j++)
		{
			if (this.ddl12.Items[j].Text == "列表价")
			{
				this.ddl12.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl13.Items.Count; j++)
		{
			if (this.ddl13.Items[j].Text == "保修期")
			{
				this.ddl13.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl14.Items.Count; j++)
		{
			if (this.ddl14.Items[j].Text == "条码")
			{
				this.ddl14.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl15.Items.Count; j++)
		{
			if (this.ddl15.Items[j].Text == "成本模式")
			{
				this.ddl15.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl16.Items.Count; j++)
		{
			if (this.ddl16.Items[j].Text == "适用产品")
			{
				this.ddl16.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl17.Items.Count; j++)
		{
			if (this.ddl17.Items[j].Text == "默认仓库")
			{
				this.ddl17.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl18.Items.Count; j++)
		{
			if (this.ddl18.Items[j].Text == "供应商")
			{
				this.ddl18.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl19.Items.Count; j++)
		{
			if (this.ddl19.Items[j].Text == "有效期")
			{
				this.ddl19.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl20.Items.Count; j++)
		{
			if (this.ddl20.Items[j].Text == "允许负库存")
			{
				this.ddl20.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl21.Items.Count; j++)
		{
			if (this.ddl21.Items[j].Text == "备注")
			{
				this.ddl21.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl22.Items.Count; j++)
		{
			if (this.ddl22.Items[j].Text == "自定义1")
			{
				this.ddl22.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl23.Items.Count; j++)
		{
			if (this.ddl23.Items[j].Text == "自定义2")
			{
				this.ddl23.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl24.Items.Count; j++)
		{
			if (this.ddl24.Items[j].Text == "自定义3")
			{
				this.ddl24.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl25.Items.Count; j++)
		{
			if (this.ddl25.Items[j].Text == "自定义4")
			{
				this.ddl25.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl26.Items.Count; j++)
		{
			if (this.ddl26.Items[j].Text == "自定义5")
			{
				this.ddl26.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl27.Items.Count; j++)
		{
			if (this.ddl27.Items[j].Text == "自定义6")
			{
				this.ddl27.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddlClass.Items.Count; j++)
		{
			if (this.ddlClass.Items[j].Text == "产品类别" || this.ddlClass.Items[j].Text == "产品分类")
			{
				this.ddlClass.ClearSelection();
				this.ddlClass.Items[j].Selected = true;
				break;
			}
		}
	}

	protected void InitDDL()
	{
		for (int i = 1; i <= 27; i++)
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
		int igoodsclassid = 0;
		if (!this.cbInputClass.Checked)
		{
			igoodsclassid = int.Parse(this.slGdsClass.Items[this.slGdsClass.SelectedIndex].Value);
		}
		decimal ddetail = 0m;
		decimal dcost = 0m;
		decimal dinner = 0m;
		decimal dwho = 0m;
		decimal dwho2 = 0m;
		decimal dwho3 = 0m;
		int ivalid = 0;
		bool bstock = false;
		string text2 = "";
		string struserdef = "";
		string struserdef2 = "";
		string struserdef3 = "";
		string struserdef4 = "";
		string struserdef5 = "";
		string struserdef6 = "";
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			string text3 = "";
			string text4 = "";
			string strattr = "";
			string strspec = "";
			string strbrand = "";
			string strunit = "";
			ddetail = 0m;
			dcost = 0m;
			dinner = 0m;
			dwho = 0m;
			dwho2 = 0m;
			dwho3 = 0m;
			string strprot = "";
			string strbarcode = "";
			int icostmode = 2;
			string strforproduct = "";
			string strstock = "";
			string strprovider = "";
			ivalid = 0;
			bstock = false;
			string strremark = "";
			if (this.cbInputClass.Checked)
			{
				string text5 = "";
				if (this.ddlClass.SelectedItem.Text != "")
				{
					text5 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddlClass.SelectedItem.Text].ToString());
				}
				if (!text5.Trim().Equals(""))
				{
					igoodsclassid = dALGoods.CheckGoodsClass(text5);
				}
			}
			if (this.ddl1.SelectedItem.Text != "")
			{
				text3 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl1.SelectedItem.Text].ToString());
			}
			if (this.cbsys.Checked)
			{
				text4 = "";
			}
			else if (this.ddl2.SelectedItem.Text != "")
			{
				text4 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl2.SelectedItem.Text].ToString());
			}
			if (this.ddl3.SelectedItem.Text != "")
			{
				strattr = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl3.SelectedItem.Text].ToString());
			}
			if (this.ddl4.SelectedItem.Text != "")
			{
				strspec = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl4.SelectedItem.Text].ToString());
			}
			if (this.ddl5.SelectedItem.Text != "")
			{
				strbrand = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl5.SelectedItem.Text].ToString());
			}
			if (this.ddl6.SelectedItem.Text != "")
			{
				strunit = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl6.SelectedItem.Text].ToString());
			}
			if (this.ddl7.SelectedItem.Text != "")
			{
				decimal.TryParse(dataTable.Rows[i][this.ddl7.SelectedItem.Text].ToString(), out ddetail);
			}
			if (this.ddl8.SelectedItem.Text != "")
			{
				decimal.TryParse(dataTable.Rows[i][this.ddl8.SelectedItem.Text].ToString(), out dcost);
			}
			if (this.ddl9.SelectedItem.Text != "")
			{
				decimal.TryParse(dataTable.Rows[i][this.ddl9.SelectedItem.Text].ToString(), out dinner);
			}
			if (this.ddl10.SelectedItem.Text != "")
			{
				decimal.TryParse(dataTable.Rows[i][this.ddl10.SelectedItem.Text].ToString(), out dwho);
			}
			if (this.ddl11.SelectedItem.Text != "")
			{
				decimal.TryParse(dataTable.Rows[i][this.ddl11.SelectedItem.Text].ToString(), out dwho2);
			}
			if (this.ddl12.SelectedItem.Text != "")
			{
				decimal.TryParse(dataTable.Rows[i][this.ddl12.SelectedItem.Text].ToString(), out dwho3);
			}
			if (this.ddl13.SelectedItem.Text != "")
			{
				strprot = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl13.SelectedItem.Text].ToString());
			}
			if (this.ddl14.SelectedItem.Text != "")
			{
				strbarcode = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl14.SelectedItem.Text].ToString());
			}
			if (this.ddl15.SelectedItem.Text != "")
			{
				if (dataTable.Rows[i][this.ddl15.SelectedItem.Text].ToString() == "先进先出法")
				{
					icostmode = 1;
				}
				else
				{
					icostmode = 2;
				}
			}
			if (this.ddl16.SelectedItem.Text != "")
			{
				strforproduct = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl16.SelectedItem.Text].ToString());
			}
			if (this.ddl17.SelectedItem.Text != "")
			{
				strstock = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl17.SelectedItem.Text].ToString());
			}
			if (this.ddl18.SelectedItem.Text != "")
			{
				strprovider = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl18.SelectedItem.Text].ToString());
			}
			if (this.ddl19.SelectedItem.Text != "")
			{
				int.TryParse(dataTable.Rows[i][this.ddl19.SelectedItem.Text].ToString(), out ivalid);
			}
			if (this.ddl20.SelectedItem.Text != "")
			{
				bool.TryParse(dataTable.Rows[i][this.ddl20.SelectedItem.Text].ToString(), out bstock);
			}
			if (this.ddl21.SelectedItem.Text != "")
			{
				strremark = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl21.SelectedItem.Text].ToString());
			}
			if (this.ddl22.SelectedItem.Text != "")
			{
				struserdef = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl22.SelectedItem.Text].ToString());
			}
			if (this.ddl23.SelectedItem.Text != "")
			{
				struserdef2 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl23.SelectedItem.Text].ToString());
			}
			if (this.ddl24.SelectedItem.Text != "")
			{
				struserdef3 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl24.SelectedItem.Text].ToString());
			}
			if (this.ddl25.SelectedItem.Text != "")
			{
				struserdef4 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl25.SelectedItem.Text].ToString());
			}
			if (this.ddl26.SelectedItem.Text != "")
			{
				struserdef5 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl26.SelectedItem.Text].ToString());
			}
			if (this.ddl27.SelectedItem.Text != "")
			{
				struserdef6 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl27.SelectedItem.Text].ToString());
			}
			if (text3 == "" || text3 == null)
			{
				num2++;
			}
			else
			{
				int num3 = dALGoods.InputGoods(ideptid, igoodsclassid, text3, text4, strattr, strspec, strbrand, strunit, ddetail, dcost, dinner, dwho, dwho2, dwho3, strprot, strbarcode, icostmode, strforproduct, strstock, strprovider, ivalid, bstock, strremark, struserdef, struserdef2, struserdef3, struserdef4, struserdef5, struserdef6, out text2);
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
						text3,
						"</td><td>",
						text2,
						"</tr>"
					});
					num2++;
				}
			}
		}
		if (num2 == 0)
		{
			this.SysInfo("window.alert(\"导入完成！成功导入" + num.ToString() + "条记录\");parent.CloseDialog('1');");
		}
		else if (num == 0)
		{
			this.SysInfo("window.alert(\"导入全部失败！产品资料已存在，请设置产品编号系统默认重新导入\");");
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
			text = "<html><meta http-equiv=\"content-type\"content=\"text/html; charset=UTF-8\"/><style type=\"text/css\">td{padding-left:10px;padding-right:10px;}</style><body><table><tr><td>产品编号</td><td>产品名称</td><td>失败原因</td></tr>" + text + "</table></body></html>";
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
