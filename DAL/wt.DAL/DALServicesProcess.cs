using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServicesProcess
	{
		public int Add(ServicesProcessInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "BillID";
			text2 += model.BillID.ToString();
			text += ",_Date";
			text2 += ",getdate()";
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.DoStatus > 0)
			{
				text += ",DoStatus";
				text2 = text2 + "," + model.DoStatus.ToString();
			}
			if (model.iOperator > 0)
			{
				text += ",iOperator";
				text2 = text2 + "," + model.iOperator.ToString();
			}
			if (model.DoStyle != "")
			{
				text += ",DoStyle";
				text2 = text2 + ",'" + model.DoStyle + "'";
			}
			if (model.Reason != "")
			{
				text += ",Reason";
				text2 = text2 + ",'" + model.Reason + "'";
			}
			if (model.TakeSteps != "")
			{
				text += ",TakeSteps";
				text2 = text2 + ",'" + model.TakeSteps + "'";
			}
			return DALCommon.InsertData("ServicesProcess", text, text2, "1=2", "1", "ID", out strMsg, out iTbid);
		}

		public ServicesProcessInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from ServicesProcess ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ServicesProcessInfo servicesProcessInfo = new ServicesProcessInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			servicesProcessInfo.ID = ID;
			ServicesProcessInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["BillID"].ToString() != "")
				{
					servicesProcessInfo.BillID = int.Parse(dataSet.Tables[0].Rows[0]["BillID"].ToString());
				}
				servicesProcessInfo.DoStyle = dataSet.Tables[0].Rows[0]["DoStyle"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					servicesProcessInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["iOperator"].ToString() != "")
				{
					servicesProcessInfo.iOperator = int.Parse(dataSet.Tables[0].Rows[0]["iOperator"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["_Date"].ToString() != "")
				{
					servicesProcessInfo._Date = DateTime.Parse(dataSet.Tables[0].Rows[0]["_Date"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DoStatus"].ToString() != "")
				{
					servicesProcessInfo.DoStatus = int.Parse(dataSet.Tables[0].Rows[0]["DoStatus"].ToString());
				}
				servicesProcessInfo.Reason = dataSet.Tables[0].Rows[0]["Reason"].ToString();
				servicesProcessInfo.TakeSteps = dataSet.Tables[0].Rows[0]["TakeSteps"].ToString();
				result = servicesProcessInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
