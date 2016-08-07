using System;
using System.Collections.Generic;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALBeginStock
	{
		public int Update(BeginStockListInfo model, int DeptID, int iOperator, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			if (model.BeginStockInfos != null)
			{
				foreach (BeginStockInfo current in model.BeginStockInfos)
				{
					list.Add(new string[]
					{
						current.DeptID.ToString(),
						current.StockID.ToString(),
						current.GoodsID.ToString(),
						current.BeginCost.ToString(),
						current.BeginStock.ToString()
					});
				}
			}
			return DbHelperSQL.QC_StockData(list, DeptID, iOperator, out strMsg);
		}
	}
}
