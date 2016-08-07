using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using wt.DAL;
using wt.Library;

public partial class Headquarters_System_AjNotice : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int iStaff = 0;
			int.TryParse((string)this.Session["Session_wtUserID"], out iStaff);
			DALSys dALSys = new DALSys();
			DataTable dataTable = dALSys.GetXTTX(1, iStaff).Tables[0];
			string text = "";
			if (dataTable.Rows.Count > 0)
			{
				text = text + "(" + dataTable.Rows[0]["�������"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["����ȷ��"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["������"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["������"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���޷���"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["�ջ�����"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["������"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���ط�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["�����"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���ھ�����"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���ھ�����"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��Ҫ���ڵ���Ʒ"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["�ѵ��ڵ���Ʒ"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["�������"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��������"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["����ǩ��"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["�������벵��"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["δ���ʼ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["Ҫ����ķ���"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���ұ��޵��ڵĻ���"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["ά�ޱ��޵��ڵĻ���"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��Ҫ���ڵı����ƻ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���ڵ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["����Ա������"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���տͻ�����"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["Ҫ����ķ���"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��Ҫ���ڵı����ƻ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���ڵ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��Ҫ���ڵĺĲĸ���"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["����Ӧ�տ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["����Ӧ����"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��Ҫ���ڵ�Ӧ�տ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��Ҫ���ڵ�Ӧ����"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["ά�ޱ��޽����ڵĻ���"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��Ҫ���ڵķ����ͬ"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["��Ҫ���ڵ�����ȫ��"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["Ҫ���ٵĿͻ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["���ٴθ��ٵĿͻ�"].ToString() + ")^";
				text = text + "(" + dataTable.Rows[0]["�����ڽ��"].ToString() + ")";
			}
			base.Response.Write(text);
		}
	}
}
