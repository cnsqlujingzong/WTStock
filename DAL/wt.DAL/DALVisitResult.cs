using System;
using System.Data;
using System.Data.SqlClient;
using wt.DB;

namespace wt.DAL
{
	public class DALVisitResult
	{
		public decimal getScore(int contentid, int id)
		{
			string sQLString = " select Rewards from VisitResult where [ID]=@ID and ContentID=@ContentID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@ContentID", SqlDbType.Int, 4)
			};
			array[0].Value = id;
			array[1].Value = contentid;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			decimal result;
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0][0].ToString() != "")
				{
					result = decimal.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0m;
			return result;
		}
	}
}
