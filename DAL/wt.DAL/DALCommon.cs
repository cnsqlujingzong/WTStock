using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using wt.DB;

namespace wt.DAL
{
	public class DALCommon
	{
		public static DataSet GetList_HL(int iPaging, string TblName, string FldName, int PageSize, int page, string strCondition, string fldSort, out int count)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iPaging", SqlDbType.Int),
				new SqlParameter("@TblName", SqlDbType.NVarChar, 50),
				new SqlParameter("@fldName", SqlDbType.NVarChar, 4000),
				new SqlParameter("@PageSize", SqlDbType.Int),
				new SqlParameter("@page", SqlDbType.Int),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 2000),
				new SqlParameter("@fldSort", SqlDbType.NVarChar, 500),
				new SqlParameter("@Counts", SqlDbType.Int)
			};
			array[0].Value = iPaging;
			array[1].Value = TblName;
			array[2].Value = FldName;
			array[3].Value = PageSize;
			array[4].Value = page;
			array[5].Value = strCondition;
			array[6].Value = fldSort;
			array[7].Direction = ParameterDirection.Output;
			return DbHelperSQL.RunPageProcedure("aa_searchdata", array, out count);
		}

		public static string TCount(string Table, string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from " + Table + " ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return Convert.ToString(DbHelperSQL.GetSingle(stringBuilder.ToString()));
		}

		public static DataSet GetList(string TbName, string TbFieldName, string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ");
			stringBuilder.Append(TbFieldName);
			stringBuilder.Append(" from ");
			stringBuilder.Append(TbName);
			stringBuilder.Append(" where " + strWhere);
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public static DataSet GetDataList(string TblName, string fldName, string strCondition)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@TblName", SqlDbType.NVarChar, 500),
				new SqlParameter("@fldName", SqlDbType.NVarChar, 4000),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 4000)
			};
			array[0].Value = TblName;
			array[1].Value = fldName;
			array[2].Value = strCondition;
			return DbHelperSQL.RunProcedureDs("aa_getdatalist", array);
		}

		public static DataSet GetStDayData(string storedProcName, int iDept, DateTime StartDate, DateTime EndDate)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@StartDate", SqlDbType.DateTime),
				new SqlParameter("@EndDate", SqlDbType.DateTime)
			};
			array[0].Value = iDept;
			array[1].Value = StartDate;
			array[2].Value = EndDate;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStDayData(string storedProcName, int iDept, DateTime StartDate, DateTime EndDate, int iStockID)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@StartDate", SqlDbType.DateTime),
				new SqlParameter("@EndDate", SqlDbType.DateTime),
				new SqlParameter("@StockID", SqlDbType.Int)
			};
			array[0].Value = iDept;
			array[1].Value = StartDate;
			array[2].Value = EndDate;
			array[3].Value = iStockID;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStDayData(string storedProcName, int iDept, string StartDate)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@StrDate", SqlDbType.VarChar, 50)
			};
			array[0].Value = iDept;
			array[1].Value = StartDate;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStDayData(string storedProcName, int iDept, string StartDate, string EndDate)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@StrDate", SqlDbType.VarChar, 50),
				new SqlParameter("@EndDate", SqlDbType.VarChar, 50)
			};
			array[0].Value = iDept;
			array[1].Value = StartDate;
			array[2].Value = EndDate;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStDayDataDe(string storedProcName, int StaffID, string StartDate, string EndDate)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StaffID", SqlDbType.Int),
				new SqlParameter("@StrDate", SqlDbType.VarChar, 50),
				new SqlParameter("@EndDate", SqlDbType.VarChar, 50)
			};
			array[0].Value = StaffID;
			array[1].Value = StartDate;
			array[2].Value = EndDate;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStDayData(string storedProcName, int iDept, int iStartYear, int iStartMonth)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@iStartYear", SqlDbType.Int),
				new SqlParameter("@iStartMonth", SqlDbType.Int)
			};
			array[0].Value = iDept;
			array[1].Value = iStartYear;
			array[2].Value = iStartMonth;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStDayData(string storedProcName, int iDept, int iStartYear)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@iStartYear", SqlDbType.Int)
			};
			array[0].Value = iDept;
			array[1].Value = iStartYear;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStStrData(string storedProcName, string strCondition, DateTime StartDate, DateTime EndDate)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StartDate", SqlDbType.DateTime),
				new SqlParameter("@EndDate", SqlDbType.DateTime),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 500)
			};
			array[0].Value = StartDate;
			array[1].Value = EndDate;
			array[2].Value = strCondition;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStStr(string storedProcName, string strCondition)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 500)
			};
			array[0].Value = strCondition;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStIStr(string storedProcName, int iflag, string strCondition)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int, 4),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 500)
			};
			array[0].Value = iflag;
			array[1].Value = strCondition;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStData(string storedProcName, int iFlag, string strCondition, string strOrderFld)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 500),
				new SqlParameter("@strOrderFld", SqlDbType.NVarChar, 50)
			};
			array[0].Value = iFlag;
			array[1].Value = strCondition;
			array[2].Value = strOrderFld;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStZhBB(string storedProcName, string strStart, string strEnd, string strCondition1, string strCondition2)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strStart", SqlDbType.NVarChar, 50),
				new SqlParameter("@strEnd", SqlDbType.NVarChar, 50),
				new SqlParameter("@strCondition1", SqlDbType.NVarChar, 500),
				new SqlParameter("@strCondition2", SqlDbType.NVarChar, 500)
			};
			array[0].Value = strStart;
			array[1].Value = strEnd;
			array[2].Value = strCondition1;
			array[3].Value = strCondition2;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStZhDetail(string storedProcName, int iFlag, string strCondition1, string strCondition2)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@strCondition1", SqlDbType.NVarChar, 500),
				new SqlParameter("@strCondition2", SqlDbType.NVarChar, 500)
			};
			array[0].Value = iFlag;
			array[1].Value = strCondition1;
			array[2].Value = strCondition2;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStMKBB(string storedProcName, int iFlag, string strStart, string strEnd, string strCondition1, string strCondition2)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@strStart", SqlDbType.NVarChar, 50),
				new SqlParameter("@strEnd", SqlDbType.NVarChar, 50),
				new SqlParameter("@strCondition1", SqlDbType.NVarChar, 500),
				new SqlParameter("@strCondition2", SqlDbType.NVarChar, 500)
			};
			array[0].Value = iFlag;
			array[1].Value = strStart;
			array[2].Value = strEnd;
			array[3].Value = strCondition1;
			array[4].Value = strCondition2;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetStMKBB(string storedProcName, int iFlag, string strStart, string strEnd, string strCondition1, string strCondition2, string strCondition3, string strCondition4)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@strStart", SqlDbType.NVarChar, 50),
				new SqlParameter("@strEnd", SqlDbType.NVarChar, 50),
				new SqlParameter("@strCondition1", SqlDbType.NVarChar, 500),
				new SqlParameter("@strCondition2", SqlDbType.NVarChar, 500),
				new SqlParameter("@strCondition3", SqlDbType.NVarChar, 500),
				new SqlParameter("@strCondition4", SqlDbType.NVarChar, 500)
			};
			array[0].Value = iFlag;
			array[1].Value = strStart;
			array[2].Value = strEnd;
			array[3].Value = strCondition1;
			array[4].Value = strCondition2;
			array[5].Value = strCondition3;
			array[6].Value = strCondition4;
			return DbHelperSQL.RunProcedureDs(storedProcName, array);
		}

		public static DataSet GetGoodsPriceList(int iFlag1, int DeptID, int iGoodsid, int iUnitid, int iCusid, int iStockid)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag1", SqlDbType.Int),
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@iGoodsid", SqlDbType.Int),
				new SqlParameter("@iUnitid", SqlDbType.Int),
				new SqlParameter("@iCusid", SqlDbType.Int),
				new SqlParameter("@iStockid", SqlDbType.Int)
			};
			array[0].Value = iFlag1;
			array[1].Value = DeptID;
			array[2].Value = iGoodsid;
			array[3].Value = iUnitid;
			array[4].Value = iCusid;
			array[5].Value = iStockid;
			return DbHelperSQL.RunProcedureDs("aa_getgoodspricelist", array);
		}

		public static string CreateID(int iBillid, int iPost)
		{
			if (iBillid == 22)
			{
				DALSysParm dALSysParm = new DALSysParm();
				if (dALSysParm.bSerSep() && HttpContext.Current.Session["Session_wtBranchID"] != null)
				{
					string s = iBillid.ToString() + HttpContext.Current.Session["Session_wtBranchID"].ToString().Trim();
					iBillid = int.Parse(s);
				}
			}
			if (iBillid == 16 || iBillid == 17)
			{
				DALSysParm dALSysParm = new DALSysParm();
				if (dALSysParm.bPurSep() && HttpContext.Current.Session["Session_wtBranchID"] != null)
				{
					string s = iBillid.ToString() + HttpContext.Current.Session["Session_wtBranchID"].ToString().Trim();
					iBillid = int.Parse(s);
				}
			}
			if (iBillid == 19 || iBillid == 20)
			{
				DALSysParm dALSysParm = new DALSysParm();
				if (dALSysParm.bSellSep() && HttpContext.Current.Session["Session_wtBranchID"] != null)
				{
					string s = iBillid.ToString() + HttpContext.Current.Session["Session_wtBranchID"].ToString().Trim();
					iBillid = int.Parse(s);
				}
			}
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iBillid", SqlDbType.Int),
				new SqlParameter("@iPost", SqlDbType.Int),
				new SqlParameter("@strBillid", SqlDbType.NVarChar, 50)
			};
			array[0].Value = iBillid;
			array[1].Value = iPost;
			array[2].Direction = ParameterDirection.Output;
			DbHelperSQL.RunProcedure("aa_createbillid", array);
			return Convert.ToString(array[2].Value);
		}

		public static int InsertData(string strTbName, string strFldName, string strFldContent, string strCondition, string strRepeat, string strTbid, out string strMsg, out int iTbid)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strTbName", SqlDbType.NVarChar, 50),
				new SqlParameter("@strFldName", SqlDbType.NVarChar, 500),
				new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000),
				new SqlParameter("@strRepeat", SqlDbType.NVarChar, 50),
				new SqlParameter("@strTbid", SqlDbType.NVarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200),
				new SqlParameter("@iTbid", SqlDbType.Int)
			};
			array[0].Value = strTbName;
			array[1].Value = strFldName;
			array[2].Value = strFldContent;
			array[3].Value = strCondition;
			array[4].Value = strRepeat;
			array[5].Value = strTbid;
			array[6].Direction = ParameterDirection.Output;
			array[7].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_insertdata", array);
			strMsg = Convert.ToString(array[6].Value);
			iTbid = Convert.ToInt32(array[7].Value);
			return result;
		}

		public static int UpdateData(string strTbName, string strFldContent, string strCheckid, string strCheckFld, string strCondition, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strTbName", SqlDbType.NVarChar, 50),
				new SqlParameter("@strFldContent", SqlDbType.NVarChar, 4000),
				new SqlParameter("@strCheckid", SqlDbType.NVarChar, 1000),
				new SqlParameter("@strCheckFld", SqlDbType.NVarChar, 1000),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strTbName;
			array[1].Value = strFldContent;
			array[2].Value = strCheckid;
			array[3].Value = strCheckFld;
			array[4].Value = strCondition;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_updatedata", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}

		public static int DeteleData(string strTbName, string strCondition, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strTbName", SqlDbType.NVarChar, 50),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 1000),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strTbName;
			array[1].Value = strCondition;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_deletedata", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public static int DeteleData(int iFlag1, int iFlag2, int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag1", SqlDbType.Int),
				new SqlParameter("@iFlag2", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iFlag1;
			array[1].Value = iFlag2;
			array[2].Value = iTbid;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_deletemd", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public static int InsertTreeData(string strTbName, string strFldContent, string strCondition, string strTbid, int iParentid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strTbName", SqlDbType.NVarChar, 50),
				new SqlParameter("@strFldContent", SqlDbType.NVarChar, 100),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 100),
				new SqlParameter("@strTbid", SqlDbType.NVarChar, 50),
				new SqlParameter("@iParentid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strTbName;
			array[1].Value = strFldContent;
			array[2].Value = strCondition;
			array[3].Value = strTbid;
			array[4].Value = iParentid;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_inserttreecode", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}

		public static int UpdateTreeData(int iFlag, string strTbName, string strFldContent, string strCondition, string strTbid, int iTbid, int iNewParentid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@strTbName", SqlDbType.NVarChar, 50),
				new SqlParameter("@strFldContent", SqlDbType.NVarChar, 100),
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 100),
				new SqlParameter("@strTbid", SqlDbType.NVarChar, 50),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iNewParentid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iFlag;
			array[1].Value = strTbName;
			array[2].Value = strFldContent;
			array[3].Value = strCondition;
			array[4].Value = strTbid;
			array[5].Value = iTbid;
			array[6].Value = iNewParentid;
			array[7].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_updatetreecode", array);
			strMsg = Convert.ToString(array[7].Value);
			return result;
		}

		public static int DeteleTreeData(string strTbName, int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strTbName", SqlDbType.NVarChar, 50),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strTbName;
			array[1].Value = iTbid;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_deletetreecode", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public static int checkformula(string strFormula)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strFormula", SqlDbType.NVarChar, 1000)
			};
			array[0].Value = strFormula;
			return DbHelperSQL.RunProcedureTran("aa_checkformula", array);
		}

		public static int GetGoodsPrice(int DeptID, int iStock, int iGoods, decimal dCount, out decimal Price)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@iStock", SqlDbType.Int),
				new SqlParameter("@iGoods", SqlDbType.Int),
				new SqlParameter("@dCount", SqlDbType.Decimal),
				new SqlParameter("@Price", SqlDbType.Decimal)
			};
			array[0].Value = DeptID;
			array[1].Value = iStock;
			array[2].Value = iGoods;
			array[3].Value = dCount;
			array[4].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("aa_getgoodsprice", array);
			Price = Convert.ToDecimal(array[4].Value);
			return result;
		}

		public static void xt_loginstart(int DeptID)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int)
			};
			array[0].Value = DeptID;
			DbHelperSQL.RunProcedure("xt_loginstart", array);
		}

		public static void aa_gridinit(int iFlag, int DeptID)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@DeptID", SqlDbType.Int)
			};
			array[0].Value = iFlag;
			array[1].Value = DeptID;
			DbHelperSQL.RunProcedure("aa_gridinit", array);
		}

		public static DataSet aa_gettoolbar(int iDeptid, int iStaffid)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iStaffid", SqlDbType.Int)
			};
			array[0].Value = iDeptid;
			array[1].Value = iStaffid;
			return DbHelperSQL.RunProcedureDs("aa_gettoolbar", array);
		}

		public static DataSet aa_getright(int RightID)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@RightID", SqlDbType.Int)
			};
			array[0].Value = RightID;
			return DbHelperSQL.RunProcedureDs("aa_getright", array);
		}

		public static void Excu(string strSql)
		{
			DbHelperSQL.ExecuteSql(strSql);
		}

		public static DataSet GetListBX(string dateStart, string dateEnd, string status, int flag, string context, string deptname)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@dates", SqlDbType.VarChar, 20),
				new SqlParameter("@datee", SqlDbType.VarChar, 20),
				new SqlParameter("@status", SqlDbType.VarChar, 20),
				new SqlParameter("@flag", SqlDbType.Int, 4),
				new SqlParameter("@context", SqlDbType.VarChar, 100),
				new SqlParameter("@deptname", SqlDbType.VarChar, 100)
			};
			array[0].Value = dateStart;
			array[1].Value = dateEnd;
			array[2].Value = status;
			array[3].Value = flag;
			array[4].Value = context;
			array[5].Value = deptname;
			return DbHelperSQL.RunProcedureDs("aa_bx_bxdetail", array);
		}

		public static int GetID(string table, string sqlWhere)
		{
			string sQLString = "select [ID] from " + table + "  where  " + sqlWhere;
			DataSet dataSet = DbHelperSQL.Query(sQLString);
			int num = 0;
			int result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				int.TryParse(dataSet.Tables[0].Rows[0][0].ToString(), out num);
				result = num;
			}
			else
			{
				result = num;
			}
			return result;
		}

		public static string GetTabNameByID(string table, int? id)
		{
			string sQLString = "select _Name from " + table + " where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			string result;
			if (dataTable.Rows.Count > 0)
			{
				result = dataTable.Rows[0][0].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
