using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALPurchasePlan
	{
		public int Add(PurchasePlanInfo model, out int iTbid)
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
			text += ",ProvID";
			text2 = text2 + "," + model.ProvID.ToString();
			text += ",StockID";
			text2 = text2 + "," + model.StockID.ToString();
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"cg_dd_kd"
			});
			if (model.PurchasePlanDetailInfos != null)
			{
				foreach (PurchasePlanDetailInfo current in model.PurchasePlanDetailInfos)
				{
					string[] array = new string[3];
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
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "cg_dd_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(PurchasePlanInfo model, List<string[]> strdellist, out string strMsg)
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
			text = text + ",Remark='" + model.Remark + "'";
			list.Add(new string[]
			{
				"PurchasePlan",
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
			if (model.PurchasePlanDetailInfos != null)
			{
				foreach (PurchasePlanDetailInfo current in model.PurchasePlanDetailInfos)
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
						array2[2] = "cg_dd_kdmx";
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
						text = text + ",TaxRate=" + current.TaxRate.ToString();
						text = text + ",TaxAmount=" + current.TaxAmount.ToString();
						text = text + ",GoodsAmount=" + current.GoodsAmount.ToString();
						array2[0] = "PurchasePlanDetail";
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

		public PurchasePlanInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select a.[ID],a.ChkDate,a.ChkOperatorID,a.Status,a.Remark,isnull(a.DeptID,0) as DeptID,a.BillID,_Date=convert(char(10), a._Date,120),a.OperatorID,isnull(a.ProvID,0) as ProvID,isnull(a.StockID,0) as StockID,b._Name as SupName from PurchasePlan a left join SupplierList b on a.ProvID=b.[ID] ");
			stringBuilder.Append(" where a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			PurchasePlanInfo purchasePlanInfo = new PurchasePlanInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			PurchasePlanInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					purchasePlanInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					purchasePlanInfo.ChkDate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					purchasePlanInfo.ChkOperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					purchasePlanInfo.Status = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString()));
				}
				purchasePlanInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					purchasePlanInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				purchasePlanInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				purchasePlanInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					purchasePlanInfo.OperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ProvID"].ToString() != "")
				{
					purchasePlanInfo.ProvID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ProvID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["StockID"].ToString() != "")
				{
					purchasePlanInfo.StockID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["StockID"].ToString()));
				}
				purchasePlanInfo.SupName = dataSet.Tables[0].Rows[0]["SupName"].ToString();
				result = purchasePlanInfo;
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
				text = text + " and ChkDate like '%" + strcon + "%' ";
				break;
			case 6:
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
			case 7:
				text = text + " and StockName like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public int ChkPurchasePlan(int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("cg_dd_chk", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int ChkPurchasePlanU(int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("cg_dd_chku", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int SwitchPlan(int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("cg_dd_switch", array);
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
			int result = DbHelperSQL.RunProcedureTran("cg_dd_del", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int FullClose(int PurPlanID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("if (select bPlanControl from SysParm where ID=1)=1 and @PlanID>0 and @PlanID is not null and\r\nnot exists(select ID from cg_purchaseplandetail where BillID=@PlanID and leftcount>0)\r\nupdate PurchasePlan set Status=3 where ID=@PlanID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@PlanID", SqlDbType.Int)
			};
			array[0].Value = PurPlanID;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
