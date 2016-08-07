using System;

namespace wt.Model
{
	public class CustomerLinkManInfo
	{
		private int _id;

		private string _fax;

		private string _email;

		private string _birthday;

		private string _remark;

		private int? _customerid;

		private string __name;

		private string _linkmandept;

		private string _sex;

		private string _posit;

		private string _tel_office;

		private string _tel_home;

		private string _tel_mobile;

		private string _adr;

        private string _tel_mobile1;

        public string Tel_mobile1
        {
            get { return _tel_mobile1; }
            set { _tel_mobile1 = value; }
        }
        private string _tel_mobile2;

        public string Tel_mobile2
        {
            get { return _tel_mobile2; }
            set { _tel_mobile2 = value; }
        }
        private string _tel_qq;

        public string Tel_qq
        {
            get { return _tel_qq; }
            set { _tel_qq = value; }
        }
        private string _tel_weixin;

        public string Tel_weixin
        {
            get { return _tel_weixin; }
            set { _tel_weixin = value; }
        }
        private string _tel_padr;

        public string Tel_padr
        {
            get { return _tel_padr; }
            set { _tel_padr = value; }
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

		public string Birthday
		{
			get
			{
				return this._birthday;
			}
			set
			{
				this._birthday = value;
			}
		}

		public int? CustomerID
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

		public string LinkManDept
		{
			get
			{
				return this._linkmandept;
			}
			set
			{
				this._linkmandept = value;
			}
		}

		public string Posit
		{
			get
			{
				return this._posit;
			}
			set
			{
				this._posit = value;
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

		public string Sex
		{
			get
			{
				return this._sex;
			}
			set
			{
				this._sex = value;
			}
		}

		public string tel_Home
		{
			get
			{
				return this._tel_home;
			}
			set
			{
				this._tel_home = value;
			}
		}

		public string tel_Mobile
		{
			get
			{
				return this._tel_mobile;
			}
			set
			{
				this._tel_mobile = value;
			}
		}

		public string tel_Office
		{
			get
			{
				return this._tel_office;
			}
			set
			{
				this._tel_office = value;
			}
		}

		public CustomerLinkManInfo()
		{
		}
	}
}