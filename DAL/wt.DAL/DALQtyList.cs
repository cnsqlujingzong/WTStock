using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALQtyList
	{
		public int Add(QtyListInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into QtyList(");
			stringBuilder.Append("BillID,DeviceID,SN,_Date,OperatorID,QtyType,Qty,Remark,Allowance)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@BillID,@DeviceID,@SN,@_Date,@OperatorID,@QtyType,@Qty,@Remark,@Allowance)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.Int, 4),
				new SqlParameter("@DeviceID", SqlDbType.Int, 4),
				new SqlParameter("@SN", SqlDbType.VarChar, 50),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@QtyType", SqlDbType.VarChar, 50),
				new SqlParameter("@Qty", SqlDbType.Int, 4),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@Allowance", SqlDbType.VarChar, 50)
			};
			array[0].Value = model.BillID;
			array[1].Value = model.DeviceID;
			array[2].Value = model.SN;
			array[3].Value = model._Date;
			array[4].Value = model.OperatorID;
			array[5].Value = model.QtyType;
			array[6].Value = model.Qty;
			array[7].Value = model.Remark;
			array[8].Value = model.Allowance;
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

		public void Update(QtyListInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update QtyList set ");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("OperatorID=@OperatorID,");
			stringBuilder.Append("QtyType=@QtyType,");
			stringBuilder.Append("Qty=@Qty,");
			stringBuilder.Append("Remark=@Remark,");
			stringBuilder.Append("Allowance=@Allowance");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@QtyType", SqlDbType.VarChar, 50),
				new SqlParameter("@Qty", SqlDbType.Int, 4),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@Allowance", SqlDbType.VarChar, 50)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Date;
			array[2].Value = model.OperatorID;
			array[3].Value = model.QtyType;
			array[4].Value = model.Qty;
			array[5].Value = model.Remark;
			array[6].Value = model.Allowance;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
