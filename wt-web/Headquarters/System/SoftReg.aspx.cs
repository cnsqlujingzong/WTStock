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

public partial class Headquarters_System_SoftReg : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPur"] != "ϵͳ����Ա")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=Right");
				base.Response.End();
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo sysParm = dALSysParm.GetSysParm();
			if (sysParm != null)
			{
				this.tbName.Text = sysParm.CorpName;
				this.tbTel.Text = sysParm.Tel;
				this.tbZip.Text = sysParm.Zip;
				this.tbAdr.Text = sysParm.Adr;
				this.tbBranchNum.Text = sysParm.BranchNum.ToString();
				this.ddlbSim.SelectedValue = (sysParm.bSim ? "1" : "0");
				for (int i = 0; i < this.ddlWeb.Items.Count; i++)
				{
					if (this.ddlWeb.Items[i].Value == sysParm.bWeb.ToString())
					{
						this.ddlWeb.Items[i].Selected = true;
						break;
					}
				}
			}
			DALSysVali dALSysVali = new DALSysVali();
			string value = dALSysVali.GetValue("ITEM2");
			this.tbRegCode.Text = value;
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (this.tbName.Text.Trim() == string.Empty)
		{
			this.SysInfo("alert('��˾���Ʋ����ǿ�.');");
		}
		else
		{
			int num = 0;
			int.TryParse(this.tbBranchNum.Text.Trim(), out num);
			if (num == 0 || num > 99999)
			{
				this.SysInfo("alert('�û�����ʽ����ȷ.1-99999֮��');");
			}
			else
			{
				string text = FunLibrary.RndStr(16);
				string text2 = string.Empty;
				try
				{
					string text3 = "code=" + text + "&product=άͨ.net(ITר��)";
					string text4 = text3;
					text3 = string.Concat(new string[]
					{
						text4,
						"&CustomerInfo=��˾����:",
						this.tbName.Text.Trim(),
						"���绰:",
						this.tbTel.Text.Trim()
					});
					text4 = text3;
					text3 = string.Concat(new string[]
					{
						text4,
						"���ʱ�:",
						this.tbZip.Text.Trim(),
						"����ַ:",
						this.tbAdr.Text.Trim(),
						"���û���:",
						this.tbBranchNum.Text.Trim()
					});
					if (this.ddlbSim.SelectedValue.Trim().Equals("1"))
					{
						text3 += "������";
					}
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(text3);
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.differsoft.com/customerinfopost.asp");
					httpWebRequest.Method = "POST";
					httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
					httpWebRequest.ContentLength = (long)bytes.Length;
					Stream requestStream = httpWebRequest.GetRequestStream();
					requestStream.Write(bytes, 0, bytes.Length);
					requestStream.Close();
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("GB2312"));
					text2 = streamReader.ReadToEnd();
					requestStream.Dispose();
					streamReader.Dispose();
				}
				catch
				{
					this.SysInfo("window.alert('ע����Ϣ�ݽ�ʧ�ܣ�������');");
					return;
				}
				if (text2.ToLower() == "ok")
				{
					this.UpdateSys();
					DALSysVali dALSysVali = new DALSysVali();
					dALSysVali.Update("ITEM4", text);
					this.SysInfo("window.alert('ע����Ϣ�ݽ��ݽ��ɹ����벻Ҫ�ظ��ݽ�');");
				}
			}
		}
	}

	protected void btnGet_Click(object sender, EventArgs e)
	{
		DALSysVali dALSysVali = new DALSysVali();
		string value = dALSysVali.GetValue("ITEM4");
		string text = string.Empty;
		if (value != string.Empty)
		{
			try
			{
				string requestUriString = "http://www.differsoft.com/getregcode.asp?code=" + value;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Method = "GET";
				httpWebRequest.MaximumAutomaticRedirections = 3;
				httpWebRequest.Timeout = 5000;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				text = streamReader.ReadToEnd();
				streamReader.Dispose();
				responseStream.Dispose();
			}
			catch
			{
				this.SysInfo("window.alert('���ע����ʧ��.');");
				return;
			}
			if (text != string.Empty)
			{
				this.tbRegCode.Text = text;
			}
			else
			{
				this.SysInfo("window.alert('ע����δ���䣬�Ժ�����.');");
			}
		}
		else
		{
			this.SysInfo("window.alert('����δ�ύע����Ϣ.');");
		}
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.UpdateSys();
		if (this.tbRegCode.Text.Trim() == string.Empty)
		{
			this.SysInfo("window.alert('������ע����.');");
		}
		else
		{
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo sysParm = dALSysParm.GetSysParm();
			string corpName = sysParm.CorpName;
			string text = sysParm.BranchNum.ToString();
			string s = DALCommon.TCount("UserManage", "");
			if (!sysParm.bSim && int.Parse(s) > int.Parse(text))
			{
				this.SysInfo("window.alert('���ʵ���û����Ѿ�����ϵͳ�����е��û���.');");
			}
			else
			{
				string text2 = this.tbRegCode.Text.Trim();
				string text3 = corpName + this.ddlWeb.SelectedValue + text;
				if (sysParm.bSim)
				{
					text3 += "����";
				}
				string b = FunLibrary.EncodeReg(text3);
				if (text2 == b)
				{
					DALSysVali dALSysVali = new DALSysVali();
					dALSysVali.Update("ITEM2", text2);
					this.SysInfo("window.alert('ע��ɹ�����л��ʹ�����ǵĲ�Ʒ��');parent.document.getElementById('hfAdmin').value='';parent.CloseDialog();");
				}
				else
				{
					this.SysInfo("window.alert('ע���벻��ȷ.');");
				}
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void UpdateSys()
	{
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParmInfo = new SysParmInfo();
		sysParmInfo.ID = 1;
		sysParmInfo.CorpName = this.tbName.Text;
		sysParmInfo.Tel = this.tbTel.Text;
		sysParmInfo.Adr = this.tbAdr.Text;
		sysParmInfo.Zip = this.tbZip.Text;
		sysParmInfo.bSim = this.ddlbSim.SelectedValue.Trim().Equals("1");
		int branchNum = 0;
		int.TryParse(this.tbBranchNum.Text, out branchNum);
		sysParmInfo.BranchNum = branchNum;
		sysParmInfo.bWeb = int.Parse(this.ddlWeb.SelectedValue);
		dALSysParm.Update2(sysParmInfo);
		dALSysParm.Update3(sysParmInfo);
	}
}
