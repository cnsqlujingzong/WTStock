using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALOA_Annunciate
	{
		public int Add(OA_AnnunciateInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "Title,_Date";
			text2 = text2 + "'" + model.Title + "',getdate()";
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID;
			if (model.AuthorID > 0)
			{
				text += ",AuthorID";
				text2 = text2 + "," + model.AuthorID;
			}
			if (model.Content != string.Empty)
			{
				text += ",Content";
				text2 = text2 + ",'" + model.Content + "'";
			}
			return DALCommon.InsertData("OA_Annunciate", text, text2, "", "", "ID", out strMsg, out iTbid);
		}

		public int Update(OA_AnnunciateInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "Title='" + model.Title + "'";
			text = text + ",Content='" + model.Content + "'";
			return DALCommon.UpdateData("OA_Annunciate", text, " [ID]=" + model.ID.ToString(), "", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public OA_AnnunciateInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,_Date,AuthorID,Title,Content,Hit from OA_Annunciate ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			OA_AnnunciateInfo oA_AnnunciateInfo = new OA_AnnunciateInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			OA_AnnunciateInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					oA_AnnunciateInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					oA_AnnunciateInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				oA_AnnunciateInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["AuthorID"].ToString() != "")
				{
					oA_AnnunciateInfo.AuthorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["AuthorID"].ToString()));
				}
				oA_AnnunciateInfo.Title = dataSet.Tables[0].Rows[0]["Title"].ToString();
				oA_AnnunciateInfo.Content = dataSet.Tables[0].Rows[0]["Content"].ToString();
				if (dataSet.Tables[0].Rows[0]["Hit"].ToString() != "")
				{
					oA_AnnunciateInfo.Hit = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Hit"].ToString()));
				}
				result = oA_AnnunciateInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void UpdateHit(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update OA_Annunciate set ");
			stringBuilder.Append("Hit=Hit+1 ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
