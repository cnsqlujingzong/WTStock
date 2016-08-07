using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALOA_Mail
	{
		public int Add(OA_EmailInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "SndID,RcvID,Title,_Date";
			object obj = text2;
			text2 = string.Concat(new object[]
			{
				obj,
				model.SndID,
				",",
				model.RcvID,
				",'",
				model.Title,
				"',getdate()"
			});
			if (model.bSndFlag > 0)
			{
				text += ",bSndFlag";
				text2 = text2 + "," + model.bSndFlag.ToString();
			}
			if (model.bRcvFlag > 0)
			{
				text += ",bRcvFlag";
				text2 = text2 + "," + model.bRcvFlag.ToString();
			}
			if (model.bAccessory)
			{
				text += ",bAccessory";
				text2 += ",1";
			}
			if (model.Content != string.Empty)
			{
				text += ",Content";
				text2 = text2 + ",'" + model.Content + "'";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"oa_znxj_add"
			});
			if (model.OA_MailAccessoryInfos != null)
			{
				foreach (OA_MailAccessoryInfo current in model.OA_MailAccessoryInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "FilePath";
					text2 = text2 + "'" + current.FilePath + "'";
					array[0] = text;
					array[1] = text2;
					array[2] = "oa_znxj_addmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public void Update(OA_EmailInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update OA_Email set ");
			stringBuilder.Append("bRcvFlag=@bRcvFlag,");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("SndID=@SndID,");
			stringBuilder.Append("RcvID=@RcvID,");
			stringBuilder.Append("Title=@Title,");
			stringBuilder.Append("Content=@Content,");
			stringBuilder.Append("bRead=@bRead,");
			stringBuilder.Append("bAccessory=@bAccessory,");
			stringBuilder.Append("bSndFlag=@bSndFlag");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@bRcvFlag", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@SndID", SqlDbType.Int, 4),
				new SqlParameter("@RcvID", SqlDbType.Int, 4),
				new SqlParameter("@Title", SqlDbType.VarChar, 100),
				new SqlParameter("@Content", SqlDbType.Text),
				new SqlParameter("@bRead", SqlDbType.Bit, 1),
				new SqlParameter("@bAccessory", SqlDbType.Bit, 1),
				new SqlParameter("@bSndFlag", SqlDbType.Int, 4)
			};
			array[0].Value = model.ID;
			array[1].Value = model.bRcvFlag;
			array[2].Value = model._Date;
			array[3].Value = model.SndID;
			array[4].Value = model.RcvID;
			array[5].Value = model.Title;
			array[6].Value = model.Content;
			array[7].Value = model.bRead;
			array[8].Value = model.bAccessory;
			array[9].Value = model.bSndFlag;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateRead(int RecID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update OA_Email set ");
			stringBuilder.Append("bRead=1 ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateRcv(int RecID, int flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update OA_Email set ");
			stringBuilder.Append("bRcvFlag=@bRcvFlag ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@bRcvFlag", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			array[1].Value = flag;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public void UpdateSnd(int RecID, int flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update OA_Email set ");
			stringBuilder.Append("bSndFlag=@bSndFlag ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@bSndFlag", SqlDbType.Int, 4)
			};
			array[0].Value = RecID;
			array[1].Value = flag;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public OA_EmailInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 a.[ID],a.[_Date],a.SndID,a.RcvID,b._Name as Snd,c._Name as Rcv,a.Title,a.Content,a.bRead,a.bAccessory,a.bSndFlag,a.bRcvFlag from OA_Email a left join StaffList b on a.SndID=b.[ID] left join StaffList c on a.RcvID=c.[ID] ");
			stringBuilder.Append(" where a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			OA_EmailInfo oA_EmailInfo = new OA_EmailInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			OA_EmailInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					oA_EmailInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				oA_EmailInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				if (dataSet.Tables[0].Rows[0]["SndID"].ToString() != "")
				{
					oA_EmailInfo.SndID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SndID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["RcvID"].ToString() != "")
				{
					oA_EmailInfo.RcvID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["RcvID"].ToString()));
				}
				oA_EmailInfo.Title = dataSet.Tables[0].Rows[0]["Title"].ToString();
				oA_EmailInfo.Snd = dataSet.Tables[0].Rows[0]["Snd"].ToString();
				oA_EmailInfo.Rcv = dataSet.Tables[0].Rows[0]["Rcv"].ToString();
				oA_EmailInfo.Content = dataSet.Tables[0].Rows[0]["Content"].ToString();
				if (dataSet.Tables[0].Rows[0]["bRead"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bRead"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bRead"].ToString().ToLower() == "true")
					{
						oA_EmailInfo.bRead = true;
					}
					else
					{
						oA_EmailInfo.bRead = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bAccessory"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bAccessory"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bAccessory"].ToString().ToLower() == "true")
					{
						oA_EmailInfo.bAccessory = true;
					}
					else
					{
						oA_EmailInfo.bAccessory = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSndFlag"].ToString() != "")
				{
					oA_EmailInfo.bSndFlag = new int?(int.Parse(dataSet.Tables[0].Rows[0]["bSndFlag"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["bRcvFlag"].ToString() != "")
				{
					oA_EmailInfo.bRcvFlag = new int?(int.Parse(dataSet.Tables[0].Rows[0]["bRcvFlag"].ToString()));
				}
				result = oA_EmailInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public string TCount(string strWhere)
		{
			return DALCommon.TCount("OA_Email", strWhere);
		}

		public string GetListStr(string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("select [FilePath] ");
			stringBuilder2.Append(" FROM OA_MailAccessory ");
			if (strWhere.Trim() != "")
			{
				stringBuilder2.Append(" where " + strWhere);
			}
			DataTable dataTable = DbHelperSQL.Query(stringBuilder2.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					stringBuilder.Append(dataTable.Rows[i][0].ToString() + ",");
				}
			}
			return stringBuilder.ToString().TrimEnd(new char[]
			{
				','
			});
		}
	}
}
