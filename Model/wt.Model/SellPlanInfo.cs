using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class SellPlanInfo
	{
		private int _id;

		private string _remark;

		private int _deptid;

		private string _billid;

		private string __date;

		private int _operatorid;

		private int _customerid;

		private DateTime _chkdate;

		private int _chkoperatorid;

		private int _status;

		private string _cusname;

		private string _contractno;

		private int _bend;

		private int _sndoperatorid;

		private string _linkman;

		private string _tel;

		private string _adr;

		private List<SellPlanDetailInfo> _sellplandetailinfos;
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

		public int bEnd
		{
			get
			{
				return this._bend;
			}
			set
			{
				this._bend = value;
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

		public List<SellPlanDetailInfo> SellPlanDetailInfos
		{
			get
			{
				return this._sellplandetailinfos;
			}
			set
			{
				this._sellplandetailinfos = value;
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

		public SellPlanInfo()
		{
		}
	}
}