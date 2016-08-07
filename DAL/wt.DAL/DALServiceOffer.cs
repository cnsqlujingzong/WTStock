using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServiceOffer
	{
		public void Update(ServiceOfferInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ServiceOffer set ");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("SellerID=@SellerID,");
			stringBuilder.Append("dAmount=@dAmount,");
			stringBuilder.Append("bCusConf=@bCusConf,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@SellerID", SqlDbType.Int, 4),
				new SqlParameter("@dAmount", SqlDbType.Decimal, 9),
				new SqlParameter("@bCusConf", SqlDbType.Bit, 1),
				new SqlParameter("@Remark", SqlDbType.VarChar, 300)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Date;
			array[2].Value = model.SellerID;
			array[3].Value = model.dAmount;
			array[4].Value = model.bCusConf;
			array[5].Value = model.Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
