using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Coding.Stock.DAL
{
    /// <summary>
    /// 数据访问类:Cd_ImgStock
    /// </summary>
    public partial class WTLog
    {
        public WTLog()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.WTLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WTLog(");
            strSql.Append("source,person,personID,BillID,decribe,common,logtime,Att1,Att2,Dtime,Dtime2)");
            strSql.Append(" values (");
            strSql.Append("@source,@person,@personID,@BillID,@decribe,@common,@logtime,@Att1,@Att2,@Dtime,@Dtime2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@source", SqlDbType.VarChar,50),
					new SqlParameter("@person", SqlDbType.VarChar,50),
					new SqlParameter("@personID", SqlDbType.NVarChar,50),
                    	new SqlParameter("@BillID", SqlDbType.NVarChar,50),
                        	new SqlParameter("@decribe", SqlDbType.NVarChar,500),
                            	new SqlParameter("@common", SqlDbType.NVarChar,500),
                                	new SqlParameter("@logtime", SqlDbType.DateTime),
                                    	new SqlParameter("@Att1", SqlDbType.NVarChar,50),
                                        	new SqlParameter("@Att2", SqlDbType.NVarChar,50),
                                            	new SqlParameter("@Dtime", SqlDbType.DateTime),
                                                	new SqlParameter("@opt", SqlDbType.VarChar,50),
					new SqlParameter("@Dtime2", SqlDbType.DateTime)};
            parameters[0].Value = model.source;
            parameters[1].Value = model.person;
            parameters[2].Value = model.personID;
            parameters[3].Value = model.BillID;
            parameters[4].Value = model.decribe;
            parameters[5].Value = model.common;
            parameters[6].Value = model.logtime;
            parameters[7].Value = model.Att1;
            parameters[8].Value = model.Att2;
            parameters[9].Value = model.Dtime;
            parameters[10].Value = model.Dtime2;
            parameters[11].Value = model.opt;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM WTLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

