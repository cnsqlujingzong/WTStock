using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALRight
	{
		public int Add(RightInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "DeptID";
			text2 += model.DeptID.ToString();
			if (model._Name != string.Empty)
			{
				text += ",_Name";
				text2 = text2 + ",'" + model._Name + "'";
			}
			list.Add(new string[]
			{
				text,
				text2,
				"xt_qx_add"
			});
			if (model.RightDetailInfos != null)
			{
				foreach (RightDetailInfo current in model.RightDetailInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "RightCode";
					text2 = text2 + "'" + current.RightCode + "'";
					if (current.bValue)
					{
						text += ",bValue";
						text2 += ",1";
					}
					else
					{
						text += ",bValue";
						text2 += ",0";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "xt_qx_addmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(RightInfo model, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			list.Add(new string[]
			{
				"[Right]",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			list2.Add(new string[]
			{
				"RightDetail",
				" RightID=" + model.ID.ToString()
			});
			if (model.RightDetailInfos != null)
			{
				foreach (RightDetailInfo current in model.RightDetailInfos)
				{
					string[] array = new string[5];
					text2 = string.Empty;
					text = string.Empty;
					text2 += "RightCode";
					text = text + "'" + current.RightCode + "'";
					if (current.bValue)
					{
						text2 += ",bValue";
						text += ",1";
					}
					else
					{
						text2 += ",bValue";
						text += ",0";
					}
					array[0] = text2;
					array[1] = text;
					array[2] = "xt_qx_addmx";
					array[3] = model.ID.ToString();
					array[4] = "0";
					list.Add(array);
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public int Delete(int Dept, int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Dept", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = Dept;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("xt_qx_del", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int DeleteMX(int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("xt_qx_delmx", array);
			strMsg = Convert.ToString(array[1].Value);
			return result;
		}

		public bool GetRight(int RightID, string RightCode)
		{
			bool result = false;
			if (RightID != 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("select bValue from RightDetail ");
				stringBuilder.Append(" where RightID=@RightID and RightCode=@RightCode");
				SqlParameter[] array = new SqlParameter[]
				{
					new SqlParameter("@RightID", SqlDbType.Int),
					new SqlParameter("@RightCode", SqlDbType.VarChar)
				};
				array[0].Value = RightID;
				array[1].Value = RightCode;
				DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					if (dataSet.Tables[0].Rows[0]["bValue"].ToString() != "")
					{
						if (dataSet.Tables[0].Rows[0]["bValue"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bValue"].ToString().ToLower() == "true")
						{
							result = true;
						}
					}
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		public bool ChkBranchPurchase(int DeptID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select bBranchPurchase from BranchList where ID=@DeptID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int, 4)
			};
			array[0].Value = DeptID;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			return single != null && (single.ToString().Trim().ToLower().Equals("true") || single.ToString().Trim().ToLower().Equals("1"));
		}

		public bool BranchAddGoods(int purid, int deptid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("declare @rev bit  set @rev=0 ");
			stringBuilder.Append("if (select isnull(bGoodsAdd,0) from BranchList where ID=@deptid)=0 begin select 0 return end ");
			stringBuilder.Append("if @purid=0 begin select 1 return end ");
			stringBuilder.Append("select @rev=bvalue from rightdetail where rightid=@purid and rightcode='ck_r79' select @rev");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@purid", SqlDbType.Int, 4),
				new SqlParameter("@deptid", SqlDbType.Int, 4)
			};
			array[0].Value = purid;
			array[1].Value = deptid;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			return single != null && (single.ToString().Trim().ToLower().Equals("true") || single.ToString().Trim().ToLower().Equals("1"));
		}
	}
}
