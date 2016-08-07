using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALDeviceConfItem
	{
		public int Add(DeviceConfItemInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.ProductClassID > 0)
			{
				text += ",ProductClassID";
				text2 = text2 + "," + model.ProductClassID.ToString();
			}
			if (model.Parameter != string.Empty)
			{
				text += ",Parameter";
				text2 = text2 + ",'" + model.Parameter + "'";
			}
			if (model.MaintenancePeriod != string.Empty)
			{
				text += ",MaintenancePeriod";
				text2 = text2 + ",'" + model.MaintenancePeriod + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("DeviceConfItem", text, text2, " 1=2 ", "机器配置项", "ID", out strMsg, out iTbid);
		}

		public int Update(DeviceConfItemInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			if (model.ProductClassID > 0)
			{
				text = text + ",ProductClassID=" + model.ProductClassID.ToString();
			}
			else
			{
				text += ",ProductClassID=null";
			}
			text = text + ",Parameter='" + model.Parameter + "'";
			text = text + ",MaintenancePeriod='" + model.MaintenancePeriod + "'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("DeviceConfItem", text, " [ID]=" + model.ID.ToString(), " 1=2 ", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public DeviceConfItemInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,isnull(ProductClassID,0) as ProductClassID,_Name,Parameter,MaintenancePeriod,Remark from DeviceConfItem ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DeviceConfItemInfo deviceConfItemInfo = new DeviceConfItemInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			DeviceConfItemInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					deviceConfItemInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					deviceConfItemInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
				{
					deviceConfItemInfo.ProductClassID = int.Parse(dataSet.Tables[0].Rows[0]["ProductClassID"].ToString());
				}
				deviceConfItemInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				deviceConfItemInfo.Parameter = dataSet.Tables[0].Rows[0]["Parameter"].ToString();
				deviceConfItemInfo.MaintenancePeriod = dataSet.Tables[0].Rows[0]["MaintenancePeriod"].ToString();
				deviceConfItemInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = deviceConfItemInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
