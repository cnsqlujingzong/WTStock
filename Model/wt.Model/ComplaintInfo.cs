using System;

namespace wt.Model
{
	public class ComplaintInfo
	{
		private int _id;

		private DateTime __date;

		private int _opetatorid;

		private string _customername;

		private string _linkman;

		private string _tel;

		private string _content;

		private string _operationid;

		private string _dooperator;

		private DateTime _dodate;

		private string _result;

		private string _measures;

		private string _status;

		private string _remark;

		private int _customerID;

		public DateTime _Date
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

		public string Content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
			}
		}

		public int CustomerID
		{
			get
			{
				return this._customerID;
			}
			set
			{
				this._customerID = value;
			}
		}

		public string CustomerName
		{
			get
			{
				return this._customername;
			}
			set
			{
				this._customername = value;
			}
		}

		public DateTime DoDate
		{
			get
			{
				return this._dodate;
			}
			set
			{
				this._dodate = value;
			}
		}

		public string DoOperator
		{
			get
			{
				return this._dooperator;
			}
			set
			{
				this._dooperator = value;
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

		public string LinkMan
		{
			get
			{
				return this._linkman;
			}
			set
			{
				this._linkman = value;
			}
		}

		public string Measures
		{
			get
			{
				return this._measures;
			}
			set
			{
				this._measures = value;
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

		public int OpetatorID
		{
			get
			{
				return this._opetatorid;
			}
			set
			{
				this._opetatorid = value;
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

		public string Result
		{
			get
			{
				return this._result;
			}
			set
			{
				this._result = value;
			}
		}

		public string Status
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

		public string Tel
		{
			get
			{
				return this._tel;
			}
			set
			{
				this._tel = value;
			}
		}

		public ComplaintInfo()
		{
		}
	}
}