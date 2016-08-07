using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BussModule.Biz.DAO
{
  public  class fw_servicesofferBuss
    {
      	#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BussModule.Biz.Model.fw_servicesoffer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into fw_servicesoffer(");
			strSql.Append("ID,BillID,_Date,OperatorID,SellerID,ItemID,dAmount,bCusConf,Remark,_Name,Operator,Seller,CusConf)");
			strSql.Append(" values (");
			strSql.Append("@ID,@BillID,@_Date,@OperatorID,@SellerID,@ItemID,@dAmount,@bCusConf,@Remark,@_Name,@Operator,@Seller,@CusConf)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@_Date", SqlDbType.Char,10),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@SellerID", SqlDbType.Int,4),
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@dAmount", SqlDbType.Decimal,9),
					new SqlParameter("@bCusConf", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,300),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@Seller", SqlDbType.VarChar,50),
					new SqlParameter("@CusConf", SqlDbType.VarChar,2)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BillID;
			parameters[2].Value = model._Date;
			parameters[3].Value = model.OperatorID;
			parameters[4].Value = model.SellerID;
			parameters[5].Value = model.ItemID;
			parameters[6].Value = model.dAmount;
			parameters[7].Value = model.bCusConf;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model._Name;
			parameters[10].Value = model.Operator;
			parameters[11].Value = model.Seller;
			parameters[12].Value = model.CusConf;

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
		public bool Update(BussModule.Biz.Model.fw_servicesoffer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fw_servicesoffer set ");
			strSql.Append("ID=@ID,");
			strSql.Append("BillID=@BillID,");
			strSql.Append("_Date=@_Date,");
			strSql.Append("OperatorID=@OperatorID,");
			strSql.Append("SellerID=@SellerID,");
			strSql.Append("ItemID=@ItemID,");
			strSql.Append("dAmount=@dAmount,");
			strSql.Append("bCusConf=@bCusConf,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("_Name=@_Name,");
			strSql.Append("Operator=@Operator,");
			strSql.Append("Seller=@Seller,");
			strSql.Append("CusConf=@CusConf");
			strSql.Append(" where ID=@ID and _Name=@_Name and Operator=@Operator and Seller=@Seller and CusConf=@CusConf and BillID=@BillID and _Date=@_Date and OperatorID=@OperatorID and SellerID=@SellerID and ItemID=@ItemID and dAmount=@dAmount and bCusConf=@bCusConf and Remark=@Remark ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@_Date", SqlDbType.Char,10),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@SellerID", SqlDbType.Int,4),
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@dAmount", SqlDbType.Decimal,9),
					new SqlParameter("@bCusConf", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,300),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@Seller", SqlDbType.VarChar,50),
					new SqlParameter("@CusConf", SqlDbType.VarChar,2)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BillID;
			parameters[2].Value = model._Date;
			parameters[3].Value = model.OperatorID;
			parameters[4].Value = model.SellerID;
			parameters[5].Value = model.ItemID;
			parameters[6].Value = model.dAmount;
			parameters[7].Value = model.bCusConf;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model._Name;
			parameters[10].Value = model.Operator;
			parameters[11].Value = model.Seller;
			parameters[12].Value = model.CusConf;

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
		public bool Delete(int ID,string _Name,string Operator,string Seller,string CusConf,int BillID,string _Date,int OperatorID,int SellerID,int ItemID,decimal dAmount,bool bCusConf,string Remark)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fw_servicesoffer ");
			strSql.Append(" where ID=@ID and _Name=@_Name and Operator=@Operator and Seller=@Seller and CusConf=@CusConf and BillID=@BillID and _Date=@_Date and OperatorID=@OperatorID and SellerID=@SellerID and ItemID=@ItemID and dAmount=@dAmount and bCusConf=@bCusConf and Remark=@Remark ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@Seller", SqlDbType.VarChar,50),
					new SqlParameter("@CusConf", SqlDbType.VarChar,2),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@_Date", SqlDbType.Char,10),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@SellerID", SqlDbType.Int,4),
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@dAmount", SqlDbType.Decimal,9),
					new SqlParameter("@bCusConf", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,300)			};
			parameters[0].Value = ID;
			parameters[1].Value = _Name;
			parameters[2].Value = Operator;
			parameters[3].Value = Seller;
			parameters[4].Value = CusConf;
			parameters[5].Value = BillID;
			parameters[6].Value = _Date;
			parameters[7].Value = OperatorID;
			parameters[8].Value = SellerID;
			parameters[9].Value = ItemID;
			parameters[10].Value = dAmount;
			parameters[11].Value = bCusConf;
			parameters[12].Value = Remark;

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
		public BussModule.Biz.Model.fw_servicesoffer GetModel(int ID,string _Name,string Operator,string Seller,string CusConf,int BillID,string _Date,int OperatorID,int SellerID,int ItemID,decimal dAmount,bool bCusConf,string Remark)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BillID,_Date,OperatorID,SellerID,ItemID,dAmount,bCusConf,Remark,_Name,Operator,Seller,CusConf from fw_servicesoffer ");
			strSql.Append(" where ID=@ID and _Name=@_Name and Operator=@Operator and Seller=@Seller and CusConf=@CusConf and BillID=@BillID and _Date=@_Date and OperatorID=@OperatorID and SellerID=@SellerID and ItemID=@ItemID and dAmount=@dAmount and bCusConf=@bCusConf and Remark=@Remark ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@Seller", SqlDbType.VarChar,50),
					new SqlParameter("@CusConf", SqlDbType.VarChar,2),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@_Date", SqlDbType.Char,10),
					new SqlParameter("@OperatorID", SqlDbType.Int,4),
					new SqlParameter("@SellerID", SqlDbType.Int,4),
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@dAmount", SqlDbType.Decimal,9),
					new SqlParameter("@bCusConf", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,300)			};
			parameters[0].Value = ID;
			parameters[1].Value = _Name;
			parameters[2].Value = Operator;
			parameters[3].Value = Seller;
			parameters[4].Value = CusConf;
			parameters[5].Value = BillID;
			parameters[6].Value = _Date;
			parameters[7].Value = OperatorID;
			parameters[8].Value = SellerID;
			parameters[9].Value = ItemID;
			parameters[10].Value = dAmount;
			parameters[11].Value = bCusConf;
			parameters[12].Value = Remark;

			BussModule.Biz.Model.fw_servicesoffer model=new BussModule.Biz.Model.fw_servicesoffer();
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
		public BussModule.Biz.Model.fw_servicesoffer DataRowToModel(DataRow row)
		{
			BussModule.Biz.Model.fw_servicesoffer model=new BussModule.Biz.Model.fw_servicesoffer();
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
				if(row["_Date"]!=null)
				{
					model._Date=row["_Date"].ToString();
				}
				if(row["OperatorID"]!=null && row["OperatorID"].ToString()!="")
				{
					model.OperatorID=int.Parse(row["OperatorID"].ToString());
				}
				if(row["SellerID"]!=null && row["SellerID"].ToString()!="")
				{
					model.SellerID=int.Parse(row["SellerID"].ToString());
				}
				if(row["ItemID"]!=null && row["ItemID"].ToString()!="")
				{
					model.ItemID=int.Parse(row["ItemID"].ToString());
				}
				if(row["dAmount"]!=null && row["dAmount"].ToString()!="")
				{
					model.dAmount=decimal.Parse(row["dAmount"].ToString());
				}
				if(row["bCusConf"]!=null && row["bCusConf"].ToString()!="")
				{
					if((row["bCusConf"].ToString()=="1")||(row["bCusConf"].ToString().ToLower()=="true"))
					{
						model.bCusConf=true;
					}
					else
					{
						model.bCusConf=false;
					}
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["_Name"]!=null)
				{
					model._Name=row["_Name"].ToString();
				}
				if(row["Operator"]!=null)
				{
					model.Operator=row["Operator"].ToString();
				}
				if(row["Seller"]!=null)
				{
					model.Seller=row["Seller"].ToString();
				}
				if(row["CusConf"]!=null)
				{
					model.CusConf=row["CusConf"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Model.fw_servicesoffer> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BillID,_Date,OperatorID,SellerID,ItemID,dAmount,bCusConf,Remark,_Name,Operator,Seller,CusConf ");
			strSql.Append(" FROM fw_servicesoffer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Model.fw_servicesoffer> list = new List<Model.fw_servicesoffer>();
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
			strSql.Append(" ID,BillID,_Date,OperatorID,SellerID,ItemID,dAmount,bCusConf,Remark,_Name,Operator,Seller,CusConf ");
			strSql.Append(" FROM fw_servicesoffer ");
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
			strSql.Append("select count(1) FROM fw_servicesoffer ");
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
			strSql.Append(")AS Row, T.*  from fw_servicesoffer T ");
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
