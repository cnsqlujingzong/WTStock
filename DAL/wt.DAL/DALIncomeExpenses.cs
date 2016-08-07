using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALIncomeExpenses
	{
		public int Add(IncomeExpensesInfo model, int iFlag, out int iTbid, out string strMsg)
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
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.RecType != string.Empty)
			{
				text += ",RecType";
				text2 = text2 + ",'" + model.RecType + "'";
			}
			if (model.CusType > 0)
			{
				text += ",CusType";
				text2 = text2 + "," + model.CusType.ToString();
			}
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID.ToString();
			}
			if (model.RecMoney > 0m)
			{
				text += ",RecMoney";
				text2 = text2 + "," + model.RecMoney.ToString();
			}
			if (model.InvoiceAmount > 0m)
			{
				text += ",InvoiceAmount";
				text2 = text2 + "," + model.InvoiceAmount.ToString();
			}
			if (model.InvoiceDate != string.Empty && model.InvoiceDate != null)
			{
				text += ",InvoiceDate";
				text2 = text2 + ",'" + model.InvoiceDate + "'";
			}
			if (model.RealRecMoney > 0m)
			{
				text += ",RealRecMoney";
				text2 = text2 + "," + model.RealRecMoney.ToString();
			}
			if (model.DueMoney > 0m)
			{
				text += ",DueMoney";
				text2 = text2 + "," + model.DueMoney.ToString();
			}
			if (model.RealDueMoney > 0m)
			{
				text += ",RealDueMoney";
				text2 = text2 + "," + model.RealDueMoney.ToString();
			}
			if (model.PreMoney > 0m)
			{
				text += ",PreMoney";
				text2 = text2 + "," + model.PreMoney.ToString();
			}
			if (model.ChargeModeID > 0)
			{
				text += ",ChargeModeID";
				text2 = text2 + "," + model.ChargeModeID.ToString();
			}
			if (model.AccountID > 0)
			{
				text += ",AccountID";
				text2 = text2 + "," + model.AccountID.ToString();
			}
			if (model.ItemID > 0)
			{
				text += ",ItemID";
				text2 = text2 + "," + model.ItemID.ToString();
			}
			if (model.InvoiceClassID > 0)
			{
				text += ",InvoiceClassID";
				text2 = text2 + "," + model.InvoiceClassID.ToString();
			}
			if (model.InvoiceNO != string.Empty)
			{
				text += ",InvoiceNO";
				text2 = text2 + ",'" + model.InvoiceNO + "'";
			}
			if (model.CheckNO != string.Empty)
			{
				text += ",CheckNO";
				text2 = text2 + ",'" + model.CheckNO + "'";
			}
			if (model.VoucherNO != string.Empty)
			{
				text += ",VoucherNO";
				text2 = text2 + ",'" + model.VoucherNO + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			string[] array = new string[3];
			array[0] = text;
			array[1] = text2;
			if (iFlag == 1)
			{
				array[2] = "zk_sk_kd";
			}
			else
			{
				array[2] = "zk_fk_kd";
			}
			list.Add(array);
			if (model.CiteAccountInfos != null)
			{
				foreach (CiteAccountInfo current in model.CiteAccountInfos)
				{
					string[] array2 = new string[3];
					array2[0] = current.ArrearageID.ToString();
					array2[1] = current.Money.ToString();
					list.Add(array2);
				}
			}
			return DbHelperSQL.ZK_RunProcedureTran(list, out strMsg, out iTbid);
		}

		public int Update(IncomeExpensesInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "Remark='" + model.Remark + "'";
			text = text + ",InvoiceAmount=" + model.InvoiceAmount.ToString();
			text = text + ",VoucherNO='" + model.VoucherNO + "'";
			text = text + ",CheckNO='" + model.CheckNO + "'";
			text = text + ",InvoiceNO='" + model.InvoiceNO + "'";
			if (model.InvoiceClassID > 0)
			{
				text = text + ",InvoiceClassID=" + model.InvoiceClassID;
			}
			else
			{
				text += ",InvoiceClassID=null";
			}
			if (model.ItemID > 0)
			{
				text = text + ",ItemID=" + model.ItemID;
			}
			else
			{
				text += ",ItemID=null";
			}
			if (model.AccountID > 0)
			{
				text = text + ",AccountID=" + model.AccountID;
			}
			else
			{
				text += ",AccountID=null";
			}
			if (model.ChargeModeID > 0)
			{
				text = text + ",ChargeModeID=" + model.ChargeModeID;
			}
			else
			{
				text += ",ChargeModeID=null";
			}
			if (!model.InvoiceDate.Equals(""))
			{
				text = text + ",InvoiceDate='" + model.InvoiceDate + "'";
			}
			else
			{
				text += ",InvoiceDate=null";
			}
			return DbHelperSQL.RunUpdateProcedureTran("zk_sfk_update", text, model.ID, out strMsg);
		}

		public IncomeExpensesInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,BillID,DeptID,Type,RecType,_Date=convert(char(10), _Date,120),InvoiceDate=convert(char(10), InvoiceDate,120),PersonID,CusType,CustomerID,RecMoney,RealRecMoney,PreMoney,DueMoney,RealDueMoney,InvoiceAmount,ChargeModeID,AccountID,ItemID,InvoiceClassID,InvoiceNO,CheckNO,VoucherNO,ChkDate,ChkOperatorID,Status,Remark,CustomerName=CASE WHEN a.CusType=1 then (select _Name from CustomerList where [ID]=a.CustomerID) else case when a.CusType=2 then (select _Name from SupplierList where [ID]=a.CustomerID) else case when a.CusType=3 then (select _Name from BranchList where [ID]=a.CustomerID) else (select _Name from StaffList where [ID]=a.CustomerID) end end end from IncomeExpenses a ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			IncomeExpensesInfo incomeExpensesInfo = new IncomeExpensesInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			IncomeExpensesInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					incomeExpensesInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				incomeExpensesInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					incomeExpensesInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				incomeExpensesInfo.Type = dataSet.Tables[0].Rows[0]["Type"].ToString();
				incomeExpensesInfo.RecType = dataSet.Tables[0].Rows[0]["RecType"].ToString();
				incomeExpensesInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["PersonID"].ToString() != "")
				{
					incomeExpensesInfo.PersonID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["PersonID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["CusType"].ToString() != "")
				{
					incomeExpensesInfo.CusType = new int?(int.Parse(dataSet.Tables[0].Rows[0]["CusType"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["CustomerID"].ToString() != "")
				{
					incomeExpensesInfo.CustomerID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["CustomerID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["RecMoney"].ToString() != "")
				{
					incomeExpensesInfo.RecMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["RecMoney"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["InvoiceAmount"].ToString() != "")
				{
					incomeExpensesInfo.InvoiceAmount = decimal.Parse(dataSet.Tables[0].Rows[0]["InvoiceAmount"].ToString());
				}
				incomeExpensesInfo.InvoiceDate = dataSet.Tables[0].Rows[0]["InvoiceDate"].ToString();
				if (dataSet.Tables[0].Rows[0]["RealRecMoney"].ToString() != "")
				{
					incomeExpensesInfo.RealRecMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["RealRecMoney"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["PreMoney"].ToString() != "")
				{
					incomeExpensesInfo.PreMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["PreMoney"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DueMoney"].ToString() != "")
				{
					incomeExpensesInfo.DueMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["DueMoney"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["RealDueMoney"].ToString() != "")
				{
					incomeExpensesInfo.RealDueMoney = decimal.Parse(dataSet.Tables[0].Rows[0]["RealDueMoney"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ChargeModeID"].ToString() != "")
				{
					incomeExpensesInfo.ChargeModeID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ChargeModeID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["AccountID"].ToString() != "")
				{
					incomeExpensesInfo.AccountID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["AccountID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ItemID"].ToString() != "")
				{
					incomeExpensesInfo.ItemID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ItemID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["InvoiceClassID"].ToString() != "")
				{
					incomeExpensesInfo.InvoiceClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["InvoiceClassID"].ToString()));
				}
				incomeExpensesInfo.InvoiceNO = dataSet.Tables[0].Rows[0]["InvoiceNO"].ToString();
				incomeExpensesInfo.CheckNO = dataSet.Tables[0].Rows[0]["CheckNO"].ToString();
				incomeExpensesInfo.VoucherNO = dataSet.Tables[0].Rows[0]["VoucherNO"].ToString();
				if (dataSet.Tables[0].Rows[0]["ChkDate"].ToString() != "")
				{
					incomeExpensesInfo.ChkDate = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["ChkDate"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString() != "")
				{
					incomeExpensesInfo.ChkOperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ChkOperatorID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					incomeExpensesInfo.Status = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString()));
				}
				incomeExpensesInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				incomeExpensesInfo.CustomerName = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
				result = incomeExpensesInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int IncomExpChk(int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("zk_sfk_chk", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int IncomExpChkU(int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("zk_sfk_chku", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int IncomExpCancel(int iTbid, int iOperator, out string strMsg)
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
			int result = DbHelperSQL.RunProcedureTran("zk_sfk_zf", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int GetIDs(string ids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID from IncomeExpenses where BillID=@BillID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.VarChar, 50)
			};
			array[0].Value = ids;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			int result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int UpdateDate(string field, string strWhere)
		{
			string sQLString = " update IncomeExpenses set " + field + "  where " + strWhere;
			return DbHelperSQL.ExecuteSql(sQLString);
		}
	}
}
