using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALCustomerList
	{
		public int Add(CustomerListInfo model, bool bsys, out string strMsg, out int iTbid)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty && model._Name != null)
			{
				text += "_Name";
				text2 = text2 + "'" + model._Name + "'";
			}
            if (model.jieshao != string.Empty && model.jieshao != null)
            {
                text += "jieshao";
                text2 = text2 + "'" + model.jieshao + "'";
            }
			if (!bsys)
			{
				if (model.CustomerNO != string.Empty && model.CustomerNO != null)
				{
					text += ",CustomerNO";
					text2 = text2 + ",'" + model.CustomerNO + "'";
				}
			}
			if (model.Zip != string.Empty && model.Zip != null)
			{
				text += ",Zip";
				text2 = text2 + ",'" + model.Zip + "'";
			}
			if (model.Fax != string.Empty && model.Fax != null)
			{
				text += ",Fax";
				text2 = text2 + ",'" + model.Fax + "'";
			}
			if (model.Email != string.Empty && model.Email != null)
			{
				text += ",Email";
				text2 = text2 + ",'" + model.Email + "'";
			}
			if (model.QQ != string.Empty && model.QQ != null)
			{
				text += ",QQ";
				text2 = text2 + ",'" + model.QQ + "'";
			}
			if (model.Account != string.Empty && model.Account != null)
			{
				text += ",Account";
				text2 = text2 + ",'" + model.Account + "'";
			}
			if (model.Area != string.Empty && model.Area != null)
			{
				text += ",Area";
				text2 = text2 + ",'" + model.Area + "'";
			}
			if (model.Coordinates != string.Empty && model.Coordinates != null)
			{
				text += ",Coordinates";
				text2 = text2 + ",'" + model.Coordinates + "'";
			}
			if (model.FromID > 0)
			{
				text += ",FromID";
				text2 = text2 + "," + model.FromID.ToString();
			}
			if (model.SellerID > 0)
			{
				text += ",SellerID";
				text2 = text2 + "," + model.SellerID.ToString();
			}
			if (model.OperatorID > 0)
			{
				text += ",OperatorID";
				text2 = text2 + "," + model.OperatorID.ToString();
			}
			text += ",PositionAmount";
			text2 = text2 + "," + model.PositionAmount.ToString();
			text += ",DeptID";
			text2 = text2 + "," + model.DeptID.ToString();
			text += ",_Date";
			text2 += ",getdate()";
			if (model.pyCode != string.Empty && model.pyCode != null)
			{
				text += ",pyCode";
				text2 = text2 + ",'" + model.pyCode + "'";
			}
			if (model.bStop)
			{
				text += ",bStop";
				text2 += ",1";
			}
			if (model.bCall)
			{
				text += ",bCall";
				text2 += ",1";
			}
			if (model.Remark != string.Empty && model.Remark != null)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.ClassID > 0)
			{
				text += ",ClassID";
				text2 = text2 + "," + model.ClassID.ToString();
			}
			if (model.LinkMan != string.Empty && model.LinkMan != null)
			{
				text += ",LinkMan";
				text2 = text2 + ",'" + model.LinkMan + "'";
			}
			if (model.Tel != string.Empty && model.Tel != null)
			{
				text += ",Tel";
				text2 = text2 + ",'" + model.Tel + "'";
			}
			if (model.Tel2 != string.Empty && model.Tel2 != null)
			{
				text += ",Tel2";
				text2 = text2 + ",'" + model.Tel2 + "'";
			}
			if (model.Adr != string.Empty && model.Adr != null)
			{
				text += ",Adr";
				text2 = text2 + ",'" + model.Adr + "'";
			}
			if (model.MemberID > 0)
			{
				text += ",MemberID";
				text2 = text2 + "," + model.MemberID.ToString();
			}
			if (model.StatusID > 0)
			{
				text += ",StatusID";
				text2 = text2 + "," + model.StatusID.ToString();
			}
			if (model.userdef1 != string.Empty)
			{
				text += ",userdef1";
				text2 = text2 + ",'" + model.userdef1 + "'";
			}
			if (model.userdef2 != string.Empty)
			{
				text += ",userdef2";
				text2 = text2 + ",'" + model.userdef2 + "'";
			}
			if (model.userdef3 != string.Empty)
			{
				text += ",userdef3";
				text2 = text2 + ",'" + model.userdef3 + "'";
			}
			if (model.userdef4 != string.Empty)
			{
				text += ",userdef4";
				text2 = text2 + ",'" + model.userdef4 + "'";
			}
			if (model.userdef5 != string.Empty)
			{
				text += ",userdef5";
				text2 = text2 + ",'" + model.userdef5 + "'";
			}
			if (model.userdef6 != string.Empty)
			{
				text += ",userdef6";
				text2 = text2 + ",'" + model.userdef6 + "'";
			}
			if (model.TrackOperatorID > 0)
			{
				text += ",TrackOperatorID";
				text2 = text2 + "," + model.TrackOperatorID.ToString();
			}
			if (model.bTrack)
			{
				text += ",bTrack";
				text2 += ",1";
			}
			if (model.BranchID > 0)
			{
				text += ",BranchID";
				text2 = text2 + "," + model.BranchID.ToString();
			}
			string[] array = new string[8];
			array[0] = "CustomerList";
			array[1] = text;
			array[2] = text2;
			array[3] = " CustomerNO='" + model.CustomerNO + "' ";
			array[4] = "客户编号";
			array[5] = "ID";
			if (bsys)
			{
				array[6] = "CustomerNO";
				array[7] = "5";
			}
			list.Add(array);
			if (model.CustomerLinkManInfos != null)
			{
				foreach (CustomerLinkManInfo current in model.CustomerLinkManInfos)
				{
					string[] array2 = new string[7];
					text = string.Empty;
					text2 = string.Empty;
					if (current._Name != string.Empty)
					{
						text += "_Name";
						text2 = text2 + "'" + current._Name + "'";
					}
					if (current.LinkManDept != string.Empty)
					{
						text += ",LinkManDept";
						text2 = text2 + ",'" + current.LinkManDept + "'";
					}
					if (current.Sex != string.Empty)
					{
						text += ",Sex";
						text2 = text2 + ",'" + current.Sex + "'";
					}
					if (current.Posit != string.Empty)
					{
						text += ",Posit";
						text2 = text2 + ",'" + current.Posit + "'";
					}
					if (current.tel_Office != string.Empty)
					{
						text += ",tel_Office";
						text2 = text2 + ",'" + current.tel_Office + "'";
					}
					if (current.tel_Home != string.Empty)
					{
						text += ",tel_Home";
						text2 = text2 + ",'" + current.tel_Home + "'";
					}
					if (current.tel_Mobile != string.Empty)
					{
						text += ",tel_Mobile";
						text2 = text2 + ",'" + current.tel_Mobile + "'";
					}
					if (current.Fax != string.Empty)
					{
						text += ",Fax";
						text2 = text2 + ",'" + current.Fax + "'";
					}
					if (current.Birthday != string.Empty)
					{
						text += ",Birthday";
						text2 = text2 + ",'" + current.Birthday + "'";
					}
					if (current.Email != string.Empty)
					{
						text += ",Email";
						text2 = text2 + ",'" + current.Email + "'";
					}
					if (current.Adr != string.Empty)
					{
						text += ",Adr";
						text2 = text2 + ",'" + current.Adr + "'";
					}
					if (current.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current.Remark + "'";
					}
					array2[0] = "CustomerLinkMan";
					array2[1] = text;
					array2[2] = text2;
					array2[3] = " _Name='" + current._Name + "' ";
					array2[4] = "客户联系人";
					array2[5] = "ID";
					array2[6] = "CustomerID";
					list.Add(array2);
				}
			}
			if (model.DeviceListInfos != null)
			{
				foreach (DeviceListInfo current2 in model.DeviceListInfos)
				{
					string[] array2 = new string[7];
					text = string.Empty;
					text2 = string.Empty;
					if (current2.ProductSN1 != string.Empty)
					{
						text += "ProductSN1";
						text2 = text2 + "'" + current2.ProductSN1 + "'";
					}
					if (current2.LinkMan != string.Empty)
					{
						text += ",LinkMan";
						text2 = text2 + ",'" + current2.LinkMan + "'";
					}
					if (current2.CusDept != string.Empty)
					{
						text += ",CusDept";
						text2 = text2 + ",'" + current2.CusDept + "'";
					}
					if (current2.Tel != string.Empty)
					{
						text += ",Tel";
						text2 = text2 + ",'" + current2.Tel + "'";
					}
					if (current2.Tel2 != string.Empty)
					{
						text += ",Tel2";
						text2 = text2 + ",'" + current2.Tel2 + "'";
					}
					if (current2.Fax != string.Empty)
					{
						text += ",Fax";
						text2 = text2 + ",'" + current2.Fax + "'";
					}
					if (current2.Zip != string.Empty)
					{
						text += ",Zip";
						text2 = text2 + ",'" + current2.Zip + "'";
					}
					if (current2.Adr != string.Empty)
					{
						text += ",Adr";
						text2 = text2 + ",'" + current2.Adr + "'";
					}
					if (current2.ProductBrandID > 0)
					{
						text += ",ProductBrandID";
						text2 = text2 + "," + current2.ProductBrandID.ToString();
					}
					if (current2.ProductClassID > 0)
					{
						text += ",ProductClassID";
						text2 = text2 + "," + current2.ProductClassID.ToString();
					}
					if (current2.ProductModelID > 0)
					{
						text += ",ProductModelID";
						text2 = text2 + "," + current2.ProductModelID.ToString();
					}
					if (current2.ProductSN2 != string.Empty)
					{
						text += ",ProductSN2";
						text2 = text2 + ",'" + current2.ProductSN2 + "'";
					}
					if (current2.ProductAspect != string.Empty)
					{
						text += ",ProductAspect";
						text2 = text2 + ",'" + current2.ProductAspect + "'";
					}
					if (current2.BuyDate != string.Empty)
					{
						text += ",BuyDate";
						text2 = text2 + ",'" + current2.BuyDate + "'";
					}
					if (current2.BuyFrom != string.Empty)
					{
						text += ",BuyFrom";
						text2 = text2 + ",'" + current2.BuyFrom + "'";
					}
					if (current2.BuyInvoice != string.Empty)
					{
						text += ",BuyInvoice";
						text2 = text2 + ",'" + current2.BuyInvoice + "'";
					}
					if (current2.MaintenancePeriod != string.Empty)
					{
						text += ",MaintenancePeriod";
						text2 = text2 + ",'" + current2.MaintenancePeriod + "'";
					}
					if (current2.WarrantyID > 0)
					{
						text += ",WarrantyID";
						text2 = text2 + "," + current2.WarrantyID.ToString();
					}
					if (current2.RepairTimes > 0)
					{
						text += ",RepairTimes";
						text2 = text2 + "," + current2.RepairTimes.ToString();
					}
					if (current2.WarrantyStart != string.Empty)
					{
						text += ",WarrantyStart";
						text2 = text2 + ",'" + current2.WarrantyStart + "'";
					}
					if (current2.WarrantyEnd != string.Empty)
					{
						text += ",WarrantyEnd";
						text2 = text2 + ",'" + current2.WarrantyEnd + "'";
					}
					if (current2.Repairlately != string.Empty)
					{
						text += ",Repairlately";
						text2 = text2 + ",'" + current2.Repairlately + "'";
					}
					if (current2.ContractWarrantyStart != string.Empty)
					{
						text += ",ContractWarrantyStart";
						text2 = text2 + ",'" + current2.ContractWarrantyStart + "'";
					}
					if (current2.ContractWarrantyEnd != string.Empty)
					{
						text += ",ContractWarrantyEnd";
						text2 = text2 + ",'" + current2.ContractWarrantyEnd + "'";
					}
					if (current2.RepairWarrantyEnd != string.Empty)
					{
						text += ",RepairWarrantyEnd";
						text2 = text2 + ",'" + current2.RepairWarrantyEnd + "'";
					}
					if (current2.ContractNO != string.Empty)
					{
						text += ",ContractNO";
						text2 = text2 + ",'" + current2.ContractNO + "'";
					}
					if (current2.InstallDate != string.Empty)
					{
						text += ",InstallDate";
						text2 = text2 + ",'" + current2.InstallDate + "'";
					}
					if (current2.Remark != string.Empty)
					{
						text += ",Remark";
						text2 = text2 + ",'" + current2.Remark + "'";
					}
					array2[0] = "DeviceList";
					array2[1] = text;
					array2[2] = text2;
					array2[3] = " ProductSN1='" + current2.ProductSN1 + "' ";
					array2[4] = "机器档案";
					array2[5] = "ID";
					array2[6] = "CustomerID";
					list.Add(array2);
				}
			}
			return DbHelperSQL.RunManyProcedureTran("aa_insertdata", list, bsys, out strMsg, out iTbid);
		}

		public int Update(CustomerListInfo model, bool bsys, string chkfld, List<string[]> strdellist, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			if (!bsys)
			{
				text = text + ",CustomerNO='" + model.CustomerNO + "'";
			}
            text = text + ",jieshao='" + model.jieshao + "'";
			text = text + ",Zip='" + model.Zip + "'";
			text = text + ",Fax='" + model.Fax + "'";
			text = text + ",Email='" + model.Email + "'";
			text = text + ",Account='" + model.Account + "'";
			text = text + ",Area='" + model.Area + "'";
			text = text + ",QQ='" + model.QQ + "'";
			if (model.FromID > 0)
			{
				text = text + ",FromID=" + model.FromID.ToString();
			}
			else
			{
				text += ",FromID=null";
			}
			if (model.SellerID > 0)
			{
				text = text + ",SellerID=" + model.SellerID.ToString();
			}
			else
			{
				text += ",SellerID=null";
			}
			if (model.MemberID > 0)
			{
				text = text + ",MemberID=" + model.MemberID.ToString();
			}
			else
			{
				text += ",MemberID=null";
			}
			if (model.StatusID > 0)
			{
				text = text + ",StatusID=" + model.StatusID.ToString();
			}
			else
			{
				text += ",StatusID=null";
			}
			text = text + ",pyCode='" + model.pyCode + "'";
			if (model.bStop)
			{
				text += ",bStop=1";
			}
			else
			{
				text += ",bStop=0";
			}
			if (model.bCall)
			{
				text += ",bCall=1";
			}
			else
			{
				text += ",bCall=0";
			}
			if (model.bTrack)
			{
				text += ",bTrack=1";
			}
			else
			{
				text += ",bTrack=0";
			}
			text = text + ",Remark='" + model.Remark + "'";
			text = text + ",userdef1='" + model.userdef1 + "'";
			text = text + ",userdef2='" + model.userdef2 + "'";
			text = text + ",userdef3='" + model.userdef3 + "'";
			text = text + ",userdef4='" + model.userdef4 + "'";
			text = text + ",userdef5='" + model.userdef5 + "'";
			text = text + ",userdef6='" + model.userdef6 + "'";

            text = text + ",pay_info='" + model.pay_info + "'";
            text = text + ",pay_type='" + model.pay_type + "'";
            text = text + ",pay_date='" + model.pay_date + "'";
            text = text + ",pay_yanshou='" + model.pay_yanshou + "'";
            text = text + ",pay_tiexi='" + model.pay_tiexi + "'";
            text = text + ",pay_fapiao='" + model.pay_fapiao + "'";
            text = text + ",pay_ren='" + model.pay_ren + "'";

			if (model.ClassID > 0)
			{
				text = text + ",ClassID=" + model.ClassID.ToString();
			}
			else
			{
				text += ",ClassID=null";
			}
			text = text + ",PositionAmount=" + model.PositionAmount;
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Tel2='" + model.Tel2 + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",Coordinates='" + model.Coordinates + "'";
			if (model.BranchID > 0)
			{
				text = text + ",BranchID=" + model.BranchID;
			}
			else
			{
				text += ",BranchID=NULL";
			}
			if (model.DeptID.HasValue)
			{
				text = text + ", DeptID =" + model.DeptID;
			}
			string[] array = new string[7];
			array[0] = "CustomerList";
			array[1] = text;
			array[2] = " [ID]=" + model.ID.ToString();
			array[3] = chkfld;
			array[4] = " [ID]=" + model.ID.ToString();
			if (bsys)
			{
				array[5] = "CustomerNO";
				array[6] = "5";
			}
			list.Add(array);
			List<string[]> list2 = new List<string[]>();
			for (int i = 0; i < strdellist.Count; i++)
			{
				string[] array2 = strdellist[i];
				list2.Add(new string[]
				{
					array2[0].ToString(),
					" ID in(" + array2[1].ToString() + ")"
				});
			}
			if (model.CustomerLinkManInfos != null)
			{
				foreach (CustomerLinkManInfo current in model.CustomerLinkManInfos)
				{
					string[] array3 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						if (current._Name != string.Empty)
						{
							text2 += "_Name";
							text = text + "'" + current._Name + "'";
						}
						if (current.LinkManDept != string.Empty)
						{
							text2 += ",LinkManDept";
							text = text + ",'" + current.LinkManDept + "'";
						}
						if (current.Sex != string.Empty)
						{
							text2 += ",Sex";
							text = text + ",'" + current.Sex + "'";
						}
						if (current.Posit != string.Empty)
						{
							text2 += ",Posit";
							text = text + ",'" + current.Posit + "'";
						}
						if (current.tel_Office != string.Empty)
						{
							text2 += ",tel_Office";
							text = text + ",'" + current.tel_Office + "'";
						}
						if (current.tel_Home != string.Empty)
						{
							text2 += ",tel_Home";
							text = text + ",'" + current.tel_Home + "'";
						}
						if (current.tel_Mobile != string.Empty)
						{
							text2 += ",tel_Mobile";
							text = text + ",'" + current.tel_Mobile + "'";
						}
						if (current.Fax != string.Empty)
						{
							text2 += ",Fax";
							text = text + ",'" + current.Fax + "'";
						}
						if (current.Birthday != string.Empty)
						{
							text2 += ",Birthday";
							text = text + ",'" + current.Birthday + "'";
						}
						if (current.Email != string.Empty)
						{
							text2 += ",Email";
							text = text + ",'" + current.Email + "'";
						}
                        if (current.Adr != string.Empty)
						{
							text2 += ",Remark";
                            text = text + ",'" + current.Adr + "'";
						}
                        if (current.Remark != string.Empty)
						{
							text2 += ",Adr";
                            text = text + ",'" + current.Remark + "'";
						}
                        if (current.Tel_mobile1 != string.Empty)
                        {
                            text2 += ",tel_Mobile1";
                            text = text + ",'" + current.Tel_mobile1 + "'";
                        } if (current.Tel_mobile2 != string.Empty)
                        {
                            text2 += ",tel_Mobile2";
                            text = text + ",'" + current.Tel_mobile2 + "'";
                        } if (current.Tel_qq != string.Empty)
                        {
                            text2 += ",tel_QQ";
                            text = text + ",'" + current.Tel_qq + "'";
                        } if (current.Tel_weixin != string.Empty)
                        {
                            text2 += ",tel_weixin";
                            text = text + ",'" + current.Tel_weixin + "'";
                        } if (current.Tel_padr != string.Empty)
                        {
                            text2 += ",tel_padr";
                            text = text + ",'" + current.Tel_padr + "'";
                        }
                        

						array3[0] = "CustomerLinkMan";
						array3[1] = text2;
						array3[2] = text;
						array3[3] = " _Name='" + current._Name + "' ";
						array3[4] = "客户联系人";
						array3[5] = "ID";
						array3[6] = "CustomerID";
						array3[7] = current.ID.ToString();
						array3[8] = model.ID.ToString();
						list.Add(array3);
					}
					else
					{
						text = string.Empty;
						text = text + "_Name='" + current._Name + "'";
						text = text + ",LinkManDept='" + current.LinkManDept + "'";
						text = text + ",Sex='" + current.Sex + "'";
						text = text + ",Posit='" + current.Posit + "'";
						text = text + ",tel_Office='" + current.tel_Office + "'";
						text = text + ",tel_Home='" + current.tel_Home + "'";
						text = text + ",tel_Mobile='" + current.tel_Mobile + "'";
						text = text + ",Fax='" + current.Fax + "'";
						if (current.Birthday != string.Empty)
						{
							text = text + ",Birthday='" + current.Birthday + "'";
						}
						else
						{
							text += ",Birthday=null";
						}                  
                            text = text + ",tel_Mobile1='" + current.Tel_mobile1 + "'";                   
                            text = text + ",tel_Mobile2='" + current.Tel_mobile2 + "'";                     
                            text = text + ",tel_QQ='" + current.Tel_qq + "'";                  
                            text = text + ",tel_weixin='" + current.Tel_weixin + "'";                    
                            text = text + ",tel_padr='" + current.Tel_padr + "'";  
						text = text + ",Email='" + current.Email + "'";
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",Adr='" + current.Adr + "'";
						array3[0] = "CustomerLinkMan";
						array3[1] = text;
						array3[2] = " [ID]=" + current.ID.ToString();
						array3[3] = "1=2";
						array3[4] = " [ID]=" + current.ID.ToString();
						array3[7] = current.ID.ToString();
						list.Add(array3);
					}
				}
			}
			if (model.DeviceListInfos != null)
			{
				foreach (DeviceListInfo current2 in model.DeviceListInfos)
				{
					string[] array3 = new string[9];
					if (current2.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						if (current2.ProductSN1 != string.Empty)
						{
							text2 += "ProductSN1";
							text = text + "'" + current2.ProductSN1 + "'";
						}
						if (current2.LinkMan != string.Empty)
						{
							text2 += ",LinkMan";
							text = text + ",'" + current2.LinkMan + "'";
						}
						if (current2.CusDept != string.Empty)
						{
							text2 += ",CusDept";
							text = text + ",'" + current2.CusDept + "'";
						}
						if (current2.Tel != string.Empty)
						{
							text2 += ",Tel";
							text = text + ",'" + current2.Tel + "'";
						}
						if (current2.Tel2 != string.Empty)
						{
							text2 += ",Tel2";
							text = text + ",'" + current2.Tel2 + "'";
						}
						if (current2.Fax != string.Empty)
						{
							text2 += ",Fax";
							text = text + ",'" + current2.Fax + "'";
						}
						if (current2.Zip != string.Empty)
						{
							text2 += ",Zip";
							text = text + ",'" + current2.Zip + "'";
						}
						if (current2.Adr != string.Empty)
						{
							text2 += ",Adr";
							text = text + ",'" + current2.Adr + "'";
						}
						if (current2.ProductBrandID > 0)
						{
							text2 += ",ProductBrandID";
							text = text + "," + current2.ProductBrandID.ToString();
						}
						if (current2.ProductClassID > 0)
						{
							text2 += ",ProductClassID";
							text = text + "," + current2.ProductClassID.ToString();
						}
						if (current2.ProductModelID > 0)
						{
							text2 += ",ProductModelID";
							text = text + "," + current2.ProductModelID.ToString();
						}
						if (current2.ProductSN2 != string.Empty)
						{
							text2 += ",ProductSN2";
							text = text + ",'" + current2.ProductSN2 + "'";
						}
						if (current2.ProductAspect != string.Empty)
						{
							text2 += ",ProductAspect";
							text = text + ",'" + current2.ProductAspect + "'";
						}
						if (current2.BuyDate != string.Empty)
						{
							text2 += ",BuyDate";
							text = text + ",'" + current2.BuyDate + "'";
						}
						if (current2.BuyFrom != string.Empty)
						{
							text2 += ",BuyFrom";
							text = text + ",'" + current2.BuyFrom + "'";
						}
						if (current2.BuyInvoice != string.Empty)
						{
							text2 += ",BuyInvoice";
							text = text + ",'" + current2.BuyInvoice + "'";
						}
						if (current2.MaintenancePeriod != string.Empty)
						{
							text2 += ",MaintenancePeriod";
							text = text + ",'" + current2.MaintenancePeriod + "'";
						}
						if (current2.WarrantyID > 0)
						{
							text2 += ",WarrantyID";
							text = text + "," + current2.WarrantyID.ToString();
						}
						if (current2.RepairTimes > 0)
						{
							text2 += ",RepairTimes";
							text = text + "," + current2.RepairTimes.ToString();
						}
						if (current2.WarrantyStart != string.Empty)
						{
							text2 += ",WarrantyStart";
							text = text + ",'" + current2.WarrantyStart + "'";
						}
						if (current2.WarrantyEnd != string.Empty)
						{
							text2 += ",WarrantyEnd";
							text = text + ",'" + current2.WarrantyEnd + "'";
						}
						if (current2.Repairlately != string.Empty)
						{
							text2 += ",Repairlately";
							text = text + ",'" + current2.Repairlately + "'";
						}
						if (current2.ContractWarrantyStart != string.Empty)
						{
							text2 += ",ContractWarrantyStart";
							text = text + ",'" + current2.ContractWarrantyStart + "'";
						}
						if (current2.ContractWarrantyEnd != string.Empty)
						{
							text2 += ",ContractWarrantyEnd";
							text = text + ",'" + current2.ContractWarrantyEnd + "'";
						}
						if (current2.RepairWarrantyEnd != string.Empty)
						{
							text2 += ",RepairWarrantyEnd";
							text = text + ",'" + current2.RepairWarrantyEnd + "'";
						}
						if (current2.ContractNO != string.Empty)
						{
							text2 += ",ContractNO";
							text = text + ",'" + current2.ContractNO + "'";
						}
						if (current2.InstallDate != string.Empty)
						{
							text2 += ",InstallDate";
							text = text + ",'" + current2.InstallDate + "'";
						}
						if (current2.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current2.Remark + "'";
						}
						array3[0] = "DeviceList";
						array3[1] = text2;
						array3[2] = text;
						array3[3] = " ProductSN1='" + current2.ProductSN1 + "' ";
						array3[4] = "机器档案";
						array3[5] = "ID";
						array3[6] = "CustomerID";
						array3[7] = current2.ID.ToString();
						array3[8] = model.ID.ToString();
						list.Add(array3);
					}
					else
					{
						text = string.Empty;
						if (current2.ProductSN1 != string.Empty)
						{
							text = text + "ProductSN1='" + current2.ProductSN1 + "'";
							text = text + ",LinkMan='" + current2.LinkMan + "'";
							text = text + ",CusDept='" + current2.CusDept + "'";
							text = text + ",Tel='" + current2.Tel + "'";
							text = text + ",Tel2='" + current2.Tel2 + "'";
							text = text + ",Fax='" + current2.Fax + "'";
							text = text + ",Zip='" + current2.Zip + "'";
							text = text + ",Adr='" + current2.Adr + "'";
							if (current2.ProductBrandID > 0)
							{
								text = text + ",ProductBrandID=" + current2.ProductBrandID.ToString();
							}
							else
							{
								text += ",ProductBrandID=null";
							}
							if (current2.ProductClassID > 0)
							{
								text = text + ",ProductClassID=" + current2.ProductClassID.ToString();
							}
							else
							{
								text += ",ProductClassID=null";
							}
							if (current2.ProductModelID > 0)
							{
								text = text + ",ProductModelID=" + current2.ProductModelID.ToString();
							}
							else
							{
								text += ",ProductModelID=null";
							}
							text = text + ",ProductSN2='" + current2.ProductSN2 + "'";
							text = text + ",ProductAspect='" + current2.ProductAspect + "'";
							if (current2.BuyDate != string.Empty)
							{
								text = text + ",BuyDate='" + current2.BuyDate + "'";
							}
							else
							{
								text += ",BuyDate=null";
							}
							text = text + ",BuyFrom='" + current2.BuyFrom + "'";
							text = text + ",BuyInvoice='" + current2.BuyInvoice + "'";
							text = text + ",MaintenancePeriod='" + current2.MaintenancePeriod + "'";
							if (current2.WarrantyID > 0)
							{
								text = text + ",WarrantyID=" + current2.WarrantyID.ToString();
							}
							else
							{
								text += ",WarrantyID=null";
							}
							text = text + ",RepairTimes=" + current2.RepairTimes.ToString();
							if (current2.WarrantyStart != string.Empty)
							{
								text = text + ",WarrantyStart='" + current2.WarrantyStart + "'";
							}
							else
							{
								text += ",WarrantyStart=null";
							}
							if (current2.WarrantyEnd != string.Empty)
							{
								text = text + ",WarrantyEnd='" + current2.WarrantyEnd + "'";
							}
							else
							{
								text += ",WarrantyEnd=null";
							}
							if (current2.Repairlately != string.Empty)
							{
								text = text + ",Repairlately='" + current2.Repairlately + "'";
							}
							else
							{
								text += ",Repairlately=null";
							}
							if (current2.ContractWarrantyStart != string.Empty)
							{
								text = text + ",ContractWarrantyStart='" + current2.ContractWarrantyStart + "'";
							}
							else
							{
								text += ",ContractWarrantyStart=null";
							}
							if (current2.ContractWarrantyEnd != string.Empty)
							{
								text = text + ",ContractWarrantyEnd='" + current2.ContractWarrantyEnd + "'";
							}
							else
							{
								text += ",ContractWarrantyEnd=null";
							}
							if (current2.RepairWarrantyEnd != string.Empty)
							{
								text = text + ",RepairWarrantyEnd='" + current2.RepairWarrantyEnd + "'";
							}
							else
							{
								text += ",RepairWarrantyEnd=null";
							}
							text = text + ",ContractNO='" + current2.ContractNO + "'";
							if (current2.InstallDate != string.Empty)
							{
								text = text + ",InstallDate='" + current2.InstallDate + "'";
							}
							else
							{
								text += ",InstallDate=null";
							}
							text = text + ",Remark='" + current2.Remark + "'";
							array3[0] = "DeviceList";
							array3[1] = text;
							array3[2] = " [ID]=" + current2.ID.ToString();
							array3[3] = "1=2";
							array3[4] = " [ID]=" + current2.ID.ToString();
							array3[7] = current2.ID.ToString();
							list.Add(array3);
						}
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, list2, bsys, out strMsg);
		}

		public int UpdateLinkMan(CustomerListInfo model, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			List<string[]> strdellist = new List<string[]>();
			text = text + "ID=" + model.ID.ToString();
			string[] array = new string[7];
			array[0] = "CustomerList";
			array[1] = text;
			array[2] = " [ID]=" + model.ID.ToString();
			array[3] = "";
			array[4] = " [ID]=" + model.ID.ToString();
			list.Add(array);
			if (model.CustomerLinkManInfos != null)
			{
				foreach (CustomerLinkManInfo current in model.CustomerLinkManInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						if (current._Name != string.Empty)
						{
							text2 += "_Name";
							text = text + "'" + current._Name + "'";
						}
						if (current.LinkManDept != string.Empty)
						{
							text2 += ",LinkManDept";
							text = text + ",'" + current.LinkManDept + "'";
						}
						if (current.Sex != string.Empty)
						{
							text2 += ",Sex";
							text = text + ",'" + current.Sex + "'";
						}
						if (current.Posit != string.Empty)
						{
							text2 += ",Posit";
							text = text + ",'" + current.Posit + "'";
						}
						if (current.tel_Office != string.Empty)
						{
							text2 += ",tel_Office";
							text = text + ",'" + current.tel_Office + "'";
						}
						if (current.tel_Home != string.Empty)
						{
							text2 += ",tel_Home";
							text = text + ",'" + current.tel_Home + "'";
						}
						if (current.tel_Mobile != string.Empty)
						{
							text2 += ",tel_Mobile";
							text = text + ",'" + current.tel_Mobile + "'";
						}
						if (current.Fax != string.Empty)
						{
							text2 += ",Fax";
							text = text + ",'" + current.Fax + "'";
						}
						if (current.Birthday != string.Empty)
						{
							text2 += ",Birthday";
							text = text + ",'" + current.Birthday + "'";
						}
						if (current.Email != string.Empty)
						{
							text2 += ",Email";
							text = text + ",'" + current.Email + "'";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current.Adr != string.Empty)
						{
							text2 += ",Adr";
							text = text + ",'" + current.Adr + "'";
						}
						array2[0] = "CustomerLinkMan";
						array2[1] = text2;
						array2[2] = text;
						array2[3] = " _Name='" + current._Name + "' ";
						array2[4] = "客户联系人";
						array2[5] = "ID";
						array2[6] = "CustomerID";
						array2[7] = current.ID.ToString();
						array2[8] = model.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "_Name='" + current._Name + "'";
						text = text + ",LinkManDept='" + current.LinkManDept + "'";
						text = text + ",Sex='" + current.Sex + "'";
						text = text + ",Posit='" + current.Posit + "'";
						text = text + ",tel_Office='" + current.tel_Office + "'";
						text = text + ",tel_Home='" + current.tel_Home + "'";
						text = text + ",tel_Mobile='" + current.tel_Mobile + "'";
						text = text + ",Fax='" + current.Fax + "'";
						if (current.Birthday != string.Empty)
						{
							text = text + ",Birthday='" + current.Birthday + "'";
						}
						else
						{
							text += ",Birthday=null";
						}
						text = text + ",Email='" + current.Email + "'";
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",Adr='" + current.Adr + "'";
						array2[0] = "CustomerLinkMan";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "1=2";
						array2[4] = " [ID]=" + current.ID.ToString();
						array2[7] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, strdellist, false, out strMsg);
		}

		public CustomerListInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select a.[ID],Zip,Fax,Email,Account,Area,isnull(FromID,-1) as FromID,isnull(MemberID,-1) as MemberID,isnull(StatusID,-1) as StatusID,isnull(SellerID,-1) as SellerID,DeptID,_Date,pyCode,bStop,bCall,bTrack,Remark,isnull(ClassID,0) as ClassID,b._Name as Class,CustomerNO,a._Name,LinkMan,Tel,Tel2,Adr,Coordinates,userdef1,userdef2,userdef3,userdef4,userdef5,userdef6,pay_info,pay_type,pay_date,pay_yanshou,pay_tiexi,pay_fapiao,pay_ren ,QQ,BranchID,PositionAmount,jieshao from CustomerList a left join CustomerClass b on a.[ClassID]=b.[ID] ");
			stringBuilder.Append(" where a.[ID]=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			CustomerListInfo customerListInfo = new CustomerListInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			CustomerListInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					customerListInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				customerListInfo.Zip = dataSet.Tables[0].Rows[0]["Zip"].ToString();
                customerListInfo.jieshao = dataSet.Tables[0].Rows[0]["jieshao"].ToString();
				customerListInfo.Fax = dataSet.Tables[0].Rows[0]["Fax"].ToString();
				customerListInfo.Email = dataSet.Tables[0].Rows[0]["Email"].ToString();
				customerListInfo.Account = dataSet.Tables[0].Rows[0]["Account"].ToString();
				customerListInfo.Area = dataSet.Tables[0].Rows[0]["Area"].ToString();
				if (dataSet.Tables[0].Rows[0]["FromID"].ToString() != "")
				{
					customerListInfo.FromID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["FromID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["MemberID"].ToString() != "")
				{
					customerListInfo.MemberID = int.Parse(dataSet.Tables[0].Rows[0]["MemberID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["StatusID"].ToString() != "")
				{
					customerListInfo.StatusID = int.Parse(dataSet.Tables[0].Rows[0]["StatusID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["SellerID"].ToString() != "")
				{
					customerListInfo.SellerID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["SellerID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					customerListInfo.DeptID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString()));
				}
				if (dataSet.Tables[0].Rows[0]["_Date"].ToString() != "")
				{
					customerListInfo._Date = new DateTime?(DateTime.Parse(dataSet.Tables[0].Rows[0]["_Date"].ToString()));
				}
				customerListInfo.pyCode = dataSet.Tables[0].Rows[0]["pyCode"].ToString();
				if (dataSet.Tables[0].Rows[0]["bStop"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStop"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStop"].ToString().ToLower() == "true")
					{
						customerListInfo.bStop = true;
					}
					else
					{
						customerListInfo.bStop = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bTrack"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bTrack"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bTrack"].ToString().ToLower() == "true")
					{
						customerListInfo.bTrack = true;
					}
					else
					{
						customerListInfo.bTrack = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bCall"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bCall"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bCall"].ToString().ToLower() == "true")
					{
						customerListInfo.bCall = true;
					}
					else
					{
						customerListInfo.bCall = false;
					}
				}
				customerListInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				if (dataSet.Tables[0].Rows[0]["ClassID"].ToString() != "")
				{
					customerListInfo.ClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ClassID"].ToString()));
				}
				customerListInfo.Class = dataSet.Tables[0].Rows[0]["Class"].ToString();
				customerListInfo.CustomerNO = dataSet.Tables[0].Rows[0]["CustomerNO"].ToString();
				customerListInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				customerListInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				customerListInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				customerListInfo.Tel2 = dataSet.Tables[0].Rows[0]["Tel2"].ToString();
				customerListInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				customerListInfo.Coordinates = dataSet.Tables[0].Rows[0]["Coordinates"].ToString();
				customerListInfo.userdef1 = dataSet.Tables[0].Rows[0]["userdef1"].ToString();
				customerListInfo.userdef2 = dataSet.Tables[0].Rows[0]["userdef2"].ToString();
				customerListInfo.userdef3 = dataSet.Tables[0].Rows[0]["userdef3"].ToString();
				customerListInfo.userdef4 = dataSet.Tables[0].Rows[0]["userdef4"].ToString();
				customerListInfo.userdef5 = dataSet.Tables[0].Rows[0]["userdef5"].ToString();
				customerListInfo.userdef6 = dataSet.Tables[0].Rows[0]["userdef6"].ToString();

                customerListInfo.pay_info = dataSet.Tables[0].Rows[0]["pay_info"].ToString();
                customerListInfo.pay_type = dataSet.Tables[0].Rows[0]["pay_type"].ToString();
                customerListInfo.pay_date = dataSet.Tables[0].Rows[0]["pay_date"].ToString();
                customerListInfo.pay_yanshou = dataSet.Tables[0].Rows[0]["pay_yanshou"].ToString();
                customerListInfo.pay_tiexi = dataSet.Tables[0].Rows[0]["pay_tiexi"].ToString();
                customerListInfo.pay_fapiao = dataSet.Tables[0].Rows[0]["pay_fapiao"].ToString();
                customerListInfo.pay_ren = dataSet.Tables[0].Rows[0]["pay_ren"].ToString();

				customerListInfo.QQ = dataSet.Tables[0].Rows[0]["QQ"].ToString();
				if (dataSet.Tables[0].Rows[0]["BranchID"].ToString() != "")
				{
					customerListInfo.BranchID = int.Parse(dataSet.Tables[0].Rows[0]["BranchID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["PositionAmount"].ToString() != "")
				{
					customerListInfo.PositionAmount = decimal.Parse(dataSet.Tables[0].Rows[0]["PositionAmount"].ToString());
				}
				result = customerListInfo;
			}
			else
			{
				result = null;
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
					" and (CustomerNO like '%",
					strcon,
					"%' or _Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%' or (LinkMan like '%",
					strcon,
					"%' or [ID] in(select CustomerID from CustomerLinkMan where _Name like '%",
					strcon,
					"%')) or (Tel like '%",
					strcon,
					"%' or Tel2 like '%",
					strcon,
					"%' or [ID] in(select CustomerID from CustomerLinkMan where tel_Office like '%",
					strcon,
					"%' or tel_Home like '%",
					strcon,
					"%' or tel_Mobile like '%",
					strcon,
					"%')) or  Adr like '%",
					strcon,
					"%' or Fax like '%",
					strcon,
					"%'or [ID] in(select CustomerID from CustomerLinkMan where Zip like '%",
					strcon,
					"%') or Zip like '%",
					strcon,
					"%' or Email like '%",
					strcon,
					"%' or [ID] in(select CustomerID from CustomerLinkMan where Email like '%",
					strcon,
					"%') or Area like '%",
					strcon,
					"%' or DeptID like '%",
					strcon,
					"%' or CusFrom like '%",
					strcon,
					"%' or FromCode like '%",
					strcon,
					"%' or  Seller like '%",
					strcon,
					"%' or Status like '%",
					strcon,
					"%' or _Date like '%",
					strcon,
					"%' or userdef1 like '%",
					strcon,
					"%' or userdef2 like '%",
					strcon,
					"%' or userdef3 like '%",
					strcon,
					"%' or userdef4 like '%",
					strcon,
					"%' or userdef5 like '%",
					strcon,
					"%' or userdef6 like '%",
					strcon,
					"%' or TrackOperator like '%",
					strcon,
					"%' or QQ like '%",
					strcon,
					"%' or Remark like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 1:
				text = text + " and CustomerNO like '%" + strcon + "%' ";
				break;
			case 2:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (_Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 3:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and LinkMan like '%",
					strcon,
					"%' or [ID] in(select CustomerID from CustomerLinkMan where _Name like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 4:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Tel like '%",
					strcon,
					"%' or Tel2 like '%",
					strcon,
					"%' or [ID] in(select CustomerID from CustomerLinkMan where tel_Office like '%",
					strcon,
					"%' or tel_Home like '%",
					strcon,
					"%' or tel_Mobile like '%",
					strcon,
					"%')) "
				});
				break;
			}
			case 5:
				text = text + " and Adr like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and Zip like '%" + strcon + "%' ";
				break;
			case 7:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and Fax like '%",
					strcon,
					"%' or [ID] in(select CustomerID from CustomerLinkMan where Fax like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 8:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and Email like '%",
					strcon,
					"%' or [ID] in(select CustomerID from CustomerLinkMan where Email like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 9:
				text = text + " and Area like '%" + strcon + "%' ";
				break;
			case 10:
				text = text + " and DeptID like '%" + strcon + "%' ";
				break;
			case 11:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (CusFrom like '%",
					strcon,
					"%' or FromCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 12:
				text = text + " and Seller like '%" + strcon + "%' ";
				break;
			case 13:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public int InputCus(int iDeptid, int iClassid, string strname, string strno, string strLinkMan, string strTel, string strTel2, string strFax, string strZip, string strEmail, string strArea, string strCoor, string strFrom, string strSeller, string strAccount, string strAdr, string strRemark, string Status, string Track, string struserdef1, string struserdef2, string struserdef3, string struserdef4, string struserdef5, string struserdef6, int iOperator, bool bTrack, bool bCover, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDeptid", SqlDbType.Int),
				new SqlParameter("@iClassid", SqlDbType.Int),
				new SqlParameter("@strname", SqlDbType.NVarChar, 50),
				new SqlParameter("@strno", SqlDbType.NVarChar, 50),
				new SqlParameter("@strLinkMan", SqlDbType.NVarChar, 50),
				new SqlParameter("@strTel", SqlDbType.NVarChar, 50),
				new SqlParameter("@strTel2", SqlDbType.NVarChar, 50),
				new SqlParameter("@strFax", SqlDbType.NVarChar, 50),
				new SqlParameter("@strZip", SqlDbType.NVarChar, 50),
				new SqlParameter("@strEmail", SqlDbType.NVarChar, 50),
				new SqlParameter("@strArea", SqlDbType.NVarChar, 50),
				new SqlParameter("@strQQ", SqlDbType.NVarChar, 50),
				new SqlParameter("@strFrom", SqlDbType.NVarChar, 50),
				new SqlParameter("@strSeller", SqlDbType.NVarChar, 50),
				new SqlParameter("@strAccount", SqlDbType.NVarChar, 50),
				new SqlParameter("@strAdr", SqlDbType.NVarChar, 200),
				new SqlParameter("@strRemark", SqlDbType.NVarChar, 2000),
				new SqlParameter("@Status", SqlDbType.NVarChar, 50),
				new SqlParameter("@Track", SqlDbType.NVarChar, 500),
				new SqlParameter("@struserdef1", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef2", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef3", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef4", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef5", SqlDbType.NVarChar, 100),
				new SqlParameter("@struserdef6", SqlDbType.NVarChar, 100),
				new SqlParameter("@iOperator", SqlDbType.Int),
				new SqlParameter("@bTrack", SqlDbType.Bit),
				new SqlParameter("@bCover", SqlDbType.Bit),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = iDeptid;
			array[1].Value = iClassid;
			array[2].Value = strname;
			array[3].Value = strno;
			array[4].Value = strLinkMan;
			array[5].Value = strTel;
			array[6].Value = strTel2;
			array[7].Value = strFax;
			array[8].Value = strZip;
			array[9].Value = strEmail;
			array[10].Value = strArea;
			array[11].Value = strCoor;
			array[12].Value = strFrom;
			array[13].Value = strSeller;
			array[14].Value = strAccount;
			array[15].Value = strAdr;
			array[16].Value = strRemark;
			array[17].Value = Status;
			array[18].Value = Track;
			array[19].Value = struserdef1;
			array[20].Value = struserdef2;
			array[21].Value = struserdef3;
			array[22].Value = struserdef4;
			array[23].Value = struserdef5;
			array[24].Value = struserdef6;
			array[25].Value = iOperator;
			array[26].Value = bTrack;
			array[27].Value = bCover;
			array[28].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("ks_inputcustomer", array);
			strMsg = Convert.ToString(array[28].Value);
			return result;
		}

		public int CusAllot(string stridlist, int operatorid, int trackoperatorid, string Reason, int iType, int iDept)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@stridlist", SqlDbType.NVarChar, 500),
				new SqlParameter("@iOperatorid", SqlDbType.Int),
				new SqlParameter("@trackoperatorid", SqlDbType.Int),
				new SqlParameter("@strReason", SqlDbType.NVarChar, 100),
				new SqlParameter("@iType", SqlDbType.Int),
				new SqlParameter("@iDept", SqlDbType.Int)
			};
			array[0].Value = stridlist;
			array[1].Value = operatorid;
			array[2].Value = trackoperatorid;
			array[3].Value = Reason;
			array[4].Value = iType;
			array[5].Value = iDept;
			return DbHelperSQL.RunProcedureTran("ks_gz_fp", array);
		}

		public int CloseTrack(string stridlist, int statusid)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@stridlist", SqlDbType.NVarChar, 500),
				new SqlParameter("@statusid", SqlDbType.Int)
			};
			array[0].Value = stridlist;
			array[1].Value = statusid;
			return DbHelperSQL.RunProcedureTran("ks_gz_gb", array);
		}

		public void UpdateClass(string strid, string strclassid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update CustomerList set ");
			if (strclassid == "0")
			{
				stringBuilder.Append("ClassID=null");
			}
			else
			{
				stringBuilder.Append("ClassID=" + strclassid);
			}
			stringBuilder.Append(" where ID in(" + strid + ")");
			DbHelperSQL.ExecuteSql(stringBuilder.ToString());
		}

		public void UpdateClass(string strid, int int_a, int int_b, int int_c, int int_d, int int_e, int int_f, int int_g, int int_h, int int_i, string strclassid, int istatus, string strarea, int imem, int bback, int btrack, int sellerid, int istop, decimal dDisposition)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder.Append("update CustomerList set ");
			if (int_a == 1)
			{
				if (strclassid == "0")
				{
					stringBuilder2.Append("ClassID=null");
				}
				else
				{
					stringBuilder2.Append("ClassID=" + strclassid);
				}
			}
			if (int_b == 1)
			{
				if (istatus == 0)
				{
					if (stringBuilder2.ToString() == "")
					{
						stringBuilder2.Append("StatusID= NULL");
					}
					else
					{
						stringBuilder2.Append(",StatusID=NULL");
					}
				}
				else if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("StatusID=" + istatus);
				}
				else
				{
					stringBuilder2.Append(",StatusID=" + istatus);
				}
			}
			if (int_c == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("Area= '" + strarea + "' ");
				}
				else
				{
					stringBuilder2.Append(",Area= '" + strarea + "' ");
				}
			}
			if (int_d == 1)
			{
				if (imem == 0)
				{
					if (stringBuilder2.ToString() == "")
					{
						stringBuilder2.Append("MemberID=null");
					}
					else
					{
						stringBuilder2.Append(",MemberID=null");
					}
				}
				else if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("MemberID=" + imem);
				}
				else
				{
					stringBuilder2.Append(",MemberID=" + imem);
				}
			}
			if (int_e == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("bCall=" + bback);
				}
				else
				{
					stringBuilder2.Append(",bCall=" + bback);
				}
			}
			if (int_f == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("bTrack=" + btrack);
				}
				else
				{
					stringBuilder2.Append(",bTrack=" + btrack);
				}
			}
			if (int_g == 1)
			{
				if (sellerid <= 0)
				{
					if (stringBuilder2.ToString() == "")
					{
						stringBuilder2.Append("SellerID=null");
					}
					else
					{
						stringBuilder2.Append(",SellerID=null");
					}
				}
				else if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("SellerID=" + sellerid);
				}
				else
				{
					stringBuilder2.Append(",SellerID=" + sellerid);
				}
			}
			if (int_h == 1)
			{
				if (istop == 1)
				{
					if (stringBuilder2.ToString() == "")
					{
						stringBuilder2.Append("bStop=1");
					}
					else
					{
						stringBuilder2.Append(",bStop=1");
					}
				}
				else if (istop == 2)
				{
					if (stringBuilder2.ToString() == "")
					{
						stringBuilder2.Append("bStop=0");
					}
					else
					{
						stringBuilder2.Append(",bStop=0");
					}
				}
			}
			if (int_i == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("PositionAmount=" + dDisposition);
				}
				else
				{
					stringBuilder2.Append(",PositionAmount=" + dDisposition);
				}
			}
			stringBuilder.Append(stringBuilder2.ToString());
			stringBuilder.Append(" where ID in(" + strid + ")");
			DbHelperSQL.ExecuteSql(stringBuilder.ToString());
		}

		public bool CusMerge(int id, string scus, string cusname, string linkman, string linktel, string adr, string remark)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@cusid", SqlDbType.Int, 4),
				new SqlParameter("@scus", SqlDbType.VarChar, 200),
				new SqlParameter("@cusname", SqlDbType.VarChar, 100),
				new SqlParameter("@linkman", SqlDbType.VarChar, 50),
				new SqlParameter("@linktel", SqlDbType.VarChar, 50),
				new SqlParameter("@adr", SqlDbType.VarChar, 200),
				new SqlParameter("@remark", SqlDbType.VarChar, 2000)
			};
			array[0].Value = id;
			array[1].Value = scus;
			array[2].Value = cusname;
			array[3].Value = linkman;
			array[4].Value = linktel;
			array[5].Value = adr;
			array[6].Value = remark;
			int num = DbHelperSQL.RunProcedureTran("ks_cusmerge", array);
			return num != -1;
		}

		public void UpdateCusInfo(int id)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@id", SqlDbType.Int)
			};
			array[0].Value = id;
			DbHelperSQL.RunProcedureTran("updateCusInfo", array);
		}

		public bool ExistCus(string customername)
		{
			string strSql = "select * from  CustomerList where _Name=@_Name";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Name", SqlDbType.VarChar, 50)
			};
			array[0].Value = customername;
			return DbHelperSQL.Exists(strSql, array);
		}

		public DataSet GetCusData(string customername)
		{
			string sQLString = "select * from CustomerList where _Name=@_Name";
			return DbHelperSQL.Query(sQLString, new SqlParameter[]
			{
				new SqlParameter("@_Name", SqlDbType.VarChar, 50)
				{
					Value = customername
				}
			});
		}

		public int getMemberID(int recid)
		{
			string sQLString = "select MemberID from CustomerList where ID=@ID";
			DataTable dataTable = DbHelperSQL.Query(sQLString, new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
				{
					Value = recid
				}
			}).Tables[0];
			int result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = int.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = -1;
			return result;
		}

		public int getCustomerID(string cusName)
		{
			string sQLString = " select [ID] from customerlist where _Name=@Name";
			DataTable dataTable = DbHelperSQL.Query(sQLString, new SqlParameter[]
			{
				new SqlParameter("@Name", SqlDbType.VarChar, 50)
				{
					Value = cusName
				}
			}).Tables[0];
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

		public decimal getPositionAmount(int id)
		{
			string sQLString = " select PositionAmount from customerlist where ID=@ID";
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = id;
			DataTable dataTable = DbHelperSQL.Query(sQLString, array).Tables[0];
			decimal result;
			if (dataTable.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
				{
					result = decimal.Parse(dataTable.Rows[0][0].ToString());
					return result;
				}
			}
			result = 0m;
			return result;
		}

		public string getCusMember(int customerid)
		{
			string result = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select b._Name as Member from customerlist a left join customermembers b on a.memberid=b.ID where a.ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = customerid;
			DataTable dataTable = DbHelperSQL.Query(stringBuilder.ToString(), array).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				result = dataTable.Rows[0][0].ToString();
			}
			return result;
		}
	}
}
