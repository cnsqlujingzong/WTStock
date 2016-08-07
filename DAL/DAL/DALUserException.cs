using System;
using System.Data;
using System.Data.SqlClient;
using wt.DB;

namespace DAL
{
	public class DALUserException
	{
		public int InsertData(int id, int staffid, string staffname, string remark)
		{
			string sQLString = " insert into UserException values(@ID,@StaffID,@StaffName,@Remark) ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StaffID", SqlDbType.Int),
				new SqlParameter("@StaffName", SqlDbType.VarChar, 50),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = staffid;
			array[1].Value = staffname;
			array[2].Value = remark;
			array[3].Value = id;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public int UpdateData(int id, int staffid, string staffname, string remark)
		{
			string sQLString = " update UserException set StaffID=@StaffID,StaffName=@StaffName,Remark=@Remark where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@StaffID", SqlDbType.Int),
				new SqlParameter("@StaffName", SqlDbType.VarChar, 50),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500)
			};
			array[0].Value = id;
			array[1].Value = staffid;
			array[2].Value = staffname;
			array[3].Value = remark;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public bool ExistsByStaffID(int staffid)
		{
			string sQLString = " select 1 from UserException where StaffID=@StaffID";
			DataSet dataSet = DbHelperSQL.Query(sQLString, new SqlParameter[]
			{
				new SqlParameter("@StaffID", SqlDbType.Int)
				{
					Value = staffid
				}
			});
			return dataSet.Tables[0].Rows.Count > 0;
		}

		public bool ExistsByID(int id)
		{
			string sQLString = " select 1 from UserException where ID=@ID";
			DataSet dataSet = DbHelperSQL.Query(sQLString, new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
				{
					Value = id
				}
			});
			return dataSet.Tables[0].Rows.Count > 0;
		}

		public DataSet GetList()
		{
			string sQLString = " select * from UserException where StaffID != 0";
			return DbHelperSQL.Query(sQLString);
		}
	}
}
