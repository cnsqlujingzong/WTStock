using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALOfferItem
	{
		public int Add(OfferItemInfo model, out string strMsg, out int iTbid)
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
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("OfferItem", text, text2, strCondition, "报价项目", "ID", out strMsg, out iTbid);
		}

		public int Update(OfferItemInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",pyCode='" + model.pyCode + "'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("Account", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public OfferItemInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,_Name,Remark from OfferItem ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			OfferItemInfo offerItemInfo = new OfferItemInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			OfferItemInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					offerItemInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				offerItemInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				offerItemInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = offerItemInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
