using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
  public  class ks_qtylist
    {
        #region Model
        private int _id;
        private int? _billid;
        private int? _deviceid;
        private string _sn;
        private string __date;
        private int? _operatorid;
        private string _qtytype;
        private int? _qty;
        private string _remark;
        private string _operator;
        private string _productsn1;
        private string _productsn2;
        private string _allowance;
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
        public int? BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
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
        public string _Date
        {
            set { __date = value; }
            get { return __date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OperatorID
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QtyType
        {
            set { _qtytype = value; }
            get { return _qtytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Qty
        {
            set { _qty = value; }
            get { return _qty; }
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
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductSN1
        {
            set { _productsn1 = value; }
            get { return _productsn1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductSN2
        {
            set { _productsn2 = value; }
            get { return _productsn2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Allowance
        {
            set { _allowance = value; }
            get { return _allowance; }
        }
        #endregion Model

    }
}
