using System;

namespace wt.Model
{
	public class ServicesPushInfo
	{
		private int _id;

		private int _billid;

		private string _linkman;

		private string _tel;

		private string __date;

		private int _ioperator;

		private string _result;

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

		public int BillID
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

		public int iOperator
		{
			get
			{
				return this._ioperator;
			}
			set
			{
				this._ioperator = value;
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

		public ServicesPushInfo()
		{
		}
	}
}