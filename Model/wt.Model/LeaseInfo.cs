using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class LeaseInfo
	{
		private int _id;

		private string _billid;

		private int _deptid;

		private int _status;

		private int _chargestatus;

		private string __date;

		private int _type;

		private int _sellerid;

		private int _operatorid;

		private int _customerid;

		private string _customername;

		private string _linkman;

		private string _tel;

		private string _adr;

		private string _contractno;

		private string _startdate;

		private string _enddate;

		private decimal _rent;

		private decimal _deposit;

		private int _chargestyle;

		private int _chargecycle;

		private int _rated;

		private string _remark;

		private string _accessory;

		private List<LeaseDeviceInfo> _leasedeviceinfos;

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

		public string Accessory
		{
			get
			{
				return this._accessory;
			}
			set
			{
				this._accessory = value;
			}
		}

		public string Adr
		{
			get
			{
				return this._adr;
			}
			set
			{
				this._adr = value;
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

		public int ChargeCycle
		{
			get
			{
				return this._chargecycle;
			}
			set
			{
				this._chargecycle = value;
			}
		}

		public int ChargeStatus
		{
			get
			{
				return this._chargestatus;
			}
			set
			{
				this._chargestatus = value;
			}
		}

		public int ChargeStyle
		{
			get
			{
				return this._chargestyle;
			}
			set
			{
				this._chargestyle = value;
			}
		}

		public string ContractNO
		{
			get
			{
				return this._contractno;
			}
			set
			{
				this._contractno = value;
			}
		}

		public int CustomerID
		{
			get
			{
				return this._customerid;
			}
			set
			{
				this._customerid = value;
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

		public decimal Deposit
		{
			get
			{
				return this._deposit;
			}
			set
			{
				this._deposit = value;
			}
		}

		public int DeptID
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

		public string EndDate
		{
			get
			{
				return this._enddate;
			}
			set
			{
				this._enddate = value;
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

		public List<LeaseDeviceInfo> LeaseDeviceInfos
		{
			get
			{
				return this._leasedeviceinfos;
			}
			set
			{
				this._leasedeviceinfos = value;
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

		public int OperatorID
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

		public int Rated
		{
			get
			{
				return this._rated;
			}
			set
			{
				this._rated = value;
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

		public decimal Rent
		{
			get
			{
				return this._rent;
			}
			set
			{
				this._rent = value;
			}
		}

		public int SellerID
		{
			get
			{
				return this._sellerid;
			}
			set
			{
				this._sellerid = value;
			}
		}

		public string StartDate
		{
			get
			{
				return this._startdate;
			}
			set
			{
				this._startdate = value;
			}
		}

		public int Status
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

		public int Type
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

		public LeaseInfo()
		{
		}
	}
}