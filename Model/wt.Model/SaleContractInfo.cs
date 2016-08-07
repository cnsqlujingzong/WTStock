using System;

namespace wt.Model
{
	public class SaleContractInfo
	{
		private int _id;

		private int _deptID;

		private DateTime _date;

		private int _sellerID;

		private int _operatorID;

		private int _status;

		private int _customerID;

		private string _customerName;

		private string _linkMan;

		private string _tel;

		private string _adr;

		private string _contractType;

		private string _contractNO;

		private DateTime _startDate;

		private DateTime _endDate;

		private string _summary;

		private decimal _damount;

		private decimal _dinCash;

		private string _accessory;

		private string _remark;
        private string _brandName;

        public string BrandName
        {
            get { return _brandName; }
            set { _brandName = value; }
        }
        private decimal _brandTaxRate;

        public decimal BrandTaxRate
        {
            get { return _brandTaxRate; }
            set { _brandTaxRate = value; }
        }
        private string _brandTaxRateType;

        public string BrandTaxRateType
        {
            get { return _brandTaxRateType; }
            set { _brandTaxRateType = value; }
        }
		private string _termRemark;

		public DateTime _Date
		{
			get
			{
				return this._date;
			}
			set
			{
				this._date = value;
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

		public string ContractNO
		{
			get
			{
				return this._contractNO;
			}
			set
			{
				this._contractNO = value;
			}
		}

		public string ContractType
		{
			get
			{
				return this._contractType;
			}
			set
			{
				this._contractType = value;
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
				return this._customerName;
			}
			set
			{
				this._customerName = value;
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
				return this._deptID;
			}
			set
			{
				this._deptID = value;
			}
		}

		public decimal dInCash
		{
			get
			{
				return this._dinCash;
			}
			set
			{
				this._dinCash = value;
			}
		}

		public DateTime EndDate
		{
			get
			{
				return this._endDate;
			}
			set
			{
				this._endDate = value;
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
				return this._linkMan;
			}
			set
			{
				this._linkMan = value;
			}
		}

		public int OperatorID
		{
			get
			{
				return this._operatorID;
			}
			set
			{
				this._operatorID = value;
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
				return this._sellerID;
			}
			set
			{
				this._sellerID = value;
			}
		}

		public DateTime StartDate
		{
			get
			{
				return this._startDate;
			}
			set
			{
				this._startDate = value;
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

		public string termRemark
		{
			get
			{
				return this._termRemark;
			}
			set
			{
				this._termRemark = value;
			}
		}

		public SaleContractInfo()
		{
		}
	}
}