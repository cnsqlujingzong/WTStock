using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSaleContractDetail
	{
		public int Add(SaleContractDetailInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" insert into SaleContractDetail(StockID,GoodsID,UnitID,Qty,Price,Dis,Remark,TaxRate,TaxAmount,GoodsAmount,ContractID,MainTenancePeriod,Spec,ProductBrand,Total)");
			stringBuilder.Append("values(@StockID,@GoodsID,@UnitID,@Qty,@Price,@Dis,@Remark,@TaxRate,@TaxAmount,@GoodsAmount,@ContractID,@MainTenancePeriod,@Spec,@ProductBrand,@Total)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StockID", SqlDbType.Int),
				new SqlParameter("@GoodsID", SqlDbType.Int),
				new SqlParameter("@UnitID", SqlDbType.Int),
				new SqlParameter("@Qty", SqlDbType.Decimal),
				new SqlParameter("@Price", SqlDbType.Money),
				new SqlParameter("@Dis", SqlDbType.Decimal),
				new SqlParameter("@Remark", SqlDbType.VarChar, 100),
				new SqlParameter("@TaxRate", SqlDbType.Money),
				new SqlParameter("@TaxAmount", SqlDbType.Money),
				new SqlParameter("@GoodsAmount", SqlDbType.Money),
				new SqlParameter("@ContractID", SqlDbType.Int),
				new SqlParameter("@MainTenancePeriod", SqlDbType.VarChar, 50),
				new SqlParameter("@Spec", SqlDbType.VarChar, 50),
				new SqlParameter("@ProductBrand", SqlDbType.VarChar, 50),
				new SqlParameter("@Total", SqlDbType.Money)
			};
			array[0].Value = model.StockID;
			array[1].Value = model.GoodsID;
			array[2].Value = model.UnitID;
			array[3].Value = model.Qty;
			array[4].Value = model.Price;
			array[5].Value = model.Dis;
			array[6].Value = model.Remark;
			array[7].Value = model.TaxRate;
			array[8].Value = model.TaxAmount;
			array[9].Value = model.GoodsAmount;
			array[10].Value = model.ContractID;
			array[11].Value = model.MainTenancePeriod;
			array[12].Value = model.Spec;
			array[13].Value = model.ProductBrand;
			array[14].Value = model.Total;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			int result;
			if (single == null)
			{
				result = 0;
			}
			else
			{
				result = Convert.ToInt32(single);
			}
			return result;
		}

		public int UpdateData(SaleContractDetailInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SaleContractDetail set ");
			stringBuilder.Append("StockID=@StockID,");
			stringBuilder.Append("GoodsID=@GoodsID,");
			stringBuilder.Append("UnitID=@UnitID,");
			stringBuilder.Append("Qty=@Qty,");
			stringBuilder.Append("Price=@Price,");
			stringBuilder.Append("Dis=@Dis,");
			stringBuilder.Append("Remark=@Remark,");
			stringBuilder.Append("TaxRate=@TaxRate,");
			stringBuilder.Append("TaxAmount=@TaxAmount,");
			stringBuilder.Append("GoodsAmount=@GoodsAmount,");
			stringBuilder.Append("MainTenancePeriod=@MainTenancePeriod,");
			stringBuilder.Append("Spec=@Spec,");
			stringBuilder.Append("ProductBrand=@ProductBrand,");
			stringBuilder.Append("Total=@Total ");
			stringBuilder.Append(" where ContractID=@ContractID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StockID", SqlDbType.Int),
				new SqlParameter("@GoodsID", SqlDbType.Int),
				new SqlParameter("@UnitID", SqlDbType.Int),
				new SqlParameter("@Qty", SqlDbType.Decimal),
				new SqlParameter("@Price", SqlDbType.Money),
				new SqlParameter("@Dis", SqlDbType.Decimal),
				new SqlParameter("@Remark", SqlDbType.VarChar, 100),
				new SqlParameter("@TaxRate", SqlDbType.Money),
				new SqlParameter("@TaxAmount", SqlDbType.Money),
				new SqlParameter("@GoodsAmount", SqlDbType.Money),
				new SqlParameter("@ContractID", SqlDbType.Int),
				new SqlParameter("@MainTenancePeriod", SqlDbType.VarChar, 50),
				new SqlParameter("@Spec", SqlDbType.VarChar, 50),
				new SqlParameter("@ProductBrand", SqlDbType.VarChar, 50),
				new SqlParameter("@Total", SqlDbType.Money)
			};
			array[0].Value = model.StockID;
			array[1].Value = model.GoodsID;
			array[2].Value = model.UnitID;
			array[3].Value = model.Qty;
			array[4].Value = model.Price;
			array[5].Value = model.Dis;
			array[6].Value = model.Remark;
			array[7].Value = model.TaxRate;
			array[8].Value = model.TaxAmount;
			array[9].Value = model.GoodsAmount;
			array[10].Value = model.ContractID;
			array[11].Value = model.MainTenancePeriod;
			array[12].Value = model.Spec;
			array[13].Value = model.ProductBrand;
			array[14].Value = model.Total;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int DeleteData(string strWhere)
		{
			int result;
			if (string.IsNullOrEmpty(strWhere))
			{
				result = 0;
			}
			else
			{
				string sQLString = " delete from SaleContractDetail where " + strWhere;
				result = DbHelperSQL.ExecuteSql(sQLString);
			}
			return result;
		}

		public int DeleteDataByContractID(int ContractID)
		{
			string sQLString = " delete from SaleContractDetail where ContractID=@ContractID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ContractID", SqlDbType.Int)
			};
			array[0].Value = ContractID;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public SaleContractDetailInfo GetModel(int ID)
		{
			SaleContractDetailInfo saleContractDetailInfo = new SaleContractDetailInfo();
			string sQLString = " select * from SaleContractDetail where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = ID;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			SaleContractDetailInfo result;
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["StockID"].ToString() != "")
				{
					saleContractDetailInfo.StockID = int.Parse(dataTable.Rows[0]["StockID"].ToString());
				}
				if (dataTable.Rows[0]["GoodsID"].ToString() != "")
				{
					saleContractDetailInfo.GoodsID = int.Parse(dataTable.Rows[0]["GoodsID"].ToString());
				}
				if (dataTable.Rows[0]["UnitID"].ToString() != "")
				{
					saleContractDetailInfo.UnitID = int.Parse(dataTable.Rows[0]["UnitID"].ToString());
				}
				if (dataTable.Rows[0]["Qty"].ToString() != "")
				{
					saleContractDetailInfo.Qty = decimal.Parse(dataTable.Rows[0]["Qty"].ToString());
				}
				if (dataTable.Rows[0]["Dis"].ToString() != "")
				{
					saleContractDetailInfo.Dis = decimal.Parse(dataTable.Rows[0]["Dis"].ToString());
				}
				saleContractDetailInfo.Remark = dataTable.Rows[0]["Remark"].ToString();
				if (dataTable.Rows[0]["TaxRate"].ToString() != "")
				{
					saleContractDetailInfo.TaxRate = decimal.Parse(dataTable.Rows[0]["TaxRate"].ToString());
				}
				if (dataTable.Rows[0]["TaxAmount"].ToString() != "")
				{
					saleContractDetailInfo.TaxAmount = decimal.Parse(dataTable.Rows[0]["TaxAmount"].ToString());
				}
				if (dataTable.Rows[0]["GoodsAmount"].ToString() != "")
				{
					saleContractDetailInfo.GoodsAmount = decimal.Parse(dataTable.Rows[0]["GoodsAmount"].ToString());
				}
				if (dataTable.Rows[0]["ContractID"].ToString() != "")
				{
					saleContractDetailInfo.ContractID = int.Parse(dataTable.Rows[0]["ContractID"].ToString());
				}
				result = saleContractDetailInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public DataSet GetList(int constractid, int goodsid)
		{
			string sQLString = " select * from SaleContractDetail where ContractID=@ContractID and GoodsID=@GoodsID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ContractID", SqlDbType.Int),
				new SqlParameter("@GoodsID", SqlDbType.Int)
			};
			array[0].Value = constractid;
			array[1].Value = goodsid;
			return DbHelperSQL.Query(sQLString, array);
		}

		public int UpdateCount(int recid, decimal sellcount)
		{
			string sQLString = " update SaleContractDetail set Quotety=isnull(Quotety,0)+@Quotety where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Quotety", SqlDbType.Decimal),
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = sellcount;
			array[1].Value = recid;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public DataTable GetTable(int ID)
		{
			string sQLString = " select * from SaleContractDetail where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = ID;
			return DbHelperSQL.Query(sQLString, array).Tables[0];
		}

		public DataTable GetTableByContstractID(int constractID)
		{
			string sQLString = " select Qty,Quotety from SaleContractDetail where ContractID=@ContractID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ContractID", SqlDbType.Int)
			};
			array[0].Value = constractID;
			return DbHelperSQL.Query(sQLString, array).Tables[0];
		}
	}
}
