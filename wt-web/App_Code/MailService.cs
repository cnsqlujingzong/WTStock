using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using wt.DAL;
using wt.Model;

[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class MailService : WebService
{
	public class PartEmailInfo
	{
		private int _ID;

		private int _count;

		private string _bRead;

		private string _Snd;

		private string _Rcv;

		private string _Title;

		private string _Content;

		private string _Date;

		private string _bAccessory;

		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		public int Count
		{
			get
			{
				return this._count;
			}
			set
			{
				this._count = value;
			}
		}

		public string bRead
		{
			get
			{
				return this._bRead;
			}
			set
			{
				this._bRead = value;
			}
		}

		public string Snd
		{
			get
			{
				return this._Snd;
			}
			set
			{
				this._Snd = value;
			}
		}

		public string Rcv
		{
			get
			{
				return this._Rcv;
			}
			set
			{
				this._Rcv = value;
			}
		}

		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this._Title = value;
			}
		}

		public string Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				this._Content = value;
			}
		}

		public string Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				this._Date = value;
			}
		}

		public string bAccessory
		{
			get
			{
				return this._bAccessory;
			}
			set
			{
				this._bAccessory = value;
			}
		}
	}

	[WebMethod]
	public List<MailService.PartEmailInfo> mailList(int pageNum, string deptId, string userName, string bRead)
	{
		int count = 0;
		List<MailService.PartEmailInfo> list = new List<MailService.PartEmailInfo>();
		string text = this.strParm("0", deptId, userName);
		if (bRead.Equals("0"))
		{
			text += "and bRead=0";
		}
		string fldSort = "ID Desc";
		DataTable dataTable = DALCommon.GetList_HL(1, "oa_mail", "", 20, pageNum, text, fldSort, out count).Tables[0];
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			list.Add(new MailService.PartEmailInfo
			{
				ID = int.Parse(dataTable.Rows[i]["ID"].ToString()),
				Count = count,
				Date = dataTable.Rows[i]["_Date"].ToString(),
				Title = dataTable.Rows[i]["Title"].ToString(),
				Content = dataTable.Rows[i]["Content"].ToString(),
				bRead = dataTable.Rows[i]["bRead"].ToString(),
				bAccessory = dataTable.Rows[i]["bAccessory"].ToString(),
				Rcv = dataTable.Rows[i]["_Rcv"].ToString(),
				Snd = dataTable.Rows[i]["_Snd"].ToString()
			});
		}
		return list;
	}

	[WebMethod]
	public OA_EmailInfo getMailByID(int mailID)
	{
		OA_EmailInfo oA_EmailInfo = new OA_EmailInfo();
		DALOA_Mail dALOA_Mail = new DALOA_Mail();
		return dALOA_Mail.GetModel(mailID);
	}

	protected string strParm(string strClass, string deptId, string userName)
	{
		DALUserManage dALUserManage = new DALUserManage();
		DALStaffList dALStaffList = new DALStaffList();
		int loginID = dALStaffList.GetLoginID(userName, int.Parse(deptId));
		UserManageInfo userManageInfo = dALUserManage.Login(loginID);
		string text = "1=1 ";
		if (strClass != null)
		{
			if (!(strClass == "-1") && !(strClass == "0"))
			{
				if (!(strClass == "1"))
				{
					if (!(strClass == "2"))
					{
						if (strClass == "3")
						{
							object obj = text;
							text = string.Concat(new object[]
							{
								obj,
								" and RcvID=",
								userManageInfo.StaffID,
								" and _Rcv='",
								userName,
								"' and bRcvFlag=1 "
							});
						}
					}
					else
					{
						object obj = text;
						text = string.Concat(new object[]
						{
							obj,
							" and RcvID=",
							userManageInfo.StaffID,
							" and _Snd='",
							userName,
							"'and bSndFlag=1 "
						});
					}
				}
				else
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						" and RcvID=",
						userManageInfo.StaffID,
						" and _Snd='",
						userName,
						"' and bSndFlag=0 "
					});
				}
			}
			else
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" and RcvID=",
					userManageInfo.StaffID,
					" and _Rcv='",
					userName,
					"' and bRcvFlag=0 and bSndFlag=1 "
				});
			}
		}
		return text;
	}
}
