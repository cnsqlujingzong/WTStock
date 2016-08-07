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
    public class fw_servicesmaterialBuss
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, string ChargeStyle, string ProductBrand, string Unit, int BillID, decimal Qty, decimal Price, decimal LQty, decimal CostPrice, decimal Total, string SN, int GoodsID, string OutSourcing, decimal OutCostPrice, decimal Taxrate, decimal Taxamount, int UnitID, string Remark, string GoodsNO, string _Name, string Spec, string MaintenancePeriod, string PeriodEndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fw_servicesmaterial");
            strSql.Append(" where ID=@ID and ChargeStyle=@ChargeStyle and ProductBrand=@ProductBrand and Unit=@Unit and BillID=@BillID and Qty=@Qty and Price=@Price and LQty=@LQty and CostPrice=@CostPrice and Total=@Total and SN=@SN and GoodsID=@GoodsID and OutSourcing=@OutSourcing and OutCostPrice=@OutCostPrice and Taxrate=@Taxrate and Taxamount=@Taxamount and UnitID=@UnitID and Remark=@Remark and GoodsNO=@GoodsNO and _Name=@_Name and Spec=@Spec and MaintenancePeriod=@MaintenancePeriod and PeriodEndDate=@PeriodEndDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar,10),
					new SqlParameter("@ProductBrand", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,20),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@LQty", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@SN", SqlDbType.VarChar,8000),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@OutSourcing", SqlDbType.VarChar,2),
					new SqlParameter("@OutCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Taxrate", SqlDbType.Decimal,9),
					new SqlParameter("@Taxamount", SqlDbType.Decimal,17),
					new SqlParameter("@UnitID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Spec", SqlDbType.VarChar,100),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar,50),
					new SqlParameter("@PeriodEndDate", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;
            parameters[1].Value = ChargeStyle;
            parameters[2].Value = ProductBrand;
            parameters[3].Value = Unit;
            parameters[4].Value = BillID;
            parameters[5].Value = Qty;
            parameters[6].Value = Price;
            parameters[7].Value = LQty;
            parameters[8].Value = CostPrice;
            parameters[9].Value = Total;
            parameters[10].Value = SN;
            parameters[11].Value = GoodsID;
            parameters[12].Value = OutSourcing;
            parameters[13].Value = OutCostPrice;
            parameters[14].Value = Taxrate;
            parameters[15].Value = Taxamount;
            parameters[16].Value = UnitID;
            parameters[17].Value = Remark;
            parameters[18].Value = GoodsNO;
            parameters[19].Value = _Name;
            parameters[20].Value = Spec;
            parameters[21].Value = MaintenancePeriod;
            parameters[22].Value = PeriodEndDate;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.fw_servicesmaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into fw_servicesmaterial(");
            strSql.Append("ID,GoodsID,UnitID,Remark,GoodsNO,_Name,Spec,MaintenancePeriod,PeriodEndDate,ChargeStyle,ProductBrand,Unit,BillID,Qty,Price,LQty,CostPrice,Total,SN,OutSourcing,OutCostPrice,Taxrate,Taxamount)");
            strSql.Append(" values (");
            strSql.Append("@ID,@GoodsID,@UnitID,@Remark,@GoodsNO,@_Name,@Spec,@MaintenancePeriod,@PeriodEndDate,@ChargeStyle,@ProductBrand,@Unit,@BillID,@Qty,@Price,@LQty,@CostPrice,@Total,@SN,@OutSourcing,@OutCostPrice,@Taxrate,@Taxamount)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@UnitID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Spec", SqlDbType.VarChar,100),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar,50),
					new SqlParameter("@PeriodEndDate", SqlDbType.VarChar,50),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar,10),
					new SqlParameter("@ProductBrand", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,20),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@LQty", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@SN", SqlDbType.VarChar,8000),
					new SqlParameter("@OutSourcing", SqlDbType.VarChar,2),
					new SqlParameter("@OutCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Taxrate", SqlDbType.Decimal,9),
					new SqlParameter("@Taxamount", SqlDbType.Decimal,17)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.GoodsID;
            parameters[2].Value = model.UnitID;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.GoodsNO;
            parameters[5].Value = model._Name;
            parameters[6].Value = model.Spec;
            parameters[7].Value = model.MaintenancePeriod;
            parameters[8].Value = model.PeriodEndDate;
            parameters[9].Value = model.ChargeStyle;
            parameters[10].Value = model.ProductBrand;
            parameters[11].Value = model.Unit;
            parameters[12].Value = model.BillID;
            parameters[13].Value = model.Qty;
            parameters[14].Value = model.Price;
            parameters[15].Value = model.LQty;
            parameters[16].Value = model.CostPrice;
            parameters[17].Value = model.Total;
            parameters[18].Value = model.SN;
            parameters[19].Value = model.OutSourcing;
            parameters[20].Value = model.OutCostPrice;
            parameters[21].Value = model.Taxrate;
            parameters[22].Value = model.Taxamount;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.fw_servicesmaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fw_servicesmaterial set ");
            strSql.Append("ID=@ID,");
            strSql.Append("GoodsID=@GoodsID,");
            strSql.Append("UnitID=@UnitID,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("GoodsNO=@GoodsNO,");
            strSql.Append("_Name=@_Name,");
            strSql.Append("Spec=@Spec,");
            strSql.Append("MaintenancePeriod=@MaintenancePeriod,");
            strSql.Append("PeriodEndDate=@PeriodEndDate,");
            strSql.Append("ChargeStyle=@ChargeStyle,");
            strSql.Append("ProductBrand=@ProductBrand,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("BillID=@BillID,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("Price=@Price,");
            strSql.Append("LQty=@LQty,");
            strSql.Append("CostPrice=@CostPrice,");
            strSql.Append("Total=@Total,");
            strSql.Append("SN=@SN,");
            strSql.Append("OutSourcing=@OutSourcing,");
            strSql.Append("OutCostPrice=@OutCostPrice,");
            strSql.Append("Taxrate=@Taxrate,");
            strSql.Append("Taxamount=@Taxamount");
            strSql.Append(" where ID=@ID and ChargeStyle=@ChargeStyle and ProductBrand=@ProductBrand and Unit=@Unit and BillID=@BillID and Qty=@Qty and Price=@Price and LQty=@LQty and CostPrice=@CostPrice and Total=@Total and SN=@SN and GoodsID=@GoodsID and OutSourcing=@OutSourcing and OutCostPrice=@OutCostPrice and Taxrate=@Taxrate and Taxamount=@Taxamount and UnitID=@UnitID and Remark=@Remark and GoodsNO=@GoodsNO and _Name=@_Name and Spec=@Spec and MaintenancePeriod=@MaintenancePeriod and PeriodEndDate=@PeriodEndDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@UnitID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Spec", SqlDbType.VarChar,100),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar,50),
					new SqlParameter("@PeriodEndDate", SqlDbType.VarChar,50),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar,10),
					new SqlParameter("@ProductBrand", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,20),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@LQty", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@SN", SqlDbType.VarChar,8000),
					new SqlParameter("@OutSourcing", SqlDbType.VarChar,2),
					new SqlParameter("@OutCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Taxrate", SqlDbType.Decimal,9),
					new SqlParameter("@Taxamount", SqlDbType.Decimal,17)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.GoodsID;
            parameters[2].Value = model.UnitID;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.GoodsNO;
            parameters[5].Value = model._Name;
            parameters[6].Value = model.Spec;
            parameters[7].Value = model.MaintenancePeriod;
            parameters[8].Value = model.PeriodEndDate;
            parameters[9].Value = model.ChargeStyle;
            parameters[10].Value = model.ProductBrand;
            parameters[11].Value = model.Unit;
            parameters[12].Value = model.BillID;
            parameters[13].Value = model.Qty;
            parameters[14].Value = model.Price;
            parameters[15].Value = model.LQty;
            parameters[16].Value = model.CostPrice;
            parameters[17].Value = model.Total;
            parameters[18].Value = model.SN;
            parameters[19].Value = model.OutSourcing;
            parameters[20].Value = model.OutCostPrice;
            parameters[21].Value = model.Taxrate;
            parameters[22].Value = model.Taxamount;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID, string ChargeStyle, string ProductBrand, string Unit, int BillID, decimal Qty, decimal Price, decimal LQty, decimal CostPrice, decimal Total, string SN, int GoodsID, string OutSourcing, decimal OutCostPrice, decimal Taxrate, decimal Taxamount, int UnitID, string Remark, string GoodsNO, string _Name, string Spec, string MaintenancePeriod, string PeriodEndDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fw_servicesmaterial ");
            strSql.Append(" where ID=@ID and ChargeStyle=@ChargeStyle and ProductBrand=@ProductBrand and Unit=@Unit and BillID=@BillID and Qty=@Qty and Price=@Price and LQty=@LQty and CostPrice=@CostPrice and Total=@Total and SN=@SN and GoodsID=@GoodsID and OutSourcing=@OutSourcing and OutCostPrice=@OutCostPrice and Taxrate=@Taxrate and Taxamount=@Taxamount and UnitID=@UnitID and Remark=@Remark and GoodsNO=@GoodsNO and _Name=@_Name and Spec=@Spec and MaintenancePeriod=@MaintenancePeriod and PeriodEndDate=@PeriodEndDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar,10),
					new SqlParameter("@ProductBrand", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,20),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@LQty", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@SN", SqlDbType.VarChar,8000),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@OutSourcing", SqlDbType.VarChar,2),
					new SqlParameter("@OutCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Taxrate", SqlDbType.Decimal,9),
					new SqlParameter("@Taxamount", SqlDbType.Decimal,17),
					new SqlParameter("@UnitID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Spec", SqlDbType.VarChar,100),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar,50),
					new SqlParameter("@PeriodEndDate", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;
            parameters[1].Value = ChargeStyle;
            parameters[2].Value = ProductBrand;
            parameters[3].Value = Unit;
            parameters[4].Value = BillID;
            parameters[5].Value = Qty;
            parameters[6].Value = Price;
            parameters[7].Value = LQty;
            parameters[8].Value = CostPrice;
            parameters[9].Value = Total;
            parameters[10].Value = SN;
            parameters[11].Value = GoodsID;
            parameters[12].Value = OutSourcing;
            parameters[13].Value = OutCostPrice;
            parameters[14].Value = Taxrate;
            parameters[15].Value = Taxamount;
            parameters[16].Value = UnitID;
            parameters[17].Value = Remark;
            parameters[18].Value = GoodsNO;
            parameters[19].Value = _Name;
            parameters[20].Value = Spec;
            parameters[21].Value = MaintenancePeriod;
            parameters[22].Value = PeriodEndDate;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.fw_servicesmaterial GetModel(int ID, string ChargeStyle, string ProductBrand, string Unit, int BillID, decimal Qty, decimal Price, decimal LQty, decimal CostPrice, decimal Total, string SN, int GoodsID, string OutSourcing, decimal OutCostPrice, decimal Taxrate, decimal Taxamount, int UnitID, string Remark, string GoodsNO, string _Name, string Spec, string MaintenancePeriod, string PeriodEndDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GoodsID,UnitID,Remark,GoodsNO,_Name,Spec,MaintenancePeriod,PeriodEndDate,ChargeStyle,ProductBrand,Unit,BillID,Qty,Price,LQty,CostPrice,Total,SN,OutSourcing,OutCostPrice,Taxrate,Taxamount from fw_servicesmaterial ");
            strSql.Append(" where ID=@ID and ChargeStyle=@ChargeStyle and ProductBrand=@ProductBrand and Unit=@Unit and BillID=@BillID and Qty=@Qty and Price=@Price and LQty=@LQty and CostPrice=@CostPrice and Total=@Total and SN=@SN and GoodsID=@GoodsID and OutSourcing=@OutSourcing and OutCostPrice=@OutCostPrice and Taxrate=@Taxrate and Taxamount=@Taxamount and UnitID=@UnitID and Remark=@Remark and GoodsNO=@GoodsNO and _Name=@_Name and Spec=@Spec and MaintenancePeriod=@MaintenancePeriod and PeriodEndDate=@PeriodEndDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ChargeStyle", SqlDbType.VarChar,10),
					new SqlParameter("@ProductBrand", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,20),
					new SqlParameter("@BillID", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@LQty", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Total", SqlDbType.Decimal,9),
					new SqlParameter("@SN", SqlDbType.VarChar,8000),
					new SqlParameter("@GoodsID", SqlDbType.Int,4),
					new SqlParameter("@OutSourcing", SqlDbType.VarChar,2),
					new SqlParameter("@OutCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Taxrate", SqlDbType.Decimal,9),
					new SqlParameter("@Taxamount", SqlDbType.Decimal,17),
					new SqlParameter("@UnitID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsNO", SqlDbType.VarChar,50),
					new SqlParameter("@_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Spec", SqlDbType.VarChar,100),
					new SqlParameter("@MaintenancePeriod", SqlDbType.VarChar,50),
					new SqlParameter("@PeriodEndDate", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;
            parameters[1].Value = ChargeStyle;
            parameters[2].Value = ProductBrand;
            parameters[3].Value = Unit;
            parameters[4].Value = BillID;
            parameters[5].Value = Qty;
            parameters[6].Value = Price;
            parameters[7].Value = LQty;
            parameters[8].Value = CostPrice;
            parameters[9].Value = Total;
            parameters[10].Value = SN;
            parameters[11].Value = GoodsID;
            parameters[12].Value = OutSourcing;
            parameters[13].Value = OutCostPrice;
            parameters[14].Value = Taxrate;
            parameters[15].Value = Taxamount;
            parameters[16].Value = UnitID;
            parameters[17].Value = Remark;
            parameters[18].Value = GoodsNO;
            parameters[19].Value = _Name;
            parameters[20].Value = Spec;
            parameters[21].Value = MaintenancePeriod;
            parameters[22].Value = PeriodEndDate;

            Model.fw_servicesmaterial model = new Model.fw_servicesmaterial();
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
        public Model.fw_servicesmaterial DataRowToModel(DataRow row)
        {
            Model.fw_servicesmaterial model = new Model.fw_servicesmaterial();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["GoodsID"] != null && row["GoodsID"].ToString() != "")
                {
                    model.GoodsID = int.Parse(row["GoodsID"].ToString());
                }
                if (row["UnitID"] != null && row["UnitID"].ToString() != "")
                {
                    model.UnitID = int.Parse(row["UnitID"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["GoodsNO"] != null)
                {
                    model.GoodsNO = row["GoodsNO"].ToString();
                }
                if (row["_Name"] != null)
                {
                    model._Name = row["_Name"].ToString();
                }
                if (row["Spec"] != null)
                {
                    model.Spec = row["Spec"].ToString();
                }
                if (row["MaintenancePeriod"] != null)
                {
                    model.MaintenancePeriod = row["MaintenancePeriod"].ToString();
                }
                if (row["PeriodEndDate"] != null)
                {
                    model.PeriodEndDate = row["PeriodEndDate"].ToString();
                }
                if (row["ChargeStyle"] != null)
                {
                    model.ChargeStyle = row["ChargeStyle"].ToString();
                }
                if (row["ProductBrand"] != null)
                {
                    model.ProductBrand = row["ProductBrand"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["BillID"] != null && row["BillID"].ToString() != "")
                {
                    model.BillID = int.Parse(row["BillID"].ToString());
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(row["Qty"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["LQty"] != null && row["LQty"].ToString() != "")
                {
                    model.LQty = decimal.Parse(row["LQty"].ToString());
                }
                if (row["CostPrice"] != null && row["CostPrice"].ToString() != "")
                {
                    model.CostPrice = decimal.Parse(row["CostPrice"].ToString());
                }
                if (row["Total"] != null && row["Total"].ToString() != "")
                {
                    model.Total = decimal.Parse(row["Total"].ToString());
                }
                if (row["SN"] != null)
                {
                    model.SN = row["SN"].ToString();
                }
                if (row["OutSourcing"] != null)
                {
                    model.OutSourcing = row["OutSourcing"].ToString();
                }
                if (row["OutCostPrice"] != null && row["OutCostPrice"].ToString() != "")
                {
                    model.OutCostPrice = decimal.Parse(row["OutCostPrice"].ToString());
                }
                if (row["Taxrate"] != null && row["Taxrate"].ToString() != "")
                {
                    model.Taxrate = decimal.Parse(row["Taxrate"].ToString());
                }
                if (row["Taxamount"] != null && row["Taxamount"].ToString() != "")
                {
                    model.Taxamount = decimal.Parse(row["Taxamount"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<fw_servicesmaterial> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,GoodsID,UnitID,Remark,GoodsNO,_Name,Spec,MaintenancePeriod,PeriodEndDate,ChargeStyle,ProductBrand,Unit,BillID,Qty,Price,LQty,CostPrice,Total,SN,OutSourcing,OutCostPrice,Taxrate,Taxamount ");
            strSql.Append(" FROM fw_servicesmaterial ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }           
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Model.fw_servicesmaterial> list = new List<Model.fw_servicesmaterial>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModel(item));
                }
            }
            return list;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,GoodsID,UnitID,Remark,GoodsNO,_Name,Spec,MaintenancePeriod,PeriodEndDate,ChargeStyle,ProductBrand,Unit,BillID,Qty,Price,LQty,CostPrice,Total,SN,OutSourcing,OutCostPrice,Taxrate,Taxamount ");
            strSql.Append(" FROM fw_servicesmaterial ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM fw_servicesmaterial ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.PeriodEndDate desc");
            }
            strSql.Append(")AS Row, T.*  from fw_servicesmaterial T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
