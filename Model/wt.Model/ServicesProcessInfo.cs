using System;

namespace wt.Model
{
	public class ServicesProcessInfo
	{
		private int _id;

		private int _billid;

		private string _dostyle;

		private int _deptid;

		private int _ioperator;

		private DateTime __date;

		private int _dostatus;

		private string _reason;

		private string _takesteps;

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

		public int DoStatus
		{
			get
			{
				return this._dostatus;
			}
			set
			{
				this._dostatus = value;
			}
		}

		public string DoStyle
		{
			get
			{
				return this._dostyle;
			}
			set
			{
				this._dostyle = value;
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

		public string Reason
		{
			get
			{
				return this._reason;
			}
			set
			{
				this._reason = value;
			}
		}

		public string TakeSteps
		{
			get
			{
				return this._takesteps;
			}
			set
			{
				this._takesteps = value;
			}
		}

		public ServicesProcessInfo()
		{
		}
	}
}