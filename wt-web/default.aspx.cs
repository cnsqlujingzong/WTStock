using DAL;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.DB;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class _Default : Page, IRequiresSessionState
{
	private string strvali = "";

	private string valicode = "0";

	private string loginddl = "class=\"isinDiv\"";

	private string strheight = " style=\"height:19px;\"";

	private string strremember = "";

	private string strtitle = string.Empty;

	private string strphone = " style=\"\"";

	private string strphoneValue = "0";
	public string Str_LoginDdl
	{
		get
		{
			return this.loginddl;
		}
	}

	public string Str_ValiCode
	{
		get
		{
			return this.valicode;
		}
	}

	public string Str_Vali
	{
		get
		{
			return this.strvali;
		}
	}

	public string Str_Height
	{
		get
		{
			return this.strheight;
		}
	}

	public string Str_Remember
	{
		get
		{
			return this.strremember;
		}
	}

	public string sTitle
	{
		get
		{
			return this.strtitle;
		}
	}

	public string Str_Phone
	{
		get
		{
			return this.strphone;
		}
	}

	public string Str_PhoneValue
	{
		get
		{
			return this.strphoneValue;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		string text = "";
		if (!base.IsPostBack)
		{
			DataTable dataTable = DALCommon.GetList("Version", "top 1 ID", " 1=1 order by RecID desc").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				text = dataTable.Rows[0]["ID"].ToString();
				this.UpdateSoft(text);
			}
			else
			{
				this.UpdateSoft("");
			}
			DALCommon.xt_loginstart(1);
			try
			{
				OtherFunction.BindBranch(this.ddlBranch);
			}
			catch (Exception var_3_9E)
			{
				this.alterTableBranch();
				OtherFunction.BindBranch(this.ddlBranch);
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo sysParmInfo = new SysParmInfo();
			try
			{
				sysParmInfo = dALSysParm.GetSysParm();
			}
			catch
			{
				this.alterTable();
				sysParmInfo = dALSysParm.GetSysParm();
			}
			if (sysParmInfo != null)
			{
				if (sysParmInfo.SysName != string.Empty)
				{
					this.strtitle += sysParmInfo.SysName;
				}
				if (sysParmInfo.bValiCode)
				{
					this.strvali = " style=\"display:none;\"";
					this.hfValiCode.Value = "1";
					this.valicode = "1";
				}
				if (sysParmInfo.bRememberPassword)
				{
					this.strremember = " style=\"display:none;\"";
				}
				if (sysParmInfo.bPhone)
				{
					this.strphone = " style=\"display:none;\"";
					this.strphoneValue = "1";
				}
				if (sysParmInfo.bLoginDdl)
				{
					this.loginddl = "";
					this.tbName.CssClass = "pin";
					this.hfLoginDdl.Value = "1";
					this.ddlStaff.Visible = false;
				}
				else
				{
					this.tbName.CssClass = "pin pinin";
					this.tbName.Attributes.Add("onblur", "ChkStaff()");
					this.ddlStaff.Visible = true;
				}
				if (!sysParmInfo.bValiCode && !sysParmInfo.bRememberPassword)
				{
					this.strheight = " style=\"height:0px;\"";
				}
			}
			else
			{
				this.tbName.CssClass = "pin pinin";
				this.tbName.Attributes.Add("onblur", "ChkStaff()");
				this.ddlStaff.Visible = true;
			}
			if (this.hfLoginDdl.Value == "0")
			{
				string text2 = text;
				DateTime t = DateTime.Parse(string.Concat(new string[]
				{
					text2.Substring(5, 4),
					"-",
					text2.Substring(9, 2),
					"-",
					text2.Substring(11, 2)
				}));
				if (t > DateTime.Parse("2012-10-08"))
				{
					OtherFunction.BindUserSortJobNO(this.ddlStaff, " DeptID=" + this.ddlBranch.SelectedValue + " and Status='正常' ");
				}
				else
				{
					OtherFunction.BindUser(this.ddlStaff, " DeptID=" + this.ddlBranch.SelectedValue + " and Status='正常' ");
				}
			}
		}
	}

	protected void btnLogin_Click(object sender, EventArgs e)
	{
		if (this.hfValiCode.Value == "0")
		{
			if (this.Session["Session_verifyCode"] == null)
			{
				this.SysInfo("alert('[验证码]失效，请尝试刷新页面.');");
			}
			else
			{
				string a = (string)this.Session["Session_verifyCode"];
				if (a != this.tbZCode.Text.Trim())
				{
					this.SysInfo("alert('验证码错误，请重新输入.');ChkImg();document.getElementById('tbZCode').select();");
				}
				else
				{
					this.Session.Remove("Session_verifyCode");
					this.ChkUser();
				}
			}
		}
		else
		{
			this.ChkUser();
		}
	}

	protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
	{
		DALCommon.xt_loginstart(int.Parse(this.ddlBranch.SelectedValue));
		if (this.hfLoginDdl.Value == "0")
		{
			Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
			AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
			string text = appSettingsSection.Settings["version"].Value.Trim().Substring(5);
			DateTime t = DateTime.Parse(string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 2),
				"-",
				text.Substring(6, 2)
			}));
			if (t > DateTime.Parse("2012-10-08"))
			{
				OtherFunction.BindUserSortJobNO(this.ddlStaff, " DeptID=" + this.ddlBranch.SelectedValue + " and Status='正常' ");
			}
			else
			{
				OtherFunction.BindUser(this.ddlStaff, " DeptID=" + this.ddlBranch.SelectedValue + " and Status='正常' ");
			}
		}
		this.tbName.Text = "";
	}

	protected void ChkUser()
	{
		DALUserManage dALUserManage = new DALUserManage();
		UserManageInfo userManageInfo = null;
		string text = FunLibrary.ChkInput(this.tbName.Text);
		string text2 = string.Empty;
		text2 = FunLibrary.StringMd5(DateTime.Now.ToString("ddHHmmssff")).Substring(4, 10);
		string text3 = FunLibrary.StrEncode(this.tbPassword.Text.Trim());
		int iD;
		if (this.hfLoginDdl.Value == "0")
		{
			iD = int.Parse(this.ddlStaff.SelectedValue);
			userManageInfo = dALUserManage.Login(iD);
			text = this.ddlStaff.SelectedItem.Text;
		}
		else
		{
			DALStaffList dALStaffList = new DALStaffList();
			iD = dALStaffList.GetLoginID(text, int.Parse(this.ddlBranch.SelectedValue));
			userManageInfo = dALUserManage.Login(iD);
		}
		if (userManageInfo == null)
		{
			this.SysInfo("alert('该用户名不存在.');ChkImg();document.getElementById('tbName').select();ChkCln();");
		}
		else if (userManageInfo.ID == -1)
		{
			this.SysInfo("alert('当前在线用户已达上限.');ChkImg();document.getElementById('tbName').select();ChkCln();");
		}
		else if (FunLibrary.StrDecode(userManageInfo.Pwd) != this.tbPassword.Text)
		{
			this.SysInfo("alert('密码不正确.');ChkImg();ChkCln();document.getElementById('tbPassword').select();");
		}
		else if (userManageInfo.Status == "锁定")
		{
			this.SysInfo("alert('该用户已被管理员锁定，请联系管理员.');ChkImg();document.getElementById('tbName').select();ChkCln();");
		}
		else
		{
			SysParmInfo model = new DALSysParm().GetModel(1);
			if (model != null)
			{
				if (!model.bPhone)
				{
					if (this.Session[text] == null)
					{
						this.SysInfo("alert('请先获取手机验证码')");
						return;
					}
					if (this.tbPhone.Text != this.Session[text].ToString())
					{
						this.SysInfo("alert('手机验证码输入错误，请重新输入')");
						return;
					}
					this.Session.Remove(text);
				}
			}
			dALUserManage.UpdateCode(iD, text2);
			DALSysVali dALSysVali = new DALSysVali();
            //if (dALSysVali.Exists("ITEM3"))
            //{
            //    string text4 = dALSysVali.GetValue("ITEM3");
            //    if (!(text4 != string.Empty))
            //    {
            //        base.Response.Redirect("Headquarters/Locked.aspx");
            //        return;
            //    }
            //    try
            //    {
            //        text4 = FunLibrary.StrDecode(text4);
            //        if (text4 != "running")
            //        {
            //            base.Response.Redirect("Headquarters/Locked.aspx");
            //            return;
            //        }
            //    }
            //    catch (Exception var_12_2C4)
            //    {
            //        base.Response.Redirect("Headquarters/Locked.aspx");
            //        return;
            //    }
            //}
			if (!base.Request.IsLocal)
			{
				string text5 = string.Empty;
				string[] array = base.Request.UserHostAddress.Split(new char[]
				{
					'.'
				});
				for (int i = 0; i < array.Length; i++)
				{
					text5 += this.ChangeStr(array[i]);
				}
				string text6 = string.Empty;
				string text7 = string.Empty;
				DALIPControl dALIPControl = new DALIPControl();
				DataTable dataTable = null;
				try
				{
					dataTable = dALIPControl.GetList(1).Tables[0];
				}
				catch (Exception var_21_3A0)
				{
					this.insertTable();
					dataTable = dALIPControl.GetList(1).Tables[0];
				}
				if (dataTable.Rows.Count > 0)
				{
					if (dataTable.Rows[0]["bEnable"].ToString() == "True")
					{
						string[] array2 = dataTable.Rows[0]["StartIP"].ToString().Split(new char[]
						{
							'.'
						});
						for (int i = 0; i < array2.Length; i++)
						{
							text7 += this.ChangeStr(array2[i]);
						}
						string[] array3 = dataTable.Rows[0]["EndIP"].ToString().Split(new char[]
						{
							'.'
						});
						for (int i = 0; i < array3.Length; i++)
						{
							text6 += this.ChangeStr(array3[i]);
						}
						if (long.Parse(text7) > long.Parse(text5) || long.Parse(text6) < long.Parse(text5))
						{
							bool flag = false;
							DALUserException ex = new DALUserException();
							DataTable dataTable2 = ex.GetList().Tables[0];
							if (dataTable2.Rows.Count > 0)
							{
								for (int i = 0; i < dataTable2.Rows.Count; i++)
								{
									if (dataTable2.Rows[i]["StaffID"].ToString().Equals(userManageInfo.StaffID.ToString()))
									{
										flag = true;
										break;
									}
								}
								if (!flag)
								{
									base.Response.Redirect("Headquarters/Pur.aspx");
								}
							}
						}
					}
				}
			}
			try
			{
				DbHelperSQL.InsertErrorLogs(1, userManageInfo.StaffID, 0, "登录系统", 0);
			}
			catch (Exception var_21_3A0)
			{
				this.updateTable();
				DbHelperSQL.InsertErrorLogs(1, userManageInfo.StaffID, 0, "登录系统", 0);
			}
			if (!text2.Trim().Equals(""))
			{
				this.Session["OperCode"] = text2;
			}
			if (this.ddlBranch.SelectedItem.Value == "1")
			{
				this.Session["Session_wtUser"] = text;
				this.Session["Session_wtUserID"] = userManageInfo.StaffID.ToString();
				this.Session["Session_wtPur"] = userManageInfo.Right;
				this.Session["Session_wtPurID"] = ((userManageInfo.Right == "系统管理员") ? "0" : userManageInfo.RightID.ToString());
				//this.SysInfo("SetCk();location.href='Headquarters/Verify.aspx';");
                Response.Redirect("/Headquarters/default.aspx");
			}
			else
			{
				DALSysParm dALSysParm = new DALSysParm();
				SysParmInfo sysParm = dALSysParm.GetSysParm();
				string corpName = sysParm.CorpName;
				string str = sysParm.BranchNum.ToString();
				string str2 = sysParm.bWeb.ToString();
				string value = dALSysVali.GetValue("ITEM2");
				string text8 = corpName + str2 + str;
				if (sysParm.bSim)
				{
					text8 += "并发";
				}
				string b = FunLibrary.EncodeReg(text8);
				bool flag2 = false;
				if (value != b)
				{
					string value2 = dALSysVali.GetValue("ITEM1");
					try
					{
						string time = FunLibrary.StrDecode(value2);
						int num = this.DayTs(time);
						if (num > 60 || num < 0)
						{
							flag2 = true;
						}
					}
					catch
					{
						flag2 = true;
					}
					DALStockIN dALStockIN = new DALStockIN();
					string billDate = dALStockIN.GetBillDate();
					if (billDate != string.Empty)
					{
						if (this.DayTs(billDate) > 60)
						{
							flag2 = true;
						}
					}
					DALServices dALServices = new DALServices();
					string makeTime = dALServices.GetMakeTime();
					if (makeTime != string.Empty)
					{
						if (this.DayTs(makeTime) > 60)
						{
							flag2 = true;
						}
					}
				}
				if (!flag2)
				{
					this.Session["Session_wtBranch"] = this.ddlBranch.SelectedItem.Text;
					this.Session["Session_wtBranchID"] = this.ddlBranch.SelectedValue;
					this.Session["Session_wtUserB"] = text;
					this.Session["Session_wtUserBID"] = userManageInfo.StaffID.ToString();
					this.Session["Session_wtPurB"] = userManageInfo.Right;
					this.Session["Session_wtPurBID"] = ((userManageInfo.Right == "系统管理员") ? "0" : userManageInfo.RightID.ToString());
					//this.SysInfo("SetCk();location.href='Branch/Verify.aspx';");
                    Response.Redirect("/Branch/default.aspx");
				}
				else
				{
					this.SysInfo("alert('试用期已经结束,网点无法登陆,请注册.');ChkImg();document.getElementById('tbName').select();ChkCln();");
				}
			}
		}
	}

	private string ChangeStr(string str)
	{
		string result;
		switch (str.Length)
		{
		case 0:
			result = null;
			break;
		case 1:
			result = "00" + str;
			break;
		case 2:
			result = "0" + str;
			break;
		case 3:
			result = str;
			break;
		default:
			result = null;
			break;
		}
		return result;
	}

	protected int DayTs(string time)
	{
		DateTime d = DateTime.Parse(time);
		DateTime now = DateTime.Now;
		return 1;
       // return 1;
	}

	protected void UpdateSoft(string version)
	{
		string text = string.Empty;
		int num = 0;
		if (version == "10.1.20111208" || version == "")
		{
			text = string.Empty;
			text = "if not exists(select * from syscolumns where id=object_id('SysParm') and name='bSerItem') begin ALTER TABLE SysParm ADD bSerItem bit DEFAULT 0 WITH VALUES end";
			try
			{
				DALCommon.Excu(text);
			}
			catch (Exception ex)
			{
				num++;
				OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，表:SysParm，升级异常:" + ex.Message.ToString());
			}
			text = string.Empty;
			text = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xt_sysparm]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[xt_sysparm]";
			try
			{
				DALCommon.Excu(text);
			}
			catch (Exception ex)
			{
				num++;
				OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:xt_sysparm，升级异常:" + ex.Message.ToString());
			}
			text = string.Empty;
			text += "CREATE VIEW dbo.xt_sysparm";
			text += " AS ";
			text += " SELECT b.ID, b.CorpName, b.Tel, b.Adr, b.Zip, a.[SysName], a.BranchNum, a.AllocatePrice, ";
			text += "      a.WarrantyCycle, a.CustomerShar, a.EmailServer, a.EmailLogName, a.EmailPwd, ";
			text += "      a.EmailAdr, a.SmsCode, a.BackUpAdr, ISNULL(a.bWeb, 0) AS bWeb, ";
			text += "      ISNULL(a.SndStyle, 1) AS SndStyle, a.UserName, a.UserPwd, isnull(a.RecDueDay,30) as RecDueDay, isnull(a.iRepair,7) as iRepair,";
			text += "     isnull( a.bLoginDdl,0) as bLoginDdl,isnull( a.bValiCode,0) as bValiCode,isnull(a.bBln,0) as bBln,isnull(a.bRememberPassword,0) as bRememberPassword,";
			text += "    isnull(a.bFinish,0) as bFinish, isnull(a.bFinish2,0) as bFinish2, isnull(a.ServicesDo,0) as ServicesDo,a.City, isnull(a.bTec,0) as bTec, isnull(a.bSerItem,0) as bSerItem";
			text += " FROM dbo.SysParm a LEFT OUTER JOIN";
			text += "      dbo.BranchList b ON a.DeptID = b.ID";
			try
			{
				DALCommon.Excu(text);
			}
			catch (Exception ex)
			{
				num++;
				OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:xt_sysparm，升级异常:" + ex.Message.ToString());
			}
		}
	}

	protected void insertTable()
	{
		string strSql = string.Empty;
		strSql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IPControl]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[IPControl]";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20131119-10.1.20140106，时间:" + DateTime.Now.ToString() + "，表:IPControl，创建异常:" + ex.Message.ToString());
		}
		strSql = string.Empty;
		strSql = "CREATE TABLE [dbo].[IPControl] (\r\n\t        [ID] [int] NOT NULL ,\r\n\t        [StartIP] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,\r\n\t        [EndIP] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,\r\n\t        [bEnable] [bit] NULL \r\n            ) ON [PRIMARY]";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20131119-10.1.20140106，时间:" + DateTime.Now.ToString() + "，表:IPControl，创建异常:" + ex.Message.ToString());
		}
	}

	protected void updateTable()
	{
		string strSql = string.Empty;
		strSql = " if not exists(select * from syscolumns where id=object_id('SysLog') and name='CustomerID')\r\n                    begin\r\n\t                alter table SysLog add CustomerID int\r\n                    end";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140226-10.1.20140325,时间:" + DateTime.Now.ToString() + ",表SysLog,修改异常:" + ex.Message.ToString());
		}
		strSql = string.Empty;
		strSql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[aa_insertlog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)\r\n                    drop procedure [dbo].[aa_insertlog]";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140226-10.1.20140325,时间:" + DateTime.Now.ToString() + ",存储过程aa_insertlog,修改异常:" + ex.Message.ToString());
		}
		strSql = string.Empty;
		strSql = "CREATE PROCEDURE aa_insertlog  \r\n                    (   \r\n                     @iFlag  int,--0异常日志,1系统日志--2维修日志  \r\n                     @iOperatorid int,  \r\n                     @iMTbid int,  \r\n                     @strContent nvarchar(500),\r\n                     @iCustomerid int  \r\n                    )  \r\n                    as  \r\n                    set nocount on  \r\n                      \r\n                    declare @strDateTime nvarchar(50)  \r\n                      \r\n                    set @strDateTime=convert(varchar(50),getdate(),120)  \r\n                      \r\n                      \r\n                    if @iFlag=0  \r\n                    begin  \r\n                     insert into ErrorLog(OperatorID,_Date,Event)values(@iOperatorid,@strDateTime,@strContent)  \r\n                    end  \r\n                    else if @iFlag=1  \r\n                    begin  \r\n                     if(@iCustomerid=0)\r\n                     begin \r\n                     insert into SysLog(OperatorID,_Date,Event)values(@iOperatorid,@strDateTime,@strContent) \r\n                     end\r\n                     if(@iOperatorid=0)\r\n                     begin\r\n                     insert into SysLog(CustomerID,_Date,Event)values(@iCustomerid,@strDateTime,@strContent)\r\n                     end \r\n                    end  \r\n                    else if @iFlag=2  \r\n                    begin  \r\n                     insert into ServicesLog(BillID,OperatorID,_Date,Event)values(@iMTbid,@iOperatorid,@strDateTime,@strContent)  \r\n                    end  ";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140226-10.1.20140325,时间:" + DateTime.Now.ToString() + ",存储过程aa_insertlog,修改异常:" + ex.Message.ToString());
		}
	}

	private void alterTableBranch()
	{
		string strSql = string.Empty;
		strSql = "if not exists(select * from syscolumns where id=object_id('BranchList') and name='Array')\r\n                begin\r\n\t                alter table BranchList add Array int default 0\r\n                end";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140605-10.1.20140630，时间:" + DateTime.Now.ToString() + "，表:BranchList，创建异常:" + ex.Message.ToString());
		}
		strSql = string.Empty;
		strSql = "Update BranchList set Array=0";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140605-10.1.20140630，时间:" + DateTime.Now.ToString() + "，表:BranchList，创建异常:" + ex.Message.ToString());
		}
	}

	private void alterTable()
	{
		string strSql = string.Empty;
		strSql = "if not exists(select * from syscolumns where id=object_id('SysParm') and name='bPlanControl') \r\n                begin \r\n\t                alter table SysParm add bPlanControl bit default(0) with values\r\n                end\r\n                GO\r\n                if not exists(select * from syscolumns where id=object_id('SysParm') and name='bDeviceOnly') \r\n                begin \r\n\t                alter table SysParm add bDeviceOnly bit default(0) with values\r\n                end\r\n                GO\r\n                if not exists(select * from syscolumns where id=object_id('SysParm') and name='bPurSep') \r\n                begin \r\n\t                alter table SysParm add bPurSep bit default(0) with values\r\n                end\r\n                GO\r\n                if not exists(select * from syscolumns where id=object_id('SysParm') and name='bSellSep') \r\n                begin \r\n\t                alter table SysParm add bSellSep bit default(0) with values\r\n                end\r\n                GO\r\n                if not exists(select * from syscolumns where id=object_id('SysParm') and name='bZeroPurchase') \r\n                begin \r\n\t                alter table SysParm add bZeroPurchase bit default(0) with values\r\n                end\r\n                GO\r\n                if not exists(select * from syscolumns where id=object_id('SysParm') and name='CostModel') \r\n                begin \r\n\t                alter table SysParm add CostModel int\r\n                end\r\n                GO\r\n                if not exists(select * from syscolumns where id=object_id('SysParm') and name='bDisblingControl') \r\n                begin \r\n\t                alter table SysParm add bDisblingControl bit default(0) with values\r\n                end\r\n                GO\r\n                if not exists(select * from syscolumns where id=object_id('SysParm') and name='LockMinutes') \r\n                begin \r\n\t                alter table SysParm add LockMinutes int\r\n                end";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
		}
		strSql = string.Empty;
		strSql = "if not exists(select * from syscolumns where id=object_id('SysParm') and name='bPhone')\r\n                begin\r\n\t            alter table SysParm add bPhone bit\r\n                end";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140520-10.1.20140605，时间:" + DateTime.Now.ToString() + "，表:SysParm，创建异常:" + ex.Message.ToString());
		}
		strSql = string.Empty;
		strSql = "update SysParm set bPhone=1";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140520-10.1.20140605，时间:" + DateTime.Now.ToString() + "，表:SysParm，创建异常:" + ex.Message.ToString());
		}
		strSql = string.Empty;
		strSql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xt_sysparm]') and OBJECTPROPERTY(id, N'IsView') = 1)\r\n                drop view [dbo].[xt_sysparm]";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140520-10.1.20140605，时间:" + DateTime.Now.ToString() + "，表:SysParm，创建异常:" + ex.Message.ToString());
		}
		strSql = string.Empty;
		strSql = "CREATE     VIEW dbo.xt_sysparm  \r\n                AS  \r\n                SELECT b.ID, b.CorpName, b.Tel, b.Adr, b.Zip, a.[SysName], a.BranchNum, a.AllocatePrice, a.bSim,a.bEnforceInput,bPlanControl,a.bPhone,  \r\n                      a.WarrantyCycle, a.CustomerShar, a.EmailServer, a.EmailLogName, a.EmailPwd, a.bFaultNoInput, a.bTakeStepsNoInput,  \r\n                      a.EmailAdr, a.SmsCode, a.BackUpAdr, ISNULL(a.bWeb, 0) AS bWeb, a.bHeadBln,a.bSerSep,a.bDeviceOnly,bPurSep,bSellSep,CostModel,  \r\n                      ISNULL(a.SndStyle, 1) AS SndStyle, a.UserName, a.UserPwd, isnull(a.RecDueDay,30) as RecDueDay, isnull(a.iRepair,7) as iRepair,  \r\n                     isnull( a.bLoginDdl,0) as bLoginDdl,isnull( a.bValiCode,0) as bValiCode,isnull(a.bBln,0) as bBln,isnull(a.bRememberPassword,0) as bRememberPassword,  \r\n                    isnull(a.bFinish,0) as bFinish, isnull(a.bFinish2,0) as bFinish2, isnull(a.ServicesDo,0) as ServicesDo,a.City, isnull(a.bTec,0) as bTec, isnull(a.bSerItem,0) as bSerItem,  \r\n                      bZeroPurchase,bDisblingControl,LockMinutes  \r\n                FROM dbo.SysParm a LEFT OUTER JOIN  \r\n                     dbo.BranchList b ON a.DeptID = b.ID  ";
		try
		{
			DALCommon.Excu(strSql);
		}
		catch (Exception ex)
		{
			OtherClass.AppendErrorLog("10.1.20140520-10.1.20140605，时间:" + DateTime.Now.ToString() + "，表:SysParm，创建异常:" + ex.Message.ToString());
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
