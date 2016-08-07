using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALVisitContent
	{
		public int Add(VisitContentInfo model, out string strMsg, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			if (model.Content != string.Empty)
			{
				text += "Content";
				text2 = text2 + "'" + model.Content + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			string[] array = new string[8];
			array[0] = "VisitContent";
			array[1] = text;
			array[2] = text2;
			array[3] = " 1=2 ";
			array[4] = "";
			array[5] = "ID";
			list.Add(array);
			foreach (VisitResultInfo current in model.VisitResultInfos)
			{
				string[] array2 = new string[7];
				text = string.Empty;
				text2 = string.Empty;
				if (current.Result != string.Empty)
				{
					text += "Result";
					text2 = text2 + "'" + current.Result + "'";
				}
				if (current.Rewards > 0m)
				{
					text += ",Rewards";
					text2 = text2 + "," + current.Rewards.ToString();
				}
				if (current.Remark != string.Empty)
				{
					text += ",Remark";
					text2 = text2 + ",'" + current.Remark + "'";
				}
				array2[0] = "VisitResult";
				array2[1] = text;
				array2[2] = text2;
				array2[3] = " 1=2 ";
				array2[4] = "";
				array2[5] = "ID";
				array2[6] = "ContentID";
				list.Add(array2);
			}
			return DbHelperSQL.RunManyProcedureTran("aa_insertdata", list, false, out strMsg, out iTbid);
		}

		public int Update(VisitContentInfo model, List<string> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "Content='" + model.Content + "'";
			text = text + ",Remark='" + model.Remark + "'";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				",bStop='",
				model.bStop,
				"'"
			});
			string[] array = new string[7];
			array[0] = "VisitContent";
			array[1] = text;
			array[2] = " [ID]=" + model.ID.ToString();
			array[3] = "";
			array[4] = " [ID]=" + model.ID.ToString();
			list.Add(array);
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				list2.Add(new string[]
				{
					"VisitResult",
					" ID in(" + strdellist[i].ToString() + ")"
				});
			}
			if (model.VisitResultInfos != null)
			{
				foreach (VisitResultInfo current in model.VisitResultInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						if (current.Result != string.Empty)
						{
							text2 += "Result";
							text = text + "'" + current.Result + "'";
						}
						text2 += ",Rewards";
						text = text + "," + current.Rewards.ToString();
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						array2[0] = "VisitResult";
						array2[1] = text2;
						array2[2] = text;
						array2[3] = "1=2";
						array2[4] = "";
						array2[5] = "ID";
						array2[6] = "ContentID";
						array2[7] = current.ID.ToString();
						array2[8] = model.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "Result='" + current.Result + "'";
						text = text + ",Rewards=" + current.Rewards.ToString();
						text = text + ",Remark='" + current.Remark + "'";
						array2[0] = "VisitResult";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "1=2";
						array2[4] = " [ID]=" + current.ID.ToString();
						array2[7] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, false, out strMsg);
		}

		public VisitContentInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Content,Remark,bStop from VisitContent ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			VisitContentInfo visitContentInfo = new VisitContentInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			VisitContentInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					visitContentInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["bStop"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStop"].ToString().ToLower() == "true")
					{
						visitContentInfo.bStop = true;
					}
					else
					{
						visitContentInfo.bStop = false;
					}
				}
				visitContentInfo.Content = dataSet.Tables[0].Rows[0]["Content"].ToString();
				visitContentInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = visitContentInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
