using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServicesPush
	{
		public int Add(ServicesPushInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "BillID";
			text2 += model.BillID.ToString();
			if (model._Date != "")
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.iOperator > 0)
			{
				text += ",iOperator";
				text2 = text2 + "," + model.iOperator.ToString();
			}
			if (model.LinkMan != "")
			{
				text += ",LinkMan";
				text2 = text2 + ",'" + model.LinkMan + "'";
			}
			if (model.Tel != "")
			{
				text += ",Tel";
				text2 = text2 + ",'" + model.Tel + "'";
			}
			if (model.Result != "")
			{
				text += ",Result";
				text2 = text2 + ",'" + model.Result + "'";
			}
			return DALCommon.InsertData("ServicesPush", text, text2, "1=2", "1", "ID", out strMsg, out iTbid);
		}

		public void Update(ServicesPushInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ServicesPush set ");
			stringBuilder.Append("LinkMan=@LinkMan,");
			stringBuilder.Append("Tel=@Tel,");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("Result=@Result");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@Result", SqlDbType.VarChar, 500)
			};
			array[0].Value = model.ID;
			array[1].Value = model.LinkMan;
			array[2].Value = model.Tel;
			array[3].Value = model._Date;
			array[4].Value = model.Result;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
