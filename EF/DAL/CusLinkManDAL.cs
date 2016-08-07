using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using wt.Model;

namespace EF.DAL
{
    public class CusLinkManDAL
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CustomerLinkMan");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CustomerLinkManInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CustomerLinkMan(");
            strSql.Append("CustomerID,_Name,LinkManDept,Sex,Posit,tel_Office,tel_Home,tel_Mobile,Fax,Email,Birthday,Remark,Adr,tel_Mobile1,tel_Mobile2,tel_QQ,tel_weixin,tel_padr,ID)");
            strSql.Append(" values (");
            strSql.Append("@CustomerID,@_Name,@LinkManDept,@Sex,@Posit,@tel_Office,@tel_Home,@tel_Mobile,@Fax,@Email,@Birthday,@Remark,@Adr,@tel_Mobile1,@tel_Mobile2,@tel_QQ,@tel_weixin,@tel_padr,@ID)");
            SqlParameter[] parameters = {				
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@_Name", SqlDbType.VarChar,50),
					new SqlParameter("@LinkManDept", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@Posit", SqlDbType.VarChar,50),
					new SqlParameter("@tel_Office", SqlDbType.VarChar,50),
					new SqlParameter("@tel_Home", SqlDbType.VarChar,50),
					new SqlParameter("@tel_Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@Adr", SqlDbType.VarChar,200),
					new SqlParameter("@tel_Mobile1", SqlDbType.VarChar,50),
					new SqlParameter("@tel_Mobile2", SqlDbType.VarChar,50),
					new SqlParameter("@tel_QQ", SqlDbType.VarChar,50),
					new SqlParameter("@tel_weixin", SqlDbType.VarChar,50),
					new SqlParameter("@tel_padr", SqlDbType.VarChar,200),
                                        	new SqlParameter("@ID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.CustomerID;
            parameters[1].Value = model._Name;
            parameters[2].Value = model.LinkManDept;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Posit;
            parameters[5].Value = model.tel_Office;
            parameters[6].Value = model.tel_Home;
            parameters[7].Value = model.tel_Mobile;
            parameters[8].Value = model.Fax;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.Birthday;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.Adr;
            parameters[13].Value = model.Tel_mobile1;
            parameters[14].Value = model.Tel_mobile2;
            parameters[15].Value = model.Tel_qq;
            parameters[16].Value = model.Tel_weixin;
            parameters[17].Value = model.Tel_padr;
            parameters[18].Value = GetMaxId()+1;

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
    }
}
