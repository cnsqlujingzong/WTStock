using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALOA_Doc
	{
		public int Add(OA_DocInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "Title,_Date";
			text2 = text2 + "'" + model.Title + "',getdate()";
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID;
			if (model.ClassID > 0)
			{
				text += ",ClassID";
				text2 = text2 + "," + model.ClassID;
			}
			if (model.AuthorID > 0)
			{
				text += ",AuthorID";
				text2 = text2 + "," + model.AuthorID;
			}
			if (model.FileSize > 0)
			{
				text += ",FileSize";
				text2 = text2 + "," + model.FileSize;
			}
			if (model.FileName != string.Empty)
			{
				text += ",FileName";
				text2 = text2 + ",'" + model.FileName + "'";
			}
			if (model.FilePath != string.Empty)
			{
				text += ",FilePath";
				text2 = text2 + ",'" + model.FilePath + "'";
			}
			return DALCommon.InsertData("OA_Doc", text, text2, "", "", "ID", out strMsg, out iTbid);
		}

		public int Update(OA_DocInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "Title='" + model.Title + "'";
			if (model.ClassID > 0)
			{
				text = text + ",ClassID=" + model.ClassID;
			}
			else
			{
				text += ",ClassID=null";
			}
			if (model.FileSize > 0)
			{
				text = text + ",FileSize=" + model.FileSize;
			}
			else
			{
				text += ",FileSize=0";
			}
			text = text + ",FileName='" + model.FileName + "'";
			text = text + ",FilePath='" + model.FilePath + "'";
			return DALCommon.UpdateData("OA_Doc", text, " [ID]=" + model.ID.ToString(), "", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public OA_DocInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,isnull(DeptID,0) as DeptID,isnull(ClassID,0) as ClassID,_Date,AuthorID,Title,FileSize,FileName,FilePath,Hit from OA_Doc ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			OA_DocInfo oA_DocInfo = new OA_DocInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			OA_DocInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					oA_DocInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					oA_DocInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ClassID"].ToString() != "")
				{
					oA_DocInfo.ClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ClassID"].ToString()));
				}
				oA_DocInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["AuthorID"].ToString() != "")
				{
					oA_DocInfo.AuthorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["AuthorID"].ToString()));
				}
				oA_DocInfo.Title = dataSet.Tables[0].Rows[0]["Title"].ToString();
				if (dataSet.Tables[0].Rows[0]["FileSize"].ToString() != "")
				{
					oA_DocInfo.FileSize = new int?(int.Parse(dataSet.Tables[0].Rows[0]["FileSize"].ToString()));
				}
				oA_DocInfo.FileName = dataSet.Tables[0].Rows[0]["FileName"].ToString();
				oA_DocInfo.FilePath = dataSet.Tables[0].Rows[0]["FilePath"].ToString();
				if (dataSet.Tables[0].Rows[0]["Hit"].ToString() != "")
				{
					oA_DocInfo.Hit = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Hit"].ToString()));
				}
				result = oA_DocInfo;
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
			stringBuilder.Append("update OA_Doc set ");
			stringBuilder.Append("Hit=Hit+1");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public string GetFilePath(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [FilePath] from OA_Doc ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			string result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = dataSet.Tables[0].Rows[0]["FilePath"].ToString();
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}
	}
}
