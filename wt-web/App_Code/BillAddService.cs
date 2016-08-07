using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using wt.DAL;
using wt.Library;
using wt.Model;

[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class BillAddService : WebService
{
	public class PartCustomer
	{
		private int id;

		private int count;

		private string customerNo;

		private string _Name;

		private string tel;

		private string tel2;

		private string adr;

		public int ID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		public int Count
		{
			get
			{
				return this.count;
			}
			set
			{
				this.count = value;
			}
		}

		public string CustomerNo
		{
			get
			{
				return this.customerNo;
			}
			set
			{
				this.customerNo = value;
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

		public string Tel
		{
			get
			{
				return this.tel;
			}
			set
			{
				this.tel = value;
			}
		}

		public string Tel2
		{
			get
			{
				return this.tel2;
			}
			set
			{
				this.tel2 = value;
			}
		}

		public string Adr
		{
			get
			{
				return this.adr;
			}
			set
			{
				this.adr = value;
			}
		}
	}

	[WebMethod]
	public List<ServicesTypeInfo> GetServicesTypeInfo(int userid, string pwd)
	{
		List<ServicesTypeInfo> result;
		if (userid == 0 || string.IsNullOrEmpty(pwd))
		{
			result = null;
		}
		else
		{
			DALUserManage dALUserManage = new DALUserManage();
			UserManageInfo userManageInfo = dALUserManage.Login(userid);
			if (userManageInfo == null)
			{
				result = null;
			}
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper().ToUpper() || userManageInfo.Status != "正常")
			{
				result = null;
			}
			else
			{
				int num = 0;
				List<ServicesTypeInfo> list = new List<ServicesTypeInfo>();
				DataSet list_HL = DALCommon.GetList_HL(0, "ServicesType", "", 0, 0, "", " Array asc ", out num);
				for (int i = 0; i < list_HL.Tables[0].Rows.Count; i++)
				{
					list.Add(new ServicesTypeInfo
					{
						_Name = list_HL.Tables[0].Rows[i]["_Name"].ToString(),
						ID = int.Parse(list_HL.Tables[0].Rows[i]["ID"].ToString())
					});
				}
				result = list;
			}
		}
		return result;
	}

	[WebMethod]
	public List<BaseInfo> GetProductBrandInfo(int userid, string pwd)
	{
		List<BaseInfo> result;
		if (userid == 0 || string.IsNullOrEmpty(pwd))
		{
			result = null;
		}
		else
		{
			DALUserManage dALUserManage = new DALUserManage();
			UserManageInfo userManageInfo = dALUserManage.Login(userid);
			if (userManageInfo == null)
			{
				result = null;
			}
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper().ToUpper() || userManageInfo.Status != "正常")
			{
				result = null;
			}
			else
			{
				int num = 0;
				List<BaseInfo> list = new List<BaseInfo>();
				DataTable dataTable = DALCommon.GetList_HL(0, "ProductBrand", "", 0, 0, "", "_Name", out num).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					list.Add(new BaseInfo
					{
						_Name = dataTable.Rows[i]["_Name"].ToString(),
						ID = int.Parse(dataTable.Rows[i]["ID"].ToString())
					});
				}
				result = list;
			}
		}
		return result;
	}

	[WebMethod]
	public List<WarrantyInfo> GetWarrantyInfo(int userid, string pwd)
	{
		List<WarrantyInfo> result;
		if (userid == 0 || string.IsNullOrEmpty(pwd))
		{
			result = null;
		}
		else
		{
			DALUserManage dALUserManage = new DALUserManage();
			UserManageInfo userManageInfo = dALUserManage.Login(userid);
			if (userManageInfo == null)
			{
				result = null;
			}
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper().ToUpper() || userManageInfo.Status != "正常")
			{
				result = null;
			}
			else
			{
				int num = 0;
				List<WarrantyInfo> list = new List<WarrantyInfo>();
				DataTable dataTable = DALCommon.GetList_HL(0, "Warranty", "", 0, 0, " bStopUse=0", " Array asc ", out num).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					list.Add(new WarrantyInfo
					{
						_Name = dataTable.Rows[i]["_Name"].ToString(),
						ID = int.Parse(dataTable.Rows[i]["ID"].ToString())
					});
				}
				result = list;
			}
		}
		return result;
	}

	[WebMethod]
	public List<BaseInfo> GetTakeStyleInfo(int userid, string pwd)
	{
		List<BaseInfo> result;
		if (userid == 0 || string.IsNullOrEmpty(pwd))
		{
			result = null;
		}
		else
		{
			DALUserManage dALUserManage = new DALUserManage();
			UserManageInfo userManageInfo = dALUserManage.Login(userid);
			if (userManageInfo == null)
			{
				result = null;
			}
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper().ToUpper() || userManageInfo.Status != "正常")
			{
				result = null;
			}
			else
			{
				int num = 0;
				List<BaseInfo> list = new List<BaseInfo>();
				DataTable dataTable = DALCommon.GetList_HL(0, "TakeStyle", "", 0, 0, "", " Array asc ", out num).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					list.Add(new BaseInfo
					{
						_Name = dataTable.Rows[i]["_Name"].ToString(),
						ID = int.Parse(dataTable.Rows[i]["ID"].ToString())
					});
				}
				result = list;
			}
		}
		return result;
	}

	[WebMethod]
	public List<BillAddService.PartCustomer> GetCustomerInfo(int pageNum, int deptId, string userName, int userid, string pwd, string checkText)
	{
		List<BillAddService.PartCustomer> result;
		if (deptId == 0 || userid == 0 || string.IsNullOrEmpty(pwd))
		{
			result = null;
		}
		else
		{
			DALUserManage dALUserManage = new DALUserManage();
			UserManageInfo userManageInfo = dALUserManage.Login(userid);
			if (userManageInfo == null)
			{
				result = null;
			}
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper().ToUpper() || userManageInfo.Status != "正常")
			{
				result = null;
			}
			else
			{
				List<BillAddService.PartCustomer> list = new List<BillAddService.PartCustomer>();
				int count = 0;
				string fldSort = "ID desc";
				string strCondition = this.strParm(deptId, checkText);
				DataTable dataTable = DALCommon.GetList_HL(1, "ks_customer", "", 20, pageNum, strCondition, fldSort, out count).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					list.Add(new BillAddService.PartCustomer
					{
						ID = int.Parse(dataTable.Rows[i]["ID"].ToString()),
						Count = count,
						CustomerNo = dataTable.Rows[i]["ID"].ToString(),
						Name = dataTable.Rows[i]["_Name"].ToString(),
						Tel = dataTable.Rows[i]["Tel"].ToString(),
						Tel2 = dataTable.Rows[i]["Tel2"].ToString(),
						Adr = dataTable.Rows[i]["Adr"].ToString()
					});
				}
				result = list;
			}
		}
		return result;
	}

	protected string strParm(int deptId, string checkText)
	{
		string text = " bStop='' and RegDept=" + deptId;
		string text2 = FunLibrary.ChkInput(checkText);
		int schid = 2;
		DALCustomerList dALCustomerList = new DALCustomerList();
		if (text2 != "")
		{
			text += dALCustomerList.GetSchWhere(schid, text2);
		}
		return text;
	}

	[WebMethod]
	public int CustomerAdd(CustomerListInfo cusinfo)
	{
		DALCustomerList dALCustomerList = new DALCustomerList();
		return 0;
	}
}
