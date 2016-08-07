using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using wt.DAL;
using wt.Library;
using wt.Model;

[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SchStock : WebService
{
	public class PartStock
	{
		private int _Count;

		private int _ID;

		private string _ClassName;

		private string _GoodsNO;

		private string _Name;

		private string _Stock;

		private string _Spec;

		private string _ProductBrand;

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

		public string ClassName
		{
			get
			{
				return this._ClassName;
			}
			set
			{
				this._ClassName = value;
			}
		}

		public string GoodsNO
		{
			get
			{
				return this._GoodsNO;
			}
			set
			{
				this._GoodsNO = value;
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

		public string Stock
		{
			get
			{
				return this._Stock;
			}
			set
			{
				this._Stock = value;
			}
		}

		public string Spec
		{
			get
			{
				return this._Spec;
			}
			set
			{
				this._Spec = value;
			}
		}

		public string ProductBrand
		{
			get
			{
				return this._ProductBrand;
			}
			set
			{
				this._ProductBrand = value;
			}
		}
	}

	public class PartStockDept
	{
		private int _ID;

		private string _StockName;

		private string _Stock;

		private string _CostPrice;

		private string _StockLocName;

		private string _DownWarning;

		private string _UpWarning;

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

		public string StockName
		{
			get
			{
				return this._StockName;
			}
			set
			{
				this._StockName = value;
			}
		}

		public string Stock
		{
			get
			{
				return this._Stock;
			}
			set
			{
				this._Stock = value;
			}
		}

		public string CostPrice
		{
			get
			{
				return this._CostPrice;
			}
			set
			{
				this._CostPrice = value;
			}
		}

		public string StockLocName
		{
			get
			{
				return this._StockLocName;
			}
			set
			{
				this._StockLocName = value;
			}
		}

		public string DownWarning
		{
			get
			{
				return this._DownWarning;
			}
			set
			{
				this._DownWarning = value;
			}
		}

		public string UpWarning
		{
			get
			{
				return this._UpWarning;
			}
			set
			{
				this._UpWarning = value;
			}
		}
	}

	[WebMethod]
	public List<SchStock.PartStock> GetStockGoods(int pageNum, int deptId, int userid, string pwd, string checkText, bool showzero)
	{
		List<SchStock.PartStock> result;
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
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper() || userManageInfo.Status != "正常" || userManageInfo.DeptID != deptId)
			{
				result = null;
			}
			else
			{
				List<SchStock.PartStock> list = new List<SchStock.PartStock>();
				int num = (userManageInfo.Right == "系统管理员") ? 0 : userManageInfo.RightID;
				DALRight dALRight = new DALRight();
				if (deptId == 1)
				{
					if (num > 0)
					{
						if (dALRight.GetRight(num, "ck_r5"))
						{
							result = null;
							return result;
						}
					}
				}
				else if (num > 0)
				{
					if (dALRight.GetRight(num, "ck_r1"))
					{
						result = null;
						return result;
					}
				}
				int count = 0;
				string text = " DeptID =" + deptId;
				if (!showzero)
				{
					text += " and Stock<>0 ";
				}
				string fldSort = "ID desc";
				string text2 = FunLibrary.ChkInput(checkText);
				int schid = 0;
				if (text2 != "")
				{
					DALGoods dALGoods = new DALGoods();
					text += dALGoods.GetSchWhere(schid, text2);
				}
				DataSet list_HL = DALCommon.GetList_HL(1, "ck_stock", "", 20, pageNum, text, fldSort, out count);
				for (int i = 0; i < list_HL.Tables[0].Rows.Count; i++)
				{
					list.Add(new SchStock.PartStock
					{
						Count = count,
						ID = Convert.ToInt32(list_HL.Tables[0].Rows[i]["ID"].ToString()),
						ClassName = list_HL.Tables[0].Rows[i]["ClassName"].ToString(),
						GoodsNO = list_HL.Tables[0].Rows[i]["GoodsNO"].ToString(),
						Name = list_HL.Tables[0].Rows[i]["_Name"].ToString(),
						ProductBrand = list_HL.Tables[0].Rows[i]["ProductBrand"].ToString(),
						Spec = list_HL.Tables[0].Rows[i]["Spec"].ToString(),
						Stock = list_HL.Tables[0].Rows[i]["Stock"].ToString()
					});
				}
				result = list;
			}
		}
		return result;
	}

	[WebMethod]
	public GoodsInfo GetGoodsInfo(int GoodsID, int deptId, int userid, string pwd)
	{
		GoodsInfo result;
		if (deptId == 0 || userid == 0 || GoodsID == 0 || string.IsNullOrEmpty(pwd))
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
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper() || userManageInfo.Status != "正常" || userManageInfo.DeptID != deptId)
			{
				result = null;
			}
			else
			{
				bool flag = true;
				bool flag2 = true;
				int num = (userManageInfo.Right == "系统管理员") ? 0 : userManageInfo.RightID;
				DALRight dALRight = new DALRight();
				if (num > 0)
				{
					if (deptId == 1)
					{
						if (dALRight.GetRight(num, "jc_r27"))
						{
							flag = false;
						}
						if (dALRight.GetRight(num, "jc_r28"))
						{
							flag2 = false;
						}
					}
					else
					{
						if (dALRight.GetRight(num, "jc_r12"))
						{
							flag = false;
						}
						if (dALRight.GetRight(num, "jc_r13"))
						{
							flag2 = false;
						}
					}
				}
				DALGoods dALGoods = new DALGoods();
				GoodsInfo model = dALGoods.GetModel(GoodsID);
				if (!flag)
				{
					model.PriceCost = new decimal?(0m);
				}
				if (!flag2)
				{
					model.SupplierName = "";
				}
				result = model;
			}
		}
		return result;
	}

	[WebMethod]
	public List<SchStock.PartStockDept> GetStockDept(int GoodsID, int deptId, string userName, int userid, int staffid, string pwd, bool showzero)
	{
		List<SchStock.PartStockDept> result;
		if (deptId == 0 || userid == 0 || GoodsID == 0 || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(userName))
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
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper() || userManageInfo.Status != "正常" || userManageInfo.DeptID != deptId)
			{
				result = null;
			}
			else
			{
				List<SchStock.PartStockDept> list = new List<SchStock.PartStockDept>();
				int num = (userManageInfo.Right == "系统管理员") ? 0 : userManageInfo.RightID;
				DALRight dALRight = new DALRight();
				if (num > 0)
				{
					if (deptId == 1)
					{
						if (dALRight.GetRight(num, "jc_r36"))
						{
						}
					}
					else if (dALRight.GetRight(num, "jc_r14"))
					{
					}
				}
				string text = " and DeptID=" + deptId;
				if (!showzero)
				{
					text += " and Stock<>0 ";
				}
				if (num > 0)
				{
					if (dALRight.GetRight(num, "ck_r82"))
					{
						object obj = text;
						text = string.Concat(new object[]
						{
							obj,
							" and (StockAdmID1=",
							staffid,
							" or StockAdmID2=",
							staffid,
							" or charindex('",
							userName,
							"',OtherStockAdm)>0) "
						});
					}
				}
				DataSet dataList = DALCommon.GetDataList("ck_stockdept", "", "bReject=0 and GoodsID=" + GoodsID + text);
				for (int i = 0; i < dataList.Tables[0].Rows.Count; i++)
				{
					list.Add(new SchStock.PartStockDept
					{
						ID = Convert.ToInt32(dataList.Tables[0].Rows[i]["ID"].ToString()),
						Stock = dataList.Tables[0].Rows[i]["Stock"].ToString(),
						CostPrice = dataList.Tables[0].Rows[i]["CostPrice"].ToString(),
						StockLocName = dataList.Tables[0].Rows[i]["StockLocName"].ToString(),
						StockName = dataList.Tables[0].Rows[i]["StockName"].ToString(),
						DownWarning = dataList.Tables[0].Rows[i]["DownWarning"].ToString(),
						UpWarning = dataList.Tables[0].Rows[i]["UpWarning"].ToString()
					});
				}
				result = list;
			}
		}
		return result;
	}
}
