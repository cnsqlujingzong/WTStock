using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALDeviceAccessory
	{
		public int Add(DeviceAccessoryInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into DeviceAccessory(");
			stringBuilder.Append("DeviceID,_Name,_Date,OperatorID,Path,Remark)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@DeviceID,@_Name,@_Date,@OperatorID,@Path,@Remark)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeviceID", SqlDbType.Int, 4),
				new SqlParameter("@_Name", SqlDbType.VarChar, 100),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@Path", SqlDbType.VarChar, 100),
				new SqlParameter("@Remark", SqlDbType.VarChar, 200)
			};
			array[0].Value = model.DeviceID;
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

		public void Update(DeviceAccessoryInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update DeviceAccessory set ");
			stringBuilder.Append("_Name=@_Name,");
			stringBuilder.Append("Path=@Path,");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("OperatorID=@OperatorID,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Name", SqlDbType.VarChar, 100),
				new SqlParameter("@Path", SqlDbType.VarChar, 100),
				new SqlParameter("@Remark", SqlDbType.VarChar, 200),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Name;
			array[2].Value = model.Path;
			array[3].Value = model.Remark;
			array[4].Value = model._Date;
			array[5].Value = model.OperatorID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public DeviceAccessoryInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from DeviceAccessory ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DeviceAccessoryInfo deviceAccessoryInfo = new DeviceAccessoryInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			deviceAccessoryInfo.ID = ID;
			DeviceAccessoryInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["DeviceID"].ToString() != "")
				{
					deviceAccessoryInfo.DeviceID = int.Parse(dataSet.Tables[0].Rows[0]["DeviceID"].ToString());
				}
				deviceAccessoryInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["_Date"].ToString() != "")
				{
					deviceAccessoryInfo._Date = DateTime.Parse(dataSet.Tables[0].Rows[0]["_Date"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					deviceAccessoryInfo.OperatorID = int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString());
				}
				deviceAccessoryInfo.Path = dataSet.Tables[0].Rows[0]["Path"].ToString();
				deviceAccessoryInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = deviceAccessoryInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
