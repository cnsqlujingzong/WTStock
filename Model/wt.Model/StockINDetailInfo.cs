using System;

namespace wt.Model
{
	public class StockINDetailInfo
	{
		private int _id;

		private string _remark;

		private int _billid;

		private int _stockid;

		private int _goodsid;

		private int _unitid;

		private decimal _qty;

		private decimal _price;

		private decimal? _total;

		private int? _snid;

		private string _sn;

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

		public decimal Price
		{
			get
			{
				return this._price;
			}
			set
			{
				this._price = value;
			}
		}

		public decimal Qty
		{
			get
			{
				return this._qty;
			}
			set
			{
				this._qty = value;
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

		public string SN
		{
			get
			{
				return this._sn;
			}
			set
			{
				this._sn = value;
			}
		}

		public int? SNID
		{
			get
			{
				return this._snid;
			}
			set
			{
				this._snid = value;
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

		public decimal? Total
		{
			get
			{
				return this._total;
			}
			set
			{
				this._total = value;
			}
		}

		public int UnitID
		{
			get
			{
				return this._unitid;
			}
			set
			{
				this._unitid = value;
			}
		}

		public StockINDetailInfo()
		{
		}
	}
}