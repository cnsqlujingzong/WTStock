using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServiceLevel
	{
		public int Add(ServiceLevelInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			string strCondition = " _Name='" + model._Name + "'";
			if (model.RepairTime > 0)
			{
				text += ",RepairTime";
				text2 = text2 + "," + model.RepairTime;
			}
			if (model.ResponseTime > 0)
			{
				text += ",ResponseTime";
				text2 = text2 + "," + model.ResponseTime;
			}
			if (model.Number > 0)
			{
				text += ",Number";
				text2 = text2 + "," + model.Number;
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("ServiceLevel", text, text2, strCondition, "服务级别", "ID", out strMsg, out iTbid);
		}

		public int Update(ServiceLevelInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",RepairTime=" + model.RepairTime;
			text = text + ",ResponseTime=" + model.ResponseTime;
			text = text + ",Number=" + model.Number;
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("ServiceLevel", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public ServiceLevelInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 [ID],[_Name],[ResponseTime],[RepairTime],[Remark],Number from ServiceLevel ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ServiceLevelInfo serviceLevelInfo = new ServiceLevelInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			serviceLevelInfo.ID = ID;
			ServiceLevelInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				serviceLevelInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["ResponseTime"].ToString() != "")
				{
					serviceLevelInfo.ResponseTime = int.Parse(dataSet.Tables[0].Rows[0]["ResponseTime"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["RepairTime"].ToString() != "")
				{
					serviceLevelInfo.RepairTime = int.Parse(dataSet.Tables[0].Rows[0]["RepairTime"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Number"].ToString() != "")
				{
					serviceLevelInfo.Number = int.Parse(dataSet.Tables[0].Rows[0]["Number"].ToString());
				}
				serviceLevelInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = serviceLevelInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
