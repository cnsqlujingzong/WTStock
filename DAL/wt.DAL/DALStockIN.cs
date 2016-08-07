using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALStockIN
	{
		public int Add(StockINInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "OperatorID";
			text2 += model.OperatorID.ToString();
			if (model._Date != string.Empty)
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.PersonID > 0)
			{
				text += ",PersonID";
				text2 = text2 + "," + model.PersonID.ToString();
			}
			if (model.ReasonID > 0)
			{
				text += ",ReasonID";
				text2 = text2 + "," + model.ReasonID.ToString();
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.Type != string.Empty)
			{
				text += ",Type";
				text2 = text2 + ",'" + model.Type + "'";
			}
			if (model.OperationID != string.Empty)
			{
				text += ",OperationID";
				text2 = text2 + ",'" + model.OperationID + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
            if (model.SendMoney != string.Empty)
            {
                text += ",SendMoney";
                text2 = text2 + ",'" + model.SendMoney + "'";
            }
            if (model.SendName != string.Empty)
            {
                text += ",SendName";
                text2 = text2 + ",'" + model.SendName + "'";
            }
            if (model.SendNum != string.Empty)
            {
                text += ",SendNum";
                text2 = text2 + ",'" + model.SendNum + "'";
            }
			list.Add(new string[]
			{
				text,
				text2,
				"ck_rk_kd"
			});
			if (model.StockINDetailInfos != null)
			{
				foreach (StockINDetailInfo current in model.StockINDetailInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "StockID";
					text2 += current.StockID.ToString();
					if (current.GoodsID > 0)
					{
						text += ",GoodsID";
						text2 = text2 + "," + current.GoodsID.ToString();
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
					if (current.Price > 0m)
					{
						text += ",Price";
						text2 = text2 + "," + current.Price.ToString();
					}
					if (current.SNID > 0)
					{
						text += ",SNID";
						text2 = text2 + "," + current.SNID.ToString();
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					if (current.SN != string.Empty && current.SN != "")
					{
						text += ",SN";
						text2 = text2 + ",'" + current.SN + "'";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "ck_rk_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(StockINInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "OperatorID=" + model.OperatorID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",ReasonID=" + model.ReasonID.ToString();
			text = text + ",Remark='" + model.Remark + "'";
            text = text + ",SendName='" + model.SendName + "'";
            text = text + ",SendNum='" + model.SendNum + "'";
            text = text + ",SendMoney='" + model.SendMoney + "'";
			list.Add(new string[]
			{
				"StockIN",
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
			if (model.StockINDetailInfos != null)
			{
				foreach (StockINDetailInfo current in model.StockINDetailInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "StockID";
						text += current.StockID.ToString();
						if (current.GoodsID > 0)
						{
							text2 += ",GoodsID";
							text = text + "," + current.GoodsID.ToString();
						}
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
						if (current.Price > 0m)
						{
							text2 += ",Price";
							text = text + "," + current.Price.ToString();
						}
						if (current.SNID > 0)
						{
							text2 += ",SNID";
							text = text + "," + current.SNID.ToString();
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current.SN != string.Empty && current.SN != "")
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "ck_rk_kdmx";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "StockID=" + current.StockID.ToString();
						text = text + ",GoodsID=" + current.GoodsID.ToString();
						text = text + ",UnitID=" + current.UnitID.ToString();
						text = text + ",Qty=" + current.Qty.ToString();
						text = text + ",Price=" + current.Price.ToString();
						if (current.SNID > 0)
						{
							text = text + ",SNID=" + current.SNID.ToString();
						}
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",SN='" + current.SN + "'";
						array2[0] = "StockINDetail";
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

		public StockINInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ID,isnull(DeptID,1) as DeptID,ChkDate,ChkOperatorID,Remark,BillID,_Date=convert(char(10), _Date,120),OperatorID,PersonID,ReasonID,Status,Type,OperationID,SendName,SendNum,SendMoney  from StockIN ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			StockINInfo stockINInfo = new StockINInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			StockINInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					stockINInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					stockINInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					stockINInfo.ChkDate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					stockINInfo.ChkOperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString()));
				}
				stockINInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				stockINInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
                stockINInfo.SendMoney = dataSet.Tables[0].Rows[0]["SendMoney"].ToString();
                stockINInfo.SendName = dataSet.Tables[0].Rows[0]["SendName"].ToString();
                stockINInfo.SendNum = dataSet.Tables[0].Rows[0]["SendNum"].ToString();
				if (dataSet.Tables[0].Rows[0]["_Date"].ToString() != "")
				{
					stockINInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					stockINInfo.OperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["PersonID"].ToString() != "")
				{
					stockINInfo.PersonID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["PersonID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ReasonID"].ToString() != "")
				{
					stockINInfo.ReasonID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ReasonID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					stockINInfo.Status = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString()));
				}
				stockINInfo.Type = dataSet.Tables[0].Rows[0]["Type"].ToString();
				stockINInfo.OperationID = dataSet.Tables[0].Rows[0]["OperationID"].ToString();
				result = stockINInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int GetID(string BillID)
		{
			int result = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [ID] from StockIN ");
			stringBuilder.Append(" where BillID=@BillID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.VarChar, 50)
			};
			array[0].Value = BillID;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					result = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
			}
			return result;
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
				text = text + " and _Date ='" + strcon + "' ";
				break;
			case 3:
				text = text + " and Person like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and Operator like '%" + strcon + "%' ";
				break;
			case 5:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Reason like '%",
					strcon,
					"%' or ReasonCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 6:
				text = text + " and OperationID like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and ChkDate like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and ChkOperator like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 10:
				text = text + " and [ID] in(select BillID from ck_stockindetail where StockName like '%" + strcon + "%') ";
				break;
			}
			return text;
		}

		public string GetBillDate()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select top 1 [_Date] from StockIN ");
			stringBuilder.Append(" order by ID Asc ");
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString());
			string result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = dataSet.Tables[0].Rows[0]["_Date"].ToString();
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public int ChkStockIn(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("ck_rk_chk", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkStockInU(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("ck_rk_chku", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
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
			int result = DbHelperSQL.RunProcedureTran("ck_rk_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public decimal GetStAmount(string strWhere)
		{
			decimal result = 0m;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select sum([Total]) as [Total] ");
			stringBuilder.Append(" FROM st_stockindetail ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append("where " + strWhere);
			}
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				decimal.TryParse(dataTable.Rows[0]["Total"].ToString(), out result);
			}
			return result;
		}
	}
}
