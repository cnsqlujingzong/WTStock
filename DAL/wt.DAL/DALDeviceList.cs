using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALDeviceList
	{
		public int Add(DeviceListInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model.ProductSN1 != string.Empty && model.ProductSN1 != null)
			{
				text += "ProductSN1";
				text2 = text2 + "'" + model.ProductSN1 + "'";
			}
			text += ",CustomerID";
			text2 = text2 + "," + model.CustomerID.ToString();
			if (model.LinkMan != string.Empty && model.LinkMan != null)
			{
				text += ",LinkMan";
				text2 = text2 + ",'" + model.LinkMan + "'";
			}
			if (model.CusDept != string.Empty && model.CusDept != null)
			{
				text += ",CusDept";
				text2 = text2 + ",'" + model.CusDept + "'";
			}
			if (model.Tel != string.Empty && model.Tel != null)
			{
				text += ",Tel";
				text2 = text2 + ",'" + model.Tel + "'";
			}
			if (model.Tel2 != string.Empty && model.Tel2 != null)
			{
				text += ",Tel2";
				text2 = text2 + ",'" + model.Tel2 + "'";
			}
			if (model.Fax != string.Empty && model.Fax != null)
			{
				text += ",Fax";
				text2 = text2 + ",'" + model.Fax + "'";
			}
			if (model.Zip != string.Empty && model.Zip != null)
			{
				text += ",Zip";
				text2 = text2 + ",'" + model.Zip + "'";
			}
			if (model.Adr != string.Empty && model.Adr != null)
			{
				text += ",Adr";
				text2 = text2 + ",'" + model.Adr + "'";
			}
			if (model.ProductBrandID > 0)
			{
				text += ",ProductBrandID";
				text2 = text2 + "," + model.ProductBrandID.ToString();
			}
			if (model.ProductClassID > 0)
			{
				text += ",ProductClassID";
				text2 = text2 + "," + model.ProductClassID.ToString();
			}
			if (model.ProductModelID > 0)
			{
				text += ",ProductModelID";
				text2 = text2 + "," + model.ProductModelID.ToString();
			}
			if (model.ProductSN2 != string.Empty && model.ProductSN2 != null)
			{
				text += ",ProductSN2";
				text2 = text2 + ",'" + model.ProductSN2 + "'";
			}
			if (model.ProductAspect != string.Empty && model.ProductAspect != null)
			{
				text += ",ProductAspect";
				text2 = text2 + ",'" + model.ProductAspect + "'";
			}
			if (model.BuyDate != string.Empty && model.BuyDate != null)
			{
				text += ",BuyDate";
				text2 = text2 + ",'" + model.BuyDate + "'";
			}
			if (model.BuyFrom != string.Empty && model.BuyFrom != null)
			{
				text += ",BuyFrom";
				text2 = text2 + ",'" + model.BuyFrom + "'";
			}
			if (model.BuyInvoice != string.Empty && model.BuyInvoice != null)
			{
				text += ",BuyInvoice";
				text2 = text2 + ",'" + model.BuyInvoice + "'";
			}
			if (model.MaintenancePeriod != string.Empty && model.MaintenancePeriod != null)
			{
				text += ",MaintenancePeriod";
				text2 = text2 + ",'" + model.MaintenancePeriod + "'";
			}
			if (model.WarrantyID > 0)
			{
				text += ",WarrantyID";
				text2 = text2 + "," + model.WarrantyID.ToString();
			}
			if (model.RepairTimes > 0)
			{
				text += ",RepairTimes";
				text2 = text2 + "," + model.RepairTimes.ToString();
			}
			if (model.WarrantyStart != string.Empty && model.WarrantyStart != null)
			{
				text += ",WarrantyStart";
				text2 = text2 + ",'" + model.WarrantyStart + "'";
			}
			if (model.WarrantyEnd != string.Empty && model.WarrantyEnd != null)
			{
				text += ",WarrantyEnd";
				text2 = text2 + ",'" + model.WarrantyEnd + "'";
			}
			if (model.Repairlately != string.Empty && model.Repairlately != null)
			{
				text += ",Repairlately";
				text2 = text2 + ",'" + model.Repairlately + "'";
			}
			if (model.ContractWarrantyStart != string.Empty && model.ContractWarrantyStart != null)
			{
				text += ",ContractWarrantyStart";
				text2 = text2 + ",'" + model.ContractWarrantyStart + "'";
			}
			if (model.ContractWarrantyEnd != string.Empty && model.ContractWarrantyEnd != null)
			{
				text += ",ContractWarrantyEnd";
				text2 = text2 + ",'" + model.ContractWarrantyEnd + "'";
			}
			if (model.RepairWarrantyEnd != string.Empty && model.RepairWarrantyEnd != null)
			{
				text += ",RepairWarrantyEnd";
				text2 = text2 + ",'" + model.RepairWarrantyEnd + "'";
			}
			if (model.ContractNO != string.Empty && model.ContractNO != null)
			{
				text += ",ContractNO";
				text2 = text2 + ",'" + model.ContractNO + "'";
			}
			if (model.InstallDate != string.Empty && model.InstallDate != null)
			{
				text += ",InstallDate";
				text2 = text2 + ",'" + model.InstallDate + "'";
			}
			if (model.Remark != string.Empty && model.Remark != null)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.DeviceNO != string.Empty && model.Remark != null)
			{
				text += ",DeviceNO";
				text2 = text2 + ",'" + model.DeviceNO + "'";
			}
			if (model.Property > 0)
			{
				text += ",Property";
				text2 = text2 + "," + model.Property.ToString();
			}
			if (model.BuyPrice > 0m)
			{
				text += ",BuyPrice";
				text2 = text2 + "," + model.BuyPrice.ToString();
			}
			if (model.userdef1 != string.Empty)
			{
				text += ",userdef1";
				text2 = text2 + ",'" + model.userdef1 + "'";
			}
			if (model.userdef2 != string.Empty)
			{
				text += ",userdef2";
				text2 = text2 + ",'" + model.userdef2 + "'";
			}
			if (model.userdef3 != string.Empty)
			{
				text += ",userdef3";
				text2 = text2 + ",'" + model.userdef3 + "'";
			}
			if (model.userdef4 != string.Empty)
			{
				text += ",userdef4";
				text2 = text2 + ",'" + model.userdef4 + "'";
			}
			if (model.userdef5 != string.Empty)
			{
				text += ",userdef5";
				text2 = text2 + ",'" + model.userdef5 + "'";
			}
			if (model.Technicians != string.Empty)
			{
				text += ",Technicians";
				text2 = text2 + ",'" + model.Technicians + "'";
			}
			return DALCommon.InsertData("DeviceList", text, text2, " 1=2 ", "机器档案", "ID", out strMsg, out iTbid);
		}

		public int Update(DeviceListInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "ProductSN1='" + model.ProductSN1 + "'";
			text = text + ",CustomerID=" + model.CustomerID.ToString();
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",CusDept='" + model.CusDept + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Tel2='" + model.Tel2 + "'";
			text = text + ",Fax='" + model.Fax + "'";
			text = text + ",Zip='" + model.Zip + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",DeviceNO='" + model.DeviceNO + "'";
			text = text + ",Property=" + model.Property.ToString();
			text = text + ",BuyPrice=" + model.BuyPrice.ToString();
			if (model.ProductBrandID > 0)
			{
				text = text + ",ProductBrandID=" + model.ProductBrandID.ToString();
			}
			else
			{
				text += ",ProductBrandID=null";
			}
			if (model.ProductClassID > 0)
			{
				text = text + ",ProductClassID=" + model.ProductClassID.ToString();
			}
			else
			{
				text += ",ProductClassID=null";
			}
			if (model.ProductModelID > 0)
			{
				text = text + ",ProductModelID=" + model.ProductModelID.ToString();
			}
			else
			{
				text += ",ProductModelID=null";
			}
			text = text + ",ProductSN2='" + model.ProductSN2 + "'";
			if (model.ProductAspect != string.Empty)
			{
				text = text + ",ProductAspect='" + model.ProductAspect + "'";
			}
			if (model.BuyDate != string.Empty)
			{
				text = text + ",BuyDate='" + model.BuyDate + "'";
			}
			else
			{
				text += ",BuyDate=null";
			}
			text = text + ",BuyFrom='" + model.BuyFrom + "'";
			text = text + ",BuyInvoice='" + model.BuyInvoice + "'";
			text = text + ",MaintenancePeriod='" + model.MaintenancePeriod + "'";
			if (model.WarrantyID > 0)
			{
				text = text + ",WarrantyID=" + model.WarrantyID.ToString();
			}
			else
			{
				text += ",WarrantyID=null";
			}
			text = text + ",RepairTimes=" + model.RepairTimes.ToString();
			if (model.WarrantyStart != string.Empty)
			{
				text = text + ",WarrantyStart='" + model.WarrantyStart + "'";
			}
			else
			{
				text += ",WarrantyStart=null";
			}
			if (model.WarrantyEnd != string.Empty)
			{
				text = text + ",WarrantyEnd='" + model.WarrantyEnd + "'";
			}
			else
			{
				text += ",WarrantyEnd=null";
			}
			if (model.Repairlately != string.Empty)
			{
				text = text + ",Repairlately='" + model.Repairlately + "'";
			}
			else
			{
				text += ",Repairlately=null";
			}
			if (model.ContractWarrantyStart != string.Empty)
			{
				text = text + ",ContractWarrantyStart='" + model.ContractWarrantyStart + "'";
			}
			else
			{
				text += ",ContractWarrantyStart=null";
			}
			if (model.ContractWarrantyEnd != string.Empty)
			{
				text = text + ",ContractWarrantyEnd='" + model.ContractWarrantyEnd + "'";
			}
			else
			{
				text += ",ContractWarrantyEnd=null";
			}
			if (model.RepairWarrantyEnd != string.Empty)
			{
				text = text + ",RepairWarrantyEnd='" + model.RepairWarrantyEnd + "'";
			}
			else
			{
				text += ",RepairWarrantyEnd=null";
			}
			text = text + ",ContractNO='" + model.ContractNO + "'";
			if (model.InstallDate != string.Empty)
			{
				text = text + ",InstallDate='" + model.InstallDate + "'";
			}
			else
			{
				text += ",InstallDate=null";
			}
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",userdef1='" + model.userdef1 + "'";
			text = text + ",userdef2='" + model.userdef2 + "'";
			text = text + ",userdef3='" + model.userdef3 + "'";
			text = text + ",userdef4='" + model.userdef4 + "'";
			text = text + ",userdef5='" + model.userdef5 + "'";
			text = text + ",Technicians='" + model.Technicians + "'";
			return DALCommon.UpdateData("DeviceList", text, " [ID]=" + model.ID.ToString(), " 1=2 ", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int FWUpdate(DeviceListInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "ProductSN1='" + model.ProductSN1 + "'";
			text = text + ",CustomerID=" + model.CustomerID.ToString();
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",CusDept='" + model.CusDept + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Tel2='" + model.Tel2 + "'";
			text = text + ",Fax='" + model.Fax + "'";
			text = text + ",Zip='" + model.Zip + "'";
			text = text + ",Adr='" + model.Adr + "'";
			if (model.ProductBrandID > 0)
			{
				text = text + ",ProductBrandID=" + model.ProductBrandID.ToString();
			}
			else
			{
				text += ",ProductBrandID=null";
			}
			if (model.ProductClassID > 0)
			{
				text = text + ",ProductClassID=" + model.ProductClassID.ToString();
			}
			else
			{
				text += ",ProductClassID=null";
			}
			if (model.ProductModelID > 0)
			{
				text = text + ",ProductModelID=" + model.ProductModelID.ToString();
			}
			else
			{
				text += ",ProductModelID=null";
			}
			text = text + ",ProductSN2='" + model.ProductSN2 + "'";
			if (model.ProductAspect != string.Empty)
			{
				text = text + ",ProductAspect='" + model.ProductAspect + "'";
			}
			if (model.BuyDate != string.Empty)
			{
				text = text + ",BuyDate='" + model.BuyDate + "'";
			}
			else
			{
				text += ",BuyDate=null";
			}
			text = text + ",BuyFrom='" + model.BuyFrom + "'";
			text = text + ",BuyInvoice='" + model.BuyInvoice + "'";
			if (model.WarrantyID > 0)
			{
				text = text + ",WarrantyID=" + model.WarrantyID.ToString();
			}
			else
			{
				text += ",WarrantyID=null";
			}
			return DALCommon.UpdateData("DeviceList", text, " [ID]=" + model.ID.ToString(), " 1=2 ", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int FWUpdateDo(DeviceListInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "ProductSN1='" + model.ProductSN1 + "'";
			if (model.ProductBrandID > 0)
			{
				text = text + ",ProductBrandID=" + model.ProductBrandID.ToString();
			}
			else
			{
				text += ",ProductBrandID=null";
			}
			if (model.ProductClassID > 0)
			{
				text = text + ",ProductClassID=" + model.ProductClassID.ToString();
			}
			else
			{
				text += ",ProductClassID=null";
			}
			if (model.ProductModelID > 0)
			{
				text = text + ",ProductModelID=" + model.ProductModelID.ToString();
			}
			else
			{
				text += ",ProductModelID=null";
			}
			text = text + ",ProductSN2='" + model.ProductSN2 + "'";
			text = text + ",BuyInvoice='" + model.BuyInvoice + "'";
			if (model.WarrantyID > 0)
			{
				text = text + ",WarrantyID=" + model.WarrantyID.ToString();
			}
			else
			{
				text += ",WarrantyID=null";
			}
			return DALCommon.UpdateData("DeviceList", text, " [ID]=" + model.ID.ToString(), " 1=2 ", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public string TCount(string strWhere)
		{
			return DALCommon.TCount("DeviceList", strWhere);
		}

		public string GetSchWhere(int schid, string strcon)
		{
			string text = string.Empty;
			switch (schid)
			{
			case 0:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (CustomerNO like '%",
					strcon,
					"%' or _Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or Tel like '%",
					strcon,
					"%' or Tel2 like '%",
					strcon,
					"%' or ProductBrand like '%",
					strcon,
					"%' or ProductBrandCode like '%",
					strcon,
					"%' or ProductClass like '%",
					strcon,
					"%' or ProductClassCode like '%",
					strcon,
					"%' or ProductModel like '%",
					strcon,
					"%' or ProductModelCode like '%",
					strcon,
					"%' or ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%' or DeviceNO like '%",
					strcon,
					"%' or Property like '%",
					strcon,
					"%'or userdef1 like '%",
					strcon,
					"%' or userdef2 like '%",
					strcon,
					"%' or userdef3 like '%",
					strcon,
					"%' or userdef4 like '%",
					strcon,
					"%' or userdef5 like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 1:
				text = text + " and DeviceNO like '%" + strcon + "%' ";
				break;
			case 2:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (_Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 3:
				text = text + " and LinkMan like '%" + strcon + "%' ";
				break;
			case 4:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Tel like '%",
					strcon,
					"%' or Tel2 like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 5:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductBrand like '%",
					strcon,
					"%' or ProductBrandCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 6:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductClass like '%",
					strcon,
					"%' or ProductClassCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 7:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductModel like '%",
					strcon,
					"%' or ProductModelCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 8:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%')  "
				});
				break;
			}
			}
			return text;
		}

		public string GetMSchWhere(int schid, string strcon)
		{
			string text = string.Empty;
			switch (schid)
			{
			case 0:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (CustomerNO like '%",
					strcon,
					"%' or _Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or Tel like '%",
					strcon,
					"%' or Tel2 like '%",
					strcon,
					"%' or ProductBrand like '%",
					strcon,
					"%' or ProductBrandCode like '%",
					strcon,
					"%' or ProductClass like '%",
					strcon,
					"%' or ProductClassCode like '%",
					strcon,
					"%' or ProductModel like '%",
					strcon,
					"%' or ProductModelCode like '%",
					strcon,
					"%' or ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%' or DeviceNO like '%",
					strcon,
					"%' )"
				});
				break;
			}
			case 1:
				text = text + " and DeviceNO like '%" + strcon + "%' ";
				break;
			case 2:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (_Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 3:
				text = text + " and LinkMan like '%" + strcon + "%' ";
				break;
			case 4:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Tel like '%",
					strcon,
					"%' or Tel2 like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 5:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductBrand like '%",
					strcon,
					"%' or ProductBrandCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 6:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductClass like '%",
					strcon,
					"%' or ProductClassCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 7:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductModel like '%",
					strcon,
					"%' or ProductModelCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 8:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%')  "
				});
				break;
			}
			}
			return text;
		}

		public int GetModelID(int CustomerID, string ProductSN1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [ID] from DeviceList ");
			stringBuilder.Append(" where CustomerID=@CustomerID and ProductSN1=@ProductSN1 ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4),
				new SqlParameter("@ProductSN1", SqlDbType.VarChar, 50)
			};
			array[0].Value = CustomerID;
			array[1].Value = ProductSN1;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			int result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					result = int.Parse(decimal.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString()).ToString("#0"));
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int InputDevice(int ideptid, string strname, string strno, string strlinkman, string strdept, string strtel, string strtel2, string strfax, string strzip, string stradr, string strbrand, string strclass, string strmodel, string strsn1, string strsn2, string straspect, string strbuydate, string strbuyfrom, string strinvoice, string strprot, string strrepstatus, string strwstart, string strwend, string strlastdate, string strpstart, string strpend, string strfind, string strcontractno, string strinstall, string strremark, string strdeviceno, string struserdef1, string struserdef2, string struserdef3, string struserdef4, string struserdef5, bool bcover, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ideptid", SqlDbType.Int),
				new SqlParameter("@strname", SqlDbType.NVarChar, 50),
				new SqlParameter("@strno", SqlDbType.NVarChar, 50),
				new SqlParameter("@strlinkman", SqlDbType.NVarChar, 50),
				new SqlParameter("@strdept", SqlDbType.NVarChar, 50),
				new SqlParameter("@strtel", SqlDbType.NVarChar, 50),
				new SqlParameter("@strtel2", SqlDbType.NVarChar, 50),
				new SqlParameter("@strfax", SqlDbType.NVarChar, 50),
				new SqlParameter("@strzip", SqlDbType.NVarChar, 50),
				new SqlParameter("@stradr", SqlDbType.NVarChar, 200),
				new SqlParameter("@strbrand", SqlDbType.NVarChar, 50),
				new SqlParameter("@strclass", SqlDbType.NVarChar, 50),
				new SqlParameter("@strmodel", SqlDbType.NVarChar, 50),
				new SqlParameter("@strsn1", SqlDbType.NVarChar, 50),
				new SqlParameter("@strsn2", SqlDbType.NVarChar, 50),
				new SqlParameter("@straspect", SqlDbType.NVarChar, 50),
				new SqlParameter("@strbuydate", SqlDbType.NVarChar, 50),
				new SqlParameter("@strbuyfrom", SqlDbType.NVarChar, 50),
				new SqlParameter("@strinvoice", SqlDbType.NVarChar, 50),
				new SqlParameter("@strprot", SqlDbType.NVarChar, 50),
				new SqlParameter("@strrepstatus", SqlDbType.NVarChar, 50),
				new SqlParameter("@strwstart", SqlDbType.NVarChar, 50),
				new SqlParameter("@strwend", SqlDbType.NVarChar, 50),
				new SqlParameter("@strlastdate", SqlDbType.NVarChar, 50),
				new SqlParameter("@strpstart", SqlDbType.NVarChar, 50),
				new SqlParameter("@strpend", SqlDbType.NVarChar, 50),
				new SqlParameter("@strfind", SqlDbType.NVarChar, 50),
				new SqlParameter("@strcontractno", SqlDbType.NVarChar, 50),
				new SqlParameter("@strinstall", SqlDbType.NVarChar, 50),
				new SqlParameter("@strremark", SqlDbType.NVarChar, 3000),
				new SqlParameter("@strdeviceno", SqlDbType.NVarChar, 50),
				new SqlParameter("@struserdef1", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef2", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef3", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef4", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef5", SqlDbType.NVarChar, 100),
				new SqlParameter("@bCover", SqlDbType.Bit, 1),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = ideptid;
			array[1].Value = strname;
			array[2].Value = strno;
			array[3].Value = strlinkman;
			array[4].Value = strdept;
			array[5].Value = strtel;
			array[6].Value = strtel2;
			array[7].Value = strfax;
			array[8].Value = strzip;
			array[9].Value = stradr;
			array[10].Value = strbrand;
			array[11].Value = strclass;
			array[12].Value = strmodel;
			array[13].Value = strsn1;
			array[14].Value = strsn2;
			array[15].Value = straspect;
			array[16].Value = strbuydate;
			array[17].Value = strbuyfrom;
			array[18].Value = strinvoice;
			array[19].Value = strprot;
			array[20].Value = strrepstatus;
			array[21].Value = strwstart;
			array[22].Value = strwend;
			array[23].Value = strlastdate;
			array[24].Value = strpstart;
			array[25].Value = strpend;
			array[26].Value = strfind;
			array[27].Value = strcontractno;
			array[28].Value = strinstall;
			array[29].Value = strremark;
			array[30].Value = strdeviceno;
			array[31].Value = struserdef1;
			array[32].Value = struserdef2;
			array[33].Value = struserdef3;
			array[34].Value = struserdef4;
			array[35].Value = struserdef5;
			array[36].Value = bcover;
			array[37].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_inputdevice", array);
			strMsg = Convert.ToString(array[37].Value);
			return result;
		}
	}
}
