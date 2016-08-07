using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALArrearage
	{
		public ArrearageInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,CusType,CustomerID,Rec,Due,Balance from Arrearage ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			ArrearageInfo arrearageInfo = new ArrearageInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			ArrearageInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					arrearageInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					arrearageInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["CusType"].ToString() != "")
				{
					arrearageInfo.CusType = new int?(int.Parse(dataSet.Tables[0].Rows[0]["CusType"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["CustomerID"].ToString() != "")
				{
					arrearageInfo.CustomerID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["CustomerID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Rec"].ToString() != "")
				{
					arrearageInfo.Rec = decimal.Parse(dataSet.Tables[0].Rows[0]["Rec"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Due"].ToString() != "")
				{
					arrearageInfo.Due = decimal.Parse(dataSet.Tables[0].Rows[0]["Due"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Balance"].ToString() != "")
				{
					arrearageInfo.Balance = decimal.Parse(dataSet.Tables[0].Rows[0]["Balance"].ToString());
				}
				result = arrearageInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int AtuoHedge(int iTbid, decimal dAmount, int iOperator, int AccountID, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iArrearageid", SqlDbType.Int),
				new SqlParameter("@dAmount", SqlDbType.Decimal),
				new SqlParameter("@iOperatorid", SqlDbType.Int),
				new SqlParameter("@iJSZH", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = dAmount;
			array[2].Value = iOperator;
			array[3].Value = AccountID;
			array[4].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zk_ysyf_zddc", array);
			strMsg = Convert.ToString(array[4].Value);
			return result;
		}

		public int ManualHedge(int iTbid, decimal dAmount, int iOperator, int AccountID, out int iTbid1, out int iTbid2, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iArrearageid", SqlDbType.Int),
				new SqlParameter("@dAmount", SqlDbType.Decimal),
				new SqlParameter("@iOperatorid", SqlDbType.Int),
				new SqlParameter("@iJSZH", SqlDbType.Int),
				new SqlParameter("@iTbid1", SqlDbType.Int),
				new SqlParameter("@iTbid2", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = dAmount;
			array[2].Value = iOperator;
			array[3].Value = AccountID;
			array[4].Direction = ParameterDirection.Output;
			array[5].Direction = ParameterDirection.Output;
			array[6].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zk_ysyf_sgdc", array);
			strMsg = Convert.ToString(array[6].Value);
			int.TryParse(Convert.ToString(array[4].Value), out iTbid1);
			int.TryParse(Convert.ToString(array[5].Value), out iTbid2);
			return result;
		}

		public int CancelArr(int iTbid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strYY", SqlDbType.NVarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = Reason;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zk_ysyf_hz", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int CancelArrDetail(int iTbid, int iDetailid, string Operator, int Deptid, int flag)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iDetailid", SqlDbType.Int),
				new SqlParameter("@Operator", SqlDbType.NVarChar, 50),
				new SqlParameter("@iDetpid", SqlDbType.Int),
				new SqlParameter("@iflag", SqlDbType.Int)
			};
			array[0].Value = iTbid;
			array[1].Value = iDetailid;
			array[2].Value = Operator;
			array[3].Value = Deptid;
			array[4].Value = flag;
			return DbHelperSQL.RunProcedureTran("zk_ysyf_zkmx", array);
		}

		public int zk_sfk_yy_kd(int iTbid1, int iTbid2, decimal dAmount1, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid1", SqlDbType.Int),
				new SqlParameter("@iTbid2", SqlDbType.Int),
				new SqlParameter("@dAmount1", SqlDbType.Decimal),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid1;
			array[1].Value = iTbid2;
			array[2].Value = dAmount1;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("zk_sfk_yy_kd", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public void updateRemindDate(int id, string RemindDate, string Remark)
		{
			if (RemindDate == "")
			{
				RemindDate = null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ArrearageDetail set RemindDate=@RemindDate,Remark=@Remark where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RemindDate", SqlDbType.DateTime),
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@Remark", SqlDbType.VarChar, 100)
			};
			array[0].Value = RemindDate;
			array[1].Value = id;
			array[2].Value = Remark;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateRemindDate(int id, string RemindDate, string Remark, string invoiceno, string invoicemoney, string invoicedate, decimal amount, decimal haveAmount, decimal notChargeAmount)
		{
			decimal num = 0m;
			if (RemindDate == "")
			{
				RemindDate = null;
			}
			if (invoicedate == "")
			{
				invoicedate = null;
			}
			decimal.TryParse(invoicemoney, out num);
			DataTable dataTable = this.getDetail(id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				decimal d;
				decimal.TryParse(dataTable.Rows[0]["Amount"].ToString(), out d);
				decimal d2;
				decimal.TryParse(dataTable.Rows[0]["HaveAmount"].ToString(), out d2);
				decimal d3;
				decimal.TryParse(dataTable.Rows[0]["NotChargeAmount"].ToString(), out d3);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("update ArrearageDetail set ");
				stringBuilder.Append("RemindDate=@RemindDate,");
				stringBuilder.Append("Remark=@Remark,");
				stringBuilder.Append("InvoiceNO=@InvoiceNO,");
				stringBuilder.Append("InvoiceMoney=@InvoiceMoney,");
				stringBuilder.Append("InvoiceDate=@InvoiceDate,");
				stringBuilder.Append("Amount=@Amount,");
				stringBuilder.Append("HaveAmount=@HaveAmount,");
				stringBuilder.Append("NotChargeAmount=@NotChargeAmount");
				stringBuilder.Append(" where ID=@ID");
				SqlParameter[] array = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4),
					new SqlParameter("@RemindDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar, 100),
					new SqlParameter("@InvoiceNO", SqlDbType.VarChar, 100),
					new SqlParameter("@InvoiceMoney", SqlDbType.Decimal),
					new SqlParameter("@InvoiceDate", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal, 8),
					new SqlParameter("@HaveAmount", SqlDbType.Decimal, 8),
					new SqlParameter("@NotChargeAmount", SqlDbType.Decimal, 8)
				};
				array[0].Value = id;
				array[1].Value = RemindDate;
				array[2].Value = Remark;
				array[3].Value = invoiceno;
				array[4].Value = num;
				array[5].Value = invoicedate;
				array[6].Value = amount;
				array[7].Value = haveAmount;
				array[8].Value = notChargeAmount;
				int num2 = DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
				if (num2 != 0)
				{
					string empty = string.Empty;
					int billID = this.getBillID(id, out empty);
					if (billID != 0)
					{
						decimal num3 = amount - d;
						decimal num4 = haveAmount - d2;
						decimal num5 = notChargeAmount - d3;
						if (empty == "应付款")
						{
							this.updateArrearge(num4, num5, billID);
						}
						else
						{
							this.updateArrearge(num5, num4, billID);
						}
					}
				}
			}
		}

		public DataSet GetArrAge(int DeptID, string strStart, string strCusName)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strStart", SqlDbType.NVarChar, 50),
				new SqlParameter("@DeptID", SqlDbType.Int, 4),
				new SqlParameter("@CusName", SqlDbType.VarChar, 500)
			};
			array[0].Value = strStart;
			array[1].Value = DeptID;
			array[2].Value = strCusName;
			return DbHelperSQL.RunProcedureDs("tj_ysyfzl", array);
		}

		public DataSet GetAgeSum(string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select isnull(sum(case when ad.Type='应付款' then ad.NotChargeAmount else 0 end),0) as Due,");
			stringBuilder.Append(" isnull(sum(case when ad.Type='应收款' then ad.NotChargeAmount else 0 end),0) as Rec ");
			stringBuilder.Append(" from ArrearageDetail ad left join Arrearage a on ad.BillID=a.ID ");
			stringBuilder.Append(" left join CustomerList cl on a.CustomerID=cl.ID and a.CusType=1 ");
			stringBuilder.Append(" left join SupplierList sl on a.CustomerID=sl.ID and a.CusType=2 ");
			stringBuilder.Append(" left join BranchList bl on a.CustomerID=bl.ID and a.CusType=3 ");
			stringBuilder.Append(" left join StaffList stfl on a.CustomerID=stfl.ID and a.CusType=4 ");
			if (!strWhere.Trim().Equals(""))
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		private int updateArrearge(decimal rec, decimal due, int id)
		{
			decimal num = rec - due;
			string sQLString = " update Arrearage set Rec=Rec+@Rec,Due=Due+@Due,Balance=Balance+@Balance where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Rec", SqlDbType.Decimal),
				new SqlParameter("@Due", SqlDbType.Decimal),
				new SqlParameter("@ID", SqlDbType.Decimal),
				new SqlParameter("@Balance", SqlDbType.Decimal)
			};
			array[0].Value = rec;
			array[1].Value = due;
			array[2].Value = id;
			array[3].Value = num;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		private int getBillID(int id, out string type)
		{
			string sQLString = " select billid,type from ArrearageDetail where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0]["billid"].ToString()))
				{
					type = dataTable.Rows[0]["type"].ToString();
					result = int.Parse(dataTable.Rows[0]["billid"].ToString());
					return result;
				}
			}
			type = null;
			result = 0;
			return result;
		}

		private int getMaxID()
		{
			string sQLString = " select Max(id) from ArrearageDetail";
			DataTable dataTable = DbHelperSQL.Query(sQLString).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = -1;
			return result;
		}

		public void insertArrearageDetail(int personid, int id, string RemindDate, string Remark, string invoiceno, string invoicemoney, string invoicedate, decimal amount, decimal haveAmount, decimal notChargeAmount, int iflag)
		{
			int maxID = this.getMaxID();
			if (maxID != -1)
			{
				decimal num = 0m;
				if (RemindDate == "")
				{
					RemindDate = null;
				}
				if (invoicedate == "")
				{
					invoicedate = null;
				}
				decimal.TryParse(invoicemoney, out num);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("insert into ArrearageDetail(ID,BillID,Type,RecType,_Date,PersonID,Amount,HaveAmount,NotChargeAmount,Status,Remark,RemindDate,InvoiceNO,InvoiceMoney,InvoiceDate) ");
				stringBuilder.Append(" values(@ID,@BillID,@Type,@RecType,@_Date,@PersonID,@Amount,@HaveAmount,@NotChargeAmount,@Status,@Remark,@RemindDate,@InvoiceNO,@InvoiceMoney,@InvoiceDate)");
				SqlParameter[] array = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4),
					new SqlParameter("@BillID", SqlDbType.Int, 4),
					new SqlParameter("@Type", SqlDbType.VarChar, 50),
					new SqlParameter("@RecType", SqlDbType.VarChar, 50),
					new SqlParameter("@_Date", SqlDbType.DateTime),
					new SqlParameter("@PersonID", SqlDbType.Int, 4),
					new SqlParameter("@Status", SqlDbType.Int, 4),
					new SqlParameter("@RemindDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar, 100),
					new SqlParameter("@InvoiceNO", SqlDbType.VarChar, 100),
					new SqlParameter("@InvoiceMoney", SqlDbType.Decimal),
					new SqlParameter("@InvoiceDate", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal, 8),
					new SqlParameter("@HaveAmount", SqlDbType.Decimal, 8),
					new SqlParameter("@NotChargeAmount", SqlDbType.Decimal, 8)
				};
				array[0].Value = maxID + 1;
				array[1].Value = id;
				if (iflag == 0)
				{
					array[2].Value = "应收款";
					array[3].Value = "期初应收";
				}
				else
				{
					array[2].Value = "应付款";
					array[3].Value = "期初应付";
				}
				array[4].Value = DateTime.Now;
				array[5].Value = personid;
				array[6].Value = 1;
				array[7].Value = RemindDate;
				array[8].Value = Remark;
				array[9].Value = invoiceno;
				array[10].Value = num;
				array[11].Value = invoicedate;
				array[12].Value = amount;
				array[13].Value = haveAmount;
				array[14].Value = notChargeAmount;
				int num2 = DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
				if (num2 != 0)
				{
					if (iflag == 0)
					{
						this.updateArrearge(notChargeAmount, haveAmount, id);
					}
					else
					{
						this.updateArrearge(haveAmount, notChargeAmount, id);
					}
				}
			}
		}

		private DataSet getDetail(int id)
		{
			string sQLString = " select Amount,HaveAmount,NotChargeAmount from ArrearageDetail where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = id;
			return DbHelperSQL.Query(sQLString, array);
		}

		public decimal getBalance(int customerid)
		{
			string sQLString = " select Balance from Arrearage where custype=1 and CustomerID=@CustomerID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", SqlDbType.Int, 4)
			};
			array[0].Value = customerid;
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
