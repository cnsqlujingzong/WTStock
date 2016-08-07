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

public partial class Headquarters_Services_AddS : Page, IRequiresSessionState
{
	private int id;

	private int purid;

	public string Str_id
	{
		get
		{
			return this.id.ToString();
		}
	}

	protected string EnforceInput
	{
		get
		{
			string result;
			if (this.hfEnforceInput.Value == "1" && this.ddlDoStyle.SelectedValue.Trim().Equals("2"))
			{
				result = "true";
			}
			else
			{
				result = "false";
			}
			return result;
		}
	}

	protected string EnforceStyle
	{
		get
		{
			string result;
			if (this.hfEnforceInput.Value == "1" && this.ddlDoStyle.SelectedValue.Trim().Equals("2"))
			{
				result = "class='sysred'";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"].Replace("m", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALRight dALRight = new DALRight();
			this.purid = int.Parse((string)this.Session["Session_wtPurID"]);
			if (this.purid > 0)
			{
				if (!dALRight.GetRight(this.purid, "gd_r9"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(this.purid, "gd_r23"))
				{
					this.ddlCloseTyle.Items.RemoveAt(1);
				}
				if (dALRight.GetRight(this.purid, "gd_r29"))
				{
					this.ddlUpDispatching.Items.Remove(new ListItem("委外送修", "1"));
				}
				if (dALRight.GetRight(this.purid, "gd_r28"))
				{
					this.ddlUpDispatching.Items.Remove(new ListItem("派给网点", "3"));
				}
			}
			DataTable dataTable = DALCommon.GetDataList("ServicesList", "Fault,DisposalOper", " [ID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbFault.Text = dataTable.Rows[0]["Fault"].ToString();
				this.tbDisposal.Text = dataTable.Rows[0]["DisposalOper"].ToString();
			}
			DataTable dataTable2 = DALCommon.GetList("SerAttach", "ID", "BillID=" + this.id + " and iType=1").Tables[0];
			string text = string.Empty;
			foreach (DataRow dataRow in dataTable2.Rows)
			{
				text = text + dataRow["ID"].ToString().Trim() + ",";
			}
			this.hfAttachs.Value = text.Trim(new char[]
			{
				','
			});
			DataTable dataTable3 = DALCommon.GetDataList("CustomerList", "BranchID", "ID=(select CustomerID from ServicesList where ID=" + this.id + ")").Tables[0];
			if (dataTable3.Rows.Count > 0 && !dataTable3.Rows[0][0].ToString().Trim().Equals(""))
			{
				this.ddlCloseTyle.Items.Add(new ListItem("网点确认", "3"));
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			OtherFunction.BindTrobleReason(this.ddlTroubleReason);
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.ServicesDo == 0)
			{
				if (this.purid > 0 && dALRight.GetRight(this.purid, "gd_r30"))
				{
					this.ddlDoStyle.Items.Remove(new ListItem("完成关闭", "2"));
					this.lbTitle.Text = "技术员";
					this.ddlUpDispatching.Visible = true;
					this.ddlParam.Visible = false;
					this.tbDisposal.Visible = true;
					this.btnSltStaff.Visible = true;
					this.dcancel.Visible = false;
					this.tbDate.Visible = false;
					this.ddlCloseTyle.Visible = false;
					this.ddlUpDispatching.ClearSelection();
				}
				this.ddlParam.Visible = false;
				this.ddlCloseTyle.Visible = false;
				this.tbDate.Visible = false;
				this.dcancel.Visible = false;
			}
			else
			{
				for (int i = 0; i < this.ddlDoStyle.Items.Count; i++)
				{
					if (this.ddlDoStyle.Items[i].Value == "2")
					{
						this.ddlDoStyle.Items[i].Selected = true;
						break;
					}
				}
				if (this.purid > 0 && dALRight.GetRight(this.purid, "gd_r30"))
				{
					this.ddlDoStyle.Items.Remove(new ListItem("完成关闭", "2"));
					this.lbTitle.Text = "技术员";
					this.ddlUpDispatching.Visible = true;
					this.ddlParam.Visible = false;
					this.tbDisposal.Visible = true;
					this.btnSltStaff.Visible = true;
					this.dcancel.Visible = false;
					this.tbDate.Visible = false;
					this.ddlCloseTyle.Visible = false;
					this.ddlUpDispatching.ClearSelection();
				}
				else
				{
					this.tbDate.Visible = true;
					this.tbDate.Text = DateTime.Now.ToString();
					this.dcancel.Visible = false;
					this.lbTitle.Text = "完工时间";
					this.ddlUpDispatching.Visible = false;
					this.ddlParam.Visible = false;
					this.tbDisposal.Visible = false;
					this.btnSltStaff.Visible = false;
					this.ddlCloseTyle.Visible = true;
					this.ddlCloseTyle.ClearSelection();
					this.btnAdd.Text = "确认关闭";
				}
			}
			if (model.bTakeStepsNoInput)
			{
				this.tbTakeSteps.Attributes["onfocus"] = "blur();";
			}
			this.hfEnforceInput.Value = (model.bEnforceInput ? "1" : "0");
			this.tbArrDate.Text = DateTime.Now.ToString();
			this.tbDay.Text = "0";
			this.tbHour.Text = "0";
		}
	}

	protected void ShowBranchTec()
	{
		this.trbtec.Visible = true;
		this.ddlParam.AutoPostBack = true;
		this.tbFault.Height = 30;
	}

	protected void HideBranchTec()
	{
		this.trbtec.Visible = false;
		this.tbDisposal2.Text = "";
		this.ddlParam.AutoPostBack = false;
		this.tbFault.Height = 57;
	}

	protected void ddlDoStyle_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.HideBranchTec();
		if (this.ddlDoStyle.SelectedValue == "1")
		{
			this.lbTitle.Text = "技术员";
			this.ddlUpDispatching.Visible = true;
			this.ddlParam.Visible = false;
			this.tbDisposal.Visible = true;
			this.btnSltStaff.Visible = true;
			this.dcancel.Visible = false;
			this.tbDate.Visible = false;
			this.ddlCloseTyle.Visible = false;
			this.ddlUpDispatching.ClearSelection();
		}
		else
		{
			this.tbDate.Visible = true;
			this.tbDate.Text = DateTime.Now.ToString();
			this.dcancel.Visible = false;
			this.lbTitle.Text = "完工时间";
			this.ddlUpDispatching.Visible = false;
			this.ddlParam.Visible = false;
			this.tbDisposal.Visible = false;
			this.btnSltStaff.Visible = false;
			this.ddlCloseTyle.Visible = true;
			this.ddlCloseTyle.ClearSelection();
		}
	}

	protected void ddlUpDispatching_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.HideBranchTec();
		if (this.ddlUpDispatching.SelectedValue == "4")
		{
			this.lbTitle.Text = "技术员";
			this.btnSltStaff.Visible = true;
			this.tbDisposal.Visible = true;
			this.ddlParam.Visible = false;
		}
		else if (this.ddlUpDispatching.SelectedValue == "3")
		{
			this.ShowBranchTec();
			this.lbTitle.Text = "派工网点";
			OtherFunction.BindBranch(this.ddlParam);
			this.ddlParam.Items.Remove(new ListItem("总部", "1"));
			this.ddlParam.Items.Insert(0, new ListItem("", "-1"));
			this.btnSltStaff.Visible = false;
			this.ddlParam.Visible = true;
			this.tbDisposal.Visible = false;
		}
		else
		{
			this.lbTitle.Text = "送修厂商";
			bool flag = true;
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r14"))
				{
					flag = false;
				}
				if (dALRight.GetRight(num, "jc_r28"))
				{
					flag = false;
				}
			}
			if (flag)
			{
				OtherFunction.BindSupplier(this.ddlParam, " bTransmitCorp=1 and bStop=0 ");
				this.ddlParam.Items.Remove(new ListItem("新建...", "0"));
			}
			else
			{
				this.ddlParam.Items.Clear();
				this.ddlParam.Items.Insert(0, new ListItem("", "-1"));
			}
			this.btnSltStaff.Visible = false;
			this.ddlParam.Visible = true;
			this.tbDisposal.Visible = false;
		}
	}

	protected void ddlCloseTyle_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlCloseTyle.SelectedValue == "2")
		{
			OtherFunction.BindCancelReason(this.ddlCancel);
			this.lbTitle.Text = "取消原因";
			this.dcancel.Visible = true;
			this.tbDate.Visible = false;
		}
		else
		{
			this.lbTitle.Text = "完工时间";
			this.dcancel.Visible = false;
			this.tbDate.Visible = true;
			this.tbDate.Text = DateTime.Now.ToString();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALServices dALServices = new DALServices();
		int iOperator = 0;
		int iPerson = 0;
		int.TryParse(this.ddlOperator.SelectedValue, out iOperator);
		int.TryParse((string)this.Session["Session_wtUserID"], out iPerson);
		if (this.EnforceInput == "true")
		{
			if (this.tbDoorDate.Text.Trim() == "")
			{
				this.SysInfo("window.alert('上门时间不能为空！');");
				this.tbDoorDate.Focus();
				return;
			}
			if (this.tbArrDate.Text.Trim() == "")
			{
				this.SysInfo("window.alert('完成时间不能为空！');");
				this.tbArrDate.Focus();
				return;
			}
			if (this.tbReason.Value.Trim() == "")
			{
				this.SysInfo("window.alert('故障原因不能为空！');");
				this.tbReason.Focus();
				return;
			}
		}
		int iDays = 0;
		decimal iHours = 0m;
		int.TryParse(this.tbDay.Text, out iDays);
		decimal.TryParse(this.tbHour.Text, out iHours);
		int num = this.id;
		string doDept = "总部";
		if (num > 0)
		{
			DateTime minValue = DateTime.MinValue;
			if (!this.tbDoorDate.Text.Trim().Equals(""))
			{
				DateTime.TryParse(this.tbDoorDate.Text, out minValue);
			}
			if (this.ddlDoStyle.SelectedValue == "1")
			{
				int num2 = 0;
				int.TryParse(this.ddlUpDispatching.SelectedValue, out num2);
				if (num2 == 3 || num2 == 1)
				{
					doDept = this.ddlParam.SelectedItem.Text;
				}
				int paramid = 0;
				int.TryParse(this.ddlParam.SelectedValue, out paramid);
				string tec = FunLibrary.ChkInput(this.tbDisposal.Text);
				if (this.ddlUpDispatching.SelectedValue == "3")
				{
					tec = FunLibrary.ChkInput(this.tbDisposal2.Text);
				}
				int num3 = dALServices.DisAllot(num2, num, 1, iOperator, iPerson, paramid, tec, FunLibrary.ChkInput(this.tbReason.Value), FunLibrary.ChkInput(this.tbTakeSteps.Text), FunLibrary.ChkInput(this.tbArrDate.Text), iDays, iHours, doDept, minValue, this.hfTakeSteps.Value.Trim().Trim(new char[]
				{
					','
				}), this.tbCourse.Text.Trim(), out empty);
				if (num3 == 0)
				{
					if (this.chkOver.Checked)
					{
						dALServices.SetIsTake(num, true);
					}
					else
					{
						dALServices.SetIsTake(num, false);
					}
					this.SysInfo("window.alert('操作成功！该服务单已升级处理');parent.CloseDialog('1');");
				}
				else
				{
					this.SysInfo("window.alert('操作失败！该服务单状态已变化，请刷新后操作！');");
				}
			}
			else if (this.ddlCloseTyle.SelectedValue == "1" || this.ddlCloseTyle.SelectedValue == "3")
			{
				bool bBranchChk = false;
				if (this.ddlCloseTyle.SelectedValue == "3")
				{
					bBranchChk = true;
				}
				int num3 = dALServices.DoBillOK(num, iOperator, iPerson, this.tbDate.Text.Trim(), FunLibrary.ChkInput(this.tbReason.Value), FunLibrary.ChkInput(this.tbTakeSteps.Text), FunLibrary.ChkInput(this.tbArrDate.Text), iDays, iHours, minValue, this.hfTakeSteps.Value.Trim().Trim(new char[]
				{
					','
				}), bBranchChk, this.tbCourse.Text.Trim(), out empty);
				if (num3 == 0)
				{
					this.SysInfo("window.alert('操作成功！该服务单已确认完工');parent.CloseDialog('2');");
				}
				else
				{
					this.SysInfo("window.alert('" + empty + "');");
				}
			}
			else
			{
				int num3 = dALServices.Cancel(num, 1, iOperator, iPerson, FunLibrary.ChkInput(this.tbCaReason.Value), FunLibrary.ChkInput(this.tbReason.Value), FunLibrary.ChkInput(this.tbTakeSteps.Text), FunLibrary.ChkInput(this.tbArrDate.Text), iDays, iHours, minValue, this.hfTakeSteps.Value.Trim().Trim(new char[]
				{
					','
				}), this.tbCourse.Text.Trim(), out empty);
				if (num3 == 0)
				{
					this.SysInfo("window.alert('操作成功！该服务单已取消');parent.CloseDialog('2');");
				}
				else
				{
					this.SysInfo("window.alert('" + empty + "');");
				}
			}
			dALServices.UpdateAttachs(-num, 2, this.hfTSAttachs.Value.Trim().Trim(new char[]
			{
				','
			}));
			dALServices.UpdateAttachs(-num, 3, this.hfReasonAttachs.Value.Trim().Trim(new char[]
			{
				','
			}));
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void ddlParam_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.tbDisposal2.Text = "";
	}
}
