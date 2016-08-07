using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALLateSet
	{
		public int Add(LateSetInfo model, out string strMsg, out int iTbid)
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
			if (model.StartMin > 0)
			{
				text += ",StartMin";
				text2 = text2 + "," + model.StartMin;
			}
			if (model.EndMin > 0)
			{
				text += ",EndMin";
				text2 = text2 + "," + model.EndMin;
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("LateSet", text, text2, strCondition, model.Type, "ID", out strMsg, out iTbid);
		}

		public int Update(LateSetInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "Type='" + model.Type + "'";
			text = text + ",dMoney=" + model.dMoney.ToString();
			text = text + ",StartMin=" + model.StartMin;
			text = text + ",EndMin=" + model.EndMin;
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("LateSet", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public LateSetInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 [ID],[DeptID],[Type],[dMoney],[StartMin],[EndMin],[Remark] from LateSet ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			LateSetInfo lateSetInfo = new LateSetInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			lateSetInfo.ID = ID;
			LateSetInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					lateSetInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				lateSetInfo.Type = dataSet.Tables[0].Rows[0]["Type"].ToString();
				if (dataSet.Tables[0].Rows[0]["dMoney"].ToString() != "")
				{
					lateSetInfo.dMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["dMoney"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StartMin"].ToString() != "")
				{
					lateSetInfo.StartMin = int.Parse(dataSet.Tables[0].Rows[0]["StartMin"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["EndMin"].ToString() != "")
				{
					lateSetInfo.EndMin = int.Parse(dataSet.Tables[0].Rows[0]["EndMin"].ToString());
				}
				lateSetInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = lateSetInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
