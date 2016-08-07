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

public partial class Branch_Tool_SmsAdm : Page, IRequiresSessionState
{
	
	private int id;

	private int f;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		int.TryParse(base.Request["f"], out this.f);
		if (!base.IsPostBack)
		{
			DataTable dataSource = DALCommon.GetDataList("SmsTmp", "", "").Tables[0];
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
			SenderID = int.Parse(this.Session["Session_wtUserBID"].ToString())
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
}
