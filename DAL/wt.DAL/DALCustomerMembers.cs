using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALCustomerMembers
	{
		public int Add(CustomerMembersInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			string strCondition = " _Name='" + model._Name + "' ";
			if (model.Price != "")
			{
				text += ",Price";
				text2 = text2 + ",'" + model.Price + "'";
			}
			if (model.Dis > 0m)
			{
				text += ",Dis";
				text2 = text2 + "," + model.Dis.ToString();
			}
			return DALCommon.InsertData("CustomerMembers", text, text2, strCondition, "等级名称", "ID", out strMsg, out iTbid);
		}

		public int Update(CustomerMembersInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",Price='" + model.Price + "'";
			text = text + ",Dis=" + model.Dis.ToString();
			return DALCommon.UpdateData("CustomerMembers", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public CustomerMembersInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 ID,_Name,Price,Dis from CustomerMembers ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			CustomerMembersInfo customerMembersInfo = new CustomerMembersInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			customerMembersInfo.ID = ID;
			CustomerMembersInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				customerMembersInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				customerMembersInfo.Price = dataSet.Tables[0].Rows[0]["Price"].ToString();
				if (dataSet.Tables[0].Rows[0]["Dis"].ToString() != "")
				{
					customerMembersInfo.Dis = decimal.Parse(dataSet.Tables[0].Rows[0]["Dis"].ToString());
				}
				result = customerMembersInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
