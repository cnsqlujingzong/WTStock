using System;
using System.Collections.Generic;

namespace wt.Model
{
	[Serializable]
	public class LendingReturnInfo
	{
		private int _id;

		private int _istock;

		private string _operationid = "";

		private string _wdate;

		private decimal _deposit = new decimal(0);

		private string _remark = "";

		private string _billid;

		private string __date;

		private int _ioperator;

		private int _iperson;

		private int _customerid;

		private string _linkman = "";

		private string _tel = "";

		private int _deptid;

		private string _curstatus;

		private List<LendingReturnDetailInfo> _lendingreturndetailinfos;

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

		public string curStatus
		{
			get
			{
				return this._curstatus;
			}
			set
			{
				this._curstatus = value;
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

		public int iOperator
		{
			get
			{
				return this._ioperator;
			}
			set
			{
				this._ioperator = value;
			}
		}

		public int iPerson
		{
			get
			{
				return this._iperson;
			}
			set
			{
				this._iperson = value;
			}
		}

		public int iStock
		{
			get
			{
				return this._istock;
			}
			set
			{
				this._istock = value;
			}
		}

		public List<LendingReturnDetailInfo> LendingReturnDetailInfos
		{
			get
			{
				return this._lendingreturndetailinfos;
			}
			set
			{
				this._lendingreturndetailinfos = value;
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

		public string WDate
		{
			get
			{
				return this._wdate;
			}
			set
			{
				this._wdate = value;
			}
		}

		public LendingReturnInfo()
		{
		}
	}
}