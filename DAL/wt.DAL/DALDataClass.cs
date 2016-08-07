using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALDataClass
	{
		public int Add(string strTbName, DataClassInfo model, out string strMsg)
		{
			string str = string.Empty;
			string text = string.Empty;
			if (model._Name != string.Empty)
			{
				str += "_Name";
				text = text + "'" + model._Name + "'";
			}
			str += ",Father";
			text = text + "," + model.Father;
			str += ",Array";
			text = text + "," + model.Array.ToString();
			return DALCommon.InsertTreeData(strTbName, text, " _Name='" + model._Name + "'", "ID", int.Parse(model.Father.ToString()), out strMsg);
		}

		public int Update(int iFlag, string strTbName, DataClassInfo model, string chkfld, int iNewParentid, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",Array=" + model.Array.ToString();
			return DALCommon.UpdateTreeData(iFlag, strTbName, text, chkfld, " [ID]", model.ID, iNewParentid, out strMsg);
		}

		public int Delete(string strTbName, int ID, out string strMsg)
		{
			return DALCommon.DeteleTreeData(strTbName, ID, out strMsg);
		}

		public DataClassInfo GetModel(string strTbName, int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,_Name,Father,_Level,Array from ");
			stringBuilder.Append(strTbName);
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DataClassInfo dataClassInfo = new DataClassInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			DataClassInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					dataClassInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				dataClassInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["Father"].ToString() != "")
				{
					dataClassInfo.Father = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Father"].ToString()));
				}
				dataClassInfo._Level = dataSet.Tables[0].Rows[0]["_Level"].ToString();
				if (dataSet.Tables[0].Rows[0]["Array"].ToString() != "")
				{
					dataClassInfo.Array = int.Parse(dataSet.Tables[0].Rows[0]["Array"].ToString());
				}
				result = dataClassInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
