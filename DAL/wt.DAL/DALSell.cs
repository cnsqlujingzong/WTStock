using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSell
	{
		public int Add(SellInfo model, out int iTbid)
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
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID.ToString();
			}
            if (model.CustomerID2 > 0)
            {
                text += ",CustomerID2";
                text2 = text2 + "," + model.CustomerID2.ToString();
            }      
                text += ",isDai";
                text2 = text2 + "," + model.isDai;
                if (model.LinkMan2 != string.Empty)
                {
                    text += ",LinkMan2";
                    text2 = text2 + ",'" + model.LinkMan2 + "'";
                } if (model.Tel2 != string.Empty)
                {
                    text += ",Tel2";
                    text2 = text2 + ",'" + model.Tel2 + "'";
                } if (model.Adr2 != string.Empty)
                {
                    text += ",Adr2";
                    text2 = text2 + ",'" + model.Adr2 + "'";
                }
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
			if (model.OperationID != string.Empty)
			{
				text += ",OperationID";
				text2 = text2 + ",'" + model.OperationID + "'";
			}

			if (model.AutoNO != string.Empty)
			{
				text += ",AutoNO";
				text2 = text2 + ",'" + model.AutoNO + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
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
           
			if (model.AccountID > 0)
			{
				text += ",AccountID";
				text2 = text2 + "," + model.AccountID;
			}
			if (model.InvoiceDate != DateTime.MinValue)
			{
				text += ",InvoiceDate";
				text2 = text2 + ",'" + model.InvoiceDate.ToString("yyyy-MM-dd") + "'";
			}
			if (model.InvoiceMoney > 0m)
			{
				text += ",InvoiceMoney";
				text2 = text2 + "," + model.InvoiceMoney;
			}
			if (model.InvoiceNO != string.Empty)
			{
				text += ",InvoiceNO";
				text2 = text2 + ",'" + model.InvoiceNO + "'";
			}
			if (model.ChargeModeID > 0)
			{
				text += ",ChargeModeID";
				text2 = text2 + "," + model.ChargeModeID;
			}
			if (model.InvoiceClassID > 0)
			{
				text += ",InvoiceClassID";
				text2 = text2 + "," + model.InvoiceClassID;
			}
            if (model.BrandName != string.Empty)
            {
                text += ",BrandName";
                text2 = text2 + ",'" + model.BrandName + "'";
            }
            text += ",BrandTaxRate";
            text2 = text2 + ",'" + model.BrandTaxRate + "'";
            text += ",BrandTaxRateType";
            text2 = text2 + ",'" + model.BrandTaxRateType + "'";
      
			string[] array = new string[3];
			array[0] = text;
			array[1] = text2;
			if (model.Type == 1)
			{
				array[2] = "xs_ck_kd";
			}
			else
			{
				array[2] = "xs_th_kd";
			}
			list.Add(array);
			if (model.SellDetailInfos != null)
			{
				foreach (SellDetailInfo current in model.SellDetailInfos)
				{
					string[] array2 = new string[3];
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
                    if (current.chengse != string.Empty)
                    {
                        text += ",chengse";
                        text2 = text2 + ",'" + current.chengse + "'";
                    }
                    if (current.baozhuang != string.Empty)
                    {
                        text += ",baozhuang";
                        text2 = text2 + ",'" + current.baozhuang + "'";
                    }
					if (current.SN != string.Empty)
					{
						text += ",SN";
						text2 = text2 + ",'" + current.SN + "'";
					}
					if (current.MaintenancePeriod != string.Empty)
					{
						text += ",MaintenancePeriod";
						text2 = text2 + ",'" + current.MaintenancePeriod + "'";
					}
					if (current.PeriodEndDate != string.Empty)
					{
						text += ",PeriodEndDate";
						text2 = text2 + ",'" + current.PeriodEndDate + "'";
					}
					if (current.CiteID > 0)
					{
						text += ",CiteID";
						text2 = text2 + "," + current.CiteID.ToString();
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
					array2[2] = "xs_xs_kdmx";
					list.Add(array2);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(SellInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "OperatorID=" + model.OperatorID.ToString();
			text = text + ",_Date='" + model._Date + "'";
            text = text + ",isDai=" + model.isDai.ToString();
			text = text + ",CustomerID=" + model.CustomerID.ToString();
            text = text + ",CustomerID2=" + model.CustomerID2.ToString();
			text = text + ",InCash=" + model.InCash.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",OperationID='" + model.OperationID + "'";
			text = text + ",AutoNO='" + model.AutoNO + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
            text = text + ",LinkMan2='" + model.LinkMan2 + "'";
			text = text + ",Tel='" + model.Tel + "'";
            text = text + ",Tel2='" + model.Tel2 + "'";
			text = text + ",Adr='" + model.Adr + "'";
            text = text + ",Adr2='" + model.Adr2+ "'";
            text = text + ",BrandName='" + model.BrandName + "'";
            text = text + ",BrandTaxRate=" + model.BrandTaxRate;
            text = text + ",BrandTaxRateType='" + model.BrandTaxRateType + "'";
			if (model.SndOperatorID > 0)
			{
				text = text + ",SndOperatorID=" + model.SndOperatorID.ToString();
			}
			else
			{
				text += ",SndOperatorID=null";
			}
			if (model.AccountID > 0)
			{
				text = text + ",AccountID=" + model.AccountID;
			}
			else
			{
				text += ",AccountID=null";
			}
			if (model.InvoiceDate != DateTime.MinValue)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					",InvoiceDate='",
					model.InvoiceDate,
					"'"
				});
			}
			else
			{
				text += ",InvoiceDate=null";
			}
			text = text + ",InvoiceNO='" + model.InvoiceNO + "'";
			if (model.InvoiceMoney > 0m)
			{
				text = text + ",InvoiceMoney=" + model.InvoiceMoney;
			}
			else
			{
				text += ",InvoiceMoney=null";
			}
			if (model.ChargeModeID > 0)
			{
				text = text + ",ChargeModeID=" + model.ChargeModeID;
			}
			else
			{
				text += ",ChargeModeID=null";
			}
			if (model.InvoiceClassID > 0)
			{
				text = text + ",InvoiceClassID=" + model.InvoiceClassID;
			}
			else
			{
				text += ",InvoiceClassID=null";
			}
			list.Add(new string[]
			{
				"Sell",
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
			if (model.SellDetailInfos != null)
			{
				foreach (SellDetailInfo current in model.SellDetailInfos)
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
                        if (current.Huoqi != string.Empty)
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
						if (current.CiteID > 0)
						{
							text2 += ",CiteID";
							text = text + "," + current.CiteID.ToString();
						}
						if (current.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						if (current.MaintenancePeriod != string.Empty)
						{
							text2 += ",MaintenancePeriod";
							text = text + ",'" + current.MaintenancePeriod + "'";
						}
						if (current.PeriodEndDate != string.Empty)
						{
							text2 += ",PeriodEndDate";
							text = text + ",'" + current.PeriodEndDate + "'";
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
						array2[2] = "xs_xs_kdmx";
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
						text = text + ",CiteID=" + current.CiteID.ToString();
						text = text + ",SN='" + current.SN + "'";
						text = text + ",MaintenancePeriod='" + current.MaintenancePeriod + "'";
						text = text + ",PeriodEndDate='" + current.PeriodEndDate + "'";
						text = text + ",TaxRate=" + current.TaxRate.ToString();
						text = text + ",TaxAmount=" + current.TaxAmount.ToString();
						text = text + ",GoodsAmount=" + current.GoodsAmount.ToString();
                        text = text + ",Huoqi='" + current.Huoqi.ToString()+"'";
                        text = text + ",chengse='" + current.chengse.ToString() + "'";
                        text = text + ",baozhuang='" + current.baozhuang.ToString() + "'";
						array2[0] = "SellDetail";
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
			stringBuilder.Append("select [ID] from Sell ");
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

		public SellInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select a.[ID],a.ChkDate,a.ChkOperatorID,a.Status,a.OperationID,a.Remark,a.DeptID,a.BillID,a.Type,_Date=convert(char(20), a._Date,120),a.OperatorID,a.isDai,a.PersonID,a.CustomerID,a.CustomerID2,a.InCash,b._Name as CusName,a.AutoNO,a.[LinkMan],a.[Tel],a.[Adr],a.[LinkMan2],a.[Tel2],a.[Adr2],a.SndOperatorID,a.InvoiceDate,a.AccountID,a.InvoiceMoney,a.InvoiceNO,a.ChargeModeID,a.InvoiceClassID,a.BrandTaxRate,a.BrandTaxRateType,a.BrandName,c._Name as CusName2 from Sell a left join CustomerList b on a.CustomerID=b.[ID] left join CustomerList c on a.CustomerID2=c.[ID]");
			stringBuilder.Append(" where a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			SellInfo sellInfo = new SellInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			SellInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					sellInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					sellInfo.ChkDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					sellInfo.ChkOperatorID = int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					sellInfo.Status = int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString());
				}
				sellInfo.OperationID = dataSet.Tables[0].Rows[0]["OperationID"].ToString();
				sellInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					sellInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				sellInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				if (dataSet.Tables[0].Rows[0]["Type"].ToString() != "")
				{
					sellInfo.Type = int.Parse(dataSet.Tables[0].Rows[0]["Type"].ToString());
				}
				sellInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					sellInfo.OperatorID = int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["PersonID"].ToString() != "")
				{
					sellInfo.PersonID = int.Parse(dataSet.Tables[0].Rows[0]["PersonID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["CustomerID"].ToString() != "")
				{
					sellInfo.CustomerID = int.Parse(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
				}
                if (dataSet.Tables[0].Rows[0]["CustomerID2"].ToString() != "")
                {
                    sellInfo.CustomerID2 = int.Parse(dataSet.Tables[0].Rows[0]["CustomerID2"].ToString());
                }
				if (dataSet.Tables[0].Rows[0]["InCash"].ToString() != "")
				{
					sellInfo.InCash = decimal.Parse(dataSet.Tables[0].Rows[0]["InCash"].ToString());
				}
				sellInfo.CusName = dataSet.Tables[0].Rows[0]["CusName"].ToString();
                sellInfo.CusName2 = dataSet.Tables[0].Rows[0]["CusName2"].ToString();
				sellInfo.AutoNO = dataSet.Tables[0].Rows[0]["AutoNO"].ToString();
				if (dataSet.Tables[0].Rows[0]["SndOperatorID"].ToString() != "")
				{
					sellInfo.SndOperatorID = int.Parse(dataSet.Tables[0].Rows[0]["SndOperatorID"].ToString());
				}
                if (dataSet.Tables[0].Rows[0]["isDai"].ToString() != "")
                {
                    sellInfo.isDai = int.Parse(dataSet.Tables[0].Rows[0]["isDai"].ToString());
                }
				sellInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				sellInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				sellInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
                sellInfo.LinkMan2 = dataSet.Tables[0].Rows[0]["LinkMan2"].ToString();
                sellInfo.Tel2 = dataSet.Tables[0].Rows[0]["Tel2"].ToString();
                sellInfo.Adr2 = dataSet.Tables[0].Rows[0]["Adr2"].ToString();
				sellInfo.InvoiceNO = dataSet.Tables[0].Rows[0]["InvoiceNO"].ToString();
				if (dataSet.Tables[0].Rows[0]["InvoiceMoney"].ToString() != "")
				{
					sellInfo.InvoiceMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["InvoiceMoney"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["InvoiceDate"].ToString() != "")
				{
					sellInfo.InvoiceDate = DateTime.Parse(dataSet.Tables[0].Rows[0]["InvoiceDate"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["AccountID"].ToString() != "")
				{
					sellInfo.AccountID = int.Parse(dataSet.Tables[0].Rows[0]["AccountID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChargeModeID"].ToString() != "")
				{
					sellInfo.ChargeModeID = int.Parse(dataSet.Tables[0].Rows[0]["ChargeModeID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["InvoiceClassID"].ToString() != "")
				{
					sellInfo.InvoiceClassID = int.Parse(dataSet.Tables[0].Rows[0]["InvoiceClassID"].ToString());
				}
                	if (dataSet.Tables[0].Rows[0]["BrandName"].ToString() != "")
				{
					sellInfo.BrandName =dataSet.Tables[0].Rows[0]["BrandName"].ToString();
				}
                  	if (dataSet.Tables[0].Rows[0]["BrandTaxRateType"].ToString() != "")
				{
					sellInfo.BrandTaxRateType =dataSet.Tables[0].Rows[0]["BrandTaxRateType"].ToString();
				}
                    if (dataSet.Tables[0].Rows[0]["BrandTaxRate"].ToString() != "")
				{
                    sellInfo.BrandTaxRate = Convert.ToDecimal(dataSet.Tables[0].Rows[0]["BrandTaxRate"]);
				}
             
				result = sellInfo;
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
				text = text + " and AutoNO like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and _Date ='" + strcon + "' ";
				break;
			case 4:
				text = text + " and Person like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and Operator like '%" + strcon + "%' ";
				break;
			case 6:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (_Name like '%",
					strcon,
					"%' or CustomerNO like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 7:
				text = text + " and ChkDate like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and ChkOperator like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 10:
				text = text + " and SndOperator like '%" + strcon + "%'";
				break;
			case 21:
				text = text + " and ID in(select BillID from xs_selldetail where GoodsNO like '%" + strcon + "%') ";
				break;
			case 22:
				text = text + " and ID in(select BillID from xs_selldetail where _Name like '%" + strcon + "%') ";
				break;
			}
			return text;
		}

		public int ChkSell(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("xs_xs_chk", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkSell1(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("xs_xs_chk1", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkSellU(int Dept, int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("xs_xs_chku", array);
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
			int result = DbHelperSQL.RunProcedureTran("xs_xs_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public bool comparePrice(int billid)
		{
			bool result = true;
			string sQLString = "select a.Price,b.LowPrice from selldetail a left join GoodsUnit b on a.goodsid=b.goodsid where a.Billid=@Billid";
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
