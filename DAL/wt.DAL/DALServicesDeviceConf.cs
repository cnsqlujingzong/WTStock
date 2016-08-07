using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServicesDeviceConf
	{
		public void Update(ServicesDeviceConfInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ServicesDeviceConf set ");
			stringBuilder.Append("_Name=@_Name,");
			stringBuilder.Append("Parameter=@Parameter,");
			stringBuilder.Append("SN=@SN,");
			stringBuilder.Append("MaintenancePeriod=@MaintenancePeriod,");
			stringBuilder.Append("BuyDate=@BuyDate,");
			stringBuilder.Append("MaintenanceEnd=@MaintenanceEnd,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Name", SqlDbType.VarChar, 50),
				new SqlParameter("@Parameter", SqlDbType.VarChar, 50),
				new SqlParameter("@SN", SqlDbType.VarChar, 50),
				new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar, 50),
				new SqlParameter("@BuyDate", SqlDbType.VarChar, 50),
				new SqlParameter("@MaintenanceEnd", SqlDbType.VarChar, 50),
				new SqlParameter("@Remark", SqlDbType.VarChar, 200)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Name;
			array[2].Value = model.Parameter;
			array[3].Value = model.SN;
			array[4].Value = model.MaintenancePeriod;
			array[5].Value = model.BuyDate;
			array[6].Value = model.MaintenanceEnd;
			array[7].Value = model.Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
