using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class StockOUTInfo
	{
		private int _id;

		private string _operationid;

		private DateTime? _chkdate;

		private int? _chkoperatorid;

		private string _remark;

		private int? _deptid;

		private string _billid;

		private string __date;

		private int? _operatorid;

		private int? _personid;

		private int? _reasonid;

		private int? _status;

		private string _type;
        private string _SendName;

        public string SendName
        {
            get { return _SendName; }
            set { _SendName = value; }
        }
        private string _SendNum;

        public string SendNum
        {
            get { return _SendNum; }
            set { _SendNum = value; }
        }
        private string _SendMoney;

        public string SendMoney
        {
            get { return _SendMoney; }
            set { _SendMoney = value; }
        }

		private List<StockOUTDetailInfo> _stockoutdetailinfos;

		public string _Date
		{
			get
			{
				return this.__date;
			}
			set
			{
				this.__date = value;
			}
		}

		public string BillID
		{
			get
			{
				return this._billid;
			}
			set
			{
				this._billid = value;
			}
		}

		public DateTime? ChkDate
		{
			get
			{
				return this._chkdate;
			}
			set
			{
				this._chkdate = value;
			}
		}

		public int? ChkOperatorID
		{
			get
			{
				return this._chkoperatorid;
			}
			set
			{
				this._chkoperatorid = value;
			}
		}

		public int? DeptID
		{
			get
			{
				return this._deptid;
			}
			set
			{
				this._deptid = value;
			}
		}

		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		public string OperationID
		{
			get
			{
				return this._operationid;
			}
			set
			{
				this._operationid = value;
			}
		}

		public int? OperatorID
		{
			get
			{
				return this._operatorid;
			}
			set
			{
				this._operatorid = value;
			}
		}

		public int? PersonID
		{
			get
			{
				return this._personid;
			}
			set
			{
				this._personid = value;
			}
		}

		public int? ReasonID
		{
			get
			{
				return this._reasonid;
			}
			set
			{
				this._reasonid = value;
			}
		}

		public string Remark
		{
			get
			{
				return this._remark;
			}
			set
			{
				this._remark = value;
			}
		}

		public int? Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}

		public List<StockOUTDetailInfo> StockOUTDetailInfos
		{
			get
			{
				return this._stockoutdetailinfos;
			}
			set
			{
				this._stockoutdetailinfos = value;
			}
		}

		public string Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		public StockOUTInfo()
		{
		}
	}
}