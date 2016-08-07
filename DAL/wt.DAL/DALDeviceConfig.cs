using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALDeviceConfig
	{
		public int Add(List<string[]> strarr, string iTbid, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			for (int i = 0; i < strarr.Count; i++)
			{
				string text = string.Empty;
				string text2 = string.Empty;
				string[] array = strarr[i];
				string[] array2 = new string[7];
				text += "DeviceID";
				text2 += iTbid;
				if (array[0].ToString() != string.Empty)
				{
					text += ",_Name";
					text2 = text2 + ",'" + array[0].ToString() + "'";
				}
				if (array[1].ToString() != string.Empty)
				{
					text += ",Parameter";
					text2 = text2 + ",'" + array[1].ToString() + "'";
				}
				if (array[2].ToString() != string.Empty)
				{
					text += ",SN";
					text2 = text2 + ",'" + array[2].ToString() + "'";
				}
				if (array[3].ToString() != string.Empty)
				{
					text += ",MaintenancePeriod";
					text2 = text2 + ",'" + array[3].ToString() + "'";
				}
				if (array[4].ToString() != string.Empty)
				{
					text += ",BuyDate";
					text2 = text2 + ",'" + array[4].ToString() + "'";
				}
				if (array[5].ToString() != string.Empty)
				{
					text += ",MaintenanceEnd";
					text2 = text2 + ",'" + array[5].ToString() + "'";
				}
				if (array[6].ToString() != string.Empty)
				{
					text += ",Remark";
					text2 = text2 + ",'" + array[6].ToString() + "'";
				}
				array2[0] = "DeviceConfig";
				array2[1] = text;
				array2[2] = text2;
				array2[3] = " 1=2 ";
				array2[4] = "机器配置";
				array2[5] = "ID";
				array2[6] = "DeviceID";
				list.Add(array2);
			}
			return DbHelperSQL.InsertManyData("aa_insertdata", list, out strMsg);
		}

		public int Add_All(string strA, string strB, string strC, string strD, string strE, string strF, string strG, string strH, string strI, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@CustomerNO", SqlDbType.VarChar, 50),
				new SqlParameter("@ProductsSN", SqlDbType.VarChar, 50),
				new SqlParameter("@Name", SqlDbType.VarChar, 100),
				new SqlParameter("@Parameter", SqlDbType.VarChar, 50),
				new SqlParameter("@SN", SqlDbType.VarChar, 50),
				new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar, 50),
				new SqlParameter("@BuyDate", SqlDbType.VarChar, 50),
				new SqlParameter("@MaintenanceEnd", SqlDbType.VarChar, 50),
				new SqlParameter("@Remark", SqlDbType.VarChar, 2000),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strA;
			array[1].Value = strB;
			array[2].Value = strC;
			array[3].Value = strD;
			array[4].Value = strE;
			array[5].Value = strF;
			array[6].Value = strG;
			array[7].Value = strH;
			array[8].Value = strI;
			array[9].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("inputDeviceConfig", array);
			strMsg = Convert.ToString(array[9].Value);
			return result;
		}

		public void Update(DeviceConfigInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update DeviceConfig set ");
			stringBuilder.Append("_Name=@_Name,");
			stringBuilder.Append("Parameter=@Parameter,");
			stringBuilder.Append("SN=@SN,");
			stringBuilder.Append("MaintenancePeriod=@MaintenancePeriod,");
			stringBuilder.Append("BuyDate=@BuyDate,");
			stringBuilder.Append("MaintenanceEnd=@MaintenanceEnd,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Name", SqlDbType.VarChar, 50),
				new SqlParameter("@Parameter", SqlDbType.VarChar, 50),
				new SqlParameter("@SN", SqlDbType.VarChar, 50),
				new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar, 50),
				new SqlParameter("@BuyDate", SqlDbType.VarChar, 50),
				new SqlParameter("@MaintenanceEnd", SqlDbType.VarChar, 50),
				new SqlParameter("@Remark", SqlDbType.VarChar, 200)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Name;
			array[2].Value = model.Parameter;
			array[3].Value = model.SN;
			array[4].Value = model.MaintenancePeriod;
			array[5].Value = model.BuyDate;
			array[6].Value = model.MaintenanceEnd;
			array[7].Value = model.Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public DeviceConfigInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeviceID,_Name,Parameter,SN,MaintenancePeriod,BuyDate,MaintenanceEnd,Remark from DeviceConfig ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DeviceConfigInfo deviceConfigInfo = new DeviceConfigInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			DeviceConfigInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					deviceConfigInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeviceID"].ToString() != "")
				{
					deviceConfigInfo.DeviceID = int.Parse(dataSet.Tables[0].Rows[0]["DeviceID"].ToString());
				}
				deviceConfigInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				deviceConfigInfo.Parameter = dataSet.Tables[0].Rows[0]["Parameter"].ToString();
				deviceConfigInfo.SN = dataSet.Tables[0].Rows[0]["SN"].ToString();
				deviceConfigInfo.MaintenancePeriod = dataSet.Tables[0].Rows[0]["MaintenancePeriod"].ToString();
				deviceConfigInfo.BuyDate = dataSet.Tables[0].Rows[0]["BuyDate"].ToString();
				deviceConfigInfo.MaintenanceEnd = dataSet.Tables[0].Rows[0]["MaintenanceEnd"].ToString();
				deviceConfigInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = deviceConfigInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
