using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServicesItem
	{
		public void Update(ServicesItemInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ServicesItem set ");
			stringBuilder.Append("Price=@Price,");
			stringBuilder.Append("dPoint=@dPoint,");
			stringBuilder.Append("Tec=@Tec,");
			stringBuilder.Append("ChargeStyle=@ChargeStyle,");
			stringBuilder.Append("TecDeduct=@TecDeduct,");
			stringBuilder.Append("Remark=@Remark,");
			stringBuilder.Append("bComplete=@bComplete");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@Price", SqlDbType.Decimal, 9),
				new SqlParameter("@dPoint", SqlDbType.Decimal, 9),
				new SqlParameter("@Tec", SqlDbType.VarChar, 50),
				new SqlParameter("@ChargeStyle", SqlDbType.VarChar, 10),
				new SqlParameter("@TecDeduct", SqlDbType.Decimal, 9),
				new SqlParameter("@Remark", SqlDbType.VarChar, 100),
				new SqlParameter("@bComplete", SqlDbType.Bit, 1)
			};
			array[0].Value = model.ID;
			array[1].Value = model.Price;
			array[2].Value = model.dPoint;
			array[3].Value = model.Tec;
			array[4].Value = model.ChargeStyle;
			array[5].Value = model.TecDeduct;
			array[6].Value = model.Remark;
			array[7].Value = model.bComplete;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
