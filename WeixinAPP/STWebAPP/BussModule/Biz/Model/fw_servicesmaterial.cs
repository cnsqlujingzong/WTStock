using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
    public class fw_servicesmaterial
    {
        #region Model
        private int _id;
        private int _goodsid;
        private int _unitid;
        private string _remark;
        private string _goodsno;
        private string __name;
        private string _spec;
        private string _maintenanceperiod;
        private string _periodenddate;
        private string _chargestyle;
        private string _productbrand;
        private string _unit;
        private int _billid;
        private decimal? _qty;
        private decimal? _price;
        private decimal? _lqty;
        private decimal? _costprice;
        private decimal? _total;
        private string _sn;
        private string _outsourcing;
        private decimal? _outcostprice;
        private decimal? _taxrate;
        private decimal? _taxamount;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UnitID
        {
            set { _unitid = value; }
            get { return _unitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsNO
        {
            set { _goodsno = value; }
            get { return _goodsno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _Name
        {
            set { __name = value; }
            get { return __name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spec
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaintenancePeriod
        {
            set { _maintenanceperiod = value; }
            get { return _maintenanceperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PeriodEndDate
        {
            set { _periodenddate = value; }
            get { return _periodenddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChargeStyle
        {
            set { _chargestyle = value; }
            get { return _chargestyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductBrand
        {
            set { _productbrand = value; }
            get { return _productbrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LQty
        {
            set { _lqty = value; }
            get { return _lqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CostPrice
        {
            set { _costprice = value; }
            get { return _costprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Total
        {
            set { _total = value; }
            get { return _total; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SN
        {
            set { _sn = value; }
            get { return _sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OutSourcing
        {
            set { _outsourcing = value; }
            get { return _outsourcing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OutCostPrice
        {
            set { _outcostprice = value; }
            get { return _outcostprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Taxrate
        {
            set { _taxrate = value; }
            get { return _taxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Taxamount
        {
            set { _taxamount = value; }
            get { return _taxamount; }
        }
        #endregion Model
    }
}
