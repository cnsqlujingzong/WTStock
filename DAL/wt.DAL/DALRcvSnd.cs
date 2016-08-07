using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALRcvSnd
	{
		public int Add(RcvSndInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "OperatorID";
			text2 += model.OperatorID.ToString();
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
			if (model.PersonID > 0)
			{
				text += ",PersonID";
				text2 = text2 + "," + model.PersonID.ToString();
			}
			if (model.SndStyleID > 0)
			{
				text += ",SndStyleID";
				text2 = text2 + "," + model.SndStyleID.ToString();
			}
			if (model.OperationType != string.Empty)
			{
				text += ",OperationType";
				text2 = text2 + ",'" + model.OperationType + "'";
			}
			if (model.RcvType != string.Empty)
			{
				text += ",RcvType";
				text2 = text2 + ",'" + model.RcvType + "'";
			}
			if (model.PostNO != string.Empty)
			{
				text += ",PostNO";
				text2 = text2 + ",'" + model.PostNO + "'";
			}
			if (model.Postage > 0m)
			{
				text += ",Postage";
				text2 = text2 + "," + model.Postage.ToString();
			}
			if (model.RcvDeptID > 0)
			{
				text += ",RcvDeptID";
				text2 = text2 + "," + model.RcvDeptID.ToString();
			}
			if (model.CorpName != string.Empty)
			{
				text += ",CorpName";
				text2 = text2 + ",'" + model.CorpName + "'";
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
			if (model.Zip != string.Empty)
			{
				text += ",Zip";
				text2 = text2 + ",'" + model.Zip + "'";
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
			list.Add(new string[]
			{
				text,
				text2,
				"sf_kd"
			});
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(RcvSndInfo model, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			text = text + " OperatorID=" + model.OperatorID.ToString();
			if (model._Date != string.Empty)
			{
				text = text + ",_Date='" + model._Date + "'";
			}
			else
			{
				text += ",_Date=null";
			}
			if (model.SndStyleID > 0)
			{
				text = text + ",SndStyleID=" + model.SndStyleID.ToString();
			}
			else
			{
				text += ",SndStyleID=null";
			}
			text = text + ",OperationType='" + model.OperationType + "'";
			text = text + ",RcvType='" + model.RcvType + "'";
			text = text + ",PostNO='" + model.PostNO + "'";
			text = text + ",Postage=" + model.Postage.ToString();
			text = text + ",CorpName='" + model.CorpName + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",Zip='" + model.Zip + "'";
			text = text + ",Summary='" + model.Summary + "'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("RcvSnd", text, " [ID]=" + model.ID.ToString(), "", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public RcvSndInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,BillID,isnull(DeptID,0) as DeptID,_Date=convert(char(10), _Date,120),OperatorID,PersonID,OperationType,RcvType,isnull(SndStyleID,0) as SndStyleID,PostNO,Postage,RcvDeptID,CorpName,LinkMan,Tel,Adr,Zip,Summary,Status,RcvDate,SignManID,Remark from RcvSnd ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			RcvSndInfo rcvSndInfo = new RcvSndInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			RcvSndInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					rcvSndInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				rcvSndInfo.BillID = dataSet.Tables[0].Rows[0]["BillID"].ToString();
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					rcvSndInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				rcvSndInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["OperatorID"].ToString() != "")
				{
					rcvSndInfo.OperatorID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["OperatorID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["PersonID"].ToString() != "")
				{
					rcvSndInfo.PersonID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["PersonID"].ToString()));
				}
				rcvSndInfo.OperationType = dataSet.Tables[0].Rows[0]["OperationType"].ToString();
				rcvSndInfo.RcvType = dataSet.Tables[0].Rows[0]["RcvType"].ToString();
				if (dataSet.Tables[0].Rows[0]["SndStyleID"].ToString() != "")
				{
					rcvSndInfo.SndStyleID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SndStyleID"].ToString()));
				}
				rcvSndInfo.PostNO = dataSet.Tables[0].Rows[0]["PostNO"].ToString();
				if (dataSet.Tables[0].Rows[0]["Postage"].ToString() != "")
				{
					rcvSndInfo.Postage = new decimal?(decimal.Parse(dataSet.Tables[0].Rows[0]["Postage"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["RcvDeptID"].ToString() != "")
				{
					rcvSndInfo.RcvDeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["RcvDeptID"].ToString()));
				}
				rcvSndInfo.CorpName = dataSet.Tables[0].Rows[0]["CorpName"].ToString();
				rcvSndInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				rcvSndInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				rcvSndInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				rcvSndInfo.Zip = dataSet.Tables[0].Rows[0]["Zip"].ToString();
				rcvSndInfo.Summary = dataSet.Tables[0].Rows[0]["Summary"].ToString();
				if (dataSet.Tables[0].Rows[0]["Status"].ToString() != "")
				{
					rcvSndInfo.Status = new int?(int.Parse(dataSet.Tables[0].Rows[0]["Status"].ToString()));
				}
				rcvSndInfo.RcvDate = dataSet.Tables[0].Rows[0]["RcvDate"].ToString();
				if (dataSet.Tables[0].Rows[0]["SignManID"].ToString() != "")
				{
					rcvSndInfo.SignManID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SignManID"].ToString()));
				}
				rcvSndInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = rcvSndInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int ConfSnd(int iTbid, int SndStyleID, string PostNO, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@SndStyleID", SqlDbType.Int),
				new SqlParameter("@PostNO", SqlDbType.NVarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = SndStyleID;
			array[2].Value = PostNO;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("sf_qrfh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int ConfRcv(int iTbid, int iOperator, string RcvDate, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@RcvDate", SqlDbType.NVarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = RcvDate;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("sf_qrsh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int UpdateRemark(int id, string remark)
		{
			string sQLString = "update RcvSnd set Remark = @Remark where ID = @ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@Remark", SqlDbType.VarChar, 2000)
			};
			array[0].Value = id;
			array[1].Value = remark;
			return DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public int ConfCancel(int iTbid, int iOperator, string RcvDate, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@RcvDate", SqlDbType.NVarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = RcvDate;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("sf_qx", array);
			strMsg = Convert.ToString(array[1].Value);
			return result;
		}

		public int Delete(int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("sf_del", array);
			strMsg = Convert.ToString(array[1].Value);
			return result;
		}

		public bool isFirm(int id)
		{
			string sQLString = " select RcvType from sf_rcvsnd where [ID] = @ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			return dataTable.Rows.Count > 0 && dataTable.Rows[0][0].ToString() == "厂商";
		}
	}
}
