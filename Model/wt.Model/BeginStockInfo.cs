using System;

namespace wt.Model
{
	public class BeginStockInfo
	{
		private int _deptid;

		private int _stockid;

		private int _goodsid;

		private decimal _beginstock;

		private decimal _begincost;

		public decimal BeginCost
		{
			get
			{
				return this._begincost;
			}
			set
			{
				this._begincost = value;
			}
		}

		public decimal BeginStock
		{
			get
			{
				return this._beginstock;
			}
			set
			{
				this._beginstock = value;
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

		public int GoodsID
		{
			get
			{
				return this._goodsid;
			}
			set
			{
				this._goodsid = value;
			}
		}

		public int StockID
		{
			get
			{
				return this._stockid;
			}
			set
			{
				this._stockid = value;
			}
		}

		public BeginStockInfo()
		{
		}
	}
}