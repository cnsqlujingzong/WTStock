using System;

namespace wt.Model
{
	public class AllocateDetailInfo
	{
		private int _id;

		private string _remark;

		private decimal? _costprice;

		private int? _billid;

		private int? _stockid;

		private int? _goodsid;

		private int? _unitid;

		private decimal? _appqty;

		private decimal? _sndqty;

		private decimal? _recqty;

		private decimal? _price;

		private string _sn;

		public decimal? AppQty
		{
			get
			{
				return this._appqty;
			}
			set
			{
				this._appqty = value;
			}
		}

		public int? BillID
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

		public decimal? CostPrice
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

		public int? GoodsID
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

		public decimal? Price
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

		public decimal? RecQty
		{
			get
			{
				return this._recqty;
			}
			set
			{
				this._recqty = value;
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

		public decimal? SndQty
		{
			get
			{
				return this._sndqty;
			}
			set
			{
				this._sndqty = value;
			}
		}

		public int? StockID
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

		public int? UnitID
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

		public AllocateDetailInfo()
		{
		}
	}
}