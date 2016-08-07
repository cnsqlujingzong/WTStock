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

public partial class Headquarters_Tool_SmsAdm : Page, IRequiresSessionState
{
	private int pageSize = 8;

	private int id;

	private int f;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		int.TryParse(base.Request["f"], out this.f);
		if (!base.IsPostBack)
		{
			DataTable dataSource = DALCommon.GetDataList("SmsTmp", "", "").Tables[0];
			this.gvdata.DataSource = dataSource;
			this.gvdata.DataBind();
			this.ddlTmp.DataSource = dataSource;
			this.ddlTmp.DataTextField = "Title";
			this.ddlTmp.DataValueField = "RecID";
			this.ddlTmp.DataBind();
			this.ddlTmp.Items.Insert(0, new ListItem("", ""));
			if (this.f > 0)
			{
				if (this.f == 1)
				{
					if (this.id > 0)
					{
						DataTable dataTable = DALCommon.GetDataList("ks_consumablestrack", "Tel", " [ID]=" + this.id).Tables[0];
						if (dataTable.Rows.Count > 0)
						{
							this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
						}
					}
				}
			}
			this.GridView1.DataSource = DALCommon.GetDataList("SmsStrategy", "", "");
			this.GridView1.DataBind();
			this.FillData();
			this.FillData1();
		}
	}

	protected void btnSnd_Click(object sender, EventArgs e)
	{
		DALSmsSnd dALSmsSnd = new DALSmsSnd();
		dALSmsSnd.Add(new SmsSndInfo
		{
			SndTo = this.tbTel.Text,
			Content = this.tbSmsContent.Text,
			SDate = DateTime.Now,
			SFlag = false,
			SenderID = int.Parse(this.Session["Session_wtUserID"].ToString())
		});
		this.SysInfo("window.alert(\"短信已经加入发送队列.\");");
		this.tbTel.Text = (this.tbSmsContent.Text = "");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
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

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('s" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "ts" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnRefTiming_Click(object sender, EventArgs e)
	{
		this.GridView1.DataSource = DALCommon.GetDataList("SmsStrategy", "", "");
		this.GridView1.DataBind();
	}

	protected void btnTimingDel_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse(this.hfRecID.Value.Replace("s", ""), out num);
		if (num > 0)
		{
			DALSmsStrategy dALSmsStrategy = new DALSmsStrategy();
			dALSmsStrategy.Delete(num);
		}
		this.GridView1.DataSource = DALCommon.GetDataList("SmsStrategy", "", "");
		this.GridView1.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnRefTmp_Click(object sender, EventArgs e)
	{
		this.gvdata.DataSource = DALCommon.GetDataList("SmsTmp", "", "");
		this.gvdata.DataBind();
	}

	protected void btnDelTmp_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse(this.hfRecID.Value, out num);
		if (num > 0)
		{
			DALSmsTmp dALSmsTmp = new DALSmsTmp();
			dALSmsTmp.Delete(num);
		}
		this.gvdata.DataSource = DALCommon.GetDataList("SmsTmp", "", "");
		this.gvdata.DataBind();
	}

	protected void FillData()
	{
		int recordCount = 0;
		this.GridView2.DataSource = DALCommon.GetList_HL(1, "xt_smssnd", "", this.pageSize, this.jsPager.CurrentPageIndex, "", " RecID Desc", out recordCount);
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
			e.Row.Attributes.Add("id", "snd" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('snd" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tsnd" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (this.jsPager.CurrentPageIndex - 1) * 8);
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.GridView2.Rows.Count.ToString();
		}
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void btnSndDel_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse(this.hfRecID.Value.Replace("snd", ""), out num);
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
		dALSmsSnd.DeleteALL("");
		this.FillData();
	}

	protected void FillData1()
	{
		int recordCount = 0;
		this.GridView3.DataSource = DALCommon.GetList_HL(1, "SmsRcv", "", this.pageSize, this.jsPagers.CurrentPageIndex, "", " RecID Desc", out recordCount);
		this.GridView3.DataBind();
		this.lbCount1.Text = recordCount.ToString();
		if (this.lbCount1.Text == "0")
		{
			this.lbCount1.Visible = false;
			this.lbPage1.Visible = false;
			this.lbCountText1.Visible = false;
		}
		else
		{
			this.lbCount1.Visible = true;
			this.lbPage1.Visible = true;
			this.lbCountText1.Visible = true;
		}
		this.jsPagers.PageSize = this.pageSize;
		this.jsPagers.RecordCount = recordCount;
	}

	protected void jsPagers_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData1();
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "rcv" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('rcv" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "trcv" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (this.jsPager.CurrentPageIndex - 1) * 8);
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage1.Text = "当前页:" + this.GridView3.Rows.Count.ToString();
		}
	}

	protected void btnFsh1_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData1();
	}

	protected void btnSndDel1_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse(this.hfRecID.Value.Replace("rcv", ""), out num);
		if (num > 0)
		{
			DALSmsRcv dALSmsRcv = new DALSmsRcv();
			dALSmsRcv.Delete(num);
		}
		this.FillData1();
	}

	protected void btnClean1_Click(object sender, EventArgs e)
	{
		DALSmsRcv dALSmsRcv = new DALSmsRcv();
		dALSmsRcv.DeleteALL();
		this.FillData1();
	}
}
