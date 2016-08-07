using System;

namespace wt.Model
{
	[Serializable]
	public class BranchListInfo
	{
		private int _id;

		private string __name;

		private string _branchno;

		private string _corpname;

		private string _linkman;

		private string _tel;

		private string _adr;

		private string _zip;

		private string _fax;

		private string _email;

		private string _account;

		private string _area;

		private bool _bstop;

		private string _remark;

		private string _pycode;

		private bool _bbranchpurchase;

		private bool _bgoodsadd;

		private int _arrayID;
        private decimal _tR_jsfw;
        public decimal TR_jsfw
        {
            get { return _tR_jsfw; }
            set { _tR_jsfw = value; }
        }
         private decimal _tR_zzsxx;
        public decimal TR_zzsxx
        {
            get { return _tR_zzsxx; }
            set { _tR_zzsxx = value; }
        }
            private decimal _tR_zzsjx;
        public decimal TR_zzsjx
        {
            get { return _tR_zzsjx; }
            set { _tR_zzsjx = value; }
        }
            private decimal _tR_ptfp;
        public decimal TR_ptfp
        {
            get { return _tR_ptfp; }
            set { _tR_ptfp = value; }
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

		public int ArrayID
		{
			get
			{
				return this._arrayID;
			}
			set
			{
				this._arrayID = value;
			}
		}

		public bool bBranchPurchase
		{
			get
			{
				return this._bbranchpurchase;
			}
			set
			{
				this._bbranchpurchase = value;
			}
		}

		public bool bGoodsAdd
		{
			get
			{
				return this._bgoodsadd;
			}
			set
			{
				this._bgoodsadd = value;
			}
		}

		public string BranchNO
		{
			get
			{
				return this._branchno;
			}
			set
			{
				this._branchno = value;
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

		public BranchListInfo()
		{
		}
	}
}