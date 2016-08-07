using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALAssociator
	{
		public int Add(AssociatorInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			string strCondition = " _Name='" + model._Name + "' ";
			if (model.Password != string.Empty)
			{
				text += ",Password";
				text2 = text2 + ",'" + model.Password + "'";
			}
			if (model.Company != string.Empty)
			{
				text += ",Company";
				text2 = text2 + ",'" + model.Company + "'";
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
			if (model.Email != string.Empty)
			{
				text += ",Email";
				text2 = text2 + ",'" + model.Email + "'";
			}
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID;
			}
			text += ",iFlag";
			text2 += ",1";
			return DALCommon.InsertData("Associator", text, text2, strCondition, "»áÔ±Ãû", "ID", out strMsg, out iTbid);
		}

		public void Update(AssociatorInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Associator set ");
			stringBuilder.Append("Company=@Company,");
			stringBuilder.Append("LinkMan=@LinkMan,");
			stringBuilder.Append("Tel=@Tel,");
			stringBuilder.Append("Adr=@Adr,");
			stringBuilder.Append("Email=@Email");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@Company", SqlDbType.VarChar, 200),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@Adr", SqlDbType.VarChar, 50),
				new SqlParameter("@Email", SqlDbType.VarChar, 100)
			};
			array[0].Value = model.ID;
			array[1].Value = model.Company;
			array[2].Value = model.LinkMan;
			array[3].Value = model.Tel;
			array[4].Value = model.Adr;
			array[5].Value = model.Email;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdatePsw(string user, string password)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Associator set ");
			stringBuilder.Append("Password=@Password");
			stringBuilder.Append(" where _Name=@_Name");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Name", SqlDbType.VarChar, 50),
				new SqlParameter("@Password", SqlDbType.VarChar, 50)
			};
			array[0].Value = user;
			array[1].Value = password;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdatePswID(int id, string password)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Associator set ");
			stringBuilder.Append("Password=@Password");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@Password", SqlDbType.VarChar, 50)
			};
			array[0].Value = id;
			array[1].Value = password;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateID(int id, int customerid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Associator set ");
			stringBuilder.Append("CustomerID=@CustomerID");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4)
			};
			array[0].Value = id;
			array[1].Value = customerid;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateiFlag(int id, bool iflag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Associator set ");
			stringBuilder.Append("iFlag=@iFlag");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@iFlag", SqlDbType.Bit, 1)
			};
			array[0].Value = id;
			array[1].Value = iflag;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public AssociatorInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [ID],[_Name],[Password],[Company],[LinkMan],[Tel],[Adr],[Email],isnull([CustomerID],0) as CustomerID,[iFlag],[CustomerNO],[CustomerName] from ks_associator ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			AssociatorInfo associatorInfo = new AssociatorInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			AssociatorInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					associatorInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				associatorInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				associatorInfo.Password = dataSet.Tables[0].Rows[0]["Password"].ToString();
				associatorInfo.Company = dataSet.Tables[0].Rows[0]["Company"].ToString();
				associatorInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				associatorInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				associatorInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				associatorInfo.Email = dataSet.Tables[0].Rows[0]["Email"].ToString();
				if (dataSet.Tables[0].Rows[0]["CustomerID"].ToString() != "")
				{
					associatorInfo.CustomerID = int.Parse(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
				}
				associatorInfo.CustomerNO = dataSet.Tables[0].Rows[0]["CustomerNO"].ToString();
				associatorInfo.CustomerName = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
				if (dataSet.Tables[0].Rows[0]["iFlag"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["iFlag"].ToString() == "1" || dataSet.Tables[0].Rows[0]["iFlag"].ToString().ToLower() == "true")
					{
						associatorInfo.iFlag = true;
					}
					else
					{
						associatorInfo.iFlag = false;
					}
				}
				result = associatorInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public AssociatorInfo GetModel(string _Name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [ID],[_Name],[Password],[Company],[LinkMan],[Tel],[Adr],[Email],isnull([CustomerID],0) as CustomerID,[iFlag],[CustomerNO],[CustomerName] from ks_associator ");
			stringBuilder.Append(" where _Name=@_Name");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Name", SqlDbType.VarChar, 50)
			};
			array[0].Value = _Name;
			AssociatorInfo associatorInfo = new AssociatorInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			AssociatorInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					associatorInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				associatorInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				associatorInfo.Password = dataSet.Tables[0].Rows[0]["Password"].ToString();
				associatorInfo.Company = dataSet.Tables[0].Rows[0]["Company"].ToString();
				associatorInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				associatorInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				associatorInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				associatorInfo.Email = dataSet.Tables[0].Rows[0]["Email"].ToString();
				if (dataSet.Tables[0].Rows[0]["CustomerID"].ToString() != "")
				{
					associatorInfo.CustomerID = int.Parse(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
				}
				associatorInfo.CustomerNO = dataSet.Tables[0].Rows[0]["CustomerNO"].ToString();
				associatorInfo.CustomerName = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
				if (dataSet.Tables[0].Rows[0]["iFlag"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["iFlag"].ToString() == "1" || dataSet.Tables[0].Rows[0]["iFlag"].ToString().ToLower() == "true")
					{
						associatorInfo.iFlag = true;
					}
					else
					{
						associatorInfo.iFlag = false;
					}
				}
				result = associatorInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public AssociatorInfo GetModelEmail(string Email)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 Password,CustomerID,iFlag,_Name from Associator ");
			stringBuilder.Append(" where Email=@Email");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Email", SqlDbType.VarChar, 100)
			};
			array[0].Value = Email;
			AssociatorInfo associatorInfo = new AssociatorInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			associatorInfo.Email = Email;
			AssociatorInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				associatorInfo.Password = dataSet.Tables[0].Rows[0]["Password"].ToString();
				associatorInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["iFlag"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["iFlag"].ToString() == "1" || dataSet.Tables[0].Rows[0]["iFlag"].ToString().ToLower() == "true")
					{
						associatorInfo.iFlag = true;
					}
					else
					{
						associatorInfo.iFlag = false;
					}
				}
				result = associatorInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int getCusID(int recid)
		{
			string sQLString = " select CustomerID from Associator where ID=@ID ";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = recid;
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
			result = -1;
			return result;
		}
	}
}
