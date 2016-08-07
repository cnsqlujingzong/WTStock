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

public partial class Branch_Basic_InputStaff : Page, IRequiresSessionState
{
    private int iflag;
    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkBran();
        int.TryParse(base.Request["iflag"], out this.iflag);
        if (!base.IsPostBack)
        {
            int num = int.Parse((string)this.Session["Session_wtPurBID"]);
            if (num > 0)
            {
                DALRight dALRight = new DALRight();
                if (!dALRight.GetRight(num, "jc_r3"))
                {
                    this.btnAdd.Enabled = false;
                }
            }
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
                    for (int i = 1; i <= 25; i++)
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
            if (this.ddl1.Items[j].Text == "员工姓名")
            {
                this.ddl1.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl2.Items.Count; j++)
        {
            if (this.ddl2.Items[j].Text == "员工编号")
            {
                this.ddl2.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl3.Items.Count; j++)
        {
            if (this.ddl3.Items[j].Text == "性别")
            {
                this.ddl3.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl4.Items.Count; j++)
        {
            if (this.ddl4.Items[j].Text == "状态")
            {
                this.ddl4.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl5.Items.Count; j++)
        {
            if (this.ddl5.Items[j].Text == "电话")
            {
                this.ddl5.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl6.Items.Count; j++)
        {
            if (this.ddl6.Items[j].Text == "岗位")
            {
                this.ddl6.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl7.Items.Count; j++)
        {
            if (this.ddl7.Items[j].Text == "出生年月")
            {
                this.ddl7.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl8.Items.Count; j++)
        {
            if (this.ddl8.Items[j].Text == "籍贯")
            {
                this.ddl8.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl9.Items.Count; j++)
        {
            if (this.ddl9.Items[j].Text == "身份证号")
            {
                this.ddl9.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl10.Items.Count; j++)
        {
            if (this.ddl10.Items[j].Text == "学历")
            {
                this.ddl10.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl11.Items.Count; j++)
        {
            if (this.ddl11.Items[j].Text == "毕业院校")
            {
                this.ddl11.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl12.Items.Count; j++)
        {
            if (this.ddl12.Items[j].Text == "专业")
            {
                this.ddl12.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl13.Items.Count; j++)
        {
            if (this.ddl13.Items[j].Text == "入职时间")
            {
                this.ddl13.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl14.Items.Count; j++)
        {
            if (this.ddl14.Items[j].Text == "区域")
            {
                this.ddl14.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl15.Items.Count; j++)
        {
            if (this.ddl15.Items[j].Text == "底薪")
            {
                this.ddl15.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl16.Items.Count; j++)
        {
            if (this.ddl16.Items[j].Text == "津贴")
            {
                this.ddl16.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl17.Items.Count; j++)
        {
            if (this.ddl17.Items[j].Text == "工资账号")
            {
                this.ddl17.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl18.Items.Count; j++)
        {
            if (this.ddl18.Items[j].Text == "地址")
            {
                this.ddl18.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl19.Items.Count; j++)
        {
            if (this.ddl19.Items[j].Text == "备注")
            {
                this.ddl19.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl20.Items.Count; j++)
        {
            if (this.ddl20.Items[j].Text == "受理员")
            {
                this.ddl20.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl21.Items.Count; j++)
        {
            if (this.ddl21.Items[j].Text == "派工人员")
            {
                this.ddl21.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl22.Items.Count; j++)
        {
            if (this.ddl22.Items[j].Text == "技术员")
            {
                this.ddl22.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl23.Items.Count; j++)
        {
            if (this.ddl23.Items[j].Text == "业务员")
            {
                this.ddl23.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl24.Items.Count; j++)
        {
            if (this.ddl24.Items[j].Text == "财务人员")
            {
                this.ddl24.Items[j].Selected = true;
                break;
            }
        }
        for (int j = 0; j < this.ddl25.Items.Count; j++)
        {
            if (this.ddl25.Items[j].Text == "仓库管理员")
            {
                this.ddl25.Items[j].Selected = true;
                break;
            }
        }
    }

    protected void InitDDL()
    {
        for (int i = 1; i <= 25; i++)
        {
            string id = "ddl" + i;
            DropDownList dropDownList = this.FindControl(id) as DropDownList;
            dropDownList.Items.Clear();
            dropDownList.Items.Add(new ListItem("", ""));
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DALStaffList dALStaffList = new DALStaffList();
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
            string strjobno = "";
            string strsex = "";
            string strstatus = "";
            string strtel = "";
            string strquarters = "";
            string strbirthdate = "";
            string strnativeplace = "";
            string strcardid = "";
            string stracademic = "";
            string strschool = "";
            string strspecialty = "";
            string strjobdate = "";
            string strarea = "";
            decimal strsalary = 0m;
            decimal strallowance = 0m;
            string straccount = "";
            string stradr = "";
            string strremark = "";
            string strbdestclerk = "";
            string strballot = "";
            string strbtechnician = "";
            string strbseller = "";
            string strbaccounttant = "";
            string strbstockman = "";
            int depetid = int.Parse((string)this.Session["Session_wtBranchID"]);
            if (this.ddl1.SelectedItem.Text != "")
            {
                strname = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl1.SelectedItem.Text].ToString());
            }
            if (this.cbsys.Checked)
            {
                strjobno = "";
            }
            else if (this.ddl2.SelectedItem.Text != "")
            {
                strjobno = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl2.SelectedItem.Text].ToString());
            }
            if (this.ddl3.SelectedItem.Text != "")
            {
                strsex = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl3.SelectedItem.Text].ToString());
            }
            if (this.ddl4.SelectedItem.Text != "")
            {
                strstatus = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl4.SelectedItem.Text].ToString());
            }
            if (this.ddl5.SelectedItem.Text != "")
            {
                strtel = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl5.SelectedItem.Text].ToString());
            }
            if (this.ddl6.SelectedItem.Text != "")
            {
                strquarters = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl6.SelectedItem.Text].ToString());
            }
            if (this.ddl7.SelectedItem.Text != "")
            {
                strbirthdate = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl7.SelectedItem.Text].ToString());
            }
            if (this.ddl8.SelectedItem.Text != "")
            {
                strnativeplace = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl8.SelectedItem.Text].ToString());
            }
            if (this.ddl9.SelectedItem.Text != "")
            {
                strcardid = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl9.SelectedItem.Text].ToString());
            }
            if (this.ddl10.SelectedItem.Text != "")
            {
                stracademic = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl10.SelectedItem.Text].ToString());
            }
            if (this.ddl11.SelectedItem.Text != "")
            {
                strschool = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl11.SelectedItem.Text].ToString());
            }
            if (this.ddl12.SelectedItem.Text != "")
            {
                strspecialty = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl12.SelectedItem.Text].ToString());
            }
            if (this.ddl13.SelectedItem.Text != "")
            {
                strjobdate = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl13.SelectedItem.Text].ToString());
            }
            if (this.ddl14.SelectedItem.Text != "")
            {
                strarea = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl14.SelectedItem.Text].ToString());
            }
            if (this.ddl15.SelectedItem.Text != "")
            {
                decimal.TryParse(FunLibrary.ChkInput(dataTable.Rows[i][this.ddl15.SelectedItem.Text].ToString()), out strsalary);
            }
            if (this.ddl16.SelectedItem.Text != "")
            {
                decimal.TryParse(FunLibrary.ChkInput(dataTable.Rows[i][this.ddl16.SelectedItem.Text].ToString()), out strallowance);
            }
            if (this.ddl17.SelectedItem.Text != "")
            {
                straccount = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl17.SelectedItem.Text].ToString());
            }
            if (this.ddl18.SelectedItem.Text != "")
            {
                stradr = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl18.SelectedItem.Text].ToString());
            }
            if (this.ddl19.SelectedItem.Text != "")
            {
                strremark = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl19.SelectedItem.Text].ToString());
            }
            if (this.ddl20.SelectedItem.Text != "")
            {
                strbdestclerk = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl20.SelectedItem.Text].ToString());
            }
            if (this.ddl21.SelectedItem.Text != "")
            {
                strballot = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl21.SelectedItem.Text].ToString());
            }
            if (this.ddl22.SelectedItem.Text != "")
            {
                strbtechnician = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl22.SelectedItem.Text].ToString());
            }
            if (this.ddl23.SelectedItem.Text != "")
            {
                strbseller = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl23.SelectedItem.Text].ToString());
            }
            if (this.ddl24.SelectedItem.Text != "")
            {
                strbaccounttant = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl24.SelectedItem.Text].ToString());
            }
            if (this.ddl25.SelectedItem.Text != "")
            {
                strbstockman = FunLibrary.ChkInput(dataTable.Rows[i][this.ddl25.SelectedItem.Text].ToString());
            }
            string text;
            int num3 = dALStaffList.Add_Staff(strname, strjobno, strsex, strstatus, strtel, strquarters, strbirthdate, strnativeplace, strcardid, stracademic, strschool, strspecialty, strjobdate, strarea, strsalary, strallowance, straccount, stradr, strremark, strbdestclerk, strballot, strbtechnician, strbseller, strbaccounttant, strbstockman, depetid, out text);
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
            this.SysInfo("window.alert(\"导入全部失败！员工信息已存在\");");
        }
        else
        {
            this.SysInfo(string.Concat(new string[]
            {
"window.alert(\"导入完成！成功导入",
num.ToString(),
"条记录，失败",
num2.ToString(),
"条记录，失败原因：员工信息已存在\");parent.CloseDialog('1');"
            }));
        }
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
    }
}
