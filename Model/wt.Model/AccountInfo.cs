using System;

namespace wt.Model
{
	[Serializable]
	public class AccountInfo
	{
		private int _id;

		private int? _deptid;

		private string __name;

		private decimal? _money;

		private string _remark;

		private decimal _beginmoney;

		private int _beginstatus;

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

		public decimal BeginMoney
		{
			get
			{
				return this._beginmoney;
			}
			set
			{
				this._beginmoney = value;
			}
		}

		public int BeginStatus
		{
			get
			{
				return this._beginstatus;
			}
			set
			{
				this._beginstatus = value;
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

		public decimal? Money
		{
			get
			{
				return this._money;
			}
			set
			{
				this._money = value;
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

		public AccountInfo()
		{
		}
	}
}