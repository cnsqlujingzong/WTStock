using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSysParm
	{
		public void Update(SysParmInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SysParm set ");
			stringBuilder.Append("SysName=@SysName,");
			stringBuilder.Append("BranchNum=@BranchNum,");
			stringBuilder.Append("AllocatePrice=@AllocatePrice,");
			stringBuilder.Append("WarrantyCycle=@WarrantyCycle,");
			stringBuilder.Append("CustomerShar=@CustomerShar,");
			stringBuilder.Append("EmailServer=@EmailServer,");
			stringBuilder.Append("EmailLogName=@EmailLogName,");
			stringBuilder.Append("EmailPwd=@EmailPwd,");
			stringBuilder.Append("EmailAdr=@EmailAdr,");
			stringBuilder.Append("SmsCode=@SmsCode,");
			stringBuilder.Append("SndStyle=@SndStyle,");
			stringBuilder.Append("UserName=@UserName,");
			stringBuilder.Append("UserPwd=@UserPwd,");
			stringBuilder.Append("RecDueDay=@RecDueDay,");
			stringBuilder.Append("bLoginDdl=@bLoginDdl,");
			stringBuilder.Append("bValiCode=@bValiCode,");
			stringBuilder.Append("bBln=@bBln,");
			stringBuilder.Append("bRememberPassword=@bRememberPassword,");
			stringBuilder.Append("iRepair=@iRepair,");
			stringBuilder.Append("bFinish=@bFinish,");
			stringBuilder.Append("bFinish2=@bFinish2,");
			stringBuilder.Append("ServicesDo=@ServicesDo,");
			stringBuilder.Append("City=@City,");
			stringBuilder.Append("bTec=@bTec,");
			stringBuilder.Append("bHeadBln=@bHeadBln,");
			stringBuilder.Append("bSerSep=@bSerSep,");
			stringBuilder.Append("bPurSep=@bPurSep,");
			stringBuilder.Append("bSellSep=@bSellSep,");
			stringBuilder.Append("bSerItem=@bSerItem,");
			stringBuilder.Append("bFaultNoInput=@bFaultNoInput,");
			stringBuilder.Append("bTakeStepsNoInput=@bTakeStepsNoInput,");
			stringBuilder.Append("bEnforceInput=@bEnforceInput,");
			stringBuilder.Append("bPlanControl=@bPlanControl,");
			stringBuilder.Append("bDisblingControl=@bDisblingControl,");
			stringBuilder.Append("LockMinutes=@LockMinutes,");
			stringBuilder.Append("bDeviceOnly=@bDeviceOnly,");
			stringBuilder.Append("bZeroPurchase=@bZeroPurchase,");
			stringBuilder.Append("CostModel=@CostModel,");
			stringBuilder.Append("bPhone=@bPhone");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@SysName", SqlDbType.VarChar, 100),
				new SqlParameter("@BranchNum", SqlDbType.Int, 4),
				new SqlParameter("@AllocatePrice", SqlDbType.Int, 4),
				new SqlParameter("@WarrantyCycle", SqlDbType.Int, 4),
				new SqlParameter("@CustomerShar", SqlDbType.Int, 4),
				new SqlParameter("@EmailServer", SqlDbType.VarChar, 100),
				new SqlParameter("@EmailLogName", SqlDbType.VarChar, 100),
				new SqlParameter("@EmailPwd", SqlDbType.VarChar, 100),
				new SqlParameter("@EmailAdr", SqlDbType.VarChar, 100),
				new SqlParameter("@SmsCode", SqlDbType.VarChar, 100),
				new SqlParameter("@SndStyle", SqlDbType.Int, 4),
				new SqlParameter("@UserName", SqlDbType.VarChar, 50),
				new SqlParameter("@UserPwd", SqlDbType.VarChar, 200),
				new SqlParameter("@RecDueDay", SqlDbType.Int, 4),
				new SqlParameter("@bLoginDdl", SqlDbType.Bit, 1),
				new SqlParameter("@bValiCode", SqlDbType.Bit, 1),
				new SqlParameter("@bBln", SqlDbType.Int, 4),
				new SqlParameter("@bRememberPassword", SqlDbType.Bit, 1),
				new SqlParameter("@iRepair", SqlDbType.Int, 4),
				new SqlParameter("@bFinish", SqlDbType.Bit, 1),
				new SqlParameter("@bFinish2", SqlDbType.Bit, 1),
				new SqlParameter("@ServicesDo", SqlDbType.Int, 4),
				new SqlParameter("@City", SqlDbType.VarChar, 50),
				new SqlParameter("@bTec", SqlDbType.Bit, 1),
				new SqlParameter("@bSerItem", SqlDbType.Bit, 1),
				new SqlParameter("@bHeadBln", SqlDbType.Bit, 1),
				new SqlParameter("@bSerSep", SqlDbType.Bit, 1),
				new SqlParameter("@bFaultNoInput", SqlDbType.Bit, 1),
				new SqlParameter("@bTakeStepsNoInput", SqlDbType.Bit, 1),
				new SqlParameter("@bEnforceInput", SqlDbType.Bit, 1),
				new SqlParameter("@bPlanControl", SqlDbType.Bit, 1),
				new SqlParameter("@bZeroPurchase", SqlDbType.Bit, 1),
				new SqlParameter("@bDisblingControl", SqlDbType.Bit, 1),
				new SqlParameter("@LockMinutes", SqlDbType.Int, 4),
				new SqlParameter("@bDeviceOnly", SqlDbType.Bit, 1),
				new SqlParameter("@bPurSep", SqlDbType.Bit, 1),
				new SqlParameter("@bSellSep", SqlDbType.Bit, 1),
				new SqlParameter("@CostModel", SqlDbType.Int, 4),
				new SqlParameter("@bPhone", SqlDbType.Bit, 1)
			};
			array[0].Value = model.ID;
			array[1].Value = model.SysName;
			array[2].Value = model.BranchNum;
			array[3].Value = model.AllocatePrice;
			array[4].Value = model.WarrantyCycle;
			array[5].Value = model.CustomerShar;
			array[6].Value = model.EmailServer;
			array[7].Value = model.EmailLogName;
			array[8].Value = model.EmailPwd;
			array[9].Value = model.EmailAdr;
			array[10].Value = model.SmsCode;
			array[11].Value = model.SndStyle;
			array[12].Value = model.UserName;
			array[13].Value = model.UserPwd;
			array[14].Value = model.RecDueDay;
			array[15].Value = model.bLoginDdl;
			array[16].Value = model.bValiCode;
			array[17].Value = model.bBln;
			array[18].Value = model.bRememberPassword;
			array[19].Value = model.iRepair;
			array[20].Value = model.bFinish;
			array[21].Value = model.bFinish2;
			array[22].Value = model.ServicesDo;
			array[23].Value = model.City;
			array[24].Value = model.bTec;
			array[25].Value = model.bSerItem;
			array[26].Value = model.bHeadBln;
			array[27].Value = model.bSerSep;
			array[28].Value = model.bFaultNoInput;
			array[29].Value = model.bTakeStepsNoInput;
			array[30].Value = model.bEnforceInput;
			array[31].Value = model.bPlanControl;
			array[32].Value = model.bZeroPurchase;
			array[33].Value = model.bDisblingControl;
			array[34].Value = model.LockMinutes;
			array[35].Value = model.bDeviceOnly;
			array[36].Value = model.bPurSep;
			array[37].Value = model.bSellSep;
			array[38].Value = model.CostModel;
			array[39].Value = model.bPhone;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateBackUpAdr(int ID, string BackUpAdr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SysParm set ");
			stringBuilder.Append("BackUpAdr=@BackUpAdr ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@BackUpAdr", SqlDbType.VarChar, 100)
			};
			array[0].Value = ID;
			array[1].Value = BackUpAdr;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Update2(SysParmInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update BranchList set ");
			stringBuilder.Append("CorpName=@CorpName,");
			stringBuilder.Append("Tel=@Tel,");
			stringBuilder.Append("Adr=@Adr,");
			stringBuilder.Append("Zip=@Zip ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@CorpName", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@Adr", SqlDbType.VarChar, 200),
				new SqlParameter("@Zip", SqlDbType.VarChar, 10)
			};
			array[0].Value = model.ID;
			array[1].Value = model.CorpName;
			array[2].Value = model.Tel;
			array[3].Value = model.Adr;
			array[4].Value = model.Zip;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void Update3(SysParmInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SysParm set ");
			stringBuilder.Append("BranchNum=@BranchNum, ");
			stringBuilder.Append("bSim=@bSim,");
			stringBuilder.Append("bWeb=@bWeb ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@BranchNum", SqlDbType.Int, 4),
				new SqlParameter("@bWeb", SqlDbType.Int, 4),
				new SqlParameter("@bSim", SqlDbType.Bit)
			};
			array[0].Value = model.ID;
			array[1].Value = model.BranchNum;
			array[2].Value = model.bWeb;
			array[3].Value = model.bSim;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public SysParmInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,CorpName,Tel,Adr,Zip,SysName,BranchNum,AllocatePrice,WarrantyCycle,CustomerShar,EmailServer,EmailLogName,EmailPwd,EmailAdr,SmsCode,bWeb,SndStyle,UserName,UserPwd,RecDueDay,bLoginDdl,bValiCode,bBln,bRememberPassword,iRepair,bFinish,bFinish2,ServicesDo,City,bTec,bSerItem,bHeadBln,bSerSep,bFaultNoInput,bTakeStepsNoInput,bSim,bEnforceInput,bPlanControl,bPhone,bZeroPurchase,bDisblingControl,LockMinutes,bDeviceOnly,bPurSep,bSellSep,CostModel from xt_sysparm ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			SysParmInfo sysParmInfo = new SysParmInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			SysParmInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					sysParmInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				sysParmInfo.CorpName = dataSet.Tables[0].Rows[0]["CorpName"].ToString();
				sysParmInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				sysParmInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				sysParmInfo.Zip = dataSet.Tables[0].Rows[0]["Zip"].ToString();
				sysParmInfo.SysName = dataSet.Tables[0].Rows[0]["SysName"].ToString();
				if (dataSet.Tables[0].Rows[0]["BranchNum"].ToString() != "")
				{
					sysParmInfo.BranchNum = int.Parse(dataSet.Tables[0].Rows[0]["BranchNum"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["bBln"].ToString() != "")
				{
					sysParmInfo.bBln = int.Parse(dataSet.Tables[0].Rows[0]["bBln"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["iRepair"].ToString() != "")
				{
					sysParmInfo.iRepair = int.Parse(dataSet.Tables[0].Rows[0]["iRepair"].ToString());
				}
				else
				{
					sysParmInfo.iRepair = 7;
				}
				if (dataSet.Tables[0].Rows[0]["bWeb"].ToString() != "")
				{
					sysParmInfo.bWeb = int.Parse(dataSet.Tables[0].Rows[0]["bWeb"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["AllocatePrice"].ToString() != "")
				{
					sysParmInfo.AllocatePrice = int.Parse(dataSet.Tables[0].Rows[0]["AllocatePrice"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["WarrantyCycle"].ToString() != "")
				{
					sysParmInfo.WarrantyCycle = int.Parse(dataSet.Tables[0].Rows[0]["WarrantyCycle"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["CustomerShar"].ToString() != "")
				{
					sysParmInfo.CustomerShar = int.Parse(dataSet.Tables[0].Rows[0]["CustomerShar"].ToString());
				}
				sysParmInfo.EmailServer = dataSet.Tables[0].Rows[0]["EmailServer"].ToString();
				sysParmInfo.EmailLogName = dataSet.Tables[0].Rows[0]["EmailLogName"].ToString();
				sysParmInfo.EmailPwd = dataSet.Tables[0].Rows[0]["EmailPwd"].ToString();
				sysParmInfo.EmailAdr = dataSet.Tables[0].Rows[0]["EmailAdr"].ToString();
				sysParmInfo.SmsCode = dataSet.Tables[0].Rows[0]["SmsCode"].ToString();
				if (dataSet.Tables[0].Rows[0]["CostModel"].ToString() != "")
				{
					sysParmInfo.CostModel = int.Parse(dataSet.Tables[0].Rows[0]["CostModel"].ToString());
				}
				else
				{
					sysParmInfo.CostModel = 0;
				}
				if (dataSet.Tables[0].Rows[0]["SndStyle"].ToString() != "")
				{
					sysParmInfo.SndStyle = int.Parse(dataSet.Tables[0].Rows[0]["SndStyle"].ToString());
				}
				sysParmInfo.UserName = dataSet.Tables[0].Rows[0]["UserName"].ToString();
				sysParmInfo.UserPwd = dataSet.Tables[0].Rows[0]["UserPwd"].ToString();
				if (dataSet.Tables[0].Rows[0]["RecDueDay"].ToString() != "")
				{
					sysParmInfo.RecDueDay = int.Parse(dataSet.Tables[0].Rows[0]["RecDueDay"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["bLoginDdl"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bLoginDdl"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bLoginDdl"].ToString().ToLower() == "true")
					{
						sysParmInfo.bLoginDdl = true;
					}
					else
					{
						sysParmInfo.bLoginDdl = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bValiCode"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bValiCode"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bValiCode"].ToString().ToLower() == "true")
					{
						sysParmInfo.bValiCode = true;
					}
					else
					{
						sysParmInfo.bValiCode = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bRememberPassword"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bRememberPassword"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bRememberPassword"].ToString().ToLower() == "true")
					{
						sysParmInfo.bRememberPassword = true;
					}
					else
					{
						sysParmInfo.bRememberPassword = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bFinish"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bFinish"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bFinish"].ToString().ToLower() == "true")
					{
						sysParmInfo.bFinish = true;
					}
					else
					{
						sysParmInfo.bFinish = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bFinish2"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bFinish2"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bFinish2"].ToString().ToLower() == "true")
					{
						sysParmInfo.bFinish2 = true;
					}
					else
					{
						sysParmInfo.bFinish2 = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["ServicesDo"].ToString() != "")
				{
					sysParmInfo.ServicesDo = int.Parse(dataSet.Tables[0].Rows[0]["ServicesDo"].ToString());
				}
				sysParmInfo.City = dataSet.Tables[0].Rows[0]["City"].ToString();
				if (dataSet.Tables[0].Rows[0]["bTec"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bTec"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bTec"].ToString().ToLower() == "true")
					{
						sysParmInfo.bTec = true;
					}
					else
					{
						sysParmInfo.bTec = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSerItem"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSerItem"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSerItem"].ToString().ToLower() == "true")
					{
						sysParmInfo.bSerItem = true;
					}
					else
					{
						sysParmInfo.bSerItem = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bHeadBln"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bHeadBln"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bHeadBln"].ToString().ToLower() == "true")
					{
						sysParmInfo.bHeadBln = true;
					}
					else
					{
						sysParmInfo.bHeadBln = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSerSep"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSerSep"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSerSep"].ToString().ToLower() == "true")
					{
						sysParmInfo.bSerSep = true;
					}
					else
					{
						sysParmInfo.bSerSep = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bFaultNoInput"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bFaultNoInput"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bFaultNoInput"].ToString().ToLower() == "true")
					{
						sysParmInfo.bFaultNoInput = true;
					}
					else
					{
						sysParmInfo.bFaultNoInput = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bTakeStepsNoInput"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bTakeStepsNoInput"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bTakeStepsNoInput"].ToString().ToLower() == "true")
					{
						sysParmInfo.bTakeStepsNoInput = true;
					}
					else
					{
						sysParmInfo.bTakeStepsNoInput = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSim"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSim"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSim"].ToString().ToLower() == "true")
					{
						sysParmInfo.bSim = true;
					}
					else
					{
						sysParmInfo.bSim = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bEnforceInput"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bEnforceInput"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bEnforceInput"].ToString().ToLower() == "true")
					{
						sysParmInfo.bEnforceInput = true;
					}
					else
					{
						sysParmInfo.bEnforceInput = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bPlanControl"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bPlanControl"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bPlanControl"].ToString().ToLower() == "true")
					{
						sysParmInfo.bPlanControl = true;
					}
					else
					{
						sysParmInfo.bPlanControl = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bZeroPurchase"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bZeroPurchase"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bZeroPurchase"].ToString().ToLower() == "true")
					{
						sysParmInfo.bZeroPurchase = true;
					}
					else
					{
						sysParmInfo.bZeroPurchase = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bDisblingControl"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bDisblingControl"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bDisblingControl"].ToString().ToLower() == "true")
					{
						sysParmInfo.bDisblingControl = true;
					}
					else
					{
						sysParmInfo.bDisblingControl = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bDeviceOnly"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bDeviceOnly"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bDeviceOnly"].ToString().ToLower() == "true")
					{
						sysParmInfo.bDeviceOnly = true;
					}
					else
					{
						sysParmInfo.bDeviceOnly = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bPurSep"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bPurSep"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bPurSep"].ToString().ToLower() == "true")
					{
						sysParmInfo.bPurSep = true;
					}
					else
					{
						sysParmInfo.bPurSep = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSellSep"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSellSep"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSellSep"].ToString().ToLower() == "true")
					{
						sysParmInfo.bSellSep = true;
					}
					else
					{
						sysParmInfo.bSellSep = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["LockMinutes"].ToString() != "")
				{
					sysParmInfo.LockMinutes = int.Parse(dataSet.Tables[0].Rows[0]["LockMinutes"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["bPhone"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bPhone"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bPhone"].ToString().ToLower() == "true")
					{
						sysParmInfo.bPhone = true;
					}
					else
					{
						sysParmInfo.bPhone = false;
					}
				}
				result = sysParmInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public SysParmInfo GetSysParm()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 CorpName,SysName,BranchNum,AllocatePrice,WarrantyCycle,bPhone,CustomerShar,EmailServer,EmailLogName,EmailPwd,EmailAdr,SmsCode,Tel,Adr,BackUpAdr,Zip,bWeb,SndStyle,UserName,UserPwd,RecDueDay,bLoginDdl,bValiCode,bBln,bRememberPassword,iRepair,bFinish,bFinish2,ServicesDo,City,bTec,bSerItem,bSim from xt_sysparm ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = 1;
			SysParmInfo sysParmInfo = new SysParmInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			SysParmInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				sysParmInfo.CorpName = dataSet.Tables[0].Rows[0]["CorpName"].ToString();
				sysParmInfo.SysName = dataSet.Tables[0].Rows[0]["SysName"].ToString();
				if (dataSet.Tables[0].Rows[0]["BranchNum"].ToString() != "")
				{
					sysParmInfo.BranchNum = int.Parse(dataSet.Tables[0].Rows[0]["BranchNum"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["bWeb"].ToString() != "")
				{
					sysParmInfo.bWeb = int.Parse(dataSet.Tables[0].Rows[0]["bWeb"].ToString());
				}
				else
				{
					sysParmInfo.bWeb = 0;
				}
				if (dataSet.Tables[0].Rows[0]["iRepair"].ToString() != "")
				{
					sysParmInfo.iRepair = int.Parse(dataSet.Tables[0].Rows[0]["iRepair"].ToString());
				}
				else
				{
					sysParmInfo.iRepair = 7;
				}
				if (dataSet.Tables[0].Rows[0]["AllocatePrice"].ToString() != "")
				{
					sysParmInfo.AllocatePrice = int.Parse(dataSet.Tables[0].Rows[0]["AllocatePrice"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["WarrantyCycle"].ToString() != "")
				{
					sysParmInfo.WarrantyCycle = int.Parse(dataSet.Tables[0].Rows[0]["WarrantyCycle"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["CustomerShar"].ToString() != "")
				{
					sysParmInfo.CustomerShar = int.Parse(dataSet.Tables[0].Rows[0]["CustomerShar"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["bBln"].ToString() != "")
				{
					sysParmInfo.bBln = int.Parse(dataSet.Tables[0].Rows[0]["bBln"].ToString());
				}
				sysParmInfo.EmailServer = dataSet.Tables[0].Rows[0]["EmailServer"].ToString();
				sysParmInfo.EmailLogName = dataSet.Tables[0].Rows[0]["EmailLogName"].ToString();
				sysParmInfo.EmailPwd = dataSet.Tables[0].Rows[0]["EmailPwd"].ToString();
				sysParmInfo.EmailAdr = dataSet.Tables[0].Rows[0]["EmailAdr"].ToString();
				sysParmInfo.SmsCode = dataSet.Tables[0].Rows[0]["SmsCode"].ToString();
				sysParmInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				sysParmInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				sysParmInfo.BackUpAdr = dataSet.Tables[0].Rows[0]["BackUpAdr"].ToString();
				sysParmInfo.Zip = dataSet.Tables[0].Rows[0]["Zip"].ToString();
				if (dataSet.Tables[0].Rows[0]["SndStyle"].ToString() != "")
				{
					sysParmInfo.SndStyle = int.Parse(dataSet.Tables[0].Rows[0]["SndStyle"].ToString());
				}
				sysParmInfo.UserName = dataSet.Tables[0].Rows[0]["UserName"].ToString();
				sysParmInfo.UserPwd = dataSet.Tables[0].Rows[0]["UserPwd"].ToString();
				if (dataSet.Tables[0].Rows[0]["RecDueDay"].ToString() != "")
				{
					sysParmInfo.RecDueDay = int.Parse(dataSet.Tables[0].Rows[0]["RecDueDay"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["bLoginDdl"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bLoginDdl"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bLoginDdl"].ToString().ToLower() == "true")
					{
						sysParmInfo.bLoginDdl = true;
					}
					else
					{
						sysParmInfo.bLoginDdl = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bValiCode"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bValiCode"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bValiCode"].ToString().ToLower() == "true")
					{
						sysParmInfo.bValiCode = true;
					}
					else
					{
						sysParmInfo.bValiCode = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bRememberPassword"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bRememberPassword"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bRememberPassword"].ToString().ToLower() == "true")
					{
						sysParmInfo.bRememberPassword = true;
					}
					else
					{
						sysParmInfo.bRememberPassword = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bFinish"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bFinish"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bFinish"].ToString().ToLower() == "true")
					{
						sysParmInfo.bFinish = true;
					}
					else
					{
						sysParmInfo.bFinish = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bFinish2"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bFinish2"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bFinish2"].ToString().ToLower() == "true")
					{
						sysParmInfo.bFinish2 = true;
					}
					else
					{
						sysParmInfo.bFinish2 = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["ServicesDo"].ToString() != "")
				{
					sysParmInfo.ServicesDo = int.Parse(dataSet.Tables[0].Rows[0]["ServicesDo"].ToString());
				}
				sysParmInfo.City = dataSet.Tables[0].Rows[0]["City"].ToString();
				if (dataSet.Tables[0].Rows[0]["bTec"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bTec"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bTec"].ToString().ToLower() == "true")
					{
						sysParmInfo.bTec = true;
					}
					else
					{
						sysParmInfo.bTec = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSerItem"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSerItem"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSerItem"].ToString().ToLower() == "true")
					{
						sysParmInfo.bSerItem = true;
					}
					else
					{
						sysParmInfo.bSerItem = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSim"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSim"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSim"].ToString().ToLower() == "true")
					{
						sysParmInfo.bSim = true;
					}
					else
					{
						sysParmInfo.bSim = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bPhone"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bPhone"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bPhone"].ToString().ToLower() == "true")
					{
						sysParmInfo.bPhone = true;
					}
					else
					{
						sysParmInfo.bPhone = false;
					}
				}
				result = sysParmInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public bool bHeadCharge()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 bHeadBln from SysParm where ID=1 ");
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString());
			bool result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["bHeadBln"].ToString() != "")
				{
					result = (dataSet.Tables[0].Rows[0]["bHeadBln"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bHeadBln"].ToString().ToLower() == "true");
					return result;
				}
			}
			result = false;
			return result;
		}

		public bool bSerSep()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 bSerSep from SysParm where ID=1 ");
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString());
			bool result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["bSerSep"].ToString() != "")
				{
					result = (dataSet.Tables[0].Rows[0]["bSerSep"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSerSep"].ToString().ToLower() == "true");
					return result;
				}
			}
			result = false;
			return result;
		}

		public bool bPurSep()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 bPurSep from SysParm where ID=1 ");
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString());
			bool result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["bPurSep"].ToString() != "")
				{
					result = (dataSet.Tables[0].Rows[0]["bPurSep"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bPurSep"].ToString().ToLower() == "true");
					return result;
				}
			}
			result = false;
			return result;
		}

		public bool bSellSep()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 bSellSep from SysParm where ID=1 ");
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString());
			bool result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["bSellSep"].ToString() != "")
				{
					result = (dataSet.Tables[0].Rows[0]["bSellSep"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSellSep"].ToString().ToLower() == "true");
					return result;
				}
			}
			result = false;
			return result;
		}
	}
}
