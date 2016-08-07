using System;

namespace wt.Model
{
	public class UserManageInfo
	{
		private int _id;

		private int _deptid;

		private int _staffid;

		private string _pwd;

		private string _status;

		private int _rightid;

		private string _right;

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

		public string Pwd
		{
			get
			{
				return this._pwd;
			}
			set
			{
				this._pwd = value;
			}
		}

		public string Right
		{
			get
			{
				return this._right;
			}
			set
			{
				this._right = value;
			}
		}

		public int RightID
		{
			get
			{
				return this._rightid;
			}
			set
			{
				this._rightid = value;
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

		public UserManageInfo()
		{
		}
	}
}