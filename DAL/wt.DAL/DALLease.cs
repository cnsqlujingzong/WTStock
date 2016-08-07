using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALLease
	{
		public int Add(LeaseInfo model, int bchk, int iflag, out int iTbid, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			if (model.OperatorID > 0)
			{
				text += "OperatorID";
				text2 += model.OperatorID.ToString();
			}
			if (model._Date != "")
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
				text += ",ChargeDate";
				text2 = text2 + ",'" + model._Date + "'";
				text += ",ReadingDate";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.SellerID > 0)
			{
				text += ",SellerID";
				text2 = text2 + "," + model.SellerID.ToString();
			}
			if (model.Type > 0)
			{
				text += ",Type";
				text2 = text2 + "," + model.Type.ToString();
			}
			text += ",Status";
			text2 = text2 + "," + model.Status.ToString();
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
			if (model.ContractNO != string.Empty)
			{
				text += ",ContractNO";
				text2 = text2 + ",'" + model.ContractNO + "'";
			}
			if (model.CustomerName != string.Empty)
			{
				text += ",CustomerName";
				text2 = text2 + ",'" + model.CustomerName + "'";
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
			if (model.Accessory != string.Empty)
			{
				text += ",Accessory";
				text2 = text2 + ",'" + model.Accessory + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.Deposit > 0m)
			{
				text += ",Deposit";
				text2 = text2 + "," + model.Deposit.ToString();
			}
			if (model.StartDate != "")
			{
				text += ",StartDate";
				text2 = text2 + ",'" + model.StartDate + "'";
			}
			if (model.EndDate != "")
			{
				text += ",EndDate";
				text2 = text2 + ",'" + model.EndDate + "'";
			}
			if (model.Rent > 0m)
			{
				text += ",Rent";
				text2 = text2 + "," + model.Rent.ToString();
			}
			if (model.ChargeCycle > 0)
			{
				text += ",ChargeCycle";
				text2 = text2 + "," + model.ChargeCycle.ToString();
			}
			if (model.ChargeStyle > 0)
			{
				text += ",ChargeStyle";
				text2 = text2 + "," + model.ChargeStyle.ToString();
			}
			if (model.Rated > 0)
			{
				text += ",Rated";
				text2 = text2 + "," + model.Rated.ToString();
			}
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
				"zl_zl_kd"
			});
			if (model.LeaseDeviceInfos != null)
			{
				foreach (LeaseDeviceInfo current in model.LeaseDeviceInfos)
				{
					string[] array = new string[4];
					text = string.Empty;
					text2 = string.Empty;
					text += "GoodsID";
					text2 += current.GoodsID.ToString();
					if (current.StockID > 0)
					{
						text += ",StockID";
						text2 = text2 + "," + current.StockID.ToString();
					}
					if (current.BrandID > 0)
					{
						text += ",BrandID";
						text2 = text2 + "," + current.BrandID.ToString();
					}
					if (current.ClassID > 0)
					{
						text += ",ClassID";
						text2 = text2 + "," + current.ClassID.ToString();
					}
					if (current.ModelID > 0)
					{
						text += ",ModelID";
						text2 = text2 + "," + current.ModelID.ToString();
					}
					if (current.ProductSN1 != "")
					{
						text += ",ProductSN1";
						text2 = text2 + ",'" + current.ProductSN1 + "'";
					}
					if (current.ProductSN2 != "")
					{
						text += ",ProductSN2";
						text2 = text2 + ",'" + current.ProductSN2 + "'";
					}
					if (current.DeviceNO != "")
					{
						text += ",DeviceNO";
						text2 = text2 + ",'" + current.DeviceNO + "'";
					}
					if (current.StrQty != string.Empty)
					{
						text += ",StrQty";
						text2 = text2 + ",'" + current.StrQty + "'";
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					text += ",iCount";
					text2 = text2 + "," + current.iCount.ToString();
					text += ",Status";
					text2 += ",'正常'";
					text += ",LeasePrice";
					text2 = text2 + "," + current.LeasePrice.ToString();
					array[0] = text;
					array[1] = text2;
					array[2] = "zl_zl_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.ZL_RunProcedureTran(list, bchk, iflag, model.OperatorID, out iTbid, out strMsg);
		}

		public int Update2(LeaseInfo model, string iOperator, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "SellerID=" + model.SellerID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",ChargeDate='" + model._Date + "'";
			text = text + ",Type=" + model.Type.ToString();
			text = text + ",CustomerID=" + model.CustomerID.ToString();
			text = text + ",CustomerName='" + model.CustomerName + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",ContractNO='" + model.ContractNO + "'";
			text = text + ",StartDate='" + model.StartDate + "'";
			text = text + ",EndDate='" + model.EndDate + "'";
			text = text + ",Rent=" + model.Rent.ToString();
			text = text + ",Deposit=" + model.Deposit.ToString();
			text = text + ",ChargeCycle=" + model.ChargeCycle.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",Accessory='" + model.Accessory + "'";
			string[] array = new string[5];
			array[0] = text;
			array[1] = model.ID.ToString();
			array[2] = iOperator;
			list.Add(array);
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array2 = strdellist[i];
				list2.Add(new string[]
				{
					array2[0].ToString(),
					" ID in(" + array2[1].ToString() + ")"
				});
			}
			if (model.LeaseDeviceInfos != null)
			{
				foreach (LeaseDeviceInfo current in model.LeaseDeviceInfos)
				{
					string[] array3 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "GoodsID";
						text += current.GoodsID.ToString();
						if (current.StockID > 0)
						{
							text2 += ",StockID";
							text = text + "," + current.StockID.ToString();
						}
						if (current.BrandID > 0)
						{
							text2 += ",BrandID";
							text = text + "," + current.BrandID.ToString();
						}
						if (current.ClassID > 0)
						{
							text2 += ",ClassID";
							text = text + "," + current.ClassID.ToString();
						}
						if (current.ModelID > 0)
						{
							text2 += ",ModelID";
							text = text + "," + current.ModelID.ToString();
						}
						if (current.ProductSN1 != "")
						{
							text2 += ",ProductSN1";
							text = text + ",'" + current.ProductSN1 + "'";
						}
						if (current.ProductSN2 != "")
						{
							text2 += ",ProductSN2";
							text = text + ",'" + current.ProductSN2 + "'";
						}
						if (current.DeviceNO != "")
						{
							text2 += ",DeviceNO";
							text = text + ",'" + current.DeviceNO + "'";
						}
						if (current.StrQty != string.Empty)
						{
							text2 += ",StrQty";
							text = text + ",'" + current.StrQty + "'";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						text2 += ",iCount";
						text = text + "," + current.iCount.ToString();
						text2 += ",Status";
						text += ",'正常'";
						text2 += ",LeasePrice";
						text = text + "," + current.LeasePrice.ToString();
						array3[0] = text2;
						array3[1] = text;
						array3[2] = "zl_zl_kdmx";
						array3[3] = model.ID.ToString();
						array3[4] = current.ID.ToString();
						list.Add(array3);
					}
					else
					{
						text = string.Empty;
						text = text + "StockID=" + current.StockID.ToString();
						text = text + ",GoodsID=" + current.GoodsID.ToString();
						if (current.BrandID > 0)
						{
							text = text + ",BrandID=" + current.BrandID.ToString();
						}
						else
						{
							text += ",BrandID=null";
						}
						if (current.ClassID > 0)
						{
							text = text + ",ClassID=" + current.ClassID.ToString();
						}
						else
						{
							text += ",ClassID=null";
						}
						if (current.ModelID > 0)
						{
							text = text + ",ModelID=" + current.ModelID.ToString();
						}
						else
						{
							text += ",ModelID=null";
						}
						text = text + ",ProductSN1='" + current.ProductSN1 + "'";
						text = text + ",ProductSN2='" + current.ProductSN2 + "'";
						text = text + ",DeviceNO='" + current.DeviceNO + "'";
						text = text + ",StrQty='" + current.StrQty + "'";
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",LeasePrice=" + current.LeasePrice;
						text = text + ",iCount=" + current.iCount;
						array3[0] = "LeaseDevice";
						array3[1] = text;
						array3[2] = " [ID]=" + current.ID.ToString();
						array3[3] = "";
						array3[4] = current.ID.ToString();
						list.Add(array3);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran("zl_mod", list, list2, out strMsg);
		}

		public int Update(LeaseInfo model, string iOperator, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string empty = string.Empty;
			text = text + "SellerID=" + model.SellerID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",CustomerID=" + model.CustomerID.ToString();
			text = text + ",CustomerName='" + model.CustomerName + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",ContractNO='" + model.ContractNO + "'";
			text = text + ",StartDate='" + model.StartDate + "'";
			text = text + ",EndDate='" + model.EndDate + "'";
			text = text + ",Rent=" + model.Rent.ToString();
			text = text + ",ChargeCycle=" + model.ChargeCycle.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",Accessory='" + model.Accessory + "'";
			string[] array = new string[5];
			array[0] = text;
			array[1] = model.ID.ToString();
			array[2] = iOperator;
			list.Add(array);
			return DbHelperSQL.UpdateManyProcedureTran("zl_mod", list, out strMsg);
		}

		public int UpdateAdd(LeaseInfo model, string iOperator, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "ContractNO='" + model.ContractNO + "'";
			text = text + ",StartDate='" + model.StartDate + "'";
			text = text + ",EndDate='" + model.EndDate + "'";
			text = text + ",Rent=" + model.Rent.ToString();
			text = text + ",ChargeCycle=" + model.ChargeCycle.ToString();
			text = text + ",Accessory='" + model.Accessory + "'";
			string[] array = new string[5];
			array[0] = text;
			array[1] = model.ID.ToString();
			array[2] = iOperator;
			list.Add(array);
			if (model.LeaseDeviceInfos != null)
			{
				foreach (LeaseDeviceInfo current in model.LeaseDeviceInfos)
				{
					string[] array2 = new string[4];
					text2 = string.Empty;
					text = string.Empty;
					text2 += "GoodsID";
					text += current.GoodsID.ToString();
					if (current.StockID > 0)
					{
						text2 += ",StockID";
						text = text + "," + current.StockID.ToString();
					}
					if (current.BrandID > 0)
					{
						text2 += ",BrandID";
						text = text + "," + current.BrandID.ToString();
					}
					if (current.ClassID > 0)
					{
						text2 += ",ClassID";
						text = text + "," + current.ClassID.ToString();
					}
					if (current.ModelID > 0)
					{
						text2 += ",ModelID";
						text = text + "," + current.ModelID.ToString();
					}
					if (current.ProductSN1 != "")
					{
						text2 += ",ProductSN1";
						text = text + ",'" + current.ProductSN1 + "'";
					}
					if (current.ProductSN2 != "")
					{
						text2 += ",ProductSN2";
						text = text + ",'" + current.ProductSN2 + "'";
					}
					if (current.DeviceNO != "")
					{
						text2 += ",DeviceNO";
						text = text + ",'" + current.DeviceNO + "'";
					}
					if (current.StrQty != string.Empty)
					{
						text2 += ",StrQty";
						text = text + ",'" + current.StrQty + "'";
					}
					if (current.Remark != string.Empty)
					{
						text2 += ",Remark";
						text = text + ",'" + current.Remark + "'";
					}
					text2 += ",iCount";
					text = text + "," + current.iCount.ToString();
					text2 += ",Status";
					text += ",'正常'";
					text2 += ",LeasePrice";
					text = text + "," + current.LeasePrice.ToString();
					array2[0] = text2;
					array2[1] = text;
					array2[2] = "zl_zl_kdmx";
					array2[3] = model.ID.ToString();
					list.Add(array2);
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran("zl_mod", list, out strMsg);
		}

		public int GetID(string BillID)
		{
			int result = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [ID] from Lease ");
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

		public int UpdateInPrice(List<string[]> StrParameters, out string strMsg)
		{
			return DbHelperSQL.UpdateMany(StrParameters, out strMsg);
		}

		public int LeaseChk(int iTbid, int iflag, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@flag", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iflag;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_zl_ck", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int LeaseChkU(int DeptID, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = DeptID;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_zl_cku", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int LeaseChargeChkU(int DeptID, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = DeptID;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_js_cku", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int LeaseChargeCancel(int iTbid, int iFlag, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iFlag;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_js_qx", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkChargeDel(int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("zl_js_del", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int ChkZLHJ(decimal doutprice, int inCount, int ingoodsID, int iTbid, int iBrand, int iClass, int iModel, string INSN, int iInStockid, decimal dPrice, int iGoodsid, int ioutstockid, int iOperatorID, string DeviceNO, string StrQty, decimal dCount, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@dOutPrice", SqlDbType.Decimal),
				new SqlParameter("@dInCount", SqlDbType.Int),
				new SqlParameter("@iInGoods", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iBrand", SqlDbType.Int),
				new SqlParameter("@iClass", SqlDbType.Int),
				new SqlParameter("@iModel", SqlDbType.Int),
				new SqlParameter("@INSN", SqlDbType.VarChar, 100),
				new SqlParameter("@iInStockid", SqlDbType.Int),
				new SqlParameter("@dPrice", SqlDbType.Decimal),
				new SqlParameter("@iOutGoodsid", SqlDbType.Int),
				new SqlParameter("@iOutStockid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@DeviceNO", SqlDbType.VarChar, 50),
				new SqlParameter("@StrQty", SqlDbType.VarChar, 3000),
				new SqlParameter("@dCount", SqlDbType.Decimal),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = doutprice;
			array[1].Value = inCount;
			array[2].Value = ingoodsID;
			array[3].Value = iTbid;
			array[4].Value = iBrand;
			array[5].Value = iClass;
			array[6].Value = iModel;
			array[7].Value = INSN;
			array[8].Value = iInStockid;
			array[9].Value = dPrice;
			array[10].Value = iGoodsid;
			array[11].Value = ioutstockid;
			array[12].Value = iOperatorID;
			array[13].Value = DeviceNO;
			array[14].Value = StrQty;
			array[15].Value = dCount;
			array[16].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_hj_crk", array);
			strMsg = Convert.ToString(array[16].Value);
			return result;
		}

		public int ChkZLTJ(int iTbid, int iInStockid, decimal dPrice, int iOperatorID, int iCount, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iStock", SqlDbType.Int),
				new SqlParameter("@dPrice", SqlDbType.Decimal),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@dCount", SqlDbType.Int, 4),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iInStockid;
			array[2].Value = dPrice;
			array[3].Value = iOperatorID;
			array[4].Value = iCount;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_tj", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}

		public int ChkRelease(int ideptid, int iTbid, int iOperator, int iPerson, int iStock, string strDate, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.VarChar, 100),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@iPerson", SqlDbType.Int),
				new SqlParameter("@iStock", SqlDbType.Int),
				new SqlParameter("@strDate", SqlDbType.VarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = ideptid;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Value = iPerson;
			array[4].Value = iStock;
			array[5].Value = strDate;
			array[6].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_ht_jy", array);
			strMsg = Convert.ToString(array[6].Value);
			return result;
		}

		public int ChkBln(int iDeptid, int iTbid, int iOperator, int iSKRid, string JsID, DateTime ChargeDate, decimal Amount, int iAccountid, decimal dInCash, string Remark, int iChargeStyle, string InvoiceDate, decimal InvoiceAmount, string InvoiceNO, int iInvoiceClass, int iItem, out string strMsg, decimal dDiscount)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@iSKRid", SqlDbType.Int),
				new SqlParameter("@JsID", SqlDbType.NVarChar, 100),
				new SqlParameter("@ChargeDate", SqlDbType.DateTime),
				new SqlParameter("@Amount", SqlDbType.Decimal),
				new SqlParameter("@iAccountid", SqlDbType.Int),
				new SqlParameter("@dInCash", SqlDbType.Decimal),
				new SqlParameter("@Remark", SqlDbType.NVarChar, 1000),
				new SqlParameter("@iChargeStyle", SqlDbType.Int),
				new SqlParameter("@InvoiceDate", SqlDbType.NVarChar, 50),
				new SqlParameter("@InvoiceAmount", SqlDbType.Decimal),
				new SqlParameter("@InvoiceNO", SqlDbType.NVarChar, 50),
				new SqlParameter("@iInvoiceClass", SqlDbType.Int),
				new SqlParameter("@iItem", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200),
				new SqlParameter("@dDiscount", SqlDbType.Decimal)
			};
			array[0].Value = iDeptid;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Value = iSKRid;
			array[4].Value = JsID;
			array[5].Value = ChargeDate;
			array[6].Value = Amount;
			array[7].Value = iAccountid;
			array[8].Value = dInCash;
			array[9].Value = Remark;
			array[10].Value = iChargeStyle;
			array[11].Value = InvoiceDate;
			array[12].Value = InvoiceAmount;
			array[13].Value = InvoiceNO;
			array[14].Value = iInvoiceClass;
			array[15].Value = iItem;
			array[16].Direction = ParameterDirection.Output;
			array[17].Value = dDiscount;
			int result = DbHelperSQL.RunProcedureTran("zl_js_ad", array);
			strMsg = Convert.ToString(array[16].Value);
			return result;
		}

		public int ChkCancel(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = 2;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_js_qx", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkLeaseCancel(int iTbid, int iOperator, string CancelReason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@CancelReason", SqlDbType.VarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = CancelReason;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zl_qx", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkDel(int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("zl_del", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public string GetSchWhere(int schid, string strcon)
		{
			string text = string.Empty;
			switch (schid)
			{
			case 0:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (BillID like '%",
					strcon,
					"%' or ID in(select BillID from zl_leasedevice where Model like '%",
					strcon,
					"%') or ID in(select BillID from zl_leasedevice where Brand like '%",
					strcon,
					"%') or ID in(select BillID from zl_leasedevice where Class like '%",
					strcon,
					"%') or ID in(select BillID from zl_leasedevice where ProductSN1 like '%",
					strcon,
					"%') or ID in(select BillID from zl_leasedevice where ProductSN2 like '%",
					strcon,
					"%') or CustomerName like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or Adr like '%",
					strcon,
					"%' or StartDate like '%",
					strcon,
					"%' or EndDate like '%",
					strcon,
					"%' or Seller like '%",
					strcon,
					"%' or Remark like '%",
					strcon,
					"%' or ContractNO like '%",
					strcon,
					"%' or Deposit like '%",
					strcon,
					"%' or Operator like '%",
					strcon,
					"%' or ID in(select BillID from zl_leasedevice where DeviceNO like '%",
					strcon,
					"%')) "
				});
				break;
			}
			case 1:
				text = text + " and BillID like '%" + strcon + "%' ";
				break;
			case 2:
				text = text + " and CustomerName like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and LinkMan like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and Tel like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and Adr like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and ID in(select BillID from zl_leasedevice where Model like '%" + strcon + "%') ";
				break;
			case 7:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and ID in(select BillID from zl_leasedevice where ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 8:
				text = text + " and ID in(select BillID from zl_leasedevice where Brand like '%" + strcon + "%') ";
				break;
			case 9:
				text = text + " and ID in(select BillID from zl_leasedevice where Class like '%" + strcon + "%') ";
				break;
			case 10:
				text = text + " and StartDate like '%" + strcon + "%' ";
				break;
			case 11:
				text = text + " and EndDate like '%" + strcon + "%' ";
				break;
			case 12:
				text = text + " and Seller like '%" + strcon + "%' ";
				break;
			case 13:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 14:
				text = text + " and curStatus like '%" + strcon + "%'";
				break;
			}
			return text;
		}

		public string GetDeviceWhere(int schid, string strcon)
		{
			string text = string.Empty;
			switch (schid)
			{
			case 0:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (strBillID like '%",
					strcon,
					"%' or Model like '%",
					strcon,
					"%' or Brand like '%",
					strcon,
					"%' or Class like '%",
					strcon,
					"%' or ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%' or CustomerName like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or Adr like '%",
					strcon,
					"%' or StartDate like '%",
					strcon,
					"%' or EndDate like '%",
					strcon,
					"%' or Seller like '%",
					strcon,
					"%' or Remark like '%",
					strcon,
					"%' or ContractNO like '%",
					strcon,
					"%' or Deposit like '%",
					strcon,
					"%' or Operator like '%",
					strcon,
					"%' or DeviceNO like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 1:
				text = text + " and strBillID like '%" + strcon + "%' ";
				break;
			case 2:
				text = text + " and CustomerName like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and LinkMan like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and Tel like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and Adr like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and Model like '%" + strcon + "%' ";
				break;
			case 7:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 8:
				text = text + " and Brand like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Class like '%" + strcon + "%' ";
				break;
			case 10:
				text = text + " and StartDate like '%" + strcon + "%' ";
				break;
			case 11:
				text = text + " and EndDate like '%" + strcon + "%' ";
				break;
			case 12:
				text = text + " and Seller like '%" + strcon + "%' ";
				break;
			case 13:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 14:
				text = text + " and curStatus like '%" + strcon + "%'";
				break;
			}
			return text;
		}

		public int Transpond(int id, int ibranch, int iOper)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Lease set DeptID=@ibranch where id=@id and status in(0,1);");
			stringBuilder.Append("if @@rowcount>0 insert into SysLog(OperatorID,_Date,Event)select @iOper,getdate(),'租赁单('+BillID+')转派(目标:'+(select top 1 _Name from BranchList where id=@ibranch)+')' from Lease where id=@id");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@ibranch", SqlDbType.Int, 4),
				new SqlParameter("@ioper", SqlDbType.Int, 4)
			};
			array[0].Value = id;
			array[1].Value = ibranch;
			array[2].Value = iOper;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int getCustomerID(int id)
		{
			string sQLString = " select customerid from lease where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int getLeaseType(int id)
		{
			StringBuilder stringBuilder = new StringBuilder("select [Type] from lease where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString(), array).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int updateCounter(int id, decimal rated, decimal supzhangfree, decimal costprice)
		{
			StringBuilder stringBuilder = new StringBuilder("update LeaseDetail set Rated=@Rated,SuperZhangFee=@SuperZhangFee,CostPrice=@CostPrice where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Rated", SqlDbType.Decimal),
				new SqlParameter("@SuperZhangFee", SqlDbType.Decimal),
				new SqlParameter("@CostPrice", SqlDbType.Decimal),
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = rated;
			array[1].Value = supzhangfree;
			array[2].Value = costprice;
			array[3].Value = id;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int getQtyType(string qtyName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID from QtyType where _Name=@name");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@name", SqlDbType.VarChar, 50)
			};
			array[0].Value = qtyName;
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString(), array).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int getLastDeviceID()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 ID from devicelist order by id desc");
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString()).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int getLastMeterReadingID()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 ID from MeterReading order by id desc");
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString()).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int insertValue(int id, int billid, int deviceid, int operatorid, int qtytype, int qty)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into MeterReading(ID,BillID,DeviceID,_Date,OperatorID,QtyType,Qty,Loss,WRemark)");
			stringBuilder.Append(" values(@ID,@BillID,@DeviceID,getdate(),@OperatorID,@QtyType,@Qty,0,'')");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@BillID", SqlDbType.Int),
				new SqlParameter("@DeviceID", SqlDbType.Int),
				new SqlParameter("@OperatorID", SqlDbType.Int),
				new SqlParameter("@QtyType", SqlDbType.Int),
				new SqlParameter("@Qty", SqlDbType.Int)
			};
			array[0].Value = id;
			array[1].Value = billid;
			array[2].Value = deviceid;
			array[3].Value = operatorid;
			array[4].Value = qtytype;
			array[5].Value = qty;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int getBillID(int id)
		{
			StringBuilder stringBuilder = new StringBuilder("select BillID from LeaseDevice where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString(), array).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int getLeaseDeviceID()
		{
			StringBuilder stringBuilder = new StringBuilder("select Top 1 ID from LeaseDetail order by ID desc");
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString()).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int insertLeaseValue(int id, int billid, int billid2, decimal rated, decimal zhangfee, int chargestyle, int qtytype, decimal costprice)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into LeaseDetail(ID,BillID,BillID2,BeginQty,Rated,SuperZhangFee,ChargeStyle,QtyType,Formula,ChargeDate,CostPrice)");
			stringBuilder.Append(" values(@ID,@BillID,@BillID2,@Rated,@SuperZhangFee,@ChargeStyle,@QtyType,'',getdate(),@CostPrice)");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@BillID", SqlDbType.Int),
				new SqlParameter("@BillID2", SqlDbType.Int),
				new SqlParameter("@Rated", SqlDbType.Decimal),
				new SqlParameter("@SuperZhangFee", SqlDbType.Decimal),
				new SqlParameter("@ChargeStyle", SqlDbType.Int),
				new SqlParameter("@QtyType", SqlDbType.Int),
				new SqlParameter("@CostPrice", SqlDbType.Decimal)
			};
			array[0].Value = id;
			array[1].Value = billid;
			array[2].Value = billid2;
			array[3].Value = rated;
			array[4].Value = zhangfee;
			array[5].Value = chargestyle;
			array[6].Value = qtytype;
			array[7].Value = costprice;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
