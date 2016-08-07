using System;
using System.Data;
using System.Data.SqlClient;
using wt.DB;

namespace DAL
{
	public class DALIPControl
	{
		public int InsertData(int id, string startIP, string endIP, bool bEnable)
		{
			string sQLString = " insert into IPControl values(@ID,@StartIP,@EndIP,@bEnable) ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StartIP", SqlDbType.VarChar, 50),
				new SqlParameter("@EndIP", SqlDbType.VarChar, 50),
				new SqlParameter("@bEnable", SqlDbType.Bit),
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = startIP;
			array[1].Value = endIP;
			array[2].Value = bEnable;
			array[3].Value = id;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public int UpdateData(string startIP, string endIP, int id, bool enable)
		{
			string sQLString = " update IPControl set StartIP=@StartIP,EndIP=@EndIP,bEnable=@bEnable where ID=@ID ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StartIP", SqlDbType.VarChar, 50),
				new SqlParameter("@EndIP", SqlDbType.VarChar, 50),
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@bEnable", SqlDbType.Bit)
			};
			array[0].Value = startIP;
			array[1].Value = endIP;
			array[2].Value = id;
			array[3].Value = enable;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public int UpdateData(int id, bool enable)
		{
			string sQLString = " update IPControl set bEnable=@bEnable where ID=@ID ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@bEnable", SqlDbType.Bit)
			};
			array[0].Value = id;
			array[1].Value = enable;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public DataSet GetList(int id)
		{
			string sQLString = " select * from IPControl where ID=@ID ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = id;
			return DbHelperSQL.Query(sQLString, array);
		}

		public bool ExitsID(int id)
		{
			string sQLString = " select 1 from IPControl where ID=@ID ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = id;
			DataSet dataSet = DbHelperSQL.Query(sQLString, array);
			return dataSet.Tables[0].Rows.Count > 0;
		}
	}
}
