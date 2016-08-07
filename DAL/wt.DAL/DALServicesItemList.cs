using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServicesItemList
	{
		public int Add(ServicesItemListInfo model, out string strMsg, out int iTbid)
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
			string strCondition = " ItemNO='" + model.ItemNO + "' ";
			if (model.ItemNO != string.Empty)
			{
				text += ",ItemNO";
				text2 = text2 + ",'" + model.ItemNO + "'";
			}
			if (model.Price > 0m)
			{
				text += ",Price";
				text2 = text2 + "," + model.Price.ToString();
			}
			if (model.WarrantyPrice > 0m)
			{
				text += ",WarrantyPrice";
				text2 = text2 + "," + model.WarrantyPrice.ToString();
			}
			if (model.TecDeduct > 0m)
			{
				text += ",TecDeduct";
				text2 = text2 + "," + model.TecDeduct.ToString();
			}
			return DALCommon.InsertData("ServicesItemList", text, text2, strCondition, "项目或编号", "ID", out strMsg, out iTbid);
		}

		public int Update(ServicesItemListInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",pyCode='" + model.pyCode + "'";
			text = text + ",ItemNO='" + model.ItemNO + "'";
			text = text + ",Price=" + model.Price.ToString();
			text = text + ",WarrantyPrice=" + model.WarrantyPrice.ToString();
			text = text + ",TecDeduct=" + model.TecDeduct.ToString();
			return DALCommon.UpdateData("ServicesItemList", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public ServicesItemListInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,ItemNO,_Name,Price,WarrantyPrice,TecDeduct from ServicesItemList ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ServicesItemListInfo servicesItemListInfo = new ServicesItemListInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			ServicesItemListInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					servicesItemListInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				servicesItemListInfo.ItemNO = dataSet.Tables[0].Rows[0]["ItemNO"].ToString();
				servicesItemListInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["Price"].ToString() != "")
				{
					servicesItemListInfo.Price = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["Price"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["WarrantyPrice"].ToString() != "")
				{
					servicesItemListInfo.WarrantyPrice = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["WarrantyPrice"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["TecDeduct"].ToString() != "")
				{
					servicesItemListInfo.TecDeduct = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["TecDeduct"].ToString()));
				}
				result = servicesItemListInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int Add_ServiceItem(string strname, string strno, decimal strprice, decimal strwarrantyprice, decimal strdeduct, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strName", SqlDbType.VarChar, 50),
				new SqlParameter("@strNo", SqlDbType.VarChar, 50),
				new SqlParameter("@strprice", SqlDbType.Decimal, 8),
				new SqlParameter("@strwarrantyprice", SqlDbType.Decimal, 8),
				new SqlParameter("@strdeduct", SqlDbType.Decimal, 8),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strname;
			array[1].Value = strno;
			array[2].Value = strprice;
			array[3].Value = strwarrantyprice;
			array[4].Value = strdeduct;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("jc_inputserviceitem", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}
	}
}
