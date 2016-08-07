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

public partial class Branch_Receive_SndNew : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "fh_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "fh_r2"))
				{
					this.btnConfSnd.Enabled = false;
				}
			}
			this.tbBillID.Text = DALCommon.CreateID(25, 0);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("", "-1"));
			this.ddlBranch.Items.Remove(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			OtherFunction.BindSndStyle(this.ddlShipStyle, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			this.ddlBranch.Enabled = false;
		}
	}

	protected void btnConfSnd_Click(object sender, EventArgs e)
	{
		int iTbid;
		int num = this.BillAdd(out iTbid);
		if (num == 0)
		{
			string empty = string.Empty;
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			num = dALRcvSnd.ConfSnd(iTbid, int.Parse(this.ddlShipStyle.SelectedValue), FunLibrary.ChkInput(this.tbSndNo.Text), out empty);
			if (num == 0)
			{
				this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！该发货单转入待收货确认');");
			}
			else
			{
				this.SysInfo("window.alert('" + empty + "');");
			}
			this.ClearText();
			this.hfPrintID.Value = iTbid.ToString();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num;
		if (this.BillAdd(out num) == 0)
		{
			this.SysInfo("window.alert('操作成功！发货单已生成');");
			this.ClearText();
			this.hfPrintID.Value = num.ToString();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！请查看错误日志');");
		}
	}

	protected int BillAdd(out int iTbid)
	{
		RcvSndInfo rcvSndInfo = new RcvSndInfo();
		rcvSndInfo.DeptID = new int?(int.Parse((string)this.Session["Session_wtBranchID"]));
		rcvSndInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		rcvSndInfo.OperatorID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		rcvSndInfo.PersonID = new int?(int.Parse(this.Session["Session_wtUserBID"].ToString()));
		rcvSndInfo.OperationType = this.ddlSndType.SelectedItem.Text;
		rcvSndInfo.RcvType = this.ddlRcvObj.SelectedItem.Text;
		rcvSndInfo.RcvDeptID = new int?(int.Parse(this.ddlBranch.SelectedValue));
		rcvSndInfo.CorpName = this.tbCusName.Text;
		rcvSndInfo.LinkMan = this.tbLinkMan.Text;
		rcvSndInfo.Tel = this.tbTel.Text;
		rcvSndInfo.Adr = this.tbAdr.Text;
		rcvSndInfo.Zip = this.tbZip.Text;
		rcvSndInfo.Summary = this.tbSummary.Text;
		rcvSndInfo.SndStyleID = new int?(int.Parse(this.ddlShipStyle.SelectedValue));
		rcvSndInfo.PostNO = this.tbSndNo.Text;
		rcvSndInfo.Postage = new decimal?((this.tbPostage.Text.Trim() == string.Empty) ? 0m : decimal.Parse(this.tbPostage.Text));
		rcvSndInfo.Remark = this.tbRemark.Text;
		DALRcvSnd dALRcvSnd = new DALRcvSnd();
		int result = dALRcvSnd.Add(rcvSndInfo, out iTbid);
		this.hfPrintID.Value = iTbid.ToString();
		return result;
	}

	protected void ClearText()
	{
		this.tbBillID.Text = DALCommon.CreateID(25, 0);
		this.tbCusName.Text = string.Empty;
		this.tbLinkMan.Text = string.Empty;
		this.tbTel.Text = string.Empty;
		this.tbZip.Text = string.Empty;
		this.tbAdr.Text = string.Empty;
		this.ddlBranch.ClearSelection();
		this.tbSummary.Text = string.Empty;
		this.ddlShipStyle.ClearSelection();
		this.tbPostage.Text = string.Empty;
		this.tbSndNo.Text = string.Empty;
		this.tbRemark.Text = string.Empty;
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	protected void ddlRcvObj_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlRcvObj.SelectedItem.Text == "网点")
		{
			this.ddlBranch.Enabled = true;
		}
		else
		{
			this.ddlBranch.Enabled = false;
		}
		this.tbCusName.Text = string.Empty;
		this.tbLinkMan.Text = string.Empty;
		this.tbTel.Text = string.Empty;
		this.tbZip.Text = string.Empty;
		this.tbAdr.Text = string.Empty;
	}

	protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlBranch.SelectedValue != "-1")
		{
			DataTable dataTable = DALCommon.GetDataList("BranchList", "", "[ID]=" + this.ddlBranch.SelectedValue).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusName.Text = dataTable.Rows[0]["CorpName"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbZip.Text = dataTable.Rows[0]["Zip"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
			}
		}
	}
}
