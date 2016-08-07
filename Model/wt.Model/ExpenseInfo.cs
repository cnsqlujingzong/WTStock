using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class ExpenseInfo
	{
		private int _id;

		private int _deptid;

		private string __date;

		private int _operatorid;

		private decimal _dmoney;

		private string _summary;

		private string _status;

		private int _chkoperatorid;

		private string _chkdate;

		private int _paymentoperid;

		private string _paymentdate;

		private int _accountid;

		private int _itemid;

		private string _remark;

		private string _accessory;

		private string _relatedbusiness;

		private string _fromadr;

		private string _toadr;

		private List<ExpenseDetailInfo> _expenseindetailinfos;

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

		public string ChkDate
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

		public decimal dMoney
		{
			get
			{
				return this._dmoney;
			}
			set
			{
				this._dmoney = value;
			}
		}

		public List<ExpenseDetailInfo> ExpenseDetailInfos
		{
			get
			{
				return this._expenseindetailinfos;
			}
			set
			{
				this._expenseindetailinfos = value;
			}
		}

		public string FromAdr
		{
			get
			{
				return this._fromadr;
			}
			set
			{
				this._fromadr = value;
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

		public int ItemID
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

		public string PaymentDate
		{
			get
			{
				return this._paymentdate;
			}
			set
			{
				this._paymentdate = value;
			}
		}

		public int PaymentOperID
		{
			get
			{
				return this._paymentoperid;
			}
			set
			{
				this._paymentoperid = value;
			}
		}

		public string RelatedBusiness
		{
			get
			{
				return this._relatedbusiness;
			}
			set
			{
				this._relatedbusiness = value;
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

		public string ToAdr
		{
			get
			{
				return this._toadr;
			}
			set
			{
				this._toadr = value;
			}
		}

		public ExpenseInfo()
		{
		}
	}
}