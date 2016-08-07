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

public partial class Branch_Receive_SndMod : Page, IRequiresSessionState
{
	private int id;


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "fh_r2"))
				{
					this.btnAdd.Enabled = false;
					this.btnConfSnd.Enabled = false;
				}
			}
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			RcvSndInfo model = dALRcvSnd.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				OtherFunction.BindStaff(this.ddlOperator, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
				OtherFunction.BindSndStyle(this.ddlShipStyle, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.OperatorID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.ddlSndType.Items.FindByText(model.OperationType).Selected = true;
				this.ddlRcvObj.Items.FindByText(model.RcvType).Selected = true;
				if (model.RcvType == "网点")
				{
					DataTable dataTable = DALCommon.GetDataList("BranchList", "_Name", "[ID]=" + model.RcvDeptID).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.ddlBranch.Items.Add(new ListItem(dataTable.Rows[0]["_Name"].ToString(), dataTable.Rows[0]["_Name"].ToString()));
					}
				}
				this.tbCusName.Text = model.CorpName;
				this.tbLinkMan.Text = model.LinkMan;
				this.tbTel.Text = model.Tel;
				this.tbAdr.Text = model.Adr;
				this.tbZip.Text = model.Zip;
				this.tbSummary.Text = model.Summary;
				for (int i = 0; i < this.ddlShipStyle.Items.Count; i++)
				{
					if (this.ddlShipStyle.Items[i].Value == model.SndStyleID.ToString())
					{
						this.ddlShipStyle.Items[i].Selected = true;
						break;
					}
				}
				this.tbSndNo.Text = model.PostNO;
				this.tbPostage.Text = model.Postage.ToString();
				this.tbRemark.Text = model.Remark;
			}
		}
	}

	protected void btnConfSnd_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = this.BillAdd(out empty);
		if (num == 0)
		{
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			num = dALRcvSnd.ConfSnd(this.id, int.Parse(this.ddlShipStyle.SelectedValue), FunLibrary.ChkInput(this.tbSndNo.Text), out empty);
			if (num == 0)
			{
				this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！该发货单转入待收货确认');");
			}
			else
			{
				this.SysInfo("window.alert('" + empty + "');");
			}
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + empty + "');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string str = "";
		if (this.BillAdd(out str) == 0)
		{
			this.SysInfo("parent.CloseDialog('1');window.alert('操作成功！发货单已生成');");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + str + "');");
		}
	}

	protected int BillAdd(out string strMsg)
	{
		RcvSndInfo rcvSndInfo = new RcvSndInfo();
		rcvSndInfo.ID = this.id;
		rcvSndInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
		rcvSndInfo.OperatorID = new int?(int.Parse(this.ddlOperator.SelectedValue));
		rcvSndInfo.OperationType = this.ddlSndType.SelectedItem.Text;
		rcvSndInfo.RcvType = this.ddlRcvObj.SelectedItem.Text;
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
		return dALRcvSnd.Update(rcvSndInfo, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
