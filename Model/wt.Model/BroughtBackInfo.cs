using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class BroughtBackInfo
	{
		private int _id;

		private int? _chkoperatorid;

		private string _remark;

		private string _billid;

		private int? _deptid;

		private string __date;

		private int? _personid;

		private int? _appid;

		private int? _type;

		private int? _status;

		private DateTime? _chkdate;

		private List<BroughtBackDetailInfo> _broughtbackdetailinfos;

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

		public int? AppID
		{
			get
			{
				return this._appid;
			}
			set
			{
				this._appid = value;
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

		public List<BroughtBackDetailInfo> BroughtBackDetailInfos
		{
			get
			{
				return this._broughtbackdetailinfos;
			}
			set
			{
				this._broughtbackdetailinfos = value;
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

		public int? Type
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

		public BroughtBackInfo()
		{
		}
	}
}