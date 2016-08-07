using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALCoordinates
	{
		public CoordinatesInfo GetModel(int RecID)
		{
			CoordinatesInfo coordinatesInfo = new CoordinatesInfo();
			string sQLString = "select * from Coordinates where RecID=@RecID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int)
			};
			array[0].Value = RecID;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			CoordinatesInfo result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0]["StaffID"].ToString()))
				{
					coordinatesInfo.StaffID = int.Parse(dataTable.Rows[0]["StaffID"].ToString());
				}
				coordinatesInfo.StaffName = dataTable.Rows[0]["StaffName"].ToString();
				if (!string.IsNullOrEmpty(dataTable.Rows[0]["DeptID"].ToString()))
				{
					coordinatesInfo.DeptID = int.Parse(dataTable.Rows[0]["DeptID"].ToString());
				}
				if (!string.IsNullOrEmpty(dataTable.Rows[0]["CreateTime"].ToString()))
				{
					coordinatesInfo.CreateTime = DateTime.Parse(dataTable.Rows[0]["CreateTime"].ToString());
				}
				coordinatesInfo.Coordinate = dataTable.Rows[0]["Coordinate"].ToString();
				result = coordinatesInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int InsertData(CoordinatesInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into Coordinates (StaffID,StaffName,DeptID,CreateTime,Coordinate) ");
			stringBuilder.Append(" values(@StaffID,@StaffName,@DeptID,@CreateTime,@Coordinate)");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StaffID", SqlDbType.Int, 4),
				new SqlParameter("@StaffName", SqlDbType.VarChar, 50),
				new SqlParameter("@DeptID", SqlDbType.Int, 4),
				new SqlParameter("@CreateTime", SqlDbType.DateTime),
				new SqlParameter("@Coordinate", SqlDbType.VarChar, 50)
			};
			array[0].Value = model.StaffID;
			array[1].Value = model.StaffName;
			array[2].Value = model.DeptID;
			array[3].Value = model.CreateTime;
			array[4].Value = model.Coordinate;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
