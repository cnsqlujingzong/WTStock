using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using wt.Library;

namespace wt.DB
{
	public abstract class DbHelperSQL
	{
		public static string connectionString;

		static DbHelperSQL()
		{
			DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		}

		public DbHelperSQL()
		{
		}

		public static int AddLayout(List<string[]> StrParameters, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlParameter[] sqlParameter;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					for (int i = 0; i < StrParameters.Count; i++)
					{
						string[] item = StrParameters[i];
						if (!(item[3].ToString() == "0"))
						{
							sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000), new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
							SqlParameter[] str = sqlParameter;
							str[0].Value = item[0].ToString();
							str[1].Value = item[1].ToString();
							str[2].Value = item[2].ToString();
							str[3].Value = "";
							str[4].Value = item[2].ToString();
							str[5].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_updatedata", str);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								try
								{
									sqlCommand.ExecuteNonQuery();
									strMsg = Convert.ToString(str[5].Value);
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								}
								catch (SqlException sqlException1)
								{
									sqlException = sqlException1;
									strMsg = Convert.ToString(str[5].Value);
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
							finally
							{
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
								}
							}
						}
						else
						{
							sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000) };
							SqlParameter[] sqlParameterArray = sqlParameter;
							sqlParameterArray[0].Value = item[0].ToString();
							sqlParameterArray[1].Value = item[1].ToString();
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, item[2].ToString(), sqlParameterArray);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								try
								{
									sqlCommand.ExecuteNonQuery();
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								}
								catch (SqlException sqlException2)
								{
									sqlException = sqlException2;
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
							finally
							{
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
								}
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
		{
			SqlCommand sqlCommand = DbHelperSQL.BuildQueryCommand(connection, storedProcName, parameters);
			sqlCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
			return sqlCommand;
		}

		private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
		{
			SqlCommand sqlCommand = new SqlCommand(storedProcName, connection)
			{
				CommandType = CommandType.StoredProcedure,
				CommandTimeout = 0
			};
			IDataParameter[] dataParameterArray = parameters;
			for (int i = 0; i < (int)dataParameterArray.Length; i++)
			{
				SqlParameter value = (SqlParameter)dataParameterArray[i];
				if (value != null)
				{
					if ((value.Direction == ParameterDirection.InputOutput || value.Direction == ParameterDirection.Input ? value.Value == null : false))
					{
						value.Value = DBNull.Value;
					}
					sqlCommand.Parameters.Add(value);
				}
			}
			return sqlCommand;
		}

		public static SqlDataReader ExecuteReader(string strSQL)
		{
			SqlDataReader sqlDataReader;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
			try
			{
				sqlConnection.Open();
				sqlDataReader = sqlCommand.ExecuteReader();
			}
			catch (SqlException sqlException)
			{
				throw new Exception(sqlException.Message);
			}
			return sqlDataReader;
		}

		public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
		{
			SqlDataReader sqlDataReader;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			SqlCommand sqlCommand = new SqlCommand();
			try
			{
				DbHelperSQL.PrepareCommand(sqlCommand, sqlConnection, null, SQLString, cmdParms);
				SqlDataReader sqlDataReader1 = sqlCommand.ExecuteReader();
				sqlCommand.Parameters.Clear();
				sqlDataReader = sqlDataReader1;
			}
			catch (SqlException sqlException)
			{
				throw new Exception(sqlException.Message);
			}
			return sqlDataReader;
		}

		public static int ExecuteSql(string SQLString)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand(SQLString, sqlConnection);
				try
				{
					try
					{
						sqlConnection.Open();
						num = sqlCommand.ExecuteNonQuery();
					}
					catch (SqlException sqlException1)
					{
						SqlException sqlException = sqlException1;
						sqlConnection.Close();
						throw new Exception(sqlException.Message);
					}
				}
				finally
				{
					if (sqlCommand != null)
					{
						((IDisposable)sqlCommand).Dispose();
					}
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int ExecuteSql(string SQLString, string content)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand(SQLString, sqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@content", SqlDbType.NText)
				{
					Value = content
				};
				sqlCommand.Parameters.Add(sqlParameter);
				try
				{
					try
					{
						sqlConnection.Open();
						num = sqlCommand.ExecuteNonQuery();
					}
					catch (SqlException sqlException)
					{
						throw new Exception(sqlException.Message);
					}
				}
				finally
				{
					sqlCommand.Dispose();
					sqlConnection.Close();
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand();
				try
				{
					try
					{
						DbHelperSQL.PrepareCommand(sqlCommand, sqlConnection, null, SQLString, cmdParms);
						int num1 = sqlCommand.ExecuteNonQuery();
						sqlCommand.Parameters.Clear();
						num = num1;
					}
					catch (SqlException sqlException)
					{
						throw new Exception(sqlException.Message);
					}
				}
				finally
				{
					if (sqlCommand != null)
					{
						((IDisposable)sqlCommand).Dispose();
					}
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int ExecuteSqlByTime(string SQLString, int Times)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand(SQLString, sqlConnection);
				try
				{
					try
					{
						sqlConnection.Open();
						sqlCommand.CommandTimeout = Times;
						num = sqlCommand.ExecuteNonQuery();
					}
					catch (SqlException sqlException1)
					{
						SqlException sqlException = sqlException1;
						sqlConnection.Close();
						throw new Exception(sqlException.Message);
					}
				}
				finally
				{
					if (sqlCommand != null)
					{
						((IDisposable)sqlCommand).Dispose();
					}
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static object ExecuteSqlGet(string SQLString, string content)
		{
			object obj;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand(SQLString, sqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@content", SqlDbType.NText)
				{
					Value = content
				};
				sqlCommand.Parameters.Add(sqlParameter);
				try
				{
					try
					{
						sqlConnection.Open();
						object obj1 = sqlCommand.ExecuteScalar();
						obj = ((object.Equals(obj1, null) ? false : !object.Equals(obj1, DBNull.Value)) ? obj1 : null);
					}
					catch (SqlException sqlException)
					{
						throw new Exception(sqlException.Message);
					}
				}
				finally
				{
					sqlCommand.Dispose();
					sqlConnection.Close();
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return obj;
		}

		public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@fs", SqlDbType.Image)
				{
					Value = fs
				};
				sqlCommand.Parameters.Add(sqlParameter);
				try
				{
					try
					{
						sqlConnection.Open();
						num = sqlCommand.ExecuteNonQuery();
					}
					catch (SqlException sqlException)
					{
						throw new Exception(sqlException.Message);
					}
				}
				finally
				{
					sqlCommand.Dispose();
					sqlConnection.Close();
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static void ExecuteSqlTran(ArrayList SQLStringList)
		{
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand()
				{
					Connection = sqlConnection
				};
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				sqlCommand.Transaction = sqlTransaction;
				try
				{
					for (int i = 0; i < SQLStringList.Count; i++)
					{
						string str = SQLStringList[i].ToString();
						if (str.Trim().Length > 1)
						{
							sqlCommand.CommandText = str;
							sqlCommand.ExecuteNonQuery();
						}
					}
					sqlTransaction.Commit();
				}
				catch (SqlException sqlException1)
				{
					SqlException sqlException = sqlException1;
					sqlTransaction.Rollback();
					throw new Exception(sqlException.Message);
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
		}

		public static void ExecuteSqlTran(Hashtable SQLStringList)
		{
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = new SqlCommand();
					try
					{
						foreach (DictionaryEntry sQLStringList in SQLStringList)
						{
							string str = sQLStringList.Key.ToString();
							SqlParameter[] value = (SqlParameter[])sQLStringList.Value;
							DbHelperSQL.PrepareCommand(sqlCommand, sqlConnection, sqlTransaction, str, value);
							sqlCommand.ExecuteNonQuery();
							sqlCommand.Parameters.Clear();
							sqlTransaction.Commit();
						}
					}
					catch
					{
						sqlTransaction.Rollback();
						throw;
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
		}

		public static bool Exists(string strSql)
		{
			int num;
			object single = DbHelperSQL.GetSingle(strSql);
			num = ((object.Equals(single, null) ? false : !object.Equals(single, DBNull.Value)) ? int.Parse(single.ToString()) : 0);
			return (num != 0 ? true : false);
		}

		public static bool Exists(string strSql, params SqlParameter[] cmdParms)
		{
			int num;
			object single = DbHelperSQL.GetSingle(strSql, cmdParms);
			num = ((object.Equals(single, null) ? false : !object.Equals(single, DBNull.Value)) ? int.Parse(single.ToString()) : 0);
			return (num != 0 ? true : false);
		}

		public static int GetMaxID(string FieldName, string TableName)
		{
			int num;
			string str = string.Concat("select max(", FieldName, ")+1 from ", TableName);
			object single = DbHelperSQL.GetSingle(str);
			num = (single != null ? int.Parse(single.ToString()) : 1);
			return num;
		}

		public static object GetSingle(string SQLString)
		{
			object obj;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand(SQLString, sqlConnection);
				try
				{
					try
					{
						sqlConnection.Open();
						object obj1 = sqlCommand.ExecuteScalar();
						obj = ((object.Equals(obj1, null) ? false : !object.Equals(obj1, DBNull.Value)) ? obj1 : null);
					}
					catch (SqlException sqlException1)
					{
						SqlException sqlException = sqlException1;
						sqlConnection.Close();
						throw new Exception(sqlException.Message);
					}
				}
				finally
				{
					if (sqlCommand != null)
					{
						((IDisposable)sqlCommand).Dispose();
					}
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return obj;
		}

		public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
		{
			object obj;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand();
				try
				{
					try
					{
						DbHelperSQL.PrepareCommand(sqlCommand, sqlConnection, null, SQLString, cmdParms);
						object obj1 = sqlCommand.ExecuteScalar();
						sqlCommand.Parameters.Clear();
						obj = ((object.Equals(obj1, null) ? false : !object.Equals(obj1, DBNull.Value)) ? obj1 : null);
					}
					catch (SqlException sqlException)
					{
						throw new Exception(sqlException.Message);
					}
				}
				finally
				{
					if (sqlCommand != null)
					{
						((IDisposable)sqlCommand).Dispose();
					}
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return obj;
		}

		public static void InsertErrorLog(int iFlag, int iMTbid, string strEvent, int icustomerid)
		{
			int num;
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@iFlag", SqlDbType.Int), new SqlParameter("@iOperatorid", SqlDbType.Int), new SqlParameter("@iMTbid", SqlDbType.Int), new SqlParameter("@strContent", SqlDbType.NVarChar, 500), new SqlParameter("@iCustomerid", SqlDbType.Int, 4) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			int.TryParse((string)HttpContext.Current.Session["Session_wtUserID"], out num);
			sqlParameterArray[0].Value = iFlag;
			sqlParameterArray[1].Value = num;
			sqlParameterArray[2].Value = iMTbid;
			sqlParameterArray[3].Value = strEvent;
			sqlParameterArray[4].Value = icustomerid;
			DbHelperSQL.RunProcedure("aa_insertlog", sqlParameterArray);
		}

		public static void InsertErrorLogs(int iFlag, int operatorid, int iMTbid, string strEvent, int customerid)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@iFlag", SqlDbType.Int), new SqlParameter("@iOperatorid", SqlDbType.Int), new SqlParameter("@iMTbid", SqlDbType.Int), new SqlParameter("@strContent", SqlDbType.NVarChar, 500), new SqlParameter("@iCustomerid", SqlDbType.Int) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			sqlParameterArray[0].Value = iFlag;
			sqlParameterArray[1].Value = operatorid;
			sqlParameterArray[2].Value = iMTbid;
			sqlParameterArray[3].Value = strEvent;
			sqlParameterArray[4].Value = customerid;
			DbHelperSQL.RunProcedure("aa_insertlog", sqlParameterArray);
		}

		public static int InsertManyData(string storedProcName, List<string[]> StrParameters, out string strMsg)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					for (int i = 0; i < StrParameters.Count; i++)
					{
						string[] item = StrParameters[i];
						SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strRepeat", SqlDbType.NVarChar, 50), new SqlParameter("@strTbid", SqlDbType.NVarChar, 50), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200), new SqlParameter("@iTbid", SqlDbType.Int) };
						SqlParameter[] str = sqlParameter;
						str[0].Value = item[0].ToString();
						str[1].Value = item[1].ToString();
						str[2].Value = item[2].ToString();
						str[3].Value = item[3].ToString();
						str[4].Value = item[4].ToString();
						str[5].Value = item[5].ToString();
						str[6].Direction = ParameterDirection.Output;
						str[7].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, str);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							try
							{
								sqlCommand.ExecuteNonQuery();
								strMsg = Convert.ToString(str[6].Value);
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
							}
							catch (SqlException sqlException1)
							{
								SqlException sqlException = sqlException1;
								strMsg = Convert.ToString(str[6].Value);
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
						finally
						{
							if (num1 != 0)
							{
								sqlTransaction.Rollback();
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
		{
			if (conn.State != ConnectionState.Open)
			{
				conn.Open();
			}
			cmd.Connection = conn;
			cmd.CommandText = cmdText;
			if (trans != null)
			{
				cmd.Transaction = trans;
			}
			cmd.CommandType = CommandType.Text;
			if (cmdParms != null)
			{
				SqlParameter[] sqlParameterArray = cmdParms;
				for (int i = 0; i < (int)sqlParameterArray.Length; i++)
				{
					SqlParameter value = sqlParameterArray[i];
					if ((value.Direction == ParameterDirection.InputOutput || value.Direction == ParameterDirection.Input ? value.Value == null : false))
					{
						value.Value = DBNull.Value;
					}
					cmd.Parameters.Add(value);
				}
			}
		}

		public static int QC_ArrearageData(List<string[]> StrParameters, int DeptID, int CusType, int iOperator, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlParameter[] sqlParameter;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					for (int i = 0; i < StrParameters.Count; i++)
					{
						string[] item = StrParameters[i];
						sqlParameter = new SqlParameter[] { new SqlParameter("@DeptID", SqlDbType.Int), new SqlParameter("@iComepanyid", SqlDbType.Int), new SqlParameter("@iCusType", SqlDbType.Int), new SqlParameter("@dYS", SqlDbType.Decimal), new SqlParameter("@dYF", SqlDbType.Decimal), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
						SqlParameter[] sqlParameterArray = sqlParameter;
						sqlParameterArray[0].Value = int.Parse(item[0].ToString());
						sqlParameterArray[1].Value = int.Parse(item[1].ToString());
						sqlParameterArray[2].Value = int.Parse(item[2].ToString());
						sqlParameterArray[3].Value = decimal.Parse(item[3].ToString());
						sqlParameterArray[4].Value = decimal.Parse(item[4].ToString());
						sqlParameterArray[5].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "qc_ysyf_kd", sqlParameterArray);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							sqlCommand.ExecuteNonQuery();
							strMsg = Convert.ToString(sqlParameterArray[5].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException1)
						{
							sqlException = sqlException1;
							strMsg = Convert.ToString(sqlParameterArray[5].Value);
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					if (num1 == 0)
					{
						sqlParameter = new SqlParameter[] { new SqlParameter("@DeptID", SqlDbType.Int), new SqlParameter("@CusType", SqlDbType.Int), new SqlParameter("@iOperator", SqlDbType.Int), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
						SqlParameter[] deptID = sqlParameter;
						deptID[0].Value = DeptID;
						deptID[1].Value = CusType;
						deptID[2].Value = iOperator;
						deptID[3].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "qc_ysyf_ad", deptID);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							sqlCommand.ExecuteNonQuery();
							strMsg = Convert.ToString(deptID[3].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException2)
						{
							sqlException = sqlException2;
							strMsg = Convert.ToString(deptID[3].Value);
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int QC_StockData(List<string[]> StrParameters, int DeptID, int iOperator, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlParameter[] sqlParameter;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					for (int i = 0; i < StrParameters.Count; i++)
					{
						string[] item = StrParameters[i];
						sqlParameter = new SqlParameter[] { new SqlParameter("@DeptID", SqlDbType.Int), new SqlParameter("@iStockid", SqlDbType.Int), new SqlParameter("@iGoodsid", SqlDbType.Int), new SqlParameter("@dCB", SqlDbType.Decimal), new SqlParameter("@dKC", SqlDbType.Decimal), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
						SqlParameter[] sqlParameterArray = sqlParameter;
						sqlParameterArray[0].Value = int.Parse(item[0].ToString());
						sqlParameterArray[1].Value = int.Parse(item[1].ToString());
						sqlParameterArray[2].Value = int.Parse(item[2].ToString());
						sqlParameterArray[3].Value = decimal.Parse(item[3].ToString());
						sqlParameterArray[4].Value = decimal.Parse(item[4].ToString());
						sqlParameterArray[5].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "qc_cp_kd", sqlParameterArray);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							sqlCommand.ExecuteNonQuery();
							strMsg = Convert.ToString(sqlParameterArray[5].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException1)
						{
							sqlException = sqlException1;
							strMsg = Convert.ToString(sqlParameterArray[5].Value);
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					if (num1 == 0)
					{
						sqlParameter = new SqlParameter[] { new SqlParameter("@DeptID", SqlDbType.Int), new SqlParameter("@iOperator", SqlDbType.Int), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
						SqlParameter[] deptID = sqlParameter;
						deptID[0].Value = DeptID;
						deptID[1].Value = iOperator;
						deptID[2].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "qc_cp_ad", deptID);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							sqlCommand.ExecuteNonQuery();
							strMsg = Convert.ToString(deptID[2].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException2)
						{
							sqlException = sqlException2;
							strMsg = Convert.ToString(deptID[2].Value);
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static DataSet Query(string SQLString)
		{
			DataSet dataSet;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				DataSet dataSet1 = new DataSet();
				try
				{
					sqlConnection.Open();
					(new SqlDataAdapter(SQLString, sqlConnection)).Fill(dataSet1, "ds");
				}
				catch (SqlException sqlException)
				{
					throw new Exception(sqlException.Message);
				}
				dataSet = dataSet1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return dataSet;
		}

		public static DataSet Query(string SQLString, int Times)
		{
			DataSet dataSet;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				DataSet dataSet1 = new DataSet();
				try
				{
					sqlConnection.Open();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQLString, sqlConnection);
					sqlDataAdapter.SelectCommand.CommandTimeout = Times;
					sqlDataAdapter.Fill(dataSet1, "ds");
				}
				catch (SqlException sqlException)
				{
					throw new Exception(sqlException.Message);
				}
				dataSet = dataSet1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return dataSet;
		}

		public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
		{
			DataSet dataSet;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				SqlCommand sqlCommand = new SqlCommand();
				DbHelperSQL.PrepareCommand(sqlCommand, sqlConnection, null, SQLString, cmdParms);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				try
				{
					DataSet dataSet1 = new DataSet();
					try
					{
						sqlDataAdapter.Fill(dataSet1, "ds");
						sqlCommand.Parameters.Clear();
					}
					catch (SqlException sqlException)
					{
						throw new Exception(sqlException.Message);
					}
					dataSet = dataSet1;
				}
				finally
				{
					if (sqlDataAdapter != null)
					{
						((IDisposable)sqlDataAdapter).Dispose();
					}
				}
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return dataSet;
		}

		public static int RunManyProcedureTran(string storedProcName, List<string[]> StrParameters, bool bsys, out string strMsg, out int iTbid)
		{
			SqlException sqlException;
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				iTbid = 0;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strRepeat", SqlDbType.NVarChar, 50), new SqlParameter("@strTbid", SqlDbType.NVarChar, 50), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200), new SqlParameter("@iTbid", SqlDbType.Int) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					if (!bsys)
					{
						str[1].Value = item[1].ToString();
					}
					else
					{
						str[1].Value = string.Concat(item[1].ToString(), ",", item[6].ToString());
					}
					if (!bsys)
					{
						str[2].Value = item[2].ToString();
					}
					else
					{
						sqlParameter = new SqlParameter[] { new SqlParameter("@iBillid", SqlDbType.Int), new SqlParameter("@iPost", SqlDbType.Int), new SqlParameter("@strBillid", SqlDbType.NVarChar, 50) };
						SqlParameter[] sqlParameterArray = sqlParameter;
						sqlParameterArray[0].Value = int.Parse(item[7].ToString());
						sqlParameterArray[1].Value = 1;
						sqlParameterArray[2].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_createbillid", sqlParameterArray);
						sqlCommand.Transaction = sqlTransaction;
						sqlCommand.ExecuteNonQuery();
						str[2].Value = string.Concat(item[2].ToString(), ",'", Convert.ToString(sqlParameterArray[2].Value), "'");
					}
					str[3].Value = item[3].ToString();
					str[4].Value = item[4].ToString();
					str[5].Value = item[5].ToString();
					str[6].Direction = ParameterDirection.Output;
					str[7].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						try
						{
							sqlCommand.ExecuteNonQuery();
							iTbid = Convert.ToInt32(str[7].Value);
							strMsg = Convert.ToString(str[6].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException1)
						{
							sqlException = sqlException1;
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					finally
					{
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
						}
					}
					if (num1 == 0)
					{
						for (int i = 1; i < StrParameters.Count; i++)
						{
							string[] strArrays = StrParameters[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strRepeat", SqlDbType.NVarChar, 50), new SqlParameter("@strTbid", SqlDbType.NVarChar, 50), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200), new SqlParameter("@iTbid", SqlDbType.Int) };
							SqlParameter[] str1 = sqlParameter;
							str1[0].Value = strArrays[0].ToString();
							str1[1].Value = string.Concat(strArrays[1].ToString(), ",", strArrays[6].ToString());
							str1[2].Value = string.Concat(strArrays[2].ToString(), ",", iTbid.ToString());
							SqlParameter sqlParameter1 = str1[3];
							string[] strArrays1 = new string[] { strArrays[3].ToString(), " and ", strArrays[6].ToString(), "=", iTbid.ToString() };
							sqlParameter1.Value = string.Concat(strArrays1);
							str1[4].Value = strArrays[4].ToString();
							str1[5].Value = strArrays[5].ToString();
							str1[6].Direction = ParameterDirection.Output;
							str1[7].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, str1);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								try
								{
									sqlCommand.ExecuteNonQuery();
									strMsg = Convert.ToString(str1[6].Value);
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								}
								catch (SqlException sqlException2)
								{
									sqlException = sqlException2;
									strMsg = Convert.ToString(str1[6].Value);
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
							finally
							{
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
								}
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static DataSet RunPageProcedure(string storedProcName, IDataParameter[] parameters, out int count)
		{
			DataSet dataSet;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				DataSet dataSet1 = new DataSet();
				sqlConnection.Open();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
				{
					SelectCommand = DbHelperSQL.BuildQueryCommand(sqlConnection, storedProcName, parameters)
				};
				sqlDataAdapter.Fill(dataSet1);
				count = Convert.ToInt32(sqlDataAdapter.SelectCommand.Parameters[7].Value.ToString());
				sqlConnection.Close();
				dataSet = dataSet1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return dataSet;
		}

		public static void RunProcedure(string storedProcName, IDataParameter[] parameters)
		{
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				sqlConnection.Open();
				DbHelperSQL.BuildQueryCommand(sqlConnection, storedProcName, parameters).ExecuteNonQuery();
				sqlConnection.Close();
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
		}

		public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
		{
			DataSet dataSet;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				DataSet dataSet1 = new DataSet();
				sqlConnection.Open();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
				{
					SelectCommand = DbHelperSQL.BuildQueryCommand(sqlConnection, storedProcName, parameters)
				};
				sqlDataAdapter.SelectCommand.CommandTimeout = Times;
				sqlDataAdapter.Fill(dataSet1, tableName);
				sqlConnection.Close();
				dataSet = dataSet1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return dataSet;
		}

		public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
		{
			int num;
			int num1;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				sqlConnection.Open();
				SqlCommand sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, parameters);
				rowsAffected = sqlCommand.ExecuteNonQuery();
				int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num);
				num1 = num;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num1;
		}

		public static DataSet RunProcedureDs(string storedProcName, IDataParameter[] parameters)
		{	
                SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
                DataSet dataSet = new DataSet();
                try
                {
                   
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
                    {
                        SelectCommand = DbHelperSQL.BuildQueryCommand(sqlConnection, storedProcName, parameters)
                    };
                    sqlDataAdapter.Fill(dataSet);
                    sqlConnection.Close();                  
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        ((IDisposable)sqlConnection).Dispose();
                    }
                }
            
			return dataSet;
		}

		public static int RunProcedureTran(string storedProcName, IDataParameter[] parameters)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.Serializable);
				try
				{
					SqlCommand sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, parameters);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						sqlCommand.ExecuteNonQuery();
						int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
						}
						else
						{
							sqlTransaction.Commit();
						}
					}
					catch (SqlException sqlException1)
					{
						SqlException sqlException = sqlException1;
						sqlTransaction.Rollback();
						num1 = 85;
						DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
						OtherClass.AppendErrorLog(sqlException.Message);
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int RunProcedureTran(List<string[]> StrParameters, out int iTbid)
		{
			SqlException sqlException;
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				iTbid = 0;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.Int) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					str[1].Value = item[1].ToString();
					str[2].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, item[2].ToString(), str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						sqlCommand.ExecuteNonQuery();
						iTbid = Convert.ToInt32(str[2].Value);
						int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
							num = num1;
							return num;
						}
					}
					catch (SqlException sqlException1)
					{
						sqlException = sqlException1;
						sqlTransaction.Rollback();
						num1 = 85;
						DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
						OtherClass.AppendErrorLog(sqlException.Message);
						num = num1;
						return num;
					}
					if (num1 == 0)
					{
						for (int i = 1; i < StrParameters.Count; i++)
						{
							string[] strArrays = StrParameters[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000) };
							SqlParameter[] sqlParameterArray = sqlParameter;
							sqlParameterArray[0].Value = strArrays[0].ToString();
							sqlParameterArray[1].Value = string.Concat(strArrays[1].ToString(), ",", iTbid.ToString());
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, strArrays[2].ToString(), sqlParameterArray);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								sqlCommand.ExecuteNonQuery();
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
									num = num1;
									return num;
								}
							}
							catch (SqlException sqlException2)
							{
								sqlException = sqlException2;
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int RunUpdateProcedureTran(string storedProcName, string strFldContent, int iTbid, out string strMsg)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.Serializable);
				try
				{
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@iTbid", SqlDbType.Int), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 2000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
					SqlParameter[] sqlParameterArray = sqlParameter;
					sqlParameterArray[0].Value = iTbid;
					sqlParameterArray[1].Value = strFldContent;
					sqlParameterArray[2].Direction = ParameterDirection.Output;
					SqlCommand sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, sqlParameterArray);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						sqlCommand.ExecuteNonQuery();
						strMsg = Convert.ToString(sqlParameterArray[2].Value);
						int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
						}
						else
						{
							sqlTransaction.Commit();
						}
					}
					catch (SqlException sqlException1)
					{
						SqlException sqlException = sqlException1;
						sqlTransaction.Rollback();
						num1 = 85;
						if (num1 > 0)
						{
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
						}
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int SN_StockIN(List<string[]> StrParameters)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					for (int i = 0; i < StrParameters.Count; i++)
					{
						string[] item = StrParameters[i];
						SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@iTbid", SqlDbType.Int), new SqlParameter("@SN", SqlDbType.NVarChar, 200), new SqlParameter("@bSys", SqlDbType.Bit), new SqlParameter("@DeptID", SqlDbType.Int) };
						SqlParameter[] str = sqlParameter;
						str[0].Value = item[0].ToString();
						str[1].Value = item[1].ToString();
						str[2].Value = item[2].ToString();
						str[3].Value = item[3].ToString();
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "ck_sn_stockin", str);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							sqlCommand.ExecuteNonQuery();
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException1)
						{
							SqlException sqlException = sqlException1;
							sqlTransaction.Rollback();
							num1 = 85;
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int SN_StockOUT(List<string[]> StrParameters, out string strMsg)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					for (int i = 0; i < StrParameters.Count; i++)
					{
						string[] item = StrParameters[i];
						SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@DeptID", SqlDbType.Int), new SqlParameter("@iTbid", SqlDbType.Int), new SqlParameter("@SN", SqlDbType.NVarChar, 200), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
						SqlParameter[] str = sqlParameter;
						str[0].Value = item[0].ToString();
						str[1].Value = item[1].ToString();
						str[2].Value = item[2].ToString();
						str[3].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "ck_sn_stockout", str);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							sqlCommand.ExecuteNonQuery();
							strMsg = Convert.ToString(str[3].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException1)
						{
							SqlException sqlException = sqlException1;
							sqlTransaction.Rollback();
							strMsg = Convert.ToString(str[3].Value);
							num1 = 85;
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int TY_RunProcedureTran(List<string[]> StrParameters, string strProcedure, out int iTbid, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				iTbid = 0;
				strMsg = "";
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.Int) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					str[1].Value = item[1].ToString();
					str[2].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, item[2].ToString(), str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						sqlCommand.ExecuteNonQuery();
						iTbid = Convert.ToInt32(str[2].Value);
						int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
							num = num1;
							return num;
						}
					}
					catch (SqlException sqlException1)
					{
						sqlException = sqlException1;
						sqlTransaction.Rollback();
						num1 = 85;
						DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
						OtherClass.AppendErrorLog(sqlException.Message);
						num = num1;
						return num;
					}
					if (num1 == 0)
					{
						for (int i = 1; i < StrParameters.Count; i++)
						{
							string[] strArrays = StrParameters[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000) };
							SqlParameter[] sqlParameterArray = sqlParameter;
							sqlParameterArray[0].Value = strArrays[0].ToString();
							sqlParameterArray[1].Value = string.Concat(strArrays[1].ToString(), ",", iTbid.ToString());
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, strArrays[2].ToString(), sqlParameterArray);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								sqlCommand.ExecuteNonQuery();
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
									num = num1;
									return num;
								}
							}
							catch (SqlException sqlException2)
							{
								sqlException = sqlException2;
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
					}
					if (num1 == 0)
					{
						sqlParameter = new SqlParameter[] { new SqlParameter("@iTbid", SqlDbType.Int), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
						SqlParameter[] sqlParameterArray1 = sqlParameter;
						sqlParameterArray1[0].Value = iTbid;
						sqlParameterArray1[1].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, strProcedure, sqlParameterArray1);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							sqlCommand.ExecuteNonQuery();
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
							strMsg = Convert.ToString(sqlParameterArray1[1].Value);
							if (num1 != 0)
							{
								sqlTransaction.Rollback();
								num = num1;
								return num;
							}
						}
						catch (SqlException sqlException3)
						{
							sqlException = sqlException3;
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int UpdateMany(List<string[]> StrParameters, out string strMsg)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					for (int i = 0; i < StrParameters.Count; i++)
					{
						string[] item = StrParameters[i];
						SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000), new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
						SqlParameter[] str = sqlParameter;
						str[0].Value = item[0].ToString();
						str[1].Value = item[1].ToString();
						str[2].Value = item[2].ToString();
						str[3].Value = "";
						str[4].Value = item[2].ToString();
						str[5].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_updatedata", str);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							try
							{
								sqlCommand.ExecuteNonQuery();
								strMsg = Convert.ToString(str[5].Value);
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
							}
							catch (SqlException sqlException1)
							{
								SqlException sqlException = sqlException1;
								strMsg = Convert.ToString(str[5].Value);
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
						finally
						{
							if (num1 != 0)
							{
								sqlTransaction.Rollback();
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int UpdateManyProcedureTran(List<string[]> StrParameters, List<string[]> strdellist, bool bsys, out string strMsg)
		{
			SqlException sqlException;
			int num;
			string[] str;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000), new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
					SqlParameter[] sqlParameterArray = sqlParameter;
					sqlParameterArray[0].Value = item[0].ToString();
					if (!bsys)
					{
						sqlParameterArray[1].Value = item[1].ToString();
						sqlParameterArray[2].Value = item[2].ToString();
					}
					else
					{
						sqlParameter = new SqlParameter[] { new SqlParameter("@iBillid", SqlDbType.Int), new SqlParameter("@iPost", SqlDbType.Int), new SqlParameter("@strBillid", SqlDbType.NVarChar, 50) };
						SqlParameter[] sqlParameterArray1 = sqlParameter;
						sqlParameterArray1[0].Value = int.Parse(item[6].ToString());
						sqlParameterArray1[1].Value = 1;
						sqlParameterArray1[2].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_createbillid", sqlParameterArray1);
						sqlCommand.Transaction = sqlTransaction;
						sqlCommand.ExecuteNonQuery();
						SqlParameter sqlParameter1 = sqlParameterArray[1];
						str = new string[] { item[1].ToString(), ",", item[5].ToString(), "='", Convert.ToString(sqlParameterArray1[2].Value), "'" };
						sqlParameter1.Value = string.Concat(str);
						sqlParameterArray[2].Value = item[2].ToString();
					}
					sqlParameterArray[3].Value = item[3].ToString();
					sqlParameterArray[4].Value = item[4].ToString();
					sqlParameterArray[5].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_updatedata", sqlParameterArray);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						sqlCommand.ExecuteNonQuery();
						strMsg = Convert.ToString(sqlParameterArray[5].Value);
						int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
					}
					catch (SqlException sqlException1)
					{
						sqlException = sqlException1;
						sqlTransaction.Rollback();
						num1 = 85;
						DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
						OtherClass.AppendErrorLog(sqlException.Message);
						num = num1;
						return num;
					}
					if (num1 == 0)
					{
						for (int i = 0; i < strdellist.Count; i++)
						{
							string[] strArrays = strdellist[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strCondition", SqlDbType.NVarChar, 4000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
							SqlParameter[] str1 = sqlParameter;
							str1[0].Value = strArrays[0].ToString();
							str1[1].Value = strArrays[1].ToString();
							str1[2].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_deletedata", str1);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								sqlCommand.ExecuteNonQuery();
								strMsg = Convert.ToString(str1[2].Value);
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
							}
							catch (SqlException sqlException2)
							{
								sqlException = sqlException2;
								strMsg = Convert.ToString(str1[2].Value);
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
						for (int j = 1; j < StrParameters.Count; j++)
						{
							string[] item1 = StrParameters[j];
							if (!(item1[7].ToString() == "0"))
							{
								sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000), new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
								SqlParameter[] str2 = sqlParameter;
								str2[0].Value = item1[0].ToString();
								str2[1].Value = item1[1].ToString();
								str2[2].Value = item1[2].ToString();
								str2[3].Value = item1[3].ToString();
								str2[4].Value = item1[4].ToString();
								str2[5].Direction = ParameterDirection.Output;
								sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_updatedata", str2);
								sqlCommand.Transaction = sqlTransaction;
								try
								{
									sqlCommand.ExecuteNonQuery();
									strMsg = Convert.ToString(str2[5].Value);
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								}
								catch (SqlException sqlException3)
								{
									sqlException = sqlException3;
									strMsg = Convert.ToString(str2[5].Value);
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
							else
							{
								sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strRepeat", SqlDbType.NVarChar, 50), new SqlParameter("@strTbid", SqlDbType.NVarChar, 50), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200), new SqlParameter("@iTbid", SqlDbType.Int) };
								SqlParameter[] sqlParameterArray2 = sqlParameter;
								sqlParameterArray2[0].Value = item1[0].ToString();
								sqlParameterArray2[1].Value = string.Concat(item1[1].ToString(), ",", item1[6].ToString());
								sqlParameterArray2[2].Value = string.Concat(item1[2].ToString(), ",", item1[8].ToString());
								SqlParameter sqlParameter2 = sqlParameterArray2[3];
								str = new string[] { item1[3].ToString(), " and ", item1[6].ToString(), "=", item1[8].ToString() };
								sqlParameter2.Value = string.Concat(str);
								sqlParameterArray2[4].Value = item1[4].ToString();
								sqlParameterArray2[5].Value = item1[5].ToString();
								sqlParameterArray2[6].Direction = ParameterDirection.Output;
								sqlParameterArray2[7].Direction = ParameterDirection.Output;
								sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_insertdata", sqlParameterArray2);
								sqlCommand.Transaction = sqlTransaction;
								try
								{
									sqlCommand.ExecuteNonQuery();
									strMsg = Convert.ToString(sqlParameterArray2[6].Value);
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								}
								catch (SqlException sqlException4)
								{
									sqlException = sqlException4;
									strMsg = Convert.ToString(sqlParameterArray2[6].Value);
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int UpdateManyProcedureTran(List<string[]> StrParameters, List<string[]> strdellist, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000), new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					str[1].Value = item[1].ToString();
					str[2].Value = item[2].ToString();
					str[3].Value = item[3].ToString();
					str[4].Value = item[4].ToString();
					str[5].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_updatedata", str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						try
						{
							sqlCommand.ExecuteNonQuery();
							strMsg = Convert.ToString(str[5].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException1)
						{
							sqlException = sqlException1;
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					finally
					{
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
						}
					}
					if (num1 == 0)
					{
						for (int i = 0; i < strdellist.Count; i++)
						{
							string[] strArrays = strdellist[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strCondition", SqlDbType.NVarChar, 4000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
							SqlParameter[] sqlParameterArray = sqlParameter;
							sqlParameterArray[0].Value = strArrays[0].ToString();
							sqlParameterArray[1].Value = strArrays[1].ToString();
							sqlParameterArray[2].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_deletedata", sqlParameterArray);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								try
								{
									sqlCommand.ExecuteNonQuery();
									strMsg = Convert.ToString(sqlParameterArray[2].Value);
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								}
								catch (SqlException sqlException2)
								{
									sqlException = sqlException2;
									strMsg = Convert.ToString(sqlParameterArray[2].Value);
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
							finally
							{
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
								}
							}
						}
						for (int j = 1; j < StrParameters.Count; j++)
						{
							string[] item1 = StrParameters[j];
							if (!(item1[4].ToString() == "0"))
							{
								sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000), new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
								SqlParameter[] str1 = sqlParameter;
								str1[0].Value = item1[0].ToString();
								str1[1].Value = item1[1].ToString();
								str1[2].Value = item1[2].ToString();
								str1[3].Value = "";
								str1[4].Value = item1[2].ToString();
								str1[5].Direction = ParameterDirection.Output;
								sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_updatedata", str1);
								sqlCommand.Transaction = sqlTransaction;
								try
								{
									try
									{
										sqlCommand.ExecuteNonQuery();
										strMsg = Convert.ToString(str1[5].Value);
										int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
									}
									catch (SqlException sqlException3)
									{
										sqlException = sqlException3;
										strMsg = Convert.ToString(str1[5].Value);
										sqlTransaction.Rollback();
										num1 = 85;
										DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
										OtherClass.AppendErrorLog(sqlException.Message);
										num = num1;
										return num;
									}
								}
								finally
								{
									if (num1 != 0)
									{
										sqlTransaction.Rollback();
									}
								}
							}
							else
							{
								sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000) };
								SqlParameter[] sqlParameterArray1 = sqlParameter;
								sqlParameterArray1[0].Value = item1[0].ToString();
								sqlParameterArray1[1].Value = string.Concat(item1[1].ToString(), ",", item1[3].ToString());
								sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, item1[2].ToString(), sqlParameterArray1);
								sqlCommand.Transaction = sqlTransaction;
								try
								{
									try
									{
										sqlCommand.ExecuteNonQuery();
										int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
									}
									catch (SqlException sqlException4)
									{
										sqlException = sqlException4;
										sqlTransaction.Rollback();
										num1 = 85;
										DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
										OtherClass.AppendErrorLog(sqlException.Message);
										num = num1;
										return num;
									}
								}
								finally
								{
									if (num1 != 0)
									{
										sqlTransaction.Rollback();
									}
								}
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int UpdateManyProcedureTran(string storedProcName, List<string[]> StrParameters, List<string[]> strdellist, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.VarChar, 50), new SqlParameter("@iOperator", SqlDbType.Int, 4), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					str[1].Value = item[1].ToString();
					str[2].Value = int.Parse(item[2].ToString());
					str[3].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						try
						{
							sqlCommand.ExecuteNonQuery();
							strMsg = Convert.ToString(str[3].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException1)
						{
							sqlException = sqlException1;
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					finally
					{
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
						}
					}
					if (num1 == 0)
					{
						for (int i = 0; i < strdellist.Count; i++)
						{
							string[] strArrays = strdellist[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
							SqlParameter[] sqlParameterArray = sqlParameter;
							sqlParameterArray[0].Value = strArrays[0].ToString();
							sqlParameterArray[1].Value = strArrays[1].ToString();
							sqlParameterArray[2].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_deletedata", sqlParameterArray);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								try
								{
									sqlCommand.ExecuteNonQuery();
									strMsg = Convert.ToString(sqlParameterArray[2].Value);
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								}
								catch (SqlException sqlException2)
								{
									sqlException = sqlException2;
									strMsg = Convert.ToString(sqlParameterArray[2].Value);
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
							finally
							{
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
								}
							}
						}
						for (int j = 1; j < StrParameters.Count; j++)
						{
							string[] item1 = StrParameters[j];
							if (!(item1[4].ToString() == "0"))
							{
								sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000), new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
								SqlParameter[] str1 = sqlParameter;
								str1[0].Value = item1[0].ToString();
								str1[1].Value = item1[1].ToString();
								str1[2].Value = item1[2].ToString();
								str1[3].Value = "";
								str1[4].Value = item1[2].ToString();
								str1[5].Direction = ParameterDirection.Output;
								sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_updatedata", str1);
								sqlCommand.Transaction = sqlTransaction;
								try
								{
									try
									{
										sqlCommand.ExecuteNonQuery();
										strMsg = Convert.ToString(str1[5].Value);
										int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
									}
									catch (SqlException sqlException3)
									{
										sqlException = sqlException3;
										strMsg = Convert.ToString(str1[5].Value);
										sqlTransaction.Rollback();
										num1 = 85;
										DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
										OtherClass.AppendErrorLog(sqlException.Message);
										num = num1;
										return num;
									}
								}
								finally
								{
									if (num1 != 0)
									{
										sqlTransaction.Rollback();
									}
								}
							}
							else
							{
								sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.Int) };
								SqlParameter[] sqlParameterArray1 = sqlParameter;
								sqlParameterArray1[0].Value = item1[0].ToString();
								sqlParameterArray1[1].Value = string.Concat(item1[1].ToString(), ",", item1[3].ToString());
								sqlParameterArray1[2].Direction = ParameterDirection.Output;
								sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, item1[2].ToString(), sqlParameterArray1);
								sqlCommand.Transaction = sqlTransaction;
								try
								{
									try
									{
										sqlCommand.ExecuteNonQuery();
										int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
									}
									catch (SqlException sqlException4)
									{
										sqlException = sqlException4;
										sqlTransaction.Rollback();
										num1 = 85;
										DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
										OtherClass.AppendErrorLog(sqlException.Message);
										num = num1;
										return num;
									}
								}
								finally
								{
									if (num1 != 0)
									{
										sqlTransaction.Rollback();
									}
								}
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int UpdateManyProcedureTran(string storedProcName, List<string[]> StrParameters, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				int num2 = 0;
				int num3 = 0;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.VarChar, 50), new SqlParameter("@iOperator", SqlDbType.Int, 4), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					str[1].Value = item[1].ToString();
					str[2].Value = int.Parse(item[2].ToString());
					num3 = int.Parse(item[2].ToString());
					num2 = int.Parse(item[1].ToString());
					str[3].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						try
						{
							sqlCommand.ExecuteNonQuery();
							strMsg = Convert.ToString(str[3].Value);
							int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						}
						catch (SqlException sqlException1)
						{
							sqlException = sqlException1;
							sqlTransaction.Rollback();
							num1 = 85;
							DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
							OtherClass.AppendErrorLog(sqlException.Message);
							num = num1;
							return num;
						}
					}
					finally
					{
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
						}
					}
					string str1 = "";
					if (num1 == 0)
					{
						for (int i = 1; i < StrParameters.Count; i++)
						{
							string[] strArrays = StrParameters[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.Int) };
							SqlParameter[] sqlParameterArray = sqlParameter;
							sqlParameterArray[0].Value = strArrays[0].ToString();
							sqlParameterArray[1].Value = string.Concat(strArrays[1].ToString(), ",", strArrays[3].ToString());
							sqlParameterArray[2].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, strArrays[2].ToString(), sqlParameterArray);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								try
								{
									sqlCommand.ExecuteNonQuery();
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
									str1 = (!(str1 != "") ? Convert.ToString(sqlParameterArray[2].Value) : string.Concat(str1, ",", Convert.ToString(sqlParameterArray[2].Value)));
								}
								catch (SqlException sqlException2)
								{
									sqlException = sqlException2;
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
							finally
							{
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
								}
							}
						}
					}
					if (str1 != "")
					{
						if (num1 == 0)
						{
							sqlParameter = new SqlParameter[] { new SqlParameter("@iTbid", SqlDbType.Int), new SqlParameter("@strlistid", SqlDbType.VarChar, 200), new SqlParameter("@iOperator", SqlDbType.Int), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
							SqlParameter[] sqlParameterArray1 = sqlParameter;
							sqlParameterArray1[0].Value = num2;
							sqlParameterArray1[1].Value = str1;
							sqlParameterArray1[2].Value = num3;
							sqlParameterArray1[3].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "zl_zj_ck", sqlParameterArray1);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								sqlCommand.ExecuteNonQuery();
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								strMsg = Convert.ToString(sqlParameterArray1[3].Value);
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
									num = num1;
									return num;
								}
							}
							catch (SqlException sqlException3)
							{
								sqlException = sqlException3;
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int UpdateProcedureTran(List<string[]> StrParameters, List<string[]> strdellist, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlParameter[] sqlParameter;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					if (num1 == 0)
					{
						for (int i = 0; i < strdellist.Count; i++)
						{
							string[] item = strdellist[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
							SqlParameter[] str = sqlParameter;
							str[0].Value = item[0].ToString();
							str[1].Value = item[1].ToString();
							str[2].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_deletedata", str);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								try
								{
									sqlCommand.ExecuteNonQuery();
									strMsg = Convert.ToString(str[2].Value);
									int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								}
								catch (SqlException sqlException1)
								{
									sqlException = sqlException1;
									strMsg = Convert.ToString(str[2].Value);
									sqlTransaction.Rollback();
									num1 = 85;
									DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
									OtherClass.AppendErrorLog(sqlException.Message);
									num = num1;
									return num;
								}
							}
							finally
							{
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
								}
							}
						}
						for (int j = 0; j < StrParameters.Count; j++)
						{
							string[] strArrays = StrParameters[j];
							if (!(strArrays[3].ToString() == "0"))
							{
								sqlParameter = new SqlParameter[] { new SqlParameter("@strTbName", SqlDbType.NVarChar, 50), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000), new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000), new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
								SqlParameter[] sqlParameterArray = sqlParameter;
								sqlParameterArray[0].Value = strArrays[0].ToString();
								sqlParameterArray[1].Value = strArrays[1].ToString();
								sqlParameterArray[2].Value = strArrays[2].ToString();
								sqlParameterArray[3].Value = "";
								sqlParameterArray[4].Value = strArrays[2].ToString();
								sqlParameterArray[5].Direction = ParameterDirection.Output;
								sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "aa_updatedata", sqlParameterArray);
								sqlCommand.Transaction = sqlTransaction;
								try
								{
									try
									{
										sqlCommand.ExecuteNonQuery();
										strMsg = Convert.ToString(sqlParameterArray[5].Value);
										int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
									}
									catch (SqlException sqlException2)
									{
										sqlException = sqlException2;
										strMsg = Convert.ToString(sqlParameterArray[5].Value);
										sqlTransaction.Rollback();
										num1 = 85;
										DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
										OtherClass.AppendErrorLog(sqlException.Message);
										num = num1;
										return num;
									}
								}
								finally
								{
									if (num1 != 0)
									{
										sqlTransaction.Rollback();
									}
								}
							}
							else
							{
								sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000) };
								SqlParameter[] str1 = sqlParameter;
								str1[0].Value = strArrays[0].ToString();
								str1[1].Value = strArrays[1].ToString();
								sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, strArrays[2].ToString(), str1);
								sqlCommand.Transaction = sqlTransaction;
								try
								{
									try
									{
										sqlCommand.ExecuteNonQuery();
										int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
									}
									catch (SqlException sqlException3)
									{
										sqlException = sqlException3;
										sqlTransaction.Rollback();
										num1 = 85;
										DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
										OtherClass.AppendErrorLog(sqlException.Message);
										num = num1;
										return num;
									}
								}
								finally
								{
									if (num1 != 0)
									{
										sqlTransaction.Rollback();
									}
								}
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int ZK_RunProcedureTran(List<string[]> StrParameters, out string strMsg, out int iTbid)
		{
			SqlException sqlException;
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				iTbid = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.Int) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					str[1].Value = item[1].ToString();
					str[2].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, item[2].ToString(), str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						sqlCommand.ExecuteNonQuery();
						int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						iTbid = Convert.ToInt32(str[2].Value);
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
							num = num1;
							return num;
						}
					}
					catch (SqlException sqlException1)
					{
						sqlException = sqlException1;
						sqlTransaction.Rollback();
						num1 = 85;
						DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
						OtherClass.AppendErrorLog(sqlException.Message);
						num = num1;
						return num;
					}
					if (num1 == 0)
					{
						for (int i = 1; i < StrParameters.Count; i++)
						{
							string[] strArrays = StrParameters[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@iTbid1", SqlDbType.Int), new SqlParameter("@iTbid2", SqlDbType.Int), new SqlParameter("@dAmount1", SqlDbType.Decimal), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
							SqlParameter[] sqlParameterArray = sqlParameter;
							sqlParameterArray[0].Value = iTbid.ToString();
							sqlParameterArray[1].Value = strArrays[0].ToString();
							sqlParameterArray[2].Value = strArrays[1].ToString();
							sqlParameterArray[3].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "zk_sfk_yy_kd", sqlParameterArray);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								sqlCommand.ExecuteNonQuery();
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								strMsg = Convert.ToString(sqlParameterArray[3].Value);
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
									num = num1;
									return num;
								}
							}
							catch (SqlException sqlException2)
							{
								sqlException = sqlException2;
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int ZL_CB_InsertManyData(string storedProcName, List<string[]> StrParameters, out string strMsg)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				strMsg = string.Empty;
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					for (int i = 0; i < StrParameters.Count; i++)
					{
						string[] item = StrParameters[i];
						SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
						SqlParameter[] str = sqlParameter;
						str[0].Value = item[0].ToString();
						str[1].Value = item[1].ToString();
						str[2].Direction = ParameterDirection.Output;
						sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, storedProcName, str);
						sqlCommand.Transaction = sqlTransaction;
						try
						{
							try
							{
								sqlCommand.ExecuteNonQuery();
								strMsg = Convert.ToString(str[2].Value);
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
							}
							catch (SqlException sqlException1)
							{
								SqlException sqlException = sqlException1;
								strMsg = Convert.ToString(str[2].Value);
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
						finally
						{
							if (num1 != 0)
							{
								sqlTransaction.Rollback();
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int ZL_JS_RunProcedureTran(List<string[]> StrParameters, out int iTbid, out string strMsg)
		{
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				iTbid = 0;
				strMsg = "";
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.Int) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					str[1].Value = item[1].ToString();
					str[2].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, item[2].ToString(), str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						sqlCommand.ExecuteNonQuery();
						iTbid = Convert.ToInt32(str[2].Value);
						int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
							num = num1;
							return num;
						}
					}
					catch (SqlException sqlException1)
					{
						SqlException sqlException = sqlException1;
						sqlTransaction.Rollback();
						num1 = 85;
						DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
						OtherClass.AppendErrorLog(sqlException.Message);
						num = num1;
						return num;
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}

		public static int ZL_RunProcedureTran(List<string[]> StrParameters, int bchk, int iflag, int iOperator, out int iTbid, out string strMsg)
		{
			SqlException sqlException;
			int num;
			SqlConnection sqlConnection = new SqlConnection(DbHelperSQL.connectionString);
			try
			{
				int num1 = 0;
				iTbid = 0;
				strMsg = "";
				sqlConnection.Open();
				SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
				try
				{
					SqlCommand sqlCommand = null;
					string[] item = StrParameters[0];
					SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.Int) };
					SqlParameter[] str = sqlParameter;
					str[0].Value = item[0].ToString();
					str[1].Value = item[1].ToString();
					str[2].Direction = ParameterDirection.Output;
					sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, item[2].ToString(), str);
					sqlCommand.Transaction = sqlTransaction;
					try
					{
						sqlCommand.ExecuteNonQuery();
						iTbid = Convert.ToInt32(str[2].Value);
						int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
						if (num1 != 0)
						{
							sqlTransaction.Rollback();
							num = num1;
							return num;
						}
					}
					catch (SqlException sqlException1)
					{
						sqlException = sqlException1;
						sqlTransaction.Rollback();
						num1 = 85;
						DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
						OtherClass.AppendErrorLog(sqlException.Message);
						num = num1;
						return num;
					}
					if (num1 == 0)
					{
						for (int i = 1; i < StrParameters.Count; i++)
						{
							string[] strArrays = StrParameters[i];
							sqlParameter = new SqlParameter[] { new SqlParameter("@strFldName", SqlDbType.NVarChar, 500), new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000), new SqlParameter("@iTbid", SqlDbType.Int) };
							SqlParameter[] sqlParameterArray = sqlParameter;
							sqlParameterArray[0].Value = strArrays[0].ToString();
							sqlParameterArray[1].Value = string.Concat(strArrays[1].ToString(), ",", iTbid.ToString());
							sqlParameterArray[2].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, strArrays[2].ToString(), sqlParameterArray);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								sqlCommand.ExecuteNonQuery();
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
									num = num1;
									return num;
								}
							}
							catch (SqlException sqlException2)
							{
								sqlException = sqlException2;
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
					}
					if (bchk == 1)
					{
						if (num1 == 0)
						{
							sqlParameter = new SqlParameter[] { new SqlParameter("@flag", SqlDbType.Int), new SqlParameter("@iTbid", SqlDbType.Int), new SqlParameter("@iOperator", SqlDbType.Int), new SqlParameter("@strMsg", SqlDbType.NVarChar, 200) };
							SqlParameter[] sqlParameterArray1 = sqlParameter;
							str[0].Value = iflag;
							sqlParameterArray1[1].Value = iTbid;
							sqlParameterArray1[2].Value = iOperator;
							sqlParameterArray1[3].Direction = ParameterDirection.Output;
							sqlCommand = DbHelperSQL.BuildIntCommand(sqlConnection, "zl_zl_ck", sqlParameterArray1);
							sqlCommand.Transaction = sqlTransaction;
							try
							{
								sqlCommand.ExecuteNonQuery();
								int.TryParse(sqlCommand.Parameters["ReturnValue"].Value.ToString(), out num1);
								strMsg = Convert.ToString(sqlParameterArray1[3].Value);
								if (num1 != 0)
								{
									sqlTransaction.Rollback();
									num = num1;
									return num;
								}
							}
							catch (SqlException sqlException3)
							{
								sqlException = sqlException3;
								sqlTransaction.Rollback();
								num1 = 85;
								DbHelperSQL.InsertErrorLog(0, 0, sqlException.Message, 0);
								OtherClass.AppendErrorLog(sqlException.Message);
								num = num1;
								return num;
							}
						}
					}
					if (num1 == 0)
					{
						sqlTransaction.Commit();
					}
				}
				finally
				{
					if (sqlTransaction != null)
					{
						((IDisposable)sqlTransaction).Dispose();
					}
				}
				num = num1;
			}
			finally
			{
				if (sqlConnection != null)
				{
					((IDisposable)sqlConnection).Dispose();
				}
			}
			return num;
		}
	}
}