using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class PurchaseInfo
	{
		private int _id;

		private DateTime? _chkdate;

		private int? _chkoperatorid;

		private int? _status;

		private string _remark;

		private int? _deptid;

		private string _billid;

		private int _type;

		private string __date;

		private int? _operatorid;

		private int? _provid;

		private int? _stockid;

		private string _operationid;

		private string _supname;

		private decimal _incash;

		private int _planid;

		private string _invoiceNO;

		private decimal _invoiceMoney;

		private DateTime _invoiceDate;

		private int? _accountID;

		private int? _invoiceClassID;

		private int? _chargeModeID;

		private string _linkMan;

		private string _tel;

		private List<PurchaseDetailInfo> _purchasedetailinfos;

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
				return this._accountID;
			}
			set
			{
				this._accountID = value;
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
				return this._chargeModeID;
			}
			set
			{
				this._chargeModeID = value;
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

		public int? InvoiceClassID
		{
			get
			{
				return this._invoiceClassID;
			}
			set
			{
				this._invoiceClassID = value;
			}
		}

		public DateTime InvoiceDate
		{
			get
			{
				return this._invoiceDate;
			}
			set
			{
				this._invoiceDate = value;
			}
		}

		public decimal InvoiceMoney
		{
			get
			{
				return this._invoiceMoney;
			}
			set
			{
				this._invoiceMoney = value;
			}
		}

		public string InvoiceNO
		{
			get
			{
				return this._invoiceNO;
			}
			set
			{
				this._invoiceNO = value;
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

		public int PlanID
		{
			get
			{
				return this._planid;
			}
			set
			{
				this._planid = value;
			}
		}

		public int? ProvID
		{
			get
			{
				return this._provid;
			}
			set
			{
				this._provid = value;
			}
		}

		public List<PurchaseDetailInfo> PurchaseDetailInfos
		{
			get
			{
				return this._purchasedetailinfos;
			}
			set
			{
				this._purchasedetailinfos = value;
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

		public int? StockID
		{
			get
			{
				return this._stockid;
			}
			set
			{
				this._stockid = value;
			}
		}

		public string SupName
		{
			get
			{
				return this._supname;
			}
			set
			{
				this._supname = value;
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

		public PurchaseInfo()
		{
		}
	}
}