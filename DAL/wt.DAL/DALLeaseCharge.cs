using System;
using System.Collections.Generic;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALLeaseCharge
	{
		public int Add(LeaseChargeInfo model, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "OperatorID";
			text2 += model.OperatorID.ToString();
			if (model._Date != "")
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.BillID > 0)
			{
				text += ",BillID";
				text2 = text2 + "," + model.BillID.ToString();
			}
			if (model.Status > 0)
			{
				text += ",Status";
				text2 = text2 + "," + model.Status.ToString();
			}
			if (model.StartDate != "")
			{
				text += ",StartDate";
				text2 = text2 + ",'" + model.StartDate + "'";
			}
			if (model.EndDate != "")
			{
				text += ",EndDate";
				text2 = text2 + ",'" + model.EndDate + "'";
			}
			if (model.Cycle > 0m)
			{
				text += ",Cycle";
				text2 = text2 + "," + model.Cycle.ToString();
			}
			if (model.Rent > 0m)
			{
				text += ",Rent";
				text2 = text2 + "," + model.Rent.ToString();
			}
			if (model.SuperZhangFee > 0m)
			{
				text += ",SuperZhangFee";
				text2 = text2 + "," + model.SuperZhangFee.ToString();
			}
			if (model.dRec > 0m)
			{
				text += ",dRec";
				text2 = text2 + "," + model.dRec.ToString();
			}
			if (model.Remark != "")
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.ShangQty > 0)
			{
				text += ",ShangQty";
				text2 = text2 + "," + model.ShangQty.ToString();
			}
			if (model.BenQty > 0)
			{
				text += ",BenQty";
				text2 = text2 + "," + model.BenQty.ToString();
			}
			if (model.Loss > 0)
			{
				text += ",Loss";
				text2 = text2 + "," + model.Loss.ToString();
			}
			list.Add(new string[]
			{
				text,
				text2,
				"zl_js_kd"
			});
			if (model.LeaseChargeDetailInfos != null)
			{
				foreach (LeaseChargeDetailInfo current in model.LeaseChargeDetailInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "DeviceID";
					text2 += current.DeviceID.ToString();
					if (current.QtyTypeID > 0)
					{
						text += ",QtyTypeID";
						text2 = text2 + "," + current.QtyTypeID.ToString();
					}
					if (current.BenQty > 0)
					{
						text += ",BenQty";
						text2 = text2 + "," + current.BenQty.ToString();
					}
					if (current.ShangQty > 0)
					{
						text += ",ShangQty";
						text2 = text2 + "," + current.ShangQty.ToString();
					}
					if (current.LossQty > 0)
					{
						text += ",LossQty";
						text2 = text2 + "," + current.LossQty.ToString();
					}
					if (current.Rated > 0)
					{
						text += ",Rated";
						text2 = text2 + "," + current.Rated.ToString();
					}
					if (current.SupperZhangFee > 0m)
					{
						text += ",SupperZhangFee";
						text2 = text2 + "," + current.SupperZhangFee.ToString();
					}
					if (current.ZSupperZhangFee > 0m)
					{
						text += ",ZSupperZhangFee";
						text2 = text2 + "," + current.ZSupperZhangFee.ToString();
					}
					if (current.ChargeDate != string.Empty)
					{
						text += ",ChargeDate";
						text2 = text2 + ",'" + current.ChargeDate + "'";
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "zl_js_kdmx";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int UpdateCusBln(List<string[]> StrParameters, out string strMsg)
		{
			return DbHelperSQL.UpdateMany(StrParameters, out strMsg);
		}
	}
}
