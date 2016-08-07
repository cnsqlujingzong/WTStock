using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALExpense
	{
		public int Add(ExpenseInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "_Date";
			text2 = text2 + "'" + model._Date + "'";
			if (model.OperatorID > 0)
			{
				text += ",OperatorID";
				text2 = text2 + "," + model.OperatorID.ToString();
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.dMoney > 0m)
			{
				text += ",dMoney";
				text2 = text2 + "," + model.dMoney.ToString();
			}
			if (model.Status != string.Empty)
			{
				text += ",Status";
				text2 = text2 + ",'" + model.Status + "'";
			}
			if (model.Summary != string.Empty)
			{
				text += ",Summary";
				text2 = text2 + ",'" + model.Summary + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.Accessory != string.Empty)
			{
				text += ",Accessory";
				text2 = text2 + ",'" + model.Accessory + "'";
			}
			if (model.ChkOperatorID > 0)
			{
				text += ",ChkOperatorID";
				text2 = text2 + "," + model.ChkOperatorID.ToString();
			}
			if (model.ChkDate != string.Empty)
			{
				text += ",ChkDate";
				text2 = text2 + ",'" + model.ChkDate + "'";
			}
			if (model.RelatedBusiness != string.Empty)
			{
				text += ",RelatedBusiness";
				text2 = text2 + ",'" + model.RelatedBusiness + "'";
			}
			if (model.FromAdr != string.Empty)
			{
				text += ",FromAdr";
				text2 = text2 + ",'" + model.FromAdr + "'";
			}
			if (model.ToAdr != string.Empty)
			{
				text += ",ToAdr";
				text2 = text2 + ",'" + model.ToAdr + "'";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"zk_bx_kd"
			});
			if (model.ExpenseDetailInfos != null)
			{
				foreach (ExpenseDetailInfo current in model.ExpenseDetailInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "ItemID";
					text2 += current.ItemID.ToString();
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
					array[2] = "zk_bx_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(ExpenseInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "OperatorID=" + model.OperatorID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			text = text + ",dMoney=" + model.dMoney.ToString();
			text = text + ",Summary='" + model.Summary + "'";
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",Accessory='" + model.Accessory + "'";
			text = text + ",RelatedBusiness='" + model.RelatedBusiness + "'";
			list.Add(new string[]
			{
				"Expense",
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
			if (model.ExpenseDetailInfos != null)
			{
				foreach (ExpenseDetailInfo current in model.ExpenseDetailInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "ItemID";
						text += current.ItemID.ToString();
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
						array2[2] = "zk_bx_kdmx";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "ItemID=" + current.ItemID.ToString();
						text = text + ",Price=" + current.Price.ToString();
						text = text + ",Remark='" + current.Remark + "'";
						array2[0] = "ExpenseDetail";
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

		public int UpdateChk(ExpenseInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "ChkOperatorID=" + model.ChkOperatorID.ToString();
			text = text + ",ChkDate='" + model.ChkDate + "'";
			text += ",Status='待发放'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("Expense", text, " [ID]=" + model.ID.ToString(), " 1=2 ", " Status='待审核' and [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int BackChk(ExpenseInfo model, string strSatus, out string strMsg)
		{
			string text = string.Empty;
			text = text + "PaymentOperID=" + model.PaymentOperID.ToString();
			text = text + ",PaymentDate='" + model.PaymentDate + "'";
			text = text + ",Status='" + strSatus + "'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("Expense", text, " [ID]=" + model.ID.ToString(), " 1=2 ", " Status='待发放' and [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int UpdateCancel(ExpenseInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "ChkOperatorID=" + model.ChkOperatorID.ToString();
			text = text + ",ChkDate='" + model.ChkDate + "'";
			text += ",Status='已取消'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("Expense", text, " [ID]=" + model.ID.ToString(), " 1=2 ", " Status='待审核' and [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int ExpPayChk(ExpenseInfo model, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@PaymentOperID", SqlDbType.Int),
				new SqlParameter("@PaymentDate", SqlDbType.VarChar, 50),
				new SqlParameter("@AccountID", SqlDbType.Int),
				new SqlParameter("@ItemID", SqlDbType.Int),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = model.ID;
			array[1].Value = model.PaymentOperID;
			array[2].Value = model.PaymentDate;
			array[3].Value = model.AccountID;
			array[4].Value = model.ItemID;
			array[5].Value = model.Remark;
			array[6].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zk_bx_pay", array);
			strMsg = Convert.ToString(array[6].Value);
			return result;
		}

		public int ExpChkU(int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zk_bx_ChkU", array);
			strMsg = Convert.ToString(array[1].Value);
			return result;
		}

		public int ExpDel(int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zk_bx_del", array);
			strMsg = Convert.ToString(array[1].Value);
			return result;
		}

		public ExpenseInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from Expense ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ExpenseInfo expenseInfo = new ExpenseInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			expenseInfo.ID = ID;
			ExpenseInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					expenseInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				expenseInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					expenseInfo.OperatorID = int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["dMoney"].ToString() != "")
				{
					expenseInfo.dMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["dMoney"].ToString());
				}
				expenseInfo.Summary = dataSet.Tables[0].Rows[0]["Summary"].ToString();
				expenseInfo.Accessory = dataSet.Tables[0].Rows[0]["Accessory"].ToString();
				expenseInfo.Status = dataSet.Tables[0].Rows[0]["Status"].ToString();
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					expenseInfo.ChkOperatorID = int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					expenseInfo.ChkDate = dataSet.Tables[0].Rows[0]["ChkDate"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["PaymentOperID"].ToString() != "")
				{
					expenseInfo.PaymentOperID = int.Parse(dataSet.Tables[0].Rows[0]["PaymentOperID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["PaymentDate"].ToString() != "")
				{
					expenseInfo.PaymentDate = dataSet.Tables[0].Rows[0]["PaymentDate"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["AccountID"].ToString() != "")
				{
					expenseInfo.AccountID = int.Parse(dataSet.Tables[0].Rows[0]["AccountID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ItemID"].ToString() != "")
				{
					expenseInfo.ItemID = int.Parse(dataSet.Tables[0].Rows[0]["ItemID"].ToString());
				}
				expenseInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				expenseInfo.RelatedBusiness = dataSet.Tables[0].Rows[0]["RelatedBusiness"].ToString();
				result = expenseInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public DataSet GetExpenseItem(string sWhere)
		{
			string sQLString = "select _Name from ExpenseItem where 1=1 " + sWhere;
			return DbHelperSQL.Query(sQLString);
		}
	}
}
