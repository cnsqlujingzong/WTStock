using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BussModule.Biz.DAO
{
   public class fw_servicesProcessBuss
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, string TakeSteps, DateTime ArrivedTime, string Person, string DoDept, string DoOperator, DateTime visitdate, string Spending, int iDays, decimal iHours, DateTime StartTime, int BillID, string Course, string DoStyle, int DeptID, string Dept, int iOperator, string Operator, DateTime _Date, string Reason)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fw_servicesprocess");
            strSql.Append(" where ID=@ID and TakeSteps=@TakeSteps and ArrivedTime=@ArrivedTime and Person=@Person and DoDept=@DoDept and DoOperator=@DoOperator and visitdate=@visitdate and Spending=@Spending and iDays=@iDays and iHours=@iHours and StartTime=@StartTime and BillID=@BillID and Course=@Course and DoStyle=@DoStyle and DeptID=@DeptID and Dept=@Dept and iOperator=@iOperator and Operator=@Operator and _Date=@_Date and Reason=@Reason ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TakeSteps", SqlDbType.VarChar,2000),
					new SqlParameter("@ArrivedTime", SqlDbType.DateTime),
					new SqlParameter("@Person", SqlDbType.VarChar,50),
					new SqlParameter("@DoDept", SqlDbType.VarChar,100),
					new SqlParameter("@DoOperator", SqlDbType.VarChar,50),
					new SqlParameter("@visitdate", SqlDbType.DateTime),
					new SqlParameter("@Spending", SqlDbType.VarChar,106),
					new SqlParameter("@iDays", SqlDbType.Int,4),
					new SqlParameter("@iHours", SqlDbType.Decimal,9),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@Course", SqlDbType.VarChar,500),
					new SqlParameter("@DoStyle", SqlDbType.VarChar,50),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@Dept", SqlDbType.VarChar,50),
					new SqlParameter("@iOperator", SqlDbType.Int,4),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@_Date", SqlDbType.DateTime),
					new SqlParameter("@Reason", SqlDbType.VarChar,100)			};
            parameters[0].Value = ID;
            parameters[1].Value = TakeSteps;
            parameters[2].Value = ArrivedTime;
            parameters[3].Value = Person;
            parameters[4].Value = DoDept;
            parameters[5].Value = DoOperator;
            parameters[6].Value = visitdate;
            parameters[7].Value = Spending;
            parameters[8].Value = iDays;
            parameters[9].Value = iHours;
            parameters[10].Value = StartTime;
            parameters[11].Value = BillID;
            parameters[12].Value = Course;
            parameters[13].Value = DoStyle;
            parameters[14].Value = DeptID;
            parameters[15].Value = Dept;
            parameters[16].Value = iOperator;
            parameters[17].Value = Operator;
            parameters[18].Value = _Date;
            parameters[19].Value = Reason;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.fw_servicesprocess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into fw_servicesprocess(");
            strSql.Append("ID,BillID,DoStyle,DeptID,Dept,iOperator,Operator,_Date,Reason,TakeSteps,ArrivedTime,Person,DoDept,DoOperator,visitdate,Spending,iDays,iHours,StartTime,Course)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BillID,@DoStyle,@DeptID,@Dept,@iOperator,@Operator,@_Date,@Reason,@TakeSteps,@ArrivedTime,@Person,@DoDept,@DoOperator,@visitdate,@Spending,@iDays,@iHours,@StartTime,@Course)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@DoStyle", SqlDbType.VarChar,50),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@Dept", SqlDbType.VarChar,50),
					new SqlParameter("@iOperator", SqlDbType.Int,4),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@_Date", SqlDbType.DateTime),
					new SqlParameter("@Reason", SqlDbType.VarChar,100),
					new SqlParameter("@TakeSteps", SqlDbType.VarChar,2000),
					new SqlParameter("@ArrivedTime", SqlDbType.DateTime),
					new SqlParameter("@Person", SqlDbType.VarChar,50),
					new SqlParameter("@DoDept", SqlDbType.VarChar,100),
					new SqlParameter("@DoOperator", SqlDbType.VarChar,50),
					new SqlParameter("@visitdate", SqlDbType.DateTime),
					new SqlParameter("@Spending", SqlDbType.VarChar,106),
					new SqlParameter("@iDays", SqlDbType.Int,4),
					new SqlParameter("@iHours", SqlDbType.Decimal,9),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Course", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BillID;
            parameters[2].Value = model.DoStyle;
            parameters[3].Value = model.DeptID;
            parameters[4].Value = model.Dept;
            parameters[5].Value = model.iOperator;
            parameters[6].Value = model.Operator;
            parameters[7].Value = model._Date;
            parameters[8].Value = model.Reason;
            parameters[9].Value = model.TakeSteps;
            parameters[10].Value = model.ArrivedTime;
            parameters[11].Value = model.Person;
            parameters[12].Value = model.DoDept;
            parameters[13].Value = model.DoOperator;
            parameters[14].Value = model.visitdate;
            parameters[15].Value = model.Spending;
            parameters[16].Value = model.iDays;
            parameters[17].Value = model.iHours;
            parameters[18].Value = model.StartTime;
            parameters[19].Value = model.Course;

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
        public bool Update(Model.fw_servicesprocess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fw_servicesprocess set ");
            strSql.Append("ID=@ID,");
            strSql.Append("BillID=@BillID,");
            strSql.Append("DoStyle=@DoStyle,");
            strSql.Append("DeptID=@DeptID,");
            strSql.Append("Dept=@Dept,");
            strSql.Append("iOperator=@iOperator,");
            strSql.Append("Operator=@Operator,");
            strSql.Append("_Date=@_Date,");
            strSql.Append("Reason=@Reason,");
            strSql.Append("TakeSteps=@TakeSteps,");
            strSql.Append("ArrivedTime=@ArrivedTime,");
            strSql.Append("Person=@Person,");
            strSql.Append("DoDept=@DoDept,");
            strSql.Append("DoOperator=@DoOperator,");
            strSql.Append("visitdate=@visitdate,");
            strSql.Append("Spending=@Spending,");
            strSql.Append("iDays=@iDays,");
            strSql.Append("iHours=@iHours,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("Course=@Course");
            strSql.Append(" where ID=@ID and TakeSteps=@TakeSteps and ArrivedTime=@ArrivedTime and Person=@Person and DoDept=@DoDept and DoOperator=@DoOperator and visitdate=@visitdate and Spending=@Spending and iDays=@iDays and iHours=@iHours and StartTime=@StartTime and BillID=@BillID and Course=@Course and DoStyle=@DoStyle and DeptID=@DeptID and Dept=@Dept and iOperator=@iOperator and Operator=@Operator and _Date=@_Date and Reason=@Reason ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@DoStyle", SqlDbType.VarChar,50),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@Dept", SqlDbType.VarChar,50),
					new SqlParameter("@iOperator", SqlDbType.Int,4),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@_Date", SqlDbType.DateTime),
					new SqlParameter("@Reason", SqlDbType.VarChar,100),
					new SqlParameter("@TakeSteps", SqlDbType.VarChar,2000),
					new SqlParameter("@ArrivedTime", SqlDbType.DateTime),
					new SqlParameter("@Person", SqlDbType.VarChar,50),
					new SqlParameter("@DoDept", SqlDbType.VarChar,100),
					new SqlParameter("@DoOperator", SqlDbType.VarChar,50),
					new SqlParameter("@visitdate", SqlDbType.DateTime),
					new SqlParameter("@Spending", SqlDbType.VarChar,106),
					new SqlParameter("@iDays", SqlDbType.Int,4),
					new SqlParameter("@iHours", SqlDbType.Decimal,9),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Course", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BillID;
            parameters[2].Value = model.DoStyle;
            parameters[3].Value = model.DeptID;
            parameters[4].Value = model.Dept;
            parameters[5].Value = model.iOperator;
            parameters[6].Value = model.Operator;
            parameters[7].Value = model._Date;
            parameters[8].Value = model.Reason;
            parameters[9].Value = model.TakeSteps;
            parameters[10].Value = model.ArrivedTime;
            parameters[11].Value = model.Person;
            parameters[12].Value = model.DoDept;
            parameters[13].Value = model.DoOperator;
            parameters[14].Value = model.visitdate;
            parameters[15].Value = model.Spending;
            parameters[16].Value = model.iDays;
            parameters[17].Value = model.iHours;
            parameters[18].Value = model.StartTime;
            parameters[19].Value = model.Course;

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
            strSql.Append("delete from fw_servicesprocess ");
            strSql.Append(" where ID=@ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
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
        /// 得到一个对象实体
        /// </summary>
        public Model.fw_servicesprocess GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BillID,DoStyle,DeptID,Dept,iOperator,Operator,_Date,Reason,TakeSteps,ArrivedTime,Person,DoDept,DoOperator,visitdate,Spending,iDays,iHours,StartTime,Course from fw_servicesprocess ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
						};
            parameters[0].Value = ID;
      

            Model.fw_servicesprocess model = new Model.fw_servicesprocess();
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
        public Model.fw_servicesprocess DataRowToModel(DataRow row)
        {
            Model.fw_servicesprocess model = new Model.fw_servicesprocess();
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
                if (row["DoStyle"] != null)
                {
                    model.DoStyle = row["DoStyle"].ToString();
                }
                if (row["DeptID"] != null && row["DeptID"].ToString() != "")
                {
                    model.DeptID = int.Parse(row["DeptID"].ToString());
                }
                if (row["Dept"] != null)
                {
                    model.Dept = row["Dept"].ToString();
                }
                if (row["iOperator"] != null && row["iOperator"].ToString() != "")
                {
                    model.iOperator = int.Parse(row["iOperator"].ToString());
                }
                if (row["Operator"] != null)
                {
                    model.Operator = row["Operator"].ToString();
                }
                if (row["_Date"] != null && row["_Date"].ToString() != "")
                {
                    model._Date = DateTime.Parse(row["_Date"].ToString());
                }
                if (row["Reason"] != null)
                {
                    model.Reason = row["Reason"].ToString();
                }
                if (row["TakeSteps"] != null)
                {
                    model.TakeSteps = row["TakeSteps"].ToString();
                }
                if (row["ArrivedTime"] != null && row["ArrivedTime"].ToString() != "")
                {
                    model.ArrivedTime = DateTime.Parse(row["ArrivedTime"].ToString());
                }
                if (row["Person"] != null)
                {
                    model.Person = row["Person"].ToString();
                }
                if (row["DoDept"] != null)
                {
                    model.DoDept = row["DoDept"].ToString();
                }
                if (row["DoOperator"] != null)
                {
                    model.DoOperator = row["DoOperator"].ToString();
                }
                if (row["visitdate"] != null && row["visitdate"].ToString() != "")
                {
                    model.visitdate = DateTime.Parse(row["visitdate"].ToString());
                }
                if (row["Spending"] != null)
                {
                    model.Spending = row["Spending"].ToString();
                }
                if (row["iDays"] != null && row["iDays"].ToString() != "")
                {
                    model.iDays = int.Parse(row["iDays"].ToString());
                }
                if (row["iHours"] != null && row["iHours"].ToString() != "")
                {
                    model.iHours = decimal.Parse(row["iHours"].ToString());
                }
                if (row["StartTime"] != null && row["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(row["StartTime"].ToString());
                }
                if (row["Course"] != null)
                {
                    model.Course = row["Course"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.fw_servicesprocess> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BillID,DoStyle,DeptID,Dept,iOperator,Operator,_Date,Reason,TakeSteps,ArrivedTime,Person,DoDept,DoOperator,visitdate,Spending,iDays,iHours,StartTime,Course ");
            strSql.Append(" FROM fw_servicesprocess ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds= DbHelperSQL.Query(strSql.ToString());
            List<Model.fw_servicesprocess> list = new List<Model.fw_servicesprocess>();
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
            strSql.Append(" ID,BillID,DoStyle,DeptID,Dept,iOperator,Operator,_Date,Reason,TakeSteps,ArrivedTime,Person,DoDept,DoOperator,visitdate,Spending,iDays,iHours,StartTime,Course ");
            strSql.Append(" FROM fw_servicesprocess ");
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
            strSql.Append("select count(1) FROM fw_servicesprocess ");
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
                strSql.Append("order by T.Reason desc");
            }
            strSql.Append(")AS Row, T.*  from fw_servicesprocess T ");
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
