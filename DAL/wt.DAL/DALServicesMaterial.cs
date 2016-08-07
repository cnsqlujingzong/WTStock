using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServicesMaterial
	{
		public void Update(ServicesMaterialInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ServicesMaterial set ");
			stringBuilder.Append("Qty=@Qty,");
			stringBuilder.Append("Price=@Price,");
			stringBuilder.Append("MaintenancePeriod=@MaintenancePeriod,");
			stringBuilder.Append("PeriodEndDate=@PeriodEndDate,");
			stringBuilder.Append("ChargeStyle=@ChargeStyle,");
			stringBuilder.Append("Remark=@Remark,");
			stringBuilder.Append("SN=@SN,");
			stringBuilder.Append("TaxRate=@TaxRate,");
			if (model.OutSourcing)
			{
				stringBuilder.Append("OutSourcing=@OutSourcing,");
				stringBuilder.Append("CostPrice=@CostPrice");
			}
			else
			{
				stringBuilder.Append("OutSourcing=@OutSourcing");
			}
			stringBuilder.Append(" where ID=@ID");
			if (model.OutSourcing)
			{
				SqlParameter[] array = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4),
					new SqlParameter("@Qty", SqlDbType.Decimal, 9),
					new SqlParameter("@Price", SqlDbType.Decimal, 9),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar, 50),
					new SqlParameter("@PeriodEndDate", SqlDbType.VarChar, 50),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar, 10),
					new SqlParameter("@Remark", SqlDbType.VarChar, 100),
					new SqlParameter("@SN", SqlDbType.VarChar, 5000),
					new SqlParameter("@OutSourcing", SqlDbType.Bit, 1),
					new SqlParameter("@CostPrice", SqlDbType.Decimal, 9),
					new SqlParameter("@TaxRate", SqlDbType.Decimal)
				};
				array[0].Value = model.ID;
				array[1].Value = model.Qty;
				array[2].Value = model.Price;
				array[3].Value = model.MaintenancePeriod;
				array[4].Value = model.PeriodEndDate;
				array[5].Value = model.ChargeStyle;
				array[6].Value = model.Remark;
				array[7].Value = model.SN;
				array[8].Value = model.OutSourcing;
				array[9].Value = model.CostPrice;
				array[10].Value = model.TaxRate;
				DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
			}
			else
			{
				SqlParameter[] array = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4),
					new SqlParameter("@Qty", SqlDbType.Decimal, 9),
					new SqlParameter("@Price", SqlDbType.Decimal, 9),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar, 50),
					new SqlParameter("@PeriodEndDate", SqlDbType.VarChar, 50),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar, 10),
					new SqlParameter("@Remark", SqlDbType.VarChar, 100),
					new SqlParameter("@SN", SqlDbType.VarChar, 5000),
					new SqlParameter("@OutSourcing", SqlDbType.Bit, 1),
					new SqlParameter("@TaxRate", SqlDbType.Decimal)
				};
				array[0].Value = model.ID;
				array[1].Value = model.Qty;
				array[2].Value = model.Price;
				array[3].Value = model.MaintenancePeriod;
				array[4].Value = model.PeriodEndDate;
				array[5].Value = model.ChargeStyle;
				array[6].Value = model.Remark;
				array[7].Value = model.SN;
				array[8].Value = model.OutSourcing;
				array[9].Value = model.TaxRate;
				DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
			}
		}
	}
}
