using System;

namespace wt.Model
{
	public class StockDeptInfo
	{
		private int _id;

		private decimal _checkcount;

		private string _remark;

		private int _deptid;

		private int _stockid;

		private int _goodsid;

		private int _stocklocid;

		private decimal _stock;

		private decimal _costprice;

		private decimal _upwarning;

		private decimal _downwarning;

		private string _goodsno;

		private string __name;

		private string _stockname;

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

		public decimal CheckCount
		{
			get
			{
				return this._checkcount;
			}
			set
			{
				this._checkcount = value;
			}
		}

		public decimal CostPrice
		{
			get
			{
				return this._costprice;
			}
			set
			{
				this._costprice = value;
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

		public decimal downWarning
		{
			get
			{
				return this._downwarning;
			}
			set
			{
				this._downwarning = value;
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

		public string GoodsNO
		{
			get
			{
				return this._goodsno;
			}
			set
			{
				this._goodsno = value;
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

		public decimal Stock
		{
			get
			{
				return this._stock;
			}
			set
			{
				this._stock = value;
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

		public int StockLocID
		{
			get
			{
				return this._stocklocid;
			}
			set
			{
				this._stocklocid = value;
			}
		}

		public string StockName
		{
			get
			{
				return this._stockname;
			}
			set
			{
				this._stockname = value;
			}
		}

		public decimal upWarning
		{
			get
			{
				return this._upwarning;
			}
			set
			{
				this._upwarning = value;
			}
		}

		public StockDeptInfo()
		{
		}
	}
}