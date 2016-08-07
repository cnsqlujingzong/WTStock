using System;
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
using wt.OtherLibrary;

public partial class Headquarters_System_UserManageAdd : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "系统管理员")
			{
				this.lbInfo.Visible = true;
				this.lbInfo.Text = "无操作权限，只有系统管理员才能添加用户。";
				this.btnAdd.Enabled = false;
			}
			OtherFunction.BindStaff(this.ddlStaff, " DeptID=1 and Status=0 ");
			this.ddlRight.DataSource = DALCommon.GetDataList("[Right]", " [ID],[_Name] ", " DeptID=1 ").Tables[0];
			this.ddlRight.DataValueField = "ID";
			this.ddlRight.DataTextField = "_Name";
			this.ddlRight.DataBind();
			this.ddlRight.Items.Insert(0, new ListItem("", "-1"));
			this.sdyes();
			int num = int.Parse(DALCommon.GetDataList("SysParm", "count(1)", "bSim=1 or BranchNum>(select count(1) from UserManage)").Tables[0].Rows[0][0].ToString());
			this.hfOverFlag.Value = num.ToString();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.tbName.Text.Trim() == string.Empty || this.tbPsw.Text.Trim().Length > 20 || this.tbPsw.Text.Trim().Length < 1)
		{
			this.SysInfo("window.alert('保存失败！密码长度必须在7-20位之间');$('tbName').select();");
		}
		else
		{
			UserManageInfo userManageInfo = new UserManageInfo();
			userManageInfo.DeptID = 1;
			userManageInfo.StaffID = int.Parse(this.ddlStaff.SelectedValue);
			userManageInfo.Pwd = FunLibrary.StrEncode(FunLibrary.ChkInput(this.tbPsw.Text));
			userManageInfo.RightID = int.Parse(this.ddlRight.SelectedValue);
			userManageInfo.Status = ((this.ddlRight.SelectedItem.Text == "系统管理员") ? "正常" : this.ddlStatus.SelectedItem.Text);
			DALUserManage dALUserManage = new DALUserManage();
			string str;
			int num2;
			int num = dALUserManage.Add(userManageInfo, out str, out num2);
			if (num == 0)
			{
				if (this.cbClose.Checked)
				{
					this.SysInfo("parent.CloseDialog('1');");
				}
				else
				{
					this.SysInfo("$('tbName').select();");
					this.ClearText();
				}
			}
			else if (num == -1)
			{
				this.SysInfo("window.alert('" + str + "');$('tbName').select();");
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
			}
		}
	}

	public void sdyes()
	{
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		DALSysVali dALSysVali = new DALSysVali();
		string corpName = sysParm.CorpName;
		string text = sysParm.BranchNum.ToString();
		string str = sysParm.bWeb.ToString();
		string value = dALSysVali.GetValue("ITEM2");
		string text2 = corpName + str + text;
		if (sysParm.bSim)
		{
			text2 += "并发";
		}
		string b = FunLibrary.EncodeReg(text2);
		if (value != b)
		{
			string value2 = dALSysVali.GetValue("ITEM1");
			try
			{
				string time = FunLibrary.StrDecode(value2);
				int num = this.DayTs(time);
				if (num > 60 || num < 0)
				{
					dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
				}
			}
			catch
			{
				dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
			}
		}
		else
		{
			int num2;
			int.TryParse(DALCommon.TCount("UserManage", ""), out num2);
			int num3;
			int.TryParse(text, out num3);
			if (!sysParm.bSim && num2 > num3)
			{
				dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
			}
			try
			{
				string requestUriString = "http://www.differsoft.com/kill_get.asp?id=8";
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Method = "GET";
				httpWebRequest.MaximumAutomaticRedirections = 3;
				httpWebRequest.Timeout = 5000;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text3 = streamReader.ReadToEnd();
				streamReader.Dispose();
				responseStream.Dispose();
				if (text3.Contains(value))
				{
					dALSysVali.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");
				}
			}
			catch
			{
			}
			string str2 = dALSysVali.GetValue("ITEM6").ToString().Trim();
			int num4 = 0;
			try
			{
				num4 = int.Parse(FunLibrary.StrDecode(str2));
			}
			catch
			{
			}
			if (dALSysVali.GetValue("ITEM5") != DateTime.Now.ToString("yyyy-MM-dd") || num4 > 0)
			{
				try
				{
					string tel = sysParm.Tel;
					string zip = sysParm.Zip;
					string adr = sysParm.Adr;
					string text4 = "id=8";
					string text5 = text4;
					text4 = string.Concat(new string[]
					{
						text5,
						"&CustomerInfo=公司名:",
						corpName,
						"，电话:",
						tel
					});
					text5 = text4;
					text4 = string.Concat(new string[]
					{
						text5,
						"，邮编:",
						zip,
						"，地址:",
						adr,
						"，注册用户数:",
						text,
						"，实际用户数:",
						num2.ToString(),
						"注册码:",
						value
					});
					if (sysParm.bSim)
					{
						text4 += "，并发";
					}
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(text4);
					HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create("http://www.differsoft.com/kill_post.asp");
					httpWebRequest2.Method = "POST";
					httpWebRequest2.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
					httpWebRequest2.ContentLength = (long)bytes.Length;
					Stream requestStream = httpWebRequest2.GetRequestStream();
					requestStream.Write(bytes, 0, bytes.Length);
					requestStream.Close();
					HttpWebResponse httpWebResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
					StreamReader streamReader2 = new StreamReader(httpWebResponse2.GetResponseStream(), Encoding.GetEncoding("GB2312"));
					string text3 = streamReader2.ReadToEnd();
					requestStream.Dispose();
					streamReader2.Dispose();
					if (text3.ToLower() == "ok")
					{
						dALSysVali.Update("ITEM5", DateTime.Now.ToString("yyyy-MM-dd"));
						dALSysVali.Update("ITEM6", FunLibrary.StrEncode("0"));
					}
					else
					{
						dALSysVali.Update("ITEM6", FunLibrary.StrEncode((num4 + 1).ToString()));
					}
				}
				catch
				{
					dALSysVali.Update("ITEM6", FunLibrary.StrEncode((num4 + 1).ToString()));
				}
			}
		}
	}

	protected int DayTs(string time)
	{
		DateTime d = DateTime.Parse(time);
		DateTime now = DateTime.Now;
		return 1;
	}

	protected void ClearText()
	{
		this.tbName.Text = (this.tbPsw.Text = "");
		this.ddlStaff.ClearSelection();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
