using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALAttendanceTime
	{
		public int Add(AttendanceTimeInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "Week";
			text2 = text2 + "'" + model.Week + "'";
			string text3 = " Week='" + model.Week + "' ";
			text3 = text3 + " and DeptID=" + model.DeptID.ToString();
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID.ToString();
			text += ",WorkTime";
			text2 = text2 + ",'" + model.WorkTime + "'";
			text += ",AfterWorkTime";
			text2 = text2 + ",'" + model.AfterWorkTime + "'";
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("AttendanceTime", text, text2, text3, model.Week, "ID", out strMsg, out iTbid);
		}

		public int Update(AttendanceTimeInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "Week='" + model.Week + "'";
			text = text + ",WorkTime='" + model.WorkTime + "'";
			text = text + ",AfterWorkTime='" + model.AfterWorkTime + "'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("AttendanceTime", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public AttendanceTimeInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,Week,CONVERT(varchar(100),WorkTime,8) as WorkTime,CONVERT(varchar(100),AfterWorkTime,8) as AfterWorkTime,Remark from AttendanceTime ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			AttendanceTimeInfo attendanceTimeInfo = new AttendanceTimeInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			AttendanceTimeInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					attendanceTimeInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					attendanceTimeInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				attendanceTimeInfo.Week = dataSet.Tables[0].Rows[0]["Week"].ToString();
				attendanceTimeInfo.WorkTime = dataSet.Tables[0].Rows[0]["WorkTime"].ToString();
				attendanceTimeInfo.AfterWorkTime = dataSet.Tables[0].Rows[0]["AfterWorkTime"].ToString();
				attendanceTimeInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = attendanceTimeInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
