using System;

namespace wt.Model
{
	public class SupplierLinkManInfo
	{
		private int _id;

		private string _fax;

		private string _email;

		private string _birthday;

		private string _remark;

		private int _Supplierid;

		private string __name;

		private string _linkmandept;

		private string _sex;

		private string _posit;

		private string _tel_office;

		private string _tel_home;

		private string _tel_mobile;

		private string _adr;

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

		public int SupplierID
		{
			get
			{
				return this._Supplierid;
			}
			set
			{
				this._Supplierid = value;
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

		public SupplierLinkManInfo()
		{
		}
	}
}