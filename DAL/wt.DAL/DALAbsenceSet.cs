using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALAbsenceSet
	{
		public int Add(AbsenceSetInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "Type";
			text2 = text2 + "'" + model.Type + "'";
			string strCondition = " 1=2 ";
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID.ToString();
			if (model.dMoney > 0m)
			{
				text += ",dMoney";
				text2 = text2 + "," + model.dMoney.ToString();
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("AbsenceSet", text, text2, strCondition, model.Type, "ID", out strMsg, out iTbid);
		}

		public int Update(AbsenceSetInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "Type='" + model.Type + "'";
			text = text + ",dMoney=" + model.dMoney.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("AbsenceSet", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public AbsenceSetInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 [ID],[DeptID],[Type],[dMoney],[Remark] from AbsenceSet ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			AbsenceSetInfo absenceSetInfo = new AbsenceSetInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			absenceSetInfo.ID = ID;
			AbsenceSetInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					absenceSetInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				absenceSetInfo.Type = dataSet.Tables[0].Rows[0]["Type"].ToString();
				if (dataSet.Tables[0].Rows[0]["dMoney"].ToString() != "")
				{
					absenceSetInfo.dMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["dMoney"].ToString());
				}
				absenceSetInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = absenceSetInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
