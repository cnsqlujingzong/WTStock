using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALLendingReturn
	{
		public int Add(LendingReturnInfo model, out int iTbid, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "iOperator";
			text2 += model.iOperator.ToString();
			if (model._Date != "")
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.iPerson > 0)
			{
				text += ",iPerson";
				text2 = text2 + "," + model.iPerson.ToString();
			}
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID.ToString();
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.Deposit > 0m)
			{
				text += ",Deposit";
				text2 = text2 + "," + model.Deposit.ToString();
			}
			if (model.OperationID != "")
			{
				text += ",OperationID";
				text2 = text2 + ",'" + model.OperationID + "'";
			}
			if (model.Remark != "")
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
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
			if (model.iStock > 0)
			{
				text += ",iStock";
				text2 = text2 + "," + model.iStock.ToString();
			}
			if (model.WDate != "")
			{
				text += ",WDate";
				text2 = text2 + ",'" + model.WDate + "'";
			}
			if (model.curStatus != "")
			{
				text += ",curStatus";
				text2 = text2 + ",'" + model.curStatus + "'";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"ck_jc_kd"
			});
			if (model.LendingReturnDetailInfos != null)
			{
				foreach (LendingReturnDetailInfo current in model.LendingReturnDetailInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					if (current.GoodsID > 0)
					{
						text += "GoodsID";
						text2 += current.GoodsID.ToString();
					}
					if (current.UnitID > 0)
					{
						text += ",UnitID";
						text2 = text2 + "," + current.UnitID.ToString();
					}
					if (current.Qty > 0m)
					{
						text += ",Qty";
						text2 = text2 + "," + current.Qty.ToString();
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					if (current.SN != string.Empty)
					{
						text += ",SN";
						text2 = text2 + ",'" + current.SN + "'";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "ck_jg_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.TY_RunProcedureTran(list, "ck_jg_ad", out iTbid, out strMsg);
		}

		public int Update(LendingReturnInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "iOperator=" + model.iOperator.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",CustomerID=" + model.CustomerID.ToString();
			text = text + ",Deposit=" + model.Deposit.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",OperationID='" + model.OperationID + "'";
			text = text + ",WDate='" + model.WDate + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",iStock=" + model.iStock.ToString();
			list.Add(new string[]
			{
				"LendingReturn",
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
			if (model.LendingReturnDetailInfos != null)
			{
				foreach (LendingReturnDetailInfo current in model.LendingReturnDetailInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "GoodsID";
						text += current.GoodsID.ToString();
						if (current.UnitID > 0)
						{
							text2 += ",UnitID";
							text = text + "," + current.UnitID.ToString();
						}
						if (current.Qty > 0m)
						{
							text2 += ",Qty";
							text = text + "," + current.Qty.ToString();
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "ck_jg_kdmx";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "GoodsID=" + current.GoodsID.ToString();
						text = text + ",UnitID=" + current.UnitID.ToString();
						text = text + ",Qty=" + current.Qty.ToString();
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",SN='" + current.SN + "'";
						array2[0] = "LendingReturnDetail";
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

		public string GetSchWhere(int schid, string strcon)
		{
			string text = string.Empty;
			switch (schid)
			{
			case 1:
				text = text + " and BillID like '%" + strcon + "%' ";
				break;
			case 2:
				text = text + " and _Date like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and Person ='" + strcon + "' ";
				break;
			case 4:
				text = text + " and Operator like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and StockName like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and CustomerName like '%" + strcon + "%'  ";
				break;
			case 7:
				text = text + " and LinkMan like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and Tel like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Deposit like '%" + strcon + "%' ";
				break;
			case 10:
				text = text + " and WDate like '%" + strcon + "%' ";
				break;
			case 11:
				text = text + " and OperationID like '%" + strcon + "%' ";
				break;
			case 12:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public int ChkLending(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("ck_jc_gh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}
	}
}
