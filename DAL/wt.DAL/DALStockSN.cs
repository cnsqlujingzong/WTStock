using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using wt.DB;

namespace wt.DAL
{
	public class DALStockSN
	{
		public int Add(List<string[]> strarr)
		{
			List<string[]> list = new List<string[]>();
			for (int i = 0; i < strarr.Count; i++)
			{
				string[] array = strarr[i];
				list.Add(new string[]
				{
					array[0].ToString(),
					array[1].ToString(),
					array[2].ToString(),
					array[3].ToString()
				});
			}
			return DbHelperSQL.SN_StockIN(list);
		}

		public int SN_StockOUT(List<string[]> strarr, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			for (int i = 0; i < strarr.Count; i++)
			{
				string[] array = strarr[i];
				list.Add(new string[]
				{
					array[0].ToString(),
					array[1].ToString(),
					array[2].ToString()
				});
			}
			return DbHelperSQL.SN_StockOUT(list, out strMsg);
		}

		public int Delete(int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_sn_del", array);
			strMsg = Convert.ToString(array[1].Value);
			return result;
		}

		public int InputSN(int iOperator, string SN, int Status, string GoodsNO, string Dept, string Stock, decimal dPrice, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@SN", SqlDbType.VarChar, 4000),
				new SqlParameter("@iStatus", SqlDbType.Int),
				new SqlParameter("@GoodsNO", SqlDbType.VarChar),
				new SqlParameter("@Dept", SqlDbType.VarChar, 50),
				new SqlParameter("@Stock", SqlDbType.VarChar, 50),
				new SqlParameter("@dPrice", SqlDbType.Decimal),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iOperator;
			array[1].Value = SN;
			array[2].Value = Status;
			array[3].Value = GoodsNO;
			array[4].Value = Dept;
			array[5].Value = Stock;
			array[6].Value = dPrice;
			array[7].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_inputsn", array);
			strMsg = Convert.ToString(array[7].Value);
			return result;
		}
	}
}
