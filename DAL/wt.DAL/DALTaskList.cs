using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALTaskList
	{
		public int Add(TaskListInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into TaskList(");
			stringBuilder.Append("DeptID,_Date,OperatorID,ExeDate,ExerID,Status,Summary,TaskRemark,Remark)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@DeptID,@_Date,@OperatorID,@ExeDate,@ExerID,@Status,@Summary,@TaskRemark,@Remark)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@ExeDate", SqlDbType.DateTime),
				new SqlParameter("@ExerID", SqlDbType.Int, 4),
				new SqlParameter("@Status", SqlDbType.VarChar, 50),
				new SqlParameter("@Summary", SqlDbType.VarChar, 500),
				new SqlParameter("@TaskRemark", SqlDbType.VarChar, 3000),
				new SqlParameter("@Remark", SqlDbType.VarChar, 3000)
			};
			array[0].Value = model.DeptID;
			array[1].Value = model._Date;
			array[2].Value = model.OperatorID;
			array[3].Value = model.ExeDate;
			array[4].Value = model.ExerID;
			array[5].Value = model.Status;
			array[6].Value = model.Summary;
			array[7].Value = model.TaskRemark;
			array[8].Value = model.Remark;
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

		public void Update(TaskListInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update TaskList set ");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("OperatorID=@OperatorID,");
			stringBuilder.Append("ExeDate=@ExeDate,");
			stringBuilder.Append("ExerID=@ExerID,");
			stringBuilder.Append("Summary=@Summary,");
			stringBuilder.Append("TaskRemark=@TaskRemark,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@ExeDate", SqlDbType.DateTime),
				new SqlParameter("@ExerID", SqlDbType.Int, 4),
				new SqlParameter("@Summary", SqlDbType.VarChar, 500),
				new SqlParameter("@TaskRemark", SqlDbType.VarChar, 3000),
				new SqlParameter("@Remark", SqlDbType.VarChar, 3000)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Date;
			array[2].Value = model.OperatorID;
			array[3].Value = model.ExeDate;
			array[4].Value = model.ExerID;
			array[5].Value = model.Summary;
			array[6].Value = model.TaskRemark;
			array[7].Value = model.Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateExe(TaskListInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update TaskList set ");
			stringBuilder.Append("Status=@Status,");
			stringBuilder.Append("CompleteRate=@CompleteRate,");
			stringBuilder.Append("executeRemark=@executeRemark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@Status", SqlDbType.VarChar, 50),
				new SqlParameter("@CompleteRate", SqlDbType.VarChar, 50),
				new SqlParameter("@executeRemark", SqlDbType.VarChar, 3000)
			};
			array[0].Value = model.ID;
			array[1].Value = model.Status;
			array[2].Value = model.CompleteRate;
			array[3].Value = model.executeRemark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateScore(TaskListInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update TaskList set ");
			stringBuilder.Append("Status=@Status,");
			stringBuilder.Append("CompleteRate=@CompleteRate,");
			stringBuilder.Append("executeRemark=@executeRemark,");
			stringBuilder.Append("Score=@Score");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@Status", SqlDbType.VarChar, 50),
				new SqlParameter("@CompleteRate", SqlDbType.VarChar, 50),
				new SqlParameter("@executeRemark", SqlDbType.VarChar, 3000),
				new SqlParameter("@Score", SqlDbType.VarChar, 3000)
			};
			array[0].Value = model.ID;
			array[1].Value = model.Status;
			array[2].Value = model.CompleteRate;
			array[3].Value = model.executeRemark;
			array[4].Value = model.Score;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
