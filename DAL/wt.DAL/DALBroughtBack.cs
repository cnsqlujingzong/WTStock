using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALBroughtBack
	{
		public int Add(BroughtBackInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "PersonID";
			text2 += model.PersonID.ToString();
			if (model._Date != string.Empty)
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.AppID > 0)
			{
				text += ",AppID";
				text2 = text2 + "," + model.AppID.ToString();
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.Type > 0)
			{
				text += ",Type";
				text2 = text2 + "," + model.Type.ToString();
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"ck_lt_kd"
			});
			if (model.BroughtBackDetailInfos != null)
			{
				foreach (BroughtBackDetailInfo current in model.BroughtBackDetailInfos)
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
					if (current.CiteID > 0)
					{
						text += ",CiteID";
						text2 = text2 + "," + current.CiteID.ToString();
					}
					if (current.OperationID != string.Empty)
					{
						text += ",OperationID";
						text2 = text2 + ",'" + current.OperationID + "'";
					}
					if (current.SN != string.Empty)
					{
						text += ",SN";
						text2 = text2 + ",'" + current.SN + "'";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "ck_lt_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(BroughtBackInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "_Date='" + model._Date + "'";
			text = text + ",AppID=" + model.AppID.ToString();
			text = text + ",Type=" + model.Type.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			list.Add(new string[]
			{
				"BroughtBack",
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
			if (model.BroughtBackDetailInfos != null)
			{
				foreach (BroughtBackDetailInfo current in model.BroughtBackDetailInfos)
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
						if (current.CiteID > 0)
						{
							text2 += ",CiteID";
							text = text + "," + current.CiteID.ToString();
						}
						if (current.OperationID != string.Empty)
						{
							text2 += ",OperationID";
							text = text + ",'" + current.OperationID + "'";
						}
						if (current.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "ck_lt_kdmx";
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
						text = text + ",CiteID=" + current.CiteID.ToString();
						text = text + ",OperationID='" + current.OperationID + "'";
						text = text + ",SN='" + current.SN + "'";
						array2[0] = "BroughtBackDetail";
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

		public int GetID(string BillID)
		{
			int result = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [ID] from BroughtBack ");
			stringBuilder.Append(" where BillID=@BillID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.VarChar, 50)
			};
			array[0].Value = BillID;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					result = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
			}
			return result;
		}

		public BroughtBackInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,ChkOperatorID,Remark,BillID,isnull(DeptID,0) as DeptID,_Date=convert(char(10), _Date,120),PersonID,AppID,Type,Status,ChkDate from BroughtBack ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			BroughtBackInfo broughtBackInfo = new BroughtBackInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			BroughtBackInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					broughtBackInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					broughtBackInfo.ChkOperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString()));
				}
				broughtBackInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				broughtBackInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					broughtBackInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				broughtBackInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["PersonID"].ToString() != "")
				{
					broughtBackInfo.PersonID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["PersonID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["AppID"].ToString() != "")
				{
					broughtBackInfo.AppID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["AppID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Type"].ToString() != "")
				{
					broughtBackInfo.Type = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Type"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					broughtBackInfo.Status = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					broughtBackInfo.ChkDate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString()));
				}
				result = broughtBackInfo;
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
				text = text + " and _Date ='" + strcon + "' ";
				break;
			case 3:
				text = text + " and Person like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and AppOperator like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and Type like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and ChkDate like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and (ChkOperator like '%" + strcon + "%') ";
				break;
			case 8:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and ID in(select BillID from BroughtBackDetail where OperationID like '%" + strcon + "%')";
				break;
			default:
				if (schid == 21)
				{
					text = text + " and Dept like '%" + strcon + "%'";
				}
				break;
			}
			return text;
		}

		public int ChkBroughtBack(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("ck_lt_chk", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkBroughtBackU(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("ck_lt_chku", array);
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
			int result = DbHelperSQL.RunProcedureTran("ck_lt_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public DataSet SchStockCount(string sWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select _Name,StockID,StockName,GoodsNO,Spec,Unit,Stock,convert(decimal(18,2), (sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end )))as avgprice, ");
			stringBuilder.Append(" convert(decimal(18,2),(sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end))) as avgprice1, ");
			stringBuilder.Append(" convert(decimal(18,2),(sum(CostPrice*case when type='退废品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='退废品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='退废品' then isnull(数量,0) else 0 end)) end))) as avgprice2, ");
			stringBuilder.Append(" sum(case when type='领良品' then 数量 else 0 end) as 领料数量, sum(case when type='退良品' then 数量 else 0 end) as 退料数量,sum(case when type='退废品' then 数量 else 0 end) as 退料数量1 from v_lt_detailbyname  ");
			stringBuilder.Append(" where " + sWhere + " group by _Name,StockID,StockName,GoodsNO,Spec,Unit,Stock  ");
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public DataSet ExecStockCount(string sWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select StockName,GoodsNO,_Name,Spec,Unit,sum(case when type='领良品' then 数量 else 0 end) as 领料数量,convert(decimal(18,2),(sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end )))as avgprice, ");
			stringBuilder.Append(" sum(case when type='退良品' then 数量 else 0 end) as 退料数量,convert(decimal(18,2),(sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end))) as avgprice1, ");
			stringBuilder.Append(" sum(case when type='退废品' then 数量 else 0 end) as 退料数量1,convert(decimal(18,2),(sum(CostPrice*case when type='退废品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='退废品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='退废品' then isnull(数量,0) else 0 end)) end))) as avgprice2,Stock from v_lt_detailbyname  ");
			stringBuilder.Append(" where " + sWhere + " group by _Name,StockID,StockName,GoodsNO,Spec,Unit,Stock  ");
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public DataSet SchStockCountBy(string sWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select AppID,AppOperator,_Name,GoodsNO,Spec,Unit,convert(decimal(18,2), (sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end )))as avgprice, ");
			stringBuilder.Append(" convert(decimal(18,2),(sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end))) as avgprice1, ");
			stringBuilder.Append(" convert(decimal(18,2),(sum(CostPrice*case when type='退废品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='退废品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='退废品' then isnull(数量,0) else 0 end)) end))) as avgprice2, ");
			stringBuilder.Append(" sum(case when type='领良品' then 数量 else 0 end) as 领料数量, sum(case when type='退良品' then 数量 else 0 end) as 退料数量,sum(case when type='退废品' then 数量 else 0 end) as 退料数量1, ");
			stringBuilder.Append(" (sum(case when type='领良品' then 数量 else 0 end)-sum(case when type='退良品' then 数量 else 0 end)-sum(case when type='退废品' then 数量 else 0 end)) as 占用数 ");
			stringBuilder.Append("  from v_lt_detailbyname where " + sWhere + " group by AppID,AppOperator,_Name,GoodsNO,Spec,Unit  ");
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public DataSet ExecStockCountBy(string sWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select AppOperator,GoodsNO,_Name,Spec,Unit,sum(case when type='领良品' then 数量 else 0 end) as 领料数量,convert(decimal(18,2), (sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end )))as avgprice, ");
			stringBuilder.Append(" sum(case when type='退良品' then 数量 else 0 end) as 退料数量,convert(decimal(18,2),(sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end))) as avgprice1,sum(case when type='退废品' then 数量 else 0 end) as 退料数量1, ");
			stringBuilder.Append(" convert(decimal(18,2),(sum(CostPrice*case when type='退废品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='退废品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='退废品' then isnull(数量,0) else 0 end)) end))) as avgprice2, ");
			stringBuilder.Append(" (sum(case when type='领良品' then 数量 else 0 end)-sum(case when type='退良品' then 数量 else 0 end)-sum(case when type='退废品' then 数量 else 0 end)) as 占用数, convert(decimal(18,2), (sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end )))as avgprice3, ");
			stringBuilder.Append(" ((sum(case when type='领良品' then 数量 else 0 end)-sum(case when type='退良品' then 数量 else 0 end)-sum(case when type='退废品' then 数量 else 0 end)) * convert(decimal(18,2), (sum(CostPrice*case when type='领良品' then isnull(数量,0) else 0 end)/ (case when convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end))=0 then 1 else convert(decimal,sum(case when type='领良品' then isnull(数量,0) else 0 end)) end ))))as 占用金额 ");
			stringBuilder.Append(" from v_lt_detailbyname where " + sWhere + " group by AppOperator,GoodsNO,_Name,Spec,Unit ");
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public bool comparePrice(int billid)
		{
			bool result = true;
			string sQLString = "select a.Price,b.LowPrice from BroughtBackDetail a left join GoodsUnit b on a.goodsid=b.goodsid where a.Billid=@Billid";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Billid", SqlDbType.Int, 4)
			};
			array[0].Value = billid;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					decimal d;
					decimal.TryParse(dataTable.Rows[i]["Price"].ToString(), out d);
					decimal d2;
					decimal.TryParse(dataTable.Rows[i]["LowPrice"].ToString(), out d2);
					if (d2 > d)
					{
						result = false;
						break;
					}
				}
			}
			return result;
		}
	}
}
