using System;

namespace wt.Model
{
	public class AbsenceSetInfo
	{
		private int _id;

		private int _deptid;

		private string _type;

		private decimal _dmoney;

		private string _remark;

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

		public decimal dMoney
		{
			get
			{
				return this._dmoney;
			}
			set
			{
				this._dmoney = value;
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

		public string Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		public AbsenceSetInfo()
		{
		}
	}
}