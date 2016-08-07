using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALChargeItem
	{
		public int Add(ChargeItemInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			string text3 = " _Name='" + model._Name + "' ";
			text3 = text3 + " and DeptID=" + model.DeptID.ToString();
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID.ToString();
			if (model.Type > 0)
			{
				text += ",Type";
				text2 = text2 + "," + model.Type;
			}
			return DALCommon.InsertData("ChargeItem", text, text2, text3, "收支项目", "ID", out strMsg, out iTbid);
		}

		public int Update(ChargeItemInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",Type=" + model.Type;
			return DALCommon.UpdateData("ChargeItem", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public ChargeItemInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,_Name,Type from ChargeItem ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ChargeItemInfo chargeItemInfo = new ChargeItemInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			ChargeItemInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					chargeItemInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					chargeItemInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				chargeItemInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["Type"].ToString() != "")
				{
					chargeItemInfo.Type = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Type"].ToString()));
				}
				result = chargeItemInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
