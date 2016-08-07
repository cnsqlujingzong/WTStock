using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALServices
	{
		public int Add(ServicesInfo model, string Faults, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "TakeOverID";
			text2 += model.TakeOverID.ToString();
			text += ",DisposalID";
			text2 = text2 + "," + model.DisposalID.ToString();
			text += ",curStatus";
			text2 = text2 + ",'" + model.curStatus + "'";
			if (model.TypeID > 0)
			{
				text += ",TypeID";
				text2 = text2 + "," + model.TypeID.ToString();
			}
			if (model.TakeStyleID > 0)
			{
				text += ",TakeStyleID";
				text2 = text2 + "," + model.TakeStyleID.ToString();
			}
			text += ",Time_TakeOver";
			text2 = text2 + ",'" + model.Time_TakeOver + "'";
			text += ",Time_Make";
			text2 = text2 + ",'" + model.Time_Make + "'";
			if (model.Time_Complete != string.Empty)
			{
				text += ",Time_Complete";
				text2 = text2 + ",'" + model.Time_Complete + "'";
			}
			if (model.OperatorID > 0)
			{
				text += ",OperatorID";
				text2 = text2 + "," + model.OperatorID.ToString();
			}
			if (model.PersonID > 0)
			{
				text += ",PersonID";
				text2 = text2 + "," + model.PersonID;
			}
			if (model.DisposalOper != string.Empty)
			{
				text += ",DisposalOper";
				text2 = text2 + ",'" + model.DisposalOper + "'";
			}
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID;
			}
			if (model.CustomerName != string.Empty)
			{
				text += ",CustomerName";
				text2 = text2 + ",'" + model.CustomerName + "'";
			}
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
			if (model.Adr != string.Empty)
			{
				text += ",Adr";
				text2 = text2 + ",'" + model.Adr + "'";
			}
			if (model.Area != string.Empty)
			{
				text += ",Area";
				text2 = text2 + ",'" + model.Area + "'";
			}
			if (model.UsePerson != string.Empty)
			{
				text += ",UsePerson";
				text2 = text2 + ",'" + model.UsePerson + "'";
			}

            if (model.CmbProver != string.Empty)
            {
                text += ",cmbProver";
                text2 = text2 + ",'" + model.CmbProver + "'";
            }
            if (model.CmbCity != string.Empty)
            {
                text += ",cmbCity";
                text2 = text2 + ",'" + model.CmbCity + "'";
            }
            if (model.BranchName != string.Empty)
            {
                text += ",BranchName";
                text2 = text2 + ",'" + model.BranchName + "'";
            }
           
                text += ",BranchRatio";
                text2 = text2 + ",'" + model.BranchRatio + "'";
            
            if (model.BranchRatioType != string.Empty)
            {
                text += ",BranchRatioType";
                text2 = text2 + ",'" + model.BranchRatioType + "'";
            }
      


            if (model.UsePersonTel != string.Empty)
			{
				text += ",UsePersonTel";
				text2 = text2 + ",'" + model.UsePersonTel + "'";
			}
			if (model.UsePersonDept != string.Empty)
			{
				text += ",UsePersonDept";
				text2 = text2 + ",'" + model.UsePersonDept + "'";
			}
			if (model.ProductBrandID > 0)
			{
				text += ",ProductBrandID";
				text2 = text2 + "," + model.ProductBrandID.ToString();
			}
			if (model.ProductClassID > 0)
			{
				text += ",ProductClassID";
				text2 = text2 + "," + model.ProductClassID.ToString();
			}
			if (model.ProductModelID > 0)
			{
				text += ",ProductModelID";
				text2 = text2 + "," + model.ProductModelID.ToString();
			}
			if (model.ProductSN1 != string.Empty && model.ProductSN1 != null)
			{
				text += ",ProductSN1";
				text2 = text2 + ",'" + model.ProductSN1 + "'";
			}
			if (model.ProductSN2 != string.Empty && model.ProductSN2 != null)
			{
				text += ",ProductSN2";
				text2 = text2 + ",'" + model.ProductSN2 + "'";
			}
			if (model.Aspect != string.Empty)
			{
				text += ",Aspect";
				text2 = text2 + ",'" + model.Aspect + "'";
			}
			if (model.WarrantyID > 0)
			{
				text += ",WarrantyID";
				text2 = text2 + "," + model.WarrantyID.ToString();
			}
			if (model.BuyDate != string.Empty && model.BuyDate != null)
			{
				text += ",BuyDate";
				text2 = text2 + ",'" + model.BuyDate + "'";
			}
			if (model.BuyFrom != string.Empty && model.BuyFrom != null)
			{
				text += ",BuyFrom";
				text2 = text2 + ",'" + model.BuyFrom + "'";
			}
			if (model.BuyInvoice != string.Empty)
			{
				text += ",BuyInvoice";
				text2 = text2 + ",'" + model.BuyInvoice + "'";
			}
			if (model.dPoint > 0m)
			{
				text += ",dPoint";
				text2 = text2 + "," + model.dPoint.ToString();
			}
			if (model.bRepair)
			{
				text += ",bRepair";
				text2 += ",1";
			}
			if (model.bAgain)
			{
				text += ",bAgain";
				text2 += ",1";
			}
			if (model.Accessory != string.Empty)
			{
				text += ",Accessory";
				text2 = text2 + ",'" + model.Accessory + "'";
			}
			if (model.Fault != string.Empty)
			{
				text += ",Fault";
				text2 = text2 + ",'" + model.Fault + "'";
			}
			if (model.SaveID != string.Empty)
			{
				text += ",SaveID";
				text2 = text2 + ",'" + model.SaveID + "'";
			}
			if (model.SupplierID != string.Empty)
			{
				text += ",SupplierID";
				text2 = text2 + ",'" + model.SupplierID + "'";
			}
			if (model.WarrantyChargeCorpID > 0)
			{
				text += ",WarrantyChargeCorpID";
				text2 = text2 + "," + model.WarrantyChargeCorpID.ToString();
			}
			if (model.SubscribeTime != string.Empty)
			{
				text += ",SubscribeTime";
				text2 = text2 + ",'" + model.SubscribeTime + "'";
			}
			if (model.SubscribeConnectTime != string.Empty)
			{
				text += ",SubscribeConnectTime";
				text2 = text2 + ",'" + model.SubscribeConnectTime + "'";
			}
			if (model.SubscribePrice > 0m)
			{
				text += ",SubscribePrice";
				text2 = text2 + "," + model.SubscribePrice.ToString();
			}
			if (model.PreCharge > 0m)
			{
				text += ",PreCharge";
				text2 = text2 + "," + model.PreCharge.ToString();
			}
			if (model.Postage > 0m)
			{
				text += ",Postage";
				text2 = text2 + "," + model.Postage.ToString();
			}
			if (model.PostNO != string.Empty)
			{
				text += ",PostNO";
				text2 = text2 + ",'" + model.PostNO + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.ServiceLevelID > 0)
			{
				text += ",ServiceLevelID";
				text2 = text2 + "," + model.ServiceLevelID;
			}
			if (model.SndStyleID > 0)
			{
				text += ",SndStyleID";
				text2 = text2 + "," + model.SndStyleID;
			}
			if (model.ContractNO != string.Empty)
			{
				text += ",ContractNO";
				text2 = text2 + ",'" + model.ContractNO + "'";
			}
			if (model.DeviceNO != string.Empty && model.Remark != null)
			{
				text += ",DeviceNO";
				text2 = text2 + ",'" + model.DeviceNO + "'";
			}
			if (model.Path != string.Empty)
			{
				text += ",Path";
				text2 = text2 + ",'" + model.Path + "'";
			}
			if (!Faults.Trim().Equals(""))
			{
				text2 = text2 + "Fault<" + Faults;
			}
			list.Add(new string[]
			{
				text,
				text2,
				"fw_gd_add"
			});
			if (model.ServicesDeviceConfInfos != null)
			{
				foreach (ServicesDeviceConfInfo current in model.ServicesDeviceConfInfos)
				{
					string[] array = new string[3];
					text = string.Empty;
					text2 = string.Empty;
					text += "_Name";
					text2 = text2 + "'" + current._Name + "'";
					if (current.Parameter != string.Empty)
					{
						text += ",Parameter";
						text2 = text2 + ",'" + current.Parameter + "'";
					}
					if (current.SN != string.Empty)
					{
						text += ",SN";
						text2 = text2 + ",'" + current.SN + "'";
					}
					if (current.MaintenancePeriod != string.Empty)
					{
						text += ",MaintenancePeriod";
						text2 = text2 + ",'" + current.MaintenancePeriod + "'";
					}
					if (current.BuyDate != string.Empty)
					{
						text += ",BuyDate";
						text2 = text2 + ",'" + current.BuyDate + "'";
					}
					if (current.MaintenanceEnd != string.Empty)
					{
						text += ",MaintenanceEnd";
						text2 = text2 + ",'" + current.MaintenanceEnd + "'";
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					if (current.DevConfID > 0)
					{
						text += ",DevConfID";
						text2 = text2 + "," + current.DevConfID;
					}
					array[0] = text;
					array[1] = text2;
					array[2] = "gd_jqpz_add";
					list.Add(array);
				}
			}
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int AddBat(ServicesInfo model, string Faults, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text += "TakeOverID";
			text2 += model.TakeOverID.ToString();
			text += ",DisposalID";
			text2 = text2 + "," + model.DisposalID.ToString();
			text += ",curStatus";
			text2 = text2 + ",'" + model.curStatus + "'";
			text += ",BillID";
			text2 = text2 + ",'" + model.BillID + "'";
			if (model.TypeID > 0)
			{
				text += ",TypeID";
				text2 = text2 + "," + model.TypeID.ToString();
			}
			if (model.TakeStyleID > 0)
			{
				text += ",TakeStyleID";
				text2 = text2 + "," + model.TakeStyleID.ToString();
			}
			text += ",Time_TakeOver";
			text2 = text2 + ",'" + model.Time_TakeOver + "'";
			text += ",Time_Make";
			text2 = text2 + ",'" + model.Time_Make + "'";
			if (model.OperatorID > 0)
			{
				text += ",OperatorID";
				text2 = text2 + "," + model.OperatorID.ToString();
			}
			if (model.PersonID > 0)
			{
				text += ",PersonID";
				text2 = text2 + "," + model.PersonID;
			}
			if (model.DisposalOper != string.Empty)
			{
				text += ",DisposalOper";
				text2 = text2 + ",'" + model.DisposalOper + "'";
			}
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID;
			}
			if (model.CustomerName != string.Empty)
			{
				text += ",CustomerName";
				text2 = text2 + ",'" + model.CustomerName + "'";
			}
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
			if (model.Adr != string.Empty)
			{
				text += ",Adr";
				text2 = text2 + ",'" + model.Adr + "'";
			}
			if (model.Area != string.Empty)
			{
				text += ",Area";
				text2 = text2 + ",'" + model.Area + "'";
			}
			if (model.UsePerson != string.Empty)
			{
				text += ",UsePerson";
				text2 = text2 + ",'" + model.UsePerson + "'";
			}
			if (model.UsePersonTel != string.Empty)
			{
				text += ",UsePersonTel";
				text2 = text2 + ",'" + model.UsePersonTel + "'";
			}
			if (model.UsePersonDept != string.Empty)
			{
				text += ",UsePersonDept";
				text2 = text2 + ",'" + model.UsePersonDept + "'";
			}
			if (model.ProductBrandID > 0)
			{
				text += ",ProductBrandID";
				text2 = text2 + "," + model.ProductBrandID.ToString();
			}
			if (model.ProductClassID > 0)
			{
				text += ",ProductClassID";
				text2 = text2 + "," + model.ProductClassID.ToString();
			}
			if (model.ProductModelID > 0)
			{
				text += ",ProductModelID";
				text2 = text2 + "," + model.ProductModelID.ToString();
			}
			if (model.ProductSN1 != string.Empty && model.ProductSN1 != null)
			{
				text += ",ProductSN1";
				text2 = text2 + ",'" + model.ProductSN1 + "'";
			}
			if (model.ProductSN2 != string.Empty && model.ProductSN2 != null)
			{
				text += ",ProductSN2";
				text2 = text2 + ",'" + model.ProductSN2 + "'";
			}
			if (model.Aspect != string.Empty)
			{
				text += ",Aspect";
				text2 = text2 + ",'" + model.Aspect + "'";
			}
			if (model.WarrantyID > 0)
			{
				text += ",WarrantyID";
				text2 = text2 + "," + model.WarrantyID.ToString();
			}
			if (model.BuyDate != string.Empty && model.BuyDate != null)
			{
				text += ",BuyDate";
				text2 = text2 + ",'" + model.BuyDate + "'";
			}
			if (model.BuyFrom != string.Empty && model.BuyFrom != null)
			{
				text += ",BuyFrom";
				text2 = text2 + ",'" + model.BuyFrom + "'";
			}
			if (model.BuyInvoice != string.Empty)
			{
				text += ",BuyInvoice";
				text2 = text2 + ",'" + model.BuyInvoice + "'";
			}
			if (model.dPoint > 0m)
			{
				text += ",dPoint";
				text2 = text2 + "," + model.dPoint.ToString();
			}
			if (model.bRepair)
			{
				text += ",bRepair";
				text2 += ",1";
			}
			if (model.bAgain)
			{
				text += ",bAgain";
				text2 += ",1";
			}
			if (model.Accessory != string.Empty)
			{
				text += ",Accessory";
				text2 = text2 + ",'" + model.Accessory + "'";
			}
			if (model.Fault != string.Empty)
			{
				text += ",Fault";
				text2 = text2 + ",'" + model.Fault + "'";
			}
			if (model.SaveID != string.Empty)
			{
				text += ",SaveID";
				text2 = text2 + ",'" + model.SaveID + "'";
			}
			if (model.SupplierID != string.Empty)
			{
				text += ",SupplierID";
				text2 = text2 + ",'" + model.SupplierID + "'";
			}
			if (model.WarrantyChargeCorpID > 0)
			{
				text += ",WarrantyChargeCorpID";
				text2 = text2 + "," + model.WarrantyChargeCorpID.ToString();
			}
			if (model.SubscribeTime != string.Empty)
			{
				text += ",SubscribeTime";
				text2 = text2 + ",'" + model.SubscribeTime + "'";
			}
			if (model.Time_Complete != string.Empty)
			{
				text += ",Time_Complete";
				text2 = text2 + ",'" + model.Time_Complete + "'";
			}
			if (model.SubscribeConnectTime != string.Empty)
			{
				text += ",SubscribeConnectTime";
				text2 = text2 + ",'" + model.SubscribeConnectTime + "'";
			}
			if (model.SubscribePrice > 0m)
			{
				text += ",SubscribePrice";
				text2 = text2 + "," + model.SubscribePrice.ToString();
			}
			if (model.PreCharge > 0m)
			{
				text += ",PreCharge";
				text2 = text2 + "," + model.PreCharge.ToString();
			}
			if (model.Postage > 0m)
			{
				text += ",Postage";
				text2 = text2 + "," + model.Postage.ToString();
			}
			if (model.PostNO != string.Empty)
			{
				text += ",PostNO";
				text2 = text2 + ",'" + model.PostNO + "'";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.ServiceLevelID > 0)
			{
				text += ",ServiceLevelID";
				text2 = text2 + "," + model.ServiceLevelID;
			}
			if (model.SndStyleID > 0)
			{
				text += ",SndStyleID";
				text2 = text2 + "," + model.SndStyleID;
			}
			if (model.ContractNO != string.Empty)
			{
				text += ",ContractNO";
				text2 = text2 + ",'" + model.ContractNO + "'";
			}
			if (model.DeviceNO != string.Empty && model.Remark != null)
			{
				text += ",DeviceNO";
				text2 = text2 + ",'" + model.DeviceNO + "'";
			}
			if (model.Path != string.Empty)
			{
				text += ",Path";
				text2 = text2 + ",'" + model.Path + "'";
			}
			if (!Faults.Trim().Equals(""))
			{
				text2 = text2 + "Fault<" + Faults;
			}
			list.Add(new string[]
			{
				text,
				text2,
				"fw_gd_addbat"
			});
			return DbHelperSQL.RunProcedureTran(list, out iTbid);
		}

		public int Update(ServicesInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "Remark='" + model.Remark + "'";
			if (model.TypeID > 0)
			{
				text = text + ",TypeID=" + model.TypeID.ToString();
			}
			else
			{
				text += ",TypeID=null";
			}
			if (model.TakeStyleID > 0)
			{
				text = text + ",TakeStyleID=" + model.TakeStyleID.ToString();
			}
			else
			{
				text += ",TakeStyleID=null";
			}
			if (model.Time_TakeOver != string.Empty)
			{
				text = text + ",Time_TakeOver='" + model.Time_TakeOver + "'";
			}
			else
			{
				text += ",Time_TakeOver=null";
			}
			if (model.Time_Make != string.Empty)
			{
				text = text + ",Time_Make='" + model.Time_Make + "'";
			}
			else
			{
				text += ",Time_Make=null";
			}
			if (model.OperatorID > 0)
			{
				text = text + ",OperatorID=" + model.OperatorID.ToString();
			}
			else
			{
				text += ",OperatorID=null";
			}
			text = text + ",DisposalOper='" + model.DisposalOper + "'";
			if (model.CustomerID > 0)
			{
				text = text + ",CustomerID=" + model.CustomerID;
			}
			else
			{
				text += ",CustomerID=null";
			}
			text = text + ",CustomerName='" + model.CustomerName + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",Area='" + model.Area + "'";
			text = text + ",UsePerson='" + model.UsePerson + "'";



            text = text + ",cmbProver='" + model.CmbProver + "'";
            text = text + ",cmbCity='" + model.CmbCity + "'";
            text = text + ",BranchName='" + model.BranchName + "'";
            text = text + ",BranchRatio=" + model.BranchRatio;
            text = text + ",BranchRatioType='" + model.BranchRatioType + "'";

			text = text + ",UsePersonTel='" + model.UsePersonTel + "'";
			text = text + ",UsePersonDept='" + model.UsePersonDept + "'";
			text = text + ",ProductSN1='" + model.ProductSN1 + "'";
			if (model.ProductBrandID > 0)
			{
				text = text + ",ProductBrandID=" + model.ProductBrandID.ToString();
			}
			else
			{
				text += ",ProductBrandID=null";
			}
			if (model.ProductClassID > 0)
			{
				text = text + ",ProductClassID=" + model.ProductClassID.ToString();
			}
			else
			{
				text += ",ProductClassID=null";
			}
			if (model.ProductModelID > 0)
			{
				text = text + ",ProductModelID=" + model.ProductModelID.ToString();
			}
			else
			{
				text += ",ProductModelID=null";
			}
			text = text + ",ProductSN2='" + model.ProductSN2 + "'";
			text = text + ",Aspect='" + model.Aspect + "'";
			if (model.WarrantyID > 0)
			{
				text = text + ",WarrantyID=" + model.WarrantyID.ToString();
			}
			else
			{
				text += ",WarrantyID=null";
			}
			if (model.BuyDate != string.Empty)
			{
				text = text + ",BuyDate='" + model.BuyDate + "'";
			}
			else
			{
				text += ",BuyDate=null";
			}
			text = text + ",BuyFrom='" + model.BuyFrom + "'";
			text = text + ",BuyInvoice='" + model.BuyInvoice + "'";
			text = text + ",dPoint=" + model.dPoint.ToString();
			if (model.bRepair)
			{
				text += ",bRepair=1";
			}
			else
			{
				text += ",bRepair=0";
			}
			if (model.bAgain)
			{
				text += ",bAgain=1";
			}
			else
			{
				text += ",bAgain=0";
			}
			text = text + ",Accessory='" + model.Accessory + "'";
			text = text + ",Fault='" + model.Fault + "'";
			text = text + ",SaveID='" + model.SaveID + "'";
			text = text + ",SupplierID='" + model.SupplierID + "'";
			if (model.WarrantyChargeCorpID > 0)
			{
				text = text + ",WarrantyChargeCorpID=" + model.WarrantyChargeCorpID.ToString();
			}
			else
			{
				text += ",WarrantyChargeCorpID=null";
			}
			if (model.SubscribeTime != string.Empty)
			{
				text = text + ",SubscribeTime='" + model.SubscribeTime + "'";
			}
			else
			{
				text += ",SubscribeTime=null";
			}
			if (model.SubscribeConnectTime != string.Empty)
			{
				text = text + ",SubscribeConnectTime='" + model.SubscribeConnectTime + "'";
			}
			else
			{
				text += ",SubscribeConnectTime=null";
			}
			if (model.Time_Complete != string.Empty)
			{
				text = text + ",Time_Complete='" + model.Time_Complete + "'";
			}
			else
			{
				text += ",Time_Complete=null";
			}
			text = text + ",SubscribePrice=" + model.SubscribePrice.ToString();
			text = text + ",PreCharge=" + model.PreCharge.ToString();
			text = text + ",Postage=" + model.Postage.ToString();
			text = text + ",PostNO='" + model.PostNO + "'";
			if (model.ServiceLevelID > 0)
			{
				text = text + ",ServiceLevelID=" + model.ServiceLevelID;
			}
			else
			{
				text += ",ServiceLevelID=null";
			}
			if (model.SndStyleID > 0)
			{
				text = text + ",SndStyleID=" + model.SndStyleID;
			}
			else
			{
				text += ",SndStyleID=null";
			}
			text = text + ",ContractNO='" + model.ContractNO + "'";
			text = text + ",DeviceNO='" + model.DeviceNO + "'";
			text = text + ",Path='" + model.Path + "'";
			list.Add(new string[]
			{
				"ServicesList",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array = strdellist[i];
				list2.Add(new string[]
				{
					array[0].ToString(),
					" ID in(" + array[1].ToString() + ")"
				});
			}
			if (model.ServicesDeviceConfInfos != null)
			{
				foreach (ServicesDeviceConfInfo current in model.ServicesDeviceConfInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "_Name";
						text = text + "'" + current._Name + "'";
						if (current.Parameter != string.Empty)
						{
							text2 += ",Parameter";
							text = text + ",'" + current.Parameter + "'";
						}
						if (current.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						if (current.MaintenancePeriod != string.Empty)
						{
							text2 += ",MaintenancePeriod";
							text = text + ",'" + current.MaintenancePeriod + "'";
						}
						if (current.BuyDate != string.Empty)
						{
							text2 += ",BuyDate";
							text = text + ",'" + current.BuyDate + "'";
						}
						if (current.MaintenanceEnd != string.Empty)
						{
							text2 += ",MaintenanceEnd";
							text = text + ",'" + current.MaintenanceEnd + "'";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "gd_jqpz_add";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "_Name='" + current._Name + "'";
						text = text + ",Parameter='" + current.Parameter + "'";
						text = text + ",SN='" + current.SN + "'";
						text = text + ",MaintenancePeriod='" + current.MaintenancePeriod + "'";
						text = text + ",BuyDate='" + current.BuyDate + "'";
						text = text + ",MaintenanceEnd='" + current.MaintenanceEnd + "'";
						text = text + ",Remark='" + current.Remark + "'";
						array2[0] = "ServicesDeviceConf";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "";
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public void UpdateProcess(int iTbid, string Reason, string TakeSteps, DateTime ArrTime, int iDays, decimal iHours, DateTime visitdate, string strCourse)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ServicesProcess set ");
			stringBuilder.Append("Reason=@Reason,");
			stringBuilder.Append("TakeSteps=@TakeSteps,");
			stringBuilder.Append("ArrivedTime=@ArrivedTime,");
			stringBuilder.Append("iDays=@iDays,");
			stringBuilder.Append("VisitDate=@VisitDate,");
			stringBuilder.Append("iHours=@iHours,");
			stringBuilder.Append("Course=@Course");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@Reason", SqlDbType.VarChar, 100),
				new SqlParameter("@TakeSteps", SqlDbType.VarChar, 2000),
				new SqlParameter("@ArrivedTime", SqlDbType.DateTime, 8),
				new SqlParameter("@iDays", SqlDbType.Int, 4),
				new SqlParameter("@iHours", SqlDbType.Decimal, 9),
				new SqlParameter("@VisitDate", SqlDbType.DateTime),
				new SqlParameter("@Course", SqlDbType.VarChar, 500)
			};
			array[0].Value = iTbid;
			array[1].Value = Reason;
			array[2].Value = TakeSteps;
			array[3].Value = ArrTime;
			array[4].Value = iDays;
			array[5].Value = iHours;
			array[6].Value = (visitdate.Equals(DateTime.MinValue) ? SqlDateTime.Null : visitdate);
			array[7].Value = strCourse;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int UpdateProcessSteps(int iTbid, string StepIDs)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (StepIDs.Equals(""))
			{
				stringBuilder.Append("delete from ServicesTakeSteps where SPID=@iTbid");
			}
			else
			{
				stringBuilder.Append(string.Format("delete from ServicesTakeSteps where SPID=@iTbid and StepID not in({0});", StepIDs));
				stringBuilder.Append(string.Format("insert into ServicesTakeSteps(SPID,StepID)select @iTbid,F1 from dbo.f_splitstr('{0}',',') where F1 not in(select StepID from ServicesTakeSteps where SPID=@iTbid)", StepIDs));
			}
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int)
			};
			array[0].Value = iTbid;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int UpdateDo(ServicesInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",UsePerson='" + model.UsePerson + "'";
			text = text + ",UsePersonTel='" + model.UsePersonTel + "'";
			text = text + ",UsePersonDept='" + model.UsePersonDept + "'";
			if (model.WarrantyID > 0)
			{
				text = text + ",WarrantyID=" + model.WarrantyID.ToString();
			}
			else
			{
				text += ",WarrantyID=null";
			}
			text = text + ",ProductSN1='" + model.ProductSN1 + "'";
			if (model.ProductBrandID > 0)
			{
				text = text + ",ProductBrandID=" + model.ProductBrandID.ToString();
			}
			else
			{
				text += ",ProductBrandID=null";
			}
			if (model.ProductClassID > 0)
			{
				text = text + ",ProductClassID=" + model.ProductClassID.ToString();
			}
			else
			{
				text += ",ProductClassID=null";
			}
			if (model.ProductModelID > 0)
			{
				text = text + ",ProductModelID=" + model.ProductModelID.ToString();
			}
			else
			{
				text += ",ProductModelID=null";
			}
			text = text + ",ProductSN2='" + model.ProductSN2 + "'";
			text = text + ",BuyInvoice='" + model.BuyInvoice + "'";
			text = text + ",Accessory='" + model.Accessory + "'";
			text = text + ",SaveID='" + model.SaveID + "'";
			if (model.SubscribeTime != string.Empty)
			{
				text = text + ",SubscribeTime='" + model.SubscribeTime + "'";
			}
			else
			{
				text += ",SubscribeTime=null";
			}
			if (model.SubscribeConnectTime != string.Empty)
			{
				text = text + ",SubscribeConnectTime='" + model.SubscribeConnectTime + "'";
			}
			else
			{
				text += ",SubscribeConnectTime=null";
			}
			text = text + ",RepairCost=" + model.RepairCost.ToString();
			text = text + ",ExtraCost=" + model.ExtraCost.ToString();
			text = text + ",Fee_Materail=" + model.Fee_Materail.ToString();
			text = text + ",Fee_Labor=" + model.Fee_Labor.ToString();
			text = text + ",Fee_Add=" + model.Fee_Add.ToString();
			text = text + ",Remark='" + model.Remark + "'";
			list.Add(new string[]
			{
				"ServicesList",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array = strdellist[i];
				list2.Add(new string[]
				{
					array[0].ToString(),
					" ID in(" + array[1].ToString() + ")"
				});
			}
			if (model.ServicesDeviceConfInfos != null)
			{
				foreach (ServicesDeviceConfInfo current in model.ServicesDeviceConfInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "_Name";
						text = text + "'" + current._Name + "'";
						if (current.Parameter != string.Empty)
						{
							text2 += ",Parameter";
							text = text + ",'" + current.Parameter + "'";
						}
						if (current.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						if (current.MaintenancePeriod != string.Empty)
						{
							text2 += ",MaintenancePeriod";
							text = text + ",'" + current.MaintenancePeriod + "'";
						}
						if (current.BuyDate != string.Empty)
						{
							text2 += ",BuyDate";
							text = text + ",'" + current.BuyDate + "'";
						}
						if (current.MaintenanceEnd != string.Empty)
						{
							text2 += ",MaintenanceEnd";
							text = text + ",'" + current.MaintenanceEnd + "'";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "gd_jqpz_add";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "_Name='" + current._Name + "'";
						text = text + ",Parameter='" + current.Parameter + "'";
						text = text + ",SN='" + current.SN + "'";
						text = text + ",MaintenancePeriod='" + current.MaintenancePeriod + "'";
						text = text + ",BuyDate='" + current.BuyDate + "'";
						text = text + ",MaintenanceEnd='" + current.MaintenanceEnd + "'";
						text = text + ",Remark='" + current.Remark + "'";
						array2[0] = "ServicesDeviceConf";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "";
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			if (model.ServicesMaterialInfos != null)
			{
				foreach (ServicesMaterialInfo current2 in model.ServicesMaterialInfos)
				{
					string[] array2 = new string[9];
					if (current2.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "GoodsID";
						text += current2.GoodsID.ToString();
						if (current2.UnitID > 0)
						{
							text2 += ",UnitID";
							text = text + "," + current2.UnitID.ToString();
						}
						if (current2.Qty > 0m)
						{
							text2 += ",Qty";
							text = text + "," + current2.Qty.ToString();
						}
						if (current2.Price > 0m)
						{
							text2 += ",Price";
							text = text + "," + current2.Price.ToString();
						}
						if (current2.ChargeStyle != string.Empty)
						{
							text2 += ",ChargeStyle";
							text = text + ",'" + current2.ChargeStyle + "'";
						}
						if (current2.MaintenancePeriod != string.Empty)
						{
							text2 += ",MaintenancePeriod";
							text = text + ",'" + current2.MaintenancePeriod + "'";
						}
						if (current2.PeriodEndDate != string.Empty)
						{
							text2 += ",PeriodEndDate";
							text = text + ",'" + current2.PeriodEndDate + "'";
						}
						if (current2.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current2.Remark + "'";
						}
						if (current2.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current2.SN + "'";
						}
						if (current2.TaxRate > 0m)
						{
							text2 += ",TaxRate";
							text = text + "," + current2.TaxRate;
						}
						if (current2.OutSourcing)
						{
							text2 += ",OutSourcing";
							text += ",1";
							if (current2.CostPrice > 0m)
							{
								text2 += ",CostPrice";
								text = text + "," + current2.CostPrice.ToString();
							}
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "gd_pj_add";
						array2[3] = model.ID.ToString();
						array2[4] = current2.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "GoodsID=" + current2.GoodsID.ToString();
						text = text + ",UnitID=" + current2.UnitID.ToString();
						text = text + ",Qty=" + current2.Qty.ToString();
						text = text + ",Price=" + current2.Price.ToString();
						text = text + ",ChargeStyle='" + current2.ChargeStyle + "'";
						text = text + ",MaintenancePeriod='" + current2.MaintenancePeriod + "'";
						text = text + ",PeriodEndDate='" + current2.PeriodEndDate + "'";
						text = text + ",Remark='" + current2.Remark + "'";
						text = text + ",SN='" + current2.SN + "'";
						text = text + ",TaxRate=" + current2.TaxRate;
						if (current2.OutSourcing)
						{
							text += ",OutSourcing=1";
							text = text + ",CostPrice=" + current2.CostPrice.ToString();
						}
						else
						{
							text += ",OutSourcing=0";
						}
						array2[0] = "ServicesMaterial";
						array2[1] = text;
						array2[2] = " [ID]=" + current2.ID.ToString();
						array2[3] = "";
						array2[4] = current2.ID.ToString();
						list.Add(array2);
					}
				}
			}
			if (model.ServicesItemInfos != null)
			{
				foreach (ServicesItemInfo current3 in model.ServicesItemInfos)
				{
					string[] array2 = new string[9];
					if (current3.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "ItemID";
						text += current3.ItemID.ToString();
						if (current3.Price > 0m)
						{
							text2 += ",Price";
							text = text + "," + current3.Price.ToString();
						}
						if (current3.dPoint > 0m)
						{
							text2 += ",dPoint";
							text = text + "," + current3.dPoint.ToString();
						}
						if (current3.TecDeduct > 0m)
						{
							text2 += ",TecDeduct";
							text = text + "," + current3.TecDeduct.ToString();
						}
						if (current3.ChargeStyle != string.Empty)
						{
							text2 += ",ChargeStyle";
							text = text + ",'" + current3.ChargeStyle + "'";
						}
						if (current3.Tec != string.Empty)
						{
							text2 += ",Tec";
							text = text + ",'" + current3.Tec + "'";
						}
						if (current3.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current3.Remark + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "gd_xm_add";
						array2[3] = model.ID.ToString();
						array2[4] = current3.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "ItemID=" + current3.ItemID.ToString();
						text = text + ",Price=" + current3.Price.ToString();
						text = text + ",dPoint=" + current3.dPoint.ToString();
						text = text + ",TecDeduct=" + current3.TecDeduct.ToString();
						text = text + ",Tec='" + current3.Tec + "'";
						text = text + ",ChargeStyle='" + current3.ChargeStyle + "'";
						text = text + ",Remark='" + current3.Remark + "'";
						array2[0] = "ServicesItem";
						array2[1] = text;
						array2[2] = " [ID]=" + current3.ID.ToString();
						array2[3] = "";
						array2[4] = current3.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public int UpdateAddM(ServicesInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = "[ID]=" + model.ID.ToString();
			list.Add(new string[]
			{
				"ServicesList",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array = strdellist[i];
				list2.Add(new string[]
				{
					array[0].ToString(),
					" ID in(" + array[1].ToString() + ")"
				});
			}
			if (model.ServicesMaterialInfos != null)
			{
				foreach (ServicesMaterialInfo current in model.ServicesMaterialInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "GoodsID";
						text += current.GoodsID.ToString();
						if (current.UnitID > 0)
						{
							text2 += ",UnitID";
							text = text + "," + current.UnitID.ToString();
						}
						if (current.Qty > 0m)
						{
							text2 += ",Qty";
							text = text + "," + current.Qty.ToString();
						}
						if (current.Price > 0m)
						{
							text2 += ",Price";
							text = text + "," + current.Price.ToString();
						}
						if (current.ChargeStyle != string.Empty)
						{
							text2 += ",ChargeStyle";
							text = text + ",'" + current.ChargeStyle + "'";
						}
						if (current.MaintenancePeriod != string.Empty)
						{
							text2 += ",MaintenancePeriod";
							text = text + ",'" + current.MaintenancePeriod + "'";
						}
						if (current.PeriodEndDate != string.Empty)
						{
							text2 += ",PeriodEndDate";
							text = text + ",'" + current.PeriodEndDate + "'";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						if (current.TaxRate > 0m)
						{
							text2 += ",TaxRate";
							text = text + "," + current.TaxRate;
						}
						if (current.OutSourcing)
						{
							text2 += ",OutSourcing";
							text += ",1";
							if (current.CostPrice > 0m)
							{
								text2 += ",CostPrice";
								text = text + "," + current.CostPrice.ToString();
							}
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "gd_pj_add";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "GoodsID=" + current.GoodsID.ToString();
						text = text + ",UnitID=" + current.UnitID.ToString();
						text = text + ",Qty=" + current.Qty.ToString();
						text = text + ",Price=" + current.Price.ToString();
						text = text + ",ChargeStyle='" + current.ChargeStyle + "'";
						text = text + ",MaintenancePeriod='" + current.MaintenancePeriod + "'";
						text = text + ",PeriodEndDate='" + current.PeriodEndDate + "'";
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",SN='" + current.SN + "'";
						text = text + ",TaxRate=" + current.TaxRate;
						if (current.OutSourcing)
						{
							text += ",OutSourcing=1";
							text = text + ",CostPrice=" + current.CostPrice.ToString();
						}
						else
						{
							text += ",OutSourcing=0";
						}
						array2[0] = "ServicesMaterial";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "";
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public int UpdateAddO(ServicesInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = "[ID]=" + model.ID.ToString();
			list.Add(new string[]
			{
				"ServicesList",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array = strdellist[i];
				list2.Add(new string[]
				{
					array[0].ToString(),
					" ID in(" + array[1].ToString() + ")"
				});
			}
			if (model.ServiceOfferInfos != null)
			{
				foreach (ServiceOfferInfo current in model.ServiceOfferInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "ItemID";
						text += current.ItemID.ToString();
						if (current.dAmount > 0m)
						{
							text2 += ",dAmount";
							text = text + "," + current.dAmount.ToString();
						}
						if (current.OperatorID > 0)
						{
							text2 += ",OperatorID";
							text = text + "," + current.OperatorID.ToString();
						}
						if (current.SellerID > 0)
						{
							text2 += ",SellerID";
							text = text + "," + current.SellerID.ToString();
						}
						if (current.bCusConf)
						{
							text2 += ",bCusConf";
							text += ",1";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current._Date != string.Empty)
						{
							text2 += ",_Date";
							text = text + ",'" + current._Date + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "gd_bj_add";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "ItemID=" + current.ItemID.ToString();
						text = text + ",dAmount=" + current.dAmount.ToString();
						text = text + ",SellerID=" + current.SellerID.ToString();
						if (current.bCusConf)
						{
							text += ",bCusConf=1";
						}
						else
						{
							text += ",bCusConf=0";
						}
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",_Date='" + current._Date + "'";
						array2[0] = "ServiceOffer";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "";
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public int UpdateAddI(ServicesInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = "[ID]=" + model.ID.ToString();
			list.Add(new string[]
			{
				"ServicesList",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array = strdellist[i];
				list2.Add(new string[]
				{
					array[0].ToString(),
					" ID in(" + array[1].ToString() + ")"
				});
			}
			if (model.ServicesItemInfos != null)
			{
				foreach (ServicesItemInfo current in model.ServicesItemInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "ItemID";
						text += current.ItemID.ToString();
						if (current.Price > 0m)
						{
							text2 += ",Price";
							text = text + "," + current.Price.ToString();
						}
						if (current.dPoint > 0m)
						{
							text2 += ",dPoint";
							text = text + "," + current.dPoint.ToString();
						}
						if (current.TecDeduct > 0m)
						{
							text2 += ",TecDeduct";
							text = text + "," + current.TecDeduct.ToString();
						}
						if (current.ChargeStyle != string.Empty)
						{
							text2 += ",ChargeStyle";
							text = text + ",'" + current.ChargeStyle + "'";
						}
						if (current.Tec != string.Empty)
						{
							text2 += ",Tec";
							text = text + ",'" + current.Tec + "'";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current.bComplete)
						{
							text2 += ",bComplete";
							text += ",1";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "gd_xm_add";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "ItemID=" + current.ItemID.ToString();
						text = text + ",Price=" + current.Price.ToString();
						text = text + ",dPoint=" + current.dPoint.ToString();
						text = text + ",TecDeduct=" + current.TecDeduct.ToString();
						text = text + ",Tec='" + current.Tec + "'";
						text = text + ",ChargeStyle='" + current.ChargeStyle + "'";
						text = text + ",Remark='" + current.Remark + "'";
						if (current.bComplete)
						{
							text += ",bComplete=1";
						}
						else
						{
							text += ",bComplete=0";
						}
						array2[0] = "ServicesItem";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "";
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public int UpdateAddD(ServicesInfo model, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = "[ID]=" + model.ID.ToString();
			list.Add(new string[]
			{
				"ServicesList",
				text,
				" [ID]=" + model.ID.ToString(),
				"",
				" [ID]=" + model.ID.ToString()
			});
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array = strdellist[i];
				list2.Add(new string[]
				{
					array[0].ToString(),
					" ID in(" + array[1].ToString() + ")"
				});
			}
			if (model.ServicesDeviceConfInfos != null)
			{
				foreach (ServicesDeviceConfInfo current in model.ServicesDeviceConfInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "_Name";
						text = text + "'" + current._Name + "'";
						if (current.Parameter != string.Empty)
						{
							text2 += ",Parameter";
							text = text + ",'" + current.Parameter + "'";
						}
						if (current.SN != string.Empty)
						{
							text2 += ",SN";
							text = text + ",'" + current.SN + "'";
						}
						if (current.MaintenancePeriod != string.Empty)
						{
							text2 += ",MaintenancePeriod";
							text = text + ",'" + current.MaintenancePeriod + "'";
						}
						if (current.BuyDate != string.Empty)
						{
							text2 += ",BuyDate";
							text = text + ",'" + current.BuyDate + "'";
						}
						if (current.MaintenanceEnd != string.Empty)
						{
							text2 += ",MaintenanceEnd";
							text = text + ",'" + current.MaintenanceEnd + "'";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						array2[0] = text2;
						array2[1] = text;
						array2[2] = "gd_jqpz_add";
						array2[3] = model.ID.ToString();
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "_Name='" + current._Name + "'";
						text = text + ",Parameter='" + current.Parameter + "'";
						text = text + ",SN='" + current.SN + "'";
						text = text + ",MaintenancePeriod='" + current.MaintenancePeriod + "'";
						text = text + ",BuyDate='" + current.BuyDate + "'";
						text = text + ",MaintenanceEnd='" + current.MaintenanceEnd + "'";
						text = text + ",Remark='" + current.Remark + "'";
						array2[0] = "ServicesDeviceConf";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "";
						array2[4] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, out strMsg);
		}

		public int UpdateCusBln(List<string[]> StrParameters, out string strMsg)
		{
			return DbHelperSQL.UpdateMany(StrParameters, out strMsg);
		}

		public string TCount(string strWhere)
		{
			return DALCommon.TCount("ServicesList", strWhere);
		}

		public string GetTech(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select DisposalOper from ServicesList ");
			stringBuilder.Append(" where [ID]=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			string result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = dataSet.Tables[0].Rows[0]["DisposalOper"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		public int GetID(string BillID)
		{
			int result = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select [ID] from ServicesList ");
			stringBuilder.Append(" where BillID=@BillID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.VarChar, 50)
			};
			array[0].Value = BillID;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					result = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
			}
			return result;
		}

		public int GetSupID(int recid)
		{
			int result = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select WarrantyChargeCorpID from ServicesList ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.VarChar, 50)
			};
			array[0].Value = recid;
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0][0].ToString() != "")
				{
					result = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
				}
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
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (BillID like '%",
					strcon,
					"%' or ServicesType like '%",
					strcon,
					"%' or TakeDept like '%",
					strcon,
					"%' or DisposalDept like '%",
					strcon,
					"%' or TakeStyle like '%",
					strcon,
					"%' or _PRI like '%",
					strcon,
					"%' or Operator like '%",
					strcon,
					"%' or  CustomerName like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or UsePerson like '%",
					strcon,
					"%' or Tel like '%",
					strcon,
					"%' or UsePersonTel like '%",
					strcon,
					"%' or Adr like '%",
					strcon,
					"%'  or ProductModel like '%",
					strcon,
					"%' or ProductBrand like '%",
					strcon,
					"%' or ProductClass like '%",
					strcon,
					"%' or ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%' or  DisposalOper like '%",
					strcon,
					"%' or Fault like '%",
					strcon,
					"%' or Warranty like '%",
					strcon,
					"%' or Remark like '%",
					strcon,
					"%'  or curStatus like '%",
					strcon,
					"%' or SaveID like '%",
					strcon,
					"%' or DeviceNO like '%",
					strcon,
					"%' or Time_TakeOver like '%",
					strcon,
					"%' or QtyType like '%",
					strcon,
					"%' or ContractNO like '%",
					strcon,
					" %')"
				});
				break;
			}
			case 1:
				text = text + " and BillID like '%" + strcon + "%' ";
				break;
			case 2:
				text = text + " and ServicesType like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and TakeDept like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and DisposalDept like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and TakeStyle like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and _PRI like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and Operator like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and CustomerName like '%" + strcon + "%' ";
				break;
			case 9:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (LinkMan like '%",
					strcon,
					"%' or UsePerson like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 10:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Tel like '%",
					strcon,
					"%' or UsePersonTel like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 11:
				text = text + " and Adr like '%" + strcon + "%' ";
				break;
			case 12:
				text = text + " and ProductModel like '%" + strcon + "%' ";
				break;
			case 13:
				text = text + " and ProductBrand like '%" + strcon + "%' ";
				break;
			case 14:
				text = text + " and ProductClass like '%" + strcon + "%' ";
				break;
			case 15:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 16:
				text = text + " and DisposalOper like '%" + strcon + "%' ";
				break;
			case 17:
				text = text + " and Fault like '%" + strcon + "%' ";
				break;
			case 18:
				text = text + " and Warranty like '%" + strcon + "%' ";
				break;
			case 19:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			case 20:
				text = text + " and RepairCorp like '%" + strcon + "%' ";
				break;
			case 21:
				text = text + " and curStatus like '%" + strcon + "%' ";
				break;
			case 22:
				text = text + " and SaveID like '%" + strcon + "%' ";
				break;
			case 23:
				text = text + " and ContractNO like '%" + strcon + "%'";
				break;
			case 24:
				text = text + " and [Time] = " + strcon;
				break;
			}
			return text;
		}

		public string GetMakeTime()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select top 1 Time_Make from ServicesList ");
			stringBuilder.Append(" order by ID Asc ");
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString());
			string result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = dataSet.Tables[0].Rows[0]["Time_Make"].ToString();
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public int NetChk(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_bx_ad", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int NetCancel(int iTbid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = Reason;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_bx_qx", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int Cancel(int iTbid, int iDeptid, int iOperator, int iPerson, string Reason, string TroubleReason, string TakeSteps, string strarrtime, int iDays, decimal iHours, DateTime visitdate, string StepIDs, string strCourse, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@iPerson", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 100),
				new SqlParameter("@TroubleReason", SqlDbType.NVarChar, 100),
				new SqlParameter("@TakeSteps", SqlDbType.NVarChar, 2000),
				new SqlParameter("@ArrTime", SqlDbType.NVarChar, 50),
				new SqlParameter("@iDays", SqlDbType.Int),
				new SqlParameter("@iHours", SqlDbType.Decimal),
				new SqlParameter("@visitdate", SqlDbType.DateTime),
				new SqlParameter("@StepIDs", SqlDbType.VarChar, 500),
				new SqlParameter("@Course", SqlDbType.VarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iDeptid;
			array[2].Value = iOperator;
			array[3].Value = iPerson;
			array[4].Value = Reason;
			array[5].Value = TroubleReason;
			array[6].Value = TakeSteps;
			array[7].Value = strarrtime;
			array[8].Value = iDays;
			array[9].Value = iHours;
			array[10].Value = (visitdate.Equals(DateTime.MinValue) ? SqlDateTime.Null : visitdate);
			array[11].Value = StepIDs;
			array[12].Value = strCourse;
			array[13].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_gd_qx", array);
			strMsg = Convert.ToString(array[13].Value);
			return result;
		}

		public int DisAllot(int iFlag, int iTbid, int iDeptid, int iOperator, int iPerson, int Paramid, string Tec, string TroubleReason, string TakeSteps, string strarrtime, int iDays, decimal iHours, string DoDept, DateTime visitdate, string StepIDs, string strCourse, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@iPerson", SqlDbType.Int),
				new SqlParameter("@Paramid", SqlDbType.Int),
				new SqlParameter("@Tec", SqlDbType.NVarChar, 100),
				new SqlParameter("@TroubleReason", SqlDbType.NVarChar, 100),
				new SqlParameter("@TakeSteps", SqlDbType.NVarChar, 2000),
				new SqlParameter("@ArrTime", SqlDbType.NVarChar, 50),
				new SqlParameter("@iDays", SqlDbType.Int),
				new SqlParameter("@iHours", SqlDbType.Decimal),
				new SqlParameter("@DoDept", SqlDbType.NVarChar, 100),
				new SqlParameter("@visitdate", SqlDbType.DateTime),
				new SqlParameter("@StepIDs", SqlDbType.VarChar, 500),
				new SqlParameter("@Course", SqlDbType.VarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iFlag;
			array[1].Value = iTbid;
			array[2].Value = iDeptid;
			array[3].Value = iOperator;
			array[4].Value = iPerson;
			array[5].Value = Paramid;
			array[6].Value = Tec;
			array[7].Value = TroubleReason;
			array[8].Value = TakeSteps;
			array[9].Value = strarrtime;
			array[10].Value = iDays;
			array[11].Value = iHours;
			array[12].Value = DoDept;
			array[13].Value = (visitdate.Equals(DateTime.MinValue) ? SqlDateTime.Null : visitdate);
			array[14].Value = StepIDs;
			array[15].Value = strCourse;
			array[16].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_gd_dd", array);
			strMsg = Convert.ToString(array[16].Value);
			return result;
		}

		public int RepairSnd(int iDeptid, int iOperatorid, string strBillID, int SndSupplierID, string SndDate, int SndStyleID, string PostNO, decimal Postage, string LinkMan, string Adr, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iOperatorid", SqlDbType.Int),
				new SqlParameter("@strBillID", SqlDbType.NVarChar, 1000),
				new SqlParameter("@SndSupplierID", SqlDbType.Int),
				new SqlParameter("@SndDate", SqlDbType.NVarChar, 50),
				new SqlParameter("@SndStyleID", SqlDbType.Int),
				new SqlParameter("@PostNO", SqlDbType.NVarChar, 50),
				new SqlParameter("@Postage", SqlDbType.Decimal),
				new SqlParameter("@Rcvr", SqlDbType.VarChar, 50),
				new SqlParameter("@Adr", SqlDbType.VarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iDeptid;
			array[1].Value = iOperatorid;
			array[2].Value = strBillID;
			array[3].Value = SndSupplierID;
			array[4].Value = SndDate;
			array[5].Value = SndStyleID;
			array[6].Value = PostNO;
			array[7].Value = Postage;
			array[8].Value = LinkMan;
			array[9].Value = Adr;
			array[10].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_sx_fh", array);
			strMsg = Convert.ToString(array[8].Value);
			return result;
		}

		public int RepairRcvCal(int iDeptid, int iOperatorid, string strBillID, int RepairType, int RepairCorpID, string RcvDate, decimal RMoney, out int FKDid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iOperatorid", SqlDbType.Int),
				new SqlParameter("@strBillID", SqlDbType.NVarChar, 1000),
				new SqlParameter("@RepairType", SqlDbType.Int),
				new SqlParameter("@RepairCorpID", SqlDbType.Int),
				new SqlParameter("@RcvDate", SqlDbType.NVarChar, 50),
				new SqlParameter("@RMoney", SqlDbType.Decimal),
				new SqlParameter("@FKDid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iDeptid;
			array[1].Value = iOperatorid;
			array[2].Value = strBillID;
			array[3].Value = RepairType;
			array[4].Value = RepairCorpID;
			array[5].Value = RcvDate;
			array[6].Value = RMoney;
			array[7].Direction = ParameterDirection.Output;
			array[8].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_sx_shjs", array);
			FKDid = Convert.ToInt32(array[7].Value);
			strMsg = Convert.ToString(array[8].Value);
			return result;
		}

		public void RepairRcvCalMX(int iDeptid, int iOperatorid, int iTbid, int RepairType, int RepairCorpID, string RcvDate, decimal RMoney, int FKDid)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iOperatorid", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@RepairType", SqlDbType.Int),
				new SqlParameter("@RepairCorpID", SqlDbType.Int),
				new SqlParameter("@RcvDate", SqlDbType.NVarChar, 50),
				new SqlParameter("@RMoney", SqlDbType.Decimal),
				new SqlParameter("@FKDid", SqlDbType.Int)
			};
			array[0].Value = iDeptid;
			array[1].Value = iOperatorid;
			array[2].Value = iTbid;
			array[3].Value = RepairType;
			array[4].Value = RepairCorpID;
			array[5].Value = RcvDate;
			array[6].Value = RMoney;
			array[7].Value = FKDid;
			DbHelperSQL.RunProcedure("fw_sx_shjsmx", array);
		}

		public int SndBackAllot(int iTbid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = Reason;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_sx_fhbh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int RcvBackSnd(int iTbid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = Reason;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_sx_shbh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int DoBillOK(int iTbid, int iOperator, int iPerson, string OverTime, string TroubleReason, string TakeSteps, string strarrtime, int iDays, decimal iHours, DateTime visitdate, string StepIDs, bool bBranchChk, string strCourse, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@iPerson", SqlDbType.Int),
				new SqlParameter("@strOverTime", SqlDbType.NVarChar, 50),
				new SqlParameter("@TroubleReason", SqlDbType.NVarChar, 100),
				new SqlParameter("@TakeSteps", SqlDbType.NVarChar, 2000),
				new SqlParameter("@ArrTime", SqlDbType.NVarChar, 50),
				new SqlParameter("@iDays", SqlDbType.Int),
				new SqlParameter("@iHours", SqlDbType.Decimal),
				new SqlParameter("@visitdate", SqlDbType.DateTime),
				new SqlParameter("@StepIDs", SqlDbType.VarChar, 500),
				new SqlParameter("@bBranchChk", SqlDbType.Bit, 1),
				new SqlParameter("@Course", SqlDbType.VarChar, 500),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = iPerson;
			array[3].Value = OverTime;
			array[4].Value = TroubleReason;
			array[5].Value = TakeSteps;
			array[6].Value = strarrtime;
			array[7].Value = iDays;
			array[8].Value = iHours;
			array[9].Value = (visitdate.Equals(DateTime.MinValue) ? SqlDateTime.Null : visitdate);
			array[10].Value = StepIDs;
			array[11].Value = bBranchChk;
			array[12].Value = strCourse;
			array[13].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_gd_wg", array);
			strMsg = Convert.ToString(array[13].Value);
			return result;
		}

		public int ConfBack(int iTbid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = Reason;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_conf_bh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int BlnBack(int iTbid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = Reason;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_bln_bh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int OverBack(int iTbid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = Reason;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_ad_bh", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public int CusBln(int iDeptid, string strBillID, string strBillIDs, int iOperator, int iSKRid, int iCusType, int iCustomerid, DateTime ChargeDate, decimal Amount, int iChargeModelid, int iAccountid, int InvoiceClassID, string InvoiceNO, string GoodsTo, decimal dInCash, decimal dPreMoney, decimal dRealMoney, string strRemark, string InvoiceDate, decimal InvoiceAmount, string VoucherNO, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@strBillID", SqlDbType.NVarChar, 500),
				new SqlParameter("@strBillIDs", SqlDbType.NVarChar, 500),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@iSKRid", SqlDbType.Int),
				new SqlParameter("@iCusType", SqlDbType.Int),
				new SqlParameter("@iCustomerid", SqlDbType.Int),
				new SqlParameter("@ChargeDate", SqlDbType.DateTime),
				new SqlParameter("@Amount", SqlDbType.Decimal),
				new SqlParameter("@iChargeModelid", SqlDbType.Int),
				new SqlParameter("@iAccountid", SqlDbType.Int),
				new SqlParameter("@InvoiceClassID", SqlDbType.Int),
				new SqlParameter("@InvoiceNO", SqlDbType.NVarChar, 50),
				new SqlParameter("@GoodsTo", SqlDbType.NVarChar, 50),
				new SqlParameter("@dInCash", SqlDbType.Decimal),
				new SqlParameter("@dPreMoney", SqlDbType.Decimal),
				new SqlParameter("@dRealMoney", SqlDbType.Decimal),
				new SqlParameter("@strRemark", SqlDbType.NVarChar, 200),
				new SqlParameter("@InvoiceDate", SqlDbType.NVarChar, 50),
				new SqlParameter("@InvoiceAmount", SqlDbType.Decimal),
				new SqlParameter("@VoucherNO", SqlDbType.NVarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iDeptid;
			array[1].Value = strBillID;
			array[2].Value = strBillIDs;
			array[3].Value = iOperator;
			array[4].Value = iSKRid;
			array[5].Value = iCusType;
			array[6].Value = iCustomerid;
			array[7].Value = ChargeDate;
			array[8].Value = Amount;
			array[9].Value = iChargeModelid;
			array[10].Value = iAccountid;
			array[11].Value = InvoiceClassID;
			array[12].Value = InvoiceNO;
			array[13].Value = GoodsTo;
			array[14].Value = dInCash;
			array[15].Value = dPreMoney;
			array[16].Value = dRealMoney;
			array[17].Value = strRemark;
			array[18].Value = InvoiceDate;
			array[19].Value = InvoiceAmount;
			array[20].Value = VoucherNO;
			array[21].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_wg_js", array);
			strMsg = Convert.ToString(array[21].Value);
			return result;
		}

		public int CancelCall(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_hf_qx", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int OverCall(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_hf_wc", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int ChkClose(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_ad_gb", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int ChkCloseSave(int iTbid, int ChargeCorpID, decimal ChargeValue, decimal dPoint, string Remark, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@ChargeCorpID", SqlDbType.Int),
				new SqlParameter("@ChargeValue", SqlDbType.Decimal),
				new SqlParameter("@dPoint", SqlDbType.Decimal),
				new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = ChargeCorpID;
			array[2].Value = ChargeValue;
			array[3].Value = dPoint;
			array[4].Value = Remark;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_ad_edit", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}

		public int ChkDel(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_del", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int ChkConf(int iTbid, int iOperator, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_conf", array);
			strMsg = Convert.ToString(array[2].Value);
			return result;
		}

		public int SchBack(int iDeptid, int iTbid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iDeptid;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Value = Reason;
			array[4].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_sch_bh", array);
			strMsg = Convert.ToString(array[4].Value);
			return result;
		}

		public int BackSteps(int iTbid, int iOperator, int BeginStep, int ToStep, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@BeginStep", SqlDbType.Int),
				new SqlParameter("@ToStep", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iOperator;
			array[2].Value = BeginStep;
			array[3].Value = ToStep;
			array[4].Value = Reason;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_gd_stepbh", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}

		public int SerConf(int iFlag, int iTbid, int iOperator, string strTel, string strDate, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@strTel", SqlDbType.NVarChar, 50),
				new SqlParameter("@strDate", SqlDbType.NVarChar, 50),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iFlag;
			array[1].Value = iTbid;
			array[2].Value = iOperator;
			array[3].Value = strTel;
			array[4].Value = strDate;
			array[5].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_gd_conf", array);
			strMsg = Convert.ToString(array[5].Value);
			return result;
		}

		public int FWCancel(int iTbid, int iDeptid, int iOperator, string Reason, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@Reason", SqlDbType.NVarChar, 100),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iTbid;
			array[1].Value = iDeptid;
			array[2].Value = iOperator;
			array[3].Value = Reason;
			array[4].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("fw_qx", array);
			strMsg = Convert.ToString(array[4].Value);
			return result;
		}

		public DataSet SerMaterail(string strWhere, string strOrder, bool hascontact)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select g._Name,g.GoodsNO,g.Spec,pj.CostCount,pj.GoodsID,pj.CostPrice from ");
			stringBuilder.Append(" (select sum(a.Qty) as CostCount,a.GoodsID,sum(a.CostPrice) as CostPrice  from ");
			stringBuilder.Append(" BroughtBackDetail a left join ");
			stringBuilder.Append(" BroughtBack b on a.BillID=b.ID ");
			if (hascontact)
			{
				stringBuilder.Append(" left join ServicesList sl on a.OperationID=sl.BillID ");
			}
			stringBuilder.Append(" where b.Status=2 and a.OperationID is not NULL and a.OperationID<>'' ");
			if (!strWhere.Equals(""))
			{
				stringBuilder.Append(string.Format(" and {0} ", strWhere));
			}
			if (hascontact)
			{
				stringBuilder.Append(" and sl.ContractNO is not null and sl.ContractNO <>'' ");
			}
			stringBuilder.Append(" group by a.GoodsID)pj left join Goods g on pj.GoodsID=g.ID ");
			if (!strOrder.Equals(""))
			{
				stringBuilder.Append(" order by " + strOrder);
			}
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public DataSet SerMaterialDe(int GoodsID, DateTime dates, DateTime datee, int deptid, bool hascontract)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from fw_services where BillID in(select OperationID from BroughtBackDetail a left join ");
			stringBuilder.Append("BroughtBack b on a.BillID=b.ID where b.Status=2 and a.OperationID is not NULL and a.OperationID<>'' and a.GoodsID=@gid ");
			if (deptid > 0)
			{
				stringBuilder.Append(" and b.DeptID=@deptid ");
			}
			if (!dates.Equals(DateTime.MinValue))
			{
				stringBuilder.Append(" and b.ChkDate>=@dates ");
			}
			if (!datee.Equals(DateTime.MinValue))
			{
				stringBuilder.Append(" and b.ChkDate<=@datee ");
			}
			stringBuilder.Append(")");
			if (hascontract)
			{
				stringBuilder.Append(" and ContractNO is NOT NULL and ContractNO<>'' ");
			}
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@gid", SqlDbType.Int, 4),
				new SqlParameter("@dates", SqlDbType.DateTime),
				new SqlParameter("@datee", SqlDbType.DateTime),
				new SqlParameter("@deptid", SqlDbType.Int, 4)
			};
			array[0].Value = GoodsID;
			array[1].Value = (dates.Equals(DateTime.MinValue) ? SqlDateTime.Null : dates);
			array[2].Value = (datee.Equals(DateTime.MinValue) ? SqlDateTime.Null : datee);
			array[3].Value = deptid;
			return DbHelperSQL.Query(stringBuilder.ToString(), array);
		}

		public DataSet GetFullServices(string strCondition, string strSort, int PageSize, int PageIndex, int iPaging, out int allcount)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strCondition", SqlDbType.NVarChar, 4000),
				new SqlParameter("@fldSort", SqlDbType.NVarChar, 500),
				new SqlParameter("@PageSize", SqlDbType.Int, 4),
				new SqlParameter("@page", SqlDbType.Int, 4),
				new SqlParameter("@iPaging", SqlDbType.Int, 4),
				new SqlParameter("@P1", SqlDbType.Int, 4)
			};
			array[0].Value = strCondition;
			array[1].Value = strSort;
			array[2].Value = PageSize;
			array[3].Value = PageIndex;
			array[4].Value = iPaging;
			array[5].Direction = ParameterDirection.Output;
			DataSet result = DbHelperSQL.RunProcedureDs("fw_getfullinfo", array);
			int.TryParse(array[5].Value.ToString(), out allcount);
			return result;
		}

		public DataSet StSerCosts(int iFlag, string strCondition, string strDateS, string strDateE)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@strCondition", SqlDbType.VarChar, 400),
				new SqlParameter("@StartDate", SqlDbType.VarChar, 20),
				new SqlParameter("@EndDate", SqlDbType.VarChar, 20)
			};
			array[0].Value = iFlag;
			array[1].Value = strCondition;
			array[2].Value = strDateS;
			array[3].Value = strDateE;
			return DbHelperSQL.RunProcedureDs("fw_Costs", array);
		}

		public int UpdateFault(int iTbid, string Faults)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Faults.Equals(""))
			{
				stringBuilder.Append("delete from ServicesFault where BillID=@iTbid");
			}
			else
			{
				stringBuilder.Append(string.Format("delete from Servicesfault where BillID=@iTbid and FaultID not in({0});", Faults));
				stringBuilder.Append(string.Format("insert into ServicesFault(BillID,FaultID)select @iTbid,F1 from dbo.f_splitstr('{0}',',') where F1 not in(select FaultID from Servicesfault where BillID=@iTbid)", Faults));
			}
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int)
			};
			array[0].Value = iTbid;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int BranchChk(int OperatorID, int iTbid, string Remark, string ids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("execute aa_insertlog 2,@iPerson,@iTbid,'网点确认" + string.Format("({0})", Remark) + "',0;");
			if (ids.Length > 0)
			{
				stringBuilder.Append(string.Format("update SerAttach set BillID=(select top 1 ID from ServicesLog where BillID=@iTbid order by ID desc) where ID in({0});", ids));
			}
			stringBuilder.Append("if (select top 1 isnull(bBln,0) from SysParm)=1 and (select ChargeValue from ServicesList where ID=@iTbid)>0 update ServicesList set curStatus='待审核' where ID=@iTbid ");
			stringBuilder.Append("else update ServicesList set curStatus='待结算' where ID=@iTbid");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iPerson", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int)
			};
			array[0].Value = OperatorID;
			array[1].Value = iTbid;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public string BranchReject(int OperatorID, int iTbid, string Remark, string ids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("exec fw_gd_stepbh @iTbid,@iPerson,8,1,'" + Remark + "',@strRev output ;");
			if (ids.Length > 0)
			{
				stringBuilder.Append(string.Format("update SerAttach set BillID=(select top 1 ID from ServicesLog where BillID=@iTbid order by ID desc) where ID in({0});", ids));
			}
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iPerson", SqlDbType.Int),
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@strRev", SqlDbType.VarChar, 500)
			};
			array[0].Value = OperatorID;
			array[1].Value = iTbid;
			array[2].Direction = ParameterDirection.Output;
			int num = DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
			return array[2].Value.ToString();
		}

		public int UpdateAttachs(int iTbid, int iType, string ids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (ids.Length == 0)
			{
				if (iTbid < 0)
				{
					stringBuilder.Append("select top 1 @iTbid=ID from ServicesProcess where BillID=-@iTbid order by ID desc ");
				}
				stringBuilder.Append("delete from SerAttach where BillID=@iTbid and iType=@iType");
			}
			else
			{
				if (iTbid < 0)
				{
					stringBuilder.Append("select top 1 @iTbid=ID from ServicesProcess where BillID=-@iTbid order by ID desc ");
				}
				stringBuilder.Append(string.Format("delete from SerAttach where BillID=@iTbid and iType=@iType and ID not in({0})", ids));
				stringBuilder.Append(string.Format("update SerAttach set BillID=@iTbid where ID in({0})", ids));
			}
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iTbid", SqlDbType.Int),
				new SqlParameter("@iType", SqlDbType.Int)
			};
			array[0].Value = iTbid;
			array[1].Value = iType;
			return DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public DataSet GetTechDayWork(int iDept, string TecName, string strDate)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@stfName", SqlDbType.VarChar, 50),
				new SqlParameter("@Date", SqlDbType.VarChar, 10)
			};
			array[0].Value = iDept;
			array[1].Value = TecName;
			array[2].Value = strDate;
			return DbHelperSQL.RunProcedureDs("tj_serdate", array);
		}

		public bool GetSerStatus(int ID)
		{
			string sQLString = "select DoStyle from ServicesProcess where ID = @ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int)
			};
			array[0].Value = ID;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			return dataTable.Rows.Count > 0 && (dataTable.Rows[0][0].ToString() == "完成关闭" || dataTable.Rows[0][0].ToString() == "取消关闭");
		}

		public void SetIsTake(int recid, bool check)
		{
			string sQLString = "update ServicesList set bTake=@bTake where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int),
				new SqlParameter("@bTake", SqlDbType.Bit)
			};
			array[0].Value = recid;
			array[1].Value = check;
			DbHelperSQL.ExecuteSql(sQLString, array);
		}

		public int GetSerID(int id)
		{
			string sQLString = "select billid from ServicesProcess where id =@id";
			object single = DbHelperSQL.GetSingle(sQLString, new SqlParameter[]
			{
				new SqlParameter("@id", SqlDbType.Int)
				{
					Value = id
				}
			});
			int result;
			if (single == null)
			{
				result = 0;
			}
			else
			{
				result = int.Parse(single.ToString());
			}
			return result;
		}

		public bool isHaveSupplies(int id)
		{
			string sQLString = "select 1 from ServicesMaterial where billid in(select [id] from serviceslist where ID=@ID)";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			return dataTable.Rows.Count > 0;
		}

		public int getCustomerID(string id)
		{
			string sQLString = " select customerid from serviceslist where ID in(" + id + ")";
			DataTable dataTable = DbHelperSQL.Query(sQLString).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0;
			return result;
		}
	}
}
