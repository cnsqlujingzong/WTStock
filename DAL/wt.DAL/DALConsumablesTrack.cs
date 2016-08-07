using System;
using System.Data;
using System.Data.SqlClient;
using wt.DB;

namespace wt.DAL
{
	public class DALConsumablesTrack
	{
		public int ChkTrackAllot(int iTbid, int iOperator, string DisOperator, int PRI, string Remark, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@DisOperator", SqlDbType.VarChar, 50),
				new SqlParameter("@PRI", SqlDbType.Int),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = DisOperator;
			array[3].Value = PRI;
			array[4].Value = Remark;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_gz_pg", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}

		public int ChkDoTrack(int iTbid, int iOperator, string strDate, string strResult, bool bagain, string warringdate, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strDate", SqlDbType.VarChar, 50),
				new SqlParameter("@strResult", SqlDbType.VarChar, 2000),
				new SqlParameter("@bAgain", SqlDbType.Bit),
				new SqlParameter("@WarringDate", SqlDbType.VarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = strDate;
			array[3].Value = strResult;
			array[4].Value = bagain;
			array[5].Value = warringdate;
			array[6].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_gz_cl", array);
			strMsg = Convert.ToString(array[6].Value);
			return result;
		}

		public int ChkCancel(int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_gz_qx", array);
			strMsg = Convert.ToString(array[1].Value);
			return result;
		}
	}
}
