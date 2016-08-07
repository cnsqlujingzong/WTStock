using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALAllocate
	{
		public int Add(AllocateInfo model, out int iTbid)
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
			if (model.FromDept > 0)
			{
				text += ",FromDept";
				text2 = text2 + "," + model.FromDept.ToString();
			}
			if (model.ToDept > 0)
			{
				text += ",ToDept";
				text2 = text2 + "," + model.ToDept.ToString();
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
				"ck_db_kd"
			});
			if (model.AllocateDetailInfos != null)
			{
				foreach (AllocateDetailInfo current in model.AllocateDetailInfos)
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
					if (current.AppQty > 0m)
					{
						text += ",AppQty";
						text2 = text2 + "," + current.AppQty.ToString();
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
					array[0] = text;
					array[1] = text2;
					array[2] = "ck_db_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(AllocateInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			text = text + "Remark='" + model.Remark + "'";
			if (model.StockID > 0)
			{
				text = text + ",StockID=" + model.StockID.ToString();
			}
			else
			{
				text += ",StockID=null";
			}
			list.Add(new string[]
			{
				"Allocate",
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
			if (model.AllocateDetailInfos != null)
			{
				foreach (AllocateDetailInfo current in model.AllocateDetailInfos)
				{
					string[] array2 = new string[9];
					text = string.Empty;
					text = text + "SndQty=" + current.SndQty.ToString();
					text = text + ",AppQty=" + current.AppQty.ToString();
					text = text + ",Price=" + current.Price.ToString();
					if (current.RecQty > 0m)
					{
						text = text + ",RecQty=" + current.RecQty.ToString();
					}
					else
					{
						text += ",RecQty=0";
					}
					text = text + ",Remark='" + current.Remark + "'";
					text = text + ",SN='" + current.SN + "'";
					array2[0] = "AllocateDetail";
					array2[1] = text;
					array2[2] = " [ID]=" + current.ID.ToString();
					array2[3] = "";
					array2[4] = current.ID.ToString();
					list.Add(array2);
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public int UpdateMod(AllocateInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "PersonID=" + model.PersonID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",ToDept=" + model.ToDept.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			if (model.FromDept > 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					",FromDept='",
					model.FromDept,
					"'"
				});
			}
			list.Add(new string[]
			{
				"Allocate",
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
			if (model.AllocateDetailInfos != null)
			{
				foreach (AllocateDetailInfo current in model.AllocateDetailInfos)
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
						if (current.AppQty > 0m)
						{
							text2 += ",AppQty";
							text = text + "," + current.AppQty.ToString();
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
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "ck_db_kdmx";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "GoodsID=" + current.GoodsID.ToString();
						text = text + ",UnitID=" + current.UnitID.ToString();
						text = text + ",AppQty=" + current.AppQty.ToString();
						text = text + ",Price=" + current.Price.ToString();
						text = text + ",Remark='" + current.Remark + "'";
						array2[0] = "AllocateDetail";
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

		public AllocateInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,SignedDate,SignedOperID,Remark,BillID,_Date,PersonID,isnull(FromDept,0) as FromDept,isnull(ToDept,0) as ToDept,Status,SndDate,SndOperID,isnull(StockID,0) as StockID from Allocate ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			AllocateInfo allocateInfo = new AllocateInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			AllocateInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					allocateInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				allocateInfo.SignedDate = dataSet.Tables[0].Rows[0]["SignedDate"].ToString();
				if (dataSet.Tables[0].Rows[0]["SignedOperID"].ToString() != "")
				{
					allocateInfo.SignedOperID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SignedOperID"].ToString()));
				}
				allocateInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				allocateInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				allocateInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["PersonID"].ToString() != "")
				{
					allocateInfo.PersonID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["PersonID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["FromDept"].ToString() != "")
				{
					allocateInfo.FromDept = new int?(int.Parse(dataSet.Tables[0].Rows[0]["FromDept"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ToDept"].ToString() != "")
				{
					allocateInfo.ToDept = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ToDept"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					allocateInfo.Status = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString()));
				}
				allocateInfo.SndDate = dataSet.Tables[0].Rows[0]["SndDate"].ToString();
				if (dataSet.Tables[0].Rows[0]["SndOperID"].ToString() != "")
				{
					allocateInfo.SndOperID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SndOperID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["StockID"].ToString() != "")
				{
					allocateInfo.StockID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["StockID"].ToString()));
				}
				result = allocateInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int GetIds(string ids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID from Allocate ");
			stringBuilder.Append(" where BillID=@BillID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.VarChar, 50)
			};
			array[0].Value = ids;
			int result = 0;
			AllocateInfo allocateInfo = new AllocateInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
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
					" and (Person like '%",
					strcon,
					"%' or PersonNO like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 4:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (FromDept like '%",
					strcon,
					"%' or FromDeptCode like '%",
					strcon,
					"%' or FromDeptNO like '%",
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
					" and (ToDept like '%",
					strcon,
					"%' or ToDeptCode like '%",
					strcon,
					"%' or ToDeptNO like '%",
					strcon,
					"%') "
				});
				break;
			}
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
					"%') "
				});
				break;
			}
			case 8:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and SndDate ='" + strcon + "' ";
				break;
			case 10:
				text = text + " and SndOper like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public int ChkAllocate(int iTbid, int iOperator, decimal dXSJE, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@dXSJE", SqlDbType.Decimal),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = dXSJE;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_db_chk", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkAllocateCancel(int iTbid, int iOperator, string strRemark, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strRemark", SqlDbType.NVarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = strRemark;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_db_bh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkAllocateRec(int iTbid, int iOperator, string snddate, int sndstyle, string postno, decimal postage, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@snddate", SqlDbType.NVarChar, 50),
				new SqlParameter("@sndstyle", SqlDbType.Int),
				new SqlParameter("@postno", SqlDbType.NVarChar, 50),
				new SqlParameter("@postage", SqlDbType.Decimal, 9),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = snddate;
			array[3].Value = sndstyle;
			array[4].Value = postno;
			array[5].Value = postage;
			array[6].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_db_rec", array);
			strMsg = Convert.ToString(array[6].Value);
			return result;
		}

		public int ChkAllocateRecBack(int iTbid, int iOperator, string strRemark, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strRemark", SqlDbType.NVarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = strRemark;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_dbrec_bh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkAllocateSign(int iTbid, int iOperator, string rcvdate, int iStock, decimal dXFJE, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@rcvdate", SqlDbType.NVarChar, 50),
				new SqlParameter("@iStock", SqlDbType.Int),
				new SqlParameter("@dXFJE", SqlDbType.Decimal, 9),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = rcvdate;
			array[3].Value = iStock;
			array[4].Value = dXFJE;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_db_sign", array);
			strMsg = Convert.ToString(array[5].Value);
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
			int result = DbHelperSQL.RunProcedureTran("ck_db_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ChkErrorDo(int iDept, int iType, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@iType", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iDept;
			array[1].Value = iType;
			array[2].Value = iTbid;
			array[3].Value = iOperator;
			array[4].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ck_db_error", array);
			strMsg = Convert.ToString(array[4].Value);
			return result;
		}

		public void UpdateChk(int id)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Allocate set ");
			stringBuilder.Append("Status=1,");
			stringBuilder.Append("ChkDate=null,");
			stringBuilder.Append("ChkOperatorID=null");
			stringBuilder.Append(" where ID=" + id.ToString());
			DbHelperSQL.ExecuteSql(stringBuilder.ToString());
		}
	}
}
