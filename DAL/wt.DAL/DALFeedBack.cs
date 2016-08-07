using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALFeedBack
	{
		public int InsertData(FeedBackInfo fb)
		{
			string sQLString = " insert into FeedBack(DeptID,DeptName,CreateDate,CreateOperator,CheckDate,CheckOperator,Context,Remark,curStatus) values(@DeptID,@DeptName,@CreateDate,@CreateOperator,@CheckDate,@CheckOperator,@Context,@Remark,0) ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@DeptName", SqlDbType.VarChar, 50),
				new SqlParameter("@CreateDate", SqlDbType.DateTime),
				new SqlParameter("@CreateOperator", SqlDbType.VarChar, 50),
				new SqlParameter("@CheckDate", SqlDbType.DateTime),
				new SqlParameter("@CheckOperator", SqlDbType.VarChar, 50),
				new SqlParameter("@Context", SqlDbType.VarChar, 4000),
				new SqlParameter("@Remark", SqlDbType.VarChar, 100)
			};
			array[0].Value = fb.DeptID;
			array[1].Value = fb.DeptName;
			array[2].Value = fb.CreateDate;
			array[3].Value = fb.CreateOperator;
			array[4].Value = fb.CheckDate;
			array[5].Value = fb.CheckOperator;
			array[6].Value = fb.Context;
			array[7].Value = fb.Remark;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public FeedBackInfo GetList(int id)
		{
			string sQLString = "select * from FeedBack where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			FeedBackInfo feedBackInfo = new FeedBackInfo();
			FeedBackInfo result;
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["DeptID"].ToString() != "")
				{
					feedBackInfo.DeptID = int.Parse(dataTable.Rows[0]["DeptID"].ToString());
				}
				feedBackInfo.DeptName = dataTable.Rows[0]["DeptName"].ToString();
				feedBackInfo.CreateDate = dataTable.Rows[0]["CreateDate"].ToString();
				feedBackInfo.CreateOperator = dataTable.Rows[0]["CreateOperator"].ToString();
				feedBackInfo.CheckDate = dataTable.Rows[0]["CheckDate"].ToString();
				feedBackInfo.CheckOperator = dataTable.Rows[0]["CheckOperator"].ToString();
				feedBackInfo.Context = dataTable.Rows[0]["Context"].ToString();
				if (dataTable.Rows[0]["Context"].ToString() != "")
				{
					feedBackInfo.curStatus = int.Parse(dataTable.Rows[0]["curStatus"].ToString());
				}
				feedBackInfo.Remark = dataTable.Rows[0]["Remark"].ToString();
				result = feedBackInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int Update(FeedBackInfo fb)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update FeedBack set  ");
			if (fb.CheckDate != "" && fb.CheckDate != null)
			{
				stringBuilder.Append("CheckDate='" + fb.CheckDate + "',");
			}
			if (fb.CheckOperator != "" && fb.CheckOperator != null)
			{
				stringBuilder.Append("CheckOperator='" + fb.CheckOperator + "',");
			}
			if (fb.CreateDate != "" && fb.CreateDate != null)
			{
				stringBuilder.Append("CreateDate='" + fb.CreateDate + "',");
			}
			if (fb.CreateOperator != "" && fb.CreateOperator != null)
			{
				stringBuilder.Append("CreateOperator='" + fb.CreateOperator + "',");
			}
			if (fb.curStatus.ToString() != "")
			{
				stringBuilder.Append("curStatus=" + fb.curStatus + ",");
			}
			if (fb.Context != "" && fb.Context != null)
			{
				stringBuilder.Append("Context='" + fb.Context + "',");
			}
			if (fb.Remark != "" && fb.Remark != null)
			{
				stringBuilder.Append("Remark='" + fb.Remark + "'");
			}
			string text = stringBuilder.ToString().Trim(new char[]
			{
				','
			});
			text = text + " where ID=" + fb.ID;
			return DbHelperSQL.ExecuteSql(text);
		}
	}
}
