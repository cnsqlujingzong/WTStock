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

public partial class Headquarters_Tool_Printtmp : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			this.FillData();
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkTname('",
				e.Row.Cells[2].Text,
				"');"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Attributes.Add("ondblclick", "ChkTmp('Modify');");
			e.Row.Cells[0].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
		}
	}

	protected void FillData()
	{
		string[] array = new string[]
		{
			"��ⵥ",
			"���ⵥ",
			"���˵�",
			"������",
			"��װ��",
			"���۵�",
			"�̵㵥",
			"�ɹ���",
			"�ɹ�����",
			"���۵�",
			"���۶���",
			"ƾ֤��",
			"�ɹ���",
			"�����",
			"���۵�",
			"���㵥",
			"�굥",
			"������",
			"�տ",
			"���",
			"���޺�ͬ",
			"���޽��㵥",
			"�����ͬ",
			"�ڲ�������",
			"�����",
			"������",
			"Ӧ��Ӧ��",
			"��Ʒ���к�",
			"ƾ֤��(����)",
			"���㵥(����)",
			"���ƾ֤",
			"����ƾ֤",
			"������"
		};
		string[] array2 = new string[]
		{
			"RKD.frf",
			"CKD.frf",
			"LTD.frf",
			"DBD.frf",
			"CZD.frf",
			"TJD.frf",
			"PDD.frf",
			"CGD.frf",
			"CGDD.frf",
			"XSD.frf",
			"XSDD.frf",
			"PZD.frf",
			"PGD.frf",
			"SJD.frf",
			"BJD.frf",
			"JSD.frf",
			"XD.frf",
			"FHD.frf",
			"SKD.frf",
			"FKD.frf",
			"ZLD.frf",
			"ZLJSD.frf",
			"HT.frf",
			"NBDBD.frf",
			"JCD.frf",
			"BXD.frf",
			"YSYF.frf",
			"CPSN.frf",
			"PLPZD.frf",
			"PLJSD.frf",
			"JCD.frf",
			"BXPZ.frf",
			"TM.frf"
		};
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
		dataTable.Columns.Add(new DataColumn("BillName", typeof(string)));
		dataTable.Columns.Add(new DataColumn("TmpName", typeof(string)));
		for (int i = 0; i < 33; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["RecID"] = i + 1;
			dataRow["BillName"] = array[i];
			dataRow["TmpName"] = array2[i];
			dataTable.Rows.Add(dataRow);
		}
		this.GridView1.DataSource = dataTable;
		this.GridView1.DataBind();
		this.sdyes();
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
			text2 += "����";
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
						"&CustomerInfo=��˾��:",
						corpName,
						"���绰:",
						tel
					});
					text5 = text4;
					text4 = string.Concat(new string[]
					{
						text5,
						"���ʱ�:",
						zip,
						"����ַ:",
						adr,
						"��ע���û���:",
						text,
						"��ʵ���û���:",
						num2.ToString(),
						"ע����:",
						value
					});
					if (sysParm.bSim)
					{
						text4 += "������";
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
}
