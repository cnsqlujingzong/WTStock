using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSmsSnd
	{
		public bool Exists(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from SmsSnd");
			stringBuilder.Append(" where RecID= @RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			return DbHelperSQL.Exists(stringBuilder.ToString(), array);
		}

		public int Add(SmsSndInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into SmsSnd(");
			stringBuilder.Append("SndTo,Content,SDate,SFlag,SenderID)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@SndTo,@Content,@SDate,@SFlag,@SenderID)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@SndTo", SqlDbType.VarChar, 50),
				new SqlParameter("@Content", SqlDbType.VarChar, 5000),
				new SqlParameter("@SDate", SqlDbType.DateTime),
				new SqlParameter("@SFlag", SqlDbType.Bit, 1),
				new SqlParameter("@SenderID", SqlDbType.Int)
			};
			array[0].Value = model.SndTo;
			array[1].Value = model.Content;
			array[2].Value = model.SDate;
			array[3].Value = model.SFlag;
			array[4].Value = model.SenderID;
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

		public void Update(int RecID, DateTime SDate)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SmsSnd set ");
			stringBuilder.Append("SDate=@SDate,");
			stringBuilder.Append("SFlag=1");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4),
				new SqlParameter("@SDate", SqlDbType.DateTime)
			};
			array[0].Value = RecID;
			array[1].Value = SDate;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Update(SmsSndInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SmsSnd set ");
			stringBuilder.Append("SndTo=@SndTo,");
			stringBuilder.Append("Content=@Content,");
			stringBuilder.Append("SDate=@SDate,");
			stringBuilder.Append("SFlag=@SFlag");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4),
				new SqlParameter("@SndTo", SqlDbType.VarChar, 50),
				new SqlParameter("@Content", SqlDbType.VarChar, 5000),
				new SqlParameter("@SDate", SqlDbType.DateTime),
				new SqlParameter("@SFlag", SqlDbType.Bit, 1)
			};
			array[0].Value = model.RecID;
			array[1].Value = model.SndTo;
			array[2].Value = model.Content;
			array[3].Value = model.SDate;
			array[4].Value = model.SFlag;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Delete(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete SmsSnd ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void DeleteALL(string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from SmsSnd ");
			stringBuilder.Append(strWhere);
			DbHelperSQL.ExecuteSql(stringBuilder.ToString());
		}

		public SmsSndInfo GetModel(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from SmsSnd ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			SmsSndInfo smsSndInfo = new SmsSndInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			smsSndInfo.RecID = RecID;
			SmsSndInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				smsSndInfo.SndTo = dataSet.Tables[0].Rows[0]["SndTo"].ToString();
				smsSndInfo.Content = dataSet.Tables[0].Rows[0]["Content"].ToString();
				if (dataSet.Tables[0].Rows[0]["SDate"].ToString() != "")
				{
					smsSndInfo.SDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["SDate"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["SFlag"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["SFlag"].ToString() == "1" || dataSet.Tables[0].Rows[0]["SFlag"].ToString().ToLower() == "true")
					{
						smsSndInfo.SFlag = true;
					}
					else
					{
						smsSndInfo.SFlag = false;
					}
				}
				result = smsSndInfo;
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
			stringBuilder.Append("select [RecID],[SndTo],[Content],[SDate],[SFlag] ");
			stringBuilder.Append(" FROM SmsSnd ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(stringBuilder.ToString());
		}
	}
}
