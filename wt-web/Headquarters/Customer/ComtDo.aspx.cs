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

public partial class Headquarters_Customer_ComtDo : Page, IRequiresSessionState
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
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r27"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			DataTable dataTable = DALCommon.GetDataList("ks_complaint", "", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbDate.Text = dataTable.Rows[0]["DoDate"].ToString();
				if (this.tbDate.Text == "")
				{
					this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				}
				for (int i = 0; i < this.ddlResult.Items.Count; i++)
				{
					if (this.ddlResult.Items[i].Text == dataTable.Rows[0]["Result"].ToString())
					{
						this.ddlResult.Items[i].Selected = true;
						break;
					}
				}
				this.tbContent.Text = dataTable.Rows[0]["Content"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbMeasures.Text = dataTable.Rows[0]["Measures"].ToString();
				string a = (string)this.Session["Session_wtUser"];
				if (a != dataTable.Rows[0]["DoOperator"].ToString())
				{
					this.lbMod.Text = "你没有权限处理该投诉";
					this.lbMod.Attributes.Add("class", "si3");
					this.btnAdd.Enabled = false;
				}
				if (dataTable.Rows[0]["Status"].ToString() == "已审核")
				{
					this.lbMod.Text = "该投诉已处理，不能再次处理";
					this.lbMod.Attributes.Add("class", "si3");
					this.btnAdd.Enabled = false;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		ComplaintInfo complaintInfo = new ComplaintInfo();
		complaintInfo.ID = this.id;
		complaintInfo.DoDate = DateTime.Parse(this.tbDate.Text);
		complaintInfo.Result = this.ddlResult.SelectedValue;
		complaintInfo.Measures = this.tbMeasures.Text;
		complaintInfo.Remark = this.tbRemark.Text;
		complaintInfo.Status = "已处理";
		DALComplaint dALComplaint = new DALComplaint();
		dALComplaint.UpdateDo(complaintInfo);
		this.SysInfo("window.alert('操作成功！该投诉已处理');parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
