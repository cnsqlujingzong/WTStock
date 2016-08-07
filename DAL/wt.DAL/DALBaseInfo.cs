using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALBaseInfo
	{
		public int Add(string strTbName, BaseInfo model, string strRepeat, bool bDept, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = " _Name='" + model._Name + "' ";
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
				text += ",pyCode";
				text2 = text2 + ",'" + model.pyCode + "'";
			}
			if (bDept)
			{
				text3 = text3 + " and DeptID=" + model.DeptID.ToString();
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.Array > 0)
			{
				text += ",Array";
				text2 = text2 + "," + model.Array.ToString();
			}
			return DALCommon.InsertData(strTbName, text, text2, text3, strRepeat, "ID", out strMsg, out iTbid);
		}

		public int Update(string strTbName, BaseInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",pyCode='" + model.pyCode + "'";
			text = text + ",Array=" + model.Array.ToString();
			return DALCommon.UpdateData(strTbName, text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int Delete(string strTbName, int ID, out string strMsg)
		{
			return DALCommon.DeteleData(strTbName, "ID=" + ID.ToString(), out strMsg);
		}

		public int Delete(int iFlag1, int iFlag2, int iTbid, out string strMsg)
		{
			return DALCommon.DeteleData(iFlag1, iFlag2, iTbid, out strMsg);
		}

		public BaseInfo GetModel(string strTbName, int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,_Name,Array from ");
			stringBuilder.Append(strTbName);
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			BaseInfo baseInfo = new BaseInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			BaseInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					baseInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				baseInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["Array"] != null)
				{
					if (dataSet.Tables[0].Rows[0]["Array"].ToString() != "")
					{
						baseInfo.Array = int.Parse(dataSet.Tables[0].Rows[0]["Array"].ToString());
					}
				}
				result = baseInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
