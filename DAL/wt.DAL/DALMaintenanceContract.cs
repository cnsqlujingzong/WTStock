using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALMaintenanceContract
	{
		public int Add(MaintenanceContractInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "OperatorID";
			text2 += model.OperatorID.ToString();
			if (model._Date != "")
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.SellerID > 0)
			{
				text += ",SellerID";
				text2 = text2 + "," + model.SellerID.ToString();
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.ContractTypeID > 0)
			{
				text += ",ContractTypeID";
				text2 = text2 + "," + model.ContractTypeID.ToString();
			}
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID.ToString();
			}
			if (model.CustomerName != "")
			{
				text += ",CustomerName";
				text2 = text2 + ",'" + model.CustomerName + "'";
			}
			if (model.LinkMan != "")
			{
				text += ",LinkMan";
				text2 = text2 + ",'" + model.LinkMan + "'";
			}
			if (model.Tel != "")
			{
				text += ",Tel";
				text2 = text2 + ",'" + model.Tel + "'";
			}
			if (model.Adr != "")
			{
				text += ",Adr";
				text2 = text2 + ",'" + model.Adr + "'";
			}
			if (model.dAmount > 0m)
			{
				text += ",dAmount";
				text2 = text2 + "," + model.dAmount.ToString();
			}
			if (model.dInCash > 0m)
			{
				text += ",dInCash";
				text2 = text2 + "," + model.dInCash.ToString();
			}
			if (model.ContractNO != string.Empty)
			{
				text += ",ContractNO";
				text2 = text2 + ",'" + model.ContractNO + "'";
			}
			if (model.Summary != string.Empty)
			{
				text += ",Summary";
				text2 = text2 + ",'" + model.Summary + "'";
			}
			if (model.StartDate != "")
			{
				text += ",StartDate";
				text2 = text2 + ",'" + model.StartDate + "'";
			}
			if (model.EndDate != "")
			{
				text += ",EndDate";
				text2 = text2 + ",'" + model.EndDate + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.Accessory != string.Empty)
			{
				text += ",Accessory";
				text2 = text2 + ",'" + model.Accessory + "'";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"ks_wxht_kd"
			});
			if (model.ContractDetailInfos != null)
			{
				foreach (ContractDetailInfo current in model.ContractDetailInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "DeviceID";
					text2 += current.DeviceID.ToString();
					if (current.ServiceLevelID > 0)
					{
						text += ",ServiceLevelID";
						text2 = text2 + "," + current.ServiceLevelID.ToString();
					}
					if (current.bRepair)
					{
						text += ",bRepair";
						text2 += ",1";
					}
					if (current.bConsumables)
					{
						text += ",bConsumables";
						text2 += ",1";
					}
					if (current.bMaterial)
					{
						text += ",bMaterial";
						text2 += ",1";
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					if (current.ProductSN != string.Empty)
					{
						text += ",ProductSN";
						text2 = text2 + ",'" + current.ProductSN + "'";
					}
					if (current.DeviceNO != string.Empty)
					{
						text += ",DeviceNO";
						text2 = text2 + ",'" + current.DeviceNO + "'";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "ks_wxht_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(MaintenanceContractInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "_Date='" + model._Date + "'";
			text = text + ",SellerID=" + model.SellerID.ToString();
			text = text + ",ContractTypeID=" + model.ContractTypeID.ToString();
			text = text + ",CustomerID=" + model.CustomerID.ToString();
			text = text + ",CustomerName='" + model.CustomerName + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",dAmount=" + model.dAmount.ToString();
			text = text + ",dInCash=" + model.dInCash.ToString();
			text = text + ",ContractNO='" + model.ContractNO + "'";
			text = text + ",Summary='" + model.Summary + "'";
			text = text + ",StartDate='" + model.StartDate + "'";
			text = text + ",EndDate='" + model.EndDate + "'";
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",Accessory='" + model.Accessory + "'";
			list.Add(new string[]
			{
				"MaintenanceContract",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array = strdellist[i];
				list2.Add(new string[]
				{
					array[0].ToString(),
					" ID in(" + array[1].ToString() + ")"
				});
			}
			if (model.ContractDetailInfos != null)
			{
				foreach (ContractDetailInfo current in model.ContractDetailInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "DeviceID";
						text += current.DeviceID.ToString();
						if (current.ServiceLevelID > 0)
						{
							text2 += ",ServiceLevelID";
							text = text + "," + current.ServiceLevelID.ToString();
						}
						if (current.bRepair)
						{
							text2 += ",bRepair";
							text += ",1";
						}
						if (current.bConsumables)
						{
							text2 += ",bConsumables";
							text += ",1";
						}
						if (current.bMaterial)
						{
							text2 += ",bMaterial";
							text += ",1";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current.ProductSN != string.Empty)
						{
							text2 += ",ProductSN";
							text = text + ",'" + current.ProductSN + "'";
						}
						if (current.DeviceNO != string.Empty)
						{
							text2 += ",DeviceNO";
							text = text + ",'" + current.DeviceNO + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "ks_wxht_kdmx";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "DeviceID=" + current.DeviceID.ToString();
						if (current.ServiceLevelID > 0)
						{
							text = text + ",ServiceLevelID=" + current.ServiceLevelID.ToString();
						}
						else
						{
							text += ",ServiceLevelID=null";
						}
						if (current.bRepair)
						{
							text += ",bRepair=1";
						}
						else
						{
							text += ",bRepair=0";
						}
						if (current.bConsumables)
						{
							text += ",bConsumables=1";
						}
						else
						{
							text += ",bConsumables=0";
						}
						if (current.bMaterial)
						{
							text += ",bMaterial=1";
						}
						else
						{
							text += ",bMaterial=0";
						}
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",ProductSN='" + current.ProductSN + "'";
						array2[0] = "ContractDetail";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "";
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public int Delete(int Dept, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Dept", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = Dept;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_wxht_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ContEnd(int Dept, int iTbid, int iOperator, string strReason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Dept", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.VarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = Dept;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Value = strReason;
			array[4].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_wxht_end", array);
			strMsg = Convert.ToString(array[4].Value);
			return result;
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
					" and (_Date like '%",
					strcon,
					"%' or ContractNO like '%",
					strcon,
					"%' or StartDate like '%",
					strcon,
					"%' or EndDate like '%",
					strcon,
					"%' or Summary like '%",
					strcon,
					"%' or CustomerName like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or Tel like '%",
					strcon,
					"%' or Adr like '%",
					strcon,
					"%' or dAmount like '%",
					strcon,
					"%' or dInCash like '%",
					strcon,
					"%' or Seller like '%",
					strcon,
					"%' or Operator like '%",
					strcon,
					"%' or Remark like '%",
					strcon,
					"%' or Area like '%",
					strcon,
					"%' or ID in(select BillID from ks_contractdetail where ProductSN1 like '%",
					strcon,
					"%') or ID in(select BillID from ks_contractdetail where ProductBrand like '%",
					strcon,
					"%') or ID in(select BillID from ks_contractdetail where ProductClass like '%",
					strcon,
					"%') or ID in(select BillID from ks_contractdetail where ProductModel like '%",
					strcon,
					"%') or ID in(select BillID from ks_contractdetail where DeviceNO like '%",
					strcon,
					"%'))"
				});
				break;
			}
			case 1:
				text = text + " and _Date like '%" + strcon + "%' ";
				break;
			case 2:
				text = text + " and ContractNO like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and StartDate like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and EndDate like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and Summary like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and CustomerName like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and LinkMan like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and Tel like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Adr like '%" + strcon + "%' ";
				break;
			case 10:
				text = text + " and dAmount like '%" + strcon + "%' ";
				break;
			case 11:
				text = text + " and Seller like '%" + strcon + "%' ";
				break;
			case 12:
				text = text + " and Operator like '%" + strcon + "%' ";
				break;
			case 13:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 14:
				text = text + " and Area like '%" + strcon + "%' ";
				break;
			}
			return text;
		}
	}
}
