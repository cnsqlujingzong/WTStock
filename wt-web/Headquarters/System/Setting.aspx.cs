using DAL;
using System;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_System_Setting : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "系统管理员")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=NOSet");
				base.Response.End();
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			this.tbName.Text = model.CorpName;
			this.tbTel.Text = model.Tel;
			this.tbAdr.Text = model.Adr;
			this.tbZip.Text = model.Zip;
			this.tbsysName.Text = model.SysName;
			if (model.BranchNum > 0)
			{
				this.tbBranchNum.Text = model.BranchNum.ToString();
			}
			for (int i = 0; i < this.ddl_parm1.Items.Count; i++)
			{
				if (this.ddl_parm1.Items[i].Value == model.AllocatePrice.ToString())
				{
					this.ddl_parm1.Items[i].Selected = true;
					break;
				}
			}
			this.tb_parm2.Text = model.WarrantyCycle.ToString();
			for (int i = 0; i < this.ddl_parm3.Items.Count; i++)
			{
				if (this.ddl_parm3.Items[i].Value == model.CustomerShar.ToString())
				{
					this.ddl_parm3.Items[i].Selected = true;
					break;
				}
			}
			this.ddlCostMode.Items.Insert(0, new ListItem("", "0"));
			this.ddlCostMode.SelectedValue = model.CostModel.ToString();
			this.tb_parm5.Text = model.EmailServer;
			this.tb_parm6.Text = model.EmailLogName;
			this.tb_parm7.Text = model.EmailPwd;
			this.tb_parm8.Text = model.EmailAdr;
			this.tb_parm9.Text = model.SmsCode;
			this.tbRecDue.Text = model.RecDueDay.ToString();
			this.cbLoginDLL.Checked = model.bLoginDdl;
			this.cbVerifyCode.Checked = model.bValiCode;
			this.cbPhone.Checked = model.bPhone;
			this.tbiRepair.Text = model.iRepair.ToString();
			if (model.bBln > 0)
			{
				this.cbbBln.Checked = true;
			}
			this.cbRememberPassword.Checked = model.bRememberPassword;
			this.cbbFinish.Checked = model.bFinish;
			this.cbbFinish2.Checked = model.bFinish2;
			this.cbHead.Checked = model.bHeadBln;
			this.cbSerBillSeparate.Checked = model.bSerSep;
			this.cbFaultNoInput.Checked = model.bFaultNoInput;
			this.cbTakeStepsNoInput.Checked = model.bTakeStepsNoInput;
			this.cbbTec.Checked = model.bTec;
			this.cbbItemExit.Checked = model.bSerItem;
			this.cbPlanControl.Checked = model.bPlanControl;
			for (int i = 0; i < this.ddlServicesDo.Items.Count; i++)
			{
				if (this.ddlServicesDo.Items[i].Value == model.ServicesDo.ToString())
				{
					this.ddlServicesDo.Items[i].Selected = true;
					break;
				}
			}
			this.tbCity.Text = model.City;
			DALSysVali dALSysVali = new DALSysVali();
			string value = dALSysVali.GetValue("ITEM2");
			string text = this.tbName.Text + model.bWeb.ToString() + this.tbBranchNum.Text;
			if (model.bSim)
			{
				this.lbRegType.Text = "并发数";
				text += "并发";
			}
			string b = FunLibrary.EncodeReg(text);
			if (value == b)
			{
				this.lbreg.Text = "-已注册用户";
				this.lbreg.Attributes.Add("style", " color:#ffffff; background:#008800");
				this.tbName.Enabled = false;
				this.tbBranchNum.Enabled = true;
			}
			else
			{
               // this.lbreg.Text = "-非注册用户";
                this.lbreg.Text = "-已注册用户";
				this.lbreg.Attributes.Add("style", " color:#ffffff; background:#ff0000");
			}
			this.cbEnforceInput.Checked = model.bEnforceInput;
			this.cbbZeroPurchase.Checked = model.bZeroPurchase;
			this.cbDisblingControl.Checked = model.bDisblingControl;
			this.tbLockTime.Text = model.LockMinutes.ToString();
			this.cbDeviceOnly.Checked = model.bDeviceOnly;
			this.cbPurSep.Checked = model.bPurSep;
			this.cbSellSep.Checked = model.bSellSep;
			DALStaffList dALStaffList = new DALStaffList();
			dALStaffList.GetStaffInfo(this.DropDownList1);
			this.DropDownList1.Items.Insert(0, new ListItem("--请选择--", "-1"));
			dALStaffList.GetStaffInfo(this.DropDownList2);
			this.DropDownList2.Items.Insert(0, new ListItem("--请选择--", "-1"));
			dALStaffList.GetStaffInfo(this.DropDownList3);
			this.DropDownList3.Items.Insert(0, new ListItem("--请选择--", "-1"));
			dALStaffList.GetStaffInfo(this.DropDownList4);
			this.DropDownList4.Items.Insert(0, new ListItem("--请选择--", "-1"));
			dALStaffList.GetStaffInfo(this.DropDownList5);
			this.DropDownList5.Items.Insert(0, new ListItem("--请选择--", "-1"));
			dALStaffList.GetStaffInfo(this.DropDownList6);
			this.DropDownList6.Items.Insert(0, new ListItem("--请选择--", "-1"));
			dALStaffList.GetStaffInfo(this.DropDownList7);
			this.DropDownList7.Items.Insert(0, new ListItem("--请选择--", "-1"));
			dALStaffList.GetStaffInfo(this.DropDownList8);
			this.DropDownList8.Items.Insert(0, new ListItem("--请选择--", "-1"));
			DALIPControl dALIPControl = new DALIPControl();
			DataTable dataTable = dALIPControl.GetList(1).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbIPStar.Text = dataTable.Rows[0]["StartIP"].ToString();
				this.tbIPEnd.Text = dataTable.Rows[0]["EndIP"].ToString();
				if (dataTable.Rows[0]["bEnable"].ToString() == "True")
				{
					this.CheckBox1.Checked = true;
				}
				else
				{
					this.CheckBox1.Checked = false;
				}
			}
			DALUserException ex = new DALUserException();
			DataTable dataTable2 = ex.GetList().Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					string s = dataTable2.Rows[i]["ID"].ToString();
					switch (int.Parse(s))
					{
					case 1:
						this.DropDownList1.SelectedValue = dataTable2.Rows[i]["StaffID"].ToString();
						this.DropDownList1.Text = dataTable2.Rows[i]["StaffName"].ToString();
						this.TextBox1.Text = dataTable2.Rows[i]["Remark"].ToString();
						break;
					case 2:
						this.DropDownList2.SelectedValue = dataTable2.Rows[i]["StaffID"].ToString();
						this.DropDownList2.Text = dataTable2.Rows[i]["StaffName"].ToString();
						this.TextBox2.Text = dataTable2.Rows[i]["Remark"].ToString();
						break;
					case 3:
						this.DropDownList3.SelectedValue = dataTable2.Rows[i]["StaffID"].ToString();
						this.DropDownList3.Text = dataTable2.Rows[i]["StaffName"].ToString();
						this.TextBox3.Text = dataTable2.Rows[i]["Remark"].ToString();
						break;
					case 4:
						this.DropDownList4.SelectedValue = dataTable2.Rows[i]["StaffID"].ToString();
						this.DropDownList4.Text = dataTable2.Rows[i]["StaffName"].ToString();
						this.TextBox4.Text = dataTable2.Rows[i]["Remark"].ToString();
						break;
					case 5:
						this.DropDownList5.SelectedValue = dataTable2.Rows[i]["StaffID"].ToString();
						this.DropDownList5.Text = dataTable2.Rows[i]["StaffName"].ToString();
						this.TextBox5.Text = dataTable2.Rows[i]["Remark"].ToString();
						break;
					case 6:
						this.DropDownList6.SelectedValue = dataTable2.Rows[i]["StaffID"].ToString();
						this.DropDownList6.Text = dataTable2.Rows[i]["StaffName"].ToString();
						this.TextBox6.Text = dataTable2.Rows[i]["Remark"].ToString();
						break;
					case 7:
						this.DropDownList7.SelectedValue = dataTable2.Rows[i]["StaffID"].ToString();
						this.DropDownList7.Text = dataTable2.Rows[i]["StaffName"].ToString();
						this.TextBox7.Text = dataTable2.Rows[i]["Remark"].ToString();
						break;
					case 8:
						this.DropDownList8.SelectedValue = dataTable2.Rows[i]["StaffID"].ToString();
						this.DropDownList8.Text = dataTable2.Rows[i]["StaffName"].ToString();
						this.TextBox8.Text = dataTable2.Rows[i]["Remark"].ToString();
						break;
					}
				}
			}
			this.DataFill();
		}
	}

	public void DataFill()
	{
		this.GridView1.DataSource = DALCommon.GetDataList("NOPlan", "", "").Tables[0];
		this.GridView1.DataBind();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "EidtNO();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnRef_Click(object sender, EventArgs e)
	{
		this.DataFill();
		if (this.hfRecID.Value != "-1")
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", "ChkID('" + this.hfRecID.Value + "');", true);
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParmInfo = new SysParmInfo();
		sysParmInfo.ID = 1;
		sysParmInfo.CorpName = this.tbName.Text;
		sysParmInfo.Tel = this.tbTel.Text;
		sysParmInfo.Adr = this.tbAdr.Text;
		sysParmInfo.Zip = this.tbZip.Text;
		sysParmInfo.SysName = this.tbsysName.Text;
		int branchNum = 0;
		int.TryParse(this.tbBranchNum.Text, out branchNum);
		sysParmInfo.BranchNum = branchNum;
		sysParmInfo.AllocatePrice = int.Parse(this.ddl_parm1.SelectedValue);
		int warrantyCycle = 0;
		int.TryParse(this.tb_parm2.Text, out warrantyCycle);
		sysParmInfo.WarrantyCycle = warrantyCycle;
		sysParmInfo.CustomerShar = int.Parse(this.ddl_parm3.SelectedValue);
		sysParmInfo.EmailServer = this.tb_parm5.Text;
		sysParmInfo.EmailLogName = this.tb_parm6.Text;
		sysParmInfo.EmailPwd = this.tb_parm7.Text;
		sysParmInfo.EmailAdr = this.tb_parm8.Text;
		sysParmInfo.SmsCode = this.tb_parm9.Text;
		int recDueDay = 0;
		int.TryParse(this.tbRecDue.Text, out recDueDay);
		sysParmInfo.RecDueDay = recDueDay;
		sysParmInfo.bLoginDdl = this.cbLoginDLL.Checked;
		sysParmInfo.bValiCode = this.cbVerifyCode.Checked;
		sysParmInfo.bPhone = this.cbPhone.Checked;
		bool @checked = this.cbbBln.Checked;
		sysParmInfo.bBln = 0;
		if (@checked)
		{
			sysParmInfo.bBln = 1;
		}
		int iRepair = 0;
		int.TryParse(this.tbiRepair.Text, out iRepair);
		sysParmInfo.iRepair = iRepair;
		sysParmInfo.bRememberPassword = this.cbRememberPassword.Checked;
		sysParmInfo.bFinish = this.cbbFinish.Checked;
		sysParmInfo.bFinish2 = this.cbbFinish2.Checked;
		sysParmInfo.bSerItem = this.cbbItemExit.Checked;
		sysParmInfo.ServicesDo = int.Parse(this.ddlServicesDo.SelectedValue);
		sysParmInfo.City = FunLibrary.ChkInput(this.tbCity.Text);
		sysParmInfo.bTec = this.cbbTec.Checked;
		sysParmInfo.bHeadBln = this.cbHead.Checked;
		sysParmInfo.bSerSep = this.cbSerBillSeparate.Checked;
		sysParmInfo.bTakeStepsNoInput = this.cbTakeStepsNoInput.Checked;
		sysParmInfo.bFaultNoInput = this.cbFaultNoInput.Checked;
		sysParmInfo.bEnforceInput = this.cbEnforceInput.Checked;
		sysParmInfo.bPlanControl = this.cbPlanControl.Checked;
		sysParmInfo.bZeroPurchase = this.cbbZeroPurchase.Checked;
		sysParmInfo.bDisblingControl = this.cbDisblingControl.Checked;
		int lockMinutes = 0;
		int.TryParse(this.tbLockTime.Text, out lockMinutes);
		sysParmInfo.LockMinutes = lockMinutes;
		sysParmInfo.bDeviceOnly = this.cbDeviceOnly.Checked;
		sysParmInfo.bSellSep = this.cbSellSep.Checked;
		sysParmInfo.bPurSep = this.cbPurSep.Checked;
		int costModel = 0;
		int.TryParse(this.ddlCostMode.SelectedValue, out costModel);
		sysParmInfo.CostModel = costModel;
		dALSysParm.Update(sysParmInfo);
		dALSysParm.Update2(sysParmInfo);
		string text = this.tbIPStar.Text.Trim();
		string text2 = this.tbIPEnd.Text.Trim();
		IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
		IPAddress iPAddress2 = IPAddress.Parse("127.0.0.1");
		if (this.CheckBox1.Checked)
		{
			if (text == string.Empty)
			{
				this.SysInfo("window.alert('IP地址填写错误，请重新填写');");
				return;
			}
			if (text2 == string.Empty)
			{
				this.SysInfo("window.alert('IP地址填写错误，请重新填写');");
				return;
			}
			if (!Regex.IsMatch(text, "((?:(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))\\.){3}(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d))))"))
			{
				this.SysInfo("window.alert('IP地址填写错误，请重新填写');");
				return;
			}
			if (!Regex.IsMatch(text2, "((?:(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))\\.){3}(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d))))"))
			{
				this.SysInfo("window.alert('IP地址填写错误，请重新填写');");
				return;
			}
			DALIPControl dALIPControl = new DALIPControl();
			if (dALIPControl.ExitsID(1))
			{
				dALIPControl.UpdateData(text, text2, 1, true);
			}
			else
			{
				dALIPControl.InsertData(1, text, text2, true);
			}
			this.UpdateByDropDownList(this.DropDownList1, 1, this.TextBox1);
			this.UpdateByDropDownList(this.DropDownList2, 2, this.TextBox2);
			this.UpdateByDropDownList(this.DropDownList3, 3, this.TextBox3);
			this.UpdateByDropDownList(this.DropDownList4, 4, this.TextBox4);
			this.UpdateByDropDownList(this.DropDownList5, 5, this.TextBox5);
			this.UpdateByDropDownList(this.DropDownList6, 6, this.TextBox6);
			this.UpdateByDropDownList(this.DropDownList7, 7, this.TextBox7);
			this.UpdateByDropDownList(this.DropDownList8, 8, this.TextBox8);
		}
		else
		{
			DALIPControl dALIPControl = new DALIPControl();
			if (dALIPControl.ExitsID(1))
			{
				dALIPControl.UpdateData(1, false);
			}
		}
		this.SysInfo("window.alert('保存成功！设置信息已更新');parent.CloseDialog();");
	}

	private void UpdateByDropDownList(DropDownList ddl, int index, TextBox tb)
	{
		if (ddl.SelectedValue != "-1")
		{
			DALUserException ex = new DALUserException();
			if (ex.ExistsByID(index))
			{
				ex.UpdateData(index, int.Parse(ddl.SelectedValue), ddl.SelectedItem.Text, tb.Text);
			}
			else
			{
				ex.InsertData(index, int.Parse(ddl.SelectedValue), ddl.SelectedItem.Text, tb.Text);
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
