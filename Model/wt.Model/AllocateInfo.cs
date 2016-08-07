using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class AllocateInfo
	{
		private int _id;

		private string _signeddate;

		private int? _signedoperid;

		private string _remark;

		private string _billid;

		private string __date;

		private int? _personid;

		private int? _fromdept;

		private int? _todept;

		private int? _status;

		private string _snddate;

		private int? _sndoperid;

		private int? _stockid;

		private List<AllocateDetailInfo> _allocatedetailinfos;

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

		public List<AllocateDetailInfo> AllocateDetailInfos
		{
			get
			{
				return this._allocatedetailinfos;
			}
			set
			{
				this._allocatedetailinfos = value;
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

		public int? FromDept
		{
			get
			{
				return this._fromdept;
			}
			set
			{
				this._fromdept = value;
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

		public string SignedDate
		{
			get
			{
				return this._signeddate;
			}
			set
			{
				this._signeddate = value;
			}
		}

		public int? SignedOperID
		{
			get
			{
				return this._signedoperid;
			}
			set
			{
				this._signedoperid = value;
			}
		}

		public string SndDate
		{
			get
			{
				return this._snddate;
			}
			set
			{
				this._snddate = value;
			}
		}

		public int? SndOperID
		{
			get
			{
				return this._sndoperid;
			}
			set
			{
				this._sndoperid = value;
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

		public int? ToDept
		{
			get
			{
				return this._todept;
			}
			set
			{
				this._todept = value;
			}
		}

		public AllocateInfo()
		{
		}
	}
}