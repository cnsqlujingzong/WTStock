using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
   public class fw_servicesoffer
    {
        #region Model
        private int _id;
        private int? _billid;
        private string __date;
        private int? _operatorid;
        private int? _sellerid;
        private int? _itemid;
        private decimal? _damount;
        private bool _bcusconf;
        private string _remark;
        private string __name;
        private string _operator;
        private string _seller;
        private string _cusconf;
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
        public int? SellerID
        {
            set { _sellerid = value; }
            get { return _sellerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ItemID
        {
            set { _itemid = value; }
            get { return _itemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? dAmount
        {
            set { _damount = value; }
            get { return _damount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bCusConf
        {
            set { _bcusconf = value; }
            get { return _bcusconf; }
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
        public string _Name
        {
            set { __name = value; }
            get { return __name; }
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
        public string Seller
        {
            set { _seller = value; }
            get { return _seller; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CusConf
        {
            set { _cusconf = value; }
            get { return _cusconf; }
        }
        #endregion Model
    }
}
