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

public partial class Headquarters_Customer_AssAdd : Page, IRequiresSessionState
{

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r3"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.ddlTmp.DataSource = DALCommon.GetDataList("SmsTmp", "", "").Tables[0];
			this.ddlTmp.DataTextField = "Title";
			this.ddlTmp.DataValueField = "RecID";
			this.ddlTmp.DataBind();
			this.ddlTmp.Items.Insert(0, new ListItem("", ""));
		}
	}

	protected void cbSms_CheckedChanged(object sender, EventArgs e)
	{
		if (this.cbSms.Checked)
		{
			this.ddlTmp.Enabled = true;
			this.tbContent.Enabled = true;
		}
		else
		{
			this.ddlTmp.Enabled = false;
			this.tbContent.Enabled = false;
		}
	}

	protected void ddlTmp_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.ddlTmp.SelectedValue != string.Empty)
		{
			DALSmsTmp dALSmsTmp = new DALSmsTmp();
			SmsTmpInfo model = dALSmsTmp.GetModel(int.Parse(this.ddlTmp.SelectedValue));
			string text = model.Content;
			text = text.Replace("{�ͻ��绰}", "");
			text = text.Replace("{�ͻ���ַ}", "");
			text = text.Replace("{����Ʒ��}", "");
			text = text.Replace("{�������}", "");
			text = text.Replace("{�����ͺ�}", "");
			text = text.Replace("{���к�}", "");
			text = text.Replace("{��������}", "");
			text = text.Replace("{Ԥ����}", "");
			text = text.Replace("{�������}", "");
			text = text.Replace("{��������}", "");
			text = text.Replace("{����Ա}", "");
			text = text.Replace("{��������}", "");
			text = text.Replace("{��ƷժҪ}", "");
			text = text.Replace("{���˷�ʽ}", "");
			if (this.tbPwd.Text != "")
			{
				text = text + " ��ʼ���룺" + this.tbPwd.Text;
			}
			this.tbContent.Text = text;
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALAssociator dALAssociator = new DALAssociator();
		DataTable dataTable = DALCommon.GetDataList("ks_customer", "", this.hfSql.Value).Tables[0];
		string text = "";
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				AssociatorInfo associatorInfo = new AssociatorInfo();
				string text2 = FunLibrary.ChkInput(dataTable.Rows[i]["LinkMan"].ToString());
				if (text2 != "")
				{
					string password = FunLibrary.ChkInput(this.tbPwd.Text);
					string company = FunLibrary.ChkInput(dataTable.Rows[i]["_Name"].ToString());
					string linkMan = FunLibrary.ChkInput(dataTable.Rows[i]["LinkMan"].ToString());
					string text3 = FunLibrary.ChkInput(dataTable.Rows[i]["Tel"].ToString());
					string adr = FunLibrary.ChkInput(dataTable.Rows[i]["Adr"].ToString());
					int customerID = 0;
					int.TryParse(dataTable.Rows[i]["ID"].ToString(), out customerID);
					associatorInfo.CustomerID = customerID;
					associatorInfo._Name = text2;
					associatorInfo.Password = password;
					associatorInfo.LinkMan = linkMan;
					associatorInfo.Company = company;
					associatorInfo.Adr = adr;
					associatorInfo.Tel = text3;
					associatorInfo.Email = FunLibrary.ChkInput(dataTable.Rows[i]["Email"].ToString());
					associatorInfo.iFlag = true;
					int num4 = dALAssociator.Add(associatorInfo, out text, out num);
					if (num4 == 0)
					{
						num2++;
						if (this.cbSms.Checked)
						{
							string text4 = string.Empty;
							string text5 = dataTable.Rows[i]["Tel2"].ToString();
							if (text3.Length == 11)
							{
								if (text3.Substring(0, 2) == "13" || text3.Substring(0, 2) == "15")
								{
									text4 = text3;
								}
							}
							if (text4 == string.Empty)
							{
								if (text5.Length == 11)
								{
									if (text5.Substring(0, 2) == "13" || text5.Substring(0, 2) == "15")
									{
										text4 = text5;
									}
								}
							}
							if (text4 != string.Empty)
							{
								SmsSndInfo smsSndInfo = new SmsSndInfo();
								string text6 = FunLibrary.ChkInput(this.tbContent.Text);
								text6 = text6.Replace("{�ͻ�����}", dataTable.Rows[i]["_Name"].ToString());
								text6 = text6.Replace("{��ϵ��}", dataTable.Rows[i]["LinkMan"].ToString());
								smsSndInfo.SndTo = text4;
								smsSndInfo.Content = text6;
								smsSndInfo.SDate = DateTime.Now;
								smsSndInfo.SFlag = false;
								DALSmsSnd dALSmsSnd = new DALSmsSnd();
								dALSmsSnd.Add(smsSndInfo);
							}
						}
					}
					else
					{
						num3++;
					}
				}
			}
			if (num3 == 0)
			{
				this.SysInfo("window.alert('�����ɹ���������" + num2 + "��Ա��Ϣ');parent.CloseDialog('1');parent.CloseDialog1();");
			}
			else if (num2 == 0)
			{
				this.SysInfo("window.alert('����ʧ�ܣ�" + num3 + "����Ա��Ϣ����ʧ�ܣ�ʧ��ԭ�򣺻�Ա�����Ѿ�����');parent.CloseDialog('1');parent.CloseDialog1();");
			}
			else
			{
				this.SysInfo(string.Concat(new object[]
				{
					"window.alert('����ʧ�ܣ�������",
					num2,
					"��Ա��Ϣ.ʧ��",
					num3,
					"����ʧ��ԭ�򣺻�Ա�����Ѿ�����');parent.CloseDialog('1');parent.CloseDialog1();"
				}));
			}
		}
		else
		{
			this.SysInfo("window.alert('����ʧ�ܣ�û��Ҫ���ɻ�Ա�Ŀͻ���Ϣ');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
