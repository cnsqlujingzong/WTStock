using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALStockDept
	{
		public StockDeptInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 a.[ID],isnull(a.StockLocID,-1) as StockLocID,a.Stock,a.CostPrice,a.upWarning,a.downWarning,a.Remark,a.DeptID,b.GoodsNO,b._Name,c._Name as StockName from StockDept a left join Goods b on a.GoodsID=b.[ID] left join StockList c on a.StockID=c.[ID] ");
			stringBuilder.Append(" where a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			StockDeptInfo stockDeptInfo = new StockDeptInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			StockDeptInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					stockDeptInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					stockDeptInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StockLocID"].ToString() != "")
				{
					stockDeptInfo.StockLocID = int.Parse(dataSet.Tables[0].Rows[0]["StockLocID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["Stock"].ToString() != "")
				{
					stockDeptInfo.Stock = decimal.Parse(dataSet.Tables[0].Rows[0]["Stock"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["CostPrice"].ToString() != "")
				{
					stockDeptInfo.CostPrice = decimal.Parse(dataSet.Tables[0].Rows[0]["CostPrice"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["upWarning"].ToString() != "")
				{
					stockDeptInfo.upWarning = decimal.Parse(dataSet.Tables[0].Rows[0]["upWarning"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["downWarning"].ToString() != "")
				{
					stockDeptInfo.downWarning = decimal.Parse(dataSet.Tables[0].Rows[0]["downWarning"].ToString());
				}
				stockDeptInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				stockDeptInfo.GoodsNO = dataSet.Tables[0].Rows[0]["GoodsNO"].ToString();
				stockDeptInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				stockDeptInfo.StockName = dataSet.Tables[0].Rows[0]["StockName"].ToString();
				result = stockDeptInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int Update(StockDeptInfo model, out string strMsg)
		{
			string text = string.Empty;
			text = text + "downWarning=" + model.downWarning.ToString();
			text = text + ",upWarning=" + model.upWarning.ToString();
			if (model.StockLocID > 0)
			{
				text = text + ",StockLocID=" + model.StockLocID.ToString();
			}
			else
			{
				text += ",StockLocID=null";
			}
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("StockDept", text, " [ID]=" + model.ID.ToString(), "", " [ID]=" + model.ID.ToString(), out strMsg);
		}
	}
}
