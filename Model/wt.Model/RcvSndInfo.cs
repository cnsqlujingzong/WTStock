using System;

namespace wt.Model
{
	[Serializable]
	public class RcvSndInfo
	{
		private int _id;

		private string _billid;

		private int? _deptid;

		private string __date;

		private int? _operatorid;

		private int? _personid;

		private string _operationtype;

		private string _rcvtype;

		private int? _sndstyleid;

		private string _postno;

		private decimal? _postage;

		private int? _rcvdeptid;

		private string _corpname;

		private string _linkman;

		private string _tel;

		private string _adr;

		private string _zip;

		private string _summary;

		private int? _status;

		private string _rcvdate;

		private int? _signmanid;

		private string _remark;

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

		public string CorpName
		{
			get
			{
				return this._corpname;
			}
			set
			{
				this._corpname = value;
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

		public string OperationType
		{
			get
			{
				return this._operationtype;
			}
			set
			{
				this._operationtype = value;
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

		public decimal? Postage
		{
			get
			{
				return this._postage;
			}
			set
			{
				this._postage = value;
			}
		}

		public string PostNO
		{
			get
			{
				return this._postno;
			}
			set
			{
				this._postno = value;
			}
		}

		public string RcvDate
		{
			get
			{
				return this._rcvdate;
			}
			set
			{
				this._rcvdate = value;
			}
		}

		public int? RcvDeptID
		{
			get
			{
				return this._rcvdeptid;
			}
			set
			{
				this._rcvdeptid = value;
			}
		}

		public string RcvType
		{
			get
			{
				return this._rcvtype;
			}
			set
			{
				this._rcvtype = value;
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

		public int? SignManID
		{
			get
			{
				return this._signmanid;
			}
			set
			{
				this._signmanid = value;
			}
		}

		public int? SndStyleID
		{
			get
			{
				return this._sndstyleid;
			}
			set
			{
				this._sndstyleid = value;
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

		public string Zip
		{
			get
			{
				return this._zip;
			}
			set
			{
				this._zip = value;
			}
		}

		public RcvSndInfo()
		{
		}
	}
}