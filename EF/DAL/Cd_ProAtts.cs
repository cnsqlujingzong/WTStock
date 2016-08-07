using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Coding.Stock.DAL
{
	/// <summary>
	/// 数据访问类:Cd_ProAtts
	/// </summary>
	public partial class Cd_ProAtts
	{
		public Cd_ProAtts()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "Cd_ProAtts"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cd_ProAtts");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Coding.Stock.Model.Cd_ProAtts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cd_ProAtts(");
			strSql.Append("ProTypeID,A100_1,A100_2,A100_3,A100_4,A100_5,A100_6,A100_7,A100_8,A100_9,A100_10,A100_11,A100_12,A100_13,A100_14,A100_15,A100_16,A100_17,A100_18,A100_19,A100_20,A100_21,A100_22,A100_23,A100_24,A100_25,A100_26,A100_27,A100_28,A100_29,A100_30,A100_31,A100_32,A100_33,A100_34,A100_35,A100_36,A100_37,A100_38,A100_39,A100_40,A100_41,A100_42,A100_43,A100_44,A100_45,A100_46,A100_47,A100_48,A100_49,A100_50)");
			strSql.Append(" values (");
			strSql.Append("@ProTypeID,@A100_1,@A100_2,@A100_3,@A100_4,@A100_5,@A100_6,@A100_7,@A100_8,@A100_9,@A100_10,@A100_11,@A100_12,@A100_13,@A100_14,@A100_15,@A100_16,@A100_17,@A100_18,@A100_19,@A100_20,@A100_21,@A100_22,@A100_23,@A100_24,@A100_25,@A100_26,@A100_27,@A100_28,@A100_29,@A100_30,@A100_31,@A100_32,@A100_33,@A100_34,@A100_35,@A100_36,@A100_37,@A100_38,@A100_39,@A100_40,@A100_41,@A100_42,@A100_43,@A100_44,@A100_45,@A100_46,@A100_47,@A100_48,@A100_49,@A100_50)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@A100_1", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_2", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_3", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_4", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_5", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_6", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_7", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_8", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_9", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_10", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_11", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_12", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_13", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_14", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_15", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_16", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_17", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_18", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_19", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_20", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_21", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_22", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_23", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_24", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_25", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_26", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_27", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_28", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_29", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_30", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_31", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_32", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_33", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_34", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_35", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_36", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_37", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_38", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_39", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_40", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_41", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_42", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_43", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_44", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_45", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_46", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_47", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_48", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_49", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_50", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.ProTypeID;
			parameters[1].Value = model.A100_1;
			parameters[2].Value = model.A100_2;
			parameters[3].Value = model.A100_3;
			parameters[4].Value = model.A100_4;
			parameters[5].Value = model.A100_5;
			parameters[6].Value = model.A100_6;
			parameters[7].Value = model.A100_7;
			parameters[8].Value = model.A100_8;
			parameters[9].Value = model.A100_9;
			parameters[10].Value = model.A100_10;
			parameters[11].Value = model.A100_11;
			parameters[12].Value = model.A100_12;
			parameters[13].Value = model.A100_13;
			parameters[14].Value = model.A100_14;
			parameters[15].Value = model.A100_15;
			parameters[16].Value = model.A100_16;
			parameters[17].Value = model.A100_17;
			parameters[18].Value = model.A100_18;
			parameters[19].Value = model.A100_19;
			parameters[20].Value = model.A100_20;
			parameters[21].Value = model.A100_21;
			parameters[22].Value = model.A100_22;
			parameters[23].Value = model.A100_23;
			parameters[24].Value = model.A100_24;
			parameters[25].Value = model.A100_25;
			parameters[26].Value = model.A100_26;
			parameters[27].Value = model.A100_27;
			parameters[28].Value = model.A100_28;
			parameters[29].Value = model.A100_29;
			parameters[30].Value = model.A100_30;
			parameters[31].Value = model.A100_31;
			parameters[32].Value = model.A100_32;
			parameters[33].Value = model.A100_33;
			parameters[34].Value = model.A100_34;
			parameters[35].Value = model.A100_35;
			parameters[36].Value = model.A100_36;
			parameters[37].Value = model.A100_37;
			parameters[38].Value = model.A100_38;
			parameters[39].Value = model.A100_39;
			parameters[40].Value = model.A100_40;
			parameters[41].Value = model.A100_41;
			parameters[42].Value = model.A100_42;
			parameters[43].Value = model.A100_43;
			parameters[44].Value = model.A100_44;
			parameters[45].Value = model.A100_45;
			parameters[46].Value = model.A100_46;
			parameters[47].Value = model.A100_47;
			parameters[48].Value = model.A100_48;
			parameters[49].Value = model.A100_49;
			parameters[50].Value = model.A100_50;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
        public int runSQL(string sql)
        {
            object obj = DbHelperSQL.GetSingle(sql);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Coding.Stock.Model.Cd_ProAtts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cd_ProAtts set ");
			strSql.Append("ProTypeID=@ProTypeID,");
			strSql.Append("A100_1=@A100_1,");
			strSql.Append("A100_2=@A100_2,");
			strSql.Append("A100_3=@A100_3,");
			strSql.Append("A100_4=@A100_4,");
			strSql.Append("A100_5=@A100_5,");
			strSql.Append("A100_6=@A100_6,");
			strSql.Append("A100_7=@A100_7,");
			strSql.Append("A100_8=@A100_8,");
			strSql.Append("A100_9=@A100_9,");
			strSql.Append("A100_10=@A100_10,");
			strSql.Append("A100_11=@A100_11,");
			strSql.Append("A100_12=@A100_12,");
			strSql.Append("A100_13=@A100_13,");
			strSql.Append("A100_14=@A100_14,");
			strSql.Append("A100_15=@A100_15,");
			strSql.Append("A100_16=@A100_16,");
			strSql.Append("A100_17=@A100_17,");
			strSql.Append("A100_18=@A100_18,");
			strSql.Append("A100_19=@A100_19,");
			strSql.Append("A100_20=@A100_20,");
			strSql.Append("A100_21=@A100_21,");
			strSql.Append("A100_22=@A100_22,");
			strSql.Append("A100_23=@A100_23,");
			strSql.Append("A100_24=@A100_24,");
			strSql.Append("A100_25=@A100_25,");
			strSql.Append("A100_26=@A100_26,");
			strSql.Append("A100_27=@A100_27,");
			strSql.Append("A100_28=@A100_28,");
			strSql.Append("A100_29=@A100_29,");
			strSql.Append("A100_30=@A100_30,");
			strSql.Append("A100_31=@A100_31,");
			strSql.Append("A100_32=@A100_32,");
			strSql.Append("A100_33=@A100_33,");
			strSql.Append("A100_34=@A100_34,");
			strSql.Append("A100_35=@A100_35,");
			strSql.Append("A100_36=@A100_36,");
			strSql.Append("A100_37=@A100_37,");
			strSql.Append("A100_38=@A100_38,");
			strSql.Append("A100_39=@A100_39,");
			strSql.Append("A100_40=@A100_40,");
			strSql.Append("A100_41=@A100_41,");
			strSql.Append("A100_42=@A100_42,");
			strSql.Append("A100_43=@A100_43,");
			strSql.Append("A100_44=@A100_44,");
			strSql.Append("A100_45=@A100_45,");
			strSql.Append("A100_46=@A100_46,");
			strSql.Append("A100_47=@A100_47,");
			strSql.Append("A100_48=@A100_48,");
			strSql.Append("A100_49=@A100_49,");
			strSql.Append("A100_50=@A100_50");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@ProTypeID", SqlDbType.Int,4),
					new SqlParameter("@A100_1", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_2", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_3", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_4", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_5", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_6", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_7", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_8", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_9", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_10", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_11", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_12", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_13", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_14", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_15", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_16", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_17", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_18", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_19", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_20", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_21", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_22", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_23", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_24", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_25", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_26", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_27", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_28", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_29", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_30", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_31", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_32", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_33", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_34", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_35", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_36", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_37", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_38", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_39", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_40", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_41", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_42", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_43", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_44", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_45", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_46", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_47", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_48", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_49", SqlDbType.NVarChar,100),
					new SqlParameter("@A100_50", SqlDbType.NVarChar,100),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.ProTypeID;
			parameters[1].Value = model.A100_1;
			parameters[2].Value = model.A100_2;
			parameters[3].Value = model.A100_3;
			parameters[4].Value = model.A100_4;
			parameters[5].Value = model.A100_5;
			parameters[6].Value = model.A100_6;
			parameters[7].Value = model.A100_7;
			parameters[8].Value = model.A100_8;
			parameters[9].Value = model.A100_9;
			parameters[10].Value = model.A100_10;
			parameters[11].Value = model.A100_11;
			parameters[12].Value = model.A100_12;
			parameters[13].Value = model.A100_13;
			parameters[14].Value = model.A100_14;
			parameters[15].Value = model.A100_15;
			parameters[16].Value = model.A100_16;
			parameters[17].Value = model.A100_17;
			parameters[18].Value = model.A100_18;
			parameters[19].Value = model.A100_19;
			parameters[20].Value = model.A100_20;
			parameters[21].Value = model.A100_21;
			parameters[22].Value = model.A100_22;
			parameters[23].Value = model.A100_23;
			parameters[24].Value = model.A100_24;
			parameters[25].Value = model.A100_25;
			parameters[26].Value = model.A100_26;
			parameters[27].Value = model.A100_27;
			parameters[28].Value = model.A100_28;
			parameters[29].Value = model.A100_29;
			parameters[30].Value = model.A100_30;
			parameters[31].Value = model.A100_31;
			parameters[32].Value = model.A100_32;
			parameters[33].Value = model.A100_33;
			parameters[34].Value = model.A100_34;
			parameters[35].Value = model.A100_35;
			parameters[36].Value = model.A100_36;
			parameters[37].Value = model.A100_37;
			parameters[38].Value = model.A100_38;
			parameters[39].Value = model.A100_39;
			parameters[40].Value = model.A100_40;
			parameters[41].Value = model.A100_41;
			parameters[42].Value = model.A100_42;
			parameters[43].Value = model.A100_43;
			parameters[44].Value = model.A100_44;
			parameters[45].Value = model.A100_45;
			parameters[46].Value = model.A100_46;
			parameters[47].Value = model.A100_47;
			parameters[48].Value = model.A100_48;
			parameters[49].Value = model.A100_49;
			parameters[50].Value = model.A100_50;
			parameters[51].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cd_ProAtts ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
        public bool Delete(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cd_ProAtts ");
            strSql.Append(" where "+strWhere); 
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cd_ProAtts ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
        public bool runSQL2(string sql)
        {
            int rows = DbHelperSQL.ExecuteSql(sql);
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
		public Coding.Stock.Model.Cd_ProAtts GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ProTypeID,A100_1,A100_2,A100_3,A100_4,A100_5,A100_6,A100_7,A100_8,A100_9,A100_10,A100_11,A100_12,A100_13,A100_14,A100_15,A100_16,A100_17,A100_18,A100_19,A100_20,A100_21,A100_22,A100_23,A100_24,A100_25,A100_26,A100_27,A100_28,A100_29,A100_30,A100_31,A100_32,A100_33,A100_34,A100_35,A100_36,A100_37,A100_38,A100_39,A100_40,A100_41,A100_42,A100_43,A100_44,A100_45,A100_46,A100_47,A100_48,A100_49,A100_50 from Cd_ProAtts ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Coding.Stock.Model.Cd_ProAtts model=new Coding.Stock.Model.Cd_ProAtts();
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

        public Coding.Stock.Model.Cd_ProAtts GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ProTypeID,A100_1,A100_2,A100_3,A100_4,A100_5,A100_6,A100_7,A100_8,A100_9,A100_10,A100_11,A100_12,A100_13,A100_14,A100_15,A100_16,A100_17,A100_18,A100_19,A100_20,A100_21,A100_22,A100_23,A100_24,A100_25,A100_26,A100_27,A100_28,A100_29,A100_30,A100_31,A100_32,A100_33,A100_34,A100_35,A100_36,A100_37,A100_38,A100_39,A100_40,A100_41,A100_42,A100_43,A100_44,A100_45,A100_46,A100_47,A100_48,A100_49,A100_50 from Cd_ProAtts ");
            strSql.Append(" where "+strWhere);
        
            Coding.Stock.Model.Cd_ProAtts model = new Coding.Stock.Model.Cd_ProAtts();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
		public Coding.Stock.Model.Cd_ProAtts DataRowToModel(DataRow row)
		{
			Coding.Stock.Model.Cd_ProAtts model=new Coding.Stock.Model.Cd_ProAtts();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["ProTypeID"]!=null && row["ProTypeID"].ToString()!="")
				{
					model.ProTypeID=int.Parse(row["ProTypeID"].ToString());
				}
				if(row["A100_1"]!=null)
				{
					model.A100_1=row["A100_1"].ToString();
				}
				if(row["A100_2"]!=null)
				{
					model.A100_2=row["A100_2"].ToString();
				}
				if(row["A100_3"]!=null)
				{
					model.A100_3=row["A100_3"].ToString();
				}
				if(row["A100_4"]!=null)
				{
					model.A100_4=row["A100_4"].ToString();
				}
				if(row["A100_5"]!=null)
				{
					model.A100_5=row["A100_5"].ToString();
				}
				if(row["A100_6"]!=null)
				{
					model.A100_6=row["A100_6"].ToString();
				}
				if(row["A100_7"]!=null)
				{
					model.A100_7=row["A100_7"].ToString();
				}
				if(row["A100_8"]!=null)
				{
					model.A100_8=row["A100_8"].ToString();
				}
				if(row["A100_9"]!=null)
				{
					model.A100_9=row["A100_9"].ToString();
				}
				if(row["A100_10"]!=null)
				{
					model.A100_10=row["A100_10"].ToString();
				}
				if(row["A100_11"]!=null)
				{
					model.A100_11=row["A100_11"].ToString();
				}
				if(row["A100_12"]!=null)
				{
					model.A100_12=row["A100_12"].ToString();
				}
				if(row["A100_13"]!=null)
				{
					model.A100_13=row["A100_13"].ToString();
				}
				if(row["A100_14"]!=null)
				{
					model.A100_14=row["A100_14"].ToString();
				}
				if(row["A100_15"]!=null)
				{
					model.A100_15=row["A100_15"].ToString();
				}
				if(row["A100_16"]!=null)
				{
					model.A100_16=row["A100_16"].ToString();
				}
				if(row["A100_17"]!=null)
				{
					model.A100_17=row["A100_17"].ToString();
				}
				if(row["A100_18"]!=null)
				{
					model.A100_18=row["A100_18"].ToString();
				}
				if(row["A100_19"]!=null)
				{
					model.A100_19=row["A100_19"].ToString();
				}
				if(row["A100_20"]!=null)
				{
					model.A100_20=row["A100_20"].ToString();
				}
				if(row["A100_21"]!=null)
				{
					model.A100_21=row["A100_21"].ToString();
				}
				if(row["A100_22"]!=null)
				{
					model.A100_22=row["A100_22"].ToString();
				}
				if(row["A100_23"]!=null)
				{
					model.A100_23=row["A100_23"].ToString();
				}
				if(row["A100_24"]!=null)
				{
					model.A100_24=row["A100_24"].ToString();
				}
				if(row["A100_25"]!=null)
				{
					model.A100_25=row["A100_25"].ToString();
				}
				if(row["A100_26"]!=null)
				{
					model.A100_26=row["A100_26"].ToString();
				}
				if(row["A100_27"]!=null)
				{
					model.A100_27=row["A100_27"].ToString();
				}
				if(row["A100_28"]!=null)
				{
					model.A100_28=row["A100_28"].ToString();
				}
				if(row["A100_29"]!=null)
				{
					model.A100_29=row["A100_29"].ToString();
				}
				if(row["A100_30"]!=null)
				{
					model.A100_30=row["A100_30"].ToString();
				}
				if(row["A100_31"]!=null)
				{
					model.A100_31=row["A100_31"].ToString();
				}
				if(row["A100_32"]!=null)
				{
					model.A100_32=row["A100_32"].ToString();
				}
				if(row["A100_33"]!=null)
				{
					model.A100_33=row["A100_33"].ToString();
				}
				if(row["A100_34"]!=null)
				{
					model.A100_34=row["A100_34"].ToString();
				}
				if(row["A100_35"]!=null)
				{
					model.A100_35=row["A100_35"].ToString();
				}
				if(row["A100_36"]!=null)
				{
					model.A100_36=row["A100_36"].ToString();
				}
				if(row["A100_37"]!=null)
				{
					model.A100_37=row["A100_37"].ToString();
				}
				if(row["A100_38"]!=null)
				{
					model.A100_38=row["A100_38"].ToString();
				}
				if(row["A100_39"]!=null)
				{
					model.A100_39=row["A100_39"].ToString();
				}
				if(row["A100_40"]!=null)
				{
					model.A100_40=row["A100_40"].ToString();
				}
				if(row["A100_41"]!=null)
				{
					model.A100_41=row["A100_41"].ToString();
				}
				if(row["A100_42"]!=null)
				{
					model.A100_42=row["A100_42"].ToString();
				}
				if(row["A100_43"]!=null)
				{
					model.A100_43=row["A100_43"].ToString();
				}
				if(row["A100_44"]!=null)
				{
					model.A100_44=row["A100_44"].ToString();
				}
				if(row["A100_45"]!=null)
				{
					model.A100_45=row["A100_45"].ToString();
				}
				if(row["A100_46"]!=null)
				{
					model.A100_46=row["A100_46"].ToString();
				}
				if(row["A100_47"]!=null)
				{
					model.A100_47=row["A100_47"].ToString();
				}
				if(row["A100_48"]!=null)
				{
					model.A100_48=row["A100_48"].ToString();
				}
				if(row["A100_49"]!=null)
				{
					model.A100_49=row["A100_49"].ToString();
				}
				if(row["A100_50"]!=null)
				{
					model.A100_50=row["A100_50"].ToString();
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
			strSql.Append("select Id,ProTypeID,A100_1,A100_2,A100_3,A100_4,A100_5,A100_6,A100_7,A100_8,A100_9,A100_10,A100_11,A100_12,A100_13,A100_14,A100_15,A100_16,A100_17,A100_18,A100_19,A100_20,A100_21,A100_22,A100_23,A100_24,A100_25,A100_26,A100_27,A100_28,A100_29,A100_30,A100_31,A100_32,A100_33,A100_34,A100_35,A100_36,A100_37,A100_38,A100_39,A100_40,A100_41,A100_42,A100_43,A100_44,A100_45,A100_46,A100_47,A100_48,A100_49,A100_50 ");
			strSql.Append(" FROM Cd_ProAtts ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataSet GetListBysql(string sql)
        {         
            return DbHelperSQL.Query(sql);
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
			strSql.Append(" Id,ProTypeID,A100_1,A100_2,A100_3,A100_4,A100_5,A100_6,A100_7,A100_8,A100_9,A100_10,A100_11,A100_12,A100_13,A100_14,A100_15,A100_16,A100_17,A100_18,A100_19,A100_20,A100_21,A100_22,A100_23,A100_24,A100_25,A100_26,A100_27,A100_28,A100_29,A100_30,A100_31,A100_32,A100_33,A100_34,A100_35,A100_36,A100_37,A100_38,A100_39,A100_40,A100_41,A100_42,A100_43,A100_44,A100_45,A100_46,A100_47,A100_48,A100_49,A100_50 ");
			strSql.Append(" FROM Cd_ProAtts ");
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
			strSql.Append("select count(1) FROM Cd_ProAtts ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from Cd_ProAtts T ");
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
			parameters[0].Value = "Cd_ProAtts";
			parameters[1].Value = "Id";
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

