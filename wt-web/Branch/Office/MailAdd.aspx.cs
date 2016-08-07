using System;
using System.Collections.Generic;
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

public partial class Branch_Office_MailAdd : Page, IRequiresSessionState
{
	

	private int id;

	
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r7"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			if (base.Request.QueryString["id"] == null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append('\r'.ToString());
				stringBuilder.Append('\r'.ToString());
				stringBuilder.Append("xxx，您好");
				for (int i = 0; i <= 10; i++)
				{
					stringBuilder.Append('\r'.ToString());
				}
				stringBuilder.Append("==============================");
				stringBuilder.Append('\r'.ToString());
				stringBuilder.Append("  发件人：" + (string)this.Session["Session_wtUserB"] + "  时间：" + DateTime.Now.ToString());
				this.tbContent.Text = stringBuilder.ToString();
				this.tbContent.Attributes.Add("old", "xxx");
			}
			else
			{
				int.TryParse(base.Request.QueryString["id"].ToString(), out this.id);
				if (this.id != 0)
				{
					string text = base.Request.QueryString["f"];
					if (text == null || text == "")
					{
						base.Response.End();
					}
					DALOA_Mail dALOA_Mail = new DALOA_Mail();
					OA_EmailInfo model = dALOA_Mail.GetModel(this.id);
					if (model != null)
					{
						this.tbRcv.Text = ((text == "0") ? model.Snd : "");
						this.tbTitle.Text = ((text == "0") ? "回复：" : "转发：");
						TextBox expr_288 = this.tbTitle;
						expr_288.Text += model.Title;
						StringBuilder stringBuilder2 = new StringBuilder();
						if (text == "0")
						{
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append(model.Snd + "，您好");
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append(">>>>>>>>>>" + model._Date + "您在来信中写到>>>>>>>>");
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append(model.Content);
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append("==============================");
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append("  发件人：" + (string)this.Session["Session_wtUserB"] + "  时间：" + DateTime.Now.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							this.tbContent.Text = stringBuilder2.ToString();
							this.tbContent.Attributes.Add("old", "xxx");
						}
						if (text == "1")
						{
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append("xxx，您好");
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append(">>>>>>>>>>>>>>>以下是转发邮件>>>>>>>>>>>>>");
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append(model.Content);
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append("==============================");
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append("  发件人：" + (string)this.Session["Session_wtUserB"] + "  时间：" + DateTime.Now.ToString());
							stringBuilder2.Append('\r'.ToString());
							stringBuilder2.Append('\r'.ToString());
							this.tbContent.Text = stringBuilder2.ToString();
							this.tbContent.Attributes.Add("old", "xxx");
							if (model.bAccessory)
							{
								string listStr = dALOA_Mail.GetListStr("MailID='" + model.ID + "'");
								string[] array = listStr.Split(new char[]
								{
									','
								});
								StringBuilder stringBuilder = new StringBuilder();
								for (int i = 0; i < array.Length; i++)
								{
									if (i == 0)
									{
										this.hfUpload1.Value = array[0];
									}
									else if (i == 1)
									{
										this.hfUpload2.Value = array[1];
									}
									else if (i == 2)
									{
										this.hfUpload3.Value = array[2];
									}
									stringBuilder.Append(string.Concat(new string[]
									{
										"<img src='../../Public/Images/dmony.gif' /> <a href=../../Headquarters/Document/",
										array[i],
										" target=_blank >附件",
										Convert.ToString(i + 1),
										"</a>"
									}));
								}
								this.dUpload.InnerHtml = stringBuilder.ToString();
							}
						}
					}
				}
			}
		}
	}

	protected void btnSend_Click(object sender, EventArgs e)
	{
		this.MailSend(1);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.MailSend(0);
	}

	protected void MailSend(int flag)
	{
		DALOA_Mail dALOA_Mail = new DALOA_Mail();
		DALStaffList dALStaffList = new DALStaffList();
		string[] array = this.tbRcv.Text.Trim().Split(new char[]
		{
			','
		});
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int iD = dALStaffList.GetID(array[i]);
			if (iD > 0)
			{
				OA_EmailInfo oA_EmailInfo = new OA_EmailInfo();
				oA_EmailInfo.Title = FunLibrary.ChkInput(this.tbTitle.Text);
				oA_EmailInfo.Content = FunLibrary.ChkInput(this.tbContent.Text);
				oA_EmailInfo.SndID = new int?(int.Parse((string)this.Session["Session_wtUserBID"]));
				oA_EmailInfo.RcvID = new int?(iD);
				oA_EmailInfo.bAccessory = !(this.hfUpload1.Value == "");
				oA_EmailInfo.bSndFlag = new int?(flag);
				if (flag == 1)
				{
					oA_EmailInfo.bRcvFlag = new int?(0);
				}
				List<OA_MailAccessoryInfo> list = new List<OA_MailAccessoryInfo>();
				if (this.hfUpload1.Value != string.Empty)
				{
					list.Add(new OA_MailAccessoryInfo
					{
						FilePath = this.hfUpload1.Value
					});
				}
				if (this.hfUpload2.Value != string.Empty)
				{
					list.Add(new OA_MailAccessoryInfo
					{
						FilePath = this.hfUpload2.Value
					});
				}
				if (this.hfUpload3.Value != string.Empty)
				{
					list.Add(new OA_MailAccessoryInfo
					{
						FilePath = this.hfUpload3.Value
					});
				}
				oA_EmailInfo.OA_MailAccessoryInfos = list;
				dALOA_Mail.Add(oA_EmailInfo, out num2);
				num++;
			}
		}
		if (flag == 1)
		{
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert('[",
				num.ToString(),
				"]封邮件发送成功，[",
				Convert.ToString(array.Length - num),
				"]封邮件发送失败！');parent.CloseDialog('1');"
			}));
		}
		else
		{
			this.SysInfo("window.alert('[" + num.ToString() + "]封邮件成功保存到发件箱！');parent.CloseDialog('1');");
		}
	}
}
