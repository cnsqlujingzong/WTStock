using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
  public  class fw_servicesprocess
    {
        #region Model
        private int _id;
        private int _billid;
        private string _dostyle;
        private int? _deptid;
        private string _dept;
        private int? _ioperator;
        private string _operator;
        private DateTime? __date;
        private string _reason;
        private string _takesteps;
        private DateTime? _arrivedtime;
        private string _person;
        private string _dodept;
        private string _dooperator;
        private DateTime? _visitdate;
        private string _spending;
        private int? _idays;
        private decimal? _ihours;
        private DateTime? _starttime;
        private string _course;
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
        public string DoStyle
        {
            set { _dostyle = value; }
            get { return _dostyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DeptID
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Dept
        {
            set { _dept = value; }
            get { return _dept; }
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
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
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
        public string Reason
        {
            set { _reason = value; }
            get { return _reason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TakeSteps
        {
            set { _takesteps = value; }
            get { return _takesteps; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ArrivedTime
        {
            set { _arrivedtime = value; }
            get { return _arrivedtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Person
        {
            set { _person = value; }
            get { return _person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DoDept
        {
            set { _dodept = value; }
            get { return _dodept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DoOperator
        {
            set { _dooperator = value; }
            get { return _dooperator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? visitdate
        {
            set { _visitdate = value; }
            get { return _visitdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spending
        {
            set { _spending = value; }
            get { return _spending; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iDays
        {
            set { _idays = value; }
            get { return _idays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iHours
        {
            set { _ihours = value; }
            get { return _ihours; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Course
        {
            set { _course = value; }
            get { return _course; }
        }
        #endregion Model
    }
}
