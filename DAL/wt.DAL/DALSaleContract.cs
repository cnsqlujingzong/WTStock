using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSaleContract
	{
		public int Add(SaleContractInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into SaleContract(OperatorID,_Date,SellerID,DeptID,ContractType,CustomerID,CustomerName,LinkMan,Tel,Adr,dAmount,dInCash,ContractNo,Summary,StartDate,EndDate,Remark,Accessory,Status)");
			stringBuilder.Append("values(@OperatorID,@_Date,@SellerID,@DeptID,@ContractType,@CustomerID,@CustomerName,@LinkMan,@Tel,@Adr,@dAmount,@dInCash,@ContractNo,@Summary,@StartDate,@EndDate,@Remark,@Accessory,@Status)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@OperatorID", SqlDbType.Int),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@SellerID", SqlDbType.Int),
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@ContractType", SqlDbType.VarChar, 50),
				new SqlParameter("@CustomerID", SqlDbType.Int),
				new SqlParameter("@CustomerName", SqlDbType.VarChar, 100),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@Adr", SqlDbType.VarChar, 200),
				new SqlParameter("@dAmount", SqlDbType.Money),
				new SqlParameter("@dInCash", SqlDbType.Money),
				new SqlParameter("@ContractNo", SqlDbType.VarChar, 50),
				new SqlParameter("@Summary", SqlDbType.VarChar, 5000),
				new SqlParameter("@StartDate", SqlDbType.DateTime),
				new SqlParameter("@EndDate", SqlDbType.DateTime),
				new SqlParameter("@Remark", SqlDbType.VarChar, 5000),
				new SqlParameter("@Accessory", SqlDbType.VarChar, 100),
				new SqlParameter("@Status", SqlDbType.Int)
			};
			array[0].Value = model.OperatorID;
			array[1].Value = model._Date;
			array[2].Value = model.SellerID;
			array[3].Value = model.DeptID;
			array[4].Value = model.ContractType;
			array[5].Value = model.CustomerID;
			array[6].Value = model.CustomerName;
			array[7].Value = model.LinkMan;
			array[8].Value = model.Tel;
			array[9].Value = model.Adr;
			array[10].Value = model.dAmount;
			array[11].Value = model.dInCash;
			array[12].Value = model.ContractNO;
			array[13].Value = model.Summary;
			array[14].Value = model.StartDate;
			array[15].Value = model.EndDate;
			array[16].Value = model.Remark;
			array[17].Value = model.Accessory;
			array[18].Value = model.Status;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			int result;
			if (single == null)
			{
				result = 0;
			}
			else
			{
				result = Convert.ToInt32(single);
			}
			return result;
		}

		public int UpdateData(SaleContractInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SaleContract set ");
			stringBuilder.Append("OperatorID=@OperatorID,");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("SellerID=@SellerID,");
			stringBuilder.Append("ContractType=@ContractType,");
			stringBuilder.Append("CustomerID=@CustomerID,");
			stringBuilder.Append("CustomerName=@CustomerName,");
			stringBuilder.Append("LinkMan=@LinkMan,");
			stringBuilder.Append("Tel=@Tel,");
			stringBuilder.Append("Adr=@Adr,");
			stringBuilder.Append("dAmount=@dAmount,");
			stringBuilder.Append("dInCash=@dInCash,");
			stringBuilder.Append("ContractNO=@ContractNO,");
			stringBuilder.Append("Summary=@Summary,");
			stringBuilder.Append("StartDate=@StartDate,");
			stringBuilder.Append("EndDate=@EndDate,");
			stringBuilder.Append("Remark=@Remark,");
			stringBuilder.Append("Accessory=@Accessory");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@OperatorID", SqlDbType.Int),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@SellerID", SqlDbType.Int),
				new SqlParameter("@ContractType", SqlDbType.VarChar, 50),
				new SqlParameter("@CustomerID", SqlDbType.Int),
				new SqlParameter("@CustomerName", SqlDbType.VarChar, 100),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@Adr", SqlDbType.VarChar, 200),
				new SqlParameter("@dAmount", SqlDbType.Money),
				new SqlParameter("@dInCash", SqlDbType.Money),
				new SqlParameter("@ContractNo", SqlDbType.VarChar, 50),
				new SqlParameter("@Summary", SqlDbType.VarChar, 5000),
				new SqlParameter("@StartDate", SqlDbType.DateTime),
				new SqlParameter("@EndDate", SqlDbType.DateTime),
				new SqlParameter("@Remark", SqlDbType.VarChar, 5000),
				new SqlParameter("@Accessory", SqlDbType.VarChar, 100),
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = model.OperatorID;
			array[1].Value = model._Date;
			array[2].Value = model.SellerID;
			array[3].Value = model.ContractType;
			array[4].Value = model.CustomerID;
			array[5].Value = model.CustomerName;
			array[6].Value = model.LinkMan;
			array[7].Value = model.Tel;
			array[8].Value = model.Adr;
			array[9].Value = model.dAmount;
			array[10].Value = model.dInCash;
			array[11].Value = model.ContractNO;
			array[12].Value = model.Summary;
			array[13].Value = model.StartDate;
			array[14].Value = model.EndDate;
			array[15].Value = model.Remark;
			array[16].Value = model.Accessory;
			array[17].Value = model.ID;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int UpdateDatas(SaleContractInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SaleContract set ");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("SellerID=@SellerID,");
			stringBuilder.Append("ContractType=@ContractType,");
			stringBuilder.Append("CustomerID=@CustomerID,");
			stringBuilder.Append("CustomerName=@CustomerName,");
			stringBuilder.Append("LinkMan=@LinkMan,");
			stringBuilder.Append("Tel=@Tel,");
			stringBuilder.Append("Adr=@Adr,");
			stringBuilder.Append("dAmount=@dAmount,");
			stringBuilder.Append("dInCash=@dInCash,");
			stringBuilder.Append("ContractNO=@ContractNO,");
			stringBuilder.Append("Summary=@Summary,");
			stringBuilder.Append("StartDate=@StartDate,");
			stringBuilder.Append("EndDate=@EndDate,");
			stringBuilder.Append("Remark=@Remark,");
			stringBuilder.Append("Accessory=@Accessory");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@SellerID", SqlDbType.Int),
				new SqlParameter("@ContractType", SqlDbType.VarChar, 50),
				new SqlParameter("@CustomerID", SqlDbType.Int),
				new SqlParameter("@CustomerName", SqlDbType.VarChar, 100),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@Adr", SqlDbType.VarChar, 200),
				new SqlParameter("@dAmount", SqlDbType.Money),
				new SqlParameter("@dInCash", SqlDbType.Money),
				new SqlParameter("@ContractNo", SqlDbType.VarChar, 50),
				new SqlParameter("@Summary", SqlDbType.VarChar, 5000),
				new SqlParameter("@StartDate", SqlDbType.DateTime),
				new SqlParameter("@EndDate", SqlDbType.DateTime),
				new SqlParameter("@Remark", SqlDbType.VarChar, 5000),
				new SqlParameter("@Accessory", SqlDbType.VarChar, 100),
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = model._Date;
			array[1].Value = model.SellerID;
			array[2].Value = model.ContractType;
			array[3].Value = model.CustomerID;
			array[4].Value = model.CustomerName;
			array[5].Value = model.LinkMan;
			array[6].Value = model.Tel;
			array[7].Value = model.Adr;
			array[8].Value = model.dAmount;
			array[9].Value = model.dInCash;
			array[10].Value = model.ContractNO;
			array[11].Value = model.Summary;
			array[12].Value = model.StartDate;
			array[13].Value = model.EndDate;
			array[14].Value = model.Remark;
			array[15].Value = model.Accessory;
			array[16].Value = model.ID;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int DeleteData(int ID)
		{
			string sQLString = " delete from SaleContract where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = ID;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public SaleContractInfo GetModel(int ID)
		{
			SaleContractInfo saleContractInfo = new SaleContractInfo();
			string sQLString = " select * from SaleContract where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = ID;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			SaleContractInfo result;
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["OperatorID"].ToString() != "")
				{
					saleContractInfo.OperatorID = int.Parse(dataTable.Rows[0]["OperatorID"].ToString());
				}
				if (dataTable.Rows[0]["_Date"].ToString() != "")
				{
					saleContractInfo._Date = DateTime.Parse(dataTable.Rows[0]["_Date"].ToString());
				}
				if (dataTable.Rows[0]["SellerID"].ToString() != "")
				{
					saleContractInfo.SellerID = int.Parse(dataTable.Rows[0]["SellerID"].ToString());
				}
				if (dataTable.Rows[0]["DeptID"].ToString() != "")
				{
					saleContractInfo.DeptID = int.Parse(dataTable.Rows[0]["DeptID"].ToString());
				}
				saleContractInfo.ContractType = dataTable.Rows[0]["ContractType"].ToString();
				if (dataTable.Rows[0]["CustomerID"].ToString() != "")
				{
					saleContractInfo.CustomerID = int.Parse(dataTable.Rows[0]["CustomerID"].ToString());
				}
				saleContractInfo.CustomerName = dataTable.Rows[0]["CustomerName"].ToString();
				saleContractInfo.LinkMan = dataTable.Rows[0]["LinkMan"].ToString();
				saleContractInfo.Tel = dataTable.Rows[0]["Tel"].ToString();
				saleContractInfo.Adr = dataTable.Rows[0]["Adr"].ToString();
				if (dataTable.Rows[0]["dAmount"].ToString() != "")
				{
					saleContractInfo.dAmount = decimal.Parse(dataTable.Rows[0]["dAmount"].ToString());
				}
				if (dataTable.Rows[0]["dInCash"].ToString() != "")
				{
					saleContractInfo.dInCash = decimal.Parse(dataTable.Rows[0]["dInCash"].ToString());
				}
				saleContractInfo.ContractNO = dataTable.Rows[0]["ContractNO"].ToString();
				saleContractInfo.Summary = dataTable.Rows[0]["Summary"].ToString();
				if (dataTable.Rows[0]["StartDate"].ToString() != "")
				{
					saleContractInfo.StartDate = DateTime.Parse(dataTable.Rows[0]["StartDate"].ToString());
				}
				if (dataTable.Rows[0]["EndDate"].ToString() != "")
				{
					saleContractInfo.EndDate = DateTime.Parse(dataTable.Rows[0]["EndDate"].ToString());
				}
				saleContractInfo.Remark = dataTable.Rows[0]["Remark"].ToString();
				saleContractInfo.Accessory = dataTable.Rows[0]["Accessory"].ToString();
				if (dataTable.Rows[0]["Status"].ToString() != "")
				{
					saleContractInfo.Status = int.Parse(dataTable.Rows[0]["Status"].ToString());
				}
				result = saleContractInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int UpdateEndSer(int ID, string reason)
		{
			string sQLString = "update SaleContract set Status=4,termRemark=@termRemark where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@termRemark", SqlDbType.VarChar, 500),
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = reason;
			array[1].Value = ID;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public int UpdateEndSer1(int ID)
		{
			string sQLString = "update SaleContract set Status=3 where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = ID;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public int UpdateEndSer2(int ID)
		{
			string sQLString = "update SaleContract set Status=2 where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = ID;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public int GetIDByContractNO(string contractNO)
		{
			string sQLString = " select [ID] from SaleContract where ContractNO=@ContractNO";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ContractNO", SqlDbType.VarChar, 50)
			};
			array[0].Value = contractNO;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				result = Convert.ToInt32(dataTable.Rows[0][0].ToString());
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}
}
