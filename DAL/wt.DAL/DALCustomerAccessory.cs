using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALCustomerAccessory
	{
		public int Add(CustomerAccessoryInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into CustomerAccessory(");
			stringBuilder.Append("CustomerID,_Name,_Date,OperatorID,Path,Remark)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@CustomerID,@_Name,@_Date,@OperatorID,@Path,@Remark)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4),
				new SqlParameter("@_Name", SqlDbType.VarChar, 100),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@Path", SqlDbType.VarChar, 100),
				new SqlParameter("@Remark", SqlDbType.VarChar, 200)
			};
			array[0].Value = model.CustomerID;
			array[1].Value = model._Name;
			array[2].Value = model._Date;
			array[3].Value = model.OperatorID;
			array[4].Value = model.Path;
			array[5].Value = model.Remark;
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

		public void Update(CustomerAccessoryInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update CustomerAccessory set ");
			stringBuilder.Append("_Name=@_Name,");
			stringBuilder.Append("Path=@Path,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Name", SqlDbType.VarChar, 100),
				new SqlParameter("@Path", SqlDbType.VarChar, 100),
				new SqlParameter("@Remark", SqlDbType.VarChar, 200)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Name;
			array[2].Value = model.Path;
			array[3].Value = model.Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public CustomerAccessoryInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from CustomerAccessory ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			CustomerAccessoryInfo customerAccessoryInfo = new CustomerAccessoryInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			customerAccessoryInfo.ID = ID;
			CustomerAccessoryInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["CustomerID"].ToString() != "")
				{
					customerAccessoryInfo.CustomerID = int.Parse(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
				}
				customerAccessoryInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["_Date"].ToString() != "")
				{
					customerAccessoryInfo._Date = DateTime.Parse(dataSet.Tables[0].Rows[0]["_Date"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					customerAccessoryInfo.OperatorID = int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString());
				}
				customerAccessoryInfo.Path = dataSet.Tables[0].Rows[0]["Path"].ToString();
				customerAccessoryInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = customerAccessoryInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
