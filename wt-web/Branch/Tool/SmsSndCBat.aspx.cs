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
using Wuqi.Webdiyer;

public partial class Branch_Tool_SmsSndCBat : Page, IRequiresSessionState
{
	private string strfid;

	private int pageSize = 6;



	public string Str_Fid
	{
		get
		{
			return this.strfid;
		}
	}

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.strfid = base.Request["fid"];
		if (this.strfid == null || this.strfid == "")
		{
			base.Response.Write("系统参数错误！请按F5刷新软件或退出重新登录操作！");
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DataTable dataSource = DALCommon.GetDataList("SmsTmp", "", "").Tables[0];
			this.ddlTmp.DataSource = dataSource;
			this.ddlTmp.DataTextField = "Title";
			this.ddlTmp.DataValueField = "RecID";
			this.ddlTmp.DataBind();
			this.ddlTmp.Items.Insert(0, new ListItem("", ""));
		}
	}

	protected void ddlTmp_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlTmp.SelectedValue != string.Empty)
		{
			DALSmsTmp dALSmsTmp = new DALSmsTmp();
			SmsTmpInfo model = dALSmsTmp.GetModel(int.Parse(this.ddlTmp.SelectedValue));
			string text = model.Content;
			text = text.Replace("{客户名称}", "");
			text = text.Replace("{客户电话}", "");
			text = text.Replace("{客户地址}", "");
			text = text.Replace("{联系人}", "");
			text = text.Replace("{机器品牌}", "");
			text = text.Replace("{机器类别}", "");
			text = text.Replace("{机器型号}", "");
			text = text.Replace("{序列号}", "");
			text = text.Replace("{故障描述}", "");
			text = text.Replace("{预报价}", "");
			text = text.Replace("{保修情况}", "");
			text = text.Replace("{购买日期}", "");
			text = text.Replace("{技术员}", "");
			text = text.Replace("{物流单号}", "");
			text = text.Replace("{货品摘要}", "");
			text = text.Replace("{货运方式}", "");
			this.tbSmsContent.Text = text;
		}
	}

	protected void FillData()
	{
		int num = 0;
		string text = string.Format("id in(select id from ks_customer where {0})", this.hfSql.Value);
		if (this.ddlSendTo.SelectedValue == "1")
		{
			text += " and t='c' ";
		}
		else if (this.ddlSendTo.SelectedValue == "2")
		{
			text += " and t='l' ";
		}
		if (!this.tbSchWord.Text.Trim().Equals(""))
		{
			text += string.Format(" and (cusname like '%{0}%' or linkman like '%{0}%' or tel like '%{0}%')", this.tbSchWord.Text.Trim());
		}
		DataSet list_HL = DALCommon.GetList_HL(1, "ks_cusmobilelist", "", this.pageSize, this.jsPager.CurrentPageIndex, text, "id", out num);
		list_HL.Tables[0].Columns.Add("bexcept");
		for (int i = 0; i < list_HL.Tables[0].Rows.Count; i++)
		{
			string value = "," + list_HL.Tables[0].Rows[i]["t"].ToString().Trim() + list_HL.Tables[0].Rows[i]["lid"].ToString().Trim() + ",";
			if (this.hfExcept.Value.Contains(value))
			{
				list_HL.Tables[0].Rows[i]["bexcept"] = "1";
			}
		}
		this.gvdata.DataSource = list_HL;
		this.gvdata.DataBind();
		this.lbCount.Text = num.ToString();
		int num2 = this.hfExcept.Value.Trim().Trim(new char[]
		{
			','
		}).Equals("") ? 0 : this.hfExcept.Value.Trim().Trim(new char[]
		{
			','
		}).Split(new char[]
		{
			','
		}).Length;
		this.tbTel.Text = "发送到" + (num - num2) + "个客户.";
		this.hfSndCount.Value = (num - num2).ToString();
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
		this.jsPager.RecordCount = num;
	}

	protected void btnSnd_Click(object sender, EventArgs e)
	{
		string text = string.Format("id in(select id from ks_customer where {0})", this.hfSql.Value);
		if (this.ddlSendTo.SelectedValue == "1")
		{
			text += " and t='c' ";
		}
		else if (this.ddlSendTo.SelectedValue == "2")
		{
			text += " and t='l' ";
		}
		DataTable dataTable = DALCommon.GetDataList("ks_cusmobilelist", "lid,t,Tel", text).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			int num = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				string sndTo = dataTable.Rows[i]["Tel"].ToString();
				string value = "," + dataTable.Rows[i]["t"].ToString().Trim() + dataTable.Rows[i]["lid"].ToString().Trim() + ",";
				if (!this.hfExcept.Value.Contains(value))
				{
					SmsSndInfo smsSndInfo = new SmsSndInfo();
					smsSndInfo.SndTo = sndTo;
					smsSndInfo.Content = this.tbSmsContent.Text;
					smsSndInfo.SDate = DateTime.Now;
					smsSndInfo.SFlag = false;
					DALSmsSnd dALSmsSnd = new DALSmsSnd();
					dALSmsSnd.Add(smsSndInfo);
					num++;
				}
			}
			this.SysInfo("window.alert('" + num.ToString() + "条短信已经加入发送队列.');parent.CloseDialog();");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void ddlSendTo_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.FillData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string text = e.Row.Cells[0].Text + e.Row.Cells[1].Text;
			e.Row.Attributes["id"] = text;
			if (this.hfExcept.Value.Contains("," + text + ","))
			{
				e.Row.CssClass = "trcross";
			}
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.FillData();
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}
}
