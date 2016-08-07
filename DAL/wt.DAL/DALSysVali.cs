using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSysVali
	{
		public bool Exists(string S_Item)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from SysVali");
			stringBuilder.Append(" where S_Item= @S_Item");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@S_Item", SqlDbType.VarChar, 50)
			};
			array[0].Value = S_Item;
			return DbHelperSQL.Exists(stringBuilder.ToString(), array);
		}

		public int Add(SysValiInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into SysVali(");
			stringBuilder.Append("S_Item,S_Value)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@S_Item,@S_Value)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@S_Item", SqlDbType.VarChar, 50),
				new SqlParameter("@S_Value", SqlDbType.VarChar, 200)
			};
			array[0].Value = model.S_Item;
			array[1].Value = model.S_Value;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			int result;
			if (single == null)
			{
				result = 1;
			}
			else
			{
				result = Convert.ToInt32(single);
			}
			return result;
		}

		public void Update(SysValiInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SysVali set ");
			stringBuilder.Append("S_Item=@S_Item,");
			stringBuilder.Append("S_Value=@S_Value");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4),
				new SqlParameter("@S_Item", SqlDbType.VarChar, 50),
				new SqlParameter("@S_Value", SqlDbType.VarChar, 200)
			};
			array[0].Value = model.RecID;
			array[1].Value = model.S_Item;
			array[2].Value = model.S_Value;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Update(string S_Item, string S_Value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (S_Item == "ITEM6")
			{
				stringBuilder.Append("if (select count(0) from SysVali where S_Item='ITEM6')=0 insert into SysVali(S_Item,S_Value)values('ITEM6','SXHSRTSRXSRHSTRSRHSTFSTISTFSVSSVVSVSSVXSVHSFTSVJSVJSFISGXSGTSGFSGVSGXSGVSGI') ");
			}
			stringBuilder.Append("update SysVali set ");
			stringBuilder.Append("S_Value=@S_Value ");
			stringBuilder.Append(" where S_Item=@S_Item ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@S_Item", SqlDbType.VarChar, 50),
				new SqlParameter("@S_Value", SqlDbType.VarChar, 200)
			};
			array[0].Value = S_Item;
			array[1].Value = S_Value;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Delete(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete SysVali ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public SysValiInfo GetModel(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from SysVali ");
			stringBuilder.Append(" where RecID=@RecID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RecID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			SysValiInfo sysValiInfo = new SysValiInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			sysValiInfo.RecID = RecID;
			SysValiInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				sysValiInfo.S_Item = dataSet.Tables[0].Rows[0]["S_Item"].ToString();
				sysValiInfo.S_Value = dataSet.Tables[0].Rows[0]["S_Value"].ToString();
				result = sysValiInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public DataSet GetList(string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [RecID],[S_Item],[S_Value] ");
			stringBuilder.Append(" FROM SysVali ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public string GetValue(string S_Item)
		{
			string text = "'SIFSXF-SIJSAT-SASBSF-BSJSFX','SXTSXH-SIISII-SARBSF-BSABSH','SITSXF-SARSXI-SATSAR-SAXBSA'";
			StringBuilder stringBuilder = new StringBuilder();
			if (S_Item == "ITEM6")
			{
				stringBuilder.Append("if (select count(0) from SysVali where S_Item='ITEM6')=0 insert into SysVali(S_Item,S_Value)values('ITEM6','SXHSRTSRXSRHSTRSRHSTFSTISTFSVSSVVSVSSVXSVHSFTSVJSVJSFISGXSGTSGFSGVSGXSGVSGI') ");
			}
			stringBuilder.Append("select S_Value from SysVali ");
			stringBuilder.Append(" where S_Item=@S_Item ");
			if (S_Item == "ITEM6")
			{
				stringBuilder.Append("select S_Value from SysVali where S_Item='ITEM2'");
			}
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@S_Item", SqlDbType.VarChar, 50)
			};
			array[0].Value = S_Item;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			string result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (S_Item == "ITEM6")
				{
					string str = dataSet.Tables[1].Rows[0]["S_Value"].ToString();
					if (text.Contains("'" + str + "'"))
					{
						stringBuilder.Remove(0, stringBuilder.Length);
						stringBuilder.Append("update SysVali set S_Value='SXHSRTSRXSRHSTRSRHSTFSTISTFSVSSVVSVSSVXSVHSFTSVJSVJSFISGXSGTSGFSGVSGXSGVSGI' where S_Item='ITEM6' ");
						stringBuilder.Append("update SysVali set S_Value='SRTSRTSIHSJRSIHSIJSIGSJTSIISTISVXSVGSVRSVHSFTSVISFVSFGSFJSGTSFISGTSGXSHSSGF' where S_Item='ITEM3' ");
						stringBuilder.Append("update SysVali set S_Value='" + DateTime.Today.ToString("yyyy-MM-dd") + "' where S_Item='ITEM5' ");
						DbHelperSQL.Query(stringBuilder.ToString());
						result = "SXHSRTSRXSRHSTRSRHSTFSTISTFSVSSVVSVSSVXSVHSFTSVJSVJSFISGXSGTSGFSGVSGXSGVSGI";
						return result;
					}
				}
				result = dataSet.Tables[0].Rows[0]["S_Value"].ToString();
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public void StartParm(string Item1, string Item3)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ITEM1", SqlDbType.VarChar, 200),
				new SqlParameter("@ITEM3", SqlDbType.VarChar, 200)
			};
			array[0].Value = Item1;
			array[1].Value = Item3;
			DbHelperSQL.RunProcedure("xt_startparm", array);
		}
	}
}
