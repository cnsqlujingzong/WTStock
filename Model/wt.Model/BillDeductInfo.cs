using System;

namespace wt.Model
{
	public class BillDeductInfo
	{
		private int _id;

		private int _billid;

		private int _deptid;

		private int _staffid;

		private DateTime _time_over;

		private DateTime _time_finish;

		private decimal _deduct;

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

		public decimal Deduct
		{
			get
			{
				return this._deduct;
			}
			set
			{
				this._deduct = value;
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

		public DateTime Time_Finish
		{
			get
			{
				return this._time_finish;
			}
			set
			{
				this._time_finish = value;
			}
		}

		public DateTime Time_Over
		{
			get
			{
				return this._time_over;
			}
			set
			{
				this._time_over = value;
			}
		}

		public BillDeductInfo()
		{
		}
	}
}