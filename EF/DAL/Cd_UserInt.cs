using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Coding.Stock.DAL
{
    /// <summary>
    /// 数据访问类:Cd_UserInt
    /// </summary>
    public partial class Cd_UserInt
    {
        public Cd_UserInt()
        { }
      
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, int UserID, string IntType, decimal IntQty, DateTime Datetime, string UpUser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cd_UserInt");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.Cd_UserInt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cd_UserInt(");
            strSql.Append("UserID,IntType,IntQty,Datetime,UpUser)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@IntType,@IntQty,@Datetime,@UpUser)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IntType", SqlDbType.VarChar,10),
					new SqlParameter("@IntQty", SqlDbType.Decimal,5),
					new SqlParameter("@Datetime", SqlDbType.DateTime),
					new SqlParameter("@UpUser", SqlDbType.VarChar,10)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.IntType;
            parameters[2].Value = model.IntQty;
            parameters[3].Value = model.Datetime;
            parameters[4].Value = model.UpUser;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Cd_UserInt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cd_UserInt set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("IntType=@IntType,");
            strSql.Append("IntQty=@IntQty,");
            strSql.Append("Datetime=@Datetime,");
            strSql.Append("UpUser=@UpUser");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IntType", SqlDbType.VarChar,10),
					new SqlParameter("@IntQty", SqlDbType.Decimal,5),
					new SqlParameter("@Datetime", SqlDbType.DateTime),
					new SqlParameter("@UpUser", SqlDbType.VarChar,10),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.IntType;
            parameters[2].Value = model.IntQty;
            parameters[3].Value = model.Datetime;
            parameters[4].Value = model.UpUser;
            parameters[5].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cd_UserInt ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cd_UserInt ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.Cd_UserInt GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,IntType,IntQty,Datetime,UpUser from Cd_UserInt ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Model.Cd_UserInt model = new Model.Cd_UserInt();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Model.Cd_UserInt DataRowToModel(DataRow row)
        {
            Model.Cd_UserInt model = new Model.Cd_UserInt();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["IntType"] != null)
                {
                    model.IntType = row["IntType"].ToString();
                }
                if (row["IntQty"] != null && row["IntQty"].ToString() != "")
                {
                    model.IntQty = decimal.Parse(row["IntQty"].ToString());
                }
                if (row["Datetime"] != null && row["Datetime"].ToString() != "")
                {
                    model.Datetime = DateTime.Parse(row["Datetime"].ToString());
                }
                if (row["UpUser"] != null)
                {
                    model.UpUser = row["UpUser"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserID,IntType,IntQty,Datetime,UpUser ");
            strSql.Append(" FROM Cd_UserInt ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,UserID,IntType,IntQty,Datetime,UpUser ");
            strSql.Append(" FROM Cd_UserInt ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Cd_UserInt ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Cd_UserInt T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

    }
}


