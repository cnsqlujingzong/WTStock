using System;

namespace wt.Model
{
	[Serializable]
	public class RepositoryInfo
	{
		private int _id;

		private int _deptid;

		private int _classid;

		private int _authorid;

		private string _title;

		private DateTime __date;

		private string _content;

		private int _hit;

		private int _accesslevel;

		private bool _btechnician;

		private bool _bseller;

		private bool _bstockman;

		private bool _bdestclerk;

		private bool _baccountant;

		public DateTime _Date
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

		public int AccessLevel
		{
			get
			{
				return this._accesslevel;
			}
			set
			{
				this._accesslevel = value;
			}
		}

		public int AuthorID
		{
			get
			{
				return this._authorid;
			}
			set
			{
				this._authorid = value;
			}
		}

		public bool bAccountant
		{
			get
			{
				return this._baccountant;
			}
			set
			{
				this._baccountant = value;
			}
		}

		public bool bDestClerk
		{
			get
			{
				return this._bdestclerk;
			}
			set
			{
				this._bdestclerk = value;
			}
		}

		public bool bSeller
		{
			get
			{
				return this._bseller;
			}
			set
			{
				this._bseller = value;
			}
		}

		public bool bStockMan
		{
			get
			{
				return this._bstockman;
			}
			set
			{
				this._bstockman = value;
			}
		}

		public bool bTechnician
		{
			get
			{
				return this._btechnician;
			}
			set
			{
				this._btechnician = value;
			}
		}

		public int ClassID
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

		public string Content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
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

		public int Hit
		{
			get
			{
				return this._hit;
			}
			set
			{
				this._hit = value;
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

		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
			}
		}

		public RepositoryInfo()
		{
		}
	}
}