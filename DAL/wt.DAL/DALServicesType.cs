using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServicesType
	{
		public int Add(ServicesTypeInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
				text += ",pyCode";
				text2 = text2 + ",'" + model.pyCode + "'";
			}
			string strCondition = " _Name='" + model._Name + "' ";
			if (model.bCall)
			{
				text += ",bCall";
				text2 += ",1";
			}
			if (model.Array > 0)
			{
				text += ",Array";
				text2 = text2 + "," + model.Array.ToString();
			}
			return DALCommon.InsertData("ServicesType", text, text2, strCondition, "服务类别", "ID", out strMsg, out iTbid);
		}

		public int Update(ServicesTypeInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",pyCode='" + model.pyCode + "'";
			text = text + ",Array=" + model.Array.ToString();
			if (model.bCall)
			{
				text += ",bCall=1";
			}
			else
			{
				text += ",bCall=0";
			}
			return DALCommon.UpdateData("ServicesType", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public ServicesTypeInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,_Name,bCall,pyCode,Array from ServicesType ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ServicesTypeInfo servicesTypeInfo = new ServicesTypeInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			ServicesTypeInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					servicesTypeInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				servicesTypeInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				servicesTypeInfo.pyCode = dataSet.Tables[0].Rows[0]["pyCode"].ToString();
				if (dataSet.Tables[0].Rows[0]["bCall"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bCall"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bCall"].ToString().ToLower() == "true")
					{
						servicesTypeInfo.bCall = true;
					}
					else
					{
						servicesTypeInfo.bCall = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["Array"].ToString() != "")
				{
					servicesTypeInfo.Array = int.Parse(dataSet.Tables[0].Rows[0]["Array"].ToString());
				}
				result = servicesTypeInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
