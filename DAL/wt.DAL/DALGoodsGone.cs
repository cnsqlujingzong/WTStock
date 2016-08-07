using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALGoodsGone
	{
		public int Add(GoodsGoneInfo model, out string strMsg, out int iTbid)
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
			if (model.bSnd)
			{
				text += ",bSnd";
				text2 += ",1";
			}
			if (model.Array > 0)
			{
				text += ",Array";
				text2 = text2 + "," + model.Array.ToString();
			}
			return DALCommon.InsertData("GoodsGone", text, text2, strCondition, "物品去向", "ID", out strMsg, out iTbid);
		}

		public int Update(GoodsGoneInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",pyCode='" + model.pyCode + "'";
			if (model.bSnd)
			{
				text += ",bSnd=1";
			}
			else
			{
				text += ",bSnd=0";
			}
			text = text + ",Array=" + model.Array.ToString();
			return DALCommon.UpdateData("GoodsGone", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public GoodsGoneInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,_Name,bSnd,pyCode,Array from GoodsGone ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			GoodsGoneInfo goodsGoneInfo = new GoodsGoneInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			GoodsGoneInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					goodsGoneInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				goodsGoneInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				goodsGoneInfo.pyCode = dataSet.Tables[0].Rows[0]["pyCode"].ToString();
				if (dataSet.Tables[0].Rows[0]["bSnd"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSnd"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSnd"].ToString().ToLower() == "true")
					{
						goodsGoneInfo.bSnd = true;
					}
					else
					{
						goodsGoneInfo.bSnd = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["Array"].ToString() != "")
				{
					goodsGoneInfo.Array = int.Parse(dataSet.Tables[0].Rows[0]["Array"].ToString());
				}
				result = goodsGoneInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
