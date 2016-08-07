using System;

namespace wt.Model
{
	public class GoodsUnitInfo
	{
		private int _id;

		private decimal? _pricewholesale1;

		private decimal? _pricewholesale2;

		private decimal? _pricewholesale3;

		private int? _goodsid;

		private int? _unitid;

		private bool _bbase;

		private decimal? _unitrelation;

		private string _barcode;

		private decimal? _pricedetail;

		private decimal? _pricecost;

		private decimal? _priceinner;

		private decimal _lowprice;

		public string BarCode
		{
			get
			{
				return this._barcode;
			}
			set
			{
				this._barcode = value;
			}
		}

		public bool bBase
		{
			get
			{
				return this._bbase;
			}
			set
			{
				this._bbase = value;
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

		public decimal LowPrice
		{
			get
			{
				return this._lowprice;
			}
			set
			{
				this._lowprice = value;
			}
		}

		public decimal? PriceCost
		{
			get
			{
				return this._pricecost;
			}
			set
			{
				this._pricecost = value;
			}
		}

		public decimal? PriceDetail
		{
			get
			{
				return this._pricedetail;
			}
			set
			{
				this._pricedetail = value;
			}
		}

		public decimal? PriceInner
		{
			get
			{
				return this._priceinner;
			}
			set
			{
				this._priceinner = value;
			}
		}

		public decimal? PriceWholesale1
		{
			get
			{
				return this._pricewholesale1;
			}
			set
			{
				this._pricewholesale1 = value;
			}
		}

		public decimal? PriceWholesale2
		{
			get
			{
				return this._pricewholesale2;
			}
			set
			{
				this._pricewholesale2 = value;
			}
		}

		public decimal? PriceWholesale3
		{
			get
			{
				return this._pricewholesale3;
			}
			set
			{
				this._pricewholesale3 = value;
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

		public decimal? UnitRelation
		{
			get
			{
				return this._unitrelation;
			}
			set
			{
				this._unitrelation = value;
			}
		}

		public GoodsUnitInfo()
		{
		}
	}
}