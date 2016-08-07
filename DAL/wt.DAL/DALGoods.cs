using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALGoods
	{
		public int Add(GoodsInfo model, bool bsys, out string strMsg, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			if (!bsys)
			{
				if (model.GoodsNO != string.Empty)
				{
					text += ",GoodsNO";
					text2 = text2 + ",'" + model.GoodsNO + "'";
				}
			}
			if (model.ClassID > 0)
			{
				text += ",ClassID";
				text2 = text2 + "," + model.ClassID.ToString();
			}
			if (model.Attr != string.Empty)
			{
				text += ",Attr";
				text2 = text2 + ",'" + model.Attr + "'";
			}
			if (model.Spec != string.Empty)
			{
				text += ",Spec";
				text2 = text2 + ",'" + model.Spec + "'";
			}
			if (model.BrandID > 0)
			{
				text += ",BrandID";
				text2 = text2 + "," + model.BrandID.ToString();
			}
			if (model.MainTenancePeriod != string.Empty)
			{
				text += ",MainTenancePeriod";
				text2 = text2 + ",'" + model.MainTenancePeriod + "'";
			}
			text += ",CostMode";
			text2 = text2 + "," + model.CostMode.ToString();
			if (model.ForProducts != string.Empty)
			{
				text += ",ForProducts";
				text2 = text2 + ",'" + model.ForProducts + "'";
			}
			if (model.StockID > 0)
			{
				text += ",StockID";
				text2 = text2 + "," + model.StockID.ToString();
			}
			if (model.ProvID > 0)
			{
				text += ",ProvID";
				text2 = text2 + "," + model.ProvID.ToString();
			}
			if (model.Valid > 0)
			{
				text += ",Valid";
				text2 = text2 + "," + model.Valid.ToString();
			}
			if (model.pyCode != string.Empty)
			{
				text += ",pyCode";
				text2 = text2 + ",'" + model.pyCode + "'";
			}
            if (model.PCB != string.Empty)
            {
                text += ",PCB";
                text2 = text2 + ",'" + model.PCB + "'";
            }
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.bIncrement)
			{
				text += ",bIncrement";
				text2 += ",1";
			}
			if (model.bStock)
			{
				text += ",bStock";
				text2 += ",1";
			}
			if (model.bStop)
			{
				text += ",bStop";
				text2 += ",1";
			}
			if (model.bSNTrack)
			{
				text += ",bSNTrack";
				text2 += ",1";
			}
			if (model.PicPath != string.Empty)
			{
				text += ",PicPath";
				text2 = text2 + ",'" + model.PicPath + "'";
			}
			if (model.userdef1 != string.Empty)
			{
				text += ",userdef1";
				text2 = text2 + ",'" + model.userdef1 + "'";
			}
			if (model.userdef2 != string.Empty)
			{
				text += ",userdef2";
				text2 = text2 + ",'" + model.userdef2 + "'";
			}
			if (model.userdef3 != string.Empty)
			{
				text += ",userdef3";
				text2 = text2 + ",'" + model.userdef3 + "'";
			}
			if (model.userdef4 != string.Empty)
			{
				text += ",userdef4";
				text2 = text2 + ",'" + model.userdef4 + "'";
			}
			if (model.userdef5 != string.Empty)
			{
				text += ",userdef5";
				text2 = text2 + ",'" + model.userdef5 + "'";
			}
			if (model.userdef6 != string.Empty)
			{
				text += ",userdef6";
				text2 = text2 + ",'" + model.userdef6 + "'";
			}
			string[] array = new string[8];
			array[0] = "Goods";
			array[1] = text;
			array[2] = text2;
			array[3] = " GoodsNO='" + model.GoodsNO + "' ";
			array[4] = "产品编号";
			array[5] = "ID";
			if (bsys)
			{
				array[6] = "GoodsNO";
				array[7] = "7";
			}
			list.Add(array);
			if (model.GoodsUnitInfos != null)
			{
				foreach (GoodsUnitInfo current in model.GoodsUnitInfos)
				{
					string[] array2 = new string[7];
					text = string.Empty;
					text2 = string.Empty;
					text += "UnitRelation";
					text2 += current.UnitRelation.ToString();
					if (current.UnitID > 0)
					{
						text += ",UnitID";
						text2 = text2 + "," + current.UnitID.ToString();
					}
					if (current.BarCode != string.Empty)
					{
						text += ",BarCode";
						text2 = text2 + ",'" + current.BarCode + "'";
					}
					if (current.bBase)
					{
						text += ",bBase";
						text2 += ",1";
					}
					if (current.PriceDetail > 0m)
					{
						text += ",PriceDetail";
						text2 = text2 + "," + current.PriceDetail.ToString();
					}
					if (current.PriceCost > 0m)
					{
						text += ",PriceCost";
						text2 = text2 + "," + current.PriceCost.ToString();
					}
					if (current.PriceInner > 0m)
					{
						text += ",PriceInner";
						text2 = text2 + "," + current.PriceInner.ToString();
					}
					if (current.PriceWholesale1 > 0m)
					{
						text += ",PriceWholesale1";
						text2 = text2 + "," + current.PriceWholesale1.ToString();
					}
					if (current.PriceWholesale2 > 0m)
					{
						text += ",PriceWholesale2";
						text2 = text2 + "," + current.PriceWholesale2.ToString();
					}
					if (current.PriceWholesale3 > 0m)
					{
						text += ",PriceWholesale3";
						text2 = text2 + "," + current.PriceWholesale3.ToString();
					}
					if (current.LowPrice > 0m)
					{
						text += ",LowPrice";
						text2 = text2 + "," + current.LowPrice;
					}
					array2[0] = "GoodsUnit";
					array2[1] = text;
					array2[2] = text2;
					array2[3] = " UnitID=" + current.UnitID.ToString();
					array2[4] = "产品单位";
					array2[5] = "ID";
					array2[6] = "GoodsID";
					list.Add(array2);
				}
			}
			if (model.DisMountingInfos != null)
			{
				foreach (DisMountingInfo current2 in model.DisMountingInfos)
				{
					string[] array2 = new string[7];
					text = string.Empty;
					text2 = string.Empty;
					text += "GoodsID";
					text2 += current2.GoodsID.ToString();
					if (current2.Qty > 0m)
					{
						text += ",Qty";
						text2 = text2 + "," + current2.Qty.ToString();
					}
					array2[0] = "DisMounting";
					array2[1] = text;
					array2[2] = text2;
					array2[3] = " GoodsID=" + current2.GoodsID.ToString();
					array2[4] = "拆装产品";
					array2[5] = "ID";
					array2[6] = "DisMountingID";
					list.Add(array2);
				}
			}
			string[] array3 = new string[7];
			text = string.Empty;
			text2 = string.Empty;
			text += "DeptID";
			text2 += "1";
			array3[0] = "Stock";
			array3[1] = text;
			array3[2] = text2;
			array3[3] = " DeptID=1 ";
			array3[4] = "产品库存";
			array3[5] = "ID";
			array3[6] = "GoodsID";
			list.Add(array3);
			if (model.StockDeptInfos != null)
			{
				foreach (StockDeptInfo current3 in model.StockDeptInfos)
				{
					string[] array2 = new string[7];
					text = string.Empty;
					text2 = string.Empty;
					text += "StockID,DeptID";
					text2 = text2 + current3.StockID.ToString() + "," + current3.DeptID.ToString();
					if (current3.StockLocID > 0)
					{
						text += ",StockLocID";
						text2 = text2 + "," + current3.StockLocID.ToString();
					}
					array2[0] = "StockDept";
					array2[1] = text;
					array2[2] = text2;
					array2[3] = " StockID=" + current3.StockID.ToString();
					array2[4] = "产品库存";
					array2[5] = "ID";
					array2[6] = "GoodsID";
					list.Add(array2);
				}
			}
			return DbHelperSQL.RunManyProcedureTran("aa_insertdata", list, bsys, out strMsg, out iTbid);
		}

		public int Update(GoodsInfo model, bool bsys, string chkfld, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			if (!bsys)
			{
				text = text + ",GoodsNO='" + model.GoodsNO + "'";
			}
			if (model.ClassID > 0)
			{
				text = text + ",ClassID=" + model.ClassID.ToString();
			}
			else
			{
				text += ",ClassID=null";
			}
			text = text + ",Attr='" + model.Attr + "'";
			text = text + ",Spec='" + model.Spec + "'";
			if (model.BrandID > 0)
			{
				text = text + ",BrandID=" + model.BrandID.ToString();
			}
			else
			{
				text += ",BrandID=null";
			}
			text = text + ",MainTenancePeriod='" + model.MainTenancePeriod + "'";
			text = text + ",CostMode=" + model.CostMode.ToString();
			text = text + ",ForProducts='" + model.ForProducts + "'";
			if (model.StockID > 0)
			{
				text = text + ",StockID=" + model.StockID.ToString();
			}
			else
			{
				text += ",StockID=null";
			}
			if (model.ProvID > 0)
			{
				text = text + ",ProvID=" + model.ProvID.ToString();
			}
			else
			{
				text += ",ProvID=null";
			}
			text = text + ",Valid=" + model.Valid.ToString();
			text = text + ",pyCode='" + model.pyCode + "'";
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",userdef1='" + model.userdef1 + "'";
			text = text + ",userdef2='" + model.userdef2 + "'";
			text = text + ",userdef3='" + model.userdef3 + "'";
			text = text + ",userdef4='" + model.userdef4 + "'";
			text = text + ",userdef5='" + model.userdef5 + "'";
			text = text + ",userdef6='" + model.userdef6 + "'";
            text = text + ",PCB='" + model.PCB + "'";
			if (model.bIncrement)
			{
				text += ",bIncrement=1";
			}
			else
			{
				text += ",bIncrement=0";
			}
			if (model.bStock)
			{
				text += ",bStock=1";
			}
			else
			{
				text += ",bStock=0";
			}
			if (model.bStop)
			{
				text += ",bStop=1";
			}
			else
			{
				text += ",bStop=0";
			}
			if (model.bSNTrack)
			{
				text += ",bSNTrack=1";
			}
			else
			{
				text += ",bSNTrack=0";
			}
			text = text + ",PicPath='" + model.PicPath + "'";
			string[] array = new string[7];
			array[0] = "Goods";
			array[1] = text;
			array[2] = " [ID]=" + model.ID.ToString();
			array[3] = chkfld;
			array[4] = " [ID]=" + model.ID.ToString();
			if (bsys)
			{
				array[5] = "GoodsNO";
				array[6] = "7";
			}
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
			if (model.GoodsUnitInfos != null)
			{
				foreach (GoodsUnitInfo current in model.GoodsUnitInfos)
				{
					string[] array3 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "UnitRelation";
						text += current.UnitRelation.ToString();
						if (current.UnitID > 0)
						{
							text2 += ",UnitID";
							text = text + "," + current.UnitID.ToString();
						}
						if (current.BarCode != string.Empty)
						{
							text2 += ",BarCode";
							text = text + ",'" + current.BarCode + "'";
						}
						if (current.PriceDetail > 0m)
						{
							text2 += ",PriceDetail";
							text = text + "," + current.PriceDetail.ToString();
						}
						if (current.PriceCost > 0m)
						{
							text2 += ",PriceCost";
							text = text + "," + current.PriceCost.ToString();
						}
						if (current.PriceInner > 0m)
						{
							text2 += ",PriceInner";
							text = text + "," + current.PriceInner.ToString();
						}
						if (current.PriceWholesale1 > 0m)
						{
							text2 += ",PriceWholesale1";
							text = text + "," + current.PriceWholesale1.ToString();
						}
						if (current.PriceWholesale2 > 0m)
						{
							text2 += ",PriceWholesale2";
							text = text + "," + current.PriceWholesale2.ToString();
						}
						if (current.PriceWholesale3 > 0m)
						{
							text2 += ",PriceWholesale3";
							text = text + "," + current.PriceWholesale3.ToString();
						}
						if (current.LowPrice > 0m)
						{
							text2 += ",LowPrice";
							text = text + "," + current.LowPrice;
						}
						array3[0] = "GoodsUnit";
						array3[1] = text2;
						array3[2] = text;
						array3[3] = " UnitID=" + current.UnitID.ToString();
						array3[4] = "产品单位";
						array3[5] = "ID";
						array3[6] = "GoodsID";
						array3[7] = current.ID.ToString();
						array3[8] = model.ID.ToString();
						list.Add(array3);
					}
					else
					{
						text = string.Empty;
						text = text + "UnitRelation=" + current.UnitRelation.ToString();
						if (current.UnitID > 0)
						{
							text = text + ",UnitID=" + current.UnitID.ToString();
						}
						else
						{
							text += ",UnitID=null";
						}
						text = text + ",BarCode='" + current.BarCode + "'";
						text = text + ",PriceDetail=" + current.PriceDetail.ToString();
						text = text + ",PriceCost=" + current.PriceCost.ToString();
						text = text + ",PriceInner=" + current.PriceInner.ToString();
						text = text + ",PriceWholesale1=" + current.PriceWholesale1.ToString();
						text = text + ",PriceWholesale2=" + current.PriceWholesale2.ToString();
						text = text + ",PriceWholesale3=" + current.PriceWholesale3.ToString();
						text = text + ",LowPrice=" + current.LowPrice.ToString();
						array3[0] = "GoodsUnit";
						array3[1] = text;
						array3[2] = " [ID]=" + current.ID.ToString();
						array3[3] = "1=2";
						array3[4] = " [ID]=" + current.ID.ToString();
						array3[7] = current.ID.ToString();
						list.Add(array3);
					}
				}
			}
			if (model.DisMountingInfos != null)
			{
				foreach (DisMountingInfo current2 in model.DisMountingInfos)
				{
					string[] array3 = new string[9];
					if (current2.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "GoodsID";
						text += current2.GoodsID.ToString();
						if (current2.Qty > 0m)
						{
							text2 += ",Qty";
							text = text + "," + current2.Qty.ToString();
						}
						array3[0] = "DisMounting";
						array3[1] = text2;
						array3[2] = text;
						array3[3] = " GoodsID=" + current2.GoodsID.ToString();
						array3[4] = "拆装产品";
						array3[5] = "ID";
						array3[6] = "DisMountingID";
						array3[7] = current2.ID.ToString();
						array3[8] = model.ID.ToString();
						list.Add(array3);
					}
					else
					{
						text = string.Empty;
						text = text + "Qty=" + current2.Qty.ToString();
						array3[0] = "DisMounting";
						array3[1] = text;
						array3[2] = " [ID]=" + current2.ID.ToString();
						array3[3] = "1=2";
						array3[4] = " [ID]=" + current2.ID.ToString();
						array3[7] = current2.ID.ToString();
						list.Add(array3);
					}
				}
			}
			if (model.StockDeptInfos != null)
			{
				foreach (StockDeptInfo current3 in model.StockDeptInfos)
				{
					string[] array3 = new string[9];
					if (current3.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "StockID,DeptID";
						text = text + current3.StockID.ToString() + "," + current3.DeptID.ToString();
						if (current3.StockLocID > 0)
						{
							text2 += ",StockLocID";
							text = text + "," + current3.StockLocID.ToString();
						}
						array3[0] = "StockDept";
						array3[1] = text2;
						array3[2] = text;
						array3[3] = " StockID=" + current3.StockID.ToString();
						array3[4] = "产品库存";
						array3[5] = "ID";
						array3[6] = "GoodsID";
						array3[7] = current3.ID.ToString();
						array3[8] = model.ID.ToString();
						list.Add(array3);
					}
					else
					{
						text = string.Empty;
						if (current3.StockLocID > 0)
						{
							text = text + "StockLocID=" + current3.StockLocID.ToString();
						}
						else
						{
							text += "StockLocID=null";
						}
						array3[0] = "StockDept";
						array3[1] = text;
						array3[2] = " [ID]=" + current3.ID.ToString();
						array3[3] = "1=2";
						array3[4] = " [ID]=" + current3.ID.ToString();
						array3[7] = current3.ID.ToString();
						list.Add(array3);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, bsys, out strMsg);
		}

		public int GetID(string GoodsNO)
		{
			int result = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [ID] from Goods ");
			stringBuilder.Append(" where GoodsNO=@GoodsNO ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@GoodsNO", SqlDbType.VarChar, 50)
			};
			array[0].Value = GoodsNO;
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

		public GoodsInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select a.[ID],MainTenancePeriod,isnull(StockID,-1) as StockID,isnull(ProvID,-1) as ProvID,sl._Name as SupplierName,bStock,CostMode,Valid,bIncrement,a.bStop,bSNTrack,a.pyCode,a.Remark,GoodsNO,PCB,a._Name,isnull(a.ClassID,0) as ClassID,b._Name as Class,Spec,isnull(BrandID,-1) as BrandID,PicPath,ForProducts,Attr,isnull(UnitID,-1) as UnitID,BarCode,PriceDetail,PriceCost,PriceInner,PriceWholesale1,PriceWholesale2,PriceWholesale3,LowPrice,c.[ID] as GoodsUnitID,userdef1,userdef2,userdef3,userdef4,userdef5,userdef6 from Goods a left join GoodsClass b on a.ClassID=b.[ID] left join GoodsUnit c on a.[ID]=c.GoodsID left join SupplierList sl on ProvID=sl.ID ");
			stringBuilder.Append(" where c.bBase=1 and a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			GoodsInfo goodsInfo = new GoodsInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			GoodsInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					goodsInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["GoodsUnitID"].ToString() != "")
				{
					goodsInfo.GoodsUnitID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["GoodsUnitID"].ToString()));
				}
				goodsInfo.MainTenancePeriod = dataSet.Tables[0].Rows[0]["MainTenancePeriod"].ToString();
				if (dataSet.Tables[0].Rows[0]["StockID"].ToString() != "")
				{
					goodsInfo.StockID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["StockID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ProvID"].ToString() != "")
				{
					goodsInfo.ProvID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ProvID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["bStock"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStock"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStock"].ToString().ToLower() == "true")
					{
						goodsInfo.bStock = true;
					}
					else
					{
						goodsInfo.bStock = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["CostMode"].ToString() != "")
				{
					goodsInfo.CostMode = int.Parse(dataSet.Tables[0].Rows[0]["CostMode"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Valid"].ToString() != "")
				{
					goodsInfo.Valid = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Valid"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["bIncrement"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bIncrement"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bIncrement"].ToString().ToLower() == "true")
					{
						goodsInfo.bIncrement = true;
					}
					else
					{
						goodsInfo.bIncrement = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSNTrack"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSNTrack"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSNTrack"].ToString().ToLower() == "true")
					{
						goodsInfo.bSNTrack = true;
					}
					else
					{
						goodsInfo.bSNTrack = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bStop"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStop"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStop"].ToString().ToLower() == "true")
					{
						goodsInfo.bStop = true;
					}
					else
					{
						goodsInfo.bStop = false;
					}
				}
				goodsInfo.pyCode = dataSet.Tables[0].Rows[0]["pyCode"].ToString();
				goodsInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
                goodsInfo.PCB = dataSet.Tables[0].Rows[0]["PCB"].ToString();
				goodsInfo.GoodsNO = dataSet.Tables[0].Rows[0]["GoodsNO"].ToString();
				goodsInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["ClassID"].ToString() != "")
				{
					goodsInfo.ClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ClassID"].ToString()));
				}
				goodsInfo.Spec = dataSet.Tables[0].Rows[0]["Spec"].ToString();
				if (dataSet.Tables[0].Rows[0]["BrandID"].ToString() != "")
				{
					goodsInfo.BrandID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["BrandID"].ToString()));
				}
				goodsInfo.PicPath = dataSet.Tables[0].Rows[0]["PicPath"].ToString();
				goodsInfo.ForProducts = dataSet.Tables[0].Rows[0]["ForProducts"].ToString();
				goodsInfo.Attr = dataSet.Tables[0].Rows[0]["Attr"].ToString();
				goodsInfo.Class = dataSet.Tables[0].Rows[0]["Class"].ToString();
				if (dataSet.Tables[0].Rows[0]["UnitID"].ToString() != "")
				{
					goodsInfo.UnitID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["UnitID"].ToString()));
				}
				goodsInfo.BarCode = dataSet.Tables[0].Rows[0]["BarCode"].ToString();
				if (dataSet.Tables[0].Rows[0]["PriceDetail"].ToString() != "")
				{
					goodsInfo.PriceDetail = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["PriceDetail"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["PriceCost"].ToString() != "")
				{
					goodsInfo.PriceCost = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["PriceCost"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["PriceInner"].ToString() != "")
				{
					goodsInfo.PriceInner = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["PriceInner"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["PriceWholesale1"].ToString() != "")
				{
					goodsInfo.PriceWholesale1 = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["PriceWholesale1"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["PriceWholesale2"].ToString() != "")
				{
					goodsInfo.PriceWholesale2 = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["PriceWholesale2"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["PriceWholesale3"].ToString() != "")
				{
					goodsInfo.PriceWholesale3 = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["PriceWholesale3"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["LowPrice"].ToString() != "")
				{
					goodsInfo.LowPrice = decimal.Parse(dataSet.Tables[0].Rows[0]["LowPrice"].ToString());
				}
				goodsInfo.userdef1 = dataSet.Tables[0].Rows[0]["userdef1"].ToString();
				goodsInfo.userdef2 = dataSet.Tables[0].Rows[0]["userdef2"].ToString();
				goodsInfo.userdef3 = dataSet.Tables[0].Rows[0]["userdef3"].ToString();
				goodsInfo.userdef4 = dataSet.Tables[0].Rows[0]["userdef4"].ToString();
				goodsInfo.userdef5 = dataSet.Tables[0].Rows[0]["userdef5"].ToString();
				goodsInfo.userdef6 = dataSet.Tables[0].Rows[0]["userdef6"].ToString();
				goodsInfo.SupplierName = dataSet.Tables[0].Rows[0]["SupplierName"].ToString();
				result = goodsInfo;
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
			case 0:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (GoodsNO like '%",
					strcon,
					"%' or _Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%' or Spec like '%",
					strcon,
					"%' or Attr like '%",
					strcon,
					"%' or Provider like '%",
					strcon,
					"%' or SuppLierCode like '%",
					strcon,
					"%' or ProductBrand like '%",
					strcon,
					"%' or BrandCode like '%",
					strcon,
					"%' or MaintenancePeriod like '%",
					strcon,
					"%' or StockName like '%",
					strcon,
					"%' or Remark like '%",
					strcon,
					"%' or userdef1 like '%",
					strcon,
					"%' or userdef2 like '%",
					strcon,
					"%' or userdef3 like '%",
					strcon,
					"%' or userdef4 like '%",
					strcon,
					"%' or userdef5 like '%",
					strcon,
					"%' or userdef6 like '%",
					strcon,
					"%' or ForProducts like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 1:
				text = text + " and GoodsNO like '%" + strcon + "%' ";
				break;
			case 2:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (_Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 3:
				text = text + " and Spec like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and Attr like '%" + strcon + "%' ";
				break;
			case 5:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Provider like '%",
					strcon,
					"%' or SuppLierCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 6:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductBrand like '%",
					strcon,
					"%' or BrandCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 7:
				text = text + " and MaintenancePeriod like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and StockName like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 10:
				text = text + " and ForProducts like '%" + strcon + "%'";
				break;
			}
			return text;
		}

		public int InputGoods(int ideptid, int igoodsclassid, string strname, string strno, string strattr, string strspec, string strbrand, string strunit, decimal ddetail, decimal dcost, decimal dinner, decimal dwho1, decimal dwho2, decimal dwho3, string strprot, string strbarcode, int icostmode, string strforproduct, string strstock, string strprovider, int ivalid, bool bstock, string strremark, string struserdef1, string struserdef2, string struserdef3, string struserdef4, string struserdef5, string struserdef6, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ideptid", SqlDbType.Int),
				new SqlParameter("@igoodsclassid", SqlDbType.Int),
				new SqlParameter("@strname", SqlDbType.NVarChar, 50),
				new SqlParameter("@strno", SqlDbType.NVarChar, 50),
				new SqlParameter("@strattr", SqlDbType.NVarChar, 50),
				new SqlParameter("@strspec", SqlDbType.NVarChar, 50),
				new SqlParameter("@strbrand", SqlDbType.NVarChar, 50),
				new SqlParameter("@strunit", SqlDbType.NVarChar, 50),
				new SqlParameter("@ddetail", SqlDbType.Decimal),
				new SqlParameter("@dcost", SqlDbType.Decimal),
				new SqlParameter("@dinner", SqlDbType.Decimal),
				new SqlParameter("@dwho1", SqlDbType.Decimal),
				new SqlParameter("@dwho2", SqlDbType.Decimal),
				new SqlParameter("@dwho3", SqlDbType.Decimal),
				new SqlParameter("@strprot", SqlDbType.NVarChar, 50),
				new SqlParameter("@strbarcode", SqlDbType.NVarChar, 50),
				new SqlParameter("@icostmode", SqlDbType.Int),
				new SqlParameter("@strforproduct", SqlDbType.NVarChar, 50),
				new SqlParameter("@strstock", SqlDbType.NVarChar, 50),
				new SqlParameter("@strprovider", SqlDbType.NVarChar, 50),
				new SqlParameter("@ivalid", SqlDbType.Int),
				new SqlParameter("@bstock", SqlDbType.Bit),
				new SqlParameter("@strremark", SqlDbType.NVarChar, 2000),
				new SqlParameter("@struserdef1", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef2", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef3", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef4", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef5", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef6", SqlDbType.NVarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = ideptid;
			array[1].Value = igoodsclassid;
			array[2].Value = strname;
			array[3].Value = strno;
			array[4].Value = strattr;
			array[5].Value = strspec;
			array[6].Value = strbrand;
			array[7].Value = strunit;
			array[8].Value = ddetail;
			array[9].Value = dcost;
			array[10].Value = dinner;
			array[11].Value = dwho1;
			array[12].Value = dwho2;
			array[13].Value = dwho3;
			array[14].Value = strprot;
			array[15].Value = strbarcode;
			array[16].Value = icostmode;
			array[17].Value = strforproduct;
			array[18].Value = strstock;
			array[19].Value = strprovider;
			array[20].Value = ivalid;
			array[21].Value = bstock;
			array[22].Value = strremark;
			array[23].Value = struserdef1;
			array[24].Value = struserdef2;
			array[25].Value = struserdef3;
			array[26].Value = struserdef4;
			array[27].Value = struserdef5;
			array[28].Value = struserdef6;
			array[29].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_inputgoods", array);
			strMsg = Convert.ToString(array[29].Value);
			return result;
		}

		public void UpdateClass(string strid, int icbGoodType, int iDefaultstock, int ibStock, int ibSNTrack, int iMainTenancePeriod, string strclassid, int int_stockid, int int_bStock, int int_bSNtrack, string str_MainTenancePeriod)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder.Append("update Goods set ");
			if (icbGoodType == 1)
			{
				if (strclassid == "0")
				{
					stringBuilder2.Append("ClassID=null");
				}
				else
				{
					stringBuilder2.Append("ClassID=" + strclassid);
				}
			}
			if (iDefaultstock == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("StockID=" + int_stockid);
				}
				else
				{
					stringBuilder2.Append(",StockID=" + int_stockid);
				}
			}
			if (ibStock == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("bStock=" + int_bStock);
				}
				else
				{
					stringBuilder2.Append(",bStock=" + int_bStock);
				}
			}
			if (ibSNTrack == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("bSNTrack=" + int_bSNtrack);
				}
				else
				{
					stringBuilder2.Append(",bSNTrack=" + int_bSNtrack);
				}
			}
			if (iMainTenancePeriod == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("MainTenancePeriod='" + str_MainTenancePeriod + "'");
				}
				else
				{
					stringBuilder2.Append(",MainTenancePeriod='" + str_MainTenancePeriod + "'");
				}
			}
			stringBuilder.Append(stringBuilder2.ToString());
			stringBuilder.Append(" where ID in(" + strid + ")");
			DbHelperSQL.ExecuteSql(stringBuilder.ToString());
		}

		public int CheckGoodsClass(string classname)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("declare @id int;set @id=0;select top 1 @id=ID from GoodsClass where _Name=@ClassName;if @id>0 select @id ");
			stringBuilder.Append("else begin exec aa_getnewkey 'GoodsClass',@id output insert into GoodsClass(_Name,Father,Array,_Level,ID)values(@ClassName,-1,0,'0'+convert(varchar,@id),@id);select @id  end");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ClassName", SqlDbType.VarChar, 100)
			};
			array[0].Value = classname;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			int result;
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				result = -1;
			}
			else
			{
				result = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
			}
			return result;
		}

		public decimal getLowPrice(int goodsid)
		{
			string sQLString = " select LowPrice from GoodsUnit where GoodsID=@GoodsID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@GoodsID", SqlDbType.Int, 4)
			};
			array[0].Value = goodsid;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			decimal result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = decimal.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0m;
			return result;
		}
	}
}
