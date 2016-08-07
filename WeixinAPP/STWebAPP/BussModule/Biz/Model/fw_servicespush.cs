using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
   public class fw_servicespush
    {
        #region Model
        private int _id;
        private int _billid;
        private string _linkman;
        private DateTime? __date;
        private int? _ioperator;
        private string _result;
        private string _tel;
        private string _operator;
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
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? _Date
        {
            set { __date = value; }
            get { return __date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iOperator
        {
            set { _ioperator = value; }
            get { return _ioperator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        #endregion Model
    }
}
