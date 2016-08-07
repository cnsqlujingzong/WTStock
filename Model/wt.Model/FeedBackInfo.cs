using System;

namespace wt.Model
{
	public class FeedBackInfo
	{
		private int _id;

		private int _deptID;

		private string _createDate;

		private string _createOperator;

		private string _checkDate;

		private string _checkOperator;

		private string _context;

		private string _deptName;

		private int _curStatus;

		private string _remark;

		public string CheckDate
		{
			get
			{
				return this._checkDate;
			}
			set
			{
				this._checkDate = value;
			}
		}

		public string CheckOperator
		{
			get
			{
				return this._checkOperator;
			}
			set
			{
				this._checkOperator = value;
			}
		}

		public string Context
		{
			get
			{
				return this._context;
			}
			set
			{
				this._context = value;
			}
		}

		public string CreateDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				this._createDate = value;
			}
		}

		public string CreateOperator
		{
			get
			{
				return this._createOperator;
			}
			set
			{
				this._createOperator = value;
			}
		}

		public int curStatus
		{
			get
			{
				return this._curStatus;
			}
			set
			{
				this._curStatus = value;
			}
		}

		public int DeptID
		{
			get
			{
				return this._deptID;
			}
			set
			{
				this._deptID = value;
			}
		}

		public string DeptName
		{
			get
			{
				return this._deptName;
			}
			set
			{
				this._deptName = value;
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

		public FeedBackInfo()
		{
		}
	}
}