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
				this.content = "<ul id=\"news\"><li><a href=\"#s\" style=\"color:#ff0000\">获取最新资讯失败……</a></li></ul>";
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
            this.lbt1.Text = "(" + dataTable.Rows[0]["报修审核"].ToString() + ")";
			this.Label2.Text = "(" + dataTable.Rows[0]["送修确认"].ToString() + ")";
			this.lbt3.Text = "(" + dataTable.Rows[0]["待处理"].ToString() + ")";
			this.lbt4.Text = "(" + dataTable.Rows[0]["处理中"].ToString() + ")";
			this.lbt5.Text = "(" + dataTable.Rows[0]["送修发货"].ToString() + ")";
			this.lbt6.Text = "(" + dataTable.Rows[0]["收货结算"].ToString() + ")";
			this.lbt7.Text = "(" + dataTable.Rows[0]["待结算"].ToString() + ")";
			this.lbt8.Text = "(" + dataTable.Rows[0]["待回访"].ToString() + ")";
            this.lbt9.Text = "(" + dataTable.Rows[0]["待审核"].ToString() + ")";
             this.lbt10.Text = "(" + dataTable.Rows[0]["高于警戒库存"].ToString() + ")";
        		this.lbt11.Text = "(" + dataTable.Rows[0]["低于警戒库存"].ToString() + ")";
			this.lbt12.Text = "(" + dataTable.Rows[0]["将要到期的商品"].ToString() + ")";
			this.lbt13.Text = "(" + dataTable.Rows[0]["已到期的商品"].ToString() + ")";
     		this.lbt14.Text = "(" + dataTable.Rows[0]["调拨审核"].ToString() + ")";
			this.lbt15.Text = "(" + dataTable.Rows[0]["调拨发货"].ToString() + ")";
			this.lbt16.Text = "(" + dataTable.Rows[0]["调拨签收"].ToString() + ")";
			this.lbt17.Text = "(" + dataTable.Rows[0]["调拨申请驳回"].ToString() + ")";
         			this.lbt18.Text = "(" + dataTable.Rows[0]["将到期借出"].ToString() + ")";
			this.lbt19.Text = "(" + dataTable.Rows[0]["到期应收款"].ToString() + ")";
			this.lbt20.Text = "(" + dataTable.Rows[0]["到期应付款"].ToString() + ")";
			this.lbt21.Text = "(" + dataTable.Rows[0]["将要到期的应收款"].ToString() + ")";
			this.lbt22.Text = "(" + dataTable.Rows[0]["将要到期的应付款"].ToString() + ")";
			this.lbt23.Text = "(" + dataTable.Rows[0]["未读邮件"].ToString() + ")";
      	this.lbt24.Text = "(" + dataTable.Rows[0]["要处理的服务单"].ToString() + ")";
			this.lbt25.Text = "(" + dataTable.Rows[0]["要跟踪的客户"].ToString() + ")";
			this.lbt26.Text = "(" + dataTable.Rows[0]["厂家保修到期的机器"].ToString() + ")";
			this.lbt27.Text = "(" + dataTable.Rows[0]["维修保修到期的机器"].ToString() + ")";
			this.lbt28.Text = "(" + dataTable.Rows[0]["维修保修将到期的机器"].ToString() + ")";
			this.lbt29.Text = "(" + dataTable.Rows[0]["将要到期的保养计划"].ToString() + ")";
      		this.lbt30.Text = "(" + dataTable.Rows[0]["将要到期的服务合同"].ToString() + ")";
			this.lbt31.Text = "(" + dataTable.Rows[0]["将要到期的租赁全保"].ToString() + ")";
			this.lbt32.Text = "(" + dataTable.Rows[0]["将要到期的耗材跟踪"].ToString() + ")";
			this.lbt33.Text = "(" + dataTable.Rows[0]["超期单"].ToString() + ")";
			this.lbt34.Text = "(" + dataTable.Rows[0]["今日员工生日"].ToString() + ")";
			this.lbt35.Text = "(" + dataTable.Rows[0]["今日客户生日"].ToString() + ")";
       		this.lbt36.Text = "(" + dataTable.Rows[0]["要处理的服务单"].ToString() + ")";
			this.lbt37.Text = "(" + dataTable.Rows[0]["将要到期的保养计划"].ToString() + ")";
			this.lbt38.Text = "(" + dataTable.Rows[0]["需再次跟踪的客户"].ToString() + ")";
			this.lbt39.Text = "(" + dataTable.Rows[0]["超期单"].ToString() + ")";
			this.lbt40.Text = "(" + dataTable.Rows[0]["将要到期的租赁结算"].ToString() + ")";
			this.lbt41.Text = "(" + dataTable.Rows[0]["催单"].ToString() + ")";
		}
		if (!base.Request.Url.ToString().Trim().Contains("localhost"))
		{
			ScriptManager.RegisterStartupScript(this.main, this.main.GetType(), "ftime", "setTimeout('RefreshData()',60000);", true);
		}
	}
}
