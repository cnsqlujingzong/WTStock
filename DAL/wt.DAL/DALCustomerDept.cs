using System;
using wt.Model;

namespace wt.DAL
{
	public class DALCustomerDept
	{
		public int Add(CustomerDeptInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
			string text3 = " _Name='" + model._Name + "' ";
			text3 = text3 + " and CustomerID=" + model.CustomerID.ToString();
			text += ",CustomerID";
			text2 = text2 + "," + model.CustomerID.ToString();
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
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("CustomerDept", text, text2, text3, "客户部门", "ID", out strMsg, out iTbid);
		}

		public int Update(CustomerDeptInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("CustomerDept", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}
	}
}
