using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALComplaint
	{
		public int Add(ComplaintInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into Complaint(");
			stringBuilder.Append("_Date,OpetatorID,CustomerName,LinkMan,Tel,Content,OperationID,DoOperator,Status,Remark,CustomerID)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@_Date,@OpetatorID,@CustomerName,@LinkMan,@Tel,@Content,@OperationID,@DoOperator,@Status,@Remark,@CustomerID)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OpetatorID", SqlDbType.Int, 4),
				new SqlParameter("@CustomerName", SqlDbType.VarChar, 100),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@Content", SqlDbType.VarChar, 500),
				new SqlParameter("@OperationID", SqlDbType.VarChar, 50),
				new SqlParameter("@DoOperator", SqlDbType.VarChar, 50),
				new SqlParameter("@Status", SqlDbType.VarChar, 50),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@CustomerID", SqlDbType.Int)
			};
			array[0].Value = model._Date;
			array[1].Value = model.OpetatorID;
			array[2].Value = model.CustomerName;
			array[3].Value = model.LinkMan;
			array[4].Value = model.Tel;
			array[5].Value = model.Content;
			array[6].Value = model.OperationID;
			array[7].Value = model.DoOperator;
			array[8].Value = model.Status;
			array[9].Value = model.Remark;
			array[10].Value = model.CustomerID;
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

		public void Update(ComplaintInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Complaint set ");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("OpetatorID=@OpetatorID,");
			stringBuilder.Append("CustomerName=@CustomerName,");
			stringBuilder.Append("LinkMan=@LinkMan,");
			stringBuilder.Append("Tel=@Tel,");
			stringBuilder.Append("Content=@Content,");
			stringBuilder.Append("OperationID=@OperationID,");
			stringBuilder.Append("DoOperator=@DoOperator,");
			stringBuilder.Append("Remark=@Remark,");
			stringBuilder.Append("CustomerID=@CustomerID");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OpetatorID", SqlDbType.Int, 4),
				new SqlParameter("@CustomerName", SqlDbType.VarChar, 100),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@Content", SqlDbType.VarChar, 500),
				new SqlParameter("@OperationID", SqlDbType.VarChar, 50),
				new SqlParameter("@DoOperator", SqlDbType.VarChar, 50),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Date;
			array[2].Value = model.OpetatorID;
			array[3].Value = model.CustomerName;
			array[4].Value = model.LinkMan;
			array[5].Value = model.Tel;
			array[6].Value = model.Content;
			array[7].Value = model.OperationID;
			array[8].Value = model.DoOperator;
			array[9].Value = model.Remark;
			array[10].Value = model.CustomerID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateDo(ComplaintInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Complaint set ");
			stringBuilder.Append("DoDate=@DoDate,");
			stringBuilder.Append("Result=@Result,");
			stringBuilder.Append("Measures=@Measures,");
			stringBuilder.Append("Status=@Status,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@DoDate", SqlDbType.DateTime),
				new SqlParameter("@Result", SqlDbType.VarChar, 50),
				new SqlParameter("@Measures", SqlDbType.VarChar, 500),
				new SqlParameter("@Status", SqlDbType.VarChar, 50),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500)
			};
			array[0].Value = model.ID;
			array[1].Value = model.DoDate;
			array[2].Value = model.Result;
			array[3].Value = model.Measures;
			array[4].Value = model.Status;
			array[5].Value = model.Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateCancel(int id, string Status)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Complaint set ");
			stringBuilder.Append("Status=@Status");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@Status", SqlDbType.VarChar, 50)
			};
			array[0].Value = id;
			array[1].Value = Status;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
