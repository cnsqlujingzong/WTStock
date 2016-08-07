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

public partial class Headquarters_Basic_StaffAdd : Page, IRequiresSessionState
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

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r6"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindQuarters(this.ddlQus);
			OtherFunction.BindArea(this.ddlArea);
			OtherFunction.BindStaff(this.ddlSellFormula, "DeptID=1");
			OtherFunction.BindStaff(this.ddlSerFormula, "DeptID=1");
			OtherFunction.BindStaff(this.ddlStaffDeduct, "DeptID=1");
			int num2 = 0;
			DataTable dataSource = DALCommon.GetList_HL(0, "StaffDept", "", 0, 0, "DeptID=1", " Array asc ", out num2).Tables[0];
			this.ddlStaffDept.DataSource = dataSource;
			this.ddlStaffDept.DataTextField = "_Name";
			this.ddlStaffDept.DataValueField = "ID";
			this.ddlStaffDept.DataBind();
			this.ddlStaffDept.Items.Insert(0, new ListItem("", "-1"));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		StaffListInfo staffListInfo = new StaffListInfo();
		staffListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		if (this.cbsys.Checked)
		{
			staffListInfo.JobNO = DALCommon.CreateID(1, 1);
		}
		else
		{
			staffListInfo.JobNO = FunLibrary.ChkInput(this.tbJobNO.Text);
		}
		staffListInfo.DeptID = new int?(1);
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
		staffListInfo.StaffDeptID = int.Parse(this.ddlStaffDept.SelectedValue);
		DataTable gridViewSource = this.GridViewSource;
		decimal d = 1m;
		if (int.Parse(this.ddlType.SelectedValue) > 2)
		{
			d = 0.01m;
		}
		if (gridViewSource.Rows.Count > 0)
		{
			staffListInfo.ftype = int.Parse(this.ddlType.SelectedValue);
			string text = string.Empty;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				decimal d2 = 0m;
				decimal.TryParse(gridViewSource.Rows[i]["deduct"].ToString().Trim(), out d2);
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					gridViewSource.Rows[i]["Amount"].ToString().Trim(),
					",",
					(d2 * d).ToString(),
					"|"
				});
			}
			staffListInfo.ProfitFormula = text.Trim(new char[]
			{
				'|'
			});
		}
		string text3 = staffListInfo.BillDeduct;
		text3 = text3.Replace("{业务额}", "1");
		text3 = text3.Replace("{毛利}", "1");
		text3 = text3.Replace("{人工费}", "1");
		text3 = text3.Replace("{材料费}", "1");
		text3 = text3.Replace("{附加费}", "1");
		text3 = text3.Replace("{工分}", "1");
		text3 = text3.Replace("{材料成本}", "1");
		text3 = text3.Replace("{保外单}", "1");
		text3 = text3.Replace("{保内单}", "0");
		text3 = text3.Replace("{工时}", "1");
		text3 = text3.Replace("{厂商结算}", "1");
		text3 = text3.Replace("{协作人数}", "1");
		text3 = text3.Replace("{项目提成}", "1");
		if (staffListInfo.BillDeduct != "")
		{
			int num = DALCommon.checkformula(text3);
			if (num == -1)
			{
				this.SysInfo("ChkTab('2');window.alert('操作失败！维修提成公式不合法，请修改！');");
				return;
			}
		}
		text3 = staffListInfo.SellDeduct;
		text3 = text3.Replace("{业务额}", "1");
		text3 = text3.Replace("{毛利}", "1");
		if (staffListInfo.SellDeduct != "")
		{
			int num = DALCommon.checkformula(text3);
			if (num == -1)
			{
				this.SysInfo("ChkTab('3');window.alert('操作失败！销售提成公式不合法，请修改！');");
				return;
			}
		}
		int value;
		int.TryParse(this.ddlStatus.SelectedValue, out value);
		staffListInfo.Status = new int?(value);
		int value2;
		int.TryParse(this.ddlQus.SelectedValue, out value2);
		staffListInfo.Qid = new int?(value2);
		staffListInfo.bTechnician = this.cbTechnician.Checked;
		staffListInfo.bSeller = this.cbSeller.Checked;
		staffListInfo.bStockMan = this.cbStockMan.Checked;
		staffListInfo.bAccountant = this.cbAccountant.Checked;
		staffListInfo.bDestClerk = this.cbDestClerk.Checked;
		staffListInfo.bAllot = this.cbAllot.Checked;
		staffListInfo.bManage = false;
		decimal salary = 0m;
		decimal.TryParse(this.tbSalary.Text, out salary);
		staffListInfo.Salary = salary;
		staffListInfo.Account = FunLibrary.ChkInput(this.tbAccount.Text);
		decimal allowance = 0m;
		decimal.TryParse(this.tbAllowance.Text, out allowance);
		staffListInfo.Allowance = allowance;
		staffListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALStaffList dALStaffList = new DALStaffList();
		string str;
		int num3;
		int num2 = dALStaffList.Add(staffListInfo, out str, out num3);
		if (num2 == 0)
		{
			if (this.cbClose.Checked)
			{
				this.SysInfo("parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("ChkTab('1');$('tbName').value='';$('tbName').select();");
				this.ClearText();
			}
		}
		else if (num2 == -1)
		{
			this.SysInfo("window.alert('" + str + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void ClearText()
	{
		this.tbAdr.Text = (this.tbBillDe.Text = (this.tbBirthDay.Text = (this.tbCardNO.Text = (this.tbJobNO.Text = (this.tbJobTime.Text = (this.tbName.Text = (this.tbNativePlace.Text = (this.tbRemark.Text = (this.tbSchool.Text = (this.tbSellDe.Text = (this.tbSpeci.Text = (this.tbTel.Text = string.Empty))))))))))));
		this.ddlQus.ClearSelection();
		this.ddlQus.Items.FindByValue("-1").Selected = true;
		this.ddlSex.ClearSelection();
		this.ddlSex.Items.FindByText("").Selected = true;
		this.ddlStatus.ClearSelection();
		this.ddlStatus.Items.FindByValue("0").Selected = true;
		this.ddlStudy.ClearSelection();
		this.ddlStudy.Items.FindByText("").Selected = true;
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

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void ddlSerFormula_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlSerFormula.SelectedValue != "-1")
		{
			DataSet dataList = DALCommon.GetDataList("StaffList", "BillDeduct", "ID=" + this.ddlSerFormula.SelectedValue);
			this.tbBillDe.Text = dataList.Tables[0].Rows[0][0].ToString().Trim();
		}
		else
		{
			this.tbBillDe.Text = "";
		}
	}

	protected void ddlSellFormula_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlSellFormula.SelectedValue != "-1")
		{
			DataSet dataList = DALCommon.GetDataList("StaffList", "SellDeduct", "ID=" + this.ddlSellFormula.SelectedValue);
			this.tbSellDe.Text = dataList.Tables[0].Rows[0][0].ToString().Trim();
		}
		else
		{
			this.tbSellDe.Text = "";
		}
	}

	protected void btnMod_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		if (!(this.hfRecID.Value == "-1"))
		{
			int num = 0;
			int.TryParse(this.hfRecID.Value, out num);
			DataRow[] array = gridViewSource.Select("ID=" + num);
			decimal num2 = 0m;
			decimal.TryParse(this.tbAmount.Text, out num2);
			DataRow[] array2 = gridViewSource.Select(string.Concat(new object[]
			{
				"Amount=",
				num2,
				" and ID<>",
				num
			}));
			if (array2.Length > 0)
			{
				this.SysInfo3("alert('修改失败！已存在相同的利润空间');");
			}
			else
			{
				array[0]["Amount"] = num2;
				array[0]["Deduct"] = decimal.Parse(this.tbDeduct.Text);
				this.GridViewSource = gridViewSource;
				this.hfRecID.Value = "-1";
				this.ClearTextDe();
				this.BindDeduct();
			}
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		if (!(this.hfRecID.Value == "-1"))
		{
			int num = 0;
			int.TryParse(this.hfRecID.Value, out num);
			DataRow[] array = gridViewSource.Select("ID=" + num);
			for (int i = 0; i < array.Length; i++)
			{
				decimal d = 0m;
				decimal.TryParse(array[i]["Amount"].ToString(), out d);
				if (d > 0m)
				{
					gridViewSource.Rows.Remove(array[i]);
				}
			}
			this.GridViewSource = gridViewSource;
			this.ClearTextDe();
			this.BindDeduct();
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		decimal num = 0m;
		decimal.TryParse(this.tbAmount.Text, out num);
		DataTable gridViewSource = this.GridViewSource;
		DataRow[] array = gridViewSource.Select("Amount=" + num);
		if (array.Length > 0)
		{
			this.SysInfo3("alert('添加失败！利润区间已存在');");
		}
		else
		{
			DataRow dataRow = gridViewSource.NewRow();
			dataRow["Amount"] = num;
			dataRow["Deduct"] = decimal.Parse(this.tbDeduct.Text);
			if (gridViewSource.Rows.Count == 0)
			{
				DataRow dataRow2 = gridViewSource.NewRow();
				dataRow2["Amount"] = 0;
				dataRow2["Deduct"] = decimal.Parse(this.tbDeduct.Text);
				gridViewSource.Rows.Add(dataRow2);
			}
			gridViewSource.Rows.Add(dataRow);
			this.GridViewSource = gridViewSource;
			this.hfRecID.Value = "-1";
			this.ClearTextDe();
			this.BindDeduct();
		}
	}

	protected void SysInfo3(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.UpdatePanel4.GetType(), "SysInfo", str, true);
	}

	protected void ClearTextDe()
	{
		this.tbAmount.Text = "";
		this.tbDeduct.Text = "";
	}

	protected void BindDeduct()
	{
		DataTable gridViewSource = this.GridViewSource;
		gridViewSource.DefaultView.Sort = "Amount";
		DataTable dataTable = gridViewSource.DefaultView.ToTable();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			decimal d = decimal.Parse(dataTable.Rows[i]["Amount"].ToString().Trim());
			if (d == 0m)
			{
				dataTable.Rows[i]["ID"] = dataTable.Rows.Count;
			}
			else
			{
				dataTable.Rows[i]["ID"] = i;
			}
		}
		dataTable.DefaultView.Sort = "ID";
		this.GridViewSource = dataTable.DefaultView.ToTable();
		this.GridView1.DataSource = this.GridViewSource;
		this.GridView1.DataBind();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["id"] = e.Row.Cells[0].Text;
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "0")
			{
				e.Row.Cells[1].Text = "超过后提成";
			}
		}
	}

	protected void ddlStaffDeduct_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ClearTextDe();
		DataTable gridViewSource = this.GridViewSource;
		gridViewSource.Rows.Clear();
		if (this.ddlStaffDeduct.SelectedValue != "-1")
		{
			DataSet dataList = DALCommon.GetDataList("StaffList", "ProfitFormula,ftype", "ID=" + this.ddlStaffDeduct.SelectedValue);
			string text = dataList.Tables[0].Rows[0]["ftype"].ToString().Trim();
			string text2 = dataList.Tables[0].Rows[0]["ProfitFormula"].ToString().Trim();
			if (text != "" && text2 != "")
			{
				this.ddlType.SelectedValue = text;
				string[] array = text2.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow["amount"] = decimal.Parse(array[i].Split(new char[]
					{
						','
					})[0]);
					dataRow["deduct"] = decimal.Parse(array[i].Split(new char[]
					{
						','
					})[1]);
					gridViewSource.Rows.Add(dataRow);
				}
			}
		}
		this.GridViewSource = gridViewSource;
		this.BindDeduct();
	}
}
