using System;

namespace wt.Model
{
	public class CoordinatesInfo
	{
		private int _staffid;

		private string _staffName;

		private int _deptid;

		private DateTime _createTime;

		private string _coordinate;

		public string Coordinate
		{
			get
			{
				return this._coordinate;
			}
			set
			{
				this._coordinate = value;
			}
		}

		public DateTime CreateTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				this._createTime = value;
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

		public int StaffID
		{
			get
			{
				return this._staffid;
			}
			set
			{
				this._staffid = value;
			}
		}

		public string StaffName
		{
			get
			{
				return this._staffName;
			}
			set
			{
				this._staffName = value;
			}
		}

		public CoordinatesInfo()
		{
		}
	}
}