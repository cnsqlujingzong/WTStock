using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALMaintenancePlan
	{
		public int Add(MaintenancePlanInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "_Name";
			text2 = text2 + "'" + model._Name + "'";
			if (model.DevID > 0)
			{
				text += ",DevID";
				text2 = text2 + "," + model.DevID.ToString();
			}
			if (model.DeptID > 0)
			{
				text += ",DeptID";
				text2 = text2 + "," + model.DeptID.ToString();
			}
			if (model.StartDate != string.Empty)
			{
				text += ",StartDate";
				text2 = text2 + ",'" + model.StartDate + "'";
			}
			if (model.EndDate != string.Empty)
			{
				text += ",EndDate";
				text2 = text2 + ",'" + model.EndDate + "'";
			}
			if (model.TimingStyle != string.Empty)
			{
				text += ",TimingStyle";
				text2 = text2 + ",'" + model.TimingStyle + "'";
			}
			if (model.MaintenanceCycle > 0)
			{
				text += ",MaintenanceCycle";
				text2 = text2 + "," + model.MaintenanceCycle.ToString();
			}
			if (model.RemindDay > 0)
			{
				text += ",RemindDay";
				text2 = text2 + "," + model.RemindDay.ToString();
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
				"ks_by_kd"
			});
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(MaintenancePlanInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",StartDate='" + model.StartDate + "'";
			text = text + ",EndDate='" + model.EndDate + "'";
			text = text + ",TimingStyle='" + model.TimingStyle + "'";
			text = text + ",MaintenanceCycle=" + model.MaintenanceCycle;
			text = text + ",RemindDay=" + model.RemindDay;
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("MaintenancePlan", text, " [ID]=" + model.ID.ToString(), "", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public int ChkEndPlan(int iTbid, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.VarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = Reason;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_by_zz", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int ChkDoPlan(int iTbid, int iOperator, string DisOperator, int PRI, string Remark, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@DisOperator", SqlDbType.VarChar, 50),
				new SqlParameter("@PRI", SqlDbType.Int),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = DisOperator;
			array[3].Value = PRI;
			array[4].Value = Remark;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_by_pg", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}

		public int ChkCancel(int iTbid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_by_qx", array);
			strMsg = Convert.ToString(array[1].Value);
			return result;
		}

		public int DelPlan(int iTbid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("if exists(select ID from MaintenancePlan where ID=@iTbid and Status=1) begin delete from PlanAllot where PlanID=@iTbid  delete from MaintenancePlan where ID=@iTbid and Status=1 end");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int)
			};
			array[0].Value = iTbid;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
