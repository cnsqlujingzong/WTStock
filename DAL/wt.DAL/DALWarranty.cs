using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALWarranty
	{
		public int Add(WarrantyInfo model, out string strMsg, out int iTbid)
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
			if (model.bStopUse)
			{
				text += ",bStopUse";
				text2 += ",1";
			}
			if (model.Array > 0)
			{
				text += ",Array";
				text2 = text2 + "," + model.Array.ToString();
			}
			return DALCommon.InsertData("Warranty", text, text2, strCondition, "保修情况", "ID", out strMsg, out iTbid);
		}

		public int Update(WarrantyInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",pyCode='" + model.pyCode + "'";
			if (model.bCall)
			{
				text += ",bCall=1";
			}
			else
			{
				text += ",bCall=0";
			}
			if (model.bStopUse)
			{
				text += ",bStopUse=1";
			}
			else
			{
				text += ",bStopUse=0";
			}
			text = text + ",Array=" + model.Array.ToString();
			return DALCommon.UpdateData("Warranty", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public WarrantyInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,_Name,bCall,pyCode,Array,bStopUse from Warranty ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			WarrantyInfo warrantyInfo = new WarrantyInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			WarrantyInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					warrantyInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				warrantyInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				warrantyInfo.pyCode = dataSet.Tables[0].Rows[0]["pyCode"].ToString();
				if (dataSet.Tables[0].Rows[0]["bCall"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bCall"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bCall"].ToString().ToLower() == "true")
					{
						warrantyInfo.bCall = true;
					}
					else
					{
						warrantyInfo.bCall = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bStopUse"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStopUse"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStopUse"].ToString().ToLower() == "true")
					{
						warrantyInfo.bStopUse = true;
					}
					else
					{
						warrantyInfo.bStopUse = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["Array"].ToString() != "")
				{
					warrantyInfo.Array = int.Parse(dataSet.Tables[0].Rows[0]["Array"].ToString());
				}
				result = warrantyInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
