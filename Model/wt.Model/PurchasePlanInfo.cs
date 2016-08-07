using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class PurchasePlanInfo
	{
		private int _id;

		private int? _status;

		private bool _bend;

		private string _remark;

		private int? _deptid;

		private string _billid;

		private string __date;

		private int? _operatorid;

		private int? _provid;

		private int? _stockid;

		private DateTime? _chkdate;

		private int? _chkoperatorid;

		private string _supname;

		private List<PurchasePlanDetailInfo> _purchaseplandetailinfos;

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

		public bool bEnd
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

		public List<PurchasePlanDetailInfo> PurchasePlanDetailInfos
		{
			get
			{
				return this._purchaseplandetailinfos;
			}
			set
			{
				this._purchaseplandetailinfos = value;
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

		public PurchasePlanInfo()
		{
		}
	}
}