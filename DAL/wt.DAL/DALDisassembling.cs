using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALDisassembling
	{
		public int Add(DisassemblingInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "OperatorID";
			text2 += model.OperatorID.ToString();
			if (model._Date != string.Empty)
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.PersonID > 0)
			{
				text += ",PersonID";
				text2 = text2 + "," + model.PersonID.ToString();
			}
			if (model.Type > 0)
			{
				text += ",Type";
				text2 = text2 + "," + model.Type.ToString();
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.StockID > 0)
			{
				text += ",StockID";
				text2 = text2 + "," + model.StockID.ToString();
			}
			if (model.GoodsID > 0)
			{
				text += ",GoodsID";
				text2 = text2 + "," + model.GoodsID.ToString();
			}
			if (model.UnitID > 0)
			{
				text += ",UnitID";
				text2 = text2 + "," + model.UnitID.ToString();
			}
			if (model.Qty > 0m)
			{
				text += ",Qty";
				text2 = text2 + "," + model.Qty.ToString();
			}
			if (model.Price > 0m)
			{
				text += ",Price";
				text2 = text2 + "," + model.Price.ToString();
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.SN != string.Empty)
			{
				text += ",SN";
				text2 = text2 + ",'" + model.SN + "'";
			}
			if (model.bStockOut)
			{
				text += ",bStockOut";
				text2 += ",1";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"ck_cz_kd"
			});
			if (model.DisassemblingDetailInfos != null)
			{
				foreach (DisassemblingDetailInfo current in model.DisassemblingDetailInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "StockID";
					text2 += current.StockID.ToString();
					if (current.GoodsID > 0)
					{
						text += ",GoodsID";
						text2 = text2 + "," + current.GoodsID.ToString();
					}
					if (current.UnitID > 0)
					{
						text += ",UnitID";
						text2 = text2 + "," + current.UnitID.ToString();
					}
					if (current.Qty > 0m)
					{
						text += ",Qty";
						text2 = text2 + "," + current.Qty.ToString();
					}
					if (current.Price > 0m)
					{
						text += ",Price";
						text2 = text2 + "," + current.Price.ToString();
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					if (current.SN != string.Empty)
					{
						text += ",SN";
						text2 = text2 + ",'" + current.SN + "'";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "ck_cz_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(DisassemblingInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "OperatorID=" + model.OperatorID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",PersonID=" + model.PersonID.ToString();
			if (model.StockID > 0)
			{
				text = text + ",StockID=" + model.StockID.ToString();
			}
			else
			{
				text += ",StockID=null";
			}
			text = text + ",Qty=" + model.Qty.ToString();
			text = text + ",Price=" + model.Price.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",SN='" + model.SN + "'";
			text = text + ",Type=" + model.Type;
			if (model.bStockOut)
			{
				text += ",bStockOut=1";
			}
			else
			{
				text += ",bStockOut=0";
			}
			list.Add(new string[]
			{
				"Disassembling",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array = strdellist[i];
				list2.Add(new string[]
				{
					array[0].ToString(),
					" ID in(" + array[1].ToString() + ")"
				});
			}
			if (model.DisassemblingDetailInfos != null)
			{
				foreach (DisassemblingDetailInfo current in model.DisassemblingDetailInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "StockID";
						text += current.StockID.ToString();
						if (current.GoodsID > 0)
						{
							text2 += ",GoodsID";
							text = text + "," + current.GoodsID.ToString();
						}
						if (current.UnitID > 0)
						{
							text2 += ",UnitID";
							text = text + "," + current.UnitID.ToString();
						}
						if (current.Qty > 0m)
						{
							text2 += ",Qty";
							text = text + "," + current.Qty.ToString();
						}
						if (current.Price > 0m)
						{
							text2 += ",Price";
							text = text + "," + current.Price.ToString();
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "ck_cz_kdmx";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "StockID=" + current.StockID.ToString();
						text = text + ",GoodsID=" + current.GoodsID.ToString();
						text = text + ",UnitID=" + current.UnitID.ToString();
						text = text + ",Qty=" + current.Qty.ToString();
						text = text + ",Price=" + current.Price.ToString();
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",SN='" + current.SN + "'";
						array2[0] = "DisassemblingDetail";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "";
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public DisassemblingInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from ck_disassembling ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DisassemblingInfo disassemblingInfo = new DisassemblingInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			DisassemblingInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					disassemblingInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					disassemblingInfo.ChkOperatorID = int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StockID"].ToString() != "")
				{
					disassemblingInfo.StockID = int.Parse(dataSet.Tables[0].Rows[0]["StockID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["GoodsID"].ToString() != "")
				{
					disassemblingInfo.GoodsID = int.Parse(dataSet.Tables[0].Rows[0]["GoodsID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["UnitID"].ToString() != "")
				{
					disassemblingInfo.UnitID = int.Parse(dataSet.Tables[0].Rows[0]["UnitID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Qty"].ToString() != "")
				{
					disassemblingInfo.Qty = decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Price"].ToString() != "")
				{
					disassemblingInfo.Price = decimal.Parse(dataSet.Tables[0].Rows[0]["Price"].ToString());
				}
				disassemblingInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				disassemblingInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					disassemblingInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				disassemblingInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					disassemblingInfo.OperatorID = int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["PersonID"].ToString() != "")
				{
					disassemblingInfo.PersonID = int.Parse(dataSet.Tables[0].Rows[0]["PersonID"].ToString());
				}
				disassemblingInfo.sStatus = dataSet.Tables[0].Rows[0]["Status"].ToString();
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					disassemblingInfo.ChkDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString());
				}
				disassemblingInfo.GoodsNO = dataSet.Tables[0].Rows[0]["GoodsNO"].ToString();
				disassemblingInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				disassemblingInfo.Spec = dataSet.Tables[0].Rows[0]["Spec"].ToString();
				disassemblingInfo.Brand = dataSet.Tables[0].Rows[0]["ProductBrand"].ToString();
				disassemblingInfo.bType = dataSet.Tables[0].Rows[0]["Type"].ToString();
				disassemblingInfo.SN = dataSet.Tables[0].Rows[0]["SN"].ToString();
				if (dataSet.Tables[0].Rows[0]["bStockOut"].ToString().Trim() == "1" || dataSet.Tables[0].Rows[0]["bStockOut"].ToString().ToLower().Trim() == "true")
				{
					disassemblingInfo.bStockOut = true;
				}
				else
				{
					disassemblingInfo.bStockOut = false;
				}
				result = disassemblingInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public string GetSchWhere(int schid, string strcon)
		{
			string text = string.Empty;
			switch (schid)
			{
			case 1:
				text = text + " and BillID like '%" + strcon + "%' ";
				break;
			case 2:
				text = text + " and Type like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and _Date ='" + strcon + "' ";
				break;
			case 4:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Person like '%",
					strcon,
					"%' or PersonNO like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 5:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Operator like '%",
					strcon,
					"%' or OperatorNO like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 6:
				text = text + " and StockName like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and GoodsNO like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and _Name like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Spec like '%" + strcon + "%' ";
				break;
			case 10:
				text = text + " and ProductBrand like '%" + strcon + "%' ";
				break;
			case 11:
				text = text + " and ChkDate like '%" + strcon + "%' ";
				break;
			case 12:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ChkOperator like '%",
					strcon,
					"%' or ChkOperatorNO like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 13:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public int ChkDis(int Dept, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Dept", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = Dept;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_cz_chk", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkDisU(int Dept, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Dept", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = Dept;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_cz_chku", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int Delete(int Dept, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Dept", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = Dept;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_cz_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}
	}
}
