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

public partial class Headquarters_Receive_SndView : Page, IRequiresSessionState
{

	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALRcvSnd dALRcvSnd = new DALRcvSnd();
			RcvSndInfo model = dALRcvSnd.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				OtherFunction.BindStaff(this.ddlOperator, "[ID]=" + model.OperatorID);
				OtherFunction.BindSndStyle(this.ddlShipStyle, "[ID]=" + model.SndStyleID);
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

	protected void btnSave_Click(object sender, EventArgs e)
	{
		int.TryParse(this.hfPrintID.Value, out this.id);
		DALRcvSnd dALRcvSnd = new DALRcvSnd();
		int num = dALRcvSnd.UpdateRemark(this.id, FunLibrary.ChkInput(this.tbRemark.Text));
		if (num > 0)
		{
			ScriptManager.RegisterStartupScript(this, base.GetType(), "11", "alert('保存成功！')", true);
		}
	}
}
