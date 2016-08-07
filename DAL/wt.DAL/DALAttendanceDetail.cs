using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALAttendanceDetail
	{
		public int Add(AttendanceDetailInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Date != string.Empty)
			{
				text += "_Date";
				text2 = text2 + "'" + model._Date + "'";
			}
			if (model.iOperator > 0)
			{
				text += ",iOperator";
				text2 = text2 + "," + model.iOperator.ToString();
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("AttendanceDetail", text, text2, " 1=2 ", "考勤明细", "ID", out strMsg, out iTbid);
		}

		public int AttendanceDe(int iDept, string strType, int iOperator, string strPwd, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@Type", SqlDbType.VarChar, 10),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strPwd", SqlDbType.VarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iDept;
			array[1].Value = strType;
			array[2].Value = iOperator;
			array[3].Value = strPwd;
			array[4].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("kq_qd", array);
			strMsg = Convert.ToString(array[4].Value);
			return result;
		}

		public int InputAttendanceDe(int iDept, string strdate, string strno, string strname, string strstartdate, string strenddate, decimal dlaftmoney, decimal daftermoney, string strtype, decimal dattmoney, string strchkdate, string strchkname, string strremark, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@strdate", SqlDbType.VarChar, 50),
				new SqlParameter("@strno", SqlDbType.VarChar, 50),
				new SqlParameter("@strname", SqlDbType.VarChar, 50),
				new SqlParameter("@strstartdate", SqlDbType.VarChar, 50),
				new SqlParameter("@strenddate", SqlDbType.VarChar, 50),
				new SqlParameter("@dlaftmoney", SqlDbType.Decimal),
				new SqlParameter("@daftermoney", SqlDbType.Decimal),
				new SqlParameter("@strtype", SqlDbType.VarChar, 50),
				new SqlParameter("@dattmoney", SqlDbType.Decimal),
				new SqlParameter("@strchkdate", SqlDbType.VarChar, 50),
				new SqlParameter("@strchkname", SqlDbType.VarChar, 50),
				new SqlParameter("@strremark", SqlDbType.VarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iDept;
			array[1].Value = strdate;
			array[2].Value = strno;
			array[3].Value = strname;
			array[4].Value = strstartdate;
			array[5].Value = strenddate;
			array[6].Value = dlaftmoney;
			array[7].Value = daftermoney;
			array[8].Value = strtype;
			array[9].Value = dattmoney;
			array[10].Value = strchkdate;
			array[11].Value = strchkname;
			array[12].Value = strremark;
			array[13].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("kq_input", array);
			strMsg = Convert.ToString(array[13].Value);
			return result;
		}

		public void Update(AttendanceDetailInfo model, string ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update AttendanceDetail set ");
			stringBuilder.Append("Properties=@Properties,");
			stringBuilder.Append("AbsencedMoney=@AbsencedMoney,");
			stringBuilder.Append("AbsenceType=@AbsenceType,");
			stringBuilder.Append("ChkOperatorID=@ChkOperatorID,");
			stringBuilder.Append("ChkDate=@ChkDate,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID in(" + ID + ")");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Properties", SqlDbType.Int, 4),
				new SqlParameter("@AbsencedMoney", SqlDbType.Decimal, 9),
				new SqlParameter("@AbsenceType", SqlDbType.VarChar, 50),
				new SqlParameter("@ChkOperatorID", SqlDbType.Int, 4),
				new SqlParameter("@ChkDate", SqlDbType.DateTime),
				new SqlParameter("@Remark", SqlDbType.VarChar, 100)
			};
			array[0].Value = model.Properties;
			array[1].Value = model.AbsencedMoney;
			array[2].Value = model.AbsenceType;
			array[3].Value = model.ChkOperatorID;
			array[4].Value = model.ChkDate;
			array[5].Value = model.Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
