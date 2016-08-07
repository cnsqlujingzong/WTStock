using System;

namespace wt.Model
{
	public class TaskListInfo
	{
		private int _id;

		private int _deptid;

		private DateTime __date;

		private int _operatorid;

		private DateTime _exedate;

		private int _exerid;

		private string _status;

		private string _summary;

		private string _completerate;

		private string _taskremark;

		private string _executeremark;

		private string _score;

		private string _remark;

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

		public string CompleteRate
		{
			get
			{
				return this._completerate;
			}
			set
			{
				this._completerate = value;
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

		public string executeRemark
		{
			get
			{
				return this._executeremark;
			}
			set
			{
				this._executeremark = value;
			}
		}

		public DateTime ExeDate
		{
			get
			{
				return this._exedate;
			}
			set
			{
				this._exedate = value;
			}
		}

		public int ExerID
		{
			get
			{
				return this._exerid;
			}
			set
			{
				this._exerid = value;
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

		public string Score
		{
			get
			{
				return this._score;
			}
			set
			{
				this._score = value;
			}
		}

		public string Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}

		public string Summary
		{
			get
			{
				return this._summary;
			}
			set
			{
				this._summary = value;
			}
		}

		public string TaskRemark
		{
			get
			{
				return this._taskremark;
			}
			set
			{
				this._taskremark = value;
			}
		}

		public TaskListInfo()
		{
		}
	}
}