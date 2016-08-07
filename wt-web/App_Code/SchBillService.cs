using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using wt.DAL;
using wt.Library;
using wt.Model;

[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SchBillService : WebService
{
	public class PartBillInfo
	{
		private int id;

		private int count;

		private string billID;

		private string curStatus;

		private string servicesType;

		private string customerName;

		private string fault;

		public int Id
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

		public string BillID
		{
			get
			{
				return this.billID;
			}
			set
			{
				this.billID = value;
			}
		}

		public string Fault
		{
			get
			{
				return this.fault;
			}
			set
			{
				this.fault = value;
			}
		}

		public string CurStatus
		{
			get
			{
				return this.curStatus;
			}
			set
			{
				this.curStatus = value;
			}
		}

		public string ServicesType
		{
			get
			{
				return this.servicesType;
			}
			set
			{
				this.servicesType = value;
			}
		}

		public string CustomerName
		{
			get
			{
				return this.customerName;
			}
			set
			{
				this.customerName = value;
			}
		}
	}

	[WebMethod]
	public List<SchBillService.PartBillInfo> SchBill(int pageNum, int deptId, string userName, int userid, string pwd, string checkText)
	{
		List<SchBillService.PartBillInfo> result;
		if (deptId == 0 || userid == 0 || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(userName))
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
				string a = "";
				string text = "";
				string a2 = "";
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
				int count = 0;
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
				DataTable dataTable2 = DALCommon.GetList_HL(1, "fw_services", "", 20, pageNum, text2, fldSort, out count).Tables[0];
				List<SchBillService.PartBillInfo> list = new List<SchBillService.PartBillInfo>();
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					list.Add(new SchBillService.PartBillInfo
					{
						Id = int.Parse(dataTable2.Rows[i]["ID"].ToString()),
						Count = count,
						BillID = dataTable2.Rows[i]["BillID"].ToString(),
						CurStatus = dataTable2.Rows[i]["CurStatus"].ToString(),
						CustomerName = dataTable2.Rows[i]["CustomerName"].ToString(),
						ServicesType = dataTable2.Rows[i]["ServicesType"].ToString()
					});
				}
				result = list;
			}
		}
		return result;
	}

	protected string strParm(int deptId, string checkText)
	{
		string text;
		if (deptId == 1)
		{
			text = " 1=1 ";
		}
		else
		{
			text = string.Concat(new object[]
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
		string text2 = FunLibrary.ChkInput(checkText);
		int schid = 0;
		if (text2 != "")
		{
			DALServices dALServices = new DALServices();
			text += dALServices.GetSchWhere(schid, text2);
		}
		return text;
	}

	[WebMethod]
	public List<SchBillService.PartBillInfo> SchBillByDsch(int pageNum, int deptId, string userName, int userid, string pwd, int dsch, string checkText)
	{
		List<SchBillService.PartBillInfo> result;
		if (deptId == 0 || userid == 0 || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(userName))
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
				string a = "";
				string text = "";
				string a2 = "";
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
				int count = 0;
				string text2 = this.strParm(deptId, dsch, checkText);
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
				DataTable dataTable2 = DALCommon.GetList_HL(1, "fw_services", "", 20, pageNum, text2, fldSort, out count).Tables[0];
				List<SchBillService.PartBillInfo> list = new List<SchBillService.PartBillInfo>();
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					list.Add(new SchBillService.PartBillInfo
					{
						Id = int.Parse(dataTable2.Rows[i]["ID"].ToString()),
						Count = count,
						BillID = dataTable2.Rows[i]["BillID"].ToString(),
						CurStatus = dataTable2.Rows[i]["CurStatus"].ToString(),
						CustomerName = dataTable2.Rows[i]["CustomerName"].ToString(),
						ServicesType = dataTable2.Rows[i]["ServicesType"].ToString()
					});
				}
				result = list;
			}
		}
		return result;
	}

	protected string strParm(int deptId, int dsch, string checkText)
	{
		string text;
		if (deptId == 1)
		{
			text = " 1=1 ";
		}
		else
		{
			text = string.Concat(new object[]
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
		string text2 = FunLibrary.ChkInput(checkText);
		if (text2 != "")
		{
			DALServices dALServices = new DALServices();
			text += dALServices.GetSchWhere(dsch, text2);
		}
		return text;
	}

	[WebMethod]
	public List<SchBillService.PartBillInfo> SchBillforAllot(int pageNum, int deptId, string userName, int userid, string pwd, string checkText)
	{
		List<SchBillService.PartBillInfo> result;
		if (deptId == 0 || userid == 0 || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(userName))
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
				string a = "";
				string text = "";
				string a2 = "";
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
				int count = 0;
				string text2 = this.strParm(deptId, checkText);
				text2 += " and (curStatus='处理中'or curStatus='待处理')";
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
				DataTable dataTable2 = DALCommon.GetList_HL(1, "fw_services", "", 20, pageNum, text2, fldSort, out count).Tables[0];
				List<SchBillService.PartBillInfo> list = new List<SchBillService.PartBillInfo>();
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					list.Add(new SchBillService.PartBillInfo
					{
						Id = int.Parse(dataTable2.Rows[i]["ID"].ToString()),
						Count = count,
						BillID = dataTable2.Rows[i]["BillID"].ToString(),
						CurStatus = dataTable2.Rows[i]["CurStatus"].ToString(),
						CustomerName = dataTable2.Rows[i]["CustomerName"].ToString(),
						ServicesType = dataTable2.Rows[i]["ServicesType"].ToString(),
						Fault = dataTable2.Rows[i]["Fault"].ToString()
					});
				}
				result = list;
			}
		}
		return result;
	}

	[WebMethod]
	public DataTable getDetailForAllot(string billid, int userid, string pwd)
	{
		DataTable result;
		if (userid == 0 || string.IsNullOrEmpty(billid) || string.IsNullOrEmpty(pwd))
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
			else if (pwd.ToUpper() != userManageInfo.Pwd.ToUpper() || userManageInfo.Status != "正常")
			{
				result = null;
			}
			else
			{
				string value = "";
				DataTable dataTable = DALCommon.GetDataList("fw_servicesprocess", "", " [BillID]='" + billid + "'").Tables[0];
				DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "Fault,DisposalOper", " [ID]=" + dataTable.Rows[0]["BillID"].ToString()).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					value = dataTable2.Rows[0]["Fault"].ToString();
				}
				DataTable dataTable3 = new DataTable("Table");
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					dataTable3.Columns.Add(dataTable.Columns[i].ColumnName, dataTable.Columns[i].DataType);
				}
				dataTable3.Columns.Add("Fault", Type.GetType("System.String"));
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					DataRow dataRow = dataTable3.NewRow();
					for (int i = 0; i < dataTable.Columns.Count; i++)
					{
						if (!dataTable.Rows[j][dataTable.Columns[i].ColumnName].ToString().Trim().Equals(""))
						{
							dataRow[dataTable.Columns[i].ColumnName] = dataTable.Rows[j][dataTable.Columns[i].ColumnName].ToString();
						}
					}
					dataRow["Fault"] = value;
					dataTable3.Rows.Add(dataRow);
				}
				result = dataTable3;
			}
		}
		return result;
	}

	[WebMethod]
	public WSbillService GetModelByID(string ID, string userName, string pwd, int deptId, int userid)
	{
		WSbillService result;
		if (deptId == 0 || userid == 0 || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(userName))
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
				WSbillService wSbillService = new WSbillService();
				string strCondition = " [ID]=" + ID;
				DataTable dataTable = DALCommon.GetDataList("fw_services", "", strCondition).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					wSbillService.ID = dataTable.Rows[0]["ID"].ToString();
					wSbillService.BillID = dataTable.Rows[0]["BillID"].ToString();
					wSbillService.TakeDept = dataTable.Rows[0]["TakeDept"].ToString();
					wSbillService.DisposalDept = dataTable.Rows[0]["DisposalDept"].ToString();
					wSbillService.curStatus = dataTable.Rows[0]["curStatus"].ToString();
					wSbillService.PayeeOperID = dataTable.Rows[0]["PayeeOperID"].ToString();
					wSbillService.ChkOperatorID = dataTable.Rows[0]["ChkOperatorID"].ToString();
					wSbillService.BackSeeOperID = dataTable.Rows[0]["BackSeeOperID"].ToString();
					wSbillService.TakeOverID = dataTable.Rows[0]["TakeOverID"].ToString();
					wSbillService.DisposalID = dataTable.Rows[0]["DisposalID"].ToString();
					wSbillService.ServicesType = dataTable.Rows[0]["ServicesType"].ToString();
					wSbillService.TakeStyle = dataTable.Rows[0]["TakeStyle"].ToString();
					wSbillService.TakeStyleID = dataTable.Rows[0]["TakeStyleID"].ToString();
					wSbillService.TypeID = dataTable.Rows[0]["TypeID"].ToString();
					wSbillService.OfferConf = dataTable.Rows[0]["OfferConf"].ToString();
					wSbillService.Time_Make = dataTable.Rows[0]["Time_Make"].ToString();
					wSbillService.Time_TakeOver = dataTable.Rows[0]["Time_TakeOver"].ToString();
					wSbillService.Time_Start = dataTable.Rows[0]["Time_Start"].ToString();
					wSbillService.Time_Over = dataTable.Rows[0]["Time_Over"].ToString();
					wSbillService.Time_Payee = dataTable.Rows[0]["Time_Payee"].ToString();
					wSbillService.OperatorID = dataTable.Rows[0]["OperatorID"].ToString();
					wSbillService.Time_BackSee = dataTable.Rows[0]["Time_BackSee"].ToString();
					wSbillService.Time_Close = dataTable.Rows[0]["Time_Close"].ToString();
					wSbillService.Operator = dataTable.Rows[0]["Operator"].ToString();
					wSbillService.Person = dataTable.Rows[0]["Person"].ToString();
					wSbillService.PersonID = dataTable.Rows[0]["PersonID"].ToString();
					wSbillService.StartOperator = dataTable.Rows[0]["StartOperator"].ToString();
					wSbillService.PayeeOper = dataTable.Rows[0]["PayeeOper"].ToString();
					wSbillService.ChkOperator = dataTable.Rows[0]["ChkOperator"].ToString();
					wSbillService.ProductClassID = dataTable.Rows[0]["ProductClassID"].ToString();
					wSbillService.ProductBrandID = dataTable.Rows[0]["ProductBrandID"].ToString();
					wSbillService.ProductModelID = dataTable.Rows[0]["ProductModelID"].ToString();
					wSbillService.BackSeeOper = dataTable.Rows[0]["BackSeeOper"].ToString();
					wSbillService.CustomerName = dataTable.Rows[0]["CustomerName"].ToString();
					wSbillService.BranchID = dataTable.Rows[0]["BranchID"].ToString();
					wSbillService.CustomerFrom = dataTable.Rows[0]["CustomerFrom"].ToString();
					wSbillService.CustomerClass = dataTable.Rows[0]["CustomerClass"].ToString();
					wSbillService.userdef1 = dataTable.Rows[0]["userdef1"].ToString();
					wSbillService.userdef2 = dataTable.Rows[0]["userdef2"].ToString();
					wSbillService.userdef3 = dataTable.Rows[0]["userdef3"].ToString();
					wSbillService.userdef4 = dataTable.Rows[0]["userdef4"].ToString();
					wSbillService.userdef5 = dataTable.Rows[0]["userdef5"].ToString();
					wSbillService.userdef6 = dataTable.Rows[0]["userdef6"].ToString();
					wSbillService.LinkMan = dataTable.Rows[0]["LinkMan"].ToString();
					wSbillService.Tel = dataTable.Rows[0]["Tel"].ToString();
					wSbillService.UsePerson = dataTable.Rows[0]["UsePerson"].ToString();
					wSbillService.UsePersonDept = dataTable.Rows[0]["UsePersonDept"].ToString();
					wSbillService.UsePersonTel = dataTable.Rows[0]["UsePersonTel"].ToString();
					wSbillService.Area = dataTable.Rows[0]["Area"].ToString();
					wSbillService.Adr = dataTable.Rows[0]["Adr"].ToString();
					wSbillService.ProductSN1 = dataTable.Rows[0]["ProductSN1"].ToString();
					wSbillService.ProductSN2 = dataTable.Rows[0]["ProductSN2"].ToString();
					wSbillService.FinTec = dataTable.Rows[0]["FinTec"].ToString();
					wSbillService.BuyDate = dataTable.Rows[0]["BuyDate"].ToString();
					wSbillService.BuyFrom = dataTable.Rows[0]["BuyFrom"].ToString();
					wSbillService.ProductClass = dataTable.Rows[0]["ProductClass"].ToString();
					wSbillService.ProductModel = dataTable.Rows[0]["ProductModel"].ToString();
					wSbillService.ProductBrand = dataTable.Rows[0]["ProductBrand"].ToString();
					wSbillService.Aspect = dataTable.Rows[0]["Aspect"].ToString();
					wSbillService.CusType = dataTable.Rows[0]["CusType"].ToString();
					wSbillService.WarrantyID = dataTable.Rows[0]["WarrantyID"].ToString();
					wSbillService.Accessory = dataTable.Rows[0]["Accessory"].ToString();
					wSbillService.Fault = dataTable.Rows[0]["Fault"].ToString();
					wSbillService.Warranty = dataTable.Rows[0]["Warranty"].ToString();
					wSbillService.BuyInvoice = dataTable.Rows[0]["BuyInvoice"].ToString();
					wSbillService.dPoint = dataTable.Rows[0]["dPoint"].ToString();
					wSbillService.SellerID = dataTable.Rows[0]["SellerID"].ToString();
					wSbillService.Speding = dataTable.Rows[0]["Speding"].ToString();
					wSbillService.bRepair = dataTable.Rows[0]["bRepair"].ToString();
					wSbillService.SaveID = dataTable.Rows[0]["SaveID"].ToString();
					wSbillService.SupplierID = dataTable.Rows[0]["SupplierID"].ToString();
					wSbillService.ChargeCorp = dataTable.Rows[0]["ChargeCorp"].ToString();
					wSbillService.DisposalOper = dataTable.Rows[0]["DisposalOper"].ToString();
					wSbillService.SubscribeTime = dataTable.Rows[0]["SubscribeTime"].ToString();
					wSbillService.SubscribeConnectTime = dataTable.Rows[0]["SubscribeConnectTime"].ToString();
					wSbillService.SubscribePrice = dataTable.Rows[0]["SubscribePrice"].ToString();
					wSbillService.PreCharge = dataTable.Rows[0]["PreCharge"].ToString();
					wSbillService.RepairStatus = dataTable.Rows[0]["RepairStatus"].ToString();
					wSbillService.RepairType = dataTable.Rows[0]["RepairType"].ToString();
					wSbillService.RepairCorpID = dataTable.Rows[0]["RepairCorpID"].ToString();
					wSbillService.RepairCorp = dataTable.Rows[0]["RepairCorp"].ToString();
					wSbillService.Remark = dataTable.Rows[0]["Remark"].ToString();
					wSbillService.CancelReason = dataTable.Rows[0]["CancelReason"].ToString();
					wSbillService.RepairSndDate = dataTable.Rows[0]["RepairSndDate"].ToString();
					wSbillService.RepairRcvDate = dataTable.Rows[0]["RepairRcvDate"].ToString();
					wSbillService.RepairCost = dataTable.Rows[0]["RepairCost"].ToString();
					wSbillService.CustomerID = dataTable.Rows[0]["CustomerID"].ToString();
					wSbillService.WarrantyChargeCorpID = dataTable.Rows[0]["WarrantyChargeCorpID"].ToString();
					wSbillService.PostNO = dataTable.Rows[0]["PostNO"].ToString();
					wSbillService.Postage = dataTable.Rows[0]["Postage"].ToString();
					wSbillService.MaterailCost = dataTable.Rows[0]["MaterailCost"].ToString();
					wSbillService.ExtraCost = dataTable.Rows[0]["ExtraCost"].ToString();
					wSbillService.Fee_Materail = dataTable.Rows[0]["Fee_Materail"].ToString();
					wSbillService.Fee_Labor = dataTable.Rows[0]["Fee_Labor"].ToString();
					wSbillService.Fee_Add = dataTable.Rows[0]["Fee_Add"].ToString();
					wSbillService.WarrantyChargeValue = dataTable.Rows[0]["WarrantyChargeValue"].ToString();
					wSbillService.ChargeValue = dataTable.Rows[0]["ChargeValue"].ToString();
					wSbillService.Fee_Total = dataTable.Rows[0]["Fee_Total"].ToString();
					wSbillService.Profit = dataTable.Rows[0]["Profit"].ToString();
					wSbillService.WarrantyEndDate = dataTable.Rows[0]["WarrantyEndDate"].ToString();
					wSbillService.WarrantyBound = dataTable.Rows[0]["WarrantyBound"].ToString();
					wSbillService.GoodsTo = dataTable.Rows[0]["GoodsTo"].ToString();
					wSbillService.ConnectDate = dataTable.Rows[0]["ConnectDate"].ToString();
					wSbillService.bCall = dataTable.Rows[0]["bCall"].ToString();
					wSbillService.SmsStatus = dataTable.Rows[0]["SmsStatus"].ToString();
					wSbillService.ConfirmDate = dataTable.Rows[0]["ConfirmDate"].ToString();
					wSbillService.CorpName = dataTable.Rows[0]["CorpName"].ToString();
					wSbillService.Coordinates = dataTable.Rows[0]["Coordinates"].ToString();
					wSbillService.CorpLinkMan = dataTable.Rows[0]["CorpLinkMan"].ToString();
					wSbillService.CorpTel = dataTable.Rows[0]["CorpTel"].ToString();
					wSbillService.CorpFax = dataTable.Rows[0]["CorpFax"].ToString();
					wSbillService.CorpZip = dataTable.Rows[0]["CorpZip"].ToString();
					wSbillService.CorpArea = dataTable.Rows[0]["CorpArea"].ToString();
					wSbillService.CorpAdr = dataTable.Rows[0]["CorpAdr"].ToString();
					wSbillService.InCash = dataTable.Rows[0]["InCash"].ToString();
					wSbillService._PRI = dataTable.Rows[0]["_PRI"].ToString();
					wSbillService.ContractNO = dataTable.Rows[0]["ContractNO"].ToString();
					wSbillService.SndStyle = dataTable.Rows[0]["SndStyle"].ToString();
					wSbillService.SndStyleID = dataTable.Rows[0]["SndStyleID"].ToString();
					wSbillService.ServiceLevelID = dataTable.Rows[0]["ServiceLevelID"].ToString();
					wSbillService.ResponseTime = dataTable.Rows[0]["ResponseTime"].ToString();
					wSbillService.RepairTime = dataTable.Rows[0]["RepairTime"].ToString();
					wSbillService.DeviceNO = dataTable.Rows[0]["DeviceNO"].ToString();
					wSbillService.PreMoney = dataTable.Rows[0]["PreMoney"].ToString();
					wSbillService.RealMoney = dataTable.Rows[0]["RealMoney"].ToString();
					wSbillService.TakeSteps = dataTable.Rows[0]["TakeSteps"].ToString();
					wSbillService.QtyType = dataTable.Rows[0]["QtyType"].ToString();
					wSbillService.OldQtyType = dataTable.Rows[0]["OldQtyType"].ToString();
					wSbillService.HaveAmount = dataTable.Rows[0]["HaveAmount"].ToString();
					wSbillService.NotChargeAmount = dataTable.Rows[0]["NotChargeAmount"].ToString();
					wSbillService.Path = dataTable.Rows[0]["Path"].ToString();
					wSbillService.bAgain = dataTable.Rows[0]["bAgain"].ToString();
					wSbillService.Deduct = dataTable.Rows[0]["Deduct"].ToString();
					wSbillService.VisitDate = dataTable.Rows[0]["VisitDate"].ToString();
					wSbillService.VisitCusName = dataTable.Rows[0]["VisitCusName"].ToString();
					wSbillService.VisitOpinon = dataTable.Rows[0]["VisitOpinon"].ToString();
					wSbillService.VisitRemark = dataTable.Rows[0]["VisitRemark"].ToString();
					wSbillService.VisitOperator = dataTable.Rows[0]["VisitOperator"].ToString();
					wSbillService.VisitStyle = dataTable.Rows[0]["VisitStyle"].ToString();
					wSbillService.HFQK = dataTable.Rows[0]["HFQK"].ToString();
					wSbillService.VisitID = dataTable.Rows[0]["VisitID"].ToString();
				}
				result = wSbillService;
			}
		}
		return result;
	}

	[WebMethod]
	public DataTable GetCancelReason()
	{
		int num = 0;
		DataSet list_HL = DALCommon.GetList_HL(0, "CancelReason", "", 0, 0, "", "Array asc", out num);
		return list_HL.Tables[0];
	}
}
