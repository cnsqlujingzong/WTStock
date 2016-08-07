using System;

namespace wt.Model
{
	public class CiteAccountInfo
	{
		private int _id;

		private int? _arrearageid;

		private int? _incomeexpensesid;

		private decimal? _money;

		public int? ArrearageID
		{
			get
			{
				return this._arrearageid;
			}
			set
			{
				this._arrearageid = value;
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

		public int? IncomeExpensesID
		{
			get
			{
				return this._incomeexpensesid;
			}
			set
			{
				this._incomeexpensesid = value;
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

		public CiteAccountInfo()
		{
		}
	}
}