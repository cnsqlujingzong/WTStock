using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BussModule.Biz.DAO
{
    public class fw_serviceslogBuss
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BussModule.Biz.Model.fw_serviceslog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into fw_serviceslog(");
            strSql.Append("ID,BillID,OperatorID,_Date,Event,Operator)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BillID,@OperatorID,@_Date,@Event,@Operator)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@_Date", SqlDbType.DateTime),
					new SqlParameter("@Event", SqlDbType.VarChar,300),
					new SqlParameter("@Operator", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BillID;
            parameters[2].Value = model.OperatorID;
            parameters[3].Value = model._Date;
            parameters[4].Value = model.Event;
            parameters[5].Value = model.Operator;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(BussModule.Biz.Model.fw_serviceslog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fw_serviceslog set ");
            strSql.Append("ID=@ID,");
            strSql.Append("BillID=@BillID,");
            strSql.Append("OperatorID=@OperatorID,");
            strSql.Append("_Date=@_Date,");
            strSql.Append("Event=@Event,");
            strSql.Append("Operator=@Operator");
            strSql.Append(" where ID=@ID and BillID=@BillID and OperatorID=@OperatorID and _Date=@_Date and Event=@Event and Operator=@Operator ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@_Date", SqlDbType.DateTime),
					new SqlParameter("@Event", SqlDbType.VarChar,300),
					new SqlParameter("@Operator", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BillID;
            parameters[2].Value = model.OperatorID;
            parameters[3].Value = model._Date;
            parameters[4].Value = model.Event;
            parameters[5].Value = model.Operator;

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
        public bool Delete(int ID, int BillID, int OperatorID, DateTime _Date, string Event, string Operator)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fw_serviceslog ");
            strSql.Append(" where ID=@ID and BillID=@BillID and OperatorID=@OperatorID and _Date=@_Date and Event=@Event and Operator=@Operator ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@_Date", SqlDbType.DateTime),
					new SqlParameter("@Event", SqlDbType.VarChar,300),
					new SqlParameter("@Operator", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;
            parameters[1].Value = BillID;
            parameters[2].Value = OperatorID;
            parameters[3].Value = _Date;
            parameters[4].Value = Event;
            parameters[5].Value = Operator;

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
        /// 得到一个对象实体
        /// </summary>
        public BussModule.Biz.Model.fw_serviceslog GetModel(int ID, int BillID, int OperatorID, DateTime _Date, string Event, string Operator)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BillID,OperatorID,_Date,Event,Operator from fw_serviceslog ");
            strSql.Append(" where ID=@ID and BillID=@BillID and OperatorID=@OperatorID and _Date=@_Date and Event=@Event and Operator=@Operator ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@_Date", SqlDbType.DateTime),
					new SqlParameter("@Event", SqlDbType.VarChar,300),
					new SqlParameter("@Operator", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;
            parameters[1].Value = BillID;
            parameters[2].Value = OperatorID;
            parameters[3].Value = _Date;
            parameters[4].Value = Event;
            parameters[5].Value = Operator;

            BussModule.Biz.Model.fw_serviceslog model = new BussModule.Biz.Model.fw_serviceslog();
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
        public BussModule.Biz.Model.fw_serviceslog DataRowToModel(DataRow row)
        {
            BussModule.Biz.Model.fw_serviceslog model = new BussModule.Biz.Model.fw_serviceslog();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["BillID"] != null && row["BillID"].ToString() != "")
                {
                    model.BillID = int.Parse(row["BillID"].ToString());
                }
                if (row["OperatorID"] != null && row["OperatorID"].ToString() != "")
                {
                    model.OperatorID = int.Parse(row["OperatorID"].ToString());
                }
                if (row["_Date"] != null && row["_Date"].ToString() != "")
                {
                    model._Date = DateTime.Parse(row["_Date"].ToString());
                }
                if (row["Event"] != null)
                {
                    model.Event = row["Event"].ToString();
                }
                if (row["Operator"] != null)
                {
                    model.Operator = row["Operator"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.fw_serviceslog> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BillID,OperatorID,_Date,Event,Operator ");
            strSql.Append(" FROM fw_serviceslog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Model.fw_serviceslog> list = new List<Model.fw_serviceslog>();
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,BillID,OperatorID,_Date,Event,Operator ");
            strSql.Append(" FROM fw_serviceslog ");
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
            strSql.Append("select count(1) FROM fw_serviceslog ");
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
                strSql.Append("order by T.Operator desc");
            }
            strSql.Append(")AS Row, T.*  from fw_serviceslog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
    }
}
