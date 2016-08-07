using BussModule.Biz.Model;
using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BussModule.Biz.DAO
{
   public class fw_servicesBuss
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BussModule.Biz.Model.fw_services GetModel(int? ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BillID,TakeDept,DisposalDept,curStatus,bTake,PayeeOperID,ChkOperatorID,BackSeeOperID,Time_Complete,TakeOverID,DisposalID,ServicesType,TakeStyle,TakeStyleID,TypeID,IsDismissed,OfferConf,SerCount,Time_Make,Time_TakeOver,Time_Start,Time_Over,Time_Payee,OperatorID,Time_BackSee,Time_Close,Operator,Person,PersonID,StartOperator,PayeeOper,ChkOperator,ProductClassID,ProductBrandID,ProductModelID,BackSeeOper,CustomerName,BranchID,CustomerFrom,CustomerClass,userdef1,userdef2,userdef3,userdef4,userdef5,userdef6,LinkMan,Tel,UsePerson,UsePersonDept,UsePersonTel,Area,Adr,ProductSN1,ProductSN2,FinTec,BuyDate,BuyFrom,ProductClass,ProductModel,ProductBrand,Aspect,CusType,WarrantyID,Accessory,Fault,Warranty,BuyInvoice,dPoint,SellerID,Speding,Time,Timeout,bRepair,SaveID,SupplierID,ChargeCorp,DisposalOper,SubscribeTime,SubscribeConnectTime,SubscribePrice,PreCharge,RepairStatus,RepairType,RepairCorpID,RepairCorp,Remark,CancelReason,RepairSndDate,RepairRcvDate,RepairCost,CustomerID,WarrantyChargeCorpID,PostNO,Postage,MaterailCost,ExtraCost,Fee_Materail,Fee_Labor,Fee_Add,WarrantyChargeValue,ChargeValue,Fee_Total,Profit,WarrantyEndDate,WarrantyBound,GoodsTo,ConnectDate,bCall,SmsStatus,ConfirmDate,CorpName,Coordinates,CorpLinkMan,CorpTel,CorpFax,CorpZip,CorpArea,CorpAdr,InCash,_PRI,ContractNO,SndStyle,SndStyleID,ServiceLevelID,ResponseTime,RepairTime,DeviceNO,PreMoney,RealMoney,TakeSteps,QtyType,OldQtyType,HaveAmount,NotChargeAmount,Path,bAgain,Deduct,VisitDate,VisitCusName,VisitOpinon,VisitRemark,VisitOperator,VisitStyle,HFQK,VisitID,cmbProver,cmbCity,BranchName,BranchRatio,BranchRatioType from fw_services ");
            strSql.Append(" where ID=@ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					};
            parameters[0].Value = ID;
            Model.fw_services model = new Model.fw_services();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public fw_services DataRowToModel(DataRow row)
        {
            Model.fw_services model = new Model.fw_services();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["BillID"] != null)
                {
                    model.BillID = row["BillID"].ToString();
                }
                if (row["TakeDept"] != null)
                {
                    model.TakeDept = row["TakeDept"].ToString();
                }
                if (row["DisposalDept"] != null)
                {
                    model.DisposalDept = row["DisposalDept"].ToString();
                }
                if (row["curStatus"] != null)
                {
                    model.curStatus = row["curStatus"].ToString();
                }
                if (row["bTake"] != null && row["bTake"].ToString() != "")
                {
                    if ((row["bTake"].ToString() == "1") || (row["bTake"].ToString().ToLower() == "true"))
                    {
                        model.bTake = true;
                    }
                    else
                    {
                        model.bTake = false;
                    }
                }
                if (row["PayeeOperID"] != null && row["PayeeOperID"].ToString() != "")
                {
                    model.PayeeOperID = int.Parse(row["PayeeOperID"].ToString());
                }
                if (row["ChkOperatorID"] != null && row["ChkOperatorID"].ToString() != "")
                {
                    model.ChkOperatorID = int.Parse(row["ChkOperatorID"].ToString());
                }
                if (row["BackSeeOperID"] != null && row["BackSeeOperID"].ToString() != "")
                {
                    model.BackSeeOperID = int.Parse(row["BackSeeOperID"].ToString());
                }
                if (row["Time_Complete"] != null && row["Time_Complete"].ToString() != "")
                {
                    model.Time_Complete = DateTime.Parse(row["Time_Complete"].ToString());
                }
                if (row["TakeOverID"] != null && row["TakeOverID"].ToString() != "")
                {
                    model.TakeOverID = int.Parse(row["TakeOverID"].ToString());
                }
                if (row["DisposalID"] != null && row["DisposalID"].ToString() != "")
                {
                    model.DisposalID = int.Parse(row["DisposalID"].ToString());
                }
                if (row["ServicesType"] != null)
                {
                    model.ServicesType = row["ServicesType"].ToString();
                }
                if (row["TakeStyle"] != null)
                {
                    model.TakeStyle = row["TakeStyle"].ToString();
                }
                if (row["TakeStyleID"] != null && row["TakeStyleID"].ToString() != "")
                {
                    model.TakeStyleID = int.Parse(row["TakeStyleID"].ToString());
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["IsDismissed"] != null && row["IsDismissed"].ToString() != "")
                {
                    model.IsDismissed = int.Parse(row["IsDismissed"].ToString());
                }
                if (row["OfferConf"] != null)
                {
                    model.OfferConf = row["OfferConf"].ToString();
                }
                if (row["SerCount"] != null)
                {
                    model.SerCount = row["SerCount"].ToString();
                }
                if (row["Time_Make"] != null && row["Time_Make"].ToString() != "")
                {
                    model.Time_Make = DateTime.Parse(row["Time_Make"].ToString());
                }
                if (row["Time_TakeOver"] != null && row["Time_TakeOver"].ToString() != "")
                {
                    model.Time_TakeOver = DateTime.Parse(row["Time_TakeOver"].ToString());
                }
                if (row["Time_Start"] != null && row["Time_Start"].ToString() != "")
                {
                    model.Time_Start = DateTime.Parse(row["Time_Start"].ToString());
                }
                if (row["Time_Over"] != null && row["Time_Over"].ToString() != "")
                {
                    model.Time_Over = DateTime.Parse(row["Time_Over"].ToString());
                }
                if (row["Time_Payee"] != null)
                {
                    model.Time_Payee = row["Time_Payee"].ToString();
                }
                if (row["OperatorID"] != null && row["OperatorID"].ToString() != "")
                {
                    model.OperatorID = int.Parse(row["OperatorID"].ToString());
                }
                if (row["Time_BackSee"] != null && row["Time_BackSee"].ToString() != "")
                {
                    model.Time_BackSee = DateTime.Parse(row["Time_BackSee"].ToString());
                }
                if (row["Time_Close"] != null && row["Time_Close"].ToString() != "")
                {
                    model.Time_Close = DateTime.Parse(row["Time_Close"].ToString());
                }
                if (row["Operator"] != null)
                {
                    model.Operator = row["Operator"].ToString();
                }
                if (row["Person"] != null)
                {
                    model.Person = row["Person"].ToString();
                }
                if (row["PersonID"] != null && row["PersonID"].ToString() != "")
                {
                    model.PersonID = int.Parse(row["PersonID"].ToString());
                }
                if (row["StartOperator"] != null)
                {
                    model.StartOperator = row["StartOperator"].ToString();
                }
                if (row["PayeeOper"] != null)
                {
                    model.PayeeOper = row["PayeeOper"].ToString();
                }
                if (row["ChkOperator"] != null)
                {
                    model.ChkOperator = row["ChkOperator"].ToString();
                }
                if (row["ProductClassID"] != null && row["ProductClassID"].ToString() != "")
                {
                    model.ProductClassID = int.Parse(row["ProductClassID"].ToString());
                }
                if (row["ProductBrandID"] != null && row["ProductBrandID"].ToString() != "")
                {
                    model.ProductBrandID = int.Parse(row["ProductBrandID"].ToString());
                }
                if (row["ProductModelID"] != null && row["ProductModelID"].ToString() != "")
                {
                    model.ProductModelID = int.Parse(row["ProductModelID"].ToString());
                }
                if (row["BackSeeOper"] != null)
                {
                    model.BackSeeOper = row["BackSeeOper"].ToString();
                }
                if (row["CustomerName"] != null)
                {
                    model.CustomerName = row["CustomerName"].ToString();
                }
                if (row["BranchID"] != null && row["BranchID"].ToString() != "")
                {
                    model.BranchID = int.Parse(row["BranchID"].ToString());
                }
                if (row["CustomerFrom"] != null)
                {
                    model.CustomerFrom = row["CustomerFrom"].ToString();
                }
                if (row["CustomerClass"] != null)
                {
                    model.CustomerClass = row["CustomerClass"].ToString();
                }
                if (row["userdef1"] != null)
                {
                    model.userdef1 = row["userdef1"].ToString();
                }
                if (row["userdef2"] != null)
                {
                    model.userdef2 = row["userdef2"].ToString();
                }
                if (row["userdef3"] != null)
                {
                    model.userdef3 = row["userdef3"].ToString();
                }
                if (row["userdef4"] != null)
                {
                    model.userdef4 = row["userdef4"].ToString();
                }
                if (row["userdef5"] != null)
                {
                    model.userdef5 = row["userdef5"].ToString();
                }
                if (row["userdef6"] != null)
                {
                    model.userdef6 = row["userdef6"].ToString();
                }
                if (row["LinkMan"] != null)
                {
                    model.LinkMan = row["LinkMan"].ToString();
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["UsePerson"] != null)
                {
                    model.UsePerson = row["UsePerson"].ToString();
                }
                if (row["UsePersonDept"] != null)
                {
                    model.UsePersonDept = row["UsePersonDept"].ToString();
                }
                if (row["UsePersonTel"] != null)
                {
                    model.UsePersonTel = row["UsePersonTel"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["Adr"] != null)
                {
                    model.Adr = row["Adr"].ToString();
                }
                if (row["ProductSN1"] != null)
                {
                    model.ProductSN1 = row["ProductSN1"].ToString();
                }
                if (row["ProductSN2"] != null)
                {
                    model.ProductSN2 = row["ProductSN2"].ToString();
                }
                if (row["FinTec"] != null)
                {
                    model.FinTec = row["FinTec"].ToString();
                }
                if (row["BuyDate"] != null)
                {
                    model.BuyDate = row["BuyDate"].ToString();
                }
                if (row["BuyFrom"] != null)
                {
                    model.BuyFrom = row["BuyFrom"].ToString();
                }
                if (row["ProductClass"] != null)
                {
                    model.ProductClass = row["ProductClass"].ToString();
                }
                if (row["ProductModel"] != null)
                {
                    model.ProductModel = row["ProductModel"].ToString();
                }
                if (row["ProductBrand"] != null)
                {
                    model.ProductBrand = row["ProductBrand"].ToString();
                }
                if (row["Aspect"] != null)
                {
                    model.Aspect = row["Aspect"].ToString();
                }
                if (row["CusType"] != null && row["CusType"].ToString() != "")
                {
                    model.CusType = int.Parse(row["CusType"].ToString());
                }
                if (row["WarrantyID"] != null && row["WarrantyID"].ToString() != "")
                {
                    model.WarrantyID = int.Parse(row["WarrantyID"].ToString());
                }
                if (row["Accessory"] != null)
                {
                    model.Accessory = row["Accessory"].ToString();
                }
                if (row["Fault"] != null)
                {
                    model.Fault = row["Fault"].ToString();
                }
                if (row["Warranty"] != null)
                {
                    model.Warranty = row["Warranty"].ToString();
                }
                if (row["BuyInvoice"] != null)
                {
                    model.BuyInvoice = row["BuyInvoice"].ToString();
                }
                if (row["dPoint"] != null && row["dPoint"].ToString() != "")
                {
                    model.dPoint = decimal.Parse(row["dPoint"].ToString());
                }
                if (row["SellerID"] != null && row["SellerID"].ToString() != "")
                {
                    model.SellerID = int.Parse(row["SellerID"].ToString());
                }
                if (row["Speding"] != null)
                {
                    model.Speding = row["Speding"].ToString();
                }
                if (row["Time"] != null && row["Time"].ToString() != "")
                {
                    model.Time = int.Parse(row["Time"].ToString());
                }
                if (row["Timeout"] != null && row["Timeout"].ToString() != "")
                {
                    model.Timeout = int.Parse(row["Timeout"].ToString());
                }
                if (row["bRepair"] != null)
                {
                    model.bRepair = row["bRepair"].ToString();
                }
                if (row["SaveID"] != null)
                {
                    model.SaveID = row["SaveID"].ToString();
                }
                if (row["SupplierID"] != null)
                {
                    model.SupplierID = row["SupplierID"].ToString();
                }
                if (row["ChargeCorp"] != null)
                {
                    model.ChargeCorp = row["ChargeCorp"].ToString();
                }
                if (row["DisposalOper"] != null)
                {
                    model.DisposalOper = row["DisposalOper"].ToString();
                }
                if (row["SubscribeTime"] != null && row["SubscribeTime"].ToString() != "")
                {
                    model.SubscribeTime = DateTime.Parse(row["SubscribeTime"].ToString());
                }
                if (row["SubscribeConnectTime"] != null)
                {
                    model.SubscribeConnectTime = row["SubscribeConnectTime"].ToString();
                }
                if (row["SubscribePrice"] != null && row["SubscribePrice"].ToString() != "")
                {
                    model.SubscribePrice = decimal.Parse(row["SubscribePrice"].ToString());
                }
                if (row["PreCharge"] != null && row["PreCharge"].ToString() != "")
                {
                    model.PreCharge = decimal.Parse(row["PreCharge"].ToString());
                }
                if (row["RepairStatus"] != null)
                {
                    model.RepairStatus = row["RepairStatus"].ToString();
                }
                if (row["RepairType"] != null)
                {
                    model.RepairType = row["RepairType"].ToString();
                }
                if (row["RepairCorpID"] != null && row["RepairCorpID"].ToString() != "")
                {
                    model.RepairCorpID = int.Parse(row["RepairCorpID"].ToString());
                }
                if (row["RepairCorp"] != null)
                {
                    model.RepairCorp = row["RepairCorp"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CancelReason"] != null)
                {
                    model.CancelReason = row["CancelReason"].ToString();
                }
                if (row["RepairSndDate"] != null && row["RepairSndDate"].ToString() != "")
                {
                    model.RepairSndDate = DateTime.Parse(row["RepairSndDate"].ToString());
                }
                if (row["RepairRcvDate"] != null && row["RepairRcvDate"].ToString() != "")
                {
                    model.RepairRcvDate = DateTime.Parse(row["RepairRcvDate"].ToString());
                }
                if (row["RepairCost"] != null && row["RepairCost"].ToString() != "")
                {
                    model.RepairCost = decimal.Parse(row["RepairCost"].ToString());
                }
                if (row["CustomerID"] != null && row["CustomerID"].ToString() != "")
                {
                    model.CustomerID = int.Parse(row["CustomerID"].ToString());
                }
                if (row["WarrantyChargeCorpID"] != null && row["WarrantyChargeCorpID"].ToString() != "")
                {
                    model.WarrantyChargeCorpID = int.Parse(row["WarrantyChargeCorpID"].ToString());
                }
                if (row["PostNO"] != null)
                {
                    model.PostNO = row["PostNO"].ToString();
                }
                if (row["Postage"] != null && row["Postage"].ToString() != "")
                {
                    model.Postage = decimal.Parse(row["Postage"].ToString());
                }
                if (row["MaterailCost"] != null && row["MaterailCost"].ToString() != "")
                {
                    model.MaterailCost = decimal.Parse(row["MaterailCost"].ToString());
                }
                if (row["ExtraCost"] != null && row["ExtraCost"].ToString() != "")
                {
                    model.ExtraCost = decimal.Parse(row["ExtraCost"].ToString());
                }
                if (row["Fee_Materail"] != null && row["Fee_Materail"].ToString() != "")
                {
                    model.Fee_Materail = decimal.Parse(row["Fee_Materail"].ToString());
                }
                if (row["Fee_Labor"] != null && row["Fee_Labor"].ToString() != "")
                {
                    model.Fee_Labor = decimal.Parse(row["Fee_Labor"].ToString());
                }
                if (row["Fee_Add"] != null && row["Fee_Add"].ToString() != "")
                {
                    model.Fee_Add = decimal.Parse(row["Fee_Add"].ToString());
                }
                if (row["WarrantyChargeValue"] != null && row["WarrantyChargeValue"].ToString() != "")
                {
                    model.WarrantyChargeValue = decimal.Parse(row["WarrantyChargeValue"].ToString());
                }
                if (row["ChargeValue"] != null && row["ChargeValue"].ToString() != "")
                {
                    model.ChargeValue = decimal.Parse(row["ChargeValue"].ToString());
                }
                if (row["Fee_Total"] != null && row["Fee_Total"].ToString() != "")
                {
                    model.Fee_Total = decimal.Parse(row["Fee_Total"].ToString());
                }
                if (row["Profit"] != null && row["Profit"].ToString() != "")
                {
                    model.Profit = decimal.Parse(row["Profit"].ToString());
                }
                if (row["WarrantyEndDate"] != null)
                {
                    model.WarrantyEndDate = row["WarrantyEndDate"].ToString();
                }
                if (row["WarrantyBound"] != null)
                {
                    model.WarrantyBound = row["WarrantyBound"].ToString();
                }
                if (row["GoodsTo"] != null)
                {
                    model.GoodsTo = row["GoodsTo"].ToString();
                }
                if (row["ConnectDate"] != null)
                {
                    model.ConnectDate = row["ConnectDate"].ToString();
                }
                if (row["bCall"] != null)
                {
                    model.bCall = row["bCall"].ToString();
                }
                if (row["SmsStatus"] != null)
                {
                    model.SmsStatus = row["SmsStatus"].ToString();
                }
                if (row["ConfirmDate"] != null && row["ConfirmDate"].ToString() != "")
                {
                    model.ConfirmDate = DateTime.Parse(row["ConfirmDate"].ToString());
                }
                if (row["CorpName"] != null)
                {
                    model.CorpName = row["CorpName"].ToString();
                }
                if (row["Coordinates"] != null)
                {
                    model.Coordinates = row["Coordinates"].ToString();
                }
                if (row["CorpLinkMan"] != null)
                {
                    model.CorpLinkMan = row["CorpLinkMan"].ToString();
                }
                if (row["CorpTel"] != null)
                {
                    model.CorpTel = row["CorpTel"].ToString();
                }
                if (row["CorpFax"] != null)
                {
                    model.CorpFax = row["CorpFax"].ToString();
                }
                if (row["CorpZip"] != null)
                {
                    model.CorpZip = row["CorpZip"].ToString();
                }
                if (row["CorpArea"] != null)
                {
                    model.CorpArea = row["CorpArea"].ToString();
                }
                if (row["CorpAdr"] != null)
                {
                    model.CorpAdr = row["CorpAdr"].ToString();
                }
                if (row["InCash"] != null && row["InCash"].ToString() != "")
                {
                    model.InCash = decimal.Parse(row["InCash"].ToString());
                }
                if (row["_PRI"] != null)
                {
                    model._PRI = row["_PRI"].ToString();
                }
                if (row["ContractNO"] != null)
                {
                    model.ContractNO = row["ContractNO"].ToString();
                }
                if (row["SndStyle"] != null)
                {
                    model.SndStyle = row["SndStyle"].ToString();
                }
                if (row["SndStyleID"] != null && row["SndStyleID"].ToString() != "")
                {
                    model.SndStyleID = int.Parse(row["SndStyleID"].ToString());
                }
                if (row["ServiceLevelID"] != null && row["ServiceLevelID"].ToString() != "")
                {
                    model.ServiceLevelID = int.Parse(row["ServiceLevelID"].ToString());
                }
                if (row["ResponseTime"] != null && row["ResponseTime"].ToString() != "")
                {
                    model.ResponseTime = int.Parse(row["ResponseTime"].ToString());
                }
                if (row["RepairTime"] != null && row["RepairTime"].ToString() != "")
                {
                    model.RepairTime = int.Parse(row["RepairTime"].ToString());
                }
                if (row["DeviceNO"] != null)
                {
                    model.DeviceNO = row["DeviceNO"].ToString();
                }
                if (row["PreMoney"] != null && row["PreMoney"].ToString() != "")
                {
                    model.PreMoney = decimal.Parse(row["PreMoney"].ToString());
                }
                if (row["RealMoney"] != null && row["RealMoney"].ToString() != "")
                {
                    model.RealMoney = decimal.Parse(row["RealMoney"].ToString());
                }
                if (row["TakeSteps"] != null)
                {
                    model.TakeSteps = row["TakeSteps"].ToString();
                }
                if (row["QtyType"] != null)
                {
                    model.QtyType = row["QtyType"].ToString();
                }
                if (row["OldQtyType"] != null)
                {
                    model.OldQtyType = row["OldQtyType"].ToString();
                }
                if (row["HaveAmount"] != null && row["HaveAmount"].ToString() != "")
                {
                    model.HaveAmount = decimal.Parse(row["HaveAmount"].ToString());
                }
                if (row["NotChargeAmount"] != null && row["NotChargeAmount"].ToString() != "")
                {
                    model.NotChargeAmount = decimal.Parse(row["NotChargeAmount"].ToString());
                }
                if (row["Path"] != null)
                {
                    model.Path = row["Path"].ToString();
                }
                if (row["bAgain"] != null)
                {
                    model.bAgain = row["bAgain"].ToString();
                }
                if (row["Deduct"] != null)
                {
                    model.Deduct = row["Deduct"].ToString();
                }
                if (row["VisitDate"] != null)
                {
                    model.VisitDate = row["VisitDate"].ToString();
                }
                if (row["VisitCusName"] != null)
                {
                    model.VisitCusName = row["VisitCusName"].ToString();
                }
                if (row["VisitOpinon"] != null)
                {
                    model.VisitOpinon = row["VisitOpinon"].ToString();
                }
                if (row["VisitRemark"] != null)
                {
                    model.VisitRemark = row["VisitRemark"].ToString();
                }
                if (row["VisitOperator"] != null)
                {
                    model.VisitOperator = row["VisitOperator"].ToString();
                }
                if (row["VisitStyle"] != null)
                {
                    model.VisitStyle = row["VisitStyle"].ToString();
                }
                if (row["HFQK"] != null)
                {
                    model.HFQK = row["HFQK"].ToString();
                }
                if (row["VisitID"] != null && row["VisitID"].ToString() != "")
                {
                    model.VisitID = int.Parse(row["VisitID"].ToString());
                }
                if (row["cmbProver"] != null)
                {
                    model.cmbProver = row["cmbProver"].ToString();
                }
                if (row["cmbCity"] != null)
                {
                    model.cmbCity = row["cmbCity"].ToString();
                }
                if (row["BranchName"] != null)
                {
                    model.BranchName = row["BranchName"].ToString();
                }
                if (row["BranchRatio"] != null && row["BranchRatio"].ToString() != "")
                {
                    model.BranchRatio = decimal.Parse(row["BranchRatio"].ToString());
                }
                if (row["BranchRatioType"] != null)
                {
                    model.BranchRatioType = row["BranchRatioType"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<fw_services> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BillID,TakeDept,DisposalDept,curStatus,bTake,PayeeOperID,ChkOperatorID,BackSeeOperID,Time_Complete,TakeOverID,DisposalID,ServicesType,TakeStyle,TakeStyleID,TypeID,IsDismissed,OfferConf,SerCount,Time_Make,Time_TakeOver,Time_Start,Time_Over,Time_Payee,OperatorID,Time_BackSee,Time_Close,Operator,Person,PersonID,StartOperator,PayeeOper,ChkOperator,ProductClassID,ProductBrandID,ProductModelID,BackSeeOper,CustomerName,BranchID,CustomerFrom,CustomerClass,userdef1,userdef2,userdef3,userdef4,userdef5,userdef6,LinkMan,Tel,UsePerson,UsePersonDept,UsePersonTel,Area,Adr,ProductSN1,ProductSN2,FinTec,BuyDate,BuyFrom,ProductClass,ProductModel,ProductBrand,Aspect,CusType,WarrantyID,Accessory,Fault,Warranty,BuyInvoice,dPoint,SellerID,Speding,Time,Timeout,bRepair,SaveID,SupplierID,ChargeCorp,DisposalOper,SubscribeTime,SubscribeConnectTime,SubscribePrice,PreCharge,RepairStatus,RepairType,RepairCorpID,RepairCorp,Remark,CancelReason,RepairSndDate,RepairRcvDate,RepairCost,CustomerID,WarrantyChargeCorpID,PostNO,Postage,MaterailCost,ExtraCost,Fee_Materail,Fee_Labor,Fee_Add,WarrantyChargeValue,ChargeValue,Fee_Total,Profit,WarrantyEndDate,WarrantyBound,GoodsTo,ConnectDate,bCall,SmsStatus,ConfirmDate,CorpName,Coordinates,CorpLinkMan,CorpTel,CorpFax,CorpZip,CorpArea,CorpAdr,InCash,_PRI,ContractNO,SndStyle,SndStyleID,ServiceLevelID,ResponseTime,RepairTime,DeviceNO,PreMoney,RealMoney,TakeSteps,QtyType,OldQtyType,HaveAmount,NotChargeAmount,Path,bAgain,Deduct,VisitDate,VisitCusName,VisitOpinon,VisitRemark,VisitOperator,VisitStyle,HFQK,VisitID,cmbProver,cmbCity,BranchName,BranchRatio,BranchRatioType ");
            strSql.Append(" FROM fw_services ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet  ds=DbHelperSQL.Query(strSql.ToString());
            List<fw_services> list = new List<fw_services>();
            if (ds.Tables[0].Rows.Count > 0)
            {             
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModel(item));
                }              
            }
            return list;
        }

    }
}
