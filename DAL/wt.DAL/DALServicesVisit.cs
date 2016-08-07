using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServicesVisit
	{
		public int Add(ServicesVisitInfo model, out int iTbid)
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
			text += ",BillID";
			text2 = text2 + "," + model.BillID.ToString();
			if (model.VisitStyleID > 0)
			{
				text += ",VisitStyleID";
				text2 = text2 + "," + model.VisitStyleID.ToString();
			}
			if (model.CusName != string.Empty)
			{
				text += ",CusName";
				text2 = text2 + ",'" + model.CusName + "'";
			}
			if (model.Opinion != string.Empty)
			{
				text += ",Opinion";
				text2 = text2 + ",'" + model.Opinion + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			text += ",Score";
			text2 = text2 + "," + model.Score;
			list.Add(new string[]
			{
				text,
				text2,
				"fw_hf_kd"
			});
			if (model.ServicesVisitResultInfos != null)
			{
				foreach (ServicesVisitResultInfo current in model.ServicesVisitResultInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "VisitResultID";
					text2 += current.VisitResultID.ToString();
					array[0] = text;
					array[1] = text2;
					array[2] = "fw_hf_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(ServicesVisitInfo model, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "OperatorID=" + model.OperatorID.ToString();
			text = text + ",_Date='" + model._Date + "'";
			if (model.VisitStyleID > 0)
			{
				text = text + ",VisitStyleID=" + model.VisitStyleID.ToString();
			}
			else
			{
				text += ",VisitStyleID=null";
			}
			text = text + ",CusName='" + model.CusName + "'";
			text = text + ",Opinion='" + model.Opinion + "'";
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",Score=" + model.Score;
			list.Add(new string[]
			{
				"ServicesVisit",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> strdellist = new List<string[]>();
			if (model.ServicesVisitResultInfos != null)
			{
				foreach (ServicesVisitResultInfo current in model.ServicesVisitResultInfos)
				{
					string[] array = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "VisitResultID";
						text += current.VisitResultID.ToString();
						array[0] = text2;
						array[1] = text;
						array[2] = "fw_hf_kdmx";
						array[3] = model.ID.ToString();
						array[4] = current.ID.ToString();
						list.Add(array);
					}
					else
					{
						text = string.Empty;
						text = text + "VisitResultID=" + current.VisitResultID.ToString();
						array[0] = "ServicesVisitResult";
						array[1] = text;
						array[2] = " [ID]=" + current.ID.ToString();
						array[3] = "";
						array[4] = current.ID.ToString();
						list.Add(array);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, strdellist, out strMsg);
		}

		public int ExistsGetValue(int BillID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 [ID] from ServicesVisit ");
			stringBuilder.Append(" where BillID=@BillID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.Int, 4)
			};
			array[0].Value = BillID;
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

		public int ExistsMXGetValue(int visitid, int visitcontentid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 [ID] from fw_visitresult ");
			stringBuilder.Append(" where VisitID=@VisitID and ContentID=@ContentID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@VisitID", SqlDbType.Int, 4),
				new SqlParameter("@ContentID", SqlDbType.Int, 4)
			};
			array[0].Value = visitid;
			array[1].Value = visitcontentid;
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
	}
}
