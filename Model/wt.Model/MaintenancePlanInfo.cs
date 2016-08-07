using System;

namespace wt.Model
{
	public class MaintenancePlanInfo
	{
		private int _id;

		private int _devid;

		private int _deptid;

		private string __name;

		private string _startdate;

		private string _enddate;

		private string _timingstyle;

		private int _maintenancecycle;

		private int _remindday;

		private string _remark;

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

		public int DevID
		{
			get
			{
				return this._devid;
			}
			set
			{
				this._devid = value;
			}
		}

		public string EndDate
		{
			get
			{
				return this._enddate;
			}
			set
			{
				this._enddate = value;
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

		public int MaintenanceCycle
		{
			get
			{
				return this._maintenancecycle;
			}
			set
			{
				this._maintenancecycle = value;
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

		public int RemindDay
		{
			get
			{
				return this._remindday;
			}
			set
			{
				this._remindday = value;
			}
		}

		public string StartDate
		{
			get
			{
				return this._startdate;
			}
			set
			{
				this._startdate = value;
			}
		}

		public string TimingStyle
		{
			get
			{
				return this._timingstyle;
			}
			set
			{
				this._timingstyle = value;
			}
		}

		public MaintenancePlanInfo()
		{
		}
	}
}