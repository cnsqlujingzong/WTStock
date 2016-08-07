using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using wt.DAL;
using wt.Model;

[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class CountService : WebService
{
	public class CountInfo
	{
		private int _Count;

		private string _Name;

		public int Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		public CountInfo()
		{
		}

		public CountInfo(string myName, int count)
		{
			this.Count = count;
			this.Name = myName;
		}
	}

	[WebMethod]
	public List<CountService.CountInfo> UserCounts(int deptId, string userName, int userid, string pwd)
	{
		List<CountService.CountInfo> result;
		if (deptId == 0 || userid == 0 || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(userName))
		{
			result = null;
		}
		else
		{
			List<CountService.CountInfo> list = new List<CountService.CountInfo>();
			CountService.CountInfo item = new CountService.CountInfo("billcount", this.CountBill(deptId, userName, userid, pwd));
			list.Add(item);
			result = list;
		}
		return result;
	}

	public int CountBill(int deptId, string userName, int userid, string pwd)
	{
		userName = userName.Replace("'", "''");
		string checkText = "(curStatus like '%待处理%' or  curStatus like '%处理中%') and DisposalID=" + deptId;
		string a = "";
		string text = "";
		string a2 = "";
		DALUserManage dALUserManage = new DALUserManage();
		UserManageInfo userManageInfo = dALUserManage.Login(userid);
		int result;
		if (userManageInfo == null)
		{
			result = 0;
		}
		else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper().ToUpper() || userManageInfo.Status != "正常")
		{
			result = 0;
		}
		else
		{
			int num = (userManageInfo.Right == "系统管理员") ? 0 : userManageInfo.RightID;
			if (deptId == 1)
			{
				if (num > 0)
				{
					DALRight dALRight = new DALRight();
					if (dALRight.GetRight(num, "gd_r20"))
					{
						a = "0";
					}
					else
					{
						a = "1";
					}
					if (dALRight.GetRight(num, "gd_r24"))
					{
						DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + userManageInfo.StaffID).Tables[0];
						if (dataTable.Rows.Count > 0)
						{
							text = dataTable.Rows[0]["Area"].ToString();
						}
					}
					if (dALRight.GetRight(num, "gd_r25"))
					{
						a2 = "1";
					}
				}
			}
			else if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (dALRight.GetRight(num, "gd_r17"))
				{
					a = "0";
				}
				else
				{
					a = "1";
				}
				if (dALRight.GetRight(num, "gd_r20"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + userManageInfo.StaffID).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						text = dataTable.Rows[0]["Area"].ToString();
					}
				}
				if (dALRight.GetRight(num, "gd_r21"))
				{
					a2 = "1";
				}
			}
			int num2 = 0;
			string text2 = this.strParm(deptId, checkText);
			string fldSort = "ID desc";
			if (a2 == "1")
			{
				object obj = text2;
				text2 = string.Concat(new object[]
				{
					obj,
					" and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=",
					userManageInfo.StaffID,
					")) or OperatorID is null)"
				});
			}
			if (a == "0")
			{
				text2 = text2 + " and CHARINDEX('" + userName + "',DisposalOper)>0 ";
			}
			if (text != "")
			{
				text2 = text2 + " and (CHARINDEX('" + text + "',Area)>0 or Area='' or Area is null) ";
			}
			DALCommon.GetList_HL(1, "fw_services", "", 20, 1, text2, fldSort, out num2);
			result = num2;
		}
		return result;
	}

	public int CountMail(string deptId, string userName)
	{
		DALUserManage dALUserManage = new DALUserManage();
		DALStaffList dALStaffList = new DALStaffList();
		int loginID = dALStaffList.GetLoginID(userName, int.Parse(deptId));
		UserManageInfo userManageInfo = dALUserManage.Login(loginID);
		DALOA_Mail dALOA_Mail = new DALOA_Mail();
		string s = dALOA_Mail.TCount(" RcvID='" + userManageInfo.StaffID + "' and bRead=0 and bSndFlag=1 and bRcvFlag=0 ");
		return int.Parse(s);
	}

	protected string strParm(int deptId, string checkText)
	{
		string str;
		if (deptId == 1)
		{
			str = " 1=1 ";
		}
		else
		{
			str = string.Concat(new object[]
			{
				" (DisposalID=",
				deptId,
				" or TakeOverID=",
				deptId,
				" or BranchID=",
				deptId,
				")"
			});
		}
		return str + " and " + checkText;
	}
}
