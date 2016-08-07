using System;

namespace wt.Model
{
	public class CustomerTrackInfo
	{
		private int _id;

		private DateTime __date;

		private int _operatorid;

		private int _customerid;

		private string _linkman;

		private string _tel;

		private int _trackstyleid;

		private int _tracktypeid;

		private string _content;

		private string _result;

		private string _nexttrack;

		private bool _btrack;

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

		public string NextTrack
		{
			get
			{
				return this._nexttrack;
			}
			set
			{
				this._nexttrack = value;
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

		public string Result
		{
			get
			{
				return this._result;
			}
			set
			{
				this._result = value;
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

		public int TrackStyleID
		{
			get
			{
				return this._trackstyleid;
			}
			set
			{
				this._trackstyleid = value;
			}
		}

		public int TrackTypeID
		{
			get
			{
				return this._tracktypeid;
			}
			set
			{
				this._tracktypeid = value;
			}
		}

		public CustomerTrackInfo()
		{
		}
	}
}