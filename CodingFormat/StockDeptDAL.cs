using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace BussModule.Biz.DAL
{
	/// <summary>
	/// 数据访问类:StockDept
	/// </summary>
	public partial class StockDeptDAL
	{
        public StockDeptDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "StockDept"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StockDept");
			strSql.Append(" where GoodsID=@NO ");
			SqlParameter[] parameters = {
					new SqlParameter("@NO", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BussModule.Biz.Model.StockDept model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StockDept(");
			strSql.Append("ID,DeptID,StockID,GoodsID,StockLocID,Stock,CostPrice,upWarning,downWarning,CheckCount,Remark,BeginStock,BeginCost,BeginStatus)");
			strSql.Append(" values (");
			strSql.Append("@ID,@DeptID,@StockID,@GoodsID,@StockLocID,@Stock,@CostPrice,@upWarning,@downWarning,@CheckCount,@Remark,@BeginStock,@BeginCost,@BeginStatus)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@StockID", SqlDbType.Int,4),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@StockLocID", SqlDbType.Int,4),
					new SqlParameter("@Stock", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@upWarning", SqlDbType.Decimal,9),
					new SqlParameter("@downWarning", SqlDbType.Decimal,9),
					new SqlParameter("@CheckCount", SqlDbType.VarChar,20),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@BeginStock", SqlDbType.Decimal,9),
					new SqlParameter("@BeginCost", SqlDbType.Decimal,9),
					new SqlParameter("@BeginStatus", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.DeptID;
			parameters[2].Value = model.StockID;
			parameters[3].Value = model.GoodsID;
			parameters[4].Value = model.StockLocID;
			parameters[5].Value = model.Stock;
			parameters[6].Value = model.CostPrice;
			parameters[7].Value = model.upWarning;
			parameters[8].Value = model.downWarning;
			parameters[9].Value = model.CheckCount;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.BeginStock;
			parameters[12].Value = model.BeginCost;
			parameters[13].Value = model.BeginStatus;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BussModule.Biz.Model.StockDept model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StockDept set ");
			strSql.Append("DeptID=@DeptID,");
			strSql.Append("StockID=@StockID,");
			strSql.Append("GoodsID=@GoodsID,");
			strSql.Append("StockLocID=@StockLocID,");
			strSql.Append("Stock=@Stock,");
			strSql.Append("CostPrice=@CostPrice,");
			strSql.Append("upWarning=@upWarning,");
			strSql.Append("downWarning=@downWarning,");
			strSql.Append("CheckCount=@CheckCount,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("BeginStock=@BeginStock,");
			strSql.Append("BeginCost=@BeginCost,");
			strSql.Append("BeginStatus=@BeginStatus");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@StockID", SqlDbType.Int,4),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@StockLocID", SqlDbType.Int,4),
					new SqlParameter("@Stock", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@upWarning", SqlDbType.Decimal,9),
					new SqlParameter("@downWarning", SqlDbType.Decimal,9),
					new SqlParameter("@CheckCount", SqlDbType.VarChar,20),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@BeginStock", SqlDbType.Decimal,9),
					new SqlParameter("@BeginCost", SqlDbType.Decimal,9),
					new SqlParameter("@BeginStatus", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.DeptID;
			parameters[1].Value = model.StockID;
			parameters[2].Value = model.GoodsID;
			parameters[3].Value = model.StockLocID;
			parameters[4].Value = model.Stock;
			parameters[5].Value = model.CostPrice;
			parameters[6].Value = model.upWarning;
			parameters[7].Value = model.downWarning;
			parameters[8].Value = model.CheckCount;
			parameters[9].Value = model.Remark;
			parameters[10].Value = model.BeginStock;
			parameters[11].Value = model.BeginCost;
			parameters[12].Value = model.BeginStatus;
			parameters[13].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StockDept ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StockDept ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BussModule.Biz.Model.StockDept GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,DeptID,StockID,GoodsID,StockLocID,Stock,CostPrice,upWarning,downWarning,CheckCount,Remark,BeginStock,BeginCost,BeginStatus from StockDept ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

			BussModule.Biz.Model.StockDept model=new BussModule.Biz.Model.StockDept();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BussModule.Biz.Model.StockDept DataRowToModel(DataRow row)
		{
			BussModule.Biz.Model.StockDept model=new BussModule.Biz.Model.StockDept();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["DeptID"]!=null && row["DeptID"].ToString()!="")
				{
					model.DeptID=int.Parse(row["DeptID"].ToString());
				}
				if(row["StockID"]!=null && row["StockID"].ToString()!="")
				{
					model.StockID=int.Parse(row["StockID"].ToString());
				}
				if(row["GoodsID"]!=null && row["GoodsID"].ToString()!="")
				{
					model.GoodsID=int.Parse(row["GoodsID"].ToString());
				}
				if(row["StockLocID"]!=null && row["StockLocID"].ToString()!="")
				{
					model.StockLocID=int.Parse(row["StockLocID"].ToString());
				}
				if(row["Stock"]!=null && row["Stock"].ToString()!="")
				{
					model.Stock=decimal.Parse(row["Stock"].ToString());
				}
				if(row["CostPrice"]!=null && row["CostPrice"].ToString()!="")
				{
					model.CostPrice=decimal.Parse(row["CostPrice"].ToString());
				}
				if(row["upWarning"]!=null && row["upWarning"].ToString()!="")
				{
					model.upWarning=decimal.Parse(row["upWarning"].ToString());
				}
				if(row["downWarning"]!=null && row["downWarning"].ToString()!="")
				{
					model.downWarning=decimal.Parse(row["downWarning"].ToString());
				}
				if(row["CheckCount"]!=null)
				{
					model.CheckCount=row["CheckCount"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["BeginStock"]!=null && row["BeginStock"].ToString()!="")
				{
					model.BeginStock=decimal.Parse(row["BeginStock"].ToString());
				}
				if(row["BeginCost"]!=null && row["BeginCost"].ToString()!="")
				{
					model.BeginCost=decimal.Parse(row["BeginCost"].ToString());
				}
				if(row["BeginStatus"]!=null && row["BeginStatus"].ToString()!="")
				{
					model.BeginStatus=int.Parse(row["BeginStatus"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,DeptID,StockID,GoodsID,StockLocID,Stock,CostPrice,upWarning,downWarning,CheckCount,Remark,BeginStock,BeginCost,BeginStatus ");
			strSql.Append(" FROM StockDept ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,DeptID,StockID,GoodsID,StockLocID,Stock,CostPrice,upWarning,downWarning,CheckCount,Remark,BeginStock,BeginCost,BeginStatus ");
			strSql.Append(" FROM StockDept ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM StockDept ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from StockDept T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "StockDept";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

