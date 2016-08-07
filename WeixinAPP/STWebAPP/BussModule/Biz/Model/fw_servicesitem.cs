using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
   public class fw_servicesitem
    {
        #region Model
        private int _id;
        private int _billid;
        private int _itemid;
        private decimal? _price;
        private decimal? _dpoint;
        private string _tec;
        private string _chargestyle;
        private decimal? _tecdeduct;
        private string _remark;
        private string _itemno;
        private string __name;
        private string _bcomplete;
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
        public int BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ItemID
        {
            set { _itemid = value; }
            get { return _itemid; }
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
        public decimal? dPoint
        {
            set { _dpoint = value; }
            get { return _dpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tec
        {
            set { _tec = value; }
            get { return _tec; }
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
        public decimal? TecDeduct
        {
            set { _tecdeduct = value; }
            get { return _tecdeduct; }
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
        public string ItemNO
        {
            set { _itemno = value; }
            get { return _itemno; }
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
        public string bComplete
        {
            set { _bcomplete = value; }
            get { return _bcomplete; }
        }
        #endregion Model
    }
}
