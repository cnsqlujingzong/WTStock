using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class CustomerListInfo
	{
		private int _id;

		private string _zip;

		private string _fax;

		private string _email;

		private string _account;

		private string _area;

		private int? _fromid;

		private int? _sellerid;

		private int? _deptid;

		private DateTime? __date;

		private string _pycode;

		private bool _bstop;

		private string _remark;

		private int? _classid;

		private string _class;

		private string _customerno;

		private string __name;

		private string _linkman;

		private string _tel;

		private string _tel2;

		private string _adr;

		private bool _bcall;

		private string _coordinates;

		private int _memberid;

		private int _statusid;

		private string _userdef1;

		private string _userdef2;

		private string _userdef3;

		private string _userdef4;

		private string _userdef5;

		private string _userdef6;

		private int _trackOperatorid;

		private bool _btrack;

		private string _qq;

		private int _operatorid;

		private int _branchid;

		private decimal _positionAmount;



     public string    pay_info	{get;set;}
    public string pay_type		{get;set;}
    public string pay_date		{get;set;}
    public string pay_yanshou		{get;set;}
    public string pay_tiexi	{get;set;}
    public string pay_fapiao		{get;set;}
    public string pay_ren { get; set; }
    public string jieshao { get; set; }



		private List<CustomerLinkManInfo> _customerlinkmaninfos;

		private List<DeviceListInfo> _devicelistinfos;

		public DateTime? _Date
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

		public string _Name
		{
			get
			{
				return this.__name;
			}
			set
			{
				this.__name = value;
			}
		}

		public string Account
		{
			get
			{
				return this._account;
			}
			set
			{
				this._account = value;
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

		public string Area
		{
			get
			{
				return this._area;
			}
			set
			{
				this._area = value;
			}
		}

		public bool bCall
		{
			get
			{
				return this._bcall;
			}
			set
			{
				this._bcall = value;
			}
		}

		public int BranchID
		{
			get
			{
				return this._branchid;
			}
			set
			{
				this._branchid = value;
			}
		}

		public bool bStop
		{
			get
			{
				return this._bstop;
			}
			set
			{
				this._bstop = value;
			}
		}

		public bool bTrack
		{
			get
			{
				return this._btrack;
			}
			set
			{
				this._btrack = value;
			}
		}

		public string Class
		{
			get
			{
				return this._class;
			}
			set
			{
				this._class = value;
			}
		}

		public int? ClassID
		{
			get
			{
				return this._classid;
			}
			set
			{
				this._classid = value;
			}
		}

		public string Coordinates
		{
			get
			{
				return this._coordinates;
			}
			set
			{
				this._coordinates = value;
			}
		}

		public List<CustomerLinkManInfo> CustomerLinkManInfos
		{
			get
			{
				return this._customerlinkmaninfos;
			}
			set
			{
				this._customerlinkmaninfos = value;
			}
		}

		public string CustomerNO
		{
			get
			{
				return this._customerno;
			}
			set
			{
				this._customerno = value;
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

		public List<DeviceListInfo> DeviceListInfos
		{
			get
			{
				return this._devicelistinfos;
			}
			set
			{
				this._devicelistinfos = value;
			}
		}

		public string Email
		{
			get
			{
				return this._email;
			}
			set
			{
				this._email = value;
			}
		}

		public string Fax
		{
			get
			{
				return this._fax;
			}
			set
			{
				this._fax = value;
			}
		}

		public int? FromID
		{
			get
			{
				return this._fromid;
			}
			set
			{
				this._fromid = value;
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

		public int MemberID
		{
			get
			{
				return this._memberid;
			}
			set
			{
				this._memberid = value;
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

		public decimal PositionAmount
		{
			get
			{
				return this._positionAmount;
			}
			set
			{
				this._positionAmount = value;
			}
		}

		public string pyCode
		{
			get
			{
				return this._pycode;
			}
			set
			{
				this._pycode = value;
			}
		}

		public string QQ
		{
			get
			{
				return this._qq;
			}
			set
			{
				this._qq = value;
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

		public int? SellerID
		{
			get
			{
				return this._sellerid;
			}
			set
			{
				this._sellerid = value;
			}
		}

		public int StatusID
		{
			get
			{
				return this._statusid;
			}
			set
			{
				this._statusid = value;
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

		public string Tel2
		{
			get
			{
				return this._tel2;
			}
			set
			{
				this._tel2 = value;
			}
		}

		public int TrackOperatorID
		{
			get
			{
				return this._trackOperatorid;
			}
			set
			{
				this._trackOperatorid = value;
			}
		}

		public string userdef1
		{
			get
			{
				return this._userdef1;
			}
			set
			{
				this._userdef1 = value;
			}
		}

		public string userdef2
		{
			get
			{
				return this._userdef2;
			}
			set
			{
				this._userdef2 = value;
			}
		}

		public string userdef3
		{
			get
			{
				return this._userdef3;
			}
			set
			{
				this._userdef3 = value;
			}
		}

		public string userdef4
		{
			get
			{
				return this._userdef4;
			}
			set
			{
				this._userdef4 = value;
			}
		}

		public string userdef5
		{
			get
			{
				return this._userdef5;
			}
			set
			{
				this._userdef5 = value;
			}
		}

		public string userdef6
		{
			get
			{
				return this._userdef6;
			}
			set
			{
				this._userdef6 = value;
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

		public CustomerListInfo()
		{
		}
	}
}