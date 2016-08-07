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

public partial class Headquarters_Office_ChkAttend : Page, IRequiresSessionState
{

	private string id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.id = base.Request["id"];
		if (this.id == null || this.id == "")
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			this.ddlType.DataSource = DALCommon.GetDataList("AbsenceSet", "[ID],Type", " DeptID=1 ");
			this.ddlType.DataTextField = "Type";
			this.ddlType.DataValueField = "ID";
			this.ddlType.DataBind();
			this.ddlType.Items.Insert(0, new ListItem("", ""));
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		AttendanceDetailInfo attendanceDetailInfo = new AttendanceDetailInfo();
		decimal absencedMoney = 0m;
		decimal.TryParse(this.tbMoney.Text, out absencedMoney);
		attendanceDetailInfo.AbsencedMoney = absencedMoney;
		attendanceDetailInfo.AbsenceType = this.ddlType.SelectedItem.Text;
		attendanceDetailInfo.Properties = 3;
		attendanceDetailInfo.ChkDate = DateTime.Now;
		attendanceDetailInfo.ChkOperatorID = int.Parse((string)this.Session["Session_wtUserID"]);
		attendanceDetailInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DALAttendanceDetail dALAttendanceDetail = new DALAttendanceDetail();
		int num = this.id.LastIndexOf(',');
		if (num > 0)
		{
			this.id = this.id.Remove(this.id.LastIndexOf(','));
		}
		dALAttendanceDetail.Update(attendanceDetailInfo, this.id);
		this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！缺勤明细已审核');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlType.SelectedValue != "")
		{
			DataTable dataTable = DALCommon.GetDataList("AbsenceSet", "", " [ID]=" + this.ddlType.SelectedValue).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbMoney.Text = dataTable.Rows[0]["dMoney"].ToString();
			}
		}
	}
}
