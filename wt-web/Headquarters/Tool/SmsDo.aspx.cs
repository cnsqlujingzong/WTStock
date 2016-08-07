using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;
using Wuqi.Webdiyer;

public partial class Headquarters_Tool_SmsDo : Page, IRequiresSessionState
{
	private int pageSize = 10;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.SndStyle == 1)
			{
				base.Response.Write("请设置发送模式为【网关】后操作！如果发送模式为【短信猫】不需要在此做发送处理.");
				base.Response.End();
			}
			else
			{
				this.FillData();
			}
		}
	}

	protected void FillData()
	{
		int recordCount = 0;
		this.GridView2.DataSource = DALCommon.GetList_HL(1, "xt_smssnd", "", this.pageSize, this.jsPager.CurrentPageIndex, " SFlag='待发送' ", " RecID Desc", out recordCount);
		this.GridView2.DataBind();
		this.lbCount.Text = recordCount.ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
			this.lbCountText.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
			this.lbCountText.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (this.jsPager.CurrentPageIndex - 1) * 10);
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.GridView2.Rows.Count.ToString();
		}
	}

	protected void btnSndDel_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse(this.hfRecID.Value, out num);
		if (num > 0)
		{
			DALSmsSnd dALSmsSnd = new DALSmsSnd();
			dALSmsSnd.Delete(num);
		}
		this.FillData();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		DALSmsSnd dALSmsSnd = new DALSmsSnd();
		dALSmsSnd.DeleteALL("SFlag='待发送'");
		this.FillData();
	}

	protected void btnSnd_Click(object sender, EventArgs e)
	{
		DataTable dataTable = DALCommon.GetDataList("xt_smssnd", "", " SFlag='待发送' ").Tables[0];
		if (dataTable.Rows.Count == 0)
		{
			this.SysInfo("window.alert('操作失败！没有要发送的短信');");
			this.FillData();
		}
		else
		{
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			DALSmsSnd dALSmsSnd = new DALSmsSnd();
			int num = 0;
			int num2 = 0;
			string text = FunLibrary.StringMd5(model.UserPwd);
			string text2 = HttpUtility.UrlEncode(model.UserName, Encoding.UTF8);
			Stream stream = null;
			StreamReader streamReader = null;
			try
			{
				string requestUriString = "http://www.differsoft.com/API/smsAPI.aspx?Msg=smsAU&User=" + text2 + "&PWD=" + text;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Method = "GET";
				httpWebRequest.MaximumAutomaticRedirections = 3;
				httpWebRequest.Timeout = 5000;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				stream = httpWebResponse.GetResponseStream();
				streamReader = new StreamReader(stream);
				string a = streamReader.ReadToEnd();
				if (!(a == "1"))
				{
					streamReader.Dispose();
					stream.Dispose();
					this.SysInfo("window.alert('用户名验证失败，请确认用户名密码是否正确！');");
					this.FillData();
					return;
				}
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					requestUriString = string.Concat(new string[]
					{
						"http://www.differsoft.com/API/smsAPI.aspx?Msg=smsSnd&User=",
						text2,
						"&PWD=",
						text,
						"&Tel=",
						HttpUtility.UrlEncode(dataTable.Rows[i]["SndTo"].ToString(), Encoding.UTF8),
						"&Body=",
						HttpUtility.UrlEncode(dataTable.Rows[i]["Content"].ToString(), Encoding.UTF8)
					});
					httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
					httpWebRequest.Method = "GET";
					httpWebRequest.MaximumAutomaticRedirections = 3;
					httpWebRequest.Timeout = 5000;
					httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					stream = httpWebResponse.GetResponseStream();
					streamReader = new StreamReader(stream);
					a = streamReader.ReadToEnd();
					if (a == "1")
					{
						dALSmsSnd.Update(int.Parse(dataTable.Rows[i]["RecID"].ToString()), DateTime.Now);
						num++;
					}
					else
					{
						num2++;
					}
				}
			}
			catch
			{
				streamReader.Dispose();
				stream.Dispose();
				this.SysInfo("window.alert('短信接口未响应，请稍后重试！');");
				this.FillData();
				return;
			}
			streamReader.Dispose();
			stream.Dispose();
			string text3 = "已成功发送" + num + "条短信！";
			if (num2 > 0)
			{
				object obj = text3;
				text3 = string.Concat(new object[]
				{
					obj,
					"失败",
					num2,
					"条。失败原因：余额不足或手机地址不可达。"
				});
			}
			this.SysInfo("window.alert('" + text3 + "');");
			this.FillData();
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
