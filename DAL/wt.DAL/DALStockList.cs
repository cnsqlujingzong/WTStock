using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALStockList
	{
		public int Add(StockListInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			string text3 = " _Name='" + model._Name + "' ";
			if (model.DeptID > 0)
			{
				text3 = text3 + " and DeptID=" + model.DeptID.ToString();
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			else
			{
				text3 += " and DeptID is null";
			}
			if (model.StockAdmID1 > 0)
			{
				text += ",StockAdmID1";
				text2 = text2 + "," + model.StockAdmID1.ToString();
			}
			if (model.StockAdmID2 > 0)
			{
				text += ",StockAdmID2";
				text2 = text2 + "," + model.StockAdmID2.ToString();
			}
			if (model.StockSite != string.Empty)
			{
				text += ",StockSite";
				text2 = text2 + ",'" + model.StockSite + "'";
			}
			if (model.bReject)
			{
				text += ",bReject";
				text2 += ",1";
			}
			if (model.bStop)
			{
				text += ",bStop";
				text2 += ",1";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.OtherStockAdm != string.Empty)
			{
				text += ",OtherStockAdm";
				text2 = text2 + ",'" + model.OtherStockAdm + "'";
			}
			return DALCommon.InsertData("StockList", text, text2, text3, "仓库名称", "ID", out strMsg, out iTbid);
		}

		public int Add_Stock(string strstockName, string strstockadmid1, string strstockadmid2, string strbreject, string strstocksite, string strremark, int depetid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strstockName", SqlDbType.VarChar, 50),
				new SqlParameter("@strstockadmid1", SqlDbType.VarChar, 50),
				new SqlParameter("@strstockadmid2", SqlDbType.VarChar, 50),
				new SqlParameter("@strbreject", SqlDbType.VarChar, 50),
				new SqlParameter("@strstocksite", SqlDbType.VarChar, 50),
				new SqlParameter("@strremark", SqlDbType.VarChar, 50),
				new SqlParameter("@depetid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strstockName;
			array[1].Value = strstockadmid1;
			array[2].Value = strstockadmid2;
			array[3].Value = strbreject;
			array[4].Value = strstocksite;
			array[5].Value = strremark;
			array[6].Value = depetid;
			array[7].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("jc_inputstock", array);
			strMsg = Convert.ToString(array[7].Value);
			return result;
		}

		public int Update(StockListInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			if (model.StockAdmID1 > 0)
			{
				text = text + ",StockAdmID1=" + model.StockAdmID1.ToString();
			}
			else
			{
				text += ",StockAdmID1=null";
			}
			if (model.StockAdmID2 > 0)
			{
				text = text + ",StockAdmID2=" + model.StockAdmID2.ToString();
			}
			else
			{
				text += ",StockAdmID2=null";
			}
			text = text + ",StockSite='" + model.StockSite + "'";
			if (model.bStop)
			{
				text += ",bStop=1";
			}
			else
			{
				text += ",bStop=0";
			}
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",OtherStockAdm='" + model.OtherStockAdm + "'";
			return DALCommon.UpdateData("StockList", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public StockListInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,_Name,isnull(StockAdmID1,-1) as StockAdmID1,isnull(StockAdmID2,-1) as StockAdmID2,StockSite,bReject,bStop,Remark,OtherStockAdm from StockList ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			StockListInfo stockListInfo = new StockListInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			StockListInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					stockListInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					stockListInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				stockListInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["StockAdmID1"].ToString() != "")
				{
					stockListInfo.StockAdmID1 = new int?(int.Parse(dataSet.Tables[0].Rows[0]["StockAdmID1"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["StockAdmID2"].ToString() != "")
				{
					stockListInfo.StockAdmID2 = new int?(int.Parse(dataSet.Tables[0].Rows[0]["StockAdmID2"].ToString()));
				}
				stockListInfo.StockSite = dataSet.Tables[0].Rows[0]["StockSite"].ToString();
				if (dataSet.Tables[0].Rows[0]["bReject"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bReject"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bReject"].ToString().ToLower() == "true")
					{
						stockListInfo.bReject = true;
					}
					else
					{
						stockListInfo.bReject = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bStop"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStop"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStop"].ToString().ToLower() == "true")
					{
						stockListInfo.bStop = true;
					}
					else
					{
						stockListInfo.bStop = false;
					}
				}
				stockListInfo.OtherStockAdm = dataSet.Tables[0].Rows[0]["OtherStockAdm"].ToString();
				stockListInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = stockListInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int GetStockID()
		{
			string sQLString = " select top 1 ID from StockList where bStop=0 ";
			DataTable dataTable = DbHelperSQL.Query(sQLString).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0][0].ToString() != "")
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				result = -1;
			}
			return result;
		}
	}
}
