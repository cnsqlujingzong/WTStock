using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALPurchase
	{
		public int Add(PurchaseInfo model, int iFlag, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "OperatorID";
			text2 += model.OperatorID.ToString();
			text += ",_Date";
			text2 = text2 + ",'" + model._Date + "'";
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.InCash > 0m)
			{
				text += ",InCash";
				text2 = text2 + "," + model.InCash.ToString();
			}
			text += ",ProvID";
			text2 = text2 + "," + model.ProvID.ToString();
			text += ",StockID";
			text2 = text2 + "," + model.StockID.ToString();
			if (model.InvoiceNO != null && model.InvoiceNO != string.Empty)
			{
				text += " ,InvoiceNO";
				text2 = text2 + "," + model.InvoiceNO;
			}
			if (model.InvoiceMoney > 0m)
			{
				text += " ,InvoiceMoney";
				text2 = text2 + "," + model.InvoiceMoney.ToString();
			}
			if (model.InvoiceDate != DateTime.MinValue)
			{
				text += " ,InvoiceDate";
				text2 = text2 + ",'" + model.InvoiceDate.ToString() + "'";
			}
			if (model.AccountID > 0)
			{
				text += " ,AccountID";
				text2 = text2 + "," + model.AccountID.ToString();
			}
			if (model.InvoiceClassID > 0)
			{
				text += " ,InvoiceClassID";
				text2 = text2 + "," + model.InvoiceClassID.ToString();
			}
			if (model.ChargeModeID > 0)
			{
				text += " ,ChargeModeID";
				text2 = text2 + "," + model.ChargeModeID.ToString();
			}
			if (model.LinkMan != null && model.LinkMan != string.Empty)
			{
				text += ",LinkMan";
				text2 = text2 + ",'" + model.LinkMan + "'";
			}
			if (model.Tel != null && model.Tel != string.Empty)
			{
				text += ",Tel";
				text2 = text2 + ",'" + model.Tel + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.OperationID != string.Empty)
			{
				text += ",OperationID";
				text2 = text2 + ",'" + model.OperationID + "'";
			}
			if (model.PlanID > 0)
			{
				text += ",PlanID";
				text2 = text2 + "," + model.PlanID;
			}
			string[] array = new string[3];
			array[0] = text;
			array[1] = text2;
			if (iFlag == 1)
			{
				array[2] = "cg_jh_kd";
			}
			else
			{
				array[2] = "cg_th_kd";
			}
			list.Add(array);
			if (model.PurchaseDetailInfos != null)
			{
				foreach (PurchaseDetailInfo current in model.PurchaseDetailInfos)
				{
					string[] array2 = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "GoodsID";
					text2 += current.GoodsID.ToString();
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
					if (current.TaxRate > 0m)
					{
						text += ",TaxRate";
						text2 = text2 + "," + current.TaxRate.ToString();
					}
					if (current.TaxAmount > 0m)
					{
						text += ",TaxAmount";
						text2 = text2 + "," + current.TaxAmount.ToString();
					}
					if (current.GoodsAmount > 0m)
					{
						text += ",GoodsAmount";
						text2 = text2 + "," + current.GoodsAmount.ToString();
					}
					array2[0] = text;
					array2[1] = text2;
					array2[2] = "cg_cg_kdmx";
					list.Add(array2);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(PurchaseInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "OperatorID=" + model.OperatorID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			if (model.ProvID > 0)
			{
				text = text + ",ProvID=" + model.ProvID.ToString();
			}
			else
			{
				text += ",ProvID=null";
			}
			if (model.StockID > 0)
			{
				text = text + ",StockID=" + model.StockID.ToString();
			}
			else
			{
				text += ",StockID=null";
			}
			text = text + ",InCash=" + model.InCash.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			list.Add(new string[]
			{
				"Purchase",
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
			if (model.PurchaseDetailInfos != null)
			{
				foreach (PurchaseDetailInfo current in model.PurchaseDetailInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "GoodsID";
						text += current.GoodsID.ToString();
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
						if (current.TaxRate > 0m)
						{
							text2 += ",TaxRate";
							text = text + "," + current.TaxRate.ToString();
						}
						if (current.TaxAmount > 0m)
						{
							text2 += ",TaxAmount";
							text = text + "," + current.TaxAmount.ToString();
						}
						if (current.GoodsAmount > 0m)
						{
							text2 += ",GoodsAmount";
							text = text + "," + current.GoodsAmount.ToString();
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "cg_cg_kdmx";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "GoodsID=" + current.GoodsID.ToString();
						text = text + ",UnitID=" + current.UnitID.ToString();
						text = text + ",Qty=" + current.Qty.ToString();
						text = text + ",Price=" + current.Price.ToString();
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",SN='" + current.SN + "'";
						text = text + ",TaxRate=" + current.TaxRate.ToString();
						text = text + ",TaxAmount=" + current.TaxAmount.ToString();
						text = text + ",GoodsAmount=" + current.GoodsAmount.ToString();
						array2[0] = "PurchaseDetail";
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
			stringBuilder.Append("select [ID] from Purchase ");
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

		public PurchaseInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select a.[ID],a.ChkDate,a.ChkOperatorID,a.Status,a.Remark,isnull(a.DeptID,0) as DeptID,a.BillID,a.Type,_Date=convert(char(10), a._Date,120),a.OperatorID,isnull(a.ProvID,0) as ProvID,isnull(a.StockID,0) as StockID,a.PlanID,b._Name as SupName,a.InCash from Purchase a left join SupplierList b on a.ProvID=b.[ID] ");
			stringBuilder.Append(" where a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			PurchaseInfo purchaseInfo = new PurchaseInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			PurchaseInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					purchaseInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					purchaseInfo.ChkDate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					purchaseInfo.ChkOperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					purchaseInfo.Status = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString()));
				}
				purchaseInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					purchaseInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				purchaseInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				if (dataSet.Tables[0].Rows[0]["Type"].ToString() != "")
				{
					purchaseInfo.Type = int.Parse(dataSet.Tables[0].Rows[0]["Type"].ToString());
				}
				purchaseInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					purchaseInfo.OperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ProvID"].ToString() != "")
				{
					purchaseInfo.ProvID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ProvID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["StockID"].ToString() != "")
				{
					purchaseInfo.StockID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["StockID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["InCash"].ToString() != "")
				{
					purchaseInfo.InCash = decimal.Parse(dataSet.Tables[0].Rows[0]["InCash"].ToString());
				}
				purchaseInfo.SupName = dataSet.Tables[0].Rows[0]["SupName"].ToString();
				if (dataSet.Tables[0].Rows[0]["PlanID"].ToString() != "")
				{
					purchaseInfo.PlanID = int.Parse(dataSet.Tables[0].Rows[0]["PlanID"].ToString());
				}
				result = purchaseInfo;
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
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Operator like '%",
					strcon,
					"%' or OperatorNO like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 4:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Provider like '%",
					strcon,
					"%' or SupNO like '%",
					strcon,
					"%' or ProviderCode like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 5:
				text = text + " and Account like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and ChkDate like '%" + strcon + "%' ";
				break;
			case 7:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ChkOperator like '%",
					strcon,
					"%' or ChkOperatorNO like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 8:
				text = text + " and StockName like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			default:
				switch (schid)
				{
				case 21:
					text = text + " and ID in(select BillID from cg_purchasedetail where GoodsNO like '%" + strcon + "%') ";
					break;
				case 22:
					text = text + " and ID in(select BillID from cg_purchasedetail where _Name like '%" + strcon + "%') ";
					break;
				}
				break;
			}
			return text;
		}

		public int ChkPurchase(int iflag, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result;
			if (iflag == 0)
			{
				result = DbHelperSQL.RunProcedureTran("cg_cg_chk", array);
			}
			else
			{
				result = DbHelperSQL.RunProcedureTran("cg_cg_chk1", array);
			}
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int ChkPurchaseU(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("cg_cg_chku", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int Delete(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("cg_cg_del", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}
	}
}
