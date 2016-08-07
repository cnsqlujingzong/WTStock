using System;
using System.Collections.Generic;

namespace wt.Model
{
	[Serializable]
	public class SupplierListInfo
	{
		private int _id;

		private int _deptid;

		private string _supno;

		private string __name;

		private int? _classid;

		private string _class;

		private string _linkman;

		private string _tel;

		private string _tel2;

		private string _adr;

		private string _zip;

		private string _fax;

		private string _email;

		private string _account;

		private bool _bsupplier;

		private bool _bchargecorp;

		private bool _btransmitcorp;

		private string _pycode;

		private bool _bstop;

		private string _remark;

		private List<SupplierLinkManInfo> _Supplierlinkmaninfos;

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

		public bool bChargeCorp
		{
			get
			{
				return this._bchargecorp;
			}
			set
			{
				this._bchargecorp = value;
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

		public bool bSupplier
		{
			get
			{
				return this._bsupplier;
			}
			set
			{
				this._bsupplier = value;
			}
		}

		public bool bTransmitCorp
		{
			get
			{
				return this._btransmitcorp;
			}
			set
			{
				this._btransmitcorp = value;
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

		public string SupNO
		{
			get
			{
				return this._supno;
			}
			set
			{
				this._supno = value;
			}
		}

		public List<SupplierLinkManInfo> SupplierLinkManInfos
		{
			get
			{
				return this._Supplierlinkmaninfos;
			}
			set
			{
				this._Supplierlinkmaninfos = value;
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

		public SupplierListInfo()
		{
		}
	}
}