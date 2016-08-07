using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALStockCheck
	{
		public int Add(StockCheckInfo model, out int iTbid)
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
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.StockID > 0)
			{
				text += ",StockID";
				text2 = text2 + "," + model.StockID.ToString();
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"ck_pd_kd"
			});
			if (model.StockCheckDetailInfos != null)
			{
				foreach (StockCheckDetailInfo current in model.StockCheckDetailInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "GoodsID";
					text2 += current.GoodsID.ToString();
					if (current.StockLocID > 0)
					{
						text += ",StockLocID";
						text2 = text2 + "," + current.StockLocID.ToString();
					}
					text += ",Stock";
					text2 = text2 + "," + current.Stock.ToString();
					if (current.Qty != 0m)
					{
						text += ",Qty";
						text2 = text2 + "," + current.Qty.ToString();
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "ck_pd_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(StockCheckInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "OperatorID=" + model.OperatorID.ToString();
			text = text + ",StockID=" + model.StockID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",Remark='" + model.Remark + "'";
			list.Add(new string[]
			{
				"StockCheck",
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
			if (model.StockCheckDetailInfos != null)
			{
				foreach (StockCheckDetailInfo current in model.StockCheckDetailInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "GoodsID";
						text += current.GoodsID.ToString();
						if (current.StockLocID > 0)
						{
							text2 += ",StockLocID";
							text = text + "," + current.StockLocID.ToString();
						}
						text2 += ",Stock";
						text = text + "," + current.Stock.ToString();
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
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "ck_pd_kdmx";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "GoodsID=" + current.GoodsID.ToString();
						if (current.StockLocID > 0)
						{
							text = text + ",StockLocID=" + current.StockLocID.ToString();
						}
						else
						{
							text += ",StockLocID=null";
						}
						text = text + ",Stock=" + current.Stock.ToString();
						text = text + ",Qty=" + current.Qty.ToString();
						text = text + ",Remark='" + current.Remark + "'";
						array2[0] = "StockCheckDetail";
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

		public StockCheckInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Remark,BillID,DeptID,_Date=convert(char(10), _Date,120),OperatorID,StockID,ChkDate,ChkOperatorID,Status from StockCheck ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			StockCheckInfo stockCheckInfo = new StockCheckInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			StockCheckInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					stockCheckInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				stockCheckInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				stockCheckInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					stockCheckInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				stockCheckInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					stockCheckInfo.OperatorID = int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StockID"].ToString() != "")
				{
					stockCheckInfo.StockID = int.Parse(dataSet.Tables[0].Rows[0]["StockID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					stockCheckInfo.ChkDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					stockCheckInfo.ChkOperatorID = int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					stockCheckInfo.Status = int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString());
				}
				result = stockCheckInfo;
			}
			else
			{
				result = null;
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
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Operator like '%",
					strcon,
					"%' or OperatorNO like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 4:
				text = text + " and StockName like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and ChkDate like '%" + strcon + "%' ";
				break;
			case 6:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ChkOperator like '%",
					strcon,
					"%' or ChkOperatorNO like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 7:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public int ChkStockCheck(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("ck_pd_ad", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkStockCheckU(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("ck_pd_fad", array);
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
			int result = DbHelperSQL.RunProcedureTran("ck_pd_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}
	}
}
