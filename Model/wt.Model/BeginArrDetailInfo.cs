using System;

namespace wt.Model
{
	public class BeginArrDetailInfo
	{
		private int _deptid;

		private int _customerid;

		private int _custype;

		private decimal _drec;

		private decimal _ddue;

		public int CustomerID
		{
			get
			{
				return this._customerid;
			}
			set
			{
				this._customerid = value;
			}
		}

		public int CusType
		{
			get
			{
				return this._custype;
			}
			set
			{
				this._custype = value;
			}
		}

		public decimal dDue
		{
			get
			{
				return this._ddue;
			}
			set
			{
				this._ddue = value;
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

		public decimal dRec
		{
			get
			{
				return this._drec;
			}
			set
			{
				this._drec = value;
			}
		}

		public BeginArrDetailInfo()
		{
		}
	}
}