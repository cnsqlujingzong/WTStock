using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class SellInfo
	{
		private int _id;

		private DateTime _chkdate;

		private int _chkoperatorid;

		private int _status;

		private string _operationid;

		private string _remark;

		private int _deptid;

		private string _billid;

		private int _type;

		private string __date;

		private int _operatorid;

		private int _personid;
        public int isDai{get;set;}
		private int _customerid;

		private decimal _incash;

		private string _cusname;

		private string _autono;

		private int _sndoperatorid;

		private string _linkman;

		private string _tel;

		private string _adr;

		private string _invoiceno;

		private decimal _invoicemoney;

		private DateTime _invoicedate;

		private int _accountid;

		private bool _bcharged;

		private int _chargemodeid;

		private int _invoiceclassid;

		private List<SellDetailInfo> _selldetailinfos;
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
              public int CustomerID2{get;set;} 
              public string LinkMan2 {get;set;} 
              public string Tel2 {get;set;}
              public string Adr2 { get; set; }
              public string CusName2 { get; set; }
		public int AccountID
		{
			get
			{
				return this._accountid;
			}
			set
			{
				this._accountid = value;
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

		public string AutoNO
		{
			get
			{
				return this._autono;
			}
			set
			{
				this._autono = value;
			}
		}

		public bool bCharged
		{
			get
			{
				return this._bcharged;
			}
			set
			{
				this._bcharged = value;
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

		public int ChargeModeID
		{
			get
			{
				return this._chargemodeid;
			}
			set
			{
				this._chargemodeid = value;
			}
		}

		public DateTime ChkDate
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

		public int ChkOperatorID
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

		public string CusName
		{
			get
			{
				return this._cusname;
			}
			set
			{
				this._cusname = value;
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

		public decimal InCash
		{
			get
			{
				return this._incash;
			}
			set
			{
				this._incash = value;
			}
		}

		public int InvoiceClassID
		{
			get
			{
				return this._invoiceclassid;
			}
			set
			{
				this._invoiceclassid = value;
			}
		}

		public DateTime InvoiceDate
		{
			get
			{
				return this._invoicedate;
			}
			set
			{
				this._invoicedate = value;
			}
		}

		public decimal InvoiceMoney
		{
			get
			{
				return this._invoicemoney;
			}
			set
			{
				this._invoicemoney = value;
			}
		}

		public string InvoiceNO
		{
			get
			{
				return this._invoiceno;
			}
			set
			{
				this._invoiceno = value;
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

		public int PersonID
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

		public List<SellDetailInfo> SellDetailInfos
		{
			get
			{
				return this._selldetailinfos;
			}
			set
			{
				this._selldetailinfos = value;
			}
		}

		public int SndOperatorID
		{
			get
			{
				return this._sndoperatorid;
			}
			set
			{
				this._sndoperatorid = value;
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

		public SellInfo()
		{
		}
	}
}