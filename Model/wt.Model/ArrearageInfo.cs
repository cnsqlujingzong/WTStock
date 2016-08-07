using System;

namespace wt.Model
{
	[Serializable]
	public class ArrearageInfo
	{
		private int _id;

		private int? _deptid;

		private int? _custype;

		private int? _customerid;

		private decimal _rec;

		private decimal _due;

		private decimal _balance;

		public decimal Balance
		{
			get
			{
				return this._balance;
			}
			set
			{
				this._balance = value;
			}
		}

		public int? CustomerID
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

		public int? CusType
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

		public int? DeptID
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

		public decimal Due
		{
			get
			{
				return this._due;
			}
			set
			{
				this._due = value;
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

		public decimal Rec
		{
			get
			{
				return this._rec;
			}
			set
			{
				this._rec = value;
			}
		}

		public ArrearageInfo()
		{
		}
	}
}