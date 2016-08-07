using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALProductModel
	{
		public int Add(ProductModelInfo model, out string strMsg, out int iTbid)
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
			if (model.ClassID > 0)
			{
				text += ",ClassID";
				text2 = text2 + "," + model.ClassID.ToString();
			}
			if (model.BrandID > 0)
			{
				text += ",BrandID";
				text2 = text2 + "," + model.BrandID.ToString();
			}
			if (model.Period > 0)
			{
				text += ",Period";
				text2 = text2 + "," + model.Period.ToString();
			}
			return DALCommon.InsertData("ProductModel", text, text2, string.Concat(new string[]
			{
				" _Name='",
				model._Name,
				"' and ClassID=",
				model.ClassID.ToString(),
				" and BrandID=",
				model.BrandID.ToString()
			}), "类别名称", "ID", out strMsg, out iTbid);
		}

		public int Add_Mod(List<string[]> strarr, string iTbid, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			for (int i = 0; i < strarr.Count; i++)
			{
				string text = string.Empty;
				string text2 = string.Empty;
				string[] array = strarr[i];
				string[] array2 = new string[4];
				text += "ID";
				text2 += iTbid;
				if (array[0].ToString() != string.Empty)
				{
					text += ",BrandID";
					text2 = text2 + ",'" + array[0].ToString() + "'";
				}
				if (array[1].ToString() != string.Empty)
				{
					text += ",ClassID";
					text2 = text2 + ",'" + array[1].ToString() + "'";
				}
				if (array[2].ToString() != string.Empty)
				{
					text += ",_Name";
					text2 = text2 + ",'" + array[2].ToString() + "'";
				}
				if (array[3].ToString() != string.Empty)
				{
					text += ",Period";
					text2 = text2 + ",'" + array[3].ToString() + "'";
				}
				array2[0] = "ProductModel";
				array2[1] = text;
				array2[2] = text2;
				array2[3] = " 1=2 ";
				list.Add(array2);
			}
			return DbHelperSQL.InsertManyData("aa_insertdata", list, out strMsg);
		}

		public int Add_Mod_M(string strBrand, string strType, string strMod, int strPeriod, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strBrand", SqlDbType.VarChar, 50),
				new SqlParameter("@strclass", SqlDbType.VarChar, 50),
				new SqlParameter("@strmodel", SqlDbType.NVarChar, 50),
				new SqlParameter("@Period", SqlDbType.Int, 4),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strBrand;
			array[1].Value = strType;
			array[2].Value = strMod;
			array[3].Value = strPeriod;
			array[4].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("jc_inputmodel", array);
			strMsg = Convert.ToString(array[4].Value);
			return result;
		}

		public int Update(ProductModelInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",ClassID=" + model.ClassID.ToString();
			text = text + ",BrandID=" + model.BrandID.ToString();
			text = text + ",Period=" + model.Period.ToString();
			text = text + ",pyCode='" + model.pyCode + "'";
			return DALCommon.UpdateData("ProductModel", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public ProductModelInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,ClassID,BrandID,_Name,Period from ProductModel ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ProductModelInfo productModelInfo = new ProductModelInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			ProductModelInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					productModelInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ClassID"].ToString() != "")
				{
					productModelInfo.ClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ClassID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["BrandID"].ToString() != "")
				{
					productModelInfo.BrandID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["BrandID"].ToString()));
				}
				productModelInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["Period"].ToString() != "")
				{
					productModelInfo.Period = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Period"].ToString()));
				}
				result = productModelInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
