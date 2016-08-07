using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALUserManage
	{
		public int Add(UserManageInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text += "StaffID";
			text2 += model.StaffID.ToString();
			string text3 = " StaffID=" + model.StaffID.ToString();
			text3 = text3 + " and DeptID=" + model.DeptID.ToString();
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID.ToString();
			if (model.Pwd != string.Empty)
			{
				text += ",Pwd";
				text2 = text2 + ",'" + model.Pwd + "'";
			}
			if (model.RightID > 0)
			{
				text += ",RightID";
				text2 = text2 + "," + model.RightID.ToString();
			}
			if (model.Status != string.Empty)
			{
				text += ",Status";
				text2 = text2 + ",'" + model.Status + "'";
			}
			return DALCommon.InsertData("UserManage", text, text2, text3, "用户名", "ID", out strMsg, out iTbid);
		}

		public int Update(UserManageInfo model, string chkfld, bool bpwd, out string strMsg)
		{
			string text = string.Empty;
			text = text + "StaffID=" + model.StaffID.ToString();
			text = text + ",RightID=" + model.RightID.ToString();
			text = text + ",Status='" + model.Status + "'";
			if (bpwd)
			{
				text = text + ",Pwd='" + model.Pwd + "'";
			}
			return DALCommon.UpdateData("UserManage", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int RefreshOnline(int ID, string OperCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("if exists(select ID from UserManage where StaffID=@ID and OperCode=@OperCode) begin update UserManage set LastOper=getdate() where StaffID=@ID select 1 return end ");
			stringBuilder.Append(" else begin select -1 return end ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@OperCode", SqlDbType.VarChar, 50)
			};
			array[0].Value = ID;
			array[1].Value = OperCode;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			int result;
			if (single == null)
			{
				result = -1;
			}
			else
			{
				int num = 0;
				int.TryParse(single.ToString(), out num);
				result = num;
			}
			return result;
		}

		public void UpdateCode(int ID, string OperCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update UserManage set LastOper=getdate(),OperCode=@OperCode where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@OperCode", SqlDbType.VarChar, 50)
			};
			array[0].Value = ID;
			array[1].Value = OperCode;
			int num = DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public UserManageInfo Login(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("declare @bSim bit,@BranchNum int,@OnlineCount int ");
			stringBuilder.Append(" select @bSim=bSim,@BranchNum=BranchNum from SysParm where ID=1 ");
			stringBuilder.Append(" if @bSim=1 begin update UserManage set OperCode=NULL where LastOper<=dateadd(minute,-1,getdate()) select @OnlineCount=count(1) from UserManage where ID<>@ID and OperCode is not null ");
			stringBuilder.Append(" if @OnlineCount>=@BranchNum begin select -1 return end end ");
			stringBuilder.Append("select * from xt_usermanage ");
			stringBuilder.Append(" where ID=@ID;");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			UserManageInfo userManageInfo = new UserManageInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			userManageInfo.ID = ID;
			UserManageInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0].ItemArray.Length == 1)
				{
					userManageInfo.ID = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
					result = userManageInfo;
				}
				else
				{
					if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
					{
						userManageInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
					}
					if (dataSet.Tables[0].Rows[0]["StaffID"].ToString() != "")
					{
						userManageInfo.StaffID = int.Parse(dataSet.Tables[0].Rows[0]["StaffID"].ToString());
					}
					userManageInfo.Pwd = dataSet.Tables[0].Rows[0]["Pwd"].ToString();
					userManageInfo.Status = dataSet.Tables[0].Rows[0]["Status"].ToString();
					if (dataSet.Tables[0].Rows[0]["RightID"].ToString() != "")
					{
						userManageInfo.RightID = int.Parse(dataSet.Tables[0].Rows[0]["RightID"].ToString());
					}
					userManageInfo.Right = dataSet.Tables[0].Rows[0]["RightName"].ToString();
					result = userManageInfo;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void Logout(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update UserManage set OperCode=NULL where StaffID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			int num = DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public UserManageInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from xt_usermanage ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			UserManageInfo userManageInfo = new UserManageInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			userManageInfo.ID = ID;
			UserManageInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					userManageInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StaffID"].ToString() != "")
				{
					userManageInfo.StaffID = int.Parse(dataSet.Tables[0].Rows[0]["StaffID"].ToString());
				}
				userManageInfo.Pwd = dataSet.Tables[0].Rows[0]["Pwd"].ToString();
				userManageInfo.Status = dataSet.Tables[0].Rows[0]["Status"].ToString();
				if (dataSet.Tables[0].Rows[0]["RightID"].ToString() != "")
				{
					userManageInfo.RightID = int.Parse(dataSet.Tables[0].Rows[0]["RightID"].ToString());
				}
				userManageInfo.Right = dataSet.Tables[0].Rows[0]["RightName"].ToString();
				result = userManageInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public UserManageInfo GetModelTel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("");
			stringBuilder.Append("select * from xt_usermanage ");
			stringBuilder.Append(" where StaffID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			UserManageInfo userManageInfo = new UserManageInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			userManageInfo.StaffID = ID;
			UserManageInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					userManageInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StaffID"].ToString() != "")
				{
					userManageInfo.StaffID = int.Parse(dataSet.Tables[0].Rows[0]["StaffID"].ToString());
				}
				userManageInfo.Pwd = dataSet.Tables[0].Rows[0]["Pwd"].ToString();
				userManageInfo.Status = dataSet.Tables[0].Rows[0]["Status"].ToString();
				if (dataSet.Tables[0].Rows[0]["RightID"].ToString() != "")
				{
					userManageInfo.RightID = int.Parse(dataSet.Tables[0].Rows[0]["RightID"].ToString());
				}
				userManageInfo.Right = dataSet.Tables[0].Rows[0]["RightName"].ToString();
				result = userManageInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public UserManageInfo GetModel(int StaffID, int DeptID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from xt_usermanage ");
			stringBuilder.Append(" where StaffID=@StaffID and DeptID=@DeptID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StaffID", SqlDbType.Int, 4),
				new SqlParameter("@DeptID", SqlDbType.Int, 4)
			};
			array[0].Value = StaffID;
			array[1].Value = DeptID;
			UserManageInfo userManageInfo = new UserManageInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			userManageInfo.StaffID = StaffID;
			userManageInfo.DeptID = DeptID;
			UserManageInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					userManageInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				userManageInfo.Pwd = dataSet.Tables[0].Rows[0]["Pwd"].ToString();
				userManageInfo.Status = dataSet.Tables[0].Rows[0]["Status"].ToString();
				if (dataSet.Tables[0].Rows[0]["RightID"].ToString() != "")
				{
					userManageInfo.RightID = int.Parse(dataSet.Tables[0].Rows[0]["RightID"].ToString());
				}
				userManageInfo.Right = dataSet.Tables[0].Rows[0]["RightName"].ToString();
				result = userManageInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void UpdatePs(int StaffID, string Pwd)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update UserManage set ");
			stringBuilder.Append("Pwd=@Pwd ");
			stringBuilder.Append(" where StaffID=@StaffID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@StaffID", SqlDbType.Int, 4),
				new SqlParameter("@Pwd", SqlDbType.VarChar, 200)
			};
			array[0].Value = StaffID;
			array[1].Value = Pwd;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int GetDelAdm(int DeptID, int UserID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("if (select _Name from [Right] where ID=(select RightID from UserManage where ID=@ID))='系统管理员'\r\n            select count(1) from \r\n            UserManage um left join [Right] r on um.RightID=r.ID\r\n            where um.DeptID=@DeptID and um.ID<>@ID and r._Name='系统管理员'\r\n            else\r\n            select 1");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = DeptID;
			array[1].Value = UserID;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			int result;
			if (single == null)
			{
				result = 0;
			}
			else
			{
				result = int.Parse(single.ToString());
			}
			return result;
		}

		public int LoginMacChk(string Mac)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("if(select isnull(bMacControl,0) from SysParm where ID=1)=0 or (select count(1) from MacList)=0 or (select count(1) from MacList where Mac=@Mac)>0");
			stringBuilder.Append("\tselect 1");
			stringBuilder.Append("else ");
			stringBuilder.Append("\tselect 0 ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Mac", SqlDbType.VarChar, 20)
			};
			array[0].Value = Mac;
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

		public DataSet GetOnline()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select a.ID,b.DeptID,RightID,b._Name as Uname,c._Name Dept,d._Name as strRight ");
			stringBuilder.Append("from UserManage a left join StaffList b on a.StaffID=b.ID ");
			stringBuilder.Append("left join BranchList c on b.DeptID=c.ID ");
			stringBuilder.Append("left join [Right] d on d.ID=a.RightID ");
			stringBuilder.Append(" where LastOper>dateadd(minute,-1,getdate()) order by b.DeptID,b.JobNO");
			return DbHelperSQL.Query(stringBuilder.ToString());
		}
	}
}
