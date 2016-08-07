using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALShippingStyle
	{
		public int Add(ShippingStyleInfo model, out string strMsg, out int iTbid)
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
			string text3 = " _Name='" + model._Name + "'";
			text3 = text3 + " and DeptID=" + model.DeptID.ToString();
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID;
			if (model.Tel != string.Empty)
			{
				text += ",Tel";
				text2 = text2 + ",'" + model.Tel + "'";
			}
			if (model.LinkMan != string.Empty)
			{
				text += ",LinkMan";
				text2 = text2 + ",'" + model.LinkMan + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("ShippingStyle", text, text2, text3, "货运公司", "ID", out strMsg, out iTbid);
		}

		public int Update(ShippingStyleInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",pyCode='" + model.pyCode + "'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("ShippingStyle", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public ShippingStyleInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,_Name,LinkMan,Tel,Remark,pyCode from ShippingStyle ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ShippingStyleInfo shippingStyleInfo = new ShippingStyleInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			ShippingStyleInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					shippingStyleInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					shippingStyleInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				shippingStyleInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				shippingStyleInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				shippingStyleInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				shippingStyleInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				shippingStyleInfo.pyCode = dataSet.Tables[0].Rows[0]["pyCode"].ToString();
				result = shippingStyleInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
