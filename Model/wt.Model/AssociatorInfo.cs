using System;

namespace wt.Model
{
	public class AssociatorInfo
	{
		private int _id;

		private string __name;

		private string _password;

		private string _company;

		private string _linkman;

		private string _tel;

		private string _adr;

		private string _email;

		private int _customerid;

		private bool _iflag;

		private string _customerno;

		private string _customername;

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

		public string Company
		{
			get
			{
				return this._company;
			}
			set
			{
				this._company = value;
			}
		}

		public int CustomerID
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

		public string CustomerName
		{
			get
			{
				return this._customername;
			}
			set
			{
				this._customername = value;
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

		public bool iFlag
		{
			get
			{
				return this._iflag;
			}
			set
			{
				this._iflag = value;
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

		public string Password
		{
			get
			{
				return this._password;
			}
			set
			{
				this._password = value;
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

		public AssociatorInfo()
		{
		}
	}
}