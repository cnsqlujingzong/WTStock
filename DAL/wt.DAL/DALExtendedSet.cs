using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALExtendedSet
	{
		public int Add(ExtendedSetInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "ClassID";
			text2 += model.ClassID.ToString();
			if (model.BrandID > 0)
			{
				text += ",BrandID";
				text2 = text2 + "," + model.BrandID.ToString();
			}
			if (model.dPoint > 0m)
			{
				text += ",dPoint";
				text2 = text2 + "," + model.dPoint.ToString();
			}
			return DALCommon.InsertData("ExtendedSet", text, text2, " ClassID=" + model.ClassID.ToString() + " and BrandID=" + model.BrandID.ToString(), "超期单", "ID", out strMsg, out iTbid);
		}

		public int Update(ExtendedSetInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "ClassID=" + model.ClassID.ToString();
			text = text + ",BrandID=" + model.BrandID.ToString();
			text = text + ",dPoint=" + model.dPoint.ToString();
			return DALCommon.UpdateData("ExtendedSet", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public ExtendedSetInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,ClassID,BrandID,dPoint from ExtendedSet ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ExtendedSetInfo extendedSetInfo = new ExtendedSetInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			ExtendedSetInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					extendedSetInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ClassID"].ToString() != "")
				{
					extendedSetInfo.ClassID = int.Parse(dataSet.Tables[0].Rows[0]["ClassID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["BrandID"].ToString() != "")
				{
					extendedSetInfo.BrandID = int.Parse(dataSet.Tables[0].Rows[0]["BrandID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["dPoint"].ToString() != "")
				{
					extendedSetInfo.dPoint = decimal.Parse(dataSet.Tables[0].Rows[0]["dPoint"].ToString());
				}
				result = extendedSetInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
