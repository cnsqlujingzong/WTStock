using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALMeterReading
	{
		public int Add(List<string[]> strarr, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			for (int i = 0; i < strarr.Count; i++)
			{
				string text = string.Empty;
				string text2 = string.Empty;
				string[] array = strarr[i];
				string[] array2 = new string[9];
				text += "BillID";
				text2 += array[7].ToString();
				if (array[0].ToString() != string.Empty)
				{
					text += ",DeviceID";
					text2 = text2 + "," + array[0].ToString();
				}
				if (array[1].ToString() != string.Empty)
				{
					text += ",_Date";
					text2 = text2 + ",'" + array[1].ToString() + "'";
				}
				if (array[2].ToString() != string.Empty)
				{
					text += ",OperatorID";
					text2 = text2 + "," + array[2].ToString();
				}
				if (array[3].ToString() != string.Empty)
				{
					text += ",Qty";
					text2 = text2 + "," + array[3].ToString();
				}
				if (array[4].ToString() != string.Empty)
				{
					text += ",QtyType";
					text2 = text2 + "," + array[4].ToString();
				}
				if (array[5].ToString() != "")
				{
					text += ",WDate";
					text2 = text2 + ",'" + array[5].ToString() + "'";
				}
				if (array[6].ToString() != "")
				{
					text += ",WRemark";
					text2 = text2 + ",'" + array[6].ToString() + "'";
				}
				if (array[8].ToString() != string.Empty)
				{
					text += ",Loss";
					text2 = text2 + "," + array[8].ToString();
				}
				if (array[9].ToString() != string.Empty)
				{
					text += ",useCount";
					text2 = text2 + "," + array[9].ToString();
				}
				array2[0] = text;
				array2[1] = text2;
				list.Add(array2);
			}
			return DbHelperSQL.ZL_CB_InsertManyData("zl_cb_add", list, out strMsg);
		}

		public void Update(MeterReadingInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update MeterReading set ");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("OperatorID=@OperatorID,");
			stringBuilder.Append("Qty=@Qty,");
			stringBuilder.Append("Loss=@Loss,");
			stringBuilder.Append("WRemark=@Remark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@Qty", SqlDbType.Int, 4),
				new SqlParameter("@Loss", SqlDbType.Int, 4),
				new SqlParameter("@Remark", SqlDbType.VarChar, 200)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Date;
			array[2].Value = model.OperatorID;
			array[3].Value = model.Qty;
			array[4].Value = model.Loss;
			array[5].Value = model.Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Delete(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete MeterReading ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public MeterReadingInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from MeterReading ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			MeterReadingInfo meterReadingInfo = new MeterReadingInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			meterReadingInfo.ID = ID;
			MeterReadingInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["BillID"].ToString() != "")
				{
					meterReadingInfo.BillID = int.Parse(dataSet.Tables[0].Rows[0]["BillID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeviceID"].ToString() != "")
				{
					meterReadingInfo.DeviceID = int.Parse(dataSet.Tables[0].Rows[0]["DeviceID"].ToString());
				}
				meterReadingInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					meterReadingInfo.OperatorID = int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Qty"].ToString() != "")
				{
					meterReadingInfo.Qty = int.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Loss"].ToString() != "")
				{
					meterReadingInfo.Loss = int.Parse(dataSet.Tables[0].Rows[0]["Loss"].ToString());
				}
				meterReadingInfo.Remark = dataSet.Tables[0].Rows[0]["WRemark"].ToString();
				result = meterReadingInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
