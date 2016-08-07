using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class MaintenanceContractInfo
	{
		private int _id;

		private int _deptid;

		private string __date;

		private int _sellerid;

		private int _operatorid;

		private int _status;

		private int _customerid;

		private string _customername;

		private string _linkman;

		private string _tel;

		private string _adr;

		private string _contractno;

		private string _startdate;

		private string _enddate;

		private string _summary;

		private decimal _damount;

		private decimal _dincash;

		private string _accessory;

		private string _remark;

		private int _contracttypeid;

		private List<ContractDetailInfo> _contractdetailinfos;

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

		public List<ContractDetailInfo> ContractDetailInfos
		{
			get
			{
				return this._contractdetailinfos;
			}
			set
			{
				this._contractdetailinfos = value;
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

		public int ContractTypeID
		{
			get
			{
				return this._contracttypeid;
			}
			set
			{
				this._contracttypeid = value;
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

		public decimal dAmount
		{
			get
			{
				return this._damount;
			}
			set
			{
				this._damount = value;
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

		public decimal dInCash
		{
			get
			{
				return this._dincash;
			}
			set
			{
				this._dincash = value;
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

		public string Summary
		{
			get
			{
				return this._summary;
			}
			set
			{
				this._summary = value;
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

		public MaintenanceContractInfo()
		{
		}
	}
}