using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSmsTmp
	{
		public bool Exists(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from SmsTmp");
			stringBuilder.Append(" where RecID= @RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			return DbHelperSQL.Exists(stringBuilder.ToString(), array);
		}

		public int Add(SmsTmpInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into SmsTmp(");
			stringBuilder.Append("Title,Content)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@Title,@Content)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Title", SqlDbType.VarChar, 50),
				new SqlParameter("@Content", SqlDbType.VarChar, 5000)
			};
			array[0].Value = model.Title;
			array[1].Value = model.Content;
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

		public void Update(SmsTmpInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SmsTmp set ");
			stringBuilder.Append("Title=@Title,");
			stringBuilder.Append("Content=@Content");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4),
				new SqlParameter("@Title", SqlDbType.VarChar, 50),
				new SqlParameter("@Content", SqlDbType.VarChar, 5000)
			};
			array[0].Value = model.RecID;
			array[1].Value = model.Title;
			array[2].Value = model.Content;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Delete(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete SmsTmp ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public SmsTmpInfo GetModel(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from SmsTmp ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			SmsTmpInfo smsTmpInfo = new SmsTmpInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			smsTmpInfo.RecID = RecID;
			SmsTmpInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				smsTmpInfo.Title = dataSet.Tables[0].Rows[0]["Title"].ToString();
				smsTmpInfo.Content = dataSet.Tables[0].Rows[0]["Content"].ToString();
				result = smsTmpInfo;
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
			stringBuilder.Append("select [RecID],[Title],[Content] ");
			stringBuilder.Append(" FROM SmsTmp ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(stringBuilder.ToString());
		}
	}
}
