using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class right_01 : Page, IRequiresSessionState
{
	
	private string content;
	public string Str_Content
	{
		get
		{
			return this.content;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			this.GetNotify();
     lb_in_mon.Text= Coding.Stock.Common.UserInter.GetUserInter(Session["Session_wtUserID"].ToString(), Session["Session_wtUser"].ToString(),"month").ToString();
     lb_in_week.Text = Coding.Stock.Common.UserInter.GetUserInter(Session["Session_wtUserID"].ToString(), Session["Session_wtUser"].ToString(), "week").ToString();
     lb_o_mon.Text = Coding.Stock.Common.UserInter.GetTop(Session["Session_wtUserID"].ToString(), Session["Session_wtUser"].ToString(), "month").ToString();
     lb_o_week.Text = Coding.Stock.Common.UserInter.GetTop(Session["Session_wtUserID"].ToString(), Session["Session_wtUser"].ToString(), "week").ToString();
         
            
            
            try
			{
				string requestUriString = "http://www.differsoft.com/production/update.ashx?id=21&c=10";
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Method = "GET";
				httpWebRequest.MaximumAutomaticRedirections = 3;
				httpWebRequest.Timeout = 5000;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				this.content = streamReader.ReadToEnd();
				streamReader.Dispose();
				responseStream.Dispose();
			}
			catch
			{
				this.content = "<ul id=\"news\"><li><a href=\"#s\" style=\"color:#ff0000\">��ȡ������Ѷʧ�ܡ���</a></li></ul>";
			}
		}
	}
	protected void btnRefresh_Click(object sender, EventArgs e)
	{
		this.GetNotify();
	}

	protected void GetNotify()
	{
		int iStaff = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iStaff);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetXTTX(1, iStaff).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
            this.lbt1.Text = "(" + dataTable.Rows[0]["�������"].ToString() + ")";
			this.Label2.Text = "(" + dataTable.Rows[0]["����ȷ��"].ToString() + ")";
			this.lbt3.Text = "(" + dataTable.Rows[0]["������"].ToString() + ")";
			this.lbt4.Text = "(" + dataTable.Rows[0]["������"].ToString() + ")";
			this.lbt5.Text = "(" + dataTable.Rows[0]["���޷���"].ToString() + ")";
			this.lbt6.Text = "(" + dataTable.Rows[0]["�ջ�����"].ToString() + ")";
			this.lbt7.Text = "(" + dataTable.Rows[0]["������"].ToString() + ")";
			this.lbt8.Text = "(" + dataTable.Rows[0]["���ط�"].ToString() + ")";
            this.lbt9.Text = "(" + dataTable.Rows[0]["�����"].ToString() + ")";
             this.lbt10.Text = "(" + dataTable.Rows[0]["���ھ�����"].ToString() + ")";
        		this.lbt11.Text = "(" + dataTable.Rows[0]["���ھ�����"].ToString() + ")";
			this.lbt12.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵ���Ʒ"].ToString() + ")";
			this.lbt13.Text = "(" + dataTable.Rows[0]["�ѵ��ڵ���Ʒ"].ToString() + ")";
     		this.lbt14.Text = "(" + dataTable.Rows[0]["�������"].ToString() + ")";
			this.lbt15.Text = "(" + dataTable.Rows[0]["��������"].ToString() + ")";
			this.lbt16.Text = "(" + dataTable.Rows[0]["����ǩ��"].ToString() + ")";
			this.lbt17.Text = "(" + dataTable.Rows[0]["�������벵��"].ToString() + ")";
         			this.lbt18.Text = "(" + dataTable.Rows[0]["�����ڽ��"].ToString() + ")";
			this.lbt19.Text = "(" + dataTable.Rows[0]["����Ӧ�տ�"].ToString() + ")";
			this.lbt20.Text = "(" + dataTable.Rows[0]["����Ӧ����"].ToString() + ")";
			this.lbt21.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵ�Ӧ�տ�"].ToString() + ")";
			this.lbt22.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵ�Ӧ����"].ToString() + ")";
			this.lbt23.Text = "(" + dataTable.Rows[0]["δ���ʼ�"].ToString() + ")";
      	this.lbt24.Text = "(" + dataTable.Rows[0]["Ҫ����ķ���"].ToString() + ")";
			this.lbt25.Text = "(" + dataTable.Rows[0]["Ҫ���ٵĿͻ�"].ToString() + ")";
			this.lbt26.Text = "(" + dataTable.Rows[0]["���ұ��޵��ڵĻ���"].ToString() + ")";
			this.lbt27.Text = "(" + dataTable.Rows[0]["ά�ޱ��޵��ڵĻ���"].ToString() + ")";
			this.lbt28.Text = "(" + dataTable.Rows[0]["ά�ޱ��޽����ڵĻ���"].ToString() + ")";
			this.lbt29.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵı����ƻ�"].ToString() + ")";
      		this.lbt30.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵķ����ͬ"].ToString() + ")";
			this.lbt31.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵ�����ȫ��"].ToString() + ")";
			this.lbt32.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵĺĲĸ���"].ToString() + ")";
			this.lbt33.Text = "(" + dataTable.Rows[0]["���ڵ�"].ToString() + ")";
			this.lbt34.Text = "(" + dataTable.Rows[0]["����Ա������"].ToString() + ")";
			this.lbt35.Text = "(" + dataTable.Rows[0]["���տͻ�����"].ToString() + ")";
       		this.lbt36.Text = "(" + dataTable.Rows[0]["Ҫ����ķ���"].ToString() + ")";
			this.lbt37.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵı����ƻ�"].ToString() + ")";
			this.lbt38.Text = "(" + dataTable.Rows[0]["���ٴθ��ٵĿͻ�"].ToString() + ")";
			this.lbt39.Text = "(" + dataTable.Rows[0]["���ڵ�"].ToString() + ")";
			this.lbt40.Text = "(" + dataTable.Rows[0]["��Ҫ���ڵ����޽���"].ToString() + ")";
			this.lbt41.Text = "(" + dataTable.Rows[0]["�ߵ�"].ToString() + ")";
		}
		if (!base.Request.Url.ToString().Trim().Contains("localhost"))
		{
			ScriptManager.RegisterStartupScript(this.main, this.main.GetType(), "ftime", "setTimeout('RefreshData()',60000);", true);
		}
	}
}
