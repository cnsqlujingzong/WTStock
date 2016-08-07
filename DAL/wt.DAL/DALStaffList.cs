using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALStaffList
	{
		public int Add(StaffListInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			string text3 = " JobNO='" + model.JobNO + "'";
			if (model.DeptID > 0)
			{
				text3 = text3 + " and DeptID=" + model.DeptID.ToString();
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID;
			}
			else
			{
				text3 += " and DeptID is null ";
			}
			if (model.JobNO != string.Empty)
			{
				text += ",JobNO";
				text2 = text2 + ",'" + model.JobNO + "'";
			}
			if (model.Sex != string.Empty)
			{
				text += ",Sex";
				text2 = text2 + ",'" + model.Sex + "'";
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
			if (model.Area != string.Empty)
			{
				text += ",Area";
				text2 = text2 + ",'" + model.Area + "'";
			}
			if (model.NativePlace != string.Empty)
			{
				text += ",NativePlace";
				text2 = text2 + ",'" + model.NativePlace + "'";
			}
			if (model.CardID != string.Empty)
			{
				text += ",CardID";
				text2 = text2 + ",'" + model.CardID + "'";
			}
			if (model.BirthDate != string.Empty)
			{
				text += ",BirthDate";
				text2 = text2 + ",'" + model.BirthDate + "'";
			}
			if (model.Academic != string.Empty)
			{
				text += ",Academic";
				text2 = text2 + ",'" + model.Academic + "'";
			}
			if (model.School != string.Empty)
			{
				text += ",School";
				text2 = text2 + ",'" + model.School + "'";
			}
			if (model.Specialty != string.Empty)
			{
				text += ",Specialty";
				text2 = text2 + ",'" + model.Specialty + "'";
			}
			if (model.JobDate != string.Empty)
			{
				text += ",JobDate";
				text2 = text2 + ",'" + model.JobDate + "'";
			}
			if (model.Qid > 0)
			{
				text += ",Qid";
				text2 = text2 + "," + model.Qid;
			}
			if (model.bTechnician)
			{
				text += ",bTechnician";
				text2 += ",1";
			}
			if (model.bSeller)
			{
				text += ",bSeller";
				text2 += ",1";
			}
			if (model.bStockMan)
			{
				text += ",bStockMan";
				text2 += ",1";
			}
			if (model.bDestClerk)
			{
				text += ",bDestClerk";
				text2 += ",1";
			}
			if (model.bAllot)
			{
				text += ",bAllot";
				text2 += ",1";
			}
			if (model.bAccountant)
			{
				text += ",bAccountant";
				text2 += ",1";
			}
			if (model.bManage)
			{
				text += ",bManage";
				text2 += ",1";
			}
			if (model.Status > 0)
			{
				text += ",Status";
				text2 = text2 + "," + model.Status;
			}
			if (model.Salary > 0m)
			{
				text += ",Salary";
				text2 = text2 + "," + model.Salary;
			}
			if (model.Allowance > 0m)
			{
				text += ",Allowance";
				text2 = text2 + "," + model.Allowance;
			}
			if (model.Account != string.Empty)
			{
				text += ",Account";
				text2 = text2 + ",'" + model.Account + "'";
			}
			if (model.SellDeduct != string.Empty)
			{
				text += ",SellDeduct";
				text2 = text2 + ",'" + model.SellDeduct + "'";
			}
			if (model.BillDeduct != string.Empty)
			{
				text += ",BillDeduct";
				text2 = text2 + ",'" + model.BillDeduct + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.StaffDeptID > 0)
			{
				text += ",StaffDeptID";
				text2 = text2 + "," + model.StaffDeptID;
			}
			if (model.ftype > 0)
			{
				text += ",ftype";
				text2 = text2 + "," + model.ftype;
			}
			if (model.ProfitFormula != string.Empty)
			{
				text += ",ProfitFormula";
				text2 = text2 + ",'" + model.ProfitFormula + "'";
			}
			return DALCommon.InsertData("StaffList", text, text2, text3, "员工编号", "ID", out strMsg, out iTbid);
		}

		public int Add_Staff(string strname, string strjobno, string strsex, string strstatus, string strtel, string strquarters, string strbirthdate, string strnativeplace, string strcardid, string stracademic, string strschool, string strspecialty, string strjobdate, string strarea, decimal strsalary, decimal strallowance, string straccount, string stradr, string strremark, string strbdestclerk, string strballot, string strbtechnician, string strbseller, string strbaccounttant, string strbstockman, int depetid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strname", SqlDbType.VarChar, 50),
				new SqlParameter("@strjobno", SqlDbType.VarChar, 50),
				new SqlParameter("@strsex", SqlDbType.VarChar, 50),
				new SqlParameter("@strstatus", SqlDbType.VarChar, 50),
				new SqlParameter("@strtel", SqlDbType.VarChar, 50),
				new SqlParameter("@strquarters", SqlDbType.VarChar, 50),
				new SqlParameter("@strbirthdate", SqlDbType.VarChar, 50),
				new SqlParameter("@strnativeplace", SqlDbType.VarChar, 50),
				new SqlParameter("@strcardid", SqlDbType.VarChar, 50),
				new SqlParameter("@stracademic", SqlDbType.VarChar, 50),
				new SqlParameter("@strschool", SqlDbType.VarChar, 50),
				new SqlParameter("@strspecialty", SqlDbType.VarChar, 50),
				new SqlParameter("@strjobdate", SqlDbType.VarChar, 50),
				new SqlParameter("@strarea", SqlDbType.VarChar, 50),
				new SqlParameter("@strsalary", SqlDbType.Decimal, 9),
				new SqlParameter("@strallowance", SqlDbType.Decimal, 9),
				new SqlParameter("@straccount", SqlDbType.VarChar, 50),
				new SqlParameter("@stradr", SqlDbType.VarChar, 100),
				new SqlParameter("@strremark", SqlDbType.VarChar, 200),
				new SqlParameter("@strbdestclerk", SqlDbType.VarChar, 10),
				new SqlParameter("@strballot", SqlDbType.VarChar, 10),
				new SqlParameter("@strbtechnician", SqlDbType.VarChar, 10),
				new SqlParameter("@strbseller", SqlDbType.VarChar, 10),
				new SqlParameter("@strbaccounttant", SqlDbType.VarChar, 10),
				new SqlParameter("@strbstockman", SqlDbType.VarChar, 10),
				new SqlParameter("@depetid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strname;
			array[1].Value = strjobno;
			array[2].Value = strsex;
			array[3].Value = strstatus;
			array[4].Value = strtel;
			array[5].Value = strquarters;
			array[6].Value = strbirthdate;
			array[7].Value = strnativeplace;
			array[8].Value = strcardid;
			array[9].Value = stracademic;
			array[10].Value = strschool;
			array[11].Value = strspecialty;
			array[12].Value = strjobdate;
			array[13].Value = strarea;
			array[14].Value = strsalary;
			array[15].Value = strallowance;
			array[16].Value = straccount;
			array[17].Value = stradr;
			array[18].Value = strremark;
			array[19].Value = strbdestclerk;
			array[20].Value = strballot;
			array[21].Value = strbtechnician;
			array[22].Value = strbseller;
			array[23].Value = strbaccounttant;
			array[24].Value = strbstockman;
			array[25].Value = depetid;
			array[26].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("jc_inputstaff", array);
			strMsg = Convert.ToString(array[26].Value);
			return result;
		}

		public int Update(StaffListInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",JobNO='" + model.JobNO + "'";
			text = text + ",Sex='" + model.Sex + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",Area='" + model.Area + "'";
			text = text + ",NativePlace='" + model.NativePlace + "'";
			text = text + ",CardID='" + model.CardID + "'";
			text = text + ",BirthDate='" + model.BirthDate + "'";
			text = text + ",Academic='" + model.Academic + "'";
			text = text + ",School='" + model.School + "'";
			text = text + ",Specialty='" + model.Specialty + "'";
			text = text + ",JobDate='" + model.JobDate + "'";
			if (model.Qid > 0)
			{
				text = text + ",Qid=" + model.Qid;
			}
			else
			{
				text += ",Qid=null";
			}
			if (model.bTechnician)
			{
				text += ",bTechnician=1";
			}
			else
			{
				text += ",bTechnician=0";
			}
			if (model.bSeller)
			{
				text += ",bSeller=1";
			}
			else
			{
				text += ",bSeller=0";
			}
			if (model.bStockMan)
			{
				text += ",bStockMan=1";
			}
			else
			{
				text += ",bStockMan=0";
			}
			if (model.bDestClerk)
			{
				text += ",bDestClerk=1";
			}
			else
			{
				text += ",bDestClerk=0";
			}
			if (model.bAccountant)
			{
				text += ",bAccountant=1";
			}
			else
			{
				text += ",bAccountant=0";
			}
			if (model.bAllot)
			{
				text += ",bAllot=1";
			}
			else
			{
				text += ",bAllot=0";
			}
			if (model.bManage)
			{
				text += ",bManage=1";
			}
			else
			{
				text += ",bManage=0";
			}
			text = text + ",Salary=" + model.Salary.ToString();
			text = text + ",Allowance=" + model.Allowance.ToString();
			text = text + ",Status=" + model.Status;
			text = text + ",Account='" + model.Account + "'";
			text = text + ",SellDeduct='" + model.SellDeduct + "'";
			text = text + ",BillDeduct='" + model.BillDeduct + "'";
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",ProfitFormula='" + model.ProfitFormula + "'";
			if (model.ftype > 0)
			{
				text = text + ",ftype=" + model.ftype;
			}
			if (model.StaffDeptID > 0)
			{
				text = text + ",StaffDeptID=" + model.StaffDeptID;
			}
			else
			{
				text += ",StaffDeptID=0";
			}
			return DALCommon.UpdateData("StaffList", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public void UpdatePwd(int iTbid, string AttendancePwd)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update StaffList set ");
			stringBuilder.Append("AttendancePwd=@AttendancePwd");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@AttendancePwd", SqlDbType.VarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = AttendancePwd;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public StaffListInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 [ID],DeptID,JobNO,_Name,Sex,Tel,Area,Adr,NativePlace,CardID,BirthDate,Academic,School,Specialty,JobDate,BillDeduct,SellDeduct,isnull(Qid,-1) as Qid,bTechnician,bSeller,bStockman,bDestClerk,bAccountant,bAllot,bManage,Salary,Status,Remark,AttendancePwd,Allowance,Account,StaffDeptID,ProfitFormula,ftype from StaffList ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			StaffListInfo staffListInfo = new StaffListInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			StaffListInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					staffListInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					staffListInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				staffListInfo.JobNO = dataSet.Tables[0].Rows[0]["JobNO"].ToString();
				staffListInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				staffListInfo.Sex = dataSet.Tables[0].Rows[0]["Sex"].ToString();
				staffListInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				staffListInfo.Area = dataSet.Tables[0].Rows[0]["Area"].ToString();
				staffListInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				staffListInfo.NativePlace = dataSet.Tables[0].Rows[0]["NativePlace"].ToString();
				staffListInfo.CardID = dataSet.Tables[0].Rows[0]["CardID"].ToString();
				staffListInfo.BirthDate = dataSet.Tables[0].Rows[0]["BirthDate"].ToString();
				staffListInfo.Academic = dataSet.Tables[0].Rows[0]["Academic"].ToString();
				staffListInfo.School = dataSet.Tables[0].Rows[0]["School"].ToString();
				staffListInfo.Specialty = dataSet.Tables[0].Rows[0]["Specialty"].ToString();
				staffListInfo.JobDate = dataSet.Tables[0].Rows[0]["JobDate"].ToString();
				staffListInfo.BillDeduct = dataSet.Tables[0].Rows[0]["BillDeduct"].ToString();
				staffListInfo.SellDeduct = dataSet.Tables[0].Rows[0]["SellDeduct"].ToString();
				if (dataSet.Tables[0].Rows[0]["Qid"].ToString() != "")
				{
					staffListInfo.Qid = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Qid"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["bTechnician"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bTechnician"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bTechnician"].ToString().ToLower() == "true")
					{
						staffListInfo.bTechnician = true;
					}
					else
					{
						staffListInfo.bTechnician = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSeller"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSeller"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSeller"].ToString().ToLower() == "true")
					{
						staffListInfo.bSeller = true;
					}
					else
					{
						staffListInfo.bSeller = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bStockMan"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStockMan"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStockMan"].ToString().ToLower() == "true")
					{
						staffListInfo.bStockMan = true;
					}
					else
					{
						staffListInfo.bStockMan = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bAllot"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bAllot"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bAllot"].ToString().ToLower() == "true")
					{
						staffListInfo.bAllot = true;
					}
					else
					{
						staffListInfo.bAllot = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bDestClerk"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bDestClerk"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bDestClerk"].ToString().ToLower() == "true")
					{
						staffListInfo.bDestClerk = true;
					}
					else
					{
						staffListInfo.bDestClerk = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bAccountant"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bAccountant"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bAccountant"].ToString().ToLower() == "true")
					{
						staffListInfo.bAccountant = true;
					}
					else
					{
						staffListInfo.bAccountant = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bManage"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bManage"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bManage"].ToString().ToLower() == "true")
					{
						staffListInfo.bManage = true;
					}
					else
					{
						staffListInfo.bManage = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					staffListInfo.Status = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["Salary"].ToString() != "")
				{
					staffListInfo.Salary = decimal.Parse(dataSet.Tables[0].Rows[0]["Salary"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Allowance"].ToString() != "")
				{
					staffListInfo.Allowance = decimal.Parse(dataSet.Tables[0].Rows[0]["Allowance"].ToString());
				}
				staffListInfo.Account = dataSet.Tables[0].Rows[0]["Account"].ToString();
				staffListInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				staffListInfo.AttendancePwd = dataSet.Tables[0].Rows[0]["AttendancePwd"].ToString();
				staffListInfo.ProfitFormula = dataSet.Tables[0].Rows[0]["ProfitFormula"].ToString();
				if (dataSet.Tables[0].Rows[0]["ftype"].ToString() != "")
				{
					staffListInfo.ftype = int.Parse(dataSet.Tables[0].Rows[0]["ftype"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StaffDeptID"].ToString() != "")
				{
					staffListInfo.StaffDeptID = int.Parse(dataSet.Tables[0].Rows[0]["StaffDeptID"].ToString());
				}
				result = staffListInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int GetID(string _Name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID from StaffList ");
			stringBuilder.Append(" where _Name=@_Name ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Name", SqlDbType.VarChar, 50)
			};
			array[0].Value = _Name;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			int result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int GetID(string _Name, int DeptID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID from StaffList ");
			stringBuilder.Append(" where _Name=@_Name and DeptID=@DeptID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Name", SqlDbType.VarChar, 50),
				new SqlParameter("@DeptID", SqlDbType.Int, 4)
			};
			array[0].Value = _Name;
			array[1].Value = DeptID;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			int result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int GetLoginID(string _Name, int DeptID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID from xt_usermanage ");
			stringBuilder.Append(" where _Name=@_Name and DeptID=@DeptID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Name", SqlDbType.VarChar, 50),
				new SqlParameter("@DeptID", SqlDbType.Int, 4)
			};
			array[0].Value = _Name;
			array[1].Value = DeptID;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			int result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public void GetStaffInfo(DropDownList ddlStaff)
		{
			string sQLString = "select * from stafflist ";
			DataTable dataSource = DbHelperSQL.Query(sQLString).Tables[0];
			ddlStaff.DataSource = dataSource;
			ddlStaff.DataTextField = "_Name";
			ddlStaff.DataValueField = "ID";
			ddlStaff.DataBind();
			ddlStaff.Items.Insert(0, new ListItem("", "0"));
		}

		public string getPhoneNum(string username, int deptid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select Tel from stafflist where DeptID=@DeptID and _Name=@Name");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int, 4),
				new SqlParameter("@Name", SqlDbType.VarChar, 50)
			};
			array[0].Value = deptid;
			array[1].Value = username;
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString(), array).Tables[0];
			string result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = dataTable.Rows[0][0].ToString();
					return result;
				}
			}
			result = "";
			return result;
		}
	}
}
