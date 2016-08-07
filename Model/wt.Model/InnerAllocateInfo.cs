using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class InnerAllocateInfo
	{
		private int _id;

		private int _deptid;

		private DateTime _chkdate;

		private int _chkoperatorid;

		private string _remark;

		private string _billid;

		private string __date;

		private int _operatorid;

		private int _personid;

		private int _stockoutid;

		private int _status;

		private int _stockinid;

		private List<InnerAllocateDetailInfo> _innerallocatedetailinfos;

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

		public List<InnerAllocateDetailInfo> InnerAllocateDetailInfos
		{
			get
			{
				return this._innerallocatedetailinfos;
			}
			set
			{
				this._innerallocatedetailinfos = value;
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

		public int StockInID
		{
			get
			{
				return this._stockinid;
			}
			set
			{
				this._stockinid = value;
			}
		}

		public int StockOutID
		{
			get
			{
				return this._stockoutid;
			}
			set
			{
				this._stockoutid = value;
			}
		}

		public InnerAllocateInfo()
		{
		}
	}
}