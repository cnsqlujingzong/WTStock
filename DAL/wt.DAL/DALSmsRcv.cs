using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSmsRcv
	{
		public bool Exists(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from SmsRcv");
			stringBuilder.Append(" where RecID= @RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			return DbHelperSQL.Exists(stringBuilder.ToString(), array);
		}

		public int Add(SmsRcvInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into SmsRcv(");
			stringBuilder.Append("SndFrom,Content,SDate)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@SndFrom,@Content,@SDate)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@SndFrom", SqlDbType.VarChar, 50),
				new SqlParameter("@Content", SqlDbType.VarChar, 5000),
				new SqlParameter("@SDate", SqlDbType.DateTime)
			};
			array[0].Value = model.SndFrom;
			array[1].Value = model.Content;
			array[2].Value = model.SDate;
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

		public void Update(SmsRcvInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SmsRcv set ");
			stringBuilder.Append("SndFrom=@SndFrom,");
			stringBuilder.Append("Content=@Content,");
			stringBuilder.Append("SDate=@SDate");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4),
				new SqlParameter("@SndFrom", SqlDbType.VarChar, 50),
				new SqlParameter("@Content", SqlDbType.VarChar, 5000),
				new SqlParameter("@SDate", SqlDbType.DateTime)
			};
			array[0].Value = model.RecID;
			array[1].Value = model.SndFrom;
			array[2].Value = model.Content;
			array[3].Value = model.SDate;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Delete(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete SmsRcv ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void DeleteALL()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from SmsRcv");
			DbHelperSQL.ExecuteSql(stringBuilder.ToString());
		}

		public SmsRcvInfo GetModel(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from SmsRcv ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			SmsRcvInfo smsRcvInfo = new SmsRcvInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			smsRcvInfo.RecID = RecID;
			SmsRcvInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				smsRcvInfo.SndFrom = dataSet.Tables[0].Rows[0]["SndFrom"].ToString();
				smsRcvInfo.Content = dataSet.Tables[0].Rows[0]["Content"].ToString();
				if (dataSet.Tables[0].Rows[0]["SDate"].ToString() != "")
				{
					smsRcvInfo.SDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["SDate"].ToString());
				}
				result = smsRcvInfo;
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
			stringBuilder.Append("select [RecID],[SndFrom],[Content],[SDate] ");
			stringBuilder.Append(" FROM SmsRcv ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(stringBuilder.ToString());
		}
	}
}
