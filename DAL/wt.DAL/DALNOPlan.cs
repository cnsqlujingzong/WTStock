using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALNOPlan
	{
		public void Update(NOPlanInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update NOPlan set ");
			stringBuilder.Append("Code=@Code,");
			stringBuilder.Append("Style=@Style,");
			stringBuilder.Append("Tally=@Tally,");
			stringBuilder.Append("BeginNO=@BeginNO,");
			stringBuilder.Append("Model=@Model");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@Code", SqlDbType.VarChar, 40),
				new SqlParameter("@Style", SqlDbType.VarChar, 10),
				new SqlParameter("@Tally", SqlDbType.VarChar, 2),
				new SqlParameter("@BeginNO", SqlDbType.VarChar, 50),
				new SqlParameter("@Model", SqlDbType.VarChar, 100)
			};
			array[0].Value = model.ID;
			array[1].Value = model.Code;
			array[2].Value = model.Style;
			array[3].Value = model.Tally;
			array[4].Value = model.BeginNO;
			array[5].Value = model.Model;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public NOPlanInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,Type,Code,Style,Tally,BeginNO,Model from NOPlan ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			NOPlanInfo nOPlanInfo = new NOPlanInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			NOPlanInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					nOPlanInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				nOPlanInfo.Type = dataSet.Tables[0].Rows[0]["Type"].ToString();
				nOPlanInfo.Code = dataSet.Tables[0].Rows[0]["Code"].ToString();
				nOPlanInfo.Style = dataSet.Tables[0].Rows[0]["Style"].ToString();
				nOPlanInfo.Tally = dataSet.Tables[0].Rows[0]["Tally"].ToString();
				nOPlanInfo.BeginNO = dataSet.Tables[0].Rows[0]["BeginNO"].ToString();
				nOPlanInfo.Model = dataSet.Tables[0].Rows[0]["Model"].ToString();
				result = nOPlanInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
