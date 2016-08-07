using System;

namespace Model
{
	public class UserExceptionInfo
	{
		private int _id;

		private int _staffID;

		private string _staffName;

		private string _remark;

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

		public int StaffID
		{
			get
			{
				return this._staffID;
			}
			set
			{
				this._staffID = value;
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

		public UserExceptionInfo()
		{
		}
	}
}