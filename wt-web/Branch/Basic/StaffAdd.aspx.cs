using System;
using System.Data;
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

public partial class Branch_Basic_StaffAdd : Page, IRequiresSessionState
{  
    private DataTable GridViewSource
    {
        get
        {
            if (this.ViewState["List"] == null)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dataTable.Columns.Add(new DataColumn("Deduct", typeof(decimal)));
                this.ViewState["List"] = dataTable;
            }
            return (DataTable)this.ViewState["List"];
        }
        set
        {
            this.ViewState["List"] = value;
        }
    }

  

    public Branch_Basic_StaffAdd()
    {
    }

    protected void BindDeduct()
    {
        DataTable gridViewSource = this.GridViewSource;
        gridViewSource.DefaultView.Sort = "Amount";
        DataTable table = gridViewSource.DefaultView.ToTable();
        for (int i = 0; i < table.Rows.Count; i++)
        {
            if (!(decimal.Parse(table.Rows[i]["Amount"].ToString().Trim()) == new decimal(0)))
            {
                table.Rows[i]["ID"] = i;
            }
            else
            {
                table.Rows[i]["ID"] = table.Rows.Count;
            }
        }
        table.DefaultView.Sort = "ID";
        this.GridViewSource = table.DefaultView.ToTable();
        this.GridView1.DataSource = this.GridViewSource;
        this.GridView1.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int num;
        int num1;
        string str;
        int num2;
        StaffListInfo staffListInfo = new StaffListInfo()
        {
            _Name = FunLibrary.ChkInput(this.tbName.Text)
        };
        if (!this.cbsys.Checked)
        {
            staffListInfo.JobNO = FunLibrary.ChkInput(this.tbJobNO.Text);
        }
        else
        {
            staffListInfo.JobNO = DALCommon.CreateID(1, 1);
        }
        staffListInfo.DeptID = new int?(int.Parse((string)this.Session["Session_wtBranchID"]));
        staffListInfo.Sex = this.ddlSex.SelectedValue;
        staffListInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
        staffListInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
        staffListInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
        staffListInfo.NativePlace = FunLibrary.ChkInput(this.tbNativePlace.Text);
        staffListInfo.CardID = FunLibrary.ChkInput(this.tbCardNO.Text);
        staffListInfo.BirthDate = FunLibrary.ChkInput(this.tbBirthDay.Text);
        staffListInfo.Academic = this.ddlStudy.SelectedValue;
        staffListInfo.School = FunLibrary.ChkInput(this.tbSchool.Text);
        staffListInfo.Specialty = FunLibrary.ChkInput(this.tbSpeci.Text);
        staffListInfo.JobDate = FunLibrary.ChkInput(this.tbJobTime.Text);
        staffListInfo.BillDeduct = FunLibrary.ChkInput(this.tbBillDe.Text);
        staffListInfo.SellDeduct = FunLibrary.ChkInput(this.tbSellDe.Text);
        DataTable gridViewSource = this.GridViewSource;
        decimal num3 = new decimal(1);
        if (int.Parse(this.ddlType.SelectedValue) > 2)
        {
            num3 = new decimal(1, 0, 0, false, 2);
        }
        if (gridViewSource.Rows.Count > 0)
        {
            staffListInfo.ftype = int.Parse(this.ddlType.SelectedValue);
            string empty = string.Empty;
            for (int i = 0; i < gridViewSource.Rows.Count; i++)
            {
                decimal num4 = new decimal(0);
                decimal.TryParse(gridViewSource.Rows[i]["deduct"].ToString().Trim(), out num4);
                string str1 = empty;
                string[] strArrays = new string[] { str1, gridViewSource.Rows[i]["Amount"].ToString().Trim(), ",", null, null };
                strArrays[3] = (num4 * num3).ToString();
                strArrays[4] = "|";
                empty = string.Concat(strArrays);
            }
            char[] chrArray = new char[] { '|' };
            staffListInfo.ProfitFormula = empty.Trim(chrArray);
        }
        string billDeduct = staffListInfo.BillDeduct;
        billDeduct = billDeduct.Replace("{业务额}", "1");
        billDeduct = billDeduct.Replace("{毛利}", "1");
        billDeduct = billDeduct.Replace("{人工费}", "1");
        billDeduct = billDeduct.Replace("{材料费}", "1");
        billDeduct = billDeduct.Replace("{附加费}", "1");
        billDeduct = billDeduct.Replace("{工分}", "1");
        billDeduct = billDeduct.Replace("{材料成本}", "1");
        billDeduct = billDeduct.Replace("{保外单}", "1");
        billDeduct = billDeduct.Replace("{保内单}", "0");
        billDeduct = billDeduct.Replace("{工时}", "1");
        billDeduct = billDeduct.Replace("{厂商结算}", "1");
        billDeduct = billDeduct.Replace("{协作人数}", "1");
        billDeduct = billDeduct.Replace("{项目提成}", "1");
        if (staffListInfo.BillDeduct != "")
        {
            if (DALCommon.checkformula(billDeduct) == -1)
            {
                this.SysInfo("ChkTab('2');window.alert('操作失败！维修提成公式不合法，请修改！');");
                return;
            }
        }
        billDeduct = staffListInfo.SellDeduct;
        billDeduct = billDeduct.Replace("{业务额}", "1");
        billDeduct = billDeduct.Replace("{毛利}", "1");
        if (staffListInfo.SellDeduct != "")
        {
            if (DALCommon.checkformula(billDeduct) == -1)
            {
                this.SysInfo("ChkTab('3');window.alert('操作失败！销售提成公式不合法，请修改！');");
                return;
            }
        }
        int.TryParse(this.ddlStatus.SelectedValue, out num);
        staffListInfo.Status = new int?(num);
        int.TryParse(this.ddlQus.SelectedValue, out num1);
        staffListInfo.Qid = new int?(num1);
        staffListInfo.bTechnician = this.cbTechnician.Checked;
        staffListInfo.bSeller = this.cbSeller.Checked;
        staffListInfo.bStockMan = this.cbStockMan.Checked;
        staffListInfo.bAccountant = this.cbAccountant.Checked;
        staffListInfo.bDestClerk = this.cbDestClerk.Checked;
        staffListInfo.bAllot = this.cbAllot.Checked;
        staffListInfo.bManage = false;
        decimal num5 = new decimal(0);
        decimal.TryParse(this.tbSalary.Text, out num5);
        staffListInfo.Salary = num5;
        staffListInfo.Account = FunLibrary.ChkInput(this.tbAccount.Text);
        decimal num6 = new decimal(0);
        decimal.TryParse(this.tbAllowance.Text, out num6);
        staffListInfo.Allowance = num6;
        staffListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
        DALStaffList dALStaffList = new DALStaffList();
        int num7 = dALStaffList.Add(staffListInfo, out str, out num2);
        if (num7 == 0)
        {
            if (!this.cbClose.Checked)
            {
                this.SysInfo("ChkTab('1');$('tbName').value='';$('tbName').select();");
                this.ClearText();
            }
            else
            {
                this.SysInfo("parent.CloseDialog('1');");
            }
        }
        else if (num7 != -1)
        {
            this.SysInfo("window.alert('系统错误！请查看错误日志');");
        }
        else
        {
            this.SysInfo(string.Concat("window.alert('", str, "');"));
        }
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        DataTable gridViewSource = this.GridViewSource;
        if (!(this.hfRecID.Value == "-1"))
        {
            int num = 0;
            int.TryParse(this.hfRecID.Value, out num);
            DataRow[] dataRowArray = gridViewSource.Select(string.Concat("ID=", num));
            for (int i = 0; i < (int)dataRowArray.Length; i++)
            {
                decimal num1 = new decimal(0);
                decimal.TryParse(dataRowArray[i]["Amount"].ToString(), out num1);
                if (num1 > new decimal(0))
                {
                    gridViewSource.Rows.Remove(dataRowArray[i]);
                }
            }
            this.GridViewSource = gridViewSource;
            this.ClearTextDe();
            this.BindDeduct();
        }
    }

    protected void btnMod_Click(object sender, EventArgs e)
    {
        DataTable gridViewSource = this.GridViewSource;
        if (!(this.hfRecID.Value == "-1"))
        {
            int num = 0;
            int.TryParse(this.hfRecID.Value, out num);
            DataRow[] dataRowArray = gridViewSource.Select(string.Concat("ID=", num));
            decimal num1 = new decimal(0);
            decimal.TryParse(this.tbAmount.Text, out num1);
            object[] objArray = new object[] { "Amount=", num1, " and ID<>", num };
            if ((int)gridViewSource.Select(string.Concat(objArray)).Length <= 0)
            {
                dataRowArray[0]["Amount"] = num1;
                dataRowArray[0]["Deduct"] = decimal.Parse(this.tbDeduct.Text);
                this.GridViewSource = gridViewSource;
                this.hfRecID.Value = "-1";
                this.ClearTextDe();
                this.BindDeduct();
            }
            else
            {
                this.SysInfo3("alert('修改失败！已存在相同的利润空间');");
            }
        }
    }

    protected void btnRef_Click(object sender, EventArgs e)
    {
        OtherFunction.BindArea(this.ddlArea);
        if (this.hfArea.Value != string.Empty)
        {
            this.ddlArea.ClearSelection();
            this.ddlArea.Items.FindByText(this.hfArea.Value).Selected = true;
            this.tbArea.Text = this.ddlArea.SelectedItem.Text;
        }
    }

    protected void btnRefQu_Click(object sender, EventArgs e)
    {
        OtherFunction.BindQuarters(this.ddlQus);
        if (this.hfQut.Value != string.Empty)
        {
            this.ddlQus.ClearSelection();
            this.ddlQus.Items.FindByText(this.hfQut.Value).Selected = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        decimal num = new decimal(0);
        decimal.TryParse(this.tbAmount.Text, out num);
        DataTable gridViewSource = this.GridViewSource;
        if ((int)gridViewSource.Select(string.Concat("Amount=", num)).Length <= 0)
        {
            DataRow dataRow = gridViewSource.NewRow();
            dataRow["Amount"] = num;
            dataRow["Deduct"] = decimal.Parse(this.tbDeduct.Text);
            if (gridViewSource.Rows.Count == 0)
            {
                DataRow dataRow1 = gridViewSource.NewRow();
                dataRow1["Amount"] = 0;
                dataRow1["Deduct"] = decimal.Parse(this.tbDeduct.Text);
                gridViewSource.Rows.Add(dataRow1);
            }
            gridViewSource.Rows.Add(dataRow);
            this.GridViewSource = gridViewSource;
            this.hfRecID.Value = "-1";
            this.ClearTextDe();
            this.BindDeduct();
        }
        else
        {
            this.SysInfo3("alert('添加失败！利润区间已存在');");
        }
    }

    protected void ClearText()
    {
        TextBox textBox = this.tbAdr;
        TextBox textBox1 = this.tbBillDe;
        TextBox textBox2 = this.tbBirthDay;
        TextBox textBox3 = this.tbCardNO;
        TextBox textBox4 = this.tbJobNO;
        TextBox textBox5 = this.tbJobTime;
        TextBox textBox6 = this.tbName;
        TextBox textBox7 = this.tbNativePlace;
        TextBox textBox8 = this.tbRemark;
        TextBox textBox9 = this.tbSchool;
        TextBox textBox10 = this.tbSellDe;
        TextBox textBox11 = this.tbSpeci;
        TextBox textBox12 = this.tbTel;
        string empty = string.Empty;
        string str = empty;
        textBox12.Text = empty;
        string str1 = str;
        str = str1;
        textBox11.Text = str1;
        string str2 = str;
        str = str2;
        textBox10.Text = str2;
        string str3 = str;
        str = str3;
        textBox9.Text = str3;
        string str4 = str;
        str = str4;
        textBox8.Text = str4;
        string str5 = str;
        str = str5;
        textBox7.Text = str5;
        string str6 = str;
        str = str6;
        textBox6.Text = str6;
        string str7 = str;
        str = str7;
        textBox5.Text = str7;
        string str8 = str;
        str = str8;
        textBox4.Text = str8;
        string str9 = str;
        str = str9;
        textBox3.Text = str9;
        string str10 = str;
        str = str10;
        textBox2.Text = str10;
        string str11 = str;
        str = str11;
        textBox1.Text = str11;
        textBox.Text = str;
        this.ddlQus.ClearSelection();
        this.ddlQus.Items.FindByValue("-1").Selected = true;
        this.ddlSex.ClearSelection();
        this.ddlSex.Items.FindByText("").Selected = true;
        this.ddlStatus.ClearSelection();
        this.ddlStatus.Items.FindByValue("0").Selected = true;
        this.ddlStudy.ClearSelection();
        this.ddlStudy.Items.FindByText("").Selected = true;
    }

    protected void ClearTextDe()
    {
        this.tbAmount.Text = "";
        this.tbDeduct.Text = "";
    }

    protected void ddlSellFormula_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(this.ddlSellFormula.SelectedValue != "-1"))
        {
            this.tbSellDe.Text = "";
        }
        else
        {
            DataSet dataList = DALCommon.GetDataList("StaffList", "SellDeduct", string.Concat("ID=", this.ddlSellFormula.SelectedValue));
            this.tbSellDe.Text = dataList.Tables[0].Rows[0][0].ToString().Trim();
        }
    }

    protected void ddlSerFormula_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(this.ddlSerFormula.SelectedValue != "-1"))
        {
            this.tbBillDe.Text = "";
        }
        else
        {
            DataSet dataList = DALCommon.GetDataList("StaffList", "BillDeduct", string.Concat("ID=", this.ddlSerFormula.SelectedValue));
            this.tbBillDe.Text = dataList.Tables[0].Rows[0][0].ToString().Trim();
        }
    }

    protected void ddlStaffDeduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClearTextDe();
        DataTable gridViewSource = this.GridViewSource;
        gridViewSource.Rows.Clear();
        if (this.ddlStaffDeduct.SelectedValue != "-1")
        {
            DataSet dataList = DALCommon.GetDataList("StaffList", "ProfitFormula,ftype", string.Concat("ID=", this.ddlStaffDeduct.SelectedValue));
            string str = dataList.Tables[0].Rows[0]["ftype"].ToString().Trim();
            string str1 = dataList.Tables[0].Rows[0]["ProfitFormula"].ToString().Trim();
            if ((str == "" ? false : str1 != ""))
            {
                this.ddlType.SelectedValue = str;
                char[] chrArray = new char[] { '|' };
                string[] strArrays = str1.Split(chrArray);
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    DataRow dataRow = gridViewSource.NewRow();
                    string str2 = strArrays[i];
                    chrArray = new char[] { ',' };
                    dataRow["amount"] = decimal.Parse(str2.Split(chrArray)[0]);
                    string str3 = strArrays[i];
                    chrArray = new char[] { ',' };
                    dataRow["deduct"] = decimal.Parse(str3.Split(chrArray)[1]);
                    gridViewSource.Rows.Add(dataRow);
                }
            }
        }
        this.GridViewSource = gridViewSource;
        this.BindDeduct();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["id"] = e.Row.Cells[0].Text;
            e.Row.Attributes.Add("onclick", string.Concat("ChkID('", e.Row.Cells[0].Text, "');"));
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            if (e.Row.Cells[1].Text == "0")
            {
                e.Row.Cells[1].Text = "超过后提成";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkBran();
        if (!base.IsPostBack)
        {
            int num = int.Parse((string)this.Session["Session_wtPurBID"]);
            if (num > 0)
            {
                if (!(new DALRight()).GetRight(num, "jc_r3"))
                {
                    this.btnAdd.Enabled = false;
                }
            }
            OtherFunction.BindQuarters(this.ddlQus);
            OtherFunction.BindArea(this.ddlArea);
            OtherFunction.BindStaff(this.ddlSellFormula, string.Concat("DeptID=", (string)this.Session["Session_wtBranchID"]));
            OtherFunction.BindStaff(this.ddlSerFormula, string.Concat("DeptID=", (string)this.Session["Session_wtBranchID"]));
            OtherFunction.BindStaff(this.ddlStaffDeduct, string.Concat("DeptID=", (string)this.Session["Session_wtBranchID"]));
        }
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }

    protected void SysInfo3(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.UpdatePanel4.GetType(), "SysInfo", str, true);
    }
}