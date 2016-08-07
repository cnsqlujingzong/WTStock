using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALAccount
	{
		public int Add(AccountInfo model, out string strMsg, out int iTbid)
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
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("Account", text, text2, text3, "收支账户", "ID", out strMsg, out iTbid);
		}

		public int Update(AccountInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("Account", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int UpdateBegin(AccountInfo model, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iJSid", SqlDbType.Int),
				new SqlParameter("@dYE", SqlDbType.Decimal),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = model.ID;
			array[1].Value = model.BeginMoney;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("qc_xj_kd", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int ChkBegin(int DeptID, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = DeptID;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("qc_xj_ad", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public AccountInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,_Name,Money,Remark,BeginMoney,BeginStatus from Account ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			AccountInfo accountInfo = new AccountInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			AccountInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					accountInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					accountInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				accountInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["Money"].ToString() != "")
				{
					accountInfo.Money = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["Money"].ToString()));
				}
				accountInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				if (dataSet.Tables[0].Rows[0]["BeginMoney"].ToString() != "")
				{
					accountInfo.BeginMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["BeginMoney"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["BeginStatus"].ToString() != "")
				{
					accountInfo.BeginStatus = int.Parse(dataSet.Tables[0].Rows[0]["BeginStatus"].ToString());
				}
				result = accountInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
