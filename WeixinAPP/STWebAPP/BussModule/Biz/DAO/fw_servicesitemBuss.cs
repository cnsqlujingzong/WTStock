using BussModule.Biz.Model;
using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BussModule.Biz.DAO
{
  public  class fw_servicesitemBuss
    {
        #region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID,string ItemNO,string _Name,string bComplete,int BillID,int ItemID,decimal Price,decimal dPoint,string Tec,string ChargeStyle,decimal TecDeduct,string Remark)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fw_servicesitem");
			strSql.Append(" where ID=@ID and ItemNO=@ItemNO and _Name=@_Name and bComplete=@bComplete and BillID=@BillID and ItemID=@ItemID and Price=@Price and dPoint=@dPoint and Tec=@Tec and ChargeStyle=@ChargeStyle and TecDeduct=@TecDeduct and Remark=@Remark ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					};
			parameters[0].Value = ID;
		

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fw_servicesitem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into fw_servicesitem(");
			strSql.Append("ID,BillID,ItemID,Price,dPoint,Tec,ChargeStyle,TecDeduct,Remark,ItemNO,_Name,bComplete)");
			strSql.Append(" values (");
			strSql.Append("@ID,@BillID,@ItemID,@Price,@dPoint,@Tec,@ChargeStyle,@TecDeduct,@Remark,@ItemNO,@_Name,@bComplete)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@dPoint", SqlDbType.Decimal,9),
					new SqlParameter("@Tec", SqlDbType.VarChar,50),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar,10),
					new SqlParameter("@TecDeduct", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@ItemNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,50),
					new SqlParameter("@bComplete", SqlDbType.VarChar,2)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BillID;
			parameters[2].Value = model.ItemID;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.dPoint;
			parameters[5].Value = model.Tec;
			parameters[6].Value = model.ChargeStyle;
			parameters[7].Value = model.TecDeduct;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.ItemNO;
			parameters[10].Value = model._Name;
			parameters[11].Value = model.bComplete;

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
		public bool Update(Model.fw_servicesitem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fw_servicesitem set ");
			strSql.Append("ID=@ID,");
			strSql.Append("BillID=@BillID,");
			strSql.Append("ItemID=@ItemID,");
			strSql.Append("Price=@Price,");
			strSql.Append("dPoint=@dPoint,");
			strSql.Append("Tec=@Tec,");
			strSql.Append("ChargeStyle=@ChargeStyle,");
			strSql.Append("TecDeduct=@TecDeduct,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("ItemNO=@ItemNO,");
			strSql.Append("_Name=@_Name,");
			strSql.Append("bComplete=@bComplete");
			strSql.Append(" where ID=@ID  ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
	};
			parameters[0].Value = model.ID;
		

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
		public bool Delete(int ID,string ItemNO,string _Name,string bComplete,int BillID,int ItemID,decimal Price,decimal dPoint,string Tec,string ChargeStyle,decimal TecDeduct,string Remark)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fw_servicesitem ");
			strSql.Append(" where ID=@ID and ItemNO=@ItemNO and _Name=@_Name and bComplete=@bComplete and BillID=@BillID and ItemID=@ItemID and Price=@Price and dPoint=@dPoint and Tec=@Tec and ChargeStyle=@ChargeStyle and TecDeduct=@TecDeduct and Remark=@Remark ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ItemNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,50),
					new SqlParameter("@bComplete", SqlDbType.VarChar,2),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@dPoint", SqlDbType.Decimal,9),
					new SqlParameter("@Tec", SqlDbType.VarChar,50),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar,10),
					new SqlParameter("@TecDeduct", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)			};
			parameters[0].Value = ID;
			parameters[1].Value = ItemNO;
			parameters[2].Value = _Name;
			parameters[3].Value = bComplete;
			parameters[4].Value = BillID;
			parameters[5].Value = ItemID;
			parameters[6].Value = Price;
			parameters[7].Value = dPoint;
			parameters[8].Value = Tec;
			parameters[9].Value = ChargeStyle;
			parameters[10].Value = TecDeduct;
			parameters[11].Value = Remark;

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
		/// 得到一个对象实体
		/// </summary>
		public Model.fw_servicesitem GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BillID,ItemID,Price,dPoint,Tec,ChargeStyle,TecDeduct,Remark,ItemNO,_Name,bComplete from fw_servicesitem ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = 
            {
					new SqlParameter("@ID", SqlDbType.Int,4)
		};
			parameters[0].Value = ID;
			Model.fw_servicesitem model=new Model.fw_servicesitem();
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
		public Model.fw_servicesitem DataRowToModel(DataRow row)
		{
			Model.fw_servicesitem model=new Model.fw_servicesitem();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["BillID"]!=null && row["BillID"].ToString()!="")
				{
					model.BillID=int.Parse(row["BillID"].ToString());
				}
				if(row["ItemID"]!=null && row["ItemID"].ToString()!="")
				{
					model.ItemID=int.Parse(row["ItemID"].ToString());
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["dPoint"]!=null && row["dPoint"].ToString()!="")
				{
					model.dPoint=decimal.Parse(row["dPoint"].ToString());
				}
				if(row["Tec"]!=null)
				{
					model.Tec=row["Tec"].ToString();
				}
				if(row["ChargeStyle"]!=null)
				{
					model.ChargeStyle=row["ChargeStyle"].ToString();
				}
				if(row["TecDeduct"]!=null && row["TecDeduct"].ToString()!="")
				{
					model.TecDeduct=decimal.Parse(row["TecDeduct"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["ItemNO"]!=null)
				{
					model.ItemNO=row["ItemNO"].ToString();
				}
				if(row["_Name"]!=null)
				{
					model._Name=row["_Name"].ToString();
				}
				if(row["bComplete"]!=null)
				{
					model.bComplete=row["bComplete"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<fw_servicesitem> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BillID,ItemID,Price,dPoint,Tec,ChargeStyle,TecDeduct,Remark,ItemNO,_Name,bComplete ");
			strSql.Append(" FROM fw_servicesitem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
		       DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<fw_servicesitem> list = new List<fw_servicesitem>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModel(item));
                }
            }
            return list;
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
			strSql.Append(" ID,BillID,ItemID,Price,dPoint,Tec,ChargeStyle,TecDeduct,Remark,ItemNO,_Name,bComplete ");
			strSql.Append(" FROM fw_servicesitem ");
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
			strSql.Append("select count(1) FROM fw_servicesitem ");
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
				strSql.Append("order by T.Remark desc");
			}
			strSql.Append(")AS Row, T.*  from fw_servicesitem T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
