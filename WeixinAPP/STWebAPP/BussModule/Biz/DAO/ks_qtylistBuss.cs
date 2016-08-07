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
    public class ks_qtylistBuss
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BussModule.Biz.Model.ks_qtylist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ks_qtylist(");
            strSql.Append("ID,BillID,DeviceID,SN,_Date,OperatorID,QtyType,Qty,Remark,Operator,ProductSN1,ProductSN2,Allowance)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BillID,@DeviceID,@SN,@_Date,@OperatorID,@QtyType,@Qty,@Remark,@Operator,@ProductSN1,@ProductSN2,@Allowance)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@DeviceID", SqlDbType.Int,4),
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@_Date", SqlDbType.Char,10),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@QtyType", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSN1", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSN2", SqlDbType.VarChar,50),
					new SqlParameter("@Allowance", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BillID;
            parameters[2].Value = model.DeviceID;
            parameters[3].Value = model.SN;
            parameters[4].Value = model._Date;
            parameters[5].Value = model.OperatorID;
            parameters[6].Value = model.QtyType;
            parameters[7].Value = model.Qty;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Operator;
            parameters[10].Value = model.ProductSN1;
            parameters[11].Value = model.ProductSN2;
            parameters[12].Value = model.Allowance;

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
        public bool Update(BussModule.Biz.Model.ks_qtylist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ks_qtylist set ");
            strSql.Append("ID=@ID,");
            strSql.Append("BillID=@BillID,");
            strSql.Append("DeviceID=@DeviceID,");
            strSql.Append("SN=@SN,");
            strSql.Append("_Date=@_Date,");
            strSql.Append("OperatorID=@OperatorID,");
            strSql.Append("QtyType=@QtyType,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Operator=@Operator,");
            strSql.Append("ProductSN1=@ProductSN1,");
            strSql.Append("ProductSN2=@ProductSN2,");
            strSql.Append("Allowance=@Allowance");
            strSql.Append(" where ID=@ID and Operator=@Operator and ProductSN1=@ProductSN1 and ProductSN2=@ProductSN2 and Allowance=@Allowance and BillID=@BillID and DeviceID=@DeviceID and SN=@SN and _Date=@_Date and OperatorID=@OperatorID and QtyType=@QtyType and Qty=@Qty and Remark=@Remark ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@DeviceID", SqlDbType.Int,4),
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@_Date", SqlDbType.Char,10),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@QtyType", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSN1", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSN2", SqlDbType.VarChar,50),
					new SqlParameter("@Allowance", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BillID;
            parameters[2].Value = model.DeviceID;
            parameters[3].Value = model.SN;
            parameters[4].Value = model._Date;
            parameters[5].Value = model.OperatorID;
            parameters[6].Value = model.QtyType;
            parameters[7].Value = model.Qty;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Operator;
            parameters[10].Value = model.ProductSN1;
            parameters[11].Value = model.ProductSN2;
            parameters[12].Value = model.Allowance;

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
        public bool Delete(int ID, string Operator, string ProductSN1, string ProductSN2, string Allowance, int BillID, int DeviceID, string SN, string _Date, int OperatorID, string QtyType, int Qty, string Remark)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ks_qtylist ");
            strSql.Append(" where ID=@ID and Operator=@Operator and ProductSN1=@ProductSN1 and ProductSN2=@ProductSN2 and Allowance=@Allowance and BillID=@BillID and DeviceID=@DeviceID and SN=@SN and _Date=@_Date and OperatorID=@OperatorID and QtyType=@QtyType and Qty=@Qty and Remark=@Remark ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSN1", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSN2", SqlDbType.VarChar,50),
					new SqlParameter("@Allowance", SqlDbType.VarChar,50),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@DeviceID", SqlDbType.Int,4),
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@_Date", SqlDbType.Char,10),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@QtyType", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,500)			};
            parameters[0].Value = ID;
            parameters[1].Value = Operator;
            parameters[2].Value = ProductSN1;
            parameters[3].Value = ProductSN2;
            parameters[4].Value = Allowance;
            parameters[5].Value = BillID;
            parameters[6].Value = DeviceID;
            parameters[7].Value = SN;
            parameters[8].Value = _Date;
            parameters[9].Value = OperatorID;
            parameters[10].Value = QtyType;
            parameters[11].Value = Qty;
            parameters[12].Value = Remark;

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
        public BussModule.Biz.Model.ks_qtylist GetModel(int ID, string Operator, string ProductSN1, string ProductSN2, string Allowance, int BillID, int DeviceID, string SN, string _Date, int OperatorID, string QtyType, int Qty, string Remark)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BillID,DeviceID,SN,_Date,OperatorID,QtyType,Qty,Remark,Operator,ProductSN1,ProductSN2,Allowance from ks_qtylist ");
            strSql.Append(" where ID=@ID and Operator=@Operator and ProductSN1=@ProductSN1 and ProductSN2=@ProductSN2 and Allowance=@Allowance and BillID=@BillID and DeviceID=@DeviceID and SN=@SN and _Date=@_Date and OperatorID=@OperatorID and QtyType=@QtyType and Qty=@Qty and Remark=@Remark ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSN1", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSN2", SqlDbType.VarChar,50),
					new SqlParameter("@Allowance", SqlDbType.VarChar,50),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@DeviceID", SqlDbType.Int,4),
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@_Date", SqlDbType.Char,10),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@QtyType", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,500)			};
            parameters[0].Value = ID;
            parameters[1].Value = Operator;
            parameters[2].Value = ProductSN1;
            parameters[3].Value = ProductSN2;
            parameters[4].Value = Allowance;
            parameters[5].Value = BillID;
            parameters[6].Value = DeviceID;
            parameters[7].Value = SN;
            parameters[8].Value = _Date;
            parameters[9].Value = OperatorID;
            parameters[10].Value = QtyType;
            parameters[11].Value = Qty;
            parameters[12].Value = Remark;

            BussModule.Biz.Model.ks_qtylist model = new BussModule.Biz.Model.ks_qtylist();
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
        public BussModule.Biz.Model.ks_qtylist DataRowToModel(DataRow row)
        {
            BussModule.Biz.Model.ks_qtylist model = new BussModule.Biz.Model.ks_qtylist();
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
                if (row["DeviceID"] != null && row["DeviceID"].ToString() != "")
                {
                    model.DeviceID = int.Parse(row["DeviceID"].ToString());
                }
                if (row["SN"] != null)
                {
                    model.SN = row["SN"].ToString();
                }
                if (row["_Date"] != null)
                {
                    model._Date = row["_Date"].ToString();
                }
                if (row["OperatorID"] != null && row["OperatorID"].ToString() != "")
                {
                    model.OperatorID = int.Parse(row["OperatorID"].ToString());
                }
                if (row["QtyType"] != null)
                {
                    model.QtyType = row["QtyType"].ToString();
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = int.Parse(row["Qty"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Operator"] != null)
                {
                    model.Operator = row["Operator"].ToString();
                }
                if (row["ProductSN1"] != null)
                {
                    model.ProductSN1 = row["ProductSN1"].ToString();
                }
                if (row["ProductSN2"] != null)
                {
                    model.ProductSN2 = row["ProductSN2"].ToString();
                }
                if (row["Allowance"] != null)
                {
                    model.Allowance = row["Allowance"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ks_qtylist> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BillID,DeviceID,SN,_Date,OperatorID,QtyType,Qty,Remark,Operator,ProductSN1,ProductSN2,Allowance ");
            strSql.Append(" FROM ks_qtylist ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Model.ks_qtylist> list = new List<Model.ks_qtylist>();
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
            strSql.Append(" ID,BillID,DeviceID,SN,_Date,OperatorID,QtyType,Qty,Remark,Operator,ProductSN1,ProductSN2,Allowance ");
            strSql.Append(" FROM ks_qtylist ");
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
            strSql.Append("select count(1) FROM ks_qtylist ");
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
                strSql.Append("order by T.Remark desc");
            }
            strSql.Append(")AS Row, T.*  from ks_qtylist T ");
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
