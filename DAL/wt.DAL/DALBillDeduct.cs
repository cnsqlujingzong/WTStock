using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALBillDeduct
	{
		public int Add(BillDeductInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "BillID";
			text2 += model.BillID.ToString();
			string strCondition = " 1=2 ";
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID.ToString();
			if (model.StaffID > 0)
			{
				text += ",StaffID";
				text2 = text2 + "," + model.StaffID.ToString();
			}
			if (model.Deduct > 0m)
			{
				text += ",Deduct";
				text2 = text2 + "," + model.Deduct.ToString();
			}
			DateTime arg_E0_0 = model.Time_Finish;
			bool flag = 1 == 0;
			text += ",Time_Finish";
			text2 = text2 + ",'" + model.Time_Finish.ToString("yyyy/MM/dd") + "'";
			DateTime arg_120_0 = model.Time_Over;
			flag = (1 == 0);
			text += ",Time_Over";
			text2 = text2 + ",'" + model.Time_Finish.ToString("yyyy/MM/dd") + "'";
			return DALCommon.InsertData("BillDeduct", text, text2, strCondition, "", "ID", out strMsg, out iTbid);
		}

		public void Update(BillDeductInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update BillDeduct set ");
			stringBuilder.Append("StaffID=@StaffID,");
			stringBuilder.Append("Time_Finish=@Time_Finish,");
			stringBuilder.Append("Deduct=@Deduct");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@StaffID", SqlDbType.Int, 4),
				new SqlParameter("@Time_Finish", SqlDbType.DateTime),
				new SqlParameter("@Deduct", SqlDbType.Decimal, 9)
			};
			array[0].Value = model.ID;
			array[1].Value = model.StaffID;
			array[2].Value = model.Time_Finish;
			array[3].Value = model.Deduct;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public BillDeductInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from BillDeduct ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			BillDeductInfo billDeductInfo = new BillDeductInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			billDeductInfo.ID = ID;
			BillDeductInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["BillID"].ToString() != "")
				{
					billDeductInfo.BillID = int.Parse(dataSet.Tables[0].Rows[0]["BillID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					billDeductInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StaffID"].ToString() != "")
				{
					billDeductInfo.StaffID = int.Parse(dataSet.Tables[0].Rows[0]["StaffID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Time_Over"].ToString() != "")
				{
					billDeductInfo.Time_Over = DateTime.Parse(dataSet.Tables[0].Rows[0]["Time_Over"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Time_Finish"].ToString() != "")
				{
					billDeductInfo.Time_Finish = DateTime.Parse(dataSet.Tables[0].Rows[0]["Time_Finish"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Deduct"].ToString() != "")
				{
					billDeductInfo.Deduct = decimal.Parse(dataSet.Tables[0].Rows[0]["Deduct"].ToString());
				}
				result = billDeductInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
