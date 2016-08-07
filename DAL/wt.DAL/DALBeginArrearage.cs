using System;
using System.Collections.Generic;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALBeginArrearage
	{
		public int Update(BeginArrearageInfo model, int DeptID, int CusType, int iOperator, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			if (model.BeginArrDetailInfos != null)
			{
				foreach (BeginArrDetailInfo current in model.BeginArrDetailInfos)
				{
					list.Add(new string[]
					{
						current.DeptID.ToString(),
						current.CustomerID.ToString(),
						current.CusType.ToString(),
						current.dRec.ToString(),
						current.dDue.ToString()
					});
				}
			}
			return DbHelperSQL.QC_ArrearageData(list, DeptID, CusType, iOperator, out strMsg);
		}
	}
}
