using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
 public   class fw_serviceslog
    {
        #region Model
        private int _id;
        private int _billid;
        private int? _operatorid;
        private DateTime __date;
        private string _event;
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
        public int? OperatorID
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime _Date
        {
            set { __date = value; }
            get { return __date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Event
        {
            set { _event = value; }
            get { return _event; }
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
