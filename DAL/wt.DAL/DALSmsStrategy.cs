using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSmsStrategy
	{
		public bool Exists(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from SmsStrategy");
			stringBuilder.Append(" where RecID= @RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			return DbHelperSQL.Exists(stringBuilder.ToString(), array);
		}

		public int Add(SmsStrategyInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into SmsStrategy(");
			stringBuilder.Append("SndTiming,SmsTmp)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@SndTiming,@SmsTmp)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@SndTiming", SqlDbType.VarChar, 50),
				new SqlParameter("@SmsTmp", SqlDbType.VarChar, 50)
			};
			array[0].Value = model.SndTiming;
			array[1].Value = model.SmsTmp;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			int result;
			if (single == null)
			{
				result = 1;
			}
			else
			{
				result = Convert.ToInt32(single);
			}
			return result;
		}

		public void Update(SmsStrategyInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SmsStrategy set ");
			stringBuilder.Append("SndTiming=@SndTiming,");
			stringBuilder.Append("SmsTmp=@SmsTmp");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4),
				new SqlParameter("@SndTiming", SqlDbType.VarChar, 50),
				new SqlParameter("@SmsTmp", SqlDbType.VarChar, 50)
			};
			array[0].Value = model.RecID;
			array[1].Value = model.SndTiming;
			array[2].Value = model.SmsTmp;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Delete(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete SmsStrategy ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public SmsStrategyInfo GetModel(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from SmsStrategy ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			SmsStrategyInfo smsStrategyInfo = new SmsStrategyInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			smsStrategyInfo.RecID = RecID;
			SmsStrategyInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				smsStrategyInfo.SndTiming = dataSet.Tables[0].Rows[0]["SndTiming"].ToString();
				smsStrategyInfo.SmsTmp = dataSet.Tables[0].Rows[0]["SmsTmp"].ToString();
				result = smsStrategyInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public DataSet GetList(string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [RecID],[SndTiming],[SmsTmp] ");
			stringBuilder.Append(" FROM SmsStrategy ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(stringBuilder.ToString());
		}
	}
}
