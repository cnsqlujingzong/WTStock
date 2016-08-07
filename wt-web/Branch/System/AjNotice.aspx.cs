using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using wt.DAL;
using wt.Library;

public partial class Branch_System_AjNotice : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int iStaff = 0;
			int.TryParse((string)this.Session["Session_wtUserBID"], out iStaff);
			DALSys dALSys = new DALSys();
			DataTable dataTable = dALSys.GetXTTX(int.Parse((string)this.Session["Session_wtBranchID"]), iStaff).Tables[0];
			string text = "";
			if (dataTable.Rows.Count > 0)
			{
				text = text + "(" + dataTable.Rows[0]["送修确认"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["待处理"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["处理中"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["送修发货"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["收货结算"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["待结算"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["高于警戒库存"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["低于警戒库存"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将要到期的商品"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["已到期的商品"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["调拨审核"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["调拨发货"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["调拨签收"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["调拨申请驳回"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["未读邮件"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["要处理的服务单"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["厂家保修到期的机器"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["维修保修到期的机器"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将要到期的保养计划"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["超期单"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["今日员工生日"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["今日客户生日"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["要处理的服务单"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将要到期的保养计划"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["超期单"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["到期应收款"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["到期应付款"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将要到期的应收款"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将要到期的应付款"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["维修保修将到期的机器"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将要到期的服务合同"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将到期借出"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["要跟踪的客户"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["需再次跟踪的客户"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将要到期的租赁全保"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["将要到期的耗材跟踪"].ToString() + ")";
			}
			base.Response.Write(text);
		}
	}
}
