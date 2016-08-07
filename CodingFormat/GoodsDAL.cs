using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BussModule.Biz.DAL
{
	/// <summary>
	/// 数据访问类:Goods
	/// </summary>
	public partial class GoodsDAL
	{
        public GoodsDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Goods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Goods");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BussModule.Biz.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Goods(");
			strSql.Append("ID,GoodsNO,_Name,ClassID,Spec,BrandID,PicPath,ForProducts,Attr,MainTenancePeriod,StockID,ProvID,bStock,CostMode,Valid,bIncrement,bSNTrack,bStop,pyCode,Remark,userdef1,userdef2,userdef3,userdef4,userdef5,userdef6,PCB)");
			strSql.Append(" values (");
			strSql.Append("@ID,@GoodsNO,@_Name,@ClassID,@Spec,@BrandID,@PicPath,@ForProducts,@Attr,@MainTenancePeriod,@StockID,@ProvID,@bStock,@CostMode,@Valid,@bIncrement,@bSNTrack,@bStop,@pyCode,@Remark,@userdef1,@userdef2,@userdef3,@userdef4,@userdef5,@userdef6,@PCB)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GoodsNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@Spec", SqlDbType.VarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@PicPath", SqlDbType.VarChar,100),
					new SqlParameter("@ForProducts", SqlDbType.VarChar,50),
					new SqlParameter("@Attr", SqlDbType.VarChar,20),
					new SqlParameter("@MainTenancePeriod", SqlDbType.VarChar,10),
					new SqlParameter("@StockID", SqlDbType.Int,4),
					new SqlParameter("@ProvID", SqlDbType.Int,4),
					new SqlParameter("@bStock", SqlDbType.Bit,1),
					new SqlParameter("@CostMode", SqlDbType.Int,4),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@bIncrement", SqlDbType.Bit,1),
					new SqlParameter("@bSNTrack", SqlDbType.Bit,1),
					new SqlParameter("@bStop", SqlDbType.Bit,1),
					new SqlParameter("@pyCode", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@userdef1", SqlDbType.VarChar,100),
					new SqlParameter("@userdef2", SqlDbType.VarChar,100),
					new SqlParameter("@userdef3", SqlDbType.VarChar,100),
					new SqlParameter("@userdef4", SqlDbType.VarChar,100),
					new SqlParameter("@userdef5", SqlDbType.VarChar,100),
					new SqlParameter("@userdef6", SqlDbType.VarChar,100),
					new SqlParameter("@PCB", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.GoodsNO;
			parameters[2].Value = model._Name;
			parameters[3].Value = model.ClassID;
			parameters[4].Value = model.Spec;
			parameters[5].Value = model.BrandID;
			parameters[6].Value = model.PicPath;
			parameters[7].Value = model.ForProducts;
			parameters[8].Value = model.Attr;
			parameters[9].Value = model.MainTenancePeriod;
			parameters[10].Value = model.StockID;
			parameters[11].Value = model.ProvID;
			parameters[12].Value = model.bStock;
			parameters[13].Value = model.CostMode;
			parameters[14].Value = model.Valid;
			parameters[15].Value = model.bIncrement;
			parameters[16].Value = model.bSNTrack;
			parameters[17].Value = model.bStop;
			parameters[18].Value = model.pyCode;
			parameters[19].Value = model.Remark;
			parameters[20].Value = model.userdef1;
			parameters[21].Value = model.userdef2;
			parameters[22].Value = model.userdef3;
			parameters[23].Value = model.userdef4;
			parameters[24].Value = model.userdef5;
			parameters[25].Value = model.userdef6;
			parameters[26].Value = model.PCB;

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
		public bool Update(BussModule.Biz.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Goods set ");
			strSql.Append("GoodsNO=@GoodsNO,");
			strSql.Append("_Name=@_Name,");
			strSql.Append("ClassID=@ClassID,");
			strSql.Append("Spec=@Spec,");
			strSql.Append("BrandID=@BrandID,");
			strSql.Append("PicPath=@PicPath,");
			strSql.Append("ForProducts=@ForProducts,");
			strSql.Append("Attr=@Attr,");
			strSql.Append("MainTenancePeriod=@MainTenancePeriod,");
			strSql.Append("StockID=@StockID,");
			strSql.Append("ProvID=@ProvID,");
			strSql.Append("bStock=@bStock,");
			strSql.Append("CostMode=@CostMode,");
			strSql.Append("Valid=@Valid,");
			strSql.Append("bIncrement=@bIncrement,");
			strSql.Append("bSNTrack=@bSNTrack,");
			strSql.Append("bStop=@bStop,");
			strSql.Append("pyCode=@pyCode,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("userdef1=@userdef1,");
			strSql.Append("userdef2=@userdef2,");
			strSql.Append("userdef3=@userdef3,");
			strSql.Append("userdef4=@userdef4,");
			strSql.Append("userdef5=@userdef5,");
			strSql.Append("userdef6=@userdef6,");
			strSql.Append("PCB=@PCB");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@GoodsNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@Spec", SqlDbType.VarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@PicPath", SqlDbType.VarChar,100),
					new SqlParameter("@ForProducts", SqlDbType.VarChar,50),
					new SqlParameter("@Attr", SqlDbType.VarChar,20),
					new SqlParameter("@MainTenancePeriod", SqlDbType.VarChar,10),
					new SqlParameter("@StockID", SqlDbType.Int,4),
					new SqlParameter("@ProvID", SqlDbType.Int,4),
					new SqlParameter("@bStock", SqlDbType.Bit,1),
					new SqlParameter("@CostMode", SqlDbType.Int,4),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@bIncrement", SqlDbType.Bit,1),
					new SqlParameter("@bSNTrack", SqlDbType.Bit,1),
					new SqlParameter("@bStop", SqlDbType.Bit,1),
					new SqlParameter("@pyCode", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@userdef1", SqlDbType.VarChar,100),
					new SqlParameter("@userdef2", SqlDbType.VarChar,100),
					new SqlParameter("@userdef3", SqlDbType.VarChar,100),
					new SqlParameter("@userdef4", SqlDbType.VarChar,100),
					new SqlParameter("@userdef5", SqlDbType.VarChar,100),
					new SqlParameter("@userdef6", SqlDbType.VarChar,100),
					new SqlParameter("@PCB", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.GoodsNO;
			parameters[1].Value = model._Name;
			parameters[2].Value = model.ClassID;
			parameters[3].Value = model.Spec;
			parameters[4].Value = model.BrandID;
			parameters[5].Value = model.PicPath;
			parameters[6].Value = model.ForProducts;
			parameters[7].Value = model.Attr;
			parameters[8].Value = model.MainTenancePeriod;
			parameters[9].Value = model.StockID;
			parameters[10].Value = model.ProvID;
			parameters[11].Value = model.bStock;
			parameters[12].Value = model.CostMode;
			parameters[13].Value = model.Valid;
			parameters[14].Value = model.bIncrement;
			parameters[15].Value = model.bSNTrack;
			parameters[16].Value = model.bStop;
			parameters[17].Value = model.pyCode;
			parameters[18].Value = model.Remark;
			parameters[19].Value = model.userdef1;
			parameters[20].Value = model.userdef2;
			parameters[21].Value = model.userdef3;
			parameters[22].Value = model.userdef4;
			parameters[23].Value = model.userdef5;
			parameters[24].Value = model.userdef6;
			parameters[25].Value = model.PCB;
			parameters[26].Value = model.ID;

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
			strSql.Append("delete from Goods ");
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
			strSql.Append("delete from Goods ");
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
		public BussModule.Biz.Model.Goods GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,GoodsNO,_Name,ClassID,Spec,BrandID,PicPath,ForProducts,Attr,MainTenancePeriod,StockID,ProvID,bStock,CostMode,Valid,bIncrement,bSNTrack,bStop,pyCode,Remark,userdef1,userdef2,userdef3,userdef4,userdef5,userdef6,PCB from Goods ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

			BussModule.Biz.Model.Goods model=new BussModule.Biz.Model.Goods();
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
		public BussModule.Biz.Model.Goods DataRowToModel(DataRow row)
		{
			BussModule.Biz.Model.Goods model=new BussModule.Biz.Model.Goods();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["GoodsNO"]!=null)
				{
					model.GoodsNO=row["GoodsNO"].ToString();
				}
				if(row["_Name"]!=null)
				{
					model._Name=row["_Name"].ToString();
				}
				if(row["ClassID"]!=null && row["ClassID"].ToString()!="")
				{
					model.ClassID=int.Parse(row["ClassID"].ToString());
				}
				if(row["Spec"]!=null)
				{
					model.Spec=row["Spec"].ToString();
				}
				if(row["BrandID"]!=null && row["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(row["BrandID"].ToString());
				}
				if(row["PicPath"]!=null)
				{
					model.PicPath=row["PicPath"].ToString();
				}
				if(row["ForProducts"]!=null)
				{
					model.ForProducts=row["ForProducts"].ToString();
				}
				if(row["Attr"]!=null)
				{
					model.Attr=row["Attr"].ToString();
				}
				if(row["MainTenancePeriod"]!=null)
				{
					model.MainTenancePeriod=row["MainTenancePeriod"].ToString();
				}
				if(row["StockID"]!=null && row["StockID"].ToString()!="")
				{
					model.StockID=int.Parse(row["StockID"].ToString());
				}
				if(row["ProvID"]!=null && row["ProvID"].ToString()!="")
				{
					model.ProvID=int.Parse(row["ProvID"].ToString());
				}
				if(row["bStock"]!=null && row["bStock"].ToString()!="")
				{
					if((row["bStock"].ToString()=="1")||(row["bStock"].ToString().ToLower()=="true"))
					{
						model.bStock=true;
					}
					else
					{
						model.bStock=false;
					}
				}
				if(row["CostMode"]!=null && row["CostMode"].ToString()!="")
				{
					model.CostMode=int.Parse(row["CostMode"].ToString());
				}
				if(row["Valid"]!=null && row["Valid"].ToString()!="")
				{
					model.Valid=int.Parse(row["Valid"].ToString());
				}
				if(row["bIncrement"]!=null && row["bIncrement"].ToString()!="")
				{
					if((row["bIncrement"].ToString()=="1")||(row["bIncrement"].ToString().ToLower()=="true"))
					{
						model.bIncrement=true;
					}
					else
					{
						model.bIncrement=false;
					}
				}
				if(row["bSNTrack"]!=null && row["bSNTrack"].ToString()!="")
				{
					if((row["bSNTrack"].ToString()=="1")||(row["bSNTrack"].ToString().ToLower()=="true"))
					{
						model.bSNTrack=true;
					}
					else
					{
						model.bSNTrack=false;
					}
				}
				if(row["bStop"]!=null && row["bStop"].ToString()!="")
				{
					if((row["bStop"].ToString()=="1")||(row["bStop"].ToString().ToLower()=="true"))
					{
						model.bStop=true;
					}
					else
					{
						model.bStop=false;
					}
				}
				if(row["pyCode"]!=null)
				{
					model.pyCode=row["pyCode"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["userdef1"]!=null)
				{
					model.userdef1=row["userdef1"].ToString();
				}
				if(row["userdef2"]!=null)
				{
					model.userdef2=row["userdef2"].ToString();
				}
				if(row["userdef3"]!=null)
				{
					model.userdef3=row["userdef3"].ToString();
				}
				if(row["userdef4"]!=null)
				{
					model.userdef4=row["userdef4"].ToString();
				}
				if(row["userdef5"]!=null)
				{
					model.userdef5=row["userdef5"].ToString();
				}
				if(row["userdef6"]!=null)
				{
					model.userdef6=row["userdef6"].ToString();
				}
				if(row["PCB"]!=null)
				{
					model.PCB=row["PCB"].ToString();
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
			strSql.Append("select ID,GoodsNO,_Name,ClassID,Spec,BrandID,PicPath,ForProducts,Attr,MainTenancePeriod,StockID,ProvID,bStock,CostMode,Valid,bIncrement,bSNTrack,bStop,pyCode,Remark,userdef1,userdef2,userdef3,userdef4,userdef5,userdef6,PCB ");
			strSql.Append(" FROM Goods ");
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
			strSql.Append(" ID,GoodsNO,_Name,ClassID,Spec,BrandID,PicPath,ForProducts,Attr,MainTenancePeriod,StockID,ProvID,bStock,CostMode,Valid,bIncrement,bSNTrack,bStop,pyCode,Remark,userdef1,userdef2,userdef3,userdef4,userdef5,userdef6,PCB ");
			strSql.Append(" FROM Goods ");
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
			strSql.Append("select count(1) FROM Goods ");
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
			strSql.Append(")AS Row, T.*  from Goods T ");
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
			parameters[0].Value = "Goods";
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

