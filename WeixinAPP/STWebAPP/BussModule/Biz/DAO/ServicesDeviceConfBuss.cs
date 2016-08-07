using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Collections.Generic;
using BussModule.Biz.Model;

namespace BussModule.Biz.DAO
{
	/// <summary>
	/// 数据访问类:ServicesDeviceConf
	/// </summary>
	public partial class ServicesDeviceConfBuss
	{
        public ServicesDeviceConfBuss()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "ServicesDeviceConf"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ServicesDeviceConf");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BussModule.Biz.Model.ServicesDeviceConf model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ServicesDeviceConf(");
			strSql.Append("ID,BillID,_Name,Parameter,SN,MaintenancePeriod,BuyDate,MaintenanceEnd,Remark,DevConfID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@BillID,@_Name,@Parameter,@SN,@MaintenancePeriod,@BuyDate,@MaintenanceEnd,@Remark,@DevConfID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@_Name", SqlDbType.VarChar,50),
					new SqlParameter("@Parameter", SqlDbType.VarChar,500),
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar,50),
					new SqlParameter("@BuyDate", SqlDbType.VarChar,50),
					new SqlParameter("@MaintenanceEnd", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@DevConfID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BillID;
			parameters[2].Value = model._Name;
			parameters[3].Value = model.Parameter;
			parameters[4].Value = model.SN;
			parameters[5].Value = model.MaintenancePeriod;
			parameters[6].Value = model.BuyDate;
			parameters[7].Value = model.MaintenanceEnd;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.DevConfID;

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
		public bool Update(BussModule.Biz.Model.ServicesDeviceConf model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ServicesDeviceConf set ");
			strSql.Append("BillID=@BillID,");
			strSql.Append("_Name=@_Name,");
			strSql.Append("Parameter=@Parameter,");
			strSql.Append("SN=@SN,");
			strSql.Append("MaintenancePeriod=@MaintenancePeriod,");
			strSql.Append("BuyDate=@BuyDate,");
			strSql.Append("MaintenanceEnd=@MaintenanceEnd,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("DevConfID=@DevConfID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@_Name", SqlDbType.VarChar,50),
					new SqlParameter("@Parameter", SqlDbType.VarChar,500),
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar,50),
					new SqlParameter("@BuyDate", SqlDbType.VarChar,50),
					new SqlParameter("@MaintenanceEnd", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@DevConfID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.BillID;
			parameters[1].Value = model._Name;
			parameters[2].Value = model.Parameter;
			parameters[3].Value = model.SN;
			parameters[4].Value = model.MaintenancePeriod;
			parameters[5].Value = model.BuyDate;
			parameters[6].Value = model.MaintenanceEnd;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.DevConfID;
			parameters[9].Value = model.ID;

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
			strSql.Append("delete from ServicesDeviceConf ");
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
			strSql.Append("delete from ServicesDeviceConf ");
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
		public BussModule.Biz.Model.ServicesDeviceConf GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BillID,_Name,Parameter,SN,MaintenancePeriod,BuyDate,MaintenanceEnd,Remark,DevConfID from ServicesDeviceConf ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

			BussModule.Biz.Model.ServicesDeviceConf model=new BussModule.Biz.Model.ServicesDeviceConf();
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
		public BussModule.Biz.Model.ServicesDeviceConf DataRowToModel(DataRow row)
		{
			BussModule.Biz.Model.ServicesDeviceConf model=new BussModule.Biz.Model.ServicesDeviceConf();
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
				if(row["_Name"]!=null)
				{
					model._Name=row["_Name"].ToString();
				}
				if(row["Parameter"]!=null)
				{
					model.Parameter=row["Parameter"].ToString();
				}
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["MaintenancePeriod"]!=null)
				{
					model.MaintenancePeriod=row["MaintenancePeriod"].ToString();
				}
				if(row["BuyDate"]!=null)
				{
					model.BuyDate=row["BuyDate"].ToString();
				}
				if(row["MaintenanceEnd"]!=null)
				{
					model.MaintenanceEnd=row["MaintenanceEnd"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["DevConfID"]!=null && row["DevConfID"].ToString()!="")
				{
					model.DevConfID=int.Parse(row["DevConfID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<ServicesDeviceConf> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BillID,_Name,Parameter,SN,MaintenancePeriod,BuyDate,MaintenanceEnd,Remark,DevConfID ");
			strSql.Append(" FROM ServicesDeviceConf ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ServicesDeviceConf> list = new List<ServicesDeviceConf>();
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
			strSql.Append(" ID,BillID,_Name,Parameter,SN,MaintenancePeriod,BuyDate,MaintenanceEnd,Remark,DevConfID ");
			strSql.Append(" FROM ServicesDeviceConf ");
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
			strSql.Append("select count(1) FROM ServicesDeviceConf ");
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
			strSql.Append(")AS Row, T.*  from ServicesDeviceConf T ");
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
			parameters[0].Value = "ServicesDeviceConf";
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

