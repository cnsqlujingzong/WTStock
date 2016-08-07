using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSellPlan
	{
		public int Add(SellPlanInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			if (model.OperatorID > 0)
			{
				text += "OperatorID";
				text2 += model.OperatorID.ToString();
			}
			if (model._Date != string.Empty)
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID.ToString();
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.ContractNO != string.Empty)
			{
				text += ",ContractNO";
				text2 = text2 + ",'" + model.ContractNO + "'";
			}
			if (model.bEnd > 0)
			{
				text += ",bEnd";
				text2 = text2 + "," + model.bEnd.ToString();
			}
			if (model.SndOperatorID > 0)
			{
				text += ",SndOperatorID";
				text2 = text2 + "," + model.SndOperatorID.ToString();
			}
			if (model.LinkMan != string.Empty)
			{
				text += ",LinkMan";
				text2 = text2 + ",'" + model.LinkMan + "'";
			}
			if (model.Tel != string.Empty)
			{
				text += ",Tel";
				text2 = text2 + ",'" + model.Tel + "'";
			}
			if (model.Adr != string.Empty)
			{
				text += ",Adr";
				text2 = text2 + ",'" + model.Adr + "'";
			}
            if (model.BrandName != string.Empty)
            {
                text += ",BrandName";
                text2 = text2 + ",'" + model.BrandName + "'";
            }     
                text += ",BrandTaxRate";
                text2 = text2 + "," + model.BrandTaxRate ;
                text += ",BrandTaxRateType";
                text2 = text2 + ",'" + model.BrandTaxRateType + "'";
			list.Add(new string[]
			{
				text.TrimStart(new char[]
				{
					','
				}),
				text2.TrimStart(new char[]
				{
					','
				}),
				"xs_dd_kd"
			});
			if (model.SellPlanDetailInfos != null)
			{
				foreach (SellPlanDetailInfo current in model.SellPlanDetailInfos)
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
					if (current.Dis > 0m)
					{
						text += ",Dis";
						text2 = text2 + "," + current.Dis.ToString();
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
                    if (current.Huoqi != string.Empty)
                    {
                        text += ",Huoqi";
                        text2 = text2 + ",'" + current.Huoqi + "'";
                    }
                    if (current.baozhuang != string.Empty)
                    {
                        text += ",baozhuang";
                        text2 = text2 + ",'" + current.baozhuang + "'";
                    }
                    if (current.chengse != string.Empty)
                    {
                        text += ",chengse";
                        text2 = text2 + ",'" + current.chengse + "'";
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
					array[0] = text;
					array[1] = text2;
					array[2] = "xs_dd_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(SellPlanInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "OperatorID=" + model.OperatorID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",CustomerID=" + model.CustomerID.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",ContractNO='" + model.ContractNO + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Adr='" + model.Adr + "'";

            text = text + ",BrandName='" + model.BrandName + "'";
            text = text + ",BrandTaxRate=" + model.BrandTaxRate ;
            text = text + ",BrandTaxRateType='" + model.BrandTaxRateType + "'";
			if (model.SndOperatorID > 0)
			{
				text = text + ",SndOperatorID=" + model.SndOperatorID.ToString();
			}
			else
			{
				text += ",SndOperatorID=null";
			}
			list.Add(new string[]
			{
				"SellPlan",
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
			if (model.SellPlanDetailInfos != null)
			{
				foreach (SellPlanDetailInfo current in model.SellPlanDetailInfos)
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
						if (current.Dis > 0m)
						{
							text2 += ",Dis";
							text = text + "," + current.Dis.ToString();
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
                        if (current.Huoqi  != string.Empty)
                        {
                            text2 += ",Huoqi";
                            text = text + ",'" + current.Huoqi + "'";
                        }
                        if (current.chengse != string.Empty)
                        {
                            text2 += ",chengse";
                            text = text + ",'" + current.chengse + "'";
                        }
                        if (current.baozhuang != string.Empty)
                        {
                            text2 += ",baozhuang";
                            text = text + ",'" + current.baozhuang + "'";
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
						array2[2] = "xs_dd_kdmx";
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
						text = text + ",Dis=" + current.Dis.ToString();
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",TaxRate=" + current.TaxRate.ToString();
						text = text + ",TaxAmount=" + current.TaxAmount.ToString();
						text = text + ",GoodsAmount=" + current.GoodsAmount.ToString();
                        text = text + ",Huoqi='" + current.Huoqi.ToString()+"'";
                        text = text + ",chengse='" + current.chengse.ToString() + "'";
                        text = text + ",baozhuang='" + current.baozhuang.ToString() + "'";
						array2[0] = "SellPlanDetail";
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

		public SellPlanInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select a.[ID],a.Remark,a.DeptID,a.BillID,_Date=convert(char(20), a._Date,120),a.OperatorID,a.CustomerID,a.ChkDate,a.ChkOperatorID,a.Status,b._Name as CusName,a.ContractNO,a.[LinkMan],a.[Tel],a.[Adr],a.SndOperatorID,a.BrandTaxRate,a.BrandTaxRateType,a.BrandName from SellPlan a left join CustomerList b on a.CustomerID=b.[ID] ");
			stringBuilder.Append(" where a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			SellPlanInfo sellPlanInfo = new SellPlanInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			SellPlanInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					sellPlanInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				sellPlanInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					sellPlanInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				sellPlanInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				sellPlanInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					sellPlanInfo.OperatorID = int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["CustomerID"].ToString() != "")
				{
					sellPlanInfo.CustomerID = int.Parse(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					sellPlanInfo.ChkDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					sellPlanInfo.ChkOperatorID = int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					sellPlanInfo.Status = int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString());
				}
				sellPlanInfo.CusName = dataSet.Tables[0].Rows[0]["CusName"].ToString();
				sellPlanInfo.ContractNO = dataSet.Tables[0].Rows[0]["ContractNO"].ToString();
				if (dataSet.Tables[0].Rows[0]["SndOperatorID"].ToString() != "")
				{
					sellPlanInfo.SndOperatorID = int.Parse(dataSet.Tables[0].Rows[0]["SndOperatorID"].ToString());
				}
                if (dataSet.Tables[0].Rows[0]["BrandName"].ToString() != "")
                {
                    sellPlanInfo.BrandName = dataSet.Tables[0].Rows[0]["BrandName"].ToString();
                }
                if (dataSet.Tables[0].Rows[0]["BrandTaxRateType"].ToString() != "")
                {
                    sellPlanInfo.BrandTaxRateType = dataSet.Tables[0].Rows[0]["BrandTaxRateType"].ToString();
                }
                if (dataSet.Tables[0].Rows[0]["BrandTaxRate"].ToString() != "")
                {
                    sellPlanInfo.BrandTaxRate = Convert.ToDecimal(dataSet.Tables[0].Rows[0]["BrandTaxRate"]);
                }
				sellPlanInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				sellPlanInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				sellPlanInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				result = sellPlanInfo;
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
				text = text + " and Operator like '%" + strcon + "%' ";
				break;
			case 4:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (_Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%' or CustomerNO like '%",
					strcon,
					"%' ) "
				});
				break;
			}
			case 5:
				text = text + " and ChkDate like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and ChkOperator like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and ContractNO like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public int ChkSellPlan(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("xs_dd_ad", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkSellPlanU(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("xs_dd_fad", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkEnd(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("xs_dd_end", array);
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
			int result = DbHelperSQL.RunProcedureTran("xs_dd_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int UpdateStatus(string Billid)
		{
			string sQLString = "update SellPlan set status = 3 where Billid = @Billid";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Billid", SqlDbType.VarChar, 50)
			};
			array[0].Value = Billid;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public DataSet Qtyquery(string Billid, int goodsid)
		{
			string sQLString = "select * from v_sellplandet where Billid = @Billid and GoodsID = @GoodsID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Billid", SqlDbType.VarChar, 50),
				new SqlParameter("@GoodsID", SqlDbType.Int)
			};
			array[0].Value = Billid;
			array[1].Value = goodsid;
			return DbHelperSQL.Query(sQLString, array);
		}

		public int UpdateCount(int Billid, decimal Count, int GoodsID)
		{
			string sQLString = "update SellPlanDetail set qty = qty - @Count ,quotety = quotety + @Count where Billid = @Billid and GoodsID = @GoodsID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Billid", SqlDbType.Int),
				new SqlParameter("@Count", SqlDbType.Decimal, 18),
				new SqlParameter("@GoodsID", SqlDbType.Int)
			};
			array[0].Value = Billid;
			array[1].Value = Count;
			array[2].Value = GoodsID;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public DataSet IDquery(string Billid)
		{
			string sQLString = "select id from sellplan where Billid = @Billid";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Billid", SqlDbType.VarChar, 50)
			};
			array[0].Value = Billid;
			return DbHelperSQL.Query(sQLString, array);
		}

		public DataSet QtyCount(int Billid)
		{
			string sQLString = "select qty from SellPlanDetail where Billid = @Billid ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Billid", SqlDbType.Int)
			};
			array[0].Value = Billid;
			return DbHelperSQL.Query(sQLString, array);
		}
	}
}
