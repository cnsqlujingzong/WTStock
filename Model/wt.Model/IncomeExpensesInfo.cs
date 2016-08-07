using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class IncomeExpensesInfo
	{
		private int _id;

		private string _billid;

		private int? _deptid;

		private string _type;

		private string _rectype;

		private string __date;

		private int? _personid;

		private int? _custype;

		private int? _customerid;

		private decimal _recmoney;

		private decimal _realrecmoney;

		private decimal _premoney;

		private decimal _duemoney;

		private decimal _realduemoney;

		private int? _chargemodeid;

		private int? _accountid;

		private int? _itemid;

		private int? _invoiceclassid;

		private string _invoiceno;

		private string _checkno;

		private string _voucherno;

		private DateTime? _chkdate;

		private int? _chkoperatorid;

		private int? _status;

		private string _remark;

		private string _customername;

		private decimal _invoiceamount;

		private string _invoicedate;

		private List<CiteAccountInfo> _citeaccountinfos;

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

		public int? AccountID
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

		public int? ChargeModeID
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

		public string CheckNO
		{
			get
			{
				return this._checkno;
			}
			set
			{
				this._checkno = value;
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

		public List<CiteAccountInfo> CiteAccountInfos
		{
			get
			{
				return this._citeaccountinfos;
			}
			set
			{
				this._citeaccountinfos = value;
			}
		}

		public int? CustomerID
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

		public int? CusType
		{
			get
			{
				return this._custype;
			}
			set
			{
				this._custype = value;
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

		public decimal DueMoney
		{
			get
			{
				return this._duemoney;
			}
			set
			{
				this._duemoney = value;
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

		public decimal InvoiceAmount
		{
			get
			{
				return this._invoiceamount;
			}
			set
			{
				this._invoiceamount = value;
			}
		}

		public int? InvoiceClassID
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

		public string InvoiceDate
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

		public int? ItemID
		{
			get
			{
				return this._itemid;
			}
			set
			{
				this._itemid = value;
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

		public decimal PreMoney
		{
			get
			{
				return this._premoney;
			}
			set
			{
				this._premoney = value;
			}
		}

		public decimal RealDueMoney
		{
			get
			{
				return this._realduemoney;
			}
			set
			{
				this._realduemoney = value;
			}
		}

		public decimal RealRecMoney
		{
			get
			{
				return this._realrecmoney;
			}
			set
			{
				this._realrecmoney = value;
			}
		}

		public decimal RecMoney
		{
			get
			{
				return this._recmoney;
			}
			set
			{
				this._recmoney = value;
			}
		}

		public string RecType
		{
			get
			{
				return this._rectype;
			}
			set
			{
				this._rectype = value;
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

		public string VoucherNO
		{
			get
			{
				return this._voucherno;
			}
			set
			{
				this._voucherno = value;
			}
		}

		public IncomeExpensesInfo()
		{
		}
	}
}