using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using wt.DAL;
using wt.Library;
using wt.Model;

[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class LoginService : WebService
{
	public class PhoneUser
	{
		private int _iuser = 0;

		private int _staffId = 0;

		private string _username = "";

		private string _pwd = "";

		private string _result = "";

		private string _deptName = "";

		public string deptName
		{
			get
			{
				return this._deptName;
			}
			set
			{
				this._deptName = value;
			}
		}

		public int iuser
		{
			get
			{
				return this._iuser;
			}
			set
			{
				this._iuser = value;
			}
		}

		public int staffId
		{
			get
			{
				return this._staffId;
			}
			set
			{
				this._staffId = value;
			}
		}

		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				this._username = value;
			}
		}

		public string pwd
		{
			get
			{
				return this._pwd;
			}
			set
			{
				this._pwd = value;
			}
		}

		public string result
		{
			get
			{
				return this._result;
			}
			set
			{
				this._result = value;
			}
		}
	}

	[WebMethod]
	public LoginService.PhoneUser Login(string deptid, string name, string password)
	{
		DALUserManage dALUserManage = new DALUserManage();
		LoginService.PhoneUser phoneUser = new LoginService.PhoneUser();
		phoneUser.result = "登录成功";
		string name2 = FunLibrary.ChkInput(name);
		string text = string.Empty;
		text = FunLibrary.StringMd5(DateTime.Now.ToString("ddHHmmssff")).Substring(4, 10);
		string text2 = FunLibrary.StrEncode(password.Trim());
		DALStaffList dALStaffList = new DALStaffList();
		int loginID = dALStaffList.GetLoginID(name2, int.Parse(deptid));
		UserManageInfo userManageInfo = dALUserManage.Login(loginID);
		if (userManageInfo == null)
		{
			phoneUser.result = "该用户名不存在";
		}
		else if (userManageInfo.ID == -1)
		{
			phoneUser.result = "当前在线用户已达上限";
		}
		else if (FunLibrary.StrDecode(userManageInfo.Pwd) != password)
		{
			phoneUser.result = "密码不正确";
		}
		else if (userManageInfo.Status == "锁定")
		{
			phoneUser.result = "该用户已被管理员锁定，请联系管理员";
		}
		phoneUser.iuser = userManageInfo.ID;
		phoneUser.username = name;
		phoneUser.staffId = userManageInfo.StaffID;
		phoneUser.pwd = userManageInfo.Pwd;
		phoneUser.deptName = this.GetDeptName(int.Parse(deptid));
		return phoneUser;
	}

	[WebMethod]
	public LoginService.PhoneUser LoginCheck(string deptid, string name, string password)
	{
		DALUserManage dALUserManage = new DALUserManage();
		LoginService.PhoneUser phoneUser = new LoginService.PhoneUser();
		string name2 = FunLibrary.ChkInput(name);
		string text = string.Empty;
		text = FunLibrary.StringMd5(DateTime.Now.ToString("ddHHmmssff")).Substring(4, 10);
		string text2 = FunLibrary.StrEncode(password.Trim());
		DALStaffList dALStaffList = new DALStaffList();
		int loginID = dALStaffList.GetLoginID(name2, int.Parse(deptid));
		UserManageInfo userManageInfo = dALUserManage.Login(loginID);
		if (userManageInfo == null)
		{
			phoneUser.result = "该用户名不存在";
		}
		else if (userManageInfo.ID == -1)
		{
			phoneUser.result = "当前在线用户已达上限";
		}
		else if (userManageInfo.Pwd.ToUpper() != password.ToUpper())
		{
			phoneUser.result = "密码不正确";
		}
		else if (userManageInfo.Status == "锁定")
		{
			phoneUser.result = "该用户已被管理员锁定，请联系管理员";
		}
		else
		{
			phoneUser.result = "登录成功";
		}
		phoneUser.iuser = userManageInfo.ID;
		phoneUser.username = name;
		phoneUser.staffId = userManageInfo.StaffID;
		phoneUser.pwd = userManageInfo.Pwd;
		phoneUser.deptName = this.GetDeptName(int.Parse(deptid));
		return phoneUser;
	}

	public string GetDeptName(int deptid)
	{
		string result = "";
		int num = 0;
		List<BranchListInfo> list = new List<BranchListInfo>();
		DataSet list_HL = DALCommon.GetList_HL(0, "BranchList", "[ID],_Name", 0, 0, "ID=" + deptid + "and bStop=0 ", "ID", out num);
		if (list_HL.Tables[0].Rows.Count > 0)
		{
			result = list_HL.Tables[0].Rows[0]["_Name"].ToString();
		}
		return result;
	}

	[WebMethod]
	public List<BranchListInfo> GetDept()
	{
		int num = 0;
		List<BranchListInfo> list = new List<BranchListInfo>();
		DataSet list_HL = DALCommon.GetList_HL(0, "BranchList", "[ID],_Name", 0, 0, " bStop=0 ", "ID", out num);
		for (int i = 0; i < num; i++)
		{
			list.Add(new BranchListInfo
			{
				_Name = list_HL.Tables[0].Rows[i]["_Name"].ToString(),
				ID = Convert.ToInt32(list_HL.Tables[0].Rows[i]["ID"].ToString())
			});
		}
		return list;
	}

	[WebMethod]
	public string GetCompanyName()
	{
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo model = dALSysParm.GetModel(1);
		return model.CorpName;
	}
}
