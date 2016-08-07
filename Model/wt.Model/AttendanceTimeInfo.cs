using System;

namespace wt.Model
{
	public class AttendanceTimeInfo
	{
		private int _id;

		private int _deptid;

		private string _worktime;

		private string _afterworktime;

		private string _week;

		private string _remark;

		public string AfterWorkTime
		{
			get
			{
				return this._afterworktime;
			}
			set
			{
				this._afterworktime = value;
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

		public string Week
		{
			get
			{
				return this._week;
			}
			set
			{
				this._week = value;
			}
		}

		public string WorkTime
		{
			get
			{
				return this._worktime;
			}
			set
			{
				this._worktime = value;
			}
		}

		public AttendanceTimeInfo()
		{
		}
	}
}