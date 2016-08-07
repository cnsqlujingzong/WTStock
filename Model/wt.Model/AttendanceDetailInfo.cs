using System;

namespace wt.Model
{
	public class AttendanceDetailInfo
	{
		private int _id;

		private string __date;

		private int _ioperator;

		private int _properties;

		private string _worktime;

		private string _afterworktime;

		private decimal _absencedmoney;

		private decimal _latedmoney;

		private decimal _leftearlydmoney;

		private string _remark;

		private string _absencetype;

		private int _chkoperatorid;

		private DateTime _chkdate;

		public string _Date
		{
			get
			{
				return this.__date;
			}
			set
			{
				this.__date = value;
			}
		}

		public decimal AbsencedMoney
		{
			get
			{
				return this._absencedmoney;
			}
			set
			{
				this._absencedmoney = value;
			}
		}

		public string AbsenceType
		{
			get
			{
				return this._absencetype;
			}
			set
			{
				this._absencetype = value;
			}
		}

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

		public DateTime ChkDate
		{
			get
			{
				return this._chkdate;
			}
			set
			{
				this._chkdate = value;
			}
		}

		public int ChkOperatorID
		{
			get
			{
				return this._chkoperatorid;
			}
			set
			{
				this._chkoperatorid = value;
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

		public int iOperator
		{
			get
			{
				return this._ioperator;
			}
			set
			{
				this._ioperator = value;
			}
		}

		public decimal LatedMoney
		{
			get
			{
				return this._latedmoney;
			}
			set
			{
				this._latedmoney = value;
			}
		}

		public decimal LeftEarlydMoney
		{
			get
			{
				return this._leftearlydmoney;
			}
			set
			{
				this._leftearlydmoney = value;
			}
		}

		public int Properties
		{
			get
			{
				return this._properties;
			}
			set
			{
				this._properties = value;
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

		public AttendanceDetailInfo()
		{
		}
	}
}