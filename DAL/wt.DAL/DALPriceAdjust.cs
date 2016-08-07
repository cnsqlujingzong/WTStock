using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALPriceAdjust
	{
		public int Add(PriceAdjust model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into PriceAdjust(");
			stringBuilder.Append("selectflag,pricename1,pricename2,separator,price,formula)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@selectflag,@pricename1,@pricename2,@separator,@price,@formula)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@selectflag", SqlDbType.Bit, 1),
				new SqlParameter("@pricename1", SqlDbType.VarChar, 50),
				new SqlParameter("@pricename2", SqlDbType.VarChar, 50),
				new SqlParameter("@separator", SqlDbType.VarChar, 10),
				new SqlParameter("@price", SqlDbType.Decimal, 9),
				new SqlParameter("@formula", SqlDbType.VarChar, 50)
			};
			array[0].Value = model.Selectflag;
			array[1].Value = model.Pricename1;
			array[2].Value = model.Pricename2;
			array[3].Value = model.Separator;
			array[4].Value = model.Price;
			array[5].Value = model.Formula;
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

		public void Update(PriceAdjust model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update PriceAdjust set ");
			stringBuilder.Append("pricename2=@pricename2,");
			stringBuilder.Append("separator=@separator,");
			stringBuilder.Append("price=@price,");
			stringBuilder.Append("formula=@formula");
			stringBuilder.Append(" where goodsadjustconfigid=@goodsadjustconfigid");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@goodsadjustconfigid", SqlDbType.Int, 4),
				new SqlParameter("@pricename2", SqlDbType.VarChar, 50),
				new SqlParameter("@separator", SqlDbType.VarChar, 10),
				new SqlParameter("@price", SqlDbType.Decimal, 9),
				new SqlParameter("@formula", SqlDbType.VarChar, 500)
			};
			array[0].Value = model.Godsadjustconfigid;
			array[1].Value = model.Pricename2;
			array[2].Value = model.Separator;
			array[3].Value = model.Price;
			array[4].Value = model.Formula;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Update_All(PriceAdjust model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update PriceAdjust set ");
			stringBuilder.Append("pricename1=@pricename1,");
			stringBuilder.Append("pricename2=@pricename2,");
			stringBuilder.Append("separator=@separator,");
			stringBuilder.Append("price=@price,");
			stringBuilder.Append("formula=@formula");
			stringBuilder.Append(" where goodsadjustconfigid=@goodsadjustconfigid");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@goodsadjustconfigid", SqlDbType.Int, 4),
				new SqlParameter("@pricename1", SqlDbType.VarChar, 50),
				new SqlParameter("@pricename2", SqlDbType.VarChar, 50),
				new SqlParameter("@separator", SqlDbType.VarChar, 10),
				new SqlParameter("@price", SqlDbType.Decimal, 9),
				new SqlParameter("@formula", SqlDbType.VarChar, 500)
			};
			array[0].Value = model.Godsadjustconfigid;
			array[1].Value = model.Pricename1;
			array[2].Value = model.Pricename2;
			array[3].Value = model.Separator;
			array[4].Value = model.Price;
			array[5].Value = model.Formula;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int updatePrice(string strFldContent, string strCondition, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strFldContent", SqlDbType.VarChar, 500),
				new SqlParameter("@strCondition", SqlDbType.VarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.VarChar, 200)
			};
			array[0].Value = strFldContent;
			array[1].Value = strCondition;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_updatePrice", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int Delete(string strTbName, int ID, out string strMsg)
		{
			return DALCommon.DeteleData(strTbName, "goodsadjustconfigid=" + ID.ToString(), out strMsg);
		}

		public PriceAdjust GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select goodsadjustconfigid,selectflag,pricename1,pricename2,separator,price,formula from PriceAdjust ");
			stringBuilder.Append(" where goodsadjustconfigid=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			PriceAdjust priceAdjust = new PriceAdjust();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			PriceAdjust result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["goodsadjustconfigid"].ToString() != "")
				{
					priceAdjust._goodsadjustconfigid = int.Parse(dataSet.Tables[0].Rows[0]["goodsadjustconfigid"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["selectflag"].ToString() != "")
				{
					priceAdjust.Selectflag = bool.Parse(dataSet.Tables[0].Rows[0]["selectflag"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["pricename1"].ToString() != "")
				{
					priceAdjust.Pricename1 = dataSet.Tables[0].Rows[0]["pricename1"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["pricename2"].ToString() != "")
				{
					priceAdjust.Pricename2 = dataSet.Tables[0].Rows[0]["pricename2"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["separator"].ToString() != "")
				{
					priceAdjust.Separator = dataSet.Tables[0].Rows[0]["separator"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["price"].ToString() != "")
				{
					priceAdjust.Price = decimal.Parse(dataSet.Tables[0].Rows[0]["price"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["formula"].ToString() != "")
				{
					priceAdjust.Formula = dataSet.Tables[0].Rows[0]["formula"].ToString();
				}
				result = priceAdjust;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
