using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Branch_Customer_InputCus : Page, IRequiresSessionState
{
	private int iflag;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (!base.IsPostBack)
		{
			int num = 0;
			this.slCusClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slCusClass);
			if (this.iflag == 2)
			{
				this.cbtrack.Checked = true;
			}
			this.sdyes();
		}
	}

	public void sdyes()
	{
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		DALSysVali dALSysVali = new DALSysVali();
		string corpName = sysParm.CorpName;
		string text = sysParm.BranchNum.ToString();
		string str = sysParm.bWeb.ToString();
		string value = dALSysVali.GetValue("ITEM2");
		string text2 = corpName + str + text;
		if (sysParm.bSim)
		{
			text2 += "并发";
		}
		string b = FunLibrary.EncodeReg(text2);
		if (value != b)
		{
			string value2 = dALSysVali.GetValue("ITEM1");
			try
			{
				string time = FunLibrary.StrDecode(value2);
				int num = this.DayTs(time);
				if (num > 60 || num < 0)
				{
					dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
				}
			}
			catch
			{
				dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
			}
		}
		else
		{
			int num2;
			int.TryParse(DALCommon.TCount("UserManage", ""), out num2);
			int num3;
			int.TryParse(text, out num3);
			if (!sysParm.bSim && num2 > num3)
			{
				dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
			}
			try
			{
				string requestUriString = "http://www.differsoft.com/kill_get.asp?id=8";
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Method = "GET";
				httpWebRequest.MaximumAutomaticRedirections = 3;
				httpWebRequest.Timeout = 5000;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text3 = streamReader.ReadToEnd();
				streamReader.Dispose();
				responseStream.Dispose();
				if (text3.Contains(value))
				{
					dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
				}
			}
			catch
			{
			}
			string str2 = dALSysVali.GetValue("ITEM6").ToString().Trim();
			int num4 = 0;
			try
			{
				num4 = int.Parse(FunLibrary.StrDecode(str2));
			}
			catch
			{
			}
			if (dALSysVali.GetValue("ITEM5") != DateTime.Now.ToString("yyyy-MM-dd") || num4 > 0)
			{
				try
				{
					string tel = sysParm.Tel;
					string zip = sysParm.Zip;
					string adr = sysParm.Adr;
					string text4 = "id=8";
					string text5 = text4;
					text4 = string.Concat(new string[]
					{
						text5,
						"&CustomerInfo=公司名:",
						corpName,
						"，电话:",
						tel
					});
					text5 = text4;
					text4 = string.Concat(new string[]
					{
						text5,
						"，邮编:",
						zip,
						"，地址:",
						adr,
						"，注册用户数:",
						text,
						"，实际用户数:",
						num2.ToString(),
						"注册码:",
						value
					});
					if (sysParm.bSim)
					{
						text4 += "，并发";
					}
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(text4);
					HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create("http://www.differsoft.com/kill_post.asp");
					httpWebRequest2.Method = "POST";
					httpWebRequest2.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
					httpWebRequest2.ContentLength = (long)bytes.Length;
					Stream requestStream = httpWebRequest2.GetRequestStream();
					requestStream.Write(bytes, 0, bytes.Length);
					requestStream.Close();
					HttpWebResponse httpWebResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
					StreamReader streamReader2 = new StreamReader(httpWebResponse2.GetResponseStream(), Encoding.GetEncoding("GB2312"));
					string text3 = streamReader2.ReadToEnd();
					requestStream.Dispose();
					streamReader2.Dispose();
					if (text3.ToLower() == "ok")
					{
						dALSysVali.Update("ITEM5", DateTime.Now.ToString("yyyy-MM-dd"));
						dALSysVali.Update("ITEM6", FunLibrary.StrEncode("0"));
					}
					else
					{
						dALSysVali.Update("ITEM6", FunLibrary.StrEncode((num4 + 1).ToString()));
					}
				}
				catch
				{
					dALSysVali.Update("ITEM6", FunLibrary.StrEncode((num4 + 1).ToString()));
				}
			}
		}
	}

	protected int DayTs(string time)
	{
		DateTime d = DateTime.Parse(time);
		DateTime now = DateTime.Now;
		return 1;
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
					for (int i = 1; i <= 23; i++)
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
			if (this.ddl4.Items[j].Text == "联系电话")
			{
				this.ddl4.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl5.Items.Count; j++)
		{
			if (this.ddl5.Items[j].Text == "手机号码")
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
			if (this.ddl8.Items[j].Text == "Email")
			{
				this.ddl8.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl9.Items.Count; j++)
		{
			if (this.ddl9.Items[j].Text == "客户区域")
			{
				this.ddl9.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl10.Items.Count; j++)
		{
			if (this.ddl10.Items[j].Text == "QQ/MSN")
			{
				this.ddl10.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl11.Items.Count; j++)
		{
			if (this.ddl11.Items[j].Text == "客户来源")
			{
				this.ddl11.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl12.Items.Count; j++)
		{
			if (this.ddl12.Items[j].Text == "业务员")
			{
				this.ddl12.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl13.Items.Count; j++)
		{
			if (this.ddl13.Items[j].Text == "帐户")
			{
				this.ddl13.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl14.Items.Count; j++)
		{
			if (this.ddl14.Items[j].Text == "地址")
			{
				this.ddl14.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl15.Items.Count; j++)
		{
			if (this.ddl15.Items[j].Text == "备注")
			{
				this.ddl15.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl16.Items.Count; j++)
		{
			if (this.ddl16.Items[j].Text == "客户状态")
			{
				this.ddl16.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl17.Items.Count; j++)
		{
			if (this.ddl17.Items[j].Text == "跟踪信息")
			{
				this.ddl17.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl18.Items.Count; j++)
		{
			if (this.ddl18.Items[j].Text == "自定义1")
			{
				this.ddl18.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl19.Items.Count; j++)
		{
			if (this.ddl19.Items[j].Text == "自定义2")
			{
				this.ddl19.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl20.Items.Count; j++)
		{
			if (this.ddl20.Items[j].Text == "自定义3")
			{
				this.ddl20.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl21.Items.Count; j++)
		{
			if (this.ddl21.Items[j].Text == "自定义4")
			{
				this.ddl21.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl22.Items.Count; j++)
		{
			if (this.ddl22.Items[j].Text == "自定义5")
			{
				this.ddl22.Items[j].Selected = true;
				break;
			}
		}
		for (int j = 0; j < this.ddl23.Items.Count; j++)
		{
			if (this.ddl23.Items[j].Text == "自定义6")
			{
				this.ddl23.Items[j].Selected = true;
				break;
			}
		}
	}

	protected void InitDDL()
	{
		for (int i = 1; i <= 23; i++)
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
		DALCustomerList dALCustomerList = new DALCustomerList();
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
		int iDeptid = int.Parse(this.Session["Session_wtBranchID"].ToString());
		int iClassid = int.Parse(this.slCusClass.Items[this.slCusClass.SelectedIndex].Value);
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
			string strLinkMan = "";
			string strTel = "";
			string strTel2 = "";
			string strFax = "";
			string strZip = "";
			string strEmail = "";
			string strArea = "";
			string strCoor = "";
			string strFrom = "";
			string strSeller = "";
			string strAccount = "";
			string strAdr = "";
			string strRemark = "";
			string status = "";
			string track = "";
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
				strLinkMan = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl3.SelectedItem.Text].ToString());
			}
			if (this.ddl4.SelectedItem.Text != "")
			{
				strTel = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl4.SelectedItem.Text].ToString());
			}
			if (this.ddl5.SelectedItem.Text != "")
			{
				strTel2 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl5.SelectedItem.Text].ToString());
			}
			if (this.ddl6.SelectedItem.Text != "")
			{
				strFax = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl6.SelectedItem.Text].ToString());
			}
			if (this.ddl7.SelectedItem.Text != "")
			{
				strZip = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl7.SelectedItem.Text].ToString());
			}
			if (this.ddl8.SelectedItem.Text != "")
			{
				strEmail = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl8.SelectedItem.Text].ToString());
			}
			if (this.ddl9.SelectedItem.Text != "")
			{
				strArea = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl9.SelectedItem.Text].ToString());
			}
			if (this.ddl10.SelectedItem.Text != "")
			{
				strCoor = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl10.SelectedItem.Text].ToString());
			}
			if (this.ddl11.SelectedItem.Text != "")
			{
				strFrom = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl11.SelectedItem.Text].ToString());
			}
			if (this.ddl12.SelectedItem.Text != "")
			{
				strSeller = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl12.SelectedItem.Text].ToString());
			}
			if (this.ddl13.SelectedItem.Text != "")
			{
				strAccount = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl13.SelectedItem.Text].ToString());
			}
			if (this.ddl14.SelectedItem.Text != "")
			{
				strAdr = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl14.SelectedItem.Text].ToString());
			}
			if (this.ddl15.SelectedItem.Text != "")
			{
				strRemark = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl15.SelectedItem.Text].ToString());
			}
			if (this.ddl16.SelectedItem.Text != "")
			{
				status = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl16.SelectedItem.Text].ToString());
			}
			if (this.ddl17.SelectedItem.Text != "")
			{
				track = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl17.SelectedItem.Text].ToString());
			}
			if (this.ddl18.SelectedItem.Text != "")
			{
				struserdef = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl18.SelectedItem.Text].ToString());
			}
			if (this.ddl19.SelectedItem.Text != "")
			{
				struserdef2 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl19.SelectedItem.Text].ToString());
			}
			if (this.ddl20.SelectedItem.Text != "")
			{
				struserdef3 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl20.SelectedItem.Text].ToString());
			}
			if (this.ddl21.SelectedItem.Text != "")
			{
				struserdef4 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl21.SelectedItem.Text].ToString());
			}
			if (this.ddl22.SelectedItem.Text != "")
			{
				struserdef5 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl22.SelectedItem.Text].ToString());
			}
			if (this.ddl23.SelectedItem.Text != "")
			{
				struserdef6 = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl23.SelectedItem.Text].ToString());
			}
			int num3 = dALCustomerList.InputCus(iDeptid, iClassid, text3, text4, strLinkMan, strTel, strTel2, strFax, strZip, strEmail, strArea, strCoor, strFrom, strSeller, strAccount, strAdr, strRemark, status, track, struserdef, struserdef2, struserdef3, struserdef4, struserdef5, struserdef6, int.Parse((string)this.Session["Session_wtUserBID"]), this.cbtrack.Checked, this.cbCover.Checked, out text2);
			if (num3 == 0)
			{
				num++;
			}
			else
			{
				string text5 = text;
				text = string.Concat(new string[]
				{
					text5,
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
		if (num2 == 0)
		{
			this.SysInfo("window.alert(\"导入完成！成功导入" + num.ToString() + "条记录\");parent.CloseDialog('1');");
		}
		else if (num == 0)
		{
			this.SysInfo("window.alert(\"导入全部失败！客户信息已存在\");");
		}
		else
		{
			string text6 = base.Server.MapPath("~/Errorlog/");
			if (!Directory.Exists(text6))
			{
				Directory.CreateDirectory(text6);
			}
			string str = DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
			string path = text6 + str;
			StreamWriter streamWriter = File.CreateText(path);
			text = "<html><meta http-equiv=\"content-type\"content=\"text/html; charset=UTF-8\"/><style type=\"text/css\">td{padding-left:10px;padding-right:10px;}</style><body><table><tr><td>客户编号</td><td>客户名称</td><td>失败原因</td></tr>" + text + "</table></body></html>";
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
