using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALTroubleList
	{
		public int Add(TroubleListInfo model, bool bsys, out string strMsg, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			if (model.Summary != string.Empty)
			{
				text += "Summary";
				text2 = text2 + "'" + model.Summary + "'";
			}
			if (!bsys)
			{
				if (model.TroubleNO != string.Empty)
				{
					text += ",TroubleNO";
					text2 = text2 + ",'" + model.TroubleNO + "'";
				}
			}
			if (model.ProductClassID > 0)
			{
				text += ",ProductClassID";
				text2 = text2 + "," + model.ProductClassID.ToString();
			}
			if (model.RepairClassID > 0)
			{
				text += ",RepairClassID";
				text2 = text2 + "," + model.RepairClassID.ToString();
			}
			if (model.TroubleClassID > 0)
			{
				text += ",TroubleClassID";
				text2 = text2 + "," + model.TroubleClassID.ToString();
			}
			text += ",dScore";
			text2 = text2 + "," + model.Score.ToString();
			string[] array = new string[8];
			array[0] = "TroubleList";
			array[1] = text;
			array[2] = text2;
			array[3] = " TroubleNO='" + model.TroubleNO + "' ";
			array[4] = "故障编号";
			array[5] = "ID";
			if (bsys)
			{
				array[6] = "TroubleNO";
				array[7] = "3";
			}
			list.Add(array);
			if (model.TakeStepsInfos != null)
			{
				foreach (TakeStepsInfo current in model.TakeStepsInfos)
				{
					string[] array2 = new string[7];
					text = string.Empty;
					text2 = string.Empty;
					if (current.Summary != string.Empty)
					{
						text += "Summary";
						text2 = text2 + "'" + current.Summary + "'";
					}
					array2[0] = "TakeSteps";
					array2[1] = text;
					array2[2] = text2;
					array2[3] = " Summary='" + current.Summary + "' ";
					array2[4] = "处理措施";
					array2[5] = "ID";
					array2[6] = "TroubleID";
					list.Add(array2);
				}
			}
			return DbHelperSQL.RunManyProcedureTran("aa_insertdata", list, bsys, out strMsg, out iTbid);
		}

		public int Update(TroubleListInfo model, bool bsys, string chkfld, List<string> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "Summary='" + model.Summary + "'";
			if (!bsys)
			{
				text = text + ",TroubleNO='" + model.TroubleNO + "'";
			}
			text = text + ",ProductClassID=" + model.ProductClassID.ToString();
			text = text + ",RepairClassID=" + model.RepairClassID.ToString();
			text = text + ",TroubleClassID=" + model.TroubleClassID.ToString();
			text = text + ",dScore=" + model.Score.ToString();
			string[] array = new string[7];
			array[0] = "TroubleList";
			array[1] = text;
			array[2] = " [ID]=" + model.ID.ToString();
			array[3] = chkfld;
			array[4] = " [ID]=" + model.ID.ToString();
			if (bsys)
			{
				array[5] = "TroubleNO";
				array[6] = "3";
			}
			list.Add(array);
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				list2.Add(new string[]
				{
					"TakeSteps",
					" ID in(" + strdellist[i].ToString() + ")"
				});
			}
			if (model.TakeStepsInfos != null)
			{
				foreach (TakeStepsInfo current in model.TakeStepsInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						if (current.Summary != string.Empty)
						{
							text2 += "Summary";
							text = text + "'" + current.Summary + "'";
						}
						array2[0] = "TakeSteps";
						array2[1] = text2;
						array2[2] = text;
						array2[3] = " Summary='" + current.Summary + "' ";
						array2[4] = "处理措施";
						array2[5] = "ID";
						array2[6] = "TroubleID";
						array2[7] = current.ID.ToString();
						array2[8] = model.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "Summary='" + current.Summary + "'";
						array2[0] = "TakeSteps";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "1=2";
						array2[4] = " [ID]=" + current.ID.ToString();
						array2[7] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, bsys, out strMsg);
		}

		public TroubleListInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select a.[ID],ProductClassID,RepairClassID,dScore,TroubleClassID,b._Name as TroubleClass,TroubleNO,Summary from TroubleList a left join TroubleClass b on a.TroubleClassID=b.[ID] ");
			stringBuilder.Append(" where a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			TroubleListInfo troubleListInfo = new TroubleListInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			TroubleListInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					troubleListInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
				{
					troubleListInfo.ProductClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ProductClassID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["RepairClassID"].ToString() != "")
				{
					troubleListInfo.RepairClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["RepairClassID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["TroubleClassID"].ToString() != "")
				{
					troubleListInfo.TroubleClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["TroubleClassID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["dScore"].ToString() != "")
				{
					troubleListInfo.Score = int.Parse(dataSet.Tables[0].Rows[0]["dScore"].ToString());
				}
				troubleListInfo.TroubleClass = dataSet.Tables[0].Rows[0]["TroubleClass"].ToString();
				troubleListInfo.TroubleNO = dataSet.Tables[0].Rows[0]["TroubleNO"].ToString();
				troubleListInfo.Summary = dataSet.Tables[0].Rows[0]["Summary"].ToString();
				result = troubleListInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public string GetSchWhere(int schid, string strcon)
		{
			string text = string.Empty;
			switch (schid)
			{
			case 0:
			{
				string[] array = strcon.Split(new string[]
				{
					" "
				}, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						" and (GoodsClass like '%",
						array[i],
						"%' or GoodsCode like '%",
						array[i],
						"%' or RepairClass like '%",
						array[i],
						"%' or RepairCode like '%",
						array[i],
						"%' or TroubleClass like '%",
						array[i],
						"%' or TroubleNO like '%",
						array[i],
						"%' or Summary like '%",
						array[i],
						"%') "
					});
				}
				break;
			}
			case 1:
				text = text + " and TroubleNO like '%" + strcon + "%' ";
				break;
			case 2:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (GoodsClass like '%",
					strcon,
					"%' or GoodsCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 3:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (RepairClass like '%",
					strcon,
					"%' or RepairCode like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 4:
				text = text + " and TroubleClass like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and Summary like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public int InputTrouble(string strProductClass, string strRepairClass, string strTroubleClass, string strTroubleNO, string strTroubleName, string strSummary1, string strSummary2, string strSummary3, string strSummary4, string strSummary5, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strProductClass", SqlDbType.NVarChar, 50),
				new SqlParameter("@strRepairClass", SqlDbType.NVarChar, 50),
				new SqlParameter("@strTroubleClass", SqlDbType.NVarChar, 50),
				new SqlParameter("@strTroubleNO", SqlDbType.NVarChar, 50),
				new SqlParameter("@strTroubleName", SqlDbType.NVarChar, 500),
				new SqlParameter("@strSummary1", SqlDbType.NVarChar, 500),
				new SqlParameter("@strSummary2", SqlDbType.NVarChar, 500),
				new SqlParameter("@strSummary3", SqlDbType.NVarChar, 500),
				new SqlParameter("@strSummary4", SqlDbType.NVarChar, 500),
				new SqlParameter("@strSummary5", SqlDbType.NVarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strProductClass;
			array[1].Value = strRepairClass;
			array[2].Value = strTroubleClass;
			array[3].Value = strTroubleNO;
			array[4].Value = strTroubleName;
			array[5].Value = strSummary1;
			array[6].Value = strSummary2;
			array[7].Value = strSummary3;
			array[8].Value = strSummary4;
			array[9].Value = strSummary5;
			array[10].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("jc_InputTrouble", array);
			strMsg = Convert.ToString(array[10].Value);
			return result;
		}
	}
}
